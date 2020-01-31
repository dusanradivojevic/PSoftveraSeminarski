using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server Server;
        public FrmServer()
        {
            InitializeComponent();
            UgasenServerForma();
        }

        private void UgasenServerForma()
        {
            txtServerStatus.Text = "Server je ugasen.";
            txtServerStatus.BackColor = Color.IndianRed;
            btnZaustavi.Enabled = false;
            btnPokreni.Enabled = true;
            btnPokreni.Focus();
        }

        private void UpaljenServerForma()
        {
            txtServerStatus.Text = "Server je pokrenut i radi.";
            txtServerStatus.BackColor = Color.LawnGreen;
            btnZaustavi.Enabled = true;
            btnPokreni.Enabled = false;
            btnZaustavi.Focus();
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            if (Server.PokreniServer())
            {
                UpaljenServerForma();
            }
            else
            {
                MessageBox.Show("Sistem nije uspeo da pokrene server!");
            }
            
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            if (Server.ZaustaviServer())
            {
                UgasenServerForma();
            }
            else
            {
                MessageBox.Show("Sistem nije uspeo da ugasi server!");
            }            
        }
    }
}
