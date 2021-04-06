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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static int YeniPersonelDegisiklikSayac = 0;

        private void FrmYeniPersonel_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = db.TBLDEPARTMAN.Select(x => new
            {
                x.ID,
                x.AD
            }).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();

            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.FOTOGRAF = TxtFotograf.Text;
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;

            db.TBLPERSONEL.Add(t);
            db.SaveChanges();

            MessageBox.Show("Personel Başarıyla Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            YeniPersonelDegisiklikSayac++;//Diger formda burda değişiklik yapılmışmı kontrol etmek icins sayac
            Formlar.FrmPersonelListesi.PubPesonelListesiTimer.Enabled = true;//UrunListesi fomrundaki timerı calıştırıyor ki çalışınca liste guncellensin
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
