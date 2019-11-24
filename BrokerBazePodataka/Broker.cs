using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domen;

namespace BrokerBazePodataka
{
    public class Broker
    {
        private SqlConnection konekcija;
        private SqlTransaction transakcija;

        public Broker()
        {
            konekcija = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TuristickaAgencija;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void OtvoriKonekciju()
        {
            konekcija.Open();
        }

        private void ZatvoriKonekciju()
        {
            konekcija.Close();
        }

        private void PokreniTransakciju()
        {
            transakcija = konekcija.BeginTransaction();
        }

        private void Commit()
        {
            transakcija.Commit();
        }

        private void Rollback()
        {
            transakcija.Rollback();
        }

        public List<Aranzman> VratiSveAranzmane()
        {
            List<Aranzman> listaAranzmana = new List<Aranzman>();

            try
            {
                OtvoriKonekciju();
                SqlCommand komanda = konekcija.CreateCommand();
                komanda.CommandText = "SELECT * FROM Aranzman";
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    Aranzman a = new Aranzman()
                    {
                        AranzmanID = (int)citac["AranzmanID"],
                        NazivAranzmana = (string)citac["NazivAranzmana"],
                        OpisAranzmana = (string)citac["OpisAranzmana"],
                        Cena = (decimal)citac["Cena"],
                        Datum = (DateTime)citac["Datum"],
                        UkupanBrMesta = (int)citac["UkupanBrMesta"],
                        BrojPutnika = (int)citac["BrojPutnika"],
                        BrSlobodnihMesta = (int)citac["BrSlobodnihMesta"],
                        Destinacija = new Destinacija()
                        {
                            DestinacijaID = (int)citac["DestinacijaID"]
                        },
                        Korisnik = new Korisnik()
                        {
                            KorisnikID = (int)citac["KorisnikID"]
                        }
                    };

                    listaAranzmana.Add(a);
                }
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return listaAranzmana;
        }

        public List<Destinacija> VratiSveDestinacije()
        {
            List<Destinacija> listaDestinacija = new List<Destinacija>();

            try
            {
                OtvoriKonekciju();

                SqlCommand komanda = konekcija.CreateCommand();
                komanda.CommandText = "SELECT * FROM Destinacija";
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    Destinacija d = new Destinacija()
                    {
                        
                        DestinacijaID = (int)citac["DestinacijaID"],
                        NazivGrada = (string)citac["NazivGrada"],
                        Zemlja = new Zemlja()
                        {
                            ZemljaID = (int)citac["ZemljaID"]
                        },
                        Korisnik = new Korisnik()
                        {
                            KorisnikID = (int)citac["KorisnikID"]
                        }
                    };

                    listaDestinacija.Add(d);
                }
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return listaDestinacija;
        }
    }
}
