using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetExportList_Result : Equipment
    {
        public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
        public string status_name { get; set; }
        public string Equipment_category_name { get; set; }
        public string department_name { get; set; }
    }
}