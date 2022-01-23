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
    public partial class ConfigurarUsuarios : Form
    {
        public ConfigurarUsuarios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                if (txtUsuario.Text != "")
                {
                    if (txtClave.Text != "")
                    {
                        BaseDatos.CrearUsuario(new Usuario() { 
                            Nombre = txtNombre.Text,
                            NombreUsuario = txtUsuario.Text,
                            Clave = txtClave.Text,
                            Tipo = cbAdmin.Checked
                        });
                        MessageBox.Show("Usuario " + txtUsuario.Text + " creado");
                    }
                    else
                        MessageBox.Show("Ingrese la clave");
                }
                else
                    MessageBox.Show("Ingrese el usuario");
            }
            else
                MessageBox.Show("Ingrese el nombre");
        }
    }
}