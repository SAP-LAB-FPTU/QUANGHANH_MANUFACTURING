using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetTranferHistory_Result
    {
        public string BASIC_INFO_full_name { get; set; }
        public int decision_id { get; set; }
        public string number { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string new_department { get; set; }
        public string old_department { get; set; }
        public string new_work { get; set; }
        public string old_work { get; set; }
    }
}