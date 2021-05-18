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
    public partial class FrmUrunIstatistik : Form
    {
        public FrmUrunIstatistik()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        void formLoad()
        {
            labelControl2.Text = db.TBLURUN.Count().ToString(); //Toplam urun sayısı

            labelControl3.Text = db.TBLKATEGORI.Count().ToString(); //Toplam kategori sayısı

            labelControl5.Text = db.TBLURUN.Sum(x => x.STOK).ToString();//Toplam Stok sayısı

            labelControl15.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();// En cok stoklu urun adı

            labelControl33.Text = (from x in db.TBLURUN
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault(); // En az stoklu urunğ adı

            labelControl13.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();//SatışFiyatı En cok olan urunun adı

            labelControl11.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault(); //SatışFiyatı En az olan urunun adı

            labelControl33.Text = db.TBLURUN.Count(x => x.KATEGORI == 4).ToString(); // Kategori numarası 4 olan urunlerin sayısı
            labelControl31.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString(); // Kategori numarası 1 olan urunlerin sayısı
            labelControl29.Text = db.TBLURUN.Count(x => x.KATEGORI == 3).ToString(); // Kategori numarası 3 olan urunlerin sayısı

            labelControl19.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();//Toplam Marka Sayısı


            var deger = db.TBLURUN.Where(x => x.AD == "BUZDOLABI").Average(y => y.SATISFIYAT); //Adı BUZDOLABI olan urunlerin SATIŞFIYAT 'ların ortalaması

            Decimal decDeger = Decimal.Round((decimal)deger, 2); //DECİMAL DEGERI VİRGULDEN SONRA 2 BASAMAKLI YAPMAK ıcın (buzdolabının ortalamsı decimal oalrak geldi o yuzden)
            //labelControl49.Text = decDeger.ToString();

            labelControl41.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).First(); //Stok sayısı en fazla olan urunun adı

            //labelControl41.Text = db.TBLURUNKABUL.Count().ToString();
            var degerler = (from x in db.TBLURUN
                     join y in db.TBLKATEGORI
                     on x.KATEGORI equals y.ID
                     select new
                     {
                         y.AD,
                         ururAd = x.AD
                        
                     }).OrderBy(y=>y.AD).GroupBy(u=>u.AD);
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmIstatistik_Activated(object sender, EventArgs e)
        {
            formLoad();//Form her active edildiğinde başta gelcek verileri yeniden yukle ki değşiklik yapıldıysa yeni veriler gelsin
        }
    }
}
    
