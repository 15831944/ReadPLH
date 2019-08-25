using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
    class CMakeDataTable<T> where T : new()
    {
        private T TR;
        private DataTable m_DT;
        public CMakeDataTable()
        {
            TR = new T();
            MakeDataTable();
        }

        public DataTable DATATABLE { get => m_DT; set => m_DT = value; }


        public void MakeDataTable()
        {
            m_DT = new DataTable();
            FieldInfo[] info = TR.GetType().GetFields();

            foreach (var item in info)
            {

                //m_DT.TableName = TR.ToString();
                m_DT.Columns.Add(item.Name, item.FieldType);

                Console.WriteLine("name is " + item.Name);
                //Console.WriteLine("Type is " + item.PropertyType.ToString());
                //  object obj = item.GetValue(TR, null);
                //  Console.WriteLine("Value is" + obj.ToString());

                // Console.WriteLine("Value is " + item.GetValue(item).ToString());
            }

        }

        public void AddData(T obj)
        {
            FieldInfo[] info = obj.GetType().GetFields();


            DataRow DR = m_DT.NewRow();


            foreach (var item in info)
            {
           
                object val = item.GetValue(obj);

                DR[item.Name] = val;

                //if (item.Name == "NO")
                //{
                //    DR[item.Name] = val.ToString().Trim().Replace(' ', '0');
                //}
                //else
                //{
                //    DR[item.Name] = val;
                //}



                //Console.WriteLine("name is " + item.Name);
                //Console.WriteLine("Type is " + item.PropertyType.ToString());
                //  object obj = item.GetValue(TR, null);
                //  Console.WriteLine("Value is" + obj.ToString());

                // Console.WriteLine("Value is " + item.GetValue(item).ToString());
            }

            m_DT.Rows.Add(DR);
        }



    }
}
