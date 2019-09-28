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
using QUANGHANHCORE.Controllers.CDVT.History;

namespace QUANGHANHCORE.Controllers.CDVT.Oto
{
    public class SuachuahangngayController : Controller
    {
        [Route("phong-cdvt/oto/bao-duong-hang-ngay")]
        [HttpGet]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Equipment> listEQ = db.Equipments.ToList<Equipment>();
            List<Supply> listSupply = db.Supplies.ToList<Supply>();

            ViewBag.listSupply = listSupply;
            ViewBag.listEQ = listEQ;
            return View("/Views/CDVT/Car/baoduonghangngay.cshtml");
        }
        [Route("phong-cdvt/oto/bao-duong-hang-ngay")]
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

                List<Maintain_CarDB> maintainCar = db.Database.SqlQuery<Maintain_CarDB>("select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content,m.maintainid " +
              "from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId " +
                "inner join Department d on d.department_id = m.departmentid").ToList();




                int totalrows = maintainCar.Count;
                int totalrowsafterfiltering = maintainCar.Count;
                //sorting
                maintainCar = maintainCar.OrderBy(sortColumnName + " " + sortDirection).ToList<Maintain_CarDB>();
                //paging
                maintainCar = maintainCar.Skip(start).Take(length).ToList<Maintain_CarDB>();
                foreach (Maintain_CarDB item in maintainCar)
                {

                    item.stringDate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(new { success = true, data = maintainCar, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-cdvt/oto/bao-duong-hang-ngay/insertMaintainCar")]
        [HttpPost]
        public JsonResult InsertMaintainCar(List<Maintain_Car_DetailDB> maintain, string equipmentId, string department_name, string date, string maintain_content)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //Truncate Table to delete all old records.
                //Check for NULL.

                //try
                //{
                    Equipment e = db.Equipments.Find(equipmentId);
                    //Department d = db.Departments.Find(department_name);
                    Department d = db.Database.SqlQuery<Department>(" select * from Department" +
                    " where department_name like @department_name",
                    new SqlParameter("department_name", department_name)).First();
                    DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);


                    db.Database.ExecuteSqlCommand("insert into Maintain_Car values(@equipmentId, @date, (select department_id from Department where department_name =@department_name),@maintain_content)",
                     new SqlParameter("equipmentId", equipmentId),
                           new SqlParameter("date", DateTime.ParseExact(date, "yyyy-MM-dd", null)),
                           new SqlParameter("department_name", department_name),
                           new SqlParameter("maintain_content", maintain_content));

                    //Loop and insert records.
                    foreach (Maintain_Car_DetailDB item in maintain)
                    {
                        Supply_tieuhao s = db.Supply_tieuhao.Where(x => x.supplyid == item.supplyid && x.departmentid == d.department_id && x.date.Month == dateTime.Month).First();
                        if (item.supplyStatus == 1) { s.used = s.used + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                        else { s.thuhoi = s.thuhoi + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                        db.Entry(s).State = EntityState.Modified;

                        db.Database.ExecuteSqlCommand("insert Maintain_Car_Detail values((select top 1 maintainid from Maintain_Car order by maintainid desc), @supplyid, @quantity, @supplyType, @supplyStatus)",
                           new SqlParameter("supplyid", item.supplyid),
                           new SqlParameter("quantity", item.quantity),
                           new SqlParameter("supplyType", item.supplyType),
                           new SqlParameter("supplyStatus", item.supplyStatus))
                        ;
                    }
                    db.SaveChanges();
                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                //}
                //catch (Exception)
                //{
                //    transaction.Rollback();
                //    string output = "";
                //    if (db.Equipments.Where(x => x.equipmentId == equipmentId).Count() == 0)
                //        output += "Mã thiết bị không tồn tại\n";
                //    if (db.Departments.Where(x => x.department_name == department_name).Count() == 0)
                //        output += "Phân xưởng không tồn tại\n";

                //    if (output == "")
                //        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                //    Response.Write(output);
                //    return Json("Có lỗi xảy ra vui lòng nhập lại ", JsonRequestBehavior.AllowGet);
                //}
            }

        }

        [Route("phong-cdvt/oto/bao-duong-hang-ngay/getMaintainCarDetail")]
        [HttpPost]
        public JsonResult getMaintainCarDetail(int maintainId)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            {
                //Truncate Table to delete all old records.
                //    Maintain_CarDB maintainCar = db.Database.SqlQuery<Maintain_CarDB>("select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content " +
                //"from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId " +
                //  "inner join Department d on d.department_id = m.departmentid where m.maintainid = @maintainId ", new SqlParameter("maintainId", maintainId )).SingleOrDefault();
                //Check for NULL.
                List<Maintain_Car_DetailDB> m = db.Database.SqlQuery<Maintain_Car_DetailDB>("select m.supplyid,s.supply_name,s.unit, m.quantity, m.supplyType, m.supplyStatus from Maintain_Car_Detail m inner " +
"join Supply s on m.supplyid = s.supply_id " +
"where m.maintainid = @maintainId ", new SqlParameter("maintainId", maintainId)).ToList();
                //maintainCar.stringDate = maintainCar.date.ToString("dd/MM/yyyy");

                //Temp temp = new Temp();
                //temp.m = m;
                //temp.maintainCar = maintainCar;
                return Json(m);
            }
        }

        [Route("phong-cdvt/oto/bao-duong-hang-ngay/getMaintainCar")]
        [HttpPost]
        public JsonResult getMaintainCar(int maintainId)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            {
                //Truncate Table to delete all old records.
                Maintain_CarDB maintainCar = db.Database.SqlQuery<Maintain_CarDB>("select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content " +
            "from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId " +
              "inner join Department d on d.department_id = m.departmentid where m.maintainid = @maintainId ", new SqlParameter("maintainId", maintainId)).SingleOrDefault();
                //Check for NULL.

                maintainCar.stringDate = maintainCar.date.ToString("dd/MM/yyyy");

                //Temp temp = new Temp();
                //temp.m = m;
                //temp.maintainCar = maintainCar;
                return Json(maintainCar);
            }
        }

        [Route("phong-cdvt/oto/bao-duong-hang-ngay/search")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string timeFrom, string timeTo, string content, string position)
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
                string query = "select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content,m.maintainid"
                    + " from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId "
                    + " inner join Department d on d.department_id = m.departmentid  "
                    + " where m.equipmentId LIKE @equipmentId"
                    + " AND e.equipment_name LIKE @equipment_name AND m.[date] between @timeFrom AND @timeTo "
                    + " AND d.department_name LIKE @position AND m.maintain_content LIKE @content "
                    + " order by m.[date] desc";

                List<Maintain_CarDB> maintainCar = DBContext.Database.SqlQuery<Maintain_CarDB>(query,
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("timeFrom", timeF),
                    new SqlParameter("timeTo", timeT),
                    new SqlParameter("position", '%' + position + '%'),
                    new SqlParameter("content", '%' + content + '%')
                    ).ToList();

                int totalrows = maintainCar.Count;
                int totalrowsafterfiltering = maintainCar.Count;
                //sorting
                maintainCar = maintainCar.OrderBy(sortColumnName + " " + sortDirection).ToList<Maintain_CarDB>();
                //paging
                maintainCar = maintainCar.Skip(start).Take(length).ToList<Maintain_CarDB>();
                foreach (Maintain_CarDB item in maintainCar)
                {
                    item.stringDate = item.date.ToString("dd/MM/yyyy");
                }

                return Json(new { success = true, data = maintainCar, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-cdvt/oto/bao-duong-hang-ngay/returnEquipmentName")]
        [HttpPost]
        public JsonResult returnname(string id)
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var equipment = db.Database.SqlQuery<FuelDB>("select equipment_name from " +
                        "(select distinct e.equipmentId, e.equipment_name from Equipment e inner join Equipment_category_attribute ea " +
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
                return Json("Mã nhiên liệu không tồn tại", JsonRequestBehavior.AllowGet);
            }

        }
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/edit")]
        [HttpPost]
        public ActionResult EditMaintain(string date, String equipmentId, String department_name, String maintain_content, int maintainid)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Maintain_Car m = new Maintain_Car();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {


                    Department d = db.Departments.Where(x => x.department_name == department_name).FirstOrDefault();
                    //          Maintain_CarDB maintainCar = db.Database.SqlQuery<Maintain_CarDB>("select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content " +
                    //"from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId " +
                    //  "inner join Department d on d.department_id = m.departmentid where m.maintainid = @maintainId ", new SqlParameter("maintainId", maintainid)).SingleOrDefault();

                    m.equipmentid = equipmentId;
                    m.departmentid = d.department_id;
                    m.maintain_content = maintain_content;
                    m.date = DateTime.Parse(DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd"));
                    m.maintainid = maintainid;
                    db.Entry(m).State = EntityState.Modified;

                    db.SaveChanges();
                    transaction.Commit();

                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    string output = "";
                    if (db.Equipments.Where(x => x.equipmentId == equipmentId).Count() == 0)
                        output += "Mã thiết bị không tồn tại\n";

                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        [Route("phong-cdvt/oto/bao-duong-hang-ngay/editMaintainDetail")]
        [HttpPost]
        public ActionResult EditMaintainDetail(List<Maintain_Car_Detail> supplyDetail)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Maintain_Car_Detail m = new Maintain_Car_Detail();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {


                    foreach (Maintain_Car_Detail item in supplyDetail)
                    {
                        if (item.maintaindetailid == 0)
                        {
                            Maintain_Car e = db.Maintain_Car.Where(x => x.maintainid == item.maintainid).FirstOrDefault();
                           
                            Supply_tieuhao su = db.Supply_tieuhao.Where(x => x.supplyid == item.supplyid && x.departmentid == e.departmentid&& x.date.Month == e.date.Month).First();
                            if (item.supplyStatus == 1) { su.used = su.used + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                            else { su.thuhoi = su.thuhoi + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                            db.Entry(su).State = EntityState.Modified;
                            Supply s = db.Supplies.Find(item.supplyid);
                            //db.Database.ExecuteSqlCommand("insert Maintain_Car_Detail values(@maintainid, @supplyid, @quantity, @supplyType, @supplyStatus)",
                            //new SqlParameter("maintainid", item.maintainid), new SqlParameter("supplyid", item.supplyid),
                            //   new SqlParameter("quantity", item.quantity),
                            //   new SqlParameter("supplyType", item.supplyType),
                            //   new SqlParameter("supplyStatus", item.supplyStatus));
                            m.maintainid = item.maintainid;
                            m.quantity = item.quantity;
                            m.supplyid = item.supplyid;
                            m.supplyStatus = item.supplyStatus;
                            m.supplyType = item.supplyType;
                            db.Maintain_Car_Detail.Add(m);

                        }
                        else
                        {
                            Maintain_Car e = db.Maintain_Car.Where(x => x.maintainid == item.maintainid).First();
                            Maintain_Car_Detail ma = db.Maintain_Car_Detail.Where(x => x.maintaindetailid == item.maintaindetailid).First();

                            Supply_tieuhao su = db.Supply_tieuhao.Where(x => x.supplyid == item.supplyid && x.departmentid == e.departmentid && x.date.Month == e.date.Month).First();
                            if (ma.supplyid != item.supplyid)
                            {
                                Supply_tieuhao sup = db.Supply_tieuhao.Where(x => x.supplyid == ma.supplyid && x.departmentid == e.departmentid && x.date.Month == e.date.Month).First();
                                if (ma.supplyStatus == 1) { sup.used = sup.used - ma.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                                else { sup.thuhoi = sup.thuhoi - ma.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                               
                                if (item.supplyStatus == 1) {
                                    su.used = su.used + item.quantity;
                                  }

                                else { su.thuhoi = su.thuhoi + item.quantity; }

                            }
                            else
                            {
                                if (item.supplyStatus == 1)
                                {
                                    su.used = su.used + item.quantity;
                                }
                                else { su.thuhoi = su.thuhoi + item.quantity; }
                            }
                           
                            db.Entry(su).State = EntityState.Modified;
                            Supply s = db.Supplies.Find(item.supplyid);
                            db.Database.ExecuteSqlCommand("update Maintain_Car_Detail set supplyid=@supplyid, quantity=@quantity,supplyType=@supplyType,supplyStatus=@supplyStatus where maintaindetailid=@maintaindetailid",
                           new SqlParameter("supplyid", item.supplyid),
                           new SqlParameter("quantity", item.quantity),
                           new SqlParameter("supplyType", item.supplyType),
                           new SqlParameter("supplyStatus", item.supplyStatus),
                            new SqlParameter("maintaindetailid", item.maintaindetailid))

                        ;

                            //m.quantity = item.quantity;
                            //m.supplyid = item.supplyid;
                            //m.supplyStatus = item.supplyStatus;
                            //m.supplyType = item.supplyType;
                            //m.maintaindetailid = item.maintaindetailid;

                            //db.Entry(item).State = EntityState.Modified;

                        }

                    }



                    db.SaveChanges();
                    transaction.Commit();

                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    string output = "";


                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return new HttpStatusCodeResult(400);
                }
            }
        }
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/returnsupplymaintainName")]
        [HttpPost]
        public JsonResult returnsupplymaintainname(String supplyid)
        {

            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                Supply supply = db.Supplies.Where(x => x.supply_id == supplyid).FirstOrDefault();
                //String item = equipment.supply_name + "^" + equipment.unit;
                return Json(new
                {
                    supply_name = supply.supply_name,
                    unit = supply.unit
                }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception)
            {
                return Json("Mã nhiên liệu không tồn tại", JsonRequestBehavior.AllowGet);
            }

        }
    }
    public class Maintain_CarDB : Maintain_Car
    {

        public String stringDate { get; set; }

        public String equipment_name { get; set; }

        public String department_name { get; set; }

    }
    public class Maintain_Car_DetailDB : Maintain_Car_Detail
    {

        public String supply_name { get; set; }
        public String unit { get; set; }

    }

    //public class Temp
    //{
    //    public List<Maintain_Car_DetailDB> m { get; set; }
    //    public Maintain_CarDB maintainCar { get; set; }
    //}
}