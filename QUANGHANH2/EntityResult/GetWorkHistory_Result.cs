using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetWorkHistory_Result
    {
        public Nullable<DateTime> attendance_date { get; set; }
        public string shifts { get; set; }
        public string note { get; set; }
    }
}