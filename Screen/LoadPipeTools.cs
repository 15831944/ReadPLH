using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Lib;

namespace WindowsFormsApp1.Screen
{

    public partial class LoadPipeTools : WindowsFormsApp1.Base.XtraBaseForm
    {

        DataTable m_dt_line;
        DataTable m_dt_line_tmp;
        DataTable m_dt_g; //지장물 정보
        DataTable m_dt_구간; //포장구간 정보 

        DataTable m_dt_maxer;
        DataTable m_dt_maxer_tmp;
        

        Dictionary<string, int> line_map = new Dictionary<string, int>();
        Dictionary<string, int> 지장물_map = new Dictionary<string, int>();
        Dictionary<string, int> 구간_map = new Dictionary<string, int>();

        public LoadPipeTools()
        {
            InitializeComponent();


            m_dt_line = DsPipe.Tables["dt_line"];
            m_dt_line_tmp = DsPipe.Tables["dt_line"];
            
            m_dt_maxer_tmp = DsPipe.Tables["dt_maxer"];

            m_dt_maxer = m_dt_maxer_tmp.Clone();


            m_dt_g = DsPipe.Tables["dt_g"];
            m_dt_구간 = DsPipe.Tables["dt_구간"];

        }

        /// <summary>
        /// 모든 데이터를 초기화한다.
        /// </summary>
        public void initData()
        {
            m_dt_line.Clear();
            m_dt_line_tmp.Clear();
            m_dt_g.Clear();
            m_dt_구간.Clear();

            m_dt_maxer.Clear();
            m_dt_maxer_tmp.Clear();

            line_map.Clear();
            지장물_map.Clear();
            구간_map.Clear();
                
        }

        public void Set구간map()
        {

        }




        private void simpleButton1_Click(object sender, EventArgs e)
        {

           
        }


        /// <summary>
        /// PIPE TOOLS DATA를 불러온다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            XtraOpenFileDialog Opendlg = new XtraOpenFileDialog();

            Opendlg.Filter = "EXCEL 파일 (*.xlsx)|*.xlsx|모든파일(*.*)|*.*";


            if (Opendlg.ShowDialog() == DialogResult.OK)
            {
                string filename = Opendlg.FileName;

                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    ///EXCEL DATA를 Load 한다.
                    sheetPipeTools.LoadDocument(stream, DocumentFormat.Xlsx);
                }
            }

        }

        /// <summary>
        /// maxer Data로 변환한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxer_Click(object sender, EventArgs e)
        {
            //데이터 초기화
            initData();


            IWorkbook workbook = sheetPipeTools.Document;
            int itemIndex = 0;
            foreach (Worksheet item in workbook.Worksheets)
            {
                string SheetName = item.Name;
                ///sheet 이름에 "(H)" 가 포함된 쉬트는 무시한다.
                if (SheetName.Contains("(H)") == true)
                {
                    continue;
                }

                m_dt_line_tmp.Clear();
                m_dt_maxer_tmp.Clear();
                m_dt_g.Clear();
                m_dt_구간.Clear();

                ///쉬트별로 데이터를 구성한다.
                GetRows(item, itemIndex);

                itemIndex++;
            }

            ///결과를 출력해보자
            PrintMaxerData();
            
        }


        public void PrintMaxerData()
        {
            sheetMaxer.BeginUpdate();

            Worksheet sheet = sheetMaxer.Document.Worksheets[0];
            
            int i = 0;
            int DrCnt = 0;
            ///header 인쇄
            foreach (DataColumn col in m_dt_maxer.Columns)
            {
                sheet.Rows[0][i].Value = col.ColumnName;
                i++;
            }


            foreach (DataRow dr in m_dt_maxer.Rows)
            {
                DrCnt++;

                for (int j = 0; j < m_dt_maxer.Columns.Count; j++)
                {
                    sheet.Rows[DrCnt][j].Value = dr[m_dt_maxer.Columns[j]].ToString();
                }
            }

            sheetMaxer.EndUpdate();

            
        }


        /// <summary>
        /// Sheet 의 내용을 읽어 처리힌다. 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="itemIndex"></param>
        private void GetRows(Worksheet sheet , int itemIndex)
        {            
            string line_tp = "";

            RowCollection Rows = sheet.Rows;

            int LastIndex = Rows.LastUsedIndex;
            
            for (int i = 0; i <= LastIndex; i++)
            {
                string str = sheet.Columns[1][i].Value.ToString();                

                //header에 Hscale 이 있으면 그 다움줄은 Header 정보이다.
                if (sheet.Columns[1][i].Value.ToString() == "Hscale")
                {
                    line_tp = "header";
                    continue;
                }
                //누가거리가 있으면 그 다움줄은 관로정보이다.
                else if (sheet.Columns[1][i].Value.ToString() == "누가거리")
                {                    
                    line_tp = "line";
                    if (itemIndex == 0)
                    {
                        ///컬럼명 index를 지정한다.
                        SetLineMap(Rows[i]);
                    }                    
                    continue;
                }
                else if (sheet.Columns[1][i].Value.ToString() == "측점")
                {
                    line_tp = "지장물";
                    if (지장물_map.Count <= 0 )
                    {
                        SetXMap(Rows[i]);
                    }
                    continue;
                }
                else if (sheet.Columns[1][i].Value.ToString() == "포장측점")
                {
                    line_tp = "포장측점";

                    if (구간_map.Count <= 0)
                    {
                        Set구간Map(Rows[i]);
                    }
                    continue;
                }




                /// 데이터를 읽어 DATA TABLE에 추가한다.
                if (line_tp == "header")
                {

                }
                else if (line_tp == "line")
                {
                    AddLineData(Rows[i]);
                }
                else if (line_tp == "지장물")
                {
                    AddXData(Rows[i]);
                }
                else if (line_tp == "포장측점")
                {
                    AddGData(Rows[i]);
                }
            }


            ///sheet 내용을 읽어서 maxer Data Table을 구성한다.
            foreach (DataRow item in m_dt_line_tmp.Rows)
            {

                ///맨홀이고 맨홀이름이 있을때만 동작한다.
                if(item["manhole_tp"].ToString() == "P" &&
                   item["맨홀"].ToString().Trim() != ""
                   )
                {
                    

                    DataRow dr = m_dt_maxer_tmp.NewRow();

                    if (item["맨홀"].ToString().Trim() == "")
                    {
                        continue;
                    }

                    dr["관로"] = item["맨홀"].ToString();
                    dr["관로_key"] = item["key"].ToString();
                    try
                    {
                        m_dt_maxer_tmp.Rows.Add(dr);
                    }
                    catch (ConstraintException e)
                    {
                        continue;
                        
                    }
                    
                }
            }


            foreach (DataRow maxer_item in m_dt_maxer_tmp.Rows)
            {

                foreach (DataRow line_item in m_dt_line_tmp.Rows)
                {
                    if ( Convert.ToUInt32(maxer_item["관로_key"].ToString()) < Convert.ToUInt32(line_item["key"].ToString())  && 
                         line_item["manhole_tp"].ToString() == "P" && 
                         maxer_item["관로"].ToString() != line_item["맨홀"].ToString() &&
                         line_item["맨홀"].ToString().Trim() != ""
                         )
                    {
                        maxer_item["다음관로"] = line_item["맨홀"].ToString();
                        //maxer_item["연장"] = GetExtention(m_dt_line_tmp, ref maxer_item);
                        DataRow tmpRow = GetExtention(m_dt_line_tmp, maxer_item);
                        maxer_item["연장"] = tmpRow["연장"];
                        maxer_item["관경"] = tmpRow["관경"];
                        maxer_item["상류지반고"] = tmpRow["상류지반고"];
                        maxer_item["하류지반고"] = tmpRow["하류지반고"];
                        maxer_item["상류관저고"] = tmpRow["상류관저고"];
                        maxer_item["하류관저고"] = tmpRow["하류관저고"];
                        maxer_item["시작거리"] = tmpRow["시작거리"];
                        maxer_item["끝거리"] = tmpRow["끝거리"];
                        maxer_item["포장"] = tmpRow["포장"];

                        break;
                    }
                    
                }
            }



            
            ///m_dt_maxer_tmp에 관로는 있지만 다음관로가 없다면 
            ///마지막으로 인지하고 삭제한다. 
            ///

            if (m_dt_maxer_tmp.Rows[m_dt_maxer_tmp.Rows.Count -1]["다음관로"].ToString().Trim() == "")
            {
                m_dt_maxer_tmp.Rows[m_dt_maxer_tmp.Rows.Count - 1].Delete();
            }


            ///지장물 정보를 막서 데이터에 추가한다.
            ///
            foreach (DataRow maxer_item in m_dt_maxer_tmp.Rows)
            {
                DataRow tmpRow = Get지장물Data(maxer_item);

                maxer_item["지장물"] = tmpRow["지장물"];

            }

            ///구간 정보를 막서 데이터에 추가한다.
            ///
            foreach (DataRow maxer_item in m_dt_maxer_tmp.Rows)
            {
                DataRow tmpRow = Get구간Data(maxer_item);

                maxer_item["포장"] = tmpRow["포장"];

            }



            ///m_dt_maxer에 추가
            ///
            foreach (DataRow item in m_dt_maxer_tmp.Rows)
            {
                DataRow dr = m_dt_maxer.NewRow();
                dr.ItemArray = item.ItemArray;
                m_dt_maxer.Rows.Add(dr);
            }

            
        }

        private void SetLineMap(Row row)
        {        
                        
            for (int i = 0; i<m_dt_line.Columns.Count; i++)
            {
                string col_nm = m_dt_line.Columns[i].ColumnName;

                for (int j = 0; j < row.ColumnCount; j++)
                {
                    string str = row[j].Value.ToString();
                    if (row[j].Value.ToString() == col_nm)
                    {
                        line_map.Add(col_nm, j);
                        break;
                    }
                }
            }

        }

        private void SetXMap(Row row)
        {

            for (int i = 0; i < m_dt_g.Columns.Count; i++)
            {
                string col_nm = m_dt_g.Columns[i].ColumnName;

                for (int j = 0; j < row.ColumnCount; j++)
                {
                    string str = row[j].Value.ToString();
                    if (row[j].Value.ToString() == col_nm)
                    {
                        지장물_map.Add(col_nm, j);
                        break;
                    }
                }
            }

        }


        private void Set구간Map(Row row)
        {
            for (int i = 0; i < m_dt_구간.Columns.Count; i++)
            {
                string col_nm = m_dt_구간.Columns[i].ColumnName;

                for (int j = 0; j < row.ColumnCount; j++)
                {
                    string str = row[j].Value.ToString();
                    if (row[j].Value.ToString() == col_nm)
                    {
                        구간_map.Add(col_nm, j);
                        break;
                    }
                }
            }

        }

        private void AddLineData(Row  row)
        {
            DataRow dr = m_dt_line_tmp.NewRow();


            if (row[line_map["누가거리"]].Value.ToString().Trim() == "")
            {
                return;
            }

            dr["manhole_tp"]   = row[0].Value.ToString();
            dr["누가거리"]     = Convert.ToDouble(row[line_map["누가거리"]].Value.ToString());
            dr["지반고"]       = Convert.ToDouble(row[line_map["지반고"]].Value.ToString());
            dr["관저고"]       = Convert.ToDouble(row[line_map["관저고"]].Value.ToString());
            dr["관경"]         = Convert.ToDouble(row[line_map["관경"]].Value.ToString());
            dr["맨홀"]         = row[line_map["맨홀"]].Value.ToString();
            dr["TEXT1"]        = row[line_map["TEXT1"]].Value.ToString();
            dr["TEXT2"]        = row[line_map["TEXT2"]].Value.ToString();
            dr["구간"]         = row[line_map["구간"]].Value.ToString();
            dr["구배"]         = Convert.ToDouble(row[line_map["구배"]].Value.ToString());
            dr["INV"]          = Convert.ToDouble(row[line_map["INV"]].Value.NumericValue);
            dr["SIZE"]         = Convert.ToDouble(row[line_map["SIZE"]].Value.NumericValue);
            dr["라인명"]       = row[line_map["라인명"]].Value.ToString();
            dr["지하수위"]     = Convert.ToDouble(row[line_map["지하수위"]].Value.ToString());
            dr["맨홀INVERT"]   = row[line_map["맨홀INVERT"]].Value.ToString();

            m_dt_line_tmp.Rows.Add(dr);


        }


        /// <summary>
        /// 지장물 정보를 추가한다.
        /// </summary>
        /// <param name="row"></param>
        private void AddXData(Row row)
        {
            DataRow dr = m_dt_g.NewRow();


            if (row[지장물_map["측점"]].Value.ToString().Trim() == "")
            {
                return;
            }

            
            dr["측점"] = row[지장물_map["측점"]].Value.ToString();
            dr["INV"]  = Convert.ToDouble(row[지장물_map["INV"]].Value.ToString());
            dr["SIZE"] = Convert.ToDouble(row[지장물_map["SIZE"]].Value.ToString());
            dr["TEXT"] = row[지장물_map["TEXT"]].Value.ToString();

            m_dt_g.Rows.Add(dr);


        }

        /// <summary>
        /// 구간정보를 설정한다.
        /// </summary>
        /// <param name="row"></param>
        private void AddGData(Row row)
        {
            DataRow dr = m_dt_구간.NewRow();


            if (row[구간_map["포장측점"]].Value.ToString().Trim() == "")
            {
                return;
            }


            dr["포장측점"] = row[구간_map["포장측점"]].Value.ToString();
            dr["포장구간"] = row[구간_map["포장구간"]].Value.ToString();

            m_dt_구간.Rows.Add(dr);

        }


        private DataRow GetExtention(DataTable dt, DataRow maxer_item)
        {
            double extention = 0;

            double startpos = 0;
            double endpos = 0;
            double 관경 = 0;
            double 상류지반고 = 0;
            double 하류지반고 = 0;
            string 구간 = "";

            foreach (DataRow item in dt.Rows)
            {
                if (item["manhole_tp"].ToString() == "P")
                {
                    if (item["맨홀"].ToString() == maxer_item["관로"].ToString())
                    {
                        startpos = Convert.ToDouble(item["누가거리"].ToString());
                        관경     = Convert.ToDouble(item["관경"].ToString());
                        상류지반고 = Convert.ToDouble(item["지반고"].ToString());
                        구간 = item["구간"].ToString();                        
                        break;
                    }
                }
            }

            foreach (DataRow item in dt.Rows)
            {
                if (item["manhole_tp"].ToString() == "P")
                {
                    if (item["맨홀"].ToString() == maxer_item["다음관로"].ToString())
                    {
                        endpos = Convert.ToDouble(item["누가거리"].ToString());
                        하류지반고 = Convert.ToDouble(item["지반고"].ToString());
                        break;
                    }
                }
            }

            DataTable tmpdt = m_dt_maxer.Clone();
            tmpdt.Clear();
            DataRow Dr = tmpdt.NewRow();

            Dr["연장"] = endpos - startpos;
            Dr["관경"] = 관경;
            Dr["상류지반고"] = 상류지반고;
            Dr["하류지반고"] = 하류지반고;
            Dr["상류관저고"] = 상류지반고 - 1 - (관경/1000);
            Dr["하류관저고"] = 하류지반고 - 1;
            Dr["시작거리"] = startpos;
            Dr["끝거리"] = endpos;
            Dr["포장"] = CMaxerSector.SetData(0, 0, 구간);


            return Dr;
            
        }

        /// <summary>
        /// 지장물 정보를 설정한다.
        /// </summary>
        /// <param name="Dr"> m_dt_maxer_tmp</param>
        /// <returns></returns>
        private DataRow Get지장물Data(DataRow Dr)
        {

            DataTable tmpdt = m_dt_maxer.Clone();
            tmpdt.Clear();
            DataRow tmpdr = tmpdt.NewRow();


            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            provider.NumberGroupSizes = new int[] { 3 };


            foreach (DataRow g_item in m_dt_g.Rows)
            {
                string[] strData = g_item["측점"].ToString().Split('+');

                //실제 거리로 변환
                double dist1 = Convert.ToDouble(strData[0]) * 20; //20* n
                double dist2 = Convert.ToDouble(strData[1]);      // + n
                
                double dist = Math.Round(dist1 + dist2, 2);
                string str_g = "";

                double start_dist = Convert.ToDouble(Dr["시작거리"].ToString());

                if (start_dist == 75)
                {
                    string sss = "";
                }

                if (dist >= start_dist && dist <= Convert.ToDouble(Dr["끝거리"].ToString()))
                {
                    //X=70.30,42.66,0.06

                    if (Convert.ToDouble(Dr["시작거리"].ToString()) == 0)
                    {
                        str_g = string.Format("X={0}, {1}, {2};", dist, g_item["INV"].ToString(), Convert.ToDouble(g_item["SIZE"].ToString()) / 1000);
                    }
                    else
                    {
                        str_g = string.Format("X={0}, {1}, {2};", Math.Round(dist - start_dist, 2), g_item["INV"].ToString(), Convert.ToDouble(g_item["SIZE"].ToString()) / 1000);
                    }                    
                    tmpdr["지장물"] = tmpdr["지장물"].ToString().Trim() + str_g;
                }
            }

            return tmpdr;
        }


        /// <summary>
        /// 구간 정보 데이터를 막서 데이터에 추가한다.
        /// </summary>
        /// <param name="Dr"> m_dt_maxer_tmp</param>
        /// <returns></returns>
        private DataRow Get구간Data(DataRow Dr)
        {

            DataTable tmpdt = m_dt_maxer.Clone();
            tmpdt.Clear();
            DataRow tmpdr = tmpdt.NewRow();


            foreach (DataRow g_item in m_dt_구간.Rows)
            {
                string[] strData = g_item["포장측점"].ToString().Split('+');

                double dist1 = Convert.ToDouble(strData[0]) * 20;
                double dist2 = Convert.ToDouble(strData[1]);

                double dist = Math.Round(dist1 + dist2, 2);
                string str_g = "";

                double start_dist = Convert.ToDouble(Dr["시작거리"].ToString());

                if (dist >= start_dist  && dist <= Convert.ToDouble(Dr["끝거리"].ToString()))
                {
                    //X=70.30,42.66,0.06

                    if (Convert.ToDouble(Dr["시작거리"].ToString()) == 0)
                    {
                        str_g = CMaxerSector.SetData(dist, Convert.ToDouble(Dr["하류지반고"].ToString()), g_item["포장구간"].ToString());// string.Format("X={0}, {1}, {2};", dist, g_item["INV"].ToString(), Convert.ToDouble(g_item["SIZE"].ToString()) / 1000);
                    }
                    else
                    {
                        str_g = CMaxerSector.SetData(Math.Round(dist - start_dist, 2), Convert.ToDouble(Dr["하류지반고"].ToString()), g_item["포장구간"].ToString());//string.Format("X={0}, {1}, {2};", dist2, g_item["INV"].ToString(), Convert.ToDouble(g_item["SIZE"].ToString()) / 1000);
                    }
                    tmpdr["포장"] = tmpdr["포장"].ToString().Trim() + str_g;
                }
            }

            return tmpdr;
        }
    }
}
