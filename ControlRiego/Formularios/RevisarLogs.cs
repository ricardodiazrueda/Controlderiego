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
        public RevisarLogs()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now;
            dtpFecha_ValueChanged(null, null);
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            dgvLogs.DataSource = null;
            dgvLogs.DataSource = BaseDatos.LeerLogsFecha(dtpFecha.Value);
            dgvLogs.Columns[0].Visible = false;
            dgvLogs.Columns[3].Width = 370;
        }
    }
}
