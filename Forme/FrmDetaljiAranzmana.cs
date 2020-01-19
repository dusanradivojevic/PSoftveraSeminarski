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
        }

        internal void PostaviVrednosti(DataGridViewRow red)
        {
            txtID.Text = (int) red.Cells[0].Value + "";
            txtNazivAranzmana.Text = red.Cells[1].Value as string;
            rtbOpis.Text = red.Cells[2].Value as string;
            txtCena.Text = (double) red.Cells[3].Value + " e";
            txtDatum.Text = red.Cells[4].Value.ToString().Split(' ')[0]+"20";
            txtUkBrMesta.Text = (int)red.Cells[5].Value + "";
            txtBrojPutnika.Text = (int)red.Cells[6].Value + "";
            txtBrSlbMesta.Text = (int)red.Cells[7].Value + "";
            //txtDestinacija.Text = (red.Cells[8].Value as Destinacija).NazivGrada;
            //txtKorisnik.Text = (red.Cells[9].Value as Korisnik).ToString();

            //dodaj prikaz putnika
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
