namespace Word_Memory
{
    partial class addWord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_word = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.rbtn_Direct = new System.Windows.Forms.RadioButton();
            this.rbtn_Dic = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_mean = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_word
            // 
            this.tb_word.Font = new System.Drawing.Font("굴림", 10F);
            this.tb_word.Location = new System.Drawing.Point(6, 25);
            this.tb_word.Name = "tb_word";
            this.tb_word.Size = new System.Drawing.Size(406, 23);
            this.tb_word.TabIndex = 0;
            this.tb_word.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_word_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.rbtn_Direct);
            this.groupBox1.Controls.Add(this.tb_word);
            this.groupBox1.Controls.Add(this.rbtn_Dic);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "단어";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "뜻 입력 방법";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(418, 25);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(82, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "검색";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // rbtn_Direct
            // 
            this.rbtn_Direct.AutoSize = true;
            this.rbtn_Direct.Location = new System.Drawing.Point(103, 76);
            this.rbtn_Direct.Name = "rbtn_Direct";
            this.rbtn_Direct.Size = new System.Drawing.Size(71, 16);
            this.rbtn_Direct.TabIndex = 3;
            this.rbtn_Direct.TabStop = true;
            this.rbtn_Direct.Text = "직접입력";
            this.rbtn_Direct.UseVisualStyleBackColor = true;
            // 
            // rbtn_Dic
            // 
            this.rbtn_Dic.AutoSize = true;
            this.rbtn_Dic.Location = new System.Drawing.Point(5, 76);
            this.rbtn_Dic.Name = "rbtn_Dic";
            this.rbtn_Dic.Size = new System.Drawing.Size(83, 16);
            this.rbtn_Dic.TabIndex = 2;
            this.rbtn_Dic.TabStop = true;
            this.rbtn_Dic.Text = "네이버사전";
            this.rbtn_Dic.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.tb_mean);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 265);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "뜻";
            // 
            // tb_mean
            // 
            this.tb_mean.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tb_mean.Font = new System.Drawing.Font("굴림", 10F);
            this.tb_mean.Location = new System.Drawing.Point(8, 20);
            this.tb_mean.Multiline = true;
            this.tb_mean.Name = "tb_mean";
            this.tb_mean.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_mean.Size = new System.Drawing.Size(492, 230);
            this.tb_mean.TabIndex = 0;
            // 
            // addWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "addWord";
            this.Text = "단어추가";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.addWord_FormClosing);
            this.Load += new System.EventHandler(this.addWord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_word;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_mean;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.RadioButton rbtn_Direct;
        private System.Windows.Forms.RadioButton rbtn_Dic;
        private System.Windows.Forms.Label label1;
    }
}