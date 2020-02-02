using KKI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmGlavna : Form
    {
        private FrmPrijava frmPrijava;
        public FrmGlavna(FrmPrijava frmPrijava)
        {
            this.frmPrijava = frmPrijava;
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            PostaviKorisnika();
            UcitajAranzmane();
            
            dgvAranzmaniPretraga.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAranzmaniPretraga.Columns[2].Width = 60;
        }

        private void UcitajAranzmane()
        {
            try
            {
                KkiAranzman.Instance.PostaviSveAranzmane(dgvAranzmaniPretraga);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                //Dispose();
                // mozda neki blok forme ili tako nesto?
            }
        }

        internal void PostaviKorisnika()
        {
            odjavaToolStripMenuItem.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesija.Instance.OdjaviKorisnika();
            MessageBox.Show("Dovidjenja!");
            frmPrijava.Dispose();            
        }

        private void btnPrikaziDetalje_Click(object sender, EventArgs e)
        {
            // Ako izabere tacno jednu celiju u jednom redu
            if (dgvAranzmaniPretraga.SelectedCells != null &&
                dgvAranzmaniPretraga.SelectedCells.Count == 1)
            {
                int rowIndex = dgvAranzmaniPretraga.SelectedCells[0].RowIndex;
                KkiAranzman.Instance.PostaviAranzman(dgvAranzmaniPretraga.Rows[rowIndex]);

                PokreniFrmDetalji(((Button)sender).Text);
            }
            // Ako izabere vise celija u istom redu ili ceo red
            else if (dgvAranzmaniPretraga.SelectedCells != null &&
                dgvAranzmaniPretraga.SelectedCells.Count > 1)
            {
                bool flag = true; // Da li je izabrao celije iz razlicith redova
                                  // (ne mogu da se prikazu 2 aranzmana istovremeno)
                int rowIndex = dgvAranzmaniPretraga.SelectedCells[0].RowIndex;
                foreach (DataGridViewCell cell in dgvAranzmaniPretraga.SelectedCells)
                {
                    if (rowIndex != cell.RowIndex)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    KkiAranzman.Instance.PostaviAranzman(dgvAranzmaniPretraga.Rows[rowIndex]);

                    PokreniFrmDetalji(((Button)sender).Text);
                }
                else
                {
                    MessageBox.Show("Morate izabrati tacno jedan red!");
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati tacno jedan red!");
            }

            UcitajAranzmane(); // Refresh
        }

        private void PokreniFrmDetalji(string tip)
        {
            FrmDetaljiAranzmana frmDetalji = new FrmDetaljiAranzmana();

            if (tip.Equals("Izmeni")) //tekst na dugmetu sa kog je pozvano
            {
                frmDetalji.OtkljucajPolja();
            }

            frmDetalji.ShowDialog();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmDodajAranzman forma = new FrmDodajAranzman();
            forma.ShowDialog();

            UcitajAranzmane();
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDodajDestinaciju forma = new FrmDodajDestinaciju();
            forma.ShowDialog();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            try
            {
                KkiAranzman.Instance.FiltrirajAranzmane(txtNaziv.Text, txtCena.Text, 
                    txtDatum.Text, txtBrSlbMesta.Text, dgvAranzmaniPretraga);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void upravljanjePutnicimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpravljanjePutnicima forma = new FrmUpravljanjePutnicima();
            forma.ShowDialog();
        }

        private void obrisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmObrisiDestinaciju forma = new FrmObrisiDestinaciju();
            forma.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach (DataGridViewCell celija in dgvAranzmaniPretraga.SelectedCells)
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
                    redovi.Add(dgvAranzmaniPretraga.Rows[rowIndex]);
                }
            }

            if (redovi.Count == 0)
            {
                MessageBox.Show("Izaberite aranzmane koje zelite da obrisete!");
                return;
            }

            DialogResult rez = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabrane" +
                " aranzmane?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rez == DialogResult.Cancel)
                return;

            try
            {
                string poruka = KkiAranzman.Instance.ObrisiAranzmane(redovi);
                MessageBox.Show(poruka);

                UcitajAranzmane();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        private void FrmGlavna_Load(object sender, EventArgs e)
        {
            frmPrijava.Visible = false;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            btnPrikaziDetalje_Click(sender, e);
        }

        private void FrmGlavna_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sesija.Instance.OdjaviKorisnika();
            MessageBox.Show("Dovidjenja!");
            frmPrijava.Dispose();
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            txtBrSlbMesta.Text = string.Empty;
            txtCena.Text = string.Empty; 
            txtDatum.Text = string.Empty;
            txtNaziv.Text = string.Empty;
        }

        private void txtNaziv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }

        private void txtCena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }

        private void txtBrSlbMesta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }

        private void txtDatum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPretrazi_Click(sender, e);
            }
        }

        private void dgvAranzmaniPretraga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPrikaziDetalje_Click(sender, e);
            }
        }
    }
    
}
