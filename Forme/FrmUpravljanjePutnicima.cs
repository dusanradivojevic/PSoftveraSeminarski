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
    public partial class FrmUpravljanjePutnicima : Form
    {
        public FrmUpravljanjePutnicima()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            UcitajSvePutnike();
            txtDatumDodavanja.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void UcitajSvePutnike()
        {
            try
            {
                KkiPutnik.Instance.PostaviSvePutnike(dgvSviPutnici);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                string poruka = KkiPutnik.Instance.KreirajPutnika(txtJmbg.Text, txtIme.Text,
                    txtPrezime.Text, txtDatumDodavanja.Text);
                MessageBox.Show(poruka);

                UcitajSvePutnike();
                OcistiFormu();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void OcistiFormu()
        {
            txtJmbg.Text = string.Empty;
            txtIme.Text = string.Empty;
            txtPrezime.Text = string.Empty;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach (DataGridViewCell celija in dgvSviPutnici.SelectedCells)
            {
                int rowIndex = celija.RowIndex;
                bool postoji = false;
                foreach (DataGridViewRow red in redovi)
                {
                    if (red.Index == rowIndex)
                    {
                        postoji = true;
                        break;
                    }
                }

                if (!postoji)
                {
                    redovi.Add(dgvSviPutnici.Rows[rowIndex]);
                }
            }

            if (redovi.Count == 0)
            {
                MessageBox.Show("Izaberite putnike koje zelite da obrisete!");
                return;
            }

            DialogResult rez = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabrane" +
                " putnike?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rez == DialogResult.Cancel)
                return;

            try
            {
                string poruka = KkiPutnik.Instance.ObrisiPutnike(redovi);
                MessageBox.Show(poruka);

                UcitajSvePutnike();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            try
            {
                KkiPutnik.Instance.FiltrirajPutnike(txtJmbgPretraga.Text,
                txtImePretraga.Text, txtPrezimePretraga.Text, dgvSviPutnici);
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

        private void txtJmbgPretraga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }

        private void txtImePretraga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }

        private void txtPrezimePretraga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            txtJmbgPretraga.Text = string.Empty;
            txtImePretraga.Text = string.Empty;
            txtPrezimePretraga.Text = string.Empty;

            btnPretrazi_Click(sender, e);
        }
    }
}
