using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetListStatus_Result
    {
        public string room_id { get; set; }
        public string room_name { get; set; }
        public string department_name { get; set; }
        public Nullable<Boolean> ca1 { get; set; }
        public Nullable<Boolean> ca2 { get; set; }
        public Nullable<Boolean> ca3 { get; set; }
        public int camera_quantity { get; set; }
    }
}