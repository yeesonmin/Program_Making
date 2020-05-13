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
    public class SaveDB : Fish_DataAdd
    {

        bool saveCheck;
        string existFile;
        Excel.Application excelapp;
        Excel._Workbook excelworkbook;
        Excel._Worksheet excelsheet;
        Excel.Range oRng;
        
        

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

        public void SaveDBFile(Fish_DataAdd FD)
        {
            SaveCheck();

            //db 파일 없으면 새로 만듬.
            if (!saveCheck)
            {
                CreateDBFile(FD);
            }
            else
            {
                AddDB(FD);
            }
        }

        void CreateDBFile(Fish_DataAdd FD)
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

                excelsheet.Cells[1 + excelRowsCount, 1] = FD.txt_FishNo.Text;
                excelsheet.Cells[1 + excelRowsCount, 2] = FD.cmb_FishClass.Text;
                excelsheet.Cells[1 + excelRowsCount, 3] = FD.txt_FishName.Text;
                excelsheet.Cells[1 + excelRowsCount, 4] = FD.txt_FishSize.Text;
                excelsheet.Cells[1 + excelRowsCount, 5] = FD.cmb_FishEat.Text;
                excelsheet.Cells[1 + excelRowsCount, 6] = FD.cmb_FishCharacter.Text;
                excelsheet.Cells[1 + excelRowsCount, 7] = FD.cmb_FishFloor.Text;
                excelsheet.Cells[1 + excelRowsCount, 8] = FD.cmb_WaterQuality.Text;
                excelsheet.Cells[1 + excelRowsCount, 9] = FD.cmb_WaterTH.Text;
                excelsheet.Cells[1 + excelRowsCount, 10] = FD.cmb_BreedDiff.Text;
                excelsheet.Cells[1 + excelRowsCount, 11] = FD.cmb_BreedingDiff.Text;
                excelsheet.Cells[1 + excelRowsCount, 12] = FD.cmb_JoinDiff.Text;
                excelsheet.Cells[1 + excelRowsCount, 13] = FD.txt_AddEx.Text;




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

        void AddDB(Fish_DataAdd FD)
        {
            
            try
            {
                excelapp = new Excel.Application();
                excelapp.Visible = true;
                excelworkbook = excelapp.Workbooks.Open(Filename: @existFile);
                excelsheet = excelworkbook.Worksheets.Item[1];

                // Create Data
                int excelRowsCount = excelsheet.UsedRange.Rows.Count;


                excelsheet.Cells[1 + excelRowsCount, 1] = FD.txt_FishNo.Text;
                excelsheet.Cells[1 + excelRowsCount, 2] = FD.cmb_FishClass.Text;
                excelsheet.Cells[1 + excelRowsCount, 3] = FD.txt_FishName.Text;
                excelsheet.Cells[1 + excelRowsCount, 4] = FD.txt_FishSize.Text;
                excelsheet.Cells[1 + excelRowsCount, 5] = FD.cmb_FishEat.Text;
                excelsheet.Cells[1 + excelRowsCount, 6] = FD.cmb_FishCharacter.Text;
                excelsheet.Cells[1 + excelRowsCount, 7] = FD.cmb_FishFloor.Text;
                excelsheet.Cells[1 + excelRowsCount, 8] = FD.cmb_WaterQuality.Text;
                excelsheet.Cells[1 + excelRowsCount, 9] = FD.cmb_WaterTH.Text;
                excelsheet.Cells[1 + excelRowsCount, 10] = FD.cmb_BreedDiff.Text;
                excelsheet.Cells[1 + excelRowsCount, 11] = FD.cmb_BreedingDiff.Text;
                excelsheet.Cells[1 + excelRowsCount, 12] = FD.cmb_JoinDiff.Text;
                excelsheet.Cells[1 + excelRowsCount, 13] = FD.txt_AddEx.Text;

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
