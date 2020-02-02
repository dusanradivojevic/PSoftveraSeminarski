using Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicki;

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

            Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiPodatkeAranzmana, a);
            Aranzman = odg.Objekat as Aranzman;

            Odgovor odg2 = Komunikacija.Instance.KreirajZahtev(Operacija.VratiSve, new Putnik());
            sviPutnici = new BindingList<Putnik>((odg2.Objekat as List<IDomenskiObjekat>).Cast<Putnik>().ToList());
            izabraniPutnici = new BindingList<Putnik>(Aranzman.Putnici);
        }

        public string SacuvajAranzman(string naziv, string opis, string strCena, DateTime datum, 
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

                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.UnesiNoviAranzman, a);
                return odg.Poruka;
            }
            else
            {
                throw new Exception("Neispravan unos vrednosti.");
            }
        }

        internal void DodajKreiranogPutnika(Putnik p)
        {
            if (sviPutnici != null)
            {
                sviPutnici.Add(p);
            }
        }

        public string ObrisiAranzmane(List<DataGridViewRow> redovi)
        {
            Odgovor odg = new Odgovor();
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

                odg = Komunikacija.Instance.KreirajZahtev(Operacija.ObrisiAranzman, a);
            }
            return odg.Poruka;
        }

        public void PostaviSveAranzmane(DataGridView dgvAranzmaniPretraga)
        {
            try
            {
                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiSve, new Aranzman());
                List<Aranzman> listaAran = (odg.Objekat as List<IDomenskiObjekat>).Cast<Aranzman>().ToList();

                if (listaAran != null && listaAran.Count == 0)
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

        public void FiltrirajAranzmane(string naziv, string strCena, string strDatum, 
            string strBrSlbMesta, DataGridView dgvAranzmaniPretraga)
        {
            IDictionary kriterijumi = new Dictionary<string, object>();

            kriterijumi["naziv"] = string.IsNullOrEmpty(naziv) ? "" : naziv;
            kriterijumi["cena"] = double.TryParse(strCena, out double cena) ? cena : 99999;
            kriterijumi["datum"] = DateTime.TryParse(strDatum, out DateTime datum) ? datum : DateTime.ParseExact("31.12.2049", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            kriterijumi["brojSlbMesta"] = int.TryParse(strBrSlbMesta, out int brSlb) ? brSlb : 0;

            Aranzman a = new Aranzman();
            a.Kriterijumi = kriterijumi;

            Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiFiltrirano, a);
            List<Aranzman> listaAranzmana = (odg.Objekat as List<IDomenskiObjekat>).Cast<Aranzman>().ToList();

            if (listaAranzmana != null && listaAranzmana.Count == 0)
            {
                throw new Exception("Nije pronadjen nijedan aranzman koji zadovoljava kriterijume!");
            }

            dgvAranzmaniPretraga.DataSource = listaAranzmana;
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

        public string SacuvajAranzmanSlozen(string id, string naziv, string opis, string strCena, 
            DateTime datum, string strUkBrMesta, string strBrPutnika, string strBrSlbMesta, 
            ComboBox cmbDestinacija)
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

                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.SacuvajAranzmanSlozen, a);
                return odg.Poruka;
            }
            else
            {
                throw new Exception("Neispravan unos vrednosti.");
            }
        }
    }
}
