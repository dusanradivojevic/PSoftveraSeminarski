using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class UnesiNovuDestinaciju : OpstaSO
    {
        public Destinacija Destinacija { get; private set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            object rezultat = broker.VratiNajveciID(objekat);
            if (rezultat is DBNull)
            {
                throw new Exception($"{objekat.NazivTabele} ne postoji!");
            }
            int noviID = (int)rezultat + 1;
            ((Destinacija)objekat).DestinacijaID = noviID;
            int brojRedova = broker.Sacuvaj(objekat);
            if (brojRedova == 1)
            {
                Destinacija = objekat as Destinacija;
            }
            else
            {
                Destinacija = null;
                throw new Exception("Sistem ne moze da zapamti novi aranzman!");
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Destinacija))
            {
                throw new Exception("Objekat nije tipa Destinacija!");
            }

            List<IDomenskiObjekat> rezultat = broker.Pronadji(objekat);
            if (rezultat.Count != 0)
            {
                throw new Exception("Postoji Destinacija sa unetim ID-jem!");
            }

            //mora da se doda validacija i za npr pokusaj unosa 2 destinacije sa istim nazivom
        }
    }
}
