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
    public partial class frmMutfak : Form
    {
        public frmMutfak()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(btnEkle, "Ekle");
            aciklama.SetToolTip(btnDegistir, "Değiştir");
            aciklama.SetToolTip(btnBul, "Ürün Ara");
            aciklama.SetToolTip(btnSil, "Sil");
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

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            cUrunCesitleri AnaKategori = new cUrunCesitleri();
            AnaKategori.UrunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;

            label6.Visible = false;
            txtArama.Visible = false;

            cUrunler c = new cUrunler();
            c.UrunleriListele(lvGidaListesi);

        }

        private void Temizle()
        {
            txtUrunAdi.Clear();
            txtUrunFiyati.Clear();
            txtUrunFiyati.Text = string.Format("{0:##0.00}", 0);

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtUrunAdi.Text.Trim() == "" || txtUrunFiyati.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {

                    MessageBox.Show("Ürün adı,fiyatı ve kategori seçilmemiştir!", "Dikkat Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat = Convert.ToDecimal(txtUrunFiyati.Text);
                    c.UrunAd = txtUrunAdi.Text;
                    c.Aciklama = "Ürün eklendi";
                    c.UrunTurNo =urunturNo;
                    int sonuc = c.UrunEkle(c);

                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün eklenmiştir!");
                        cbKategoriler_SelectedIndexChanged(sender, e);
                        Yenile();
                        Temizle();

                    }

                }

            }

            else
            {
                if (txtKategoriAd.Text == "")
                {
                    MessageBox.Show("Lütfen bir kategori ismi giriniz!", "Dikkat Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else
                {
                    cUrunCesitleri urun = new cUrunCesitleri();
                    urun.KategoriAd = txtKategoriAd.Text;
                    urun.Aciklama = txtAciklama.Text;
                    int sonuc = urun.UrunKategoriEkle(urun);

                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori eklenmiştir!");
                        Yenile();
                        Temizle();

                    }


                }

            }
        }

        int urunturNo = 0;
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunler u = new cUrunler();
            if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
            {
                u.UrunleriListele(lvGidaListesi);

            }

            else
            {
                cUrunCesitleri cesit = (cUrunCesitleri)cbKategoriler.SelectedItem;
                urunturNo = cesit.UrunTurNo;
                u.UrunleriListeleByKategoriId(lvGidaListesi, urunturNo);  //burası urunlerilistelebyurunAdi olabilir


            }

        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {

                if (txtUrunAdi.Text.Trim() == "" || txtUrunFiyati.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {

                    MessageBox.Show("Ürün adı,fiyatı ve kategori seçilmemiştir", "Dikkat Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat = Convert.ToDecimal(txtUrunFiyati.Text);
                    c.UrunAd = txtUrunAdi.Text;
                    c.UrunId = Convert.ToInt32(txtUrunId.Text); 
                    c.UrunTurNo =urunturNo;
                    c.Aciklama = "Ürün güncellendi";
                   
                    int sonuc = c.UrunGuncelle(c);

                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün güncellenmiştir!");

                        
                        Yenile();
                        Temizle();

                    }

                }

            }

            else
            {
                if (txtKategoriId.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz!", "Dikkat Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else
                {
                    cUrunCesitleri urun = new cUrunCesitleri();
                    urun.KategoriAd = txtKategoriAd.Text;
                    urun.Aciklama = txtAciklama.Text;
                    urun.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = urun.UrunKategoriGuncelle(urun);

                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori güncellenmiştir!");
                        urun.UrunCesitleriniGetir(lvKategoriler);
                        Yenile();
                        Temizle();

                    }


                }

            }
        }


        private void lvGidaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGidaListesi.Items.Count > 0)
            {
                if (lvGidaListesi.SelectedItems.Count > 0 && lvGidaListesi.SelectedItems[0].SubItems.Count > 2)//burada bir hata alıp böyle çözdüm ilerisi için bu notu bırakıyorum(lv hatasının çözümü)
                {
                    txtUrunAdi.Text = lvGidaListesi.SelectedItems[0].SubItems[3].Text;
                    txtUrunFiyati.Text = lvGidaListesi.SelectedItems[0].SubItems[4].Text;
                    txtUrunId.Text = lvGidaListesi.SelectedItems[0].SubItems[0].Text;
                }
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.Items.Count > 0)
            {
                if (lvKategoriler.SelectedItems.Count > 0 && lvKategoriler.SelectedItems[0].SubItems.Count > 2)//burada bir hata alıp böyle çözdüm ilerisi için bu notu bırakıyorum(lv hatasının çözümü)
                {
                    txtKategoriId.Visible = true;
                    txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                    txtKategoriId.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                    txtAciklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
                }


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (rbAltKategori.Checked)
            {
                if (lvGidaListesi.SelectedItems.Count > 0)
                {


                    if (MessageBox.Show("Seçtiğiniz ürünü kaldırmak istediğinize emin misiniz?", "Dikkat Bilgiler Silinecek!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        cUrunler c = new cUrunler();

                        c.UrunId = Convert.ToInt32(txtUrunId.Text);

                        int sonuc = c.UrunSil(c);

                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün kaldırıldı!");
                            cbKategoriler_SelectedIndexChanged(sender, e);
                            Yenile();
                            Temizle();

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Silmek için bir ürün seçiniz", "Dikkat! Ürün seçmediniz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                if (lvKategoriler.SelectedItems.Count>0)
                {


                    if (MessageBox.Show("Seçtiğiniz ürünü kaldırmak istediğinize emin misiniz?", "Dikkat Bilgiler Silinecek!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        cUrunCesitleri uc = new cUrunCesitleri();
                       

                        int sonuc = uc.UrunKategoriSil(Convert.ToInt32(txtKategoriId.Text));

                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün kaldırıldı!");
                            //cbKategoriler_SelectedIndexChanged(sender, e);
                            Yenile();
                            Temizle();

                        }

                    }
                }

            }

        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            txtKategoriAd.Clear();
            txtAciklama.Clear();
            txtKategoriId.Clear();
            txtKategoriId.Visible = false;
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGidaListesi.Visible = true;
            Yenile();
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            txtUrunAdi.Clear();
            txtUrunFiyati.Clear();
            txtUrunId.Clear();
            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGidaListesi.Visible = false;
            Yenile();
           

        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            txtArama.Visible = true;

        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {

                cUrunler u = new cUrunler();
                u.UrunleriListeleByUrunAdi(lvGidaListesi, txtArama.Text);


            }

            else
            {
                cUrunCesitleri uc = new cUrunCesitleri();
                uc.UrunCesitleriniGetir(lvKategoriler, txtArama.Text);

            }
        }

        private void Yenile()
        {
            cUrunCesitleri uc = new cUrunCesitleri();
            uc.UrunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            uc.UrunCesitleriniGetir(lvKategoriler);

            cUrunler c = new cUrunler();
            c.UrunleriListele(lvGidaListesi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Close();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
