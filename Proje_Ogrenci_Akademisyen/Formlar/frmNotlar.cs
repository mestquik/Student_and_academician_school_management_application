using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        OgrenciSinavEntities2 db = new OgrenciSinavEntities2();
        void listele()
        {
            dataGridView1.DataSource = db.Notlar2();
        }
        private void frmNotlar_Load(object sender, EventArgs e)
        {
            comboboxDers.ValueMember = "DersID";
            comboboxDers.DisplayMember = "DersAd";
            comboboxDers.DataSource = db.TBLDERSLER.ToList();
            comboBox1.ValueMember = "DersID";
            comboBox1.DisplayMember = "DersAd";
            comboBox1.DataSource = db.TBLDERSLER.ToList();
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLNOTLAR t = new TBLNOTLAR();
            t.Sinav1 = byte.Parse(txtSinav1.Text);
            t.Sinav2 = byte.Parse(txtSinav2.Text);
            t.Sinav3 = byte.Parse(txtSinav3.Text);
            t.Proje = byte.Parse(txtProje.Text);
            t.Quiz1 = byte.Parse(txtQuiz1.Text);
            t.Quiz2 = byte.Parse(txtQuiz2.Text);
            t.Ogrenci = int.Parse(txtOgrenci.Text.ToString());
            t.Ders = int.Parse(comboboxDers.SelectedValue.ToString());
            db.TBLNOTLAR.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Not Bilgisi Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            byte s1, s2, s3, q1, q2, proje;
            double ortalama;

            s1 = byte.Parse(txtSinav1.Text);
            s2 = byte.Parse(txtSinav2.Text);
            s3 = byte.Parse(txtSinav3.Text);
            q1 = byte.Parse(txtQuiz1.Text);
            q2 = byte.Parse(txtQuiz2.Text);
            proje = byte.Parse(txtProje.Text);
            ortalama = (s1 + s2 + s3 + q1 + q2 + proje) / 6;
            txtOrtalama.Text = ortalama.ToString();
        }
        
        private void btnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.View_1.ToList();
            dataGridView1.DataSource = db.Notlar2();

            
        }

        private void comboboxDers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLNOTLAR
                           select new
                           {
                               x.NotID,
                               x.TBLDERSLER.DersAd,
                               Ogrenci_Ad = x.TBLOGRENCI.OgrAd + x.TBLOGRENCI.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ders

                           };
            int d = int.Parse(comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = degerler.Where(y => y.Ders == d).ToList();
            dataGridView1.Columns["Ders"].Visible = false;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLNOTLAR
                           select new
                           {
                               x.NotID,
                               x.TBLDERSLER.DersAd,
                               Ogrenci_Ad = x.TBLOGRENCI.OgrAd + x.TBLOGRENCI.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ogrenci

                           };
            int id = int.Parse(comboBox1.Text);
            dataGridView1.DataSource = degerler.Where(y => y.Ogrenci == id).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }

        private void btnAra2_Click(object sender, EventArgs e)
        {
            string ogrenci_no = maskedTextBox1.Text;
            var deger = db.TBLOGRENCI.Where(x => x.OgrNumara ==ogrenci_no).Select(y => y.OgrID).FirstOrDefault();
           

            var degerler = from x in db.TBLNOTLAR
                           select new
                           {
                               x.NotID,                       
                               Ogrenci_Ad = x.TBLOGRENCI.OgrAd + x.TBLOGRENCI.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ogrenci,
                               x.Ortalama,
                               x.TBLDERSLER.DersAd

                           };
            
            dataGridView1.DataSource = degerler.Where(z => z.Ogrenci == deger).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboboxDers.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrenci.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtQuiz1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtQuiz2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            






        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.TBLNOTLAR.Find(id);

            x.Sinav1 = int.Parse(txtSinav1.Text);
            x.Sinav2 = int.Parse(txtSinav2.Text);
            x.Sinav3 = int.Parse(txtSinav3.Text);
            x.Quiz1 = int.Parse(txtQuiz1.Text);
            x.Quiz2 = int.Parse(txtQuiz2.Text);
            x.Proje = int.Parse(txtProje.Text);
            x.Ortalama = decimal.Parse(txtOrtalama.Text);
            db.ortalama();
            db.SaveChanges();
            MessageBox.Show("Öğrenci notu başarıyla güncellendi","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            listele();
        }   
    }
}
