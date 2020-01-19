using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
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

        public string KriterijumiZaPretragu => $"ZemljaID = {ZemljaID}";

        public override string ToString()
        {
            return skraceniNaziv;
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
            Zemlja z = (Zemlja)ido;

            ZemljaID = z.ZemljaID;
            NazivZemlje = z.NazivZemlje;
            SkraceniNaziv = z.SkraceniNaziv;
        }

        public void PostaviVrednostPodDomena(IDomenskiObjekat ido)
        {
            return;
        }
    }
}
