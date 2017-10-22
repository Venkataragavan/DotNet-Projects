using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Outlook_Project
{
    internal class ExcelApplication
    {
        public ExcelApplication()
        {
            
        }

        public void WritetoExcel(string Text)
        {
            Excel.Application MyApplication = new Excel.Application();
            string Path = "C:\\Users\\Venkataragavan\\Documents\\Desktop";
            MyApplication.Workbooks.Open(Path);
            int rowID = 1, columnID = 4;
            Excel.Workbook book;

            MyApplication.Cells[rowID, columnID] = Text;
            Excel.Application workbooks = new Excel.Application();
            book=(Excel.Workbook)MyApplication.Workbooks.Open(Path);
            book.SaveAs("C:\\Users\\Venkataragavan\\Documents\\Test.xlsx");
            //MyApplication.Visible = true;
            book.Close();
            MyApplication.Workbooks.Close();
            Console.WriteLine("Saved");

            
        }

        
    }
}