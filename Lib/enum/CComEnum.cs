using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
    class CComEnum
    {
        public enum enumProject
        {
            [CGetName("ProjectName")]
            ProjectName,
            [CGetName("ProjectPath")]
            ProjectPath
        }

        public enum enumPrjoectCreate
        {
            [CGetName("SECTOR")]
            [CGetLength(50)]
            [CFormat("{0,-50}")]
            SECTOR,
            [CGetName("asphalt1")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asphalt1,
            [CGetName("asphalt2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asphalt2,
            [CGetName("complay")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            complay,
            [CGetName("mixlay")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            mixlay,
            [CGetName("delete")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            delete
        }
    }
}
