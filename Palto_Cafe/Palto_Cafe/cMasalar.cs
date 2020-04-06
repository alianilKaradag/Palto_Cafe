using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Palto_Cafe
{
    class cMasalar
    {

        #region Fields
        private int _ID;
        private int _KAPASITE;
        private int _SERVISTURU;
        private int _DURUM;
        private int _ONAY;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int KAPASITE { get => _KAPASITE; set => _KAPASITE = value; }
        public int SERVISTURU { get => _SERVISTURU; set => _SERVISTURU = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int ONAY { get => _ONAY; set => _ONAY = value; }
        #endregion


        cGenel gnl = new cGenel();
        public string SessionSum(int state, string MasaId)
        {


            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH,MASAID From ADISYON Right Join MASALAR on ADISYON.MASAID=MASALAR.ID Where MASALAR.DURUM=@Durum and ADISYON.DURUM=0 and MASALAR.ID=@MasaId",con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Convert.ToInt32(MasaId);

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

                throw;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;
        }

        public int TableGetByNumber(string TableValue)
        {
            string aa = TableValue;
            return Convert.ToInt32(aa);

        }
    
        public bool TableGetByState(int ButtonName,int State)
        {

            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM from MASALAR Where ID=@TableId and DURUM=@State",con);

            cmd.Parameters.Add("@TableId",SqlDbType.Int).Value=ButtonName;
            cmd.Parameters.Add("@State", SqlDbType.Int).Value =State;

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());


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

        public void SetChangeTableState(string ButonName,int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update MASALAR Set DURUM=@Durum where ID=@MasaNo",con);
            string masaNo = "";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string aa = ButonName;
            int uzunluk = aa.Length;

            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = aa;
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();


        }

        public void MasalariDurumaGoreGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from MASALAR where DURUM=1", con);
            
            
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
                cb.Items.Add(dr[0]);

            }

            dr.Close();
            con.Close();

        }

        public void MasaDurumuDegistir(int durum)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update MASALAR set DURUM=1 where ID=@id",con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.AddWithValue("@id",durum);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex )
            {

                string hata = ex.Message;
            }

            finally
            {
                con.Dispose();
                con.Close();
            }

        }
    
    }
}
