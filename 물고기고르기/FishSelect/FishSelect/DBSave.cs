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
        bool check = false;

        /// <summary>
        /// 엑셀파일 문제가 없으면 저장
        /// </summary>
        /// <param name="FD"></param>
        public void SaveDBFile(Fish_DataAdd FD)
        {
            try
            {
                Form1 fm1 = (Form1)Application.OpenForms["Form1"];//실행중인 폼 정보 전달
                existFile = fm1.existFile;
                excelapp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                excelworkbook = excelapp.Workbooks.Open(Filename: @existFile);
                excelsheet = excelworkbook.Worksheets.Item[1];
                int excelRowsCount = excelsheet.UsedRange.Rows.Count;

                if(!check)
                {
                    // Create Data
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
                }else
                {
                    if(MessageBox.Show("중복된 데이터가 있습니다. 저장하시겠습니까?", "중복된 데이터", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        // Create Data
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
                    
                }

               

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

        /// <summary>
        /// 엑셀에 물고기번호(기본키)가 중복되는지 확인.
        /// </summary>
        void DataCheck(Form1 fm1, Fish_DataAdd fd, Excel.Application excelapp, Excel._Workbook excelworkbook, Excel._Worksheet excelsheet, int excelRowsCount)
        {
            string checkNo = fd.txt_FishNo.Text;
            check = false;

            for(int i = 2; i<= excelRowsCount + 1; i++)
            {
                if(checkNo == excelsheet.Cells[i,1])
                {
                    check = true;
                    break;
                }
            }
        }
        
       
       

    }
}
