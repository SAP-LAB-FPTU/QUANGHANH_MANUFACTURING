using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetExportByGroup_Result : Equipment
    {
        public string Equipment_category_name { get; set; }
        public Int64 stt { get; set; }
        public int num { get; set; }
        public int sum1 { get; set; }
        public int sum2 { get; set; }
    }
}