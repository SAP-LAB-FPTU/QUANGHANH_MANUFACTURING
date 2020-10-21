using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.SupportClass
{
    public class Auther : ActionFilterAttribute, IAuthorizationFilter
    {
        public string RightID { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserID"])))
            {
                var Url = new UrlHelper(filterContext.RequestContext);
                var url = Url.Action("Index", "Login");
                filterContext.Result = new RedirectResult(url);
            }
            else
            {
                List<string> RightIDs = (List<string>)filterContext.HttpContext.Session["RightIDs"];
                bool Check = false;
                foreach (var r in RightID.Split(','))
                {
                    if (RightIDs.Contains(r))
                    {
                        Check = true;
                        break;
                    }
                }
                if (!Check)
                {
                    string url = (string)filterContext.HttpContext.Session["url"];
                    filterContext.Result = new RedirectResult("/" + url);
                    //filterContext.Result = new ViewResult() { ViewName = "Permisssion" };
                }
            }
        }
    }
}