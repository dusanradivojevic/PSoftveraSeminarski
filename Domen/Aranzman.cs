using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Aranzman : IDomenskiObjekat
    {
        private int aranzmanID;
        [DisplayName("ID")]
        public int AranzmanID
        {
            get { return aranzmanID; }
            set { aranzmanID = value; }
        }

        private String nazivAranzmana;
        [DisplayName("Naziv")]
        public String NazivAranzmana
        {
            get { return nazivAranzmana; }
            set { nazivAranzmana = value; }
        }

        private String opisAranzman;
        [DisplayName("Opis")]
        public String OpisAranzmana
        {
            get { return opisAranzman; }
            set { opisAranzman = value; }
        }

        private double cena;
        
        public double Cena
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
        [DisplayName("Ukupan broj mesta")]
        public int UkupanBrMesta
        {
            get { return ukupanBrojMesta; }
            set { ukupanBrojMesta = value; }
        }

        private int brojPutnika;
        [DisplayName("Broj putnika")]
        public int BrojPutnika
        {
            get { return brojPutnika; }
            set { brojPutnika = value; }
        }

        private int brojSlobodnihMesta;
        [DisplayName("Raspoloziv broj mesta")]
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

        [Browsable(false)]
        public string NazivTabele => "Aranzman";

        [Browsable(false)]
        public string VrednostiZaInsert => $"{AranzmanID}, '{NazivAranzmana}', '{OpisAranzmana}'," +
            $" {Cena}, '{Datum}', {ukupanBrojMesta}, {BrojPutnika}, {brojSlobodnihMesta}," +
            $" {Destinacija.DestinacijaID}, {Korisnik.KorisnikID}"; //!

        [Browsable(false)]
        public string KriterijumiZaPretragu => $"AranzmanID = {AranzmanID}";
        [Browsable(false)]
        public string PrimarniKljuc => "AranzmanID";

        public override string ToString()
        {
            return nazivAranzmana;
        }

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> aranzmani = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Aranzman a = new Aranzman
                {
                    AranzmanID = (int)reader["AranzmanID"],
                    NazivAranzmana = (string)reader["NazivAranzmana"],
                    OpisAranzmana = (string)reader["OpisAranzmana"],
                    Cena = (double)reader["Cena"],
                    Datum = (DateTime)reader["Datum"],
                    UkupanBrMesta = (int)reader["UkupanBrojMesta"],
                    BrojPutnika = (int)reader["BrojPutnika"],
                    BrSlobodnihMesta = (int)reader["BrojSlobodnihMesta"],
                    Destinacija = new Destinacija()
                    {
                        DestinacijaID = (int)reader["DestinacijaID"]
                    },
                    Korisnik = new Korisnik()
                    {
                        KorisnikID = (int)reader["KorisnikID"]
                    }
                };

                aranzmani.Add(a);
            }

            return aranzmani;
        }

        public IDomenskiObjekat VratiPodDomen()
        {
            if(Destinacija != null && Destinacija.NazivGrada == null)
            {
                return Destinacija as IDomenskiObjekat;
            }

            if(Korisnik != null && Korisnik.Ime == null)
            {
                return Korisnik as IDomenskiObjekat;
            }

            return null;
        }

        public void PostaviVrednost(IDomenskiObjekat ido)
        {
            if (!(ido is Aranzman))
                return;

            Aranzman a = (Aranzman)ido;

            AranzmanID = a.AranzmanID;
            NazivAranzmana = a.NazivAranzmana;
            OpisAranzmana = a.OpisAranzmana;
            Cena = a.Cena;
            Datum = a.Datum;
            UkupanBrMesta = a.UkupanBrMesta;
            BrojPutnika = a.BrojPutnika;
            brojSlobodnihMesta = a.BrSlobodnihMesta;
            Destinacija = a.Destinacija;
            Korisnik = a.Korisnik;
        }

        public void PostaviVrednostPodDomena(IDomenskiObjekat ido)
        {
            if(ido is Destinacija)
            {
                Destinacija = (Destinacija)ido;
            }

            if(ido is Korisnik)
            {
                Korisnik = (Korisnik)ido;
            }
        }
    }
}
