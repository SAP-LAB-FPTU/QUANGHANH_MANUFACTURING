using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class CarDB : Equipment
    {
        public string chassis_number { get; set; }
        public string engine_number { get; set; }
        public Nullable<System.Boolean> GPS { get; set; }
        public string GPSstring { get; set; }
        public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
        public string status_name { get; set; }
        public string equipment_category_name { get; set; }
        public string department_name { get; set; }
        public Nullable<System.Int32> manufacture_year { get; set; }
        public Nullable<System.Boolean> fuel { get; set; }
    }
}