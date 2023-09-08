using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    
    public class selectbll
    {
        public static bool selects(string suid)
        {
           if(select.selectuser(suid))
            {
                return true;
            }else { return false; }
        }
        public static void SelectUsers(string sid)
        {
            select.selectusers(sid);
        }
        public static void Selectsidroe(string sid)
        {
            select.Selectsidroe(sid);
        }
        public static void Selectbook(int sel) { 
         select.selectbook(sel);
        }
        public static void Selectbook(string sel)
        {
            select.selectbook(sel);
        }


        public static void selectbooktype()
        {
           
            select.selectbooktype();
        }
        public static void selectbooktype(int typeid)
        {

            select.selectbooktype(typeid);
        }
        public static void selectbooktype(string type)
        {

            select.selectbooktype(type);
        }


        public static void selectbook()
        {
            
            select.selectbook();
        }
        public static void selectdelbook(int id)
        {

            select.selectdelbook(id);
        }

        public static void selectdel()
        {
            select.selectdel();
        }
    }
   
}
