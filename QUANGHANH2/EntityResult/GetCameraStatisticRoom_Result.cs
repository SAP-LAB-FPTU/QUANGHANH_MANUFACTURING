using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetCameraStatisticRoom_Result
    {
        public string room_name { get; set; }
        public string department_name { get; set; }
        public int camera_available { get; set; }
        public int camera_quantity { get; set; }
    }
}