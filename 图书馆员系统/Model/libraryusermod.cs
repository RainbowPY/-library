using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class libraryusermod
    {
        private string sid;
        private string pwd;
        private string sname;
        private string sex;
        private string role;
        private string states;
        private int roleid;

        public string Sid { get => sid; set => sid = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Sname { get => sname; set => sname = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Role { get => role; set => role = value; }
        public string States { get => states; set => states = value; }
        public int Roleid { get => roleid; set => roleid = value; }
    }
}
