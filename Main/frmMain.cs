using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.popup;
using WindowsFormsApp1.Screen;

namespace WindowsFormsApp1.Main
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        

        /// <summary>
        /// PLH 처리폼을 부른다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //CReadPLH frmPLH = new CReadPLH();
            //frmPLH.MdiParent = this;
            //frmPLH.Show();

            XtraPLH frmPLH = new XtraPLH();
            frmPLH.MdiParent = this;
            frmPLH.Show();
        }

        /// <summary>
        /// PLD 처리 폼을 부른다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CReadPLD frmPLD = new CReadPLD();
            frmPLD.MdiParent = this;
            frmPLD.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CfrmExcel frmExcel = new CfrmExcel();
            frmExcel.MdiParent = this;
            frmExcel.Show();
        }

        /// <summary>
        /// 구간정보 설정 Dialog를 Load한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupDataInfo1 frmDataInfo = new popupDataInfo1();
            frmDataInfo.ShowDialog(this);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
    }
}
