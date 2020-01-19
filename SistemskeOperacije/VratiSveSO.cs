using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveSO : OpstaSO
    {
        public List<IDomenskiObjekat> lista;

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            lista = broker.VratiSve(objekat);

            if (lista.Count == 0)
            {
                throw new Exception("Nije pronadjen nijedan objekat.");

                //ili da samo vratim praznu listu pa da forma prepoznaje dalje
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            // ?
        }
    }
}
