using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class ProfileGetListTBDK_Result : Equipment
    {
        public string supply_id { get; set; }
        public string supply_name { get; set; }
        public int quantity { get; set; }
        public string accompanied_equipment_id { get; set; }
    }
}