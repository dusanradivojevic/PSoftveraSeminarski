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
    public partial class FrmGlavna : Form, IDomenskaForma
    {
        private FrmPrijava frmPrijava;
        public FrmGlavna(FrmPrijava frmPrijava)
        {
            KkiAranzman.Instance.forma = this; //treba i za sve ostale kki koji se koriste
            this.frmPrijava = frmPrijava;
            InitializeComponent();
            SrediFormu();

            //Thread tajmerZaRefreh = new Thread(Tajmer);
            //tajmerZaRefreh.IsBackground = true;
            //tajmerZaRefreh.Start();
        }

        private void Tajmer()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(10000);
                    Invoke(new Action(() =>
                    {
                        UcitajAranzmane();
                    }));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SrediFormu()
        {
            try
            {
                PostaviKorisnika();
                UcitajAranzmane();
            
                //dgvAranzmaniPretraga.AutoSizeColumnsMode =
                //    DataGridViewAutoSizeColumnsMode.AllCells;
                dgvAranzmaniPretraga.Columns[1].Width = 120; // Naziv
                dgvAranzmaniPretraga.Columns[2].Width = 200; // Opis
                dgvAranzmaniPretraga.Columns[3].Width = 50; // Cena
                dgvAranzmaniPretraga.Columns[5].Width = 110; // Uk br mesta
                dgvAranzmaniPretraga.Columns[6].Width = 110; // Br putnika
                dgvAranzmaniPretraga.Columns[7].Width = 110; // Br slb mesta
                dgvAranzmaniPretraga.Columns[8].Width = 160; // Destinacija
                dgvAranzmaniPretraga.Columns[9].Width = 160; // Korisnik
                dgvAranzmaniPretraga.Columns[0].Visible = false; //ID
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajAranzmane()
        {
            try
            {
                KkiAranzman.Instance.PostaviSveAranzmane(dgvAranzmaniPretraga);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void PostaviKorisnika()
        {
            odjavaToolStripMenuItem.Text = Sesija.Instance.VratiKorisnikaToString();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Sesija.Instance.OdjaviKorisnika();
                MessageBox.Show("Uspešno ste se odjavili sa sistema!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPrijava.Dispose();            
            }
            catch
            {
                MessageBox.Show("Neuspešno odjavljivanje sa sistema!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrikaziDetalje_Click(object sender, EventArgs e)
        {
            // Ako izabere tacno jednu celiju u jednom redu
            if (dgvAranzmaniPretraga.SelectedCells != null &&
                dgvAranzmaniPretraga.SelectedCells.Count == 1)
            {
                int rowIndex = dgvAranzmaniPretraga.SelectedCells[0].RowIndex;
                try
                {
                    KkiAranzman.Instance.PostaviAranzman(dgvAranzmaniPretraga.Rows[rowIndex]);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                    try
                    {
                        KkiAranzman.Instance.PostaviAranzman(dgvAranzmaniPretraga.Rows[rowIndex]);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PokreniFrmDetalji(((Button)sender).Text);
                }
                else
                {
                    MessageBox.Show("Morate izabrati tacno jedan red!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati tacno jedan red!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            UcitajAranzmane(); // Refresh
        }

        private void PokreniFrmDetalji(string tip)
        {
            FrmDetaljiAranzmana frmDetalji = new FrmDetaljiAranzmana();

            if (tip.Equals("Izmeni")) // Tekst na dugmetu sa kog je pozvano
            {
                frmDetalji.OtkljucajPolja();
            }

            frmDetalji.ShowDialog();
            btnOcisti_Click(null, null);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmDodajAranzman forma = new FrmDodajAranzman();
            forma.ShowDialog();

            UcitajAranzmane();
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
                MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
        }

        private void upravljanjePutnicimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpravljanjePutnicima forma = new FrmUpravljanjePutnicima();
            forma.ShowDialog();

            UcitajAranzmane();
        }
       
        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDodajDestinaciju forma = new FrmDodajDestinaciju();
            forma.ShowDialog();

            UcitajAranzmane();
        }

        private void obrisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmObrisiDestinaciju forma = new FrmObrisiDestinaciju();
            forma.ShowDialog();

            UcitajAranzmane();
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
                MessageBox.Show("Izaberite aranzmane koje zelite da obrisete!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult rez = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabrane" +
                " aranzmane?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rez == DialogResult.Cancel)
                return;

            try
            {
                string poruka = KkiAranzman.Instance.ObrisiAranzmane(redovi);
                MessageBox.Show(poruka, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajAranzmane();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Dovidjenja!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmPrijava.Dispose();
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            txtBrSlbMesta.Text = string.Empty;
            txtCena.Text = string.Empty; 
            txtDatum.Text = string.Empty;
            txtNaziv.Text = string.Empty;

            btnPretrazi_Click(sender, e);
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

        public void IspisiPoruku(string tekst)
        {
            Invoke(
                new Action(() =>
                    MessageBox.Show(tekst, "", MessageBoxButtons.OK)
                )
            ); 
        }
    }
    
}
