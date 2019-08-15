using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Comm
{
    public class Cnpgsql
    {

        NpgsqlConnection m_Con;
        NpgsqlDataAdapter m_Adt;

        string strErrCd;
        string strErrMsg;

        string exceptionMsg;

        public Cnpgsql()
        {
            m_Con = new NpgsqlConnection("server=localhost;port=5432;User id=postgres;password=postgres;Database=Tops");
            m_Adt = new NpgsqlDataAdapter();

        }



        public void SetSelect(NpgsqlCommand select_command)
        {
            select_command.Connection = m_Con;
            m_Adt.SelectCommand = select_command;

        }


        public void SetInsert(NpgsqlCommand insert_command)
        {
            insert_command.Connection = m_Con;
            m_Adt.InsertCommand = insert_command;

        }

        public void SetUpdate(NpgsqlCommand update_command)
        {
            update_command.Connection = m_Con;
            m_Adt.UpdateCommand = update_command;
        }

        public void SetDelete(NpgsqlCommand delete_command)
        {
            delete_command.Connection = m_Con;
            m_Adt.DeleteCommand = delete_command;
        }


        public int Insert()
        {
            int nRet;


            try
            {

                m_Con.Open();

                using (NpgsqlTransaction nTran = m_Con.BeginTransaction())
                {
                    nRet = m_Adt.InsertCommand.ExecuteNonQuery();

                    nTran.Commit();
                }


                return nRet;
            }
            catch (Exception ex)
            {
                exceptionMsg = ex.Message;

                return -1;
                throw;
            }
            finally
            {
                m_Con.Close();
            }

        }

        public DataTable Select()
        {
            int nRet;

            try
            {
                m_Con.Open();

                DataTable dt = new DataTable();

                nRet = m_Adt.Fill(dt);

                
                if (nRet > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                exceptionMsg = ex.Message;
                
                throw;
            }
            finally
            {
                m_Con.Close();
            }
        }


    }
}
