using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Word_Memory
{
    public partial class mainWordListName : UserControl
    {
        public int lblNum = 0;
        public Label label = new Label();
        public Form1 form1 = new Form1();
        public mainWordListName()
        {
            InitializeComponent();
        }

        private void mainWordListName_Load(object sender, EventArgs e)
        {

        }

        public void getInfoMainForm(Form1 fm, int cnt)
        {
            form1 = fm;
            lblNum = cnt;
            label = fm.label[lblNum];
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
            setting.getInfoWLN(this);
        }
    }
}
