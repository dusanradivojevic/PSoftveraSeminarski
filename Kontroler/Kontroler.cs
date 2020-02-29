using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using SistemskeOperacije;
using System.ComponentModel;
using System.Collections;

namespace Kontroler
{
    public class Kontroler
    {
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
        }

        // *** SELECT ***
        public List<IDomenskiObjekat> VratiFiltrirano(IDomenskiObjekat ido)
        {
            OpstaSO os = new VratiFiltrirano();
            try
            {                
                os.IzvrsiSO(ido);
                return ((VratiFiltrirano)os).lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public IDomenskiObjekat VratiPodatkeAranzmana(IDomenskiObjekat ido)
        {
            OpstaSO os = new VratiPodatkeAranzmana();
            try
            {
                os.IzvrsiSO(ido);
                return ((VratiPodatkeAranzmana)os).Aranzman;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<IDomenskiObjekat> VratiSveAranzmane()
        {
            IDomenskiObjekat ido = new Aranzman();
            OpstaSO os = new UcitajSveAranzmane();
            try
            {
                os.IzvrsiSO(ido);
                List<IDomenskiObjekat> lista = ((UcitajSveAranzmane)os).lista;
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public List<IDomenskiObjekat> VratiSve(IDomenskiObjekat ido)
        {
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(ido);
                List<IDomenskiObjekat> lista = ((VratiSve)os).lista;
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
             
        // *** INSERT ***

        public bool UnesiNoviAranzman(IDomenskiObjekat ido)
        {           
            OpstaSO os = new UnesiNoviAranzman();
            try
            {
                os.IzvrsiSO(ido);
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

        public bool UnesiNovuDestinaciju(IDomenskiObjekat ido)
        {
            OpstaSO os = new UnesiNovuDestinaciju();
            try
            {
                os.IzvrsiSO(ido);
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
        
        public bool KreirajPutnika(IDomenskiObjekat ido) //Putnik
        {    
            OpstaSO os = new KreirajPutnika();
            try
            {
                os.IzvrsiSO(ido);
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

        public bool ObrisiAranzman(IDomenskiObjekat ido) //Aranzman
        {
            OpstaSO os = new ObrisiAranzman();
            try
            {
                os.IzvrsiSO(ido);
            }
            catch
            {
                return false;
            }

            return ((ObrisiAranzman)os).Obrisan;
        }

        public bool ObrisiDestinaciju(IDomenskiObjekat ido) //Destinacija
        {
            OpstaSO os = new ObrisiDestinaciju();
            try
            {
                os.IzvrsiSO(ido);
            }
            catch
            {
                return false;
            }

            return ((ObrisiDestinaciju)os).Obrisan;
        }           
               
        public bool ObrisiPutnika(IDomenskiObjekat ido)
        {
            OpstaSO os = new ObrisiPutnika();
            try
            {
                os.IzvrsiSO(ido);
            }
            catch
            {
                return false;
            }

            return ((ObrisiPutnika)os).Obrisan;
        }

        // *** OTHER ***                

        public IDomenskiObjekat Prijava(IDomenskiObjekat ido) //Korisnik
        {
            OpstaSO os = new PrijaviMe();
            try
            {
                os.IzvrsiSO(ido);
                return ((PrijaviMe)os).Korisnik;
            }
            catch
            {
                return null;   // U bazi ne postoji korisnik sa unetim mejlom i sifrom
            }
        }

        public bool UnosPutnikaSlozen(IDomenskiObjekat ido) // INSERT <-> UPDATE
        {
            OpstaSO os = new UnosPutnikaSlozen(); // Isto sto i izmeni
            try
            {
                os.IzvrsiSO(ido);
            }
            catch
            {
                return false;
            }

            return ((UnosPutnikaSlozen)os).UspesanUnos;               
        }
    }
}
