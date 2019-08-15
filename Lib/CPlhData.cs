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
    public class CPlhData
    {

        public enum enumPLH
        {
            [CGetName("key")]
            key,
            [CGetName("order_seq")]
            order_seq,            
            [CGetName("filename")]
            filename,
            [CGetName("linenumber")]
            [CGetLength(6)]       
            [CFormat("{0,-6}")]  //왼쪽정렬
            linenumber,
            [CGetName("asp+con")]
            asp_con,
            [CGetName("extention")]
            [CGetLength(12)]
            [CFormat("{0,-12}")]
            extention,
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
            [CGetName("inv")]            
            [CGetLength(7)]
            [CFormat("{0,7:##0.00}")]
            inv,
            [CGetName("filler1")]
            [CGetLength(1)]
            [CFormat("{0,-1}")]
            filler1,
            [CGetName("linename")]
            [CGetLength(19)]
            [CFormat("{0,-19}")]
            linename,
            [CGetName("dia")]            
            [CGetLength(5)]
            [CFormat("{0,5:#0.00}")]
            dia,
            [CGetName("br")]            
            [CGetLength(5)]
            [CFormat("{0,5:#0.00}")]
            br,
            [CGetName("type")]            
            [CGetLength(3)]
            [CFormat("{0,3:##0}")]
            type,
            [CGetName("t1")]            
            [CGetLength(6)]
            [CFormat("{0,6:#0.000}")]
            t1,
            [CGetName("filler3")]
            [CGetLength(1)]
            [CFormat("{0,-1}")]
            filler3,
            [CGetName("slope")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            slope,
            [CGetName("bcut")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            bcut,
            [CGetName("hcut")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            hcut,
            [CGetName("manwork")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            manwork,
            [CGetName("sand")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            sand,
            [CGetName("conca")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            conca,
            [CGetName("concb")]            
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            concb,
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
            [CGetName("t2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            t2,
            [CGetName("t3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            t3,
            [CGetName("t4")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            t4,
            [CGetName("b")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            b,
            [CGetName("h")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            h,
            [CGetName("filler4")]
            [CGetLength(2)]
            [CFormat("{0,-2}")]
            filler4,
            [CGetName("dir")]
            [CGetLength(30)] //마지막 필드는 고정값이 아니라서 좀 넉넉히 잡음
            [CFormat("{0,-30}")]
            dir,
            [CGetName("b2")]
            b2,
            [CGetName("inv2")]
            inv2,
            [CGetName("dia2")]
            dia2,
            [CGetName("baseangle")]
            [CGetLength(10)]
            [CFormat("{0,10:##0}")]
            baseangle,
            [CGetName("check")]
            check,
            [CGetName("section")]
            [CGetLength(20)]            
            section //구간정보
        }

        public DataTable m_dt = new DataTable();
        public int m_key = 0;

        public string dirPath_save = ""; //저장될 dir Path
        public const string DEF_TABLE_NAME = "PLH_TABLE";
        public const string DEF_XML_FILE = "PLH.xml";

        public CPlhData(DataTable Dt)
        {
            m_dt = Dt;
            m_dt.TableName = DEF_TABLE_NAME;
        }

        public CPlhData()
        {
            m_dt.TableName = DEF_TABLE_NAME;

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.key), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.order_seq), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.filename), typeof(String))); //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.linenumber), typeof(String)));       //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.asp_con), typeof(bool)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.extention), typeof(string)));     //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.dist), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.dist2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.gh), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.inv), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.linename), typeof(String)));  //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.dia), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.br), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.type), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.t1), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.slope), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.bcut), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.hcut), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.manwork), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.sand), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.conca), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.concb), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.humanity), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.concrete), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.asphalt1), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.asphalt2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.complay), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.mixlay), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.mixlay1), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.mixlay2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area1), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area3), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area4), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area5), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area6), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area7), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area8), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area9), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area10), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.area11), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.t2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.t3), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.t4), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.b), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.h), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.dir), typeof(String)));  //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.b2), typeof(String)));   //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.inv2), typeof(String))); //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.dia2), typeof(String))); //문자
            DataColumn dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumPLH.baseangle);
            dc.DataType = typeof(double);
            dc.DefaultValue = 0;

            m_dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumPLH.check);
            //dc.DataType = typeof(Boolean);
            dc.DefaultValue = "false";
            

            m_dt.Columns.Add(dc);

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLH.section), typeof(String)));
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
                
                strFileName = dr[CUtil.GetName(enumPLH.filename)].ToString().Trim();


                strLine += dr[CUtil.GetName(enumPLH.linenumber)].ToString().PadRight(6);

                //byte[] buffer = Encoding.GetEncoding("ks_c_5601-1987").GetBytes(dr["+"].ToString());
                //string s = Encoding.GetEncoding("ks_c_5601-1987").GetString(buffer, 0, buffer.Length);
                //strLine += s;
                
                strLine += getWordByByte(dr[CUtil.GetName(enumPLH.extention)].ToString(), CUtil.GetLength(enumPLH.extention));

                strLine += dr[CUtil.GetName(enumPLH.dist)].ToString().PadLeft(CUtil.GetLength(enumPLH.dist));
                strLine += dr[CUtil.GetName(enumPLH.dist2)].ToString().PadLeft(CUtil.GetLength(enumPLH.dist2));
                strLine += dr[CUtil.GetName(enumPLH.gh)].ToString().PadLeft(CUtil.GetLength(enumPLH.gh));
                strLine += dr[CUtil.GetName(enumPLH.inv)].ToString().PadLeft(CUtil.GetLength(enumPLH.inv));
                strLine += " "; //라인명 앞에 의미없는 한자리 공백이 보임 
                strLine += dr[CUtil.GetName(enumPLH.linename)].ToString().PadRight(CUtil.GetLength(enumPLH.linename));
                strLine += dr[CUtil.GetName(enumPLH.dia)].ToString().PadLeft(CUtil.GetLength(enumPLH.dia));
                strLine += dr[CUtil.GetName(enumPLH.br)].ToString().PadLeft(CUtil.GetLength(enumPLH.br));
                strLine += dr[CUtil.GetName(enumPLH.type)].ToString().PadLeft(CUtil.GetLength(enumPLH.type));

                //strLine += " ";
                strLine += dr[CUtil.GetName(enumPLH.t1)].ToString().PadLeft(CUtil.GetLength(enumPLH.t1));
                strLine += " ";
                strLine += dr[CUtil.GetName(enumPLH.slope)].ToString().PadLeft(CUtil.GetLength(enumPLH.slope));
                strLine += dr[CUtil.GetName(enumPLH.bcut)].ToString().PadLeft(CUtil.GetLength(enumPLH.bcut));
                strLine += dr[CUtil.GetName(enumPLH.hcut)].ToString().PadLeft(CUtil.GetLength(enumPLH.hcut));
                strLine += dr[CUtil.GetName(enumPLH.manwork)].ToString().PadLeft(CUtil.GetLength(enumPLH.manwork));
                strLine += dr[CUtil.GetName(enumPLH.sand)].ToString().PadLeft(CUtil.GetLength(enumPLH.sand));
                strLine += dr[CUtil.GetName(enumPLH.conca)].ToString().PadLeft(CUtil.GetLength(enumPLH.conca));
                strLine += dr[CUtil.GetName(enumPLH.concb)].ToString().PadLeft(CUtil.GetLength(enumPLH.concb));
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
                strLine += dr[CUtil.GetName(enumPLH.t2)].ToString().PadLeft(CUtil.GetLength(enumPLH.t2));
                strLine += dr[CUtil.GetName(enumPLH.t3)].ToString().PadLeft(CUtil.GetLength(enumPLH.t3));
                strLine += dr[CUtil.GetName(enumPLH.t4)].ToString().PadLeft(CUtil.GetLength(enumPLH.t4));
                strLine += dr[CUtil.GetName(enumPLH.b)].ToString().PadLeft(CUtil.GetLength(enumPLH.b));
                strLine += dr[CUtil.GetName(enumPLH.h)].ToString().PadLeft(CUtil.GetLength(enumPLH.h));
                strLine += "  ";
                strLine += dr[CUtil.GetName(enumPLH.dir)].ToString().PadRight(CUtil.GetLength(enumPLH.dir)); 
                

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
            Dr[CUtil.GetName(enumPLH.filename)] = strFileName;
            Dr[CUtil.GetName(enumPLH.asp_con)] = false;
           

            Dr[CUtil.GetName(enumPLH.linenumber)] = ReplacePlus(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.linenumber)));


            if (checkPlus(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.linenumber))) >= 0)
            {
                nPos += CUtil.GetLength(enumPLH.linenumber);
                Dr[CUtil.GetName(enumPLH.extention)] = "+" + encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.extention));
            }
            else
            {
                nPos += CUtil.GetLength(enumPLH.linenumber);
                Dr[CUtil.GetName(enumPLH.extention)] = encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.extention));
            }
            nPos += CUtil.GetLength(enumPLH.extention);            

            Dr[CUtil.GetName(enumPLH.dist)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.dist)));
            nPos += CUtil.GetLength(enumPLH.dist);

            Dr[CUtil.GetName(enumPLH.dist2)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.dist2)));
            nPos += CUtil.GetLength(enumPLH.dist2);

            Dr[CUtil.GetName(enumPLH.gh)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.gh)));
            nPos += CUtil.GetLength(enumPLH.gh);

            Dr[CUtil.GetName(enumPLH.inv)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.inv)));
            nPos += CUtil.GetLength(enumPLH.inv);

            nPos += 1; //Filler1 공백 

            Dr[CUtil.GetName(enumPLH.linename)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.linename)));
            nPos += CUtil.GetLength(enumPLH.linename);

            Dr[CUtil.GetName(enumPLH.dia)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.dia)));
            nPos += CUtil.GetLength(enumPLH.dia);

            Dr[CUtil.GetName(enumPLH.br)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.br)));
            nPos += CUtil.GetLength(enumPLH.br);

            Dr[CUtil.GetName(enumPLH.type)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.type)));
            nPos += CUtil.GetLength(enumPLH.type);
                        
            Dr[CUtil.GetName(enumPLH.t1)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.t1)));
            nPos += CUtil.GetLength(enumPLH.t1);

            nPos += CUtil.GetLength(enumPLH.filler3); //공백1자리

            Dr[CUtil.GetName(enumPLH.slope)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.slope)));
            nPos += CUtil.GetLength(enumPLH.slope);            

            Dr[CUtil.GetName(enumPLH.bcut)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.bcut)));
            nPos += CUtil.GetLength(enumPLH.bcut);

            Dr[CUtil.GetName(enumPLH.hcut)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.hcut)));
            nPos += CUtil.GetLength(enumPLH.hcut);

            Dr[CUtil.GetName(enumPLH.manwork)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.manwork)));
            nPos += CUtil.GetLength(enumPLH.manwork);

            Dr[CUtil.GetName(enumPLH.sand)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.sand)));
            nPos += CUtil.GetLength(enumPLH.sand);

            Dr[CUtil.GetName(enumPLH.conca)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.conca)));
            nPos += CUtil.GetLength(enumPLH.conca);

            Dr[CUtil.GetName(enumPLH.concb)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.concb)));
            nPos += CUtil.GetLength(enumPLH.concb);

            Dr[CUtil.GetName(enumPLH.humanity)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.humanity)));
            nPos += CUtil.GetLength(enumPLH.humanity);



            Dr[CUtil.GetName(enumPLH.concrete)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.concrete)));
            nPos += CUtil.GetLength(enumPLH.concrete);

            Dr[CUtil.GetName(enumPLH.asphalt1)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.asphalt1)));
            nPos += CUtil.GetLength(enumPLH.asphalt1);

            Dr[CUtil.GetName(enumPLH.asphalt2)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.asphalt2)));
            nPos += CUtil.GetLength(enumPLH.asphalt2);

            Dr[CUtil.GetName(enumPLH.complay)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.complay)));
            nPos += CUtil.GetLength(enumPLH.complay);

            Dr[CUtil.GetName(enumPLH.mixlay)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.mixlay)));
            nPos += CUtil.GetLength(enumPLH.mixlay);

            Dr[CUtil.GetName(enumPLH.mixlay1)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.mixlay1)));
            nPos += CUtil.GetLength(enumPLH.mixlay1);

            Dr[CUtil.GetName(enumPLH.mixlay2)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.mixlay2)));
            nPos += CUtil.GetLength(enumPLH.mixlay2);

            Dr[CUtil.GetName(enumPLH.area1)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area1)));
            nPos += CUtil.GetLength(enumPLH.area1);

            Dr[CUtil.GetName(enumPLH.area2)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area2)));
            nPos += CUtil.GetLength(enumPLH.area2);

            Dr[CUtil.GetName(enumPLH.area3)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area3)));
            nPos += CUtil.GetLength(enumPLH.area3);

            Dr[CUtil.GetName(enumPLH.area4)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area4)));
            nPos += CUtil.GetLength(enumPLH.area4);

            Dr[CUtil.GetName(enumPLH.area5)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area5)));
            nPos += CUtil.GetLength(enumPLH.area5);

            Dr[CUtil.GetName(enumPLH.area6)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area6)));
            nPos += CUtil.GetLength(enumPLH.area6);

            Dr[CUtil.GetName(enumPLH.area7)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area7)));
            nPos += CUtil.GetLength(enumPLH.area7);

            Dr[CUtil.GetName(enumPLH.area8)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area8)));
            nPos += CUtil.GetLength(enumPLH.area8);

            Dr[CUtil.GetName(enumPLH.area9)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area9)));
            nPos += CUtil.GetLength(enumPLH.area9);

            Dr[CUtil.GetName(enumPLH.area10)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area10)));
            nPos += CUtil.GetLength(enumPLH.area10);

            Dr[CUtil.GetName(enumPLH.area11)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.area11)));
            nPos += CUtil.GetLength(enumPLH.area11);

            Dr[CUtil.GetName(enumPLH.t2)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.t2)));
            nPos += CUtil.GetLength(enumPLH.t2);

            Dr[CUtil.GetName(enumPLH.t3)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.t3)));
            nPos += CUtil.GetLength(enumPLH.t3);

            Dr[CUtil.GetName(enumPLH.t4)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.t4)));
            nPos += CUtil.GetLength(enumPLH.t4);

            Dr[CUtil.GetName(enumPLH.b)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.b)));
            nPos += CUtil.GetLength(enumPLH.b);

            Dr[CUtil.GetName(enumPLH.h)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLH.h)));
            nPos += CUtil.GetLength(enumPLH.h);

            nPos += CUtil.GetLength(enumPLH.filler4);

            Dr[CUtil.GetName(enumPLH.dir)] = Convert(encode.GetString(buf, nPos, buf.Length - nPos));  //마지막열은 가변으로 처리 

            m_dt.Rows.Add(Dr);
            
        }


        /// <summary>
        /// 변경된 기초각으로 모래부설을 재계산한다.
        /// </summary>
        /// <param name="Dr"></param>
        /// <returns></returns>
        public double CalcBaseAngle(DataRow Dr)
        {
            double concA = ToDouble(Dr, CUtil.GetName(enumPLH.conca));
            double BaseAngle = ToDouble(Dr, CUtil.GetName(enumPLH.baseangle));
            double DIA = ToDouble(Dr, CUtil.GetName(enumPLH.dia));               //관경
            double Hcut = ToDouble(Dr, CUtil.GetName(enumPLH.hcut));             //관 기초두께
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
