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

            string kisi1, kisi2, kisi3, kisi4, kisi5, kisi6, kisi7, kisi8;
            string konu1, konu2, konu3, konu4, konu5, konu6, konu7, konu8;

            kisi1 = db.TBLILETISIM.First(x => x.ID == 1).ADSOYAD.ToString();
            konu1 = db.TBLILETISIM.First(x => x.ID == 1).KONU.ToString();

            lbl10.Text = kisi1;
            lbl11.Text = konu1;

            kisi2 = db.TBLILETISIM.First(x => x.ID == 2).ADSOYAD.ToString();
            konu2 = db.TBLILETISIM.First(x => x.ID == 2).KONU.ToString();

            lbl20.Text = kisi2;
            lbl21.Text = konu2;

            kisi3 = db.TBLILETISIM.First(x => x.ID == 3).ADSOYAD.ToString();
            konu3 = db.TBLILETISIM.First(x => x.ID == 3).KONU.ToString();

            lbl30.Text = kisi3;
            lbl31.Text = konu3;

            kisi4 = db.TBLILETISIM.First(x => x.ID == 4).ADSOYAD.ToString();
            konu4 = db.TBLILETISIM.First(x => x.ID == 4).KONU.ToString();

            lbl40.Text = kisi4;
            lbl41.Text = konu4;

            kisi5 = db.TBLILETISIM.First(x => x.ID == 5).ADSOYAD.ToString();
            konu5 = db.TBLILETISIM.First(x => x.ID == 5).KONU.ToString();

            lbl50.Text = kisi5;
            lbl51.Text = konu5;

            kisi6 = db.TBLILETISIM.First(x => x.ID == 6).ADSOYAD.ToString();
            konu6 = db.TBLILETISIM.First(x => x.ID == 6).KONU.ToString();

            lbl60.Text = kisi6;
            lbl61.Text = konu6;

            kisi7 = db.TBLILETISIM.First(x => x.ID == 7).ADSOYAD.ToString();
            konu7 = db.TBLILETISIM.First(x => x.ID == 7).KONU.ToString();

            lbl70.Text = kisi7;
            lbl71.Text = konu7;

            kisi8 = db.TBLILETISIM.First(x => x.ID == 8).ADSOYAD.ToString();
            konu8 = db.TBLILETISIM.First(x => x.ID == 8).KONU.ToString();

            lbl80.Text = kisi8;
            lbl81.Text = konu8;





        }
    }
}
