using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.History
{
    public class LichsuController : Controller
    {
        [Auther(RightID = "7,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/cap-nhat-hoat-dong")]
        public ActionResult Index()
        {
            // only taken by each department.
            string department_id = Session["departID"].ToString();
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<FuelDB> listEQ; List<Supply> listSupply;
            if (department_id.Contains("PX"))
            {
                 listEQ = db.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from Equipment where department_id = @department_id", new SqlParameter("department_id", department_id)).ToList();
                 listSupply = db.Supplies.Where(x => x.unit == "L" ).ToList();
            }
            else
            {
                 listEQ = db.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from Equipment").ToList();
                 listSupply = db.Supplies.Where(x => x.unit == "L" ).ToList();
            }
            ViewBag.listSupply = listSupply;
            ViewBag.listEQ = listEQ;
            return View("/Views/CDVT/History/Lichsu.cshtml");
        }

        //search acti
        [Route("phong-cdvt/cap-nhat-hoat-dong/search-acti")]
        [HttpPost]
        public ActionResult SearchActi(string equipmentId, string equipmentName, string timeFrom, string timeTo)
        {
            try
            {
                //validate timeFrom when input blank
                if (timeFrom.Trim() == "") {
                    timeFrom = "01/01/1900";
                }
                DateTime timeF = DateTime.ParseExact(timeFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //validate timeTo when input blank
                DateTime timeT;
                if (timeTo.Trim() == "") {
                    timeT = DateTime.Now;
                } else
                {
                    timeT = DateTime.ParseExact(timeTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                //Server Side Parameter
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                // only taken by each department.
                string department_id = Session["departID"].ToString();
                List<activitiesDB> listActi;
                if (department_id.Contains("PX"))
                {
                    string query = "select a.[date], a.equipmentId, e.equipment_name , a.activityname, a.hours_per_day, a.quantity , a.[activityid]"
                                    + " from Activity a ,Equipment e "
                                    + " where e.equipmentId = a.equipmentId AND a.equipmentId LIKE @equipmentId "
                                    + " AND e.equipment_name LIKE @equipment_name AND a.[date] between @timeFrom AND @timeTo "
                                    + " AND e.department_id = @department_id";
                     listActi = DBContext.Database.SqlQuery<activitiesDB>(query,
                        new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                        new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                        new SqlParameter("timeFrom", timeF),
                        new SqlParameter("timeTo", timeT),
                        new SqlParameter("department_id", department_id)
                        ).ToList();
                }
                else
                {
                    string query = "select a.[date], a.equipmentId, e.equipment_name , a.activityname, a.hours_per_day, a.quantity , a.[activityid]"
                                    + " from Activity a ,Equipment e "
                                    + " where e.equipmentId = a.equipmentId AND a.equipmentId LIKE @equipmentId "
                                    + " AND e.equipment_name LIKE @equipment_name AND a.[date] between @timeFrom AND @timeTo ";
                     listActi = DBContext.Database.SqlQuery<activitiesDB>(query,
                        new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                        new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                        new SqlParameter("timeFrom", timeF),
                        new SqlParameter("timeTo", timeT)
                        ).ToList();
                }
                int totalrows = listActi.Count;
                int totalrowsafterfiltering = listActi.Count;
                //sorting
                listActi = listActi.OrderBy(sortColumnName + " " + sortDirection).ToList<activitiesDB>();
                //paging
                listActi = listActi.Skip(start).Take(length).ToList<activitiesDB>();
                
                ViewBag.ListEQ = listActi;
                return Json(new { success = true, data = listActi, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        //search fuel
        [Route("phong-cdvt/cap-nhat-hoat-dong/search-fuel")]
        [HttpPost]
        public ActionResult SearchFuel(string equipmentId, string equipmentName, string timeFrom, string timeTo)
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
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                // only taken by each department.
                string department_id = Session["departID"].ToString();
                List<fuelDB> listFuelConsump;
                if (department_id.Contains("PX"))
                {
                    string query = "select f.fuelId, f.[date], f.equipmentId, e.equipment_name , s.supply_name , f.consumption_value , s.unit"
                                    + " from Fuel_activities_consumption f, Equipment e , Supply s "
                                    + "where e.equipmentId = f.equipmentId and s.supply_id = f.fuel_type AND f.equipmentId LIKE @equipmentId "
                                    + " AND e.equipment_name LIKE @equipment_name AND f.[date] between @timeFrom AND @timeTo "
                                    + " AND e.department_id = @department_id order by f.[date] desc";
                    listFuelConsump = DBContext.Database.SqlQuery<fuelDB>(query,
                       new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                       new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                       new SqlParameter("timeFrom", timeF),
                       new SqlParameter("timeTo", timeT),
                       new SqlParameter("department_id", department_id)
                       ).ToList();
                }
                else
                {
                    string query = "select f.fuelId, f.[date], f.equipmentId, e.equipment_name , s.supply_name , f.consumption_value , s.unit"
                                    + " from Fuel_activities_consumption f, Equipment e , Supply s "
                                    + "where e.equipmentId = f.equipmentId and s.supply_id = f.fuel_type AND f.equipmentId LIKE @equipmentId "
                                    + " AND e.equipment_name LIKE @equipment_name AND f.[date] between @timeFrom AND @timeTo "
                                    + "  order by f.[date] desc";
                    listFuelConsump = DBContext.Database.SqlQuery<fuelDB>(query,
                       new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                       new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                       new SqlParameter("timeFrom", timeF),
                       new SqlParameter("timeTo", timeT)
                       ).ToList();
                }


                int totalrows = listFuelConsump.Count;
                int totalrowsafterfiltering = listFuelConsump.Count;
                //sorting
                listFuelConsump = listFuelConsump.OrderBy(sortColumnName + " " + sortDirection).ToList<fuelDB>();

                //paging
                listFuelConsump = listFuelConsump.Skip(start).Take(length).ToList<fuelDB>();

               

                return Json(new { success = true, data = listFuelConsump, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
      
        public void EditSupply_duphong(String supplyid, int quantity)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Supply_DuPhong duphong = db.Supply_DuPhong.Where(x => x.supply_id == supplyid).FirstOrDefault();
            if (duphong != null)
            {
                duphong.quantity -= quantity;
                db.Entry(duphong).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        //get key of activity to edit
        [Route("phong-cdvt/cap-nhat-hoat-dong/getkeydata-acti")]
        [HttpPost]
        public ActionResult getActivityID(int activityid)
        {
            try
            {
                // only taken by each department.
                string department_id = Session["departID"].ToString();
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                activitiesDB activity = DBContext.Database.SqlQuery<activitiesDB>("select a.activityid,a.[date], a.equipmentId, e.equipment_name , a.activityname, a.hours_per_day, a.quantity " +
                    " from Activity a ,Equipment e  " +
                    " where e.equipmentId = a.equipmentId  " +
                    " and activityid = @activityid AND e.department_id = @department_id "
                    , new SqlParameter("activityid", activityid)
                    , new SqlParameter("department_id", department_id)
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

        //get key of fuel to edit
        [Route("phong-cdvt/cap-nhat-hoat-dong/getkeydata-fuel")]
        [HttpPost]
        public ActionResult getFuelID(int fuelid)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                fuelDB activity = DBContext.Database.SqlQuery<fuelDB>(
                    "select f.fuelId, f.[date], f.equipmentId, f.fuel_type, e.equipment_name , s.supply_name , f.consumption_value , s.unit " +
                    " from Fuel_activities_consumption f, Equipment e , Supply s" +
                    " where e.equipmentId = f.equipmentId and s.supply_id = f.fuel_type and f.fuelId = @fuelid " +
                    " order by f.[date] desc  ", new SqlParameter("fuelid", fuelid)).First();
                activity.stringDate = activity.date.ToString("dd/MM/yyyy");

                return Json(activity);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        //edit activity
        [Auther(RightID = "9,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/cap-nhat-hoat-dong/edit-activity")]
        [HttpPost]
        public ActionResult Edit(float quantity, string activity_name, int hours_per_day, string date1, String equipmentId, int activityid)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    //check
                    //need to check equipment of each department.
                    string department_id = Session["departID"].ToString();
                    //Equipment i = DBContext.Equipments.Find(equipmentId);
                    Equipment i = DBContext.Equipments.Where(x => (x.department_id == department_id &&  x.equipmentId == equipmentId)).First();

                    //Activity q = DBContext.Activities.Where(x => x.activityid == activityid).SingleOrDefault();
                    Activity q = DBContext.Activities.Find(activityid);
                    Activity fixBug = DBContext.Activities.Find(activityid);
                    string oldEq = fixBug.equipmentid;
                    q.equipmentid = i.equipmentId;

                    q.date = DateTime.ParseExact(date1, "dd/MM/yyyy", null);
                    q.hours_per_day = hours_per_day;
                    q.quantity = quantity;
                    q.activityname = activity_name;
                    q.activityid = activityid;
                    DBContext.Entry(q).State = EntityState.Modified;
                    DBContext.SaveChanges();

                    //after update activity.
                    //get old and new.
                    //string oldEq = q.equipmentid;
                    string newEq = equipmentId;

                    //update old:
                    double hoursOld = DBContext.Database.SqlQuery<double>("" +
                        " select sum(hours_per_day) as total  from Activity " +
                        " where equipmentid = @equipmentId"
                        , new SqlParameter("equipmentId", oldEq)).First();
                    int totalHourOld = (int) hoursOld;
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
                        output += "Có lỗi xảy ra";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        //edit fuel
        [Auther(RightID = "9,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/cap-nhat-hoat-dong/edit-fuel")]
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

                    //Equipment i = DBContext.Equipments.Find(equipmentId);
                    Equipment i = DBContext.Equipments.Where(x => (x.department_id == department_id && x.equipmentId == equipmentId)).First();

                    Supply s = DBContext.Database.SqlQuery<Supply>("select * from Supply where supply_id=@supply_id and (unit = 'L')", new SqlParameter("supply_id", fuel_type)).First();
                    fuelDB f = DBContext.Database.SqlQuery<fuelDB>("select * from Fuel_activities_consumption where fuelid=@fuelid", new SqlParameter("fuelid", fuelid)).First();
                    string date = DateTime.ParseExact(date1, "dd/MM/yyyy", null).ToString("MM-dd-yyyy");
                    //AddSupply_tieuhao(DateTime.ParseExact(date1, "dd/MM/yyyy", null), fuel_type, department_id, consumption_value);
                    EditSupply_duphong(fuel_type, consumption_value);
                    DBContext.Database.ExecuteSqlCommand("UPDATE Fuel_activities_consumption  set fuel_type =@fuel_type, [date] =@date1, consumption_value = @consumption_value, equipmentId = @equipmentId where fuelId= @fuelid",
                        new SqlParameter("fuel_type", fuel_type), new SqlParameter("date1", DateTime.ParseExact(date1, "dd/MM/yyyy", null)), new SqlParameter("consumption_value", consumption_value), new SqlParameter("equipmentId", equipmentId), new SqlParameter("fuelId", fuelid));

                    //get old and new.
                    

                    //get update amount of old.
                  

                    DBContext.SaveChanges();
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

        //auto get EquipmentName after entering EquipmentID.
        [Route("phong-cdvt/cap-nhat-hoat-dong/getEQname")]
        [HttpPost]
        public JsonResult returnname(string id)
        {
            try
            {
                // only taken by each department.
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var equipment = db.Equipments.Where(x => x.equipmentId == id).SingleOrDefault();
                return Json(equipment.equipment_name, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Mã thiết bị không tồn tại", JsonRequestBehavior.AllowGet);
            }
        }

        //Add activity
        [Auther(RightID = "8,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/cap-nhat-hoat-dong/add-acti")]
        [HttpPost]
        public ActionResult AddActivity(float quantity, string activity_name, int hours_per_day, string date1, String equipmentId)
        {
            string output = "";
            //fix bug negative number.
            if (quantity <= 0 || hours_per_day <= 0 || hours_per_day > 24)
            {
                return new HttpStatusCodeResult(400);
            }

            // only taken by each department.
            string department_id = Session["departID"].ToString();

            //add function
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            Activity a = new Activity();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Equipment e = DBContext.Equipments.Where(x => (x.department_id == department_id && x.equipmentId == equipmentId)).First();
                    //Equipment e = DBContext.Equipments.Find(equipmentId);
                    a.equipmentid = e.equipmentId;
                    //fix bug
                    a.date = DateTime.ParseExact(date1, "dd/MM/yyyy", null);
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
                        int totalHour = (int)hours;

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

        [Route("phong-cdvt/cap-nhat-hoat-dong/returnsupplyName")]
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

        //Add fuel
        [Auther(RightID = "8,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/cap-nhat-hoat-dong/add-fuel")]
        [HttpPost]
        public ActionResult AddFuel(int consumption_value, string fuel_type, string date1, String equipmentId)
        {
            string output = "";

            // only taken by each department.
            string department_id = Session["departID"].ToString();

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
          
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    //check eq in department.
                  
                    EditSupply_duphong(fuel_type, consumption_value);
                    Equipment e = DBContext.Equipments.Where(x => (x.department_id == department_id && x.equipmentId == equipmentId)).First();
                    //Equipment e = DBContext.Equipments.Find(equipmentId);
                    Supply s = DBContext.Database.SqlQuery<Supply>("select * from Supply where supply_id=@fueltype",new SqlParameter("fueltype",fuel_type)).First();
                    
                    DateTime date = DateTime.ParseExact(date1, "dd/MM/yyyy", null);
                   
                    Fuel_activities_consumption f = DBContext.Database.SqlQuery<Fuel_activities_consumption>("select * from Fuel_activities_consumption " +
                        "where fuel_type=@fueltype and equipmentId=@equipmentid and date=@date", new SqlParameter("fueltype", fuel_type),new SqlParameter("equipmentid",equipmentId),new SqlParameter("date",date)).FirstOrDefault();
                    if (f!=null)
                    {
                        f.consumption_value = f.consumption_value + consumption_value;
                        DBContext.Entry(f).State = EntityState.Modified;

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
                    //get update amount of new.
                    

                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
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

    public class activitiesDB : Activity
    {
        public string stringDate { get; set; }
        public String equipment_name { get; set; }

    }

    public class fuelDB : Fuel_activities_consumption
    {
        public String IDitem { get; set; }
        public string stringDate { get; set; }
        public String equipment_name { get; set; }
        public String unit { get; set; }
        public String supply_name { get; set; }
    }
}