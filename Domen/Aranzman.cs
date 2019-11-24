using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Aranzman
    {
        private int aranzmanID;

        public int AranzmanID
        {
            get { return aranzmanID; }
            set { aranzmanID = value; }
        }

        private String nazivAranzmana;

        public String NazivAranzmana
        {
            get { return nazivAranzmana; }
            set { nazivAranzmana = value; }
        }

        private String opisAranzman;

        public String OpisAranzmana
        {
            get { return opisAranzman; }
            set { opisAranzman = value; }
        }

        private decimal cena;

        public decimal Cena
        {
            get { return cena; }
            set { cena = value; }
        }

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        private int ukupanBrojMesta;

        public int UkupanBrMesta
        {
            get { return ukupanBrojMesta; }
            set { ukupanBrojMesta = value; }
        }

        private int brojPutnika;

        public int BrojPutnika
        {
            get { return brojPutnika; }
            set { brojPutnika = value; }
        }

        private int brojSlobodnihMesta;

        public int BrSlobodnihMesta
        {
            get { return brojSlobodnihMesta; }
            set { brojSlobodnihMesta = value; }
        }

        private Destinacija destinacija;

        public Destinacija Destinacija
        {
            get { return destinacija; }
            set { destinacija = value; }
        }

        private Korisnik korisnik;

        public Korisnik Korisnik
        {
            get { return korisnik; }
            set { korisnik = value; }
        }
        
        public override string ToString()
        {
            return nazivAranzmana;
        }
    }
}
