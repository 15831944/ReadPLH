using System;
using System.IO;
//using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;


public class CTrans<T> where T: struct
{
    private T m_tr;
    public CTrans()
    {
       // m_tr = TR;        
    }

    public T ByteToStruct(string streamData)
    {

        //입력받은 string을 Byte 배열로 변환 
        byte[] byteData;

        int type_size = Marshal.SizeOf(typeof(T));
        byteData = Encoding.UTF8.GetBytes(streamData.ToString().PadRight(type_size));

        Type objtype;
        objtype = typeof(T);

        int size = Marshal.SizeOf(objtype);

            if (size > byteData.Length)
            {
                
                return m_tr;
            }

            IntPtr buffer = Marshal.AllocHGlobal(size);
            Marshal.Copy(byteData, 0, buffer, size);

            object obj = Marshal.PtrToStructure(buffer, objtype);
            Marshal.FreeHGlobal(buffer);

            return (T)obj;
    }


    
}