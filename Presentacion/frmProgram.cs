using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Comunication;
using Data;

namespace Presentation
{
    public partial class frmProgram : Form
    {
        RadioBusiness radioBusiness = new RadioBusiness();
        ProgramBusiness programBusiness = new ProgramBusiness();
        SprinklerBusiness sprinklerBusiness = new SprinklerBusiness();
        List<ProgramEntity> programList = new List<ProgramEntity>();
        LogData logData = new LogData();

        List<ProgramEntity> programs = null;
        List<ProgramEntity> sent = new List<ProgramEntity>();
        List<ProgramEntity> late = new List<ProgramEntity>();
        List<ProgramEntity> done = new List<ProgramEntity>();
        List<ProgramEntity> fail = new List<ProgramEntity>();

        List<string> days = null;
        UserEntity user = null;
        public frmProgram(UserEntity user)
        {
            InitializeComponent();
            int radios = radioBusiness.Quantity();
            cbxRadios.Items.Clear();
            for (int i = 1; i <= radios; i++)
                cbxRadios.Items.Add("Radio " + i);
            LoadPrograms();
            this.user = user;

            string[] days = { "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado" };
            this.days = days.ToList();

            Serial.callback = (data) =>
            {
                if (data.Contains(".D"))
                {
                    // data = "ME0301OON.D";
                    string s_radio = data.Substring(2, 2);
                    string s_sprinkler = data.Substring(4, 2);
                    string s_action = data.Substring(6, 3);

                    int i_radio = Convert.ToInt32(s_radio);
                    int i_sprinkler = Convert.ToInt32(s_sprinkler);

                    int i_id = radioBusiness.PrevQuantity(i_radio) + i_sprinkler;

                    int action = 0;
                    if (s_action == "OON")
                        action = 1;
                    
                    sprinklerBusiness.SetState(i_id, action);

                    List<ProgramEntity> found = sent.FindAll(x => x.SprinklerID == i_id && x.Action == action);
                    foreach (ProgramEntity entity in found)
                    {
                        entity.Finish = true;
                    }
                }
            };
        }
        void LoadPrograms()
        {
            programList = programBusiness.GetAll();
        }
        private void cbxRadios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sprinklers = radioBusiness.GetSprinklers(cbxRadios.SelectedIndex + 1);
            cbxSprinklers.Items.Clear();
            for (int i = 1; i <= sprinklers; i++)
                cbxSprinklers.Items.Add("Solenoide " + i);
        }
        void ListShowPrograms()
        {
            int id = radioBusiness.PrevQuantity(cbxRadios.SelectedIndex + 1) + cbxSprinklers.SelectedIndex + 1;
            programs = programBusiness.GetPrograms(id);

            programs = programs.OrderBy(x => x.ActionTime).ToList();

            lbxPrograms.DataSource = null;
            lbxPrograms.DataSource = programs;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxRadios.SelectedIndex != -1 && cbxSprinklers.SelectedIndex != -1 && cbxDay.SelectedIndex != -1)
            {
                int id = radioBusiness.PrevQuantity(cbxRadios.SelectedIndex + 1) + cbxSprinklers.SelectedIndex + 1;
                string date = cbxDay.Text + " " + dtpTime.Value.ToString("HH:mm");
                programBusiness.Create(id, date, rbOn.Checked ? 1 : 0);
                logData.Insert(new LogEntity() { Type = "SOLENOIDE PROGRAM", Data = user.FullName + " programó el solenoide " + id + " para " + (rbOn.Checked ? "encenderse" : "apagarse") +  " el dia " + date, EntityID = user.UserID });
                ListShowPrograms();
                LoadPrograms();
            }
        }

        private void cbxSprinklers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListShowPrograms();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("dddd HH:mm");
            
            List<ProgramEntity> found = programList.FindAll(x => x.ActionTime == time);
            foreach (ProgramEntity program in found)
            {
                bool exist = sent.Exists(x => x.ActionTime == program.ActionTime && x.Action == program.Action && x.SprinklerID == program.SprinklerID);
                if (!exist || (exist && !program.Finish))
                {
                    if (program.Action == 1)
                    {
                        int on = program.SprinklerID * 2 - 1;
                        Serial.Send(on.ToString());
                    }
                    else
                    {
                        int off = program.SprinklerID * 2;
                        Serial.Send(off.ToString());
                    }

                    if (!exist)
                    {
                        program.Finish = false;
                        sent.Add(program);
                    }
                }
            }

            found = late.FindAll(x => x.ActionTime == time);
            foreach (ProgramEntity program in found)
            {
                bool exist = sent.Exists(x => x.ActionTime == program.ActionTime && x.Action == program.Action && x.SprinklerID == program.SprinklerID);
                if (!exist || (exist && !program.Finish))
                {
                    if (program.Action == 1)
                    {
                        int on = program.SprinklerID * 2 - 1;
                        Serial.Send(on.ToString());
                    }
                    else
                    {
                        int off = program.SprinklerID * 2;
                        Serial.Send(off.ToString());
                    }

                    if (!exist)
                    {
                        program.Finish = false;
                        sent.Add(program);
                    }
                }
            }
            for (int i = 0; i < sent.Count; i++)
            {
                ProgramEntity program = sent[i];
                if (program.ProgramID != -1)
                {
                    if (program.Finish && program.ActionTime != time)
                    {
                        sent.Remove(program); i--;
                    }
                    else if (!program.Finish && program.ActionTime != time)
                    {
                        string[] data = program.ActionTime.Split(' ');
                        int min = 10;
                        string[] t = data[1].Split(':');
                        int newHour = (int.Parse(t[0]) + ((int.Parse(t[1]) + min) / 60)) % 24;
                        int newMinute = (int.Parse(t[1]) + min) % 60;
                        int newDay = days.IndexOf(data[0]) + ((int.Parse(t[0]) + ((int.Parse(t[1]) + min) / 60)) / 24) % 7;
                        string newTime = days[newDay] + " " + newHour.ToString().PadLeft(2, '0') + ":" + newMinute.ToString().PadLeft(2, '0');
                        late.Add(new ProgramEntity() { Action = program.Action, SprinklerID = program.SprinklerID, Finish = false, ActionTime = newTime, ProgramID = -1, previus = program});
                        sent.Remove(program); i--;
                    }
                }
                else
                {
                    if (program.Finish)
                    {
                        sent.Remove(program); i--;
                        late.Remove(program);
                    }
                    else if (string.Compare(program.ActionTime, time) < 0)
                    {
                        sent.Remove(program); i--;
                        late.Remove(program);
                        lbxAlerts.Items.Add(program.previus);
                    }
                }
            }

            lblProgramados.Text = "Monitoreando: " + programList.Count;
            lbProgramados.DataSource = null;
            lbProgramados.DataSource = programList;

            lblExecuting.Text = "En ejecucion: " + sent.Count.ToString();
            lbExecuting.DataSource = null;
            lbExecuting.DataSource = sent;

            lblLate.Text = "Tarde: " + late.Count.ToString();
            lbLate.DataSource = null;
            lbLate.DataSource = late;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProgramEntity program = programs[lbxPrograms.SelectedIndex];
            int id = program.ProgramID;

            logData.Insert(new LogEntity() { Type = "SOLENOIDE PROGRAM", Data = user.FullName + " eliminó la programación del solenoide " + program.SprinklerID + " para " + (program.Action == 1 ? "encenderse" : "apagarse") + " el dia " + program.ActionTime, EntityID = user.UserID });

            programBusiness.Delete(id);
            LoadPrograms();
            ListShowPrograms();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            clock.Enabled = !clock.Enabled;
            btnDelete.Enabled = !btnDelete.Enabled;
            btnAdd.Enabled = !btnAdd.Enabled;

            btnStart.BackColor = clock.Enabled ? Color.Red : Color.Green;
            btnStart.Text = clock.Enabled ? "Detener" : "Empezar";

            lblProgramados.Text = "Monitoreando: 0";
            lblExecuting.Text = "En ejecución: 0";
            lblLate.Text = "Tarde: 0";

            clock_Tick(null, null);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ProgramEntity program = programs[lbxPrograms.SelectedIndex];
            int id = program.ProgramID;

            logData.Insert(new LogEntity() { Type = "SOLENOIDE PROGRAM", Data = user.FullName + " eliminó todos los programas", EntityID = user.UserID });

            programBusiness.Delete();
            LoadPrograms();
            ListShowPrograms();
        }
    }
}