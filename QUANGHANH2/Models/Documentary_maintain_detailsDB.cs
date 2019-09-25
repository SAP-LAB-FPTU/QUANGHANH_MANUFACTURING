using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Documentary_maintain_detailsDB : Documentary_maintain_details
    {
        public string department_name { get; set; }
        public string equipment_name { get; set; }
        public string stringDate { get; set; }
        public string statusAndEquip { get; set; }
        public string idAndEquip { get; set; }
    }
}