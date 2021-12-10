using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation
{
    public partial class frmLogin : Form
    {
        UserBusiness userBusiness = new UserBusiness();
        public UserEntity user { get; set; } = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            user = userBusiness.Login(txtUserName.Text, txtPassword.Text);
            if (user != null)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Usuario o contraseña incorrecto");
        }
    }
}
