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
        public string idAndid { get; set; }
        public bool du_phong { get; set; }
        public bool di_kem { get; set; }
        public bool can { get; set; }
        public string documentary_name { get; set; }

        public string temp { get; set; }
        public Nullable<System.DateTime> acceptance_date { get; set; }
        public int count { get; set; }
        public LinkIdCode2 linkIdCode { get; set; }

        public Boolean QDQT { get; set; }
    }
    public class LinkIdCode2
    {
        public string link { get; set; }
        public string id { get; set; }
        public string code { get; set; }
        public int doc { get; set; }
    }
}