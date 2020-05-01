using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishSelect
{
    public partial class Fish_DataAdd : Form
    {
        DataSet ds = new DataSet();

        public Fish_DataAdd()
        {
            InitializeComponent();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 저장버튼을 누르면 테이블을 만들고 테이블을 ds에 저장.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool bCheckIsTalbe = false;

            // DataSet안에 해당하는 DataTable이 있는지 확인 한다
            if (ds.Tables.Contains(cboxRegClass.Text))
            {
                bCheckIsTalbe = true;
            }


       
        }
    }
}
