using Domen;
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
        private BindingList<Destinacija> sveDestinacije;
        public FrmObrisiDestinaciju()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            sveDestinacije = new BindingList<Destinacija>(Kontroler.Kontroler.Instance.VratiSveDestinacije());
            dgvDestinacije.DataSource = sveDestinacije;
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

            foreach (DataGridViewRow red in redovi)
            {
                //preneti u Kontroler KI
                Destinacija d = new Destinacija
                {
                    DestinacijaID = (int)red.Cells[0].Value,
                    NazivGrada = (string)red.Cells[1].Value,
                    Zemlja = red.Cells[2].Value as Zemlja,
                    Korisnik = red.Cells[3].Value as Korisnik
                };

                if (Kontroler.Kontroler.Instance.ObrisiDestinaciju(d))
                {
                    sveDestinacije.Remove(d);
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da obrise destinacije!");
                    return;
                }
            }

            MessageBox.Show("Sistem je uspesno obrisao destinacije!");
        }
    }
}
