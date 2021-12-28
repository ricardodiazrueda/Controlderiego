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
    public partial class frmMenu : Form
    {
        UserEntity user = null;
        RadioBusiness radioBusiness = new RadioBusiness();
        public frmMenu(UserEntity user)
        {
            InitializeComponent();
            CreateButtons();
            this.user = user;

            btnLog.Visible = user.Type == 1;
        }
        void CreateButtons()
        {
            int quantity = radioBusiness.Quantity();
            for (int i = 0; i < quantity; i++)
            {
                Button button = new Button();
                this.SuspendLayout();
                button.Text = "Radio\n" + (i + 1).ToString();
                button.Location = new Point((i % 4) * 100 + 20, (i / 4)* 100 + 20);
                button.Size = new Size(100, 100);
                button.Tag = i + 1;
                button.Click += (sender, e) =>
                {
                    Button btn = (Button)sender;
                    frmManageSprinklers frm = new frmManageSprinklers((int)btn.Tag, user);
                    this.Visible = false;
                    frm.ShowDialog();
                    this.Visible = true;
                };
                this.Controls.Add(button);
                this.ResumeLayout(false);
            }
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            new frmProgram(user).ShowDialog();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            new frmLog().ShowDialog();
        }
    }
}
