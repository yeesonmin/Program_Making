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
using System.Reflection;
using System.IO;

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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Excel.Application excelapp;
            Excel._Workbook excelworkbook;
            Excel._Worksheet excelsheet;
            Excel.Range oRng;

            //db경로
            string folderPath = System.Windows.Forms.Application.StartupPath;
            string dbPath = Path.GetFullPath(Path.Combine(folderPath, @"..\..\" + @"data\db"));


            //db 파일 유무확인
            string existFile = dbPath + "\\aquafishdb.xlsx";
            FileInfo fileInfo = new FileInfo(existFile);

            //db 파일 없으면 새로 만듬.
            if(!fileInfo.Exists)
            {
                try
                {
                    //Start Excel and get Application object.
                    excelapp = new Excel.Application();
                   // excelapp.Visible = true;

                    //Get a new workbook.
                    excelworkbook = excelapp.Workbooks.Add();
                    excelsheet = excelworkbook.Worksheets.get_Item(1) as Excel.Worksheet;

                    //Add table headers going cell by cell.
                    excelsheet.Cells[1, 1] = "물고기 번호";
                    excelsheet.Cells[1, 2] = "물고기 과/류";
                    excelsheet.Cells[1, 3] = "물고기 이름";
                    excelsheet.Cells[1, 4] = "물고기 크기";
                    excelsheet.Cells[1, 5] = "물고기 먹성";
                    excelsheet.Cells[1, 6] = "물고기 성격";
                    excelsheet.Cells[1, 7] = "물고기 서식층";
                    excelsheet.Cells[1, 8] = "적정수질";
                    excelsheet.Cells[1, 9] = "적정온도";
                    excelsheet.Cells[1, 10] = "사육 난이도";
                    excelsheet.Cells[1, 11] = "번식 난이도";
                    excelsheet.Cells[1, 12] = "합사 난이도";
                    excelsheet.Cells[1, 13] = "물고기 부과설명";


                    //Format A1:M1 as bold, vertical alignment = center.
                    excelsheet.get_Range("A1", "M1").Font.Bold = true;
                    excelsheet.get_Range("A1", "M1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;

                    // Create Data
                    int excelRowsCount = excelsheet.Rows.Count;
                    ////////////////////////// 여기 부터 할 차례
                    excelsheet.Cells[1, 1] = "물고기 번호";
                    excelsheet.Cells[1, 2] = "물고기 과/류";
                    excelsheet.Cells[1, 3] = "물고기 이름";
                    excelsheet.Cells[1, 4] = "물고기 크기";
                    excelsheet.Cells[1, 5] = "물고기 먹성";
                    excelsheet.Cells[1, 6] = "물고기 성격";
                    excelsheet.Cells[1, 7] = "물고기 서식층";
                    excelsheet.Cells[1, 8] = "적정수질";
                    excelsheet.Cells[1, 9] = "적정온도";
                    excelsheet.Cells[1, 10] = "사육 난이도";
                    excelsheet.Cells[1, 11] = "번식 난이도";
                    excelsheet.Cells[1, 12] = "합사 난이도";
                    excelsheet.Cells[1, 13] = "물고기 부과설명";
                    string[,] addData = new string[excelsheet.Rows.Count + 1, 2];

                    addData[0, 0] = "John";
                   

                    //Fill A2:B6 with an array of values (First and Last Names).
                    excelsheet.get_Range("A2", "B6").Value2 = saNames;

          

                    //AutoFit columns A:D.
                    oRng = excelsheet.get_Range("A1", "M1");
                    oRng.EntireColumn.AutoFit();


                    //Make sure Excel is visible and give the user control
                    //of Microsoft Excel's lifetime.
                    excelapp.Visible = true;
                    excelapp.UserControl = true;
                }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);

                    MessageBox.Show(errorMessage, "Error");
                }
            }
            else
            {
                MessageBox.Show("데이터 있다.");
            }
        }
            

       
    }
}
