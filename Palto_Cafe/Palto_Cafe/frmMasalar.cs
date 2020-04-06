using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palto_Cafe
{
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
            ToolTip aciklama = new ToolTip();
            
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

        cGenel gnl = new cGenel();
        private void frmMasalar_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,ID from MASALAR",con);
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                
            }
            dr = cmd.ExecuteReader();
            
            

            
            while (dr.Read())
            {

               foreach(Control item in this.Controls)
                {
                    if(item is Button)
                    {
                        if (Convert.ToInt32(dr["ID"])<10)
                        {
                            if (item.Name == "btnMasa0" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")
                            {
                                item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.yesil);
                            }
                            else if (item.Name == "btnMasa0" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                            {
                                cMasalar ms = new cMasalar();

                                //DateTime dt1 = Convert.ToDateTime(ms.SessionSum());
                                //DateTime dt2 = DateTime.Now;

                                //string st1 = Convert.ToDateTime(ms.SessionSum(1)).ToShortTimeString();
                                //string st2 = DateTime.Now.ToShortTimeString();

                                //DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                                //DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);

                                //var fark = t2 - t1;

                                //item.Text = String.Format("{0}{1}{2}",
                                //    fark.Days > 0 ? string.Format("{0}G.", fark.Days) : " ",
                                //    fark.Hours > 0 ? string.Format("{0}S.", fark.Hours) : " ",
                                //    fark.Minutes > 0 ? string.Format("{0}Dk.", fark.Minutes) : "").Trim() + "\nMasa" + dr["ID"].ToString();

                                item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.kirmizi);

                            }

                        }

                       

                        else if(Convert.ToInt32(dr["ID"]) >= 10)
                        {
                            if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")
                            {
                                item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.yesil);
                            }
                            else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                            {
                                cMasalar ms = new cMasalar();

                                //DateTime dt1 = Convert.ToDateTime(ms.SessionSum());
                                //DateTime dt2 = DateTime.Now;

                                //string st1 = Convert.ToDateTime(ms.SessionSum(1)).ToShortTimeString();
                                //string st2 = DateTime.Now.ToShortTimeString();

                                //DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                                //DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);

                                //var fark = t2 - t1;

                                //item.Text = String.Format("{0}{1}{2}",
                                //    fark.Days > 0 ? string.Format("{0}G.", fark.Days) : " ",
                                //    fark.Hours > 0 ? string.Format("{0}S.", fark.Hours) : " ",
                                //    fark.Minutes > 0 ? string.Format("{0}Dk.", fark.Minutes) : "").Trim() + "\nMasa" + dr["ID"].ToString();

                                item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.kirmizi);

                            }

                        }

                        
                        
                        

                        
                    }

                }


            }



        }

        private void btnMasa01_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa01.Text.Length;

            cGenel._ButtonValue = btnMasa01.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa01.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa02_Click(object sender, EventArgs e)
        {

            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa02.Text.Length;

            cGenel._ButtonValue = btnMasa02.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa02.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa03_Click(object sender, EventArgs e)
        {

            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa03.Text.Length;

            cGenel._ButtonValue = btnMasa03.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa03.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa04_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa04.Text.Length;

            cGenel._ButtonValue = btnMasa04.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa04.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa05_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa05.Text.Length;

            cGenel._ButtonValue = btnMasa05.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa05.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa06_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa06.Text.Length;

            cGenel._ButtonValue = btnMasa06.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa06.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa07_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa07.Text.Length;

            cGenel._ButtonValue = btnMasa07.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa07.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa08_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa08.Text.Length;

            cGenel._ButtonValue = btnMasa08.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa08.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa09_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa09.Text.Length;

            cGenel._ButtonValue = btnMasa09.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa09.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa10.Text.Length;

            cGenel._ButtonValue = btnMasa10.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa10.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa11_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa11.Text.Length;

            cGenel._ButtonValue = btnMasa11.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa11.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa12_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa12.Text.Length;

            cGenel._ButtonValue = btnMasa12.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa12.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa13_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa13.Text.Length;

            cGenel._ButtonValue = btnMasa13.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa13.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa14_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa14.Text.Length;

            cGenel._ButtonValue = btnMasa14.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa14.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa15_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa15.Text.Length;

            cGenel._ButtonValue = btnMasa15.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa15.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa16_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa16.Text.Length;

            cGenel._ButtonValue = btnMasa16.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa16.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa17_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa17.Text.Length;

            cGenel._ButtonValue = btnMasa17.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa17.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa18_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa18.Text.Length;

            cGenel._ButtonValue = btnMasa18.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa18.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa19_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa19.Text.Length;

            cGenel._ButtonValue = btnMasa19.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa19.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa20_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa20.Text.Length;

            cGenel._ButtonValue = btnMasa20.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa20.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa21_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa21.Text.Length;

            cGenel._ButtonValue = btnMasa21.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa21.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa22_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa22.Text.Length;

            cGenel._ButtonValue = btnMasa22.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa22.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa23_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa23.Text.Length;

            cGenel._ButtonValue = btnMasa23.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa23.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa24_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa24.Text.Length;

            cGenel._ButtonValue = btnMasa24.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa24.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa25_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa25.Text.Length;

            cGenel._ButtonValue = btnMasa25.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa25.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa26_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa26.Text.Length;

            cGenel._ButtonValue = btnMasa26.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa26.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa27_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa27.Text.Length;

            cGenel._ButtonValue = btnMasa27.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa27.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa28_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa28.Text.Length;

            cGenel._ButtonValue = btnMasa28.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa28.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa29_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa29.Text.Length;

            cGenel._ButtonValue = btnMasa29.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa29.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa30_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa30.Text.Length;

            cGenel._ButtonValue = btnMasa30.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa30.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa31_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa31.Text.Length;

            cGenel._ButtonValue = btnMasa31.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa31.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa32_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa32.Text.Length;

            cGenel._ButtonValue = btnMasa32.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa32.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa33_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa33.Text.Length;

            cGenel._ButtonValue = btnMasa33.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa33.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa34_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa34.Text.Length;

            cGenel._ButtonValue = btnMasa34.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa34.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa35_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa35.Text.Length;

            cGenel._ButtonValue = btnMasa35.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa35.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa36_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa36.Text.Length;

            cGenel._ButtonValue = btnMasa36.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa36.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa37_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa37.Text.Length;

            cGenel._ButtonValue = btnMasa37.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa37.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa38_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa38.Text.Length;

            cGenel._ButtonValue = btnMasa38.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa38.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa39_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa39.Text.Length;

            cGenel._ButtonValue = btnMasa39.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa39.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa40_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa40.Text.Length;

            cGenel._ButtonValue = btnMasa40.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa40.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa41_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa41.Text.Length;

            cGenel._ButtonValue = btnMasa41.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa41.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa42_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa42.Text.Length;

            cGenel._ButtonValue = btnMasa42.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa42.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa43_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa43.Text.Length;

            cGenel._ButtonValue = btnMasa43.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa43.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa44_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa44.Text.Length;

            cGenel._ButtonValue = btnMasa44.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa44.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa45_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa45.Text.Length;

            cGenel._ButtonValue = btnMasa45.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa45.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa46_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa46.Text.Length;

            cGenel._ButtonValue = btnMasa46.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa46.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa47_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa47.Text.Length;

            cGenel._ButtonValue = btnMasa47.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa47.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa48_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa48.Text.Length;

            cGenel._ButtonValue = btnMasa48.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa48.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa49_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa49.Text.Length;

            cGenel._ButtonValue = btnMasa49.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa49.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa50_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa50.Text.Length;

            cGenel._ButtonValue = btnMasa50.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa50.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa51_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa51.Text.Length;

            cGenel._ButtonValue = btnMasa51.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa51.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();

        }

        private void btnMasa52_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa52.Text.Length;

            cGenel._ButtonValue = btnMasa52.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa52.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();

        }

        private void btnMasa53_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa53.Text.Length;

            cGenel._ButtonValue = btnMasa53.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa53.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa54_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa54.Text.Length;

            cGenel._ButtonValue = btnMasa54.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa54.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa55_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa55.Text.Length;

            cGenel._ButtonValue = btnMasa55.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa55.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();

        }

        private void btnMasa56_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa56.Text.Length;

            cGenel._ButtonValue = btnMasa56.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa56.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa57_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa57.Text.Length;

            cGenel._ButtonValue = btnMasa57.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa57.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa58_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa58.Text.Length;

            cGenel._ButtonValue = btnMasa58.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa58.Name.Substring(uzunluk + 1, 2);
            this.Close();
            frm.ShowDialog();
        }
    }
}
