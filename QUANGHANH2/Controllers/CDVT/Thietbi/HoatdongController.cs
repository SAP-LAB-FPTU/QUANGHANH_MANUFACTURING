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

                    string query = "SELECT e.[equipmentId],[equipment_name],[supplier],[date_import],[durationOfMaintainance],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment.Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                                    "FROM Equipment.Equipment e LEFT JOIN General.Department d ON e.department_id = d.department_id LEFT JOIN Equipment.Category ec ON e.Equipment_category_id = ec.Equipment_category_id LEFT JOIN Equipment.Status s on e.current_Status = s.statusid " +
                                    "where e.equipmentId LIKE @equipmentId AND e.equipment_name LIKE @equipment_name  and e.isAttach = 0 ";

                    if (department != "" || quality != "" || dateStart != "" || dateEnd != "" || category != "" || sup != "" || att != "")
                    {
                        if (department != "")
                        {
                            query += "AND d.department_id LIKE @department_name ";
                        }
                        if (quality != "")
                        {
                            query += "AND e.quality_type LIKE @quality ";
                        }
                        if (dateStart != "" || dateEnd != "")
                        {
                            query += "AND e.usedDay between @start_time1 and @start_time2 ";
                        }
                        if (category != "")
                        {
                            query += "AND ec.Equipment_category_name LIKE @cate ";
                        }
                        if (sup != "")
                        {
                            query += "AND e.supplier LIKE @sup ";
                        }
                        if (att != "")
                        {
                            query += "AND e.isAttach like @att ";
                        }
                    }

                    var equipList = db.Database.SqlQuery<EquipWithName>(query,
                                        new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                                        new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                                        new SqlParameter("department_name", '%' + department),
                                        new SqlParameter("quality", '%' + quality + '%'),
                                        new SqlParameter("start_time1", dtStart),
                                        new SqlParameter("start_time2", dtEnd),
                                        new SqlParameter("cate", '%' + category + '%'),
                                        new SqlParameter("sup", '%' + sup + '%'),
                                        new SqlParameter("att", '%' + att + '%')
                                        ).ToList();

                    int k = 2;
                    for (int i = 0; i < equipList.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = equipList.ElementAt(i).equipmentId;
                        excelWorksheet.Cells[k, 2].Value = equipList.ElementAt(i).equipment_name;
                        excelWorksheet.Cells[k, 3].Value = equipList.ElementAt(i).supplier;
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 4].Value = equipList.ElementAt(i).date_import.Value.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 5].Value = equipList.ElementAt(i).depreciation_estimate;
                        excelWorksheet.Cells[k, 6].Value = equipList.ElementAt(i).depreciation_present;
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 7].Value = equipList.ElementAt(i).durationOfInspection.Value.ToString("dd/MM/yyyy");
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 8].Value = equipList.ElementAt(i).durationOfInsurance.Value.ToString("dd/MM/yyyy");
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 9].Value = equipList.ElementAt(i).usedDay.Value.ToString("dd/MM/yyyy");
                        if (equipList.ElementAt(i).durationOfInsurance == null)
                            excelWorksheet.Cells[k, 8].Value = "";
                        else
                            excelWorksheet.Cells[k, 10].Value = equipList.ElementAt(i).durationOfMaintainance.Value.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 11].Value = equipList.ElementAt(i).total_operating_hours;
                        excelWorksheet.Cells[k, 12].Value = equipList.ElementAt(i).statusname;
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
        [Auther(RightID = "3")]
        [Route("phong-cdvt/huy-dong/export2")]
        public void export2()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/download/");
            string filename = "huy-dong-2.xlsx";
            FileInfo file = new FileInfo(path + filename);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string query = @"select e.equipment_name, COUNT(e.equipmentId) as 'num',
                                SUM(case when e.current_Status = 2 then 1 else 0 end) as 'sum1',
                                SUM(case when e.current_Status != 2 then 1 else 0 end) as 'sum2'
                                from Equipment.Equipment e
                                where e.isAttach = 0
                                group by e.equipment_name";
                    var equipList = db.Database.SqlQuery<ExportByGroup>(query).ToList();

                    int k = 2;
                    for (int i = 0; i < equipList.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = equipList.ElementAt(i).equipment_name;
                        excelWorksheet.Cells[k, 2].Value = equipList.ElementAt(i).num;
                        excelWorksheet.Cells[k, 3].Value = equipList.ElementAt(i).sum1;
                        excelWorksheet.Cells[k, 4].Value = equipList.ElementAt(i).sum2;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/CDVT/download/baocaohoatdong-2.xlsx")));
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
            EquipThongKe etk = new EquipThongKe();
            var equipList = db.Equipments.ToList<Equipment>();
            etk.total = equipList.Count().ToString();
            var temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary.RepairDetails dr").ToList<Temp>();
            etk.total_repair = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary.MaintainDetails dr").ToList<Temp>();
            etk.total_maintain = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary.BigMaintainDetails dr").ToList<Temp>();
            etk.total_KD = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary.LiquidationDetails dr").ToList<Temp>();
            etk.total_TL = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct dr.equipmentId as 'abc' from Documentary.RevokeDetails dr").ToList<Temp>();
            etk.total_TH = temp.Count().ToString();
            Equipment emp = new Equipment();
            ViewBag.e = emp;
            ViewBag.Thongke = etk;
            List<SelectListItem> listStatus = new List<SelectListItem>();
            var statsu = db.Status1.ToList<Status1>();
            foreach (Status1 item in statsu)
            {
                listStatus.Add(new SelectListItem { Text = item.statusid.ToString(), Value = item.statusname });
            }
            //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
            ViewBag.listStatus = listStatus;
            List<EquipWithName> listID = new List<EquipWithName>();
            ViewBag.listID = listID;
            return View("/Views/CDVT/Hoat_dong.cshtml");
        }

        public class Temp
        {
            public string abc { get; set; }
        }

        //[Route("phong-cdvt/huy-dong")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {

                var equipList = db.Database.SqlQuery<EquipWithName>("SELECT e.[equipmentId],[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment.Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                    "FROM [Equipment] e, Status s, Department d, Equipment_category ec where d.department_id != 'kho' and e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid  and e.isAttach = 0 " +
                    "except " +
                    "select e.[equipmentId],[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present], (select MAX(ei.inspect_date) from Equipment.Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                    "from Equipment.Equipment e inner join Equipment.Car c on e.equipmentId = c.equipmentId, Equipment.Status s, General.Department d, Equipment.Category ec " +
                    "where e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid and e.isAttach = 0 " +
                    " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY").ToList();

                int totalrows = db.Database.SqlQuery<int>("SELECT COUNT(e.[equipmentId]) FROM Equipment.Equipment e, Equipment.Status s, General.Department d, Equipment.Category ec " +
                    "where d.department_id != 'kho' and e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid  and e.isAttach = 0  " +
                    "except select e.[equipmentId] from Equipment.Equipment e inner join Equipment.Car c on e.equipmentId = c.equipmentId, Equipment.Status s, General.Department d, Equipment.Category ec  " +
                    "where e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid").FirstOrDefault();
                List<Department> listDepeartment = db.Departments.ToList<Department>();
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.bolEdit = false;
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
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

        public class ExportByGroup : Equipment
        {
            public string Equipment_category_name { get; set; }
            public Int64 stt { get; set; }
            public int num { get; set; }
            public int sum1 { get; set; }
            public int sum2 { get; set; }
        }
        public class EquipWithName : Equipment
        {
            public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
            public string statusname { get; set; }
            public string Equipment_category_name { get; set; }
            public string department_name { get; set; }
        }

        [Route("phong-cdvt/huy-dong/change")]
        [HttpPost]
        public ActionResult Change(string id)
        {
            ViewBag.listID = null;
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            string sql = "select e.equipmentId from Equipment.Equipment e where e.equipmentId like @id";
            List<EquipWithName> listID = db.Database.SqlQuery<EquipWithName>(sql, new SqlParameter("id", "%" + id + "%")).Take(10).ToList();
            ViewBag.listID = listID;
            string d = "";
            foreach (var item in listID)
            {
                d += "<option value='" + item.equipmentId + "'/>";
            }
            return Json(new { success = true, data = d }, JsonRequestBehavior.AllowGet);


        }

        public class EquipTempSearch
        {
            public string equipmentId { get; set; }
        }

        [HttpPost]
        public ActionResult ChangeID(string id, string ck)
        {
            string sql = "";
            if (ck.Equals("0"))
            {
                sql = @"select e.equipmentId
                        from Equipment.Equipment e
                        where e.equipmentId like @id
                        except
                        select e.equipmentId
                        from Equipment.Equipment e join Equipment.Car c on e.equipmentId = c.equipmentId";
            }
            else if (ck.Equals("1"))
            {
                sql = @"select e.equipment_name as 'equipmentId'
                        from Equipment.Equipment e
                        where e.equipment_name like @id
                        except
                        select e.equipment_name
                        from Equipment.Equipment e join Equipment.Car c on e.equipmentId = c.equipmentId";
            }
            else if (ck.Equals("2"))
            {
                sql = @"select ec.Equipment_category_name as 'equipmentId'
                        from Equipment.Equipment e join Equipment.Category ec on e.Equipment_category_id = ec.Equipment_category_id
                        where ec.Equipment_category_name like @id
                        except
                        select ec.Equipment_category_name
                        from Equipment.Equipment e join Equipment.Car c on e.equipmentId = c.equipmentId
	                        join Equipment.Category ec on e.Equipment_category_id = ec.Equipment_category_id";
            }
            else if (ck.Equals("3"))
            {
                sql = @"select e.supplier as 'equipmentId'
                        from Equipment.Equipment e
                        where e.supplier like @id
                        except
                        select e.supplier
                        from Equipment.Equipment e join Equipment.Car c on e.equipmentId = c.equipmentId";
            }
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<EquipTempSearch> list = db.Database.SqlQuery<EquipTempSearch>(sql, new SqlParameter("id", "%" + id + "%")).Take(10).ToList();
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
                d += "<td>" + item.Equipment_category_attribute_name + "</td>";
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
            if (sortColumnName == null) sortColumnName = "Equipment_category_name";
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
            //Hầu như tất cả các trường đều chuyển thành allow NULL, nếu để like sẽ không thể hiện ra
            string query = "SELECT e.[equipmentId],[equipment_name],[supplier],[date_import],[durationOfMaintainance],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment.Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                "FROM Equipment.Equipment e LEFT JOIN General.Department d ON e.department_id = d.department_id LEFT JOIN Equipment.Category ec ON e.Equipment_category_id = ec.Equipment_category_id LEFT JOIN Equipment.Status s on e.current_Status = s.statusid " +
                "where e.equipmentId LIKE @equipmentId AND e.equipment_name LIKE @equipment_name  and e.isAttach = 0 ";
            string queryTotalRow = @"SELECT count(e.[equipmentId])
                FROM Equipment.Equipment e LEFT JOIN General.Department d ON e.department_id = d.department_id LEFT JOIN Equipment.Category ec ON e.Equipment_category_id = ec.Equipment_category_id LEFT JOIN Equipment.Status s on e.current_Status = s.statusid left join Equipment.Car c on e.equipmentId = c.equipmentId
                where e.equipmentId LIKE @equipmentId AND e.equipment_name LIKE @equipment_name and c.equipmentId is null  and e.isAttach = 0 ";

            if (department != "" || quality != "" || dateStart != "" || dateEnd != "" || category != "" || sup != "" || att != "")
            {
                if (department != "")
                {
                    query += "AND d.department_id LIKE @department_name ";
                    queryTotalRow += "AND d.department_id LIKE @department_name ";
                }
                if (quality != "")
                {
                    query += "AND e.quality_type LIKE @quality ";
                    queryTotalRow += "AND e.quality_type LIKE @quality ";
                }
                if (dateStart != "" || dateEnd != "")
                {
                    query += "AND e.usedDay between @start_time1 and @start_time2 ";
                    queryTotalRow += "AND e.usedDay between @start_time1 and @start_time2 ";
                }
                if (category != "")
                {
                    query += "AND ec.Equipment_category_name LIKE @cate ";
                    queryTotalRow += "AND ec.Equipment_category_name LIKE @cate ";
                }
                if (sup != "")
                {
                    query += "AND e.supplier LIKE @sup ";
                    queryTotalRow += "AND e.supplier LIKE @sup ";
                }
                if (att != "")
                {
                    query += "AND e.isAttach like @att ";
                    queryTotalRow += "AND e.isAttach like @att ";
                }
            }
            query += " except " +
                "select e.[equipmentId],[equipment_name],[supplier],[date_import],[durationOfMaintainance],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment.Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                "from Equipment.Equipment e inner join Equipment.Car c on e.equipmentId = c.equipmentId LEFT JOIN General.Department d ON e.department_id = d.department_id LEFT JOIN Equipment.Category ec ON e.Equipment_category_id = ec.Equipment_category_id LEFT JOIN Equipment.Status s on e.current_Status = s.statusid " +
                "where e.equipmentId LIKE @equipmentId AND e.equipment_name LIKE @equipment_name  and e.isAttach = 0 ";
            if (department != "" || quality != "" || dateStart != "" || dateEnd != "" || category != "" || sup != "" || att != "")
            {
                if (department != "")
                    query += "AND d.department_id LIKE @department_name ";
                if (quality != "")
                    query += "AND e.quality_type LIKE @quality ";
                if (dateStart != "" || dateEnd != "")
                    query += "AND e.usedDay between @start_time1 and @start_time2 ";
                if (category != "")
                    query += "AND ec.Equipment_category_name LIKE @cate ";
                if (sup != "")
                    query += "AND e.supplier LIKE @sup ";
                if (att != "")
                    query += "AND e.isAttach like @att ";
            }

            List<EquipWithName> equiplist = DBContext.Database.SqlQuery<EquipWithName>(query + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", '%' + department),
                new SqlParameter("quality", '%' + quality + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd),
                new SqlParameter("cate", '%' + category + '%'),
                new SqlParameter("sup", '%' + sup + '%'),
                new SqlParameter("att", '%' + att + '%')
                ).ToList();
            int totalrows = DBContext.Database.SqlQuery<int>(queryTotalRow,
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_name", '%' + department),
                new SqlParameter("quality", '%' + quality + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd),
                new SqlParameter("cate", '%' + category + '%'),
                new SqlParameter("sup", '%' + sup + '%'),
                new SqlParameter("att", '%' + att + '%')
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

        public class Supply_DK : Supply_DiKem
        {
            public string equipment_name { get; set; }

        }

        [HttpGet]
        public ActionResult Add()
        {

            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            List<SelectListItem> listStatus = new List<SelectListItem>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<Supply_DK> listsupdk = db.Database.SqlQuery<Supply_DK>("select equipment_name,equipmentId from Equipment.Equipment where isAttach = 1").ToList();
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
                    listCategory.Add(new SelectListItem { Text = items.Equipment_category_id, Value = items.Equipment_category_name });

                }
                var statsu = db.Status1.ToList<Status1>();
                foreach (Status1 item in statsu)
                {
                    listStatus.Add(new SelectListItem { Text = item.statusid.ToString(), Value = item.statusname });
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
            Category category = db.Categories.Find(ec.Equipment_category_id);
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
                                    Equipment_category_id = ec.Equipment_category_id,
                                    Equipment_category_attribute_id = id[i],
                                    unit = unit[i],
                                    Equipment_category_attribute_name = name[i]
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
                        Equipment equipment = db.Equipments.Find(emp.equipmentId);
                        if (equipment != null)
                            return Json(new { success = false, message = "Mã thiết bị đã tồn tại" });
                        //import date
                        if (import != "")
                            emp.date_import = DateTime.ParseExact(import, "dd/MM/yyyy", null);
                        //durationOfInspection
                        if (duraInspec != "")
                            emp.durationOfInspection = DateTime.ParseExact(duraInspec, "dd/MM/yyyy", null);
                        if (Insua != "")
                        {
                            emp.durationOfInsurance = DateTime.ParseExact(Insua, "dd/MM/yyyy", null);
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
                            emp.usedDay = DateTime.ParseExact(used, "dd/MM/yyyy", null);
                        emp.input_channel = "Đường kế toán";
                        emp.department_id = Convert.ToString(Session["departID"]);
                        emp.total_operating_hours = 0;
                        emp.durationOfMaintainance = DateTime.Now;
                        db.Equipments.Add(emp);
                        string sql = "select * from Equipment.CategoryAttribute where Equipment_category_id = @cateid";
                        List<CategoryAttribute> list = db.Database.SqlQuery<CategoryAttribute>(sql, new SqlParameter("cateid", emp.Equipment_category_id)).ToList();
                        if (id != null)
                        {
                            for (int i = 0; i < id.Count(); i++)
                            {
                                if (!id[i].Equals(""))
                                {
                                    QUANGHANH2.Models.Attribute ea = new QUANGHANH2.Models.Attribute
                                    {
                                        equipmentId = emp.equipmentId,
                                        Equipment_attribute_id = id[i],
                                        unit = unit[i],
                                        value = value[i],
                                        Equipment_attribute_name = name[i]
                                    };
                                    db.Attributes.Add(ea);
                                }

                            }
                        }
                        if (sk != "" && sm != "")
                        {
                            Car ca = new Car
                            {
                                equipmentId = emp.equipmentId,
                                sokhung = sk,
                                somay = sm
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
                                ca.nhienlieu = true;
                            }
                            else
                            {
                                ca.nhienlieu = false;
                            }
                            if (yearSX != "")
                            {
                                ca.namsanxuat = Convert.ToInt32(yearSX);
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
                                        Value = attri[i],
                                        equipmentId = emp.equipmentId,
                                        Equipment_category_id = emp.Equipment_category_id,
                                        Equipment_category_attribute_id = list.ElementAt(i).Equipment_category_attribute_id
                                    };
                                    db.CategoryAttributeValues.Add(cav);
                                }
                            }
                        }

                        Inspection ei = new Inspection();
                        if (emp.durationOfInspection != null)
                        {
                            ei.equipmentId = emp.equipmentId;
                            ei.inspect_date = emp.durationOfInspection.Value;
                            db.Inspections.Add(ei);
                        }
                        bool isAc = true;
                        if (attype.Equals("0"))
                        {
                            isAc = false;
                        }
                        emp.isAttach = isAc;
                        db.SaveChanges();

                        if (nameSup != null)
                        {
                            for (int i = 0; i < nameSup.Count(); i++)
                            {
                                if (!nameSup[i].Equals(""))
                                {

                                    string sql_sup = "insert into dbo.Supply_DiKem values (@eid, @supid, @quan, @note, 0)";
                                    db.Database.ExecuteSqlCommand(sql_sup
                                        , new SqlParameter("@supid", nameSup[i])
                                        , new SqlParameter("@eid", emp.equipmentId)
                                        , new SqlParameter("@quan", quantity[i])
                                        , new SqlParameter("@note", ""));
                                }

                            }
                        }

                        db.SaveChanges();

                        if (nameVTDK != null)
                        {
                            if (emp.isAttach == false)
                            {
                                for (int i = 0; i < nameVTDK.Count(); i++)
                                {
                                    if (!nameVTDK[i].Equals(""))
                                    {

                                        string sql_sup = "insert into dbo.Vattu_Dikem values (@supid, @eid, @quan)";
                                        db.Database.ExecuteSqlCommand(sql_sup
                                            , new SqlParameter("@supid", nameVTDK[i])
                                            , new SqlParameter("@eid", emp.equipmentId)
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

                                        string sql_sup = "insert into dbo.Supply_Equipment_DiKem values (@supid, @eid, @quan)";
                                        db.Database.ExecuteSqlCommand(sql_sup
                                            , new SqlParameter("@supid", nameVTDK[i])
                                            , new SqlParameter("@eid", emp.equipmentId)
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

                            string check = "select * from Equipment.Inspection e where e.equipmentId = @eid order by inspect_id desc";
                            Inspection checkNull = db.Database.SqlQuery<Inspection>(check, new SqlParameter("eid", emp.equipmentId)).FirstOrDefault();
                            if (checkNull == null)
                            {
                                Inspection temp = new Inspection
                                {
                                    equipmentId = emp.equipmentId,
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

                            emp.durationOfInspection = Convert.ToDateTime(date_fix);
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

                            string check = "select * from Equipment.Insurance e where e.equipmentId = @eid order by insurance_id desc";
                            Insurance checkNull = db.Database.SqlQuery<Insurance>(check, new SqlParameter("eid", emp.equipmentId)).FirstOrDefault();
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
                                    equipmentId = emp.equipmentId,
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

                            emp.durationOfInsurance = Convert.ToDateTime(date_fix);
                        }
                        //usedDay
                        if (!used.Equals(""))
                        {
                            date = used.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            emp.usedDay = Convert.ToDateTime(date_fix);
                        }
                        //nearest_Maintenance_Day
                        if (!main.Equals(""))
                        {
                            date = main.Split('/');
                            date_fix = date[1] + "/" + date[0] + "/" + date[2];
                            emp.durationOfMaintainance = Convert.ToDateTime(date_fix);
                        }



                        if (sk != "" && sm != "")
                        {
                            Car ca = db.Cars.Where(x => x.equipmentId == emp.equipmentId).FirstOrDefault();
                            ca.sokhung = sk;
                            ca.somay = sm;
                            ca.GPS = cdb.GPS;
                            if (yearSX != "")
                            {
                                ca.namsanxuat = Convert.ToInt32(yearSX);
                            }
                            ca.nhienlieu = cdb.nhienlieu;
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
                    listStatus.Add(new SelectListItem { Text = item.statusid.ToString(), Value = item.statusname });
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
                string query = "SELECT e.department_id,e.Equipment_category_id,e.[equipmentId],e.insurance_date,e.inspect_date,e.[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present],[durationOfInspection],[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name,a.sokhung, a.somay, a.GPS, a.nhienlieu, a.namsanxuat " +
                "from Equipment.Equipment e left outer join Equipment.Car a on a.equipmentId = e.equipmentId, General.Department d, Equipment.Category ec,Equipment.Status s " +
                " where e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id AND e.current_Status = s.statusid AND e.equipmentId LIKE @equipmentId";

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

                Car ca = db.Database.SqlQuery<Car>("select * from Equipment.Car where equipmentId = @id", new SqlParameter("id", id + "")).FirstOrDefault();
                if (ca == null)
                {
                    query = "SELECT e.department_id,e.Equipment_category_id,e.[equipmentId],e.insurance_date,e.inspect_date,e.[equipment_name],[durationOfMaintainance],[supplier],[date_import],[depreciation_estimate],[depreciation_present],[durationOfInspection],[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                        "from Equipment.Equipment e, General.Department d, Equipment.Category ec,Equipment.Status s " +
                        " where e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id AND e.current_Status = s.statusid AND e.equipmentId LIKE @equipmentId";
                    Equipment e = db.Database.SqlQuery<CarDB>(query, new SqlParameter("equipmentId", '%' + id + '%')).FirstOrDefault();
                    return View(e);
                }
                else
                {
                    CarDB c = db.Database.SqlQuery<CarDB>(query, new SqlParameter("equipmentId", '%' + id + '%')).FirstOrDefault();
                    return View(c);
                }
                //return Json(new { success = true, message = "Cập nhật thành công" , data= db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>()}, JsonRequestBehavior.AllowGet);
            }
        }

        //[Route("phong-cdvt/huy-dong/kd")]
        //[HttpPost]
        //public ActionResult EditKD(string id, DateTime date)
        //{
        //    QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
        //    Equipment emp = db.Equipments.Where(e => e.equipmentId == id).FirstOrDefault();
        //    emp.durationOfInspection = date;
        //    db.Entry(emp).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("GetData");
        //    //return Json(new { success = true, message = "Cập nhật thành công" , data= db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>()}, JsonRequestBehavior.AllowGet);

        //}


        //[HttpGet]
        //public ActionResult Delete(string id)
        //{
        //    try
        //    {
        //        using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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