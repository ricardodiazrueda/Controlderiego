namespace Presentation
{
    partial class frmMonitoring
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
            this.lbExecuting = new System.Windows.Forms.ListBox();
            this.lbProgramOn = new System.Windows.Forms.ListBox();
            this.lblExecuting = new System.Windows.Forms.Label();
            this.lblProgramados = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.grbMonitoring = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbProgramOff = new System.Windows.Forms.ListBox();
            this.grbExecuted = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbExecutedOff = new System.Windows.Forms.ListBox();
            this.lbExecutedOn = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grbReprogramed = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbReprogramedOff = new System.Windows.Forms.ListBox();
            this.lbReprogramedOn = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grbFailed = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbFailedOff = new System.Windows.Forms.ListBox();
            this.lbFailedOn = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.grbMonitoring.SuspendLayout();
            this.grbExecuted.SuspendLayout();
            this.grbReprogramed.SuspendLayout();
            this.grbFailed.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbExecuting
            // 
            this.lbExecuting.FormattingEnabled = true;
            this.lbExecuting.ItemHeight = 16;
            this.lbExecuting.Location = new System.Drawing.Point(724, 53);
            this.lbExecuting.Name = "lbExecuting";
            this.lbExecuting.Size = new System.Drawing.Size(128, 500);
            this.lbExecuting.TabIndex = 25;
            // 
            // lbProgramOn
            // 
            this.lbProgramOn.FormattingEnabled = true;
            this.lbProgramOn.ItemHeight = 16;
            this.lbProgramOn.Location = new System.Drawing.Point(7, 35);
            this.lbProgramOn.Name = "lbProgramOn";
            this.lbProgramOn.Size = new System.Drawing.Size(165, 228);
            this.lbProgramOn.TabIndex = 24;
            // 
            // lblExecuting
            // 
            this.lblExecuting.AutoSize = true;
            this.lblExecuting.Location = new System.Drawing.Point(721, 30);
            this.lblExecuting.Name = "lblExecuting";
            this.lblExecuting.Size = new System.Drawing.Size(97, 16);
            this.lblExecuting.TabIndex = 22;
            this.lblExecuting.Text = "En ejecución: 0";
            // 
            // lblProgramados
            // 
            this.lblProgramados.AutoSize = true;
            this.lblProgramados.Location = new System.Drawing.Point(6, 18);
            this.lblProgramados.Name = "lblProgramados";
            this.lblProgramados.Size = new System.Drawing.Size(65, 16);
            this.lblProgramados.TabIndex = 20;
            this.lblProgramados.Text = "Encender";
            // 
            // clock
            // 
            this.clock.Enabled = true;
            this.clock.Interval = 5000;
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // grbMonitoring
            // 
            this.grbMonitoring.Controls.Add(this.label1);
            this.grbMonitoring.Controls.Add(this.lbProgramOff);
            this.grbMonitoring.Controls.Add(this.lbProgramOn);
            this.grbMonitoring.Controls.Add(this.lblProgramados);
            this.grbMonitoring.Location = new System.Drawing.Point(12, 12);
            this.grbMonitoring.Name = "grbMonitoring";
            this.grbMonitoring.Size = new System.Drawing.Size(350, 272);
            this.grbMonitoring.TabIndex = 28;
            this.grbMonitoring.TabStop = false;
            this.grbMonitoring.Text = "En monitoreo: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Apagar";
            // 
            // lbProgramOff
            // 
            this.lbProgramOff.FormattingEnabled = true;
            this.lbProgramOff.ItemHeight = 16;
            this.lbProgramOff.Location = new System.Drawing.Point(178, 35);
            this.lbProgramOff.Name = "lbProgramOff";
            this.lbProgramOff.Size = new System.Drawing.Size(165, 228);
            this.lbProgramOff.TabIndex = 25;
            // 
            // grbExecuted
            // 
            this.grbExecuted.Controls.Add(this.label2);
            this.grbExecuted.Controls.Add(this.lbExecutedOff);
            this.grbExecuted.Controls.Add(this.lbExecutedOn);
            this.grbExecuted.Controls.Add(this.label3);
            this.grbExecuted.Location = new System.Drawing.Point(368, 12);
            this.grbExecuted.Name = "grbExecuted";
            this.grbExecuted.Size = new System.Drawing.Size(350, 272);
            this.grbExecuted.TabIndex = 29;
            this.grbExecuted.TabStop = false;
            this.grbExecuted.Text = "Ejecutadas correctamente: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Apagar";
            // 
            // lbExecutedOff
            // 
            this.lbExecutedOff.FormattingEnabled = true;
            this.lbExecutedOff.ItemHeight = 16;
            this.lbExecutedOff.Location = new System.Drawing.Point(178, 35);
            this.lbExecutedOff.Name = "lbExecutedOff";
            this.lbExecutedOff.Size = new System.Drawing.Size(165, 228);
            this.lbExecutedOff.TabIndex = 25;
            // 
            // lbExecutedOn
            // 
            this.lbExecutedOn.FormattingEnabled = true;
            this.lbExecutedOn.ItemHeight = 16;
            this.lbExecutedOn.Location = new System.Drawing.Point(7, 35);
            this.lbExecutedOn.Name = "lbExecutedOn";
            this.lbExecutedOn.Size = new System.Drawing.Size(165, 228);
            this.lbExecutedOn.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Encender";
            // 
            // grbReprogramed
            // 
            this.grbReprogramed.Controls.Add(this.label5);
            this.grbReprogramed.Controls.Add(this.lbReprogramedOff);
            this.grbReprogramed.Controls.Add(this.lbReprogramedOn);
            this.grbReprogramed.Controls.Add(this.label6);
            this.grbReprogramed.Location = new System.Drawing.Point(12, 290);
            this.grbReprogramed.Name = "grbReprogramed";
            this.grbReprogramed.Size = new System.Drawing.Size(350, 272);
            this.grbReprogramed.TabIndex = 29;
            this.grbReprogramed.TabStop = false;
            this.grbReprogramed.Text = "Reprogramadas: 0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Apagar";
            // 
            // lbReprogramedOff
            // 
            this.lbReprogramedOff.FormattingEnabled = true;
            this.lbReprogramedOff.ItemHeight = 16;
            this.lbReprogramedOff.Location = new System.Drawing.Point(178, 35);
            this.lbReprogramedOff.Name = "lbReprogramedOff";
            this.lbReprogramedOff.Size = new System.Drawing.Size(165, 228);
            this.lbReprogramedOff.TabIndex = 25;
            // 
            // lbReprogramedOn
            // 
            this.lbReprogramedOn.FormattingEnabled = true;
            this.lbReprogramedOn.ItemHeight = 16;
            this.lbReprogramedOn.Location = new System.Drawing.Point(7, 35);
            this.lbReprogramedOn.Name = "lbReprogramedOn";
            this.lbReprogramedOn.Size = new System.Drawing.Size(165, 228);
            this.lbReprogramedOn.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Encender";
            // 
            // grbFailed
            // 
            this.grbFailed.Controls.Add(this.label7);
            this.grbFailed.Controls.Add(this.lbFailedOff);
            this.grbFailed.Controls.Add(this.lbFailedOn);
            this.grbFailed.Controls.Add(this.label8);
            this.grbFailed.Location = new System.Drawing.Point(368, 290);
            this.grbFailed.Name = "grbFailed";
            this.grbFailed.Size = new System.Drawing.Size(350, 272);
            this.grbFailed.TabIndex = 30;
            this.grbFailed.TabStop = false;
            this.grbFailed.Text = "Falladas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Apagar";
            // 
            // lbFailedOff
            // 
            this.lbFailedOff.FormattingEnabled = true;
            this.lbFailedOff.ItemHeight = 16;
            this.lbFailedOff.Location = new System.Drawing.Point(178, 35);
            this.lbFailedOff.Name = "lbFailedOff";
            this.lbFailedOff.Size = new System.Drawing.Size(165, 228);
            this.lbFailedOff.TabIndex = 25;
            // 
            // lbFailedOn
            // 
            this.lbFailedOn.FormattingEnabled = true;
            this.lbFailedOn.ItemHeight = 16;
            this.lbFailedOn.Location = new System.Drawing.Point(7, 35);
            this.lbFailedOn.Name = "lbFailedOn";
            this.lbFailedOn.Size = new System.Drawing.Size(165, 228);
            this.lbFailedOn.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Encender";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(62, 565);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(52, 16);
            this.lblLast.TabIndex = 31;
            this.lblLast.Text = "Apagar";
            // 
            // frmMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 595);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.grbFailed);
            this.Controls.Add(this.grbReprogramed);
            this.Controls.Add(this.grbExecuted);
            this.Controls.Add(this.grbMonitoring);
            this.Controls.Add(this.lbExecuting);
            this.Controls.Add(this.lblExecuting);
            this.Name = "frmMonitoring";
            this.Text = "frmMonitoring";
            this.grbMonitoring.ResumeLayout(false);
            this.grbMonitoring.PerformLayout();
            this.grbExecuted.ResumeLayout(false);
            this.grbExecuted.PerformLayout();
            this.grbReprogramed.ResumeLayout(false);
            this.grbReprogramed.PerformLayout();
            this.grbFailed.ResumeLayout(false);
            this.grbFailed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbExecuting;
        private System.Windows.Forms.ListBox lbProgramOn;
        private System.Windows.Forms.Label lblExecuting;
        private System.Windows.Forms.Label lblProgramados;
        private System.Windows.Forms.GroupBox grbMonitoring;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbProgramOff;
        private System.Windows.Forms.GroupBox grbExecuted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbExecutedOff;
        private System.Windows.Forms.ListBox lbExecutedOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbReprogramed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbReprogramedOff;
        private System.Windows.Forms.ListBox lbReprogramedOn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbFailed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbFailedOff;
        private System.Windows.Forms.ListBox lbFailedOn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Label lblLast;
    }
}