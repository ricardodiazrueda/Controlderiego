using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Presentation
{
    public partial class frmLog : Form
    {
        LogData logData = new LogData();
        public frmLog()
        {
            InitializeComponent();
            dtpStart.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            dtpEnd.Value = DateTime.Now;

            FillLogs();
        }
        void FillLogs()
        {
            List<string> logs = logData.Read(dtpStart.Value, dtpEnd.Value);
            lbxLog.DataSource = null;
            lbxLog.DataSource = logs;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            FillLogs();
        }
    }
}
