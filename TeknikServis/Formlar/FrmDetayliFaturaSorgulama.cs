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
    public partial class FrmDetayliFaturaSorgulama : Form
    {
        public FrmDetayliFaturaSorgulama()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void BtnAra_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var seri = TxtSeri.Text;

      

            gridControl1.DataSource = (from x in db.TBLFATURADETAY
                                       join y in db.TBLFATURABILGI
                                       on x.FATURAID equals y.ID
                                       select new
                                       {
                                           y.ID,
                                           y.SERI,
                                           x.URUN,
                                           x.ADET,
                                           x.TUTAR,
                                           y.SAAT

                                       }).Where(y => y.SERI == seri && y.ID == id).ToList();



            //sİLİNEBİİLİR





        }
    }
}
