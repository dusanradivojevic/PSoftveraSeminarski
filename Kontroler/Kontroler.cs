using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using BrokerBazePodataka;
using SistemskeOperacije;

namespace Kontroler
{
    public class Kontroler
    {
        private Broker broker;
        private static Kontroler _instance;
        public static Kontroler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Kontroler();
                }

                return _instance;
            }
        }
        private Kontroler()
        {
            broker = new Broker();
        }

        public List<Aranzman> VratiSveAranzmane()
        {
            Aranzman a = new Aranzman();
            OpstaSO os = new VratiSveSO();
            try
            {
                os.IzvrsiSO(a);
                List<Aranzman> lista = ((VratiSveSO)os).lista.Cast<Aranzman>().ToList();
                return lista;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Aranzman>();
            }
        }        

        public string Prijava(string email, string pw)
        {
            Korisnik k = new Korisnik();
            k.Email = email;
            k.Sifra = pw;
            OpstaSO os = new PrijaviMeSO();
            try
            {
                os.IzvrsiSO(k);
                return ((PrijaviMeSO)os).Korisnik.ToString();
            }
            catch
            {
                return null;   // U bazi ne postoji korisnik sa unetim mejlom i sifrom
            }
        }
    }
}
