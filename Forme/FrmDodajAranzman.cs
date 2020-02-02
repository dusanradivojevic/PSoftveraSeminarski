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
    public partial class FrmDodajAranzman : Form
    {
        public FrmDodajAranzman()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {        
            dtpDatum.Format = DateTimePickerFormat.Short;
            try
            {
                KkiDestinacija.Instance.PostaviSveDestinacije(cmbDestinacija);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            txtKorisnik.Text = Sesija.Instance.VratiKorisnikaToString();
        }
        
        private void txtUkBrMesta_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtUkBrMesta.Text, out int ukBr))
            {
                txtBrSlbMesta.Text = ukBr + "";
                txtUkBrMesta.BackColor = Color.White;
            }
            else
            {
                txtUkBrMesta.BackColor = Color.IndianRed;
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                string poruka = KkiAranzman.Instance.SacuvajAranzman(txtNazivAranzmana.Text,
                    rtbOpis.Text, txtCena.Text, dtpDatum.Value, txtUkBrMesta.Text, 
                    txtBrojPutnika.Text, txtBrSlbMesta.Text, cmbDestinacija);

                MessageBox.Show(poruka);
                Dispose();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }              
        }
    }
}
