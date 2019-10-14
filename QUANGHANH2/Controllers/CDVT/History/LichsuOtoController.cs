using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq.Dynamic;
using System.Globalization;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.History
{
    public class LichsuOtoController : Controller
    {
        [Auther(RightID = "13")]
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong")]
        [HttpGet]
        public ActionResult Index()
        {
            // only taken by each department.
            string department_id = Session["departID"].ToString();

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Supply> listSupply = db.Supplies.Where(x => x.unit == "L" || x.unit == "kWh").ToList();

            List<FuelDB> listEQ = db.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from " +
               " (select distinct e.equipmentId, e.equipment_name ,e.department_id from Equipment e inner join Equipment_category_attribute ea " +
               "  on ea.Equipment_category_id = e.Equipment_category_id where " +
               " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
               " where department_id = @department_id", new SqlParameter("department_id", department_id)
            ).ToList();
            ViewBag.listSupply = listSupply;
            ViewBag.listEQ = listEQ;
            return View("/Views/CDVT/History/LichsuOto.cshtml");
        }

        //search acti
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/search-acti")]
        [HttpPost]
        public ActionResult SearchActi(string equipmentId, string equipmentName, string timeFrom, string timeTo)
        {
            try
            {
                //validate timeFrom when input blank
                if (timeFrom.Trim() == "")
                {
                    timeFrom = "01/01/1900";
                }
                DateTime timeF = DateTime.ParseExact(timeFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //validate timeTo when input blank
                DateTime timeT;
                if (timeTo.Trim() == "")
                {
                    timeT = DateTime.Now;
                }
                else
                {
                    timeT = DateTime.ParseExact(timeTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                //Server Side Parameter
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                // only taken by each department.
                string department_id = Session["departID"].ToString();
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                string query = "select q.[date], q.equipmentId, t.equipment_name, q.activityname, q.hours_per_day, q.quantity,q.activityid"
                    + " from (select distinct e.equipmentId, e.equipment_name ,e.department_id "
                    + " from Equipment e inner join Equipment_category_attribute ea  "
                    + " on ea.Equipment_category_id = e.Equipment_category_id and  "
                    + " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') "
                    + " as t inner join Activity q on t.equipmentId = q.equipmentId "
                    + " where q.equipmentId LIKE @equipmentId"
                    + " AND t.equipment_name LIKE @equipment_name AND q.[date] between @timeFrom AND @timeTo "
                    + " ANd t.department_id = @department_id"
                    + " order by q.[date] desc";
                
                List<activitiesDB> listActi = DBContext.Database.SqlQuery<activitiesDB>(query,
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("timeFrom", timeF),
                    new SqlParameter("timeTo", timeT),
                    new SqlParameter("department_id", department_id)
                    ).ToList();

                int totalrows = listActi.Count;
                int totalrowsafterfiltering = listActi.Count;
                //sorting
                listActi = listActi.OrderBy(sortColumnName + " " + sortDirection).ToList<activitiesDB>();
                //paging
                listActi = listActi.Skip(start).Take(length).ToList<activitiesDB>();
                foreach (activitiesDB item in listActi)
                {
                    item.stringDate = item.date.ToString("dd/MM/yyyy");
                }

                return Json(new { success = true, data = listActi, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        //search fuel
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/search-fuel")]
        [HttpPost]
        public ActionResult SearchFuel(string equipmentId, string equipmentName, string timeFrom, string timeTo)
        {
            try {
                //validate timeFrom when input blank
                if (timeFrom.Trim() == "")
                {
                    timeFrom = "01/01/1900";
                }
                DateTime timeF = DateTime.ParseExact(timeFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //validate timeTo when input blank
                DateTime timeT;
                if (timeTo.Trim() == "")
                {
                    timeT = DateTime.Now;
                }
                else
                {
                    timeT = DateTime.ParseExact(timeTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                //Server Side Parameter
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                // only taken by each department.
                string department_id = Session["departID"].ToString();
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                string query = "select f.[date], f.equipmentId, t.equipment_name, f.fuel_type, f.consumption_value, s.unit,s.supply_name,fuelId from(select distinct e.equipmentId, e.equipment_name ,e.department_id"
                    + " from Equipment e inner join Equipment_category_attribute ea "
                    + " on ea.Equipment_category_id = e.Equipment_category_id where  "
                    + " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') "
                    + " as t join Fuel_activities_consumption f  "
                    + " on t.equipmentId = f.equipmentId "
                    + " join Supply s on s.supply_id = f.fuel_type "
                    + " where f.equipmentId LIKE @equipmentId "
                    + " AND t.equipment_name LIKE @equipment_name AND f.[date] between @timeFrom AND @timeTo " 
                    + " AND t.department_id = @department_id "
                    + " order by f.[date] desc";

                List<fuelDB> listFuelConsump = DBContext.Database.SqlQuery<fuelDB>(query,
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("timeFrom", timeF),
                    new SqlParameter("timeTo", timeT),
                    new SqlParameter("department_id", department_id)
                    ).ToList();

                int totalrows = listFuelConsump.Count;
                int totalrowsafterfiltering = listFuelConsump.Count;
                //sorting
                listFuelConsump = listFuelConsump.OrderBy(sortColumnName + " " + sortDirection).ToList<fuelDB>();

                //paging
                listFuelConsump = listFuelConsump.Skip(start).Take(length).ToList<fuelDB>();

                foreach (fuelDB item in listFuelConsump)
                {
                    item.stringDate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(new { success = true, data = listFuelConsump, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }            
        }

        [Route("phong-cdvt/oto/cap-nhat-hoat-dong")]
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
                List<ActivityDB> incidents = db.Database.SqlQuery<ActivityDB>("select q.[date], q.equipmentId, t.equipment_name, q.activity_name, q.hours_per_day, q.quantity,q.activity_id " +
                    "from (select distinct e.equipmentId, e.equipment_name " +
                    "from Equipment e inner join Equipment_category_attribute ea " +
                    "on ea.Equipment_category_id = e.Equipment_category_id and " +
                    "ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') " +
                    "as t inner join Activity q on t.equipmentId = q.equipmentId order by q.[date] desc").ToList();


                int totalrows = incidents.Count;
                int totalrowsafterfiltering = incidents.Count;
                //sorting
                incidents = incidents.OrderBy(sortColumnName + " " + sortDirection).ToList<ActivityDB>();
                //paging
                incidents = incidents.Skip(start).Take(length).ToList<ActivityDB>();
                foreach (ActivityDB item in incidents)
                {

                    item.stringDate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(new { success = true, data = incidents, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/getdata")]
        [HttpPost]
        public ActionResult getActivityID(int activityid)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                ActivityDB activity = DBContext.Database.SqlQuery<ActivityDB>(
                    "select q.[date], q.equipmentId, t.equipment_name, q.activityname, q.hours_per_day, q.quantity,q.activityid " +
                    "from (select distinct e.equipmentId, e.equipment_name " +
                    "from Equipment e inner join Equipment_category_attribute ea " +
                    "on ea.Equipment_category_id = e.Equipment_category_id and " +
                    "ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') " +
                    "as t inner join Activity q on t.equipmentId = q.equipmentId where activityid=@activity_id", new SqlParameter("activity_id", activityid)
                    ).First();
                activity.stringDate = activity.date.ToString("dd/MM/yyyy");

                return Json(activity);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        [Auther(RightID = "15")]
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/edit")]
        [HttpPost]
        public ActionResult Edit(float quantity, string activity_name, int hours_per_day, string date1, String equipmentId, int activityid)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {

                try
                {
                    // only taken by each department.
                    string department_id = Session["departID"].ToString();
                    Equipment i = DBContext.Equipments.Find(equipmentId);
                    
                    //check vehicle eq exist in department
                    FuelDB f = DBContext.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from " +
                        " (select distinct e.equipmentId, e.equipment_name ,e.department_id from Equipment e inner join Equipment_category_attribute ea " +
                        "  on ea.Equipment_category_id = e.Equipment_category_id where " +
                        " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
                        " where department_id = @department_id" +
                        " AND equipmentId = @equipmentId "
                        , new SqlParameter("department_id", department_id)
                        , new SqlParameter("equipmentId", equipmentId)
                    ).First();

                    //Activity q = DBContext.Activities.Where(x => x.activityid == activityid).SingleOrDefault();
                    Activity q = DBContext.Activities.Find(activityid);
                    Activity fixBug = DBContext.Activities.Find(activityid);
                    string oldEq = fixBug.equipmentid;
                    q.equipmentid = i.equipmentId;
                    string date = DateTime.ParseExact(date1, "dd/MM/yyyy", null).ToString("MM-dd-yyyy");
                    q.date = DateTime.Parse(date);
                    q.hours_per_day = hours_per_day;
                    q.quantity = quantity;
                    q.activityname = activity_name;
                    q.activityid = activityid;
                    DBContext.SaveChanges();

                    //after update activity.
                    //get old and new.
                    //string oldEq = q.equipmentid;
                    string newEq = equipmentId;

                    //update old:
                    double hoursOld = DBContext.Database.SqlQuery<double>("" +
                        " select sum(hours_per_day) aequipmentIds total  from Activity " +
                        " where equipmentid = @equipmentId"
                        , new SqlParameter("", oldEq)).First();
                    int totalHourOld = (int)hoursOld;
                    DBContext.Database.ExecuteSqlCommand("update Equipment set total_operating_hours = @hour where equipmentId = @equipmentId",
                        new SqlParameter("hour", totalHourOld),
                        new SqlParameter("equipmentId", oldEq));

                    //update new:
                    double hoursNew = DBContext.Database.SqlQuery<double>("" +
                        " select sum(hours_per_day) as total  from Activity " +
                        " where equipmentid = @equipmentId"
                        , new SqlParameter("equipmentId", newEq)).First();
                    int totalHourNew = (int)hoursNew;
                    DBContext.Database.ExecuteSqlCommand("update Equipment set total_operating_hours = @hour where equipmentId = @equipmentId",
                        new SqlParameter("hour", totalHourNew),
                        new SqlParameter("equipmentId", newEq));

                    transaction.Commit();
                    return new HttpStatusCodeResult(201);
            }
                catch (Exception ex)
            {
                transaction.Rollback();
                string output = "";
                if (DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE equipmentId = N'" + equipmentId + "'").Count() == 0)
                    output += "Mã thiết bị không tồn tại\n";

                if (output == "")
                    output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                Response.Write(output);
                return new HttpStatusCodeResult(400);
            }
        }
        }

        [Auther(RightID = "14")]
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/addactivity")]
        [HttpPost]
        public ActionResult AddActivity(float quantity, string activity_name, int hours_per_day, string date1, String equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            Activity a = new Activity();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                string output = "";
                //fix bug negative number.
                if (quantity <= 0 || hours_per_day <= 0)
                {
                    return new HttpStatusCodeResult(400);
                }
                try
                {
                    // only taken by each department.
                    string department_id = Session["departID"].ToString();

                    //note : need to be fixed
                    Equipment e = DBContext.Equipments.Find(equipmentId);
                    //check vehicle eq exist in department
                    FuelDB f = DBContext.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from " +
                        " (select distinct e.equipmentId, e.equipment_name ,e.department_id from Equipment e inner join Equipment_category_attribute ea " +
                        "  on ea.Equipment_category_id = e.Equipment_category_id where " +
                        " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
                        " where department_id = @department_id" +
                        " AND equipmentId = @equipmentId "
                        , new SqlParameter("department_id", department_id)
                        , new SqlParameter("equipmentId", equipmentId)
                    ).First();

                    a.equipmentid = e.equipmentId;
                    string date = DateTime.ParseExact(date1, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                    a.date = DateTime.Parse(date);
                    a.quantity = quantity;
                    a.hours_per_day = hours_per_day;
                    a.activityname = activity_name;

                    DBContext.Activities.Add(a);
                    DBContext.SaveChanges();

                    //update total_hour
                    int count = DBContext.Database.SqlQuery<int>("select total_operating_hours from Equipment where equipmentid = @equipmentId", new SqlParameter("equipmentId", equipmentId)).First();
                    if (count == 0)
                    {
                        //add first
                        DBContext.Database.ExecuteSqlCommand("update Equipment set total_operating_hours = @hour where equipmentId = @equipmentId",
                            new SqlParameter("hour", hours_per_day),
                            new SqlParameter("equipmentId", equipmentId));
                    }
                    else
                    {
                        //count total hours.
                        double hours = DBContext.Database.SqlQuery<double>("" +
                        " select sum(hours_per_day) as total  from Activity " +
                        " where equipmentid = @equipmentId"
                        , new SqlParameter("equipmentId", equipmentId)).First();
                        //fix bug
                        int totalHour = (int) hours;

                        DBContext.Database.ExecuteSqlCommand("update Equipment set total_operating_hours = @hour where equipmentId = @equipmentId",
                            new SqlParameter("hour", totalHour),
                            new SqlParameter("equipmentId", equipmentId));
                    }
                        transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE equipmentId = N'" + equipmentId + "'").Count() == 0)
                        output += "Mã thiết bị không tồn tại\n";

                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/nhienlieu")]
        [HttpPost]
        public ActionResult GetNhienLieu()
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

                List<FuelDB> nhienlieu = db.Database.SqlQuery<FuelDB>("select f.[date],f.equipmentId, t.equipment_name, f.fuel_type, f.consumption_value, s.unit,s.supply_name,fuelId from " +
                    "(select distinct e.equipmentId, e.equipment_name from Equipment e inner " +
                    "join Equipment_category_attribute ea " +
                    "on ea.Equipment_category_id = e.Equipment_category_id where " +
                    "ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') " +
                    "as t join Fuel_activities_consumption f " +
                    "on t.equipmentId = f.equipmentId " +
                    "join Supply s on s.supply_id = f.fuel_type " +
                    "order by f.[date] ASC").ToList();

                //db.Configuration.LazyLoadingEnabled = false;
                //List<Department> abc = db.Departments.ToList<Department>();

                //foreach (Equipment e in equipList)
                //{
                //    string name = (from a in db.Equipments join b in db.Departments on a.department_id equals b.department_id where a.equipmentId == e.equipmentId select b.department_name).ToString();
                //    e.department_name = name;
                //}
                int totalrows = nhienlieu.Count;
                int totalrowsafterfiltering = nhienlieu.Count;
                //sorting
                nhienlieu = nhienlieu.OrderBy(sortColumnName + " " + sortDirection).ToList<FuelDB>();
                //paging
                nhienlieu = nhienlieu.Skip(start).Take(length).ToList<FuelDB>();
                foreach (FuelDB item in nhienlieu)
                {
                    //item.IDitem = item.date + "^" + item.fuel_type + "^" + item.equipmentId;
                    item.stringDate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(new { success = true, data = nhienlieu, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/getFuel")]
        [HttpPost]
        public ActionResult getFuelID(int fuelid)
        {
            //DateTime date = DateTime.Parse(date1);
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                FuelDB activity = DBContext.Database.SqlQuery<FuelDB>("select f.[date], f.equipmentId, t.equipment_name, f.fuel_type, f.consumption_value, s.unit,s.supply_name,fuelId from(select distinct e.equipmentId, e.equipment_name " +
                                                 "from Equipment e inner join Equipment_category_attribute ea " +
                                                  "on ea.Equipment_category_id = e.Equipment_category_id where " +
                                                  "ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') " +
                                                  "as t join Fuel_activities_consumption f " +
                                                  "on t.equipmentId = f.equipmentId " +
                                                   "join Supply s on s.supply_id = f.fuel_type where fuelId=@fuelid", new SqlParameter("fuelid", fuelid)).First();
                activity.stringDate = activity.date.ToString("dd/MM/yyyy");
                return Json(activity);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/returnEquipmentName")]
        [HttpPost]
        public JsonResult returnname(string id)
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var equipment = db.Database.SqlQuery<FuelDB>("select equipment_name from " +
                    " (select distinct e.equipmentId, e.equipment_name from Equipment e inner join Equipment_category_attribute ea " +
                    " on ea.Equipment_category_id = e.Equipment_category_id where " +
                    " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
                    " where equipmentId = @id", new SqlParameter("id", id)).SingleOrDefault();

                return Json(equipment.equipment_name, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Mã thiết bị cơ giới không tồn tại", JsonRequestBehavior.AllowGet);
            }

        }

        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/returnsupplyName")]
        [HttpPost]
        public JsonResult returnsupplyname(String fuel_type)
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var equipment = db.Supplies.Where(x => (x.supply_id == fuel_type) && (x.unit == "L" || x.unit == "kWh")).SingleOrDefault();
                String item = equipment.supply_name + "^" + equipment.unit;
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Mã nhien lieu không tồn tại", JsonRequestBehavior.AllowGet);
            }

        }

        [Auther(RightID = "15")]
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/edit-fuel")]
        [HttpPost]
        public ActionResult EditFuel(int consumption_value, string fuel_type, string date1, String equipmentId, int fuelid)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    // only taken by each department.
                    string department_id = Session["departID"].ToString();

                    //update 
                    Equipment i = DBContext.Equipments.Find(equipmentId);
                    //check vehicle eq exist in department
                    FuelDB check = DBContext.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from " +
                        " (select distinct e.equipmentId, e.equipment_name ,e.department_id from Equipment e inner join Equipment_category_attribute ea " +
                        "  on ea.Equipment_category_id = e.Equipment_category_id where " +
                        " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
                        " where department_id = @department_id" +
                        " AND equipmentId = @equipmentId "
                        , new SqlParameter("department_id", department_id)
                        , new SqlParameter("equipmentId", equipmentId)
                    ).First();

                    Supply s = DBContext.Database.SqlQuery<Supply>("select * from Supply where supply_id=@supply_id and (unit = 'L' or unit = 'kWh')", new SqlParameter("supply_id", fuel_type)).First();
                    FuelDB f = DBContext.Database.SqlQuery<FuelDB>("select * from Fuel_activities_consumption where fuelid=" + fuelid + "").First();
                    string date = DateTime.ParseExact(date1, "dd/MM/yyyy", null).ToString("MM-dd-yyyy");
                    //Supply_tieuhao supply = DBContext.Supply_tieuhao.Where(x => x.supplyid == fuel_type && x.departmentid == i.department_id && x.date.Month == DateTime.Parse(date).Month && x.date.Year == DateTime.Parse(date).Year).First();
                    DBContext.Database.ExecuteSqlCommand("UPDATE Fuel_activities_consumption  set fuel_type =@fuel_type, [date] =@date1, consumption_value = @consumption_value, equipmentId = @equipmentId where fuelId= @fuelid",
                        new SqlParameter("fuel_type", fuel_type), new SqlParameter("date1", date), new SqlParameter("consumption_value", consumption_value), new SqlParameter("equipmentId", equipmentId), new SqlParameter("fuelId", fuelid));

                    //get old and new.
                    string oldFuelType = f.fuel_type;
                    string newFuelType = fuel_type;
                    string old_departmentId = DBContext.Database.SqlQuery<string>("" +
                        "select department_id from Equipment where equipmentId = " +
                        " (select equipmentId from Fuel_activities_consumption where fuelid=@fuelid)"
                        , new SqlParameter("fuelid", fuelid)).First();
                    string new_departmentId = i.department_id;
                    string old_day = f.date.ToString("MM-dd-yyyy");
                    string new_day = date;

                    //get update amount of old.
                    int update_amount_old = DBContext.Database.SqlQuery<int>("" +
                        " select sum(f.consumption_value) " +
                        " from Fuel_activities_consumption f, Equipment e , Supply s " +
                        " where e.equipmentId = f.equipmentId and s.supply_id = f.fuel_type " +
                        " and MONTH(date) = MONTH(@oldday) " +
                         " and Year(date) = Year(@oldday) " +
                        " and supply_id = @oldFuelType " +
                        " and department_id = @oldDepartmentId "
                        , new SqlParameter("oldday", old_day)
                        , new SqlParameter("oldFuelType", oldFuelType)
                        , new SqlParameter("oldDepartmentId", old_departmentId)).First();

                    
                    DBContext.Database.ExecuteSqlCommand("" +
                        " update Supply_tieuhao set used=@old" +
                        " where MONTH(date) = MONTH(@oldday) " +
                         " and Year(date) = Year(@oldday) " +
                        " and supplyid = @oldFuelType " +
                        " and departmentid = @oldDepartmentId "
                        , new SqlParameter("old", update_amount_old)
                        , new SqlParameter("oldday", old_day)
                        , new SqlParameter("oldFuelType", oldFuelType)
                        , new SqlParameter("oldDepartmentId", old_departmentId));

                    //get update amount of new.
                    int update_amount_new = DBContext.Database.SqlQuery<int>("" +
                        " select sum(f.consumption_value) " +
                        " from Fuel_activities_consumption f, Equipment e , Supply s " +
                        " where e.equipmentId = f.equipmentId and s.supply_id = f.fuel_type " +
                        " and MONTH(date) = MONTH(@newday) " +
                        " and Year(date) = Year(@newday) " +
                        " and supply_id = @newFuelType " +
                        " and department_id = @newDepartmentId "
                        , new SqlParameter("newday", new_day)
                        , new SqlParameter("newFuelType", newFuelType)
                        , new SqlParameter("newDepartmentId", new_departmentId)).First();

                    DBContext.Database.ExecuteSqlCommand("" +
                        " update Supply_tieuhao set used=@new" +
                        " where MONTH(date) = MONTH(@newday) " +
                        " and Year(date) = Year(@newday) " +
                        " and supplyid = @newFuelType " +
                        " and departmentid = @newDepartmentId "
                        , new SqlParameter("new", update_amount_new)
                        , new SqlParameter("newday", new_day)
                        , new SqlParameter("newFuelType", newFuelType)
                        , new SqlParameter("newDepartmentId", new_departmentId));

                    DBContext.SaveChanges();
                    //if (consumption_value < 0)
                    //{
                    //    transaction.Rollback();
                    //    return new HttpStatusCodeResult(400);
                    //}
                    transaction.Commit();
                    return new HttpStatusCodeResult(201);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string output = "";
                    if (DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE equipmentId = N'" + equipmentId + "'").Count() == 0)
                        output += "Mã thiết bị không tồn tại\n";
                    if (DBContext.Supplies.Where(x => (x.supply_id == fuel_type) && (x.unit == "L" || x.unit == "kWh")).Count() == 0)
                        output += "Mã Nhiên Liệu không tồn tại\n";
                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        [Auther(RightID = "14")]
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/addfuel")]
        [HttpPost]
        public ActionResult AddFuel(int consumption_value, string fuel_type, string date1, String equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            //bug : depend on supply_tieuhao.
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    // only taken by each department.
                    string department_id = Session["departID"].ToString();

                    Equipment e = DBContext.Equipments.Find(equipmentId);
                    //check vehicle eq exist in department
                    FuelDB check = DBContext.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from " +
                        " (select distinct e.equipmentId, e.equipment_name ,e.department_id from Equipment e inner join Equipment_category_attribute ea " +
                        "  on ea.Equipment_category_id = e.Equipment_category_id where " +
                        " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
                        " where department_id = @department_id" +
                        " AND equipmentId = @equipmentId "
                        , new SqlParameter("department_id", department_id)
                        , new SqlParameter("equipmentId", equipmentId)
                    ).First();

                    DateTime dateTime = DateTime.ParseExact(date1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Supply s = DBContext.Supplies.Where(x => x.supply_id == fuel_type).First();

                    Supply_tieuhao supp = DBContext.Supply_tieuhao.Where(x => x.supplyid == fuel_type && x.departmentid == e.department_id && x.date.Month == dateTime.Month&& x.date.Year == dateTime.Year).First();


                    int count = DBContext.Database.SqlQuery<ActivityDB>("select f.[date],f.equipmentId, " +
                        "t.equipment_name, f.fuel_type, f.consumption_value, s.unit from (select distinct e.equipmentId," +
                        "e.equipment_name from Equipment e inner join Equipment_category_attribute ea on " +
                        "ea.Equipment_category_id = e.Equipment_category_id where ea.Equipment_category_attribute_name = N'Số khung' " +
                        "or ea.Equipment_category_attribute_name = N'Số máy') as t join Fuel_activities_consumption f " +
                        "on t.equipmentId = f.equipmentId join Supply s on s.supply_id = f.fuel_type where year(date) = @year " +
                        "AND month(date) = @month AND day(date) = @day AND f.equipmentId = @id AND fuel_type = @fuel",
                        new SqlParameter("year", dateTime.Year),
                        new SqlParameter("month", dateTime.Month),
                        new SqlParameter("day", dateTime.Day),
                        new SqlParameter("id", equipmentId),
                        new SqlParameter("fuel", fuel_type)).Count();
                    if (count != 0)
                    {
                        FuelDB temp = DBContext.Database.SqlQuery<FuelDB>("select f.[date],t.equipmentId, t.equipment_name, f.fuel_type, f.consumption_value, s.unit from (select distinct e.equipmentId, e.equipment_name from Equipment e inner join Equipment_category_attribute ea on ea.Equipment_category_id = e.Equipment_category_id where ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t join Fuel_activities_consumption f on t.equipmentId = f.equipmentId join Supply s on s.supply_id = f.fuel_type where year(date) = @year " +
                        "AND month(date) = @month AND day(date) = @day AND t.equipmentId = @id AND fuel_type = @fuel",
                        new SqlParameter("year", dateTime.Year),
                        new SqlParameter("month", dateTime.Month),
                        new SqlParameter("day", dateTime.Day),
                        new SqlParameter("id", equipmentId),
                        new SqlParameter("fuel", fuel_type)).First();
                        int a = temp.consumption_value + consumption_value;
                        DBContext.Database.ExecuteSqlCommand("UPDATE f SET f.consumption_value = @value from Equipment t inner join Fuel_activities_consumption f on t.equipmentId = f.equipmentId join Supply s on s.supply_id = f.fuel_type where year(date) = @year " +
                        "AND month(date) = @month AND day(date) = @day AND t.equipmentId = @id AND fuel_type = @fuel",
                        new SqlParameter("year", dateTime.Year),
                        new SqlParameter("month", dateTime.Month),
                        new SqlParameter("day", dateTime.Day),
                        new SqlParameter("id", equipmentId),
                        new SqlParameter("fuel", fuel_type),
                        new SqlParameter("value", a));
                    }
                    else
                    {

                        Fuel_activities_consumption fuel_Activities_Consumption = new Fuel_activities_consumption()
                        {
                            consumption_value = consumption_value,
                            equipmentId = equipmentId,
                            fuel_type = fuel_type,
                            date = DateTime.ParseExact(date1, "dd/MM/yyyy", null)
                        };
                        DBContext.Fuel_activities_consumption.Add(fuel_Activities_Consumption);
                        DBContext.SaveChanges();
                    }

                    //Update : 
                    //get new
                    string newFuelType = fuel_type;
                    string new_departmentId = e.department_id;
                    string new_day = DateTime.ParseExact(date1, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                    //if (supp != null&& DBContext.Fuel_activities_consumption.Where(x => x.fuel_type == fuel_type && x.date.Month == DateTime.Parse(date1).Month && x.date.Year == DateTime.Parse(date1).Year).Count()==0)
                    //{
                    //    Supply
                    //}
                    //get update amount of new.
                    int update_amount_new = DBContext.Database.SqlQuery<int>("" +
                        " select sum(f.consumption_value) " +
                        " from Fuel_activities_consumption f, Equipment e , Supply s " +
                        " where e.equipmentId = f.equipmentId and s.supply_id = f.fuel_type " +
                        " and MONTH(date) = MONTH(@newday) " +
                        " and YEAR(date) = YEAR(@newday)" +
                        " and supply_id = @newFuelType " +
                        " and department_id = @newDepartmentId "
                        , new SqlParameter("newday", new_day)
                        , new SqlParameter("newFuelType", newFuelType)
                        , new SqlParameter("newDepartmentId", new_departmentId)).First();

                    DBContext.Database.ExecuteSqlCommand("" +
                        " update Supply_tieuhao set used=@new" +
                        " where MONTH(date) = MONTH(@newday) " +
                        " and YEAR(date) = YEAR(@newday) " +
                        " and supplyid = @newFuelType " +
                        " and departmentid = @newDepartmentId "
                        , new SqlParameter("new", update_amount_new)
                        , new SqlParameter("newday", new_day)
                        , new SqlParameter("newFuelType", newFuelType)
                        , new SqlParameter("newDepartmentId", new_departmentId));

                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    string output = "";
                    if (DBContext.Equipments.Where(x => x.equipmentId == equipmentId).Count() == 0)
                        output += "Mã thiết bị không tồn tại\n";

                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }
    }
    public class ActivityDB : Activity
    {
        public string stringDate { get; set; }
        public String equipment_name { get; set; }
    }
    public class FuelDB : Fuel_activities_consumption
    {
        public String IDitem { get; set; }
        public string stringDate { get; set; }
        public String equipment_name { get; set; }
        public String unit { get; set; }
        public String supply_name { get; set; }
    }
}