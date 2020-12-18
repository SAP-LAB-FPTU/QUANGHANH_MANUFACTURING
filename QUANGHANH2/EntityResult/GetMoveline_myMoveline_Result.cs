using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetMoveline_myMoveline_Result : MovelineDetail
    {
        public string documentary_code { get; set; }
        public string person_created { get; set; }
        public System.DateTime date_created { get; set; }
        public string reason { get; set; }
        public string department_id_to { get; set; }
        public string date { get; set; }
    }
}