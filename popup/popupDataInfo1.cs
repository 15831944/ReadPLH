using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.popup
{
    public partial class popupDataInfo1 : Form
    {
        public popupDataInfo1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 그리드의 내용을 Xml로 저장한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string strPath = CUtil.SaveDlgLoad();

            if (strPath == "")
            {
                MessageBox.Show("파일명을 지정하지 않았습니다.");

                return;
            }

            CUtil.SaveToXml((DataTable)gridControl1.DataSource, @"d:\", System.IO.Path.GetFileNameWithoutExtension(strPath));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CDataInfo1 DataInfo1 = new CDataInfo1();
            gridControl1.DataSource = DataInfo1.GetDefaultGridData();


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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = CUtil.LoadXmlToPLH();

        }

        private void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {

            
        }

        private void repositoryItemSpinEdit1_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {


        }
    }
}
