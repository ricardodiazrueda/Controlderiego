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
            ControlManual frm = new ControlManual(this.usuario);
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
            Serial.callback = Serial.defaultCallback;
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProgramarHorarios frm = new ProgramarHorarios(this.usuario);
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
            Serial.callback = Serial.defaultCallback;
        }

        private void btnMonitorear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MonitorearHorarios frm = new MonitorearHorarios(this.usuario);
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
            Serial.callback = Serial.defaultCallback;
        }

        private void btnRevisarLogs_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RevisarLogs frm = new RevisarLogs(this.usuario);
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
            Serial.callback = Serial.defaultCallback;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbBateriaBaja.DataSource = null;
            lbBateriaBaja.DataSource = BaseDatos.LeerLogsBateriaBaja();
        }
        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GestionarUsuarios frm = new GestionarUsuarios();
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
            Serial.callback = Serial.defaultCallback;
        }
    }
}
