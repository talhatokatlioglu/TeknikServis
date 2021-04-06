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
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmSatisListesi_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TBLURUNHAREKET
                            join y in db.TBLURUN
                            on x.URUN equals y.ID
                            select new
                            {
                                ÜRÜN = y.AD,
                                MÜŞTERİ = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                                SATIŞTARİHİ = x.TARIH,
                                ADET = x.ADET,
                                FİYAT = x.FIYAT,
                                SERİNO = x.URUNSERINO
                            });
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
