using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using QUANGHANH2.SupportClass;
using System.Data.Entity;
using OfficeOpenXml;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Routing;
using System.Globalization;
using QUANGHANH2.EntityResult;

namespace QUANGHANH2.Controllers.CDVT.Vattu
{
    public class DanhsachvattuController : Controller
    {
        [HttpPost]
        public ActionResult ChangeID(string id, string ck)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<GetSuggestSearchSupply_Result> list = db.Database.SqlQuery<GetSuggestSearchSupply_Result>("Supply.Get_Suggest_Search_Supply {0}, {1}", id, ck).Take(10).ToList();
            return Json(new { success = true, id = list }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "172")]
        [Route("phong-cdvt/danh-sach-vat-tu")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Vattu/Danhsachvattu.cshtml");
        }

        [Route("phong-cdvt/danh-sach-vat-tu")]
        [HttpPost]
        public ActionResult Index(string supply_id, string supply_name)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();

            List<Supply> supplies = DBContext.Database.SqlQuery<Supply>("Supply.Get_list_Supply {0}, {1}, {2}, {3}, {4}, {5}" ,
                    supply_id, supply_name, sortColumnName, sortDirection, start, length).ToList();

            int totalrows = DBContext.Supplies.Where(x => x.supply_id.Contains(supply_id) && x.supply_name.Contains(supply_name)).Count();

            int totalrowsafterfiltering = totalrows;

            return Json(new { success = true, data = supplies, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "173")]
        [Route("phong-cdvt/danh-sach-vat-tu/add")]
        [HttpPost]
        public ActionResult Add(string supply_id, string supply_name, string unit)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            Supply s = DBContext.Supplies.Find(supply_id);
            if (supply_id.Trim()=="")
            {
                return Json(new { success = false, message = "Không được để trống trường Mã vật tư" }, JsonRequestBehavior.AllowGet);
            }
            else
             if (supply_name.Trim() == "")
            {
                return Json(new { success = false, message = "Không được để trống trường Tên vật tư" }, JsonRequestBehavior.AllowGet);
            }
            else
              if (unit.Trim() == "")
            {
                return Json(new { success = false, message = "Không được để trống trường Đơn vị" }, JsonRequestBehavior.AllowGet);
            }
            else
            if (s != null)
                return Json(new { success = false, message = "Vật tư đã tồn tại"}, JsonRequestBehavior.AllowGet);
            else
            {
                s = new Supply();
                s.supply_id = supply_id;
                s.supply_name = supply_name;
                s.unit = unit;
                DBContext.Supplies.Add(s);
                DBContext.SaveChanges();
                return Json(new { success = true, message = "Tạo loại vật tư thành công" }, JsonRequestBehavior.AllowGet);
            }
        }

        [Auther(RightID = "174")]
        [Route("phong-cdvt/danh-sach-vat-tu/delete")]
        [HttpPost]
        public ActionResult Delete(string supply_id)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            Supply s = DBContext.Supplies.Find(supply_id);
            try
            {
                DBContext.Supplies.Remove(DBContext.Supplies.Find(supply_id));
                DBContext.SaveChanges();
                return Json(new { success = true, message = "Xóa vật tư thành công" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Bạn không thể xóa vật tư này" });
            }
        }
    }
}