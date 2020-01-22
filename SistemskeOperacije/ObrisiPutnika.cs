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
        public bool Obrisan { get; set; }
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
                throw new Exception("Sistem ne moze da zapamti novi aranzman!");
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            // throw new NotImplementedException();
        }
    }
}
