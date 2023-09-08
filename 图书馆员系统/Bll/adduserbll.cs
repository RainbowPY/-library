using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class adduserbll
    {

        public static bool addusers(libraryusermod lib)
        {
            if (adduser.Addusers(lib))
                return true;
            else return false;
        }

        public static bool addbook(bookmod bookmod)
        {
            if (adduser.Addnook(bookmod))
                return true;
            else return false;
        }
    }
}
