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
    public class DBSave : DBOpen
    {

        
        public void SaveDBFile(Fish_DataAdd FD)
        {
            try
            {
                Form1 fm1 = (Form1)Application.OpenForms["Form1"];//실행중인 폼 정보 전달
                existFile = fm1.existFile;
                excelapp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
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

              
                excelworkbook.Save(); // 엑셀 파일 저장

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

        
       
       

    }
}
