using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class CarDB : Equipment
    {
        public string sokhung { get; set; }
        public string somay { get; set; }
        public Boolean GPS { get; set; }
        public string GPSstring { get; set; }
        public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
        public string statusname { get; set; }
        public string Equipment_category_name { get; set; }
        public string department_name { get; set; }
    }
}