using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlRiego
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

            if (BaseDatos.LeerCantidadRadios() == 0)
            {
                new ConfigurarRadios().ShowDialog();
                new ConfigurarUsuarios().ShowDialog();
            }

            IniciarSesion iniciarSesion = new IniciarSesion();
            if (iniciarSesion.ShowDialog() == DialogResult.OK)
            {
                ConsolaSerial consolaSerial = new ConsolaSerial();
                if (consolaSerial.ShowDialog() == DialogResult.OK)
                {
                    if (iniciarSesion.Usuario.Tipo)
                        consolaSerial.Show();

                    Application.Run(new MenuPrincipal(iniciarSesion.Usuario));
                }
            }
        }
    }
}
