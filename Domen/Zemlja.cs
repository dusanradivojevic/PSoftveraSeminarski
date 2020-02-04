using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Zemlja : IDomenskiObjekat
    {
        private int zemljaID;

        public int ZemljaID
        {
            get { return zemljaID; }
            set { zemljaID = value; }
        }

        private String naziv;

        public String NazivZemlje
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private String skraceniNaziv;

        public String SkraceniNaziv
        {
            get { return skraceniNaziv; }
            set { skraceniNaziv = value; }
        }        

        public string NazivTabele => "Zemlja";

        public string VrednostiZaInsert => $"{ZemljaID}, '{NazivZemlje}', " +
            $"{SkraceniNaziv}";

        public string VrednostZaUpdate => null;

        public string KriterijumiZaPretragu => $"ZemljaID = {ZemljaID}";

        public string PrimarniKljuc => "ZemljaID";

        public IDictionary Kriterijumi { get; set; }

        public override string ToString()
        {
            return NazivZemlje + " - " + SkraceniNaziv;
        }

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> zemlje = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Zemlja d = new Zemlja
                {
                    ZemljaID = (int)reader["ZemljaID"],
                    NazivZemlje = (string)reader["NazivZemlje"],
                    SkraceniNaziv = (string)reader["SkraceniNaziv"]
                };

                zemlje.Add(d);
            }

            return zemlje;
        }

        public IDomenskiObjekat VratiPodDomen()
        {
            return null;
        }

        public void PostaviVrednost(IDomenskiObjekat ido)
        {
            if (!(ido is Zemlja))
                return;

            Zemlja z = (Zemlja)ido;

            ZemljaID = z.ZemljaID;
            NazivZemlje = z.NazivZemlje;
            SkraceniNaziv = z.SkraceniNaziv;
        }

        public void PostaviVrednostPodDomena(IDomenskiObjekat ido)
        {
            return;
        }

        public bool AdekvatnoPopunjen()
        {
            if (ZemljaID <= 0)
                return false;

            if (NazivZemlje == null)
                return false;

            if (SkraceniNaziv == null)
                return false;

            return true;
        }

        public string UslovFiltera()
        {
            return null;
        }
    }
}
