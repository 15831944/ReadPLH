using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Info;

namespace WindowsFormsApp1.Comm
{
    class CHeader
    {

        private string strUserId;
        private string strTrNo;
        private string strScrnNo;
        private string strErrCd;
        private string strErrMsg;

        private DataTable m_dt;

        public string StrUserId { get => strUserId; set => strUserId = value; }
        public string StrTrNo { get => strTrNo; set => strTrNo = value; }
        public string StrScrnNo { get => strScrnNo; set => strScrnNo = value; }
        public string StrErrCd { get => strErrCd; set => strErrCd = value; }
        public string StrErrMsg { get => strErrMsg; set => strErrMsg = value; }


        public CHeader()
        {


        }

        public CHeader(String UserId, String TrNo, String ScrnNo, String ErrCd, String ErrMsg)
        {
            StrUserId = UserId;
            StrTrNo = TrNo;
            StrScrnNo = ScrnNo;
            StrErrCd = ErrCd;
            StrErrMsg = ErrMsg;
        }

        public CHeader(CUserInfo UserInfo, String TrNo, String ScrnNo, String ErrCd, String ErrMsg)
        {
            StrUserId = UserInfo.UserID;
            StrTrNo = TrNo;
            StrScrnNo = ScrnNo;
            StrErrCd = ErrCd;
            StrErrMsg = ErrMsg;
        }


        public void PrintHeader()
        {

        }

        public string SerializeTo()
        {
            DataSet ds = new DataSet();
            DataTable m_dt = new DataTable();

            m_dt.Columns.Add(new DataColumn("userid", typeof(String)));
            m_dt.Columns.Add(new DataColumn("trno", typeof(String)));
            m_dt.Columns.Add(new DataColumn("scrnno", typeof(String)));
            m_dt.Columns.Add(new DataColumn("errcd", typeof(String)));
            m_dt.Columns.Add(new DataColumn("errmsg", typeof(String)));

            DataRow dr = m_dt.NewRow();
            dr["userid"] = StrUserId;
            dr["trno"] = StrTrNo;
            dr["scrnno"] = StrScrnNo;
            dr["errcd"] = StrErrCd;
            dr["errmsg"] = StrErrMsg;

            m_dt.Rows.Add(dr);

            CCompress cp = new CCompress();
            return cp.CompressDataFromDataTable(m_dt);
        }

        public void SerializeFrom(String InData)
        {
            CCompress cp = new CCompress();
            m_dt = new DataTable();
            m_dt = cp.DeCompressDataToDataTable(InData);

            StrUserId = m_dt.Rows[0]["userid"].ToString();
            StrTrNo = m_dt.Rows[0]["trno"].ToString();
            StrScrnNo = m_dt.Rows[0]["scrnno"].ToString();
            StrErrCd = m_dt.Rows[0]["errcd"].ToString();
            StrErrMsg = m_dt.Rows[0]["errmsg"].ToString();

        }

    }
}
