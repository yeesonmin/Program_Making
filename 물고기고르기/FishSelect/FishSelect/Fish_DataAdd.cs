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
using System.Runtime.InteropServices;

namespace FishSelect
{
    public partial class Fish_DataAdd : Form
    {
        Excel.Application excelapp;
        Excel._Workbook excelworkbook;
        Excel._Worksheet excelsheet;
        Excel.Range oRng;

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


            //db경로
            string folderPath = System.Windows.Forms.Application.StartupPath;
            string dbPath = Path.GetFullPath(Path.Combine(folderPath, @"..\..\" + @"data\db"));


            //db 파일 유무확인
            string existFile = dbPath + "\\aquafishdb.xlsx";
            FileInfo fileInfo = new FileInfo(existFile);

            //db 파일 없으면 새로 만듬.
            if (!fileInfo.Exists)
            {
                try
                {
                    //Start Excel and get Application object.
                    excelapp = new Excel.Application();
                    excelapp.Visible = true;

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
                    int excelRowsCount = excelsheet.Rows.Row;
                    
                    excelsheet.Cells[1 + excelRowsCount, 1] = txt_FishNo.Text;
                    excelsheet.Cells[1 + excelRowsCount, 2] = cmb_FishClass.Text;
                    excelsheet.Cells[1 + excelRowsCount, 3] = txt_FishName.Text;
                    excelsheet.Cells[1 + excelRowsCount, 4] = txt_FishSize.Text;
                    excelsheet.Cells[1 + excelRowsCount, 5] = cmb_FishEat.Text;
                    excelsheet.Cells[1 + excelRowsCount, 6] = cmb_FishCharacter.Text;
                    excelsheet.Cells[1 + excelRowsCount, 7] = cmb_FishFloor.Text;
                    excelsheet.Cells[1 + excelRowsCount, 8] = cmb_WaterQuality.Text;
                    excelsheet.Cells[1 + excelRowsCount, 9] = cmb_WaterTH.Text;
                    excelsheet.Cells[1 + excelRowsCount, 10] = cmb_BreedDiff.Text;
                    excelsheet.Cells[1 + excelRowsCount, 11] = cmb_BreedingDiff.Text;
                    excelsheet.Cells[1 + excelRowsCount, 12] = cmb_JoinDiff.Text;
                    excelsheet.Cells[1 + excelRowsCount, 13] = txt_AddEx.Text;




                    //AutoFit columns A:D.
                    oRng = excelsheet.get_Range("A1", "M1");
                    oRng.EntireColumn.AutoFit();


                    //Make sure Excel is visible and give the user control
                    //of Microsoft Excel's lifetime.
                    excelapp.Visible = true;
                    excelapp.UserControl = true;

                    excelworkbook.SaveAs(existFile, Excel.XlFileFormat.xlWorkbookDefault); // 엑셀 파일 저장
                    excelworkbook.Close(true);
                    excelapp.Quit();


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
                finally
                {
                    ReleaseObject(excelsheet);
                    ReleaseObject(excelworkbook);
                    ReleaseObject(excelapp);
                }
            }
            else
            {
                try
                {
                    // 여기 부터 수정

                    excelapp = new Excel.Application();
                    excelapp.Visible = true;
                    excelworkbook = excelapp.Workbooks.Open(Filename: @existFile);
                    excelsheet = excelworkbook.Worksheets.Item[1];

                    // Create Data
                    int excelRowsCount = excelsheet.Rows.Row;

                    excelsheet.Cells[1 + excelRowsCount, 1] = txt_FishNo.Text;
                    excelsheet.Cells[1 + excelRowsCount, 2] = cmb_FishClass.Text;
                    excelsheet.Cells[1 + excelRowsCount, 3] = txt_FishName.Text;
                    excelsheet.Cells[1 + excelRowsCount, 4] = txt_FishSize.Text;
                    excelsheet.Cells[1 + excelRowsCount, 5] = cmb_FishEat.Text;
                    excelsheet.Cells[1 + excelRowsCount, 6] = cmb_FishCharacter.Text;
                    excelsheet.Cells[1 + excelRowsCount, 7] = cmb_FishFloor.Text;
                    excelsheet.Cells[1 + excelRowsCount, 8] = cmb_WaterQuality.Text;
                    excelsheet.Cells[1 + excelRowsCount, 9] = cmb_WaterTH.Text;
                    excelsheet.Cells[1 + excelRowsCount, 10] = cmb_BreedDiff.Text;
                    excelsheet.Cells[1 + excelRowsCount, 11] = cmb_BreedingDiff.Text;
                    excelsheet.Cells[1 + excelRowsCount, 12] = cmb_JoinDiff.Text;
                    excelsheet.Cells[1 + excelRowsCount, 13] = txt_AddEx.Text;

                    //AutoFit columns A:D.
                    oRng = excelsheet.get_Range("A1", "M1");
                    oRng.EntireColumn.AutoFit();


                    //Make sure Excel is visible and give the user control
                    //of Microsoft Excel's lifetime.
                    excelapp.Visible = true;
                    excelapp.UserControl = true;


                    excelworkbook.Save(); // 엑셀 파일 저장
                    excelworkbook.Close(true);
                    excelapp.Quit();
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
                finally
                {
                    ReleaseObject(excelsheet);
                    ReleaseObject(excelworkbook);
                    ReleaseObject(excelapp);
                }

            }
        }


        /// <summary> 
        /// 액셀 객체 해제 메소드 
        /// </summary>
        /// <param name="obj"></param>
        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj); // 액셀 객체 해제 
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null; throw ex;
            }
            finally
            {
                GC.Collect();
                // 가비지 수집 
            }
        }


    }
}
