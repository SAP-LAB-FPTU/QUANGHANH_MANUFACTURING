//using QUANGHANH2.Models;
//using QUANGHANH2.SupportClass;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.SqlClient;
//using System.Globalization;
//using System.Linq;
//using System.Linq.Dynamic;
//using System.Web;
//using System.Web.Mvc;

//namespace QUANGHANH2.Controllers.CDVT.Thietbi
//{
//    public class KiemdinhController : Controller
//    {
//        [Auther(RightID = "24")]
//        [Route("phong-cdvt/kiem-dinh")]
//        [HttpGet]
//        public ActionResult Index()
//        {
//            return View("/Views/CDVT/Thietbi/Kiemdinh.cshtml");
//        }

//        [Route("phong-cdvt/kiem-dinh")]
//        [HttpPost]
//        public ActionResult GetData(string equipmentId, string equipmentName, string dateStart, string dateEnd)
//        {
//            //Server Side Parameter
//            int start = Convert.ToInt32(Request["start"]);
//            int length = Convert.ToInt32(Request["length"]);
//            string searchValue = Request["search[value]"];
//            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//            string sortDirection = Request["order[0][dir]"];

//            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
//            DateTime dtStart = dateStart.Equals("") ? DateTime.ParseExact("01/01/1753", "MM/dd/yyyy", null) : DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
//            DateTime dtEnd = dateEnd.Equals("") ? DateTime.ParseExact("12/31/9999", "MM/dd/yyyy", null) : DateTime.ParseExact(dateEnd, "dd/MM/yyyy", null);
//            var list = (from ei in DBContext.Equipment_Inspection.GroupBy(x => x.equipmentId).Select(x => new
//            {
//                equipmentId = x.Key,
//                inspect_date = x.Max(row => row.inspect_date)
//            })
//                        where ei.inspect_date >= dtStart && ei.inspect_date <= dtEnd
//                        join ei2 in DBContext.Equipment_Inspection on ei.equipmentId equals ei2.equipmentId
//                        where ei2.inspect_date == ei.inspect_date
//                        join e in DBContext.Equipments.Where(e => e.equipmentId.Contains(equipmentId) && e.equipment_name.Contains(equipmentName)) on ei.equipmentId equals e.equipmentId
//                        join s in DBContext.Status on e.current_Status equals s.statusid
//                        select new
//                        {
//                            ei.equipmentId,
//                            ei.inspect_date,
//                            ei2.inspect_id,
//                            s.statusname,
//                            e.equipment_name
//                        }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList().Select(p => new Equipment_InspectionDB
//                        {
//                            equipmentId = p.equipmentId,
//                            equipment_name = p.equipment_name,
//                            inspect_date = p.inspect_date,
//                            inspect_id = p.inspect_id,
//                            statusname = p.statusname,
//                            stringExpectedTime = p.inspect_date.ToString("dd/MM/yyyy")
//                        }).ToList<Equipment_InspectionDB>();
//            int totalrows = (from ei in DBContext.Equipment_Inspection.GroupBy(x => x.equipmentId).Select(x => x.FirstOrDefault())
//                             where ei.inspect_date >= dtStart && ei.inspect_date <= dtEnd
//                             join e in DBContext.Equipments.Where(e => e.equipmentId.Contains(equipmentId) && e.equipment_name.Contains(equipmentName)) on ei.equipmentId equals e.equipmentId
//                             join s in DBContext.Status on e.current_Status equals s.statusid
//                             select ei).Count();
//            int totalrowsafterfiltering = totalrows;
//            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
//        }

//        [Auther(RightID = "171")]
//        [Route("phong-cdvt/kiem-dinh/add")]
//        [HttpPost]
//        public ActionResult Add(int inspect_id, string dateTemp)
//        {
//            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
//            try
//            {
//                Equipment_Inspection ei = DBContext.Equipment_Inspection.Find(inspect_id);
//                DateTime dtTemp = DateTime.ParseExact(dateTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture);
//                ei.inspect_date = DateTime.Now;
//                Equipment e = DBContext.Equipments.Find(ei.equipmentId);
//                Equipment_Inspection temp = new Equipment_Inspection
//                {
//                    equipmentId = ei.equipmentId,
//                    inspect_date = dtTemp
//                };
//                DBContext.Equipment_Inspection.Add(temp);
//                e.durationOfInspection = dtTemp;
//                DBContext.SaveChanges();
//                return Json(new { success = true, message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception)
//            {
//                return Json(new { success = false, message = "Có lỗi xảy ra\nxin vui lòng thử lại" }, JsonRequestBehavior.AllowGet);
//            }
//        }
//    }
//}