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
    public partial class FrmAjanda : Form
    {
        public FrmAjanda()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        void formLoad()
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();//Durum = Okundu Bilgisi, Okunmadıysa 1.tabloya(Okunmayan Notlar) ekle
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();//Durum = Okundu Bilgisi, Okunduysa 2.tabloya(Okunan Notlar) ekle

            TxtID.Enabled = false;
        }

        private void FrmAjanda_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        void GetTiklaninlanSatirBilgileri(DevExpress.XtraGrid.Views.Grid.GridView liste)
        {
            TxtID.Text = liste.GetFocusedRowCellValue("ID").ToString();//gridView'in tiklanilan satırın değerini getir.
            TxtBaslik.Text = liste.GetFocusedRowCellValue("BASLIK").ToString();
            TxtIcerik.Text = liste.GetFocusedRowCellValue("ICERIK").ToString();
            checkEdit1.Checked = bool.Parse(liste.GetFocusedRowCellValue("DURUM").ToString());
            //Durumu çağırıyoruz true false şeklinde o yüzden bunu bool'a ceviriyoruz ve tik şeklinde tabloya geliyor
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)//Okunan notlar tablosunda Tıklanilan satır değiştirildğinde
        {
            GetTiklaninlanSatirBilgileri(gridView1);
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)//Okunmayan notlar tablosunda Tıklanilan satır değiştirildğinde
        {
            GetTiklaninlanSatirBilgileri(gridView2);
        }

        void Kaydet()
        {
            TBLNOTLARIM n = new TBLNOTLARIM();

            n.BASLIK = TxtBaslik.Text;
            n.ICERIK = TxtIcerik.Text;
            n.DURUM = checkEdit1.Checked;

            db.TBLNOTLARIM.Add(n);
            db.SaveChanges();

            MessageBox.Show("Not başarıyla kaydedilmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AjandaTimer.Enabled = true;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)//Okundu Bilgisi işaretlendiyse
            {
                Kaydet();
            }
            else
            {
                Kaydet();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)//Tüm alanları boşaltıp yeni not girişi yapılması için hazır duruma getirir
        {
            TxtID.Text = "";
            TxtBaslik.Text = "";
            TxtIcerik.Text = "";
            checkEdit1.Checked = false;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLNOTLARIM.Find(id);

            db.TBLNOTLARIM.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Not başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            AjandaTimer.Enabled = true;
        }

        void Guncelle()
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLNOTLARIM.Find(id);

            deger.BASLIK = TxtBaslik.Text;
            deger.ICERIK = TxtBaslik.Text;
            deger.DURUM = checkEdit1.Checked;//CheckEditin check halini al yani işaretli ise true yazar işaretlenmemiş ise false yazar.
            //checkEdit işaretli ise yani true ise notu okundu olarak günceller.İşaretli değilse false ise okumadı olarak günceller.

            db.SaveChanges();

            MessageBox.Show("Not başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            AjandaTimer.Enabled = true;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(checkEdit1.Checked == true)//Okundu Bilgisi işaretlendiyse
            {
                Guncelle();
            }
            else
            {
                Guncelle();
            }  
        }

        private void AjandaTimer_Tick(object sender, EventArgs e)
        {
            formLoad();
            AjandaTimer.Enabled = false;
        }
    }
}
