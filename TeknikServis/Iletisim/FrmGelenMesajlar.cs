using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Iletisim
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            labelControl15.Text = db.TBLILETISIM.Count().ToString();
            labelControl13.Text = db.TBLILETISIM.Where(x => x.KONU == "Teşekkür").Count().ToString();
            labelControl17.Text = db.TBLILETISIM.Where(x => x.KONU == "Rica").Count().ToString();
            labelControl19.Text = db.TBLILETISIM.Where(x => x.KONU == "Şikayet").Count().ToString();

            gridControl1.DataSource = db.TBLILETISIM.Select(x => new
            {
                x.ID,
                x.ADSOYAD,
                x.MAIL,
                x.KONU,
                x.MESAJ
            }).ToList();
        }
    }
}
