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
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
    public string NO;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12-1)]
    public string plus;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6+1)]
    public string dist;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string dist2;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
    public string gh;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
    public string INV;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
    public string LINENAME;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
    public string DIA;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
    public string BR;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
    public string type;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
    public string T1;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string SLOPE;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string Bcut;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string Hcut;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string manwork;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string sand;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string concA;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string concB;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string humanity;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string concrete;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string asphalt1;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string asphalt2;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string complay;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string mixlay;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string mixlay1;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string mixlay2;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area1;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area2; //관주위

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area3;  //관상단

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area4;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area5;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area6;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area7;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area8;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area9;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area10;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string area11;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string T2;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string T3;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string T4;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string B;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string H;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string DIR;

}
 