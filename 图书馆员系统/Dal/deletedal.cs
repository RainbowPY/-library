using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class deletedal
    {

        public static bool deletebook(int id)
        {
            string sql = $"delete from book where id = {id}";
            if (userdal.deletebook(sql))
            {
                return true;
            }else 
                return false;
            

        }
        public static bool deletedel(int id)
        {
            string sql = $"delete from backupTable where id = {id}";
            if (userdal.deletebook(sql))
            {
                return true;
            }
            else
                return false;


        }
    }
}
