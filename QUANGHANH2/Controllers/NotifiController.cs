using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANGHANH2.Models;

namespace QUANGHANH2.Controllers
{
    public class NotifiController : Controller
    {
        private QUANGHANHABCEntities db = new QUANGHANHABCEntities();
        // GET: Notifi
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CDVT()
        {
            List<main> total = new List<main>();
            var testTime = DateTime.Now.AddDays(10);
            var hanDangKiem = db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now).OrderBy(x => x.durationOfInspection).
                                    Select(x => new main
                                    {
                                        pb = "Cơ điện vận tải",
                                        title = "Mã thiết bị "+x.equipmentId,
                                        date = x.durationOfInspection
                                    }).FirstOrDefault();
            var hanBaohiem = (from equip in db.Equipments.Where(x => x.durationOfInsurance <= testTime && x.durationOfInsurance >= DateTime.Now)
                                     join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                        on equip.Equipment_category_id equals cate.Equipment_category_id
                                     select new main
                                     {
                                         pb = "Cơ điện vận tải",
                                         title = "Mã thiết bị " + equip.equipmentId,
                                         date = equip.durationOfInsurance
                                     }).OrderBy(x => x.date).FirstOrDefault();
            if (hanBaohiem != null)
            {
                TimeSpan span = hanBaohiem.date.Subtract(DateTime.Now.Date);
                hanBaohiem.remain_title = "Còn " + span.TotalDays + " ngày đến hạn bảo hiểm";
                total.Add(hanBaohiem);
            }
            if (hanDangKiem != null)
            {
                TimeSpan span = hanDangKiem.date.Subtract(DateTime.Now.Date);
                hanDangKiem.remain_title = "Còn " + span.TotalDays + " ngày đến hạn kiểm định";
                total.Add(hanDangKiem);
            }
            return Json(new { result = total}, JsonRequestBehavior.AllowGet);
        }
    }
    public class main
    {
        public string pb { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string remain_title { get; set; }
    }
}