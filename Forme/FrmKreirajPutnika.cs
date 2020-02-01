using KKI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmKreirajPutnika : Form
    {
        public FrmKreirajPutnika()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            txtDatumDodavanja.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }
        
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                string poruka = KkiPutnik.Instance.KreirajPutnika(txtJmbg.Text, txtIme.Text,
                    txtPrezime.Text, txtDatumDodavanja.Text);
                MessageBox.Show(poruka);
                Dispose();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        private void txtJmbg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPotvrdi_Click(sender, e);
            }
        }

        private void txtIme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPotvrdi_Click(sender, e);
            }
        }

        private void txtPrezime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPotvrdi_Click(sender, e);
            }
        }
    }
}
