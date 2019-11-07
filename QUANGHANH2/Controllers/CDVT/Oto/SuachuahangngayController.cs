﻿using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using QUANGHANHCORE.Controllers.CDVT.History;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Oto
{
    public class SuachuahangngayController : Controller
    {
        [Auther(RightID = "188")]
        [Route("phong-cdvt/oto/bao-duong-hang-ngay")]
        [HttpGet]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<FuelDB> listEQ = db.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from " +
               " (select distinct e.equipmentId, e.equipment_name from Equipment e inner join Equipment_category_attribute ea " +
               "  on ea.Equipment_category_id = e.Equipment_category_id where " +
               " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t "
            ).ToList();
            List<Supply> listSupply = db.Supplies.Where(x => x.unit != "L" && x.unit != "kWh").ToList();
            List<Department> listDepartment = db.Departments.ToList<Department>();

            ViewBag.listDepartment = listDepartment;
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

                    item.stringDate = item.date.ToString("HH:mm dd/MM/yyyy");
                }
                return Json(new { success = true, data = maintainCar, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }
        public void AddSupply_tieuhao(DateTime date, String supplyid, String department_id, int supplyStatus, int quantity)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Supply_tieuhao supply_tieuhao = new Supply_tieuhao();
            supply_tieuhao.date = date;
            supply_tieuhao.supplyid = supplyid;
            supply_tieuhao.departmentid = department_id;
            supply_tieuhao.quantity = 0;
            if (supplyStatus == 1) { supply_tieuhao.used = quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
            else { supply_tieuhao.thuhoi = quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
            db.Supply_tieuhao.Add(supply_tieuhao);
            db.SaveChanges();
        }
        public void EditSupply_duphong(String supplyid,int quantity)
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
        [Auther(RightID = "188")]
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/insertMaintainCar")]
        [HttpPost]
        public JsonResult InsertMaintainCar(List<Maintain_Car_DetailDB> maintain, string equipmentId, string department_name, string date, string maintain_content, int hour, int minute, int year, int month, int day)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //Truncate Table to delete all old records.
                //Check for NULL.

                try
                {
                    Supply_tieuhao supply_tieuhao = new Supply_tieuhao();
                    Equipment e = db.Equipments.Find(equipmentId);
                    DateTime startDate = new DateTime(year, month, day, hour, minute, 0);
                    //Department d = db.Departments.Find(department_name);
                    Department d = db.Database.SqlQuery<Department>(" select * from Department" +
                    " where department_name like @department_name",
                    new SqlParameter("department_name", department_name)).First();
                    DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", null);


                    db.Database.ExecuteSqlCommand("insert into Maintain_Car values(@equipmentId, @date, (select department_id from Department where department_name =@department_name),@maintain_content)",
                     new SqlParameter("equipmentId", equipmentId),
                     new SqlParameter("date", startDate),
                     new SqlParameter("department_name", department_name),
                     new SqlParameter("maintain_content", maintain_content));

                    //Loop and insert records.
                    foreach (Maintain_Car_DetailDB item in maintain)
                    {
                        EditSupply_duphong(item.supplyid, item.quantity);
                        Supply_tieuhao s = db.Supply_tieuhao.Where(x => x.supplyid == item.supplyid && x.departmentid == e.department_id && x.date.Month == dateTime.Month && x.date.Year == dateTime.Year).FirstOrDefault();
                        if (s == null)
                        {

                            AddSupply_tieuhao(DateTime.ParseExact(date, "dd/MM/yyyy", null), item.supplyid, e.department_id, item.supplyStatus, item.quantity);
                        }
                        else
                        {
                            if (item.supplyStatus == 1) { s.used = s.used + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                            else { s.thuhoi = s.thuhoi + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                            db.Entry(s).State = EntityState.Modified;
                        }

                        db.Database.ExecuteSqlCommand("insert Maintain_Car_Detail values((select top 1 maintainid from Maintain_Car order by maintainid desc), @supplyid, @quantity, @supplyType, @supplyStatus)",
                           new SqlParameter("supplyid", item.supplyid),
                           new SqlParameter("quantity", item.quantity),
                           new SqlParameter("supplyType", item.supplyType),
                           new SqlParameter("supplyStatus", item.supplyStatus));
                        db.SaveChanges();
                    }


                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    string output = "";
                    if (db.Equipments.Where(x => x.equipmentId == equipmentId).Count() == 0)
                        output += "Mã thiết bị không tồn tại\n";
                    if (db.Departments.Where(x => x.department_name == department_name).Count() == 0)
                        output += "Phân xưởng không tồn tại\n";

                    if (output == "")
                        output += "Có lỗi xảy ra, xin vui lòng nhập lại";
                    Response.Write(output);
                    return Json("Có lỗi xảy ra vui lòng nhập lại ", JsonRequestBehavior.AllowGet);
                }
            }

        }
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/getMaintainCarDetail")]
        [HttpPost]
        public JsonResult getMaintainCarDetail(int maintainId)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            {
                List<Maintain_Car_DetailDB> m = db.Database.SqlQuery<Maintain_Car_DetailDB>("select m.supplyid,s.supply_name,s.unit, m.quantity, m.supplyType, m.supplyStatus,m.maintaindetailid from Maintain_Car_Detail m inner " +
                "join Supply s on m.supplyid = s.supply_id " +
                "where m.maintainid = @maintainId ", new SqlParameter("maintainId", maintainId)).ToList();

                return Json(m);
            }
        }
        [Auther(RightID = "188")]
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/getMaintainCar")]
        [HttpPost]
        public JsonResult getMaintainCar(int maintainId)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            {
                //Truncate Table to delete all old records.
                Maintain_CarDB maintainCar = db.Database.SqlQuery<Maintain_CarDB>("select m.[date], m.maintainid ,e.equipment_name, m.equipmentid,d.department_name,m.maintain_content,m.maintainid " +
                          "from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId " +
                          "inner join Department d on d.department_id = m.departmentid where m.maintainid = @maintainId ", new SqlParameter("maintainId", maintainId)).SingleOrDefault();
                //Check for NULL.

                maintainCar.stringDate = maintainCar.date.ToString("HH:mm dd/MM/yyyy");

                //Temp temp = new Temp();
                //temp.m = m;
                //temp.maintainCar = maintainCar;
                return Json(maintainCar);
            }
        }
        [Auther(RightID = "188")]
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/search")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string timeFrom, string timeTo, string content, string position)
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
                string query = "select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content,m.maintainid"
                    + " from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId "
                    + " inner join Department d on d.department_id = m.departmentid  "
                    + " where m.equipmentId LIKE @equipmentId"
                    + " AND e.equipment_name LIKE @equipment_name AND m.[date] between @timeFrom AND @timeTo "
                    + " AND d.department_name LIKE @position AND m.maintain_content LIKE @content "
                    + " AND e.department_id = @department_id order by m.[date] desc";

                List<Maintain_CarDB> maintainCar = DBContext.Database.SqlQuery<Maintain_CarDB>(query,
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("timeFrom", timeF),
                    new SqlParameter("timeTo", timeT),
                    new SqlParameter("position", '%' + position + '%'),
                    new SqlParameter("content", '%' + content + '%'),
                    new SqlParameter("department_id",Session["departID"].ToString())
                    ).ToList();

                int totalrows = maintainCar.Count;
                int totalrowsafterfiltering = maintainCar.Count;
                //sorting
                maintainCar = maintainCar.OrderBy(sortColumnName + " " + sortDirection).ToList<Maintain_CarDB>();
                //paging
                maintainCar = maintainCar.Skip(start).Take(length).ToList<Maintain_CarDB>();
                foreach (Maintain_CarDB item in maintainCar)
                {
                    item.stringDate = item.date.ToString("dd/MM/yyyy HH:mm");
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


        [Auther(RightID = "188")]
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/edit")]
        [HttpPost]
        public ActionResult EditMaintain(string date, String equipmentId, String department_name, String maintain_content, int maintainid, int hour, int minute, int year, int month, int day)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Maintain_Car m = new Maintain_Car();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    DateTime startDate = new DateTime(year, month, day, hour, minute, 0);
                    Department d = db.Departments.Where(x => x.department_name == department_name).FirstOrDefault();
                    

                    m.equipmentid = equipmentId;
                    m.departmentid = d.department_id;
                    m.maintain_content = maintain_content;
                    m.date = startDate;
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
        [Auther(RightID = "188")]
        [Route("phong-cdvt/oto/bao-duong-hang-ngay/editMaintainDetail")]
        [HttpPost]
        public ActionResult EditMaintainDetail(List<Maintain_Car_Detail> supplyDetail)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Maintain_Car_Detail m = new Maintain_Car_Detail();
            Supply_tieuhao supply_tieuhao = new Supply_tieuhao();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //note:  thiếu data db cho supply id
                try
                {
                    //                
                    foreach (Maintain_Car_Detail item in supplyDetail)
                    {
                        Maintain_Car e = db.Maintain_Car.Where(x => x.maintainid == item.maintainid).First();
                        Equipment d = db.Equipments.Where(x => x.equipmentId == e.equipmentid).First();
                        if (item.maintaindetailid == 0)
                        {
                            EditSupply_duphong(item.supplyid, item.quantity);
                            Supply_tieuhao su = db.Supply_tieuhao.Where(x => x.supplyid == item.supplyid && x.departmentid == e.departmentid && x.date.Month == e.date.Month && x.date.Year == e.date.Year).FirstOrDefault();
                            if (su == null)
                            {
                                String test = string.Format("{0:MM/dd/yyyy}", e.date);
                                AddSupply_tieuhao(DateTime.ParseExact(test, "MM/dd/yyyy", null), item.supplyid, e.departmentid, item.supplyStatus, item.quantity);

                            }
                            else
                            {

                                if (item.supplyStatus == 1) { su.used = su.used + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                                else { su.thuhoi = su.thuhoi + item.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                                db.Entry(su).State = EntityState.Modified;
                            }
                            Supply s = db.Supplies.Find(item.supplyid);

                            m.maintainid = item.maintainid;
                            m.quantity = item.quantity;
                            m.supplyid = item.supplyid;
                            m.supplyStatus = item.supplyStatus;
                            m.supplyType = item.supplyType;
                            db.Maintain_Car_Detail.Add(m);
                            db.SaveChanges();
                        }
                        else
                        {

                            Maintain_Car_Detail ma = db.Maintain_Car_Detail.Where(x => x.maintaindetailid == item.maintaindetailid).First();

                            Supply_tieuhao su = db.Supply_tieuhao.Where(x => x.supplyid == item.supplyid && x.departmentid == d.department_id && x.date.Month == e.date.Month && x.date.Year == e.date.Year).FirstOrDefault();

                            if (ma.supplyid != item.supplyid)
                            {
                                Supply_tieuhao sup = db.Supply_tieuhao.Where(x => x.supplyid == ma.supplyid && x.departmentid == e.departmentid && x.date.Month == e.date.Month && x.date.Year == e.date.Year).FirstOrDefault();
                                EditSupply_duphong(item.supplyid, item.quantity);
                                if (ma.supplyStatus == 1) { sup.used = sup.used - ma.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                                else { sup.thuhoi = sup.thuhoi - ma.quantity; /*db.Entry(s).State = EntityState.Modified;*/ }
                                if (su == null)
                                {

                                    String test = string.Format("{0:MM/dd/yyyy}", e.date);
                                    AddSupply_tieuhao(DateTime.ParseExact(test, "MM/dd/yyyy", null), item.supplyid, d.department_id, item.supplyStatus, item.quantity);
                                }
                                else
                                {
                                    if (item.supplyStatus == 1)
                                    {
                                        su.used = su.used + item.quantity;
                                    }

                                    else { su.thuhoi = su.thuhoi + item.quantity; }
                                }

                            }
                            else
                            {
                                EditSupply_duphong(item.supplyid, item.quantity);
                                int old_used = 0, old_thuhoi = 0, new_used = 0, new_thuhoi = 0;
                                if (ma.supplyStatus == 1) old_used = ma.quantity;
                                else old_thuhoi = ma.quantity;
                                if (item.supplyStatus == 1) new_used = item.quantity;
                                else new_thuhoi = item.quantity;
                                su.thuhoi = su.thuhoi + (new_thuhoi - old_thuhoi);
                                su.used = su.used + (new_used - old_used);

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
                            db.SaveChanges();
                        }

                    }




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
                var supply = db.Supplies.Where(x => (x.supply_id == supplyid) && (x.unit != "L" && x.unit != "kWh")).SingleOrDefault();
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