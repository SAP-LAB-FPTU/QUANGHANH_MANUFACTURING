using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Documentary_Extend : Documentary
    {
        public string templdId { get; set; }
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }
        public System.DateTime acceptance_date { get; set; }
    }
}