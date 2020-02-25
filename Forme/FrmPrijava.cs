using KKI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmPrijava : Form
    {
        public FrmPrijava()
        {
            InitializeComponent();
            this.ActiveControl = txtKorisnickoIme;
            txtKorisnickoIme.Focus();

            //this.ActiveControl = btnPrijaviSe;
            //btnPrijaviSe.Focus();            
        }

        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Komunikacija.Instance.PoveziSe())
                    throw new Exception("Neuspesno povezivanje na server.");

                string poruka = KkiGlavna.Instance.Prijava(txtKorisnickoIme.Text, txtSifra.Text);

                MessageBox.Show(poruka, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmGlavna forma = new FrmGlavna(this);
                forma.ShowDialog();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSifra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnPrijaviSe_Click(sender, e);
            }
        }

        private void txtKorisnickoIme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPrijaviSe_Click(sender, e);
            }
        }

        private void txtSifra_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtKorisnickoIme.Text) ||
                string.IsNullOrEmpty(txtSifra.Text))
            {
                btnPrijaviSe.Enabled = false;
            }
            else
            {
                btnPrijaviSe.Enabled = true;
            }
        }

        private void txtKorisnickoIme_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKorisnickoIme.Text) ||
                string.IsNullOrEmpty(txtSifra.Text))
            {
                btnPrijaviSe.Enabled = false;
            }
            else
            {
                btnPrijaviSe.Enabled = true;
            }
        }

    }
}
