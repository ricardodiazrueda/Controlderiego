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
    public partial class ConsolaSerial : Form
    {
        public ConsolaSerial()
        {
            InitializeComponent();
            cbxPuertos.DataSource = Serial.GetPorts();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (Serial.Open(cbxPuertos.Text))
            {
                btnContinuar.Enabled = true;
                txtEnviar.Enabled = true;
                cbxPuertos.Enabled = false;
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if (Serial.Close())
            {
                btnContinuar.Enabled = false;
                txtEnviar.Enabled = false;
                cbxPuertos.Enabled = true;
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtEnviar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Serial.Send(txtEnviar.Text);
            }
        }
    }
}
