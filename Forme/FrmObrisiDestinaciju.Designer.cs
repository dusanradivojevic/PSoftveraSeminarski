namespace Forme
{
    partial class FrmObrisiDestinaciju
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObrisiDestinaciju));
            this.dgvDestinacije = new System.Windows.Forms.DataGridView();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNazivGrada = new System.Windows.Forms.TextBox();
            this.btnPretrazi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinacije)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDestinacije
            // 
            this.dgvDestinacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDestinacije.Location = new System.Drawing.Point(12, 69);
            this.dgvDestinacije.Name = "dgvDestinacije";
            this.dgvDestinacije.Size = new System.Drawing.Size(398, 221);
            this.dgvDestinacije.TabIndex = 0;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(12, 300);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(104, 36);
            this.btnObrisi.TabIndex = 9;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(306, 300);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(104, 36);
            this.btnOdustani.TabIndex = 10;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Naziv grada:";
            // 
            // txtNazivGrada
            // 
            this.txtNazivGrada.Location = new System.Drawing.Point(108, 21);
            this.txtNazivGrada.Name = "txtNazivGrada";
            this.txtNazivGrada.Size = new System.Drawing.Size(168, 24);
            this.txtNazivGrada.TabIndex = 12;
            this.txtNazivGrada.TextChanged += new System.EventHandler(this.txtNazivGrada_TextChanged);
            this.txtNazivGrada.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNazivGrada_KeyDown);
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(301, 18);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(109, 30);
            this.btnPretrazi.TabIndex = 13;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // FrmObrisiDestinaciju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 348);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.txtNazivGrada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.dgvDestinacije);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmObrisiDestinaciju";
            this.Text = "Brisanje destinacije";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDestinacije;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNazivGrada;
        private System.Windows.Forms.Button btnPretrazi;
    }
}