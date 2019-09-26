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

namespace QUANGHANHCORE.Controllers.CDVT.History
{
    public class LichsuOtoController : Controller
    {
        [Route("phong-cdvt/oto/cap-nhat-hoat-dong")]
        [HttpGet]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Equipment> listEQ = db.Equipments.ToList<Equipment>();
            List<Supply> listSupply = db.Supplies.ToList<Supply>();

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
                //Server Side Parameter
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                DateTime timeF = DateTime.ParseExact(timeFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime timeT = DateTime.ParseExact(timeTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                string query = "select q.[date], q.equipmentId, t.equipment_name, q.activity_name, q.hours_per_day, q.quantity,q.activity_id"
                    + " from (select distinct e.equipmentId, e.equipment_name "
                    + " from Equipment e inner join Equipment_category_attribute ea  "
                    + " on ea.Equipment_category_id = e.Equipment_category_id and  "
                    + " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') "
                    + " as t inner join Activity q on t.equipmentId = q.equipmentId "
                    + " where q.equipmentId LIKE @equipmentId"
                    + " AND t.equipment_name LIKE @equipment_name AND q.[date] between @timeFrom AND @timeTo "
                    + " order by q.[date] desc";

                List<activitiesDB> listActi = DBContext.Database.SqlQuery<activitiesDB>(query,
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("timeFrom", timeF),
                    new SqlParameter("timeTo", timeT)
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
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            DateTime timeF = DateTime.ParseExact(timeFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime timeT = DateTime.ParseExact(timeTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            string query = "select f.[date], f.equipmentId, t.equipment_name, f.fuel_type, f.consumption_value, s.unit,s.supply_name,fuelId from(select distinct e.equipmentId, e.equipment_name"
                + " from Equipment e inner join Equipment_category_attribute ea "
                + " on ea.Equipment_category_id = e.Equipment_category_id where  "
                + " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') "
                + " as t join Fuel_activities_consumption f  "
                + " on t.equipmentId = f.equipmentId "
                + " join Supply s on s.supply_id = f.fuel_type "
                + " where f.equipmentId LIKE @equipmentId "
                + " AND t.equipment_name LIKE @equipment_name AND f.[date] between @timeFrom AND @timeTo order by f.[date] desc";

            List<fuelDB> listFuelConsump = DBContext.Database.SqlQuery<fuelDB>(query,
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("timeFrom", timeF),
                new SqlParameter("timeTo", timeT)
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



                //db.Configuration.LazyLoadingEnabled = false;
                //List<Department> abc = db.Departments.ToList<Department>();

                //foreach (Equipment e in equipList)
                //{
                //    string name = (from a in db.Equipments join b in db.Departments on a.department_id equals b.department_id where a.equipmentId == e.equipmentId select b.department_name).ToString();
                //    e.department_name = name;
                //}
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
        public ActionResult getActivityID(int activity_id)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                ActivityDB activity = DBContext.Database.SqlQuery<ActivityDB>("select q.[date], q.equipmentId, t.equipment_name, q.activity_name, q.hours_per_day, q.quantity,q.activity_id " +
                    "from (select distinct e.equipmentId, e.equipment_name " +
                    "from Equipment e inner join Equipment_category_attribute ea " +
                    "on ea.Equipment_category_id = e.Equipment_category_id and " +
                    "ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = 'So may') " +
                    "as t inner join Activity q on t.equipmentId = q.equipmentId where activity_id=@activity_id", new SqlParameter("activity_id", activity_id)
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

        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/edit")]
        [HttpPost]
        public ActionResult Edit(float quantity, string activity_name, int hours_per_day, string date1, String equipmentId, int activityid)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {

                try
                {
                    Equipment i = DBContext.Equipments.Find(equipmentId);

                    //Activity q = DBContext.Activities.Where(x => x.activity_id == activityid).SingleOrDefault();
                    Activity q = DBContext.Activities.Find(activityid);
                    q.equipmentid = i.equipmentId;
                    string date = DateTime.ParseExact(date1, "dd/MM/yyyy", null).ToString("MM-dd-yyyy");
                    q.date = DateTime.Parse(date);
                    q.hours_per_day = hours_per_day;
                    q.quantity = quantity;
                    q.activityname = activity_name;
                    q.activityid = activityid;
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

                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }


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
                    Equipment e = DBContext.Equipments.Find(equipmentId);

                    a.equipmentid = e.equipmentId;
                    string date = DateTime.ParseExact(date1, "yyyy-MM-dd", null).ToString("yyyy-MM-dd");
                    a.date = DateTime.Parse(date);
                    a.quantity = quantity;
                    a.hours_per_day = hours_per_day;
                    a.activityname = activity_name;

                    DBContext.Activities.Add(a);
                    DBContext.SaveChanges();
                    transaction.Commit();
                    DBContext.SaveChanges();
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
                                                   "join Supply s on s.supply_id = f.fuel_type where fuelId=@fuelid", new SqlParameter("fuelId", fuelid)).First();
                activity.stringDate = activity.date.ToString("dd/MM/yyyy");

                return Json(activity);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("returnEquipmentName")]
        [HttpPost]
        public JsonResult returnname(string id)
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var equipment = db.Database.SqlQuery<FuelDB>("select equipment_name from " +
"(select distinct e.equipmentId, e.equipment_name from Equipment e inner join Equipment_category_attribute ea " +
                                               "  on ea.Equipment_category_id = e.Equipment_category_id where " +
                                                 "ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
"where equipmentId = @id", new SqlParameter("id", id)).SingleOrDefault();

                return Json(equipment.equipment_name, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Mã thiết bị cơ giới không tồn tại", JsonRequestBehavior.AllowGet);
            }

        }

        [Route("returnsupplyName")]
        [HttpPost]
        public JsonResult returnsupplyname(String fuel_type)
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var equipment = db.Supplies.Where(x => x.supply_id == fuel_type).SingleOrDefault();
                String item = equipment.supply_name + "^" + equipment.unit;
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Mã nhien lieu không tồn tại", JsonRequestBehavior.AllowGet);
            }

        }

        [Route("phong-cdvt/oto/cap-nhat-hoat-dong/edit-fuel")]
        [HttpPost]
        public ActionResult EditFuel(int consumption_value, string fuel_type, string date1, String equipmentId, int fuelid)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {

                try
                {
                    Equipment i = DBContext.Equipments.Find(equipmentId);
                    Supply s = DBContext.Database.SqlQuery<Supply>("select * from Supply where supply_id='" + fuel_type + "'").First();
                    FuelDB f = DBContext.Database.SqlQuery<FuelDB>("select * from Fuel_activities_consumption where fuelid=" + fuelid + "").First();
                    string date = DateTime.ParseExact(date1, "dd/MM/yyyy", null).ToString("MM-dd-yyyy");
                    DBContext.Database.ExecuteSqlCommand("UPDATE Fuel_activities_consumption  set fuel_type =@fuel_type, [date] =@date1, consumption_value = @consumption_value, equipmentId = @equipmentId where fuelId= @fuelid",
                        new SqlParameter("fuel_type", fuel_type), new SqlParameter("date1", date), new SqlParameter("consumption_value", consumption_value), new SqlParameter("equipmentId", equipmentId), new SqlParameter("fuelId", fuelid));

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
                    if (DBContext.Supplies.Where(x => x.supply_id == fuel_type).Count() == 0)
                        output += "Mã Nhiên Liệu không tồn tại\n";
                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        [Route("addfuel")]
        [HttpPost]
        public ActionResult AddFuel(int consumption_value, string fuel_type, string date1, String equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            FuelDB f = new FuelDB();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                string output = "";
                //fix bug negative number.
                if (consumption_value <= 0)
                {
                    return new HttpStatusCodeResult(400);
                }
                try
                {

                    Equipment e = DBContext.Equipments.Find(equipmentId);
                    Supply s = DBContext.Database.SqlQuery<Supply>("select * from Supply where supply_id='" + fuel_type + "'").First();

                    if (e.equipmentId == equipmentId && s.supply_id == fuel_type && f.date.Equals(date1))
                    {
                        f.consumption_value = f.consumption_value + consumption_value;
                    }
                    else
                    {

                        Fuel_activities_consumption fuel_Activities_Consumption = new Fuel_activities_consumption()
                        {
                            consumption_value = consumption_value,
                            equipmentId = equipmentId,
                            fuel_type = fuel_type,
                            date = DateTime.ParseExact(date1, "yyyy-MM-dd", null)
                        };
                        DBContext.Fuel_activities_consumption.Add(fuel_Activities_Consumption);
                    }


                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
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
        public int fuelId { get; set; }
    }
}