namespace Forme
{
    partial class FrmPrijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrijava));
            this.btnPrijaviSe = new System.Windows.Forms.Button();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrijaviSe
            // 
            this.btnPrijaviSe.Location = new System.Drawing.Point(198, 159);
            this.btnPrijaviSe.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrijaviSe.Name = "btnPrijaviSe";
            this.btnPrijaviSe.Size = new System.Drawing.Size(126, 36);
            this.btnPrijaviSe.TabIndex = 0;
            this.btnPrijaviSe.Text = "Prijavi se";
            this.btnPrijaviSe.UseVisualStyleBackColor = true;
            this.btnPrijaviSe.Click += new System.EventHandler(this.btnPrijaviSe_Click);
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(151, 36);
            this.txtKorisnickoIme.Margin = new System.Windows.Forms.Padding(4);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(226, 24);
            this.txtKorisnickoIme.TabIndex = 1;
            this.txtKorisnickoIme.Text = "r.dusan97@gmail.com";
            this.txtKorisnickoIme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKorisnickoIme_KeyDown);
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(151, 105);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.PasswordChar = '*';
            this.txtSifra.Size = new System.Drawing.Size(226, 24);
            this.txtSifra.TabIndex = 2;
            this.txtSifra.Text = "123";
            this.txtSifra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifra_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Korisnicko ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Šifra:";
            // 
            // FrmPrijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 215);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.txtKorisnickoIme);
            this.Controls.Add(this.btnPrijaviSe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrijava";
            this.Text = "Prijava";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrijaviSe;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

