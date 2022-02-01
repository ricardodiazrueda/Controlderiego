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
    public partial class ProgramarHorarios : Form
    {
        Usuario usuario = null;
        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<Programa> programasEncendido = null;
        List<Programa> programasApagado = null;
        public ProgramarHorarios(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            int radios = BaseDatos.LeerCantidadRadios();
            int k = 0;
            for (int i = 1; i <= radios; i++)
            {
                List<Solenoide> solenoides = BaseDatos.LeerSolenoidesPorRadio(i);
                AgregarSolenoides(solenoides, i, 240 * (k % 2) + 30, 70 * (k++ / 2) + 30);
            }

            dtpHora.Value = DateTime.Now;
            LlenarListasProgramas();
        }
        void AgregarSolenoides(List<Solenoide> solenoides, int radio, int x, int y)
        {
            int k = 0;
            int ancho = 50, alto = 20;

            this.SuspendLayout();

            Label label = new Label();
            label.AutoSize = true;
            label.Text = "Radio " + radio;
            label.Location = new Point(x, y - 20);
            panel1.Controls.Add(label);

            foreach (Solenoide solenoide in solenoides)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Text = solenoide.SolenoideID.ToString();
                checkBox.Location = new Point((k % 4) * ancho + x , (k / 4) * alto + y);
                checkBox.Tag = solenoide;

                k++;
                panel1.Controls.Add(checkBox);
                checkBoxes.Add(checkBox);
                this.ResumeLayout(false);
            }
        }


        void LlenarListasProgramas()
        {
            List<Programa> programas = BaseDatos.LeerTodosProgramas();

            programasEncendido = programas.FindAll(x => x.Accion == true);
            programasApagado = programas.FindAll(x => x.Accion == false);

            lbxEncender.DataSource = null;
            lbxEncender.DataSource = programasEncendido;
            lbxEncender.SelectedIndex = -1;

            lbxApagar.DataSource = null;
            lbxApagar.DataSource = programasApagado;
            lbxApagar.SelectedIndex = -1;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkBox in checkBoxes)
                checkBox.Checked = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (cbxEstado.SelectedIndex != -1)
            {
                if (cbxDia.SelectedIndex != -1)
                {
                    bool accion = cbxEstado.SelectedIndex == 1;
                    string hora = cbxDia.SelectedIndex + " " + dtpHora.Value.ToString("HH:mm");
                    foreach (CheckBox checkBox in checkBoxes)
                    {
                        if (checkBox.Checked)
                        {
                            Solenoide solenoide = checkBox.Tag as Solenoide;

                            Programa programa = new Programa();
                            programa.SolenoideID = solenoide.SolenoideID;
                            programa.Hora = hora;
                            programa.Accion = accion;

                            BaseDatos.CrearPrograma(programa);
                            BaseDatos.CrearLog(new Log() { Tipo = "Crear Programa", Info = usuario.Nombre + " creó un programa para " + (programa.Accion ? "encender" : "apagar") + " el solenoide " + programa.ToString() });
                        }
                    }
                    LlenarListasProgramas();
                }
                else
                    MessageBox.Show("Seleccione el día");
            }
            else
                MessageBox.Show("Seleccione el estado del solenoide");

        }

        private void btnBorrarTodos_Click(object sender, EventArgs e)
        {
            BaseDatos.BorrarTodosProgramas();
            BaseDatos.CrearLog(new Log() { Tipo = "Crear Programa", Info = usuario.Nombre + " borró todos los programas" });
            LlenarListasProgramas();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lbxEncender.SelectedIndex != -1)
            {
                Programa programa = programasEncendido[lbxEncender.SelectedIndex];
                BaseDatos.BorrarPrograma(programa);
                BaseDatos.CrearLog(new Log() { Tipo = "Crear Programa", Info = usuario.Nombre + " borró el programa para " + (programa.Accion ? "encender" : "apagar") + " el solenoide " + programa.ToString() });
            }

            if (lbxApagar.SelectedIndex != -1)
            {
                Programa programa = programasApagado[lbxApagar.SelectedIndex];
                BaseDatos.BorrarPrograma(programa);
                BaseDatos.CrearLog(new Log() { Tipo = "Crear Programa", Info = usuario.Nombre + " borró el programa para " + (programa.Accion ? "encender" : "apagar") + " el solenoide " + programa.ToString() });
            }

            LlenarListasProgramas();
        }
    }
}
