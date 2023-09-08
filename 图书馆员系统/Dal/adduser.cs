using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    public class adduser
    {
        private static string connString = @"server=127.0.0.1;uid=sa;pwd=123456;database=Library";

        public static  bool Addusers(libraryusermod lb)
        {

            bool ispol = false;
            SqlConnection con = new SqlConnection(connString);

          
           
    
                    try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "add_user";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@sid", lb.Sid));
                        cmd.Parameters.Add(new SqlParameter("@pwd", lb.Pwd));
                        cmd.Parameters.Add(new SqlParameter("@sname", lb.Sname));
                        cmd.Parameters.Add(new SqlParameter("@sex", lb.Sex));
                        cmd.Parameters.Add(new SqlParameter("@states", lb.States));
                        cmd.Parameters.Add(new SqlParameter("@roleid", lb.Roleid));     
                        if (cmd.ExecuteNonQuery() != null)
                        {
                            int count = (int)cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                Console.WriteLine("插入成功");
                                ispol = true;
                            }
                            else { ispol = false; }
                        }
                       
                    }
                    catch
                    {
                      
                        throw;
                    }
                
            
            return ispol;
        }

        /// <summary>
        /// 更新书籍
        /// </summary>
        /// <param name="bookmod"></param>
        /// <returns></returns>
        public static bool Updatebook(bookmod bookmod)
        {

            bool ispol = false;
            SqlConnection con = new SqlConnection(connString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update_book";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", bookmod.Id));
                cmd.Parameters.Add(new SqlParameter("@bookname",bookmod.Bookname ));
                cmd.Parameters.Add(new SqlParameter("@typeid", bookmod.Typeid));
                cmd.Parameters.Add(new SqlParameter("@price", bookmod.Price));
                cmd.Parameters.Add(new SqlParameter("@num", bookmod.Num));
                cmd.Parameters.Add(new SqlParameter("@indate", bookmod.Indate));
                cmd.Parameters.Add(new SqlParameter("@pricture", bookmod.Pricture));
                if (cmd.ExecuteNonQuery() != null)
                {
                    int count = (int)cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Console.WriteLine("插入成功");
                        ispol = true;
                    }
                    else { ispol = false; }
                }

            }
            catch
            {

                throw;
            }


            return ispol;
        }

        /// <summary>
        /// 插入书籍
        /// </summary>
        /// <param name="bookmod"></param>
        /// <returns></returns>
        public static bool Addnook(bookmod bookmod)
        {

            bool ispol = false;
            SqlConnection con = new SqlConnection(connString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
               // string sql = "  insert into book(bookname,typeid,price,num,indate,pricture) values(@bookname,@typeid,@price,@num,@indate,@pricture)";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "add_books";
                NewMethod(bookmod, cmd);

                if (cmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("插入成功");
                        ispol = true;
                    }
                    else { ispol = false; }
                

            }
            catch
            {

                throw;
            }


            return ispol;
        }


        /// <summary>
        /// 恢复书籍
        /// </summary>
        /// <param name="bookmod"></param>
        /// <returns></returns>
        public static bool Huifu(bookmod bookmod)
        {
            

            bool ispol = false;
            SqlConnection con = new SqlConnection(connString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_del_book";
                NewMethod(bookmod, cmd);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("插入成功");
                    ispol = true;
                }
                else { ispol = false; }


            }
            catch
            {

                throw;
            }


            return ispol;
        }

        private static void NewMethod(bookmod bookmod, SqlCommand cmd)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", bookmod.Id));
            parameters.Add(new SqlParameter("@bookname", bookmod.Bookname));
            parameters.Add(new SqlParameter("@typeid", bookmod.Typeid));
            parameters.Add(new SqlParameter("@price", bookmod.Price));
            parameters.Add(new SqlParameter("@num", bookmod.Num));
            parameters.Add(new SqlParameter("@indate", bookmod.Indate));
            parameters.Add(new SqlParameter("@pricture", bookmod.Pricture));
            cmd.Parameters.AddRange(parameters.ToArray());
        }
    }
}
