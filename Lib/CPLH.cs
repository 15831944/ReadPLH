using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Lib;

namespace WindowsFormsApp1
{
    public class CPLH
    {

        public enum enumPLH
        {
            [CGetName("key")]
            key,
            [CGetName("order_seq")]
            order_seq,            
            [CGetName("FileName")]
            FileName,
            [CGetName("NO.")]
            [CGetLength(6)]       
            [CFormat("{0,-6}")]  //왼쪽정렬
            NO,
            [CGetName("ASP+CON")]
            ASP_CON,
            [CGetName("+")]
            [CGetLength(12)]
            [CFormat("{0,-12}")]
            plus,
            [CGetName("dist")]
            [CGetLength(6)]
            [CFormat("{0,6:#0.00}")]
            dist,
            [CGetName("dist2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]
            dist2,
            [CGetName("gh")]            
            [CGetLength(7)]
            [CFormat("{0,7:#0.00}")]
            gh,
            [CGetName("INV")]            
            [CGetLength(7)]
            [CFormat("{0,7:##0.00}")]
            INV,
            [CGetName("Filler1")]
            [CGetLength(1)]
            [CFormat("{0,-1}")]
            Filler1,
            [CGetName("LINENAME")]
            [CGetLength(19)]
            [CFormat("{0,-19}")]
            LINENAME,
            [CGetName("DIA")]            
            [CGetLength(5)]
            [CFormat("{0,5:#0.00}")]
            DIA,
            [CGetName("BR")]            
            [CGetLength(5)]
            [CFormat("{0,5:#0.00}")]
            BR,
            [CGetName("type")]            
            [CGetLength(3)]
            [CFormat("{0,3:##0}")]
            type,
            [CGetName("T1")]            
            [CGetLength(6)]
            [CFormat("{0,6:#0.000}")]
            T1,
            [CGetName("Filler3")]
            [CGetLength(1)]
            [CFormat("{0,-1}")]
            Filler3,
            [CGetName("SLOPE")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            SLOPE,
            [CGetName("Bcut")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            Bcut,
            [CGetName("Hcut")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            Hcut,
            [CGetName("manwork")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            manwork,
            [CGetName("sand")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            sand,
            [CGetName("concA")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            concA,
            [CGetName("concB")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            concB,
            [CGetName("humanity")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            humanity,
            [CGetName("concrete")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            concrete,
            [CGetName("asphalt1")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asphalt1,
            [CGetName("asphalt2")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asphalt2,
            [CGetName("complay")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            complay,
            [CGetName("mixlay")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            mixlay,
            [CGetName("mixlay1")]
            [CGetLength(10)]
            [CFormat("{0,10:###0}")]
            mixlay1,
            [CGetName("mixlay2")]
            [CFormat("{0,10:#0.00}")]
            [CGetLength(10)]
            mixlay2,
            [CGetName("area1")]
            [CFormat("{0,10:#0.000}")]
            [CGetLength(10)]
            area1,
            [CGetName("area2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area2, //관주위
            [CGetName("area3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area3, //관상단
            [CGetName("area4")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area4,
            [CGetName("area5")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area5,
            [CGetName("area6")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area6,
            [CGetName("area7")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area7,
            [CGetName("area8")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area8,
            [CGetName("area9")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area9,
            [CGetName("area10")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area10,
            [CGetName("area11")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area11,
            [CGetName("T2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            T2,
            [CGetName("T3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            T3,
            [CGetName("T4")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            T4,
            [CGetName("B")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            B,
            [CGetName("H")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            H,
            [CGetName("Filler4")]
            [CGetLength(2)]
            [CFormat("{0,-2}")]
            Filler4,
            [CGetName("DIR")]
            [CGetLength(30)] //마지막 필드는 고정값이 아니라서 좀 넉넉히 잡음
            [CFormat("{0,-30}")]
            DIR,
            [CGetName("B2")]
            B2,
            [CGetName("INV2")]
            INV2,
            [CGetName("DIA2")]
            DIA2,
            [CGetName("BaseAngle")]
            [CGetLength(10)]
            [CFormat("{0,10:##0}")]
            BaseAngle,
            [CGetName("check")]
            check,
            [CGetName("Section")]
            [CGetLength(20)]            
            Section //구간정보
        }

        public DataTable m_dt = new DataTable();
        public int m_key = 0;

        public string dirPath_save = ""; //저장될 dir Path
        public const string DEF_TABLE_NAME = "PLH_TABLE";
        public const string DEF_XML_FILE = "PLH.xml";

        public CPLH(DataTable Dt)
        {
            m_dt = Dt;
            m_dt.TableName = DEF_TABLE_NAME;
        }

        public CPLH()
        {
            m_dt.TableName = DEF_TABLE_NAME;

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.key), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.order_seq), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.FileName), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.NO), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.ASP_CON), typeof(bool)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.plus), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.dist), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.dist2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.gh), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.INV), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.LINENAME), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.DIA), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.BR), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.type), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.T1), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.SLOPE), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.Bcut), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.Hcut), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.manwork), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.sand), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.concA), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.concB), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.humanity), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.concrete), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.asphalt1), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.asphalt2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.complay), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.mixlay), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.mixlay1), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.mixlay2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area1), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area3), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area4), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area5), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area6), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area7), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area8), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area9), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area10), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area11), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.T2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.T3), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.T4), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.B), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.H), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.DIR), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.B2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.INV2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.DIA2), typeof(String)));
                        DataColumn dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumPLH.BaseAngle);
            dc.DataType = typeof(String);
            dc.DefaultValue = "0";

            m_dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumPLH.check);
            //dc.DataType = typeof(Boolean);
            dc.DefaultValue = "false";
            

            m_dt.Columns.Add(dc);

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.Section), typeof(String)));
            //m_dt.Columns.Add(new DataColumn("BaseAngle", typeof(String)));
            //m_dt.Columns.Add(new DataColumn("check", typeof(Boolean)));

        }

        public String Convert(String inString)
        {
            return inString.Trim();
        }

        /// <summary>
        /// 입력받은 문자열중에 "+" 문자의 자릿수를 Return
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public int checkPlus(String inString)
        {

            return inString.IndexOf("+");
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public string  ReplacePlus(String inString)
        {
            
            if (checkPlus(inString) > 0)
            {
                
                inString = inString.Remove(checkPlus(inString), 1);
                inString = inString.Insert(3, " ");
            }

            return inString;
        }


        /// <summary>
        /// Data Table 을  PLH로 전환한다.
        /// </summary>
        /// <param name="DirPath"></param>
        /// <returns></returns>
        public int RecordToLine(string strSavepath)
        {

            try
            {
                if (m_dt.Rows.Count <= 0)
                {
                    MessageBox.Show("저장할 내용이 없습니다.");
                    return 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("저장할 내용이 없습니다.");

                return 0;
                throw ex ;
            }

            //요기부터 저장하면 됨
            Encoding encode = Encoding.GetEncoding("ks_c_5601-1987");

            //key로 Sort 한다.
            //m_dt.DefaultView.Sort = "key";

            string strFileName = "";
            string strOldFile = "";

            List<String> fscr = new List<String>();

            //의미없는 라인 2줄을 생성한다.

            foreach (DataRow dr in m_dt.Rows)
            {
                string strLine = "";
                
                strFileName = dr[CUtil.GetName(enumPLH.FileName)].ToString().Trim();


                strLine += dr[CUtil.GetName(enumPLH.NO)].ToString().PadRight(6);

                //byte[] buffer = Encoding.GetEncoding("ks_c_5601-1987").GetBytes(dr["+"].ToString());
                //string s = Encoding.GetEncoding("ks_c_5601-1987").GetString(buffer, 0, buffer.Length);
                //strLine += s;
                
                strLine += getWordByByte(dr[CUtil.GetName(enumPLH.plus)].ToString(), CUtil.GetLength(enumPLH.plus));

                strLine += dr[CUtil.GetName(enumPLH.dist)].ToString().PadLeft(CUtil.GetLength(enumPLH.dist));
                strLine += dr[CUtil.GetName(enumPLH.dist2)].ToString().PadLeft(CUtil.GetLength(enumPLH.dist2));
                strLine += dr[CUtil.GetName(enumPLH.gh)].ToString().PadLeft(CUtil.GetLength(enumPLH.gh));
                strLine += dr[CUtil.GetName(enumPLH.INV)].ToString().PadLeft(CUtil.GetLength(enumPLH.INV));
                strLine += " "; //라인명 앞에 의미없는 한자리 공백이 보임 
                strLine += dr[CUtil.GetName(enumPLH.LINENAME)].ToString().PadRight(CUtil.GetLength(enumPLH.LINENAME));
                strLine += dr[CUtil.GetName(enumPLH.DIA)].ToString().PadLeft(CUtil.GetLength(enumPLH.DIA));
                strLine += dr[CUtil.GetName(enumPLH.BR)].ToString().PadLeft(CUtil.GetLength(enumPLH.BR));
                strLine += dr[CUtil.GetName(enumPLH.type)].ToString().PadLeft(CUtil.GetLength(enumPLH.type));

                //strLine += " ";
                strLine += dr[CUtil.GetName(enumPLH.T1)].ToString().PadLeft(CUtil.GetLength(enumPLH.T1));
                strLine += " ";
                strLine += dr[CUtil.GetName(enumPLH.SLOPE)].ToString().PadLeft(CUtil.GetLength(enumPLH.SLOPE));
                strLine += dr[CUtil.GetName(enumPLH.Bcut)].ToString().PadLeft(CUtil.GetLength(enumPLH.Bcut));
                strLine += dr[CUtil.GetName(enumPLH.Hcut)].ToString().PadLeft(CUtil.GetLength(enumPLH.Hcut));
                strLine += dr[CUtil.GetName(enumPLH.manwork)].ToString().PadLeft(CUtil.GetLength(enumPLH.manwork));
                strLine += dr[CUtil.GetName(enumPLH.sand)].ToString().PadLeft(CUtil.GetLength(enumPLH.sand));
                strLine += dr[CUtil.GetName(enumPLH.concA)].ToString().PadLeft(CUtil.GetLength(enumPLH.concA));
                strLine += dr[CUtil.GetName(enumPLH.concB)].ToString().PadLeft(CUtil.GetLength(enumPLH.concB));
                strLine += dr[CUtil.GetName(enumPLH.humanity)].ToString().PadLeft(CUtil.GetLength(enumPLH.humanity));
                strLine += dr[CUtil.GetName(enumPLH.concrete)].ToString().PadLeft(CUtil.GetLength(enumPLH.concrete));
                strLine += dr[CUtil.GetName(enumPLH.asphalt1)].ToString().PadLeft(CUtil.GetLength(enumPLH.asphalt1));
                strLine += dr[CUtil.GetName(enumPLH.asphalt2)].ToString().PadLeft(CUtil.GetLength(enumPLH.asphalt2));
                strLine += dr[CUtil.GetName(enumPLH.complay)].ToString().PadLeft(CUtil.GetLength(enumPLH.complay));
                strLine += dr[CUtil.GetName(enumPLH.mixlay)].ToString().PadLeft(CUtil.GetLength(enumPLH.mixlay));
                strLine += dr[CUtil.GetName(enumPLH.mixlay1)].ToString().PadLeft(CUtil.GetLength(enumPLH.mixlay1));
                strLine += dr[CUtil.GetName(enumPLH.mixlay2)].ToString().PadLeft(CUtil.GetLength(enumPLH.mixlay2));
                strLine += dr[CUtil.GetName(enumPLH.area1)].ToString().PadLeft(CUtil.GetLength(enumPLH.area1));
                strLine += dr[CUtil.GetName(enumPLH.area2)].ToString().PadLeft(CUtil.GetLength(enumPLH.area2));
                strLine += dr[CUtil.GetName(enumPLH.area3)].ToString().PadLeft(CUtil.GetLength(enumPLH.area3));
                strLine += dr[CUtil.GetName(enumPLH.area4)].ToString().PadLeft(CUtil.GetLength(enumPLH.area4));
                strLine += dr[CUtil.GetName(enumPLH.area5)].ToString().PadLeft(CUtil.GetLength(enumPLH.area5));
                strLine += dr[CUtil.GetName(enumPLH.area6)].ToString().PadLeft(CUtil.GetLength(enumPLH.area6));
                strLine += dr[CUtil.GetName(enumPLH.area7)].ToString().PadLeft(CUtil.GetLength(enumPLH.area7));
                strLine += dr[CUtil.GetName(enumPLH.area8)].ToString().PadLeft(CUtil.GetLength(enumPLH.area8));
                strLine += dr[CUtil.GetName(enumPLH.area9)].ToString().PadLeft(CUtil.GetLength(enumPLH.area9));
                strLine += dr[CUtil.GetName(enumPLH.area10)].ToString().PadLeft(CUtil.GetLength(enumPLH.area10));
                strLine += dr[CUtil.GetName(enumPLH.area11)].ToString().PadLeft(CUtil.GetLength(enumPLH.area11));
                strLine += dr[CUtil.GetName(enumPLH.T2)].ToString().PadLeft(CUtil.GetLength(enumPLH.T2));
                strLine += dr[CUtil.GetName(enumPLH.T3)].ToString().PadLeft(CUtil.GetLength(enumPLH.T3));
                strLine += dr[CUtil.GetName(enumPLH.T4)].ToString().PadLeft(CUtil.GetLength(enumPLH.T4));
                strLine += dr[CUtil.GetName(enumPLH.B)].ToString().PadLeft(CUtil.GetLength(enumPLH.B));
                strLine += dr[CUtil.GetName(enumPLH.H)].ToString().PadLeft(CUtil.GetLength(enumPLH.H));
                strLine += "  ";
                strLine += dr[CUtil.GetName(enumPLH.DIR)].ToString().PadRight(CUtil.GetLength(enumPLH.DIR)); 
                

                //파일이 없는 빈 디렉토리에서 시작하기 때문에 파일이 있는지 보고 없으면 신규 생성하고 있으면 덧붙인다.

                FileInfo  fInfo = new FileInfo(strSavepath + "\\" + strFileName);

                FileStream fs;

                ///상단 SCALE 설정
                if (fInfo.Exists == false)
                {
                    using (fs = new FileStream(fInfo.FullName, FileMode.Append))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("ks_c_5601-1987")))
                        {
                            sw.WriteLine("                               ");
                            sw.WriteLine("100         0      0            ");
                        }
                    }

                }
                fs = new FileStream(fInfo.FullName, FileMode.Append);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("ks_c_5601-1987")))
                {
                    sw.WriteLine(strLine);
                }
                fs.Close();

                if (fscr.Contains(fInfo.FullName) == false)
                {
                    fscr.Add(fInfo.FullName);
                }                
            }

            //SUH.SCR을 만든다.
            FileInfo FInfo2 = new FileInfo(strSavepath + "\\" + "SUH.SCR");
            FileStream fs2 = new FileStream(FInfo2.FullName, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs2, Encoding.GetEncoding("ks_c_5601-1987")))
            {

                foreach (String item in fscr)
                {
                    sw.WriteLine("(load\"sangh31\")");
                    sw.WriteLine("SANGH");
                    sw.WriteLine(item);
                    sw.WriteLine("ZOOM ALL");
                    sw.WriteLine("SAVEAS 2000 " + Path.GetDirectoryName(item) + "\\" + Path.GetFileNameWithoutExtension(item) + ".dwg");
                    sw.WriteLine("erase all");
                    sw.WriteLine("  ");
                }
            }

            fs2.Close();

            //CUtil.SaveToXml(m_dt, strSavepath, "PLH_XML");            

            CUtil.AutoMsg("저장확인", "저장되었습니다.", 3);

            return 0;
        }

        private string getWordByByte(string src, int byteCount)
        {
            System.Text.Encoding myEncoding = System.Text.Encoding.GetEncoding("ks_c_5601-1987");

            byte[] buf = myEncoding.GetBytes(src);

            return myEncoding.GetString(buf, 0, byteCount);
        }


        /// <summary>
        /// 
        /// PLH를 Data Table로 변환한다.
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strLine"></param>
        public void LineToRecord(String strFileName, String strLine)
        {
            int nPos = 0;
            Encoding encode = Encoding.GetEncoding("ks_c_5601-1987");
            byte[] buf = encode.GetBytes(strLine);

            String sTmp;
            sTmp = encode.GetString(buf, 0, 3);

            if (sTmp != "NO.")
            {
                return;
            }

            DataRow Dr = m_dt.NewRow();

            m_key++;

            Dr[CUtil.GetName(enumPLH.key)] = m_key;
            Dr[CUtil.GetName(enumPLH.order_seq)] = m_key;
            Dr[CUtil.GetName(enumPLH.FileName)] = strFileName;
            Dr[CUtil.GetName(enumPLH.ASP_CON)] = false;
           

            Dr[CUtil.GetName(enumPLH.NO)] = ReplacePlus(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.NO)));


            if (checkPlus(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.NO))) >= 0)
            {
                nPos += CUtil.GetLength(enumPLH.NO);
                Dr[CUtil.GetName(enumPLH.plus)] = "+" + encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.plus));
            }
            else
            {
                nPos += CUtil.GetLength(enumPLH.NO);
                Dr[CUtil.GetName(enumPLH.plus)] = encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.plus));
            }
            nPos += CUtil.GetLength(enumPLH.plus);

            Dr[CUtil.GetName(enumPLH.dist)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.dist)));
            nPos += CUtil.GetLength(enumPLH.dist);

            Dr[CUtil.GetName(enumPLH.dist2)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.dist2)));
            nPos += CUtil.GetLength(enumPLH.dist2);

            Dr[CUtil.GetName(enumPLH.gh)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.gh)));
            nPos += CUtil.GetLength(enumPLH.gh);

            Dr[CUtil.GetName(enumPLH.INV)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.INV)));
            nPos += CUtil.GetLength(enumPLH.INV);

            nPos += 1; //Filler1 공백 

            Dr[CUtil.GetName(enumPLH.LINENAME)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.LINENAME)));
            nPos += CUtil.GetLength(enumPLH.LINENAME);

            Dr[CUtil.GetName(enumPLH.DIA)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.DIA)));
            nPos += CUtil.GetLength(enumPLH.DIA);

            Dr[CUtil.GetName(enumPLH.BR)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.BR)));
            nPos += CUtil.GetLength(enumPLH.BR);

            Dr[CUtil.GetName(enumPLH.type)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.type)));
            nPos += CUtil.GetLength(enumPLH.type);
                        
            Dr[CUtil.GetName(enumPLH.T1)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.T1)));
            nPos += CUtil.GetLength(enumPLH.T1);

            nPos += CUtil.GetLength(enumPLH.Filler3); //공백1자리

            Dr[CUtil.GetName(enumPLH.SLOPE)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.SLOPE)));
            nPos += CUtil.GetLength(enumPLH.SLOPE);            

            Dr[CUtil.GetName(enumPLH.Bcut)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.Bcut)));
            nPos += CUtil.GetLength(enumPLH.Bcut);

            Dr[CUtil.GetName(enumPLH.Hcut)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.Hcut)));
            nPos += CUtil.GetLength(enumPLH.Hcut);

            Dr[CUtil.GetName(enumPLH.manwork)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.manwork)));
            nPos += CUtil.GetLength(enumPLH.manwork);

            Dr[CUtil.GetName(enumPLH.sand)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.sand)));
            nPos += CUtil.GetLength(enumPLH.sand);

            Dr[CUtil.GetName(enumPLH.concA)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.concA)));
            nPos += CUtil.GetLength(enumPLH.concA);

            Dr[CUtil.GetName(enumPLH.concB)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.concB)));
            nPos += CUtil.GetLength(enumPLH.concB);

            Dr[CUtil.GetName(enumPLH.humanity)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.humanity)));
            nPos += CUtil.GetLength(enumPLH.humanity);



            Dr[CUtil.GetName(enumPLH.concrete)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.concrete)));
            nPos += CUtil.GetLength(enumPLH.concrete);

            Dr[CUtil.GetName(enumPLH.asphalt1)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.asphalt1)));
            nPos += CUtil.GetLength(enumPLH.asphalt1);

            Dr[CUtil.GetName(enumPLH.asphalt2)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.asphalt2)));
            nPos += CUtil.GetLength(enumPLH.asphalt2);

            Dr[CUtil.GetName(enumPLH.complay)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.complay)));
            nPos += CUtil.GetLength(enumPLH.complay);

            Dr[CUtil.GetName(enumPLH.mixlay)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.mixlay)));
            nPos += CUtil.GetLength(enumPLH.mixlay);

            Dr[CUtil.GetName(enumPLH.mixlay1)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.mixlay1)));
            nPos += CUtil.GetLength(enumPLH.mixlay1);

            Dr[CUtil.GetName(enumPLH.mixlay2)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.mixlay2)));
            nPos += CUtil.GetLength(enumPLH.mixlay2);

            Dr[CUtil.GetName(enumPLH.area1)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area1)));
            nPos += CUtil.GetLength(enumPLH.area1);

            Dr[CUtil.GetName(enumPLH.area2)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area2)));
            nPos += CUtil.GetLength(enumPLH.area2);

            Dr[CUtil.GetName(enumPLH.area3)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area3)));
            nPos += CUtil.GetLength(enumPLH.area3);

            Dr[CUtil.GetName(enumPLH.area4)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area4)));
            nPos += CUtil.GetLength(enumPLH.area4);

            Dr[CUtil.GetName(enumPLH.area5)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area5)));
            nPos += CUtil.GetLength(enumPLH.area5);

            Dr[CUtil.GetName(enumPLH.area6)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area6)));
            nPos += CUtil.GetLength(enumPLH.area6);

            Dr[CUtil.GetName(enumPLH.area7)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area7)));
            nPos += CUtil.GetLength(enumPLH.area7);

            Dr[CUtil.GetName(enumPLH.area8)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area8)));
            nPos += CUtil.GetLength(enumPLH.area8);

            Dr[CUtil.GetName(enumPLH.area9)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area9)));
            nPos += CUtil.GetLength(enumPLH.area9);

            Dr[CUtil.GetName(enumPLH.area10)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area10)));
            nPos += CUtil.GetLength(enumPLH.area10);

            Dr[CUtil.GetName(enumPLH.area11)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area11)));
            nPos += CUtil.GetLength(enumPLH.area11);

            Dr[CUtil.GetName(enumPLH.T2)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.T2)));
            nPos += CUtil.GetLength(enumPLH.T2);

            Dr[CUtil.GetName(enumPLH.T3)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.T3)));
            nPos += CUtil.GetLength(enumPLH.T3);

            Dr[CUtil.GetName(enumPLH.T4)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.T4)));
            nPos += CUtil.GetLength(enumPLH.T4);

            Dr[CUtil.GetName(enumPLH.B)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.B)));
            nPos += CUtil.GetLength(enumPLH.B);

            Dr[CUtil.GetName(enumPLH.H)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.H)));
            nPos += CUtil.GetLength(enumPLH.H);

            nPos += CUtil.GetLength(enumPLH.Filler4);

            Dr[CUtil.GetName(enumPLH.DIR)] = Convert(encode.GetString(buf, nPos, buf.Length - nPos));  //마지막열은 가변으로 처리 

            m_dt.Rows.Add(Dr);
            
        }


        /// <summary>
        /// 변경된 기초각으로 모래부설을 재계산한다.
        /// </summary>
        /// <param name="Dr"></param>
        /// <returns></returns>
        public double CalcBaseAngle(DataRow Dr)
        {
            double concA = ToDouble(Dr, CUtil.GetName(enumPLH.concA));
            double BaseAngle = ToDouble(Dr, CUtil.GetName(enumPLH.BaseAngle));
            double DIA = ToDouble(Dr, CUtil.GetName(enumPLH.DIA));               //관경
            double Hcut = ToDouble(Dr, CUtil.GetName(enumPLH.Hcut));             //관 기초두께
            double manwork = ToDouble(Dr, CUtil.GetName(enumPLH.manwork));       //관주위


            if (concA > 0)
            {
                return 0;
            }

            if (BaseAngle == 360)
            {
                return Math.Round(DIA + Hcut + manwork, 3);
            }
            else
            {
                return Math.Round((Hcut) + ((DIA / 2) - Math.Sqrt(Math.Pow((DIA / 2), 2) - Math.Pow((2 * DIA / 2 * Math.Sin((Math.PI * BaseAngle / 180) / 2)) / 2, 2))), 3);
            }

            return 0;
        }


        private double ToDouble(DataRow Dr, String sColNm)
        {

            return System.Convert.ToDouble(Dr[sColNm].ToString());



        }

        public DataTable LoadFromXML(string strFilePath)
        {
            string strFileName = strFilePath + "\\" + DEF_XML_FILE;

            DataSet ds = new DataSet();
            ds.ReadXml(strFileName);

            return ds.Tables[DEF_TABLE_NAME];
        }
        /*
          
        public string GetName(enumPLH value)
        {
            string output = null;

            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            CGetName[] attrs = fi.GetCustomAttributes(typeof(CGetName), false) as CGetName[];

            if (attrs.Length > 0)
            {
                output = attrs[0].value;
            }

            return output;
        }
        */




    }
}
