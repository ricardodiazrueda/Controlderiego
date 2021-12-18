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

                    if (s_action == "OON")
                    {
                        sprinklerBusiness.SetState(i_id, 1);
                    }
                    else
                    {
                        sprinklerBusiness.SetState(i_id, 0);
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
                int on = program.SprinklerID * 2 - 1;
                int off = program.SprinklerID * 2;

                if (program.Action == 1)
                {
                    Serial.Send(on.ToString());
                }
                else
                {
                    Serial.Send(off.ToString());
                }
            }

            lblProgramados.Text = "Monitoreando: " + programList.Count + " actividades a las " + time;
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
