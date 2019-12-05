using Newtonsoft.Json.Linq;
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
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;


namespace QUANGHANH2.Controllers.Camera
{
    public class SuachuaCameraController : Controller
    {
        [Route("camera/sua-chua")]
        public ActionResult AddSuaChua()
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies.Get("SuaChuaThietBi") == null)
            {
                cookie = new HttpCookie("SuaChuaThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies.Get("SuaChuaThietBi");
            }
            ViewBag.selectedList = cookie.Value;
            if (TempData["shortMessage"] != null)
                ViewBag.alert = true;
            else
                ViewBag.alert = false;
            return View("/Views/Camera/Sua_chua_camera.cshtml");
        }

        public class CamList : Models.Camera
        {
            public string department_id { get; set; }
            public string department_name { get; set; }
            public string department_type { get; set; }
            public string room_name { get; set; }
            public string statusname { get; set; }
        }
 
        [Route("camera/sua-chua/search")]
        [HttpPost]
        public ActionResult SearchThem(string cameraID, string department_name, string cameraName)
        {
            HttpCookie cookie;
            if (HttpContext.Request.Cookies["SuaChuaThietBi"] == null)
            {
                cookie = new HttpCookie("SuaChuaThietBi");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.Value = "[]";
            }
            else
            {
                cookie = HttpContext.Request.Cookies["SuaChuaThietBi"];
                cookie.Value = Request["selectList"];
            }

            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            ViewBag.selectedList = cookie.Value;
            //
            HttpContext.Response.Cookies.Set(cookie);
            var listSelect = Request["selectList"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string query = "select c.camera_id, c.camera_name, r.room_name, c.camera_status, d.department_name, s.statusname from Camera c left join Room r on c.room_id = r.room_id join Department d on r.department_id = d.department_id join Status s on s.statusid = c.camera_status";
                if (!cameraID.Equals("") || !cameraName.Equals("") || !department_name.Equals(""))
                {
                    query += " where ";
                    if (!cameraID.Equals("")) query += "c.camera_id LIKE @cameraID AND ";
                    if (!cameraName.Equals("")) query += "c.camera_name LIKE @cameraName AND ";
                    if (!department_name.Equals("")) query += "d.department_name LIKE @department_name AND ";
                    query = query.Substring(0, query.Length - 5);
                }
                List<CamList> equipList = db.Database.SqlQuery<CamList>(query,
                    new SqlParameter("cameraID", '%' + cameraID + '%'),
                    new SqlParameter("cameraName", '%' + cameraName + '%'),
                    new SqlParameter("department_name", '%' + department_name + '%')).ToList();
                int totalrows = equipList.Count;
                int totalrowsafterfiltering = equipList.Count;
                //sorting
                equipList = equipList.OrderBy(sortColumnName + " " + sortDirection).ToList<CamList>();
                //paging
                equipList = equipList.Skip(start).Take(length).ToList<CamList>();
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        //[Auther(RightID = "194")]
        [Route("camera/quyet-dinh-sua-chua")]
        public ActionResult Index()
        {
            ViewBag.count = 1;
            return View("/Views/Camera/Quyet_dinh_sua_chua.cshtml");
        }

        [Route("camera/quyet-dinh-sua-chua/update")]
        public ActionResult UpdateID(int documentary_id, string documentary_code, string date_created, string person_created, string reason, string out_in_come)
        {

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();

            Documentary i = DBContext.Documentaries.Find(documentary_id);

            if (String.IsNullOrEmpty(documentary_code))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường mã quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }
            else

               if (String.IsNullOrEmpty(date_created))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường mã quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }
            else

               if (String.IsNullOrEmpty(person_created))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường người lập quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }
            else

               if (String.IsNullOrEmpty(reason))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường lý do quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }

            if (String.IsNullOrEmpty(out_in_come))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường nguồn vốn là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }

            else
            {
                try
                {
                    var query = (from x in DBContext.Documentaries
                                 where x.documentary_code == documentary_code
                                 select x).First();
                    return Json(new
                    {
                        success = false,
                        message = "Mã số quyết định đã tồn tại"
                    }, JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
                    {
                        try
                        {
                            List<Documentary_camera_repair_details> details = DBContext.Documentary_camera_repair_details.Where(x => x.documentary_id == documentary_id).ToList();
                            foreach (Documentary_camera_repair_details item in details)
                            {
                                Models.Camera e = DBContext.Cameras.Find(item.camera_id);
                                e.camera_status = 3;
                            }
                            documentary_code = documentary_code.Replace(" ", String.Empty);
                            i.documentary_code = documentary_code;
                            i.date_created = DateTime.Parse(date_created);
                            i.person_created = person_created;
                            i.reason = reason;
                            i.out_in_come = out_in_come;
                            DBContext.SaveChanges();
                            transaction.Commit();
                            return Json(new
                            {
                                success = true,
                            }, JsonRequestBehavior.AllowGet);
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            return Json(new
                            {
                                success = false,
                                message = "Có lỗi xảy ra"
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }

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

        public class CamDocument : Documentary
        {
            public string camera_id { get; set; }
            public int count { get; set; }
            public string tempId { get; set; }
        }

        [Route("camera/quyet-dinh-sua-chua")]
        [HttpPost]
        public ActionResult Search(string person_created, string dateStart, string dateEnd)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<CamDocument> documentaryList = new List<CamDocument>();
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
                               where document.documentary_type == 8 && (document.documentary_code == null || document.documentary_code == "") && document.person_created.Contains(person_created) && (document.date_created >= dtStart && document.date_created <= dtEnd)
                               join cam in db.Documentary_camera_repair_details on document.documentary_id equals cam.documentary_id
                               into temporary
                               select new
                               {
                                   documentary_id = document.documentary_id,
                                   documentary_code = document.documentary_code,
                                   date_created = document.date_created,
                                   person_created = document.person_created,
                                   reason = document.reason,
                                   out_in_come = document.out_in_come,
                                   count = temporary.Select(x => new { x.camera_id }).Count()
                               }).ToList().Select(p => new CamDocument
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
                                                                where (document.documentary_type.Equals("1") && (document.documentary_code == "" || document.documentary_code == null))
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

        [Route("camera/sua-chua-chon")]
        [HttpGet]
        public ActionResult Index(String selectListJson)
        {
            var listSelected = selectListJson;
            var listConvert = listSelected;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var result = (from a in db.Cameras
                              where listConvert.Contains(a.camera_id)
                              join r in db.Rooms on a.room_id equals r.room_id
                              join d in db.Departments on r.department_id equals d.department_id
                              join c in db.Status on a.camera_status equals c.statusid
                              select new
                              {
                                  camera_id = a.camera_id,
                                  camera_name = a.camera_name,
                                  department_name = d.department_name,
                                  department_id = r.department_id,
                                  current_Status = a.camera_status,
                                  statusname = c.statusname,
                              }).ToList().Select(s => new CamList
                              {
                                  camera_id = s.camera_id,
                                  camera_name = s.camera_name,
                                  department_name = s.department_name,
                                  department_id = s.department_id,
                                  camera_status = s.current_Status,
                                  statusname = s.statusname,

                              }).ToList();
                ViewBag.DataThietBi = result;

                List<Supply> supplies = db.Supplies.ToList();
                List<Department> departments = db.Departments.ToList();

                try
                {
                    int validate = 1;
                    var department_id = result[0].department_id;
                    foreach (var item in result)
                    {
                        if (!item.department_id.Equals(department_id))
                        {
                            validate = 0;
                            break;
                        }
                    }
                    Department department = db.Departments.Find(department_id);
                    ViewBag.validate = validate;
                    ViewBag.department_name = department.department_name;
                    ViewBag.department_id = department.department_id;
                    ViewBag.Supplies = supplies;
                    ViewBag.Departments = departments;
                }
                catch (Exception e)
                {
                    ViewBag.alert = true;
                    e.Message.ToString();
                    TempData["shortMessage"] = true;
                    return Redirect("sua-chua");
                    throw e;
                }

            }
            return View("/Views/Camera/Sua_chua_camera_chon.cshtml");
        }

        [Route("camera/sua-chua-chon")]
        [HttpPost]
        public ActionResult GetData(string documentary_code, string out_in_come, string data, string department_id, string reason)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary();
                    documentary.documentary_code = documentary_code == "" ? null : documentary_code;
                    documentary.documentary_type = 8;
                    documentary.department_id = department_id;
                    documentary.date_created = DateTime.Now;
                    documentary.person_created = "Long";
                    documentary.reason = reason;
                    documentary.out_in_come = out_in_come;
                    documentary.documentary_status = 1;
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string cameraId = (string)item.Value["id"];
                        string department_id_to = (string)item.Value["department_id"];
                        string repair_reason = (string)item.Value["repair_reason"];
                        string datestring = (string)item.Value["finish_date_plan"];
                        if (documentary_code != "")
                        {
                            Equipment e = DBContext.Equipments.Find(cameraId);
                            e.current_Status = 3;
                        }
                        Documentary_camera_repair_details drd = new Documentary_camera_repair_details();
                        drd.Documentary_camera_repair_status = 0;
                        drd.repair_requirement = repair_reason;
                        drd.department_id = department_id_to;//
                        drd.documentary_id = documentary.documentary_id;
                        drd.camera_id = cameraId;
                        DBContext.Documentary_camera_repair_details.Add(drd);
                        DBContext.SaveChanges();
                        JArray vattu = (JArray)item.Value.SelectToken("vattu");
                        foreach (JObject jObject in vattu)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            string supplyStatus = (string)jObject["supplyStatus"];
                            string department_id_temp = (string)jObject["department_id"];
                            Supply_Documentary_Camera sde = new Supply_Documentary_Camera();
                            sde.documentary_id = documentary.documentary_id;
                            sde.camera_id = cameraId;
                            sde.supply_id = supply_id;
                            sde.quantity_plan = quantity;
                            sde.supplyStatus = supplyStatus;
                            sde.supply_documentary_status = 0;
                            DBContext.Supply_Documentary_Camera.Add(sde);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();

                    return Redirect("/camera/quyet-dinh-sua-chua");


                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    e.Message.ToString();
                    TempData["shortMessage"] = true;
                    return Redirect("sua-chua");
                    throw e;
                }
            }
        }

    }
}