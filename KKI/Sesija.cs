using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domen;

namespace KKI
{
    public class Sesija
    {
        private Korisnik korisnik;
        private List<Thread> listaNiti = new List<Thread>();
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

        internal void PonovoPovezivanje(IDomenskaForma idf)
        {
            if(listaNiti.Count == 0)
            {
                Thread nit = new Thread(() => PonovoPovezi(idf));
                nit.IsBackground = true;
                nit.Start();
                listaNiti.Add(nit);
            }            
        }

        private void PonovoPovezi(IDomenskaForma idf)
        {
            while (true)
            {
                if (Komunikacija.Instance.PoveziSe())
                {
                    idf.IspisiPoruku("Konekcija sa serverom je ponovo uspostavljena!");
                    break;
                }
                else
                {
                    idf.IspisiPoruku("Neuspesno povezivanje, pokusavam opet ...");
                    Thread.Sleep(5000);
                }
            }

            listaNiti.Clear();
        }
    }
}
