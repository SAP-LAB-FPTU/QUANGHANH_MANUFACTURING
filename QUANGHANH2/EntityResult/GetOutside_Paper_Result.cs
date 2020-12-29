using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetOutside_Paper_Result
    {
        public int records_papers_id { get; set; }
        public int papers_id { get; set; }
        public string papers_number { get; set; }
        public string paper_name { get; set; }
        public string type_name { get; set; }
        public DateTime? received_date { get; set; }
        public DateTime? given_date { get; set; }
    }
}