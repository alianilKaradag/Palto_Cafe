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
    class cPersoneller
    {
        #region Fields
        private int _PersonelId;
        private int _PersonelGorevId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;
        #endregion
        #region Properties
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int PersonelGorevId { get => _PersonelGorevId; set => _PersonelGorevId = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; }
        #endregion

        cGenel gnl = new cGenel();

        public bool personelEntryControl(string Password,int UserId) 
        {

            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@Id and Parola=@Password", con);
            
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
            
           

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());
                
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
                
            }


            return result;
        }
        public void PersonelGetByInformation(ComboBox cb)
        {

            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller", con);
           

           
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p._PersonelId = Convert.ToInt32(dr["ID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                p._PersonelDurum = Convert.ToBoolean(dr["DURUM"]);
                p._PersonelGorevId = Convert.ToInt32(dr["YETKIID"]);
                
                cb.Items.Add(p);

            }

            dr.Close();
            con.Close();

            

        }
        public override string ToString()
        {
            return PersonelAd+ " "+ PersonelSoyad;
        }

        public bool personelSifreDegistir(int PersonelID,string pass)
        {
            bool sonuc1 = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update PERSONELLER set PAROLA = @pass where ID=@perID",con);

            cmd.Parameters.Add("perID",SqlDbType.Int).Value= PersonelID;
            cmd.Parameters.Add("pass",SqlDbType.VarChar).Value= pass;

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc1 = Convert.ToBoolean(cmd.ExecuteNonQuery());

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


            return sonuc1;
        }

        public bool personelEkle(cPersoneller cp)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert into PERSONELLER(AD,SOYAD,KULLANICIADI,PAROLA,YETKIID) values(@AD,@SOYAD,@KULLANICIADI,@PAROLA,@YetkiId)",con);

            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("KULLANICIADI", SqlDbType.VarChar).Value = _PersonelKullaniciAdi;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("YetkiId",SqlDbType.Int).Value=_PersonelGorevId;

           
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

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

        public bool personelGuncelle(cPersoneller cp,int perId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update  PERSONELLER set AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA where ID=@perID", con);
            cmd.Parameters.Add("perID",SqlDbType.Int).Value=perId;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            

            sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

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

        public void personelSil(int perId)
        {
            

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete from PERSONELHAREKETLERI where PERSONELID=@perID", con);
            cmd.Parameters.AddWithValue("@perID",perId);
            

            
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


            
        }

        public void personelSil2(int perId)
        {


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete from PERSONELLER where ID=@perID", con);
            cmd.Parameters.AddWithValue("@perID", perId);



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



        }

        public void personelGetir(ListView lv)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select ID,AD,SOYAD from PERSONELLER",con);

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
