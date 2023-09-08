using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class deletebll
    {
        public static bool deletebook(int id)
        {
           
            if (deletedal.deletebook(id))
            {
                return true;
            }
            else
                return false;


        }

        public static bool deletedel(int id)
        {

            if (deletedal.deletedel(id))
            {
                return true;
            }
            else
                return false;


        }
    }
}
