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
    public partial class FrmYeniCari : Form
    {
        public FrmYeniCari()
        {
            InitializeComponent();
        }

        public static int YeniCariDegisiklikSayac = 0;

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
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

            YeniCariDegisiklikSayac++;//Diger formda burda değişiklik yapılmışmı kontrol etmek icins sayac
            Formlar.FrmCariListesi.PubCariListesiTimer.Enabled = true;
            //UrunListesi fomrundaki timerı calıştırıyor ki çalışınca liste guncellensin

        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtAd_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
        }

        private void TxtSoyad_Click(object sender, EventArgs e)
        {
            TxtSoyad.Text = "";
        }

        private void TxtMail_Click(object sender, EventArgs e)
        {
            TxtMail.Text = "";
        }

        private void TxtTelefon_Click(object sender, EventArgs e)
        {
            TxtTelefon.Text = "";
        }

        private void TxtBanka_Click(object sender, EventArgs e)
        {
            TxtBanka.Text = "";
        }

        private void TxtVergiDairesi_Click(object sender, EventArgs e)
        {
            TxtVergiDairesi.Text = "";
        }

        private void TxtVergiNo_Click(object sender, EventArgs e)
        {
            TxtVergiNo.Text = "";
        }

        private void TxtStatu_Click(object sender, EventArgs e)
        {
            TxtStatu.Text = "";
        }

        private void TxtAdres_Click(object sender, EventArgs e)
        {
            TxtAdres.Text = "";
        }
    }
}
