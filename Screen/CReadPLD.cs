using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Screen
{
    public partial class CReadPLD : DevExpress.XtraEditors.XtraForm
    {
        public CReadPLD()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String FileName;
            String RLine;
            CPLD LToR = new CPLD();


            LToR.m_dt.Clear();
            gridControl3.DataSource = LToR.m_dt;

            int nIndex = 0;
            int nRecLine = 0;

            using (OpenFileDialog openDlg = new OpenFileDialog())
            {

                openDlg.Filter = "PLD 파일 (*.PLD)|*.PLD|모든파일(*.*)|*.*";
                openDlg.Multiselect = true;

                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string strFileName in openDlg.FileNames)
                    {
                        FileName = Path.GetFileName(strFileName);

                        using (StreamReader SR = new StreamReader(strFileName, Encoding.Default))
                        {
                            nIndex = 0;
                            while ((RLine = SR.ReadLine()) != null)
                            {
                                nIndex++;

                                if (nIndex <= 2)
                                {
                                    continue;
                                }

                                if (RLine.Substring(0, 3) == "-99")
                                {
                                    break;
                                }

                                LToR.LineToRecord(FileName, RLine);
                            }
                        }
                    }

                    gridControl3.DataSource = LToR.m_dt;
                    //MessageBox.Show(LToR.m_dt.Rows.Count.ToString());

                }
            }
        }
    }
}
