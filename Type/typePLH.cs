using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _st_typePLH
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
    public string sId;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
    public string sExchange_Acronym;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
    public string sFiller1;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
    public string sExchange_Code;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 123)]
    public string sFiller2;

}
