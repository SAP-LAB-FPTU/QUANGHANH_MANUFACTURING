using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Equipment_InspectionDB : Equipment_Inspection
    {
        public string equipment_name { get; set; }
        public string stringStartTime { get; set; }
        public string stringEndTime { get; set; }
        public string updateAble { get; set; }

        public string getEndtime()
        {
            if (inspect_end_date == null) return "";
            else
            {
                DateTime temp;
                DateTime.TryParse(inspect_end_date.ToString(), out temp);
                return temp.ToString("dd/MM/yyyy");
            }
        }
    }
}