using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Putnik : IDomenskiObjekat
    {
        private String jmbg;

        public String JMBG
        {
            get { return jmbg; }
            set { jmbg = value; }
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

        private DateTime datumDodavanja;
        [DisplayName("Datum kreiranja")]
        public DateTime DatumDodavanja
        {
            get { return datumDodavanja; }
            set { datumDodavanja = value; }
        }

        private Korisnik korisnik;

        public Korisnik Korisnik
        {
            get { return korisnik; }
            set { korisnik = value; }
        }
        [Browsable(false)]
        public string NazivTabele => "Putnik";
        [Browsable(false)]
        public string VrednostiZaInsert => $"'{JMBG}', '{Ime}', '{Prezime}'," +
            $"'{DatumDodavanja}', {Korisnik.KorisnikID}";
        [Browsable(false)]
        public string VrednostZaUpdate => null;
        [Browsable(false)]
        public string KriterijumiZaPretragu => $"JMBG = '{JMBG}'";
        [Browsable(false)]
        public string PrimarniKljuc => "JMBG";
        [Browsable(false)]
        public IDictionary Kriterijumi { get; set; }

        public override string ToString()
        {
            return ime + ' ' + prezime;
        }

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> putnici = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Putnik p = new Putnik
                {
                    JMBG = (string)reader["JMBG"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    DatumDodavanja = (DateTime)reader["DatumDodavanja"],
                    Korisnik = new Korisnik()
                    {
                        KorisnikID = (int)reader["KorisnikID"]
                    }
                };

                putnici.Add(p);
            }

            return putnici;
        }

        public IDomenskiObjekat VratiPodDomen()
        {
            if (Korisnik != null && Korisnik.Ime == null)
            {
                return Korisnik as IDomenskiObjekat;
            }

            return null;
        }

        public void PostaviVrednost(IDomenskiObjekat ido)
        {
            if (!(ido is Putnik))
                return;

            Putnik p = ido as Putnik;

            JMBG = p.jmbg;
            Ime = p.Ime;
            Prezime = p.Prezime;
            DatumDodavanja = p.DatumDodavanja;
            Korisnik = p.Korisnik;
        }

        public void PostaviVrednostPodDomena(IDomenskiObjekat ido)
        {
            if (ido is Korisnik)
            {
                Korisnik = (Korisnik)ido;
            }
        }

        public bool AdekvatnoPopunjen()
        {
            if (JMBG == null)
                return false;

            if (Ime == null)
                return false;

            if (Prezime == null)
                return false;

            if (DatumDodavanja == new DateTime())
                return false;

            if (Korisnik == null || Korisnik.KorisnikID == 0)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Putnik putnik &&
                   JMBG == putnik.JMBG;
        }

        public string UslovFiltera()
        {
            if (Kriterijumi == null)
                throw new ArgumentException("Dictionary nije postavljen.");

            return $"JMBG LIKE '%{Kriterijumi["jmbg"] as string}%' AND " +
                $"Ime LIKE '%{Kriterijumi["ime"] as string}%' AND " +
                $"Prezime LIKE '%{Kriterijumi["prezime"] as string}%'";
        }
    }
}
