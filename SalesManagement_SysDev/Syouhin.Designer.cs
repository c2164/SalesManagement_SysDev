﻿namespace SalesManagement_SysDev
{
    partial class Syouhin
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
            this.combobox_Meka_ID = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker_Nitizi_3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Nitizi_2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.combobox_Syoubunnrui_Namae = new System.Windows.Forms.ComboBox();
            this.textbox_Anzen = new System.Windows.Forms.TextBox();
            this.textbox_Kakaku = new System.Windows.Forms.TextBox();
            this.textbox_Kataban = new System.Windows.Forms.TextBox();
            this.textbox_Iro = new System.Windows.Forms.TextBox();
            this.textbox_Syouhin_Namae = new System.Windows.Forms.TextBox();
            this.textbox_Syouhin_ID = new System.Windows.Forms.TextBox();
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
            this.button_Sakujyo = new System.Windows.Forms.Button();
            this.button_Itiran = new System.Windows.Forms.Button();
            this.button_Kennsaku = new System.Windows.Forms.Button();
            this.button_Kousin = new System.Windows.Forms.Button();
            this.button_Touroku = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // combobox_Meka_ID
            // 
            this.combobox_Meka_ID.FormattingEnabled = true;
            this.combobox_Meka_ID.Location = new System.Drawing.Point(1251, 189);
            this.combobox_Meka_ID.Name = "combobox_Meka_ID";
            this.combobox_Meka_ID.Size = new System.Drawing.Size(280, 32);
            this.combobox_Meka_ID.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dateTimePicker_Nitizi_3);
            this.groupBox1.Controls.Add(this.dateTimePicker_Nitizi_2);
            this.groupBox1.Location = new System.Drawing.Point(68, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 88);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索用日時";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(376, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 24);
            this.label10.TabIndex = 21;
            this.label10.Text = "～";
            // 
            // dateTimePicker_Nitizi_3
            // 
            this.dateTimePicker_Nitizi_3.Location = new System.Drawing.Point(433, 43);
            this.dateTimePicker_Nitizi_3.Name = "dateTimePicker_Nitizi_3";
            this.dateTimePicker_Nitizi_3.Size = new System.Drawing.Size(364, 31);
            this.dateTimePicker_Nitizi_3.TabIndex = 17;
            // 
            // dateTimePicker_Nitizi_2
            // 
            this.dateTimePicker_Nitizi_2.Location = new System.Drawing.Point(20, 43);
            this.dateTimePicker_Nitizi_2.Name = "dateTimePicker_Nitizi_2";
            this.dateTimePicker_Nitizi_2.Size = new System.Drawing.Size(350, 31);
            this.dateTimePicker_Nitizi_2.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1251, 341);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(278, 31);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 493);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1533, 351);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // combobox_Syoubunnrui_Namae
            // 
            this.combobox_Syoubunnrui_Namae.FormattingEnabled = true;
            this.combobox_Syoubunnrui_Namae.Location = new System.Drawing.Point(222, 261);
            this.combobox_Syoubunnrui_Namae.Name = "combobox_Syoubunnrui_Namae";
            this.combobox_Syoubunnrui_Namae.Size = new System.Drawing.Size(280, 32);
            this.combobox_Syoubunnrui_Namae.TabIndex = 10;
            // 
            // textbox_Anzen
            // 
            this.textbox_Anzen.Location = new System.Drawing.Point(1251, 273);
            this.textbox_Anzen.MaxLength = 4;
            this.textbox_Anzen.Name = "textbox_Anzen";
            this.textbox_Anzen.Size = new System.Drawing.Size(280, 31);
            this.textbox_Anzen.TabIndex = 12;
            // 
            // textbox_Kakaku
            // 
            this.textbox_Kakaku.Location = new System.Drawing.Point(728, 265);
            this.textbox_Kakaku.MaxLength = 9;
            this.textbox_Kakaku.Name = "textbox_Kakaku";
            this.textbox_Kakaku.Size = new System.Drawing.Size(280, 31);
            this.textbox_Kakaku.TabIndex = 11;
            // 
            // textbox_Kataban
            // 
            this.textbox_Kataban.Location = new System.Drawing.Point(222, 336);
            this.textbox_Kataban.MaxLength = 20;
            this.textbox_Kataban.Name = "textbox_Kataban";
            this.textbox_Kataban.Size = new System.Drawing.Size(280, 31);
            this.textbox_Kataban.TabIndex = 13;
            // 
            // textbox_Iro
            // 
            this.textbox_Iro.Location = new System.Drawing.Point(728, 336);
            this.textbox_Iro.MaxLength = 20;
            this.textbox_Iro.Name = "textbox_Iro";
            this.textbox_Iro.Size = new System.Drawing.Size(280, 31);
            this.textbox_Iro.TabIndex = 14;
            // 
            // textbox_Syouhin_Namae
            // 
            this.textbox_Syouhin_Namae.Location = new System.Drawing.Point(727, 181);
            this.textbox_Syouhin_Namae.MaxLength = 50;
            this.textbox_Syouhin_Namae.Name = "textbox_Syouhin_Namae";
            this.textbox_Syouhin_Namae.Size = new System.Drawing.Size(280, 31);
            this.textbox_Syouhin_Namae.TabIndex = 8;
            // 
            // textbox_Syouhin_ID
            // 
            this.textbox_Syouhin_ID.Location = new System.Drawing.Point(222, 181);
            this.textbox_Syouhin_ID.MaxLength = 6;
            this.textbox_Syouhin_ID.Name = "textbox_Syouhin_ID";
            this.textbox_Syouhin_ID.Size = new System.Drawing.Size(280, 31);
            this.textbox_Syouhin_ID.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label9.Location = new System.Drawing.Point(1066, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 41);
            this.label9.TabIndex = 67;
            this.label9.Text = "発売日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label8.Location = new System.Drawing.Point(592, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 41);
            this.label8.TabIndex = 66;
            this.label8.Text = "色";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label7.Location = new System.Drawing.Point(101, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 41);
            this.label7.TabIndex = 65;
            this.label7.Text = "型番";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label6.Location = new System.Drawing.Point(1060, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 41);
            this.label6.TabIndex = 64;
            this.label6.Text = "安全在庫数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label5.Location = new System.Drawing.Point(578, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 41);
            this.label5.TabIndex = 63;
            this.label5.Text = "価格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label4.Location = new System.Drawing.Point(46, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 41);
            this.label4.TabIndex = 62;
            this.label4.Text = "小分類名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label3.Location = new System.Drawing.Point(1066, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 41);
            this.label3.TabIndex = 61;
            this.label3.Text = "メーカー名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label2.Location = new System.Drawing.Point(566, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 41);
            this.label2.TabIndex = 60;
            this.label2.Text = "商品名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label1.Location = new System.Drawing.Point(73, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 41);
            this.label1.TabIndex = 59;
            this.label1.Text = "商品ID";
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(1375, 29);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(188, 75);
            this.button_Kuria.TabIndex = 6;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // button_Sakujyo
            // 
            this.button_Sakujyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakujyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakujyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakujyo.Location = new System.Drawing.Point(1124, 29);
            this.button_Sakujyo.Name = "button_Sakujyo";
            this.button_Sakujyo.Size = new System.Drawing.Size(188, 75);
            this.button_Sakujyo.TabIndex = 5;
            this.button_Sakujyo.Text = "🚮削除";
            this.button_Sakujyo.UseVisualStyleBackColor = false;
            this.button_Sakujyo.Click += new System.EventHandler(this.button_Sakujyo_Click);
            // 
            // button_Itiran
            // 
            this.button_Itiran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itiran.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Itiran.ForeColor = System.Drawing.Color.White;
            this.button_Itiran.Location = new System.Drawing.Point(842, 29);
            this.button_Itiran.Name = "button_Itiran";
            this.button_Itiran.Size = new System.Drawing.Size(207, 75);
            this.button_Itiran.TabIndex = 4;
            this.button_Itiran.Text = "📖一覧表示";
            this.button_Itiran.UseVisualStyleBackColor = false;
            this.button_Itiran.Click += new System.EventHandler(this.button_Itiran_Click);
            // 
            // button_Kennsaku
            // 
            this.button_Kennsaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kennsaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kennsaku.ForeColor = System.Drawing.Color.White;
            this.button_Kennsaku.Location = new System.Drawing.Point(586, 29);
            this.button_Kennsaku.Name = "button_Kennsaku";
            this.button_Kennsaku.Size = new System.Drawing.Size(188, 75);
            this.button_Kennsaku.TabIndex = 3;
            this.button_Kennsaku.Text = "🔍検索";
            this.button_Kennsaku.UseVisualStyleBackColor = false;
            this.button_Kennsaku.Click += new System.EventHandler(this.button_Kennsaku_Click);
            // 
            // button_Kousin
            // 
            this.button_Kousin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kousin.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kousin.ForeColor = System.Drawing.Color.White;
            this.button_Kousin.Location = new System.Drawing.Point(326, 29);
            this.button_Kousin.Name = "button_Kousin";
            this.button_Kousin.Size = new System.Drawing.Size(188, 75);
            this.button_Kousin.TabIndex = 2;
            this.button_Kousin.Text = "↻更新";
            this.button_Kousin.UseVisualStyleBackColor = false;
            this.button_Kousin.Click += new System.EventHandler(this.button_Kousin_Click);
            // 
            // button_Touroku
            // 
            this.button_Touroku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Touroku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Touroku.ForeColor = System.Drawing.Color.White;
            this.button_Touroku.Location = new System.Drawing.Point(68, 29);
            this.button_Touroku.Name = "button_Touroku";
            this.button_Touroku.Size = new System.Drawing.Size(188, 75);
            this.button_Touroku.TabIndex = 1;
            this.button_Touroku.Text = "🖊登録";
            this.button_Touroku.UseVisualStyleBackColor = false;
            this.button_Touroku.Click += new System.EventHandler(this.button_Touroku_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton1.Location = new System.Drawing.Point(68, 110);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(189, 36);
            this.radioButton1.TabIndex = 79;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "登録必要項目";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton2.Location = new System.Drawing.Point(326, 110);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(189, 36);
            this.radioButton2.TabIndex = 80;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "更新可能項目";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton3.Location = new System.Drawing.Point(586, 110);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(189, 36);
            this.radioButton3.TabIndex = 81;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "検索可能項目";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton4.Location = new System.Drawing.Point(1124, 110);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(189, 36);
            this.radioButton4.TabIndex = 82;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "削除必要項目";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // Syouhin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.combobox_Meka_ID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.combobox_Syoubunnrui_Namae);
            this.Controls.Add(this.textbox_Anzen);
            this.Controls.Add(this.textbox_Kakaku);
            this.Controls.Add(this.textbox_Kataban);
            this.Controls.Add(this.textbox_Iro);
            this.Controls.Add(this.textbox_Syouhin_Namae);
            this.Controls.Add(this.textbox_Syouhin_ID);
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
            this.Controls.Add(this.button_Sakujyo);
            this.Controls.Add(this.button_Itiran);
            this.Controls.Add(this.button_Kennsaku);
            this.Controls.Add(this.button_Kousin);
            this.Controls.Add(this.button_Touroku);
            this.Name = "Syouhin";
            this.Size = new System.Drawing.Size(1610, 875);
            this.Load += new System.EventHandler(this.Syouhin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combobox_Meka_ID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Nitizi_3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Nitizi_2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox combobox_Syoubunnrui_Namae;
        private System.Windows.Forms.TextBox textbox_Anzen;
        private System.Windows.Forms.TextBox textbox_Kakaku;
        private System.Windows.Forms.TextBox textbox_Kataban;
        private System.Windows.Forms.TextBox textbox_Iro;
        private System.Windows.Forms.TextBox textbox_Syouhin_Namae;
        private System.Windows.Forms.TextBox textbox_Syouhin_ID;
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
        private System.Windows.Forms.Button button_Sakujyo;
        private System.Windows.Forms.Button button_Itiran;
        private System.Windows.Forms.Button button_Kennsaku;
        private System.Windows.Forms.Button button_Kousin;
        private System.Windows.Forms.Button button_Touroku;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
    }
}
