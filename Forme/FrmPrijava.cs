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
    public partial class FrmPrijava : Form
    {
        public FrmPrijava()
        {
            InitializeComponent();
            this.ActiveControl = txtKorisnickoIme;
            txtKorisnickoIme.Focus();
        }
               

        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            //Validacija

            FrmGlavna forma = new FrmGlavna();
            forma.ShowDialog();
        }

        private void txtSifra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnPrijaviSe_Click(sender, e);
            }
        }
    }
}
