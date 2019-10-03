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
            string query = "SELECT e.equipment_name, ei.* FROM Equipment e inner join Equipment_Inspection ei on e.equipmentId = ei.equipmentId WHERE inspect_start_date between @start_time1 and @start_time2 and ";
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
                item.stringStartTime = item.inspect_start_date.HasValue? item.inspect_start_date.Value.ToString("dd/MM/yyyy") : "";
                item.stringEndTime = item.getEndtime();
                item.updateAble = item.stringEndTime == "" ? "1" + item.inspect_id : "0" + item.inspect_id;
            }
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-cdvt/kiem-dinh/update")]
        [HttpPost]
        public ActionResult Update(string inspect_id, string dateStart, string dateEnd, string dateTemp)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    DateTime dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtTemp = DateTime.ParseExact(dateTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (DateTime.Compare(dtStart,dtEnd) > 0)
                    {
                        Response.Write("Bạn đã nhập ngày bắt đầu \nlớn hơn ngày kết thúc");
                        return new HttpStatusCodeResult(400);
                    }
                    if (DateTime.Compare(dtEnd,dtTemp) >= 0)
                    {
                        Response.Write("Bạn đã nhập ngày kiểm định sau\nnhỏ hơn hoặc bằng ngày kiểm định trước");
                        return new HttpStatusCodeResult(400);
                    }

                    Equipment_Inspection ei = DBContext.Equipment_Inspection.Find(int.Parse(inspect_id));
                    ei.inspect_start_date = dtStart;
                    ei.inspect_end_date = dtEnd;
                    Equipment_Inspection temp = new Equipment_Inspection();
                    temp.equipmentId = ei.equipmentId;
                    temp.inspect_start_date = dtTemp;
                    DBContext.Equipment_Inspection.Add(temp);

                    DBContext.SaveChanges();
                    transaction.Commit();
                    return new HttpStatusCodeResult(200);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        [Route("phong-cdvt/kiem-dinh/edit")]
        [HttpPost]
        public ActionResult Edit(string inspect_id, string dateStart, string dateEnd)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            try
            {
                DateTime dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (DateTime.Compare(dtStart, dtEnd) > 0)
                {
                    Response.Write("Bạn đã nhập ngày bắt đầu \nlớn hơn ngày kết thúc");
                    return new HttpStatusCodeResult(400);
                }
                Equipment_Inspection ei = DBContext.Equipment_Inspection.Find(int.Parse(inspect_id));
                ei.inspect_start_date = dtStart;
                ei.inspect_end_date = dtEnd;

                DBContext.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
    }
}