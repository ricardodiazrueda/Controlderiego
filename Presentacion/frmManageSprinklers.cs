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
using Comunication;

namespace Presentation
{
    public partial class frmManageSprinklers : Form
    {
        List<Button> buttons = new List<Button>();

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

            Serial.callback = (data) =>
            {
                if (data.Contains(".D"))
                {
                    // data = "ME0301OON.D";
                    string s_radio = data.Substring(2, 2);
                    string s_sprinkler = data.Substring(4, 2);
                    string s_action = data.Substring(6, 3);

                    int i_radio = Convert.ToInt32(s_radio);
                    int i_sprinkler = Convert.ToInt32(s_sprinkler);

                    int i_id = radioBusiness.PrevQuantity(i_radio) + i_sprinkler;

                    Button button = buttons.Find( x => (int)x.Tag == i_sprinkler);

                    if (s_action == "OON")
                    {
                        sprinklerBusiness.SetState(i_id, 1);
                        button.BackColor = Color.Green;
                    }
                    else
                    {
                        sprinklerBusiness.SetState(i_id, 0);
                        button.BackColor = Color.Red;
                    }

                    foreach (Button btn in buttons)
                        btn.Enabled = true;
                }
            };
        }
        void CreateButtons()
        {
            List<int> states = sprinklerBusiness.ReadAll();

            for (int i = 0; i < sprinklers; i++)
            {
                int state = states[prevSprinklers + i];
                int id = prevSprinklers + i + 1;

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

                    if (btn.BackColor == Color.Green)
                    {
                        btn.BackColor = Color.Blue;
                        Serial.Send(off.ToString());
                    }
                    else
                    {
                        btn.BackColor = Color.Blue;
                        Serial.Send(on.ToString());
                    }

                    foreach (Button btn1 in buttons)
                        btn1.Enabled = false;
                };
                this.Controls.Add(button);
                this.ResumeLayout(false);
            }
        }
    }
}
