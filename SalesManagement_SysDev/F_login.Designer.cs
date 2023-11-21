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
            this.buturyuu1 = new SalesManagement_SysDev.Buturyuu();
            this.eigyou1 = new SalesManagement_SysDev.Eigyou();
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
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 1008);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(3, 778);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(300, 227);
            this.button3.TabIndex = 2;
            this.button3.Text = "社員管理";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(-3, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(306, 227);
            this.button2.TabIndex = 2;
            this.button2.Text = "営業担当";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(-6, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 227);
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
            this.panel2.Location = new System.Drawing.Point(4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1894, 143);
            this.panel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(1703, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 64);
            this.button4.TabIndex = 1;
            this.button4.Text = "👤ログイン";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 19.875F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(898, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "販売管理";
            // 
            // buturyuu1
            // 
            this.buturyuu1.Location = new System.Drawing.Point(307, 149);
            this.buturyuu1.Name = "buturyuu1";
            this.buturyuu1.Size = new System.Drawing.Size(1591, 862);
            this.buturyuu1.TabIndex = 2;
            // 
            // eigyou1
            // 
            this.eigyou1.Location = new System.Drawing.Point(303, 146);
            this.eigyou1.Name = "eigyou1";
            this.eigyou1.Size = new System.Drawing.Size(1592, 862);
            this.eigyou1.TabIndex = 3;
            // 
            // F_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.eigyou1);
            this.Controls.Add(this.buturyuu1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(6);
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
    }
}

