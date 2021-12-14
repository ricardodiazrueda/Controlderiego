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
                Application.Run(new frmCreateSprinkler());
            }
            else
            {
                Application.Run(new frmMenu());
            }
            /*
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmCreateSprinkler());
            }
            */
        }
    }
}
