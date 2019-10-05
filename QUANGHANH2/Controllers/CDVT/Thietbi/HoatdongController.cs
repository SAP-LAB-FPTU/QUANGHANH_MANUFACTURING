using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Threading;
using System.IO;
using System.Web.Hosting;
using OfficeOpenXml;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;

namespace QUANGHANHCORE.Controllers.CDVT.Thietbi
{
    public class HoatdongController : Controller
    {
        [Route("phong-cdvt/huy-dong/export")]
        public void export()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
            string filename = "huy-dong.xlsx";
            FileInfo file = new FileInfo(path + filename);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    
                    var equipList = db.Database.SqlQuery<EquipWithName>("SELECT e.[equipmentId],[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_expected_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                        "FROM [Equipment] e, Status s, Department d, Equipment_category ec " +
                        "where e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid").ToList();

                    int k = 2;
                    for (int i = 0; i < equipList.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = equipList.ElementAt(i).equipmentId;
                        excelWorksheet.Cells[k, 2].Value = equipList.ElementAt(i).equipment_name;
                        excelWorksheet.Cells[k, 3].Value = equipList.ElementAt(i).supplier;
                        excelWorksheet.Cells[k, 4].Value = equipList.ElementAt(i).date_import.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 5].Value = equipList.ElementAt(i).depreciation_estimate;
                        excelWorksheet.Cells[k, 6].Value = equipList.ElementAt(i).depreciation_present;
                        excelWorksheet.Cells[k, 7].Value = equipList.ElementAt(i).durationOfInspection_fix;
                        excelWorksheet.Cells[k, 8].Value = equipList.ElementAt(i).durationOfInsurance.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 9].Value = equipList.ElementAt(i).usedDay.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 10].Value = equipList.ElementAt(i).total_operating_hours;
                        excelWorksheet.Cells[k, 11].Value = equipList.ElementAt(i).statusname;
                        excelWorksheet.Cells[k, 12].Value = equipList.ElementAt(i).fabrication_number;
                        excelWorksheet.Cells[k, 13].Value = equipList.ElementAt(i).mark_code;
                        excelWorksheet.Cells[k, 14].Value = equipList.ElementAt(i).quality_type;
                        excelWorksheet.Cells[k, 15].Value = equipList.ElementAt(i).input_channel;
                        excelWorksheet.Cells[k, 16].Value = equipList.ElementAt(i).Equipment_category_name;
                        excelWorksheet.Cells[k, 17].Value = equipList.ElementAt(i).department_name;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/CDVT/download/baocaohoatdong.xlsx")));
                }
                //


            }
        }

        [Route("phong-cdvt/huy-dong")]
        [HttpGet]
        public ActionResult Index()
        {

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Department> listDepeartment = db.Departments.ToList<Department>();
            ViewBag.listDepeartment = listDepeartment;
            EquipThongKe etk = new EquipThongKe();
            var equipList = db.Equipments.ToList<Equipment>();
            etk.total = equipList.Count().ToString();
            var temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_repair_details dr").ToList<Temp>();
            etk.total_repair = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_maintain_details dr").ToList<Temp>();
            etk.total_maintain = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_big_maintain_details dr").ToList<Temp>();
            etk.total_KD = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_liquidation_details dr").ToList<Temp>();
            etk.total_TL = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary_revoke_details dr").ToList<Temp>();
            etk.total_TH = temp.Count().ToString();
            Equipment emp = new Equipment();
            ViewBag.e = emp;
            ViewBag.Thongke = etk;
            List<SelectListItem> listStatus = new List<SelectListItem>();
            var statsu = db.Status.ToList<Status>();
            foreach (Status item in statsu)
            {
                listStatus.Add(new SelectListItem { Text = item.statusid.ToString(), Value = item.statusname });
            }
            //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
            ViewBag.listStatus = listStatus;
            return View("/Views/CDVT/Hoat_dong.cshtml");
        }

        public class Temp
        {
            public string abc { get; set; }
        }

        [Route("phong-cdvt/huy-dong")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
               
                var equipList = db.Database.SqlQuery<EquipWithName>("SELECT e.[equipmentId],[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_expected_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name FROM [Equipment] e, Status s, Department d, Equipment_category ec where e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid").ToList();
                int totalrows = equipList.Count;
                int totalrowsafterfiltering = equipList.Count;
                //sorting
                equipList = equipList.OrderBy(sortColumnName + " " + sortDirection).ToList<EquipWithName>();
                //paging
                equipList = equipList.Skip(start).Take(length).ToList<EquipWithName>();
                List<Department> listDepeartment = db.Departments.ToList<Department>();
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.bolEdit = false;
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }
        public class EquipThongKe
        {
            public string total { get; set; }
            public string total_repair { get; set; }
            public string total_maintain { get; set; }
            public string total_KD { get; set; }
            public string total_TL { get; set; }
            public string total_TH { get; set; }
            public int total_KHD { get; set; }
            public int total_HD { get; set; }
        }


        public class EquipWithName : Equipment
        {
            public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
            public string statusname { get; set; }
            public string Equipment_category_name { get; set; }
            public string department_name { get; set; }
        }

        [Route("phong-cdvt/huy-dong/search")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string department, string quality, string dateStart, string dateEnd, string category, string sup)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string query = "SELECT e.[equipmentId],[equipment_name],[supplier],[date_import],[durationOfMaintainance],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_expected_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                "FROM [Equipment] e, Status s, Department d, Equipment_category ec " +
                "where e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid and ";
            if (!equipmentId.Equals("") || !equipmentName.Equals("") || !department.Equals("") || !quality.Equals("") || !category.Equals("") || !sup.Equals(""))
            {
                if (!equipmentId.Equals("")) query += "e.equipmentId LIKE @equipmentId AND ";
                if (!equipmentName.Equals("")) query += "e.equipment_name LIKE @equipment_name AND ";
                if (!department.Equals("")) query += "d.department_id = @department_name AND ";
                if (!quality.Equals("")) query += "e.quality_type LIKE @quality AND ";
                if (!category.Equals("")) query += "ec.Equipment_category_name LIKE @cate AND ";
                if (!sup.Equals("")) query += "e.supplier LIKE @sup AND ";
            }
            query = query.Substring(0, query.Length - 5);
            List<EquipWithName> equiplist = DBContext.Database.SqlQuery<EquipWithName>(query,
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", department),
                new SqlParameter("quality", '%' + quality + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd),
                new SqlParameter("cate", '%' + category + '%'),
                new SqlParameter("sup", '%' + sup + '%')
                ).ToList();
            int totalrows = equiplist.Count;
            int totalrowsafterfiltering = equiplist.Count;
            //sorting
            equiplist = equiplist.OrderBy(sortColumnName + " " + sortDirection).ToList<EquipWithName>();
            //paging
            equiplist = equiplist.Skip(start).Take(length).ToList<EquipWithName>();
            return Json(new { success = true, data = equiplist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(string id = "")
        {
            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_id });

                }
                //
                var categories = db.Equipment_category.ToList<Equipment_category>();
                foreach (Equipment_category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.Equipment_category_id, Value = items.Equipment_category_id });

                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                if (id == "" || id == null)
                {
                    return View(new Equipment());
                }
                else
                    return View(db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>());
            }
        }


        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            List<SelectListItem> listStatus = new List<SelectListItem>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_name });

                }
                //
                var categories = db.Equipment_category.ToList<Equipment_category>();
                foreach (Equipment_category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.Equipment_category_id, Value = items.Equipment_category_name });

                }
                var statsu = db.Status.ToList<Status>();
                foreach(Status item in statsu)
                {
                    listStatus.Add(new SelectListItem { Text = item.statusid.ToString(), Value = item.statusname });
                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listStatus = listStatus;
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
            }
            return View(new Equipment());
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            List<SelectListItem> listType = new List<SelectListItem>();
            listType.Add(new SelectListItem { Text = "Lộ thiên", Value = "Lộ thiên" });
            listType.Add(new SelectListItem { Text = "Hầm lò", Value = "Hầm lò" });
            listType.Add(new SelectListItem { Text = "Sàng tuyển", Value = "Sàng tuyển" });
            listType.Add(new SelectListItem { Text = "Cung cấp điện, truyền dẫn", Value = "Cung cấp điện, truyền dẫn" });
            ViewBag.listType = listType;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Supply> listSup = db.Supplies.ToList<Supply>();
            ViewBag.listSup = listSup;
            return View(new Equipment_category());
        }
        [HttpPost]
        public ActionResult AddCategory(Equipment_category ec, string[] id, string[] name, string[] unit, string[] nameSup, int[] quantitySup)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Equipment_category.Add(ec);
            if (id != null)
            {
                for (int i = 0; i < id.Count(); i++)
                {
                    if (!id[i].Equals(""))
                    {
                        Equipment_category_attribute ea = new Equipment_category_attribute();
                        ea.Equipment_category_id = ec.Equipment_category_id;
                        ea.Equipment_category_attribute_id = id[i];
                        ea.unit = unit[i];
                        ea.Equipment_category_attribute_name = name[i];
                        db.Equipment_category_attribute.Add(ea);
                    }

                }
            }
            if (nameSup != null)
            {
                List<Supply> listSup = db.Supplies.ToList();
                for (int i = 0; i < nameSup.Count(); i++)
                {
                    if (!nameSup[i].Equals(""))
                    {
                        Equipment_Category_Supply ecs = new Equipment_Category_Supply();
                        Supply s = new Supply();
                        for (int j = 0; j < listSup.Count(); j++)
                        {
                            if (listSup.ElementAt(j).supply_name.Equals(nameSup[i]))
                            {
                                s.supply_id = listSup.ElementAt(j).supply_id;
                                break;
                            }
                        }
                        ecs.supply_id = s.supply_id;
                        ecs.Equipment_category_id = ec.Equipment_category_id;
                        db.Equipment_Category_Supply.Add(ecs);
                    }

                }
            }
            db.SaveChanges();
            return RedirectToAction("GetData");
        }

        [HttpPost]
        public ActionResult Add(Equipment emp, string import, string duraInspec, string duraInsura, string used, string duramain, string[] id, string[] name, int[] value, string[] unit)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //import date
                string[] date = import.Split('/');
                string date_fix = date[1] + "/" + date[0] + "/" + date[2];
                emp.date_import = Convert.ToDateTime(date_fix);
                //durationOfInspection
                date = duraInspec.Split('/');
                date_fix = date[1] + "/" + date[0] + "/" + date[2];
                emp.durationOfInspection = Convert.ToDateTime(date_fix);
                //durationOfInsurance
                date = duraInsura.Split('/');
                date_fix = date[1] + "/" + date[0] + "/" + date[2];
                emp.durationOfInsurance = Convert.ToDateTime(date_fix);
                //usedDay
                date = used.Split('/');
                date_fix = date[1] + "/" + date[0] + "/" + date[2];
                emp.usedDay = Convert.ToDateTime(date_fix);
                //nearest_Maintenance_Day
                date = duramain.Split('/');
                date_fix = date[1] + "/" + date[0] + "/" + date[2];
                emp.durationOfMaintainance = Convert.ToDateTime(date_fix);


                db.Equipments.Add(emp);
                if (id != null)
                {
                    for (int i = 0; i < id.Count(); i++)
                    {
                        if (!id[i].Equals(""))
                        {
                            Equipment_attribute ea = new Equipment_attribute();
                            ea.equipmentId = emp.equipmentId;
                            ea.Equipment_attribute_id = id[i];
                            ea.unit = unit[i];
                            ea.value = value[i];
                            ea.Equipment_attribute_name = name[i];
                            db.Equipment_attribute.Add(ea);
                        }

                    }
                }
                Equipment_Inspection ei = new Equipment_Inspection();
                ei.equipmentId = emp.equipmentId;
                ei.inspect_start_date = emp.durationOfInspection;
                db.Equipment_Inspection.Add(ei);
                db.SaveChanges();
                return RedirectToAction("GetData");
            }
        }

        [HttpPost]
        public ActionResult Edit(Equipment emp, string import, string inspec, string insua, string used, string main)
        {
            //import date
            string[] date = import.Split('/');
            string date_fix = date[1] + "/" + date[0] + "/" + date[2];
            emp.date_import = Convert.ToDateTime(date_fix);
            //durationOfInspection
            date = inspec.Split('/');
            date_fix = date[1] + "/" + date[0] + "/" + date[2];
            emp.durationOfInspection = Convert.ToDateTime(date_fix);
            //durationOfInsurance
            date = insua.Split('/');
            date_fix = date[1] + "/" + date[0] + "/" + date[2];
            emp.durationOfInsurance = Convert.ToDateTime(date_fix);
            //usedDay
            date = used.Split('/');
            date_fix = date[1] + "/" + date[0] + "/" + date[2];
            emp.usedDay = Convert.ToDateTime(date_fix);
            //nearest_Maintenance_Day
            date = main.Split('/');
            date_fix = date[1] + "/" + date[0] + "/" + date[2];
            emp.durationOfMaintainance = Convert.ToDateTime(date_fix);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                try
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GetData");
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }

            }
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_name });

                }
                //
                var categories = db.Equipment_category.ToList<Equipment_category>();
                foreach (Equipment_category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.Equipment_category_id, Value = items.Equipment_category_name });
                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                Equipment emp = db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>();
                if (emp == null)
                {
                    emp = new Equipment();
                }
                ViewBag.e = emp;
                emp.date_import = DateTime.Parse(emp.date_import.ToString("dd-MMM-yyyy"));
                List<SelectListItem> listStatus = new List<SelectListItem>();
                var statsu = db.Status.ToList<Status>();
                foreach (Status item in statsu)
                {
                    listStatus.Add(new SelectListItem { Text = item.statusid.ToString(), Value = item.statusname });
                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listStatus = listStatus;
                return View(db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>());
                //return Json(new { success = true, message = "Cập nhật thành công" , data= db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>()}, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("phong-cdvt/huy-dong/kd")]
        [HttpPost]
        public ActionResult EditKD(string id, DateTime date)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Equipment emp = db.Equipments.Where(e => e.equipmentId == id).FirstOrDefault();
            emp.durationOfInspection = date;
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("GetData");
            //return Json(new { success = true, message = "Cập nhật thành công" , data= db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>()}, JsonRequestBehavior.AllowGet);

        }


        //[HttpGet]
        //public ActionResult Delete(string id)
        //{
        //    try
        //    {
        //        using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        //        {
        //            Equipment emp = db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>();
        //            List<Equipment_attribute> list = db.Equipment_attribute.Where(ea => ea.equipmentId == id).ToList();
        //            for (int i = 0; i < list.Count(); i++)
        //            {
        //                Equipment_attribute e = list.ElementAt(i);
        //                db.Equipment_attribute.Remove(e);
        //            }
        //            Equipment_Inspection ei = db.Equipment_Inspection.Where(x => x.equipmentId == emp.equipmentId).FirstOrDefault();
        //            db.Equipment_Inspection.Remove(ei);
        //            db.Equipments.Remove(emp);
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("GetData");
        //        // return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", getAllEquipments()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}