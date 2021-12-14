using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comunication;

namespace Presentation
{
    public partial class frmSetSerialPort : Form
    {
        public frmSetSerialPort()
        {
            InitializeComponent();
            string[] ports = Serial.GetPorts();
            cbxPorts.Items.AddRange(ports);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Serial.Open(cbxPorts.Text))
            {
                txtTerminal.Enabled = true;
                btnDisconnect.Enabled = true;
            }
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if(Serial.Close())
            {
                txtTerminal.Enabled = false;
                btnDisconnect.Enabled = false;
            }
        }

        private void txtTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Serial.Send(txtTerminal.Text);
                txtTerminal.Clear();
                e.Handled = true;
            }
        }

    }
}
