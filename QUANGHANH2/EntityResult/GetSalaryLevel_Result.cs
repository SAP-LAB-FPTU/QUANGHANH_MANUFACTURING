using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetSalaryLevel_Result
    {
        public int salary_id { get; set; }
        public string salary_number { get; set; }
        public string applied_year { get; set; }
        public Nullable<int> pay_rate_id { get; set; }
        public Nullable<int> pay_table_id { get; set; }
        public string pay_rate { get; set; }
        public string pay_table { get; set; }
        public string rate_table_level { get; set; }
    }
}