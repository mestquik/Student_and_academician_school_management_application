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
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class frmOgrenciKayit : Form
    {
        public frmOgrenciKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=CANAVAR;Initial Catalog=OgrenciSinav;Integrated Security=True");
        OgrenciSinavEntities2 db = new OgrenciSinavEntities2();
        private void frmOgrenciKayit_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from TBLBOLUM", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmbBolumAd.ValueMember = "BolumID";
            cmbBolumAd.DisplayMember = "BolumAd";
            cmbBolumAd.DataSource = ds;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //textBox1.Text = comboBox1.SelectedValue.ToString();

            TBLOGRENCI t = new TBLOGRENCI();
           
            if(txtSifree.Text!= txtSifreTekrarr.Text || txtAd.Text.Length>=30 || txtSoyad.Text.Length<=2 || txtSifree.Text.Length>=10 )
            {
                MessageBox.Show("Kaydedilemedi!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                t.OgrAd = txtAd.Text;
                t.OgrSoyad = txtSoyad.Text;
                t.OgrNumara = maskedTextBox1.Text;
                t.OgrSifre = txtSifree.Text;
                t.OgrResim = txtResim.Text;
                t.OgrMail = txtMail.Text;
                t.OgrBolum = int.Parse(cmbBolumAd.SelectedValue.ToString());
                db.TBLOGRENCI.Add(t);
                db.SaveChanges();

                MessageBox.Show("Öğrenci Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
            


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtResim.Text = openFileDialog1.FileName;
            
        }
    }
}
