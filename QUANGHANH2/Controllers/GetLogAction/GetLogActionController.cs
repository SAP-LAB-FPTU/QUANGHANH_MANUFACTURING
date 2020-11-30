using Newtonsoft.Json;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.API
{
    public class GetLogActionController : Controller
    {
        [Route("api/getLog")]
        public ActionResult Index()
        {
            string from_string = Request["from"];
            string to_string = Request["to"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                DateTime from_date = DateTime.TryParse(from_string, out from_date)? DateTime.Parse(from_string) : DateTime.MinValue;
                DateTime to_date = DateTime.TryParse(to_string, out to_date) ? DateTime.Parse(to_string) : DateTime.MaxValue;
                db.Configuration.LazyLoadingEnabled = false;
                List<User_log> list = db.User_Action_Log.Where(x => x.Action_Time >= from_date && x.Action_Time <= to_date).ToList().Select(x => new User_log { 
                    AccountID = x.AccountID,
                    Method = x.Method,
                    Url_From = x.Url_From,
                    Url_To = x.Url_To,
                    Action_Time = x.Action_Time,
                    Browser = x.Browser,
                    IP = x.Location_IP
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        private class User_log
        {
            public int AccountID { get; set; }
            public string Method { get; set; }
            public string Url_From { get; set; }
            public string Url_To { get; set; }
            public DateTime Action_Time { get; set; }
            public string Browser { get; set; }
            public string IP { get; set; }
        }
    }
}