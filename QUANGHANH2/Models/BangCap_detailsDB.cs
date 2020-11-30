using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class BangCap_detailsDB:BangCap_GiayChungNhan
    {
        public string TenTruong { get; set; }
        public string TenChuyenNganh { get; set; }
        public string TenTrinhDo { get; set; }
    }
}