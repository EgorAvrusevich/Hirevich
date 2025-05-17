using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JA.Classes
{
    public class ResponsedAppForList
    {
        public AppForList AppForList { get; set; }
        public ResponseStatus Status { get; set; }
        public PersonalData? PersonalData { get; set; }

        public Response? Response { get; set; }

        public ResponsedAppForList() { }

        public ResponsedAppForList(AppForList app, ResponseStatus status, PersonalData personalData)
        {
            AppForList = app;
            Status = status;
            PersonalData = personalData;
        }
        public ResponsedAppForList(AppForList app, ResponseStatus status, PersonalData personalData, Response resp)
        {
            AppForList = app;
            Status = status;
            Response = resp;
            PersonalData = personalData;
        }
        public ResponsedAppForList(AppForList app, ResponseStatus status)
        {
            AppForList = app;
            Status = status;
        }

        public string StatusText => Status.GetDescription();

        public Brush StatusColor
        {
            get
            {
                switch (Status)
                {
                    case ResponseStatus.Approved:
                        return Brushes.Green;
                    case ResponseStatus.Rejected:
                        return Brushes.Red;
                    case ResponseStatus.Withdrawn:
                        return Brushes.Gray;
                    default:
                        return Brushes.Orange;
                }
            }
        }
    }
}