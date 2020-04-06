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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button1, "Giriş");

        }



        private void button1_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();

            cPersoneller p = new cPersoneller();
            bool result = p.personelEntryControl(txtSifre.Text,cGenel._PersonelId);
            
            if(result)
            {
                cPersonelHareketleri ch = new cPersonelHareketleri();
                ch.PersonelId = cGenel._PersonelId;
                ch.Islem = "Giriş Yaptı";
                ch.Tarih = DateTime.Now;
                ch.PersonelActionSave(ch);

                this.Hide();
                FrmMenu menu = new FrmMenu();
                menu.Show();
            }

            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

            cPersoneller p = new cPersoneller();
            p.PersonelGetByInformation(cbKullaniciAdi);
            
        }

        private void cbKullaniciAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)cbKullaniciAdi.SelectedItem;
            cGenel._PersonelId = p.PersonelId;
            cGenel._GorevId = p.PersonelGorevId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?","Dikkat!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
