using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class Equipment_InsuranceDB : Equipment_Insurance
    {
        public string equipment_name { get; set; }
        public string statusname { get; set; }
        public string stringStartDate { get { return insurance_start_date.ToString("dd/MM/yyyy"); } }
        public string stringEndDate { get { return insurance_end_date.ToString("dd/MM/yyyy"); } }
    }
}