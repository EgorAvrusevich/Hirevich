using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

// CompanyResponseItem.cs
namespace JA.Classes
{
    public class CompanyResponseItem
    {
        public int ResponseId { get; set; }
        public int VacancyId { get; set; }
        public string VacancyName { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public DateTime ResponseDate { get; set; }
        public ResponseStatus Status { get; set; }

        public string StatusText => Status.GetDescription();

        public Brush StatusColor => Status switch
        {
            ResponseStatus.Approved => Brushes.Green,
            ResponseStatus.Rejected => Brushes.Red,
            ResponseStatus.Withdrawn => Brushes.Gray,
            _ => Brushes.Orange
        };
    }
}