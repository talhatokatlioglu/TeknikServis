
namespace TeknikServis.Formlar
{
    partial class FrmYeniKategori
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYeniKategori));
            this.BtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.TxtUrunKategorisi = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtKategoriAdi = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrunKategorisi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKategoriAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.BtnKaydet.Appearance.Options.UseForeColor = true;
            this.BtnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnKaydet.Location = new System.Drawing.Point(124, 183);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKaydet.Size = new System.Drawing.Size(87, 70);
            this.BtnKaydet.TabIndex = 41;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnCikis
            // 
            this.BtnCikis.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.BtnCikis.Appearance.Options.UseForeColor = true;
            this.BtnCikis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnCikis.ImageOptions.Image")));
            this.BtnCikis.Location = new System.Drawing.Point(262, 183);
            this.BtnCikis.Name = "BtnCikis";
            this.BtnCikis.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnCikis.Size = new System.Drawing.Size(87, 70);
            this.BtnCikis.TabIndex = 40;
            this.BtnCikis.Click += new System.EventHandler(this.BtnCikis_Click);
            // 
            // TxtUrunKategorisi
            // 
            this.TxtUrunKategorisi.EditValue = "Yeni Kategori Ekleme";
            this.TxtUrunKategorisi.Location = new System.Drawing.Point(167, 28);
            this.TxtUrunKategorisi.Name = "TxtUrunKategorisi";
            this.TxtUrunKategorisi.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtUrunKategorisi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TxtUrunKategorisi.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.TxtUrunKategorisi.Properties.Appearance.Options.UseBackColor = true;
            this.TxtUrunKategorisi.Properties.Appearance.Options.UseFont = true;
            this.TxtUrunKategorisi.Properties.Appearance.Options.UseForeColor = true;
            this.TxtUrunKategorisi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TxtUrunKategorisi.Size = new System.Drawing.Size(208, 28);
            this.TxtUrunKategorisi.TabIndex = 29;
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.EditValue = ((object)(resources.GetObject("pictureEdit3.EditValue")));
            this.pictureEdit3.Location = new System.Drawing.Point(97, 12);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.pictureEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit3.Properties.ZoomPercent = 80D;
            this.pictureEdit3.Size = new System.Drawing.Size(64, 60);
            this.pictureEdit3.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(97, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 3);
            this.panel1.TabIndex = 24;
            // 
            // TxtKategoriAdi
            // 
            this.TxtKategoriAdi.EditValue = "Kategori Adı";
            this.TxtKategoriAdi.Location = new System.Drawing.Point(97, 126);
            this.TxtKategoriAdi.Name = "TxtKategoriAdi";
            this.TxtKategoriAdi.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtKategoriAdi.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.TxtKategoriAdi.Properties.Appearance.Options.UseBackColor = true;
            this.TxtKategoriAdi.Properties.Appearance.Options.UseForeColor = true;
            this.TxtKategoriAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TxtKategoriAdi.Size = new System.Drawing.Size(125, 20);
            this.TxtKategoriAdi.TabIndex = 23;
            this.TxtKategoriAdi.Click += new System.EventHandler(this.TxtUrunAdi_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(27, 101);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ZoomPercent = 80D;
            this.pictureEdit1.Size = new System.Drawing.Size(64, 60);
            this.pictureEdit1.TabIndex = 22;
            // 
            // FrmYeniKategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(455, 289);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnCikis);
            this.Controls.Add(this.TxtUrunKategorisi);
            this.Controls.Add(this.pictureEdit3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtKategoriAdi);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 150);
            this.Name = "FrmYeniKategori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmYeniKategori";
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrunKategorisi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKategoriAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnKaydet;
        private DevExpress.XtraEditors.SimpleButton BtnCikis;
        private DevExpress.XtraEditors.TextEdit TxtUrunKategorisi;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit TxtKategoriAdi;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}