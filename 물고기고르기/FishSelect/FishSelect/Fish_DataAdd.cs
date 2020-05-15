using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace FishSelect
{
    public partial class Fish_DataAdd : Form
    {
        public string existFile;


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
            DBSave S = new DBSave();
            S.SaveDBFile(this);
            
        }

        private void Fish_DataAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
