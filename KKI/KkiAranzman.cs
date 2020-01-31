using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KKI
{
    public class KkiAranzman
    {
        private BindingList<Putnik> sviPutnici;
        private BindingList<Putnik> izabraniPutnici;
        private Aranzman Aranzman { get; set; }
        private static KkiAranzman _instance;
        public static KkiAranzman Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KkiAranzman();
                }

                return _instance;
            }
        }

        private KkiAranzman()
        {
        }

        ////////////////////
        
        public void PostaviAranzman(DataGridViewRow red)
        {
            Aranzman a = new Aranzman
            {
                AranzmanID = (int)red.Cells[0].Value
            };

            Aranzman = Kontroler.Kontroler.Instance.VratiPodatkeAranzmana(a);

            sviPutnici = new BindingList<Putnik>(Kontroler.Kontroler.Instance.VratiSvePutnike());
            izabraniPutnici = new BindingList<Putnik>(Aranzman.Putnici);
        }

        public void SacuvajAranzman(string naziv, string opis, string strCena, DateTime datum, 
            string strUkBrMesta, string strBrPutnika, string strBrSlbMesta, ComboBox cmbDestinacija)
        {
            if (double.TryParse(strCena, out double cena) &&
                int.TryParse(strUkBrMesta, out int ukBrMesta) &&
                int.TryParse(strBrPutnika, out int brPutnika) &&
                int.TryParse(strBrSlbMesta, out int brSlbMesta) &&
                cmbDestinacija.SelectedItem != null && cmbDestinacija.SelectedItem is Destinacija)
            {
                Aranzman a = new Aranzman
                {
                    NazivAranzmana = naziv,
                    OpisAranzmana = opis,
                    Cena = cena,
                    Datum = datum,
                    UkupanBrMesta = ukBrMesta,
                    BrojPutnika = brPutnika,
                    BrSlobodnihMesta = brSlbMesta,
                    Destinacija = cmbDestinacija.SelectedItem as Destinacija,
                    Korisnik = Sesija.Instance.VratiKorisnikaObjekat()
                };

                if (!Kontroler.Kontroler.Instance.UnesiNoviAranzman(a))
                {
                    throw new Exception("Sistem ne moze da sacuva aranzman!");
                }
            }
            else
            {
                throw new Exception("Neispravan unos vrednosti.");
            }
        }

        internal void DodajKreiranogPutnika(Putnik p)
        {
            sviPutnici.Add(p);
        }

        public void ObrisiAranzmane(List<DataGridViewRow> redovi)
        {
            foreach (DataGridViewRow red in redovi)
            {
                Aranzman a = new Aranzman
                {
                    AranzmanID = (int)red.Cells[0].Value,
                    NazivAranzmana = (string)red.Cells[1].Value,
                    OpisAranzmana = (string)red.Cells[2].Value,
                    Cena = (double)red.Cells[3].Value,
                    Datum = (DateTime)red.Cells[4].Value,
                    UkupanBrMesta = (int)red.Cells[5].Value,
                    BrojPutnika = (int)red.Cells[6].Value,
                    BrSlobodnihMesta = (int)red.Cells[7].Value,
                    Destinacija = red.Cells[8].Value as Destinacija,
                    Korisnik = red.Cells[9].Value as Korisnik
                };

                if (!Kontroler.Kontroler.Instance.ObrisiAranzman(a))
                {
                    throw new Exception("Sistem ne moze da obrise aranzmane!");
                }
            }
        }

        public void PostaviSveAranzmane(DataGridView dgvAranzmaniPretraga)
        {
            try
            {
                List<Aranzman> listaAran = Kontroler.Kontroler.Instance.VratiSveAranzmane();

                if (listaAran.Count == 0)
                {
                    throw new Exception("Neuspesno ucitavanje aranzmana!");
                }

                dgvAranzmaniPretraga.DataSource = listaAran;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void IzaberiPutnike(DataGridView izvoriste, DataGridView odrediste, List<DataGridViewRow> redovi)
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

                if (izvoriste.Name.Equals("dgvSviPutnici"))
                {
                    sviPutnici.Remove(p);
                    izabraniPutnici.Add(p);
                }
                else
                {
                    izabraniPutnici.Remove(p);
                    sviPutnici.Add(p);
                }
            }
        }

        public void PostaviSvePutnike(DataGridView dgvSviPutnici)
        {    
            foreach (Putnik p in this.izabraniPutnici)
            {
                if (sviPutnici.Contains(p))
                {
                    sviPutnici.Remove(p);
                }
            }

            dgvSviPutnici.DataSource = sviPutnici;
        }

        public void IspisiDetaljeAranzmana(TextBox txtID, TextBox txtNazivAranzmana, RichTextBox rtbOpis, TextBox txtCena, TextBox txtDatum, TextBox txtUkBrMesta, TextBox txtBrojPutnika, TextBox txtBrSlbMesta, TextBox txtDestinacija, TextBox txtKorisnik)
        {
            txtID.Text = Aranzman.AranzmanID + "";
            txtNazivAranzmana.Text = Aranzman.NazivAranzmana;
            rtbOpis.Text = Aranzman.OpisAranzmana;
            txtCena.Text = Aranzman.Cena + " e";
            txtDatum.Text = Aranzman.Datum.ToString("dd.MM.yyyy");
            txtUkBrMesta.Text = Aranzman.UkupanBrMesta + "";
            txtBrojPutnika.Text = Aranzman.BrojPutnika + "";
            txtBrSlbMesta.Text = Aranzman.BrSlobodnihMesta + "";
            txtDestinacija.Text = Aranzman.Destinacija.ToString();
            txtKorisnik.Text = Aranzman.Korisnik.ToString();
        }

        public void PostaviPutnikeZaAranzman(DataGridView izabraniPutnici)
        {
            izabraniPutnici.DataSource = this.izabraniPutnici;
        }

        public void SacuvajAranzmanSlozen(string id, string naziv, string opis, string strCena, 
            DateTime datum, string strUkBrMesta, string strBrPutnika, string strBrSlbMesta, 
            ComboBox cmbDestinacija, DataGridView izabraniPutnici)
        {
            Destinacija dest;

            if (double.TryParse(strCena.Substring(0, strCena.Length - 2), out double cena) &&
                int.TryParse(strUkBrMesta, out int ukBrMesta) &&
                int.TryParse(strBrPutnika, out int brPutnika) &&
                int.TryParse(strBrSlbMesta, out int brSlbMesta) &&
                int.TryParse(id, out int aID))
            {
                if (cmbDestinacija.Visible)
                {
                    if (cmbDestinacija.SelectedItem != null && cmbDestinacija.SelectedItem is Destinacija)
                    {
                        dest = cmbDestinacija.SelectedItem as Destinacija;
                    }
                    else
                    {
                        throw new Exception("Neispravan unos vrednosti za destinaciju.");
                    }
                }
                else
                {
                    dest = Aranzman.Destinacija;
                }

                Aranzman a = new Aranzman
                {
                    AranzmanID = aID,
                    NazivAranzmana = naziv,
                    OpisAranzmana = opis,
                    Cena = cena,
                    Datum = datum,
                    UkupanBrMesta = ukBrMesta,
                    BrojPutnika = brPutnika,
                    BrSlobodnihMesta = brSlbMesta,
                    Destinacija = dest,
                    Korisnik = Aranzman.Korisnik, //ako stavim sesiju onda ce se menjati za svaki update
                    Putnici = this.izabraniPutnici.ToList()
                };

                if (!Kontroler.Kontroler.Instance.SacuvajAranzmanSlozen(a))
                {
                    throw new Exception("Sistem ne moze da sacuva aranzman!");
                }
            }
            else
            {
                throw new Exception("Neispravan unos vrednosti.");
            }
        }
    }
}
