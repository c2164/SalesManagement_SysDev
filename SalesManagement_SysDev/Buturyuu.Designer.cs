﻿namespace SalesManagement_SysDev
{
    partial class Buturyuu
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_Nyuuko_Kannri = new System.Windows.Forms.Button();
            this.button_Hattyuu_Kannri = new System.Windows.Forms.Button();
            this.button_Syukko_Kannri = new System.Windows.Forms.Button();
            this.button_Zaiko_Kannri = new System.Windows.Forms.Button();
            this.button_Syouhin_Kannri = new System.Windows.Forms.Button();
            this.syouhin1 = new SalesManagement_SysDev.Syouhin();
            this.zaiko1 = new SalesManagement_SysDev.Zaiko();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_Nyuuko_Kannri);
            this.splitContainer1.Panel1.Controls.Add(this.button_Hattyuu_Kannri);
            this.splitContainer1.Panel1.Controls.Add(this.button_Syukko_Kannri);
            this.splitContainer1.Panel1.Controls.Add(this.button_Zaiko_Kannri);
            this.splitContainer1.Panel1.Controls.Add(this.button_Syouhin_Kannri);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zaiko1);
            this.splitContainer1.Panel2.Controls.Add(this.syouhin1);
            this.splitContainer1.Size = new System.Drawing.Size(1579, 862);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_Nyuuko_Kannri
            // 
            this.button_Nyuuko_Kannri.Location = new System.Drawing.Point(0, 753);
            this.button_Nyuuko_Kannri.Name = "button_Nyuuko_Kannri";
            this.button_Nyuuko_Kannri.Size = new System.Drawing.Size(337, 106);
            this.button_Nyuuko_Kannri.TabIndex = 4;
            this.button_Nyuuko_Kannri.Text = "入庫管理";
            this.button_Nyuuko_Kannri.UseVisualStyleBackColor = true;
            // 
            // button_Hattyuu_Kannri
            // 
            this.button_Hattyuu_Kannri.Location = new System.Drawing.Point(0, 569);
            this.button_Hattyuu_Kannri.Name = "button_Hattyuu_Kannri";
            this.button_Hattyuu_Kannri.Size = new System.Drawing.Size(337, 106);
            this.button_Hattyuu_Kannri.TabIndex = 3;
            this.button_Hattyuu_Kannri.Text = "発注管理";
            this.button_Hattyuu_Kannri.UseVisualStyleBackColor = true;
            // 
            // button_Syukko_Kannri
            // 
            this.button_Syukko_Kannri.Location = new System.Drawing.Point(0, 371);
            this.button_Syukko_Kannri.Name = "button_Syukko_Kannri";
            this.button_Syukko_Kannri.Size = new System.Drawing.Size(337, 106);
            this.button_Syukko_Kannri.TabIndex = 2;
            this.button_Syukko_Kannri.Text = "出庫管理";
            this.button_Syukko_Kannri.UseVisualStyleBackColor = true;
            // 
            // button_Zaiko_Kannri
            // 
            this.button_Zaiko_Kannri.Location = new System.Drawing.Point(0, 191);
            this.button_Zaiko_Kannri.Name = "button_Zaiko_Kannri";
            this.button_Zaiko_Kannri.Size = new System.Drawing.Size(337, 106);
            this.button_Zaiko_Kannri.TabIndex = 1;
            this.button_Zaiko_Kannri.Text = "在庫管理";
            this.button_Zaiko_Kannri.UseVisualStyleBackColor = true;
            this.button_Zaiko_Kannri.Click += new System.EventHandler(this.button_Zaiko_Kannri_Click);
            // 
            // button_Syouhin_Kannri
            // 
            this.button_Syouhin_Kannri.Location = new System.Drawing.Point(0, 3);
            this.button_Syouhin_Kannri.Name = "button_Syouhin_Kannri";
            this.button_Syouhin_Kannri.Size = new System.Drawing.Size(337, 106);
            this.button_Syouhin_Kannri.TabIndex = 0;
            this.button_Syouhin_Kannri.Text = "商品管理";
            this.button_Syouhin_Kannri.UseVisualStyleBackColor = true;
            this.button_Syouhin_Kannri.Click += new System.EventHandler(this.button_Syouhin_Kannri_Click);
            // 
            // syouhin1
            // 
            this.syouhin1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
            this.syouhin1.Location = new System.Drawing.Point(3, 0);
            this.syouhin1.Name = "syouhin1";
            this.syouhin1.Size = new System.Drawing.Size(1579, 862);
            this.syouhin1.TabIndex = 0;
            // 
            // zaiko1
            // 
            this.zaiko1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
            this.zaiko1.Location = new System.Drawing.Point(3, 3);
            this.zaiko1.Name = "zaiko1";
            this.zaiko1.Size = new System.Drawing.Size(1579, 862);
            this.zaiko1.TabIndex = 1;
            // 
            // Buturyuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Buturyuu";
            this.Size = new System.Drawing.Size(1579, 862);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_Nyuuko_Kannri;
        private System.Windows.Forms.Button button_Hattyuu_Kannri;
        private System.Windows.Forms.Button button_Syukko_Kannri;
        private System.Windows.Forms.Button button_Zaiko_Kannri;
        private System.Windows.Forms.Button button_Syouhin_Kannri;
        private Syouhin syouhin1;
        private Zaiko zaiko1;
    }
}
