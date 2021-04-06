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
    public partial class FrmDepartmanListesi : Form
    {
        public FrmDepartmanListesi()
        {
            InitializeComponent();
        }

        public static Timer PubDepartmanListesiTimer;//Farklı formda bu formu etkileyecek değişiklik oldğunda timerı calıştırmak icin public timer oluşturdum
        public static int DepartmanListesiDegisiklikSayac = 0;//Degisiklik yapıldığında bu fromdaki listeyi yenilemek icin kullanıorum

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        void EnCokPersoneliOlanDepartman()
        {
            labelControl17.Text = (from x in db.TBLDEPARTMAN
                                   join y in db.TBLPERSONEL
                                   on x.ID equals y.DEPARTMAN
                                   group x by x.AD into Dep
                                   select new
                                   {
                                       Dep.Key,
                                       Toplam = Dep.Count()
                                   }).OrderByDescending(c => c.Toplam).Select(b => b.Key).First(); //EN COK PERSONELI OLAN DEPARTMANIN ADI

            // BURASI DOĞRU EN COK PERSONELI OLAN DEPARTMNI GETIRIYOR AMA ISMINI DEIL IDSINI GETIRIYOR
            /*
             labelControl17.Text = db.TBLPERSONEL.OrderBy(x => x.DEPARTMAN).GroupBy(y => y.DEPARTMAN).Select(z => new
            {
                z.Key,
                toplam = z.Count()
            }).OrderByDescending(a=>a.toplam).Select(b=>b.Key).First().ToString();

            */
        }

        void EnAzPersoneliOlanDepartman()
        {
            labelControl19.Text = (from x in db.TBLDEPARTMAN
                                   join y in db.TBLPERSONEL
                                   on x.ID equals y.DEPARTMAN
                                   group x by x.AD into Dep
                                   select new
                                   {
                                       Dep.Key,
                                       Toplam = Dep.Count()
                                   }).OrderBy(c => c.Toplam).Select(b => b.Key).First(); //EN COK PERSONELI OLAN DEPARTMANIN ADI
        }

        void EnCokPersoneliOlanDepartmaninPersonelSayisi()
        {
            labelControl17.Text = (from x in db.TBLDEPARTMAN
                                   join y in db.TBLPERSONEL
                                   on x.ID equals y.DEPARTMAN
                                   group x by x.AD into Dep
                                   select new
                                   {
                                       Dep.Key,
                                       Toplam = Dep.Count()
                                   }).OrderByDescending(a => a.Toplam).Select(b => b.Toplam).First().ToString(); //EN COK PERSONELI OLAN DEPARTMANIN PERSONEL SAYISI
        }

        void EnAzPersoneliOlanDepartmaninPersonelSayisi()
        {
            labelControl19.Text = (from x in db.TBLDEPARTMAN
                                   join y in db.TBLPERSONEL
                                   on x.ID equals y.DEPARTMAN
                                   group x by x.AD into Dep
                                   select new
                                   {
                                       Dep.Key,
                                       Toplam = Dep.Count()
                                   }).OrderBy(a => a.Toplam).Select(b => b.Toplam).First().ToString(); //EN COK PERSONELI OLAN DEPARTMANIN PERSONEL SAYISI
        }

        void departmanListele()
        {
            var deger = db.TBLDEPARTMAN.Select(x => new
            {
                x.ID,
                x.AD,
                x.ACIKLAMA
            });
            gridControl1.DataSource = deger.ToList();

            labelControl15.Text = db.TBLDEPARTMAN.Count().ToString(); //Toplam Depertman sayısı
            /*
             labelControl13.Text = (from x in db.TBLDEPARTMAN
                                   join y in db.TBLPERSONEL
                                   on x.ID equals y.DEPARTMAN 
                                   select x.TBLPERSONEL).Count().ToString();//Toplam personel sayısı ama joine gerek yoktu
            */

            labelControl13.Text = db.TBLPERSONEL.Count().ToString(); //Toplam personle sayısı

            EnCokPersoneliOlanDepartman();
            EnAzPersoneliOlanDepartman();
        }

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            TxtID.Enabled = false;
            departmanListele();

            PubDepartmanListesiTimer = DepartmanTimer;
        }

        int lbl17TikalamSayac=0;
        private void labelControl17_Click(object sender, EventArgs e)
        {
            lbl17TikalamSayac++;
            if(lbl17TikalamSayac % 2 != 0)
            {
                EnCokPersoneliOlanDepartman();
            }
            else
            {
                EnCokPersoneliOlanDepartmaninPersonelSayisi();
            }
        }

        int lbl19TiklamaSayac = 0;
        private void labelControl19_Click(object sender, EventArgs e)
        {
            lbl19TiklamaSayac++;
            if (lbl19TiklamaSayac % 2 != 0)
            {
                EnAzPersoneliOlanDepartman();
            }
            else
            {
                EnAzPersoneliOlanDepartmaninPersonelSayisi();
            } 
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtAd.Text.Length > 20 || TxtAciklama.Text == "" || TxtAd.Text == "")
            {
                MessageBox.Show("Bu hatayı alıyorsanız:\n\n" +
                                "1- 20'den fazla karakter girilmiş,\n" +
                                "2- Doldurulması gereken bir alan boş bırakılmış,\n\n" +
                                "Olabilir.\n\n" +
                                "LUTFEN BU KURALLARA UYARAK TEKRAR İŞLEM YAPINIZ..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TBLDEPARTMAN t = new TBLDEPARTMAN();

                t.AD = TxtAd.Text;
                t.ACIKLAMA = TxtAciklama.Text;

                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();

                MessageBox.Show("Departman Başarıyla Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PubDepartmanListesiTimer.Enabled = true;
                FrmPersonelListesi.PubPesonelListesiTimer.Enabled = true;//Bu ekleme işlemi personel listesindeki lookupediti etikiliyor o yuzde personel listesinin timerını çalıştırdım
                DepartmanListesiDegisiklikSayac++;
            } 
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Departman Başarıyla Silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            PubDepartmanListesiTimer.Enabled = true;
            DepartmanListesiDegisiklikSayac++;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var t = db.TBLDEPARTMAN.Find(id);

            t.AD = TxtAd.Text;
            t.ACIKLAMA = TxtAciklama.Text;
            
            db.SaveChanges();

            MessageBox.Show("Departman Başarıyla Güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            PubDepartmanListesiTimer.Enabled = true;
            DepartmanListesiDegisiklikSayac++;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtAciklama.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }

        private void DepartmanTimer_Tick(object sender, EventArgs e)
        {
            departmanListele();//Değişikliği anında kaydetmek icin calısınca yeni verilerle listeleme yapıyoruz

            if (Formlar.FrmYeniDepartman.YeniDepartmanDegisiklikSayac > 0)
            {
                departmanListele();
            }

            PubDepartmanListesiTimer.Enabled = false;//Tekrar kullanabilmek icn timerı kapatıyoruz
        }
    }
}
