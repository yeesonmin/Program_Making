namespace Word_Memory
{
    partial class mainWordListName
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_study = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_list = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_study
            // 
            this.btn_study.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_study.Location = new System.Drawing.Point(364, 5);
            this.btn_study.Name = "btn_study";
            this.btn_study.Size = new System.Drawing.Size(64, 30);
            this.btn_study.TabIndex = 0;
            this.btn_study.Text = "학습";
            this.btn_study.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_print.Location = new System.Drawing.Point(276, 5);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(64, 30);
            this.btn_print.TabIndex = 0;
            this.btn_print.Text = "프린트";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_add.Location = new System.Drawing.Point(188, 5);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(64, 30);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "단어추가";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // btn_list
            // 
            this.btn_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_list.Location = new System.Drawing.Point(100, 5);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(64, 30);
            this.btn_list.TabIndex = 0;
            this.btn_list.Text = "단어목록";
            this.btn_list.UseVisualStyleBackColor = true;
            // 
            // btn_setting
            // 
            this.btn_setting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_setting.Location = new System.Drawing.Point(12, 5);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(64, 30);
            this.btn_setting.TabIndex = 0;
            this.btn_setting.Text = "설정";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_study, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_setting, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_print, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_list, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_add, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 40);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // mainWordListName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "mainWordListName";
            this.Size = new System.Drawing.Size(443, 43);
            this.Load += new System.EventHandler(this.mainWordListName_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_study;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_list;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
