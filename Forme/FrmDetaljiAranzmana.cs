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
    public partial class FrmDetaljiAranzmana : Form
    {
        public FrmDetaljiAranzmana()
        {
            InitializeComponent();
            PostaviVrednosti();
        }

        internal void PostaviVrednosti() 
        {
            try
            {
                KkiAranzman.Instance.IspisiDetaljeAranzmana(txtID, txtNazivAranzmana, rtbOpis,
                        txtCena, txtDatum, txtUkBrMesta, txtBrojPutnika, txtBrSlbMesta, txtDestinacija,
                        txtKorisnik);
                KkiAranzman.Instance.PostaviPutnikeZaAranzman(dgvIzabraniPutnici);
                IzmeniBrojeveVezaneZaPutnike();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            UcitajSvePutnike();
        }

        private void UcitajSvePutnike()
        {
            try
            {
                KkiAranzman.Instance.PostaviSvePutnike(dgvSviPutnici);         
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnIzaberiPutnike_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach(DataGridViewCell celija in dgvSviPutnici.SelectedCells)
            {
                int rowIndex = celija.RowIndex;
                bool postoji = false;
                foreach(DataGridViewRow red in redovi)
                {
                    if(red.Index == rowIndex)
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

            try
            {
                KkiAranzman.Instance.IzaberiPutnike(dgvSviPutnici, dgvIzabraniPutnici, redovi);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            IzmeniBrojeveVezaneZaPutnike();
        }
                
        internal void OtkljucajPolja()
        {
            btnSacuvaj.Enabled = true;
            btnKreirajPutnika.Enabled = true;
            btnIzaberi.Enabled = true;
            btnIzbaci.Enabled = true;

            txtNazivAranzmana.ReadOnly = false;
            txtUkBrMesta.ReadOnly = false;
            txtUkBrMesta.BackColor = txtNazivAranzmana.BackColor;
            rtbOpis.ReadOnly = false;
            txtCena.ReadOnly = false;

            txtDatum.Visible = false;
            dtpDatum.Visible = true;

            txtDestinacija.Visible = false;
            cmbDestinacija.Visible = true;
            try
            {
                KkiDestinacija.Instance.PostaviSveDestinacije(cmbDestinacija);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnIzbaci_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> redovi = new List<DataGridViewRow>();

            foreach (DataGridViewCell celija in dgvIzabraniPutnici.SelectedCells)
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
                    redovi.Add(dgvIzabraniPutnici.Rows[rowIndex]);
                }
            }

            try
            {
                KkiAranzman.Instance.IzaberiPutnike(dgvIzabraniPutnici, dgvSviPutnici, redovi);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            IzmeniBrojeveVezaneZaPutnike();
        }

        private void IzmeniBrojeveVezaneZaPutnike()
        {
            txtBrojPutnika.Text = dgvIzabraniPutnici.Rows.Count + "";

            if (txtUkBrMesta.BackColor == txtNazivAranzmana.BackColor)
            {
                txtBrSlbMesta.Text = (int.Parse(txtUkBrMesta.Text) - dgvIzabraniPutnici.Rows.Count) + "";
                txtBrSlbMesta.BackColor = txtBrojPutnika.BackColor;
            }
            else
            {
                txtBrSlbMesta.Text = "";
                txtBrSlbMesta.BackColor = Color.IndianRed;
            }
        }
                               
        private void btnKreirajPutnika_Click(object sender, EventArgs e)
        {
            FrmKreirajPutnika forma = new FrmKreirajPutnika();
            forma.ShowDialog();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (txtUkBrMesta.BackColor != txtNazivAranzmana.BackColor)
                return;

            DialogResult rez = MessageBox.Show("Da li ste sigurni da zelite da sacuvate izmene?", 
                "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rez == DialogResult.Cancel)
                return;

            try
            {
                DateTime datum;
                if (txtDatum.Visible)
                {
                    datum = DateTime.Parse(txtDatum.Text);
                }
                else
                {
                    datum = dtpDatum.Value;
                }

                string poruka = KkiAranzman.Instance.SacuvajAranzmanSlozen(txtID.Text, txtNazivAranzmana.Text, rtbOpis.Text,
                txtCena.Text, datum, txtUkBrMesta.Text, txtBrojPutnika.Text, txtBrSlbMesta.Text, 
                cmbDestinacija); 

                MessageBox.Show(poruka);
                Dispose();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        private void txtUkBrMesta_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtUkBrMesta.Text, out int d))
            {
                txtUkBrMesta.BackColor = txtNazivAranzmana.BackColor;
            }
            else
            {
                txtUkBrMesta.BackColor = Color.IndianRed;
            }

            IzmeniBrojeveVezaneZaPutnike();
        }
    }
}
