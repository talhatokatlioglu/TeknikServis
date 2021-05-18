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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var query = db.TBLADMIN.Where(x => x.KULLANICIAD == TxtKullaniciAdi.Text & x.SIFRE == TxtSifre.Text).Select(y=>y);

            if (query.Any())
            {
                Form1 Anasayfa = new Form1();
                Anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Enter(object sender, EventArgs e)
        {
            var query = db.TBLADMIN.Where(x => x.KULLANICIAD == TxtKullaniciAdi.Text & x.SIFRE == TxtSifre.Text).Select(y => y);

            if (query.Any())
            {
                Form1 Anasayfa = new Form1();
                Anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }
    }
}

