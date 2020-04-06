using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Palto_Cafe
{
    class cOdeme
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _OdemeId;
        private int _AdisyonId;
        private int _OdemeTurId;
        private decimal _AraToplam;
        private decimal _Indirim;
        private decimal _KdvTutari;
        private decimal _GenelToplam;
        private DateTime _Tarih;
        private int _MusteriId;
        private int _Gunluk;
        private int _Aylik;
        #endregion

        #region Properties
        public int OdemeId { get => _OdemeId; set => _OdemeId = value; }
        public int AdisyonId { get => _AdisyonId; set => _AdisyonId = value; }
        public int OdemeTurId { get => _OdemeTurId; set => _OdemeTurId = value; }
        public decimal AraToplam { get => _AraToplam; set => _AraToplam = value; }
        public decimal Indirim { get => _Indirim; set => _Indirim = value; }
        public decimal KdvTutari { get => _KdvTutari; set => _KdvTutari = value; }
        public decimal GenelToplam { get => _GenelToplam; set => _GenelToplam = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int MusteriId { get => _MusteriId; set => _MusteriId = value; }
        public int Gunluk { get => _Gunluk; set => _Gunluk = value; }
        public int Aylik { get => _Aylik; set => _Aylik = value; }
        #endregion

        //müşteri masa hesabı kapatma 
        public bool billClose(cOdeme bill)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into HESAPODEMELERI(ADISYONID,ODEMETURID,MUSTERIID,ARATOPLAM,KDVTUTARI,INDIRIM,TOPLAMTUTAR) values (@AdisyonId,@OdemeTurId,@MusteriId,@AraToplam,@KdvTutari,@Indirim,@ToplamTutar)",con);


            try
            {

                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("AdisyonId",SqlDbType.Int).Value=bill._AdisyonId;
                cmd.Parameters.Add("OdemeTurId",SqlDbType.Int).Value=bill._OdemeTurId;
                cmd.Parameters.Add("MusteriId",SqlDbType.Int).Value=bill._MusteriId;
                cmd.Parameters.Add("AraToplam",SqlDbType.Money).Value=bill._AraToplam;
                cmd.Parameters.Add("KdvTutari",SqlDbType.Money).Value=bill._KdvTutari;
                cmd.Parameters.Add("Indirim",SqlDbType.Money).Value=bill._Indirim;
                cmd.Parameters.Add("ToplamTutar",SqlDbType.Money).Value=bill._GenelToplam;
               // cmd.Parameters.Add("Gunluk", SqlDbType.Int).Value = bill._Gunluk;
               // cmd.Parameters.Add("Aylik", SqlDbType.Int).Value = bill._Aylik;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                

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


            return result;

        }

        public bool hesaptandus(cOdeme bill)
        {

            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into HESAPODEMELERI(ADISYONID,ODEMETURID,MUSTERIID,ARATOPLAM) values (@AdisyonId,@OdemeTurId,@MusteriId,@AraToplam)", con);


            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("AdisyonId", SqlDbType.Int).Value = bill._AdisyonId;
                cmd.Parameters.Add("OdemeTurId", SqlDbType.Int).Value = bill._OdemeTurId;
                cmd.Parameters.Add("MusteriId", SqlDbType.Int).Value = bill._MusteriId;
                cmd.Parameters.Add("AraToplam", SqlDbType.Money).Value = bill._AraToplam;
               // cmd.Parameters.Add("KdvTutari", SqlDbType.Money).Value = bill._KdvTutari;
               // cmd.Parameters.Add("Indirim", SqlDbType.Money).Value = bill._Indirim;
               // cmd.Parameters.Add("AraToplam", SqlDbType.Money).Value = bill._GenelToplam;
                // cmd.Parameters.Add("Gunluk", SqlDbType.Int).Value = bill._Gunluk;
                // cmd.Parameters.Add("Aylik", SqlDbType.Int).Value = bill._Aylik;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());


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


            return result;

        }

        //müşteri toplam harcaması yazma
        public decimal sumTotalForClientId(int clientId)
        {

            decimal total = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(TOPLAMTUTAR) as total from HESAPODEMELERI Where MUSTERIID=@ClientId",con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();

                }
                cmd.Parameters.Add("ClientId", SqlDbType.Int).Value = clientId;
                total = Convert.ToDecimal(cmd.ExecuteScalar());

            }
            catch (SqlException ex )
            {
                string hata = ex.Message;
                throw;
            }

            finally
            {
                con.Dispose();
                con.Close();

            }


            return total;
        }


    }
}
