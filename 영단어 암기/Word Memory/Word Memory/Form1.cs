
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Word_Memory
{
    public partial class Form1 : Form
    {
        public Label[] label = new Label[255];
        public mainWordListName[] mwln = new mainWordListName[255];
        public int lblCNT = 0;
        public bool[] lblClicked = new bool[255];

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 메뉴버튼 마우스 접근 동작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font, FontStyle.Underline | FontStyle.Bold);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font, FontStyle.Bold);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Font = new Font(label2.Font, FontStyle.Underline | FontStyle.Bold);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new Font(label2.Font, FontStyle.Bold);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font, FontStyle.Underline | FontStyle.Bold);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font, FontStyle.Bold);
        }

        /// <summary>
        /// 단어장 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            //폼 중복 열기 방지
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "addWordList") // 열린 폼의 이름 검사
                {
                    openForm.Activate();
                    return;
                }
            }
           
            addWordList awl = new addWordList();
            awl.getInfoForm1(this);
            awl.Show();

            
        }

        /// <summary>
        /// 단어장 클릭 동작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void label_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            int lblNum = Array.IndexOf(label,lbl);
            if (!lblClicked[lblNum])
            {
                mwln[lblNum] = new mainWordListName();
                mwln[lblNum].Name = "mwln" + lblNum.ToString();
                mwln[lblNum].Location = new Point(lbl.Location.X + lbl.Width / 2 - (mwln[lblNum].Width / 2), lbl.Location.Y + lbl.Height);
                panel1.Controls.Add(mwln[lblNum]);

                mwln[lblNum].getInfoMainForm(this, lblNum);

                //뒤에 있는 컨트롤 위치 조정
                for (int i = lblNum + 1; i < lblCNT; i++)
                {
                    foreach (Control control in panel1.Controls)
                    {
                        if (control.Name == "mwln" + i.ToString())
                        {
                            mwln[i].Location = new Point(mwln[i].Location.X, mwln[i].Location.Y + mwln[i].Height);
                            break;
                        }
                    }

                    label[i].Location = new Point(label[i].Location.X, label[i].Location.Y + mwln[lblNum].Height);
                }
                lblClicked[lblNum] = !lblClicked[lblNum];
            }
            else
            {
                foreach (Control control in panel1.Controls)
                {
                    if (control.Name == "mwln" + lblNum.ToString())
                    {
                        panel1.Controls.Remove(control);

                        //뒤에 있는 컨트롤 위치 조정
                        for (int i = lblNum + 1; i < lblCNT; i++)
                        {
                            foreach (Control ctr in panel1.Controls)
                            {
                                if (ctr.Name == "mwln" + i.ToString())
                                {
                                    mwln[i].Location = new Point(mwln[i].Location.X, mwln[i].Location.Y - mwln[i].Height);
                                    break;
                                }
                            }

                            label[i].Location = new Point(label[i].Location.X, label[i].Location.Y - mwln[lblNum].Height);
                        }
                        lblClicked[lblNum] = !lblClicked[lblNum];
                        break;
                    }
                }
               




            }
           


           
        }

    }
}
