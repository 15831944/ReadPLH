using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.popup;
using WindowsFormsApp1.Screen;

namespace WindowsFormsApp1
{
    public partial class CReadPLH : DevExpress.XtraEditors.XtraForm
    {
        public CReadPLH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PLH Data 관리 Class
        /// </summary>
        

        /// <summary>
        /// CellValue가 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            GridView view = sender as GridView;
            DataRow Dr;
            Dr = view.GetDataRow(e.RowHandle);


            if (e.Column.FieldName.Trim() == "BaseAngle")
            {
                //PLH TAB의 기초각을 편집할 경우 수식을 모래부설에 적용한다.
                CPLH LToR = new CPLH();

                Dr["sand"] = LToR.CalcBaseAngle(Dr).ToString($"F{3}");
            }
            else
            {
                ReCalcArea(Dr);

            }
        }

        /*
         * 
         *            m_dt.Columns.Add(new DataColumn("key", typeof(Int64)));
            m_dt.Columns.Add(new DataColumn("FileName", typeof(String)));
            m_dt.Columns.Add(new DataColumn("NO.", typeof(String)));
            m_dt.Columns.Add(new DataColumn("ASP+CON", typeof(bool)));
            m_dt.Columns.Add(new DataColumn("+", typeof(String)));
            m_dt.Columns.Add(new DataColumn("dist", typeof(String)));
            m_dt.Columns.Add(new DataColumn("dist2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("gh", typeof(String)));
            m_dt.Columns.Add(new DataColumn("INV", typeof(String)));
            m_dt.Columns.Add(new DataColumn("LINENAME", typeof(String)));
            m_dt.Columns.Add(new DataColumn("DIA", typeof(String)));
            m_dt.Columns.Add(new DataColumn("BR", typeof(String)));
            m_dt.Columns.Add(new DataColumn("type", typeof(String)));
            m_dt.Columns.Add(new DataColumn("T1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("SLOPE", typeof(String)));
            m_dt.Columns.Add(new DataColumn("Bcut", typeof(String)));
            m_dt.Columns.Add(new DataColumn("Hcut", typeof(String)));
            m_dt.Columns.Add(new DataColumn("manwork", typeof(String)));
            m_dt.Columns.Add(new DataColumn("sand", typeof(String)));
            m_dt.Columns.Add(new DataColumn("concA", typeof(String)));
            m_dt.Columns.Add(new DataColumn("concB", typeof(String)));
            m_dt.Columns.Add(new DataColumn("humanity", typeof(String)));
            m_dt.Columns.Add(new DataColumn("concrete", typeof(String)));
            m_dt.Columns.Add(new DataColumn("asphalt1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("asphalt2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("complay", typeof(String)));
            m_dt.Columns.Add(new DataColumn("mixlay", typeof(String)));
            m_dt.Columns.Add(new DataColumn("mixlay1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("mixlay2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area1", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area3", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area4", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area5", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area6", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area7", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area8", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area9", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area10", typeof(String)));
            m_dt.Columns.Add(new DataColumn("area11", typeof(String)));
            m_dt.Columns.Add(new DataColumn("T2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("T3", typeof(String)));
            m_dt.Columns.Add(new DataColumn("T4", typeof(String)));
            m_dt.Columns.Add(new DataColumn("B", typeof(String)));
            m_dt.Columns.Add(new DataColumn("H", typeof(String)));
            m_dt.Columns.Add(new DataColumn("DIR", typeof(String)));
            m_dt.Columns.Add(new DataColumn("B2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("INV2", typeof(String)));
            m_dt.Columns.Add(new DataColumn("DIA2", typeof(String)));
         * 
         */

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

            double AA = ToDouble(Dr, "mixlay");
            double AS = ToDouble(Dr, "H");
            double AR = ToDouble(Dr, "B");
            double O  = ToDouble(Dr, "SLOPE");
            double V  = ToDouble(Dr, "humanity");
            double W  = ToDouble(Dr, "concrete"); 
            double X  = ToDouble(Dr, "asphalt1");             
            double Y  = ToDouble(Dr, "asphalt2"); 
            double Z  = ToDouble(Dr, "complay");
            double K  = ToDouble(Dr, "DIA"); 
            double P  = ToDouble(Dr, "Bcut");
            double Q  = ToDouble(Dr, "Hcut");
            double R  = ToDouble(Dr, "manwork");
            double S  = ToDouble(Dr, "sand");

            area9 = Math.Round(((AR + (AR - (((Z + AA) * P) * 2))) / 2 * AA), 3);
            area8 = Math.Round(((AR + (AR - ((Z * O) * 2))) / 2 * Z), 3);
            area7 = Math.Round(AR, 3);
            area6 = Math.Round(AR * (W + X + Y), 3);
            area5 = Math.Round(((((K + P * 2) + ((K + P * 2) + (S * O * 2))) / 2 * S) - (Math.Pow(K, 2) * 3.14 / 4 * 0.5)), 3);
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advBandedGridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
            
        }
        


        /// <summary>
        /// PLH 그리드의 기초각 설정을 일괄 처리한다. 
        /// 선택된 ROW에 일괄로 변경 처리한다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBaseAngle_Click(object sender, EventArgs e)
        {

            SetColData("BaseAngle", spinBaseAngle.Value.ToString());


        }

        /// <summary>
        /// 보도구간을 설정한다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHumanity_Click(object sender, EventArgs e)
        {
            SetColData("humanity", spinHumanity.Value.ToString());            
        }


        /// <summary>
        /// 선택된 그리드의 특정 컬럼값을 변경한다. 
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="value"></param>
        private void SetColData(string FieldName, string value)
        {            
            DataRow Dr;


            for (int i = 0; i < adView1.RowCount - 1; i++)
            {
                Dr = adView1.GetDataRow(i);

                if ((Boolean)adView1.GetRowCellValue(i, "check") == true)
                {
                    adView1.SetRowCellValue(i, FieldName, value);
                }
            }

        }

        /// <summary>
        /// 콘크리트를 설정한다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConcrete_Click(object sender, EventArgs e)
        {
            SetColData("concrete", spinConcrete.Value.ToString());
        }

        /// <summary>
        /// 표층을 설정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsphalt1_Click(object sender, EventArgs e)
        {
            SetColData("asphalt1", spinAsphalt1.Value.ToString());
        }

        /// <summary>
        /// 기층을 설정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SetColData("asphalt2", spinAsphalt2.Value.ToString());
        }

        /// <summary>
        /// 보조기층을 설정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplay_Click(object sender, EventArgs e)
        {
            SetColData("complay", spinComplay.Value.ToString());
        }


        /// <summary>
        /// 혼합기층을 설정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            SetColData("mixlay", spinMixlay.Value.ToString());            
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow Dr;


            switch (e.ClickedItem.Tag )
            {
                case "1":
                    //전체선택
                    adView1.SelectAll();

                    foreach (var item in adView1.GetSelectedRows())
                    {
                        Dr = adView1.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        adView1.SetRowCellValue(item, "check", true);
                    }

                    break;
                case "2":
                    //전체해제
                    //전체 해제

                    adView1.SelectAll();

                    foreach (var item in adView1.GetSelectedRows())
                    {
                        Dr = adView1.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        adView1.SetRowCellValue(item, "check", false);
                    }

                    //전체 선택 해제
                    adView1.ClearSelection();
                    break;
                case "3":                    
                    //부분선택

                    foreach (var item in adView1.GetSelectedRows())
                    {
                        Dr = adView1.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        adView1.SetRowCellValue(item, "check", true);
                    }
                    break;
                case "4":
                    //부분해제

                    // 부분해제

                    foreach (var item in adView1.GetSelectedRows())
                    {
                        Dr = adView1.GetDataRow(item);

                        //Dr["BaseAngle"] = spinBaseAngle.Value.ToString();
                        adView1.SetRowCellValue(item, "check", false);
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 그리드를 EXCEL 파일로 저장한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "EXCEL 파일 (*.xlsx)|*.xls|모든파일(*.*)|*.*";
            saveFileDialog1.FileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + ".xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(saveFileDialog1.FileName + ".xlsx");

                MessageBox.Show(saveFileDialog1.FileName + "로 저장되었습니다. ");
            }

        }

        /// <summary>
        /// PLH를 Grid로 불러온다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            String FileName;
            String RLine;
            CPLH LToR = new CPLH();


            LToR.m_dt.Clear();
            gridControl1.DataSource = LToR.m_dt;

            openFileDialog1.Filter = "PLH 파일 (*.PLH)|*.PLH|모든파일(*.*)|*.*";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string strFileName in openFileDialog1.FileNames)
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
        /// 그리드를 PLH 파일로 저장한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            CPLH LToR = new CPLH(gridControl1.DataSource as DataTable);
            //LToR.RecordToLine();
        }

        /// <summary>
        /// XML을 그리드로 불러온다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable Dt = CUtil.LoadXmlToPLH();
        }


        /// <summary>
        /// 줄을 복사한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DataTable Dt = (DataTable)gridControl1.DataSource;


            DataRow Dr = CUtil.CopyDataRow(Dt, adView1.GetFocusedDataRow());

            long nCurKey = 0;

            nCurKey = Convert.ToInt64(Dr["key"].ToString());

            foreach (DataRow item in Dt.Rows)
            {
                long nKey = Convert.ToInt64(item["key"].ToString());

                if ( nKey >= nCurKey)
                {
                    item["key"] = ++nKey;
                }
            }                        
            Dt.Rows.InsertAt(Dr, adView1.GetFocusedDataSourceRowIndex());            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 그리드 컬럼의 포맷을 처리한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            CPLH plh = new CPLH();
            

            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == CUtil.GetName(CPLH.enumPLH.dist) && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                double dist = Convert.ToDouble(e.Value);

                e.DisplayText = string.Format("{0,4:#0.00}", dist);


            }
        }

        private void adView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            ColumnView view = sender as ColumnView;

           // e.Column.FieldName == 



            //if (e.Column.FieldName == "dist" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //{
            //    //e.DisplayText = string.Format("{0,4:0.00}", dist);
            //}
        }

        private void adView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aaa = string.Format(CUtil.GetFormat(CPLH.enumPLH.area1), 0.03);


            string bbb = aaa;

        }

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CReadPLH_Load(object sender, EventArgs e)
        {
            CDataInfo1 DataInfo1 = new CDataInfo1();
                       
            repositoryItemGridLookUpEdit1.DataSource = DataInfo1.GetDataTable();
            repositoryItemGridLookUpEdit1.ValueMember = "value";
            repositoryItemGridLookUpEdit1.DisplayMember = "name";
        }

        private void repositoryItemGridLookUpEdit1_Click(object sender, EventArgs e)
        {
        }

        private void repositoryItemGridLookUpEdit1View_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void repositoryItemGridLookUpEdit1View_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }

        private void repositoryItemGridLookUpEdit1View_Click(object sender, EventArgs e)
        {
            
            GridView view = sender as GridView;
            if (view != null)
            {
                DataRow dr = view.GetFocusedDataRow();

                string sss = string.Format("seq[{0}] value[{1}] name[{2}]", dr["seq"].ToString(), dr["name"].ToString(), dr["value"].ToString());

                //MessageBox.Show(sss);

            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = CUtil.LoadXmlToPLH();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SetSector();
        }

        private void adView2_DoubleClick(object sender, EventArgs e)
        {
            SetSector();
        }

        /// <summary>
        /// 구간정보를 적용한다.
        /// </summary>
        private void SetSector()
        {
            DataRow Dr = adView2.GetFocusedDataRow();
            SetColData(CUtil.GetName(CDataInfo1.enumInfo1.asphalt1), Dr[CUtil.GetName(CDataInfo1.enumInfo1.asphalt1)].ToString());
            SetColData(CUtil.GetName(CDataInfo1.enumInfo1.asphalt2), Dr[CUtil.GetName(CDataInfo1.enumInfo1.asphalt2)].ToString());
            SetColData(CUtil.GetName(CDataInfo1.enumInfo1.complay), Dr[CUtil.GetName(CDataInfo1.enumInfo1.complay)].ToString());
            SetColData(CUtil.GetName(CDataInfo1.enumInfo1.mixlay), Dr[CUtil.GetName(CDataInfo1.enumInfo1.mixlay)].ToString());

        }

        /// <summary>
        /// 토적표를 불러온다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            CReport1 report1 = new CReport1();

            DataTable dt = gridControl1.DataSource as DataTable;

//            DataTable dt = (DataTable)gridControl1.DataSource;

            if (dt == null)
            {
                MessageBox.Show("PLH 데이터가 없습니다.");
                return;
            }

            report1.SetData(dt);

            report1.Show();
        }
    }
}
