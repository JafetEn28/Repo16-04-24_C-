namespace Proyecto_Final_PrograIV
{
    partial class RepEquipos
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataEquipos = new System.Windows.Forms.DataGridView();
            this.cbTipoReporte = new System.Windows.Forms.ComboBox();
            this.cbTipoEquipo = new System.Windows.Forms.ComboBox();
            this.btnRep = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(121)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(227, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(329, 37);
            this.label3.TabIndex = 45;
            this.label3.Text = "Generar Reporte Equipos";
            // 
            // dataEquipos
            // 
            this.dataEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEquipos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dataEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEquipos.Location = new System.Drawing.Point(15, 357);
            this.dataEquipos.Name = "dataEquipos";
            this.dataEquipos.ReadOnly = true;
            this.dataEquipos.Size = new System.Drawing.Size(787, 195);
            this.dataEquipos.TabIndex = 50;
            this.dataEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEquipos_CellContentClick);
            // 
            // cbTipoReporte
            // 
            this.cbTipoReporte.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbTipoReporte.FormattingEnabled = true;
            this.cbTipoReporte.Location = new System.Drawing.Point(154, 106);
            this.cbTipoReporte.Name = "cbTipoReporte";
            this.cbTipoReporte.Size = new System.Drawing.Size(476, 33);
            this.cbTipoReporte.TabIndex = 51;
            this.cbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cbTipoReporte_SelectedIndexChanged);
            // 
            // cbTipoEquipo
            // 
            this.cbTipoEquipo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbTipoEquipo.FormattingEnabled = true;
            this.cbTipoEquipo.Location = new System.Drawing.Point(15, 202);
            this.cbTipoEquipo.Name = "cbTipoEquipo";
            this.cbTipoEquipo.Size = new System.Drawing.Size(200, 33);
            this.cbTipoEquipo.TabIndex = 52;
            this.cbTipoEquipo.SelectedIndexChanged += new System.EventHandler(this.cbTipoEquipo_SelectedIndexChanged);
            // 
            // btnRep
            // 
            this.btnRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(67)))), ((int)(((byte)(191)))));
            this.btnRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRep.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRep.ForeColor = System.Drawing.Color.White;
            this.btnRep.Image = global::Proyecto_Final_PrograIV.Properties.Resources.icons8_documento_32;
            this.btnRep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRep.Location = new System.Drawing.Point(271, 282);
            this.btnRep.Name = "btnRep";
            this.btnRep.Size = new System.Drawing.Size(248, 49);
            this.btnRep.TabIndex = 48;
            this.btnRep.Text = "Generar Reporte";
            this.btnRep.UseVisualStyleBackColor = false;
            this.btnRep.Click += new System.EventHandler(this.btnRep_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_Final_PrograIV.Properties.Resources.barraAzulBajo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 558);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 65);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Proyecto_Final_PrograIV.Properties.Resources.Imagen2;
            this.pictureBox2.Location = new System.Drawing.Point(0, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(815, 501);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(121)))));
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Image = global::Proyecto_Final_PrograIV.Properties.Resources.flecha_derecha;
            this.btnAtras.Location = new System.Drawing.Point(12, 12);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(38, 23);
            this.btnAtras.TabIndex = 46;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Proyecto_Final_PrograIV.Properties.Resources.barraAzulBajo;
            this.pictureBox3.Location = new System.Drawing.Point(0, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(815, 63);
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            // 
            // cbMarca
            // 
            this.cbMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(308, 202);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(200, 33);
            this.cbMarca.TabIndex = 53;
            this.cbMarca.SelectedIndexChanged += new System.EventHandler(this.cbMarca_SelectedIndexChanged);
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(584, 202);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(200, 33);
            this.cbDepartamento.TabIndex = 54;
            this.cbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cbDepartamento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(220)))), ((int)(((byte)(225)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.label1.Location = new System.Drawing.Point(12, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 55;
            this.label1.Text = "Tipo Equipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(220)))), ((int)(((byte)(225)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.label2.Location = new System.Drawing.Point(581, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 56;
            this.label2.Text = "Departamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(220)))), ((int)(((byte)(225)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.label4.Location = new System.Drawing.Point(305, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 57;
            this.label4.Text = "Marca:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(220)))), ((int)(((byte)(225)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.label5.Location = new System.Drawing.Point(279, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 25);
            this.label5.TabIndex = 58;
            this.label5.Text = "Seleccione el tipo de reporte:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // RepEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 623);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDepartamento);
            this.Controls.Add(this.cbMarca);
            this.Controls.Add(this.cbTipoEquipo);
            this.Controls.Add(this.cbTipoReporte);
            this.Controls.Add(this.dataEquipos);
            this.Controls.Add(this.btnRep);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RepEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RepEquipos";
            this.Load += new System.EventHandler(this.RepEquipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRep;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dataEquipos;
        private System.Windows.Forms.ComboBox cbTipoReporte;
        private System.Windows.Forms.ComboBox cbTipoEquipo;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}