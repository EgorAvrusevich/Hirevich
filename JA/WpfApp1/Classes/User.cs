using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    public class User
    {
        public int id { get; set; }

        public string login { get; set; }
        public string password { get; set; }
        public int isSercher { get; set; }
        public int admin { get; set; }

        public User() { }

        public User( string login, string password, bool isSercher)
        {
            this.login = login;
            this.password = password;
            this.isSercher = isSercher? 1: 0;
            this.admin = 0;
        }
    }
}
