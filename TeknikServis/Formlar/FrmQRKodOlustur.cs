using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace TeknikServis.Formlar
{
    public partial class FrmQRKodOlustur : Form
    {
        public FrmQRKodOlustur()
        {
            InitializeComponent();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            QRCodeEncoder QRKod = new QRCodeEncoder();
            pictureEdit1.Image = QRKod.Encode(TxtSeriNo.Text);
        }
    }
}
