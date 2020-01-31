using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket osluskujuciSoket;
        private List<Obrada> klijenti = new List<Obrada>();
        private static Server _instance;
        public static Server Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Server();
                }

                return _instance;
            }
        }
        private Server()
        {
        }

        //////////////
       
        internal bool PokreniServer()
        {
            try
            {
                osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 17510));
                osluskujuciSoket.Listen(5);

                Thread osluskujucaNit = new Thread(Osluskuj);
                osluskujucaNit.IsBackground = true;
                osluskujucaNit.Start();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private void Osluskuj()
        {
            bool kraj = false;
            while (!kraj)
            {
                try
                {
                    Socket klijentskiSoket = osluskujuciSoket.Accept();

                    Obrada obrada = new Obrada(klijentskiSoket);
                    klijenti.Add(obrada);
                    Thread nitKlijenta = new Thread(obrada.ObradaZahteva);
                    //nitKlijenta.IsBackground = true;
                    nitKlijenta.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    kraj = true;
                }
            }
        }

        internal bool ZaustaviServer()
        {
            try
            {
                osluskujuciSoket.Close();
                foreach (Obrada o in klijenti)
                {
                    o.Zaustavi();
                }
                klijenti.Clear();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }            
        }        
    }
}
