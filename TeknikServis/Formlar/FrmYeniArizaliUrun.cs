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
    public partial class FrmYeniArizaliUrun : Form
    {
        public FrmYeniArizaliUrun()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static int YeniArizaliUrunDegisiklikSayac = 0; //Veritabanında değişiklik yapıldığında urun detay formuna bildirp tabloyu tekrar yenileyerek yeni bilgileri gondermsini sağlıyoruz

        private void FrmYeniArizaliUrun_Load(object sender, EventArgs e)
        {
            TxtMusteriID.Enabled = false;
            TxtMusteriAd.Enabled = false;
            TxtPersonelID.Enabled = false;
            TxtPersonelAd.Enabled = false;

            this.KeyPreview = true;
        }

        private void BtnPersonelTemizle_Click(object sender, EventArgs e)
        {
            TxtPersonelID.Enabled = true;
            TxtPersonelID.Text = "Personel ID";
            TxtPersonelAd.Text = "Personel";
        }

        private void TxtPersonelID_Leave(object sender, EventArgs e)
        {
            //PERSONEL BILGILERI ALMA
            if (TxtPersonelID.Text == "Personel ID" || TxtPersonelID.Text == "")
            {
                TxtPersonelID.Text = "Personel ID";
                TxtPersonelAd.Text = "Personel";
            }
            else
            {
                int idPersonel = int.Parse(TxtPersonelID.Text);

                var personel = db.TBLPERSONEL.Find(idPersonel);

                if (personel != null && TxtPersonelID.Text == idPersonel.ToString())
                {
                    TxtPersonelAd.Text = personel.AD + " " + personel.SOYAD;
                }
                else
                {
                    MessageBox.Show(idPersonel + " ID numarası ile kayıtlı Personel bulunmamaktadır.\n\n" +
                                                 "LUTFEN GEÇERLİ BİR ID NUMARASI GİRİNİZ...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtPersonelID.Text = "";
                    TxtPersonelAd.Text = "";
                }
            }
        }

        private void TxtPersonelID_Click(object sender, EventArgs e)
        {
            TxtPersonelID.Text = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();

            t.CARI = int.Parse(TxtMusteriID.Text);
            t.PERSONEL = short.Parse(TxtPersonelID.Text);
            t.GELISTARIH = DateTime.Parse(TxtTarih.Text);
            t.URUNSERINO = TxtSeriNo.Text;

            db.TBLURUNKABUL.Add(t);

            db.SaveChanges();

            MessageBox.Show("Atızalı Ürün Kayıt İşlemi Başarıyla Yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            YeniArizaliUrunDegisiklikSayac++;//Değişiklik olduğu icins ayca arttırıyoruz
            FrmArizaliUrunListesi.PubYeniArizaliUrunTimer.Enabled = true;//Urun detay formundaki timerı calıştırıyoruz ki çalışınca listeleme yapsın
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int EnterTiklamaSayac = 0;
        string SeriNo;
        TeknikServis.TBLURUNHAREKET SeriNoBul;

        void EslesenBilgileriYerineYaz()
        {
            TxtPersonelID.Text = SeriNoBul.TBLPERSONEL.ID.ToString();
            TxtPersonelAd.Text = SeriNoBul.TBLPERSONEL.AD + " - " + SeriNoBul.TBLPERSONEL.SOYAD;

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

        private void FrmYeniArizaliUrun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
            if(e.KeyChar == (char)Keys.Enter)
            {
                EnterTiklamaSayac++;//Tıklama sayacını 1 arttır

                //URUN VE MUSTERI BILGILERI ALMA
                if (TxtSeriNo.Text == "Seri No" || TxtSeriNo.Text == "")//Eğer Seri No'ya birşey yazılmamışsa ve Entera basılmışsa Yazıları tekrar yaz sayacı 0'la
                {
                    TxtPersonelID.Text = "Personel ID";
                    TxtPersonelAd.Text = "Personel";
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

                        if (SeriNoBul.TBLPERSONEL.ID.ToString() == TxtPersonelID.Text && SeriNoBul.TBLCARI.ID.ToString() == TxtMusteriID.Text)//Eğer bulunan ıd ile txtboxtakiler eşleşiyorsa
                        {
                            TBLURUNKABUL t = new TBLURUNKABUL();

                            t.CARI = int.Parse(TxtMusteriID.Text);
                            t.PERSONEL = short.Parse(TxtPersonelID.Text);
                            t.GELISTARIH = DateTime.Parse(TxtTarih.Text);
                            t.URUNSERINO = TxtSeriNo.Text;

                            db.TBLURUNKABUL.Add(t);

                            db.SaveChanges();

                            MessageBox.Show("Atızalı Ürün Kayıt İşlemi Başarıyla Yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            YeniArizaliUrunDegisiklikSayac++;
                            FrmArizaliUrunListesi.PubYeniArizaliUrunTimer.Enabled = true;

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

        private void TxtPersonelID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
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

                TxtPersonelID.Enabled = false;
            }
        }
    }
}
