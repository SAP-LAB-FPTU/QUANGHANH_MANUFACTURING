using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Documentary_repair_detailsDB : Documentary_repair_details
    {
        public string department_name { get; set; }
        public string equipment_name { get; set; }
        public string stringDate { get; set; }
        public string statusAndEquip { get; set; }
        public string documentary_code { get; set; }
        public string department_id { get; set; }
        public string reason { get; set; }
        public int order_number { get; set; }
        public string idAndEquip { get; set; }
    }
}