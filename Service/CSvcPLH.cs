using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Comm;
using WindowsFormsApp1.Info;

namespace WindowsFormsApp1.Service
{
    public static class CSvcPLH
    {

        public static void DeletePLH(CProjectInfo ProjectInfo)
        {
            Cnpgsql delete = new Cnpgsql();

            NpgsqlCommand[] deleteCommands = new NpgsqlCommand[2];


            NpgsqlCommand deleteCommander = new NpgsqlCommand();

            string sql;

            sql = $"delete from plh01t00    " +
                  $" where project_cd =  :p_project_cd   ";

            deleteCommander.CommandText = sql;
            deleteCommander.Parameters.AddWithValue("p_project_cd", ProjectInfo.ProjectCD);

            deleteCommands[0] = deleteCommander;


            //////////////////////////////////////
            NpgsqlCommand deleteCommander2 = new NpgsqlCommand();


            sql = "";
            sql = $"delete from plh01m00    " +
                  $" where project_cd =  :p_project_cd   ";

            deleteCommander2.CommandText = sql;
            deleteCommander2.Parameters.AddWithValue("p_project_cd", ProjectInfo.ProjectCD);

            deleteCommands[1] = deleteCommander2;

            delete.delete(deleteCommands);


        }

        public static void SavePLH(CProjectInfo ProjectInfo, DataTable dt)
        {
            


            Cnpgsql qry = new Cnpgsql();
            

            NpgsqlCommand[] qryCommanders = new NpgsqlCommand[dt.Rows.Count];



            int i = 0;

            foreach (DataRow item in dt.Rows)
            {

                

                
                NpgsqlCommand qryCommander = new NpgsqlCommand();

                string sql;

                sql = $"insert into plh01t00    " +
                      $" select :p_project_cd   " +
                      $"      , :p_file_name    " +
                      $"      , :p_line_name    " +                      
                      $"      , :p_p_node       " +
                      $"      , :p_c_node       ";

                if (i == 0)
                {
                    //노드 구성을 해보자
                    qryCommander.CommandText = sql;
                    qryCommander.Parameters.AddWithValue("p_project_cd" , ProjectInfo.ProjectCD);
                    qryCommander.Parameters.AddWithValue("p_file_name", item["FileName"]);
                    qryCommander.Parameters.AddWithValue("p_line_name", item["linename"]);
                    qryCommander.Parameters.AddWithValue("p_p_node", 0);
                    qryCommander.Parameters.AddWithValue("p_c_node", Convert.ToInt16(item["key"].ToString()));
                    
                }
                else
                {
                    if (dt.Rows[i-1]["linename"].ToString() == item["linename"].ToString()    ) 
                    {
                        //노드 구성을 해보자
                        qryCommander.CommandText = sql;
                        qryCommander.Parameters.AddWithValue("p_project_cd", ProjectInfo.ProjectCD);
                        qryCommander.Parameters.AddWithValue("p_file_name", item["FileName"]);
                        qryCommander.Parameters.AddWithValue("p_line_name", item["linename"]);
                        qryCommander.Parameters.AddWithValue("p_p_node", Convert.ToInt16(dt.Rows[i-1]["key"].ToString()) );
                        qryCommander.Parameters.AddWithValue("p_c_node",  Convert.ToInt16(item["key"].ToString()));


                    }
                    else
                    {

                        string sss = item["linename"].ToString();
                        string aaa = dt.Rows[i - 1]["linename"].ToString();

                        //노드 구성을 해보자
                        qryCommander.CommandText = sql;
                        qryCommander.Parameters.AddWithValue("p_project_cd", ProjectInfo.ProjectCD);
                        qryCommander.Parameters.AddWithValue("p_file_name", item["FileName"]);
                        qryCommander.Parameters.AddWithValue("p_line_name", item["linename"]);
                        qryCommander.Parameters.AddWithValue("p_p_node", 0);
                        qryCommander.Parameters.AddWithValue("p_c_node", Convert.ToInt16(item["key"].ToString()));

                    }

                }


                sql = "";
                sql = $"insert into plh01m00 " +
                        $" select :p_project_cd " +
                        $"      , :p_key " +
                        $"      , :p_order_seq" +
                        $"      , :p_filename " +
                        $"      , :p_linenumber " +
                        $"      , :p_extention " +
                        $"      , :p_dist" +
                        $"      , :p_dist2" +
                        $"      , :p_gh" +
                        $"      , :p_inv" +
                        $"      , :p_linename" +
                        $"      , :p_dia" +
                        $"      , :p_br" +
                        $"      , :p_type" +
                        $"      , :p_t1" +
                        $"      , :p_slope" +
                        $"      , :p_bcut" +
                        $"      , :p_hcut" +
                        $"      , :p_manwork" +
                        $"      , :p_sand" +
                        $"      , :p_baseangle" +
                        $"      , :p_conca" +
                        $"      , :p_concb" +
                        $"      , :p_humanity" +
                        $"      , :p_concrete" +
                        $"      , :p_asphalt1" +
                        $"      , :p_asphalt2" +
                        $"      , :p_complay" +
                        $"      , :p_mixlay" +
                        $"      , :p_mixlay1" +
                        $"      , :p_mixlay2" +
                        $"      , :p_area1" +
                        $"      , :p_area2" +
                        $"      , :p_area3" +
                        $"      , :p_area4" +
                        $"      , :p_area5" +
                        $"      , :p_area6" +
                        $"      , :p_area7" +
                        $"      , :p_area8" +
                        $"      , :p_area9" +
                        $"      , :p_area10" +
                        $"      , :p_area11" +
                        $"      , :p_t2" +
                        $"      , :p_t3" +
                        $"      , :p_t4" +
                        $"      , :p_b" +
                        $"      , :p_h" +
                        $"      , :p_dir " +
                        $"      , :p_pavement_stat";

                qryCommander.CommandText = sql;

                qryCommander.Parameters.AddWithValue("p_project_cd", ProjectInfo.ProjectCD);
                qryCommander.Parameters.AddWithValue("p_key", item["key"].ToString());
                qryCommander.Parameters.AddWithValue("p_order_seq", item["order_seq"].ToString());
                qryCommander.Parameters.AddWithValue("p_filename", item["FileName"].ToString()); //string
                qryCommander.Parameters.AddWithValue("p_linenumber", item["linenumber"].ToString()); //string
                qryCommander.Parameters.AddWithValue("p_extention", item["extention"].ToString()); //plus
                qryCommander.Parameters.AddWithValue("p_dist", item["dist"].ToString());
                qryCommander.Parameters.AddWithValue("p_dist2", item["dist2"].ToString());
                qryCommander.Parameters.AddWithValue("p_gh", item["gh"].ToString());
                qryCommander.Parameters.AddWithValue("p_inv", item["inv"].ToString());
                qryCommander.Parameters.AddWithValue("p_linename", item["linename"].ToString()); //string
                qryCommander.Parameters.AddWithValue("p_dia", item["dia"].ToString());
                qryCommander.Parameters.AddWithValue("p_br", item["br"].ToString());
                qryCommander.Parameters.AddWithValue("p_type", item["type"].ToString());
                qryCommander.Parameters.AddWithValue("p_t1", item["t1"].ToString());
                qryCommander.Parameters.AddWithValue("p_slope", item["slope"].ToString());
                qryCommander.Parameters.AddWithValue("p_bcut", item["bcut"].ToString());
                qryCommander.Parameters.AddWithValue("p_hcut", item["hcut"].ToString());
                qryCommander.Parameters.AddWithValue("p_manwork", item["manwork"].ToString());
                qryCommander.Parameters.AddWithValue("p_sand", item["sand"].ToString());
                qryCommander.Parameters.AddWithValue("p_baseangle", item["baseangle"].ToString());
                qryCommander.Parameters.AddWithValue("p_conca", item["conca"].ToString());
                qryCommander.Parameters.AddWithValue("p_concb", item["concb"].ToString());
                qryCommander.Parameters.AddWithValue("p_humanity", item["humanity"].ToString());
                qryCommander.Parameters.AddWithValue("p_concrete", item["concrete"].ToString());
                qryCommander.Parameters.AddWithValue("p_asphalt1", item["asphalt1"].ToString());
                qryCommander.Parameters.AddWithValue("p_asphalt2", item["asphalt2"].ToString());
                qryCommander.Parameters.AddWithValue("p_complay", item["complay"].ToString());
                qryCommander.Parameters.AddWithValue("p_mixlay", item["mixlay"].ToString());
                qryCommander.Parameters.AddWithValue("p_mixlay1", item["mixlay1"].ToString());
                qryCommander.Parameters.AddWithValue("p_mixlay2", item["mixlay2"].ToString());
                qryCommander.Parameters.AddWithValue("p_area1", item["area1"].ToString());
                qryCommander.Parameters.AddWithValue("p_area2", item["area2"].ToString());
                qryCommander.Parameters.AddWithValue("p_area3", item["area3"].ToString());
                qryCommander.Parameters.AddWithValue("p_area4", item["area4"].ToString());
                qryCommander.Parameters.AddWithValue("p_area5", item["area5"].ToString());
                qryCommander.Parameters.AddWithValue("p_area6", item["area6"].ToString());
                qryCommander.Parameters.AddWithValue("p_area7", item["area7"].ToString());
                qryCommander.Parameters.AddWithValue("p_area8", item["area8"].ToString());
                qryCommander.Parameters.AddWithValue("p_area9", item["area9"].ToString());
                qryCommander.Parameters.AddWithValue("p_area10", item["area10"].ToString());
                qryCommander.Parameters.AddWithValue("p_area11", item["area11"].ToString());
                qryCommander.Parameters.AddWithValue("p_t2", item["t2"].ToString());
                qryCommander.Parameters.AddWithValue("p_t3", item["t3"].ToString());
                qryCommander.Parameters.AddWithValue("p_t4", item["t4"].ToString());
                qryCommander.Parameters.AddWithValue("p_b", item["b"].ToString());
                qryCommander.Parameters.AddWithValue("p_h", item["h"].ToString());
                qryCommander.Parameters.AddWithValue("p_dir", item["dir"].ToString());

                qryCommanders[i] = qryCommander;
                
                i++;
            }

            qry.insert(qryCommanders);

        }
    }
}
