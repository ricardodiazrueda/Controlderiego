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
    public partial class ConfigurarRadios : Form
    {
        public ConfigurarRadios()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtCampo.Text != "")
            {
                if (nudSolenoides.Value != 0)
                {
                    BaseDatos.CrearRadio();
                    for (int i = 0; i < nudSolenoides.Value; i++)
                    {
                        BaseDatos.CrearSolenoide(new Solenoide() {
                            Campo = txtCampo.Text,
                            RadioID = Convert.ToInt32(txtRadio.Text),
                            NumeroSolenoide = i + 1,
                            Estado = false
                        });
                    }
                    MessageBox.Show("Radio " + txtRadio.Text + " agregada con " + nudSolenoides.Value + " Solenoides");
                    txtRadio.Text = (Convert.ToInt32(txtRadio.Text) + 1).ToString();
                }
                else
                    MessageBox.Show("Numero de solenoides invalido");
            }
            else
                MessageBox.Show("Ingrese el nombre del campo");
        }
    }
}
