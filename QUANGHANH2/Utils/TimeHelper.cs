using System;

namespace QUANGHANH2.Utils
{
    public class TimeHelper
    {
        public DateTime StartOfNextWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).AddDays(7).Date;
        }
    }
}