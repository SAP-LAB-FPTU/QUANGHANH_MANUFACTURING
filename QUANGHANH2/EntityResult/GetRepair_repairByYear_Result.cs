using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetRepair_repairByYear_Result
    {
        public List<GetRepair_myRepair_Result> list { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }
}