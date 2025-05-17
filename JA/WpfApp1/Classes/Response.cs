using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    [Table("Responses")]
    public class Response
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Application")]
        public int VacancyId { get; set; }       // ID вакансии
        [ForeignKey("User")]
        public int ApplicantId { get; set; }     // ID соискателя
        public DateTime ResponseDate { get; set; } = DateTime.Now;
        public ResponseStatus Status { get; set; } = ResponseStatus.Pending;

        public Application Application { get; set; }
        public User User { get; set; }
        public Response() { }

        public Response(int vacancyId, int applicantId)
        {
            VacancyId = vacancyId;
            ApplicantId = applicantId;
        }
    }

    public enum ResponseStatus
    {
        [Description("На рассмотрении")]
        Pending,

        [Description("Приглашение")]
        Approved,

        [Description("Отклонено")]
        Rejected,

        [Description("Отозвано")]
        Withdrawn
    }
    public static class ResponseStatusExtensions
    {
        public static string GetDescription(this ResponseStatus value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(
                field,
                typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }
    }
}
