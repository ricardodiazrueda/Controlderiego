namespace Presentation
{
    partial class frmCreateSprinkler
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSprinklers = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblRadios = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSprinklers)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set Radio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Solenoides:";
            // 
            // nudSprinklers
            // 
            this.nudSprinklers.Location = new System.Drawing.Point(140, 55);
            this.nudSprinklers.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudSprinklers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSprinklers.Name = "nudSprinklers";
            this.nudSprinklers.Size = new System.Drawing.Size(155, 32);
            this.nudSprinklers.TabIndex = 4;
            this.nudSprinklers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSprinklers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(89, 97);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(136, 33);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Crear";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblRadios
            // 
            this.lblRadios.Location = new System.Drawing.Point(140, 19);
            this.lblRadios.Name = "lblRadios";
            this.lblRadios.Size = new System.Drawing.Size(141, 23);
            this.lblRadios.TabIndex = 7;
            this.lblRadios.Text = "1";
            this.lblRadios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCreateSprinkler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 143);
            this.Controls.Add(this.lblRadios);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSprinklers);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateSprinkler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Solenoides";
            ((System.ComponentModel.ISupportInitialize)(this.nudSprinklers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSprinklers;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblRadios;
    }
}