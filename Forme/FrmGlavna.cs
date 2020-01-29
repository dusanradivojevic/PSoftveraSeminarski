using Domen;
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
        private BindingList<Aranzman> sviAranzmani;
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
            UcitajAranzmane();            
            dgvAranzmaniPretraga.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAranzmaniPretraga.Columns[2].Width = 60;

        }

        private void UcitajAranzmane()
        {
            sviAranzmani = new BindingList<Aranzman>(Kontroler.Kontroler.Instance.VratiSveAranzmane());
            dgvAranzmaniPretraga.DataSource = sviAranzmani;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        internal void PostaviKorisnika(string korisnik)
        {
            odjavaToolStripMenuItem.Text = korisnik;
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kontroler ?
            if (true)
            {
                Sesija.Instance.OdjaviKorisnika();
                MessageBox.Show("Dovidjenja!");
                frmPrijava.Dispose();
                //Dispose();
            }
            else
            {
             //   MessageBox.Show("Sistem ne moze da vas odjavi!");
            }
        }

        private void btnPrikaziDetalje_Click(object sender, EventArgs e)
        {
            if (dgvAranzmaniPretraga.SelectedCells != null &&
                dgvAranzmaniPretraga.SelectedCells.Count == 1)
            {
                int rowIndex = dgvAranzmaniPretraga.SelectedCells[0].RowIndex;
                //DataGridViewRow red = dgvAranzmaniPretraga.Rows[rowIndex];
                int aranzmanID = (int) dgvAranzmaniPretraga.Rows[rowIndex].Cells[0].Value;
                PokreniFrmDetalji(sviAranzmani.Where(x => x.AranzmanID == aranzmanID).SingleOrDefault(),
                    ((Button)sender).Text);
            }
            else if (dgvAranzmaniPretraga.SelectedCells != null &&
                dgvAranzmaniPretraga.SelectedCells.Count > 1)
            {
                // Ako odabere vise celija u istom redu ili ceo red
                bool flag = true;
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
                    int aranzmanID = (int)dgvAranzmaniPretraga.Rows[rowIndex].Cells[0].Value;
                    PokreniFrmDetalji(sviAranzmani.Where(x => x.AranzmanID == aranzmanID).SingleOrDefault(),
                        ((Button)sender).Text);
                    //PokreniFrmDetalji(red);
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
        }

        private void PokreniFrmDetalji(Aranzman a, string tip)
        {
            // izvuci u kontroler pa da on poziva formu?

            FrmDetaljiAranzmana frmDetalji = new FrmDetaljiAranzmana();
            frmDetalji.PostaviVrednosti(a);

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

            foreach (DataGridViewRow red in redovi)
            {
                //preneti u Kontroler KI
                Aranzman a = new Aranzman
                {
                    AranzmanID = (int)red.Cells[0].Value,
                    NazivAranzmana = (string)red.Cells[1].Value,
                    OpisAranzmana = (string)red.Cells[2].Value,
                    Cena = (double)red.Cells[3].Value,
                    Datum = (DateTime)red.Cells[4].Value,
                    UkupanBrMesta = (int)red.Cells[5].Value,
                    BrojPutnika = (int)red.Cells[6].Value,
                    BrSlobodnihMesta = (int)red.Cells[7].Value,
                    Destinacija = red.Cells[8].Value as Destinacija,
                    Korisnik = red.Cells[9].Value as Korisnik
                };

                if (Kontroler.Kontroler.Instance.ObrisiAranzman(a))
                {
                    sviAranzmani.Remove(a);
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da obrise aranzman!");
                    return;
                }
            }

            MessageBox.Show("Sistem je uspesno obrisao aranzman!");
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
