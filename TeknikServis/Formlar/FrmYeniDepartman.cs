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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        public static int YeniDepartmanDegisiklikSayac = 0;

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text.Length > 20 || TxtAciklama.Text == "" || TxtAd.Text == "")
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

                YeniDepartmanDegisiklikSayac++;//Diger formda burda değişiklik yapılmışmı kontrol etmek icins sayac
                Formlar.FrmDepartmanListesi.PubDepartmanListesiTimer.Enabled = true;
                //UrunListesi fomrundaki timerı calıştırıyor ki çalışınca liste guncellensin

            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
