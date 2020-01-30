using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public void Prijava(string email, string pw)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(pw))
            {
                throw new Exception("Unesite sifru i email!");
            }

            Korisnik k = new Korisnik();
            k.Email = email;
            k.Sifra = pw;

            k = Kontroler.Kontroler.Instance.Prijava(k);

            if (k != null)
            {
                Sesija.Instance.PostaviKorisnika(k);
            }
            else
            {
                throw new Exception("Neispravan email ili sifra!");
            }
        }
    }
}
