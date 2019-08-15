using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Info
{
    public class CProjectInfo
    {
        string m_ProjectCD = "";
        string m_ProjectNM = "";

        public CProjectInfo()
        {

        }

        public string ProjectNM { get => m_ProjectNM; set => m_ProjectNM = value; }
        public string ProjectCD { get => m_ProjectCD; set => m_ProjectCD = value; }
    }
}
