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
using Comunicacion;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        Serial serial;
        public Form1()
        {
            serial = new Serial();

            InitializeComponent();
            cbxPorts.Items.AddRange(serial.GetPorts());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string result = serial.Open(cbxPorts.Text);
            MessageBox.Show(result);
        }

        private void txtTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serial.Send(txtTerminal.Text);
                txtTerminal.Clear();
                e.Handled = true;
            }
        }
    }
}
