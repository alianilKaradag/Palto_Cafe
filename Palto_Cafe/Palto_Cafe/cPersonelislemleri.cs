using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Palto_Cafe
{
    class cPersonelislemleri
    {
        cGenel gnl = new cGenel();

        public void Personelislemleri(ListView lv)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select PERSONELID,ISLEM,TARIH from PERSONELHAREKETLERI order by TARIH desc",con);

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
                lv.Items[sayac].SubItems.Add(dr[2].ToString());
                sayac++;

            }

            con.Dispose();
            con.Close();

        }
    }
}
