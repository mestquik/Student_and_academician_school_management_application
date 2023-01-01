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
    public partial class frmDersKayit : Form
    {
        public frmDersKayit()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities2 db = new OgrenciSinavEntities2();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtDersAd.Text.Length<=5 || txtDersAd.Text.Length >30  )
            {
                MessageBox.Show("Ders Adı hatalı girildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                TBLDERSLER ders = new TBLDERSLER();
                ders.DersAd = txtDersAd.Text;
                db.TBLDERSLER.Add(ders);
                db.SaveChanges();
                MessageBox.Show("Ders Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
