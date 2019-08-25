using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Comm;
using WindowsFormsApp1.Info;
using WindowsFormsApp1.Lib;
using WindowsFormsApp1.popup;
using static WindowsFormsApp1.CPlhData;

namespace WindowsFormsApp1.Screen
{
    public partial class XtraPLH : WindowsFormsApp1.Base.XtraBaseForm
    {
        string m_strFileName = "";
        public XtraPLH()
        {
            InitializeComponent();
        }

        public XtraPLH(CProjectInfo paramProjectInfo)
        {
            InitializeComponent();

            ProjectInfo = paramProjectInfo;
        }

        public XtraPLH(string strProc)
        {
            InitializeComponent();

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            

          

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
 
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void XtraPLH_Load(object sender, EventArgs e)
        {
            this.Text = ProjectInfo.ProjectNM;
        }


        /// <summary>
        /// 파일에서 PLH 정보를 읽는다.
        /// </summary>
        public void LoadPLH()
        {
            String FileName;
            String RLine;
            CPlhData LToR = new CPlhData();


            LToR.m_dt.Clear();
            XtraOpenFileDialog Opendlg = new XtraOpenFileDialog();

            Opendlg.Filter = "PLH 파일 (*.PLH)|*.PLH|모든파일(*.*)|*.*";
            Opendlg.Multiselect = true;

            if (Opendlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string strFileName in Opendlg.FileNames)
                {
                    FileName = Path.GetFileName(strFileName);

                    using (StreamReader SR = new StreamReader(strFileName, Encoding.Default))
                    {
                        while ((RLine = SR.ReadLine()) != null)
                        {

                            LToR.LineToRecord(FileName, RLine);
                        }
                    }
                }


                gridControl1.DataSource = LToR.m_dt;
                //MessageBox.Show(LToR.m_dt.Rows.Count.ToString());

                adView1.BestFitColumns();

            }
        }


        /// <summary>
        /// 서버에 PLH 정보를 저장한다. 
        /// </summary>
        private void SavePLH()
        {

            DataTable plh_data;
            try
            {
                plh_data = (DataTable)gridControl1.DataSource;
                plh_data.TableName = "PlhData";

            }
            catch (Exception e)
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = e.Message;

                return;
            }

            Service.CSvcPLH.DeletePLH(ProjectInfo);
            Service.CSvcPLH.SavePLH(ProjectInfo, plh_data);
                                    
            //DataTable plh_data;
            //try
            //{
            //    plh_data = (DataTable)gridControl1.DataSource;
            //    plh_data.TableName = "PlhData";

            //}
            //catch (Exception e)
            //{
            //    itemErrCd.Caption = "ERROR";
            //    itemErrMsg.Caption = e.Message;

            //    throw;
            //}







            //CHeader Header = new CHeader(UserInfo.UserID, "A1001A", "XtraPLH", "00000", "");



            //DataTable Data = new DataTable("PlhInfo");
            //DataColumn colProjectCd = new DataColumn("project_cd", typeof(string));


            //Data.Columns.Add(colProjectCd);



            //DataRow Dr = Data.NewRow();
            //Dr["project_cd"] = ProjectInfo.ProjectCD;

            //Data.Rows.Add(Dr);

            ////Project 정보를 담은 ...
            //CParam Param = new CParam(Data);


            //Param.AddDataTable(plh_data);


            //using (DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet()))
            //{

            //    DataTable Dt = ds.Tables["eror_dt"];
            //    itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            //    itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            //    DataTable rcvData = ds.Tables["Table"];
            //    gridControl1.DataSource = rcvData;

            //}
        }

        /// <summary>
        /// 서버에서 PLH 정보를 LOAD  한다.
        /// </summary>
        public void QryPLH()
        {


            Cnpgsql Qry = new Cnpgsql();
            NpgsqlCommand qryCommand = new NpgsqlCommand();

            string sql;

            sql = $" select a.*                   " +
                  $"      ,get_pavement('1', project_cd, key, order_seq, filename) pavement_stat    " +
                  $"      ,get_pavement('2', project_cd, key, order_seq, filename) pavement_stat_nm " +
                  $"      , 'false'  as check   " +
                  $"  from plh01m00 a   " +
                  $" where project_cd = :p_project_cd                 " +
                  $" order by a.order_seq; ";

            
            qryCommand.CommandText = sql;

            qryCommand.Parameters.AddWithValue("p_project_cd", ProjectInfo.ProjectCD);


            Qry.SetSelect(qryCommand);

            try
            {
                DataTable dt = Qry.Select();
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                itemErrMsg.Caption = ex.Message;
                
                //throw;
            }

/*            

            CHeader Header = new CHeader(UserInfo.UserID, "A1002A", "XtraPLH", "00000", "");



            DataTable Data = new DataTable("PlhInfo");
            DataColumn colProjectCd = new DataColumn("project_cd", typeof(string));


            Data.Columns.Add(colProjectCd);



            DataRow Dr = Data.NewRow();
            Dr["project_cd"] = ProjectInfo.ProjectCD;

            Data.Rows.Add(Dr);

            //Project 정보를 담은 ...
            CParam Param = new CParam(Data);


            using (DataSet ds = CTransfer.QryData(Header, Param.GetDataSet()))
            {

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                DataTable rcvData = ds.Tables["Table"];
                gridControl1.DataSource = rcvData;

            }

*/
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


            //AdvBandedGridView view = sender as AdvBandedGridView;
            AdvBandedGridView view = adView1;
            DataRow Dr;


            switch (e.ClickedItem.Tag)
            {
                case "1":
                    //전체선택
                    view.SelectAll();

                    foreach (var item in view.GetSelectedRows())
                    {
                        Dr = view.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        view.SetRowCellValue(item, "check", "true");
                    }

                    break;
                case "2":
                    //전체해제
                    //전체 해제

                    view.SelectAll();

                    foreach (var item in view.GetSelectedRows())
                    {
                        Dr = view.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        view.SetRowCellValue(item, "check", "false");
                    }

                    //전체 선택 해제
                    view.ClearSelection();
                    break;
                case "3":
                    //부분선택

                    foreach (var item in view.GetSelectedRows())
                    {
                        Dr = view.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        view.SetRowCellValue(item, "check", "true");
                    }
                    break;
                case "4":
                    //부분해제

                    // 부분해제

                    foreach (var item in view.GetSelectedRows())
                    {
                        Dr = view.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        view.SetRowCellValue(item, "check", "false");
                    }
                    break;

                default:
                    break;
            }
        }


        /// <summary>
        /// 줄 복사를 처리한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DataTable Dt = (DataTable)gridControl1.DataSource;


            //DataRow를 Copy한다.
            DataRow Dr = CUtil.CopyDataRow(Dt, adView1.GetFocusedDataRow());

            long nCurKey = 0;
            long nOrderSeq = 0;
            long nTotRecord = 0;

            nTotRecord = Dt.Rows.Count + 1;
            //복사해서 새로 생긴 Record는 Key값은 최종 Record Count로 지정한다.
            Dr["key"] = nTotRecord;
            nOrderSeq = Convert.ToInt64(Dr["order_seq"].ToString());
            nCurKey = Convert.ToInt64(Dr["key"].ToString());

            foreach (DataRow item in Dt.Rows)
            {
                long nSeq = Convert.ToInt64(item["order_seq"].ToString());

                if (nSeq >= nOrderSeq)
                {
                    item["order_seq"] = ++nSeq;
                }
            }
            Dt.Rows.InsertAt(Dr, adView1.GetFocusedDataSourceRowIndex());

        }

        private void adView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow Dr;
            Dr = view.GetDataRow(e.RowHandle);


            if (e.Column.FieldName.Trim() == "baseangle")
            {
                //PLH TAB의 기초각을 편집할 경우 수식을 모래부설에 적용한다.
                CPlhData LToR = new CPlhData();

                Dr["sand"] = LToR.CalcBaseAngle(Dr).ToString($"F{3}");
            }
            else
            {
                ReCalcArea(Dr);

            }
        }


        private void ReCalcArea(DataRow Dr)
        {
            double area1; //터파기
            double area2; //관주위
            double area3; //관상단
            double area4; //잔토처리
            double area5; //모래부설
            double area6; //파취  
            double area7; //복구
            double area8; //보조기층
            double area9; //혼합기층

            double AA = ToDouble(Dr, CUtil.GetName(enumPLH.mixlay));
            double AS = ToDouble(Dr, CUtil.GetName(enumPLH.h));
            double AR = ToDouble(Dr, CUtil.GetName(enumPLH.b));
            double O = ToDouble(Dr, CUtil.GetName(enumPLH.slope));
            double V = ToDouble(Dr, CUtil.GetName(enumPLH.humanity));
            double W = ToDouble(Dr, CUtil.GetName(enumPLH.concrete));
            double X = ToDouble(Dr, CUtil.GetName(enumPLH.asphalt1));
            double Y = ToDouble(Dr, CUtil.GetName(enumPLH.asphalt2));
            double Z = ToDouble(Dr, CUtil.GetName(enumPLH.complay));
            double K = ToDouble(Dr, CUtil.GetName(enumPLH.dia));
            double P = ToDouble(Dr, CUtil.GetName(enumPLH.bcut));
            double Q = ToDouble(Dr, CUtil.GetName(enumPLH.hcut));
            double R = ToDouble(Dr, CUtil.GetName(enumPLH.manwork));
            double S = ToDouble(Dr, CUtil.GetName(enumPLH.sand));

            area9 = Math.Round(((AR + (AR - (((Z + AA) * P) * 2))) / 2 * AA), 3);
            area8 = Math.Round(((AR + (AR - ((Z * O) * 2))) / 2 * Z), 3);
            area7 = Math.Round(AR, 3);
            area6 = Math.Round(AR * (W + X + Y), 3);
            area5 = Math.Round(((((K + P * 2) + ((K + P * 2) + (S * O * 2))) / 2 * S) - (Math.Pow(K, 2) * 3.14 / 4 * 0.5)), 4);
            area4 = Math.Round((area5 + area8 + area9) + (Math.Pow(K, 2) * 3.14 / 4), 3);
            area1 = Math.Round(((((((AS - (V + W + X + Y)) * O) * 2 + (K + P * 2)) + (K + P * 2)) / 2) * (AS - (V + W + X + Y))), 3);
            area2 = Math.Round((((K + P * 2) + ((K + P * 2) + ((Q + K + R) * O * 2))) / 2 * (Q + K + R) - (Math.Pow(K, 2) * 3.14 / 4)) - area5, 3);
            area3 = Math.Round(area1 - area2 - area4, 3);

            Dr["area1"] = area1.ToString("0.000");
            Dr["area2"] = area2.ToString("0.000");
            Dr["area3"] = area3.ToString("0.000");
            Dr["area4"] = area4.ToString("0.000");
            Dr["area5"] = area5.ToString("0.000");
            Dr["area6"] = area6.ToString("0.000");
            Dr["area7"] = area7.ToString("0.000");
            Dr["area8"] = area8.ToString("0.000");
            Dr["area9"] = area9.ToString("0.000");
        }

        private double ToDouble(DataRow Dr, String sColNm)
        {
            return Convert.ToDouble(Dr[sColNm].ToString());
        }

        /// <summary>
        /// 구간정보 POPUP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

        }


        private void SetSectorInfo(object sender)
        {
            GridView gridview1 = sender as GridView;

            DataRow Dr = gridview1.GetFocusedDataRow();


            for (int i = 0; i < adView1.RowCount - 1; i++)
            {
               // Dr = adView1.GetDataRow(i);

                if (adView1.GetRowCellValue(i, "check").ToString() == "true")
                {
                    adView1.SetRowCellValue(i, "asphalt1", Dr["asphalt1"]);
                    adView1.SetRowCellValue(i, "asphalt2", Dr["asphalt2"]);
                    adView1.SetRowCellValue(i, "complay", Dr["complay"]);
                    adView1.SetRowCellValue(i, "mixlay", Dr["mixlay"]);
                }
            }

        }

        /// <summary>
        /// 구간정보 POPUP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 구간정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraQrySectionList frmProject = new XtraQrySectionList();
            frmProject.UserInfo = this.UserInfo;

            frmProject.TopMost = true;


            frmProject.SendSelectListEvent += new XtraQrySectionList.SendSelecList(SetSectorInfo);

            frmProject.Show();

        }


        private void gridControl3_Click(object sender, EventArgs e)
        {

        }

        private void advBandedGridView1_ShowingPopupEditForm(object sender, ShowingPopupEditFormEventArgs e)
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

        private void InsertData()
        {
            try
            {

                DataTable chkTable = (DataTable)gridControl3.DataSource;

                if (chkTable == null)
                {
                    MessageBox.Show("데이터가 없습니다.");

                    return;
                }

                CHeader Header = new CHeader(UserInfo, "A1003B", "XtraQrySection", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colProjectCd= new DataColumn("project_cd", typeof(string));
                DataColumn colKey      = new DataColumn("key", typeof(Int32));
                DataColumn colyoungsu_m2 = new DataColumn("yongsu_m2", typeof(double));
                DataColumn col보도블럭_석분_m2 = new DataColumn("보도블럭_석분_m2", typeof(double));
                DataColumn col덧씌우기_asp_m = new DataColumn("덧씌우기_asp_m", typeof(double));
                DataColumn col덧씌우기_asp_con_m = new DataColumn("덧씌우기_asp_con_m", typeof(double));


                data.Columns.Add(colProjectCd);
                data.Columns.Add(colKey);
                data.Columns.Add(colyoungsu_m2);
                data.Columns.Add(col보도블럭_석분_m2);
                data.Columns.Add(col덧씌우기_asp_m);                
                data.Columns.Add(col덧씌우기_asp_con_m);                

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
                Dr["project_cd"] = ProjectInfo.ProjectCD;
                Dr["key"] = advBandedGridView1.GetFocusedDataRow()["key"];
                Dr["yongsu_m2"] = advBandedGridView1.GetFocusedDataRow()["yongsu_m2"];
                Dr["보도블럭_석분_m2"] = advBandedGridView1.GetFocusedDataRow()["보도블럭_석분_m2"];
                Dr["덧씌우기_asp_m"] = advBandedGridView1.GetFocusedDataRow()["덧씌우기_asp_m"];
                Dr["덧씌우기_asp_con_m"] = advBandedGridView1.GetFocusedDataRow()["덧씌우기_asp_con_m"];

                

                //Dr.ItemArray = advBandedGridView1.GetFocusedDataRow().ItemArray.Clone() as object[];

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
                    //QryList();
                }


                //                DataTable Data = ds.Tables["Table"];
                //                gridControl1.DataSource = Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnLoadPLH_Click(object sender, EventArgs e)
        {
            LoadPLH();


            ///marshal 로 처리 하려 하였으나
            ///원래 PLH파일의 처리가 잘 못되어 있어 Marshal 처리 불가능
            //String FileName;
            //String RLine;
            //CMakeDataTable<_st_typePLH> MakeTable = new CMakeDataTable<_st_typePLH>();

            //XtraOpenFileDialog Opendlg;
            //using (Opendlg = new XtraOpenFileDialog() )
            //{
            //    Opendlg.Filter = "PLH 파일 (*.PLH)|*.PLH|모든파일(*.*)|*.*";
            //    Opendlg.Multiselect = true;

            //    if (Opendlg.ShowDialog() == DialogResult.OK)
            //    {
            //        foreach (string strFileName in Opendlg.FileNames)
            //        {
            //            FileName = Path.GetFileName(strFileName);

            //            //using (StreamReader SR = new StreamReader(strFileName, Encoding.Default, true))
            //            using (StreamReader SR = new StreamReader(strFileName, Encoding.Default, true))
            //            {

            //                CTrans<_st_typePLH> Trans_PLH = new CTrans<_st_typePLH>();
                            
                            

            //                while ((RLine = SR.ReadLine()) != null)
            //                {
            //                    if (RLine.Substring(0, 2) != "NO")
            //                    {
            //                        continue;
            //                    }

            //                    //RLine = RLine.Replace('+', ' ');
            //                    _st_typePLH st_typePLH  = Trans_PLH.ByteToStruct(RLine);
            //                    MakeTable.AddData(st_typePLH);
            //                }
            //            }
            //        }

            //        if (MakeTable.DATATABLE != null)
            //        {
            //            DataTable dt = MakeTable.DATATABLE;
            //        }

                    


            //    }

            //}







        }

        private void btnSavePLH_Click_1(object sender, EventArgs e)
        {
            SavePLH();
        }

        private void btnQryPLH_Click(object sender, EventArgs e)
        {
            QryPLH();
        }

        /// <summary>
        /// 토적표를 조회한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_QryMass_Click(object sender, EventArgs e)
        {
            QryMassCalc();
        }

        private void QryMassCalc()
        {
            if (xtraTabControl2.SelectedTabPage.Text == "토적표")
            {

                CHeader Header = new CHeader(UserInfo.UserID, "A1003A", "XtraPLH", "00000", "");



                DataTable Data = new DataTable("PlhInfo");
                DataColumn colProjectCd = new DataColumn("project_cd", typeof(string));


                Data.Columns.Add(colProjectCd);



                DataRow Dr = Data.NewRow();
                Dr["project_cd"] = ProjectInfo.ProjectCD;

                Data.Rows.Add(Dr);

                //Project 정보를 담은 ...
                CParam Param = new CParam(Data);


                using (DataSet ds = CTransfer.QryData(Header, Param.GetDataSet()))
                {

                    DataTable Dt = ds.Tables["eror_dt"];
                    itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                    itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                    DataTable rcvData = ds.Tables["Table"];
                    gridControl3.DataSource = rcvData;

                }

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// 맨홀정보 입력창을 띄운다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 맨홀정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraManhole  frmProject = new XtraManhole();
            frmProject.UserInfo = this.UserInfo;
            frmProject.ProjectInfo = this.ProjectInfo;

            frmProject.TopMost = true;


          

            frmProject.Show();
        }


        /// <summary>
        /// PLD 를 불러온다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadPLD_Click(object sender, EventArgs e)
        {
            String FileName;
            String RLine;
            CPldData LToR = new CPldData();


            LToR.m_dt.Clear();
            XtraOpenFileDialog Opendlg = new XtraOpenFileDialog();

            Opendlg.Filter = "PLD 파일 (*.PLD)|*.PLD|모든파일(*.*)|*.*";
            Opendlg.Multiselect = true;

            if (Opendlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string strFileName in Opendlg.FileNames)
                {
                    FileName = Path.GetFileName(strFileName);

                    using (StreamReader SR = new StreamReader(strFileName, Encoding.Default))
                    {
                        while ((RLine = SR.ReadLine()) != null)
                        {

                            LToR.LineToRecord(FileName, RLine);
                        }
                    }
                }


                gridControl8.DataSource = LToR.m_dt;                

                adView8.BestFitColumns();

            }
        }



        /// <summary>
        /// PLH 와 PLD 를 EXCEL 로 저장한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            

            
            DataTable plh_dt = (DataTable)gridControl1.DataSource;
            DataTable pld_dt = (DataTable)gridControl8.DataSource;

            COutSheet1 output = new COutSheet1(plh_dt, pld_dt, spreadControl);
            output.LoadData();
            return;

            if (plh_dt == null || plh_dt.Rows.Count <= 0 )
            {
                CUtil.AutoMsg("DATA 확인", "PLH 데이터가 없습니다.", 1);

                return;
            }

            
            if (pld_dt == null || pld_dt.Rows.Count <= 0)
            {
                CUtil.AutoMsg("DATA 확인", "PLD 데이터가 없습니다.", 1);
                return;
            }

            this.spreadControl.BeginUpdate();




            Worksheet sheet = this.spreadControl.Document.Worksheets[0];

            //Line1 head 출력
            //컬럼 Row 추가
            for (int i = 1; i <= 10; i++)
            {
                Cell cell = sheet.Rows[0][i];
                SetCellStyle(cell, true, 9, Color.Aquamarine);//Cell Style 설정

                switch (i)
                {
                    case 1:
                        cell.SetValue("Hscale");
                        break;
                    case 2:
                        cell.SetValue("Vscale");
                        break;

                    case 3:
                        cell.SetValue("CHAIN");
                        break;

                    case 4:
                        cell.SetValue("시작지반");
                        break;

                    case 5:
                        cell.SetValue("TYPE");
                        break;

                    case 6:
                        cell.SetValue("종단분할");
                        break;

                    case 7:
                        cell.SetValue("라인명");
                        break;

                    case 8:
                        cell.SetValue("관종");
                        break;
                    case 9:
                        cell.SetValue("맨홀INV");
                        break;
                    case 10:
                        cell.SetValue("유입라인");
                        break;
                }

                cell = sheet.Rows[1][i];
                //SetCellStyle(cell, true, 9, Color.Aquamarine);//Cell Style 설정

                switch (i)
                {
                    case 1:
                        cell.SetValue("500");
                        break;
                    case 2:
                        cell.SetValue("100");
                        break;

                    case 3:
                        cell.SetValue("20");
                        break;

                    case 4:
                        cell.SetValue("95");
                        break;

                    case 5:
                        cell.SetValue("A");
                        break;

                    case 6:
                        cell.SetValue("268");
                        break;

                    case 7:
                        cell.SetValue("");
                        break;

                    case 8:
                        cell.SetValue("PE 다중벽관");
                        break;
                    case 9:
                        cell.SetValue("0.2");
                        break;
                    case 10:
                        cell.SetValue("유입라인");
                        break;
                }

            }


            //Line1 head 출력
            //컬럼 Row 추가
            for (int i = 1; i <= 12; i++)
            {
                Cell cell = sheet.Rows[2][i];
                SetCellStyle(cell, true, 9, Color.Aquamarine);//Cell Style 설정

                switch (i)
                {
                    case 1:
                        cell.SetValue("누가거리");
                        break;
                    case 2:
                        cell.SetValue("지반고");
                        break;

                    case 3:
                        cell.SetValue("관저고");
                        break;

                    case 4:
                        cell.SetValue("관경");
                        break;

                    case 5:
                        cell.SetValue("맨홀");
                        break;

                    case 6:
                        cell.SetValue("TEXT1");
                        break;

                    case 7:
                        cell.SetValue("TEXT2");
                        break;

                    case 8:
                        cell.SetValue("구간");
                        break;
                    case 9:
                        cell.SetValue("구배");
                        break;
                    case 10:
                        cell.SetValue("INV");
                        break;

                    case 11:
                        cell.SetValue("SIZE");
                        break;

                    case 12:
                        cell.SetValue("라인명");
                        break;

                }
            }

            for (int i = 0; i <= 12; i++)
            {
                for (int j = 0; j < plh_dt.Rows.Count; j++)
                {
                    Cell cell = sheet.Rows[3+j][i];
                    //SetCellStyle(cell, true, 9, Color.Aquamarine);//Cell Style 설정



                    switch (i)
                    {

                        case 1:
                            cell.SetValue(plh_dt.Rows[j]["dist2"]); //누가거리
                            break;
                        case 2:
                            cell.SetValue(plh_dt.Rows[j]["gh"]); //지반고
                            break;

                        case 3:
                            cell.SetValue(plh_dt.Rows[j]["inv"]); //관저고
                            break;

                        case 4:
                            cell.SetValue(plh_dt.Rows[j]["dia"]); //관경
                            break;

                        case 5:
                            if (plh_dt.Rows[j]["manhole_yn"].ToString() == "Y")
                            {
                                cell.SetValue(plh_dt.Rows[i]["linename"]);
                            }
                            
                            break;

                        case 6:
                            cell.SetValue("TEXT1");
                            break;

                        case 7:
                            cell.SetValue("TEXT2");
                            break;

                        case 8:
                            cell.SetValue("구간");
                            break;
                        case 9:
                            cell.SetValue(plh_dt.Rows[j]["slope"]); //구배                            
                            break;
                        case 10:
                            cell.SetValue("inv");
                            break;

                        case 11:
                            cell.SetValue("SIZE");
                            break;

                        case 12:
                            cell.SetValue("라인명");
                            break;

                    }
                }
            
            }

            this.spreadControl.EndUpdate();
            
        }

        //Cell Style 설정
        private void SetCellStyle(Cell cell, bool isBold, int fontSize, Color fillColor)
        {
            cell.Font.Bold = isBold;
            cell.Font.Size = fontSize;
            cell.FillColor = fillColor;
            cell.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }



        /// <summary>
        /// PIPE TOOLS 데이터를 불러온다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadPipeTool_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog Opendlg = new XtraOpenFileDialog();

            Opendlg.Filter = "EXCEL 파일 (*.xlsx)|*.xlsx|모든파일(*.*)|*.*";
            

            if (Opendlg.ShowDialog() == DialogResult.OK)
            {
                string filename = Opendlg.FileName;

                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    ///EXCEL DATA를 Load 한다.
                    sheetPipeTools.LoadDocument(stream, DocumentFormat.Xlsx);
                }

                m_strFileName = filename;

            }

        }

        private void btnSavePipeTool_Click(object sender, EventArgs e)
        {

            if (m_strFileName.Trim() == "")
            {
                XtraMessageBox.Show("PIPE TOOLS 파일이 없습니다.");
                return;
            }

            CPipetools pipetoolsData = new CPipetools(ProjectInfo.ProjectCD, Path.GetFileNameWithoutExtension(m_strFileName), sheetPipeTools);
            pipetoolsData.LoadDataTools();



            
            try
            {
                pipetoolsData.m_dt_line.TableName = "pipetool";
                pipetoolsData.m_dt_지장물.TableName = "pipetool_g";
                pipetoolsData.m_dt_포장.TableName = "pipetool_pavement";

            }
            catch (Exception ex)
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = ex.Message;

                throw;
            }



            CHeader Header = new CHeader(UserInfo.UserID, "A1301A", "XtraPlH", "00000", "");




            //Project 정보를 담은 ...
            CParam Param = new CParam(pipetoolsData.m_dt_line);
            Param.AddDataTable(pipetoolsData.m_dt_지장물);
            Param.AddDataTable(pipetoolsData.m_dt_포장);
            

            using (DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet()))
            {

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();


                if (Dt.Rows[0]["err_cd"].ToString() == "00000")
                {
                    QryMaxerInput();
                }
            }

        }


        //변환된 Maxer Input Data를 구한다.
        private void QryMaxerInput()
        {
            CHeader Header = new CHeader(UserInfo.UserID, "A1301B", "XtraPLH", "00000", "");


            DataTable Data = new DataTable("project_info");
            DataColumn colProjectCd = new DataColumn("project_cd", typeof(string));


            Data.Columns.Add(colProjectCd);



            DataRow Dr = Data.NewRow();
            Dr["project_cd"] = ProjectInfo.ProjectCD;

            Data.Rows.Add(Dr);

            //Project 정보를 담은 ...
            CParam Param = new CParam(Data);


            using (DataSet ds = CTransfer.QryData(Header, Param.GetDataSet()))
            {

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                DataTable rcvData = ds.Tables["Table"];
                gridMaxer.DataSource = rcvData;

            }

        }

        private void BtnQryManhole_Click(object sender, EventArgs e)
        {
            CHeader Header = new CHeader(UserInfo.UserID, "A1002A", "XtraPLH", "00000", "");



            DataTable Data = new DataTable("PlhInfo");
            DataColumn colProjectCd = new DataColumn("project_cd", typeof(string));


            Data.Columns.Add(colProjectCd);



            DataRow Dr = Data.NewRow();
            Dr["project_cd"] = ProjectInfo.ProjectCD;

            Data.Rows.Add(Dr);

            //Project 정보를 담은 ...
            CParam Param = new CParam(Data);


            using (DataSet ds = CTransfer.QryData(Header, Param.GetDataSet()))
            {

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                DataTable rcvData = ds.Tables["Table"];
                gridControl1.DataSource = rcvData;

            }
        }
    }
}
