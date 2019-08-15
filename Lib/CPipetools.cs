using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
    public class CPipetools
    {

        string m_Project_cd;
        string m_file_nm;
        public DataTable m_dt_line;
        public DataTable m_dt_지장물;
        public DataTable m_dt_포장;

        Dictionary<string, int> m_map_line;
        Dictionary<string, int> m_map_지장물;
        Dictionary<string, int> m_map_포장;


        List<string> list_line;
        List<string> list_지장물;
        List<string> list_포장;

        SpreadsheetControl m_SheetControl;

        public CPipetools( string project_cd, string file_nm, SpreadsheetControl SheetControl)
        {

            m_Project_cd = project_cd;
            m_file_nm = file_nm;
            m_SheetControl = SheetControl;

            m_dt_line = new DataTable();
            m_dt_지장물 = new DataTable();
            m_dt_포장 = new DataTable();

            m_map_line = new Dictionary<string, int>();
            m_map_지장물 = new Dictionary<string, int>();
            m_map_포장 = new Dictionary<string, int>();

            list_line = new List<string>();
            list_지장물 = new List<string>();
            list_포장= new List<string>();

            m_dt_line.Columns.Add(new DataColumn("project_cd", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("id", typeof(int)));
            m_dt_line.Columns.Add(new DataColumn("line_info", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("sheet_info", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("manhole_tp", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("dist2", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("gh", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("inv", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("dia", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("linename", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("pavement_type", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("slope", typeof(string)));
            m_dt_line.Columns.Add(new DataColumn("sheet_index", typeof(int)));

            m_dt_지장물.Columns.Add(new DataColumn("project_cd", typeof(string)));
            m_dt_지장물.Columns.Add(new DataColumn("id", typeof(int)));
            m_dt_지장물.Columns.Add(new DataColumn("line_info", typeof(string)));
            m_dt_지장물.Columns.Add(new DataColumn("sheet_info", typeof(string)));
            m_dt_지장물.Columns.Add(new DataColumn("measure_point", typeof(string)));
            m_dt_지장물.Columns.Add(new DataColumn("inv", typeof(string)));
            m_dt_지장물.Columns.Add(new DataColumn("dia", typeof(string)));
            m_dt_지장물.Columns.Add(new DataColumn("text", typeof(string)));
            m_dt_지장물.Columns.Add(new DataColumn("sheet_index", typeof(int)));

            m_dt_포장.Columns.Add(new DataColumn("project_cd", typeof(string)));
            m_dt_포장.Columns.Add(new DataColumn("id", typeof(int)));
            m_dt_포장.Columns.Add(new DataColumn("line_info", typeof(string)));
            m_dt_포장.Columns.Add(new DataColumn("sheet_info", typeof(string)));
            m_dt_포장.Columns.Add(new DataColumn("measure_point", typeof(string)));
            m_dt_포장.Columns.Add(new DataColumn("pavement_type", typeof(string)));
            m_dt_포장.Columns.Add(new DataColumn("sheet_index", typeof(int)));

            m_map_line.Add("맨홀구분", 0);
            m_map_line.Add("누가거리", 1);
            m_map_line.Add("지반고" , 2 );
            m_map_line.Add("관저고" , 3);
            m_map_line.Add("관경", 4);
            m_map_line.Add("맨홀", 5);
            m_map_line.Add("구간", 8);
            m_map_line.Add("구배", 9);


            m_map_지장물.Add("측점", 1);
            m_map_지장물.Add("INV", 2);
            m_map_지장물.Add("SIZE", 3);
            m_map_지장물.Add("TEXT", 4);

            m_map_포장.Add("포장측점", 1);
            m_map_포장.Add("포장구간", 2);

        }





        public void InitDataTable()
        {

            m_dt_line.Clear();
            m_dt_지장물.Clear();
            m_dt_포장.Clear();
        }



        public void LoadDataTools()
        {
            InitDataTable();

            IWorkbook workbook = m_SheetControl.Document;
            int itemIndex = 0;
            foreach (Worksheet item in workbook.Worksheets)
            {
                string SheetName = item.Name;
                ///sheet 이름에 "(H)" 가 포함된 쉬트는 무시한다.
                if (SheetName.Contains("(H)") == true)
                {
                    continue;
                }


                ///쉬트별로 데이터를 구성한다.
                GetSheetData(item);

                itemIndex++;
            }
        }

        public int GetSheetData(Worksheet sheet)
        {
            RowCollection Rows = sheet.Rows;
            int LastIndex = Rows.LastUsedIndex;

            Dictionary<string, int> map_section = new Dictionary<string, int>();


            for (int i = 0; i <= LastIndex; i++)
            {
                string str = sheet.Columns[1][i].Value.ToString();

                if (i == 0)
                {
                    map_section.Add("Header", 0);
                }

                if (str == "누가거리")
                {
                    map_section.Add("LINE", i);
                }
                else if (str == "측점")
                {
                    map_section.Add("지장물", i);
                }
                else if (str == "포장측점")
                {
                    map_section.Add("포장", i);
                }

            }


            GetLineData(sheet, map_section);
            Get지장물Data(sheet, map_section);
            Get포장Data(sheet, map_section);

                return 0;
        }


        /// <summary>
        /// LINE 정보를 DATA TABLE에 LOAD 한다.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public int GetLineData(Worksheet sheet, Dictionary<string, int> map)
        {

            RowCollection Rows = sheet.Rows;
            int LastIndex = Rows.LastUsedIndex;

            int index = 0;

            for (int i = map["LINE"]+1; i < map["지장물"]; i++)
            {
                DataRow dr = m_dt_line.NewRow();

                dr["project_cd"] = m_Project_cd;
                dr["id"] = index;
                dr["line_info"] = m_file_nm;
                dr["sheet_info"] = sheet.Name;
                dr["manhole_tp"] = Rows[i][m_map_line["맨홀구분"]].Value.ToString();
                dr["dist2"] = Rows[i][m_map_line["누가거리"]].Value.ToString();
                dr["gh"] = Rows[i][m_map_line["지반고"]].Value.ToString();
                dr["inv"] = Rows[i][m_map_line["관저고"]].Value.ToString();
                dr["dia"] = Rows[i][m_map_line["관경"]].Value.ToString();
                dr["linename"] = Rows[i][m_map_line["맨홀"]].Value.ToString();
                dr["pavement_type"] = Rows[i][m_map_line["구간"]].Value.ToString();
                dr["slope"] = Rows[i][m_map_line["구배"]].Value.ToString();
                dr["sheet_index"] = sheet.Index;


                if (dr["dist2"].ToString().Trim() != "")
                {
                    m_dt_line.Rows.Add(dr);
                    index++;
                }
            }

            return 0;
        }

        public int Get지장물Data(Worksheet sheet, Dictionary<string, int> map)
        {
            RowCollection Rows = sheet.Rows;
            int LastIndex = Rows.LastUsedIndex;

            int index = 0;
            int first;
            int last;
            //지장물 정보가 없을수도 있다
            if (map.ContainsKey("지장물") == false)
            {
                return 0;
            }
            else
            {
                first = map["지장물"] + 1;
            }

            //포장 정보가 없을수도 있다.
            if (map.ContainsKey("포장") == false)
            {
                last = LastIndex;
            }
            else
            {
                last = map["포장"]-1;
            }

            for (int i = first; i <= last; i++)
            {
                DataRow dr = m_dt_지장물.NewRow();

                dr["project_cd"] = m_Project_cd;
                dr["id"] = index;
                dr["line_info"] = m_file_nm;
                dr["sheet_info"] = sheet.Name;
                dr["measure_point"] = Rows[i][m_map_지장물["측점"]].Value.ToString();                
                dr["inv"] = Rows[i][m_map_지장물["INV"]].Value.ToString();
                dr["dia"] = Rows[i][m_map_지장물["SIZE"]].Value.ToString();
                dr["text"] = Rows[i][m_map_지장물["TEXT"]].Value.ToString();
                dr["sheet_index"] = sheet.Index;

                if (dr["measure_point"].ToString().Trim() != "")
                {
                    m_dt_지장물.Rows.Add(dr);
                    index++;
                }
            }


            return 0;
        }

        public int Get포장Data(Worksheet sheet, Dictionary<string, int> map)
        {
            RowCollection Rows = sheet.Rows;
            int LastIndex = Rows.LastUsedIndex;

            int index = 0;

            if (map.ContainsKey("포장") == false)
            {
                return 0;
            }


            for (int i = map["포장"] + 1; i <= LastIndex; i++)
            {
                DataRow dr = m_dt_포장.NewRow();

                dr["project_cd"] = m_Project_cd;
                dr["id"] = index;
                dr["line_info"] = m_file_nm;
                dr["sheet_info"] = sheet.Name;
                dr["measure_point"] = Rows[i][m_map_포장["포장측점"]].Value.ToString();
                dr["pavement_type"] = Rows[i][m_map_포장["포장구간"]].Value.ToString();
                dr["sheet_index"] = sheet.Index;

                if (dr["measure_point"].ToString().Trim() != "")
                {
                    m_dt_포장.Rows.Add(dr);
                    index++;
                }
            }


            return 0;
        }

    }
}
