namespace SalesManagement_SysDev
{
    partial class Roguin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Syain_ID = new System.Windows.Forms.TextBox();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.button_Roguin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 19.875F);
            this.label1.Location = new System.Drawing.Point(175, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 143);
            this.label1.TabIndex = 0;
            this.label1.Text = "社員ID";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 19.875F);
            this.label2.Location = new System.Drawing.Point(175, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 143);
            this.label2.TabIndex = 1;
            this.label2.Text = "パスワード";
            // 
            // textBox_Syain_ID
            // 
            this.textBox_Syain_ID.Location = new System.Drawing.Point(667, 200);
            this.textBox_Syain_ID.Name = "textBox_Syain_ID";
            this.textBox_Syain_ID.Size = new System.Drawing.Size(731, 31);
            this.textBox_Syain_ID.TabIndex = 2;
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.Location = new System.Drawing.Point(667, 477);
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.Size = new System.Drawing.Size(731, 31);
            this.textBox_Pass.TabIndex = 3;
            // 
            // button_Roguin
            // 
            this.button_Roguin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(13)))), ((int)(((byte)(67)))));
            this.button_Roguin.Font = new System.Drawing.Font("ＭＳ ゴシック", 19.875F, System.Drawing.FontStyle.Bold);
            this.button_Roguin.ForeColor = System.Drawing.Color.White;
            this.button_Roguin.Location = new System.Drawing.Point(445, 647);
            this.button_Roguin.Name = "button_Roguin";
            this.button_Roguin.Size = new System.Drawing.Size(595, 88);
            this.button_Roguin.TabIndex = 4;
            this.button_Roguin.Text = "ログイン";
            this.button_Roguin.UseVisualStyleBackColor = false;
            this.button_Roguin.Click += new System.EventHandler(this.button_Roguin_Click);
            // 
            // Roguin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Roguin);
            this.Controls.Add(this.textBox_Pass);
            this.Controls.Add(this.textBox_Syain_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Roguin";
            this.Size = new System.Drawing.Size(1610, 875);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Syain_ID;
        private System.Windows.Forms.TextBox textBox_Pass;
        private System.Windows.Forms.Button button_Roguin;
    }
}
