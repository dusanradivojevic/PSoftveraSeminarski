using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Zemlja
    {
        private int zemljaID;

        public int ZemljaID
        {
            get { return zemljaID; }
            set { zemljaID = value; }
        }

        private String skraceniNaziv;

        public String SkraceniNaziv
        {
            get { return skraceniNaziv; }
            set { skraceniNaziv = value; }
        }

        private String naziv;

        public String NazivZemlje
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public override string ToString()
        {
            return skraceniNaziv;
        }
    }
}
