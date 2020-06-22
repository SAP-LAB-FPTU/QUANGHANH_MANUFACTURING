using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.DieuDong
{
    public class DanhSachController : Controller
    {
        [Auther(RightID = "30")]
        [Route("phong-cdvt/quyet-dinh/dieu-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyetdinh/DieuDong/DanhSach.cshtml");
        }

        [HttpPost]
        public ActionResult GetById(List<String> docID)
        {
            string id = docID[0];

            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                Documentary_Extend documentaryList = DBContext.Database.SqlQuery<Documentary_Extend>("Select documentary_id,documentary_code,department_id,person_created,date_created,reason, [out/in_come] as out_in_come from Documentary where documentary_id = @documentary_id", new SqlParameter("documentary_id", id)).First();
                documentaryList.tempId = id;
                documentaryList.date_created = DateTime.Now;
                ViewBag.ID = id;
                return Json(documentaryList);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        [HttpPost]
        [Auther(RightID = "30")]
        public ActionResult DeleteDoc(int docID)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Documentary doc = db.Documentaries.Where(x => x.documentary_id == docID).FirstOrDefault<Documentary>();
                db.Documentaries.Remove(doc);
                db.SaveChanges();
                Response.Write("Xóa thành công!");
                return new HttpStatusCodeResult(201);
            }
        }

        [Route("phong-cdvt/quyet-dinh/dieu-dong/search")]
        [HttpPost]
        public ActionResult Search(string documentary_code, string person_created, string dateStart, string dateEnd)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Documentary_Extend> documentaryList = new List<Documentary_Extend>();
            DateTime dtEnd;
            DateTime dtStart;
            try
            {
                if (dateStart == "") dateStart = "01/01/1900";
                dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (dateEnd == "") dtEnd = DateTime.Now;
                else dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dtEnd = dtEnd.AddHours(23);
                dtEnd = dtEnd.AddMinutes(59);
            }
            catch
            {
                Response.Write("Vui lòng nhập đúng ngày tháng năm");
                return new HttpStatusCodeResult(400);
            }
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            documentaryList = (from document in db.Documentaries
                               where document.documentary_type.Equals(3) && (document.documentary_code == "" || document.documentary_code == null) && document.person_created.Contains(person_created) && (document.date_created >= dtStart && document.date_created <= dtEnd)
                               join detail in db.Documentary_moveline_details on document.documentary_id equals detail.documentary_id
                               into temporary
                               select new
                               {
                                   document.documentary_id,
                                   document.documentary_code,
                                   document.date_created,
                                   document.person_created,
                                   document.reason,
                                   document.out_in_come,
                                   count = temporary.Select(x => new { x.equipmentId }).Count()
                               }).ToList().Select(p => new Documentary_Extend
                               {
                                   documentary_id = p.documentary_id,
                                   documentary_code = p.documentary_code,
                                   date_created = p.date_created,
                                   person_created = p.person_created,
                                   reason = p.reason,
                                   out_in_come = p.out_in_come,
                                   count = p.count
                               }).ToList();

            foreach (var el in documentaryList)
            {
                if (el.documentary_code == null || el.documentary_code.Equals(""))
                {
                    el.tempId = el.documentary_id + "^false";
                }
                else
                {
                    el.tempId = el.documentary_id + "^true^" + el.documentary_code;
                }
            }

            int totalrows = documentaryList.Count;
            int totalrowsafterfiltering = documentaryList.Count;
            //sorting
            documentaryList = documentaryList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_Extend>();
            //paging
            documentaryList = documentaryList.Skip(start).Take(length).ToList<Documentary_Extend>();

            return Json(new { success = true, data = documentaryList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "38")]
        [Route("phong-cdvt/quyet-dinh/dieu-dong/export")]
        public ActionResult ExportExcel()
        {
            string fileName = HostingEnvironment.MapPath("/excel/CDVT/danhsachsuachua_Template.xlsx");
            byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
            using (var stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    List<Documentary_Export> documentaryList = (from document in db.Documentaries
                                                                where (document.documentary_type.Equals(3) && (document.documentary_code == "" || document.documentary_code == null))
                                                                join detail in db.Documentary_moveline_details on document.documentary_id equals detail.documentary_id
                                                                into temporary
                                                                select new Documentary_Export
                                                                {
                                                                    date_created = document.date_created,
                                                                    documentary_code = document.documentary_code,
                                                                    person_created = document.person_created,
                                                                    reason = document.reason,
                                                                    out_in_come = document.out_in_come,
                                                                    count = temporary.Select(x => new { x.equipmentId }).Count()
                                                                }).ToList();
                        int k = 0;
                        for (int i = 2; i < documentaryList.Count + 2; i++)
                        {
                            excelWorksheet.Cells[i, 1].Value = (k + 1);
                            excelWorksheet.Cells[i, 2].Value = documentaryList.ElementAt(k).date_created.ToString("hh:mm tt dd/MM/yyyy");
                            excelWorksheet.Cells[i, 3].Value = documentaryList.ElementAt(k).documentary_code;
                            excelWorksheet.Cells[i, 4].Value = documentaryList.ElementAt(k).person_created;
                            excelWorksheet.Cells[i, 5].Value = documentaryList.ElementAt(k).count;
                            excelWorksheet.Cells[i, 6].Value = documentaryList.ElementAt(k).reason;
                            excelWorksheet.Cells[i, 7].Value = documentaryList.ElementAt(k).out_in_come;
                            k++;
                        }

                        stream.Position = 0;
                        string handle = Guid.NewGuid().ToString();
                        TempData[handle] = excelPackage.GetAsByteArray();

                        if (TempData[handle] != null)
                        {
                            byte[] output = TempData[handle] as byte[];
                            return File(output, "application/vnd.ms-excel", $"DieuDongThietBi.xlsx");
                        }
                        else
                        {
                            return new HttpStatusCodeResult(400);
                        }
                    }
                }
            }
        }
    }
}