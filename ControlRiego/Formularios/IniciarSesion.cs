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
    public partial class IniciarSesion : Form
    {
        public Usuario Usuario { get; set; } = null;
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtClave.Text != "")
                {
                    Usuario = BaseDatos.LeerUsuario(txtUsuario.Text, txtClave.Text);
                    if (Usuario != null)
                        this.DialogResult = DialogResult.OK;
                    else
                        MessageBox.Show("Credenciales incorrectas");
                }
                else
                    MessageBox.Show("Ingrese la clave");
            }
            else
                MessageBox.Show("Ingrese el usuario");
        }
    }
}
