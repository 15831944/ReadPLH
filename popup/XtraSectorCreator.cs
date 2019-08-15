using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApp1.Lib;

namespace WindowsFormsApp1.popup
{
    public partial class XtraSectorCreator : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        CSectorCreator m_Creator;
        CProjectData m_ProjectData;

        public XtraSectorCreator(CProjectData ProjectData)
        {
            InitializeComponent();

            m_Creator = new CSectorCreator();
            

            gridControl1.DataSource = m_Creator.m_dt;
            m_ProjectData = ProjectData;
        }


        public void InitData()
        {
            m_Creator = new CSectorCreator();
            gridControl1.DataSource = m_Creator.m_dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow dr = m_Creator.m_dt.NewRow();
            m_Creator.m_dt.Rows.Add(dr);
        }


        /// <summary>
        /// 그리드 상의 삭제 버튼을 누르면 발생하는 Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 저장 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            m_Creator.Save();
        }

        /// <summary>
        /// XML 데이터를 로드한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = m_Creator.LoadXml();
        }

        /// <summary>
        /// 
        /// 초기화한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}