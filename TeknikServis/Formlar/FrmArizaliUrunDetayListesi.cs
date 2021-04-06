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
    public partial class FrmArizaliUrunDetayListesi : Form
    {
        public FrmArizaliUrunDetayListesi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static Timer PubArizaliUrunDetayListesiTimer;//Aciklama formundan çalıştırabilmek icin public timer

        void formLoad()
        {
            var deger = db.TBLURUNTAKIP.Select(x => new
            {
                x.TAKIPID,
                x.SERINO,
                x.ACIKLAMA,
                x.TARIH
            });

            gridControl1.DataSource = deger.ToList();
        }

        private void FrmArizaliUrunDetayListesi_Activated(object sender, EventArgs e)
        {
            formLoad();

            PubArizaliUrunDetayListesiTimer = ArizaliUrunDetayListesiTimer;
        }

        private void ArizaliUrunDetayListesiTimer_Tick(object sender, EventArgs e)//Timer calıştığında
        {
            if (FrmArizaliUrunAciklama.ArizaliUrunAciklamaDegisiklikSayac > 0)//Eğer diger formda değşiklik yapıldıysa
            {
                formLoad(); //Yeni bilgilerle listele
            }

            PubArizaliUrunDetayListesiTimer.Enabled = false;//Tkerar kullanabilmek icin timerı kapat
        }
    }
}
