namespace Presentation
{
    partial class frmProgram
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
            this.cbxRadios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSprinklers = new System.Windows.Forms.ComboBox();
            this.lbxPrograms = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rbOn = new System.Windows.Forms.RadioButton();
            this.rbOff = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxDay = new System.Windows.Forms.ComboBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.lblProgramados = new System.Windows.Forms.Label();
            this.lbxAlerts = new System.Windows.Forms.ListBox();
            this.lblExecuting = new System.Windows.Forms.Label();
            this.lblLate = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbProgramados = new System.Windows.Forms.ListBox();
            this.lbExecuting = new System.Windows.Forms.ListBox();
            this.lbLate = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxRadios
            // 
            this.cbxRadios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRadios.FormattingEnabled = true;
            this.cbxRadios.Location = new System.Drawing.Point(110, 40);
            this.cbxRadios.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRadios.Name = "cbxRadios";
            this.cbxRadios.Size = new System.Drawing.Size(255, 31);
            this.cbxRadios.TabIndex = 0;
            this.cbxRadios.SelectedIndexChanged += new System.EventHandler(this.cbxRadios_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Radio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Solenoide:";
            // 
            // cbxSprinklers
            // 
            this.cbxSprinklers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSprinklers.FormattingEnabled = true;
            this.cbxSprinklers.Location = new System.Drawing.Point(373, 40);
            this.cbxSprinklers.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSprinklers.Name = "cbxSprinklers";
            this.cbxSprinklers.Size = new System.Drawing.Size(255, 31);
            this.cbxSprinklers.TabIndex = 2;
            this.cbxSprinklers.SelectedIndexChanged += new System.EventHandler(this.cbxSprinklers_SelectedIndexChanged);
            // 
            // lbxPrograms
            // 
            this.lbxPrograms.FormattingEnabled = true;
            this.lbxPrograms.ItemHeight = 23;
            this.lbxPrograms.Location = new System.Drawing.Point(249, 185);
            this.lbxPrograms.Name = "lbxPrograms";
            this.lbxPrograms.Size = new System.Drawing.Size(255, 119);
            this.lbxPrograms.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Programación:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(372, 310);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 33);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(553, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 33);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rbOn
            // 
            this.rbOn.AutoSize = true;
            this.rbOn.Location = new System.Drawing.Point(13, 31);
            this.rbOn.Name = "rbOn";
            this.rbOn.Size = new System.Drawing.Size(125, 27);
            this.rbOn.TabIndex = 8;
            this.rbOn.Text = "Encender";
            this.rbOn.UseVisualStyleBackColor = true;
            // 
            // rbOff
            // 
            this.rbOff.AutoSize = true;
            this.rbOff.Checked = true;
            this.rbOff.Location = new System.Drawing.Point(144, 31);
            this.rbOff.Name = "rbOff";
            this.rbOff.Size = new System.Drawing.Size(107, 27);
            this.rbOff.TabIndex = 9;
            this.rbOff.TabStop = true;
            this.rbOff.Text = "Apagar";
            this.rbOff.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxDay);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.rbOn);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.rbOff);
            this.groupBox1.Location = new System.Drawing.Point(13, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 74);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar";
            // 
            // cbxDay
            // 
            this.cbxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDay.FormattingEnabled = true;
            this.cbxDay.Items.AddRange(new object[] {
            "domingo",
            "lunes",
            "martes",
            "miércoles",
            "jueves",
            "viernes",
            "sábado"});
            this.cbxDay.Location = new System.Drawing.Point(257, 27);
            this.cbxDay.Name = "cbxDay";
            this.cbxDay.Size = new System.Drawing.Size(170, 31);
            this.cbxDay.TabIndex = 15;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(433, 26);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(114, 32);
            this.dtpTime.TabIndex = 10;
            // 
            // clock
            // 
            this.clock.Interval = 10000;
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // lblProgramados
            // 
            this.lblProgramados.AutoSize = true;
            this.lblProgramados.Location = new System.Drawing.Point(12, 401);
            this.lblProgramados.Name = "lblProgramados";
            this.lblProgramados.Size = new System.Drawing.Size(175, 23);
            this.lblProgramados.TabIndex = 11;
            this.lblProgramados.Text = "Monitoreando: 0 ";
            // 
            // lbxAlerts
            // 
            this.lbxAlerts.FormattingEnabled = true;
            this.lbxAlerts.ItemHeight = 23;
            this.lbxAlerts.Location = new System.Drawing.Point(16, 598);
            this.lbxAlerts.Name = "lbxAlerts";
            this.lbxAlerts.Size = new System.Drawing.Size(674, 73);
            this.lbxAlerts.TabIndex = 12;
            // 
            // lblExecuting
            // 
            this.lblExecuting.AutoSize = true;
            this.lblExecuting.Location = new System.Drawing.Point(242, 401);
            this.lblExecuting.Name = "lblExecuting";
            this.lblExecuting.Size = new System.Drawing.Size(156, 23);
            this.lblExecuting.TabIndex = 13;
            this.lblExecuting.Text = "En ejecución: 0";
            // 
            // lblLate
            // 
            this.lblLate.AutoSize = true;
            this.lblLate.Location = new System.Drawing.Point(462, 401);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(87, 23);
            this.lblLate.TabIndex = 14;
            this.lblLate.Text = "Tarde: 0";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Location = new System.Drawing.Point(11, 349);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(685, 49);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "Empezar";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbProgramados
            // 
            this.lbProgramados.FormattingEnabled = true;
            this.lbProgramados.ItemHeight = 23;
            this.lbProgramados.Location = new System.Drawing.Point(16, 427);
            this.lbProgramados.Name = "lbProgramados";
            this.lbProgramados.Size = new System.Drawing.Size(224, 142);
            this.lbProgramados.TabIndex = 16;
            // 
            // lbExecuting
            // 
            this.lbExecuting.FormattingEnabled = true;
            this.lbExecuting.ItemHeight = 23;
            this.lbExecuting.Location = new System.Drawing.Point(246, 427);
            this.lbExecuting.Name = "lbExecuting";
            this.lbExecuting.Size = new System.Drawing.Size(214, 142);
            this.lbExecuting.TabIndex = 17;
            // 
            // lbLate
            // 
            this.lbLate.FormattingEnabled = true;
            this.lbLate.ItemHeight = 23;
            this.lbLate.Location = new System.Drawing.Point(466, 427);
            this.lbLate.Name = "lbLate";
            this.lbLate.Size = new System.Drawing.Size(224, 142);
            this.lbLate.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 572);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fallas:";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(558, 277);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(132, 66);
            this.btnDeleteAll.TabIndex = 20;
            this.btnDeleteAll.Text = "Eliminar\r\nTodo";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // frmProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 680);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbLate);
            this.Controls.Add(this.lbExecuting);
            this.Controls.Add(this.lbProgramados);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblLate);
            this.Controls.Add(this.lblExecuting);
            this.Controls.Add(this.lbxAlerts);
            this.Controls.Add(this.lblProgramados);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxPrograms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSprinklers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxRadios);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programar Solenoides";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxRadios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSprinklers;
        private System.Windows.Forms.ListBox lbxPrograms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rbOn;
        private System.Windows.Forms.RadioButton rbOff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Label lblProgramados;
        private System.Windows.Forms.ListBox lbxAlerts;
        private System.Windows.Forms.Label lblExecuting;
        private System.Windows.Forms.Label lblLate;
        private System.Windows.Forms.ComboBox cbxDay;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lbProgramados;
        private System.Windows.Forms.ListBox lbExecuting;
        private System.Windows.Forms.ListBox lbLate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}