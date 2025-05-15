using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    public class Response
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }       // ID вакансии
        public int ApplicantId { get; set; }     // ID соискателя
        public DateTime ResponseDate { get; set; } = DateTime.Now;
        public ResponseStatus Status { get; set; } = ResponseStatus.Pending;
    }

    public enum ResponseStatus
    {
        [Description("На рассмотрении")]
        Pending,

        [Description("Приглашение")]
        Approved,

        [Description("Отклонено")]
        Rejected,

    }
}
