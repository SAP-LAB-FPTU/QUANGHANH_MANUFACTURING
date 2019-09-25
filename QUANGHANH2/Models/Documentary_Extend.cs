using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Documentary_Extend : Documentary
    {
        public string tempId { get; set; }
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }

        public string documentary_code { get; set; }
        public string temp { get; set; }
        public System.DateTime acceptance_date { get; set; }
        public int count { get; set; }
    }
}