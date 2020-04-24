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

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class suachuaQDController : Controller
    {
        [Auther(RightID = "30")]
        [Route("phong-cdvt/quyet-dinh/sua-chua")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyetdinh/SuaChua/DanhSach.cshtml");
        }

        [Route("phong-cdvt/quyet-dinh/sua-chua")]
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
                             where document.documentary_type.Equals(1) && (document.documentary_code == null || document.documentary_code == "") && document.person_created.Contains(person_created) && (document.date_created >= dtStart && document.date_created <= dtEnd)
                             join detail in db.Documentary_repair_details on document.documentary_id equals detail.documentary_id
                             into temporary
                             select new
                             {
                                 documentary_id = document.documentary_id,
                                 documentary_code = document.documentary_code,
                                 date_created = document.date_created,
                                 person_created = document.person_created,
                                 reason = document.reason,
                                 out_in_come = document.out_in_come,
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

            //}


            int totalrows = documentaryList.Count;
            int totalrowsafterfiltering = documentaryList.Count;
            //sorting
            documentaryList = documentaryList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_Extend>();
            //paging
            documentaryList = documentaryList.Skip(start).Take(length).ToList<Documentary_Extend>();

            return Json(new { success = true, data = documentaryList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }


        public void ExportExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/danhsachsuachua_Template.xlsx");
            FileInfo file = new FileInfo(path);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    List<Documentary_Extend> documentaryList = (from document in db.Documentaries
                                                          where (document.documentary_type.Equals(1) && (document.documentary_code == "" || document.documentary_code == null))
                                                          join detail in db.Documentary_repair_details on document.documentary_id equals detail.documentary_id
                                                          into temporary
                                                          select new
                                                          {
                                                              date_created = document.date_created,
                                                              documentary_code = document.documentary_code,
                                                              person_created = document.person_created,
                                                              reason = document.reason,
                                                              out_in_come = document.out_in_come,
                                                              count = temporary.Select(x => new { x.equipmentId }).Count()
                                                          }).ToList().Select(p => new Documentary_Extend
                                                          {
                                                              date_created = p.date_created,
                                                              documentary_code = p.documentary_code,
                                                              person_created = p.person_created,
                                                              reason = p.reason,
                                                              out_in_come = p.out_in_come,
                                                              count = p.count
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
                    string location = HostingEnvironment.MapPath("/excel/CDVT/download");
                    excelPackage.SaveAs(new FileInfo(location + "/SuaChuaThietBi.xlsx"));
                }

            }

        }
    }
}