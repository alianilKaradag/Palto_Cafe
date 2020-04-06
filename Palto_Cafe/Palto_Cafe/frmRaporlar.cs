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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button1, "Kaydet");
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {

        }

        int sayi;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim()=="" || textBox4.Text.Trim()=="" || textBox5.Text.Trim()=="")
            {

                MessageBox.Show("Personel bilgilerini kontrol ediniz!", "Dikkat Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                cGenel gnl = new cGenel();
                cPersoneller p = new cPersoneller();

                p.PersonelAd = textBox1.Text;
                p.PersonelSoyad = textBox2.Text;
                p.PersonelParola = textBox3.Text;
                p.PersonelKullaniciAdi = textBox4.Text;
                p.PersonelGorevId = Convert.ToInt32(textBox5.Text);

                bool sonuc = p.personelEkle(p);
                MessageBox.Show("Personel eklenmiştir!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

            }
            


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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
