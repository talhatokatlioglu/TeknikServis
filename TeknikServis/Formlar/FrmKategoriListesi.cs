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
    public partial class FrmKategoriListesi : Form
    {
        public FrmKategoriListesi()
        {
            InitializeComponent();
        }

        public static Timer PubKategoriListesiTimer;

        void kategoriListele()
        {
            var degerler = from kategoriBilgileri in db.TBLKATEGORI
                           select new
                           {
                               ID = kategoriBilgileri.ID,
                               AD = kategoriBilgileri.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static int KategoriDegisiklikSayac = 0;
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            gridControl1.Visible = true; // Kategorilerin lstelendiği grid gorunur olucak
            gridControl2.Visible = false; //Markalara tıklandığında markalra ait urunleri getiren grid gorunmez olucak
            kategoriListele(); //Sayfa acılınca kategori listelencek

            PubKategoriListesiTimer = KategoriTimer;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtKategoriAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLKATEGORI k = new TBLKATEGORI();

            k.AD = TxtKategoriAd.Text;
            db.TBLKATEGORI.Add(k);
            db.SaveChanges();

            MessageBox.Show("Kategori başarıyla kaydedilmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PubKategoriListesiTimer.Enabled = true; //Değişiklik yapıldığıdna timerı acıorm
            KategoriDegisiklikSayac++; //Yapılan Değişikliği anlamak icin urunler formunda lookupedite veri ekliyorm
        }
        /*
        void GeriDonusumKutusuListele()
        {
            var degerler = from kategoriBilgileri in db.TBLKATEGORI
                           select new
                           {
                               AD = kategoriBilgileri.AD
                           };
        }
        */
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLKATEGORI.Find(id);

            db.TBLKATEGORI.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Kategori başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            PubKategoriListesiTimer.Enabled = true;
            KategoriDegisiklikSayac++;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLKATEGORI.Find(id);

            deger.AD = TxtKategoriAd.Text;

            db.SaveChanges();

            MessageBox.Show("Kategori başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            PubKategoriListesiTimer.Enabled = true;
            KategoriDegisiklikSayac++;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.Visible = true;
            gridControl2.Visible = false;
        }

        void SeciliMarkaBulUrunListele(string marka)
        {
            var deger = (from x in db.TBLURUN
                         join y in db.TBLKATEGORI
                         on x.KATEGORI equals y.ID
                         select new
                         {
                             Urun = x.AD,
                             Kategori = y.AD,
                             Marka = x.MARKA,
                             Fiyat = x.SATISFIYAT,
                             Stok = x.STOK
                         }).Where(z => z.Marka == marka);//Gelen pictureBoxın adını veri tabanında arar
                                                         //pictureBoxşarın adını markaların veri tabanındaki adıyla aynı yaptım ki o isismle arasın diye
            gridControl2.DataSource = deger.ToList();
        }
        void SeciliMarkaBul()
        {
            if (marka == "XIAOMI") //Marka eğer pictureBox un adındaysa
            {
                SeciliMarkaBulUrunListele(marka);// Metoda markayı gonder MARKANIN ADINA AIT KAYITLARI GETIRSIN
            }
            else if (marka == "APPLE")
            {
                SeciliMarkaBulUrunListele(marka);
            }
            else if (marka == "SAMSUNG")
            {
                SeciliMarkaBulUrunListele(marka);
            }
            else if (marka == "MONSTER")
            {
                SeciliMarkaBulUrunListele(marka);
            }
            else if (marka == "LENOVO")
            {
                SeciliMarkaBulUrunListele(marka);
            }
            else if (marka == "SIEMENS")
            {
                SeciliMarkaBulUrunListele(marka);
            }
            else if (marka == "LG")
            {
                SeciliMarkaBulUrunListele(marka);
            }
            else
            {
                SeciliMarkaBulUrunListele(marka);
            }
        }

        static string pictureBoxName; //Pictureboxa tıklayınca adını alıyorum aşşağıda sender ile bu adı tıtması icin bu değişkeni tanımladım
        
        private void ARCELIK_DoubleClick(object sender, EventArgs e) 
            // Ketgori sayfasında gorunen 8 markadan birine çift tıklanırsa olayı
            // 8 pictureBox ıda secip onlara double click olayı dedim
        {
            gridControl1.Visible = false;
            gridControl2.Visible = true;

            PictureBox pb = (PictureBox)sender; // PictureBox Nesnesi oluşturdum
            pictureBoxName = pb.Name; // nesnenin adını markaya atadım
            marka = pictureBoxName;//Aşşağıdaki secilimarkabul metodunda kullanılması icin pictureboxun adını markaya atadım

            SeciliMarkaBul();

            PubKategoriListesiTimer.Enabled = true;
        }


        string marka = pictureBoxName; 
        //burda da pictureBoxın adı artık pb.name onuda markaya atadım kategori activatedda kullanabilmek icin
        //Cunku diğer marka değişkeni click eventinin icinde ve onu activated eventinde kullanamıyoruz o yuzden picturebpxun adına yeni bri marka değişkenine atadım

        private void FrmKategori_Activated(object sender, EventArgs e)
        {
            PubKategoriListesiTimer.Enabled = true;// sayfa aktive edilsdiuse timerı calıştır
            if(KategoriTimer.Enabled == true)//Timer calısıosa
            {
                SeciliMarkaBul(); //Secili markayı bul ve yeni verileriyle listele diyoruz
                PubKategoriListesiTimer.Enabled = false;//Tekrar kullanabilmek icin timerı kapatıyoruz
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtKategoriAd.Text = "";
        }

        private void KategoriTimer_Tick(object sender, EventArgs e)
        {
            kategoriListele();//Değişiklik yapıldığında from loadda tapılacak şeyleri tekrar yap yapılan değişikliği anında kaydetmek icin

            if (Formlar.FrmYeniKategori.YeniKategoriDegisiklikSayac > 0)
            {
                kategoriListele();
            }

            PubKategoriListesiTimer.Enabled = false;//Tekrar kullanabilmek icin timerı kapatıyoruz
        }
    }
}
