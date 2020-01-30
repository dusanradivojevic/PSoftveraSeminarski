using Domen;
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
        // Obrisi tajmer ako je refresh postavljen posle svake crud operacija
        private FrmPrijava frmPrijava;
        public FrmGlavna(FrmPrijava frmPrijava)
        {
            this.frmPrijava = frmPrijava;
            InitializeComponent();
            SrediFormu();

            Thread tajmerZaUcitavanje = new Thread(Tajmer);
            tajmerZaUcitavanje.IsBackground = true;
            tajmerZaUcitavanje.Start();
        }

        private void SrediFormu()
        {
            PostaviKorisnika();
            UcitajAranzmane();   
            
            // proveri da li ovo radi uopste
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
        }

        private void Tajmer()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(15000);
                    Invoke(new Action(() =>
                    {
                        UcitajAranzmane();
                    }));
                }
            }
            catch (Exception)
            {

            }
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDodajDestinaciju forma = new FrmDodajDestinaciju();
            forma.ShowDialog();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            
                    
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

            try
            {
                KkiAranzman.Instance.ObrisiAranzmane(redovi);
                MessageBox.Show("Sistem je uspesno obrisao aranzmane!");

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
    }
    
}
