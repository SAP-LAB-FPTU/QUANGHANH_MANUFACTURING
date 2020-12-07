using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetFamiliesOfAnEmployee_Result
    {
        public string full_name { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
        public string background { get; set; }
        public string permanent_address { get; set; }
        public string phone_number { get; set; }
        public string employee_id { get; set; }
        public int family_type_id { get; set; }
        public int family_relationship_id { get; set; }
        public string relationship_name { get; set; }
        public string type_name { get; set; }


    }
}