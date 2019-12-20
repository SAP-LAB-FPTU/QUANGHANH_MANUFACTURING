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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<User_log> list = db.User_Action_Log.ToList().Select(x => new User_log { 
                    AccountID = x.AccountID,
                    Method = x.Method,
                    Url = x.Url,
                    Action_Time = x.Action_Time.Value,
                    Browser = x.Browser
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        private class User_log
        {
            public int AccountID { get; set; }
            public string Method { get; set; }
            public string Url { get; set; }
            public DateTime Action_Time { get; set; }
            public string Browser { get; set; }
        }
    }
}