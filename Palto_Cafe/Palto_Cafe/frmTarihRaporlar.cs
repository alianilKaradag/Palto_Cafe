using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Palto_Cafe
{
    public partial class frmTarihRaporlar : Form
    {
        public frmTarihRaporlar()
        {
            InitializeComponent();
        }

        private void frmTarihRaporlar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            cTarihRaporlar ct = new cTarihRaporlar();
            ct.TarihRaporlar(listView1,dateTimePicker1,dateTimePicker2);
            ct.toplamTarihRaporlar(label2, dateTimePicker1, dateTimePicker2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
