using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetMoveline_moveLineByYear_Result
    {
        public List<GetMoveline_myMoveline_Result> listmoveline { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }
}