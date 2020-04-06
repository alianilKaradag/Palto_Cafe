using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Palto_Cafe
{
    class cIstatistik
    {

        cGenel gnl = new cGenel();

        #region Fields
        private decimal _nakit;
        private decimal _kart;
        private int _gunluk;
        private int _aylik;
        private DateTime _tarih;
        private int _odemeTurId;
        private decimal _toplam;
        #endregion

        #region Properties
        public decimal Nakit { get => _nakit; set => _nakit = value; }
        public decimal Kart { get => _kart; set => _kart = value; }
        public int Gunluk { get => _gunluk; set => _gunluk = value; }
        public int Aylik { get => _aylik; set => _aylik = value; }
        public DateTime Tarih { get => _tarih; set => _tarih = value; }
        public int OdemeTurId { get => _odemeTurId; set => _odemeTurId = value; }
        public decimal Toplam { get => _toplam; set => _toplam = value; }
        #endregion

        public bool IstatistikTut(cIstatistik istatistik)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into ISTATISTIK (NAKIT,KART,GUNLUK,AYLIK,TARIH,ODEMETURID) values (@nakit,@kart,@gunluk,@aylik,@tarih,@odemeTur) ",con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@nakit",SqlDbType.Money).Value=istatistik._nakit;
                cmd.Parameters.Add("@kart", SqlDbType.Money).Value = istatistik._kart;
                cmd.Parameters.Add("@gunluk", SqlDbType.Int).Value = istatistik._gunluk;
                cmd.Parameters.Add("@aylik", SqlDbType.Int).Value = istatistik._aylik;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = istatistik._tarih;
                cmd.Parameters.Add("@odemeTur", SqlDbType.Money).Value = istatistik._odemeTurId;

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
    }
}
