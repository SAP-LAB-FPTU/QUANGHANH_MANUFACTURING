using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Supply_Extend
    {
        public string equipmentId { get; set; }
        public string supply_id { get; set; }
        public int quantity { get; set; }
        public string supplyType { get; set; }
        public string supplyStatus { get; set; }
        public string supply_name { get; set; }
        public string unit { get; set; }
        public string documentary_process_result { get; set; }
    }
}