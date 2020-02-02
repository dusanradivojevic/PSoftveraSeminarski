using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiAranzman : OpstaSO
    {
        public bool Obrisan { get; private set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            int brojRedova = broker.Obrisi(objekat);
            if (brojRedova == 1)
            {
                Putnik_Aranzman pa = new Putnik_Aranzman();
                pa.AranzmanID = ((Aranzman)objekat).AranzmanID;
                broker.Obrisi(pa);

                Obrisan = true;
            }
            else
            {
                Obrisan = false;
                throw new Exception("Sistem ne moze da obrise aranzman!");
            }            
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Aranzman))
            {
                throw new Exception("Objekat nije tipa Aranzman!");
            }

            List<IDomenskiObjekat> rezultat = broker.Pronadji(objekat);
            if (rezultat.Count == 0)
            {
                throw new Exception($"U bazi ne postoji Aranzman sa datim ID-jem!");
            }
        }
    }
}
