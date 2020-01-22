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
    public partial class FrmUpravljanjePutnicima : Form
    {
        private BindingList<Putnik> sviPutnici;
        public FrmUpravljanjePutnicima()
        {
            InitializeComponent();
            sviPutnici = new BindingList<Putnik>();
            SrediFormu();
        }

        private void SrediFormu()
        {
            UcitajPutnike();
            txtDatumDodavanja.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void UcitajPutnike()
        {
            sviPutnici = new BindingList<Putnik>(Kontroler.Kontroler.Instance.VratiSvePutnike());
            dgvSviPutnici.DataSource = sviPutnici;
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            //Prebaciti ovu validaciju u kontroler?
            if(txtJmbg.Text.Length != 13)
            {
                MessageBox.Show("JMBG mora imati tacno 13 cifara!");
                return;
            }
            string jmbg = txtJmbg.Text;
            bool flag = true;
            foreach (char c in jmbg)
            {
                if (!char.IsDigit(c))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                Putnik rez = Kontroler.Kontroler.Instance.KreirajPutnika(txtJmbg.Text,
                    txtIme.Text, txtPrezime.Text, DateTime.ParseExact(txtDatumDodavanja.Text,
                    "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Sesija.Instance.VratiKorisnikaObjekat());
                if (rez != null)
                {
                    MessageBox.Show("Putnik je uspesno sacuvan!");
                    sviPutnici.Add(rez);
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

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach (DataGridViewCell celija in dgvSviPutnici.SelectedCells)
            {
                int rowIndex = celija.RowIndex;
                bool postoji = false;
                foreach (DataGridViewRow red in redovi)
                {
                    if (red.Index == rowIndex)
                    {
                        postoji = true;
                        break;
                    }
                }

                if (!postoji)
                {
                    redovi.Add(dgvSviPutnici.Rows[rowIndex]);
                }
            }

            foreach (DataGridViewRow red in redovi)
            {
                //preneti u Kontroler KI
                Putnik p = new Putnik
                {
                    JMBG = (string)red.Cells[0].Value,
                    Ime = (string)red.Cells[1].Value,
                    Prezime = (string)red.Cells[2].Value,
                    DatumDodavanja = (DateTime)red.Cells[3].Value,
                    Korisnik = red.Cells[4].Value as Korisnik
                };

                if (Kontroler.Kontroler.Instance.ObrisiPutnika(p))
                {
                    sviPutnici.Remove(p);
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da obrise putnike!");
                    return;
                }
            }

            MessageBox.Show("Sistem je uspesno obrisao putnike!");
        }

        private void btnZavrsi_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
