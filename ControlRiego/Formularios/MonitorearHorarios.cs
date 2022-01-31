using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlRiego
{
    public partial class MonitorearHorarios : Form
    {
        Usuario usuario = null;
        int reprogramacion = 1; // en cuantos minutos se reprograma

        List<Programa> programasEsperando;
        List<Programa> programasEnviados = new List<Programa>();
        List<Programa> programasReprogramados = new List<Programa>();
        List<Programa> programasFallados = new List<Programa>();
        List<Programa> programasEjecutados = new List<Programa>();

        public MonitorearHorarios(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            lblHora.Text = "Dia, fecha y hora: " + DateTime.Now.ToString("U");

            programasEsperando = BaseDatos.LeerTodosProgramas();

            Serial.callback = (radio, solenoide, accion) =>
            {
                // Buscar el que respondió
                Solenoide sol = BaseDatos.LeerSolenoidePorRadioNumero(radio, solenoide);
                if (sol != null)
                {
                    Programa programa = programasEnviados.Find(x => x.SolenoideID == sol.SolenoideID && x.Accion == (accion == 'E'));
                    if (programa != null)
                    {
                        programasEnviados.Remove(programa);
                        programasEjecutados.Add(programa);
                        BaseDatos.CrearLog(new Log() { Tipo = "Monitorear Programa", Info = "¡Correcto! - Pograma para " + (programa.Accion ? "encender" : "apagar") + " el solenoide " + programa.ToString() });
                    }
                }
            };
        }
        string ObtenerHora()
        {
            string dia = DateTime.Now.ToString("dddd");
            string hora = DateTime.Now.ToString("HH:mm");

            if (dia == "domingo")
                dia = "0 ";
            else if (dia == "lunes")
                dia = "1 ";
            else if (dia == "martes")
                dia = "2 ";
            else if (dia == "miércoles")
                dia = "3 ";
            else if (dia == "jueves")
                dia = "4 ";
            else if (dia == "viernes")
                dia = "5 ";
            else if (dia == "sábado")
                dia = "6 ";

            return dia + hora;
        }
        string AumentarHora(string horaStr, int minutos)
        {
            // "0 12:03"
            int dia = horaStr[0] - '0';
            int hora = Convert.ToInt32(horaStr.Substring(2, 2));
            int minuto = Convert.ToInt32(horaStr.Substring(5, 2));

            minuto += minutos;
            if (minuto >= 60)
            {
                hora += minuto / 60;
                minuto = minuto % 60;
            }

            if (hora >= 24)
            {
                dia += hora / 24;
                hora = hora % 24;
            }

            return dia + " " + hora.ToString().PadLeft(2, '0') + ":" + minuto.ToString().PadLeft(2, '0');
        }

        void LlenarListasProgramas()
        {
            lbxEsperando.DataSource = null;
            lbxEsperando.DataSource = programasEsperando;
            lbxEsperando.SelectedIndex = -1;

            lbxEnviado.DataSource = null;
            lbxEnviado.DataSource = programasEnviados;
            lbxEnviado.SelectedIndex = -1;

            lbxReprogramado.DataSource = null;
            lbxReprogramado.DataSource = programasReprogramados;
            lbxReprogramado.SelectedIndex = -1;

            lbxFinalizado.DataSource = null;
            lbxFinalizado.DataSource = programasEjecutados;
            lbxFinalizado.SelectedIndex = -1;

            lbxFallados.DataSource = null;
            lbxFallados.DataSource = programasFallados;
            lbxFallados.SelectedIndex = -1;
        }

        private void marcapasos_Tick(object sender, EventArgs e)
        {
            string hora = ObtenerHora();

            // Obtener el primero a mandar
            Programa porEjecutar = programasEsperando.Find(x => x.Hora == hora);
            if (porEjecutar != null)
            {
                Solenoide solenoide = BaseDatos.LeerSolenoidePorID(porEjecutar.SolenoideID);
                string msg = solenoide.ToString() + (porEjecutar.Accion ? "E" : "A");
                Serial.Send(msg);
                programasEsperando.Remove(porEjecutar);
                programasEnviados.Add(porEjecutar);
            }
            else
            {
                // Enviar los reprogramados
                porEjecutar = programasReprogramados.Find(x => x.Hora == hora);
                if (porEjecutar != null)
                {
                    Solenoide solenoide = BaseDatos.LeerSolenoidePorID(porEjecutar.SolenoideID);
                    string msg = solenoide.ToString() + (porEjecutar.Accion ? "E" : "A");
                    Serial.Send(msg);
                    programasReprogramados.Remove(porEjecutar);
                    programasEnviados.Add(porEjecutar);
                }
            }

            // Retirar todos los retrasados
            List<Programa> programasTarde = programasEnviados.FindAll(x => x.Hora != hora);
            if (programasTarde.Count > 0)
            {
                foreach (Programa tarde in programasTarde)
                {
                    if (tarde.Intento < 3)
                    {
                        Programa reprogramado = new Programa();
                        reprogramado.ProgramaID = -1;
                        reprogramado.SolenoideID = tarde.SolenoideID;
                        reprogramado.Accion = tarde.Accion;
                        reprogramado.Hora = AumentarHora(tarde.Hora, reprogramacion);
                        reprogramado.Intento = tarde.Intento + 1;
                        if (tarde.Original == null)
                            reprogramado.Original = tarde;
                        else
                            reprogramado.Original = tarde.Original;

                        programasEnviados.Remove(tarde);
                        programasReprogramados.Add(reprogramado);
                    }
                    else
                    {
                        programasEnviados.Remove(tarde);
                        programasFallados.Add(tarde.Original);
                        BaseDatos.CrearLog(new Log() { Tipo = "Monitorear Programa", Info = "¡Fallado! - Pograma para " + (tarde.Original.Accion ? "encender" : "apagar") + " el solenoide " + tarde.Original.ToString() });
                    }
                }
            }
        }
        private void reloj_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Dia, fecha y hora: " + DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
            LlenarListasProgramas();
        }
    }
}
