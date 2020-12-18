using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetIncident_IncidentByDate_Result
    {
        public List<GetIncident_IncidentDB_Result> incidents { get; set; }
        public DateTime date { get; set; }
    }
}