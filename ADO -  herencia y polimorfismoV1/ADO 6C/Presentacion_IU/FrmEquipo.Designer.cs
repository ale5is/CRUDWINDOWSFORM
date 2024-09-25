
namespace Presentacion_IU
{
    partial class FrmEquipo
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
            this.Label14 = new System.Windows.Forms.Label();
            this.Button3 = new System.Windows.Forms.Button();
            this.dataGridJugadores = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridEquipo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TxtColoresEquipo = new System.Windows.Forms.TextBox();
            this.TxtNombreEquipo = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJugadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEquipo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(33, 438);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(45, 13);
            this.Label14.TabIndex = 44;
            this.Label14.Text = "Label14";
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(36, 386);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(323, 23);
            this.Button3.TabIndex = 43;
            this.Button3.Text = "Buscar Equipo con Mayor Puntaje";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // dataGridJugadores
            // 
            this.dataGridJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridJugadores.Location = new System.Drawing.Point(480, 191);
            this.dataGridJugadores.Name = "dataGridJugadores";
            this.dataGridJugadores.Size = new System.Drawing.Size(538, 189);
            this.dataGridJugadores.TabIndex = 42;
            this.dataGridJugadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridJugadores_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Jugadores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Equipos";
            // 
            // dataGridEquipo
            // 
            this.dataGridEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEquipo.Location = new System.Drawing.Point(477, 20);
            this.dataGridEquipo.Name = "dataGridEquipo";
            this.dataGridEquipo.Size = new System.Drawing.Size(541, 139);
            this.dataGridEquipo.TabIndex = 39;
            this.dataGridEquipo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEquipo_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.TxtColoresEquipo);
            this.groupBox1.Controls.Add(this.TxtNombreEquipo);
            this.groupBox1.Controls.Add(this.Label12);
            this.groupBox1.Controls.Add(this.Label11);
            this.groupBox1.Controls.Add(this.Button1);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 369);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Equipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "DT";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.Button2);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.Label15);
            this.groupBox2.Controls.Add(this.Label9);
            this.groupBox2.Controls.Add(this.TextBox4);
            this.groupBox2.Controls.Add(this.Label8);
            this.groupBox2.Controls.Add(this.Label7);
            this.groupBox2.Controls.Add(this.Label6);
            this.groupBox2.Controls.Add(this.TextBox3);
            this.groupBox2.Controls.Add(this.TextBox2);
            this.groupBox2.Controls.Add(this.TextBox1);
            this.groupBox2.Location = new System.Drawing.Point(16, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 229);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Jugadores";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(106, 79);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(299, 20);
            this.textBox6.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "DNI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Apellido";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(105, 49);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(299, 20);
            this.textBox5.TabIndex = 19;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(10, 183);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(394, 37);
            this.Button2.TabIndex = 18;
            this.Button2.Text = "Agregar Jugador";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Profesional",
            "Principiante"});
            this.comboBox2.Location = new System.Drawing.Point(304, 140);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 17;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(301, 114);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(52, 13);
            this.Label15.TabIndex = 14;
            this.Label15.Text = "Categoria";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(208, 114);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(34, 13);
            this.Label9.TabIndex = 15;
            this.Label9.Text = "Goles";
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new System.Drawing.Point(211, 140);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(72, 20);
            this.TextBox4.TabIndex = 16;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(102, 114);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(89, 13);
            this.Label8.TabIndex = 9;
            this.Label8.Text = "Tarjetas Amarillas";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(7, 114);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(75, 13);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "Tarjetas Rojas";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(37, 25);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(44, 13);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Nombre";
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(105, 140);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(72, 20);
            this.TextBox3.TabIndex = 13;
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(10, 141);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(72, 20);
            this.TextBox2.TabIndex = 12;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(105, 19);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(300, 20);
            this.TextBox1.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(117, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 31;
            // 
            // TxtColoresEquipo
            // 
            this.TxtColoresEquipo.Location = new System.Drawing.Point(117, 57);
            this.TxtColoresEquipo.Name = "TxtColoresEquipo";
            this.TxtColoresEquipo.Size = new System.Drawing.Size(231, 20);
            this.TxtColoresEquipo.TabIndex = 27;
            // 
            // TxtNombreEquipo
            // 
            this.TxtNombreEquipo.Location = new System.Drawing.Point(117, 29);
            this.TxtNombreEquipo.Name = "TxtNombreEquipo";
            this.TxtNombreEquipo.Size = new System.Drawing.Size(231, 20);
            this.TxtNombreEquipo.TabIndex = 26;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(13, 60);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(42, 13);
            this.Label12.TabIndex = 29;
            this.Label12.Text = "Colores";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(13, 29);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(97, 13);
            this.Label11.TabIndex = 30;
            this.Label11.Text = "Nombre del Equipo";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(354, 29);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(86, 85);
            this.Button1.TabIndex = 28;
            this.Button1.Text = "Agregar Equipo";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FrmEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 460);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.dataGridJugadores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridEquipo);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmEquipo";
            this.Text = "Equipo";
            this.Load += new System.EventHandler(this.FrmEquipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJugadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEquipo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Button Button3;
        public System.Windows.Forms.DataGridView dataGridJugadores;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dataGridEquipo;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.ComboBox comboBox2;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox TextBox4;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.TextBox TxtColoresEquipo;
        internal System.Windows.Forms.TextBox TxtNombreEquipo;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox textBox5;
        internal System.Windows.Forms.TextBox textBox6;
        internal System.Windows.Forms.Label label10;
    }
}