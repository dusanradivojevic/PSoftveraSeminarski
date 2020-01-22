using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmKreirajPutnika : Form
    {
        public FrmKreirajPutnika()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            txtDatumDodavanja.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void txtNazivAranzmana_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            //Prebaciti ovu validaciju u kontroler?
            if (txtJmbg.Text.Length != 13)
            {
                MessageBox.Show("JMBG mora imati tacno 13 cifara!");
                return;
            }
            string jmbg = txtJmbg.Text;
            bool flag = true;
            foreach(char c in jmbg)
            {
                if (!char.IsDigit(c))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                //ovo mora da se pozove tek kad se klikne sacuvaj aranzman
                var rez = Kontroler.Kontroler.Instance.KreirajPutnika(txtJmbg.Text,
                    txtIme.Text, txtPrezime.Text, DateTime.ParseExact(txtDatumDodavanja.Text,
                    "dd-MM-yyyy",CultureInfo.InvariantCulture), 
                    Sesija.Instance.VratiKorisnikaObjekat());
                if (rez != null)
                {
                    MessageBox.Show("Putnik je uspesno sacuvan!");
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da sacuva putnika!");
                }
            }
            else
            {
                MessageBox.Show("Neispravan JMBG!");
            }
        }
    }
}
