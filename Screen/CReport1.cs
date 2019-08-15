using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Lib;

namespace WindowsFormsApp1.Screen
{



    public partial class CReport1 : DevExpress.XtraEditors.XtraForm
    {

        DataTable m_dt;

        public CReport1()
        {
            InitializeComponent();
        }

        public void SetData(DataTable dt)
        {
            m_dt = new DataTable();

            CReport1Dat Data = new CReport1Dat();
            m_dt = Data.SetData(dt);

            gridControl1.DataSource = m_dt;

        }


        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
