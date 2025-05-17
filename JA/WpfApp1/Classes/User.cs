using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int isSercher { get; set; }
        public int admin { get; set; }

        // Навигационные свойства
        public PersonalData Users_data { get; set; }
        public Companys_data Companys_data { get; set; }
        public ICollection<Application> Applications { get; set; } // Для работодателя
        public ICollection<Response> Responses { get; set; } // Для соискателя

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
