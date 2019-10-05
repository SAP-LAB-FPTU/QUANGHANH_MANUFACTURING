using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using QUANGHANH2.SupportClass;
using System.Data.Entity;
using System.Data.SqlClient;

namespace QUANGHANH2.Controllers.CDVT.Vattu
{
    public class DanhsachvattuController : Controller
    {
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

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            string query = "SELECT * FROM Supply";
            if (!supply_id.Equals("") || !supply_name.Equals(""))
            {
                query += " where ";
                if (!supply_id.Equals("")) query += "supply_id LIKE @supply_id AND ";
                if (!supply_name.Equals("")) query += "supply_name LIKE @supply_name AND ";
                query = query.Substring(0, query.Length - 5);
            }
            List<Supply> supplies = DBContext.Database.SqlQuery<Supply>(query,
                new SqlParameter("supply_id", '%' + supply_id + '%'),
                new SqlParameter("supply_name", '%' + supply_name + '%')).ToList();
            int totalrows = supplies.Count;
            int totalrowsafterfiltering = supplies.Count;
            //sorting
            supplies = supplies.OrderBy(sortColumnName + " " + sortDirection).ToList<Supply>();
            //paging
            supplies = supplies.Skip(start).Take(length).ToList<Supply>();
            return Json(new { success = true, data = supplies, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-cdvt/danh-sach-vat-tu/add")]
        [HttpPost]
        public ActionResult Add(string supply_id, string supply_name, string unit)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            Supply s = DBContext.Supplies.Find(supply_id);
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

        [Route("phong-cdvt/danh-sach-vat-tu/delete")]
        [HttpPost]
        public ActionResult Delete(string supply_id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
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