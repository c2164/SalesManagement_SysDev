namespace SalesManagement_SysDev
{
    partial class Syukko
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
            this.button_Kennsaku = new System.Windows.Forms.Button();
            this.button_Itiranhyouzi = new System.Windows.Forms.Button();
            this.button_Sakuzyo = new System.Windows.Forms.Button();
            this.button_Kakutei = new System.Windows.Forms.Button();
            this.button_Kuria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_Syain = new System.Windows.Forms.TextBox();
            this.textBox_Zyutyuu_ID = new System.Windows.Forms.TextBox();
            this.textBox_Kakutei_Syain_Namae = new System.Windows.Forms.TextBox();
            this.textBox_Syukkosyousai_ID = new System.Windows.Forms.TextBox();
            this.comboBox_Eigyousyo = new System.Windows.Forms.ComboBox();
            this.comboBox_Kokyaku = new System.Windows.Forms.ComboBox();
            this.comboBox_Meka_Namae = new System.Windows.Forms.ComboBox();
            this.comboBoxSyouhin_Namae = new System.Windows.Forms.ComboBox();
            this.domainUpDown_Suuryou = new System.Windows.Forms.NumericUpDown();
            this.textBox_Syukko_ID = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.checkBox_Kakutei = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDown_Suuryou)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Kennsaku
            // 
            this.button_Kennsaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kennsaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kennsaku.ForeColor = System.Drawing.Color.White;
            this.button_Kennsaku.Location = new System.Drawing.Point(59, 22);
            this.button_Kennsaku.Margin = new System.Windows.Forms.Padding(2);
            this.button_Kennsaku.Name = "button_Kennsaku";
            this.button_Kennsaku.Size = new System.Drawing.Size(171, 56);
            this.button_Kennsaku.TabIndex = 1;
            this.button_Kennsaku.Text = "🔍検索";
            this.button_Kennsaku.UseVisualStyleBackColor = false;
            this.button_Kennsaku.Click += new System.EventHandler(this.button_Kennsaku_Click);
            // 
            // button_Itiranhyouzi
            // 
            this.button_Itiranhyouzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itiranhyouzi.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Itiranhyouzi.ForeColor = System.Drawing.Color.White;
            this.button_Itiranhyouzi.Location = new System.Drawing.Point(289, 22);
            this.button_Itiranhyouzi.Margin = new System.Windows.Forms.Padding(2);
            this.button_Itiranhyouzi.Name = "button_Itiranhyouzi";
            this.button_Itiranhyouzi.Size = new System.Drawing.Size(168, 56);
            this.button_Itiranhyouzi.TabIndex = 2;
            this.button_Itiranhyouzi.Text = "📖一覧表示";
            this.button_Itiranhyouzi.UseVisualStyleBackColor = false;
            this.button_Itiranhyouzi.Click += new System.EventHandler(this.button_Itiranhyouzi_Click);
            // 
            // button_Sakuzyo
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(523, 22);
            this.button_Sakuzyo.Margin = new System.Windows.Forms.Padding(2);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(165, 56);
            this.button_Sakuzyo.TabIndex = 3;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            this.button_Sakuzyo.Click += new System.EventHandler(this.button_Sakuzyo_Click);
            // 
            // button_Kakutei
            // 
            this.button_Kakutei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kakutei.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kakutei.ForeColor = System.Drawing.Color.White;
            this.button_Kakutei.Location = new System.Drawing.Point(751, 22);
            this.button_Kakutei.Margin = new System.Windows.Forms.Padding(2);
            this.button_Kakutei.Name = "button_Kakutei";
            this.button_Kakutei.Size = new System.Drawing.Size(183, 56);
            this.button_Kakutei.TabIndex = 4;
            this.button_Kakutei.Text = "出庫確定";
            this.button_Kakutei.UseVisualStyleBackColor = false;
            this.button_Kakutei.Click += new System.EventHandler(this.button_Kakutei_Click);
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(1005, 22);
            this.button_Kuria.Margin = new System.Windows.Forms.Padding(2);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(183, 56);
            this.button_Kuria.TabIndex = 5;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label1.Location = new System.Drawing.Point(54, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "出庫ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label2.Location = new System.Drawing.Point(418, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "営業所";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label3.Location = new System.Drawing.Point(786, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "注文社員名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label4.Location = new System.Drawing.Point(54, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "顧客名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label5.Location = new System.Drawing.Point(419, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 30);
            this.label5.TabIndex = 10;
            this.label5.Text = "受注ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label6.Location = new System.Drawing.Point(786, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "確定社員名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label7.Location = new System.Drawing.Point(22, 275);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 30);
            this.label7.TabIndex = 12;
            this.label7.Text = "出庫詳細ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label8.Location = new System.Drawing.Point(419, 273);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 30);
            this.label8.TabIndex = 13;
            this.label8.Text = "メーカー名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label9.Location = new System.Drawing.Point(812, 274);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 30);
            this.label9.TabIndex = 14;
            this.label9.Text = "商品名";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label10.Location = new System.Drawing.Point(77, 339);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 30);
            this.label10.TabIndex = 15;
            this.label10.Text = "数量";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 383);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1179, 263);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBox_Syain
            // 
            this.textBox_Syain.Location = new System.Drawing.Point(964, 145);
            this.textBox_Syain.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Syain.MaxLength = 50;
            this.textBox_Syain.Name = "textBox_Syain";
            this.textBox_Syain.Size = new System.Drawing.Size(191, 25);
            this.textBox_Syain.TabIndex = 8;
            // 
            // textBox_Zyutyuu_ID
            // 
            this.textBox_Zyutyuu_ID.Location = new System.Drawing.Point(535, 207);
            this.textBox_Zyutyuu_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Zyutyuu_ID.MaxLength = 6;
            this.textBox_Zyutyuu_ID.Name = "textBox_Zyutyuu_ID";
            this.textBox_Zyutyuu_ID.Size = new System.Drawing.Size(206, 25);
            this.textBox_Zyutyuu_ID.TabIndex = 10;
            // 
            // textBox_Kakutei_Syain_Namae
            // 
            this.textBox_Kakutei_Syain_Namae.Location = new System.Drawing.Point(964, 207);
            this.textBox_Kakutei_Syain_Namae.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Kakutei_Syain_Namae.MaxLength = 50;
            this.textBox_Kakutei_Syain_Namae.Name = "textBox_Kakutei_Syain_Namae";
            this.textBox_Kakutei_Syain_Namae.Size = new System.Drawing.Size(191, 25);
            this.textBox_Kakutei_Syain_Namae.TabIndex = 11;
            // 
            // textBox_Syukkosyousai_ID
            // 
            this.textBox_Syukkosyousai_ID.Location = new System.Drawing.Point(184, 280);
            this.textBox_Syukkosyousai_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Syukkosyousai_ID.MaxLength = 6;
            this.textBox_Syukkosyousai_ID.Name = "textBox_Syukkosyousai_ID";
            this.textBox_Syukkosyousai_ID.Size = new System.Drawing.Size(201, 25);
            this.textBox_Syukkosyousai_ID.TabIndex = 12;
            // 
            // comboBox_Eigyousyo
            // 
            this.comboBox_Eigyousyo.FormattingEnabled = true;
            this.comboBox_Eigyousyo.Location = new System.Drawing.Point(535, 137);
            this.comboBox_Eigyousyo.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Eigyousyo.Name = "comboBox_Eigyousyo";
            this.comboBox_Eigyousyo.Size = new System.Drawing.Size(206, 26);
            this.comboBox_Eigyousyo.TabIndex = 7;
            // 
            // comboBox_Kokyaku
            // 
            this.comboBox_Kokyaku.FormattingEnabled = true;
            this.comboBox_Kokyaku.Location = new System.Drawing.Point(184, 207);
            this.comboBox_Kokyaku.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Kokyaku.Name = "comboBox_Kokyaku";
            this.comboBox_Kokyaku.Size = new System.Drawing.Size(201, 26);
            this.comboBox_Kokyaku.TabIndex = 9;
            // 
            // comboBox_Meka_Namae
            // 
            this.comboBox_Meka_Namae.FormattingEnabled = true;
            this.comboBox_Meka_Namae.Location = new System.Drawing.Point(535, 281);
            this.comboBox_Meka_Namae.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Meka_Namae.Name = "comboBox_Meka_Namae";
            this.comboBox_Meka_Namae.Size = new System.Drawing.Size(206, 26);
            this.comboBox_Meka_Namae.TabIndex = 13;
            // 
            // comboBoxSyouhin_Namae
            // 
            this.comboBoxSyouhin_Namae.FormattingEnabled = true;
            this.comboBoxSyouhin_Namae.Location = new System.Drawing.Point(964, 281);
            this.comboBoxSyouhin_Namae.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSyouhin_Namae.Name = "comboBoxSyouhin_Namae";
            this.comboBoxSyouhin_Namae.Size = new System.Drawing.Size(191, 26);
            this.comboBoxSyouhin_Namae.TabIndex = 14;
            // 
            // domainUpDown_Suuryou
            // 
            this.domainUpDown_Suuryou.Location = new System.Drawing.Point(184, 346);
            this.domainUpDown_Suuryou.Margin = new System.Windows.Forms.Padding(2);
            this.domainUpDown_Suuryou.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.domainUpDown_Suuryou.Name = "domainUpDown_Suuryou";
            this.domainUpDown_Suuryou.Size = new System.Drawing.Size(200, 25);
            this.domainUpDown_Suuryou.TabIndex = 15;
            // 
            // textBox_Syukko_ID
            // 
            this.textBox_Syukko_ID.Location = new System.Drawing.Point(184, 139);
            this.textBox_Syukko_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Syukko_ID.MaxLength = 6;
            this.textBox_Syukko_ID.Name = "textBox_Syukko_ID";
            this.textBox_Syukko_ID.Size = new System.Drawing.Size(201, 25);
            this.textBox_Syukko_ID.TabIndex = 29;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton2.Location = new System.Drawing.Point(72, 83);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(145, 29);
            this.radioButton2.TabIndex = 46;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "検索可能項目";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton3.Location = new System.Drawing.Point(535, 83);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(145, 29);
            this.radioButton3.TabIndex = 47;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "削除必要項目";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton4.Location = new System.Drawing.Point(770, 82);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(145, 29);
            this.radioButton4.TabIndex = 48;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "確定必要項目";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // checkBox_Kakutei
            // 
            this.checkBox_Kakutei.AutoSize = true;
            this.checkBox_Kakutei.Location = new System.Drawing.Point(438, 347);
            this.checkBox_Kakutei.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_Kakutei.Name = "checkBox_Kakutei";
            this.checkBox_Kakutei.Size = new System.Drawing.Size(151, 22);
            this.checkBox_Kakutei.TabIndex = 17;
            this.checkBox_Kakutei.Text = "確定済みを含む";
            this.checkBox_Kakutei.UseVisualStyleBackColor = true;
            this.checkBox_Kakutei.CheckedChanged += new System.EventHandler(this.checkBox_Kakutei_CheckedChanged);
            // 
            // Syukko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.textBox_Syukko_ID);
            this.Controls.Add(this.checkBox_Kakutei);
            this.Controls.Add(this.domainUpDown_Suuryou);
            this.Controls.Add(this.comboBoxSyouhin_Namae);
            this.Controls.Add(this.comboBox_Meka_Namae);
            this.Controls.Add(this.comboBox_Kokyaku);
            this.Controls.Add(this.comboBox_Eigyousyo);
            this.Controls.Add(this.textBox_Syukkosyousai_ID);
            this.Controls.Add(this.textBox_Kakutei_Syain_Namae);
            this.Controls.Add(this.textBox_Zyutyuu_ID);
            this.Controls.Add(this.textBox_Syain);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Kuria);
            this.Controls.Add(this.button_Kakutei);
            this.Controls.Add(this.button_Sakuzyo);
            this.Controls.Add(this.button_Itiranhyouzi);
            this.Controls.Add(this.button_Kennsaku);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Syukko";
            this.Size = new System.Drawing.Size(1238, 656);
            this.Load += new System.EventHandler(this.Syukko_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDown_Suuryou)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Kennsaku;
        private System.Windows.Forms.Button button_Itiranhyouzi;
        private System.Windows.Forms.Button button_Sakuzyo;
        private System.Windows.Forms.Button button_Kakutei;
        private System.Windows.Forms.Button button_Kuria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Syain;
        private System.Windows.Forms.TextBox textBox_Zyutyuu_ID;
        private System.Windows.Forms.TextBox textBox_Kakutei_Syain_Namae;
        private System.Windows.Forms.TextBox textBox_Syukkosyousai_ID;
        private System.Windows.Forms.ComboBox comboBox_Eigyousyo;
        private System.Windows.Forms.ComboBox comboBox_Kokyaku;
        private System.Windows.Forms.ComboBox comboBox_Meka_Namae;
        private System.Windows.Forms.ComboBox comboBoxSyouhin_Namae;
        private System.Windows.Forms.NumericUpDown domainUpDown_Suuryou;
        private System.Windows.Forms.TextBox textBox_Syukko_ID;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.CheckBox checkBox_Kakutei;
    }
}
