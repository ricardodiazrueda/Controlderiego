namespace ControlRiego
{
    partial class ControlManual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRadios = new System.Windows.Forms.ComboBox();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Radios:";
            // 
            // cbxRadios
            // 
            this.cbxRadios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRadios.FormattingEnabled = true;
            this.cbxRadios.Location = new System.Drawing.Point(12, 28);
            this.cbxRadios.Name = "cbxRadios";
            this.cbxRadios.Size = new System.Drawing.Size(294, 24);
            this.cbxRadios.TabIndex = 1;
            this.cbxRadios.SelectedIndexChanged += new System.EventHandler(this.cbxRadios_SelectedIndexChanged);
            // 
            // clock
            // 
            this.clock.Interval = 3000;
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // ControlManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 209);
            this.Controls.Add(this.cbxRadios);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ControlManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Manual";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRadios;
        private System.Windows.Forms.Timer clock;
    }
}