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

namespace QUANGHANH2.Controllers.Camera.Quyetdinh.SuaChua
{
    public class DanhSachController : Controller
    {

        [Auther(RightID = "193")]
        [Route("phong-cdvt/quyet-dinh")]
        public ActionResult Index()
        {
            ViewBag.count = 1;
            return View("/Views/Camera/Quyetdinh/SuaChua/DanhSach.cshtml");
        }

        [Route("camera/quyet-dinh-sua-chua")]
        [HttpPost]
        public ActionResult Search(string person_created, string dateStart)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            DateTime dtStart_0 = new DateTime();
            DateTime dtStart_1 = new DateTime();

            if (dateStart.Contains("-"))
            {
                var temp = dateStart.Split('-');
                dtStart_0 = DateTime.ParseExact(temp[0].Trim(), "dd/MM/yyyy", null);
                dtStart_1 = DateTime.ParseExact(temp[1].Trim(), "dd/MM/yyyy", null).AddDays(1);
            }
            else if (!string.IsNullOrEmpty(dateStart))
            {
                dtStart_0 = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
                dtStart_1 = dtStart_0.AddDays(1);
            }

            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

            var documentaryList = (from document in db.Documentaries join type in db.DocumentaryTypes on document.documentary_type equals type.documentary_type
                               where (document.documentary_code == null || document.documentary_code == "") 
                               && document.person_created.Contains(person_created)
                               && (string.IsNullOrEmpty(dateStart) || (document.date_created >= dtStart_0 && document.date_created < dtStart_1))
                               select new
                               {
                                   document.documentary_id,
                                   document.documentary_code,
                                   document.date_created,
                                   document.person_created,
                                   document.reason,
                                   document.out_income,
                                   document.documentary_type,
                                   type.documentary_name
                               }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();

            int totalrows = (from document in db.Documentaries
                             where (document.documentary_code == null || document.documentary_code == "")
                             && document.person_created.Contains(person_created)
                             && (string.IsNullOrEmpty(dateStart) || (document.date_created >= dtStart_0 && document.date_created < dtStart_1))
                             select document).Count();
            return Json(new { success = true, data = documentaryList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }


        public void ExportExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/danhsachsuachua_Template.xlsx");
            FileInfo file = new FileInfo(path);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    List<Documentary_Extend> documentaryList = (from document in db.Documentaries
                                                                where (document.documentary_type.Equals(8) && (document.documentary_code == "" || document.documentary_code == null))
                                                                join detail in db.CameraRepairDetails on document.documentary_id equals detail.documentary_id
                                                                into temporary
                                                                select new Documentary_Extend
                                                                {
                                                                    date_created = document.date_created,
                                                                    documentary_code = document.documentary_code,
                                                                    person_created = document.person_created,
                                                                    reason = document.reason,
                                                                    out_income = document.out_income,
                                                                    count = temporary.Select(x => new { x.broken_camera_quantity }).Sum(x => x.broken_camera_quantity)
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
                        excelWorksheet.Cells[i, 7].Value = documentaryList.ElementAt(k).out_income;
                        k++;
                    }
                    string location = HostingEnvironment.MapPath("/excel/CDVT/download");
                    excelPackage.SaveAs(new FileInfo(location + "/SuaChuaThietBi.xlsx"));
                }
            }
        }
    }
}