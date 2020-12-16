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
using System.Data.SqlClient;
using System.Globalization;
using QUANGHANH2.SupportClass;
using QUANGHANH2.EntityResult;

namespace QUANGHANHCORE.Controllers.CDVT.Thietbi
{
    public class HoatdongController : Controller
    {
        [Auther(RightID = "3")]
        [Route("phong-cdvt/huy-dong/export")]
        public ActionResult export(string equipmentId, string equipmentName, string department, string quality, string dateStart, string dateEnd, string category, string sup, string att)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
            string filename = "huy-dong.xlsx";
            FileInfo file = new FileInfo(path + filename);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    DateTime dtStart = DateTime.Parse("1800-1-1");
                    DateTime dtEnd = DateTime.MaxValue;
                    if (!dateStart.Equals(""))
                    {
                        String[] date = dateStart.Split('/');
                        String date_fix = date[1] + "/" + date[0] + "/" + date[2];
                        dtStart = Convert.ToDateTime(date_fix);
                    }
                    if (!dateEnd.Equals(""))
                    {
                        String[] date = dateEnd.Split('/');
                        String date_fix = date[1] + "/" + date[0] + "/" + date[2];
                        dtEnd = Convert.ToDateTime(date_fix);
                    }

                    string query = "Equipment.Get_Export_List {0},{1},{2},{3},{4},{5},{6},{7},{8}";


                    var equipList = db.Database.SqlQuery<GetExportList_Result>(query,
                                        equipmentId,equipmentName,department,quality,dtStart,dtEnd,category,sup,att 
                                        ).ToList();

                    int k = 2;
                    for (int i = 0; i < equipList.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = equipList.ElementAt(i).equipment_id;
                        excelWorksheet.Cells[k, 2].Value = equipList.ElementAt(i).equipment_name;
                        excelWorksheet.Cells[k, 3].Value = equipList.ElementAt(i).supplier;
                        if (equipList.ElementAt(i).date_import == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 4].Value = equipList.ElementAt(i).date_import.Value.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 5].Value = equipList.ElementAt(i).depreciation_estimate;
                        excelWorksheet.Cells[k, 6].Value = equipList.ElementAt(i).depreciation_present;
                        if (equipList.ElementAt(i).durationOfInspection_fix == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 7].Value = equipList.ElementAt(i).durationOfInspection_fix.Value.ToString("dd/MM/yyyy");
                        if (equipList.ElementAt(i).duration_of_insurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 8].Value = equipList.ElementAt(i).duration_of_insurance.Value.ToString("dd/MM/yyyy");
                        if (equipList.ElementAt(i).used_day == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 9].Value = equipList.ElementAt(i).used_day.Value.ToString("dd/MM/yyyy");
                        if (equipList.ElementAt(i).duration_of_maintainance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 10].Value = equipList.ElementAt(i).duration_of_maintainance.Value.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 11].Value = equipList.ElementAt(i).total_operating_hours;
                        excelWorksheet.Cells[k, 12].Value = equipList.ElementAt(i).status_name;
                        excelWorksheet.Cells[k, 13].Value = equipList.ElementAt(i).fabrication_number;
                        excelWorksheet.Cells[k, 14].Value = equipList.ElementAt(i).mark_code;
                        excelWorksheet.Cells[k, 15].Value = equipList.ElementAt(i).quality_type;
                        excelWorksheet.Cells[k, 16].Value = equipList.ElementAt(i).input_channel;
                        excelWorksheet.Cells[k, 17].Value = equipList.ElementAt(i).Equipment_category_name;
                        excelWorksheet.Cells[k, 18].Value = equipList.ElementAt(i).department_name;
                        k++;
                    }
                    string Flocation = "/excel/CDVT/download/baocaohoatdong.xlsx";
                    string savePath = HostingEnvironment.MapPath(Flocation);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/CDVT/download/baocaohoatdong.xlsx")));
                    return Json(new { success = true, location = Flocation }, JsonRequestBehavior.AllowGet);
                }
                //


            }
        }
        [Auther(RightID = "6")]
        [Route("phong-cdvt/huy-dong")]
        [HttpGet]
        public ActionResult Index()
        {

            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<Department> listDepeartment = db.Departments.ToList<Department>();
            ViewBag.listDepeartment = listDepeartment;
            List<GetExportList_Result> listID = new List<GetExportList_Result>();
            ViewBag.listID = listID;
            return View("/Views/CDVT/Hoat_dong.cshtml");
        }

        [Route("phong-cdvt/huy-dong/change")]
        [HttpPost]
        public ActionResult Change(string id)
        {
            ViewBag.listID = null;
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            string sql = "select e.equipmentId from Equipment.Equipment e where e.equipment_id like @id";
            List<GetExportList_Result> listID = db.Database.SqlQuery<GetExportList_Result>(sql, new SqlParameter("id", "%" + id + "%")).Take(10).ToList();
            ViewBag.listID = listID;
            string d = "";
            foreach (var item in listID)
            {
                d += "<option value='" + item.equipment_id + "'/>";
            }
            return Json(new { success = true, data = d }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult ChangeID(string id, string ck)
        {
            string sql = "Equipment.Get_Suggest_Search {0},{1}";
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<GetSuggestSearch_Result> list = db.Database.SqlQuery<GetSuggestSearch_Result>(sql, ck, id).Take(10).ToList();
            return Json(new { success = true, id = list }, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult Atri(string name)
        {
            ViewBag.listID = null;
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            String d = "";
            string sql = "select * from Equipment.CategoryAttribute where Equipment_category_id = @name";
            List<CategoryAttribute> list = db.Database.SqlQuery<CategoryAttribute>(sql, new SqlParameter("name", name)).ToList();
            foreach (var item in list)
            {
                d += "<tr>";
                d += "<td>" + item.equipment_category_attribute_name + "</td>";
                d += "<td><input type='number' name='attri' class='form-control'/></td>";
                d += "</tr>";
            }

            return Json(new { success = true, data = d }, JsonRequestBehavior.AllowGet);
        }
        //[Auther(RightID = "6")]
        [Route("phong-cdvt/huy-dong/search")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string department, string quality, string dateStart, string dateEnd, string category, string sup, string att)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            if (length == 0) length = 10;
            if (sortColumnName == null) sortColumnName = "equipment_category_name";
            if (sortDirection == null) sortDirection = "asc";

            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            DateTime dtStart = DateTime.Parse("1800-1-1");
            DateTime dtEnd = DateTime.MaxValue;
            if (!dateStart.Equals(""))
            {
                String[] date = dateStart.Split('/');
                String date_fix = date[1] + "/" + date[0] + "/" + date[2];
                dtStart = Convert.ToDateTime(date_fix);
            }
            if (!dateEnd.Equals(""))
            {
                String[] date = dateEnd.Split('/');
                String date_fix = date[1] + "/" + date[0] + "/" + date[2];
                dtEnd = Convert.ToDateTime(date_fix);
            }
            String query = "Equipment.Get_List_Search_Equipment {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}";
            List<GetExportList_Result> equiplist = DBContext.Database.SqlQuery<GetExportList_Result>(query,
                equipmentId,equipmentName,department,quality,dtStart,dtEnd,category,sup,att,sortColumnName,sortDirection,start,length).ToList();
            String queryTotalRow = "Equipment.Get_Total_Row_Equipment {0},{1},{2},{3},{4},{5},{6},{7},{8}";
            int totalrows = DBContext.Database.SqlQuery<int>(queryTotalRow,
                equipmentId, equipmentName, department, quality, dtStart, dtEnd, category, sup, att
                ).FirstOrDefault();
            return Json(new { success = true, data = equiplist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddOrEdit(string id = "")
        {
            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_id });

                }
                //
                var categories = db.Categories.ToList<Category>();
                foreach (Category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.equipment_category_id, Value = items.equipment_category_id });

                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                if (id == "" || id == null)
                {
                    return View(new Equipment());
                }
                else
                    return View(db.Equipments.Where(x => x.equipment_id == id).FirstOrDefault<Equipment>());
            }
        }

        [HttpGet]
        public ActionResult Add()
        {

            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            List<SelectListItem> listStatus = new List<SelectListItem>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<GetAccompaniedEquipmentWithName_Result> listsupdk = db.Database.SqlQuery<GetAccompaniedEquipmentWithName_Result>("select equipment_name,equipment_id from Equipment.Equipment where is_attach = 1").ToList();
                ViewBag.listsupdk = listsupdk;

                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_name });

                }
                //
                var categories = db.Categories.ToList<Category>();
                foreach (Category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.equipment_category_id, Value = items.equipment_category_name });

                }
                var statsu = db.Status1.ToList<Status1>();
                foreach (Status1 item in statsu)
                {
                    listStatus.Add(new SelectListItem { Text = item.status_id.ToString(), Value = item.status_name });
                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listStatus = listStatus;
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                List<SelectListItem> listQuality = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Không có chất lượng", Value = "" },
                    new SelectListItem { Text = "A", Value = "A" },
                    new SelectListItem { Text = "B", Value = "B" },
                    new SelectListItem { Text = "C", Value = "C" }
                };
                ViewBag.listQuality = listQuality;

                List<SelectListItem> listDN = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Đường kế toán", Value = "Đường kế toán" },
                    new SelectListItem { Text = "Đường vật tư", Value = "Đường vật tư" }
                };
                ViewBag.listDN = listDN;

                string script = "select * from Equipment.CategoryAttribute where Equipment_category_id = (select top 1 Equipment_category_id from Equipment.Category)";
                List<CategoryAttribute> listcateatrri = db.Database.SqlQuery<CategoryAttribute>(script).ToList();
                ViewBag.listcateatrri = listcateatrri;
            }
            return View(new Equipment());
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            List<SelectListItem> listType = new List<SelectListItem>
            {
                new SelectListItem { Text = "Lộ thiên", Value = "Lộ thiên" },
                new SelectListItem { Text = "Hầm lò", Value = "Hầm lò" },
                new SelectListItem { Text = "Sàng tuyển", Value = "Sàng tuyển" },
                new SelectListItem { Text = "Cung cấp điện, truyền dẫn", Value = "Cung cấp điện, truyền dẫn" }
            };
            ViewBag.listType = listType;
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<Supply> listSup = db.Supplies.ToList<Supply>();
            ViewBag.listSup = listSup;
            return View(new Category());
        }

        [HttpPost]
        public ActionResult AddCategory(Category ec, string[] id, string[] name, string[] unit)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            Category category = db.Categories.Find(ec.equipment_category_id);
            if (category != null)
                return Json(new { success = false, message = "Mã loại thiết bị đã tồn tại" });
            using (DbContextTransaction dbc = db.Database.BeginTransaction())
            {
                try
                {
                    db.Categories.Add(ec);
                    db.SaveChanges();
                    if (id != null)
                    {
                        for (int i = 0; i < id.Count(); i++)
                        {
                            if (!id[i].Equals(""))
                            {
                                CategoryAttribute ea = db.CategoryAttributes.Find(id[i]);
                                if (ea != null) continue;
                                ea = new CategoryAttribute
                                {
                                    equipment_category_id = ec.equipment_category_id,
                                    equipment_category_attribute_id = id[i],
                                    unit = unit[i],
                                    equipment_category_attribute_name = name[i]
                                };
                                db.CategoryAttributes.Add(ea);
                            }

                        }
                    }
                    db.SaveChanges();
                    dbc.Commit();
                    return Search("", "", "", "", "", "", "", "", "");
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                }
            }
        }

        [HttpPost]
        public ActionResult Add(Equipment emp, string import, string duraInspec, string Insua, string BuyInspec, string BuyInsua, string used, string duramain, string[] id, string[] name, string[] value, string[] unit, int[] attri, string[] nameSup, int[] quantity, string[] nameVTDK, int[] quantityVTDK, string sk, string sm, string gps, string attype, string NL, string yearSX)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {


                using (DbContextTransaction dbc = db.Database.BeginTransaction())
                {
                    try
                    {
                        Equipment equipment = db.Equipments.Find(emp.equipment_id);
                        if (equipment != null)
                            return Json(new { success = false, message = "Mã thiết bị đã tồn tại" });
                        //import date
                        if (import != "")
                            emp.date_import = DateTime.ParseExact(import, "dd/MM/yyyy", null);
                        //durationOfInspection
                        if (duraInspec != "")
                            emp.duration_of_inspection = DateTime.ParseExact(duraInspec, "dd/MM/yyyy", null);
                        if (Insua != "")
                        {
                            emp.duration_of_insurance = DateTime.ParseExact(Insua, "dd/MM/yyyy", null);
                        }
                        if (BuyInsua != "")
                        {
                            emp.insurance_date = DateTime.ParseExact(BuyInsua, "dd/MM/yyyy", null);
                        }
                        if (BuyInspec != "")
                        {
                            emp.inspect_date = DateTime.ParseExact(BuyInspec, "dd/MM/yyyy", null);
                        }
                        //usedDay
                        if (used != "")
                            emp.used_day = DateTime.ParseExact(used, "dd/MM/yyyy", null);
                        emp.input_channel = "Đường kế toán";
                        emp.department_id = Convert.ToString(Session["departID"]);
                        emp.total_operating_hours = 0;
                        emp.duration_of_maintainance = DateTime.Now;
                        db.Equipments.Add(emp);
                        string sql = "select * from Equipment.CategoryAttribute where Equipment_category_id = @cateid";
                        List<CategoryAttribute> list = db.Database.SqlQuery<CategoryAttribute>(sql, new SqlParameter("cateid", emp.equipment_category_id)).ToList();
                        if (id != null)
                        {
                            for (int i = 0; i < id.Count(); i++)
                            {
                                if (!id[i].Equals(""))
                                {
                                    QUANGHANH2.Models.Attribute ea = new QUANGHANH2.Models.Attribute
                                    {
                                        equipment_id = emp.equipment_id,
                                        equipment_attribute_id = id[i],
                                        unit = unit[i],
                                        value = value[i],
                                        equipment_attribute_name = name[i]
                                    };
                                    db.Attributes.Add(ea);
                                }

                            }
                        }
                        if (sk != "" && sm != "")
                        {
                            Car ca = new Car
                            {
                                equipment_id = emp.equipment_id,
                                chassis_number = sk,
                                engine_number = sm
                            };
                            if (gps.Equals("1"))
                            {
                                ca.GPS = true;
                            }
                            else
                            {
                                ca.GPS = false;
                            }
                            if (NL.Equals("1"))
                            {
                                ca.fuel = true;
                            }
                            else
                            {
                                ca.fuel = false;
                            }
                            if (yearSX != "")
                            {
                                ca.manufacture_year = Convert.ToInt32(yearSX);
                            }

                            db.Cars.Add(ca);
                        }
                        if (attri != null)
                        {
                            for (int i = 0; i < attri.Count(); i++)
                            {
                                if (!attri[i].Equals(""))
                                {
                                    CategoryAttributeValue cav = new CategoryAttributeValue
                                    {
                                        value = attri[i],
                                        equipment_id = emp.equipment_id,
                                        equipment_category_id = emp.equipment_category_id,
                                        equipment_category_attribute_id = list.ElementAt(i).equipment_category_attribute_id
                                    };
                                    db.CategoryAttributeValues.Add(cav);
                                }
                            }
                        }

                        Inspection ei = new Inspection();
                        if (emp.duration_of_inspection != null)
                        {
                            ei.equipment_id = emp.equipment_id;
                            ei.inspect_date = emp.duration_of_inspection.Value;
                            db.Inspections.Add(ei);
                        }
                        bool isAc = true;
                        if (attype.Equals("0"))
                        {
                            isAc = false;
                        }
                        emp.is_attach = isAc;
                        db.SaveChanges();

                        if (nameSup != null)
                        {
                            for (int i = 0; i < nameSup.Count(); i++)
                            {
                                if (!nameSup[i].Equals(""))
                                {

                                    string sql_sup = "insert into Equipment.AccompaniedEquipment values (@eid, @supid, @quan, 0)";
                                    db.Database.ExecuteSqlCommand(sql_sup
                                        , new SqlParameter("@supid", nameSup[i])
                                        , new SqlParameter("@eid", emp.equipment_id)
                                        , new SqlParameter("@quan", quantity[i]));
                                }

                            }
                        }

                        db.SaveChanges();

                        if (nameVTDK != null)
                        {
                            if (emp.is_attach == false)
                            {
                                for (int i = 0; i < nameVTDK.Count(); i++)
                                {
                                    if (!nameVTDK[i].Equals(""))
                                    {

                                        string sql_sup = "insert into Equipment.AccompaniedSupply values (@supid, @eid, @quan)";
                                        db.Database.ExecuteSqlCommand(sql_sup
                                            , new SqlParameter("@supid", nameVTDK[i])
                                            , new SqlParameter("@eid", emp.equipment_id)
                                            , new SqlParameter("@quan", quantity[i]));
                                    }

                                }
                            }
                            else
                            {
                                for (int i = 0; i < nameVTDK.Count(); i++)
                                {
                                    if (!nameVTDK[i].Equals(""))
                                    {

                                        string sql_sup = "insert into Equipment.AccompaniedSupply values (@supid, @eid, @quan)";
                                        db.Database.ExecuteSqlCommand(sql_sup
                                            , new SqlParameter("@supid", nameVTDK[i])
                                            , new SqlParameter("@eid", emp.equipment_id)
                                            , new SqlParameter("@quan", quantity[i]));
                                    }

                                }
                            }
                        }

                        db.SaveChanges();
                        dbc.Commit();
                        return Search("", "", "", "", "", "", "", "", "");
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                        dbc.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" }, JsonRequestBehavior.AllowGet);

                    }
                }

            }

        }

        [HttpPost]
        public ActionResult Edit(Equipment emp, string import, string inspec, string Insua, string BuyInspec, string BuyInsua, string used, string main, string sk, string sm, CarDB cdb, string yearSX)
        {

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction dbc = db.Database.BeginTransaction())
                {
                    try
                    {
                        string[] date;
                        string date_fix;
                        //import date
                        if (!import.Equals(""))
                        {
                            date = import.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            emp.date_import = Convert.ToDateTime(date_fix);
                        }
                        //durationOfInspection
                        if (!inspec.Equals(""))
                        {
                            date = inspec.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];

                            string check = "select * from Equipment.Inspection e where e.equipment_id = @eid order by inspect_id desc";
                            Inspection checkNull = db.Database.SqlQuery<Inspection>(check, new SqlParameter("eid", emp.equipment_id)).FirstOrDefault();
                            if (checkNull == null)
                            {
                                Inspection temp = new Inspection
                                {
                                    equipment_id = emp.equipment_id,
                                    inspect_date = Convert.ToDateTime(date_fix)
                                };
                                db.Inspections.Add(temp);
                                db.SaveChanges();
                            }
                            else
                            {
                                checkNull.inspect_date = Convert.ToDateTime(date_fix);
                                db.SaveChanges();
                            }

                            emp.duration_of_inspection = Convert.ToDateTime(date_fix);
                        }
                        //BuyOfInsurance
                        if (!BuyInsua.Equals(""))
                        {
                            date = BuyInsua.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            emp.insurance_date = Convert.ToDateTime(date_fix);
                        }
                        //BuyOfInspection
                        if (!BuyInspec.Equals(""))
                        {
                            date = BuyInspec.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            emp.inspect_date = Convert.ToDateTime(date_fix);
                        }
                        //durationOfInsurance
                        if (!Insua.Equals(""))
                        {
                            date = Insua.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            DateTime buyDate;

                            string check = "select * from Equipment.Insurance e where e.equipment_id = @eid order by insurance_id desc";
                            Insurance checkNull = db.Database.SqlQuery<Insurance>(check, new SqlParameter("eid", emp.equipment_id)).FirstOrDefault();
                            if (checkNull == null)
                            {
                                if (emp.insurance_date != null)
                                {
                                    buyDate = emp.insurance_date.Value;
                                }
                                else
                                {
                                    int yearBuy = Convert.ToInt32(date[2]) - 1;
                                    String dateTemp = date[1] + "/" + date[0] + "/" + yearBuy;
                                    buyDate = Convert.ToDateTime(dateTemp);
                                }
                                Insurance temp = new Insurance
                                {
                                    equipment_id = emp.equipment_id,
                                    insurance_start_date = buyDate,
                                    insurance_end_date = Convert.ToDateTime(date_fix),
                                };
                                db.Insurances.Add(temp);
                                db.SaveChanges();
                            }
                            else
                            {
                                db.Database.ExecuteSqlCommand("Update Equipment.Insurance set insurance_end_date = @date where insurance_id = @id"
                                    , new SqlParameter("date", Convert.ToDateTime(date_fix))
                                    , new SqlParameter("id", checkNull.insurance_id));
                                //checkNull.insurance_end_date = Convert.ToDateTime(date_fix);
                                db.SaveChanges();
                            }

                            emp.duration_of_insurance = Convert.ToDateTime(date_fix);
                        }
                        //usedDay
                        if (!used.Equals(""))
                        {
                            date = used.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            emp.used_day = Convert.ToDateTime(date_fix);
                        }
                        //nearest_Maintenance_Day
                        if (!main.Equals(""))
                        {
                            date = main.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            emp.duration_of_maintainance = Convert.ToDateTime(date_fix);
                        }



                        if (sk != "" && sm != "")
                        {
                            Car ca = db.Cars.Where(x => x.equipment_id == emp.equipment_id).FirstOrDefault();
                            ca.chassis_number = sk;
                            ca.engine_number = sm;
                            ca.GPS = cdb.GPS;
                            if (yearSX != "")
                            {
                                ca.manufacture_year = Convert.ToInt32(yearSX);
                            }
                            ca.fuel = cdb.fuel;
                            db.Entry(ca).State = EntityState.Modified;
                        }

                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                        dbc.Commit();
                        return Search("", "", "", "", "", "", "", "", "");

                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                        dbc.Rollback();
                        return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                    }
                }

            }
        }

        //[Auther(RightID = "4")] 
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id != null)
            {
                id = id.Replace("^", " ");
                id = id.Replace("_", ".");
            }
            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_name });

                }
                //
                var categories = db.Categories.ToList<Category>();
                foreach (Category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.equipment_category_id, Value = items.equipment_category_name });
                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                Equipment emp = db.Equipments.Where(x => x.equipment_id == id).FirstOrDefault<Equipment>();
                if (emp == null)
                {
                    emp = new Equipment();
                }
                ViewBag.e = emp;
                if (emp.date_import.HasValue == true)
                {
                    emp.date_import = DateTime.Parse(emp.date_import.Value.ToString("dd-MMM-yyyy"));
                }
                else
                {
                    emp.date_import = null;
                }
                List<SelectListItem> listStatus = new List<SelectListItem>();
                var statsu = db.Status1.ToList<Status1>();
                foreach (Status1 item in statsu)
                {
                    listStatus.Add(new SelectListItem { Text = item.status_id.ToString(), Value = item.status_name });
                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listStatus = listStatus;
                List<SelectListItem> listQuality = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Không có chất lượng", Value = "" },
                    new SelectListItem { Text = "A", Value = "A" },
                    new SelectListItem { Text = "B", Value = "B" },
                    new SelectListItem { Text = "C", Value = "C" }
                };
                ViewBag.listQuality = listQuality;

                List<SelectListItem> listDN = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Đường kế toán", Value = "Đường kế toán" },
                    new SelectListItem { Text = "Đường vật tư", Value = "Đường vật tư" }
                };
                ViewBag.listDN = listDN;
                string query = "Equipment.Get_Equipment_Edit 1, {0}";

                List<SelectListItem> listGPS = new List<SelectListItem>();
                bool t = true;
                listGPS.Add(new SelectListItem { Text = t.ToString(), Value = "Có tín hiệu" });
                t = false;
                listGPS.Add(new SelectListItem { Text = t.ToString(), Value = "Mất tín hiệu" });
                ViewBag.listGPS = listGPS;

                List<SelectListItem> listNL = new List<SelectListItem>();
                t = true;
                listNL.Add(new SelectListItem { Text = t.ToString(), Value = "Có nhiên liệu" });
                t = false;
                listNL.Add(new SelectListItem { Text = t.ToString(), Value = "Hết nhiên liêu" });
                ViewBag.listNL = listNL;

                Car ca = db.Database.SqlQuery<Car>("select * from Equipment.Car where equipment_id = @id", new SqlParameter("id", id + "")).FirstOrDefault();
                if (ca == null)
                {
                    query = "Equipment.Get_Equipment_Edit 1, {0}";
                    Equipment e = db.Database.SqlQuery<CarDB>(query, id).FirstOrDefault();
                    return View(e);
                }
                else
                {
                    CarDB c = db.Database.SqlQuery<CarDB>(query, id).FirstOrDefault();
                    return View(c);
                }
                //return Json(new { success = true, message = "Cập nhật thành công" , data= db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>()}, JsonRequestBehavior.AllowGet);
            }
        }

    }
}