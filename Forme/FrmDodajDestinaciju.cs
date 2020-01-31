using KKI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmDodajDestinaciju : Form
    {
        public FrmDodajDestinaciju()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            try
            {
                KkiDestinacija.Instance.PostaviSveZemlje(cmbZemlja);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                //Dispose();
                // mozda neki blok forme ili tako nesto?
            }
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                KkiDestinacija.Instance.SacuvajDestinaciju(cmbZemlja, txtNazivGrada.Text);
                MessageBox.Show("Destinacija je uspesno sacuvana!");
                Dispose();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
