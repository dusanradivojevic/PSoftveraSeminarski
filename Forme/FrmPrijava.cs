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
            //this.ActiveControl = txtKorisnickoIme;
            //txtKorisnickoIme.Focus();

            this.ActiveControl = btnPrijaviSe;
            btnPrijaviSe.Focus();
        }

        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Komunikacija.Instance.PoveziSe())
                    throw new Exception("Neuspesno povezivanje na server.");

                string poruka = KkiGlavna.Instance.Prijava(txtKorisnickoIme.Text, txtSifra.Text);

                MessageBox.Show(poruka);

                FrmGlavna forma = new FrmGlavna(this);
                forma.ShowDialog();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
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
    }
}
