using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace KKI
{
    public class Komunikacija
    {
        private Socket klijentskiSoket;
        private NetworkStream tok;
        private BinaryFormatter formatter = new BinaryFormatter();
        private static Komunikacija _instance;
        public static Komunikacija Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Komunikacija();

                return _instance;
            }
        }
        private Komunikacija()
        {
        }

        //////////////

        public bool PoveziSe()
        {
            try
            {
                if (klijentskiSoket == null || !klijentskiSoket.Connected)
                {
                    klijentskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijentskiSoket.Connect("localhost", 17510);
                    tok = new NetworkStream(klijentskiSoket);
                }
                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Odgovor KreirajZahtev(Operacija operacija, object objekat)
        {
            Zahtev zahtev = new Zahtev(operacija, objekat);

            try
            {
                formatter.Serialize(tok, zahtev);
                return ObradiOdgovor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                if (e is IOException)
                    e = new Exception ("Server je prestao sa radom.");

                if(e is SocketException)
                    e = new Exception("Socket exception.");

                throw e; 
                //u zavisnosti od exc ugasiti server ako je potrebno
                //jer exc moze da bude samo da destinacija npr nije 
                //sacuvana jer su losi podaci
            }
        }

        private Odgovor ObradiOdgovor()
        {
            Odgovor odg = formatter.Deserialize(tok) as Odgovor;
            if (odg.Status == Status.OK)
            {
                return odg;
            }
            else
            {
                throw new Exception(odg.Poruka);
            }
        }
    }
}
