using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Word_Memory
{
    public partial class addWordList : Form
    {
        Form1 form1 = new Form1();
        Label[] label = new Label[255];
        int lblCNT = 0;
        public addWordList()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 추가버튼 활성화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.TextLength>0)
            {
                foreach (Control control in form1.panel1.Controls)
                {
                    if (control.Name.Contains("lbl"))
                    {
                        if (textBox1.Text == control.Text)
                        {
                            button2.Enabled = false;
                            return;
                        }
                    }

                }
                button2.Enabled = true;

            }else
            {
                button2.Enabled = false;
            }
           

        }

        /// <summary>
        /// 단어장 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int mwlnHeights = 0;
            int lblHeights = 0;
            label[lblCNT] = new Label();
            label[lblCNT].Name = "lbl" + lblCNT.ToString();
            label[lblCNT].AutoSize = false;
            label[lblCNT].Font = new Font("굴림", 11);
            label[lblCNT].Text = textBox1.Text;
            label[lblCNT].Cursor = Cursors.Hand;

            
            //단어장 유무 확인


            //앞에 있는 컨트롤 위치 저장 후 라벨 위치 설정
            foreach (Control control in form1.panel1.Controls)
            {
                if (control.Name.Contains("mwln"))
                {
                    mwlnHeights += control.Height;
                }
                if(control.Name.Contains("lbl"))
                {
                    lblHeights += label[lblCNT].Height;
                }
            }


            label[lblCNT].Location = new Point((form1.panel1.Width / 2) - (label[lblCNT].Width / 2), ((form1.panel1.Height / 6) - (label[lblCNT].Height / 2)) + lblHeights + mwlnHeights);
            label[lblCNT].Click += new EventHandler(form1.label_Click);
            form1.panel1.Controls.Add(label[lblCNT]);
            lblCNT++;

            //데이터 전달
            form1.label = label;
            form1.lblCNT = lblCNT;

            this.Close();
        }

        public void getInfoForm1(Form1 fm)
        {
            label = fm.label;
            lblCNT = fm.lblCNT;
            form1 = fm;
        }

      
    }
}
