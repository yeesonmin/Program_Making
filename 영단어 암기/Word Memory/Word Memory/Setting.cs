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
    public partial class Setting : Form
    {
        public int lblNum = 0;
        Label label = new Label();
        Form1 form1 = new Form1();

        public Setting()
        {
            InitializeComponent();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 단어장 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        ///////오류 있다.
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("단어장을 삭제하겠습니까?", "단어장 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                foreach (Control control in form1.panel1.Controls)
                {
                    if (control.Name == "mwln" + lblNum.ToString())
                    {
                        //라벨 및 속성 창 제거
                        form1.panel1.Controls.Remove(control);
                        form1.panel1.Controls.Remove(form1.label[lblNum]);

                        //뒤에 있는 컨트롤 위치 조정
                        for (int i = lblNum + 1; i < form1.lblCNT; i++)
                        {
                            foreach (Control ctr in form1.panel1.Controls)
                            {
                                if (ctr.Name == "mwln" + i.ToString())
                                {
                                    form1.mwln[i].Location = new Point(form1.mwln[i].Location.X, form1.mwln[i].Location.Y - form1.mwln[i].Height - form1.label[i].Height);
                                    break;
                                }
                            }

                            form1.label[i].Location = new Point(form1.label[i].Location.X, form1.label[i].Location.Y - form1.mwln[lblNum].Height - form1.label[i].Height);
                        }
                        form1.lblClicked[lblNum] = !form1.lblClicked[lblNum];
                        break;
                    }
                }

                this.Close();

            }
            
        }

        /// <summary>
        /// 메인폼 정보를 wln에서 받음.
        /// </summary>
        /// <param name="wln"></param>
        public void getInfoWLN(mainWordListName wln)
        {
            form1 = wln.form1;
            lblNum = wln.lblNum;
            label = wln.label;
        }
    }
}
