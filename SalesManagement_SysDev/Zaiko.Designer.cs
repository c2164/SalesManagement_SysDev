namespace SalesManagement_SysDev
{
    partial class Zaiko
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
            this.button_Kousin = new System.Windows.Forms.Button();
            this.button_Kensaku = new System.Windows.Forms.Button();
            this.button_Itirannhyouzi = new System.Windows.Forms.Button();
            this.button_Sakuzyo = new System.Windows.Forms.Button();
            this.button_Kuria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Zaiko_ID = new System.Windows.Forms.TextBox();
            this.comboBox_Meka_Namae = new System.Windows.Forms.ComboBox();
            this.comboBox_Syouhin_Namae = new System.Windows.Forms.ComboBox();
            this.domainUpDown_Zaikosuu = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDown_Zaikosuu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Kousin
            // 
            this.button_Kousin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kousin.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kousin.ForeColor = System.Drawing.Color.White;
            this.button_Kousin.Location = new System.Drawing.Point(54, 55);
            this.button_Kousin.Name = "button_Kousin";
            this.button_Kousin.Size = new System.Drawing.Size(224, 74);
            this.button_Kousin.TabIndex = 1;
            this.button_Kousin.Text = "↻更新";
            this.button_Kousin.UseVisualStyleBackColor = false;
            this.button_Kousin.Click += new System.EventHandler(this.button_Kousin_Click);
            // 
            // button_Kensaku
            // 
            this.button_Kensaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kensaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kensaku.ForeColor = System.Drawing.Color.White;
            this.button_Kensaku.Location = new System.Drawing.Point(360, 55);
            this.button_Kensaku.Name = "button_Kensaku";
            this.button_Kensaku.Size = new System.Drawing.Size(243, 74);
            this.button_Kensaku.TabIndex = 2;
            this.button_Kensaku.Text = "🔍検索";
            this.button_Kensaku.UseVisualStyleBackColor = false;
            this.button_Kensaku.Click += new System.EventHandler(this.button_Kensaku_Click);
            // 
            // button_Itirannhyouzi
            // 
            this.button_Itirannhyouzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itirannhyouzi.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Itirannhyouzi.ForeColor = System.Drawing.Color.White;
            this.button_Itirannhyouzi.Location = new System.Drawing.Point(670, 55);
            this.button_Itirannhyouzi.Name = "button_Itirannhyouzi";
            this.button_Itirannhyouzi.Size = new System.Drawing.Size(270, 74);
            this.button_Itirannhyouzi.TabIndex = 3;
            this.button_Itirannhyouzi.Text = "📖一覧表示";
            this.button_Itirannhyouzi.UseVisualStyleBackColor = false;
            this.button_Itirannhyouzi.Click += new System.EventHandler(this.button_Itirannhyouzi_Click);
            // 
            // button_Sakuzyo
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(1010, 55);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(240, 74);
            this.button_Sakuzyo.TabIndex = 4;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            this.button_Sakuzyo.Click += new System.EventHandler(this.button_Sakuzyo_Click);
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(1314, 55);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(237, 74);
            this.button_Kuria.TabIndex = 5;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(49, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "在庫ID";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(527, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "メーカー名";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1049, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 41);
            this.label3.TabIndex = 7;
            this.label3.Text = "商品名";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(49, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 41);
            this.label4.TabIndex = 8;
            this.label4.Text = "在庫数";
            // 
            // textBox_Zaiko_ID
            // 
            this.textBox_Zaiko_ID.Location = new System.Drawing.Point(242, 239);
            this.textBox_Zaiko_ID.MaxLength = 6;
            this.textBox_Zaiko_ID.Name = "textBox_Zaiko_ID";
            this.textBox_Zaiko_ID.Size = new System.Drawing.Size(250, 31);
            this.textBox_Zaiko_ID.TabIndex = 6;
            // 
            // comboBox_Meka_Namae
            // 
            this.comboBox_Meka_Namae.FormattingEnabled = true;
            this.comboBox_Meka_Namae.Location = new System.Drawing.Point(703, 239);
            this.comboBox_Meka_Namae.Name = "comboBox_Meka_Namae";
            this.comboBox_Meka_Namae.Size = new System.Drawing.Size(273, 32);
            this.comboBox_Meka_Namae.TabIndex = 7;
            // 
            // comboBox_Syouhin_Namae
            // 
            this.comboBox_Syouhin_Namae.FormattingEnabled = true;
            this.comboBox_Syouhin_Namae.Location = new System.Drawing.Point(1202, 238);
            this.comboBox_Syouhin_Namae.Name = "comboBox_Syouhin_Namae";
            this.comboBox_Syouhin_Namae.Size = new System.Drawing.Size(277, 32);
            this.comboBox_Syouhin_Namae.TabIndex = 8;
            // 
            // domainUpDown_Zaikosuu
            // 
            this.domainUpDown_Zaikosuu.Location = new System.Drawing.Point(242, 387);
            this.domainUpDown_Zaikosuu.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.domainUpDown_Zaikosuu.Name = "domainUpDown_Zaikosuu";
            this.domainUpDown_Zaikosuu.Size = new System.Drawing.Size(250, 31);
            this.domainUpDown_Zaikosuu.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 483);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1533, 351);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton1.Location = new System.Drawing.Point(70, 135);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(189, 36);
            this.radioButton1.TabIndex = 45;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "更新可能項目";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton2.Location = new System.Drawing.Point(380, 135);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(189, 36);
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
            this.radioButton3.Location = new System.Drawing.Point(1029, 135);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(189, 36);
            this.radioButton3.TabIndex = 47;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "削除必要項目";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Zaiko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.domainUpDown_Zaikosuu);
            this.Controls.Add(this.comboBox_Syouhin_Namae);
            this.Controls.Add(this.comboBox_Meka_Namae);
            this.Controls.Add(this.textBox_Zaiko_ID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Kuria);
            this.Controls.Add(this.button_Sakuzyo);
            this.Controls.Add(this.button_Itirannhyouzi);
            this.Controls.Add(this.button_Kensaku);
            this.Controls.Add(this.button_Kousin);
            this.Name = "Zaiko";
            this.Size = new System.Drawing.Size(1610, 875);
            this.Load += new System.EventHandler(this.Zaiko_Load);
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDown_Zaikosuu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Kousin;
        private System.Windows.Forms.Button button_Kensaku;
        private System.Windows.Forms.Button button_Itirannhyouzi;
        private System.Windows.Forms.Button button_Sakuzyo;
        private System.Windows.Forms.Button button_Kuria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Zaiko_ID;
        private System.Windows.Forms.ComboBox comboBox_Meka_Namae;
        private System.Windows.Forms.ComboBox comboBox_Syouhin_Namae;
        private System.Windows.Forms.NumericUpDown domainUpDown_Zaikosuu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}
