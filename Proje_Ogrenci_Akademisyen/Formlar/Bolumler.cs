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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities2 db = new OgrenciSinavEntities2();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtBolumAd.Text=="" || txtBolumAd.Text.Length>=30 || txtBolumAd.Text.Length<=4)
            {
                errorProvider1.SetError(txtBolumAd, "Bölüm adı boş geçilemez!");
            }
            else
            {
                TBLBOLUM t = new TBLBOLUM();
                t.BolumAd = txtBolumAd.Text;
                db.TBLBOLUM.Add(t);
                db.SaveChanges();
                MessageBox.Show("Bölüm Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmBolumler_Load(object sender, EventArgs e)
        {

        }
    }
}
