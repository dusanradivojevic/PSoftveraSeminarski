using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiPodatkeAranzmana : OpstaSO
    {
        public Aranzman Aranzman { get; private set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            List<IDomenskiObjekat> lista = broker.Pronadji(objekat);

            if (lista.Count == 0)
                return;

            Aranzman a = lista[0] as Aranzman;
            
            Putnik_Aranzman pa = new Putnik_Aranzman();
            pa.AranzmanID = a.AranzmanID;
            List<IDomenskiObjekat> listaAsoc = broker.Pronadji(pa);
            foreach (IDomenskiObjekat id2 in listaAsoc)
            {
                Putnik putnik = new Putnik();
                putnik.JMBG = ((Putnik_Aranzman)id2).JMBG;
                a.PostaviVrednostPodDomena(broker.Pronadji(putnik)[0]);
            }
            
            IDomenskiObjekat ido = a;
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

            Aranzman = a;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Aranzman))
            {
                throw new Exception("Objekat nije tipa Aranzman!");
            }
        }
    }
}
