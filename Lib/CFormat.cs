﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
   
    class CFormat : System.Attribute
    {
        private string _value;

        public CFormat(string value)
        {
            _value = value;
        }

        public string value
        {
            get { return _value; }
        }
    }

}
