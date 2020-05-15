using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace FishSelect
{
    public class DBOpen
    {
        bool saveCheck;
        public string existFile;
        public Excel.Application excelapp;
        public Excel._Workbook excelworkbook;
        public Excel._Worksheet excelsheet;


        public void DBFileOpen(Form1 fm1)
        {
            SaveCheck();

            //db 파일 없으면 새로 만듬.
            if (!saveCheck)
            {
                CreateDBFile();
            }
            else
            {
                Open();
            }

            //excel값 전달
            fm1.existFile = existFile;

        }
        void SaveCheck()
        {
            //db경로
            string folderPath = System.Windows.Forms.Application.StartupPath;
            string dbPath = Path.GetFullPath(Path.Combine(folderPath, @"..\..\" + @"data\db"));


            //db 파일 유무확인
            existFile = dbPath + "\\AquaFishDB.xlsx";
            FileInfo fileInfo = new FileInfo(existFile);
            saveCheck = fileInfo.Exists;

        }

        void CreateDBFile()
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

        void Open()
        {

            try
            {
                excelapp = new Excel.Application();
                excelapp.Visible = true;
                excelworkbook = excelapp.Workbooks.Open(Filename: @existFile);
                excelsheet = excelworkbook.Worksheets.Item[1];

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
