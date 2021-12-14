using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace Presentation
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataBusiness dataBusiness = new DataBusiness();

            if (dataBusiness.Read("Sprinklers") == "0")
            {
                new frmCreateSprinkler().ShowDialog();
                new frmCreateUser().ShowDialog();
            }
            else
            {
                frmLogin frm = new frmLogin();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //new frmSetSerialPort().ShowDialog();
                    new frmMenu().ShowDialog();
                }
            }
        }
    }
}
