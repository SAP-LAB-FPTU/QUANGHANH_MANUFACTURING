using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetBasic_Info_Employee_Result
    {
        public string employee_id { get; set; }
        public string full_name { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string identity_card { get; set; }
        public string social_insurance_number { get; set; }
        public string phone_number { get; set; }
        public string home_town { get; set; }
        public string current_residence { get; set; }
        public string academic_level { get; set; }
        public string department_name { get; set; }
    }
}