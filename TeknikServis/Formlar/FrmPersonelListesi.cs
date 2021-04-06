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
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        public static Timer PubPesonelListesiTimer;

        string lblAdSoyad, lblDepartman, lblMail;

        void pinliPersonel(int id)//Kullancııdan bir personel id alıp kişiyi pinleriz
        {
            string adi, soyadi, departmani, maili;

            var idControl = db.TBLPERSONEL.Find(id);//Alınan id tabloda var mı kontrol ediyoruz

            if(idControl != null)//Eğer varsa gerekli sorguları yapıp verileri çekiyoruz
            {
                adi = db.TBLPERSONEL.First(x => x.ID == id).AD;
                soyadi = db.TBLPERSONEL.First(x => x.ID == id).SOYAD;

                departmani = (from departman in db.TBLDEPARTMAN
                              join personel in db.TBLPERSONEL
                              on departman.ID equals personel.DEPARTMAN
                              select new
                              {
                                  personelID = personel.ID,
                                  departmanAd = departman.AD
                              }).Where(x => x.personelID == id).Select(y => y.departmanAd).First().ToString();

                //YUKARDAKİ İLE AYNI İŞLEMİ YAPAR
                //departmani = db.TBLPERSONEL.First(x => x.ID == id).TBLDEPARTMAN.AD;

                maili = db.TBLPERSONEL.First(x => x.ID == id).MAIL;

                lblAdSoyad = adi + " " + soyadi;
                lblDepartman = departmani;
                lblMail = maili;
            }
            else
            {
                MessageBox.Show("ID numarası " + id + " olan bir personel kaydı yok." +
                                "LÜTFEN KAYITLI OLAN BİR ID NUMARASI GİRİNİZ...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void formLoad()
        {
            var deger = from departman in db.TBLDEPARTMAN
                        join personel in db.TBLPERSONEL
                        on departman.ID equals personel.DEPARTMAN
                        select new
                        {
                            personel.ID,
                            personel.AD,
                            personel.SOYAD,
                            DEPARTMAN = departman.AD,
                            personel.FOTOGRAF,
                            personel.MAIL,
                            personel.TELEFON
                        };
            gridControl1.DataSource = deger.ToList(); //Form yuklendiğinde personeleri listeler

            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList(); //lookUpEdite departmanları listeler

        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            formLoad();

            PubPesonelListesiTimer = PersonelTimer;
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

            PubPesonelListesiTimer.Enabled = true;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Personel Başarıyla Silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            PubPesonelListesiTimer.Enabled = true;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var t = db.TBLPERSONEL.Find(id);

            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.FOTOGRAF = TxtFotograf.Text;
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;

            db.SaveChanges();

            MessageBox.Show("Personel Başarıyla Güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            PubPesonelListesiTimer.Enabled = true;
        }

        private void BtnPinle_Click(object sender, EventArgs e)
        {
            if(TxtPinle.Text != "" && (comboBoxEdit1.SelectedIndex == 0 || comboBoxEdit1.SelectedIndex == 1 || comboBoxEdit1.SelectedIndex == 2 || comboBoxEdit1.SelectedIndex == 3))
            {
                int id = int.Parse(TxtPinle.Text);

                if (comboBoxEdit1.SelectedIndex == 0)
                {
                    pinliPersonel(id);

                    labelControl10.Text = lblAdSoyad;
                    labelControl11.Text = lblDepartman;
                    labelControl8.Text = lblMail;
                }
                else if (comboBoxEdit1.SelectedIndex == 1)
                {
                    pinliPersonel(id);

                    labelControl14.Text = lblAdSoyad;
                    labelControl15.Text = lblDepartman;
                    labelControl13.Text = lblMail;
                }
                else if (comboBoxEdit1.SelectedIndex == 2)
                {
                    pinliPersonel(id);

                    labelControl21.Text = lblAdSoyad;
                    labelControl22.Text = lblDepartman;
                    labelControl20.Text = lblMail;
                }
                else
                {
                    pinliPersonel(id);

                    labelControl27.Text = lblAdSoyad;
                    labelControl28.Text = lblDepartman;
                    labelControl26.Text = lblMail;
                }

                TxtPinle.Text = "";
                comboBoxEdit1.Text = "Pin";
            }
            else
            {
                MessageBox.Show("Bu hata mesajını alıyorsanız:\n\n" +
                                "1- Personeli ekleyeceğiniz pin değerini seçememiş\n" +
                                "2- Pine ekleyeceğiniz personelin ID'sini girmemiş\n\n" +
                                "Olabilirsiniz.\n\n" +
                                "LÜTFEN BU KURALLARA UYARAK İŞLEMİNİZİ TEKRARLAYINIZ", "Bilgilerndirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("DEPARTMAN").ToString();
            TxtFotograf.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
        }

        private void PersonelTimer_Tick(object sender, EventArgs e)
        {
            formLoad();

            if (Formlar.FrmYeniPersonel.YeniPersonelDegisiklikSayac > 0)
            {
                formLoad();
            }
            if (Formlar.FrmDepartmanListesi.DepartmanListesiDegisiklikSayac > 0)
            {
                formLoad();
            }

            PubPesonelListesiTimer.Enabled = false;
        }

        private void BtnPinKaldir_Click(object sender, EventArgs e)
        {
            string pinKaldirmaPin1Kontrol = labelControl10.Text;
            string pinKaldirmaPin2Kontrol = labelControl14.Text;
            string pinKaldirmaPin3Kontrol = labelControl21.Text;
            string pinKaldirmaPin4Kontrol = labelControl27.Text;

            if (comboBoxEdit1.SelectedIndex == 0 || comboBoxEdit1.SelectedIndex == 1 || comboBoxEdit1.SelectedIndex == 2 || comboBoxEdit1.SelectedIndex == 3)
            {
                if (comboBoxEdit1.SelectedIndex == 0)
                {
                    if (pinKaldirmaPin1Kontrol != "")
                    {
                        labelControl10.Text = "";
                        labelControl11.Text = "";
                        labelControl8.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(comboBoxEdit1.Text + " NUMARALI PİN ZATEN BOŞ...", "Bilgilerndirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxEdit1.Text = "Pin";
                    }
                }
                else if (comboBoxEdit1.SelectedIndex == 1)
                {
                    if (pinKaldirmaPin2Kontrol != "")
                    {
                        labelControl14.Text = "";
                        labelControl15.Text = "";
                        labelControl13.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(comboBoxEdit1.Text + " NUMARALI PİN ZATEN BOŞ...", "Bilgilerndirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxEdit1.Text = "Pin";
                    }
                }
                else if (comboBoxEdit1.SelectedIndex == 2)
                {
                    if (pinKaldirmaPin3Kontrol != "")
                    {
                        labelControl21.Text = "";
                        labelControl22.Text = "";
                        labelControl20.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(comboBoxEdit1.Text + " NUMARALI PİN ZATEN BOŞ...", "Bilgilerndirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxEdit1.Text = "Pin";
                    }
                }
                else if (comboBoxEdit1.SelectedIndex == 3)
                {
                    if (pinKaldirmaPin4Kontrol != "")
                    {
                        labelControl27.Text = "";
                        labelControl28.Text = "";
                        labelControl26.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(comboBoxEdit1.Text + " NUMARALI PİN ZATEN BOŞ...", "Bilgilerndirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxEdit1.Text = "Pin";
                    }
                }
            }
            else
            {
                MessageBox.Show("LÜTFEN SİLMEK İSTEDİĞİNİZ PİN NUMARASINI'SİNİ SECİNİZ...", "Bilgilerndirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            lookUpEdit1.Text = "";
            TxtFotograf.Text = "";
            TxtMail.Text = "";
            TxtTelefon.Text = "";
        }
    }
}
