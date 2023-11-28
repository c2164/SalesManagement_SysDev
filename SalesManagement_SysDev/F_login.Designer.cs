namespace SalesManagement_SysDev
{
    partial class F_Login
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.syain1 = new SalesManagement_SysDev.Syain();
            this.eigyou1 = new SalesManagement_SysDev.Eigyou();
            this.buturyuu1 = new SalesManagement_SysDev.Buturyuu();
            this.roguin1 = new SalesManagement_SysDev.Roguin();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 1008);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(2, 778);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(299, 228);
            this.button3.TabIndex = 2;
            this.button3.Text = "社員管理";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(-2, 458);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(306, 228);
            this.button2.TabIndex = 2;
            this.button2.Text = "営業担当";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(-6, 144);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 228);
            this.button1.TabIndex = 2;
            this.button1.Text = "物流担当";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1894, 144);
            this.panel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(1703, 34);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(169, 64);
            this.button4.TabIndex = 1;
            this.button4.Text = "👤ログイン";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 19.875F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(897, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "販売管理";
            // 
            // syain1
            // 
            this.syain1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(196)))));
            this.syain1.Location = new System.Drawing.Point(295, 148);
            this.syain1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.syain1.Name = "syain1";
            this.syain1.Size = new System.Drawing.Size(1603, 861);
            this.syain1.TabIndex = 4;
            // 
            // eigyou1
            // 
            this.eigyou1.Location = new System.Drawing.Point(296, 145);
            this.eigyou1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.eigyou1.Name = "eigyou1";
            this.eigyou1.Size = new System.Drawing.Size(1580, 861);
            this.eigyou1.TabIndex = 3;
            // 
            // buturyuu1
            // 
            this.buturyuu1.Location = new System.Drawing.Point(308, 148);
            this.buturyuu1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.buturyuu1.Name = "buturyuu1";
            this.buturyuu1.Size = new System.Drawing.Size(1590, 862);
            this.buturyuu1.TabIndex = 2;
            // 
            // roguin1
            // 
            this.roguin1.Location = new System.Drawing.Point(289, 145);
            this.roguin1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.roguin1.Name = "roguin1";
            this.roguin1.Size = new System.Drawing.Size(1603, 861);
            this.roguin1.TabIndex = 5;
            // 
            // F_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(3244, 2018);
            this.Controls.Add(this.roguin1);
            this.Controls.Add(this.syain1);
            this.Controls.Add(this.eigyou1);
            this.Controls.Add(this.buturyuu1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "F_Login";
            this.Text = "販売管理システム";
            this.Load += new System.EventHandler(this.F_Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private Buturyuu buturyuu1;
        private Eigyou eigyou1;
        private Syain syain1;
        private Roguin roguin1;
    }
}

