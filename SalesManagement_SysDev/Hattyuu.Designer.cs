﻿namespace SalesManagement_SysDev
{
    partial class Hattyuu
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Syouhin_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Meka_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Syain_Namae = new System.Windows.Forms.ComboBox();
            this.textBox_Hattyuusyousai = new System.Windows.Forms.TextBox();
            this.textBox_Suuryou = new System.Windows.Forms.TextBox();
            this.textBox_Syouhin_ID = new System.Windows.Forms.TextBox();
            this.textBox_Syain_ID = new System.Windows.Forms.TextBox();
            this.textBox_Hattyuu_ID = new System.Windows.Forms.TextBox();
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
            this.button_Kakutei = new System.Windows.Forms.Button();
            this.button_Sakuzyo = new System.Windows.Forms.Button();
            this.button_Itirannhyouzi = new System.Windows.Forms.Button();
            this.button_Kennsaku = new System.Windows.Forms.Button();
            this.button_Touroku = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 487);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1533, 351);
            this.dataGridView1.TabIndex = 51;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.checkBox1.Location = new System.Drawing.Point(718, 441);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(245, 49);
            this.checkBox1.TabIndex = 50;
            this.checkBox1.Text = "入庫済みフラグ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(246, 441);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(389, 31);
            this.dateTimePicker1.TabIndex = 49;
            // 
            // comboBox_Syouhin_Namae
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(638, 26);
            this.button_Sakuzyo.Margin = new System.Windows.Forms.Padding(2);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(118, 56);
            this.button_Sakuzyo.TabIndex = 3;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            this.button_Sakuzyo.Click += new System.EventHandler(this.button_Sakuzyo_Click);
            // 
            // comboBox_Meka_Namae
            // 
            this.comboBox_Meka_Namae.FormattingEnabled = true;
            this.comboBox_Meka_Namae.Location = new System.Drawing.Point(253, 263);
            this.comboBox_Meka_Namae.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Meka_Namae.Name = "comboBox_Meka_Namae";
            this.comboBox_Meka_Namae.Size = new System.Drawing.Size(251, 32);
            this.comboBox_Meka_Namae.TabIndex = 47;
            // 
            // comboBox_Syain_Namae
            // 
            this.comboBox_Syain_Namae.FormattingEnabled = true;
            this.comboBox_Syain_Namae.Location = new System.Drawing.Point(1259, 175);
            this.comboBox_Syain_Namae.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Syain_Namae.Name = "comboBox_Syain_Namae";
            this.comboBox_Syain_Namae.Size = new System.Drawing.Size(242, 32);
            this.comboBox_Syain_Namae.TabIndex = 46;
            // 
            // textBox_Hattyuusyousai
            // 
            this.textBox_Hattyuusyousai.Location = new System.Drawing.Point(748, 356);
            this.textBox_Hattyuusyousai.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Hattyuusyousai.Name = "textBox_Hattyuusyousai";
            this.textBox_Hattyuusyousai.Size = new System.Drawing.Size(281, 31);
            this.textBox_Hattyuusyousai.TabIndex = 45;
            // 
            // textBox_Suuryou
            // 
            this.textBox_Suuryou.Location = new System.Drawing.Point(246, 353);
            this.textBox_Suuryou.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Suuryou.Name = "textBox_Suuryou";
            this.textBox_Suuryou.Size = new System.Drawing.Size(251, 31);
            this.textBox_Suuryou.TabIndex = 44;
            // 
            // textBox_Syouhin_ID
            // 
            this.textBox_Syouhin_ID.Location = new System.Drawing.Point(746, 263);
            this.textBox_Syouhin_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Syouhin_ID.Name = "textBox_Syouhin_ID";
            this.textBox_Syouhin_ID.Size = new System.Drawing.Size(284, 31);
            this.textBox_Syouhin_ID.TabIndex = 43;
            // 
            // textBox_Syain_ID
            // 
            this.textBox_Syain_ID.Location = new System.Drawing.Point(748, 173);
            this.textBox_Syain_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Syain_ID.Name = "textBox_Syain_ID";
            this.textBox_Syain_ID.Size = new System.Drawing.Size(281, 31);
            this.textBox_Syain_ID.TabIndex = 42;
            // 
            // textBox_Hattyuu_ID
            // 
            this.textBox_Hattyuu_ID.Location = new System.Drawing.Point(253, 173);
            this.textBox_Hattyuu_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Hattyuu_ID.Name = "textBox_Hattyuu_ID";
            this.textBox_Hattyuu_ID.Size = new System.Drawing.Size(251, 31);
            this.textBox_Hattyuu_ID.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label9.Location = new System.Drawing.Point(38, 432);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 41);
            this.label9.TabIndex = 40;
            this.label9.Text = "発注年月日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label8.Location = new System.Drawing.Point(561, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 41);
            this.label8.TabIndex = 39;
            this.label8.Text = "発注詳細ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label7.Location = new System.Drawing.Point(77, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 41);
            this.label7.TabIndex = 38;
            this.label7.Text = "数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label6.Location = new System.Drawing.Point(1123, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 41);
            this.label6.TabIndex = 37;
            this.label6.Text = "商品名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label5.Location = new System.Drawing.Point(571, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 41);
            this.label5.TabIndex = 36;
            this.label5.Text = "商品ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label4.Location = new System.Drawing.Point(44, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 41);
            this.label4.TabIndex = 35;
            this.label4.Text = "メーカー名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label3.Location = new System.Drawing.Point(1123, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 41);
            this.label3.TabIndex = 34;
            this.label3.Text = "社員名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label2.Location = new System.Drawing.Point(575, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 41);
            this.label2.TabIndex = 33;
            this.label2.Text = "社員ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label1.Location = new System.Drawing.Point(77, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 41);
            this.label1.TabIndex = 32;
            this.label1.Text = "発注ID";
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(1345, 23);
            this.button_Kuria.Margin = new System.Windows.Forms.Padding(2);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(153, 75);
            this.button_Kuria.TabIndex = 31;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // button_Kakutei
            // 
            this.button_Kakutei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kakutei.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kakutei.ForeColor = System.Drawing.Color.White;
            this.button_Kakutei.Location = new System.Drawing.Point(1089, 23);
            this.button_Kakutei.Margin = new System.Windows.Forms.Padding(2);
            this.button_Kakutei.Name = "button_Kakutei";
            this.button_Kakutei.Size = new System.Drawing.Size(153, 75);
            this.button_Kakutei.TabIndex = 30;
            this.button_Kakutei.Text = "確定";
            this.button_Kakutei.UseVisualStyleBackColor = false;
            // 
            // button_Sakuzyo
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(831, 23);
            this.button_Sakuzyo.Margin = new System.Windows.Forms.Padding(2);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(153, 75);
            this.button_Sakuzyo.TabIndex = 29;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            // 
            // button_Itirannhyouzi
            // 
            this.button_Itirannhyouzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itirannhyouzi.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Itirannhyouzi.ForeColor = System.Drawing.Color.White;
            this.button_Itirannhyouzi.Location = new System.Drawing.Point(516, 23);
            this.button_Itirannhyouzi.Margin = new System.Windows.Forms.Padding(2);
            this.button_Itirannhyouzi.Name = "button_Itirannhyouzi";
            this.button_Itirannhyouzi.Size = new System.Drawing.Size(212, 75);
            this.button_Itirannhyouzi.TabIndex = 28;
            this.button_Itirannhyouzi.Text = "📖一覧表示";
            this.button_Itirannhyouzi.UseVisualStyleBackColor = false;
            this.button_Itirannhyouzi.Click += new System.EventHandler(this.button_Itirannhyouzi_Click);
            // 
            // button_Kennsaku
            // 
            this.button_Kennsaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kennsaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kennsaku.ForeColor = System.Drawing.Color.White;
            this.button_Kennsaku.Location = new System.Drawing.Point(279, 23);
            this.button_Kennsaku.Margin = new System.Windows.Forms.Padding(2);
            this.button_Kennsaku.Name = "button_Kennsaku";
            this.button_Kennsaku.Size = new System.Drawing.Size(153, 75);
            this.button_Kennsaku.TabIndex = 27;
            this.button_Kennsaku.Text = "🔍検索";
            this.button_Kennsaku.UseVisualStyleBackColor = false;
            this.button_Kennsaku.Click += new System.EventHandler(this.button_Kennsaku_Click);
            // 
            // button_Touroku
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 499);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1179, 263);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Hattyuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox_Syouhin_Namae);
            this.Controls.Add(this.comboBox_Meka_Namae);
            this.Controls.Add(this.comboBox_Syain_Namae);
            this.Controls.Add(this.textBox_Hattyuusyousai);
            this.Controls.Add(this.textBox_Suuryou);
            this.Controls.Add(this.textBox_Syouhin_ID);
            this.Controls.Add(this.textBox_Syain_ID);
            this.Controls.Add(this.textBox_Hattyuu_ID);
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
            this.Controls.Add(this.button_Itirannhyouzi);
            this.Controls.Add(this.button_Kennsaku);
            this.Controls.Add(this.button_Touroku);
            this.Name = "Hattyuu";
            this.Size = new System.Drawing.Size(1580, 861);
            this.Load += new System.EventHandler(this.Hattyuu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox_Syouhin_Namae;
        private System.Windows.Forms.ComboBox comboBox_Meka_Namae;
        private System.Windows.Forms.ComboBox comboBox_Syain_Namae;
        private System.Windows.Forms.TextBox textBox_Hattyuusyousai;
        private System.Windows.Forms.TextBox textBox_Suuryou;
        private System.Windows.Forms.TextBox textBox_Syouhin_ID;
        private System.Windows.Forms.TextBox textBox_Syain_ID;
        private System.Windows.Forms.TextBox textBox_Hattyuu_ID;
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
        private System.Windows.Forms.Button button_Kakutei;
        private System.Windows.Forms.Button button_Sakuzyo;
        private System.Windows.Forms.Button button_Itirannhyouzi;
        private System.Windows.Forms.Button button_Kennsaku;
        private System.Windows.Forms.Button button_Touroku;
    }
}
