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
            konekcija = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db_agencija;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void OtvoriKonekciju()
        {
            konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            konekcija.Close();
        }

        public void PokreniTransakciju()
        {
            transakcija = konekcija.BeginTransaction();
        }

        public void Commit()
        {
            transakcija.Commit();
        }

        public void Rollback()
        {
            transakcija.Rollback();
        }

        public List<IDomenskiObjekat> VratiSve(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", konekcija, transakcija);
            command.CommandText = $"SELECT * FROM {objekat.NazivTabele}";
            SqlDataReader reader = command.ExecuteReader();
            List<IDomenskiObjekat> rezultat = objekat.VratiListu(reader);
            reader.Close();

            for (int i = 0; i < rezultat.Count; )
            {
                IDomenskiObjekat ido = rezultat[i];
                IDomenskiObjekat podDomen = ido.VratiPodDomen();

                if (podDomen != null)
                {
                    podDomen.PostaviVrednost(Pronadji(podDomen)[0]);
                    ido.PostaviVrednostPodDomena(podDomen);
                }
                else
                {
                    i++;
                }
            }
                          
            return rezultat;       
            
        }

        public List<IDomenskiObjekat> Pronadji(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", konekcija, transakcija);
            command.CommandText = $"SELECT * FROM {objekat.NazivTabele} " +
                $"WHERE {objekat.KriterijumiZaPretragu}";
            SqlDataReader reader = command.ExecuteReader();
            List<IDomenskiObjekat> rezultat = objekat.VratiListu(reader);
            reader.Close();
            return rezultat;
        }

    }
}
