using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSve : OpstaSO
    {
        public List<IDomenskiObjekat> lista;

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            List<IDomenskiObjekat> rezultat = broker.VratiSve(objekat);

            for (int i = 0; i < rezultat.Count;)
            {
                IDomenskiObjekat ido = rezultat[i];
                IDomenskiObjekat podDomen = ido.VratiPodDomen();

                if (podDomen != null)
                {
                    podDomen.PostaviVrednost(broker.Pronadji(podDomen)[0]);
                    ido.PostaviVrednostPodDomena(podDomen);

                    while (podDomen.VratiPodDomen() != null)
                    {
                        IDomenskiObjekat podPod = podDomen.VratiPodDomen();
                        
                        podPod.PostaviVrednost(broker.Pronadji(podPod)[0]);
                        podDomen.PostaviVrednostPodDomena(podPod);                        
                    }
                }
                else
                {
                    i++;
                }
            }

            if (rezultat.Count == 0)
            {
                throw new Exception("Nije pronadjen nijedan objekat.");

                //ili da samo vratim praznu listu pa da forma prepoznaje dalje
            }

            lista = rezultat;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            // ?
        }
    }
}
