using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetShutDown_Notyet_List_Result
    {
        public int decision_id { get; set; }
        public string number { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string termination_type { get; set; }
        public Nullable<DateTime> terminate_date { get; set; }
        public string BASIC_INFO_full_name { get; set; }
        public string employee_id { get; set; }
    }
}