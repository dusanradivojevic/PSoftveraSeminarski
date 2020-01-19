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
            this.ActiveControl = txtKorisnickoIme;
            txtKorisnickoIme.Focus();
        }
               

        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            //Validacija unosa, ovde ili u kontroleru

            string korisnik = Kontroler.Kontroler.Instance.Prijava(txtKorisnickoIme.Text,
                txtSifra.Text);
            if (korisnik != null)
            {
                string[] pom = korisnik.Split(' ');
                Sesija.Instance.PostaviKorisnika(pom[0], pom[1]);

                FrmGlavna forma = new FrmGlavna();
                forma.PostaviKorisnika(Sesija.Instance.VratiKorisnika());
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
