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
                MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                string poruka = KkiDestinacija.Instance.SacuvajDestinaciju(cmbZemlja, txtNazivGrada.Text);
                MessageBox.Show(poruka, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtNazivGrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDodaj_Click(sender, e);
            }
        }
    }
}
