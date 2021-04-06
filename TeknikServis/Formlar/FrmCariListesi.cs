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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        public static Timer PubCariListesiTimer;

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        static public int CariListesiDegisiklikSayac = 0;
        void cariListele()
        {
            var deger = db.TBLCARI.Select(x => new
            {
                x.ID,
                x.AD,
                x.SOYAD,
                x.MAIL,
                x.TELEFON,
                x.IL,
                x.ILCE,
                x.BANKA,
                x.VERGIDAIRESI,
                x.VERGINO,
                x.STATU,
                x.ADRES
            });
            gridControl1.DataSource = deger.ToList();

            labelControl13.Text = db.TBLCARI.Count().ToString();
            labelControl17.Text = db.TBLCARI.Select(y => y.IL).Distinct().Count().ToString();

            EnFazlaCariBulunanIl();
        }

        void EnFazlaCariBulunanIl()
        {
            labelControl19.Text = db.TBLCARI.OrderBy(x => x.IL).GroupBy(a => a.IL).Select(y => new
            {
                İl = y.Key,
                Toplam = y.Count()
            }).OrderByDescending(z => z.Toplam).Select(t => t.İl).First().ToString();//En fazla cari bulunan il
        }

        void EnFazlaCariBulunanIlCariSayisi()
        {
            labelControl19.Text = db.TBLCARI.OrderBy(x => x.IL).GroupBy(y => y.IL).Select(z => new
            {
                İl = z.Key,
                Cari = z.Count()
            }).OrderByDescending(b => b.Cari).Select(c => c.Cari).First().ToString(); //En fazla cari bulunan il cari sayisi
        }

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            TxtID.Enabled = false;

            cariListele();//Başlangıcta listeyi goster

            PubCariListesiTimer = CariListesiTimer;//Degisiklerklerin kontrolu icin timeı public bir timera atadık başka formdan açılabilir bir timer
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
            TxtBanka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
            TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRESI").ToString();
            TxtVergiNo.Text = gridView1.GetFocusedRowCellValue("VERGINO").ToString();
            TxtStatu.Text = gridView1.GetFocusedRowCellValue("STATU").ToString();
            TxtAdres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();

            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
            t.IL = lookUpEdit1.EditValue.ToString();
            t.ILCE = lookUpEdit2.EditValue.ToString();
            t.BANKA = TxtBanka.Text;
            t.VERGIDAIRESI = TxtVergiDairesi.Text;
            t.VERGINO = TxtVergiNo.Text;
            t.STATU = TxtStatu.Text; ;
            t.ADRES = TxtAdres.Text;

            db.TBLCARI.Add(t);
            db.SaveChanges();
 
            MessageBox.Show("Cari Başarıyla Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PubCariListesiTimer.Enabled = true;//Degisiklik olunca timerı calıştırıyorum ki timer calıştığında ve değşikillk olduğunda yeni listeyi cagırayım
            CariListesiDegisiklikSayac++;//Degisikliğe gore timerı çalıştııtyorum
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            TxtTelefon.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit2.Text = "";
            TxtBanka.Text = "";
            TxtVergiDairesi.Text = "";
            TxtVergiNo.Text = "";
            TxtStatu.Text = "";
            TxtAdres.Text = "";
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var t = db.TBLCARI.Find(id);

            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
            t.IL = lookUpEdit1.EditValue.ToString();
            t.ILCE = lookUpEdit2.EditValue.ToString();
            t.BANKA = TxtBanka.Text;
            t.VERGIDAIRESI = TxtVergiDairesi.Text;
            t.VERGINO = TxtVergiNo.Text;
            t.STATU = TxtStatu.Text; ;
            t.ADRES = TxtAdres.Text;
            db.SaveChanges();

            MessageBox.Show("Cari Başarıyla Güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            PubCariListesiTimer.Enabled = true;
            CariListesiDegisiklikSayac++;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Cari Başarıyla Silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            PubCariListesiTimer.Enabled = true;
            CariListesiDegisiklikSayac++;
        }

        int labelTiklamaSayac = 0;//Labela tıklayınca ilgili veriyi gostermek icin sayac
        private void labelControl19_Click(object sender, EventArgs e)
        {
            labelTiklamaSayac++;
            if(labelTiklamaSayac%2 != 0)
            {
                EnFazlaCariBulunanIl();
            }
            else
            {
                EnFazlaCariBulunanIlCariSayisi();
            }
        }

        private void CariListesiTimer_Tick(object sender, EventArgs e)
        {
            cariListele(); //Değişikliği anında kaydetmek icin calısınca yeni verilerle listeleme yapıyoruz

            if (Formlar.FrmYeniCari.YeniCariDegisiklikSayac > 0)//YeniCariden cari eklendiyse yeni lsiteyi yeni bilgilerle cağırıyoruz
            {
                cariListele();
            }

            PubCariListesiTimer.Enabled = false;//Tekrar kullanabilmek icn timerı kapatıyoruz
        }
    }
}
