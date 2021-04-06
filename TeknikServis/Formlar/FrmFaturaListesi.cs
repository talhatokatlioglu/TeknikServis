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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            TxtID.Enabled = false;

            var degerler = db.TBLFATURABILGI.Select(x => new
            {
                x.ID,
                x.SERI,
                x.SIRANO,
                x.TARIH,
                x.SAAT,
                x.VERGIDAIRE,
                CARI = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD

            });
            gridControl1.DataSource = degerler.ToList();

            var cariler = db.TBLCARI.Select(x => new
            {
                x.ID,
                CARI = x.AD + " " + x.SOYAD
            });
            lookUpEdit1.Properties.DataSource = cariler.ToList();

            var personeller = db.TBLPERSONEL.Select(x => new
            {
                x.ID,
                PERSONEL = x.AD + " " + x.SOYAD
            });
            lookUpEdit2.Properties.DataSource = personeller.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();

            t.SERI = TxtSeri.Text;
            t.SIRANO = TxtSiraNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGIDAIRE = TxtVergiDairesi.Text;
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());

            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();

            MessageBox.Show("Fatura Başarıyla Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLFATURABILGI.Find(id);
            db.TBLFATURABILGI.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Fatura Başarıyla Silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var t = db.TBLFATURABILGI.Find(id);

            t.SERI = TxtSeri.Text;
            t.SIRANO = TxtSiraNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGIDAIRE = TxtVergiDairesi.Text;
            t.CARI = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = byte.Parse(lookUpEdit2.EditValue.ToString());

            db.SaveChanges();

            MessageBox.Show("Fatura Başarıyla Güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtSeri.Text = gridView1.GetFocusedRowCellValue("SERI").ToString();
            TxtSiraNo.Text = gridView1.GetFocusedRowCellValue("SIRANO").ToString();
            TxtTarih.Text = gridView1.GetFocusedRowCellValue("TARIH").ToString();
            TxtSaat.Text = gridView1.GetFocusedRowCellValue("SAAT").ToString();
            TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRE").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("CARI").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("PERSONEL").ToString();
        }
    }
}
