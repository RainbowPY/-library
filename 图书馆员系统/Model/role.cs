using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class role
    {
        private int roleid;
        private string rolename;

        public int Roleid { get => roleid; set => roleid = value; }
        public string Rolename { get => rolename; set => rolename = value; }

    }
}
