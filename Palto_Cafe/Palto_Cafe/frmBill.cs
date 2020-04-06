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
    public partial class frmBill : Form
    {
       
        public frmBill()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(btnHesabiKapat, "Hesabı Kapat");
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
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

        cSiparis cs = new cSiparis();

        public void frmBill_Load(object sender, EventArgs e)
        {

            
            lblAdisyonId.Text = cGenel._AdisyonId;
            txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
            cs.GetByOrder(lvUrunler,Convert.ToInt32(lblAdisyonId.Text));
            

            if (lvUrunler.Items.Count>0)
            {

                decimal toplam = 0;
                

                for (int i = 0; i < lvUrunler.Items.Count; i++)
                {
                    toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text); 

                }

                lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                lblOdenecek.Text = string.Format("{0:0.000}",toplam);

            }

           
            txtIndirimTutari.Clear();
        }

        private void txtIndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDecimal(txtIndirimTutari.Text)/100* Convert.ToDecimal(lblToplamTutar.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {

                    try
                    {
                        

                        lblIndirim.Text = string.Format("{0:0.000}", Convert.ToDecimal(txtIndirimTutari.Text) / 100 * Convert.ToDecimal(lblToplamTutar.Text));

                    }
                    catch (Exception)
                    {

                        lblIndirim.Text = string.Format("{0:0.000}", 0);
                    }

                }

                else
                {

                    MessageBox.Show("Indirim tutarı toplam tutardan fazla olamaz!");
                    txtIndirimTutari.Clear();

                }

            }
            catch (Exception)
            {

                lblIndirim.Text = string.Format("{0:0.000}", 0);
            }
        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)  
        {

            if (chkIndirim.Checked)
            {
                chkIndirim.Checked = true;
                gbIndirim.Visible = true;
                groupBox8.Visible = false;
                txtIndirimTutari.Clear();
                textBox3.Clear();
                checkBox3.Checked = false;
            }

            else if(chkIndirim.Checked==false)
            {
                chkIndirim.Checked = false;
                gbIndirim.Visible = false;
                txtIndirimTutari.Clear();
            }
                 
            

           
            
        }

        public void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text)>=0)
            {

                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                decimal indirim = Convert.ToDecimal(lblIndirim.Text);
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - indirim;
                lblOdenecek.Text = string.Format("{0:0.000}", odenecek);


            }

            

        }

        private void lblToplamTutar_TextChanged(object sender, EventArgs e)
        {
            decimal kdv = Convert.ToDecimal(lblToplamTutar.Text) * 8 / 100;
            lblKdv.Text = string.Format("{0:0.000}", kdv);
        }


        cMasalar masalar = new cMasalar();
        private void btnHesabiKapat_Click(object sender, EventArgs e)
        {
            int masaid = masalar.TableGetByNumber(cGenel._ButtonName);
            int müsteriid = 0;
            int odemetürid = 0;

            if (rbNakit.Checked)
            {
                odemetürid = 1;

            }

            if (rbKrediKarti.Checked)
            {

                odemetürid = 2;

            }

            cOdeme odeme = new cOdeme();
            
            // (ADISYONID, ODEMETURID, MUSTERIID, ARATOPLAM, KDVTUTARI, INDIRIM, TOPLAMTUTAR)

            odeme.AdisyonId = Convert.ToInt32(lblAdisyonId.Text);
            odeme.OdemeTurId = odemetürid;
            
            odeme.MusteriId = müsteriid;
            odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
            
            odeme.KdvTutari = Convert.ToDecimal(lblKdv.Text);
            odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
            odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);

            bool result = odeme.billClose(odeme);

            if (result)
            {
                MessageBox.Show("Hesap Kapatılmıştır.");
                masalar.SetChangeTableState(Convert.ToString(masaid),1);

                cAdisyon a = new cAdisyon();
                a.AdisyonKapat(Convert.ToInt32(lblAdisyonId.Text),0);

                this.Close();
                frmMasalar frm = new frmMasalar();
                frm.Show();


            }

            else
            {
                MessageBox.Show("Hesap kapatılırken bir hata oluştu!");
            }

        }

        int sayac2 = 0;
        decimal toplamtutar = 0;
        decimal odenecektutar = 0;
        
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (listView1.Items.Count > 0)
            {
               
                
               
                if (listView1.SelectedItems[0].SubItems[4].Text != "0")
                {
                   
                    

                    if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].SubItems.Count > 4)
                    {
                        cSiparis saveOrder = new cSiparis();
                        saveOrder.SetDeleteOrder(Convert.ToInt32(listView1.SelectedItems[0].SubItems[4].Text));

                        int lvurunsayac = lvUrunler.Items.Count;
                        int listviewsayac = listView1.Items.Count;

                        lvUrunler.Items.Add(listView1.SelectedItems[0].Text);
                        lvUrunler.Items[lvurunsayac].SubItems.Add(listView1.SelectedItems[0].SubItems[1].Text);
                        lvUrunler.Items[lvurunsayac].SubItems.Add(listView1.SelectedItems[0].SubItems[2].Text);
                        lvUrunler.Items[lvurunsayac].SubItems.Add(listView1.SelectedItems[0].SubItems[3].Text);
                        lvUrunler.Items[lvurunsayac].SubItems.Add(listView1.SelectedItems[0].SubItems[4].Text);

                        int lvurunsayac2 = lvUrunler.Items.Count;


                        toplamtutar = 0;
                        odenecektutar = 0;

                        for (int i = 0; i < lvurunsayac2; i++)
                        {
                            toplamtutar = Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text) + toplamtutar;
                            odenecektutar = Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text) + odenecektutar;

                            lblToplamTutar.Text = toplamtutar.ToString();
                            lblOdenecek.Text = odenecektutar.ToString();
                        }
                        toplamtutar = 0;
                        odenecektutar = 0;

                        //hesaptandustoplam = Convert.ToDecimal(listView1.Items[sayac].SubItems[3].Text) + hesaptandustoplam;
                        //label7.Text = hesaptandustoplam.ToString();

                        lvurunsayac++;
                        



                    }

                }
                else
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (lvUrunler.Items[i].SubItems[4].Text == listView1.SelectedItems[0].SubItems[5].Text)
                        {

                            lvUrunler.Items.RemoveAt(i);

                        }

                    }
                }
                hesaptandustoplam = 0;
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                int listviewsayac2 = listView1.Items.Count;
                for (int i = 0; i < listviewsayac2; i++)
                {
                    hesaptandustoplam = Convert.ToDecimal(listView1.Items[i].SubItems[3].Text) + hesaptandustoplam;
                    label7.Text = hesaptandustoplam.ToString();
                    label21.Text = hesaptandustoplam.ToString();


                }
                hesaptandustoplam = 0;

            }
        }

        int sayac = 0;
        
        decimal hesaptandustoplam = 0;
        private void lvUrunler_DoubleClick(object sender, EventArgs e)
        {
            label30.Visible = true;
            listView1.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            groupBox5.Visible = true;
            button1.Visible = true;
            groupBox2.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label27.Visible = true;


            if (lvUrunler.Items.Count > 0)
            {
                
                if (lvUrunler.SelectedItems[0].SubItems[4].Text != "0")
                {

                    if (lvUrunler.SelectedItems.Count > 0 && lvUrunler.SelectedItems[0].SubItems.Count > 4)
                    {
                        cSiparis saveOrder = new cSiparis();
                        saveOrder.SetDeleteOrder(Convert.ToInt32(lvUrunler.SelectedItems[0].SubItems[4].Text));

                        int listviewsayac = listView1.Items.Count;

                        listView1.Items.Add(lvUrunler.SelectedItems[0].Text);
                        listView1.Items[listviewsayac].SubItems.Add(lvUrunler.SelectedItems[0].SubItems[1].Text);
                        listView1.Items[listviewsayac].SubItems.Add(lvUrunler.SelectedItems[0].SubItems[2].Text);
                        listView1.Items[listviewsayac].SubItems.Add(lvUrunler.SelectedItems[0].SubItems[3].Text);
                        listView1.Items[listviewsayac].SubItems.Add(lvUrunler.SelectedItems[0].SubItems[4].Text);

                        int listviewsayac2 = listView1.Items.Count;

                        hesaptandustoplam = 0;
                        for (int i = 0; i < listviewsayac2; i++)
                        {
                            hesaptandustoplam = Convert.ToDecimal(listView1.Items[i].SubItems[3].Text) + hesaptandustoplam;
                            label7.Text = hesaptandustoplam.ToString();
                            label21.Text = hesaptandustoplam.ToString();
                            
                        }
                        hesaptandustoplam = 0;



                        lblToplamTutar.Text = (Convert.ToDecimal(lblToplamTutar.Text) - Convert.ToDecimal(listView1.Items[listviewsayac].SubItems[3].Text)).ToString();
                        lblOdenecek.Text = (Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(listView1.Items[listviewsayac].SubItems[3].Text)).ToString();
                        listviewsayac++;



                    }

                   
                }
                else
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[4].Text == lvUrunler.SelectedItems[0].SubItems[5].Text)
                        {

                            listView1.Items.RemoveAt(i);

                        }

                    }
                }
                
                lvUrunler.Items.RemoveAt(lvUrunler.SelectedItems[0].Index);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int masaid = masalar.TableGetByNumber(cGenel._ButtonName);
            int müsteriid = 0;
            int odemetürid = 0;
            

            if (radioButton1.Checked)
            {
                odemetürid = 1;


                cOdeme odeme = new cOdeme();

                

                odeme.AdisyonId = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemetürid;

                odeme.MusteriId = müsteriid;
                
                
                odeme.AraToplam = Convert.ToDecimal(label7.Text);
               

                bool result = odeme.hesaptandus(odeme);
                
                MessageBox.Show("Hesaptan Düşülmüştür");
                label7.Text = "0";
                listView1.Items.Clear();
                
                hesaptandustoplam = 0;

                textBox1.Clear();
                textBox2.Clear();
                radioButton1.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;


                label24.Text = "0";
                label21.Text = "0";
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;



            }

            else if (radioButton2.Checked)
            {

                odemetürid = 2;


                cOdeme odeme = new cOdeme();

              

                odeme.AdisyonId = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemetürid;

                odeme.MusteriId = müsteriid;
               

                odeme.AraToplam = Convert.ToDecimal(label7.Text);
               

                bool result = odeme.hesaptandus(odeme);
                MessageBox.Show("Hesaptan Düşülmüştür");
                listView1.Items.Clear();
                sayac = 0;
                hesaptandustoplam = 0;
                label7.Text = "0";
                radioButton2.Checked = false;
                textBox1.Clear();
                textBox2.Clear();

                label24.Text ="0" ;
                label21.Text = "0" ;
                checkBox1.Checked = false;
                checkBox2.Checked = false;

                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;


            }

            else
            {
                MessageBox.Show("Hesap Kapatılırken Bir Hata Oluştu!");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Masayı Silmek İstediğinizden Emin Misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cAdisyon a = new cAdisyon();
                a.AdisyonuSil(Convert.ToInt32(lblAdisyonId.Text));

                cMasalar cms = new cMasalar();
                int masaid = masalar.TableGetByNumber(cGenel._ButtonName);
                cms.MasaDurumuDegistir(masaid);

                this.Close();
                frmMasalar frm = new frmMasalar();
                frm.Show();


            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                gbIndirim.Visible = false;
                groupBox8.Visible = true;
                txtIndirimTutari.Clear();
                textBox3.Clear();
                checkBox3.Checked = true;
                chkIndirim.Checked = false;
            }
            else if (checkBox3.Checked == false)
            {
                checkBox3.Checked = false;
                groupBox8.Visible = false;
                textBox3.Clear();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDecimal(lblToplamTutar.Text)-Convert.ToDecimal(textBox3.Text)>0)
                {

                    try
                    {


                        lblIndirim.Text = string.Format("{0:0.000}",
                            Convert.ToDecimal(textBox3.Text));

                    }
                    catch (Exception)
                    {

                        lblIndirim.Text = string.Format("{0:0.000}", 0);
                    }

                }

                else
                {

                    MessageBox.Show("Indirim tutarı toplam tutardan fazla olamaz!");
                    textBox3.Clear();

                }

            }
            catch (Exception)
            {

                lblIndirim.Text = string.Format("{0:0.000}", 0);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                checkBox1.Checked = true;
                groupBox6.Visible = true;
                groupBox7.Visible = false;
                textBox1.Clear();
                textBox2.Clear();
                checkBox2.Checked = false;
            }
            else if (checkBox1.Checked == false)
            {
                checkBox1.Checked = false;
                groupBox6.Visible = false;
                textBox1.Clear();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = true;
                groupBox6.Visible = false;
                groupBox7.Visible = true;
                textBox1.Clear();
                textBox2.Clear();
                checkBox1.Checked = false;
            }
            else if (checkBox2.Checked == false)
            {
                checkBox2.Checked = false;
                groupBox7.Visible = false;
                textBox2.Clear();
            }
        }
        decimal indirim = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDecimal(textBox1.Text) / 100 * Convert.ToDecimal(label21.Text) < Convert.ToDecimal(label21.Text))
                {

                    try
                    {
                        

                        label18.Text = string.Format("{0:0.000}", Convert.ToDecimal(textBox1.Text) / 100 * Convert.ToDecimal(label21.Text));

                    }
                    catch (Exception)
                    {

                        label18.Text = string.Format("{0:0.000}", 0);
                    }

                }

                else
                {

                    MessageBox.Show("Indirim tutarı toplam tutardan fazla olamaz!");
                    textBox1.Clear();

                }

            }
            catch (Exception)
            {
                label18.Text = string.Format("{0:0.000}", 0);
                textBox1.Clear();
            }
        }

        private void label18_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(label18.Text) >= 0)
            {

                decimal odenecek = 0;
                label7.Text = label21.Text;
                decimal indirim = Convert.ToDecimal(label18.Text);
                odenecek = Convert.ToDecimal(label7.Text) - indirim;
                label7.Text = string.Format("{0:0.000}", odenecek);


            }
        }


        private void label21_TextChanged(object sender, EventArgs e)
        {
            decimal kdv = Convert.ToDecimal(lblToplamTutar.Text) * 8 / 100;
            label24.Text = string.Format("{0:0.000}", kdv);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDecimal(label21.Text) - Convert.ToDecimal(textBox2.Text) > 0)
                {

                    try
                    {


                        label18.Text = string.Format("{0:0.000}",
                            Convert.ToDecimal(textBox2.Text));

                    }
                    catch (Exception)
                    {

                        label18.Text = string.Format("{0:0.000}", 0);
                    }

                }

                else
                {

                    MessageBox.Show("Indirim tutarı toplam tutardan fazla olamaz!");
                    textBox2.Clear();

                }

            }
            catch (Exception)
            {

                label18.Text = string.Format("{0:0.000}", 0);
            }
        }
    }
    
}
