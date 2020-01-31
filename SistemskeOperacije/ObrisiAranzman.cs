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
                Obrisan = true;
            }
            else
            {
                Obrisan = false;
                throw new Exception("Sistem ne moze da obrise aranzman!");
            }

            //treba obrisati i sve asocijativne klase

            //moze da se izmeni kriterijum u domenskoj klasi za P_A da
            // kriterijum pretrage bude AID like '%.%' and JMBG like '%.%'
            //to bi radilo i da jedan od podataka nedostaje
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
