using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class UnesiNoviAranzman : OpstaSO
    {
        public Aranzman Aranzman { get; private set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            object rezultat = broker.VratiNajveciID(objekat);
            int noviID;
            if (rezultat is DBNull)
            {
                //throw new Exception($"{objekat.NazivTabele} ne postoji!");
                noviID = 1;
            }
            else
            {
                noviID = (int)rezultat + 1;
            }

            ((Aranzman)objekat).AranzmanID = noviID;
            int brojRedova = broker.Sacuvaj(objekat);
            if(brojRedova == 1)
            {
                Aranzman = objekat as Aranzman;
            }
            else
            {
                Aranzman = null;
                throw new Exception("Sistem ne moze da zapamti novi aranzman!");
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Aranzman))
            {
                throw new Exception("Objekat nije tipa Aranzman!");
            }

            List<IDomenskiObjekat> rezultat = broker.Pronadji(objekat);
            if (rezultat.Count != 0)
            {
                throw new Exception("Postoji Aranzman sa unetim ID-jem!");
            }
        }
    }
}
