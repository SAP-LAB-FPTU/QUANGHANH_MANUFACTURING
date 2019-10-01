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
using QUANGHANH2.SupportClass;
using System.Data.SqlClient;

namespace QUANGHANH2.Controllers.CDVT.Work
{
    [SessionState(SessionStateBehavior.Default)]
    public class TrungdaituController : Controller
    {
      [Auther(RightID = "95")]
        [Route("phong-cdvt/trung-dai-tu")]
        public ActionResult Index()
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies.Get("TrungTuThietBi") == null)
            {
                cookie = new HttpCookie("TrungTuThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies.Get("TrungTuThietBi");
            }
            ViewBag.selectedList = cookie.Value;
            return View("/Views/CDVT/Work/sctx.cshtml");
        }

        [Auther(RightID = "95")]
        [Route("phong-cdvt/trung-dai-tu/search")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string department_name, string equipmentName)
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies["TrungTuThietBi"] == null)
            {
                cookie = new HttpCookie("TrungTuThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies["TrungTuThietBi"];
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

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string query = "SELECT * FROM Equipment e inner join Department d on e.department_id = d.department_id";
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