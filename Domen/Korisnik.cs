using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Korisnik : IDomenskiObjekat
    {
        private int korisnikID;

        public int KorisnikID
        {
            get { return korisnikID; }
            set { korisnikID = value; }
        }

        private String ime;

        public String Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private String prezime;

        public String Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        private String sifra;

        public String Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        public string NazivTabele => "Korisnik";

        public string VrednostiZaInsert => $"{korisnikID}, '{Ime}', '{Prezime}', '{Email}', " +
            $"'{Sifra}";

        public string KriterijumiZaPretragu => $"KorisnikID = {KorisnikID} AND Sifra = {Sifra}";

        public override string ToString()
        {
            return ime + ' ' + prezime;
        }

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> korisnici = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Korisnik k = new Korisnik
                {
                    KorisnikID = (int)reader["KorisnikID"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    Email = (string)reader["Email"],
                    Sifra = (string)reader["Sifra"]
                };

                korisnici.Add(k);
            }

            return korisnici;
        }
    }
}
