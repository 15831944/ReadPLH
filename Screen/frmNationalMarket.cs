using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1.Screen
{
    public partial class frmNationalMarket : WindowsFormsApp1.Base.XtraBaseForm
    {
        public frmNationalMarket()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            QryData();
        }



        private void QryData()
        {
            //검색조건
            string a = "";
            string b = "";

            string xml = "";
            WebClient wc = null;
            XmlDocument doc = null;
            XmlNode root = null;


            wc = new WebClient() { Encoding = Encoding.UTF8 };
            doc = new XmlDocument();

            //string operation = "getPriceInfoListFcltyCmmnMtrilEngrk"; //시설공통자제(토목)
            //string bbb = "getPriceInfoListFcltyCmmnMtrilBildng"; //시설공통자재(건축)

            //string sss = "getPriceInfoListMrktCnstrctPcEngrk";   //시장시공가격(토목)     
            //string aaa = "getPriceInfoListMrktCnstrctPcBildng"; //시장시공가격(건축)
            string numOfRows = "10";
            string pageNo = "1";
            string ServiceKey = "Tp5dsjhspYJ2b7EX%2FGsbr9H6qr6tWEbaUNj7pgQCGHsA8GP80Gg4y3WFjtNgSxlgSPpEBUKuEb1t8sePtAvVtg%3D%3D";
            string prdctClsfcNo = "";//"40172503";//"30199997";// "30199997"; //물품분류번호
            string prdctClsfcNoNm = "수도용";// "여행";//"ACE JOINT"; // "H형 MMA복공판";
            string prdctIdntNo = ""; //"90000000";//"22146252";
            string krnPrdctNm = "";
            //string type = "json"; //"json";
            string type = ""; //"json";

            string strUrl = "http://apis.data.go.kr/1230000/ShoppingMallPrdctInfoService/getUcntrctPrdctInfoList";

            string sTmp;
            //sTmp = string.Format("http://apis.data.go.kr/1230000/PriceInfoService/getPriceInfoListMrktCnstrctPcMchnEqp?numOfRows={0}&pageNo={1}&ServiceKey={2}&prdctClsfcNo={3}&prdctClsfcNoNm={4}&type={5}&prdctIdntNo={6}", 
            //sTmp = string.Format("http://apis.data.go.kr/1230000/PriceInfoService/getPriceInfoListFcltyCmmnMtrilEngrk?numOfRows={0}&pageNo={1}&ServiceKey={2}&prdctClsfcNo={3}&prdctClsfcNoNm={4}&type={5}&prdctIdntNo={6}", 
            //sTmp = string.Format("http://apis.data.go.kr/1230000/PriceInfoService/getPriceInfoListMrktCnstrctPcEngrk?numOfRows={0}&pageNo={1}&ServiceKey={2}&prdctClsfcNo={3}&prdctClsfcNoNm={4}&type={5}&prdctIdntNo={6}", 
            //sTmp = string.Format("http://apis.data.go.kr/1230000/PriceInfoService/getPriceInfoListMrktCnstrctPcBildng?numOfRows={0}&pageNo={1}&ServiceKey={2}&prdctClsfcNo={3}&prdctClsfcNoNm={4}&type={5}&prdctIdntNo={6}", 
            //sTmp = string.Format("http://apis.data.go.kr/1230000/PriceInfoService/getPriceInfoListFcltyCmmnMtrilBildng?numOfRows={0}&pageNo={1}&ServiceKey={2}&prdctClsfcNo={3}&prdctClsfcNoNm={4}&type={5}&prdctIdntNo={6}", 

            //sTmp = string.Format("http://apis.data.go.kr/1230000/PriceInfoService/getPriceInfoListFcltyCmmnMtrilBildng?numOfRows={0}&pageNo={1}&ServiceKey={2}&prdctClsfcNo={3}&prdctClsfcNoNm={4}&type={5}&prdctIdntNo={6}", 
            //sTmp = string.Format("http://apis.data.go.kr/1230000/ShoppingMallPrdctInfoService/getUcntrctPrdctInfoList?numOfRows={0}&pageNo={1}&ServiceKey={2}&prdctClsfcNo={3}&prdctClsfcNoNm={4}&type={5}&prdctIdntNo={6}",
            sTmp = string.Format("{0}?numOfRows={1}&pageNo={2}&ServiceKey={3}&prdctClsfcNo={4}&prdctClsfcNoNm={5}&type={6}&prdctIdntNo={7}", strUrl, numOfRows, pageNo, ServiceKey, prdctClsfcNo, prdctClsfcNoNm, type, prdctIdntNo);
            try
            {
                //1. 서비스 데이터 조회
                xml = wc.DownloadString(                           
                            new Uri(sTmp)
                      );

                if (type != "json")
                {
                    doc.LoadXml(xml);

                    XmlNodeList xmllist = doc.GetElementsByTagName("item");


                    foreach (XmlNode item in xmllist)
                    {




                        Console.WriteLine(item["prdctClsfcNoNm"].InnerText);
                        Console.WriteLine(item["krnPrdctNm"].InnerText);
                        Console.WriteLine(item["unit"].InnerText);
                        Console.WriteLine(item["prce"].InnerText);
                    }


                }



                Console.WriteLine(xml);
                //                root = doc.SelectSingleNode("EmpmnListResponse");

                //2. 화면 작업
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                doc = null;
                root = null;
                wc.Dispose();
            }

            Console.WriteLine("Hello World!");
        }

    }
}
