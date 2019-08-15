using DevExpress.XtraEditors;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
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
    public partial class XtraMngrCd : WindowsFormsApp1.Base.XtraBaseForm
    {
        public XtraMngrCd()
        {
            InitializeComponent();


        }

        private void XtraMngrCd_Load(object sender, EventArgs e)
        {
            LoadMngrGb();
        }

        /// <summary>
        /// 대분류 정보를 lookup Editor에 출력
        /// </summary>
        private void LoadMngrGb()
        {
            CHeader Header = new CHeader(UserInfo.UserID, "A0111A", "XtraMngrCd", "00000", "");

            DataTable data = new DataTable("section_list");

            DataColumn colSectionGroupNm = new DataColumn("mngr_gb_nm", typeof(string));

            data.Columns.Add(colSectionGroupNm);


            DataRow Dr = data.NewRow();
            Dr["mngr_gb_nm"] = "";

            data.Rows.Add(Dr);

            CParam Param = new CParam(data);

            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            DataTable Data = ds.Tables["Table"];

            lookUpMngrGb.Properties.DataSource = Data;

            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            if (itemErrCd.Caption == "00000")
            {
                //DataTable dt1 = ds.Tables["Table"];
                //edtGroupCd.Text = dt1.Rows[0]["cnt"].ToString();

                LoadMngrTp();
            }


            

        }

        private void LoadMngrTp()
        {

            if (lookUpMngrGb.Properties.DataSource is null)
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = "대분류 선택을 확인하세요 (null)";

                return;
            }

            if (lookUpMngrGb.Text == "NO DATA")
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = "대분류 선택을 확인하세요 (no data)";


                return;
            }




            CHeader Header = new CHeader(UserInfo.UserID, "A0112A", "XtraMngrCd", "00000", "");

            DataTable data = new DataTable("section_list");

            DataColumn colMngrGb= new DataColumn("mngr_gb", typeof(Int32));
            DataColumn colMngrTpNm= new DataColumn("mngr_tp_nm", typeof(string));

            data.Columns.Add(colMngrGb);
            data.Columns.Add(colMngrTpNm);


            DataRow Dr = data.NewRow();
            Dr["mngr_gb"] = Convert.ToInt32(lookUpMngrGb.GetColumnValue("mngr_gb").ToString());
            Dr["mngr_tp_nm"] = "";

            data.Rows.Add(Dr);

            CParam Param = new CParam(data);

            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            DataTable Data = ds.Tables["Table"];

            lookUpMngrTp.Properties.DataSource = Data;

        }

        private void lookUpMngrGb_EditValueChanged(object sender, EventArgs e)
        {
            LoadMngrTp();
        }

        private void btnQry_Click(object sender, EventArgs e)
        {
            QrySectionList();
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        /// <summary>
        /// 프로젝트 리스트를 조회한다.
        /// </summary>
        private void QrySectionList()
        {

            try
            {
                CHeader Header = new CHeader(UserInfo.UserID, "A0113A", "XtraMngrCd", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colMngrGb = new DataColumn("mngr_gb", typeof(Int32));
                DataColumn colMngrTp = new DataColumn("mngr_tp", typeof(Int32));
                DataColumn colMngrCdNm = new DataColumn("mngr_cd_nm", typeof(string));

                data.Columns.Add(colMngrGb);
                data.Columns.Add(colMngrTp);
                data.Columns.Add(colMngrCdNm);


                DataRow Dr = data.NewRow();
                Dr["mngr_gb"] = Convert.ToInt32(lookUpMngrGb.GetColumnValue("mngr_gb").ToString());
                Dr["mngr_tp"] = Convert.ToInt32(lookUpMngrTp.GetColumnValue("mngr_tp").ToString());
                Dr["mngr_cd_nm"] = edtMngrCdNm.Text;

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                DataTable Data = ds.Tables["Table"];
                gridControl1.DataSource = Data;
            }
            catch (Exception ex)
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = ex.Message;
            }

        }

        private void gridView1_ShowingPopupEditForm(object sender, DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {
            foreach (Control control in e.EditForm.Controls)
            {
                if (!(control is EditFormContainer))
                {
                    continue;
                }
                foreach (Control nestedControl in control.Controls)
                {
                    if (!(nestedControl is PanelControl))
                    {
                        continue;
                    }
                    foreach (Control button in nestedControl.Controls)
                    {
                        if (!(button is SimpleButton))
                        {
                            continue;
                        }





                        if (button.Text == "취소")
                        {
                            var btnCancel = button as SimpleButton;
                            btnCancel.Click -= editFormCancelButton_Click;
                            btnCancel.Click += editFormCancelButton_Click;

                        }
                        else
                        {
                            var btnUpdate = button as SimpleButton;
                            btnUpdate.Click -= editFormUpdateButton_Click;
                            btnUpdate.Click += editFormUpdateButton_Click;
                        }


                    }
                }
            }
        }

        private void editFormUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUtil.GetFocusedFieldValue(gridView1, "mngr_cd").Trim() == "")
                {
                    InsertSection();
                }
                else
                {
                    if (XtraMessageBox.Show("정정 하시겠습니까?", "정정확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MidifySection();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void editFormCancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소");
        }

        private void MidifySection()
        {

        }

        /// <summary>
        /// 신규 중분류를 등록한다.
        /// </summary>
        private void InsertSection()
        {
            try
            {

                CHeader Header = new CHeader(UserInfo.UserID, "A0113B", "XtraMngrCd", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionMngrGb = new DataColumn("mngr_gb", typeof(Int32));
                DataColumn colSectionMngrTp = new DataColumn("mngr_tp", typeof(Int32));
                DataColumn colSectionMngrCdNm = new DataColumn("mngr_cd_nm", typeof(string));
                DataColumn colSectionUnitTp   = new DataColumn("unit_tp", typeof(string));
                DataColumn colSectionUnit     = new DataColumn("unit", typeof(double));


                data.Columns.Add(colSectionMngrGb);
                data.Columns.Add(colSectionMngrTp);
                data.Columns.Add(colSectionMngrCdNm);
                data.Columns.Add(colSectionUnitTp);
                data.Columns.Add(colSectionUnit);

                DataRow Dr = data.NewRow();

                //Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];
                Dr["mngr_gb"] = gridView1.GetFocusedDataRow()["mngr_gb"];
                Dr["mngr_tp"] = gridView1.GetFocusedDataRow()["mngr_tp"];
                Dr["mngr_cd_nm"] = gridView1.GetFocusedDataRow()["mngr_cd_nm"];
                Dr["unit_tp"] = gridView1.GetFocusedDataRow()["unit_tp"];
                Dr["unit"] = gridView1.GetFocusedDataRow()["unit"];

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                if (itemErrCd.Caption == "00000")
                {
                    //DataTable dt1 = ds.Tables["Table"];
                    //edtGroupCd.Text = dt1.Rows[0]["cnt"].ToString();

                    QrySectionList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            //DataTable Data = ds.Tables["Table"];
            //gridControl1.DataSource = Data;
        }


        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow Dr = gridView1.GetDataRow(e.RowHandle);

            Dr["mngr_gb_nm"] = lookUpMngrGb.Text;
            Dr["mngr_gb"] = lookUpMngrGb.GetColumnValue("mngr_gb");

            Dr["mngr_tp_nm"] = lookUpMngrTp.Text;
            Dr["mngr_tp"] = lookUpMngrTp.GetColumnValue("mngr_tp");

        }

        private void btnAddData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (lookUpMngrGb.Text == "NO DATA" || lookUpMngrGb.Properties.DataSource is null || lookUpMngrGb.Text.Trim() == "")
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = "대분류 선택을 확인하세요 (no data)";


                return;
            }


            if (lookUpMngrTp.Text == "NO DATA" || lookUpMngrTp.Properties.DataSource is null || lookUpMngrTp.Text.Trim() == "")
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = "중분류 선택을 확인하세요 (no data)";


                return;
            }


            gridView1.AddNewRow();
        }

        private void btnDelData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteSection();
        }


        /// <summary>
        /// 중분류를 삭제한다.
        /// </summary>
        private void DeleteSection()
        {
            try
            {

                CHeader Header = new CHeader(UserInfo.UserID, "A0112C", "XtraMngrGb", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionMngrGb = new DataColumn("mngr_gb", typeof(Int32));
                DataColumn colSectionMngrTp = new DataColumn("mngr_tp", typeof(Int32));


                data.Columns.Add(colSectionMngrGb);
                data.Columns.Add(colSectionMngrTp);


                DataRow Dr = data.NewRow();
                Dr["mngr_gb"] = Convert.ToInt32(gridView1.GetFocusedDataRow()["mngr_gb"].ToString());
                Dr["mngr_tp"] = Convert.ToInt32(gridView1.GetFocusedDataRow()["mngr_tp"].ToString());

                //Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.deleteData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                if (itemErrCd.Caption == "00000")
                {

                    //edtGroupCd.Text = "";
                    //edtGroupNm.Text = "";

                    QrySectionList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


            //DataTable Data = ds.Tables["Table"];
            //gridControl1.DataSource = Data;
        }

        private void lookUpMngrTp_EditValueChanged(object sender, EventArgs e)
        {
            QrySectionList();
        }
    }
}
