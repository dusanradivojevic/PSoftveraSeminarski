using Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicki;

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
        
        public string KreirajPutnika(string jmbg, string ime, string prezime, string datum)
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

            Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.KreirajPutnika, p);
            KkiAranzman.Instance.DodajKreiranogPutnika(p);
            return odg.Poruka;
        }

        public void PostaviSvePutnike(DataGridView dgvSviPutnici)
        {
            try
            {
                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiSve, new Putnik());
                List<Putnik> listaPutnika = (odg.Objekat as List<IDomenskiObjekat>).Cast<Putnik>().ToList();

                dgvSviPutnici.DataSource = listaPutnika;

                //if (listaPutnika != null && listaPutnika.Count == 0)
                //{
                //    //throw new Exception("Neuspesno ucitavanje putnika!");
                //    throw new Exception(odg.Poruka);
                //}
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string ObrisiPutnike(List<DataGridViewRow> redovi)
        {
            Odgovor odg = new Odgovor();
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

                odg = Komunikacija.Instance.KreirajZahtev(Operacija.ObrisiPutnika, p);
            }
            return odg.Poruka;
        }

        public void FiltrirajPutnike(string jmbg, string ime, string prezime, DataGridView dgvSviPutnici)
        {
            IDictionary kriterijumi = new Dictionary<string, string>();

            kriterijumi["jmbg"] = string.IsNullOrEmpty(jmbg) ? "" : jmbg;
            kriterijumi["ime"] = string.IsNullOrEmpty(ime) ? "" : ime;
            kriterijumi["prezime"] = string.IsNullOrEmpty(prezime) ? "" : prezime;

            Putnik p = new Putnik();
            p.Kriterijumi = kriterijumi;

            Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiFiltrirano, p);
            List<Putnik> listaPutnika = (odg.Objekat as List<IDomenskiObjekat>).Cast<Putnik>().ToList();

            dgvSviPutnici.DataSource = listaPutnika;

            if (listaPutnika != null && listaPutnika.Count == 0)
            {
                throw new Exception("Nije pronadjen nijedan putnik koji zadovoljava kriterijume!");               
            }
        }
    }
}
