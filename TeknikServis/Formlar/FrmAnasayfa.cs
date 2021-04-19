using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmAnasayfa_Activated(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x => x.STOK < 30).ToList();
            gridControl2.DataSource = (from x in db.TBLCARI
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.IL
                                       }).ToList();
            gridControl3.DataSource = (from x in db.TBLURUN
                                       join y in db.TBLKATEGORI
                                       on x.KATEGORI equals y.ID
                                       select new
                                       {
                                           Kategori = y.AD,
                                           Urun = x.AD,
                                           Marka = x.MARKA
                                       }).ToList();
            DateTime today = DateTime.Today;
            gridControl4.DataSource = db.TBLNOTLARIM.OrderBy(x => x.ID).Where(y => y.TARIH == today).Select(z => new
            {
                z.BASLIK,
                z.ICERIK
            }).ToList();

        }
    }
}
