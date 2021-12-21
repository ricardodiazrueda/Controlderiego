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
    public partial class frmCreateUser : Form
    {
        UserBusiness userBusiness = new UserBusiness();
        public frmCreateUser()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            UserEntity user = new UserEntity()
            {
                FullName = txtFullName.Text,
                Password = txtPassword.Text,
                UserName = txtUserName.Text,
                Type = (cbAdmin.Checked) ? 1 : 0
            };
            string result = userBusiness.Create(user);
            MessageBox.Show(result);
        }
    }
}
