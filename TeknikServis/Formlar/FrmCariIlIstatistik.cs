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
    public partial class FrmCariIlIstatistik : Form
    {
        public FrmCariIlIstatistik()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        SqlConnection baglanti = new SqlConnection(@"Data Source = 7E7LENOVO\TETLENOVO; Initial Catalog = DBTEKNIKSERVIS; Integrated Security = True");
        //Charta veri eklemek icin sql bağlantısı yapıoruz
        void ChartVeriEkleme()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT IL, COUNT(*) FROM TBLCARI GROUP BY IL", baglanti);//Cari tablosunu ıle gore grupluyoruz ve sayılarını alıyoruz
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
                //Sonra il adını ve cari sayısını charta eklioruz
            }
            baglanti.Close();
        }
        void formLoad()
        {
            var deger = db.TBLCARI.GroupBy(x => x.IL).Select(y =>
              new
              {
                  İl = y.Key,
                  Cari = y.Count()
              }).OrderByDescending(z => z.Cari); // İllerdeki Cari sayılarını getirir (tablo)
            gridControl1.DataSource = deger.ToList();

            if(Formlar.FrmCariListesi.CariListesiDegisiklikSayac > 0)//Carilistesiformudna değşiklik yapılıysa
            {
                chartControl1.Series["Series 1"].Points.Clear();//Chart temizle

                ChartVeriEkleme();//Yeni verileri charta ekle

                Formlar.FrmCariListesi.CariListesiDegisiklikSayac = 0; //Tekrar kullanabilmek icin sayacı 0'la
            }
        }
        private void FrmCariIlIstatistik_Load(object sender, EventArgs e)
        {
            // formLoad(); //Fprm activated ekoyduğumuz icin buray akoymamıza gere yok yoksa 2 kere donduruyor form loadı
            ChartVeriEkleme();
            //Başta veri gostermek icin charat veri ekliyoruz
            //Form activated akoyamıoruz cunku her aktive dildiğinde aynı verileri tekrar tekrar ekliyor charta
        }

        private void FrmCariIlIstatistik_Activated(object sender, EventArgs e)
        {
            formLoad();//Active edildiğinde gerekli listelemeyi yapıyor ve carilistesinde değşiklik charta yapıldıysa ekleme yapıyor
        }
    }
}
