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
    public partial class FrmGlavna : Form
    {
        public FrmGlavna()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            List<Aranzman> lista = Kontroler.Kontroler.Instance.VratiSveAranzmane();
            dgvAranzmaniPretraga.DataSource = lista;
            dgvAranzmaniPretraga.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAranzmaniPretraga.Columns[2].Width = 60;

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
                Dispose();
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
                DataGridViewRow red = dgvAranzmaniPretraga.Rows[rowIndex];
                PokreniFrmDetalji(red);
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
                    DataGridViewRow red = dgvAranzmaniPretraga.Rows[rowIndex];
                    PokreniFrmDetalji(red);
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

        private void PokreniFrmDetalji(DataGridViewRow red)
        {
            // izvuci u kontroler pa da on poziva formu?

            FrmDetaljiAranzmana frmDetalji = new FrmDetaljiAranzmana();
            frmDetalji.PostaviVrednosti(red);
            frmDetalji.ShowDialog();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmDodajAranzman forma = new FrmDodajAranzman();
            forma.ShowDialog();
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
    }
}
