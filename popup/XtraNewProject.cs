using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Comm;
using WindowsFormsApp1.Info;

namespace WindowsFormsApp1.popup
{
    public partial class XtraNewProject : WindowsFormsApp1.Base.XtraBaseForm
    {

        CProjectInfo ProjectInfo = new CProjectInfo();

        string m_Seq = "";

        public XtraNewProject()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (InsertProjectInfo() == 0)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private int chkData()
        {
            Cnpgsql Qry = new Cnpgsql();

            NpgsqlCommand cmd_select = new NpgsqlCommand();

            string sql = $" select count(*) cnt" +
                         $"  from prj01m00" +
                         $" where trim(project_nm) =  trim(:p_project_nm)";


            cmd_select.CommandText = sql;
            cmd_select.Parameters.AddWithValue("p_project_nm", edtProjectNm.Text);


            Qry.SetSelect(cmd_select);


            try
            {
                DataTable dt = Qry.Select();
                if (Convert.ToInt32(dt.Rows[0]["cnt"].ToString()) != 0)
                {
                    itemErrMsg.Caption = "동일한 프로젝트명이 존재합니다.";
                    return -1;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

                itemErrMsg.Caption = ex.Message;
                throw;
            }

            return 0;
        }



        private  int makeSEQ()
        {

            Cnpgsql qry = new Cnpgsql();

            NpgsqlCommand qryCommand = new NpgsqlCommand();

            string sql = $" select to_char(count(*) +1, 'FM0000000000')  cnt" +
                         $"  from prj01m00";

            qryCommand.CommandText = sql;

            qry.SetSelect(qryCommand);

            try
            {
                DataTable dt = qry.Select();
                m_Seq = dt.Rows[0]["cnt"].ToString();

            }
            catch (Exception ex)
            {
                itemErrMsg.Caption = ex.Message;
                return -1;
            }

            return 0;
        }
            

        private int InsertData()
        {

            Cnpgsql qry = new Cnpgsql();
            NpgsqlCommand qryCommander = new NpgsqlCommand();

            string sql;
            sql =   $" insert into prj01m00     " +
                    $" select :p_seq         , " +
                    $"        :p_project_nm  , " +
                    $"        :p_start_dt    , " +
                    $"        :p_end_dt      , " +
                    $"        :p_client_cd   , " +
                    $"        :p_client_id     ";

            qryCommander.CommandText = sql;
            qryCommander.Parameters.AddWithValue("project_nm", edtProjectNm.Text);
            qryCommander.Parameters.AddWithValue("start_dt"  , dateStart.Text.Replace("-", ""));
            qryCommander.Parameters.AddWithValue("end_dt"    , dateEnd.Text.Replace("-", "")  );
            qryCommander.Parameters.AddWithValue("client_cd" , lookupClient.GetColumnValue("client_cd"));
            qryCommander.Parameters.AddWithValue("client_id" , lookupClientID.GetColumnValue("client_id"));


            qry.SetInsert(qryCommander);

            try
            {
                int nRet = qry.Insert();
                
                if (nRet < 0)
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                itemErrMsg.Caption = ex.Message;
                return -1;                
            }


            return 0;

        }

        private int InsertProjectInfo()
        {


            try
            {
                if (chkData() < 0)
                {
                    return -1;
                }

                if (makeSEQ() < 0)
                {
                    return -1;
                }

                if (InsertData() < 0)
                {
                    return -1;
                }

            }
            catch (Exception ex)
            {
                itemErrMsg.Caption = ex.Message;
                return -1;                
            }

            return 0;
/*


            CHeader Header = new CHeader(UserInfo.UserID, "A0101A", "XtraNewProject", "00000", "");

            DataTable data = new DataTable("projectInfo");

            DataColumn colproject_nm = new DataColumn("project_nm", typeof(string));
            DataColumn colstart_dt = new DataColumn("start_dt", typeof(string));
            DataColumn colend_dt = new DataColumn("end_dt", typeof(string));
            DataColumn colclient_cd = new DataColumn("client_cd", typeof(string));
            DataColumn colclient_id = new DataColumn("client_id", typeof(string));



            data.Columns.Add(colproject_nm);
            data.Columns.Add(colstart_dt);
            data.Columns.Add(colend_dt);
            data.Columns.Add(colclient_cd);
            data.Columns.Add(colclient_id);


            DataRow Dr = data.NewRow();
            Dr["project_nm"] = edtProjectNm.Text;
            Dr["start_dt"] = dateStart.Text.Replace("-", "");
            Dr["end_dt"] = dateEnd.Text.Replace("-", "");
            Dr["client_cd"] = lookupClient.GetColumnValue("client_cd");
            Dr["client_id"] = lookupClientID.GetColumnValue("client_id");


            data.Rows.Add(Dr);

            CParam Param = new CParam(data);

            DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            if (Dt.Rows[0]["err_cd"].ToString() == "00000")
            {


                DataTable Data = ds.Tables["Table"];
                ProjectInfo.ProjectCD = Data.Rows[0]["project_cd"].ToString();
                ProjectInfo.ProjectNM = Data.Rows[0]["project_nm"].ToString();

            }
            else
            {
               // this.DialogResult = DialogResult.Abort;

                return -1;
            }
            
            return 0;
*/
        }


        private void XtraNewProject_Load(object sender, EventArgs e)
        {
            //발주처 정보를 조회한다.
            QueryClientInfo();
        }

        public void QueryClientInfo()
        {

            Cnpgsql Qry = new Cnpgsql();
            NpgsqlCommand QryCommander = new NpgsqlCommand();

            string sql = $" select client_cd" +
                         $"      , client_nm" +
                         $"  from client01m00";

            QryCommander.CommandText = sql;

            Qry.SetSelect(QryCommander);

            try
            {
                DataTable dt = Qry.Select();

                lookupClient.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                itemErrMsg.Caption = ex.Message;

                return;
            }

            /*

            // 로그인 정보를 처리한다.
            CHeader Header = new CHeader(UserInfo.UserID, "A0200A", "XtraNewProject", "00000", "");


            CParam Param = new CParam();


            //refHighTops.HighTopsSoapClient aaa = new refHighTops.HighTopsSoapClient();
            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());            

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();
            
            DataTable Data = ds.Tables["Table"];
            lookupClient.Properties.DataSource = Data;
            

    */

        }

        /// <summary>
        /// 발주처 담당자 정보를 조회한다.
        /// </summary>
        public void QueryClientIDInfo()
        {

            Cnpgsql Qry = new Cnpgsql();
            NpgsqlCommand QryCommander = new NpgsqlCommand();

            string sql = $" select client_id" +
                         $"      , client_id_nm" +
                         $"  from client01t00" +
                         $" where client_cd like '%'|| :p_client_cd ||'%'";


            QryCommander.CommandText = sql;

            QryCommander.Parameters.AddWithValue("p_client_cd", lookupClient.GetColumnValue("client_cd").ToString());

            Qry.SetSelect(QryCommander);

            try
            {
                DataTable dt = Qry.Select();
                lookupClientID.Properties.DataSource = dt;

            }
            catch (Exception ex)
            {
                itemErrMsg.Caption = ex.Message;
                return;
            }

            /*

            CHeader Header = new CHeader(UserInfo.UserID, "A0201A", "XtraNewProject", "00000", "");

            DataTable data = new DataTable("clientInfo");

            DataColumn colClientCd = new DataColumn("client_cd", typeof(string));

            data.Columns.Add(colClientCd);

            


            DataRow Dr = data.NewRow();
            Dr["client_cd"] = lookupClient.GetColumnValue("client_cd");

            data.Rows.Add(Dr);

            CParam Param = new CParam(data);
            
            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            DataTable Data = ds.Tables["Table"];
            lookupClientID.Properties.DataSource = Data;

    */
        }

        /// <summary>
        /// 발주처 정보를 선택하면
        /// 해당 발주처에 등록된 담당자를 조회한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookupClient_EditValueChanged(object sender, EventArgs e)
        {
            QueryClientIDInfo();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
