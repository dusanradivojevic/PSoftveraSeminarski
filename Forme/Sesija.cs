using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace Forme
{
    public class Sesija
    {
        private Korisnik Korisnik { get; set; }

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
    }
}
