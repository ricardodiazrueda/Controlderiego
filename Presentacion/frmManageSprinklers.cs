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
    public partial class frmManageSprinklers : Form
    {
        RadioBusiness radioBusiness = new RadioBusiness();
        SprinklerBusiness sprinklerBusiness = new SprinklerBusiness();
        int radio = 0;
        int sprinklers = 0;
        int prevSprinklers = 0;
        public frmManageSprinklers(int radio)
        {
            InitializeComponent();
            this.radio = radio;
            sprinklers = radioBusiness.GetSprinklers(radio);
            prevSprinklers = radioBusiness.PrevQuantity(radio);
            this.Text = "Radio " + radio;
            CreateButtons();
        }
        void CreateButtons()
        {
            List<int> states = sprinklerBusiness.ReadAll();

            for (int i = 0; i < sprinklers; i++)
            {
                int state = states[prevSprinklers + i];

                Button button = new Button();
                this.SuspendLayout();
                if (state == 0)
                    button.BackColor = Color.Red;
                else
                    button.BackColor = Color.Green;
                button.Text = "Solenoide\n" + (i + 1).ToString();
                button.Location = new Point((i % 4) * 100 + 20, (i / 4) * 100 + 20);
                button.Size = new Size(100, 100);
                button.Tag = i + 1;
                button.Click += (sender, e) =>
                {
                    Button btn = sender as Button;
                    int on = (prevSprinklers + (int)btn.Tag) * 2 - 1;
                    int off = (prevSprinklers + (int)btn.Tag) * 2;
                    MessageBox.Show(on.ToString());
                    MessageBox.Show(off.ToString());
                };
                this.Controls.Add(button);
                this.ResumeLayout(false);
            }
        }
    }
}
