using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
    public static class CMaxerSector
    {


        /// <summary>
        /// Pipe Line의 구간 정보값으로 막서 데이터를 설정한다.
        /// </summary>
        /// <param name="strData"></param>
        public static string SetData(double 거리, double 지반고, string strData)
        {

            string 포장 = "";
            string 가시설 = "";
            string 보고공 = "";

            switch (strData.ToUpper())
            {
                case "OP01":   //open 토사
                    포장 = "0";
                    가시설 = "0";
                    break;
                case "OP02":  //open asp
                    포장 = "3";
                    가시설 = "0";
                    break;
                case "OP03":  //open concrete
                    포장 = "2";
                    가시설 = "0";
                    break;
                case "OP04":  //open 보도
                    포장 = "1";
                    가시설 = "0";
                    break;
                case "OP05":   //open asp+concrete
                    포장 = "2";  //막서에서 표기가 안되므로 콘크리트로 처리함
                    가시설 = "0";
                    break;
                case "GA01":
                    포장 = "0";
                    가시설 = "1";
                    break;
                case "GA02":
                    포장 = "3";
                    가시설 = "1";
                    break;
                case "GA03":
                    포장 = "2";
                    가시설 = "1";
                    break;
                case "GA04":
                    포장 = "1";
                    가시설 = "1";
                    break;
                case "GA05":
                    포장 = "2";  //막서에서 표기가 안되므로 콘크리트로 처리함
                    가시설 = "1";
                    break;
                default:
                    break;
            }
            return string.Format("G={0},{1},{2},{3};", 거리, 지반고, 포장, 가시설);
        }


    }
}
