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

namespace Presentation
{
    public partial class frmProgram : Form
    {
        RadioBusiness radioBusiness = new RadioBusiness();
        ProgramBusiness programBusiness = new ProgramBusiness();
        SprinklerBusiness sprinklerBusiness = new SprinklerBusiness();
        List<ProgramEntity> programList = new List<ProgramEntity>();
        List<ProgramEntity> programs = null;
        List<ProgramEntity> sent = new List<ProgramEntity>();
        List<ProgramEntity> late = new List<ProgramEntity>();
        List<ProgramEntity> fail = new List<ProgramEntity>();
        public frmProgram()
        {
            InitializeComponent();
            int radios = radioBusiness.Quantity();
            cbxRadios.Items.Clear();
            for (int i = 1; i <= radios; i++)
                cbxRadios.Items.Add("Radio " + i);
            LoadPrograms();
            clock_Tick(null, null);

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
            int id = radioBusiness.PrevQuantity(cbxRadios.SelectedIndex + 1) + cbxSprinklers.SelectedIndex + 1;
            programBusiness.Create(id, dtpTime.Value.ToString("HH:mm"), rbOn.Checked ? 1 : 0);
            ListShowPrograms();
            LoadPrograms();
        }

        private void cbxSprinklers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListShowPrograms();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm");
            
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
                        int min = 10;
                        string[] t = program.ActionTime.Split(':');
                        int newHour = (int.Parse(t[0])) + ((int.Parse(t[1]) + min) / 60);
                        int newMinute = (int.Parse(t[1]) + min) % 60;
                        string newTime = newHour.ToString().PadLeft(2, '0') + ":" + newMinute.ToString().PadLeft(2, '0');
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

            lblProgramados.Text = "Monitoreando: " + programList.Count + " actividades a las " + time;
            lblExecuting.Text = "En ejecucion: " + sent.Count.ToString();
            lblLate.Text = "Tarde: " + late.Count.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = programs[lbxPrograms.SelectedIndex].ProgramID;
            programBusiness.Delete(id);
            LoadPrograms();
            ListShowPrograms();
            clock_Tick(null, null);
        }
    }
}
