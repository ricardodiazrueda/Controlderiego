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
            this.components = new System.ComponentModel.Container();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnProgramar = new System.Windows.Forms.Button();
            this.btnMonitorear = new System.Windows.Forms.Button();
            this.btnRevisarLogs = new System.Windows.Forms.Button();
            this.lbBateriaBaja = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
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
            this.btnProgramar.Location = new System.Drawing.Point(12, 89);
            this.btnProgramar.Name = "btnProgramar";
            this.btnProgramar.Size = new System.Drawing.Size(150, 65);
            this.btnProgramar.TabIndex = 1;
            this.btnProgramar.Text = "Programar";
            this.btnProgramar.UseVisualStyleBackColor = true;
            this.btnProgramar.Click += new System.EventHandler(this.btnProgramar_Click);
            // 
            // btnMonitorear
            // 
            this.btnMonitorear.Location = new System.Drawing.Point(168, 89);
            this.btnMonitorear.Name = "btnMonitorear";
            this.btnMonitorear.Size = new System.Drawing.Size(150, 65);
            this.btnMonitorear.TabIndex = 2;
            this.btnMonitorear.Text = "Monitorear";
            this.btnMonitorear.UseVisualStyleBackColor = true;
            this.btnMonitorear.Click += new System.EventHandler(this.btnMonitorear_Click);
            // 
            // btnRevisarLogs
            // 
            this.btnRevisarLogs.Location = new System.Drawing.Point(12, 163);
            this.btnRevisarLogs.Name = "btnRevisarLogs";
            this.btnRevisarLogs.Size = new System.Drawing.Size(306, 65);
            this.btnRevisarLogs.TabIndex = 3;
            this.btnRevisarLogs.Text = "Revisar Logs";
            this.btnRevisarLogs.UseVisualStyleBackColor = true;
            this.btnRevisarLogs.Click += new System.EventHandler(this.btnRevisarLogs_Click);
            // 
            // lbBateriaBaja
            // 
            this.lbBateriaBaja.FormattingEnabled = true;
            this.lbBateriaBaja.ItemHeight = 16;
            this.lbBateriaBaja.Location = new System.Drawing.Point(324, 32);
            this.lbBateriaBaja.Name = "lbBateriaBaja";
            this.lbBateriaBaja.Size = new System.Drawing.Size(448, 196);
            this.lbBateriaBaja.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Batería baja:";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 240);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbBateriaBaja);
            this.Controls.Add(this.btnRevisarLogs);
            this.Controls.Add(this.btnMonitorear);
            this.Controls.Add(this.btnProgramar);
            this.Controls.Add(this.btnManual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Riego";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnProgramar;
        private System.Windows.Forms.Button btnMonitorear;
        private System.Windows.Forms.Button btnRevisarLogs;
        private System.Windows.Forms.ListBox lbBateriaBaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
    }
}