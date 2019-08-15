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
    public partial class XtraSectionList : WindowsFormsApp1.Base.XtraBaseForm
    {
        public XtraSectionList()
        {
            InitializeComponent();
        }

        private void XtraSectionList_Load(object sender, EventArgs e)
        {
            QrySectionGroup();
        }


        /// <summary>
        /// 프로젝트 리스트를 조회한다.
        /// </summary>
        private void QrySectionGroup()
        {
            CHeader Header = new CHeader(UserInfo, "A0110A", "XtraQrySection", "00000", "");

            DataTable data = new DataTable("section_list");

            DataColumn colSectionGroupCd = new DataColumn("section_group_cd", typeof(string));

            data.Columns.Add(colSectionGroupCd);


            DataRow Dr = data.NewRow();
            Dr["section_group_cd"] = "";

            data.Rows.Add(Dr);

            CParam Param = new CParam(data);

            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            DataTable Data = ds.Tables["Table"];
            lookupGroup.Properties.DataSource = Data;
        }

        private void lookupGroup_EditValueChanged(object sender, EventArgs e)
        {
            
            QrySectionList();
        }

        private void QrySectionList()
        {
            try
            {

                CHeader Header = new CHeader(UserInfo, "A0120A", "XtraQrySection", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionGroupCd = new DataColumn("section_group_cd", typeof(string));
                data.Columns.Add(colSectionGroupCd);

                DataRow Dr = data.NewRow();
                Dr["section_group_cd"] = lookupGroup.GetColumnValue("section_group_cd");

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

                throw ex;
            }

        }

        /// <summary>
        /// 구간 ID를 등록한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void DeleteData()
        {
            try
            {

                DataTable chkTable = (DataTable)gridControl1.DataSource;

                if (chkTable == null)
                {
                    MessageBox.Show("데이터가 없습니다.");

                    return;
                }

                CHeader Header = new CHeader(UserInfo, "A0120C", "XtraQrySection", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionGroupCd = new DataColumn("section_group_cd", typeof(string));
                DataColumn colSectionId = new DataColumn("section_id", typeof(string));
                DataColumn colSectionNm = new DataColumn("section_id_nm", typeof(string));
                DataColumn colAsphalt1 = new DataColumn("asphalt1", typeof(double));
                DataColumn colAsphalt2 = new DataColumn("asphalt2", typeof(double));
                DataColumn colComplay = new DataColumn("complay", typeof(double));
                DataColumn colMixlay = new DataColumn("mixlay", typeof(double));
                DataColumn colDesc = new DataColumn("desc", typeof(string));

                data.Columns.Add(colSectionGroupCd);
                data.Columns.Add(colSectionId);
                data.Columns.Add(colSectionNm);
                data.Columns.Add(colAsphalt1);
                data.Columns.Add(colAsphalt2);
                data.Columns.Add(colComplay);
                data.Columns.Add(colMixlay);
                data.Columns.Add(colDesc);


                DataRow Dr = data.NewRow();

                Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];
                Dr["section_group_cd"] = lookupGroup.GetColumnValue("section_group_cd");
                data.Rows.Add(Dr);
                //data.Rows.Add(.);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                ///정상등록된 경우만 최종 결과값을 재 조회한다.
                if (Dt.Rows[0]["err_cd"].ToString() == "00000")
                {
                    QrySectionList();
                }


                //                DataTable Data = ds.Tables["Table"];
                //                gridControl1.DataSource = Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void InsertData()
        {
            try
            {

                DataTable chkTable = (DataTable)gridControl1.DataSource;

                if (chkTable == null)
                {
                    MessageBox.Show("데이터가 없습니다.");

                    return;
                }

                CHeader Header = new CHeader(UserInfo, "A0120B", "XtraQrySection", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionGroupCd = new DataColumn("section_group_cd", typeof(string));
                DataColumn colSectionId = new DataColumn("section_id", typeof(string));
                DataColumn colSectionNm = new DataColumn("section_id_nm", typeof(string));
                DataColumn colAsphalt1 = new DataColumn("asphalt1", typeof(double));
                DataColumn colAsphalt2 = new DataColumn("asphalt2", typeof(double));
                DataColumn colComplay = new DataColumn("complay", typeof(double));
                DataColumn colMixlay = new DataColumn("mixlay", typeof(double));
                DataColumn colDesc = new DataColumn("desc", typeof(string));


                data.Columns.Add(colSectionGroupCd);
                data.Columns.Add(colSectionId);
                data.Columns.Add(colSectionNm);
                data.Columns.Add(colAsphalt1);
                data.Columns.Add(colAsphalt2);
                data.Columns.Add(colComplay);
                data.Columns.Add(colMixlay);
                data.Columns.Add(colDesc);

                //DataRow Dr = data.NewRow();



                //Dr["section_group_cd"] = lookupGroup.GetColumnValue("section_group_cd");
                //Dr["section_id"] = edtSectionId.Text;
                //Dr["section_id_nm"] = edtSectionIdNm.Text;
                //Dr["asphalt1"] = edtAsphalt1.Text;
                //Dr["asphalt2"] = edtAsphalt2.Text;
                //Dr["complay"] = edtCompLay.Text;
                //Dr["mixlay"] = edtMixLay.Text;
                //Dr["desc"] = edtDesc.Text;

                DataRow Dr = data.NewRow();



                Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];
                Dr["section_group_cd"] = lookupGroup.GetColumnValue("section_group_cd");
                data.Rows.Add(Dr);
                //data.Rows.Add(.);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                ///정상등록된 경우만 최종 결과값을 재 조회한다.
                if (Dt.Rows[0]["err_cd"].ToString() == "00000")
                {
                    QrySectionList();
                }


//                DataTable Data = ds.Tables["Table"];
//                gridControl1.DataSource = Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void edtCompLay_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //DataRow dr = gridView1.GetFocusedDataRow();
            //edtSectionId.Text = dr["section_id"].ToString();
            //edtSectionIdNm.Text = dr["section_id_nm"].ToString();
            //edtAsphalt1.Text = dr["asphalt1"].ToString();
            //edtAsphalt2.Text = dr["asphalt2"].ToString();
            //edtCompLay.Text = dr["complay"].ToString();
            //edtMixLay.Text = dr["mixlay"].ToString();
            //edtDesc.Text = dr["desc"].ToString();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
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
                InsertData();                
            }
            catch (Exception ex)
            {

            }
        }

        private void editFormCancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소");
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //e.Valid = false;
            //e.ErrorText = "잘 안된것 같아요";
        }

            private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ErrorText = "18181818";
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInit_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// POP UP MENU 실행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu1.ShowPopup(Control.MousePosition);
        }

        /// <summary>
        /// POP UP 신규 메뉴 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteData();
        }
    }
}
