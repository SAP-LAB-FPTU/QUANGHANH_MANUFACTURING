using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetOutside_Termination_Result
    {
        public int decision_id { get; set; }
        public string decision_number { get; set; }
        public string termination_name { get; set; }
        public DateTime? decision_date { get; set; }
        public DateTime? terminate_date { get; set; }
    }
}