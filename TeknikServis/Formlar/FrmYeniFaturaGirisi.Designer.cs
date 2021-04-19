
namespace TeknikServis.Formlar
{
    partial class FrmYeniFaturaGirisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYeniFaturaGirisi));
            this.TxtID = new DevExpress.XtraEditors.TextEdit();
            this.TxtTarih = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.TxtVergiDairesi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.BtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSaat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSiraNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSeri = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVergiDairesi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSaat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSiraNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeri.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(107, 24);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(181, 22);
            this.TxtID.TabIndex = 53;
            // 
            // TxtTarih
            // 
            this.TxtTarih.Location = new System.Drawing.Point(107, 108);
            this.TxtTarih.Name = "TxtTarih";
            this.TxtTarih.Properties.BeepOnError = false;
            this.TxtTarih.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.TxtTarih.Properties.MaskSettings.Set("mask", "d");
            this.TxtTarih.Size = new System.Drawing.Size(181, 22);
            this.TxtTarih.TabIndex = 52;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(56, 109);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(39, 16);
            this.labelControl12.TabIndex = 51;
            this.labelControl12.Text = "Tarih :";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.EditValue = "";
            this.lookUpEdit2.Location = new System.Drawing.Point(107, 220);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Properties.DisplayMember = "PERSONEL";
            this.lookUpEdit2.Properties.ValueMember = "ID";
            this.lookUpEdit2.Size = new System.Drawing.Size(181, 22);
            this.lookUpEdit2.TabIndex = 50;
            // 
            // TxtVergiDairesi
            // 
            this.TxtVergiDairesi.Location = new System.Drawing.Point(107, 162);
            this.TxtVergiDairesi.Name = "TxtVergiDairesi";
            this.TxtVergiDairesi.Size = new System.Drawing.Size(181, 22);
            this.TxtVergiDairesi.TabIndex = 49;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(13, 165);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(82, 16);
            this.labelControl8.TabIndex = 48;
            this.labelControl8.Text = "Vergi Dairesi :";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(74, 27);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(21, 16);
            this.labelControl7.TabIndex = 46;
            this.labelControl7.Text = "ID :";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnKaydet.Location = new System.Drawing.Point(107, 279);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(181, 43);
            this.BtnKaydet.TabIndex = 43;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.EditValue = "";
            this.lookUpEdit1.Location = new System.Drawing.Point(107, 190);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.DisplayMember = "CARI";
            this.lookUpEdit1.Properties.ValueMember = "ID";
            this.lookUpEdit1.Size = new System.Drawing.Size(181, 22);
            this.lookUpEdit1.TabIndex = 42;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(37, 221);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 16);
            this.labelControl5.TabIndex = 41;
            this.labelControl5.Text = "Personel :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(63, 193);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 16);
            this.labelControl4.TabIndex = 40;
            this.labelControl4.Text = "Cari :";
            // 
            // TxtSaat
            // 
            this.TxtSaat.Location = new System.Drawing.Point(107, 134);
            this.TxtSaat.Name = "TxtSaat";
            this.TxtSaat.Properties.BeepOnError = false;
            this.TxtSaat.Size = new System.Drawing.Size(181, 22);
            this.TxtSaat.TabIndex = 39;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(60, 137);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 16);
            this.labelControl3.TabIndex = 38;
            this.labelControl3.Text = "Saat :";
            // 
            // TxtSiraNo
            // 
            this.TxtSiraNo.Location = new System.Drawing.Point(107, 80);
            this.TxtSiraNo.Name = "TxtSiraNo";
            this.TxtSiraNo.Size = new System.Drawing.Size(181, 22);
            this.TxtSiraNo.TabIndex = 37;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(44, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Sıra No :";
            // 
            // TxtSeri
            // 
            this.TxtSeri.Location = new System.Drawing.Point(107, 52);
            this.TxtSeri.Name = "TxtSeri";
            this.TxtSeri.Size = new System.Drawing.Size(181, 22);
            this.TxtSeri.TabIndex = 35;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(63, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 16);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Seri :";
            // 
            // FrmYeniFaturaGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 358);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.TxtTarih);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lookUpEdit2);
            this.Controls.Add(this.TxtVergiDairesi);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.TxtSaat);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TxtSiraNo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtSeri);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmYeniFaturaGirisi";
            this.Text = "FrmYeniFaturaGirisi";
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVergiDairesi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSaat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSiraNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeri.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtID;
        private DevExpress.XtraEditors.TextEdit TxtTarih;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private DevExpress.XtraEditors.TextEdit TxtVergiDairesi;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton BtnKaydet;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit TxtSaat;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TxtSiraNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtSeri;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}