using Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;
using Domen;

namespace Server
{
    public class Obrada
    {
        private Socket klijentskiSoket;
        private NetworkStream tok;
        private BinaryFormatter formatter = new BinaryFormatter();

        public Obrada(Socket ks)
        {
            this.klijentskiSoket = ks;
            tok = new NetworkStream(klijentskiSoket);
        }

        public void Zaustavi()
        {
            klijentskiSoket.Close();
        }

        internal void ObradaZahteva()
        {
            bool kraj = false;
            while (!kraj)
            {
                try
                {
                    Zahtev zahtev = formatter.Deserialize(tok) as Zahtev;
                    Odgovor odgovor = KreirajOdgovor(zahtev);
                    formatter.Serialize(tok, odgovor);
                }
                catch
                {
                    kraj = true;
                }
            }
        }

        private Odgovor KreirajOdgovor(Zahtev zahtev)
        {
            switch (zahtev.Operacija)
            {
                case Operacija.VratiSve: return VratiSve(zahtev.Objekat);
                case Operacija.PrijaviMe: return Prijava(zahtev.Objekat);
                case Operacija.ObrisiPutnika: return ObrisiPutnika(zahtev.Objekat);
                case Operacija.KreirajPutnika: return KreirajPutnika(zahtev.Objekat);
                case Operacija.ObrisiAranzman: return ObrisiAranzman(zahtev.Objekat);
                case Operacija.VratiFiltrirano: return Filtriraj(zahtev.Objekat);
                case Operacija.ObrisiDestinaciju: return ObrisiDestinaciju(zahtev.Objekat);
                case Operacija.VratiSveAranzmane: return VratiSveAranzmane();
                case Operacija.UnesiNoviAranzman: return UnesiAranzman(zahtev.Objekat);
                case Operacija.UnesiNovuDestinaciju: return UnesiDestinaciju(zahtev.Objekat);
                case Operacija.SacuvajAranzmanSlozen: return SacuvajAranzmanSlozen(zahtev.Objekat);
                case Operacija.VratiPodatkeAranzmana: return VratiAranzman(zahtev.Objekat);
                default: 
                    Odgovor o = new Odgovor();
                    o.Poruka = "Nepostojeca operacija zahteva!";
                    o.Status = Status.ERR;
                    return o;
            }
        }

        /// === Metode koje pozivaju kontrolera i kreiraju odgovor na osnovu povratne vrednosti ===

        private Odgovor KreirajPutnika(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat && 
                Kontroler.Kontroler.Instance.KreirajPutnika(objekat as IDomenskiObjekat))
            {
                odg.Poruka = "Putnik je uspešno sačuvan!";
                odg.Status = Status.OK;
            }
            else
            {
                odg.Poruka = "Sistem ne može da zapamti putnika!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor ObrisiAranzman(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat &&
                Kontroler.Kontroler.Instance.ObrisiAranzman(objekat as IDomenskiObjekat))
            {
                odg.Poruka = "Sistem je obrisao aranžman!";
                odg.Status = Status.OK;
            }
            else
            {
                odg.Poruka = "Sistem ne može da obriše aranžman!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor ObrisiDestinaciju(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat &&
                Kontroler.Kontroler.Instance.ObrisiDestinaciju(objekat as IDomenskiObjekat))
            {
                odg.Poruka = "Sistem je obrisao destinaciju!";
                odg.Status = Status.OK;
            }
            else
            {
                odg.Poruka = "Sistem ne može da obriše destinaciju!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor ObrisiPutnika(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat &&
                Kontroler.Kontroler.Instance.ObrisiPutnika(objekat as IDomenskiObjekat))
            {
                odg.Poruka = "Sistem je obrisao putnike!";
                odg.Status = Status.OK;
            }
            else
            {
                odg.Poruka = "Sistem ne može da obriše putnike!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor Prijava(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat)
            {
                IDomenskiObjekat ido = Kontroler.Kontroler.Instance.Prijava(objekat as IDomenskiObjekat);
                if(ido != null)
                {
                    odg.Poruka = "Uspešno ste se prijavili na sistem!";
                    odg.Status = Status.OK;
                    odg.Objekat = ido;
                    return odg;
                }
            }

            odg.Poruka = "Neuspešno prijavljivanje na sistem!";
            odg.Status = Status.ERR;
            return odg;
        }
        private Odgovor VratiSveAranzmane()
        {
            Odgovor odg = new Odgovor();
            try
            {
                List<IDomenskiObjekat> listaAranzmana = Kontroler.Kontroler.Instance.VratiSveAranzmane();
                odg.Objekat = listaAranzmana;
                odg.Status = Status.OK;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                odg.Poruka = "Sistem ne moze da pronadje aranzmane";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor VratiSve(object objekat)
        {
            Odgovor odg = new Odgovor();
            try
            {
                if (!(objekat is IDomenskiObjekat))
                    throw new ArgumentException("Prosledjeni objekat nije tipa IDO.");

                List<IDomenskiObjekat> lista = Kontroler.Kontroler.Instance.VratiSve(objekat as IDomenskiObjekat);
                odg.Objekat = lista;
                odg.Status = Status.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                odg.Poruka = "Sistem ne moze da pronadje trazene objekte!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor VratiAranzman(object objekat)
        {
            Odgovor odg = new Odgovor();
            try
            {
                if (!(objekat is IDomenskiObjekat))
                    throw new ArgumentException("Prosledjeni objekat nije tipa IDO.");

                IDomenskiObjekat ido = Kontroler.Kontroler.Instance.VratiPodatkeAranzmana(objekat as IDomenskiObjekat);
                odg.Objekat = ido;
                odg.Status = Status.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                odg.Poruka = "Sistem ne može da pronađe podatke aranžmana!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor Filtriraj(object objekat)
        {
            Odgovor odg = new Odgovor();
            try
            {
                if (!(objekat is IDomenskiObjekat))
                    throw new ArgumentException("Prosledjeni objekat nije tipa IDO.");

                List<IDomenskiObjekat> lista = Kontroler.Kontroler.Instance.VratiFiltrirano(objekat as IDomenskiObjekat);
                odg.Objekat = lista;
                odg.Status = Status.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                odg.Poruka = "U sistemu ne postoje objekti sa takvim vrednostima!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor UnesiAranzman(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat &&
                Kontroler.Kontroler.Instance.UnesiNoviAranzman(objekat as IDomenskiObjekat))
            {
                odg.Poruka = "Novi aranžman je uspešno sačuvan!";
                odg.Status = Status.OK;
            }
            else
            {
                odg.Poruka = "Sistem ne može da zapamti aranžman!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor UnesiDestinaciju(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat &&
                Kontroler.Kontroler.Instance.UnesiNovuDestinaciju(objekat as IDomenskiObjekat))
            {
                odg.Poruka = "Destinacija je uspešno sačuvana!";
                odg.Status = Status.OK;
            }
            else
            {
                odg.Poruka = "Sistem ne može da zapamti destinaciju!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
        private Odgovor SacuvajAranzmanSlozen(object objekat)
        {
            Odgovor odg = new Odgovor();
            if (objekat is IDomenskiObjekat &&
                Kontroler.Kontroler.Instance.SacuvajAranzmanSlozen(objekat as IDomenskiObjekat))
            {
                odg.Poruka = "Sistem je zapamtio podatke!";
                odg.Status = Status.OK;
            }
            else
            {
                odg.Poruka = "Sistem ne može da zapamti podatke!";
                odg.Status = Status.ERR;
            }
            return odg;
        }
    }    
}
