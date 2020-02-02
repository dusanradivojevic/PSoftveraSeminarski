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

        public string KriterijumiZaPretragu
        {
            get
            {
                if (KorisnikID != 0)
                {
                    return $"KorisnikID = {KorisnikID}";
                }
                else
                {
                    return $"Email = '{Email}' AND Sifra = '{Sifra}'";
                }
            }
        }

        public string PrimarniKljuc => "KorisnikID";

        public IDictionary Kriterijumi { get; set; }

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

        public IDomenskiObjekat VratiPodDomen()
        {
            return null;
        }

        public void PostaviVrednost(IDomenskiObjekat ido)
        {
            if (!(ido is Korisnik))
                return;

            Korisnik k = (Korisnik)ido;

            korisnikID = k.KorisnikID;
            Ime = k.Ime;
            Prezime = k.Prezime;
            Email = k.Email;
            Sifra = k.Sifra;
        }

        public void PostaviVrednostPodDomena(IDomenskiObjekat ido)
        {
            return;
        }

        public bool AdekvatnoPopunjen()
        {
            if (KorisnikID <= 0)
                return false;

            if (Ime == null)
                return false;
            
            if (Prezime == null)
                return false;

            if (Email == null)
                return false;

            if (Sifra == null)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Korisnik korisnik &&
                   Email == korisnik.Email &&
                   Sifra == korisnik.Sifra;
        }

        public string UslovFiltera()
        {
            return null;
        }
    }
}
