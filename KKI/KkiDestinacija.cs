﻿using Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicki;

namespace KKI
{
    public class KkiDestinacija
    {
        private static KkiDestinacija _instance;
        public static KkiDestinacija Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KkiDestinacija();
                }

                return _instance;
            }
        }

        private KkiDestinacija()
        {
        }

        ////////////////////
        
        public void PostaviSveDestinacije(ComboBox cmb)
        {
            try
            {
                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiSve, new Destinacija());
                List<Destinacija> listaDest = odg.Objekat as List<Destinacija>;

                if (listaDest.Count == 0)
                {
                    throw new Exception("Neuspesno ucitavanje destinacija");
                }

                cmb.DataSource = listaDest;                
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }        

        public void PostaviSveDestinacije(DataGridView dgvDestinacije)
        {
            try
            {
                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiSve, new Destinacija());
                List<Destinacija> listaDest = odg.Objekat as List<Destinacija>;

                if (listaDest.Count == 0)
                {
                    throw new Exception("Neuspesno ucitavanje destinacija!");
                }

                dgvDestinacije.DataSource = listaDest;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void PostaviSveZemlje(ComboBox cmb)
        {
            try
            {
                Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiSve, new Zemlja());
                List<Zemlja> listaZem = odg.Objekat as List<Zemlja>;

                if (listaZem.Count == 0)
                {
                    throw new Exception("Neuspesno ucitavanje zemalja!");
                }

                cmb.DataSource = listaZem;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string ObrisiDestinaciju(List<DataGridViewRow> redovi)
        {
            Odgovor odg = new Odgovor();
            foreach (DataGridViewRow red in redovi)
            {
                Destinacija d = new Destinacija
                {
                    DestinacijaID = (int)red.Cells[0].Value,
                    NazivGrada = (string)red.Cells[1].Value,
                    Zemlja = red.Cells[2].Value as Zemlja,
                    Korisnik = red.Cells[3].Value as Korisnik
                };

                 odg = Komunikacija.Instance.KreirajZahtev(Operacija.ObrisiDestinaciju, d);            
            }
            return odg.Poruka;
        }

        public void FiltrirajDestinacije(string grad, DataGridView dgvDestinacije)
        {
            IDictionary kriterijumi = new Dictionary<string, string>();

            kriterijumi["nazivGrada"] = string.IsNullOrEmpty(grad) ? "" : grad;

            Destinacija d = new Destinacija();
            d.Kriterijumi = kriterijumi;

            Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.VratiFiltrirano, d);
            List<Destinacija> listaDest = odg.Objekat as List<Destinacija>;

            if (listaDest.Count == 0)
            {
                throw new Exception("Nije pronadjena nijedna destinacija koji zadovoljava kriterijume!");
            }

            dgvDestinacije.DataSource = listaDest;
        }

        public string SacuvajDestinaciju(ComboBox cmbZemlja, string nazivGrada)
        {
            if (cmbZemlja.SelectedItem == null || !(cmbZemlja.SelectedItem is Zemlja) ||
                string.IsNullOrEmpty(nazivGrada))
            {
                throw new Exception("Svi podaci moraju biti pravilno uneti!");
            }

            Destinacija dest = new Destinacija
            {
                NazivGrada = nazivGrada,
                Zemlja = cmbZemlja.SelectedItem as Zemlja,
                Korisnik = Sesija.Instance.VratiKorisnikaObjekat()
            };

            Odgovor odg = Komunikacija.Instance.KreirajZahtev(Operacija.UnesiNovuDestinaciju, dest);
            return odg.Poruka;
        }
    }
}
