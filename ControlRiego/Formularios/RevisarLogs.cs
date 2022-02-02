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
    public partial class RevisarLogs : Form
    {
        Usuario usuario = null;
        List<Log> logs = null;
        public RevisarLogs(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            dtpFecha_ValueChanged(null, null);

            btnBorrarTodo.Visible = usuario.Tipo;
            btnBorrarSeleccionado.Visible = usuario.Tipo;
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            logs = BaseDatos.LeerLogsFecha(dtpFecha.Value);
            dgvLogs.DataSource = null;
            dgvLogs.DataSource = logs;
            dgvLogs.Columns[0].Visible = false;
            dgvLogs.Columns[3].Width = 370;
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            BaseDatos.BorrarLogsTodos(dtpFecha.Value);
            BaseDatos.CrearLog(new Log() { Tipo = "Registro Eliminado", Info = usuario.Nombre + " borró todos los registros del día " + dtpFecha.Value.ToString("yyyy-MM-dd") });

            dtpFecha_ValueChanged(null, null);
        }

        private void btnBorrarSeleccionado_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                BaseDatos.BorrarLog(seleccionado);
                BaseDatos.CrearLog(new Log() { Tipo = "Registro Eliminado", Info = usuario.Nombre + " borró un registro del día " + dtpFecha.Value.ToString("yyyy-MM-dd") });

                dtpFecha_ValueChanged(null, null);
            }
        }

        Log seleccionado = null;
        private void dgvLogs_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < logs.Count)
                seleccionado = logs[e.RowIndex];
            else
                seleccionado = null;
        }
    }
}
