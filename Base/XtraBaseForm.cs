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
using WindowsFormsApp1.Info;

namespace WindowsFormsApp1.Base
{
    public partial class XtraBaseForm : DevExpress.XtraEditors.XtraForm
    {
        private CUserInfo m_UserInfo;
        private CProjectInfo m_ProjectInfo;

        public XtraBaseForm()
        {
            InitializeComponent();

            m_UserInfo  = new CUserInfo();
            m_ProjectInfo = new CProjectInfo();

        }

        public CUserInfo UserInfo { get => m_UserInfo; set => m_UserInfo = value; }
        public CProjectInfo ProjectInfo { get => m_ProjectInfo; set => m_ProjectInfo = value; }

        public Boolean SetStatus(DataSet ds)
        {
            Boolean bRet = false;

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();


            if (Dt.Rows[0]["err_cd"].ToString() == "00000")
            {
                bRet = true;
            }


            return bRet;
        }
    }
}