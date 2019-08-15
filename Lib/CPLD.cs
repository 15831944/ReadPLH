using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class CPLD
    {
        public DataTable m_dt = new DataTable();
        public int m_key = 0;

        public CPLD(DataTable Dt)
        {
            m_dt = Dt;
        }

        public CPLD()
        {
            m_dt.Columns.Add(new DataColumn("key", typeof(Int64)));
            m_dt.Columns.Add(new DataColumn("FileName", typeof(String)));
            m_dt.Columns.Add(new DataColumn("NO.", typeof(String)));            
            m_dt.Columns.Add(new DataColumn("Lspan", typeof(String)));
            m_dt.Columns.Add(new DataColumn("nugchain", typeof(String)));
            m_dt.Columns.Add(new DataColumn("GH", typeof(String)));
            m_dt.Columns.Add(new DataColumn("INV1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("INV2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("Hwater1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("Hwater2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("coverh1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("coverh2", typeof(String)));            
            m_dt.Columns.Add(new DataColumn("T1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("B1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("T2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("B2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("type", typeof(String)));
            m_dt.Columns.Add(new DataColumn("THI", typeof(String)));
            m_dt.Columns.Add(new DataColumn("CTXT", typeof(String)));
            m_dt.Columns.Add(new DataColumn("WLI", typeof(String)));
            m_dt.Columns.Add(new DataColumn("LTOTAL", typeof(String)));
        }

        public String Convert(String inString)
        {
            return inString.Trim();
        }

        public int checkPlus(String inString)
        {

            return inString.IndexOf("+");
            
        }

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
        public int RecordToLine()
        {
            string dirPath = "";

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
            

            using(FolderBrowserDialog FolderDlg = new FolderBrowserDialog())
            {
                int nFileCnt = 0; ;

                if (FolderDlg.ShowDialog() == DialogResult.OK)
                {
                    dirPath = FolderDlg.SelectedPath;

                    if (Directory.Exists(dirPath) == true)
                    {

                        
                        foreach (string filenm  in Directory.GetFiles(dirPath))
                        {
                            //순수 확장자가 파일명의 끝에 있는지 체크해서 카운트.
                            if (filenm.EndsWith("PLH"))
                            {
                                nFileCnt++;
                            }
                        }

                        //이미 있는 디렉토리잖아 
                        if (nFileCnt > 0)
                        {
                            if (MessageBox.Show(" PLH 파일이 있어, 다시 다 덮어 쓸거야?" + "[" + dirPath + "]", "PLH 확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                MessageBox.Show("취소 되었습니다.");
                                return 0;
                            }
                            else
                            {
                                //디렉토리를 날려버리고 새로 만든다.
                                if (MessageBox.Show("선택한 디렉토리와 하위 디렉토리 하위 파일들이 모두 지워진다. 그래도 OK?", "잘 생각해 봐", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    foreach (string filenm in Directory.GetFiles(dirPath))
                                    {
                                        //순수 확장자가 파일명의 끝에 있는지 체크해서 카운트.
                                        if (filenm.EndsWith("PLH"))
                                        {
                                            FileInfo fInfo = new FileInfo(filenm);
                                            fInfo.Delete();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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
                
                strFileName = dr["FileName"].ToString().Trim();


                strLine += dr["NO."].ToString().PadRight(6);

                //byte[] buffer = Encoding.GetEncoding("ks_c_5601-1987").GetBytes(dr["+"].ToString());
                //string s = Encoding.GetEncoding("ks_c_5601-1987").GetString(buffer, 0, buffer.Length);
                //strLine += s;
                string s = " ";
                strLine += s.PadRight(12);

                strLine += dr["dist"].ToString().PadLeft(7);
                strLine += dr["dist2"].ToString().PadLeft(10);
                strLine += dr["gh"].ToString().PadLeft(7);
                strLine += dr["INV"].ToString().PadLeft(7);
                strLine += dr["LINENAME"].ToString().PadRight(20);
                strLine += dr["DIA"].ToString().PadLeft(5);
                strLine += dr["BR"].ToString().PadLeft(5);
                strLine += dr["type"].ToString().PadLeft(3);

                strLine += " ";
                strLine += dr["T1"].ToString().PadLeft(5);
                strLine += dr["SLOPE"].ToString().PadLeft(10);
                strLine += dr["Bcut"].ToString().PadLeft(10);
                strLine += dr["Hcut"].ToString().PadLeft(10);
                strLine += dr["manwork"].ToString().PadLeft(10);
                strLine += dr["sand"].ToString().PadLeft(10);
                strLine += dr["concA"].ToString().PadLeft(10);
                strLine += dr["concB"].ToString().PadLeft(10);
                strLine += dr["humanity"].ToString().PadLeft(10);
                strLine += dr["concrete"].ToString().PadLeft(10);
                strLine += dr["asphalt1"].ToString().PadLeft(10);
                strLine += dr["asphalt2"].ToString().PadLeft(10);
                strLine += dr["complay"].ToString().PadLeft(10);
                strLine += dr["mixlay"].ToString().PadLeft(10);
                strLine += dr["mixlay1"].ToString().PadLeft(10);
                strLine += dr["mixlay2"].ToString().PadLeft(10);
                strLine += dr["area1"].ToString().PadLeft(10);
                strLine += dr["area2"].ToString().PadLeft(10);
                strLine += dr["area3"].ToString().PadLeft(10);
                strLine += dr["area4"].ToString().PadLeft(10);
                strLine += dr["area5"].ToString().PadLeft(10);
                strLine += dr["area6"].ToString().PadLeft(10);
                strLine += dr["area7"].ToString().PadLeft(10);
                strLine += dr["area8"].ToString().PadLeft(10);
                strLine += dr["area9"].ToString().PadLeft(10);
                strLine += dr["area10"].ToString().PadLeft(10);
                strLine += dr["area11"].ToString().PadLeft(10);
                strLine += dr["T2"].ToString().PadLeft(10);
                strLine += dr["T3"].ToString().PadLeft(10);
                strLine += dr["T4"].ToString().PadLeft(10);
                strLine += dr["B"].ToString().PadLeft(10);
                strLine += dr["H"].ToString().PadLeft(10);
                strLine += dr["DIR"].ToString().PadLeft(10);

                //파일이 없는 빈 디렉토리에서 시작하기 때문에 파일이 있는지 보고 없으면 신규 생성하고 있으면 덧붙인다.

                FileInfo  fInfo = new FileInfo(dirPath + "\\" + strFileName);

                FileStream fs;

                ///상단 SCALE 설정
                if (fInfo.Exists == false)
                {
                    using (fs = new FileStream(fInfo.FullName, FileMode.Append))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                        {
                            sw.WriteLine(" ");
                            sw.WriteLine("100         0      0            ");
                        }
                    }

                }
                fs = new FileStream(fInfo.FullName, FileMode.Append);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
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
            FileInfo FInfo2 = new FileInfo(dirPath + "\\" + "SUH.SCR");
            FileStream fs2 = new FileStream(FInfo2.FullName, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs2, Encoding.UTF8))
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


            string curPath = "";
            string parPath = "";
            string dataPath = "";

            curPath = Application.StartupPath;
            parPath = Directory.GetParent(curPath).FullName;
            parPath = Directory.GetParent(parPath).FullName;

            dataPath = parPath + "\\Data";

            File.Copy(dataPath + "\\SANGH31.LSP", dirPath + "\\SANGH31.LSP");
            File.Copy(dataPath + "\\바탕.DWG", dirPath + "\\바탕.DWG" );


            MessageBox.Show("저장되었습니다.");

            return 0;
        }



        /// <summary>
        /// 
        /// PLD를 Data Table로 변환한다.
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strLine"></param>
        public void LineToRecord(String strFileName, String strLine)
        {
            Encoding encode = Encoding.GetEncoding("ks_c_5601-1987");
            byte[] buf = encode.GetBytes(strLine);

            //String sTmp;
            //sTmp = encode.GetString(buf, 0, 3);

            DataRow Dr = m_dt.NewRow();

            m_key++;

            try
            {
                Dr["key"] = m_key;
                Dr["FileName"] = strFileName;

                Dr["NO."] = Convert(encode.GetString(buf, 0, 6));
                Dr["Lspan"] = Convert(encode.GetString(buf, 6, 9));
                Dr["nugchain"] = Convert(encode.GetString(buf, 15, 10));
                Dr["GH"] = Convert(encode.GetString(buf, 25, 7));
                Dr["INV1"] = Convert(encode.GetString(buf, 32, 9));
                Dr["INV2"] = Convert(encode.GetString(buf, 41, 9));
                Dr["Hwater1"] = Convert(encode.GetString(buf, 50, 9));
                Dr["Hwater2"] = Convert(encode.GetString(buf, 59, 9));
                Dr["coverh1"] = Convert(encode.GetString(buf, 68, 9));
                Dr["coverh2"] = Convert(encode.GetString(buf, 77, 9));
                Dr["T1"] = Convert(encode.GetString(buf, 86, 6));
                Dr["B1"] = Convert(encode.GetString(buf, 92, 6));
                Dr["T2"] = Convert(encode.GetString(buf, 98, 6));
                Dr["B2"] = Convert(encode.GetString(buf, 104, 6));

                Dr["type"] = Convert(encode.GetString(buf, 110, 2));
                Dr["THI"] = Convert(encode.GetString(buf, 112, 2));
                Dr["CTXT"] = Convert(encode.GetString(buf, 114, 2));
                Dr["WLI"] = Convert(encode.GetString(buf, 116, 6));
                Dr["LTOTAL"] = Convert(encode.GetString(buf, 118, 10));

                m_dt.Rows.Add(Dr);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                throw;
            }


            
        }


    }
}
