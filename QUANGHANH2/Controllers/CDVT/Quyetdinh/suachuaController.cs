using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class suachuaController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/sua-chua")]
        public ActionResult Index()
        {
            ViewBag.count = 1;
            return View("/Views/CDVT/Quyet_dinh/Quyet_dinh_sua_chua.cshtml");
        }
        [Route("phong-cdvt/quyet-dinh/sua-chua")]
        [HttpPost]
        public ActionResult GetData()
        {

            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<NewDocumentary> documentariesList = (from document in db.Documentaries
                                                       join detail in db.Documentary_Inspection_details
                                               on document.documentary_id equals detail.documentary_id
                                               into temporary
                                                       select new
                                                       {
                                                           documentary_id = document.documentary_id,
                                                           date_created = document.date_created,
                                                           person_created = document.person_created,
                                                           reason = document.reason,
                                                           out_in_come = document.out_in_come,
                                                           count = temporary.Select(x => new { x.equipmentId }).Count()
                                                       }).ToList().Select(p => new NewDocumentary
                                                       {
                                                           documentary_id = p.documentary_id,
                                                           date_created = p.date_created,
                                                           person_created = p.person_created,
                                                           reason = p.reason,
                                                           out_in_come = p.out_in_come,
                                                           count = p.count
                                                       }).ToList();

                int totalrows = documentariesList.Count;
                int totalrowsafterfiltering = documentariesList.Count;
                //sorting
                documentariesList = documentariesList.OrderBy(sortColumnName + " " + sortDirection).ToList<NewDocumentary>();
                //paging
                documentariesList = documentariesList.Skip(start).Take(length).ToList<NewDocumentary>();
                return Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        public ActionResult ABC(NewDocumentary doc)
        {
            return Edit(doc);
        }

        [HttpPost]
        public ActionResult Edit(NewDocumentary doc)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //while (true)
                //{
                //    try
                //    {
                //db.Documentaries.Where(x => x.documentary_id == doc.tempId).UpdatFromQuery(x => new Documentary { IsActive = false });
                //  db.Entry(doc).State = EntityState.Modified;
                var query = "Update Documentary set documentary_id = '" + doc.tempId + "', date_created = '" + doc.date_created + "' ,person_created = '" + doc.person_created + "',reason = '" + doc.reason + "',  [out/in_come] = '" + doc.out_in_come + "' where documentary_id = '" + doc.documentary_id + "'";

                db.Database.ExecuteSqlCommand(query);

                //        break;
                //    }
                //    catch (Exception e)
                //    {

                //    }
                //}


                // db.SaveChanges();
                return RedirectToAction("GetData");
            }
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var query = db.Documentaries.SqlQuery("Select doc.reason,doc.documentary_id, doc.date_created,doc.person_created,doc.[out/in_come] as out_in_come,doc.documentary_status from Documentary doc where documentary_id = '" + id + "'").FirstOrDefault<Documentary>();
                ViewBag.DocID = id;
                query.tempId = id;
                //   return View(db.Documentaries.Where(x => x.documentary_id == id).FirstOrDefault<Documentary>());
                return View(query);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Documentary doc = db.Documentaries.Where(x => x.documentary_id == id).FirstOrDefault<Documentary>();
                    db.Documentaries.Remove(doc);
                    db.SaveChanges();
                }
                return RedirectToAction("GetData");
                // return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", getAllEquipments()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteDoc(List<String> docID)
        {
            string id = docID[0];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Documentary doc = db.Documentaries.Where(x => x.documentary_id == id).FirstOrDefault<Documentary>();
                db.Documentaries.Remove(doc);
                db.SaveChanges();
            }

            return RedirectToAction("GetData");
        }

        // [Route("phong-cdvt/quyet-dinh/sua-chua/export")]
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
                    List<NewDocumentary> incidents = (from document in db.Documentaries
                                                   join detail in db.Documentary_Inspection_details
                                           on document.documentary_id equals detail.documentary_id
                                           into temporary
                                                   select new
                                                   {
                                                       documentary_id = document.documentary_id,
                                                       date_created = document.date_created,
                                                       person_created = document.person_created,
                                                       reason = document.reason,
                                                       out_in_come = document.out_in_come,
                                                       count = temporary.Select(x => new { x.equipmentId }).Count()
                                                   }).ToList().Select(p => new NewDocumentary
                                                   {
                                                       documentary_id = p.documentary_id,
                                                       date_created = p.date_created,
                                                       person_created = p.person_created,
                                                       reason = p.reason,
                                                       out_in_come = p.out_in_come,
                                                       count = p.count
                                                   }).ToList();
                    int k = 0;
                    for (int i = 2; i < incidents.Count; i++)
                    {
                        excelWorksheet.Cells[i, 1].Value = (k + 1);
                        excelWorksheet.Cells[i, 2].Value = incidents.ElementAt(k).date_created.ToString("hh:mm tt dd/MM/yyyy");
                        excelWorksheet.Cells[i, 3].Value = incidents.ElementAt(k).documentary_id;
                        excelWorksheet.Cells[i, 4].Value = incidents.ElementAt(k).person_created;
                        excelWorksheet.Cells[i, 5].Value = incidents.ElementAt(k).count;
                        excelWorksheet.Cells[i, 6].Value = incidents.ElementAt(k).reason;
                        excelWorksheet.Cells[i, 7].Value = incidents.ElementAt(k).out_in_come;
                        k++;
                    }
                    string location = HostingEnvironment.MapPath("/excel/CDVT/download");
                    excelPackage.SaveAs(new FileInfo(location + "/DanhsachSuaChua.xlsx"));
                }

            }

        }
    }


    public class NewDocumentary : Documentary
    {
        public string documentary_id { get; set; }

        public System.DateTime date_created { get; set; }

        public string person_created { get; set; }

        public string reason { get; set; }

        public string out_in_come { get; set; }

        public int documentary_status { get; set; }
     
        public int count { get; set; }
        public int tempId { get; set; }


    }
}