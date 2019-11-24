using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Destinacija
    {
        private int destinacijaID;

        public int DestinacijaID
        {
            get { return destinacijaID; }
            set { destinacijaID = value; }
        }

        private String nazivGrada;

        public String NazivGrada
        {
            get { return nazivGrada; }
            set { nazivGrada = value; }
        }

        private Zemlja zemlja;

        public Zemlja Zemlja
        {
            get { return zemlja; }
            set { zemlja = value; }
        }

        private Korisnik korisnik;

        public Korisnik Korisnik
        {
            get { return korisnik; }
            set { korisnik = value; }
        }
        
        public override string ToString()
        {
            return nazivGrada;
        }
    }
}
