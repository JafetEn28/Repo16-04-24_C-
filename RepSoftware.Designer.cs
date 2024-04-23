namespace Proyecto_Final_PrograIV
{
    partial class RepSoftware
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
            this.dataSoftware = new System.Windows.Forms.DataGridView();
            this.cbTipoRepSoft = new System.Windows.Forms.ComboBox();
            this.cbNombreSoftware = new System.Windows.Forms.ComboBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnRep = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbTipoLicencia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEquipos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSoftware)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(121)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(56, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 25);
            this.label3.TabIndex = 45;
            this.label3.Text = "Generar Reporte SoftWare";
            // 
            // dataSoftware
            // 
            this.dataSoftware.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSoftware.Location = new System.Drawing.Point(81, 209);
            this.dataSoftware.Name = "dataSoftware";
            this.dataSoftware.ReadOnly = true;
            this.dataSoftware.Size = new System.Drawing.Size(713, 214);
            this.dataSoftware.TabIndex = 50;
            this.dataSoftware.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSoftware_CellContentClick);
            // 
            // cbTipoRepSoft
            // 
            this.cbTipoRepSoft.FormattingEnabled = true;
            this.cbTipoRepSoft.Location = new System.Drawing.Point(315, 71);
            this.cbTipoRepSoft.Name = "cbTipoRepSoft";
            this.cbTipoRepSoft.Size = new System.Drawing.Size(237, 21);
            this.cbTipoRepSoft.TabIndex = 51;
<<<<<<< Updated upstream
            this.cbTipoRepSoft.SelectedIndexChanged += new System.EventHandler(this.cbTipoRepSoft_SelectedIndexChanged);
=======
>>>>>>> Stashed changes
            // 
            // cbNombreSoftware
            // 
            this.cbNombreSoftware.FormattingEnabled = true;
            this.cbNombreSoftware.Location = new System.Drawing.Point(12, 158);
            this.cbNombreSoftware.Name = "cbNombreSoftware";
            this.cbNombreSoftware.Size = new System.Drawing.Size(237, 21);
            this.cbNombreSoftware.TabIndex = 52;
            this.cbNombreSoftware.SelectedIndexChanged += new System.EventHandler(this.cbNombreSoftware_SelectedIndexChanged);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(121)))));
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Image = global::Proyecto_Final_PrograIV.Properties.Resources.flecha_derecha;
            this.btnAtras.Location = new System.Drawing.Point(12, 6);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(38, 23);
            this.btnAtras.TabIndex = 46;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Proyecto_Final_PrograIV.Properties.Resources.barraAzulBajo;
            this.pictureBox3.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(882, 37);
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_Final_PrograIV.Properties.Resources.barraAzulBajo;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 496);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(882, 57);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // BtnRep
            // 
            this.BtnRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(67)))), ((int)(((byte)(191)))));
            this.BtnRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRep.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRep.ForeColor = System.Drawing.Color.White;
            this.BtnRep.Image = global::Proyecto_Final_PrograIV.Properties.Resources.icons8_documento_32;
            this.BtnRep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRep.Location = new System.Drawing.Point(327, 444);
            this.BtnRep.Name = "BtnRep";
            this.BtnRep.Size = new System.Drawing.Size(225, 46);
            this.BtnRep.TabIndex = 48;
            this.BtnRep.Text = "Generar Reporte";
            this.BtnRep.UseVisualStyleBackColor = false;
            this.BtnRep.Click += new System.EventHandler(this.BtnRep_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Proyecto_Final_PrograIV.Properties.Resources.Imagen2;
            this.pictureBox2.Location = new System.Drawing.Point(-1, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(857, 465);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // cbTipoLicencia
            // 
            this.cbTipoLicencia.FormattingEnabled = true;
            this.cbTipoLicencia.Location = new System.Drawing.Point(619, 158);
            this.cbTipoLicencia.Name = "cbTipoLicencia";
            this.cbTipoLicencia.Size = new System.Drawing.Size(237, 21);
            this.cbTipoLicencia.TabIndex = 55;
            this.cbTipoLicencia.SelectedIndexChanged += new System.EventHandler(this.cbTipoLicencia_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "Seleccione el tipo de reporte:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Equipos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(615, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 61;
            this.label5.Text = "Tipo de Licencia:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 62;
            this.label6.Text = "Nombre SoftWare:";
            // 
            // cbEquipos
            // 
            this.cbEquipos.FormattingEnabled = true;
<<<<<<< Updated upstream
            this.cbEquipos.Location = new System.Drawing.Point(315, 158);
=======
            this.cbEquipos.Location = new System.Drawing.Point(315, 182);
>>>>>>> Stashed changes
            this.cbEquipos.Name = "cbEquipos";
            this.cbEquipos.Size = new System.Drawing.Size(237, 21);
            this.cbEquipos.TabIndex = 63;
            this.cbEquipos.SelectedIndexChanged += new System.EventHandler(this.cbEquipos_SelectedIndexChanged);
            // 
            // RepSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 546);
            this.Controls.Add(this.cbEquipos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTipoLicencia);
            this.Controls.Add(this.cbNombreSoftware);
            this.Controls.Add(this.cbTipoRepSoft);
            this.Controls.Add(this.dataSoftware);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnRep);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RepSoftware";
            this.Text = "RepSoftware";
            this.Load += new System.EventHandler(this.RepSoftware_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSoftware)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnRep;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataSoftware;
        private System.Windows.Forms.ComboBox cbTipoRepSoft;
        private System.Windows.Forms.ComboBox cbNombreSoftware;
        private System.Windows.Forms.ComboBox cbTipoLicencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbEquipos;
    }
}