using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Lib
{
    class CReport1Dat
    {
        public enum enumReport1Dat
        {
            [CGetName("key")]
            key,
            [CGetName("LINENAME")]
            [CGetLength(19)]
            [CFormat("{0,-19}")]
            LINENAME,
            [CGetName("NO.")]
            [CGetLength(50)]
            [CFormat("{0,-50}")]  //왼쪽정렬
            NO, //측점
            [CGetName("dist2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]
            dist2,    //누가거리
            [CGetName("dist")]
            [CGetLength(6)]
            [CFormat("{0,6:#0.00}")]
            dist,    //거리
            [CGetName("concrete")]
            [CFormat("{0,10:#0.000}")]
            [CGetLength(10)]
            concrete,    //concrete
            [CGetName("humanity")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            humanity,
            [CGetName("area1")]
            [CFormat("{0,10:#0.000}")]
            [CGetLength(10)]
            area1, //터파기
            [CGetName("area2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area2, //관주위
            [CGetName("area3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area3, //관상단
            [CGetName("area5")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area5, //관기초
            [CGetName("area7")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area7, //복구
            [CGetName("asphalt1")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asphalt1, //표층
            [CGetName("asphalt2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asphalt2, //기층
            [CGetName("area8")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area8, //보조기층

            [CGetName("ASP포장_국도_절단")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_국도_절단, //ASP포장_국도_절단
            [CGetName("ASP포장_국도_복구_m")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_국도_복구_m, //ASP포장_국도
            [CGetName("ASP포장_국도_복구_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_국도_복구_m2, //ASP포장_국도
            [CGetName("ASP포장_국도_보조기층_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_국도_보조기층_m2, //ASP포장_국도
            [CGetName("ASP포장_국도_보조기층_m3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_국도_보조기층_m3, //ASP포장_국도


            [CGetName("ASP포장_지방도_절단")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_지방도_절단, //ASP포장_국도_절단
            [CGetName("ASP포장_지방도_복구_m")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_지방도_복구_m, //ASP포장_지방도
            [CGetName("ASP포장_지방도_복구_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_지방도_복구_m2, //ASP포장_지방도
            [CGetName("ASP포장_지방도_보조기층_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_지방도_보조기층_m2, //ASP포장_지방도
            [CGetName("ASP포장_지방도_보조기층_m3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP포장_지방도_보조기층_m3, //ASP포장_지방도


            


            //CONCRETE 포장 
            [CGetName("CON포장_절단")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            CON포장_절단, 
            [CGetName("CON포장_복구_m")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            CON포장_복구_m, //CON포장_복구
            [CGetName("CON포장_복구_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            CON포장_복구_m2, //ASP포장_지방도
            [CGetName("CON포장_보조기층_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            CON포장_보조기층_m2, //ASP포장_지방도
            [CGetName("CON포장_보조기층_m3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            CON포장_보조기층_m3, //ASP포장_지방도

            //ASP + CONCRETE 포장 
            [CGetName("ASP_CON포장_절단")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP_CON포장_절단,
            [CGetName("ASP_CON포장_복구_m")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP_CON포장_복구_m, //CON포장_복구
            [CGetName("ASP_CON포장_복구_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP_CON포장_복구_m2, //ASP포장_지방도
            [CGetName("ASP_CON포장_보조기층_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP_CON포장_보조기층_m2, //ASP포장_지방도
            [CGetName("ASP_CON포장_보조기층_m3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            ASP_CON포장_보조기층_m3, //ASP포장_지방도


            //투수콘포장 
            [CGetName("투수콘_절단")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            투수콘_절단,
            [CGetName("투수콘_복구_m")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            투수콘_복구_m, //투수콘_복구_m
            [CGetName("투수콘_복구_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            투수콘_복구_m2, //투수콘_복구_m2
            [CGetName("투수콘_보조기층_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            투수콘_보조기층_m2, //투수콘_보조기층_m2
            [CGetName("투수콘_보조기층_m3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            투수콘_보조기층_m3, //투수콘_보조기층_m3
            [CGetName("투수콘_모래_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            투수콘_모래_m2, //투수콘_모래_m2
            [CGetName("투수콘_모래_m3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            투수콘_모래_m3, //투수콘_모래_m2


            //보도블럭 
            [CGetName("보도블럭_복구_m")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            보도블럭_복구_m, //보도블럭_복구_m
            [CGetName("보도블럭_복구_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            보도블럭_복구_m2, //보도블럭_복구_m
            [CGetName("보도블럭_석분_m2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            보도블럭_석분_m2, //보도블럭_석분_m2
            [CGetName("보도블럭_석분_m3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            보도블럭_석분_m3, //보도블럭_석분_m3
          

            // 터파기 토사 
            //육상
            [CGetName("area1_2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]
            area1_2, //절단m
            //육상
            [CGetName("area1_3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]
            area1_3, //절단m
            [CGetName("area1_4")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.00}")]
            area1_4, //절단m

            //되메우기
            //관주위 
            [CGetName("area2_2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area2_2, //관주위
            [CGetName("area3_2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area3_2, //관상단


            [CGetName("area5_2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            area5_2, //관기초


            //ASP+CON'C 포장
            //asp+con_a1 (절단)
            [CGetName("asp_con_a1")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asp_con_a1, //절단m
            //asp+con_a2 (깨기및 복구)
            [CGetName("asp_con_a2")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asp_con_a2, //깨기및 복구 m
            //asp+con_a2 (깨기및 복구)
            [CGetName("asp_con_a3")]
            [CGetLength(10)]
            [CFormat("{0,10:#0.000}")]
            asp_con_a3,//깨기및 복구 m2

            //asp+con_a2 (깨기및 복구)
            [CGetName("장비")]
            [CGetLength(30)]
            [CFormat("{0,10:#0.000}")]
            장비//장비


        }



        public enum branches
        {
            [CGetName("투수콘")]
            투수콘,
            [CGetName("CONCRETE")]
            CONCRETE,
            [CGetName("ASP_CON")]
            ASP_CON,
            [CGetName("ASP국도")]
            ASP국도,
            [CGetName("ASP")]
            ASP
        }

        public branches m_branches;

        public DataTable m_dt;
        public int m_key = 0;
        double calc_area7 = 0.0;
        double calc_area8 = 0.0;
        double calc_cut = 0.0;


        /// <summary>
        /// 전달받은 DataSet으로 토적표 DATA를 구성한다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable SetData(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                long nKey;
                int index, pre_index;

                DataRow Dr = m_dt.NewRow();
                nKey = Convert.ToInt64(item[CUtil.GetName(CPLH.enumPLH.key)].ToString());
                index = (int)nKey - 1;
                pre_index = index - 1;
                Dr[CUtil.GetName(enumReport1Dat.key)] = nKey;
                Dr[CUtil.GetName(enumReport1Dat.LINENAME)] = item[CUtil.GetName(CPLH.enumPLH.LINENAME)];

                //측점 값 변경 NO. +  
                if (item[CUtil.GetName(CPLH.enumPLH.plus)].ToString().Trim() == "")
                {
                    Dr[CUtil.GetName(enumReport1Dat.NO)] = item[CUtil.GetName(CPLH.enumPLH.NO)].ToString() + "   +0.00";
                }
                else
                {
                    Dr[CUtil.GetName(enumReport1Dat.NO)] = item[CUtil.GetName(CPLH.enumPLH.NO)].ToString() + "   " + item[CUtil.GetName(CPLH.enumPLH.plus)].ToString();
                }                
                Dr[CUtil.GetName(enumReport1Dat.dist2)] = item[CUtil.GetName(CPLH.enumPLH.dist2)];
                Dr[CUtil.GetName(enumReport1Dat.dist)]  = item[CUtil.GetName(CPLH.enumPLH.dist)];
                Dr[CUtil.GetName(enumReport1Dat.area1)] = item[CUtil.GetName(CPLH.enumPLH.area1)]; //터파기 (토사)
                Dr[CUtil.GetName(enumReport1Dat.area2)] = item[CUtil.GetName(CPLH.enumPLH.area2)]; //관주위 
                Dr[CUtil.GetName(enumReport1Dat.area3)] = item[CUtil.GetName(CPLH.enumPLH.area3)]; //관상단
                Dr[CUtil.GetName(enumReport1Dat.area5)] = item[CUtil.GetName(CPLH.enumPLH.area5)]; //모래부설
                Dr[CUtil.GetName(enumReport1Dat.area7)] = item[CUtil.GetName(CPLH.enumPLH.area7)]; //복구 

                Dr[CUtil.GetName(enumReport1Dat.asphalt1)] = item[CUtil.GetName(CPLH.enumPLH.asphalt1)]; //표층 
                Dr[CUtil.GetName(enumReport1Dat.asphalt2)] = item[CUtil.GetName(CPLH.enumPLH.asphalt2)]; //기층 

                

                //터파기 토사 (area1_2)
                if (nKey == 1)
                {
                    Dr[CUtil.GetName(enumReport1Dat.area1_2)] = "0.00";                    
                }
                else
                {
                    double dprev_a2 = Convert.ToDouble(dt.Rows[pre_index][CUtil.GetName(CPLH.enumPLH.area1)].ToString());
                    double d_a2 = Convert.ToDouble(Dr[CUtil.GetName(enumReport1Dat.area1)] = item[CUtil.GetName(CPLH.enumPLH.area1)].ToString());

                    Dr[CUtil.GetName(enumReport1Dat.area1_2)] = Math.Round((dprev_a2 + d_a2) / 2 * Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.dist)].ToString()), 2).ToString();
                }

                //터파기 토사 (area2_2)
                if (nKey == 1)
                {
                    Dr[CUtil.GetName(enumReport1Dat.area2_2)] = "0.00";
                }
                else
                {
                    double dprev_a2 = Convert.ToDouble(dt.Rows[pre_index][CUtil.GetName(CPLH.enumPLH.area2)].ToString());
                    double d_a2 = Convert.ToDouble(Dr[CUtil.GetName(enumReport1Dat.area2)] = item[CUtil.GetName(CPLH.enumPLH.area2)].ToString());

                    Dr[CUtil.GetName(enumReport1Dat.area2_2)] = Math.Round((dprev_a2 + d_a2) / 2 * Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.dist)].ToString()), 2).ToString();
                }

                //관상단 (area3_2)
                if (nKey == 1)
                {
                    Dr[CUtil.GetName(enumReport1Dat.area3_2)] = "0.00";
                }
                else
                {
                    double dprev_a2 = Convert.ToDouble(dt.Rows[pre_index][CUtil.GetName(CPLH.enumPLH.area3)].ToString());
                    double d_a2 = Convert.ToDouble(Dr[CUtil.GetName(enumReport1Dat.area3)] = item[CUtil.GetName(CPLH.enumPLH.area3)].ToString());

                    Dr[CUtil.GetName(enumReport1Dat.area3_2)] = Math.Round((dprev_a2 + d_a2) / 2 * Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.dist)].ToString()), 2).ToString();
                }


                //관기초 (area5_2)
                if (nKey == 1)
                {
                    Dr[CUtil.GetName(enumReport1Dat.area5_2)] = "0.00";
                }
                else
                {
                    double dprev_a2 = Convert.ToDouble(dt.Rows[pre_index][CUtil.GetName(CPLH.enumPLH.area5)].ToString());
                    double d_a2 = Convert.ToDouble(Dr[CUtil.GetName(enumReport1Dat.area5)] = item[CUtil.GetName(CPLH.enumPLH.area5)].ToString());

                    Dr[CUtil.GetName(enumReport1Dat.area5_2)] = Math.Round((dprev_a2 + d_a2) / 2 * Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.dist)].ToString()), 2).ToString();
                }


                


                if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.concrete)].ToString()) > 0) //concrete > 0
                {
                    if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.concrete)].ToString()) == 0.07)
                    {
                        if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.complay)].ToString()) == 0.15)
                        {
                            if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.sand)].ToString()) == 0.05)
                            {
                                m_branches = branches.투수콘;
                            }
                        }
                    }
                    else // concrete 가 != 0.07
                    {
                        if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.asphalt1)].ToString()) > 0) //asphalt1 > 0
                        {
                            m_branches = branches.ASP_CON;    //A+C
                        }
                        else //asphalt1 == 0
                        {
                            m_branches = branches.CONCRETE;  //CONCRETE
                        }
                    }
                }
                else //concrete <= 0
                {
                    if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.asphalt1)].ToString()) > 0
                       && Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.asphalt1)].ToString()) == 0.11
                       && Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.asphalt2)].ToString()) == 0.1
                       )
                    {
                        m_branches = branches.ASP국도;  //ASP 국도 
                    }
                    else if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.concrete)].ToString()) == 0)
                    {
                        // ASP 지방도
                        m_branches = branches.ASP;
                    }
                }



                if (nKey == 1)
                {
                    calc_area7 = 0;
                    calc_area8 = 0;
                    calc_cut = 0;
                }
                else
                {
                    double dprev_area7 = Convert.ToDouble(dt.Rows[pre_index][CUtil.GetName(CPLH.enumPLH.area7)].ToString());
                    double d_area7 = Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.area7)].ToString());
                    Dr[CUtil.GetName(enumReport1Dat.area7)] = item[CUtil.GetName(CPLH.enumPLH.area7)].ToString();

                    double dprev_area8 = Convert.ToDouble(dt.Rows[pre_index][CUtil.GetName(CPLH.enumPLH.area8)].ToString());
                    double d_area8 = Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.area8)].ToString());
                    Dr[CUtil.GetName(enumReport1Dat.area8)] = item[CUtil.GetName(CPLH.enumPLH.area8)].ToString();

                    double d_prev_dist2 = Convert.ToDouble(dt.Rows[pre_index][CUtil.GetName(CPLH.enumPLH.dist2)].ToString());
                    double d_dist2 = Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.dist2)].ToString());


                    calc_area7 = Math.Round((dprev_area7 + d_area7) / 2 * Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.dist)].ToString()), 2);
                    calc_area8 = Math.Round((dprev_area8 + d_area8) / 2 * Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.dist)].ToString()), 2);
                    calc_cut = Math.Round( (d_dist2 - d_prev_dist2) * 2, 2);
                }







                //ASP 포장 (국도)
                if (m_branches == branches.ASP국도)                   
                {
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_국도_절단)]        = calc_cut;
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_국도_복구_m)]      = item[CUtil.GetName(enumReport1Dat.area7)].ToString();
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_국도_복구_m2)]     = calc_area7.ToString();
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_국도_보조기층_m2)] = item[CUtil.GetName(enumReport1Dat.area8)].ToString();                    
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_국도_보조기층_m3)] = calc_area8.ToString();

                }

                //ASP 포장 (지방도)
                if (m_branches == branches.ASP)
                {
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_지방도_절단)] = calc_cut;
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_지방도_복구_m)] = item[CUtil.GetName(enumReport1Dat.area7)].ToString();
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_지방도_복구_m2)] = calc_area7.ToString();
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_지방도_보조기층_m2)] = item[CUtil.GetName(enumReport1Dat.area8)].ToString();                    
                    Dr[CUtil.GetName(enumReport1Dat.ASP포장_지방도_보조기층_m3)] = calc_area8.ToString();

                }

                //Con'c 포장                
                if (m_branches == branches.CONCRETE)
                {
                    Dr[CUtil.GetName(enumReport1Dat.CON포장_절단)] = calc_cut;
                    Dr[CUtil.GetName(enumReport1Dat.CON포장_복구_m)] = item[CUtil.GetName(enumReport1Dat.area7)].ToString();
                    Dr[CUtil.GetName(enumReport1Dat.CON포장_복구_m2)] = calc_area7.ToString();
                    Dr[CUtil.GetName(enumReport1Dat.CON포장_보조기층_m2)] = item[CUtil.GetName(enumReport1Dat.area8)].ToString();                    
                    Dr[CUtil.GetName(enumReport1Dat.CON포장_보조기층_m3)] = calc_area8.ToString();
                }

                //asp + con'c 포장 
                
                if (m_branches == branches.ASP_CON)
                {
                    Dr[CUtil.GetName(enumReport1Dat.ASP_CON포장_절단)] = calc_cut;
                    Dr[CUtil.GetName(enumReport1Dat.ASP_CON포장_복구_m)] = item[CUtil.GetName(enumReport1Dat.area7)].ToString();
                    Dr[CUtil.GetName(enumReport1Dat.ASP_CON포장_복구_m2)] = calc_area7.ToString();
                    Dr[CUtil.GetName(enumReport1Dat.ASP_CON포장_보조기층_m2)] = item[CUtil.GetName(enumReport1Dat.area8)].ToString();                    
                    Dr[CUtil.GetName(enumReport1Dat.ASP_CON포장_보조기층_m3)] = calc_area8.ToString();

                }

                //투수콘
                if (m_branches == branches.투수콘)
                {
                    Dr[CUtil.GetName(enumReport1Dat.투수콘_절단)] = calc_cut;
                    Dr[CUtil.GetName(enumReport1Dat.투수콘_복구_m)] = item[CUtil.GetName(enumReport1Dat.area7)].ToString();
                    Dr[CUtil.GetName(enumReport1Dat.투수콘_복구_m2)] = calc_area7.ToString();
                    Dr[CUtil.GetName(enumReport1Dat.투수콘_보조기층_m2)] = item[CUtil.GetName(enumReport1Dat.area8)].ToString();                    
                    Dr[CUtil.GetName(enumReport1Dat.투수콘_보조기층_m3)] = calc_area8.ToString();

                }

                //보도블럭
                //humanity > 0
                if (Convert.ToDouble(item[CUtil.GetName(CPLH.enumPLH.humanity)].ToString()) > 0 )
                {
                    Dr[CUtil.GetName(enumReport1Dat.보도블럭_복구_m)] = item[CUtil.GetName(enumReport1Dat.area7)].ToString();
                    Dr[CUtil.GetName(enumReport1Dat.보도블럭_복구_m2)] = calc_area7.ToString();
                }



                m_dt.Rows.Add(Dr);
            }//end if for each

            return m_dt;
        }

        public CReport1Dat()
        {
            //double area1; //터파기
            //double area2; //관주위
            //double area3; //관상단
            //double area4; //잔토처리
            //double area5; //모래부설
            //double area6; //파취  
            //double area7; //복구
            //double area8; //보조기층
            //double area9; //혼합기층

            m_dt = new DataTable();
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.key), typeof(Int64)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.LINENAME), typeof(String)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.NO), typeof(String)));            
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.dist2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.dist), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area1), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area3), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area5), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area7), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.asphalt1), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.asphalt2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area8), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area1_2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area2_2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area3_2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.area5_2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.concrete), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.humanity), typeof(double)));




            //ASP 포장(국도)
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_국도_절단), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_국도_복구_m), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_국도_복구_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_국도_보조기층_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_국도_보조기층_m3), typeof(double)));

            //ASP 포장(지방도)
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_지방도_절단), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_지방도_복구_m), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_지방도_복구_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_지방도_보조기층_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP포장_지방도_보조기층_m3), typeof(double)));


            //CONCRETE 포장 
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.CON포장_절단), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.CON포장_복구_m), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.CON포장_복구_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.CON포장_보조기층_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.CON포장_보조기층_m3), typeof(double)));

            //ASP + CONCRETE 포장  포장 
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP_CON포장_절단), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP_CON포장_복구_m), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP_CON포장_복구_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP_CON포장_보조기층_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.ASP_CON포장_보조기층_m3), typeof(double)));


            //투수콘포장
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.투수콘_절단), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.투수콘_복구_m), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.투수콘_복구_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.투수콘_보조기층_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.투수콘_보조기층_m3), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.투수콘_모래_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.투수콘_모래_m3), typeof(double)));


            //보도블럭
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.보도블럭_복구_m), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.보도블럭_복구_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.보도블럭_석분_m2), typeof(double)));
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.보도블럭_석분_m3), typeof(double)));


            //장비
            m_dt.Columns.Add(new DataColumn(CUtil.GetName(enumReport1Dat.장비), typeof(String)));




        }




    }
}
