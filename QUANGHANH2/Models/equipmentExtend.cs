using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class equipmentExtend : Equipment
    {
        public string department_name { get; set; }
        public int order_number { get; set; }
        public string statusname { get; set; }
    }
}