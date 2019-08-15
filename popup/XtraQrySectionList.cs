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
    public partial class XtraQrySectionList : WindowsFormsApp1.Base.XtraBaseForm
    {

        // delegate 이벤트선언

        public delegate void SendSelecList(object obj);
        public event SendSelecList SendSelectListEvent;





        public XtraQrySectionList()
        {
            InitializeComponent();
        }

        private void XtraQrySectionList_Load(object sender, EventArgs e)
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


        /// <summary>
        /// 더블클릭 이벤트 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {            
            this.SendSelectListEvent(gridView1);

            
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_ShowingPopupEditForm(object sender, DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {
  
        }

        private void editFormUpdateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void editFormCancelButton_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
        }

            private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
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
        }

        /// <summary>
        /// POP UP 신규 메뉴 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }


    }
}
