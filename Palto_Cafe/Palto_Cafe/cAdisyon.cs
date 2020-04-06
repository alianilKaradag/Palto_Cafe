using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Palto_Cafe
{
    class cAdisyon
    {

        cGenel gnl = new cGenel();
        
        #region Fields
        private int _ID;
        private decimal _TUTAR;
        private DateTime _TARIH;
        private int _PERSONELID;
        private int _DURUM;
        private int _MASAID;
        #endregion
       
        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public decimal TUTAR { get => _TUTAR; set => _TUTAR = value; }
        public DateTime TARIH { get => _TARIH; set => _TARIH = value; }
        public int PERSONELID { get => _PERSONELID; set => _PERSONELID = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int MASAID { get => _MASAID; set => _MASAID = value; } 
        #endregion




        public int GetByAddition(int MasaId)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From ADISYON Where MASAID=@MasaId Order by ID desc",con);
            cmd.Parameters.Add("@MasaId",SqlDbType.Int).Value=MasaId;

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();

                }

                MasaId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

                
            }

            finally
            {
                con.Close();
            }

            return MasaId;

        }


        public bool SetByAdditionNew(cAdisyon bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into ADISYON(TARIH,PERSONELID,MASAID,DURUM) values (@Tarih,@PersonelId,@MasaId,@Durum)", con);

           
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@Tarih",SqlDbType.DateTime).Value=bilgiler._TARIH;
                cmd.Parameters.Add("@PersonelId",SqlDbType.Int).Value=bilgiler._PERSONELID;
                cmd.Parameters.Add("@MasaId",SqlDbType.Int).Value=bilgiler._MASAID;
                cmd.Parameters.Add("@Durum",SqlDbType.Bit).Value=bilgiler._DURUM;

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

        public void AdisyonKapat(int adisyonId,int durum)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Uptade ADISYON set DURUM=@Durum Where ID=@AdisyonId",con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {

                    con.Open();
                }

                cmd.Parameters.Add("AdisyonId",SqlDbType.Int).Value=adisyonId;
                cmd.Parameters.Add("Durum",SqlDbType.Int).Value=durum;
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



        }

        public void AdisyonuSil(int adisyonid)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete SATISLAR where ADISYONID=@adisyonid",con);
            SqlCommand cmd2 = new SqlCommand("Delete ADISYON where ID=@id",con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                }
                cmd.Parameters.AddWithValue("@adisyonid", adisyonid);
                cmd.ExecuteNonQuery();
                cmd2.Parameters.AddWithValue("@id",adisyonid);
                cmd2.ExecuteNonQuery();
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

        public void MasaOrtalamaTutar(ListView lv)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select distinct ADISYONID from HESAPODEMELERI ", con);

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

            while (dr.Read())
            {
                lv.Items.Add(dr[0].ToString());

            }
            con.Dispose();
            con.Close();

        }
    }
}

