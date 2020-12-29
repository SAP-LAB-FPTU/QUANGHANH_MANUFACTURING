using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetRelevant_Paper_Result
    {
        public string employee_id { get; set; }

        public string employee_name { get; set; }

        public string paper_name { get; set; }
        public string paper_id { get; set; }
        public string type_name { get; set; }
        public string papers_type_id { get; set; }
        public string papers_storage_type_id { get; set; }
        public int records_papers_id { get; set; }
    }
}