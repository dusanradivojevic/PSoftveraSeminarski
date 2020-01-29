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
    public partial class FrmDetaljiAranzmana : Form
    {
        private BindingList<Putnik> izabraniPutnici;
        private BindingList<Putnik> sviPutnici;
        private Aranzman aranzman;
        public FrmDetaljiAranzmana()
        {
            InitializeComponent();
            izabraniPutnici = new BindingList<Putnik>();
            sviPutnici = new BindingList<Putnik>();
        }

        internal void PostaviVrednosti(Aranzman a)
        {
            //treba da se izmesti kontroler KI da forma ne bi imala
            //ref na domenske klase

            /*
                txtID.Text = (int) red.Cells[0].Value + "";
                txtNazivAranzmana.Text = red.Cells[1].Value as string;
                rtbOpis.Text = red.Cells[2].Value as string;
                txtCena.Text = (double) red.Cells[3].Value + " e";
                txtDatum.Text = red.Cells[4].Value.ToString().Split(' ')[0]+"20";
                txtUkBrMesta.Text = (int)red.Cells[5].Value + "";
                txtBrojPutnika.Text = (int)red.Cells[6].Value + "";
                txtBrSlbMesta.Text = (int)red.Cells[7].Value + "";
                txtDestinacija.Text = (red.Cells[8].Value as Destinacija).ToString();
                txtKorisnik.Text = (red.Cells[9].Value as Korisnik).ToString();
            */
            aranzman = a;

            txtID.Text = a.AranzmanID + "";
            txtNazivAranzmana.Text = a.NazivAranzmana;
            rtbOpis.Text = a.OpisAranzmana;
            txtCena.Text = a.Cena + " e";
            txtDatum.Text = a.Datum.ToString("dd.MM.yyyy");
            txtUkBrMesta.Text = a.UkupanBrMesta + "";
            txtBrojPutnika.Text = a.BrojPutnika + "";
            txtBrSlbMesta.Text = a.BrSlobodnihMesta + "";
            txtDestinacija.Text = a.Destinacija.ToString();
            txtKorisnik.Text = a.Korisnik.ToString();

            izabraniPutnici = new BindingList<Putnik>(a.Putnici);
            dgvIzabraniPutnici.DataSource = izabraniPutnici;
            UcitajSvePutnike();
        }

        private void UcitajSvePutnike()
        {
            sviPutnici = new BindingList<Putnik>(Kontroler.Kontroler.Instance.VratiSvePutnike());
            foreach(Putnik p in sviPutnici.ToList())
            {
                if (izabraniPutnici.Contains(p))
                {
                    sviPutnici.Remove(p);
                }
            }
            dgvSviPutnici.DataSource = sviPutnici;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnIzaberiPutnike_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach(DataGridViewCell celija in dgvSviPutnici.SelectedCells)
            {
                int rowIndex = celija.RowIndex;
                bool postoji = false;
                foreach(DataGridViewRow red in redovi)
                {
                    if(red.Index == rowIndex)
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

            DodajPutnike(redovi, izabraniPutnici);
            IzbaciPutnike(redovi, sviPutnici);
        }

        private void DodajPutnike(List<DataGridViewRow> redovi, BindingList<Putnik> odrediste)
        {
            foreach(DataGridViewRow red in redovi)
            {
                Putnik p = new Putnik
                {
                    JMBG = (string)red.Cells[0].Value,
                    Ime = (string)red.Cells[1].Value,
                    Prezime = (string)red.Cells[2].Value,
                    DatumDodavanja = (DateTime)red.Cells[3].Value,
                    Korisnik = red.Cells[4].Value as Korisnik
                };

                odrediste.Add(p);
            }
        }

        internal void OtkljucajPolja()
        {
            txtNazivAranzmana.ReadOnly = false;
            rtbOpis.ReadOnly = false;
            txtCena.ReadOnly = false;
            txtBrSlbMesta.ReadOnly = false;
            txtUkBrMesta.ReadOnly = false;
            txtBrojPutnika.ReadOnly = false;

            txtDatum.Visible = false;
            dtpDatum.Visible = true;

            txtDestinacija.Visible = false;
            cmbDestinacija.Visible = true;
            cmbDestinacija.DataSource = Kontroler.Kontroler.Instance.VratiSveDestinacije();
        }

        private void btnIzbaci_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach (DataGridViewCell celija in dgvIzabraniPutnici.SelectedCells)
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
                    redovi.Add(dgvIzabraniPutnici.Rows[rowIndex]);
                }
            }

            DodajPutnike(redovi, sviPutnici);
            IzbaciPutnike(redovi, izabraniPutnici);
        }

        private void IzbaciPutnike(List<DataGridViewRow> redovi, BindingList<Putnik> izvoriste)
        {
            foreach (DataGridViewRow red in redovi)
            {
                Putnik p = new Putnik
                {
                    JMBG = (string)red.Cells[0].Value,
                    Ime = (string)red.Cells[1].Value,
                    Prezime = (string)red.Cells[2].Value,
                    DatumDodavanja = (DateTime)red.Cells[3].Value,
                    Korisnik = red.Cells[4].Value as Korisnik
                };

                izvoriste.Remove(p);
            }
        }
               
        private void btnKreirajPutnika_Click(object sender, EventArgs e)
        {
            FrmKreirajPutnika forma = new FrmKreirajPutnika();
            forma.ShowDialog();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            double cena = Convert.ToDouble(txtCena.Text.Substring(0, txtCena.Text.Length - 2));

            if (Kontroler.Kontroler.Instance.SacuvajAranzman(Convert.ToInt32(txtID.Text), txtNazivAranzmana.Text,
                rtbOpis.Text, cena, dtpDatum.Value, Convert.ToInt32(txtUkBrMesta.Text),
                Convert.ToInt32(txtBrojPutnika.Text), Convert.ToInt32(txtBrSlbMesta.Text),
                cmbDestinacija.SelectedItem as Destinacija, Sesija.Instance.VratiKorisnikaObjekat(),
                izabraniPutnici.ToList()))
            {
                MessageBox.Show("Uspesan unos");
                Dispose();
            }
            else
            {
                MessageBox.Show("Neuspeno..");
            }
        }

        private void txtDestinacija_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
