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
    /// <summary>
    /// 프로젝트 경로를 관리 하는 클래스이다
    /// 기본 디렉토리 정보 및 기본 XML 파일 정보를 가지고 있다
    /// </summary>
    public class CProjectData
    {

        public DataTable m_dt;
        public String m_strFullPath;
        public string m_strAppPath;
        public string m_strDataPath;


        public DirectoryInfo m_di;
        public DirectoryInfo m_di_plh;
        public DirectoryInfo m_di_pld;
        public DirectoryInfo m_di_lisp;
        public DirectoryInfo m_di_sector;
        public DirectoryInfo m_di_data;
        


        public const string DEF_PROJECT_XML = "Project.xml";
        public const string DEF_PROJECT_XSD = "Project.xsd";
        public const string DEF_PROJECT = "Project";
        public const string DEF_TABLE_NAME = "Project";

        


        /// <summary>
        /// 기본 생성자 프로젝트 관리 클래스
        /// </summary>
        public CProjectData()
        {
            m_dt = new DataTable();
            m_dt.TableName = DEF_PROJECT;
            

            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumProject.ProjectName), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumProject.ProjectPath), typeof(String)));

            m_strAppPath= Application.StartupPath;
            m_strDataPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(m_strAppPath).FullName).FullName).FullName + "\\Data";


        }


        // XML 파일을 읽어서 Datatable을 생성한다.
        public CProjectData(String strFileName)
        {
           if  (CLoadProjectXml(strFileName) == null)
            {
                XtraMessageBox.Show("테이블을 찾을수 없습니다.");
            }

        }


        public bool ProjectSetCheck()
        {

            if (m_dt == null)
            {
                return false;
            }

            if (m_dt.Rows.Count <= 0)
            {
                return false;
            }

            if (GetProjectName().Trim().ToString() == "" || GetProjectPath().Trim().ToString() == "")
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 선택된 디렉토리를 기본 디렉토리로 지정한다.
        /// 그외 기본 디렉토리를 자동 생성한다.
        /// 빈 디렉토리가 아니면 모두 삭제 후 LISP , PLH, PLD  디렉토리를 자동 생성한다.
        /// </summary>
        public void SetProjectDir()
        {
            string dirPath = "";

            XtraFolderBrowserDialog folderDlg1 = new XtraFolderBrowserDialog();

            folderDlg1.DialogStyle = DevExpress.Utils.CommonDialogs.FolderBrowserDialogStyle.Wide;
            if (folderDlg1.ShowDialog() == DialogResult.OK)
            {
                m_strFullPath = folderDlg1.SelectedPath;
                SaveProjectDir(m_strFullPath);
                
            }
        }

        public void SaveProjectDir(String strPath)
        {
            //디렉토리 존재유무를 확인한다.
            if (Directory.Exists(strPath) == true)
            {
                DirectoryInfo di = new DirectoryInfo(strPath);

                DirectoryInfo[] dis = di.GetDirectories();
                FileInfo[] fis = di.GetFiles("*.*");
                if (dis.Length > 0 || fis.Length > 0)
                {
                    if (MessageBox.Show("빈 디렉토리가 아닙니다. OK 를 선택하면 하위 파일 정보는 모두 삭제됩니다.", "주의", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        foreach (DirectoryInfo item in dis)
                        {
                            item.Delete(true);
                        }

                        foreach (FileInfo item in fis)
                        {
                            item.Delete();
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                //SUB Directory를 만든다.  
                m_di = di;
                m_di_plh = di.CreateSubdirectory("PLH");
                m_di_pld = di.CreateSubdirectory("PLD");
                m_di_lisp = di.CreateSubdirectory("LISP");
                m_di_sector = di.CreateSubdirectory("구간정보");
                m_di_data = di.CreateSubdirectory("DATA");

                CopyBaseData();
            }
        }



        //기본 데이터를 프로젝트에 복사한다.
        public void CopyBaseData()
        {
            File.Copy(m_strDataPath + "\\SANGH31.LSP", m_di_data.FullName + "\\SANGH31.LSP");
            File.Copy(m_strDataPath + "\\바탕.DWG", m_di_data.FullName+ "\\바탕.DWG");            

        }


        public void SaveToXml(DataTable Dt, string dirPath_save)
        {

            DataTable CloneDt = Dt.Copy();



            String strXSDName;
            String strXMLName;

            strXSDName = System.IO.Path.ChangeExtension(dirPath_save + "\\" + DEF_PROJECT, "xsd");
            strXMLName = System.IO.Path.ChangeExtension(dirPath_save + "\\" + DEF_PROJECT, "xml");

            DataSet Ds = new DataSet();
            Ds.DataSetName = "XmlSave";
            Dt.TableName = DEF_TABLE_NAME;
            CloneDt.TableName = DEF_TABLE_NAME;



            Ds.Tables.Add(CloneDt);

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(strXSDName))
            {
                Ds.WriteXmlSchema(writer);
                writer.Close();
            }

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(strXMLName))
            {
                Ds.WriteXml(writer);
                writer.Close();
            }

        }


        /// <summary>
        /// XML 경로를 입력 받아 DATA Table을 생성한다.
        /// </summary>
        /// <param name="strFullPath"></param>
        public DataTable CLoadProjectXml(string strFullPath)
        {
            m_strFullPath = strFullPath;
            String strPrjFile = strFullPath;// + @"\Project.xml";

            DataSet ds = new DataSet();
            ds.ReadXml(strPrjFile);

            m_dt = ds.Tables[DEF_PROJECT];


            FileInfo  fInfo = new FileInfo(strFullPath);
            DirectoryInfo di = new DirectoryInfo(fInfo.DirectoryName);

            m_di = di;
            m_di_plh = new DirectoryInfo(di.FullName + "\\PLH");
            m_di_pld = new DirectoryInfo(di.FullName + "\\PLD"); 
            m_di_lisp = new DirectoryInfo(di.FullName + "\\LISP"); 
            m_di_sector = new DirectoryInfo(di.FullName + "\\구간정보"); 
            m_di_data = new DirectoryInfo(di.FullName + "\\DATA"); 

            return m_dt;
        }


        public string GetValueByFieldName(String strFieldName)
        {
            return m_dt.Rows[0][strFieldName].ToString();
        }

        public string GetProjectName()
        {
            return GetValueByFieldName(CUtil.GetName(enumProject.ProjectName));
        }

        public string GetProjectPath()
        {
            return GetValueByFieldName(CUtil.GetName(enumProject.ProjectPath));
        }
        
    }
}
