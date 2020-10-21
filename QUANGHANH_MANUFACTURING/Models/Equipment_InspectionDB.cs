using System;

namespace QUANGHANH_MANUFACTURING.Models
{
    public class Equipment_InspectionDB : Equipment_Inspection
    {
        public string equipment_name { get; set; }
        public string statusname { get; set; }
        public string stringExpectedTime { get; set; }

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