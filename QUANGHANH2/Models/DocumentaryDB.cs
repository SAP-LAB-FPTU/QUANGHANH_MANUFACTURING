using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class DocumentaryDB: Documentary
    {
        public string stringtype { get; set; }
        public string stringstatus { get; set; }
        public string stringdate { get; set; }
        public string outincome { get; set; }
        public string department_name { get; set; }
        public string stringlink { get; set; }
    }
}