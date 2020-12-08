using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetListEquipNoAccreditationWithDate_Result
    {
        public string equipment_name { get; set; }
        public string equipmentId { get; set; }
        public DateTime day { get; set; }
        public int ngay { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
    }
}