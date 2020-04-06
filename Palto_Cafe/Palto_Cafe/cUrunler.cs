using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Palto_Cafe
{
    class cUrunler
    {

        cGenel gnl = new cGenel();

        #region Fields
        private int _UrunId;
        private int _UrunTurNo;
        private string _UrunAd;
        private decimal _Fiyat;
        private string _Aciklama;
        #endregion

        #region Properties
        public int UrunId { get => _UrunId; set => _UrunId = value; }
        public int UrunTurNo { get => _UrunTurNo; set => _UrunTurNo = value; }
        public string UrunAd { get => _UrunAd; set => _UrunAd = value; }
        public decimal Fiyat { get => _Fiyat; set => _Fiyat = value; }
        public string Aciklama { get => _Aciklama; set => _Aciklama = value; }
        #endregion

        //ürünadina göre listeleme
        public void UrunleriListeleByUrunAdi(ListView lv, string urunadi)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from URUNLER Where DURUM=0 and URUNAD like '%' +@urunAdi+ '%'", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = urunadi;

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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));

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

        //urun ekle
        public int UrunEkle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into URUNLER(URUNAD,KATEGORIID,ACIKLAMA,FIYAT) values (@urunAd,@katId,@aciklama,@fiyat)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._UrunAd;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._UrunTurNo;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._Aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._Fiyat;

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

        //urunler ve kategorileri listele
        public void UrunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNLER.*,KATEGORIADI from URUNLER inner join KATEGORILER on KATEGORILER.ID=URUNLER.KATEGORIID Where URUNLER.DURUM=0", con);
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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

        //urunleri güncelle
        public int UrunGuncelle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update URUNLER set URUNAD=@urunAd,KATEGORIID=@katId,ACIKLAMA=@aciklama,FIYAT=@fiyat where ID=@urunId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._UrunAd;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._UrunTurNo;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._Aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._Fiyat;
                cmd.Parameters.Add("@urunId", SqlDbType.Int).Value = u._UrunId;

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

        //urunleri sil
        public int UrunSil(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update URUNLER set DURUM=1 where ID=@urunId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunId", SqlDbType.Int).Value = u._UrunId;

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

        //urunlerı IDye gore listeleme
        public void UrunleriListeleByUrunId(ListView lv, int urunid)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNLER.*,KATEGORIADI from URUNLER inner join KATEGORILER on KATEGORILER.ID=URUNLER.KATEGORIID Where URUNLER.DURUM=0 and URUNLER.KATEGORIID=@urunId", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunId", SqlDbType.Int).Value = urunid;

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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add("".ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    // lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));

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

        //iki tarih arası bütün ürünleri getiriyor 
        public void UrunleriListeleByIstatistiklereGore(ListView lv, DateTimePicker baslangic, DateTimePicker bitis)
        {

            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 10 dbo.URUNLER.URUNAD,sum(dbo.SATISLAR.ADET) as adeti FROM dbo.KATEGORILER Inner join dbo.URUNLER ON dbo.KATEGORILER.ID=dbo.URUNLER.KATEGORIID Inner join dbo.SATISLAR ON dbo.URUNLER.ID=dbo.SATISLAR.URUNID Inner join dbo.ADISYON ON dbo.SATISLAR.ADISYONID=dbo.ADISYON.ID where (CONVERT(datetime,TARIH,104) BETWEEN CONVERT datetime,'01.01.2013',104) AND CONVERT(datetime,'01.01.2025',104)) group by dbo.URUNLER.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@baslangic", SqlDbType.VarChar).Value = baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@bitis", SqlDbType.VarChar).Value = bitis.Value.ToShortDateString();

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

                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());


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

        //belirli kategoriye ait ürünleri listeliyor
        public void UrunleriListeleByIstatistiklereGoreUrunId(ListView lv, DateTimePicker baslangic, DateTimePicker bitis, int urunkatid)
        {

            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 10 dbo.URUNLER.URUNAD,sum(dbo.SATISLAR.ADET) as adeti FROM dbo.KATEGORILER Inner join dbo.URUNLER ON dbo.KATEGORILER.ID=dbo.URUNLER.KATEGORIID Inner join dbo.SATISLAR ON dbo.URUNLER.ID=dbo.SATISLAR.URUNID Inner join dbo.ADISYON ON dbo.SATISLAR.ADISYONID=dbo.ADISYON.ID where (CONVERT(datetime,TARIH,104) BETWEEN CONVERT datetime,'01.01.2013',104) AND CONVERT(datetime,'01.01.2025',104)) and (dbo.URUNLER.KATEGORIID=@katId) group by dbo.URUNLER.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@baslangic", SqlDbType.VarChar).Value = baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@bitis", SqlDbType.VarChar).Value = bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunkatid;

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

                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());


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


        public void UrunleriListeleByKategoriId(ListView lv, int katid)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from URUNLER Where DURUM=0 and KATEGORIID=@katId", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = katid;

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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add("".ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                   // lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));

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


    }

}


      