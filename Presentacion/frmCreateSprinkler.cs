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

namespace Presentation
{
    public partial class frmCreateSprinkler : Form
    {
        DataBusiness dataBusiness = new DataBusiness();
        RadioBusiness radioBusiness = new RadioBusiness();
        SprinklerBusiness sprinklerBusiness = new SprinklerBusiness();
        int radio = 1;
        int sprinklers = 0;
        public frmCreateSprinkler()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nudSprinklers.Value; i++)
            {
                sprinklerBusiness.Create();
            }
            radioBusiness.Create((int)nudSprinklers.Value);
            sprinklers += (int)nudSprinklers.Value;
            lblRadios.Text = (++radio).ToString();
            dataBusiness.Write("Sprinklers", sprinklers.ToString());
        }
    }
}
