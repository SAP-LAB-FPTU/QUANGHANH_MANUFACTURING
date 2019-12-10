using QUANGHANH2.Models;
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

namespace QUANGHANH2.Controllers.CDVT.Thietbi
{
    public class SCTXController : Controller
    {
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,189")]
        [Route("phong-cdvt/thiet-bi/sctx")]
        [HttpGet]
        public ActionResult Index()
        {
            string departID = Session["departID"].ToString();
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            //List<FuelDB> listEQ = db.Database.SqlQuery<FuelDB>("select e.equipmentId, e.equipment_name from Equipment e  " +
            //        "EXCEPT " +
            //        "select distinct e.equipmentId,e.equipment_name " +
            //        "from Equipment e inner join Equipment_category_attribute ea on e.Equipment_category_id = ea.Equipment_category_id " +
            //        "where ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy'").ToList();
            List<Supply> listSupply = db.Supplies.Where(x => x.unit != "L" && x.unit != "kWh").ToList();
            List<Department> listDepartment = db.Departments.ToList<Department>();
            List<FuelDB> listEQ = db.Database.SqlQuery<FuelDB>("select e.equipmentId, e.equipment_name from Equipment e where e.department_id = @departID", new SqlParameter("departID", departID)).ToList();

            ViewBag.
            ViewBag.listDepartment = listDepartment;
            ViewBag.listSupply = listSupply;
            ViewBag.listEQ = listEQ;
            return View("/Views/CDVT/Thietbi/SCTX.cshtml");
        }

        //?
        //[Route("phong-cdvt/thiet-bi/sctx")]
        //[HttpPost]
        //public ActionResult GetData()
        //{
        //    //Server Side Parameter
        //    int start = Convert.ToInt32(Request["start"]);
        //    int length = Convert.ToInt32(Request["length"]);
        //    string searchValue = Request["search[value]"];
        //    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
        //    string sortDirection = Request["order[0][dir]"];


        //    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        //    {

        //        List<MaintainDB> maintainCar = db.Database.SqlQuery<MaintainDB>("select m.[date], e.equipment_name, m.equipmentid, d.department_name, m.maintain_content, m.maintain_id " +
        //                        "from Equipment_SCTX m inner join Equipment e on m.equipmentid = e.equipmentId " +
        //                        "inner join Department d on d.department_id = m.department_id  " +
        //                        "inner join (select e.equipmentId, e.equipment_name from Equipment e  " +
        //                        "EXCEPT " +
        //                        "select distinct e.equipmentId,e.equipment_name " +
        //                        "from Equipment e inner join Equipment_category_attribute ea on e.Equipment_category_id = ea.Equipment_category_id " +
        //                        "where ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') a on m.equipmentid = a.equipmentId ").ToList();
        //        int totalrows = maintainCar.Count;
        //        int totalrowsafterfiltering = maintainCar.Count;
        //        //sorting
        //        maintainCar = maintainCar.OrderBy(sortColumnName + " " + sortDirection).ToList<MaintainDB>();
        //        //paging
        //        maintainCar = maintainCar.Skip(start).Take(length).ToList<MaintainDB>();
        //        foreach (MaintainDB item in maintainCar)
        //        {

        //            item.stringDate = item.date.ToString("dd/MM/yyyy");
        //        }
        //        return Json(new { success = true, data = maintainCar, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [Auther(RightID = "179,180,181,182,183,184,185,186,187,189")]
        [Route("phong-cdvt/thiet-bi/sctx/insertMaintainCar")]
        [HttpPost]
        public JsonResult InsertMaintainCar(List<Maintain_DetailDB> maintain, string equipmentId, string department_name, string date, string maintain_content)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //Truncate Table to delete all old records.
                //Check for NULL.

                try
                {
                    Equipment e = db.Equipments.Find(equipmentId);
                    //Department d = db.Departments.Find(department_name);
                    Department d = db.Database.SqlQuery<Department>(" select * from Department" +
                    " where department_name like @department_name",
                    new SqlParameter("department_name", department_name)).First();
                    DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", null);


                    db.Database.ExecuteSqlCommand("insert into Equipment_SCTX values(@equipmentId, @date, (select department_id from Department where department_name =@department_name),@maintain_content)",
                     new SqlParameter("equipmentId", equipmentId),
                     new SqlParameter("date", DateTime.ParseExact(date, "dd/MM/yyyy", null)),
                     new SqlParameter("department_name", department_name),
                     new SqlParameter("maintain_content", maintain_content));

                    //Loop and insert records.
                    string bulk_insert = string.Empty;
                    //Loop and insert records.
                    foreach (Maintain_DetailDB item in maintain)
                    {
                        string sub_insert = $"insert into Equipment_SCTX_Detail(maintain_id, supplyid, quantity, supplyStatus) " +
                              $"VALUES((select top 1 maintain_id from Equipment_SCTX order by maintain_id desc), '{item.supplyid}', {item.quantity}, {item.supplyStatus});" +
                              " update Supply_DuPhong " +
                              $"set quantity = (select quantity from Supply_DuPhong where supply_id = '{item.supplyid}' and equipmentId='{equipmentId}')" + (item.supplyStatus == 1 ? "-" : "+") + $"{item.quantity} " +
                              $" where supply_id = '{item.supplyid}' and equipmentId='{equipmentId}'";
                        bulk_insert = string.Concat(bulk_insert, sub_insert);
                    }
                    db.Database.ExecuteSqlCommand(bulk_insert);

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


        [Auther(RightID = "179,180,181,182,183,184,185,186,187,189")]
        [Route("phong-cdvt/thiet-bi/sctx/getMaintainCarDetail")]
        [HttpPost]
        public JsonResult getMaintainCarDetail(int maintainId)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            {
                List<Maintain_DetailDB> m = db.Database.SqlQuery<Maintain_DetailDB>("select m.supplyid,s.supply_name,s.unit,equipmentid ,m.quantity, m.supplyStatus,m.maintain_detail_id" +
                     " from Equipment_SCTX_Detail m inner join Equipment_SCTX ma on m.maintain_id = ma.maintain_id inner " +
                  " join Supply s on m.supplyid = s.supply_id " +
                 "where m.maintain_id  = @maintainId ", new SqlParameter("maintainId", maintainId)).ToList();

                return Json(m);
            }
        }
        [Route("phong-cdvt/thiet-bi/sctx/getMaintainCar")]
        [HttpPost]
        public JsonResult getMaintainCar(int maintainId)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            {
                //Truncate Table to delete all old records.
                MaintainDB maintainCar = db.Database.SqlQuery<MaintainDB>("select m.[date], e.equipment_name, m.equipmentid, d.department_name, m.maintain_content, m.maintain_id  " +
                                "from Equipment_SCTX m inner join Equipment e on m.equipmentid = e.equipmentId " +
                                "inner join Department d on d.department_id = m.department_id " +
                                "inner join (select e.equipmentId, e.equipment_name from Equipment e  " +
                                "EXCEPT " +
                                "select distinct e.equipmentId,e.equipment_name " +
                                "from Equipment e inner join Equipment_category_attribute ea on e.Equipment_category_id = ea.Equipment_category_id " +
                                "where ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') a on m.equipmentid = a.equipmentId " +
                                " where m.maintain_id = @maintainId ", new SqlParameter("maintainId", maintainId)).SingleOrDefault();
                //Check for NULL.

                maintainCar.stringDate = maintainCar.date.ToString("dd/MM/yyyy");

                //Temp temp = new Temp();
                //temp.m = m;
                //temp.maintainCar = maintainCar;
                return Json(maintainCar);
            }
        }
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,189")]
        [Route("phong-cdvt/thiet-bi/sctx/search")]
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
                string query = "select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content,m.maintain_id"
                    + " from Equipment_SCTX m inner join Equipment e on m.equipmentid = e.equipmentId "
                    + " inner join Department d on d.department_id = m.department_id" +
                    " inner join (select e.equipmentId, e.equipment_name from Equipment e" +
                    " EXCEPT" +
                    " select distinct e.equipmentId,e.equipment_name" +
                    " from Equipment e inner join Equipment_category_attribute ea on e.Equipment_category_id = ea.Equipment_category_id" +
                    " where ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') a on m.equipmentid = a.equipmentId  "
                    + " Where m.equipmentId LIKE @equipmentId"
                    + " AND e.equipment_name LIKE @equipment_name AND m.[date] between @timeFrom AND @timeTo "
                    + " AND d.department_name LIKE @position AND m.maintain_content LIKE @content "
                    + " AND e.department_id = @department_id order by m.[date] desc";

                List<MaintainDB> maintainCar = DBContext.Database.SqlQuery<MaintainDB>(query,
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("timeFrom", timeF),
                    new SqlParameter("timeTo", timeT),
                    new SqlParameter("position", '%' + position + '%'),
                    new SqlParameter("content", '%' + content + '%'),
                    new SqlParameter("department_id", Session["departID"].ToString())
                    ).ToList();

                int totalrows = maintainCar.Count;
                int totalrowsafterfiltering = maintainCar.Count;
                //sorting
                maintainCar = maintainCar.OrderBy(sortColumnName + " " + sortDirection).ToList<MaintainDB>();
                //paging
                maintainCar = maintainCar.Skip(start).Take(length).ToList<MaintainDB>();
               
                return Json(new { success = true, data = maintainCar, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-cdvt/thiet-bi/sctx/returnEquipmentName")]
        [HttpPost]
        public JsonResult returnname(string id)
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var equipment = db.Database.SqlQuery<FuelDB>("select e.equipmentId, e.equipment_name from Equipment e  where  e.equipment_name = @id " +
                                "EXCEPT " +
                                "select distinct e.equipmentId,e.equipment_name " +
                                "from Equipment e inner join Equipment_category_attribute ea on e.Equipment_category_id = ea.Equipment_category_id " +
                                "where ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy' " +
                        "", new SqlParameter("id", id)).SingleOrDefault();
                return Json(equipment.equipmentId, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("Mã thiết bị cơ giới không tồn tại", JsonRequestBehavior.AllowGet);
            }
        }


        [Auther(RightID = "179,180,181,182,183,184,185,186,187,189")]
        [Route("phong-cdvt/thiet-bi/sctx/edit")]
        [HttpPost]
        public ActionResult EditMaintain(string date, String equipmentId, String department_name, String maintain_content, int maintainid)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Equipment_SCTX m = new Equipment_SCTX();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    Department d = db.Departments.Where(x => x.department_name == department_name).FirstOrDefault();
                    //          Maintain_CarDB maintainCar = db.Database.SqlQuery<Maintain_CarDB>("select m.[date],  e.equipment_name, m.equipmentid,d.department_name,m.maintain_content " +
                    //"from Maintain_Car m inner join Equipment e on m.equipmentid = e.equipmentId " +
                    //  "inner join Department d on d.department_id = m.departmentid where m.maintainid = @maintainId ", new SqlParameter("maintainId", maintainid)).SingleOrDefault();

                    m.equipmentId = equipmentId;
                    m.department_id = d.department_id;
                    m.maintain_content = maintain_content;
                    m.date = DateTime.Parse(DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd"));
                    m.maintain_id = maintainid;
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
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,189")]
        [Route("phong-cdvt/thiet-bi/sctx/editMaintainDetail")]
        [HttpPost]
        public ActionResult EditMaintainDetail(List<Equipment_SCTX_Detail> supplyDetail, string equipmentID)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            Equipment_SCTX_Detail m = new Equipment_SCTX_Detail();

            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //note:  thiếu data db cho supply id
                try
                {
                    // 
                    string bulk_insert = string.Empty;
                    foreach (Equipment_SCTX_Detail item in supplyDetail)
                    {
                        string sub_insert = $"if exists (select * from Equipment_SCTX_Detail  where maintain_detail_id={item.maintain_detail_id} ) " +
                      "begin " +
                     "update Equipment_SCTX_Detail set " +
                     $"supplyid = '{item.supplyid}',quantity = {item.quantity},supplyStatus = {item.supplyStatus} " +
                    $" where maintain_detail_id = {item.maintain_detail_id}" +
                     " end " +
                     "else " +
                      "begin " +
                     $" insert into Equipment_SCTX_Detail(maintain_id, supplyid, quantity, supplyStatus) VALUES({item.maintain_id}, '{item.supplyid}', {item.quantity}, {item.supplyStatus}) " +
                  "end;  " +
                    " update Supply_DuPhong " +
                            $"set quantity = (select quantity from Supply_DuPhong where supply_id = '{item.supplyid}' and equipmentId='{equipmentID}')-{item.quantity} " +
                            $" where supply_id = '{item.supplyid}' and equipmentId='{equipmentID}'";
                        bulk_insert = string.Concat(bulk_insert, sub_insert);

                    }

                    db.Database.ExecuteSqlCommand(bulk_insert);


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
        [Route("phong-cdvt/thiet-bi/sctx/returnsupplymaintainName")]
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
    public class MaintainDB : Equipment_SCTX
    {

        public String stringDate { get; set; }

        public String equipment_name { get; set; }

        public String department_name { get; set; }

    }
    public class Maintain_DetailDB : Equipment_SCTX_Detail
    {

        public String supply_name { get; set; }
        public String unit { get; set; }

    }
}
