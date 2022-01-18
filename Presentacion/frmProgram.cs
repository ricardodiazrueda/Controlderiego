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
            new frmMonitoring(user).ShowDialog();
            return;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            logData.Insert(new LogEntity() { Type = "SOLENOIDE PROGRAM", Data = user.FullName + " eliminó todos los programas", EntityID = user.UserID });

            programBusiness.Delete();
            LoadPrograms();
            ListShowPrograms();
        }
    }
}