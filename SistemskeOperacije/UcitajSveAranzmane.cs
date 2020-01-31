using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class UcitajSveAranzmane : OpstaSO
    {
        public List<IDomenskiObjekat> lista;
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            List<IDomenskiObjekat> sviAranzmani = broker.VratiSve(objekat);
            foreach(IDomenskiObjekat id in sviAranzmani)
            {
                Putnik_Aranzman pa = new Putnik_Aranzman();
                pa.AranzmanID = ((Aranzman)id).AranzmanID;
                List<IDomenskiObjekat> listaAsoc = broker.Pronadji(pa);
                foreach(IDomenskiObjekat id2 in listaAsoc)
                {
                    Putnik putnik = new Putnik();
                    putnik.JMBG = ((Putnik_Aranzman)id2).JMBG;
                    id.PostaviVrednostPodDomena(broker.Pronadji(putnik)[0]);
                }
            }

            for (int i = 0; i < sviAranzmani.Count;)
            {
                IDomenskiObjekat ido = sviAranzmani[i];
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

            lista = sviAranzmani;
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
