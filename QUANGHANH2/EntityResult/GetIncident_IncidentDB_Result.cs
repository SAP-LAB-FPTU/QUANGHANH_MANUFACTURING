using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetIncident_IncidentDB_Result
    {
        public string equipment_name { get; set; }
        public string equipment_id { get; set; }
        public string department_name { get; set; }
        public DateTime start_time { get; set; }
        public Nullable<DateTime> end_time { get; set; }
        public string reason { get; set; }
        public string incident_type { get; set; }
        public int incident_id { get; set; }
    }
}