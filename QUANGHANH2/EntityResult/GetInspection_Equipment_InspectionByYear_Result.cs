using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetInspection_Equipment_InspectionByYear_Result
    {
        public int year { get; set; }
        public List<Inspection> equipment_Inspections { get; set; }
        public int count { get; set; }
    }
}