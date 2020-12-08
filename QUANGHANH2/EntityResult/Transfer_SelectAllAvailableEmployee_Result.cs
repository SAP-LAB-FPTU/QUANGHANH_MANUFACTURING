using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace QUANGHANH2.EntityResult
{
    public class Transfer_SelectAllAvailableEmployee_Result: QUANGHANH2.Models.Employee
    {
        public string department_name { get; set; }
        public string status_name { get; set; }
        public string work_name { get; set; }
    }
}