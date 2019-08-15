using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Lib.CComEnum;

namespace WindowsFormsApp1.Lib
{
    class CSectorCreator
    {
        public DataTable m_dt;

        public const string DEF_TABLE_NMAE = "구간정보";

        /// <summary>
        /// 기본 생성자 프로젝트 관리 클래스
        /// </summary>
        public CSectorCreator()
        {
            m_dt = new DataTable();
            m_dt.TableName = DEF_TABLE_NMAE;

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPrjoectCreate.SECTOR  ), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPrjoectCreate.asphalt1), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPrjoectCreate.asphalt2), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPrjoectCreate.complay ), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPrjoectCreate.mixlay  ), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumPrjoectCreate.delete  ), typeof(String)));
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
        /// 지정된 경로에 파일을 저장한다.
        /// </summary>
        /// <param name="strPath"></param>
        public void Save(String strPath)
        {

        }

        /// <summary>
        /// 구간정보를 불러온다.
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
                
                m_dt = ds.Tables[DEF_TABLE_NMAE];

                return m_dt;
            }

            return m_dt;
        }
        

    }
}
