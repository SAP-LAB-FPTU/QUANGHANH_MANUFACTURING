using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT.Thietbi
{
    public class KiemdinhController : Controller
    {
        [Route("phong-cdvt/kiem-dinh")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Thietbi/Kiemdinh.cshtml");
        }

        [Route("phong-cdvt/kiem-dinh")]
        [HttpPost]
        public ActionResult GetData(string equipmentId, string equipmentName, string dateStart, string dateEnd)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtEnd = dtEnd.AddHours(23);
            dtEnd = dtEnd.AddMinutes(59);
            string query = "SELECT ei.*, e.equipment_name, s.statusname FROM Equipment_Inspection ei INNER JOIN Equipment e on e.equipmentId = ei.equipmentId INNER JOIN Status s on s.statusid = e.current_Status WHERE ei.inspect_end_date IS NULL AND inspect_expected_date between @start_time1 and @start_time2 and ";
            if (!equipmentId.Equals("") || !equipmentName.Equals(""))
            {
                if (!equipmentId.Equals("")) query += "ei.equipmentId LIKE @equipmentId AND ";
                if (!equipmentName.Equals("")) query += "e.equipment_name LIKE @equipment_name AND ";
            }
            query = query.Substring(0, query.Length - 5);
            List<Equipment_InspectionDB> list = DBContext.Database.SqlQuery<Equipment_InspectionDB>(query,
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd)).ToList();
            int totalrows = list.Count;
            int totalrowsafterfiltering = list.Count;
            //sorting
            list = list.OrderBy(sortColumnName + " " + sortDirection).ToList<Equipment_InspectionDB>();
            //paging
            list = list.Skip(start).Take(length).ToList<Equipment_InspectionDB>();
            foreach (Equipment_InspectionDB item in list)
            {
                item.stringExpectedTime = item.inspect_expected_date.ToString("dd/MM/yyyy");
                item.stringStartTime = item.getStringtime(item.inspect_start_date);
                item.updateAble = item.stringStartTime == "" ? "1" + item.inspect_id : "0" + item.inspect_id;
            }
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-cdvt/kiem-dinh/update")]
        [HttpPost]
        public ActionResult Update(string inspect_id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Equipment_Inspection ei = DBContext.Equipment_Inspection.Find(int.Parse(inspect_id));
                    ei.inspect_start_date = DateTime.Now;
                    Equipment e = DBContext.Equipments.Find(ei.equipmentId);
                    e.current_Status = 10;
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Cập nhật thành công"}, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra\nxin vui lòng thử lại" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [Route("phong-cdvt/kiem-dinh/edit")]
        [HttpPost]
        public ActionResult Edit(string inspect_id, string dateTemp)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            try
            {
                Equipment_Inspection ei = DBContext.Equipment_Inspection.Find(int.Parse(inspect_id));
                DateTime dtTemp = DateTime.ParseExact(dateTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ei.inspect_end_date = DateTime.Now;
                Equipment e = DBContext.Equipments.Find(ei.equipmentId);
                e.current_Status = 1;
                Equipment_Inspection temp = new Equipment_Inspection();
                temp.equipmentId = ei.equipmentId;
                temp.inspect_expected_date = dtTemp;
                DBContext.Equipment_Inspection.Add(temp);
                DBContext.SaveChanges();
                return Json(new { success = true, message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra\nxin vui lòng thử lại" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}