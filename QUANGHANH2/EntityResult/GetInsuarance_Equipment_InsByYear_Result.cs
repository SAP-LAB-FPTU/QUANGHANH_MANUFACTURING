using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetInsuarance_Equipment_InsByYear_Result
    {
        public int year { get; set; }
        public List<GetInsuarance_Equipment_InsDB_Result> equipment_Ins { get; set; }
        public int count { get; set; }
    }
}