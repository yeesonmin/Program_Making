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
       

        public Fish_DataAdd()
        {
            InitializeComponent();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            
            this.Close();


        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveDB S = new SaveDB();
            S.SaveDBFile(this);
            
        }

        private void txt_FishNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
