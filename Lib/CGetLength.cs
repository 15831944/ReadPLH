using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
    public class CGetLength : System.Attribute
    {
        private int _value;

        public CGetLength(int value)
        {
            _value = value;
        }

        public int value
        {
            get { return _value; }
        }
    }
}
