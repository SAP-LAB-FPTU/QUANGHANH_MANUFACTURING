using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetPaper_Detail_Result
    {
        public int records_papers_id { get; set; }
        public string school_name { get; set; }
        public string spe_name { get; set; }
        public string career_name { get; set; }
        public string papers_number { get; set; }
        public string papers_name { get; set; }
        public string duration { get; set; }
        public DateTime? given_date { get; set; }
        public string paper_storage_name { get; set; }
        public string type_name { get; set; }
    }
}