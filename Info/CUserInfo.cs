using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Info
{
    public class CUserInfo
    {

        string m_strUserID;
        string m_strUserName;

        public CUserInfo()
        {

        }

        public string UserID{ get => m_strUserID; set => m_strUserID = value; }
        public string UserName { get => m_strUserName; set => m_strUserName = value; }

    }
}
