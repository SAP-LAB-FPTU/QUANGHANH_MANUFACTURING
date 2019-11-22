using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class OccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-cong-viec")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Occupation/Occupation.cshtml");
        }

        ////////////////////////////LIST/////////////////////////////
        [Route("phong-tcld/quan-ly-cong-viec/danh-sach-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = true;

                //get data paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                try
                {
                    List<CongViec> congviec_list = new List<CongViec>();
                    var sqlList = "select * from CongViec order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                    congviec_list = db.Database.SqlQuery<CongViec>(sqlList).ToList();
                    int totalrows = db.CongViecs.Count();

                    int totalrowsafterfiltering = totalrows;
                    return Json(new { congviec_list = congviec_list, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }
    }
}