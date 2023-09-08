using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class userdal
    {
        private static string connString = @"server=127.0.0.1;uid=sa;pwd=123456;database=Library";

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool Logon(string sid,String pwd)
        {
            bool logon =false;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
           
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "select * from userole where sid =@sid and pwd=@pwd"; 
                sqlCommand.Parameters.AddWithValue("@sid", sid);
                sqlCommand.Parameters.AddWithValue("@pwd", pwd);
                if(sqlCommand.ExecuteScalar() != null)
                {
                    int count = (int)sqlCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        return logon = true;
                    }
                    else
                        return logon = false;
                }
                else
                    return logon = false;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return logon;
        }


        /// <summary>
        /// 查suid 是否存在
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool selectuser(string sql)
        {
            bool logon = false;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = sql;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (!reader.HasRows)
                {
                    logon = true;
                }
                else
                {
                    logon = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        return logon;
        }


        public static DataTable dataTable = null;

        
        /// <summary>
        /// 所有查询
        /// </summary>
        /// <param name="sql"></param>
        public static void selectusers(string sql)
        {
            
            

            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);  
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

      public static   ArrayList ArrayList = new ArrayList();

        /// <summary>
        /// 查找职业角色
        /// </summary>
        /// <param name="sid"></param>
        public static void selectsidrole(string sid)
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "selec_sid_role ";
                sqlCommand.Parameters.Add(new SqlParameter("@sid", sid));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ArrayList.Add(reader["sid"].ToString());
                    ArrayList.Add(reader["rolename"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// 查询书籍
        /// </summary>
        /// <param name="sql"></param>
        public static void selectbook(string sql)
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sql"></param>
        public static bool deletebook(string sql)
        {
            bool isde =false;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = sql;
               if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    isde = true;
                } else { isde = false; }    
               
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isde;
        }
    }
}
