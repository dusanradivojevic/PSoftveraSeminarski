using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class UnosPutnika : OpstaSO
    {
        public bool UspesanUnos { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat) //Aranzman
        {
            Aranzman aranzman = objekat as Aranzman;

            Putnik_Aranzman pa = new Putnik_Aranzman();
            pa.AranzmanID = aranzman.AranzmanID;
            int brojRedova = broker.Obrisi(pa);
            if (brojRedova < 1)
            {
                UspesanUnos = false;
                throw new Exception("Sistem ne moze da obrise Putnik_Aranzman!");
            }
                        
            pa.DatumRezervacije = DateTime.Now;
            foreach (Putnik p in aranzman.Putnici) 
            {
                pa.JMBG = p.JMBG;
                broker.Sacuvaj(pa);
            }                       

            brojRedova = broker.Obrisi(aranzman);
            if (brojRedova < 1)
            {
                UspesanUnos = false;
                throw new Exception("Sistem ne moze da obrise Aranzman!");
            }
            broker.Sacuvaj(aranzman);

            UspesanUnos = true;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Aranzman))
            {
                throw new Exception("Objekat nije tipa Aranzman!");
            }

            if (!objekat.AdekvatnoPopunjen())
            {
                throw new MissingFieldException("Svi neophodni podaci moraju biti ispravno uneti!");
            }

            List<IDomenskiObjekat> rezultat = broker.Pronadji(objekat);
            if (rezultat.Count == 0)
            {
                throw new Exception("Aranzman ne moze biti azuriran jer ne postoji u bazi!");
            }
        }
    }
}
