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
    public partial class FrmDovizKurlari : Form
    {
        public FrmDovizKurlari()
        {
            InitializeComponent();
        }

        private void FrmDovizKurlariFormu_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
