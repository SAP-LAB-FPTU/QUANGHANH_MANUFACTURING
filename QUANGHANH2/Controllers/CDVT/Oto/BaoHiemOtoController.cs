using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT.Oto
{
    public class BaoHiemOtoController : Controller
    {
        [Auther(RightID = "24")]
        [Route("phong-cdvt/oto/bao-hiem")]
        [HttpGet]
        public ActionResult Index()
        {
            //  Bảo hiểm và kiểm định là 1
            return View("/Views/CDVT/Car/BaoHiemOto.cshtml");
        }

        [Route("phong-cdvt/oto/bao-hiem")]
        [HttpPost]
        public ActionResult AdvanceSearch(string equipmentId, string equipmentName, string dateStart, string dateEnd)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            DateTime dtStart = dateStart.Equals("") ? DateTime.ParseExact("01/01/1753", "MM/dd/yyyy", null) : DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            DateTime dtEnd = dateEnd.Equals("") ? DateTime.MaxValue : DateTime.ParseExact(dateEnd, "dd/MM/yyyy", null);
            var list = (from ei in db.Equipment_Insurance.GroupBy(x => x.equipmentId).Select(x => new
            {
                equipmentId = x.Key,
                insurance_end_date = x.Max(row => row.insurance_end_date)
            })
                        where ei.insurance_end_date >= dtStart && ei.insurance_end_date <= dtEnd
                        join ei2 in db.Equipment_Insurance on ei.equipmentId equals ei2.equipmentId
                        where ei2.insurance_end_date == ei.insurance_end_date
                        join c in db.Cars.Where(c => c.equipmentId.Contains(equipmentId)) on ei.equipmentId equals c.equipmentId
                        join e in db.Equipments.Where(e => e.equipment_name.Contains(equipmentName)) on ei.equipmentId equals e.equipmentId
                        join s in db.Status on e.current_Status equals s.statusid
                        select new
                        {
                            ei.equipmentId,
                            ei.insurance_end_date,
                            ei2.insurance_id,
                            ei2.insurance_start_date,
                            s.statusname,
                            e.equipment_name
                        }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList().Select(p => new Equipment_InsuranceDB
                        {
                            equipmentId = p.equipmentId,
                            equipment_name = p.equipment_name,
                            insurance_end_date = p.insurance_end_date,
                            insurance_id = p.insurance_id,
                            statusname = p.statusname,
                            stringEndDate = p.insurance_end_date.ToString("dd/MM/yyyy"),
                            stringStartDate = p.insurance_start_date.ToString("dd/MM/yyyy")
                        }).ToList();
            int totalrows = (from ei in db.Equipment_Insurance.GroupBy(x => x.equipmentId).Select(x => x.FirstOrDefault())
                             where ei.insurance_end_date >= dtStart && ei.insurance_end_date <= dtEnd
                             join c in db.Cars.Where(c => c.equipmentId.Contains(equipmentId)) on ei.equipmentId equals c.equipmentId
                             join e in db.Equipments.Where(e => e.equipment_name.Contains(equipmentName)) on ei.equipmentId equals e.equipmentId
                             join s in db.Status on e.current_Status equals s.statusid
                             select ei).Count();
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "171")]
        [Route("phong-cdvt/oto/bao-hiem/add")]
        [HttpPost]
        public ActionResult Edit(string equipmentId, string stringStartDate, string stringEndDate)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Equipment e = db.Equipments.Find(equipmentId);
                    DateTime start = DateTime.ParseExact(stringStartDate, "dd/MM/yyyy", null);
                    DateTime end = DateTime.ParseExact(stringEndDate, "dd/MM/yyyy", null);
                    if (e == null)
                        return Json(new { success = false, message = "Thiết bị không tồn tại" });
                    if (DateTime.Compare(start, end) >= 0)
                        return Json(new { success = false, message = "Ngày mua phải nhỏ hơn ngày hết hạn" });

                    Equipment_Insurance temp = new Equipment_Insurance
                    {
                        equipmentId = equipmentId,
                        insurance_start_date = start,
                        insurance_end_date = end,
                    };
                    db.Equipment_Insurance.Add(temp);
                    e.insurance_date = temp.insurance_start_date;
                    e.durationOfInsurance = temp.insurance_end_date;
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Cập nhật thành công" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra\nxin vui lòng thử lại" });
            }
        }
    }
}