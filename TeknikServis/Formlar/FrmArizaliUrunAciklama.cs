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
    public partial class FrmArizaliUrunAciklama : Form
    {
        public FrmArizaliUrunAciklama()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static int ArizaliUrunAciklamaDegisiklikSayac = 0; //Veritabanında değişiklik yapıldığında urun detay formuna bildirp tabloyu tekrar yenileyerek yeni bilgileri gondermsini sağlıyoruz

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                TBLURUNTAKIP t = new TBLURUNTAKIP();

                t.ACIKLAMA = richTextBox1.Text;
                t.SERINO = TxtSeriNo.Text;
                t.TARIH = DateTime.Parse(TxtTarih.Text);

                db.TBLURUNTAKIP.Add(t);

                db.SaveChanges();

                MessageBox.Show("Arızalı Ürüne Açıklama Kayıt İşlemi Başarıyla Yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ArizaliUrunAciklamaDegisiklikSayac++;//Değişiklik olduğu icins ayca arttırıyoruz
                FrmArizaliUrunDetayListesi.PubArizaliUrunDetayListesiTimer.Enabled = true;//Urun detay formundaki timerı calıştırıyoruz ki çalışınca listeleme yapsın
            }
            else
            {
                MessageBox.Show(SeriNo + " Açıklama boş bırakılamaz.","Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        TeknikServis.TBLURUNHAREKET SeriNoBul;
        string SeriNo;
     
        void EslesenBilgileriYerineYaz()
        {
            TxtUrunID.Text = db.TBLURUN.Select(x=>x.AD).ToString();
            TxtUrunAd.Text = db.TBLURUN.Select(x => x.MARKA).ToString() + " - " + db.TBLURUN.Select(x=>x.AD).ToString();

            TxtMusteriID.Text = SeriNoBul.TBLCARI.ID.ToString();
            TxtMusteriAd.Text = SeriNoBul.TBLCARI.AD + " " + SeriNoBul.TBLCARI.SOYAD;

            DateTime today = DateTime.Today;
            TxtTarih.Text = today.ToString();//Bilgileri yerine yaz
        }

        void HataMesaji()
        {
            MessageBox.Show(SeriNo + " Seri Nosu ile kayıtlı satılmış ürün bulunmamaktadır.\n\n" + //Kayıtlı olamdığını sole
                                                         "LUTFEN GEÇERLİ BİR SERI NO NUMARASI GİRİNİZ...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtSeriNo.Text = "Seri No";//Serinoyu sil yenisnin girilmesi icin
            EnterTiklamaSayac = 0;//Tıklama sayacını 0'la ki kaydetmesin
        }

        int EnterTiklamaSayac = 0;
        private void FrmArizaliUrunAciklama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) // Esc'ye basıldıysa
            {
                this.Close(); // Formu Kapat
            }
            if (e.KeyChar == (char)Keys.Enter)//Enter'a basıldıysa
            {
                EnterTiklamaSayac++;//Tıklama sayacını 1 arttır

                //URUN VE MUSTERI BILGILERI ALMA
                if (TxtSeriNo.Text == "Seri No" || TxtSeriNo.Text == "")//Eğer Seri No'ya birşey yazılmamışsa ve Entera basılmışsa Yazıları tekrar yaz sayacı 0'la
                {
                    TxtUrunID.Text = "Ürün ID";
                    TxtUrunAd.Text = "Ürün";
                    TxtMusteriID.Text = "Müşteri ID";
                    TxtMusteriAd.Text = "Müşteri";
                    TxtTarih.Text = "Tarih";

                    EnterTiklamaSayac = 0;
                }
                else//Eğer Seri no girilmiş ise
                {
                    if (EnterTiklamaSayac % 2 != 0)//Tıklama sayacı tek sayı ise
                    {
                        SeriNo = TxtSeriNo.Text;

                        SeriNoBul = db.TBLURUNHAREKET.Find(SeriNo);//Seri no yu gerekli tabloda bul bilgilerini getir

                        if (SeriNoBul != null && TxtSeriNo.Text == SeriNo.ToString())//Eğer seri no kayıtlı ise ve bilgiler eşleşiyorsa
                        {
                            EslesenBilgileriYerineYaz();
                        }
                        else//Eğer aranan seri no yoksa yada bilgiler eşleşmiyorsa 
                        {
                            HataMesaji();
                        }
                    }
                    else//Eğer eğer tıklanma sayısı 2 ise
                    {
                        SeriNo = TxtSeriNo.Text;

                        SeriNoBul = db.TBLURUNHAREKET.Find(SeriNo);//Seri noyu tekrar tabloda bul

                        if (db.TBLURUN.Select(x=>x.ID).ToString() == TxtUrunID.Text && SeriNoBul.TBLCARI.ID.ToString() == TxtMusteriID.Text)//Eğer bulunan ıd ile txtboxtakiler eşleşiyorsa
                        {
                            if(richTextBox1.Text != "")//Eğer açıklama yazılmışsa kaydet
                            {
                                TBLURUNTAKIP t = new TBLURUNTAKIP();

                                t.ACIKLAMA = richTextBox1.Text;
                                t.SERINO = TxtSeriNo.Text;
                                t.TARIH = DateTime.Parse(TxtTarih.Text);

                                db.TBLURUNTAKIP.Add(t);

                                db.SaveChanges();//Acıklamayı kaydet

                                MessageBox.Show("Arızalı Ürüne Açıklama Kayıt İşlemi Başarıyla Yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ArizaliUrunAciklamaDegisiklikSayac++;
                                FrmArizaliUrunDetayListesi.PubArizaliUrunDetayListesiTimer.Enabled = true;
                            }
                            else//Eğer acıklama yazılammışsa hata mesajı ver
                            {
                                MessageBox.Show(SeriNo + " Açıklama boş bırakılamaz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EnterTiklamaSayac = 1;//Sayaycı 1 yap ki acıkalma yapıp tekrar geldiğinde tıklanma 2 olsun ve kaydetsin
                            }
                            
                        }
                        else//Eğer bilgiler eşleşmiyorsa
                        {
                            EnterTiklamaSayac = 1;//Tıklama sayacını 1 yap ki 2. tıklamada kaydetsin yuları tekrar donunce 

                            if (SeriNoBul != null && TxtSeriNo.Text == SeriNo.ToString())//Eğer seri no kayıtlı ise
                            {
                                EslesenBilgileriYerineYaz();
                                //Burdan sonra tıklam sayacı 2 olucak başa donucek ve tıklama sayacı 2 ise bilgileri kaydet kısmından kaydedicek
                            }
                            else//Eğer seri no kayıtlı deilse hata mesajı ver
                            {
                                HataMesaji();
                            }
                        }
                    }
                }
            }
        }

        private void TxtSeriNo_Click(object sender, EventArgs e)
        {
            TxtSeriNo.Text = "";
        }

        private void FrmArizaliUrunAciklama_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;//Tıklanılan tuşu okuyabilme izni

            TxtUrunID.Enabled = false;
            TxtUrunAd.Enabled = false;
            TxtMusteriID.Enabled = false;
            TxtMusteriAd.Enabled = false;
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
