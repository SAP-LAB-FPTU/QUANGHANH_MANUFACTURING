using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetIncident_IncidentByYear_Result
    {
        public int year { get; set; }
        public List<GetIncident_IncidentByDate_Result> IncidentByDates { get; set; }
        public int count { get; set; }
    }
}