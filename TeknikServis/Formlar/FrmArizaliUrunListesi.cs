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
    public partial class FrmArizaliUrunListesi : Form
    {
        public FrmArizaliUrunListesi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static Timer PubYeniArizaliUrunTimer;//Aciklama formundan çalıştırabilmek icin public timer

        void formLoad()
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               x.URUNSERINO,
                               Cari = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                               Personel = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                               x.GELISTARIH,
                               x.CIKISTARIH
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void ArizaliUrunListesiTimer_Tick(object sender, EventArgs e)
        {
            if (FrmYeniArizaliUrun.YeniArizaliUrunDegisiklikSayac > 0)//Eğer diger formda değşiklik yapıldıysa
            {
                formLoad(); //Yeni bilgilerle listele
            }

            PubYeniArizaliUrunTimer.Enabled = false;//Tkerar kullanabilmek icin timerı kapat
        }

        private void FrmArizaliUrunListesi_Activated(object sender, EventArgs e)
        {
            formLoad();

            PubYeniArizaliUrunTimer = ArizaliUrunListesiTimer;
        }
    }
}
