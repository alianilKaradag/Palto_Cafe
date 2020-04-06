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
    public partial class frmKasaIslemleri : Form
    {
        cGenel gnl = new cGenel();
        public frmKasaIslemleri()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(btnAylikRapor, "Aylık Rapor");
            aciklama.SetToolTip(btnZRapor, "Günlük Rapor");
            aciklama.SetToolTip(button3, "Topla");
            aciklama.SetToolTip(button4, "Topla");
            aciklama.SetToolTip(btnAylik, "Okundu! Dikkat burayı tıkladıktan sonra raporu tekrar gözlemleyemezsiniz! Lütfen bu işlemi ayda 1 kere yapın.");
            aciklama.SetToolTip(btnGunluk, "Okundu! Dikkat burayı tıkladıktan sonra raporu tekrar gözlemleyemezsiniz! Lütfen bu işlemi günde 1 kere,kasayı kapatırken yapın.");
            aciklama.SetToolTip(button1, "Hesapla");
            aciklama.SetToolTip(button2, "Hesapla");
            aciklama.SetToolTip(btnGunlukNakit, "Hesapla");
            aciklama.SetToolTip(btnGunlukKart, "Hesapla");
        }

        private void frmKasaIslemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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

       
        private void btnAylikRapor_Click(object sender, EventArgs e)
        {
            gbGunluk.Visible = false;
            gbAylik.Visible = true;
            
        }

        private void btnZRapor_Click(object sender, EventArgs e)
        {
            gbGunluk.Visible = true;
            gbAylik.Visible = false;
        }

        private void btnAylik_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update HESAPODEMELERI set AYLIK=1 where AYLIK=0", con);
           
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }

            MessageBox.Show("Aylık istatistik okundu!");
            textBox7.Clear();
            textBox8.Clear();
            textBox3.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(ARATOPLAM) from HESAPODEMELERI where DURUM=0 and ODEMETURID=1 and AYLIK=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox8.Text = dr[0].ToString();

                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(ARATOPLAM) from HESAPODEMELERI where DURUM=0 and ODEMETURID=2 and AYLIK=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox7.Text = dr[0].ToString();

                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        private void btnGunlukNakit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(ARATOPLAM) from HESAPODEMELERI where DURUM=0 and ODEMETURID=1 and GUNLUK=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox4.Text = dr[0].ToString();

                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        private void btnGunlukKart_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(ARATOPLAM) from HESAPODEMELERI where DURUM=0 and ODEMETURID=2 and GUNLUK=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox5.Text = dr[0].ToString();

                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                decimal toplam = Convert.ToDecimal(textBox7.Text) + Convert.ToDecimal(textBox8.Text);
                textBox3.Text = toplam.ToString();
                cAdisyon c = new cAdisyon();
                c.MasaOrtalamaTutar(listView2);
                int adisyonadet = listView2.Items.Count;

                decimal toplamtutar = Convert.ToDecimal(textBox3.Text);

                textBox10.Text = (toplamtutar / adisyonadet).ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Geçersiz bir işlem yürüttünüz!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                cAdisyon c = new cAdisyon();
                c.MasaOrtalamaTutar(listView1);
                int adisyonadet = listView1.Items.Count;
                decimal toplam = Convert.ToDecimal(textBox4.Text) + Convert.ToDecimal(textBox5.Text);
                textBox6.Text = toplam.ToString();
                decimal toplamtutar = Convert.ToDecimal(textBox6.Text);
                textBox9.Text = (toplamtutar / adisyonadet).ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Geçersiz bir işlem yürüttünüz!");
            }

        }

        private void btnGunluk_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update HESAPODEMELERI set GUNLUK=1 where GUNLUK=0", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }

            MessageBox.Show("Günlük istatistik okundu!");
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox9.Clear();
        }

        private void checkGunluk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkGunluk.Checked)
            {

                btnGunluk.Visible = true;

            }
            else
            {
                btnGunluk.Visible = false;
            }
        }

        private void checkAylik_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAylik.Checked)
            {

                btnAylik.Visible = true;

            }
            else
            {
                btnAylik.Visible = false;
            }
        }
    }
}
