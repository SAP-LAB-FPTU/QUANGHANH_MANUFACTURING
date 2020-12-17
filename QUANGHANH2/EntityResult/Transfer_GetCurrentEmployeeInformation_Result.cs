using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class Transfer_GetCurrentEmployeeInformation_Result
    {
        public string employee_id { get; set; }
        public string BASIC_INFO_full_name { get; set; }
        public string department_name { get; set; }
        public string TenCongViec { get; set; }
        public double? PhuCap { get; set; }
        public string BacLuong { get; set; }
        public string ThangLuong { get; set; }
        public string Luong { get; set; }
        public string current_department_id { get; set; }
        public Nullable<int> current_work_id { get; set; }
    }
}