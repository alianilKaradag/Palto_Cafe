using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Palto_Cafe
{
    class cTarihRaporlar
    {
        cGenel gnl = new cGenel();

        public void TarihRaporlar(ListView lv,DateTimePicker dtp1,DateTimePicker dtp2)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(ARATOPLAM),TARIH from HESAPODEMELERI where TARIH between @tarih1 and @tarih2 group by TARIH ",con);
           

            cmd.Parameters.AddWithValue("@tarih1",dtp1.Value);
            cmd.Parameters.AddWithValue("@tarih2",dtp2.Value);
            


            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            SqlDataReader dr = cmd.ExecuteReader();
           
            int sayac = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr[0].ToString());
                lv.Items[sayac].SubItems.Add(dr[1].ToString());
                sayac++;
            }

            

            con.Dispose();
            con.Close();
        }

        public void toplamTarihRaporlar(Label lb,DateTimePicker dtp1,DateTimePicker dtp2)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(ARATOPLAM) from HESAPODEMELERI where TARIH between @tarih1 and @tarih2", con);

            cmd.Parameters.AddWithValue("@tarih1", dtp1.Value);
            cmd.Parameters.AddWithValue("@tarih2", dtp2.Value);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lb.Text = dr[0].ToString();
                
               
            }

        }

        
        
    }
}
