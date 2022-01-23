namespace ControlRiego
{
    partial class ConfigurarRadios
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCampo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSolenoides = new System.Windows.Forms.NumericUpDown();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtRadio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolenoides)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Campo:";
            // 
            // txtCampo
            // 
            this.txtCampo.Location = new System.Drawing.Point(97, 12);
            this.txtCampo.MaxLength = 1;
            this.txtCampo.Name = "txtCampo";
            this.txtCampo.Size = new System.Drawing.Size(152, 22);
            this.txtCampo.TabIndex = 1;
            this.txtCampo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Radio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Solenoides:";
            // 
            // nudSolenoides
            // 
            this.nudSolenoides.Location = new System.Drawing.Point(97, 68);
            this.nudSolenoides.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudSolenoides.Name = "nudSolenoides";
            this.nudSolenoides.Size = new System.Drawing.Size(152, 22);
            this.nudSolenoides.TabIndex = 4;
            this.nudSolenoides.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(123, 96);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(100, 27);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(97, 40);
            this.txtRadio.MaxLength = 1;
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.ReadOnly = true;
            this.txtRadio.Size = new System.Drawing.Size(152, 22);
            this.txtRadio.TabIndex = 7;
            this.txtRadio.Text = "1";
            this.txtRadio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConfigurarRadios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 135);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSolenoides);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCampo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigurarRadios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Radios";
            ((System.ComponentModel.ISupportInitialize)(this.nudSolenoides)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCampo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSolenoides;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtRadio;
    }
}

