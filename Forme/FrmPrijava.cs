using Domen;
using Kontroler;
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
            //Validacija unosa, ovde ili u kontroleru
            Korisnik k = Kontroler.Kontroler.Instance.Prijava(txtKorisnickoIme.Text,
                txtSifra.Text);

            if (k != null)
            {
                Sesija.Instance.PostaviKorisnika(k);
                FrmGlavna forma = new FrmGlavna(this);
                forma.PostaviKorisnika(Sesija.Instance.VratiKorisnikaToString());
                forma.ShowDialog();
            }
            else
            {
                MessageBox.Show("Neispravan email ili sifra!");
            }
        }

        private void txtSifra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnPrijaviSe_Click(sender, e);
            }
        }
    }
}
