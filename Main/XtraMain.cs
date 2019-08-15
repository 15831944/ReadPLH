using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using WindowsFormsApp1.Screen;
using WindowsFormsApp1.Comm;
using WindowsFormsApp1.LogIn;
using WindowsFormsApp1.Info;
using WindowsFormsApp1.popup;

namespace WindowsFormsApp1.Main
{
    public partial class XtraMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        CUserInfo UserInfo = new CUserInfo();

        public XtraMain()
        {
            InitializeComponent();
        }

        private void XtraMain_Load(object sender, EventArgs e)
        {

#if (DEBUG && !ONLY_PIPE_TOOLS)
            frmLogIn LogIn = new frmLogIn();
            if (LogIn.ShowDialog() == DialogResult.OK)
            {
                if (QyrUserInfo(LogIn.edtUserId.Text) != 0)
                {
                    //어떻게 할래?
                }

            }
#endif
        }


        /// <summary>
        /// 사용자 정보를 조회한다.
        /// </summary>
        /// <param name="strUserId"></param>
        /// <returns></returns>
        public int QyrUserInfo(string strUserId)
        {

            CHeader Header = new CHeader("test", "A0001B", "MAIN", "00000", "");

            DataTable data = new DataTable("custinfo");

            DataColumn colUserId = new DataColumn("user_id", typeof(string));

            data.Columns.Add(colUserId);

            DataRow Dr = data.NewRow();
            Dr["user_id"] = strUserId;

            data.Rows.Add(Dr);

            CParam Param = new CParam(data);
            
            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());


            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            if (Dt.Rows[0]["err_cd"].ToString().PadRight(5, ' ') != "00000")
            {
                return -1;
            }

            itemUserId.Caption = ds.Tables["Table"].Rows[0]["user_id"].ToString();

            

            //사용자 정보를 설정한다.
            UserInfo.UserID = ds.Tables["Table"].Rows[0]["user_id"].ToString();
            UserInfo.UserName = ds.Tables["Table"].Rows[0]["user_nm"].ToString();

            return 0;
        }

        private void btrnPLH_ItemClick(object sender, ItemClickEventArgs e)
        {
   
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraNewProject frmProject = new XtraNewProject();
            frmProject.UserInfo = UserInfo;


            //적용 처리를 한거라면
            if (frmProject.ShowDialog() == DialogResult.OK)
            {
                XtraPLH frmPLH = new XtraPLH();

                frmPLH.UserInfo = UserInfo;
                frmPLH.ProjectInfo = frmProject.ProjectInfo;

                frmPLH.IsMdiContainer = false;
                frmPLH.MdiParent = this;
                frmPLH.Show();
            }
            else
            {

            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraQryProject frmProject = new XtraQryProject();
            frmProject.UserInfo = UserInfo;

            //적용 처리를 한거라면
            if (frmProject.ShowDialog() == DialogResult.OK)
            {
                CUtil.AutoMsg("프로젝트 불러오기", "성공", 2);

                XtraPLH frmPLH = new XtraPLH();

                frmPLH.UserInfo = UserInfo;
                frmPLH.ProjectInfo = frmProject.ProjectInfo;

                frmPLH.IsMdiContainer = false;
                frmPLH.MdiParent = this;                
                frmPLH.Show();
                frmPLH.QryPLH();


            }
            else
            {
                CUtil.AutoMsg("프로젝트 불러오기", "취소되었습니다.", 3);
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraQrySection frmProject = new XtraQrySection();
            frmProject.UserInfo = UserInfo;

            frmProject.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraSectionList frmProject = new XtraSectionList();
            frmProject.UserInfo = UserInfo;

            frmProject.ShowDialog();

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPLHBase frmPLH = new frmPLHBase();

            frmPLH.UserInfo = UserInfo;
            //frmPLH.ProjectInfo = this.ProjectInfo;


            frmPLH.MdiParent = this;
            frmPLH.Show();
           // frmPLH.QryPLH();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraUserInfo frmUser= new XtraUserInfo();
            frmUser.UserInfo = UserInfo;

            frmUser.ShowDialog();
        }


        /// <summary>
        /// PLH 파일을 관리한다
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraPLHFile frmUser = new XtraPLHFile();
            frmUser.UserInfo = UserInfo;

            frmUser.ShowDialog();
        }

        private void barButtonItem8_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraMngrGb frmUser = new XtraMngrGb();
            frmUser.UserInfo = UserInfo;

            frmUser.ShowDialog();

        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMngrTp frmUser = new XtraMngrTp();
            frmUser.UserInfo = UserInfo;

            frmUser.ShowDialog();

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMngrCd frmUser = new XtraMngrCd();
            frmUser.UserInfo = UserInfo;

            frmUser.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadPipeTools frmUser = new LoadPipeTools();

            frmUser.IsMdiContainer = false;
            frmUser.MdiParent = this;
            frmUser.Show();

        }

        private void baritem조달청정보_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNationalMarket frmUser = new frmNationalMarket();

            frmUser.IsMdiContainer = false;
            frmUser.MdiParent = this;
            frmUser.Show();
        }

        private void BarButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraItemDlg frmItem = new XtraItemDlg();
            frmItem.UserInfo = UserInfo;
            
            frmItem.ShowDialog();
        }
    }
}