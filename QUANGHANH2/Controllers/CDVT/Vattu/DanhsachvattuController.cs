using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Vattu
{
    public class DanhsachvattuController : Controller
    {
        readonly QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

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

            db.Configuration.LazyLoadingEnabled = false;

            var supplies = db.Supplies.Where(x => x.supply_id.Contains(supply_id) && x.supply_name.Contains(supply_name)).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();

            int totalrows = db.Supplies.Where(x => x.supply_id.Contains(supply_id) && x.supply_name.Contains(supply_name)).Count();

            return Json(new { success = true, data = supplies, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows });
        }

        [Auther(RightID = "173")]
        [Route("phong-cdvt/danh-sach-vat-tu/add")]
        [HttpPost]
        public ActionResult Add(string supply_id, string supply_name, string unit)
        {
            Supply s = db.Supplies.Find(supply_id);
            if (supply_id.Trim() == "")
            {
                return Json(new { success = false, message = "Không được để trống trường Mã vật tư" }, JsonRequestBehavior.AllowGet);
            }
            else if (supply_name.Trim() == "")
            {
                return Json(new { success = false, message = "Không được để trống trường Tên vật tư" }, JsonRequestBehavior.AllowGet);
            }
            else if (unit.Trim() == "")
            {
                return Json(new { success = false, message = "Không được để trống trường Đơn vị" }, JsonRequestBehavior.AllowGet);
            }
            else if (s != null)
                return Json(new { success = false, message = "Vật tư đã tồn tại" }, JsonRequestBehavior.AllowGet);
            else
            {
                s = new Supply
                {
                    supply_id = supply_id,
                    supply_name = supply_name,
                    unit = unit
                };
                db.Supplies.Add(s);
                db.SaveChanges();
                return Json(new { success = true, message = "Tạo loại vật tư thành công" }, JsonRequestBehavior.AllowGet);
            }
        }

        [Auther(RightID = "174")]
        [Route("phong-cdvt/danh-sach-vat-tu/delete")]
        [HttpPost]
        public ActionResult Delete(string supply_id)
        {
            Supply s = db.Supplies.Find(supply_id);
            if (s == null)
                return Json(new { success = false, message = "Vật tư không tồn tại" });
            try
            {
                db.Supplies.Remove(s);
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa vật tư thành công" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Bạn không thể xóa vật tư này" });
            }
        }
    }
}