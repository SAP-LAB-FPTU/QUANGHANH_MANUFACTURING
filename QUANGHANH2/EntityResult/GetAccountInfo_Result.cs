using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetAccountInfo_Result
    {
        public int ID { get; set; }
        public string BASIC_INFO_full_name { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }
        public string TenCongViec { get; set; }
        public bool ADMIN { get; set; }
        public string department_name { get; set; }
        public string department_id { get; set; }
        public int Role { get; set; }
    }
}