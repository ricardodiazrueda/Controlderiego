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
        Usuario usuario = null;
        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            lbBateriaBaja.DataSource = BaseDatos.LeerLogsBateriaBaja();
            btnGestionarUsuarios.Visible = usuario.Tipo;
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new ControlManual(this.usuario)).ShowDialog();
            this.Visible = true;
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new ProgramarHorarios(this.usuario)).ShowDialog();
            this.Visible = true;
        }

        private void btnMonitorear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new MonitorearHorarios(this.usuario)).ShowDialog();
            this.Visible = true;
        }

        private void btnRevisarLogs_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new RevisarLogs(this.usuario)).ShowDialog();
            this.Visible = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbBateriaBaja.DataSource = null;
            lbBateriaBaja.DataSource = BaseDatos.LeerLogsBateriaBaja();
        }
        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new GestionarUsuarios()).ShowDialog();
            this.Visible = true;
        }
    }
}
