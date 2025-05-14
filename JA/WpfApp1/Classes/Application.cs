using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    class Application
    {
        public int Id { get; set; }
        public int? Id_Company { get; set; }
        public string? Company_name { get; set; }
        public string? Vacation_Name { get; set; }
        public int? Wage { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Experience { get; set; }

        public Application() { }
        public Application(Application applications)
        {
            Id = applications.Id;
            Id_Company = applications.Id_Company;
            Company_name = applications.Company_name;
            Description = applications.Description;
            Country = applications.Country;
            Wage = applications.Wage;
            Vacation_Name = applications.Vacation_Name;
            Experience = applications.Experience;
        }

        public Application(int id, int? IdCompany, string? CompanyName, string? vacationName, int? wage, string? vacationDescription, string? country, string? expirience)
        {
            Id = id;
            Id_Company = IdCompany;
            Company_name = CompanyName;
            Vacation_Name = vacationName;
            Wage = wage;
            Description = vacationDescription;
            Country = country;
            Experience = expirience;
        }
    }
}
