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
    public partial class FrmOgrenciPanel : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANAVAR;Initial Catalog=OgrenciSinav;Integrated Security=True");
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }
        public string numara;
        OgrenciSinavEntities2 db = new OgrenciSinavEntities2();
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            txtNumara.Text = numara;
            txtAd.Text = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrAd).FirstOrDefault();
            txtSoyad.Text = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrSoyad).FirstOrDefault();
            txtSifre.Text = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrAd).FirstOrDefault();
            txtMail.Text = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrMail).FirstOrDefault();
            txtResim.Text = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrResim).FirstOrDefault();
            txtDurum.Text = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrDurum).FirstOrDefault().ToString();
            if(txtDurum.Text == "false")
            {
                txtDurum.BackColor = Color.Red;
                txtDurum.ForeColor = Color.White;
                txtDurum.Text = "Pasif";
            }
            else
            {
                txtDurum.BackColor = Color.Green;
                txtDurum.ForeColor = Color.White;
                txtDurum.Text = "Aktif";
            }
            txtBolum.Text = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrBolum).FirstOrDefault().ToString();
            int idnumarasi = db.TBLOGRENCI.Where(x => x.OgrNumara == numara).Select(y => y.OgrID).FirstOrDefault();
            
            var sinavnotlari = (from x in db.TBLNOTLAR
                                select new
                                {
                                    x.TBLDERSLER.DersAd,
                                    x.Sinav1,
                                    x.Sinav2,
                                    x.Sinav3,
                                    x.Quiz1,
                                    x.Quiz2,
                                    x.Proje,
                                    x.Ortalama,
                                    x.Ogrenci
                                }).Where(x=> x.Ogrenci == idnumarasi).ToList();
            dataGridView1.DataSource = sinavnotlari;

            dataGridView1.Columns["Ogrenci"].Visible = false;



        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
        }
    }
}
