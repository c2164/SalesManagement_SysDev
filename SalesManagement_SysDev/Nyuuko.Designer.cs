namespace SalesManagement_SysDev
{
    partial class Nyuuko
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
            this.button_Nyuuko_Kakutei = new System.Windows.Forms.Button();
            this.button_Kennsaku = new System.Windows.Forms.Button();
            this.button_Itirannhyouzi = new System.Windows.Forms.Button();
            this.button_Sakuzyo = new System.Windows.Forms.Button();
            this.button_Kuria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_Nyuuko_ID = new System.Windows.Forms.TextBox();
            this.textBox_Hattyuu_ID = new System.Windows.Forms.TextBox();
            this.textBox_Nyuukosyousai_ID = new System.Windows.Forms.TextBox();
            this.textBox_Hattyuu_Syain_Namae = new System.Windows.Forms.TextBox();
            this.numericUpDown_Suuryou = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Meka_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Syouhin_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Kakutei_Syain_Namae = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Suuryou)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Nyuuko_Kakutei
            // 
            this.button_Nyuuko_Kakutei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Nyuuko_Kakutei.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 10.875F, System.Drawing.FontStyle.Bold);
            this.button_Nyuuko_Kakutei.ForeColor = System.Drawing.Color.White;
            this.button_Nyuuko_Kakutei.Location = new System.Drawing.Point(84, 45);
            this.button_Nyuuko_Kakutei.Name = "button_Nyuuko_Kakutei";
            this.button_Nyuuko_Kakutei.Size = new System.Drawing.Size(210, 75);
            this.button_Nyuuko_Kakutei.TabIndex = 1;
            this.button_Nyuuko_Kakutei.Text = "入庫確定";
            this.button_Nyuuko_Kakutei.UseVisualStyleBackColor = false;
            this.button_Nyuuko_Kakutei.Click += new System.EventHandler(this.button_Nyuuko_Kakutei_Click);
            // 
            // button_Kennsaku
            // 
            this.button_Kennsaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kennsaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 10.875F, System.Drawing.FontStyle.Bold);
            this.button_Kennsaku.ForeColor = System.Drawing.Color.White;
            this.button_Kennsaku.Location = new System.Drawing.Point(363, 45);
            this.button_Kennsaku.Name = "button_Kennsaku";
            this.button_Kennsaku.Size = new System.Drawing.Size(220, 75);
            this.button_Kennsaku.TabIndex = 2;
            this.button_Kennsaku.Text = "🔍検索";
            this.button_Kennsaku.UseVisualStyleBackColor = false;
            this.button_Kennsaku.Click += new System.EventHandler(this.button_Kennsaku_Click);
            // 
            // button_Itirannhyouzi
            // 
            this.button_Itirannhyouzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itirannhyouzi.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 10.875F, System.Drawing.FontStyle.Bold);
            this.button_Itirannhyouzi.ForeColor = System.Drawing.Color.White;
            this.button_Itirannhyouzi.Location = new System.Drawing.Point(670, 45);
            this.button_Itirannhyouzi.Name = "button_Itirannhyouzi";
            this.button_Itirannhyouzi.Size = new System.Drawing.Size(224, 75);
            this.button_Itirannhyouzi.TabIndex = 3;
            this.button_Itirannhyouzi.Text = "📖一覧表示";
            this.button_Itirannhyouzi.UseVisualStyleBackColor = false;
            this.button_Itirannhyouzi.Click += new System.EventHandler(this.button_Itirannhyouzi_Click);
            // 
            // button_Sakuzyo
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 10.875F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(989, 45);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(223, 75);
            this.button_Sakuzyo.TabIndex = 4;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            this.button_Sakuzyo.Click += new System.EventHandler(this.button_Sakuzyo_Click);
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 10.875F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(1308, 45);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(218, 75);
            this.button_Kuria.TabIndex = 5;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label1.Location = new System.Drawing.Point(40, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "入庫ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label2.Location = new System.Drawing.Point(584, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "発注ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label3.Location = new System.Drawing.Point(1083, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 41);
            this.label3.TabIndex = 7;
            this.label3.Text = "入庫詳細ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label4.Location = new System.Drawing.Point(40, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 41);
            this.label4.TabIndex = 8;
            this.label4.Text = "発注社員名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label5.Location = new System.Drawing.Point(554, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 41);
            this.label5.TabIndex = 9;
            this.label5.Text = "確定社員名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label6.Location = new System.Drawing.Point(40, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 41);
            this.label6.TabIndex = 10;
            this.label6.Text = "メーカー名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label7.Location = new System.Drawing.Point(582, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 41);
            this.label7.TabIndex = 11;
            this.label7.Text = "商品名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label8.Location = new System.Drawing.Point(1134, 411);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 41);
            this.label8.TabIndex = 12;
            this.label8.Text = "数量";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 493);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1533, 351);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBox_Nyuuko_ID
            // 
            this.textBox_Nyuuko_ID.Location = new System.Drawing.Point(222, 196);
            this.textBox_Nyuuko_ID.MaxLength = 6;
            this.textBox_Nyuuko_ID.Name = "textBox_Nyuuko_ID";
            this.textBox_Nyuuko_ID.Size = new System.Drawing.Size(294, 31);
            this.textBox_Nyuuko_ID.TabIndex = 6;
            // 
            // textBox_Hattyuu_ID
            // 
            this.textBox_Hattyuu_ID.Location = new System.Drawing.Point(760, 197);
            this.textBox_Hattyuu_ID.MaxLength = 6;
            this.textBox_Hattyuu_ID.Name = "textBox_Hattyuu_ID";
            this.textBox_Hattyuu_ID.Size = new System.Drawing.Size(280, 31);
            this.textBox_Hattyuu_ID.TabIndex = 7;
            // 
            // textBox_Nyuukosyousai_ID
            // 
            this.textBox_Nyuukosyousai_ID.Location = new System.Drawing.Point(1275, 197);
            this.textBox_Nyuukosyousai_ID.MaxLength = 6;
            this.textBox_Nyuukosyousai_ID.Name = "textBox_Nyuukosyousai_ID";
            this.textBox_Nyuukosyousai_ID.Size = new System.Drawing.Size(251, 31);
            this.textBox_Nyuukosyousai_ID.TabIndex = 8;
            // 
            // textBox_Hattyuu_Syain_Namae
            // 
            this.textBox_Hattyuu_Syain_Namae.Location = new System.Drawing.Point(224, 303);
            this.textBox_Hattyuu_Syain_Namae.MaxLength = 50;
            this.textBox_Hattyuu_Syain_Namae.Name = "textBox_Hattyuu_Syain_Namae";
            this.textBox_Hattyuu_Syain_Namae.Size = new System.Drawing.Size(294, 31);
            this.textBox_Hattyuu_Syain_Namae.TabIndex = 9;
            // 
            // numericUpDown_Suuryou
            // 
            this.numericUpDown_Suuryou.Location = new System.Drawing.Point(1268, 420);
            this.numericUpDown_Suuryou.Name = "numericUpDown_Suuryou";
            this.numericUpDown_Suuryou.Size = new System.Drawing.Size(265, 31);
            this.numericUpDown_Suuryou.TabIndex = 13;
            // 
            // comboBox_Meka_Namae
            // 
            this.comboBox_Meka_Namae.FormattingEnabled = true;
            this.comboBox_Meka_Namae.Location = new System.Drawing.Point(222, 412);
            this.comboBox_Meka_Namae.Name = "comboBox_Meka_Namae";
            this.comboBox_Meka_Namae.Size = new System.Drawing.Size(294, 32);
            this.comboBox_Meka_Namae.TabIndex = 11;
            // 
            // comboBox_Syouhin_Namae
            // 
            this.comboBox_Syouhin_Namae.FormattingEnabled = true;
            this.comboBox_Syouhin_Namae.Location = new System.Drawing.Point(760, 411);
            this.comboBox_Syouhin_Namae.Name = "comboBox_Syouhin_Namae";
            this.comboBox_Syouhin_Namae.Size = new System.Drawing.Size(294, 32);
            this.comboBox_Syouhin_Namae.TabIndex = 12;
            // 
            // comboBox_Kakutei_Syain_Namae
            // 
            this.comboBox_Kakutei_Syain_Namae.FormattingEnabled = true;
            this.comboBox_Kakutei_Syain_Namae.Location = new System.Drawing.Point(760, 301);
            this.comboBox_Kakutei_Syain_Namae.Name = "comboBox_Kakutei_Syain_Namae";
            this.comboBox_Kakutei_Syain_Namae.Size = new System.Drawing.Size(294, 32);
            this.comboBox_Kakutei_Syain_Namae.TabIndex = 10;
            // 
            // Nyuuko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.comboBox_Kakutei_Syain_Namae);
            this.Controls.Add(this.comboBox_Syouhin_Namae);
            this.Controls.Add(this.comboBox_Meka_Namae);
            this.Controls.Add(this.numericUpDown_Suuryou);
            this.Controls.Add(this.textBox_Hattyuu_Syain_Namae);
            this.Controls.Add(this.textBox_Nyuukosyousai_ID);
            this.Controls.Add(this.textBox_Hattyuu_ID);
            this.Controls.Add(this.textBox_Nyuuko_ID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Kuria);
            this.Controls.Add(this.button_Sakuzyo);
            this.Controls.Add(this.button_Itirannhyouzi);
            this.Controls.Add(this.button_Kennsaku);
            this.Controls.Add(this.button_Nyuuko_Kakutei);
            this.Name = "Nyuuko";
            this.Size = new System.Drawing.Size(1610, 875);
            this.Load += new System.EventHandler(this.Nyuuko_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Suuryou)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Nyuuko_Kakutei;
        private System.Windows.Forms.Button button_Kennsaku;
        private System.Windows.Forms.Button button_Itirannhyouzi;
        private System.Windows.Forms.Button button_Sakuzyo;
        private System.Windows.Forms.Button button_Kuria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Nyuuko_ID;
        private System.Windows.Forms.TextBox textBox_Hattyuu_ID;
        private System.Windows.Forms.TextBox textBox_Nyuukosyousai_ID;
        private System.Windows.Forms.TextBox textBox_Hattyuu_Syain_Namae;
        private System.Windows.Forms.NumericUpDown numericUpDown_Suuryou;
        private System.Windows.Forms.ComboBox comboBox_Meka_Namae;
        private System.Windows.Forms.ComboBox comboBox_Syouhin_Namae;
        private System.Windows.Forms.ComboBox comboBox_Kakutei_Syain_Namae;
    }
}
