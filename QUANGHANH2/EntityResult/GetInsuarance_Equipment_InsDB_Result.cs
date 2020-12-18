using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetInsuarance_Equipment_InsDB_Result : Insurance
    {
        public string equipment_name { get; set; }
        public string status_name { get; set; }
        public string stringExpectedTime { get; set; }
        public string stringStartTime { get; set; }
        public string stringEndTime { get; set; }
        public string updateAble { get; set; }

        public string getStringtime(Nullable<DateTime> dateTime)
        {
            if (dateTime == null) return "";
            else
            {
                DateTime temp;
                DateTime.TryParse(dateTime.ToString(), out temp);
                return temp.ToString("dd/MM/yyyy");
            }
        }

        public string getDateString(Nullable<DateTime> dateTime)
        {
            if (dateTime == null) return "";
            else
            {
                DateTime temp;
                DateTime.TryParse(dateTime.ToString(), out temp);
                return "Thứ " + ((int)temp.DayOfWeek + 1) + ", ngày " + temp.Day + " tháng " + temp.Month;
            }
        }
    }
}