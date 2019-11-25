using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
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

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime dtStart = dateStart.Equals("") ? DateTime.MinValue : DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            DateTime dtEnd = dateStart.Equals("") ? DateTime.MaxValue : DateTime.ParseExact(dateEnd, "dd/MM/yyyy", null);
            var list = (from ei in DBContext.Equipment_Insurance.GroupBy(x => x.equipmentId).Select(x => new
            {
                equipmentId = x.Key,
                insurance_end_date = x.Max(row => row.insurance_end_date)
            })
                        where ei.insurance_end_date >= dtStart && ei.insurance_end_date <= dtEnd
                        join ei2 in DBContext.Equipment_Insurance on ei.equipmentId equals ei2.equipmentId
                        where ei2.insurance_end_date == ei.insurance_end_date
                        join e in DBContext.Equipments.Where(e => e.equipmentId.Contains(equipmentId) && e.equipment_name.Contains(equipmentName)) on ei.equipmentId equals e.equipmentId
                        join s in DBContext.Status on e.current_Status equals s.statusid
                        select new
                        {
                            ei.equipmentId,
                            ei2.insurance_start_date,
                            ei.insurance_end_date,
                            ei2.insurance_id,
                            s.statusname,
                            e.equipment_name
                        }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList().Select(p => new Equipment_InsuranceDB
                        {
                            equipmentId = p.equipmentId,
                            equipment_name = p.equipment_name,
                            insurance_start_date = p.insurance_start_date,
                            insurance_end_date = p.insurance_end_date,
                            insurance_id = p.insurance_id,
                            statusname = p.statusname
                        }).ToList<Equipment_InsuranceDB>();
            int totalrows = (from ei in DBContext.Equipment_Insurance.GroupBy(x => x.equipmentId).Select(x => x.FirstOrDefault())
                             where ei.insurance_end_date >= dtStart && ei.insurance_end_date <= dtEnd
                             join e in DBContext.Equipments.Where(e => e.equipmentId.Contains(equipmentId) && e.equipment_name.Contains(equipmentName)) on ei.equipmentId equals e.equipmentId
                             join s in DBContext.Status on e.current_Status equals s.statusid
                             select ei).Count();
            int totalrowsafterfiltering = totalrows;
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "171")]
        [Route("phong-cdvt/oto/bao-hiem/add")]
        [HttpPost]
        public ActionResult Edit(string equipmentId, string dateTemp)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            try
            {
                Equipment_Insurance temp = new Equipment_Insurance();
                temp.equipmentId = equipmentId;
                temp.insurance_start_date = DateTime.Now;
                temp.insurance_end_date = DateTime.ParseExact(dateTemp, "dd/MM/yyyy", null);
                DBContext.Equipment_Insurance.Add(temp);
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