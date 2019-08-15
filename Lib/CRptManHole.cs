using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Lib
{
    class CRptManHole
    {
        public enum enumRptManHole
        {
            [CGetName("key")]
            key,
            [CGetName("check")]
            check,
            [CGetName("LINENAME")]
            [CGetLength(19)]
            [CFormat("{0,-19}")]
            LINENAME,
            [CGetName("ManHoleNo")]
            [CGetLength(50)]
            [CFormat("{0,-50}")]  //왼쪽정렬
            ManHoleNo, //
            [CGetName("NO.")]
            [CGetLength(50)]
            [CFormat("{0,-50}")]  //왼쪽정렬
            NO, //측점
            [CGetName("dist2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]
            dist2,    //누가거리
            [CGetName("dist")]
            [CGetLength(6)]
            [CFormat("{0,6:#0.00}")]
            dist,    //거리
            [CGetName("MANHOLE")]
            [CGetLength(30)]
            [CFormat("{0,-30}")]  //왼쪽정렬
            MANHOLE, // MANHOLE
            [CGetName("규격")]
            [CGetLength(30)]
            [CFormat("{0,-30}")]  //왼쪽정렬
            규격, // 규격
            [CGetName("포장상태")]
            [CGetLength(30)]
            [CFormat("{0,-30}")]  //왼쪽정렬
            포장상태, // 규격
            [CGetName("OPEN구간맨홀높이")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            OPEN구간맨홀높이, // 규격
            [CGetName("가시설구간맨홀높이")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            가시설구간맨홀높이, // 가시설구간맨홀높이            
            [CGetName("맨홀적용높이")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            맨홀적용높이, // 맨홀적용높이
            [CGetName("맨홀뚜겅높이조절")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            맨홀뚜겅높이조절, // 맨홀뚜겅높이조절
            [CGetName("D150")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            D150, // 맨홀뚜겅높이조절
            [CGetName("D200")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            D200, // 맨홀뚜겅높이조절
            [CGetName("D300")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            D300, // 맨홀뚜겅높이조절
            [CGetName("비고")]
            [CGetLength(200)]
            [CFormat("{0,-200}")]
            비고// 비고

        }

        public DataTable m_dt;

        public const string DEF_TABLE_NAME = "맨홀정보";


        /// <summary>
        /// 전달받은 DataSet으로 맨홀조서 DATA를 구성한다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable SetData(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                long nKey;
                int index, pre_index;

                DataRow Dr = m_dt.NewRow();
                nKey = Convert.ToInt64(item[CUtil.GetName(CPLH.enumPLH.key)].ToString());
                index = (int)nKey - 1;
                pre_index = index - 1;
                Dr[CUtil.GetName(enumRptManHole.key)] = nKey;
                Dr[CUtil.GetName(enumRptManHole.LINENAME)] = item[CUtil.GetName(CPLH.enumPLH.LINENAME)];

                //측점 값 변경 NO. +  
                if (item[CUtil.GetName(CPLH.enumPLH.plus)].ToString().Trim() == "")
                {
                    Dr[CUtil.GetName(enumRptManHole.NO)] = item[CUtil.GetName(CPLH.enumPLH.NO)].ToString() + "   +0.00";
                }
                else
                {
                    Dr[CUtil.GetName(enumRptManHole.NO)] = item[CUtil.GetName(CPLH.enumPLH.NO)].ToString() + "   " + item[CUtil.GetName(CPLH.enumPLH.plus)].ToString();
                }                
                Dr[CUtil.GetName(enumRptManHole.dist2)] = item[CUtil.GetName(CPLH.enumPLH.dist2)];
                Dr[CUtil.GetName(enumRptManHole.dist)]  = item[CUtil.GetName(CPLH.enumPLH.dist)];
               

                m_dt.Rows.Add(Dr);
            }//end if for each

            return m_dt;
        }

        public CRptManHole()
        {
            m_dt = new DataTable();
            m_dt.TableName = DEF_TABLE_NAME;
            
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.key), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.check), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.LINENAME), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.ManHoleNo), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.NO), typeof(String)));            
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.dist2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.dist), typeof(String)));

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.MANHOLE), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.규격), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.포장상태), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.OPEN구간맨홀높이), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.가시설구간맨홀높이), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.맨홀적용높이), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.맨홀뚜겅높이조절), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.D150), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.D200), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.D300), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumRptManHole.비고), typeof(String)));



        }


        /// <summary>
        /// 경로명 없는 전달로 경로명 및 폴더를 지정하여 생성한다.
        /// </summary>
        public void Save()
        {
            String savePath;

            //저장할 내용이 없으면 오류
            if (m_dt == null || m_dt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("저장할 내용이 없습니다.", "저장 오류", MessageBoxButtons.OK);

                return;
            }

            XtraSaveFileDialog saveDlg = new XtraSaveFileDialog();
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {

                saveDlg.Filter = "xml 파일 (*.xml)|*.xml|모든파일(*.*)|*.*";
                savePath = saveDlg.FileName;

                CUtil.SaveToXml(m_dt, Path.GetDirectoryName(savePath), Path.GetFileNameWithoutExtension(savePath));

            }

        }

        /// <summary>
        /// 맨홀정보를 불러온다.
        /// </summary>
        public DataTable LoadXml()
        {
            String strFilePath;

            XtraOpenFileDialog OpenDlg = new XtraOpenFileDialog();
            OpenDlg.Filter = "xml 파일 (*.xml)|*.xml|모든파일(*.*)|*.*";

            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                strFilePath = OpenDlg.FileName;

                DataSet ds = new DataSet();
                ds.ReadXml(OpenDlg.FileName);

                m_dt = ds.Tables[DEF_TABLE_NAME];

                return m_dt;
            }

            return m_dt;
        }

    }
}
