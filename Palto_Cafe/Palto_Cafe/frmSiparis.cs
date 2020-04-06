using System;
using System.Collections;
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
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(btnSiparis,"Adisyona İşle");
            aciklama.SetToolTip(btnOdeme, "Hesabı Kapat");
          
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
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.Show();
        }

        //Hesap İşlemi
        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;


                default:
                    MessageBox.Show("Sayı Gir");
                    break;
            }

        }
        int TableId;
        int AdditionId;
        private void frmSiparis_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            lblMasaNo.Text = cGenel._ButtonValue;
          
            cMasalar ms = new cMasalar();

            TableId = ms.TableGetByNumber(cGenel._ButtonName);

            if (ms.TableGetByState(TableId,2)==true)
            {

                cAdisyon Ad = new cAdisyon();
                AdditionId = Ad.GetByAddition(TableId);
                cSiparis orders = new cSiparis();
                orders.GetByOrder(lvSiparisler, AdditionId);
            
            }

            btn1.Click +=new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);

          
                
         // ms.MasalariDurumaGoreGetir(cbMasalar);

            
        }

        cUrunCesitleri uc = new cUrunCesitleri();
        
private void btnEspresso01_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnEspresso01);
        }

        private void btnFiltre02_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnFiltre02);
        }

        private void btnCappucino03_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnCappucino03);
        }

        private void btnLatte04_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnLatte04);
        }

        private void btnMocha05_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnMocha05);
        }

        private void btnCikolata06_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnCikolata06);
        }

        private void btnSıcak07_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnSıcak07);
        }

        private void btnTurk08_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnTurk08);
        }

        private void btnBitki09_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnBitki09);
        }

        private void btnSogukKahveler10_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnSogukKahveler10);
        }

        private void btnMilkshake11_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnMilkshake11);
        }

        private void btnSoguk12_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnSoguk12);
        }

        private void btnFrozen13_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnFrozen13);
        }

        private void btnTatlilar14_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnTatlilar14);
        }

        private void btnMenuler15_Click(object sender, EventArgs e)
        {
            uc.GetByProductTypes(lvMenu, btnMenuler15);
        }

        int sayac = 0;
        int sayac2 = 0;

        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtAdet.Text=="")
            {
                txtAdet.Text = "1";
            }

            if (lvMenu.Items.Count > 0)
            {

                sayac = lvSiparisler.Items.Count;
                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());
                
                lvYeniEklenenler.Items.Add(AdditionId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(TableId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;
                txtAdet.Text = "";


            }
        }

        ArrayList silinenler = new ArrayList();
        private void btnSiparis_Click(object sender, EventArgs e)
        {
            /*
             1-masa boş
             2-masa dolu
             */

            cMasalar Masa = new cMasalar();
            cAdisyon NewAddition = new cAdisyon();
            cSiparis SaveOrder = new cSiparis();

            frmMasalar ms = new frmMasalar();

            bool sonuc = false;


            if (Masa.TableGetByState(TableId,1)==true)
            {

                NewAddition.PERSONELID = 1;
                NewAddition.MASAID = TableId;
                NewAddition.TARIH = DateTime.Now;
                sonuc = NewAddition.SetByAdditionNew(NewAddition);
                Masa.SetChangeTableState(cGenel._ButtonName,2);

                if (lvSiparisler.Items.Count>0)
                {

                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {

                        SaveOrder.MasaId = TableId;
                        SaveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        SaveOrder.AdisyonId = NewAddition.GetByAddition(TableId);
                        SaveOrder.Adet= Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        SaveOrder.SetSaveOrder(SaveOrder);

                    }

                    this.Close();
                    ms.Show();

                }


            }
            else if (Masa.TableGetByState(TableId, 2) == true)
            {
                if (lvYeniEklenenler.Items.Count > 0)
                {

                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {

                        SaveOrder.MasaId = TableId;
                        SaveOrder.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        SaveOrder.AdisyonId = NewAddition.GetByAddition(TableId);
                        SaveOrder.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        SaveOrder.SetSaveOrder(SaveOrder);

                    }

                    

                }

                if (silinenler.Count > 0)
                {
                    foreach (string item in silinenler)
                    {
                        SaveOrder.SetDeleteOrder(Convert.ToInt32(item));
                    }

                }

                this.Close();
                ms.Show();


            } 



        }

        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparisler.Items.Count>0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    cSiparis saveOrder = new cSiparis();
                    saveOrder.SetDeleteOrder(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[4].Text));
                }

                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text )
                        {

                            lvYeniEklenenler.Items.RemoveAt(i);

                        }

                    }
                }

                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);

            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            cGenel._AdisyonId = AdditionId.ToString();
            frmBill frm = new frmBill();
            this.Close();
            frm.Show();
        }

        private void lvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}