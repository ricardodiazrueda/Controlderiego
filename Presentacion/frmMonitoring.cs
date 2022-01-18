using Business;
using Comunication;
using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmMonitoring : Form
    {
        LogData logData = new LogData();

        ProgramBusiness programBusiness = new ProgramBusiness();
        SprinklerBusiness sprinklerBusiness = new SprinklerBusiness();
        RadioBusiness radioBusiness = new RadioBusiness();

        List<ProgramEntity> programList = new List<ProgramEntity>();
        List<ProgramEntity> executing = new List<ProgramEntity>();
        List<ProgramEntity> executed = new List<ProgramEntity>();
        List<ProgramEntity> reprogrammed = new List<ProgramEntity>();
        List<ProgramEntity> failed = new List<ProgramEntity>();

        ProgramEntity lastExecuted = null;

        UserEntity user = null;

        List<string> days = null;
        public frmMonitoring(UserEntity user)
        {
            InitializeComponent();
            this.user = user;

            string[] days = { "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado" };
            this.days = days.ToList();

            programList = programBusiness.GetAll();
            programList = programList.OrderBy(x => x.SprinklerID).ToList();

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
                    logData.Insert(new LogEntity() { Type = "SOLENOIDE PROGRAM COMPLETE", Data = "El solenoide " + i_id + " se " + ((action == 1) ? "prendió" : "apagó") + "correctamente", EntityID = i_id });


                    List<ProgramEntity> found = executing.FindAll(x => x.SprinklerID == i_id && x.Action == action);
                    foreach (ProgramEntity entity in found)
                    {
                        entity.Finish = true;
                    }
                }
            };

            ShowData();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("dddd HH:mm");
            lastExecuted = null;

            //Mandar la señal de uno de los que le toca ejecutarse 
            List<ProgramEntity> toExecute = programList.FindAll(x => x.ActionTime == time);
            if (toExecute.Count > 0)
                Execute(toExecute[0]);
            else
            {
                toExecute = reprogrammed.FindAll(x => x.ActionTime == time);
                if (toExecute.Count > 0)
                    Execute(toExecute[0]);
            }

            // Borrar de la lista de 'en ejecucion'
            executed.AddRange(executing.FindAll(x => x.Finish));
            executing.RemoveAll(x => x.Finish);

            // Borrar de la lista de tardados si alguno llegó
            executed.AddRange(reprogrammed.FindAll(x => x.previus.Finish));
            reprogrammed.RemoveAll(x => x.previus.Finish);

            // Ver cuales se tardaron y reprogramarlos
            List<ProgramEntity> late = executing.FindAll(x => x.previus == null && x.ActionTime != time);
            foreach (ProgramEntity program in late)
            {
                int min = 1;
                string[] data = program.ActionTime.Split(' ');
                string[] t = data[1].Split(':');
                int newHour = (int.Parse(t[0]) + ((int.Parse(t[1]) + min) / 60)) % 24;
                int newMinute = (int.Parse(t[1]) + min) % 60;
                int newDay = days.IndexOf(data[0]) + ((int.Parse(t[0]) + ((int.Parse(t[1]) + min) / 60)) / 24) % 7;
                string newTime = days[newDay] + " " + newHour.ToString().PadLeft(2, '0') + ":" + newMinute.ToString().PadLeft(2, '0');
                program.Sent = false;
                reprogrammed.Add(new ProgramEntity() { Action = program.Action, SprinklerID = program.SprinklerID, Finish = false, ActionTime = newTime, ProgramID = -1, previus = program });
            }
            executing.RemoveAll(x => x.previus == null && x.ActionTime != time);

            // Ver cuales reprogramados no funcionaron
            List<ProgramEntity> fail = executing.FindAll(x => x.previus != null && x.ActionTime != time && x.Sent == true);
            executing.RemoveAll(x => x.previus != null && x.ActionTime != time && x.Sent == true);
            foreach (ProgramEntity F in fail)
                failed.Add(F.previus);

            ShowData();
        }
        void Execute(ProgramEntity program)
        {
            if (program.previus == null)
                programList.Remove(program);
            else
                reprogrammed.Remove(program);

            int message = program.SprinklerID * 2 - program.Action;
            Serial.Send(message.ToString());
            program.Sent = true;

            lastExecuted = program;
            executing.Add(program);
        }
        void ShowData()
        {
            grbMonitoring.Text = "En monitoreo: " + programList.Count.ToString();
            lbProgramOn.DataSource = null;
            lbProgramOn.DataSource = programList.FindAll(x => x.Action == 1);
            lbProgramOff.DataSource = null;
            lbProgramOff.DataSource = programList.FindAll(x => x.Action == 0);

            grbExecuted.Text = "Ejecutadas correctamente: " + executed.Count.ToString();
            lbExecutedOn.DataSource = null;
            lbExecutedOn.DataSource = executed.FindAll(x => x.Action == 1);
            lbExecutedOff.DataSource = null;
            lbExecutedOff.DataSource = executed.FindAll(x => x.Action == 0);

            grbReprogramed.Text = "Reprogramadas: " + reprogrammed.Count.ToString();
            lbReprogramedOn.DataSource = null;
            lbReprogramedOn.DataSource = reprogrammed.FindAll(x => x.Action == 1);
            lbReprogramedOff.DataSource = null;
            lbReprogramedOff.DataSource = reprogrammed.FindAll(x => x.Action == 0);

            grbFailed.Text = "Fallidas: " + failed.Count.ToString();
            lbFailedOn.DataSource = null;
            lbFailedOn.DataSource = failed.FindAll(x => x.Action == 1);
            lbFailedOff.DataSource = null;
            lbFailedOff.DataSource = failed.FindAll(x => x.Action == 0);

            lblExecuting.Text = "En ejecución: " + executing.Count.ToString();
            lbExecuting.DataSource = null;
            lbExecuting.DataSource = executing;

            if (lastExecuted != null)
                lblLast.Text = lastExecuted.ToString();
            else
                lblLast.Text = "";
        }
    }
}
