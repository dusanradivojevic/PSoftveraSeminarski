using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PrijaviMeSO : OpstaSO
    {
        Korisnik Korisnik { get; set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            List<IDomenskiObjekat> korisnici = broker.PrijaviMe((Korisnik)objekat);

            if(korisnici.Count == 0)
            {
                throw new Exception("Nije pronadjen korisnik sa takvim parametrima");
            }

            if(korisnici.Count > 1)
            {
                throw new Exception("Postoji visestruko podudaranje korisnika sa" +
                    "tim parametrima u bazi");
            }      

            Korisnik = korisnici[0] as Korisnik;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Korisnik))
            {
                throw new ArgumentException("Objekat nije tipa Korisnik.");
            }

            Korisnik k = objekat as Korisnik;

            if(string.IsNullOrEmpty(k.Email) || string.IsNullOrEmpty(k.Sifra))
            {
                throw new MissingFieldException("Email i sifra moraju biti uneti!");
            }
        }
    }
}
