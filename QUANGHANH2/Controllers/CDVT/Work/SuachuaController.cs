using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Web.Services;
using System.Collections;
using System.Web;
using System.Web.SessionState;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    [SessionState(SessionStateBehavior.Default)]
    public class SuachuaController : Controller
    {


        [Route("phong-cdvt/sua-chua")]
        public ActionResult Index()
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies.Get("SuaChuaThietBi") == null)
            {
                cookie = new HttpCookie("SuaChuaThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies.Get("SuaChuaThietBi");
            }
            ViewBag.selectedList = cookie.Value;
            return View("/Views/CDVT/Work/suachua.cshtml");
        }

        [Route("phong-cdvt/sua-chua")]
        [HttpPost]
        public ActionResult GetData(String selectListJson)
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies["SuaChuaThietBi"] == null)
            {
                cookie = new HttpCookie("SuaChuaThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies["SuaChuaThietBi"];
                cookie.Value = Request["selectList"];
            }

            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            ViewBag.selectedList = cookie.Value;
            //
            HttpContext.Response.Cookies.Set(cookie);
            var listSelect = Request["selectList"];
            List<Equipment> equipList = new List<Equipment>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                equipList = db.Equipments.ToList<Equipment>();
                int totalrows = equipList.Count;
                int totalrowsafterfiltering = equipList.Count;
                if (sortColumnName != null && sortDirection != null)
                {
                    //sorting
                    equipList = equipList.OrderBy(sortColumnName + " " + sortDirection).ToList<Equipment>();
                }
                //paging
                if (start != null && length != null)
                {
                    equipList = equipList.Skip(start).Take(length).ToList<Equipment>();
                }
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}