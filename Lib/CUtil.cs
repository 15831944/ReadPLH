
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
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
    /// <summary>
    /// 독립적 기능을 가진 Static 함수를 기반으로 구성되어 있음 
    /// </summary>
    public static class CUtil
    {
        /// <summary>
        /// DataTable 을 XML로 저장한다.
        /// </summary>
        /// <param name="Dt"></param>
        public static void SaveToXml(DataTable Dt, string dirPath_save, string strFileName, string strTableName = "기본테이블") 
        {
            try
            {
                DataTable CloneDt = Dt.Copy();                
                CloneDt.TableName = Dt.TableName;

                String strXSDName;
                String strXMLName;

                strXSDName = System.IO.Path.ChangeExtension(dirPath_save + "\\" + strFileName, "xsd");
                strXMLName = System.IO.Path.ChangeExtension(dirPath_save + "\\" + strFileName, "xml");

                DataSet Ds = new DataSet();
                Ds.DataSetName = "XmlSave";

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
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString(), "오류발생", MessageBoxButtons.OK);


                throw;
            }
            
        }

        public static DataTable LoadXmlToPLH()
        {
            using (OpenFileDialog OpenDlg = new OpenFileDialog())
            {
                if (OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    CPLH plh = new CPLH();

                    DataSet ds = new DataSet();
                    ds.ReadXml(OpenDlg.FileName);

                    return ds.Tables[0];
                }
            }


            return null;
                
        }

        public static String SaveDlgLoad()
        {
            try
            {
                SaveFileDialog SaveDlg = new SaveFileDialog();

                if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    //throw new ArgumentNullException("Exception");

                    return SaveDlg.FileName;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return "";
        }


        public static void AutoCloseMsg(string strCaption, string strMsg)
        {
            
        }


        /// <summary>
        /// 확장자 존재 유무에 따라 디렉토리 처리여부를 판단한다.
        /// 선택 디렉토리에  전달된 확장자가 존재한다면 모두 삭제되는걸 경고해줌 
        /// </summary>
        /// <param name="strExt"></param>
        public static string CheckExistExt(string strExt)
        {
            string dirPath = "";
            Boolean bExtention = false; //확장자 존재여부 

            
            using (XtraFolderBrowserDialog FolderDlg = new XtraFolderBrowserDialog())
            {
                int nFileCnt = 0; ;

                if (FolderDlg.ShowDialog() == DialogResult.OK)
                {
                    dirPath = FolderDlg.SelectedPath;

                    //디렉토리 존재유무를 확인한다.
                    if (Directory.Exists(dirPath) == true)
                    {
                        DirectoryInfo di = new DirectoryInfo(dirPath);
                        
                        foreach (var item in di.GetFiles())
                        {
                            bExtention = true;
                            break;
#if false
                            //확장자가 PLH 이면 
                            if (item.Extension == strExt)
                            {
                                bExtention = true;
                                break;
                            }

#endif
                        }

                        //만약 디렉토리내에 해당 확장자를 가진 파일이 존재한다면 물어보자
                        if (bExtention == true)
                        {
                            if (MessageBox.Show(" 기존 파일이 존재합니다. 계속 진행하면 기존 파일 삭제 후 진행합니다. " + "[" + dirPath + "]", " 확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                //cancel 하면 
                                MessageBox.Show("취소 되었습니다.");
                                return null;
                            }
                            else
                            {
                                //디렉토리를 날려버리고 새로 만든다.
                                if (MessageBox.Show("선택한 디렉토리 하위 파일들이 모두 지워집니다.", " 삭제", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    foreach (string filenm in Directory.GetFiles(dirPath))
                                    {

                                        FileInfo fInfo = new FileInfo(filenm);
                                        fInfo.Delete();
#if false
                                        //순수 확장자가 파일명의 끝에 있는지 체크해서 카운트.
                                        if (filenm.EndsWith("PLH"))
                                        {
                                            FileInfo fInfo = new FileInfo(filenm);
                                            fInfo.Delete();
                                        }
#endif
                                    }
                                }
                                else
                                {

                                    XtraMessageBox.Show("취소 되었습니다.");                                    

                                    return null;
                                }

                            }
                        }
                    }
                }
                    
            }

            return dirPath;
        } // end of CheckExistExt


        /// <summary>
        /// DataRow의 값이 복사된 Clone을 생성한다.
        /// </summary>
        /// <param name="Dt"></param>
        /// <param name="DrOrig"></param>
        /// <returns></returns>
        public static DataRow CopyDataRow(DataTable Dt, DataRow DrOrig)
        {
            DataRow Dr = Dt.NewRow();


            foreach (DataColumn item in DrOrig.Table.Columns)
            {
                Dr[item.ColumnName] = DrOrig[item.ColumnName];
            }



            return Dr;
        }

        public static string GetName<TEnum>(TEnum value)
        {
            string output = null;

            Type type = typeof(TEnum);

            FieldInfo fi = type.GetField(value.ToString());
            CGetName[] attrs = fi.GetCustomAttributes(typeof(CGetName), false) as CGetName[];

            if (attrs.Length > 0)
            {
                output = attrs[0].value;
            }

            return output;
        }

        public static string GetCaption<TEnum>(TEnum value)
        {
            string output = null;

            Type type = typeof(TEnum);

            FieldInfo fi = type.GetField(value.ToString());
            CGetCaption[] attrs = fi.GetCustomAttributes(typeof(CGetCaption), false) as CGetCaption[];

            if (attrs.Length > 0)
            {
                output = attrs[0].value;
            }

            return output;
        }


        public static int GetLength<TEnum>(TEnum value)
        {
            int output = 0;
            Type type = typeof(TEnum);

            try
            {
                FieldInfo fi = type.GetField(value.ToString());
                CGetLength[] attrs = fi.GetCustomAttributes(typeof(CGetLength), false) as CGetLength[];

                if (attrs.Length > 0)
                {
                    output = attrs[0].value;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("GetLength is " + e.Message.ToString());

                throw;
            }
            return output;
        }

        public static string GetFormat<TEnum>(TEnum value)
        {
            string output = null;

            Type type = typeof(TEnum);

            FieldInfo fi = type.GetField(value.ToString());
            CFormat[] attrs = fi.GetCustomAttributes(typeof(CFormat), false) as CFormat[];

            if (attrs.Length > 0)
            {
                output = attrs[0].value;
            }

            return output;
        }

        /// <summary>
        /// TABPage 에서 이름으로 Visible 속성을 제어한다.
        /// </summary>
        /// <param name="Tab"></param>
        /// <param name="tabText"></param>
        public static void SetVisibleByText(XtraTabControl Tab,  string tabText, bool visible)
        {
            foreach (XtraTabPage item in Tab.TabPages)
            {
                if (item.Text == tabText)
                {
                    item.PageVisible = visible;
                    Tab.SelectedTabPage = item;
                }
                else
                {
                    item.PageVisible = false;
                }
            }


        }

        public static void AutoMsg(string caption, string msg, int sec)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = sec * 1000;
            args.Caption = caption;
            args.Text = msg;
            //args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            XtraMessageBox.Show(args).ToString();
        }

        public static string GetFocusedFieldValue(GridView gridview, String fieldName)
        {
            return gridview.GetFocusedDataRow()[fieldName].ToString();
        }

    }



}
