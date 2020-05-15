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
        public string attach_to { get; set; }
        public string idAndid { get; set; }
        public bool du_phong { get; set; }
        public bool di_kem { get; set; }
        public bool can { get; set; }
        public string documentary_name { get; set; }

        public string temp { get; set; }
        public Nullable<System.DateTime> acceptance_date { get; set; }
        public int count { get; set; }
        public int acceptance_id { get; set; }
    }
}