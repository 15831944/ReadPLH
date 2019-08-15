using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Lib;

namespace WindowsFormsApp1.popup
{
    /// <summary>
    /// 구간 정보 기본 값의 데이터 관리 클래스
    /// </summary>
    public class CDataInfo1
    {
        DataTable m_dt;





        public enum enumInfo1
        {
            [CGetCaption("번호")]
            [CGetName("seq")]
            [CGetLength(6)]
            [CFormat("{0,-6}")]  //왼쪽정렬
            seq,
            [CGetCaption("구간정보")]
            [CGetName("Section")]
            [CGetLength(20)]
            Section, //구간정보
            [CGetCaption("표층")]
            [CGetName("asphalt1")]
            [CGetLength(10)]
            [CFormat("{0,10:#,##0.000}")]
            asphalt1,
            [CGetCaption("기층")]
            [CGetName("asphalt2")]
            [CGetLength(10)]
            [CFormat("{0,10:#,##0.000}")]
            asphalt2,
            [CGetCaption("보조기층")]
            [CGetName("complay")]
            [CGetLength(10)]
            [CFormat("{0,10:#,##0.000}")]
            complay,
            [CGetCaption("혼합기층")]
            [CGetName("mixlay")]
            [CGetLength(10)]
            [CFormat("{0,10:#,##0.000}")]
            mixlay
        }


        public CDataInfo1()
        {
            m_dt = new DataTable();

            CreateColumns();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void CreateColumns()
        {
            //m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumInfo1.seq), typeof(Int64)));
            //m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumInfo1.name), typeof(string)));
            //m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumInfo1.value), typeof(string)));

            DataColumn dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumInfo1.seq);
            dc.DataType = typeof(Int64);
            dc.Caption = CUtil.GetCaption(enumInfo1.seq);

            m_dt.Columns.Add(dc);


            //구간정보
            dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumInfo1.Section);
            dc.DataType = typeof(string);
            dc.Caption = CUtil.GetCaption(enumInfo1.Section);

            m_dt.Columns.Add(dc);

            //표층
            dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumInfo1.asphalt1);
            dc.DataType = typeof(string);
            dc.Caption = CUtil.GetCaption(enumInfo1.asphalt1);

            m_dt.Columns.Add(dc);

            //기층
            dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumInfo1.asphalt2);
            dc.DataType = typeof(string);
            dc.Caption = CUtil.GetCaption(enumInfo1.asphalt2);

            m_dt.Columns.Add(dc);

            //보조기층
            dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumInfo1.complay);
            dc.DataType = typeof(string);
            dc.Caption = CUtil.GetCaption(enumInfo1.complay);

            m_dt.Columns.Add(dc);

            //혼합기층
            dc = new DataColumn();
            dc.ColumnName = CUtil.GetName(enumInfo1.mixlay);
            dc.DataType = typeof(string);
            dc.Caption = CUtil.GetCaption(enumInfo1.mixlay);

            m_dt.Columns.Add(dc);
//            TestData();

        }

        public DataTable GetDefaultGridData()
        {
            DataRow Dr = m_dt.NewRow();
            Dr[CUtil.GetName(enumInfo1.seq)] = 1;
            Dr[CUtil.GetName(enumInfo1.Section)] = "국도";
            Dr[CUtil.GetName(enumInfo1.asphalt1)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.asphalt2)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.complay)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.mixlay)] = "1.112";

            m_dt.Rows.Add(Dr);

            Dr = m_dt.NewRow();
            Dr[CUtil.GetName(enumInfo1.seq)] = 2;
            Dr[CUtil.GetName(enumInfo1.Section)] = "ASP";
            Dr[CUtil.GetName(enumInfo1.asphalt1)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.asphalt2)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.complay)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.mixlay)] = "1.112";

            m_dt.Rows.Add(Dr);

            Dr = m_dt.NewRow();
            Dr[CUtil.GetName(enumInfo1.seq)] = 3;
            Dr[CUtil.GetName(enumInfo1.Section)] = "ASP + CON";
            Dr[CUtil.GetName(enumInfo1.asphalt1)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.asphalt2)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.complay)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.mixlay)] = "1.112";

            m_dt.Rows.Add(Dr);

            Dr = m_dt.NewRow();
            Dr[CUtil.GetName(enumInfo1.seq)] = 4;
            Dr[CUtil.GetName(enumInfo1.Section)] = "보도블럭";
            Dr[CUtil.GetName(enumInfo1.asphalt1)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.asphalt2)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.complay)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.mixlay)] = "1.112";

            m_dt.Rows.Add(Dr);


            Dr = m_dt.NewRow();
            Dr[CUtil.GetName(enumInfo1.seq)] = 5;
            Dr[CUtil.GetName(enumInfo1.Section)] = "투수콘";
            Dr[CUtil.GetName(enumInfo1.asphalt1)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.asphalt2)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.complay)] = "1.112";
            Dr[CUtil.GetName(enumInfo1.mixlay)] = "1.112";

            m_dt.Rows.Add(Dr);


            return m_dt;
        }


        public void TestData()
        {
            //DataRow Dr = m_dt.NewRow();
            //Dr[CUtil.GetName(enumInfo1.seq)] = 1;
            //Dr[CUtil.GetName(enumInfo1.name)] = "국도";
            //Dr[CUtil.GetName(enumInfo1.value)] = "1.112";

            //m_dt.Rows.Add(Dr);

            //Dr = m_dt.NewRow();
            //Dr[CUtil.GetName(enumInfo1.seq)] = 2;
            //Dr[CUtil.GetName(enumInfo1.name)] = "ASP.CON";
            //Dr[CUtil.GetName(enumInfo1.value)] = "1.000";

            //m_dt.Rows.Add(Dr);


        }

        public DataTable GetDataTable()
        {
            return m_dt;
        }

    }
}
