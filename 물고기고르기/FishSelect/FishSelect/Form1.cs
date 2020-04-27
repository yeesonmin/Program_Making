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
    public partial class Form1 : Form
    {
        public bool open = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
