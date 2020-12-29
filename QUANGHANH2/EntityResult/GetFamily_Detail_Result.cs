using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetFamily_Detail_Result
    {
        public string full_name { get; set; }
        public string background { get; set; }
        public string type_family { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string relationship { get; set; }
    }
}