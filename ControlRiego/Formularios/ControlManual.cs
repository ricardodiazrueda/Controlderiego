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
    public partial class ControlManual : Form
    {
        List<Button> botones = new List<Button>();
        Button presionado = null;
        public ControlManual()
        {
            InitializeComponent();

            int cantidad = BaseDatos.LeerCantidadRadios();
            for (int i = 1; i <= cantidad; i++)
                cbxRadios.Items.Add("Radio " + i.ToString());

            Serial.callback = (radio, solenoide, accion) =>
            {
                Solenoide sole = BaseDatos.LeerSolenoidePorRadioNumero(radio, solenoide);
                if (sole != null)
                {
                    if (sole.Equals(presionado.Tag))
                    {
                        sole.Estado = accion == 'E';
                        BaseDatos.ModificarSolenoide(sole);
                        presionado.BackColor = sole.Estado ? Color.Green : Color.Red;
                    }
                }
            };
        }

        private void cbxRadios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRadios.SelectedIndex != -1)
            {
                List<Solenoide> solenoides = BaseDatos.LeerSolenoidesPorRadio(cbxRadios.SelectedIndex + 1);
                CrearBotones(solenoides);
            }
        }
        void CrearBotones(List<Solenoide> solenoides)
        {
            // Borrar botones antiguos
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Button)
                    this.Controls.RemoveAt(i--);
            }
            botones.Clear();

            // Nuevos botones
            int k = 0;
            int ancho = 50, alto = 50;
            foreach (Solenoide solenoide in solenoides)
            {
                Button button = new Button();
                button.Text = "Sol\n" + solenoide.SolenoideID.ToString();
                button.BackColor = solenoide.Estado ? Color.Green : Color.Red;
                button.Location = new Point((k % 4) * ancho + 20, (k / 4) * alto + 50);
                button.Size = new Size(ancho, alto);
                button.Tag = solenoide;
                button.Click += (sender, e) =>
                {
                    Button btn = sender as Button;
                    Solenoide s = btn.Tag as Solenoide;

                    string data = s.ToString() + (btn.BackColor == Color.Green ? "A" : "E");
                    Serial.Send(data);

                    presionado = btn;
                    presionado.BackColor = Color.Blue;

                    clock.Enabled = true;
                    foreach (Button button1 in botones)
                        button1.Enabled = false;
                    cbxRadios.Enabled = false;
                };
                k++;

                this.SuspendLayout();
                this.Controls.Add(button);
                botones.Add(button);
                this.ResumeLayout(false);
            }
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            Solenoide solenoide = presionado.Tag as Solenoide;
            if (presionado != null)
            {
                if (presionado.BackColor == Color.Blue)
                {
                    if (solenoide.Estado)
                        presionado.BackColor = Color.Green;
                    else
                        presionado.BackColor = Color.Red;
                }
            }

            clock.Enabled = false;
            foreach (Button button1 in botones)
                button1.Enabled = true;
            cbxRadios.Enabled = true;
        }
    }
}
