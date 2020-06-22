using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.TrungDaiTu
{
    public class DanhSachController : Controller
    {
        [Auther(RightID = "42")]
        [Route("phong-cdvt/quyet-dinh/trung-dai-tu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyetdinh/TrungDaiTu/DanhSach.cshtml");
        }

        [Route("phong-cdvt/quyet-dinh/trung-dai-tu")]
        [HttpPost]
        public ActionResult Search(string person_created, string dateStart, string dateEnd)
        {
            //Server Side Parameter
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
                               where document.documentary_type.Equals(6) && (document.documentary_code == null || document.documentary_code == "") && document.person_created.Contains(person_created) && (document.date_created >= dtStart && document.date_created <= dtEnd)
                               join detail in db.Documentary_big_maintain_details on document.documentary_id equals detail.documentary_id
                               into temporary
                               select new Documentary_Extend
                               {
                                   documentary_id = document.documentary_id,
                                   date_created = document.date_created,
                                   person_created = document.person_created,
                                   reason = document.reason,
                                   out_in_come = document.out_in_come,
                                   count = temporary.Select(x => new { x.equipmentId }).Count()
                               }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
            int totalrows = (from document in db.Documentaries
                             where document.documentary_type.Equals(1) && (document.documentary_code == null || document.documentary_code == "") && document.person_created.Contains(person_created) && (document.date_created >= dtStart && document.date_created <= dtEnd)
                             join detail in db.Documentary_big_maintain_details on document.documentary_id equals detail.documentary_id
                             into temporary
                             select new Documentary_Extend
                             {
                                 documentary_id = document.documentary_id,
                                 date_created = document.date_created,
                                 person_created = document.person_created,
                                 reason = document.reason,
                                 out_in_come = document.out_in_come,
                                 count = temporary.Select(x => new { x.equipmentId }).Count()
                             }).Count();

            return Json(new { success = true, data = documentaryList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "42")]
        [Route("phong-cdvt/quyet-dinh/trung-dai-tu/export")]
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
                                                                    where (document.documentary_type.Equals(6) && (document.documentary_code == "" || document.documentary_code == null))
                                                                    join detail in db.Documentary_big_maintain_details on document.documentary_id equals detail.documentary_id
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
                            return File(output, "application/vnd.ms-excel", $"TrungDaiTuThietBi.xlsx");
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