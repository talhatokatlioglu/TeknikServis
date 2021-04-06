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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static int YeniUrunDegisiklikSayac = 0;

        void lookUpEditKategoriListeleme()
        {
            lookUpEdit1.Properties.DataSource = db.TBLKATEGORI.Select(x => new
            {
                x.ID,
                KATEGORI = x.AD
            }).ToList();
        }

        private void TxtUrunAdi_Click(object sender, EventArgs e)
        {
            TxtUrunAdi.Text = "";
        }

        private void TxtUrunMarkasi_Click(object sender, EventArgs e)
        {
            TxtUrunMarkasi.Text = "";
        }

        private void TxtUrunAlisFiyati_Click(object sender, EventArgs e)
        {
            TxtUrunAlisFiyati.Text = "";
        }

        private void TxtUrunSatisFiyati_Click(object sender, EventArgs e)
        {
            TxtUrunSatisFiyati.Text = "";
        }

        private void TxtUrunStokAdedi_Click(object sender, EventArgs e)
        {
            TxtUrunStokAdedi.Text = "";
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();

            t.AD = TxtUrunAdi.Text;
            t.MARKA = TxtUrunMarkasi.Text;
            t.ALISFIYAT = decimal.Parse(TxtUrunAlisFiyati.Text);
            t.SATISFIYAT = decimal.Parse(TxtUrunSatisFiyati.Text);
            t.STOK = short.Parse(TxtUrunStokAdedi.Text);
            t.DURUM = false;
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());

            db.TBLURUN.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            YeniUrunDegisiklikSayac++;//Diger formda burda değişiklik yapılmışmı kontrol etmek icins sayac
            Formlar.FrmUrunListesi.PubUrunListesiTimer.Enabled = true;//UrunListesi fomrundaki timerı calıştırıyor ki çalışınca liste guncellensin
        }

        private void FrmYeniUrun_Activated(object sender, EventArgs e)
        {
            lookUpEditKategoriListeleme();
        }
    }
}
