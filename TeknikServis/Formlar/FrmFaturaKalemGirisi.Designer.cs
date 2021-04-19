
namespace TeknikServis.Formlar
{
    partial class FrmFaturaKalemGirisi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFaturaKalemGirisi));
            this.CariListesiTimer = new System.Windows.Forms.Timer(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.TxtID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.BtnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.BtnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtUrun = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.TxtAdet = new DevExpress.XtraEditors.TextEdit();
            this.TxtFiyat = new DevExpress.XtraEditors.TextEdit();
            this.TxtTutar = new DevExpress.XtraEditors.TextEdit();
            this.TxtFaturaID = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAdet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFaturaID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // CariListesiTimer
            // 
            this.CariListesiTimer.Interval = 700;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.Salmon;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(-5, 1);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1439, 1053);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(168, 39);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(181, 22);
            this.TxtID.TabIndex = 33;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(126, 124);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(36, 16);
            this.labelControl12.TabIndex = 31;
            this.labelControl12.Text = "Fiyat :";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(100, 180);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 16);
            this.labelControl8.TabIndex = 28;
            this.labelControl8.Text = "Fatura ID :";
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnTemizle.ImageOptions.Image")));
            this.BtnTemizle.Location = new System.Drawing.Point(54, 229);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(108, 40);
            this.BtnTemizle.TabIndex = 21;
            this.BtnTemizle.Text = "TEMİZLE";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(141, 42);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(21, 16);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "ID :";
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.ImageOptions.Image")));
            this.BtnGuncelle.Location = new System.Drawing.Point(168, 325);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(181, 43);
            this.BtnGuncelle.TabIndex = 17;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.ImageOptions.Image")));
            this.BtnSil.Location = new System.Drawing.Point(168, 276);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(181, 43);
            this.BtnSil.TabIndex = 16;
            this.BtnSil.Text = "SİL";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnKaydet.Location = new System.Drawing.Point(168, 227);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(181, 43);
            this.BtnKaydet.TabIndex = 15;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(122, 152);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Tutar :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(127, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Adet :";
            // 
            // TxtUrun
            // 
            this.TxtUrun.Location = new System.Drawing.Point(168, 67);
            this.TxtUrun.Name = "TxtUrun";
            this.TxtUrun.Size = new System.Drawing.Size(181, 22);
            this.TxtUrun.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(126, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Ürün :";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.Controls.Add(this.TxtFaturaID);
            this.groupControl1.Controls.Add(this.TxtTutar);
            this.groupControl1.Controls.Add(this.TxtFiyat);
            this.groupControl1.Controls.Add(this.TxtAdet);
            this.groupControl1.Controls.Add(this.TxtID);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.BtnTemizle);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.BtnGuncelle);
            this.groupControl1.Controls.Add(this.BtnSil);
            this.groupControl1.Controls.Add(this.BtnKaydet);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.TxtUrun);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(1440, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(490, 1016);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "FATURA İŞLEMLERİ";
            // 
            // TxtAdet
            // 
            this.TxtAdet.Location = new System.Drawing.Point(168, 95);
            this.TxtAdet.Name = "TxtAdet";
            this.TxtAdet.Size = new System.Drawing.Size(181, 22);
            this.TxtAdet.TabIndex = 34;
            // 
            // TxtFiyat
            // 
            this.TxtFiyat.Location = new System.Drawing.Point(168, 121);
            this.TxtFiyat.Name = "TxtFiyat";
            this.TxtFiyat.Size = new System.Drawing.Size(181, 22);
            this.TxtFiyat.TabIndex = 35;
            // 
            // TxtTutar
            // 
            this.TxtTutar.Location = new System.Drawing.Point(168, 149);
            this.TxtTutar.Name = "TxtTutar";
            this.TxtTutar.Size = new System.Drawing.Size(181, 22);
            this.TxtTutar.TabIndex = 36;
            // 
            // TxtFaturaID
            // 
            this.TxtFaturaID.Location = new System.Drawing.Point(168, 177);
            this.TxtFaturaID.Name = "TxtFaturaID";
            this.TxtFaturaID.Size = new System.Drawing.Size(181, 22);
            this.TxtFaturaID.TabIndex = 37;
            // 
            // FrmFaturaKalemGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmFaturaKalemGirisi";
            this.Text = "FrmFaturaKalemGirisi";
            this.Activated += new System.EventHandler(this.FrmFaturaKalemGirisi_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAdet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFaturaID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CariListesiTimer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.TextEdit TxtID;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton BtnTemizle;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton BtnGuncelle;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.SimpleButton BtnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtUrun;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit TxtFaturaID;
        private DevExpress.XtraEditors.TextEdit TxtTutar;
        private DevExpress.XtraEditors.TextEdit TxtFiyat;
        private DevExpress.XtraEditors.TextEdit TxtAdet;
    }
}