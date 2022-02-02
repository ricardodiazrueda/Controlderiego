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
    public partial class GestionarUsuarios : Form
    {
        Usuario seleccionado = null;
        List<Usuario> usuarios = null;
        public GestionarUsuarios()
        {
            InitializeComponent();
            LlenarListaUsuarios();
        }
        void LlenarListaUsuarios()
        {
            usuarios = BaseDatos.LeerTodosUsuarios();
            lbUsuarios.DataSource = null;
            lbUsuarios.DataSource = usuarios;
            lbUsuarios.SelectedIndex = -1;
        }

        private void lbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUsuarios.SelectedIndex != -1)
            {
                seleccionado = usuarios[lbUsuarios.SelectedIndex];
                gbUsuario.Text = seleccionado.Nombre + " (" + seleccionado.NombreUsuario + ")";
                btnResetear.Enabled = true;
                txtNuevaContraseña.Enabled = true;
            }
            else
            {
                seleccionado = null;
                btnResetear.Enabled = false;
                txtNuevaContraseña.Enabled = false;
                gbUsuario.Text = "";
            }
            txtNuevaContraseña.Text = "";
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            if (txtNuevaContraseña.Text != "" && seleccionado != null)
            {
                seleccionado.Clave = txtNuevaContraseña.Text;
                BaseDatos.ModificarUsuarioClave(seleccionado);
                LlenarListaUsuarios();
                MessageBox.Show("Contraseña cambiada!");
            }
        }
    }
}
