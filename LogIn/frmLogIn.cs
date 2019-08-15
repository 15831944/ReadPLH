using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Comm;

namespace WindowsFormsApp1.LogIn
{
    public partial class frmLogIn : WindowsFormsApp1.Base.XtraBaseForm
    {        
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (QryData() == 0)
            {
                DialogResult = DialogResult.OK;
                
                this.Close();
            }
            else
            {
                //DialogResult = DialogResult.No;
            }
            
        }


        private int QryData()
        {

            string sql = $" select user_id" +
                         $"      , user_nm" +
                         $"  from usr01m00" +
                         $" where user_id =  :p_user_id " +
                         $"   and pswd    =  :p_pswd ";


            SqlUserCheck.CommandText = sql;


            Cnpgsql npgsql = new Cnpgsql();

            SqlUserCheck.Parameters.AddWithValue("p_user_id", edtUserId.Text);
            SqlUserCheck.Parameters.AddWithValue("p_pswd", edtPswd.Text);

            npgsql.SetSelect(SqlUserCheck);
            DataTable dt = npgsql.Select();


            if (dt is null)
            {
                return -1;
            }


            return 0;
            

            /*


            // 로그인 정보를 처리한다.
            CHeader Header = new CHeader("test", "A0001A", "LOGIN", "00000", "");


            DataTable data = new DataTable("LoginInfo");

            DataColumn colUserId = new DataColumn("user_id", typeof(string));
            DataColumn colPswd = new DataColumn("pswd", typeof(string));

            data.Columns.Add(colUserId);
            data.Columns.Add(colPswd);


            DataRow Dr = data.NewRow();
            Dr["user_id"] = edtUserId.Text;
            Dr["pswd"] = edtPswd.Text;

            data.Rows.Add(Dr);

            CParam Param = new CParam(data);

            //wcfHighTop.HighTopsSoapClient aaa = new refHighTops.HighTopsSoapClient();
            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());


            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            if (Dt.Rows[0]["err_cd"].ToString().PadRight(5, ' ') != "00000")
            {
                return -1;
            }

            return 0;

            */
        }

    }
}
