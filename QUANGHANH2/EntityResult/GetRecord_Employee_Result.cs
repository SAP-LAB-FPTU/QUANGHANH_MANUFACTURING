using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetRecord_Employee_Result
    {
        public string employee_id { get; set; }
        public string employee_name { get; set; }
        public int records_id { get; set; }
        public DateTime? date_of_birth { get; set; }
        public DateTime? received_date { get; set; }
        public string delivery_employee_name { get; set; }
        public string handover_employee_name { get; set; }
        public string management_employee_name { get; set; }
    }
}