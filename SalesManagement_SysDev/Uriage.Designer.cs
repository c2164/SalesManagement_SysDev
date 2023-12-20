namespace SalesManagement_SysDev
{
    partial class Uriage
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
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_Nitizi_3 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_Nitizi_2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Nitizi = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Syain_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Eigyousyo_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Kokyaku_Namae = new System.Windows.Forms.ComboBox();
            this.textBox_Zyutyuu_ID = new System.Windows.Forms.TextBox();
            this.textBox_Uriagesyousai_ID = new System.Windows.Forms.TextBox();
            this.textBox_Uriage_ID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Kuria = new System.Windows.Forms.Button();
            this.button_Sakuzyo = new System.Windows.Forms.Button();
            this.button_Kensaku = new System.Windows.Forms.Button();
            this.button_Itirannhyouzi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 505);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1540, 337);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "～";
            // 
            // dateTimePicker_Nitizi_3
            // 
            this.dateTimePicker_Nitizi_3.Location = new System.Drawing.Point(433, 43);
            this.dateTimePicker_Nitizi_3.Name = "dateTimePicker_Nitizi_3";
            this.dateTimePicker_Nitizi_3.Size = new System.Drawing.Size(364, 31);
            this.dateTimePicker_Nitizi_3.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTimePicker_Nitizi_3);
            this.groupBox1.Controls.Add(this.dateTimePicker_Nitizi_2);
            this.groupBox1.Location = new System.Drawing.Point(74, 381);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 107);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索用日時";
            // 
            // dateTimePicker_Nitizi_2
            // 
            this.dateTimePicker_Nitizi_2.Location = new System.Drawing.Point(20, 43);
            this.dateTimePicker_Nitizi_2.Name = "dateTimePicker_Nitizi_2";
            this.dateTimePicker_Nitizi_2.Size = new System.Drawing.Size(350, 31);
            this.dateTimePicker_Nitizi_2.TabIndex = 19;
            // 
            // dateTimePicker_Nitizi
            // 
            this.dateTimePicker_Nitizi.Location = new System.Drawing.Point(796, 297);
            this.dateTimePicker_Nitizi.Name = "dateTimePicker_Nitizi";
            this.dateTimePicker_Nitizi.Size = new System.Drawing.Size(287, 31);
            this.dateTimePicker_Nitizi.TabIndex = 37;
            // 
            // comboBox_Syain_Namae
            // 
            this.comboBox_Syain_Namae.FormattingEnabled = true;
            this.comboBox_Syain_Namae.Location = new System.Drawing.Point(796, 223);
            this.comboBox_Syain_Namae.Name = "comboBox_Syain_Namae";
            this.comboBox_Syain_Namae.Size = new System.Drawing.Size(287, 32);
            this.comboBox_Syain_Namae.TabIndex = 36;
            // 
            // comboBox_Eigyousyo_Namae
            // 
            this.comboBox_Eigyousyo_Namae.FormattingEnabled = true;
            this.comboBox_Eigyousyo_Namae.Location = new System.Drawing.Point(1294, 147);
            this.comboBox_Eigyousyo_Namae.Name = "comboBox_Eigyousyo_Namae";
            this.comboBox_Eigyousyo_Namae.Size = new System.Drawing.Size(242, 32);
            this.comboBox_Eigyousyo_Namae.TabIndex = 35;
            // 
            // comboBox_Kokyaku_Namae
            // 
            this.comboBox_Kokyaku_Namae.FormattingEnabled = true;
            this.comboBox_Kokyaku_Namae.Location = new System.Drawing.Point(796, 147);
            this.comboBox_Kokyaku_Namae.Name = "comboBox_Kokyaku_Namae";
            this.comboBox_Kokyaku_Namae.Size = new System.Drawing.Size(287, 32);
            this.comboBox_Kokyaku_Namae.TabIndex = 34;
            // 
            // textBox_Zyutyuu_ID
            // 
            this.textBox_Zyutyuu_ID.Location = new System.Drawing.Point(240, 299);
            this.textBox_Zyutyuu_ID.Name = "textBox_Zyutyuu_ID";
            this.textBox_Zyutyuu_ID.Size = new System.Drawing.Size(346, 31);
            this.textBox_Zyutyuu_ID.TabIndex = 33;
            // 
            // textBox_Uriagesyousai_ID
            // 
            this.textBox_Uriagesyousai_ID.Location = new System.Drawing.Point(240, 223);
            this.textBox_Uriagesyousai_ID.Name = "textBox_Uriagesyousai_ID";
            this.textBox_Uriagesyousai_ID.Size = new System.Drawing.Size(346, 31);
            this.textBox_Uriagesyousai_ID.TabIndex = 32;
            // 
            // textBox_Uriage_ID
            // 
            this.textBox_Uriage_ID.Location = new System.Drawing.Point(240, 147);
            this.textBox_Uriage_ID.Name = "textBox_Uriage_ID";
            this.textBox_Uriage_ID.Size = new System.Drawing.Size(346, 31);
            this.textBox_Uriage_ID.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label7.Location = new System.Drawing.Point(620, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 41);
            this.label7.TabIndex = 30;
            this.label7.Text = "売上日時";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label6.Location = new System.Drawing.Point(66, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 41);
            this.label6.TabIndex = 29;
            this.label6.Text = "受注ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label5.Location = new System.Drawing.Point(620, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 41);
            this.label5.TabIndex = 28;
            this.label5.Text = "社員名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label4.Location = new System.Drawing.Point(20, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 41);
            this.label4.TabIndex = 27;
            this.label4.Text = "売上詳細ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label3.Location = new System.Drawing.Point(1130, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 41);
            this.label3.TabIndex = 26;
            this.label3.Text = "営業所";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label2.Location = new System.Drawing.Point(620, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 41);
            this.label2.TabIndex = 25;
            this.label2.Text = "顧客名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            this.label1.Location = new System.Drawing.Point(81, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 41);
            this.label1.TabIndex = 24;
            this.label1.Text = "売上ID";
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(1205, 20);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(218, 75);
            this.button_Kuria.TabIndex = 23;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // button_Sakuzyo
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(844, 20);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(218, 75);
            this.button_Sakuzyo.TabIndex = 22;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            this.button_Sakuzyo.Click += new System.EventHandler(this.button_Sakuzyo_Click);
            // 
            // button_Kensaku
            // 
            this.button_Kensaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kensaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kensaku.ForeColor = System.Drawing.Color.White;
            this.button_Kensaku.Location = new System.Drawing.Point(489, 20);
            this.button_Kensaku.Name = "button_Kensaku";
            this.button_Kensaku.Size = new System.Drawing.Size(211, 75);
            this.button_Kensaku.TabIndex = 21;
            this.button_Kensaku.Text = "🔍検索";
            this.button_Kensaku.UseVisualStyleBackColor = false;
            this.button_Kensaku.Click += new System.EventHandler(this.button_Kensaku_Click);
            // 
            // button_Itirannhyouzi
            // 
            this.button_Itirannhyouzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itirannhyouzi.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Itirannhyouzi.ForeColor = System.Drawing.Color.White;
            this.button_Itirannhyouzi.Location = new System.Drawing.Point(108, 27);
            this.button_Itirannhyouzi.Name = "button_Itirannhyouzi";
            this.button_Itirannhyouzi.Size = new System.Drawing.Size(253, 68);
            this.button_Itirannhyouzi.TabIndex = 39;
            this.button_Itirannhyouzi.Text = "📚一覧表示";
            this.button_Itirannhyouzi.UseVisualStyleBackColor = false;
            this.button_Itirannhyouzi.Click += new System.EventHandler(this.button_Itirannhyouzi_Click);
            // 
            // Uriage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(184)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker_Nitizi);
            this.Controls.Add(this.comboBox_Syain_Namae);
            this.Controls.Add(this.comboBox_Eigyousyo_Namae);
            this.Controls.Add(this.comboBox_Kokyaku_Namae);
            this.Controls.Add(this.textBox_Zyutyuu_ID);
            this.Controls.Add(this.textBox_Uriagesyousai_ID);
            this.Controls.Add(this.textBox_Uriage_ID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Kuria);
            this.Controls.Add(this.button_Sakuzyo);
            this.Controls.Add(this.button_Kensaku);
            this.Controls.Add(this.button_Itirannhyouzi);
            this.Name = "Uriage";
            this.Size = new System.Drawing.Size(1580, 861);
            this.Load += new System.EventHandler(this.Uriage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Nitizi_3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Nitizi_2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Nitizi;
        private System.Windows.Forms.ComboBox comboBox_Syain_Namae;
        private System.Windows.Forms.ComboBox comboBox_Eigyousyo_Namae;
        private System.Windows.Forms.ComboBox comboBox_Kokyaku_Namae;
        private System.Windows.Forms.TextBox textBox_Zyutyuu_ID;
        private System.Windows.Forms.TextBox textBox_Uriagesyousai_ID;
        private System.Windows.Forms.TextBox textBox_Uriage_ID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Kuria;
        private System.Windows.Forms.Button button_Sakuzyo;
        private System.Windows.Forms.Button button_Kensaku;
        private System.Windows.Forms.Button button_Itirannhyouzi;
    }
}
