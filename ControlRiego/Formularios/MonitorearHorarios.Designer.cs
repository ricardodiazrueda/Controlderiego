namespace ControlRiego
{
    partial class MonitorearHorarios
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
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxEsperando = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxEnviado = new System.Windows.Forms.ListBox();
            this.lbxReprogramado = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbxFinalizado = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbxFallados = new System.Windows.Forms.ListBox();
            this.marcapasos = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // reloj
            // 
            this.reloj.Enabled = true;
            this.reloj.Interval = 1000;
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(12, 476);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(40, 16);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "En espera:";
            // 
            // lbxEsperando
            // 
            this.lbxEsperando.FormattingEnabled = true;
            this.lbxEsperando.ItemHeight = 16;
            this.lbxEsperando.Location = new System.Drawing.Point(15, 28);
            this.lbxEsperando.Name = "lbxEsperando";
            this.lbxEsperando.Size = new System.Drawing.Size(152, 436);
            this.lbxEsperando.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "En ejecución:";
            // 
            // lbxEnviado
            // 
            this.lbxEnviado.FormattingEnabled = true;
            this.lbxEnviado.ItemHeight = 16;
            this.lbxEnviado.Location = new System.Drawing.Point(173, 28);
            this.lbxEnviado.Name = "lbxEnviado";
            this.lbxEnviado.Size = new System.Drawing.Size(152, 132);
            this.lbxEnviado.TabIndex = 12;
            // 
            // lbxReprogramado
            // 
            this.lbxReprogramado.FormattingEnabled = true;
            this.lbxReprogramado.ItemHeight = 16;
            this.lbxReprogramado.Location = new System.Drawing.Point(173, 188);
            this.lbxReprogramado.Name = "lbxReprogramado";
            this.lbxReprogramado.Size = new System.Drawing.Size(152, 276);
            this.lbxReprogramado.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Reprogramados:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Finalizados:";
            // 
            // lbxFinalizado
            // 
            this.lbxFinalizado.FormattingEnabled = true;
            this.lbxFinalizado.ItemHeight = 16;
            this.lbxFinalizado.Location = new System.Drawing.Point(331, 28);
            this.lbxFinalizado.Name = "lbxFinalizado";
            this.lbxFinalizado.Size = new System.Drawing.Size(152, 436);
            this.lbxFinalizado.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Fallados:";
            // 
            // lbxFallados
            // 
            this.lbxFallados.FormattingEnabled = true;
            this.lbxFallados.ItemHeight = 16;
            this.lbxFallados.Location = new System.Drawing.Point(489, 28);
            this.lbxFallados.Name = "lbxFallados";
            this.lbxFallados.Size = new System.Drawing.Size(152, 436);
            this.lbxFallados.TabIndex = 18;
            // 
            // marcapasos
            // 
            this.marcapasos.Enabled = true;
            this.marcapasos.Interval = 5000;
            this.marcapasos.Tick += new System.EventHandler(this.marcapasos_Tick);
            // 
            // MonitorearHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 501);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbxFallados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbxFinalizado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxReprogramado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxEnviado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxEsperando);
            this.Controls.Add(this.lblHora);
            this.Name = "MonitorearHorarios";
            this.Text = "Monitorear Programas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonitorearHorarios_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxEsperando;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxEnviado;
        private System.Windows.Forms.ListBox lbxReprogramado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxFinalizado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbxFallados;
        private System.Windows.Forms.Timer marcapasos;
    }
}