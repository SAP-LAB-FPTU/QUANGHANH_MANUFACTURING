using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetRecord_Detail_Result
    {
        public int records_id { get; set; }
        public string employee_id { get; set; }
        public DateTime? received_date { get; set; }
        public string delivery_employee_name { get; set; }
        public string handover_employee_name { get; set; }
        public string management_employee_name { get; set; }
        public DateTime? recruitment_date { get; set; }
        public DateTime? recruitment_decision_date { get; set; }
        public string department_name { get; set; }
        public string termination_type { get; set; }
        public string recruitment_type { get; set; }
        public DateTime? termination_date { get; set; }
        public DateTime? termination_decision_date { get; set; }
    }
}