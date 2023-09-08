using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class select
    {
        public static bool selectuser(string sid)
        {
            string sql = "select * from userole where sid ='" + sid+"'";
            if (userdal.selectuser(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void selectusers(string sid)
        {
            string sql = "select * from userole where sid ='" + sid + "'"; 
            userdal.selectusers(sql);
        }

        public static void Selectsidroe(string sid)
        {
            
            userdal.selectsidrole(sid);
        }


        public static void selectbook(int sel)
        {
            string sql = $"SELECT * FROM book WHERE id LIKE '%{sel}%'"; 
            userdal.selectbook(sql);
        }
        public static void selectbook(string sel)
        {
            string sql = $"SELECT * FROM book WHERE bookname LIKE '%{sel}%'"; 
            userdal.selectbook(sql);
        }


        public static void selectbooktype()
        {
            string sql = "select * from booktype";
            userdal.selectusers(sql);
        }

        public static void selectbooktype(int typeid)
        {
            string sql = $"select * from book where typeid ={typeid}";
            userdal.selectusers(sql);
        }

        public static void selectbooktype(string type)
        {
            string sql = $"select * from book where typeid in(select typeid from booktype where typename = '{type}')";
            userdal.selectusers(sql);
        }
        public static void selectbook()
        {
            string sql = "select * from book";
            userdal.selectusers(sql);
        }
        public static void selectdelbook(int id)
        {
            string sql = $"select * from backupTable where id ={id}";
            userdal.selectusers(sql);
        }

        public static void selectdel()
        {
            string sql = "select * from backupTable";
            userdal.selectusers(sql);
        }
    }
}
