using System;
using System.Web.Mvc;
using QUANGHANH_MANUFACTURING.Models;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Oto
{
    public class BaoHiemOtoController : Controller
    {
        [Auther(RightID = "24")]
        [Route("phong-cdvt/oto/bao-hiem")]
        [HttpGet]
        public ActionResult Index()
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            ViewBag.equipmentId = db.Cars.Select(x => x.equipmentId).ToList();
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

            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            DateTime dtStart = dateStart.Equals("") ? DateTime.ParseExact("01/01/1753", "MM/dd/yyyy", null) : DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            DateTime dtEnd = dateEnd.Equals("") ? DateTime.MaxValue : DateTime.ParseExact(dateEnd, "dd/MM/yyyy", null);
            var list = (from a in db.Equipment_Insurance
                        group a by a.equipmentId into ei
                        join ei2 in db.Equipment_Insurance on ei.Max(s => s.insurance_id) equals ei2.insurance_id
                        where ei2.insurance_end_date >= dtStart && ei2.insurance_end_date <= dtEnd
                        join c in db.Cars.Where(c => c.equipmentId.Contains(equipmentId)) on ei2.equipmentId equals c.equipmentId
                        join e in db.Equipments.Where(e => e.equipment_name.Contains(equipmentName)) on ei2.equipmentId equals e.equipmentId
                        join s in db.Status on e.current_Status equals s.statusid
                        select new Equipment_InsuranceDB
                        {
                            equipmentId = ei2.equipmentId,
                            equipment_name = e.equipment_name,
                            insurance_id = ei2.insurance_id,
                            statusname = s.statusname,
                            insurance_start_date = ei2.insurance_start_date,
                            insurance_end_date = ei2.insurance_end_date,
                        }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
            int totalrows = (from a in db.Equipment_Insurance
                             group a by a.equipmentId into ei
                             join ei2 in db.Equipment_Insurance on ei.Max(s => s.insurance_id) equals ei2.insurance_id
                             where ei2.insurance_end_date >= dtStart && ei2.insurance_end_date <= dtEnd
                             join c in db.Cars.Where(c => c.equipmentId.Contains(equipmentId)) on ei2.equipmentId equals c.equipmentId
                             join e in db.Equipments.Where(e => e.equipment_name.Contains(equipmentName)) on ei2.equipmentId equals e.equipmentId
                             join s in db.Status on e.current_Status equals s.statusid
                             select new Equipment_InsuranceDB
                             {
                                 equipmentId = ei2.equipmentId,
                                 equipment_name = e.equipment_name,
                                 insurance_id = ei2.insurance_id,
                                 statusname = s.statusname,
                                 insurance_start_date = ei2.insurance_start_date,
                                 insurance_end_date = ei2.insurance_end_date,
                             }).Count();
            foreach (var item in list)
            {
                item.stringStartDate = item.insurance_start_date.ToString("dd/MM/yyyy");
                item.stringEndDate = item.insurance_end_date.ToString("dd/MM/yyyy");
            }
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "171")]
        [Route("phong-cdvt/oto/bao-hiem/add")]
        [HttpPost]
        public ActionResult Add(string equipmentId, string stringStartDate, string stringEndDate)
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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

        [Auther(RightID = "171")]
        [Route("phong-cdvt/oto/bao-hiem/edit")]
        [HttpPost]
        public ActionResult Edit(string insurance_id, string stringStartDate, string stringEndDate)
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    Equipment_Insurance ei = db.Equipment_Insurance.Find(insurance_id);
                    DateTime start = DateTime.ParseExact(stringStartDate, "dd/MM/yyyy", null);
                    DateTime end = DateTime.ParseExact(stringEndDate, "dd/MM/yyyy", null);
                    if (ei == null)
                        return Json(new { success = false, message = "Lịch sử không tồn tại" });
                    if (DateTime.Compare(start, end) >= 0)
                        return Json(new { success = false, message = "Ngày mua phải nhỏ hơn ngày hết hạn" });

                    ei.insurance_start_date = start;
                    ei.insurance_end_date = end;
                    ei.Equipment.insurance_date = start;
                    ei.Equipment.durationOfInsurance = end;
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Chỉnh sửa thành công" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra\nxin vui lòng thử lại" });
            }
        }
    }
}