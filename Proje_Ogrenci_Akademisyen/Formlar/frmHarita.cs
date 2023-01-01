using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class frmHarita : Form
    {
        public frmHarita()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            frmOgrenci frm = new frmOgrenci();
            frm.Show();
           
        }

        private void DersListesiPanel_Click(object sender, EventArgs e)
        {
            frmDersListesi frm = new frmDersListesi();
            frm.Show();

        }

        private void NotlarFormuPanel_Click(object sender, EventArgs e)
        {
            frmNotlar frm = new frmNotlar();
            frm.Show();
        }

        private void OgrenciKayitPanel_Click(object sender, EventArgs e)
        {
            frmOgrenciKayit frm = new frmOgrenciKayit();
            frm.Show();
        }

        private void CikisPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YeniDersPanel_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void YeniDersPanel_Click(object sender, EventArgs e)
        {
            frmDersKayit frm = new frmDersKayit();
            frm.Show();
        }

        private void BolumListesiPanel_Click(object sender, EventArgs e)
        {
            frmBolumListesi frm = new frmBolumListesi();
            frm.Show();
        }

        private void YeniBolumPanel_Click(object sender, EventArgs e)
        {
            FrmBolumler frm = new FrmBolumler();
            frm.Show();
        }
    }
}
