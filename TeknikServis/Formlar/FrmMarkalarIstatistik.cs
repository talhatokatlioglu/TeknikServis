using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalarIstatistik : Form
    {
        public FrmMarkalarIstatistik()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=7E7LENOVO\TETLENOVO;Initial Catalog=DBTEKNIKSERVIS;Integrated Security=True");

        void EnPahalıUrunMarka()
        {
            labelControl7.Text = (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault(); //En Pahalı Urune Sahip Marka Adi
        }
        void EnPahalıUrunFiyat()
        {
            var fiyat = (from x in db.TBLURUN
                         orderby x.SATISFIYAT descending
                         select x.SATISFIYAT).FirstOrDefault(); //En Pahalı Urun Fiyatı

            Decimal decFiyat = (decimal)fiyat;

            labelControl7.Text = decFiyat.ToString();
        }

        void EnCokUrunuOlanMarkaAdi()
        {
            labelControl5.Text = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            }).OrderByDescending(t => t.Toplam).Select(s => s.Marka).First(); // En Cok Urunu Olan Marka Adi
        }

        void EnCokUrunuOlanMarkaUrunSayisi()
        {
            var deger = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            }).OrderByDescending(t => t.Toplam).Select(s => s.Toplam).First(); // En Cok Urunu Olan Markanin Urun Sayisi

            Decimal fiyat = (decimal)deger;

            labelControl5.Text = fiyat.ToString();
        }

        void ChartVeriEkleme()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA, COUNT(*) FROM TBLURUN GROUP BY MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

        public void formLoad()//Urun Ekledğimde bilgiler değişmiyordu o yuzden form loadın fonksiyonunu yaptım form aktive olunca da bu fonk cagırdım
        {
            labelControl2.Text = db.TBLURUN.Count().ToString(); // Toplam Urun Sayısı

            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).
                Select(z => new
                {
                    Marka = z.Key,
                    UrunSayisi = z.Count()
                }).OrderByDescending(z => z.UrunSayisi); //Hangi Markada Kaç Urun Var
            gridControl1.DataSource = degerler.ToList();

            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString(); //Toplam Marka Sayısı

            EnCokUrunuOlanMarkaAdi();

            EnPahalıUrunMarka();


            if (Formlar.FrmUrunListesi.UrunListesiDegisiklikSayac > 0) //UrunListesidne değiişklik yapıldığında sayac artıyor.Arttıysa...
            {
                chartControl1.Series["Series 1"].Points.Clear();//Once Chartı temilizyorum

                ChartVeriEkleme();//Sonra yenilenmiş verileri tekrar ekliyorun

                Formlar.FrmUrunListesi.UrunListesiDegisiklikSayac = 0; //Tekrar kullanabilmek icin sayacı 0' lıyorum
            }

        }

        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            ChartVeriEkleme(); 
            //Başta charta veri ekliyorum ki boş durmasın
            //Eğer bunu form activateda koysam sayfa her aktive dildiğinde charta aynı verileri ekliyor
        }

        private void FrmMarkalar_Activated(object sender, EventArgs e)
        {
            formLoad(); 
            //Form active dildiğinde load olunca gelecek veriler ve ürünlerde değişiklik yapıldıysa chart temizlenip yeni veriler ekleniyor
        }

        int lbl7TiklamaSayac = 0; //En pahalı Markayı gosteriyorum ustune tıklayıncada fiyatını gosterrecek kac kere tıkladığını anlamak icin sayac
        private void labelControl7_Click(object sender, EventArgs e)
        {
            lbl7TiklamaSayac++;
            if(lbl7TiklamaSayac % 2 != 0)//Tıklama sayısı tek sayıysa urunun fiyatını goster
            {
                EnPahalıUrunFiyat();
            }
            else
            {
                EnPahalıUrunMarka();//Tıklama sayısı cift sayıysa urun adını goster
            }
            
        }

        int lbl5TiklamaSayac = 0;
        private void labelControl5_Click(object sender, EventArgs e)
        {
            lbl5TiklamaSayac++;
            if (lbl5TiklamaSayac % 2 != 0)
            {
                EnCokUrunuOlanMarkaUrunSayisi();
            }
            else
            {
                EnCokUrunuOlanMarkaAdi();
            }
        }
    }
}
