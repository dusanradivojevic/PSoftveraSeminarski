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
        public FrmDetaljiAranzmana()
        {
            InitializeComponent();
            izabraniPutnici = new BindingList<Putnik>();
            sviPutnici = new BindingList<Putnik>();
        }

        internal void PostaviVrednosti(DataGridViewRow red)
        {
            //treba da se izmesti kontroler KI da forma ne bi imala
            //ref na domenske klase
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

            dgvIzabraniPutnici.DataSource = izabraniPutnici;
            UcitajSvePutnike();
        }

        private void UcitajSvePutnike()
        {
            sviPutnici = new BindingList<Putnik>(Kontroler.Kontroler.Instance.VratiSvePutnike());
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
            //dodati red u asoc klasi
        }
    }
}
