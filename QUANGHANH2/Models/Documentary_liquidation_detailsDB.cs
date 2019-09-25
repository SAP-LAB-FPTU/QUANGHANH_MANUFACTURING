using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Documentary_liquidation_detailsDB : Documentary_liquidation_details
    {
        public string equipment_name { get; set; }
        public string statusAndEquip { get; set; }
        public string idAndEquip { get; set; }
    }
}