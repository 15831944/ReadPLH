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
    public partial class XtraQrySection : WindowsFormsApp1.Base.XtraBaseForm
    {
        public XtraQrySection()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow Dr = gridView1.GetFocusedDataRow();

            edtGroupCd.Text = Dr["section_group_cd"].ToString();
            edtGroupNm.Text = Dr["section_group_nm"].ToString();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QrySectionList();
        }


        /// <summary>
        /// 프로젝트 리스트를 조회한다.
        /// </summary>
        private void QrySectionList()
        {
            CHeader Header = new CHeader(UserInfo.UserID, "A0110A", "XtraQrySection", "00000", "");

            DataTable data = new DataTable("section_list");

            DataColumn colSectionGroupCd = new DataColumn("section_group_cd", typeof(string));
            DataColumn colSectionGroupNm = new DataColumn("section_group_nm", typeof(string));

            data.Columns.Add(colSectionGroupCd);
            data.Columns.Add(colSectionGroupNm);


            DataRow Dr = data.NewRow();
            Dr["section_group_cd"] = edtGroupCd.Text;
            Dr["section_group_nm"] = edtGroupNm.Text;


            data.Rows.Add(Dr);

            CParam Param = new CParam(data);

            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            DataTable Data = ds.Tables["Table"];
            gridControl1.DataSource = Data;
        }

        private void brnInsert_Click(object sender, EventArgs e)
        {
        }


        private void InsertSection()
        {
            try
            {

                CHeader Header = new CHeader(UserInfo.UserID, "A0110B", "XtraQrySection", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionGroupCd = new DataColumn("section_group_cd", typeof(string));
                DataColumn colSectionGroupNm = new DataColumn("section_group_nm", typeof(string));

                data.Columns.Add(colSectionGroupCd);
                data.Columns.Add(colSectionGroupNm);


                DataRow Dr = data.NewRow();

                Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                if (itemErrCd.Caption == "00000")
                {
                    DataTable dt1 = ds.Tables["Table"];
                    edtGroupCd.Text = dt1.Rows[0]["cnt"].ToString();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void DeleteSection()
        {
            try
            {

                CHeader Header = new CHeader(UserInfo.UserID, "A0110C", "XtraQrySection", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionGroupCd = new DataColumn("section_group_cd", typeof(string));
                DataColumn colSectionGroupNm = new DataColumn("section_group_nm", typeof(string));

                data.Columns.Add(colSectionGroupCd);
                data.Columns.Add(colSectionGroupNm);


                DataRow Dr = data.NewRow();
                Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.deleteData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                if (itemErrCd.Caption == "00000")
                {

                    edtGroupCd.Text = "";
                    edtGroupNm.Text = "";

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

        private void btnInit_Click(object sender, EventArgs e)
        {
     
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu1.ShowPopup(Control.MousePosition);
        }



        /// <summary>
        /// 신규 아이템 추가 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.AddNewRow();
        }

        /// <summary>
        /// 아이템 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteSection();
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
                InsertSection();                
            }
            catch (Exception ex)
            {

            }
        }

        private void editFormCancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소");
        }

        private void groupControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu2.ShowPopup(Control.MousePosition);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitGroupPanel();
        }

        private void InitGroupPanel()
        {



            //if (groupControl1.HasChildren == true)
            //{
            //    foreach (Control item in groupControl1.Controls)
            //    {
            //        if (item is TextEdit)
            //        {
            //            TextEdit edtbox = (TextEdit)item;
            //            edtbox.Text = "";
            //        }
            //    }
            //}
        }
    }

}