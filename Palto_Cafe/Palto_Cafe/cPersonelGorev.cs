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
    class cPersonelGorev
    {

        cGenel gnl = new cGenel();

        private int _personelGorevId;
        private string _tanim;

        public int PersonelGorevId { get => _personelGorevId; set => _personelGorevId = value; }
        public string Tanim { get => _tanim; set => _tanim = value; }

        public void PersonelGorevGetir(ComboBox cb)
        {

            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@Id and Parola=@Password", con);
            

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
                throw;
            }



        }
    }
}
