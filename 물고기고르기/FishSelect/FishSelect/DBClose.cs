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
    class DBClose : DBSave
    {
        public Excel.Range oRng;

        public void DBFileCloes()
        {
            try
            {
                Form1 fm1 = (Form1)Application.OpenForms["Form1"];
                existFile = fm1.existFile;
                excelapp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                excelworkbook = excelapp.Workbooks.Open(Filename: @existFile);
                excelsheet = excelworkbook.Worksheets.Item[1];



                //AutoFit columns A:D.
                oRng = excelsheet.get_Range("A1", "M1");
                oRng.EntireColumn.AutoFit();

           
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
