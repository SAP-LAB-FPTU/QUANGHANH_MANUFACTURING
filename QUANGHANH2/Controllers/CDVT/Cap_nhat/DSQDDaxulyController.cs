using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.Models;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Cap_nhat
{
    public class DSQDChuaxulyController : Controller
    {
        [Auther(RightID = "24")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh-da-xu-ly")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Cap_nhat/Daxuly.cshtml");
        }

        [Auther(RightID = "24")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh-da-xu-ly")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<DocumentaryDB> docList = new List<DocumentaryDB>();


            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                db.Configuration.LazyLoadingEnabled = false;
                docList = db.Database.SqlQuery<DocumentaryDB>("SELECT docu.documentary_id, docu.documentary_status, docu.documentary_type, docu.date_created, docu.person_created, docu.reason, docu.[out/in_come] as out_in_come, depa.department_name FROM Documentary docu inner join Department depa on docu.department_id = depa.department_id where docu.documentary_status = 2 or docu.documentary_status = 3").ToList<DocumentaryDB>();
                foreach (DocumentaryDB item in docList)
                {
                    switch (item.documentary_type)
                    {
                        case "1":
                            item.stringtype = "Sửa chữa";
                            break;
                        case "2":
                            item.stringtype = "Bảo dưỡng";
                            break;
                        case "3":
                            item.stringtype = "Điều động";
                            break;
                        case "4":
                            item.stringtype = "Thu hồi";
                            break;
                        case "5":
                            item.stringtype = "Thanh lý";
                            break;
                        case "6":
                            item.stringtype = "Trung đại tu";
                            break;
                    }
                    if (item.documentary_status == 2) item.stringstatus = "Xử lý xong chưa nghiệm thu";
                    else item.stringstatus = "Đã nghiệm thu";
                    item.stringdate = item.date_created.ToString("dd/MM/yyyy");
                    item.outincome = item.out_in_come;
                }
                int totalrows = docList.Count;
                int totalrowsafterfiltering = docList.Count;
                ViewBag.List = docList.Count;
                //sorting
                docList = docList.OrderBy(sortColumnName + " " + sortDirection).ToList<DocumentaryDB>();
                //paging
                docList = docList.Skip(start).Take(length).ToList<DocumentaryDB>();
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}