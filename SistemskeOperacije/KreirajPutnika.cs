using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class KreirajPutnika : OpstaSO
    {
        public Putnik Putnik { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {            
            int brojRedova = broker.Sacuvaj(objekat);
            if (brojRedova == 1)
            {
                Putnik = objekat as Putnik;
            }
            else
            {
                Putnik = null;
                throw new Exception("Sistem ne moze da zapamti novi aranzman!");
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if(!(objekat is Putnik))
            {
                throw new Exception("Objekat nije tipa Putnik!");
            }

            List<IDomenskiObjekat> rezultat = broker.Pronadji(objekat);
            if (rezultat.Count != 0)
            {
                throw new Exception($"Postoji putnik sa unetim jmbg-om!");
            }
        }
    }
}
