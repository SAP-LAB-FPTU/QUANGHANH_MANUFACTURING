using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Web;
using System.Web.SessionState;
using QUANGHANH2.SupportClass;
using System.Data.SqlClient;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    [SessionState(SessionStateBehavior.Default)]
    public class ThanhlyController : Controller
    {
        [Auther(RightID = "91")]
        [Route("phong-cdvt/thanh-ly")]
        public ActionResult Index()
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies.Get("ThanhLyThietBi") == null)
            {
                cookie = new HttpCookie("SuaChuaThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies.Get("ThanhLyThietBi");
            }
            ViewBag.selectedList = cookie.Value;
            if (TempData["shortMessage"] != null)
                ViewBag.alert = true;
            else
                ViewBag.alert = false;
            return View("/Views/CDVT/Quyetdinh/ThanhLy/ChonThietBi.cshtml");
        }

        [Auther(RightID = "91")]
        [Route("phong-cdvt/thanh-ly/search")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string department_name, string equipmentName)
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies["ThanhLyThietBi"] == null)
            {
                cookie = new HttpCookie("ThanhLyThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies["ThanhLyThietBi"];
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

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                string query = "SELECT *, s.statusname FROM Equipment e inner join Department d on e.department_id = d.department_id inner join Status s on e.current_Status = s.statusid";
                if (!equipmentId.Equals("") || !equipmentName.Equals("") || !department_name.Equals(""))
                {
                    query += " where ";
                    if (!equipmentId.Equals("")) query += "e.equipmentId LIKE @equipmentId AND ";
                    if (!equipmentName.Equals("")) query += "e.equipment_name LIKE @equipment_name AND ";
                    if (!department_name.Equals("")) query += "d.department_name LIKE @department_name AND ";
                    query = query.Substring(0, query.Length - 5);
                }
                List<equipmentExtend> equipList = db.Database.SqlQuery<equipmentExtend>(query,
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("department_name", '%' + department_name + '%')).ToList();
                int totalrows = equipList.Count;
                int totalrowsafterfiltering = equipList.Count;
                //sorting
                equipList = equipList.OrderBy(sortColumnName + " " + sortDirection).ToList<equipmentExtend>();
                //paging
                equipList = equipList.Skip(start).Take(length).ToList<equipmentExtend>();
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}