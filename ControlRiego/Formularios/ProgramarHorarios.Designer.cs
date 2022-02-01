﻿namespace ControlRiego
{
    partial class ProgramarHorarios
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
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.lbxEncender = new System.Windows.Forms.ListBox();
            this.lbxApagar = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBorrarTodos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpHora
            // 
            this.dtpHora.CausesValidation = false;
            this.dtpHora.Checked = false;
            this.dtpHora.CustomFormat = "HH:mm";
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(422, 725);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.RightToLeftLayout = true;
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(71, 22);
            this.dtpHora.TabIndex = 1;
            // 
            // cbxEstado
            // 
            this.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Items.AddRange(new object[] {
            "Apagar",
            "Encender"});
            this.cbxEstado.Location = new System.Drawing.Point(29, 726);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(121, 24);
            this.cbxEstado.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 730);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "todos los dias";
            // 
            // cbxDia
            // 
            this.cbxDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDia.FormattingEnabled = true;
            this.cbxDia.Items.AddRange(new object[] {
            "domingo",
            "lunes",
            "martes",
            "miércoles",
            "jueves",
            "viernes",
            "sábado"});
            this.cbxDia.Location = new System.Drawing.Point(253, 726);
            this.cbxDia.Name = "cbxDia";
            this.cbxDia.Size = new System.Drawing.Size(121, 24);
            this.cbxDia.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 730);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "a las";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(499, 699);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(122, 30);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // lbxEncender
            // 
            this.lbxEncender.FormattingEnabled = true;
            this.lbxEncender.ItemHeight = 16;
            this.lbxEncender.Location = new System.Drawing.Point(647, 33);
            this.lbxEncender.Name = "lbxEncender";
            this.lbxEncender.Size = new System.Drawing.Size(152, 660);
            this.lbxEncender.TabIndex = 7;
            // 
            // lbxApagar
            // 
            this.lbxApagar.FormattingEnabled = true;
            this.lbxApagar.ItemHeight = 16;
            this.lbxApagar.Location = new System.Drawing.Point(805, 33);
            this.lbxApagar.Name = "lbxApagar";
            this.lbxApagar.Size = new System.Drawing.Size(152, 660);
            this.lbxApagar.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(644, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Encender:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(802, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Apagar:";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(647, 699);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(310, 30);
            this.btnBorrar.TabIndex = 11;
            this.btnBorrar.Text = "Borrar Seleccionado";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(499, 735);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(122, 30);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBorrarTodos
            // 
            this.btnBorrarTodos.Location = new System.Drawing.Point(647, 735);
            this.btnBorrarTodos.Name = "btnBorrarTodos";
            this.btnBorrarTodos.Size = new System.Drawing.Size(310, 30);
            this.btnBorrarTodos.TabIndex = 13;
            this.btnBorrarTodos.Text = "Borrar Todos";
            this.btnBorrarTodos.UseVisualStyleBackColor = true;
            this.btnBorrarTodos.Click += new System.EventHandler(this.btnBorrarTodos_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnBorrarTodos);
            this.panel1.Controls.Add(this.lbxApagar);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.dtpHora);
            this.panel1.Controls.Add(this.btnBorrar);
            this.panel1.Controls.Add(this.cbxEstado);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxDia);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbxEncender);
            this.panel1.Controls.Add(this.btnCrear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 545);
            this.panel1.TabIndex = 15;
            // 
            // ProgramarHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 545);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProgramarHorarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programar Horarios";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.ListBox lbxEncender;
        private System.Windows.Forms.ListBox lbxApagar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBorrarTodos;
        private System.Windows.Forms.Panel panel1;
    }
}