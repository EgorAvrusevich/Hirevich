using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    internal class PersonalData
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName {  get; set; }
        public string? email { get; set; }
        public string? age { get; set; }
        public string? Country { get; set; }
        public string? About { get; set; }
        public string? Education { get; set; }
        public byte[]? Photo { get; set; }
        public string? speciality { get; set; }

        public PersonalData(int id) { Id = id; }
    }
}
