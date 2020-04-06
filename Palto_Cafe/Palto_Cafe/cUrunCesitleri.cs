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
    class cUrunCesitleri
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Aciklama;
        #endregion

        #region Properties
        public int UrunTurNo { get => _UrunTurNo; set => _UrunTurNo = value; }
        public string KategoriAd { get => _KategoriAd; set => _KategoriAd = value; }
        public string Aciklama { get => _Aciklama; set => _Aciklama = value; }
        #endregion

        public void GetByProductTypes(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNAD,FIYAT,URUNLER.ID From KATEGORILER Inner Join URUNLER on KATEGORILER.ID=URUNLER.KATEGORIID where URUNLER.KATEGORIID=@KategoriId", con);

            string aa = btn.Name;
            int uzunluk = aa.Length;


            cmd.Parameters.Add("@KategoriId", SqlDbType.Int).Value = aa.Substring(uzunluk - 2, 2);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }

            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;

            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //uruncesitlerini getir combobox
        public void UrunCesitleriniGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from KATEGORILER where DURUM=0", con);
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

                    cUrunCesitleri uc = new cUrunCesitleri();

                    uc._UrunTurNo = Convert.ToInt32(dr["ID"]);
                    uc._KategoriAd = dr["KATEGORIADI"].ToString();
                    uc._Aciklama = dr["ACIKLAMA"].ToString();

                    cb.Items.Add(uc);


                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        //uruncesitlerini getir listview
        public void UrunCesitleriniGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from KATEGORILER where DURUM=0", con);
            SqlDataReader dr = null;



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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());


                    sayac++;

                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        //uruncesitlerini getir listview arama
        public void UrunCesitleriniGetir(ListView lv,string source)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from KATEGORILER where DURUM=0 and KATEGORIADI like '%'+ @source+ '%'", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("source",SqlDbType.VarChar).Value=source;

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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());


                    sayac++;

                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        //urun cesitleri ekleme
        public int UrunKategoriEkle(cUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into KATEGORILER(KATEGORIADI,ACIKLAMA) values (@katAdi,@aciklama)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@katAdi", SqlDbType.VarChar).Value = u._KategoriAd;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._Aciklama;
               

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

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

        //urun ceşitleri güncelle
        public int UrunKategoriGuncelle(cUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update KATEGORILER set KATEGORIADI=@katAdi,ACIKLAMA=@aciklama where ID=@katId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@katAdi", SqlDbType.VarChar).Value = u._KategoriAd;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._Aciklama;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._UrunTurNo;
               

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

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

        //urun cesitleri sil
        public int UrunKategoriSil(int id)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update KATEGORILER set DURUM = 1 where ID=@katId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = id;


                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

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

        public override string ToString()
        {
            return _KategoriAd;
        }

       

    }
}
