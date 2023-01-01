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
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class frmOgrenci : Form
    {
        public frmOgrenci()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities2 db = new OgrenciSinavEntities2();
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtResim.Text = openFileDialog1.FileName;
        }
        SqlConnection baglanti = new SqlConnection("Data Source=CANAVAR;Initial Catalog=OgrenciSinav;Integrated Security=True");
        void DeaktifListele()
        {
            var degerler = from x in db.TBLOGRENCI
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrResim,
                               x.OgrMail,
                               x.OgrBolum,
                               x.TBLBOLUM.BolumAd,
                               x.OgrDurum
                           };

            dataGridView1.DataSource = degerler.Where(x => x.OgrDurum == false).ToList();
        }
        void AktifListele()
        {


            var degerler = from x in db.TBLOGRENCI
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrResim,
                               x.OgrMail,
                               x.OgrBolum,
                               x.TBLBOLUM.BolumAd,
                               x.OgrDurum
                           };

            dataGridView1.DataSource = degerler.Where(x => x.OgrDurum == true).ToList();
        }



        void Listelee()
        {
            var degerler = from x in db.TBLOGRENCI
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrResim,
                               x.OgrMail,
                               x.OgrBolum,
                               x.TBLBOLUM.BolumAd,
                               x.OgrDurum
                           };

            dataGridView1.DataSource = degerler.ToList();
       
    
        }

        private void frmOgrenci_Load(object sender, EventArgs e)
        {
            Listelee();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from TBLBOLUM", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmbBolumAd.ValueMember = "BolumID";
            cmbBolumAd.DisplayMember = "BolumAd";
            cmbBolumAd.DataSource = ds;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AktifListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();        
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtResim.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbBolumAd.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void txtDurum_TextChanged(object sender, EventArgs e)
        {
            if(txtDurum.Text == "True")
            {
                
                txtDurum.Text = "Aktif Durumda";
                txtDurum.BackColor = Color.Green;
                txtDurum.ForeColor = Color.White;
            }
            else if(txtDurum.Text == "False")
            {
                txtDurum.Text = "Aktif Değil";
                txtDurum.BackColor = Color.Red;
                txtDurum.ForeColor = Color.White;
            }
            
            
        }

        private void rdbAktif_CheckedChanged(object sender, EventArgs e)
        {
            AktifListele();
        }

        private void rdbDeaktif_CheckedChanged(object sender, EventArgs e)
        {
            DeaktifListele();
        }

        private void rdbTumOgrenciler_CheckedChanged(object sender, EventArgs e)
        {
            Listelee();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.TBLOGRENCI.Find(id);
            x.OgrDurum = false;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Başarılı şekilde silindi, Silinen öğrencilere 'Pasif Öğrenciler' kısmından erişebilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listelee();
        }

        private void dataGridView1_BackgroundColorChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.TBLOGRENCI.Find(id);
            x.OgrAd = txtAd.Text;
            x.OgrSoyad = txtSoyad.Text;
            x.OgrNumara = txtNumara.Text;
            x.OgrSifre = txtSifre.Text;
            x.OgrMail = txtMail.Text;
            x.OgrResim = txtResim.Text;
            x.OgrBolum = int.Parse(cmbBolumAd.SelectedValue.ToString());

            db.SaveChanges();
            MessageBox.Show("Öğrenci Başarılı bir şekilde güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listelee();
        }
    }
}
