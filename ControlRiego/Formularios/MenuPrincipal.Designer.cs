namespace ControlRiego
{
    partial class MenuPrincipal
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
            this.btnManual = new System.Windows.Forms.Button();
            this.btnProgramar = new System.Windows.Forms.Button();
            this.btnMonitorear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(12, 12);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(306, 65);
            this.btnManual.TabIndex = 0;
            this.btnManual.Text = "Control Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnProgramar
            // 
            this.btnProgramar.Location = new System.Drawing.Point(12, 83);
            this.btnProgramar.Name = "btnProgramar";
            this.btnProgramar.Size = new System.Drawing.Size(150, 65);
            this.btnProgramar.TabIndex = 1;
            this.btnProgramar.Text = "Programar";
            this.btnProgramar.UseVisualStyleBackColor = true;
            this.btnProgramar.Click += new System.EventHandler(this.btnProgramar_Click);
            // 
            // btnMonitorear
            // 
            this.btnMonitorear.Location = new System.Drawing.Point(168, 83);
            this.btnMonitorear.Name = "btnMonitorear";
            this.btnMonitorear.Size = new System.Drawing.Size(150, 65);
            this.btnMonitorear.TabIndex = 2;
            this.btnMonitorear.Text = "Monitorear";
            this.btnMonitorear.UseVisualStyleBackColor = true;
            this.btnMonitorear.Click += new System.EventHandler(this.btnMonitorear_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 167);
            this.Controls.Add(this.btnMonitorear);
            this.Controls.Add(this.btnProgramar);
            this.Controls.Add(this.btnManual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Riego";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnProgramar;
        private System.Windows.Forms.Button btnMonitorear;
    }
}