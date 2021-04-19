
namespace TeknikServis.Formlar
{
    partial class FrmDetayliFaturaSorgulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetayliFaturaSorgulama));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TxtID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSeri = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSiraNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.BtnAra = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSiraNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 54);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1927, 999);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.Salmon;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(79, 15);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(181, 22);
            this.TxtID.TabIndex = 35;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(11, 18);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(62, 16);
            this.labelControl7.TabIndex = 34;
            this.labelControl7.Text = "Fatura ID :";
            // 
            // TxtSeri
            // 
            this.TxtSeri.Location = new System.Drawing.Point(340, 15);
            this.TxtSeri.Name = "TxtSeri";
            this.TxtSeri.Properties.BeepOnError = false;
            this.TxtSeri.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.TxtSeri.Properties.MaskSettings.Set("mask", "A");
            this.TxtSeri.Properties.MaskSettings.Set("placeholder", '_');
            this.TxtSeri.Properties.MaskSettings.Set("ignoreMaskBlank", true);
            this.TxtSeri.Properties.UseMaskAsDisplayFormat = true;
            this.TxtSeri.Size = new System.Drawing.Size(181, 22);
            this.TxtSeri.TabIndex = 37;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(283, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 16);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Seri No :";
            // 
            // TxtSiraNo
            // 
            this.TxtSiraNo.Location = new System.Drawing.Point(605, 15);
            this.TxtSiraNo.Name = "TxtSiraNo";
            this.TxtSiraNo.Properties.BeepOnError = false;
            this.TxtSiraNo.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.TxtSiraNo.Properties.MaskSettings.Set("mask", "000000");
            this.TxtSiraNo.Properties.UseMaskAsDisplayFormat = true;
            this.TxtSiraNo.Size = new System.Drawing.Size(181, 22);
            this.TxtSiraNo.TabIndex = 39;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(548, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 38;
            this.labelControl2.Text = "Sıra No :";
            // 
            // BtnAra
            // 
            this.BtnAra.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnAra.Location = new System.Drawing.Point(802, 5);
            this.BtnAra.Name = "BtnAra";
            this.BtnAra.Size = new System.Drawing.Size(181, 43);
            this.BtnAra.TabIndex = 40;
            this.BtnAra.Text = "Ara";
            this.BtnAra.Click += new System.EventHandler(this.BtnAra_Click);
            // 
            // FrmDetayliFaturaSorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.BtnAra);
            this.Controls.Add(this.TxtSiraNo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtSeri);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmDetayliFaturaSorgulama";
            this.Text = "FrmFaturaKalemleri";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSiraNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit TxtID;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit TxtSeri;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtSiraNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton BtnAra;
    }
}