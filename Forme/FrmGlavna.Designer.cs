﻿namespace Forme
{
    partial class FrmGlavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGlavna));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrikaziDetalje = new System.Windows.Forms.Button();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrSlbMesta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAranzmaniPretraga = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.upravljanjeDestinacijamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upravljanjePutnicimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjavaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjaviSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOcisti = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAranzmaniPretraga)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOcisti);
            this.groupBox1.Controls.Add(this.txtDatum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnPrikaziDetalje);
            this.groupBox1.Controls.Add(this.btnPretrazi);
            this.groupBox1.Controls.Add(this.txtNaziv);
            this.groupBox1.Controls.Add(this.txtCena);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBrSlbMesta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvAranzmaniPretraga);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 325);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(278, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "(gornja granica)";
            // 
            // btnPrikaziDetalje
            // 
            this.btnPrikaziDetalje.Location = new System.Drawing.Point(9, 233);
            this.btnPrikaziDetalje.Name = "btnPrikaziDetalje";
            this.btnPrikaziDetalje.Size = new System.Drawing.Size(131, 39);
            this.btnPrikaziDetalje.TabIndex = 15;
            this.btnPrikaziDetalje.Text = "Prikazi detalje";
            this.btnPrikaziDetalje.UseVisualStyleBackColor = true;
            this.btnPrikaziDetalje.Click += new System.EventHandler(this.btnPrikaziDetalje_Click);
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(9, 157);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(131, 39);
            this.btnPretrazi.TabIndex = 14;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(89, 38);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(149, 24);
            this.txtNaziv.TabIndex = 12;
            this.txtNaziv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNaziv_KeyDown);
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(256, 38);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(149, 24);
            this.txtCena.TabIndex = 11;
            this.txtCena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCena_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kriterijumi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Broj slobodnih mesta:";
            // 
            // txtBrSlbMesta
            // 
            this.txtBrSlbMesta.Location = new System.Drawing.Point(427, 38);
            this.txtBrSlbMesta.Name = "txtBrSlbMesta";
            this.txtBrSlbMesta.Size = new System.Drawing.Size(149, 24);
            this.txtBrSlbMesta.TabIndex = 8;
            this.txtBrSlbMesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBrSlbMesta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrSlbMesta_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cena:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naziv:";
            // 
            // dgvAranzmaniPretraga
            // 
            this.dgvAranzmaniPretraga.AllowUserToAddRows = false;
            this.dgvAranzmaniPretraga.AllowUserToDeleteRows = false;
            this.dgvAranzmaniPretraga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAranzmaniPretraga.Location = new System.Drawing.Point(146, 86);
            this.dgvAranzmaniPretraga.Name = "dgvAranzmaniPretraga";
            this.dgvAranzmaniPretraga.ReadOnly = true;
            this.dgvAranzmaniPretraga.Size = new System.Drawing.Size(602, 233);
            this.dgvAranzmaniPretraga.TabIndex = 1;
            this.dgvAranzmaniPretraga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAranzmaniPretraga_KeyDown);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.Location = new System.Drawing.Point(12, 375);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(131, 39);
            this.btnDodaj.TabIndex = 16;
            this.btnDodaj.Text = "Dodaj novi";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.Location = new System.Drawing.Point(324, 375);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(131, 39);
            this.btnIzmeni.TabIndex = 17;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.Location = new System.Drawing.Point(635, 375);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(131, 39);
            this.btnObrisi.TabIndex = 18;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upravljanjeDestinacijamaToolStripMenuItem,
            this.upravljanjePutnicimaToolStripMenuItem,
            this.odjavaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // upravljanjeDestinacijamaToolStripMenuItem
            // 
            this.upravljanjeDestinacijamaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem,
            this.obrisiToolStripMenuItem});
            this.upravljanjeDestinacijamaToolStripMenuItem.Name = "upravljanjeDestinacijamaToolStripMenuItem";
            this.upravljanjeDestinacijamaToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.upravljanjeDestinacijamaToolStripMenuItem.Text = "Upravljaj destinacijama";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            this.dodajToolStripMenuItem.Click += new System.EventHandler(this.dodajToolStripMenuItem_Click);
            // 
            // obrisiToolStripMenuItem
            // 
            this.obrisiToolStripMenuItem.Name = "obrisiToolStripMenuItem";
            this.obrisiToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.obrisiToolStripMenuItem.Text = "Obrisi";
            this.obrisiToolStripMenuItem.Click += new System.EventHandler(this.obrisiToolStripMenuItem_Click);
            // 
            // upravljanjePutnicimaToolStripMenuItem
            // 
            this.upravljanjePutnicimaToolStripMenuItem.Name = "upravljanjePutnicimaToolStripMenuItem";
            this.upravljanjePutnicimaToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.upravljanjePutnicimaToolStripMenuItem.Text = "Upravljaj putnicima";
            this.upravljanjePutnicimaToolStripMenuItem.Click += new System.EventHandler(this.upravljanjePutnicimaToolStripMenuItem_Click);
            // 
            // odjavaToolStripMenuItem
            // 
            this.odjavaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odjaviSeToolStripMenuItem});
            this.odjavaToolStripMenuItem.Name = "odjavaToolStripMenuItem";
            this.odjavaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.odjavaToolStripMenuItem.Text = "Odjava";
            // 
            // odjaviSeToolStripMenuItem
            // 
            this.odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            this.odjaviSeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.odjaviSeToolStripMenuItem.Text = "Odjavi se";
            this.odjaviSeToolStripMenuItem.Click += new System.EventHandler(this.odjaviSeToolStripMenuItem_Click);
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(599, 38);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(149, 24);
            this.txtDatum.TabIndex = 20;
            this.txtDatum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDatum_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(642, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Datum:";
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(9, 86);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(131, 26);
            this.btnOcisti.TabIndex = 21;
            this.btnOcisti.Text = "Ocisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            this.btnOcisti.Click += new System.EventHandler(this.btnOcisti_Click);
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 420);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmGlavna";
            this.Text = "Pretraga aranzmana";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGlavna_FormClosing);
            this.Load += new System.EventHandler(this.FrmGlavna_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAranzmaniPretraga)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAranzmaniPretraga;
        private System.Windows.Forms.Button btnPrikaziDetalje;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrSlbMesta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem upravljanjeDestinacijamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upravljanjePutnicimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odjavaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odjaviSeToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.Label label2;
    }
}