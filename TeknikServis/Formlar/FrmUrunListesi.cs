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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        
         DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static int UrunListesiDegisiklikSayac = 0;
        public static Timer PubUrunListesiTimer;

        void urunListele()
        {
            var degerler = from urunBilgileri in db.TBLURUN
                           select new
                           {
                               urunBilgileri.ID,
                               KATEGORI = urunBilgileri.TBLKATEGORI.AD,//urun tablosundan kategori tablosunu cagirdik ilişkili tablo oldukları icin
                                                                       //Bi anonimous type oluştur diyordu o yuzden KATGEROI =  dedik
                               urunBilgileri.AD,
                               urunBilgileri.MARKA,
                               urunBilgileri.ALISFIYAT,
                               urunBilgileri.SATISFIYAT,
                               urunBilgileri.STOK,
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();

            t.AD = TxtUrunAd.Text;
            t.MARKA = TxtUrunMarka.Text;
            t.ALISFIYAT = decimal.Parse(TxtUrunAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtUrunSatisFiyat.Text);
            t.STOK = short.Parse(TxtUrunStok.Text);
            t.DURUM = false;
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());

            db.TBLURUN.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PubUrunListesiTimer.Enabled = true;
            UrunListesiDegisiklikSayac++; //Yapılan Değişikliği anlamak icin markalar formunda bu değere gore chartta değişiklik yapıyorum
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtUrunMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            TxtUrunAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            TxtUrunSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            TxtUrunStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
            //Burdaki KATEGORI veri tabaındakı alan adı ama veriyi cekerken anonymous typeınıda KATEGORI yapmazsak farklı ad olursa çağırmaz.Aynı olmalı
            //lookUpEditte DisplayMember ıda aynı adda olmalı
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Ürün Başarıyla Silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            PubUrunListesiTimer.Enabled = true;
            UrunListesiDegisiklikSayac++;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLURUN.Find(id);

            deger.AD = TxtUrunAd.Text;
            deger.MARKA = TxtUrunMarka.Text;
            deger.ALISFIYAT = decimal.Parse(TxtUrunAlisFiyat.Text);
            deger.SATISFIYAT = decimal.Parse(TxtUrunSatisFiyat.Text);
            deger.STOK = short.Parse(TxtUrunStok.Text);
            deger.DURUM = false;
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();

            MessageBox.Show("Ürün Başarıyla Güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            PubUrunListesiTimer.Enabled = true;
            UrunListesiDegisiklikSayac++;
        }

        void lookUpEditKategoriListeleme()
        {
            lookUpEdit1.Properties.DataSource = db.TBLKATEGORI.Select(x => new
            {
                x.ID,
                KATEGORI = x.AD
            }).ToList();
        }
        private void FrmUrunListesi_Activated(object sender, EventArgs e)
        {
            PubUrunListesiTimer = UrunListesiTimer;

            urunListele(); //Form Active edildiginde urunleri tekrar listele ki yeni verilen eklensin
            lookUpEditKategoriListeleme(); ////Form Active edildiginde kategorileri tekrar listele ki yeni kategori eklendiyse gelsin

            if (Formlar.FrmKategoriListesi.KategoriDegisiklikSayac > 0) //Kategoride değişiklik yapıldıysa
            {
                lookUpEdit1.Properties.DataSource = " "; //LookupEditi boşalt

                lookUpEditKategoriListeleme();//Tekrar yeni verilerle doldur

                Formlar.FrmKategoriListesi.KategoriDegisiklikSayac = 0;//Tkrar kullanabilmke icin sayacı 0 la
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtUrunAd.Text = "";
            TxtUrunMarka.Text = "";
            TxtUrunAlisFiyat.Text = "";
            TxtUrunSatisFiyat.Text = "";
            TxtUrunStok.Text = "";
        }

        private void UrunListesiTimer_Tick(object sender, EventArgs e)
        {
            urunListele();//Değiişiklik yapılıysa timer çalışacak ve urunler yeni bilgilerle listelenecek
            if (Formlar.FrmYeniUrun.YeniUrunDegisiklikSayac > 0)//Timer calıştığında(yeni urun formunda kaydet deninlince degisiklik sayacı artıyor)
            {
                urunListele();//Urunleri yeni bilgilerle listele
            }
            PubUrunListesiTimer.Enabled = false; //Tkrar kullanabilmke icin timer kapatılacak
        }
    }
}
