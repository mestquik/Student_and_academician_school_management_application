using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=CANAVAR;Initial Catalog=OgrenciSinav;Integrated Security=True");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from TBLOGRENCI where OgrNumara=@p1 and OgrSifre=@p2",baglanti);
            komut1.Parameters.AddWithValue("@p1", txtNumara.Text);
            komut1.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut1.ExecuteReader();

            if(dr.Read())
            {
                FrmOgrenciPanel frm = new FrmOgrenciPanel();
                frm.numara = txtNumara.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Numara veya şifre hatalıdır! \n Lütfen tekrar deneyiniz.", "Hatalı giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();

        }

        private void txtNumara_TextChanged(object sender, EventArgs e)
        {
            if(txtNumara.Text == "00000" && txtSifre.Text == "000")
            {
                frmHarita frm = new frmHarita();
                frm.Show();
                
            }
            

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            if (txtSifre.Text == "000" && txtNumara.Text == "00000")
            {
                frmHarita frm = new frmHarita();
                frm.Show();
                
            }
        }
    }
}
