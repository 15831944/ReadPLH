using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Comm
{
    class CParam
    {

        protected DataSet m_ds;
        protected DataTable m_dt;

        //테이블 명과 테이블로 구성된 Map 생성
        protected Dictionary<string, DataTable> Table_map =  new Dictionary<string, DataTable>();


        //DataSet을 생성한다.
        public CParam()
        {
            m_ds = new DataSet();
        }


        // 이름을 가진 데이터 테이블을 생성한다.
        public CParam(string strTableName)
        {
            m_ds = new DataSet();
            m_dt = new DataTable();
            m_dt.TableName = strTableName;

            m_dt.TableName = strTableName;
            Table_map.Add(strTableName, m_dt);
        }

        /// <summary>
        /// 요걸 쓰려면 DataTable의 이름을 미리 지정한채 넘겨야 한다.
        /// </summary>
        /// <param name="data"></param>
        public CParam(DataTable data)
        {
            m_ds = new DataSet();

            Table_map.Add(data.TableName, data);
        }

        public void AddDataTable(DataTable data)
        {
            Table_map.Add(data.TableName, data);

        }

        public DataSet GetDataSet()
        {

            m_ds.Clear();

            foreach (var item in Table_map)
            {
                DataTable tmpData = new DataTable();
                tmpData = item.Value.Copy();
                //m_ds.Tables.Add(item.Value);
                m_ds.Tables.Add(tmpData);
            }            

            return m_ds;
        }

    }
}
