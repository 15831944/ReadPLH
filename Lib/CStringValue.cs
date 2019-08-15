using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{

    public class CStringValue: System.Attribute
    {
        private string _value;

        public CStringValue(string value)
        {
            _value = value;
        }

        public string value
        {
            get { return _value; }
        }
    }

}
