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
            this.button_CleateDatabase = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_loginEmName = new System.Windows.Forms.Label();
            this.label_loginEmPosition = new System.Windows.Forms.Label();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 1019);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 16.125F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(10, 761);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(217, 171);
            this.button3.TabIndex = 2;
            this.button3.Text = "社員管理";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 16.125F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(10, 473);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(282, 228);
            this.button2.TabIndex = 2;
            this.button2.Text = "営業担当";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(13, 169);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 171);
            this.button1.TabIndex = 2;
            this.button1.Text = "物流担当";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label_loginEmPosition);
            this.panel2.Controls.Add(this.label_loginEmName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button_CleateDatabase);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1905, 144);
            this.panel2.TabIndex = 1;
            // 
            // button_CleateDatabase
            // 
            this.button_CleateDatabase.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button_CleateDatabase.Location = new System.Drawing.Point(1472, 33);
            this.button_CleateDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_CleateDatabase.Name = "button_CleateDatabase";
            this.button_CleateDatabase.Size = new System.Drawing.Size(195, 64);
            this.button_CleateDatabase.TabIndex = 2;
            this.button_CleateDatabase.Text = "データベース作成";
            this.button_CleateDatabase.UseVisualStyleBackColor = true;
            this.button_CleateDatabase.Click += new System.EventHandler(this.btn_CleateDabase_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(1703, 35);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.label1.Location = new System.Drawing.Point(690, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "販売管理";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(299, 148);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1610, 875);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "社員名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "役職";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "ログイン中";
            // 
            // label_loginEmName
            // 
            this.label_loginEmName.AutoSize = true;
            this.label_loginEmName.Location = new System.Drawing.Point(322, 48);
            this.label_loginEmName.Name = "label_loginEmName";
            this.label_loginEmName.Size = new System.Drawing.Size(0, 18);
            this.label_loginEmName.TabIndex = 6;
            // 
            // label_loginEmPosition
            // 
            this.label_loginEmPosition.AutoSize = true;
            this.label_loginEmPosition.Location = new System.Drawing.Point(307, 73);
            this.label_loginEmPosition.Name = "label_loginEmPosition";
            this.label_loginEmPosition.Size = new System.Drawing.Size(0, 18);
            this.label_loginEmPosition.TabIndex = 7;
            // 
            // F_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "F_Login";
            this.Text = "販売管理システム";
            this.Load += new System.EventHandler(this.F_Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button button_CleateDatabase;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_loginEmPosition;
        private System.Windows.Forms.Label label_loginEmName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

