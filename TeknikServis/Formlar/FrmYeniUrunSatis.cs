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
    public partial class FrmYeniUrunSatis : Form
    {
        public FrmYeniUrunSatis()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSatisYap_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();

            t.URUN = int.Parse(TxtUrunID.Text);
            t.MUSTERI = int.Parse(TxtMusteriID.Text);
            t.PERSONEL = short.Parse(TxtPersonelID.Text);
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.URUNSERINO = TxtSeriNo.Text;

            db.TBLURUNHAREKET.Add(t);

            db.SaveChanges();

            MessageBox.Show("Ürün Satış İşlemi Başarıyla Yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUrunTemizle_Click(object sender, EventArgs e)
        {
            TxtUrunID.Text = "Ürün ID";
            TxtUrunAd.Text = "Ürün";

            TxtSatisFiyat.Text = "";
        }

        private void TxtID_Leave(object sender, EventArgs e)
        {
            if(TxtUrunID.Text == "Ürün ID" || TxtUrunID.Text == "")
            {
                TxtUrunID.Text = "Ürün ID";
                TxtUrunAd.Text = "Ürün";   
            }
            else
            {
                int idUrun = int.Parse(TxtUrunID.Text);

                var urun = db.TBLURUN.Find(idUrun);

                if (urun != null && TxtUrunID.Text == idUrun.ToString())
                {
                    string UrunAd = urun.AD;
                    string UrunFiyat = urun.SATISFIYAT.ToString();

                    TxtUrunAd.Text = UrunAd;
                    TxtSatisFiyat.Text = UrunFiyat;

                    TxtUrunAd.Enabled = false;

                    TxtSatisFiyat.Enabled = false;
                }
                else
                {
                    MessageBox.Show(idUrun + " ID numarası ile kayıtlı Ürün bulunmamaktadır.\n\n" +
                                                 "LUTFEN GEÇERLİ BİR ID NUMARASI GİRİNİZ...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtUrunID.Text = "";
                    TxtUrunAd.Text = "";
                }
            }
            
        }

        private void FrmYeniUrunSatis_Load(object sender, EventArgs e)
        {
            TxtUrunAd.Enabled = false;
            TxtMusteriAd.Enabled = false;
            TxtPersonelAd.Enabled = false;

            TxtSatisFiyat.Enabled = false;
        }

        private void BtnMusteriTemizle_Click(object sender, EventArgs e)
        {
            TxtMusteriID.Text = "Müşteri ID";
            TxtMusteriAd.Text = "Müşteri";
        }

        private void BtnPersonelTemizle_Click(object sender, EventArgs e)
        {
            TxtPersonelID.Text = "Personel ID";
            TxtPersonelAd.Text = "Personel";
        }

        private void TxtMusteriID_Leave(object sender, EventArgs e)
        {
            //MÜŞTERİ BILGILERI ALMA
            if (TxtMusteriID.Text == "Ürün ID" || TxtMusteriID.Text == "")
            {
                TxtMusteriID.Text = "Müşteri ID";
                TxtMusteriAd.Text = "Müşteri"; 
            }
            else
            {
                int idCari = int.Parse(TxtMusteriID.Text);

                var cari = db.TBLCARI.Find(idCari);

                if (cari != null && TxtMusteriID.Text == idCari.ToString())
                {
                    string MusteriAd = cari.AD + " " + cari.SOYAD;

                    TxtMusteriAd.Text = MusteriAd;
                }
                else
                {
                    MessageBox.Show(idCari + " ID numarası ile kayıtlı Müşteri bulunmamaktadır.\n\n" +
                                                 "LUTFEN GEÇERLİ BİR ID NUMARASI GİRİNİZ...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtMusteriID.Text = "";
                    TxtMusteriAd.Text = "";
                }
            }
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

        private void TxtUrunID_Click(object sender, EventArgs e)
        {
            TxtUrunID.Text = "";
        }

        private void TxtMusteriID_Click(object sender, EventArgs e)
        {
            TxtMusteriID.Text = "";
        }

        private void TxtPersonelID_Click(object sender, EventArgs e)
        {
            TxtPersonelID.Text = "";
        }
    }
}
