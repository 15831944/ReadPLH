using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Comm
{
    class CTransfer
    {

        public static DataSet QryData(CHeader header)
        {

            wcfHighTop.Service1Client HighTops = new wcfHighTop.Service1Client();

            CCompress cp = new CCompress();
            return cp.DeCompressDataToDataSet(HighTops.ProcByNoneParam(header.SerializeTo()));
        }

        public static DataSet QryData(CHeader header, DataSet Param)
        {

            try
            {
                wcfHighTop.Service1Client HighTops = new wcfHighTop.Service1Client();

                CCompress cp = new CCompress();

                return cp.DeCompressDataToDataSet(HighTops.ProcByParam(header.SerializeTo(), cp.CompressDataFromDataSet(Param)));
            }
            catch (Exception err)
            { return GetErrDs(err); 

            }

        }

        public static DataSet InsertData(CHeader header, DataSet Param)
        {

            try
            {
                wcfHighTop.Service1Client HighTops = new wcfHighTop.Service1Client();

                CCompress cp = new CCompress();

                return cp.DeCompressDataToDataSet(HighTops.ProcInsert(header.SerializeTo(), cp.CompressDataFromDataSet(Param)));

            }
            catch (Exception err)
            {

                return GetErrDs(err);
            }


            //CHeader r_header = new CHeader();

            //r_header.SerializeFrom(sHeader);

            //return r_header;
        }

        public static CHeader UpdateData(CHeader header, DataSet Param)
        {
            wcfHighTop.Service1Client HighTops = new wcfHighTop.Service1Client();

            CCompress cp = new CCompress();

            String sHeader = HighTops.ProcUpdate(header.SerializeTo(), cp.CompressDataFromDataSet(Param));

            CHeader r_header = new CHeader();

            r_header.SerializeFrom(sHeader);

            return r_header;
        }

        public static DataSet deleteData(CHeader header, DataSet Param)
        {
            try
            {
                wcfHighTop.Service1Client HighTops = new wcfHighTop.Service1Client();

                CCompress cp = new CCompress();

                return cp.DeCompressDataToDataSet(HighTops.ProcDelete(header.SerializeTo(), cp.CompressDataFromDataSet(Param)));
            }
            catch (Exception err)
            {

                return GetErrDs(err);
            }
        }


        public static DataSet GetErrDs(Exception err)
        {
            DataSet ds = new DataSet();
            DataTable err_dt = new DataTable();
            err_dt.TableName = "eror_dt";
            err_dt.Columns.Add(new DataColumn("err_cd", typeof(String)));
            err_dt.Columns.Add(new DataColumn("err_msg", typeof(String)));



            DataRow dr = err_dt.NewRow();

            dr["err_cd"] = "ERROR";
            dr["err_msg"] = err.Message.ToString();

            err_dt.Rows.Add(dr);

            ds.Tables.Add(err_dt);

            return ds;
        }
    }
}
