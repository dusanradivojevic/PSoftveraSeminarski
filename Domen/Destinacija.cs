using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Destinacija : IDomenskiObjekat
    {
        private int destinacijaID;

        public int DestinacijaID
        {
            get { return destinacijaID; }
            set { destinacijaID = value; }
        }

        private String nazivGrada;
        [DisplayName("Naziv grada")]
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
            //return nazivGrada;
            return nazivGrada + $" ({Zemlja.NazivZemlje})";
        }
        
        [Browsable(false)]
        public string NazivTabele => "Destinacija";
        [Browsable(false)]
        public string VrednostiZaInsert => $"{DestinacijaID}, '{nazivGrada}', " +
            $"{Zemlja.ZemljaID}, {Korisnik.KorisnikID}";
        [Browsable(false)]
        public string KriterijumiZaPretragu => $"DestinacijaID = {DestinacijaID}";
        [Browsable(false)]
        public string PrimarniKljuc => "DestinacijaID"; 

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> destinacije = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Destinacija d = new Destinacija
                {
                    DestinacijaID = (int)reader["DestinacijaID"],
                    NazivGrada = (string)reader["NazivGrada"],
                    Zemlja = new Zemlja()
                    {
                        ZemljaID = (int)reader["ZemljaID"]
                    },
                    Korisnik = new Korisnik()
                    {
                        KorisnikID = (int)reader["KorisnikID"]
                    }
                };

                destinacije.Add(d);
            }

            return destinacije;
        }

        public IDomenskiObjekat VratiPodDomen()
        {
            if (Zemlja != null && Zemlja.NazivZemlje == null)
            {
                return Zemlja as IDomenskiObjekat;
            }

            if (Korisnik != null && Korisnik.Ime == null)
            {
                return Korisnik as IDomenskiObjekat;
            }

            return null;
        }

        public void PostaviVrednost(IDomenskiObjekat ido)
        {
            if (!(ido is Destinacija))
                return;
            
            Destinacija d = (Destinacija)ido;

            DestinacijaID = d.DestinacijaID;
            NazivGrada = d.NazivGrada;
            Zemlja = d.Zemlja;
            Korisnik = d.Korisnik;
        }

        public void PostaviVrednostPodDomena(IDomenskiObjekat ido)
        {
            if (ido is Zemlja)
            {
                Zemlja = (Zemlja)ido;
            }

            if (ido is Korisnik)
            {
                Korisnik = (Korisnik)ido;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Destinacija destinacija &&
                   DestinacijaID == destinacija.DestinacijaID;
        }
    }
}
