using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiPutnika : OpstaSO
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
                throw new Exception("Sistem ne moze da obrise putnika!");
            }
            // treba brisati i sve Asocijativne klase!
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            // objekat tipa putnika
            // da li je popunjen adekvatno
            // sprecavanje ponavljanja iz baze

            if (!(objekat is Putnik))
            {
                throw new Exception("Objekat nije tipa Putnik!");
            }

            List<IDomenskiObjekat> rezultat = broker.Pronadji(objekat);
            if (rezultat.Count == 0)
            {
                throw new Exception($"U bazi ne postoji Putnik sa datim JMBG-om!");
            }
        }
    }
}
