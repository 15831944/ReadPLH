using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Comm
{
    class CCompress
    {


        /// <summary>
        /// 압축된 내용을 DataTable 형식으로 변환한다. 
        /// </summary>
        /// <param name="str"> 압축된 문자열 형식 </param>
        /// <returns>DataTable </returns>
        public DataTable DeCompressDataToDataTable(string InData)
        {
            byte[] str = Convert.FromBase64String(InData);

            DataTable dt = new DataTable();

            MemoryStream objStream = new MemoryStream(str);
            objStream.Seek(0, 0);
            DeflateStream objZS = new DeflateStream(objStream, CompressionMode.Decompress, true);

            byte[] buffer = ReadFullStream(objZS, str.Length);
            objZS.Flush();
            objZS.Close();
            MemoryStream outStream = new MemoryStream(buffer);
            outStream.Seek(0, 0);
            dt.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();

            return (DataTable)bf.Deserialize(outStream, null);
        }

        public DataSet DeCompressDataToDataSet(string InData)
        {
            byte[] str = Convert.FromBase64String(InData);

            DataSet ds = new DataSet();

            MemoryStream objStream = new MemoryStream(str);
            objStream.Seek(0, 0);
            DeflateStream objZS = new DeflateStream(objStream, CompressionMode.Decompress, true);

            byte[] buffer = ReadFullStream(objZS, str.Length);
            objZS.Flush();
            objZS.Close();
            MemoryStream outStream = new MemoryStream(buffer);
            outStream.Seek(0, 0);
            ds.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();

            return (DataSet)bf.Deserialize(outStream, null);
        }

        protected byte[] ReadFullStream(Stream stream, int byteSize)
        {
            byte[] buffer = new byte[2048];

            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public string CompressDataFromDataTable(DataTable dt)
        {
            dt.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, dt);

            byte[] inbyt = ms.ToArray();
            MemoryStream objStream = new MemoryStream();
            DeflateStream objZS = new DeflateStream(objStream, CompressionMode.Compress);
            objZS.Write(inbyt, 0, inbyt.Length);
            objZS.Flush();
            objZS.Close();


            byte[] data = objStream.ToArray();

            return Convert.ToBase64String(data, 0, data.Length);
        }

        public string CompressDataFromDataSet(DataSet ds)
        {
            ds.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ds);

            byte[] inbyt = ms.ToArray();
            MemoryStream objStream = new MemoryStream();
            DeflateStream objZS = new DeflateStream(objStream, CompressionMode.Compress);
            objZS.Write(inbyt, 0, inbyt.Length);
            objZS.Flush();
            objZS.Close();


            byte[] data = objStream.ToArray();

            return Convert.ToBase64String(data, 0, data.Length);
        }

    }
}
