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
                Putnik_Aranzman pa = new Putnik_Aranzman();
                pa.JMBG = ((Putnik)objekat).JMBG;

                if(broker.Pronadji(pa).Count > 0)
                {
                    pa = broker.Pronadji(pa)[0] as Putnik_Aranzman;
                    broker.Obrisi(pa);

                    Aranzman a = new Aranzman();
                    a.AranzmanID = pa.AranzmanID;
                    a = broker.Pronadji(a)[0] as Aranzman;
                    a.BrojPutnika -= 1;
                    broker.Azuriraj(a);
                }   

                Obrisan = true;
            }
            else
            {
                Obrisan = false;
                throw new Exception("Sistem ne moze da obrise putnika!");
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
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
