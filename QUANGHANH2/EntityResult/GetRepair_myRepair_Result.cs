using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetRepair_myRepair_Result : RepairDetail
    {
        public string documentary_code { get; set; }
        public string afterStatus { get; set; }
        public int rowCount { get; set; }
        public System.DateTime date_created { get; set; }
        public List<GetRepair_mySupply_Result> listSup { get; set; }
    }
}