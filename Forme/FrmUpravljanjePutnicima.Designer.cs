namespace Forme
{
    partial class FrmUpravljanjePutnicima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpravljanjePutnicima));
            this.txtKorisnik = new System.Windows.Forms.TextBox();
            this.btnKreiraj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatumDodavanja = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJmbg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSviPutnici = new System.Windows.Forms.DataGridView();
            this.btnZavrsi = new System.Windows.Forms.Button();
            this.btnObrisiPutnike = new System.Windows.Forms.Button();
            this.grp1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSviPutnici)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKorisnik
            // 
            this.txtKorisnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKorisnik.Location = new System.Drawing.Point(85, 246);
            this.txtKorisnik.Name = "txtKorisnik";
            this.txtKorisnik.ReadOnly = true;
            this.txtKorisnik.Size = new System.Drawing.Size(210, 24);
            this.txtKorisnik.TabIndex = 47;
            // 
            // btnKreiraj
            // 
            this.btnKreiraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKreiraj.Location = new System.Drawing.Point(139, 290);
            this.btnKreiraj.Name = "btnKreiraj";
            this.btnKreiraj.Size = new System.Drawing.Size(99, 40);
            this.btnKreiraj.TabIndex = 45;
            this.btnKreiraj.Text = "Kreiraj";
            this.btnKreiraj.UseVisualStyleBackColor = true;
            this.btnKreiraj.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "Datum dodavanja:";
            // 
            // txtDatumDodavanja
            // 
            this.txtDatumDodavanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatumDodavanja.Location = new System.Drawing.Point(85, 186);
            this.txtDatumDodavanja.Name = "txtDatumDodavanja";
            this.txtDatumDodavanja.ReadOnly = true;
            this.txtDatumDodavanja.Size = new System.Drawing.Size(210, 24);
            this.txtDatumDodavanja.TabIndex = 43;
            // 
            // txtIme
            // 
            this.txtIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIme.Location = new System.Drawing.Point(85, 74);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(210, 24);
            this.txtIme.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "Ime:";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrezime.Location = new System.Drawing.Point(85, 113);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(210, 24);
            this.txtPrezime.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "Prezime:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(156, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 18);
            this.label9.TabIndex = 38;
            this.label9.Text = "Korisnik:";
            // 
            // txtJmbg
            // 
            this.txtJmbg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJmbg.Location = new System.Drawing.Point(85, 35);
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.Size = new System.Drawing.Size(210, 24);
            this.txtJmbg.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "JMBG:";
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.txtPrezime);
            this.grp1.Controls.Add(this.txtKorisnik);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Controls.Add(this.txtJmbg);
            this.grp1.Controls.Add(this.btnKreiraj);
            this.grp1.Controls.Add(this.label9);
            this.grp1.Controls.Add(this.label4);
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.txtDatumDodavanja);
            this.grp1.Controls.Add(this.label3);
            this.grp1.Controls.Add(this.txtIme);
            this.grp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp1.Location = new System.Drawing.Point(412, 12);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(339, 336);
            this.grp1.TabIndex = 48;
            this.grp1.TabStop = false;
            this.grp1.Text = "Kreiraj putnika";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSviPutnici);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 195);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Svi putnici";
            // 
            // dgvSviPutnici
            // 
            this.dgvSviPutnici.AllowUserToAddRows = false;
            this.dgvSviPutnici.AllowUserToDeleteRows = false;
            this.dgvSviPutnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSviPutnici.Location = new System.Drawing.Point(7, 24);
            this.dgvSviPutnici.Name = "dgvSviPutnici";
            this.dgvSviPutnici.ReadOnly = true;
            this.dgvSviPutnici.Size = new System.Drawing.Size(374, 165);
            this.dgvSviPutnici.TabIndex = 0;
            // 
            // btnZavrsi
            // 
            this.btnZavrsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZavrsi.Location = new System.Drawing.Point(150, 302);
            this.btnZavrsi.Name = "btnZavrsi";
            this.btnZavrsi.Size = new System.Drawing.Size(99, 40);
            this.btnZavrsi.TabIndex = 50;
            this.btnZavrsi.Text = "Zavrsi";
            this.btnZavrsi.UseVisualStyleBackColor = true;
            this.btnZavrsi.Click += new System.EventHandler(this.btnZavrsi_Click);
            // 
            // btnObrisiPutnike
            // 
            this.btnObrisiPutnike.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiPutnike.Location = new System.Drawing.Point(122, 207);
            this.btnObrisiPutnike.Name = "btnObrisiPutnike";
            this.btnObrisiPutnike.Size = new System.Drawing.Size(171, 35);
            this.btnObrisiPutnike.TabIndex = 51;
            this.btnObrisiPutnike.Text = "Obrisi izabrane putnike";
            this.btnObrisiPutnike.UseVisualStyleBackColor = true;
            this.btnObrisiPutnike.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // FrmUpravljanjePutnicima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 356);
            this.Controls.Add(this.btnObrisiPutnike);
            this.Controls.Add(this.btnZavrsi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUpravljanjePutnicima";
            this.Text = "FrmUpravljanjePutnicima";
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSviPutnici)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtKorisnik;
        private System.Windows.Forms.Button btnKreiraj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDatumDodavanja;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtJmbg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSviPutnici;
        private System.Windows.Forms.Button btnZavrsi;
        private System.Windows.Forms.Button btnObrisiPutnike;
    }
}