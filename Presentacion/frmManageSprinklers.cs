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
using Entities;
using Data;

namespace Presentation
{
    public partial class frmManageSprinklers : Form
    {
        List<Button> buttons = new List<Button>();
        LogData logData = new LogData();
        UserEntity user = null;
        Button pressed = null;
        int action = -1;

        RadioBusiness radioBusiness = new RadioBusiness();
        SprinklerBusiness sprinklerBusiness = new SprinklerBusiness();

        int radio = 0;
        int sprinklers = 0;
        int prevSprinklers = 0;
        public frmManageSprinklers(int radio, UserEntity user)
        {
            InitializeComponent();
            this.user = user;
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
                        button.BackColor = Color.Green;
                        sprinklerBusiness.SetState(i_id, 1);
                    }
                    else
                    {
                        button.BackColor = Color.Red;
                        sprinklerBusiness.SetState(i_id, 0);
                    }
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
                    if (buttons.Exists(x => x.BackColor == Color.Blue))
                        return;

                    Button btn = sender as Button;
                    pressed = btn;

                    int on = (prevSprinklers + (int)btn.Tag) * 2 - 1;
                    int off = (prevSprinklers + (int)btn.Tag) * 2;

                    if (btn.BackColor == Color.Green)
                    {
                        btn.BackColor = Color.Blue;
                        Serial.Send(off.ToString());
                        action = 0;
                        logData.Insert(new LogEntity() { Type = "SOLENOIDE OFF", Data = user.FullName + " apagó el solenoide " + (prevSprinklers + (int)btn.Tag), EntityID = user.UserID });
                    }
                    else
                    {
                        btn.BackColor = Color.Blue;
                        Serial.Send(on.ToString());
                        action = 1;
                        logData.Insert(new LogEntity() { Type = "SOLENOIDE ON", Data = user.FullName + " encendió el solenoide " + (prevSprinklers + (int)btn.Tag), EntityID = user.UserID });
                    }

                    clock.Enabled = true;
                    foreach (Button button1 in buttons)
                        button1.Enabled = false;
                };
                buttons.Add(button);
                this.Controls.Add(button);
                this.ResumeLayout(false);
            }
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            if (pressed != null)
            {
                if (pressed.BackColor == Color.Blue)
                {
                    if (action == 0)
                        pressed.BackColor = Color.Green;
                    else
                        pressed.BackColor = Color.Red;
                }
            }

            clock.Enabled = false;
            foreach (Button button1 in buttons)
                button1.Enabled = true;
        }
    }
}
