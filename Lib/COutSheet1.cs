using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
    class COutSheet1
    {
        public DataTable m_dt_plh;
        public DataTable m_dt_pld;
        public SpreadsheetControl m_SpreadSheet;
        public int m_Sheet_idx;


        public COutSheet1(DataTable dt_plh, DataTable dt_pld, SpreadsheetControl SpreadSheet)
        {
            m_dt_plh = dt_plh;
            m_dt_pld = dt_pld;
            m_SpreadSheet = SpreadSheet;


        }

        public void LoadData( )
        {
            String tmp_linename = "";

            foreach (DataRow item in m_dt_plh.Rows)
            {




                int idx = item["linename"].ToString().LastIndexOf('-');
                int length = item["linename"].ToString().Trim().Length;


                if (tmp_linename != item["linename"].ToString().Substring(0, length - idx) )
                {
                    tmp_linename = item["linename"].ToString().Substring(0, length - idx);
                    //새로운 라인이면 Sheet를 분리한다.
                    AddSheet(tmp_linename);

                }
                else
                {

                }




            }

        }

        private Worksheet AddSheet(string SheetName)
        {
            

            Worksheet sheet = m_SpreadSheet.Document.Worksheets.Insert(m_Sheet_idx);
            sheet.Name = SheetName;
            AddHead1(sheet);
            m_Sheet_idx++;

            return sheet;
        }


        public void AddHead1(Worksheet sheet)
        {

        }


        public void AddHead2(Worksheet sheet)
        {

        }


        private void SetCellStyle(Cell cell, bool isBold, int fontSize, Color fillColor)
        {
            cell.Font.Bold = isBold;
            cell.Font.Size = fontSize;
            cell.FillColor = fillColor;
            cell.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }


    }
}
