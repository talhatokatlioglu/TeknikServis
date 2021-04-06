using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void sekmeControl()//Max 21 sekmeye izin vermek icin
        {
            int tabSayac = xtraTabbedMdiManager1.Pages.Count();
            if (tabSayac < 20)
            {
                ribbonControl1.Enabled = true;
            }
            else
            {
                ribbonControl1.Enabled = false;
                MessageBox.Show("21'DEN FAZLA SEKME AÇAMAZSINIZ.\n\n" +
                                "Tekrar sayfa açabilmeniz için:\n" +
                                "1- İşlem yapmadığınız sekmeleri kapatın.\n" +
                                "2- Az işlem yaptığınız sekmeleri kapatın.\n" +
                                "3- 1'den çok kez açtığınız sekmeleri kapattın.\n\n" +
                                "-Bu işlemlerin birini ya da birkaçını yaparsanız yeniden sekme açabileceksiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmUrunListesi UrunListesiFormu = new Formlar.FrmUrunListesi();
            UrunListesiFormu.MdiParent = this;
            UrunListesiFormu.Show();
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)//MDI'dan sayfa kaldırıldığında.(RibbonPageden sayfa kaldırıldığında)
        {
            sekmeControl();
        }

        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)//MDI'a sayfa eklendiğinde(RibbonPageden sayfa acildiğinda)
        {
            sekmeControl();
        }

        private void BtnKategoriListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmKategoriListesi KategoriListesiFormu = new Formlar.FrmKategoriListesi();
            KategoriListesiFormu.MdiParent = this;
            KategoriListesiFormu.Show();
        }

        
        private void BtnYeniUrunFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniUrun YeniUrunFormu = new Formlar.FrmYeniUrun();
            YeniUrunFormu.Show();
        }

        private void BtnYeniKategoriFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniKategori YeniKategoriFormu = new Formlar.FrmYeniKategori();
            YeniKategoriFormu.Show();
        }

        private void BtnUrunIstatistikFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmUrunIstatistik UrunIstatistikFormu = new Formlar.FrmUrunIstatistik();
            UrunIstatistikFormu.MdiParent = this;
            UrunIstatistikFormu.Show();
        }

        private void BtnMarkaIstatistikFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmMarkalarIstatistik MarkaIstatistikFormu = new Formlar.FrmMarkalarIstatistik();
            MarkaIstatistikFormu.MdiParent = this;
            MarkaIstatistikFormu.Show();
        }

        private void BtnCariListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmCariListesi CariListesiFormu = new Formlar.FrmCariListesi();
            CariListesiFormu.MdiParent = this;
            CariListesiFormu.Show();
        }

        private void BtnYeniCariFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniCari YeniCariFormu = new Formlar.FrmYeniCari();
            YeniCariFormu.Show();
        }

        private void BtnCariIlIstatistikFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmCariIlIstatistik CariIlIstatistikFormu = new Formlar.FrmCariIlIstatistik();
            CariIlIstatistikFormu.MdiParent = this;
            CariIlIstatistikFormu.Show();
        }

        private void BtnDepartmanListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmDepartmanListesi DepartmanListesiFormu = new Formlar.FrmDepartmanListesi();
            DepartmanListesiFormu.MdiParent = this;
            DepartmanListesiFormu.Show();
        }

        private void BtnPersonelListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmPersonelListesi PersonelListesiFormu = new Formlar.FrmPersonelListesi();
            PersonelListesiFormu.MdiParent = this;
            PersonelListesiFormu.Show();
        }

        private void BtnYeniDepartmanFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniDepartman YeniDepartmanFormu = new Formlar.FrmYeniDepartman();
            YeniDepartmanFormu.Show();
        }

        private void BtnYeniPersonelFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniPersonel YeniPersonelFormu = new Formlar.FrmYeniPersonel();
            YeniPersonelFormu.Show();
        }

        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnDövizKurları_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmDovizKurlari DovizKurlariFormu = new Formlar.FrmDovizKurlari();
            DovizKurlariFormu.MdiParent = this;
            DovizKurlariFormu.Show();
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void BtnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmYoutube YoutubeFormu = new Formlar.FrmYoutube();
            YoutubeFormu.MdiParent = this;
            YoutubeFormu.Show();
        }

        private void BtnAjandaFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmAjanda AjandaFormu = new Formlar.FrmAjanda();
            AjandaFormu.MdiParent = this;
            AjandaFormu.Show();
        }

        private void BtnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmArizaliUrunListesi ArizaliUrunListesiFormu = new Formlar.FrmArizaliUrunListesi();
            ArizaliUrunListesiFormu.MdiParent = this;
            ArizaliUrunListesiFormu.Show();
        }

        private void BtnYeniUrunSatisFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniUrunSatis YeniUrunSatisFormu = new Formlar.FrmYeniUrunSatis();
            YeniUrunSatisFormu.Show();
        }

        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmSatisListesi SatisListesiFormu = new Formlar.FrmSatisListesi();
            SatisListesiFormu.MdiParent = this;
            SatisListesiFormu.Show();
        }

        private void BtnYeniArizaliUrunFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniArizaliUrun YeniArizaliUrunFormu = new Formlar.FrmYeniArizaliUrun();
            YeniArizaliUrunFormu.Show();
        }

        private void BtnArizaliUrunAciklamaFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunAciklama ArizaliUrunAciklamaFormu = new Formlar.FrmArizaliUrunAciklama();
            ArizaliUrunAciklamaFormu.Show();
        }

        private void BtnArizaliUrunDetaylariListele_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmArizaliUrunDetayListesi ArizaliUrunDetayListesiFormu = new Formlar.FrmArizaliUrunDetayListesi();
            ArizaliUrunDetayListesiFormu.MdiParent = this;
            ArizaliUrunDetayListesiFormu.Show();
        }

        private void BtnQRKodOluşturFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRKodOlustur QRKodOlusturFormu = new Formlar.FrmQRKodOlustur();
            QRKodOlusturFormu.Show();
        }

        private void BtnFaturaListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = false;

            Formlar.FrmFaturaListesi FaturaListesiFormu = new Formlar.FrmFaturaListesi();
            FaturaListesiFormu.MdiParent = this;
            FaturaListesiFormu.Show();
        }
    }
}
