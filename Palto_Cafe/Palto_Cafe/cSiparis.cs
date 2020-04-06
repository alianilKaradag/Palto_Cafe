using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Palto_Cafe
{
    class cSiparis
    {

        cGenel gnl = new cGenel();

        #region Fields
        private int _Id;
        private int _AdisyonId;
        private int _UrunId;
        private int _Adet;
        private int _MasaId;
        #endregion

        #region Properties

        public int Id { get => _Id; set => _Id = value; }
        public int AdisyonId { get => _AdisyonId; set => _AdisyonId = value; }
        public int UrunId { get => _UrunId; set => _UrunId = value; }
        public int Adet { get => _Adet; set => _Adet = value; }
        public int MasaId { get => _MasaId; set => _MasaId = value; } 
        #endregion


        //siparişleri getir
        public void GetByOrder(ListView lv,int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNAD,FIYAT,SATISLAR.ID,SATISLAR.URUNID,SATISLAR.ADET from SATISLAR Inner Join URUNLER on SATISLAR.URUNID=URUNLER.ID Where ADISYONID=@AdisyonId",con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@AdisyonId",SqlDbType.Int).Value=AdisyonId;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                dr = cmd.ExecuteReader();
                int sayac = 0;

                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

                    sayac++;

                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }



        }

        public bool SetSaveOrder(cSiparis Bilgiler)
        {

            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into SATISLAR(ADISYONID,URUNID,ADET,MASAID) values (@AdisyonNo,@UrunId,@Adet,@MasaId)", con);

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdisyonNo",SqlDbType.Int).Value=Bilgiler._AdisyonId;
                cmd.Parameters.Add("@UrunId",SqlDbType.Int).Value=Bilgiler._UrunId;
                cmd.Parameters.Add("@Adet",SqlDbType.Int).Value=Bilgiler._Adet;
                cmd.Parameters.Add("@MasaId",SqlDbType.Int).Value=Bilgiler._MasaId;

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

            return sonuc;
        }

        public void SetDeleteOrder(int SatisId)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From SATISLAR Where ID=@SatisId", con);

            cmd.Parameters.Add("@SatisId",SqlDbType.Int).Value = SatisId;

            if (con.State==ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();

        }
    }
}
