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
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDown_Zaikosuu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Kousin
            // 
            this.button_Kousin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kousin.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kousin.ForeColor = System.Drawing.Color.White;
            this.button_Kousin.Location = new System.Drawing.Point(43, 41);
            this.button_Kousin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Kousin.Name = "button_Kousin";
            this.button_Kousin.Size = new System.Drawing.Size(119, 56);
            this.button_Kousin.TabIndex = 0;
            this.button_Kousin.Text = "↻更新";
            this.button_Kousin.UseVisualStyleBackColor = false;
            // 
            // button_Kensaku
            // 
            this.button_Kensaku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kensaku.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kensaku.ForeColor = System.Drawing.Color.White;
            this.button_Kensaku.Location = new System.Drawing.Point(277, 41);
            this.button_Kensaku.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Kensaku.Name = "button_Kensaku";
            this.button_Kensaku.Size = new System.Drawing.Size(119, 56);
            this.button_Kensaku.TabIndex = 1;
            this.button_Kensaku.Text = "🔍検索";
            this.button_Kensaku.UseVisualStyleBackColor = false;
            // 
            // button_Itirannhyouzi
            // 
            this.button_Itirannhyouzi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Itirannhyouzi.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Itirannhyouzi.ForeColor = System.Drawing.Color.White;
            this.button_Itirannhyouzi.Location = new System.Drawing.Point(507, 41);
            this.button_Itirannhyouzi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Itirannhyouzi.Name = "button_Itirannhyouzi";
            this.button_Itirannhyouzi.Size = new System.Drawing.Size(163, 56);
            this.button_Itirannhyouzi.TabIndex = 2;
            this.button_Itirannhyouzi.Text = "📖一覧表示";
            this.button_Itirannhyouzi.UseVisualStyleBackColor = false;
            // 
            // button_Sakuzyo
            // 
            this.button_Sakuzyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Sakuzyo.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Sakuzyo.ForeColor = System.Drawing.Color.White;
            this.button_Sakuzyo.Location = new System.Drawing.Point(791, 41);
            this.button_Sakuzyo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Sakuzyo.Name = "button_Sakuzyo";
            this.button_Sakuzyo.Size = new System.Drawing.Size(119, 56);
            this.button_Sakuzyo.TabIndex = 3;
            this.button_Sakuzyo.Text = "🚮削除";
            this.button_Sakuzyo.UseVisualStyleBackColor = false;
            // 
            // button_Kuria
            // 
            this.button_Kuria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Kuria.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.button_Kuria.ForeColor = System.Drawing.Color.White;
            this.button_Kuria.Location = new System.Drawing.Point(1018, 41);
            this.button_Kuria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Kuria.Name = "button_Kuria";
            this.button_Kuria.Size = new System.Drawing.Size(119, 56);
            this.button_Kuria.TabIndex = 4;
            this.button_Kuria.Text = "クリア";
            this.button_Kuria.UseVisualStyleBackColor = false;
            this.button_Kuria.Click += new System.EventHandler(this.button_Kuria_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(38, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "在庫ID";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(424, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "メーカー名";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(807, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "商品名";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(38, 283);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "在庫数";
            // 
            // textBox_Zaiko_ID
            // 
            this.textBox_Zaiko_ID.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.textBox_Zaiko_ID.Location = new System.Drawing.Point(186, 179);
            this.textBox_Zaiko_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Zaiko_ID.Name = "textBox_Zaiko_ID";
            this.textBox_Zaiko_ID.Size = new System.Drawing.Size(193, 29);
            this.textBox_Zaiko_ID.TabIndex = 9;
            // 
            // comboBox_Meka_Namae
            // 
            this.comboBox_Meka_Namae.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.comboBox_Meka_Namae.FormattingEnabled = true;
            this.comboBox_Meka_Namae.Location = new System.Drawing.Point(541, 179);
            this.comboBox_Meka_Namae.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Meka_Namae.Name = "comboBox_Meka_Namae";
            this.comboBox_Meka_Namae.Size = new System.Drawing.Size(211, 30);
            this.comboBox_Meka_Namae.TabIndex = 10;
            // 
            // comboBox_Syouhin_Namae
            // 
            this.comboBox_Syouhin_Namae.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.comboBox_Syouhin_Namae.FormattingEnabled = true;
            this.comboBox_Syouhin_Namae.Location = new System.Drawing.Point(925, 178);
            this.comboBox_Syouhin_Namae.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Syouhin_Namae.Name = "comboBox_Syouhin_Namae";
            this.comboBox_Syouhin_Namae.Size = new System.Drawing.Size(214, 30);
            this.comboBox_Syouhin_Namae.TabIndex = 11;
            // 
            // domainUpDown_Zaikosuu
            // 
            this.domainUpDown_Zaikosuu.Font = new System.Drawing.Font("HGPｺﾞｼｯｸM", 11F, System.Drawing.FontStyle.Bold);
            this.domainUpDown_Zaikosuu.Location = new System.Drawing.Point(186, 290);
            this.domainUpDown_Zaikosuu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDown_Zaikosuu.Name = "domainUpDown_Zaikosuu";
            this.domainUpDown_Zaikosuu.Size = new System.Drawing.Size(192, 29);
            this.domainUpDown_Zaikosuu.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 362);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1179, 263);
            this.dataGridView1.TabIndex = 13;
            // 
            // Zaiko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(221)))), ((int)(((byte)(216)))));
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Zaiko";
            this.Size = new System.Drawing.Size(1238, 656);
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
    }
}
