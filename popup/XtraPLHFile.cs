using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Comm;

namespace WindowsFormsApp1.popup
{
    public partial class XtraPLHFile : WindowsFormsApp1.Base.XtraBaseForm
    {
        public XtraPLHFile()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            QryFileList();
        }



        /// <summary>
        /// 프로젝트 리스트를 조회한다.
        /// </summary>
        private void QryFileList()
        {

            Cnpgsql Qry = new Cnpgsql();

            string sql = $" select file_name" +
                         $"      , description" +
                         $"      , work_date" +
                         $"      , work_user" +
                         $"      , file" +
                         $"      , 'DWONLOAD' " +
                         $"  from file01m00" +
                         $" where file_name like  '%' || :p_file_name || '%' ";

            NpgsqlCommand QryCommander = new NpgsqlCommand();

            QryCommander.CommandText = sql;
            QryCommander.Parameters.AddWithValue("p_file_name", edtFileNm.Text);

            Qry.SetSelect(QryCommander);

            try
            {
                DataTable dt = Qry.Select();
                gridControl1.DataSource = dt;

            }
            catch (Exception ex)
            {
                itemErrMsg.Caption = ex.Message;
            }

/*

            CHeader Header = new CHeader(UserInfo.UserID, "A0002A", "XtraPLHFile", "00000", "");


            dsFile.Tables["tbl_file"].Clear();

            DataRow Dr = dsFile.Tables["tbl_file"].NewRow();
            Dr["file_name"] = edtFileNm.Text;


            dsFile.Tables["tbl_file"].Rows.Add(Dr);                

            CParam Param = new CParam(dsFile.Tables["tbl_file"]);

            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            if (SetStatus(ds) == true)
            {
                DataTable Data = ds.Tables["Table"];
                gridControl1.DataSource = Data;
            }



*/
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDlg = new OpenFileDialog();
            fDlg.ShowDialog();

            DataRow dr = gridView1.GetFocusedDataRow();
            dr["file_name"] = fDlg.FileName;



            //gridView1.inp

        }
    }
}
