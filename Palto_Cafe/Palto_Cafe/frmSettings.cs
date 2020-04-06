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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button5, "Kaydet");
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

        private void frmSettings_Load(object sender, EventArgs e)
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

        bool result = false;
        bool sonuc = false;
        private void button5_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();

            cPersoneller p = new cPersoneller();
            bool result = p.personelEntryControl(txtSifre.Text, cGenel._PersonelId);
            cPersonelHareketleri ch = new cPersonelHareketleri();

            if (result)
            {
               
                ch.PersonelId = cGenel._PersonelId;
               

                if (txtYeniSifre.Text.Trim() != "" || txtYeniSifreTekrar.Text.Trim() != "")
                {

                    if (txtYeniSifre.Text==txtYeniSifreTekrar.Text)
                    {

                        

                            cPersoneller c = new cPersoneller();
                            bool sonuc = c.personelSifreDegistir(ch.PersonelId, txtYeniSifre.Text);
                            if (sonuc)
                            {

                                MessageBox.Show("Şifreniz Başarıyla Değiştirilmiştir!");
                                txtSifre.Clear();
                                txtYeniSifre.Clear();
                                txtYeniSifreTekrar.Clear();
                                cbKullaniciAdi.Items.Clear();

                            }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Aynı değil!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("Şifre Alanı Boş Bırakılamaz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            else
            {
                MessageBox.Show("Eski Şifrenizi Yanlış Girdiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
