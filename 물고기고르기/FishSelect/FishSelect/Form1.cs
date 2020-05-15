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
    public partial class Form1 : Form
    {
        public bool open = false;
        public string existFile;//파일 주소 저장

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBOpen dbopen = new DBOpen();
            dbopen.DBFileOpen(this);
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if(open ==false)
            {
                Fish_DataAdd fda = new Fish_DataAdd();
                fda.Show();
            }
           open = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBClose dpclose = new DBClose();
            dpclose.DBFileCloes();
        }
    }
}
