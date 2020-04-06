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
    public partial class frmPersonelSil : Form
    {
        public frmPersonelSil()
        {
            InitializeComponent();
        }

        private void frmPersonelSil_Load(object sender, EventArgs e)
        {
            cPersoneller p = new cPersoneller();
            p.PersonelGetByInformation(cbKullaniciAdi);
        }

        private void cbKullaniciAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)cbKullaniciAdi.SelectedItem;
            cGenel.personelid =p.PersonelId;
            //cGenel._GorevId = p.PersonelGorevId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cPersoneller c = new cPersoneller();
            c.personelSil(cGenel.personelid);
            c.personelSil2(cGenel.personelid);
            MessageBox.Show("Personel Silinmiştir!");
            FrmMenu frm = new FrmMenu();
            this.Close();
            frm.Show();

        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
