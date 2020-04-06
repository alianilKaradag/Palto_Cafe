using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palto_Cafe
{
    public partial class frmPersonelHareketleri : Form
    {
        public frmPersonelHareketleri()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Close();
            frm.Show();
        }

        private void frmPersonelHareketleri_Load(object sender, EventArgs e)
        {
            cPersonelislemleri cpi = new cPersonelislemleri();
            cpi.Personelislemleri(listView1);
            cPersoneller cp = new cPersoneller();
            cp.personelGetir(listView2);
            
        }
    }
}
