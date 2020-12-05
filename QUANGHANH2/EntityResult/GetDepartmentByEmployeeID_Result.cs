using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QUANGHANH2.Models;

namespace QUANGHANH2.EntityResult
{
    public class GetDepartmentByEmployeeID_Result : Employee
    {
        public string department_type { get; set; }

    }
}