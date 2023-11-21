namespace SalesManagement_SysDev
{
    partial class Eigyou
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
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tyuumon1 = new SalesManagement_SysDev.Tyuumon();
            this.zyutyuu1 = new SalesManagement_SysDev.Zyutyuu();
            this.kokyaku1 = new SalesManagement_SysDev.Kokyaku();
            this.nyuuka1 = new SalesManagement_SysDev.Nyuuka();
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
            this.splitContainer1.Panel1.Controls.Add(this.button6);
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nyuuka1);
            this.splitContainer1.Panel2.Controls.Add(this.tyuumon1);
            this.splitContainer1.Panel2.Controls.Add(this.zyutyuu1);
            this.splitContainer1.Panel2.Controls.Add(this.kokyaku1);
            this.splitContainer1.Size = new System.Drawing.Size(1579, 862);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(0, 756);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(337, 106);
            this.button6.TabIndex = 5;
            this.button6.Text = "売上管理";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 616);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(337, 106);
            this.button5.TabIndex = 4;
            this.button5.Text = "出荷管理";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 462);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(337, 106);
            this.button4.TabIndex = 3;
            this.button4.Text = "入荷管理";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(337, 106);
            this.button3.TabIndex = 2;
            this.button3.Text = "注文管理";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(337, 106);
            this.button2.TabIndex = 1;
            this.button2.Text = "受注管理";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(337, 106);
            this.button1.TabIndex = 0;
            this.button1.Text = "顧客管理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tyuumon1
            // 
            this.tyuumon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(184)))));
            this.tyuumon1.Location = new System.Drawing.Point(3, 3);
            this.tyuumon1.Name = "tyuumon1";
            this.tyuumon1.Size = new System.Drawing.Size(1579, 862);
            this.tyuumon1.TabIndex = 2;
            // 
            // zyutyuu1
            // 
            this.zyutyuu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(184)))));
            this.zyutyuu1.Location = new System.Drawing.Point(3, 3);
            this.zyutyuu1.Name = "zyutyuu1";
            this.zyutyuu1.Size = new System.Drawing.Size(1579, 862);
            this.zyutyuu1.TabIndex = 1;
            // 
            // kokyaku1
            // 
            this.kokyaku1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(184)))));
            this.kokyaku1.Location = new System.Drawing.Point(3, 0);
            this.kokyaku1.Name = "kokyaku1";
            this.kokyaku1.Size = new System.Drawing.Size(1579, 862);
            this.kokyaku1.TabIndex = 0;
            // 
            // nyuuka1
            // 
            this.nyuuka1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(184)))));
            this.nyuuka1.Location = new System.Drawing.Point(3, 3);
            this.nyuuka1.Name = "nyuuka1";
            this.nyuuka1.Size = new System.Drawing.Size(1579, 862);
            this.nyuuka1.TabIndex = 3;
            // 
            // Eigyou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Eigyou";
            this.Size = new System.Drawing.Size(1579, 862);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private Kokyaku kokyaku1;
        private Zyutyuu zyutyuu1;
        private Tyuumon tyuumon1;
        private Nyuuka nyuuka1;
    }
}
