using Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KKI
{
    public class KkiPutnik
    {
        private static KkiPutnik _instance;
        public static KkiPutnik Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KkiPutnik();
                }

                return _instance;
            }
        }
        private KkiPutnik()
        {
        }

        ////////////////////
        
        public void KreirajPutnika(string jmbg, string ime, string prezime, string datum)
        {
            if (jmbg.Length != 13)
            {
                throw new Exception("Neispravan jmbg!");
            }

            foreach (char c in jmbg)
            {
                if (!char.IsDigit(c))
                {
                    throw new Exception("Neispravan jmbg!");
                }
            }

            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime))
                throw new Exception("Unesite sve podatke!");

            if(!DateTime.TryParseExact(datum, "dd-MM-yyyy", CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out DateTime dat))
            {
                throw new Exception("Neuspesno parsiranje datuma!");
            }

            Putnik p = new Putnik
            {
                JMBG = jmbg,
                Ime = ime,
                Prezime = prezime,
                DatumDodavanja = dat,
                Korisnik = Sesija.Instance.VratiKorisnikaObjekat()
            };

            if (!Kontroler.Kontroler.Instance.KreirajPutnika(p))
            {
                throw new Exception("Sistem ne moze da sacuva putnika!");
            }

            KkiAranzman.Instance.DodajKreiranogPutnika(p);
        }

        public void PostaviSvePutnike(DataGridView dgvSviPutnici)
        {
            try
            {
                List<Putnik> listaPutnika = Kontroler.Kontroler.Instance.VratiSvePutnike();

                if (listaPutnika.Count == 0)
                {
                    throw new Exception("Neuspesno ucitavanje putnika!");
                }

                dgvSviPutnici.DataSource = listaPutnika;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void ObrisiPutnike(List<DataGridViewRow> redovi)
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

                if (!Kontroler.Kontroler.Instance.ObrisiPutnika(p))
                {
                    throw new Exception("Sistem ne moze da obrise putnike!");
                }
            }
        }

        public void FiltrirajPutnike(string jmbg, string ime, string prezime, DataGridView dgvSviPutnici)
        {
            IDictionary kriterijumi = new Dictionary<string, string>();

            kriterijumi["jmbg"] = string.IsNullOrEmpty(jmbg) ? "" : jmbg;
            kriterijumi["ime"] = string.IsNullOrEmpty(ime) ? "" : ime;
            kriterijumi["prezime"] = string.IsNullOrEmpty(prezime) ? "" : prezime;

            Putnik p = new Putnik();
            p.Kriterijumi = kriterijumi;

            List<Putnik> listaPutnika = Kontroler.Kontroler.Instance.VratiFiltrirano(p).Cast<Putnik>().ToList();

            if (listaPutnika.Count == 0)
            {
                throw new Exception("Nije pronadjen nijedan putnik koji zadovoljava kriterijume!");
            }

            dgvSviPutnici.DataSource = listaPutnika;
        }
    }
}
