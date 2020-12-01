//using OfficeOpenXml;
//using QUANGHANH2.Models;
//using QUANGHANH2.SupportClass;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Linq.Dynamic;
//using System.Web.Hosting;
//using System.Web.Mvc;
//using System.Web.Routing;

//namespace QUANGHANH2.Controllers.Camera
//{
//    public class SuachuaCameraController : Controller
//    {

//        [Auther(RightID = "193")]
//        [Route("phong-cdvt/camera/quyet-dinh/sua-chua")]
//        public ActionResult Index()
//        {
//            ViewBag.count = 1;
//            return View("/Views/Camera/Quyetdinh/SuaChua/DanhSach.cshtml");
//        }

//        public class CamDocument : Documentary
//        {
//            public int count { get; set; }
//        }

//        [Route("camera/quyet-dinh-sua-chua")]
//        [HttpPost]
//        public ActionResult Search(string person_created, string dateStart, string dateEnd)
//        {
//            //Server Side Parameter
//            int start = Convert.ToInt32(Request["start"]);
//            int length = Convert.ToInt32(Request["length"]);
//            string searchValue = Request["search[value]"];
//            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//            string sortDirection = Request["order[0][dir]"];
//            List<CamDocument> documentaryList = new List<CamDocument>();
//            DateTime dtEnd;
//            DateTime dtStart;
//            try
//            {
//                if (dateStart == "") dateStart = "01/01/1900";
//                dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
//                if (dateEnd == "") dtEnd = DateTime.Now;
//                else dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
//                dtEnd = dtEnd.AddHours(23);
//                dtEnd = dtEnd.AddMinutes(59);
//            }
//            catch
//            {
//                Response.Write("Vui lòng nhập đúng ngày tháng năm");
//                return new HttpStatusCodeResult(400);
//            }
//            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

//            documentaryList = (from document in db.Documentaries
//                               where document.documentary_type == 8 && (document.documentary_code == null || document.documentary_code == "") && document.person_created.Contains(person_created) && (document.date_created >= dtStart && document.date_created <= dtEnd)
//                               join cam in db.Documentary_camera_repair_details on document.documentary_id equals cam.documentary_id
//                               into temporary
//                               select new CamDocument
//                               {
//                                   documentary_id = document.documentary_id,
//                                   documentary_code = document.documentary_code,
//                                   date_created = document.date_created,
//                                   person_created = document.person_created,
//                                   reason = document.reason,
//                                   out_in_come = document.out_in_come,
//                                   count = temporary.Select(x => x.broken_camera_quantity).Sum()
//                               }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();

//            int totalrows = (from document in db.Documentaries
//                             where document.documentary_type == 8 && (document.documentary_code == null || document.documentary_code == "") && document.person_created.Contains(person_created) && (document.date_created >= dtStart && document.date_created <= dtEnd)
//                             join cam in db.Documentary_camera_repair_details on document.documentary_id equals cam.documentary_id
//                             into temporary
//                             select new
//                             {
//                                 document.documentary_id
//                             }).Count();
//            return Json(new { success = true, data = documentaryList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
//        }


//        public void ExportExcel()
//        {
//            string path = HostingEnvironment.MapPath("/excel/CDVT/danhsachsuachua_Template.xlsx");
//            FileInfo file = new FileInfo(path);

//            using (ExcelPackage excelPackage = new ExcelPackage(file))
//            {
//                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
//                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    List<Documentary_Extend> documentaryList = (from document in db.Documentaries
//                                                                where (document.documentary_type.Equals(8) && (document.documentary_code == "" || document.documentary_code == null))
//                                                                join detail in db.Documentary_repair_details on document.documentary_id equals detail.documentary_id
//                                                                into temporary
//                                                                select new Documentary_Extend
//                                                                {
//                                                                    date_created = document.date_created,
//                                                                    documentary_code = document.documentary_code,
//                                                                    person_created = document.person_created,
//                                                                    reason = document.reason,
//                                                                    out_in_come = document.out_in_come,
//                                                                    count = temporary.Select(x => new { x.equipmentId }).Count()
//                                                                }).ToList();
//                    int k = 0;
//                    for (int i = 2; i < documentaryList.Count + 2; i++)
//                    {
//                        excelWorksheet.Cells[i, 1].Value = (k + 1);
//                        excelWorksheet.Cells[i, 2].Value = documentaryList.ElementAt(k).date_created.ToString("hh:mm tt dd/MM/yyyy");
//                        excelWorksheet.Cells[i, 3].Value = documentaryList.ElementAt(k).documentary_code;
//                        excelWorksheet.Cells[i, 4].Value = documentaryList.ElementAt(k).person_created;
//                        excelWorksheet.Cells[i, 5].Value = documentaryList.ElementAt(k).count;
//                        excelWorksheet.Cells[i, 6].Value = documentaryList.ElementAt(k).reason;
//                        excelWorksheet.Cells[i, 7].Value = documentaryList.ElementAt(k).out_in_come;
//                        k++;
//                    }
//                    string location = HostingEnvironment.MapPath("/excel/CDVT/download");
//                    excelPackage.SaveAs(new FileInfo(location + "/SuaChuaThietBi.xlsx"));
//                }
//            }
//        }
//    }
//}