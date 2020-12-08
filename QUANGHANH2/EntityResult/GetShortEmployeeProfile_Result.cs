using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetShortEmployeeProfile_Result
    {
        public string employee_id { get; set; }
        public string BASIC_INFO_full_name { get; set; }
        public bool BASIC_INFO_gender { get; set; }
        public Nullable<DateTime> BASIC_INFO_date_of_birth { get; set; }
        public string BASIC_INFO_home_town { get; set; }
        public string department_name { get; set; }
        public string work_name { get; set; }
        public Nullable<DateTime> nearest_working_date { get; set; }
        public int nearest_working_shifts { get; set; }
    }
}