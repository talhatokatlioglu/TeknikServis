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
    public partial class FrmFaturaKalemGirisi : Form
    {
        public FrmFaturaKalemGirisi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();

            t.URUN = TxtUrun.Text;
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaID.Text);

            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();

            MessageBox.Show("Faturaya Kalem Girişi Başarıyla Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLFATURADETAY.Find(id);
            db.TBLFATURADETAY.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Faturaya Kalem Girişi Başarıyla Silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var t = db.TBLFATURADETAY.Find(id);

            t.URUN = TxtUrun.Text;
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaID.Text);

            db.SaveChanges();

            MessageBox.Show("Fatura Kalem Girişi Başarıyla Güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrun.Text = gridView1.GetFocusedRowCellValue("URUN").ToString();
            TxtAdet.Text = gridView1.GetFocusedRowCellValue("ADET").ToString();
            TxtFiyat.Text = gridView1.GetFocusedRowCellValue("FIYAT").ToString();
            TxtTutar.Text = gridView1.GetFocusedRowCellValue("TUTAR").ToString();
            TxtFaturaID.Text = gridView1.GetFocusedRowCellValue("FATURAID").ToString();
        }

        private void FrmFaturaKalemGirisi_Activated(object sender, EventArgs e)
        {
            TxtID.Enabled = false;
            
            gridControl1.DataSource = db.TBLFATURADETAY.Select(x => new
            {
                x.ID,
                x.URUN,
                x.ADET,
                x.FIYAT,
                x.TUTAR,
                x.FATURAID
            }).ToList();
        }
    }
}
