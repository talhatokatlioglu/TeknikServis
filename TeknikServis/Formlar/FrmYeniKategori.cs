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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        public static int YeniKategoriDegisiklikSayac = 0;

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtUrunAdi_Click(object sender, EventArgs e)
        {
            TxtKategoriAdi.Text = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLKATEGORI k = new TBLKATEGORI();

            k.AD = TxtKategoriAdi.Text;

            db.TBLKATEGORI.Add(k);
            db.SaveChanges();

            int id = k.ID;//Hangi ID  ile kaydolduğunu gostermek için 

            MessageBox.Show("Kategori Başarılı bir şekilde ID numarası " + id.ToString() + "  olarak Kaydedildi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

            YeniKategoriDegisiklikSayac++;//Diger formda burda değişiklik yapılmışmı kontrol etmek icins sayac
            Formlar.FrmKategoriListesi.PubKategoriListesiTimer.Enabled = true;
            //UrunListesi fomrundaki timerı calıştırıyor ki çalışınca liste guncellensin

        }
    }
}
