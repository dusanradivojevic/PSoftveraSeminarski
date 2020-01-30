using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using BrokerBazePodataka;
using SistemskeOperacije;
using System.ComponentModel;

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

        // *** SELECT ***

        public List<Aranzman> VratiSveAranzmane()
        {
            Aranzman a = new Aranzman();
            OpstaSO os = new UcitajSveAranzmane();
            try
            {
                os.IzvrsiSO(a);
                List<Aranzman> lista = ((UcitajSveAranzmane)os).lista.Cast<Aranzman>().ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Aranzman>();
            }
        }

        public List<Zemlja> VratiSveZemlje()
        {
            Zemlja z = new Zemlja();
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(z);
                List<Zemlja> lista = ((VratiSve)os).lista.Cast<Zemlja>().ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Zemlja>();
            }
        }

        public List<Putnik> VratiSvePutnike()
        {
            Putnik p = new Putnik();
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(p);
                List<Putnik> lista = ((VratiSve)os).lista.Cast<Putnik>().ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Putnik>();
            }
        }

        public List<Destinacija> VratiSveDestinacije() //ovde metode mogu da vracaju i object
        {
            Destinacija d = new Destinacija();
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(d);
                List<Destinacija> lista = ((VratiSve)os).lista.Cast<Destinacija>().ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Destinacija>();
            }
        }

        // *** INSERT ***

        public bool UnesiNoviAranzman(Aranzman a)
        {           
            OpstaSO os = new UnesiNoviAranzman();
            try
            {
                os.IzvrsiSO(a);
            }
            catch
            {
                return false;
            }
            if (((UnesiNoviAranzman)os).Aranzman != null)
                return true;
            else
                return false;
        }

        public bool UnesiNovuDestinaciju(Destinacija d)
        {
            OpstaSO os = new UnesiNovuDestinaciju();
            try
            {
                os.IzvrsiSO(d);
            }
            catch
            {
                return false;
            }
            if (((UnesiNovuDestinaciju)os).Destinacija != null)
                return true;
            else
                return false;
        }

        public bool KreirajPutnika(Putnik p)
        {    
            OpstaSO os = new KreirajPutnika();
            try
            {
                os.IzvrsiSO(p);
            }
            catch
            {
                return false;
            }

            if (((KreirajPutnika)os).Putnik != null)
                return true;
            else
                return false;
        }

        // *** DELETE ***

        public bool ObrisiAranzman(Aranzman a)
        {
            OpstaSO os = new ObrisiAranzman();
            try
            {
                os.IzvrsiSO(a);
            }
            catch
            {
                return false;
            }

            return ((ObrisiAranzman)os).Obrisan;
        }

        public bool ObrisiDestinaciju(Destinacija d)
        {
            OpstaSO os = new ObrisiDestinaciju();
            try
            {
                os.IzvrsiSO(d);
            }
            catch
            {
                return false;
            }

            return ((ObrisiDestinaciju)os).Obrisan;
        }           
               
        public bool ObrisiPutnika(Putnik p)
        {
            OpstaSO os = new ObrisiPutnika();
            try
            {
                os.IzvrsiSO(p);
            }
            catch
            {
                return false;
            }

            return ((ObrisiPutnika)os).Obrisan;
        }

        // *** OTHER ***                

        public Korisnik Prijava(Korisnik k)
        {
            OpstaSO os = new PrijaviMe();
            try
            {
                os.IzvrsiSO(k);
                return ((PrijaviMe)os).Korisnik;
            }
            catch
            {
                return null;   // U bazi ne postoji korisnik sa unetim mejlom i sifrom
            }
        }

        public bool SacuvajAranzmanSlozen(Aranzman a)
        {
            //    a.BrojPutnika = a.Putnici.Count();
            //    a.BrSlobodnihMesta = a.UkupanBrMesta - a.BrojPutnika;

            OpstaSO os = new UnosPutnika(); //isto sto i izmeni
            try
            {
                os.IzvrsiSO(a);
            }
            catch
            {
                return false;
            }

            return ((UnosPutnika)os).UspesanUnos;               
        }
    }
}
