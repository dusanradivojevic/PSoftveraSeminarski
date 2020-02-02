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
    public partial class FrmObrisiDestinaciju : Form
    {
        public FrmObrisiDestinaciju()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            UcitajSveDestinacije();

            dgvDestinacije.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDestinacije.Columns[2].Width = 80;
            dgvDestinacije.Columns[0].Visible = false;
        }

        private void UcitajSveDestinacije()
        {
            try
            {
                KkiDestinacija.Instance.PostaviSveDestinacije(dgvDestinacije);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                //Dispose();
                // mozda neki blok forme ili tako nesto? - ovde ili u SrediFormu()
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach (DataGridViewCell celija in dgvDestinacije.SelectedCells)
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
                    redovi.Add(dgvDestinacije.Rows[rowIndex]);
                }
            }

            if (redovi.Count == 0)
            {
                MessageBox.Show("Izaberite destinacije koje zelite da obrisete!");
                return;
            }

            DialogResult rez = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabrane" +
                " destinacije?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rez == DialogResult.Cancel)
                return;

            try
            {
                string poruka = KkiDestinacija.Instance.ObrisiDestinaciju(redovi);
                MessageBox.Show(poruka);

                UcitajSveDestinacije();
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
                KkiDestinacija.Instance.FiltrirajDestinacije(txtNazivGrada.Text, dgvDestinacije);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void txtNazivGrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }
    }
}
