using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetPowerReport_Result
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public double LuongTieuThu { get; set; }
        public double SanLuong { get; set; }
        public string DonVi { get; set; }
    }
}