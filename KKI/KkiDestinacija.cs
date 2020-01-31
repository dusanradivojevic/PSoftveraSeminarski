using Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                List<Destinacija> listaDest = Kontroler.Kontroler.Instance.VratiSve(new Destinacija()).Cast<Destinacija>().ToList();

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
                List<Destinacija> listaDest= Kontroler.Kontroler.Instance.VratiSve(new Destinacija()).Cast<Destinacija>().ToList();

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
                List<Zemlja> listaZem = Kontroler.Kontroler.Instance.VratiSve(new Zemlja()).Cast<Zemlja>().ToList();

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

        public void ObrisiDestinacije(List<DataGridViewRow> redovi)
        {
            foreach (DataGridViewRow red in redovi)
            {
                Destinacija d = new Destinacija
                {
                    DestinacijaID = (int)red.Cells[0].Value,
                    NazivGrada = (string)red.Cells[1].Value,
                    Zemlja = red.Cells[2].Value as Zemlja,
                    Korisnik = red.Cells[3].Value as Korisnik
                };

                if (!Kontroler.Kontroler.Instance.ObrisiDestinaciju(d))
                {
                    throw new Exception("Sistem ne moze da obrise destinacije!");
                }                
            }
        }

        public void FiltrirajDestinacije(string grad, DataGridView dgvDestinacije)
        {
            IDictionary kriterijumi = new Dictionary<string, string>();

            kriterijumi["nazivGrada"] = string.IsNullOrEmpty(grad) ? "" : grad;

            Destinacija d = new Destinacija();
            d.Kriterijumi = kriterijumi;

            List<Destinacija> listaDestinacija = Kontroler.Kontroler.Instance.VratiFiltrirano(d).Cast<Destinacija>().ToList();

            if (listaDestinacija.Count == 0)
            {
                throw new Exception("Nije pronadjena nijedna destinacija koji zadovoljava kriterijume!");
            }

            dgvDestinacije.DataSource = listaDestinacija;
        }

        public void SacuvajDestinaciju(ComboBox cmbZemlja, string nazivGrada)
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

            bool rez = Kontroler.Kontroler.Instance.UnesiNovuDestinaciju(dest);
            if (!rez)
            {
                throw new Exception("Sistem ne moze da sacuva destinaciju!");
            }
        }
    }
}
