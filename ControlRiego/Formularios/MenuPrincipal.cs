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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new ControlManual()).ShowDialog();
            this.Visible = true;
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new ProgramarHorarios()).ShowDialog();
            this.Visible = true;
        }

        private void btnMonitorear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new MonitorearHorarios()).ShowDialog();
            this.Visible = true;
        }
    }
}
