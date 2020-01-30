using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace KKI
{
    public class Sesija
    {
        private Korisnik korisnik;

        private static Sesija _instance;
        public static Sesija Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sesija();
                }

                return _instance;
            }
        }
        private Sesija()
        {

        }

        public void PostaviKorisnika(Korisnik k)
        {
            korisnik = k;
        }

        public void OdjaviKorisnika()
        {
            korisnik = null;
        }

        public string VratiKorisnikaToString()
        {
            return $"{korisnik.Ime} {korisnik.Prezime}";
        }
        public Korisnik VratiKorisnikaObjekat()
        {
            return korisnik;
        }
    }
}
