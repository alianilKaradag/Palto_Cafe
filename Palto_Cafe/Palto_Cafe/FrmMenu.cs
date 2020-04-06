using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Palto_Cafe
{
    
    public partial class FrmMenu : Form
    {
        cGenel gnl = new cGenel();
        public FrmMenu()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(btnMasaSiparis, "Masalar");
            aciklama.SetToolTip(btnAyarlar, "Şifre Değiştirme");
            aciklama.SetToolTip(btnKasaIslemleri, "Kasa İşlemleri");
            aciklama.SetToolTip(btnPersonel, "Personel Ekle");
            aciklama.SetToolTip(btnMutfak, "Menüyü Düzenle");
        }

        private void btnMasaSiparis_Click(object sender, EventArgs e)
        {
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.Show();
        }

        private void btnKasaIslemleri_Click(object sender, EventArgs e)
        {
            frmKasaIslemleri frm = new frmKasaIslemleri();
            this.Close();
            frm.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            frmMutfak frm = new frmMutfak();
            this.Close();
            frm.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            frmPersonel frm = new frmPersonel();
            this.Close();
            frm.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            this.Close();
            frm.Show();
        }

        private void btnKilit_Click(object sender, EventArgs e)
        {
            frmLock frm = new frmLock();
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

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            cPersonelHareketleri ch = new cPersonelHareketleri();
            

            if (cGenel._GorevId==1)
            {
                btnKasaIslemleri.Visible = true;
                btnMutfak.Visible = true;
                btnPersonel.Visible = true;
                button3.Visible = true;
                button2.Visible = true;
                button1.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
            }

            else
            {
                btnMutfak.Visible = false;
                btnKasaIslemleri.Visible = false;
                btnPersonel.Visible = false;
                button3.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label1.Visible = false;
                label8.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTarihRaporlar frm = new frmTarihRaporlar();
            this.Close();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPersonelHareketleri frm = new frmPersonelHareketleri();
            this.Close();
            frm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPersonelSil frm = new frmPersonelSil();
            this.Close();
            frm.Show();
        }
    }
}
