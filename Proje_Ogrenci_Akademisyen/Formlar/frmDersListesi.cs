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
    public partial class frmDersListesi : Form
    {
        public frmDersListesi()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities2 db = new OgrenciSinavEntities2();
        private void frmDersListesi_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TBLDERSLER
                            select new
                            {
                                x.DersID,
                                x.DersAd
                            }).ToList();

            dataGridView1.DataSource = degerler;
        }

    }

}
