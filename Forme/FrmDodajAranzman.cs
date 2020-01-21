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
    public partial class FrmDodajAranzman : Form
    {
        public FrmDodajAranzman()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            dtpDatum.Format = DateTimePickerFormat.Short;
            cmbDestinacija.DataSource = Kontroler.Kontroler.Instance.VratiSveDestinacije();
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void FrmDodajAranzman_Load(object sender, EventArgs e)
        {

        }

        private void txtUkBrMesta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUkBrMesta.Text))
            {
                return;
            }

            if(int.TryParse(txtUkBrMesta.Text, out int ukBr))
            {
                txtBrSlbMesta.Text = ukBr + "";
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            //Prebaciti ovu validaciju u kontroler?
            if(double.TryParse(txtCena.Text, out double cena) &&
                int.TryParse(txtUkBrMesta.Text, out int ukBrMesta) &&
                cmbDestinacija.SelectedItem != null)
            {
                bool rez = Kontroler.Kontroler.Instance.UnesiNoviAranzman(txtNazivAranzmana.Text,
                    rtbOpis.Text, cena, dtpDatum.Value, ukBrMesta, ukBrMesta, ukBrMesta,
                    cmbDestinacija.SelectedItem as Destinacija,
                    Sesija.Instance.VratiKorisnikaObjekat());
                if (rez)
                {
                    MessageBox.Show("Aranzman je uspesno sacuvan!");
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da sacuva aranzman!");
                }
            }
            else
            {
                MessageBox.Show("Unesite cenu u odgovarajucem formatu!");
            }
        }
    }
}
