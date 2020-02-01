using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KKI
{
    public class KkiGlavna
    {
        private static KkiGlavna _instance;
        public static KkiGlavna Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KkiGlavna();
                }

                return _instance;
            }
        }
        private KkiGlavna()
        {
        }

        ////////////////////
        
        public string Prijava(string email, string pw)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(pw))
            {
                throw new Exception("Unesite sifru i email!");
            }

            Korisnik k = new Korisnik();
            k.Email = email;
            k.Sifra = pw;

            try
            {
                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.PrijaviMe, k);
                Sesija.Instance.PostaviKorisnika(odg.Objekat as Korisnik);
                return odg.Poruka;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
