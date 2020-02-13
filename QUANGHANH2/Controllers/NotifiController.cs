using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;

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
                                        type = 0,
                                        pb = "Cơ điện vận tải",
                                        title = "Mã thiết bị " + x.equipmentId,
                                        name = x.equipment_name,
                                        date = x.durationOfInspection.Value
                                    }).FirstOrDefault();
            var hanBaohiem = (from equip in db.Equipments.Where(x => x.durationOfInsurance <= testTime && x.durationOfInsurance >= DateTime.Now)
                              join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                 on equip.Equipment_category_id equals cate.Equipment_category_id
                              select new main
                              {
                                  type = 1,
                                  pb = "Cơ điện vận tải",
                                  title = "Mã thiết bị " + equip.equipmentId,
                                  name = equip.equipment_name,
                                  date = equip.durationOfInsurance.Value
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
            return Json(new { result = total }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult notifiSC()
        {
            var sc = db.Notifications.Where(x => x.isread == false && x.description == "su co").ToList();
            noti ins = new noti();
            ins.text = "";
            ins.title = "Thông báo sự cố";
            if(sc.Count != 0)
            {
                List<int> ints = new List<int>();
                foreach(Notification i in sc)
                {
                    ints.Add(i.id_noti);
                }
                ins.text = "Có " + sc.Count + " sự cố mới được nhập.";
                ins.id = ints;
            }

            return Json(ins, JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateStatus(string id)
        {
            try
            {
                foreach(var r in id.Split(','))
                {
                    int i = int.Parse(r);
                    var up = db.Notifications.Where(x => x.id_noti == i).SingleOrDefault();
                    up.isread = true;
                    db.Entry(up).State = EntityState.Modified;
                }
                db.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Export(int type)
        {
            string path = HostingEnvironment.MapPath("/excel/Notifi/ThongbaoCDVT.xlsx");
            string saveAsPath = ("/excel/CDVT/download/ThongbaoCDVT.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var testTime = DateTime.Now.AddDays(10);
                    if (type == 0)
                    {
                        var maintitle = db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now).OrderBy(x => x.durationOfInspection).
                                                Select(x => new main
                                                {
                                                    type = 0,
                                                    pb = "Cơ điện vận tải",
                                                    title = x.equipmentId,
                                                    name = x.equipment_name,
                                                    date = x.durationOfInspection.Value
                                                }).ToList().Distinct();
                        foreach(main item in maintitle)
                        {
                            TimeSpan span = item.date.Subtract(DateTime.Now.Date);
                            item.remain_title = span.TotalDays.ToString()+" ngày";
                        }
                        excelWorksheet.Cells[1,5].Value = "Danh sách thiết bị đến hạn kiểm định";
                        excelWorksheet.Cells[2, 7].Value = "Ngày hết hạn kiểm định";
                        int k = 3;
                        List<main> oop = maintitle.ToList();
                        for (int i = 0; i < oop.Count; i++)
                        {
                            excelWorksheet.Cells[k, 5].Value = oop.ElementAt(i).title;
                            excelWorksheet.Cells[k, 6].Value = oop.ElementAt(i).name;
                            excelWorksheet.Cells[k, 7].Value = oop.ElementAt(i).date;
                            excelWorksheet.Cells[k, 8].Value = oop.ElementAt(i).remain_title;
                            k++;
                        }
                    }
                    else
                    {
                        var maintitle = (from equip in db.Equipments.Where(x => x.durationOfInsurance <= testTime && x.durationOfInsurance >= DateTime.Now)
                                                 join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                                    on equip.Equipment_category_id equals cate.Equipment_category_id
                                                 select new main
                                                 {
                                                     type = 1,
                                                     pb = "Cơ điện vận tải",
                                                     title = equip.equipmentId,
                                                     name = equip.equipment_name,
                                                     date = equip.durationOfInsurance.Value
                                                 }).OrderBy(x => x.date).ToList();
                        foreach (main item in maintitle)
                        {
                            TimeSpan span = item.date.Subtract(DateTime.Now.Date);
                            item.remain_title = span.TotalDays.ToString() + " ngày";
                        }
                        excelWorksheet.Cells[1,5].Value = "Danh sách thiết bị đến hạn bảo hiểm";
                        excelWorksheet.Cells[2,7].Value = "Ngày hết hạn bảo hiểm";
                        int k = 3;
                        List<main> oop = maintitle.ToList();
                        for (int i = 0; i < oop.Count; i++)
                        {
                            excelWorksheet.Cells[k, 5].Value = oop.ElementAt(i).title;
                            excelWorksheet.Cells[k, 6].Value = oop.ElementAt(i).name;
                            excelWorksheet.Cells[k, 7].Value = oop.ElementAt(i).date;
                            excelWorksheet.Cells[k, 8].Value = oop.ElementAt(i).remain_title;
                            k++;
                        }
                    }

                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            return Redirect(saveAsPath);
        }
    }
    public class main
    {
        public int type { get; set; }
        public string pb { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string remain_title { get; set; }
    }
    public class noti
    {
        public List<int> id { get; set; }
        public string text { get; set; }
        public string title { get; set; }
    }
}

