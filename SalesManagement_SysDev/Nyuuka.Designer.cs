﻿namespace SalesManagement_SysDev
{
    partial class Nyuuka
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

        

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_Kokyaku_Namae = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioButton_Kakutei = new System.Windows.Forms.RadioButton();
            this.radioButton_Mikakutei = new System.Windows.Forms.RadioButton();
            this.numericUpDown_Suuryou = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Meka_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Syouhin_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Eigyousyo = new System.Windows.Forms.ComboBox();
            this.textBox_Nyuukasyousai_ID = new System.Windows.Forms.TextBox();
            this.textBox_Kakutei_Syain_Namae = new System.Windows.Forms.TextBox();
            this.textBox_Zyutyuu_ID = new System.Windows.Forms.TextBox();
            this.textBox_Nyuuka_Syain_Namae = new System.Windows.Forms.TextBox();
            this.textBox_Nyuuka_ID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Kuria = new System.Windows.Forms.Button();
            this.button_Nyuuka_Kakutei = new System.Windows.Forms.Button();
            this.button_Sakuzyo = new System.Windows.Forms.Button();
            this.button_Kensaku = new System.Windows.Forms.Button();
            this.button_Itirannhyouzi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Suuryou)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_Kokyaku_Namae
            // 
            this.comboBox_Kokyaku_Namae.FormattingEnabled = true;
            this.comboBox_Kokyaku_Namae.Location = new System.Drawing.Point(202, 132);
            this.comboBox_Kokyaku_Namae.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Kokyaku_Namae.Name = "comboBox_Kokyaku_Namae";
            this.comboBox_Kokyaku_Namae.Size = new System.Drawing.Size(265, 32);
            this.comboBox_Kokyaku_Namae.TabIndex = 84;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 373);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1533, 351);
            this.dataGridView1.TabIndex = 83;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // radioButton_Kakutei
            // 
            this.radioButton_Kakutei.AutoSize = true;
            this.radioButton_Kakutei.Location = new System.Drawing.Point(602, 339);
            this.radioButton_Kakutei.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton_Kakutei.Name = "radioButton_Kakutei";
            this.radioButton_Kakutei.Size = new System.Drawing.Size(134, 28);
            this.radioButton_Kakutei.TabIndex = 82;
            this.radioButton_Kakutei.TabStop = true;
            this.radioButton_Kakutei.Text = "確定済み";
            this.radioButton_Kakutei.UseVisualStyleBackColor = true;
            // 
            // radioButton_Mikakutei
            // 
            this.radioButton_Mikakutei.AutoSize = true;
            this.radioButton_Mikakutei.Location = new System.Drawing.Point(465, 339);
            this.radioButton_Mikakutei.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton_Mikakutei.Name = "radioButton_Mikakutei";
            this.radioButton_Mikakutei.Size = new System.Drawing.Size(113, 28);
            this.radioButton_Mikakutei.TabIndex = 81;
            this.radioButton_Mikakutei.TabStop = true;
            this.radioButton_Mikakutei.Text = "未確定";
            this.radioButton_Mikakutei.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_Suuryou
            // 
            this.numericUpDown_Suuryou.Location = new System.Drawing.Point(265, 449);
            this.numericUpDown_Suuryou.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});

            this.numericUpDown_Suuryou.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Suuryou.Name = "numericUpDown_Suuryou";
            this.numericUpDown_Suuryou.Size = new System.Drawing.Size(265, 31);
            this.numericUpDown_Suuryou.TabIndex = 80;
            // 
            // comboBox_Meka_Namae
            // 
            this.comboBox_Meka_Namae.FormattingEnabled = true;
            this.comboBox_Meka_Namae.Location = new System.Drawing.Point(952, 277);
            this.comboBox_Meka_Namae.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Meka_Namae.Name = "comboBox_Meka_Namae";
            this.comboBox_Meka_Namae.Size = new System.Drawing.Size(256, 32);
            this.comboBox_Meka_Namae.TabIndex = 79;
            // 
            // comboBox_Syouhin_Namae
            // 
            this.comboBox_Syouhin_Namae.FormattingEnabled = true;
            this.comboBox_Syouhin_Namae.Location = new System.Drawing.Point(952, 201);
            this.comboBox_Syouhin_Namae.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Syouhin_Namae.Name = "comboBox_Syouhin_Namae";
            this.comboBox_Syouhin_Namae.Size = new System.Drawing.Size(256, 32);
            this.comboBox_Syouhin_Namae.TabIndex = 78;
            // 
            // comboBox_Eigyousyo
            // 
            this.comboBox_Eigyousyo.FormattingEnabled = true;
            this.comboBox_Eigyousyo.Location = new System.Drawing.Point(952, 130);
            this.comboBox_Eigyousyo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Eigyousyo.Name = "comboBox_Eigyousyo";
            this.comboBox_Eigyousyo.Size = new System.Drawing.Size(256, 32);
            this.comboBox_Eigyousyo.TabIndex = 77;
            // 
            // textBox_Nyuukasyousai_ID
            // 
            this.textBox_Nyuukasyousai_ID.Location = new System.Drawing.Point(759, 361);
            this.textBox_Nyuukasyousai_ID.MaxLength = 6;
            this.textBox_Nyuukasyousai_ID.Location = new System.Drawing.Point(584, 271);
            this.textBox_Nyuukasyousai_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Nyuukasyousai_ID.Name = "textBox_Nyuukasyousai_ID";
            this.textBox_Nyuukasyousai_ID.Size = new System.Drawing.Size(273, 31);
            this.textBox_Nyuukasyousai_ID.TabIndex = 76;
            // 
            // textBox_Kakutei_Syain_Namae
            // 
            this.textBox_Kakutei_Syain_Namae.Location = new System.Drawing.Point(263, 361);
            this.textBox_Kakutei_Syain_Namae.MaxLength = 50;
            this.textBox_Kakutei_Syain_Namae.Location = new System.Drawing.Point(202, 271);
            this.textBox_Kakutei_Syain_Namae.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Kakutei_Syain_Namae.Name = "textBox_Kakutei_Syain_Namae";
            this.textBox_Kakutei_Syain_Namae.Size = new System.Drawing.Size(265, 31);
            this.textBox_Kakutei_Syain_Namae.TabIndex = 75;
            // 
            // textBox_Zyutyuu_ID
            // 
            this.textBox_Zyutyuu_ID.Location = new System.Drawing.Point(759, 268);
            this.textBox_Zyutyuu_ID.MaxLength = 6;
            this.textBox_Zyutyuu_ID.Location = new System.Drawing.Point(584, 201);
            this.textBox_Zyutyuu_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Zyutyuu_ID.Name = "textBox_Zyutyuu_ID";
            this.textBox_Zyutyuu_ID.Size = new System.Drawing.Size(273, 31);
            this.textBox_Zyutyuu_ID.TabIndex = 74;
            // 
            // textBox_Nyuuka_Syain_Namae
            // 
            this.textBox_Nyuuka_Syain_Namae.Location = new System.Drawing.Point(263, 268);
            this.textBox_Nyuuka_Syain_Namae.MaxLength = 50;
            this.textBox_Nyuuka_Syain_Namae.Location = new System.Drawing.Point(202, 201);
            this.textBox_Nyuuka_Syain_Namae.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Nyuuka_Syain_Namae.Name = "textBox_Nyuuka_Syain_Namae";
            this.textBox_Nyuuka_Syain_Namae.Size = new System.Drawing.Size(265, 31);
            this.textBox_Nyuuka_Syain_Namae.TabIndex = 73;
            // 
            // textBox_Nyuuka_ID
            // 
            this.textBox_Nyuuka_ID.Location = new System.Drawing.Point(759, 176);
            this.textBox_Nyuuka_ID.MaxLength = 6;
            this.textBox_Nyuuka_ID.Location = new System.Drawing.Point(584, 132);
            this.textBox_Nyuuka_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Nyuuka_ID.Name = "textBox_Nyuuka_ID";
            this.textBox_Nyuuka_ID.Size = new System.Drawing.Size(273, 31);
            this.textBox_Nyuuka_ID.TabIndex = 72;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label10.Location = new System.Drawing.Point(75, 330);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 41);
            this.label10.TabIndex = 71;
            this.label10.Text = "数量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label9.Location = new System.Drawing.Point(835, 265);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 41);
            this.label9.TabIndex = 70;
            this.label9.Text = "メーカー名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label8.Location = new System.Drawing.Point(432, 271);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 41);
            this.label8.TabIndex = 69;
            this.label8.Text = "入荷詳細ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label7.Location = new System.Drawing.Point(42, 265);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 41);
            this.label7.TabIndex = 68;
            this.label7.Text = "確定社員名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label6.Location = new System.Drawing.Point(850, 195);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 41);
            this.label6.TabIndex = 67;
            this.label6.Text = "商品名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label5.Location = new System.Drawing.Point(468, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 41);
            this.label5.TabIndex = 66;
            this.label5.Text = "受注ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label4.Location = new System.Drawing.Point(42, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 30);
            this.label4.TabIndex = 65;
            this.label4.Text = "入荷社員名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label3.Location = new System.Drawing.Point(842, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 41);
            this.label3.TabIndex = 64;
            this.label3.Text = "営業所";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label2.Location = new System.Drawing.Point(468, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 41);
            this.label2.TabIndex = 63;
            this.label2.Text = "入荷ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label1.Location = new System.Drawing.Point(87, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 41);
            this.label1.TabIndex = 62;
            this.label1.Text = "顧客名";
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(993, 20);
            this.button_Kuria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(229, 75);
            this.button_Kuria.TabIndex = 61;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // button_Nyuuka_Kakutei
            // 
            this.button_Nyuuka_Kakutei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Nyuuka_Kakutei.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Nyuuka_Kakutei.ForeColor = System.Drawing.Color.White;
            this.button_Nyuuka_Kakutei.Location = new System.Drawing.Point(1005, 27);
            this.button_Nyuuka_Kakutei.Name = "button_Nyuuka_Kakutei";
            this.button_Nyuuka_Kakutei.Size = new System.Drawing.Size(229, 75);
            this.button_Nyuuka_Kakutei.TabIndex = 60;
            this.button_Nyuuka_Kakutei.Text = "入荷確定";
            this.button_Nyuuka_Kakutei.UseVisualStyleBackColor = false;
            this.button_Nyuuka_Kakutei.Click += new System.EventHandler(this.button_Nyuuka_Kakutei_Click);
            // 
            // button_Sakuzyo
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(547, 20);
            this.button_Sakuzyo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(229, 75);
            this.button_Sakuzyo.TabIndex = 59;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            this.button_Sakuzyo.Click += new System.EventHandler(this.button_Sakuzyo_Click);
            // 
            // button_Kensaku
            // 
            this.button_Kensaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kensaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kensaku.ForeColor = System.Drawing.Color.White;
            this.button_Kensaku.Location = new System.Drawing.Point(299, 20);
            this.button_Kensaku.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Kensaku.Name = "button_Kensaku";
            this.button_Kensaku.Size = new System.Drawing.Size(229, 75);
            this.button_Kensaku.TabIndex = 58;
            this.button_Kensaku.Text = "🔍検索";
            this.button_Kensaku.UseVisualStyleBackColor = false;
            this.button_Kensaku.Click += new System.EventHandler(this.button_Kensaku_Click);
            // 
            // button_Itirannhyouzi
            // 
            this.button_Itirannhyouzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itirannhyouzi.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Itirannhyouzi.ForeColor = System.Drawing.Color.White;
            this.button_Itirannhyouzi.Location = new System.Drawing.Point(39, 20);
            this.button_Itirannhyouzi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Itirannhyouzi.Name = "button_Itirannhyouzi";
            this.button_Itirannhyouzi.Size = new System.Drawing.Size(229, 75);
            this.button_Itirannhyouzi.TabIndex = 57;
            this.button_Itirannhyouzi.Text = "📖一覧表示";
            this.button_Itirannhyouzi.UseVisualStyleBackColor = false;
            this.button_Itirannhyouzi.Click += new System.EventHandler(this.button_Itirannhyouzi_Click);
            // 
            // Nyuuka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(184)))));
            this.Controls.Add(this.comboBox_Kokyaku_Namae);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radioButton_Kakutei);
            this.Controls.Add(this.radioButton_Mikakutei);
            this.Controls.Add(this.numericUpDown_Suuryou);
            this.Controls.Add(this.comboBox_Meka_Namae);
            this.Controls.Add(this.comboBox_Syouhin_Namae);
            this.Controls.Add(this.comboBox_Eigyousyo);
            this.Controls.Add(this.textBox_Nyuukasyousai_ID);
            this.Controls.Add(this.textBox_Kakutei_Syain_Namae);
            this.Controls.Add(this.textBox_Zyutyuu_ID);
            this.Controls.Add(this.textBox_Nyuuka_Syain_Namae);
            this.Controls.Add(this.textBox_Nyuuka_ID);
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
            this.Controls.Add(this.button_Nyuuka_Kakutei);
            this.Controls.Add(this.button_Sakuzyo);
            this.Controls.Add(this.button_Kensaku);
            this.Controls.Add(this.button_Itirannhyouzi);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Nyuuka";
            this.Size = new System.Drawing.Size(1238, 656);
            this.Load += new System.EventHandler(this.Nyuuka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Suuryou)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBox_Kokyaku_Namae;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButton_Kakutei;
        private System.Windows.Forms.RadioButton radioButton_Mikakutei;
        private System.Windows.Forms.NumericUpDown numericUpDown_Suuryou;
        private System.Windows.Forms.ComboBox comboBox_Meka_Namae;
        private System.Windows.Forms.ComboBox comboBox_Syouhin_Namae;
        private System.Windows.Forms.ComboBox comboBox_Eigyousyo;
        private System.Windows.Forms.TextBox textBox_Nyuukasyousai_ID;
        private System.Windows.Forms.TextBox textBox_Kakutei_Syain_Namae;
        private System.Windows.Forms.TextBox textBox_Zyutyuu_ID;
        private System.Windows.Forms.TextBox textBox_Nyuuka_Syain_Namae;
        private System.Windows.Forms.TextBox textBox_Nyuuka_ID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Kuria;
        private System.Windows.Forms.Button button_Nyuuka_Kakutei;
        private System.Windows.Forms.Button button_Sakuzyo;
        private System.Windows.Forms.Button button_Kensaku;
        private System.Windows.Forms.Button button_Itirannhyouzi;
    }
}
