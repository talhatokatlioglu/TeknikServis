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
    public partial class FrmYeniFaturaGirisi : Form
    {
        public FrmYeniFaturaGirisi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

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
    }
}
