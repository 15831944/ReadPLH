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
    public class CPldData
    {

        public enum enumPLD
        {
            [CGetName("key")]
            key,
            [CGetName("order_seq")]
            order_seq,            
            [CGetName("filename")]
            filename,
            [CGetName("measure_point")]
            [CGetLength(10)]       
            [CFormat("{0,10:#0.00}")]  //측점
            measure_point,
            [CGetName("inv")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]  //inv
            inv,
            [CGetName("size")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]  //size
            size,
            [CGetName("text")]
            text,
            [CGetName("boxt1")]
            boxt1,
            [CGetName("boxt2")]
            boxt2,
            [CGetName("boxt3")]
            boxt3
        }

        public DataTable m_dt = new DataTable();
        public int m_key = 0;

        public string dirPath_save = ""; //저장될 dir Path
        public const string DEF_TABLE_NAME = "PLD_TABLE";
        public const string DEF_XML_FILE = "PLD.xml";

        public CPldData(DataTable Dt)
        {
            m_dt = Dt;
            m_dt.TableName = DEF_TABLE_NAME;
        }

        public CPldData()
        {
            m_dt.TableName = DEF_TABLE_NAME;

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.key), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.order_seq), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.filename), typeof(String))); //문자
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.measure_point), typeof(String)));       //문자            
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.inv), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.size), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.text), typeof(string)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.boxt1), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.boxt2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPLD.boxt3), typeof(double)));            
        }

        public String Convert(String inString)
        {
            return inString.Trim();
        }



        /// <summary>
        /// 
        /// PLD를 Data Table로 변환한다.
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strLine"></param>
        public void LineToRecord(String strFileName, String strLine)
        {

            if (strLine.Contains("CROSS mid") == false)
            {
                return;
            }


            int nPos = 0;
            Encoding encode = Encoding.GetEncoding("ks_c_5601-1987");
            byte[] buf = encode.GetBytes(strLine);

            String sTmp;

            DataRow Dr = m_dt.NewRow();

            m_key++;

            Dr[CUtil.GetName(enumPLD.key)] = m_key;
            Dr[CUtil.GetName(enumPLD.order_seq)] = m_key;
            Dr[CUtil.GetName(enumPLD.filename)] = strFileName;
           

            Dr[CUtil.GetName(enumPLD.measure_point)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLD.measure_point)));
            nPos += CUtil.GetLength(enumPLD.measure_point);

            Dr[CUtil.GetName(enumPLD.inv)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLD.inv)));
            nPos += CUtil.GetLength(enumPLD.inv);

            Dr[CUtil.GetName(enumPLD.size)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLD.size)));
            nPos += CUtil.GetLength(enumPLD.size);

            //Dr[CUtil.GetName(enumPLD.text)] = Convert(encode.GetString(buf, nPos, CUtil.GetLength(enumPLD.text)));
            //nPos += CUtil.GetLength(enumPLD.text);            

            //Dr[CUtil.GetName(enumPLD.boxt1)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLD.boxt1)));
            //nPos += CUtil.GetLength(enumPLD.boxt1);

            //Dr[CUtil.GetName(enumPLD.boxt2)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLD.boxt2)));
            //nPos += CUtil.GetLength(enumPLD.boxt2);

            //Dr[CUtil.GetName(enumPLD.boxt3)] = System.Convert.ToDouble(encode.GetString(buf, nPos, CUtil.GetLength(enumPLD.boxt3)));
            //nPos += CUtil.GetLength(enumPLD.boxt3);

            m_dt.Rows.Add(Dr);
            
        }




    }
}
