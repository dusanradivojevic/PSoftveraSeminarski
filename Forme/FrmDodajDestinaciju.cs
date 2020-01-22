using Domen;
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
    public partial class FrmDodajDestinaciju : Form
    {
        public FrmDodajDestinaciju()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            cmbZemlja.DataSource = Kontroler.Kontroler.Instance.VratiSveZemlje();
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbZemlja.SelectedItem != null && cmbZemlja.SelectedItem is Zemlja)
            {
                bool rez = Kontroler.Kontroler.Instance.UnesiNovuDestinaciju(txtNazivGrada.Text,
                    cmbZemlja.SelectedItem as Zemlja,
                    Sesija.Instance.VratiKorisnikaObjekat());
                if (rez)
                {
                    MessageBox.Show("Destinacija je uspesno sacuvana!");
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da sacuva destinaciju!");
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati zemlju!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbZemlja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
