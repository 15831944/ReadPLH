using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Screen
{
    public partial class CfrmExcel : Form
    {
        public CfrmExcel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            textBox2.Text = "";
            using (OpenFileDialog OpenDlg = new OpenFileDialog())
            {
                OpenDlg.Filter = " EXCEL 파일 (*.xls)|*.xls|EXCEL 파일 (*.xlsx)|*.xlsx|모든파일(*.*)|*.*";

                if (OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    gridControl2.DataSource = OpenFile(OpenDlg.FileName);
                }
            }

        }


        /// <summary>
        /// EXCEL 파일을 DataTable에 넣는다.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static object OpenFile(string fileName)
        {
            string fullFileName = fileName;

            //HDR은 첫줄이 HEADER라는 말
            //IMEX는 중간에 다른 타입이 나오더라도 표기해주는 옵션 
            //0이 기본값인데 처음에 몇줄과 다른 형식이 나오면 처리못함
            ///var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;HDR=YES;IMEX=1", fullFileName);
            //var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;HDR=YES;IMEX=2", fullFileName);
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;Imex=7;HDR=Yes;\"", fullFileName);

            var adapter = new OleDbDataAdapter("select * from [Sheet$]", connectionString);
            var ds = new DataSet();
            string tableName = "excelData";
            adapter.Fill(ds, tableName);
            DataTable data = ds.Tables[tableName];
            return data;
        }
    }
}
