using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using QUANGHANH2.SupportClass;
using QUANGHANH2.Models;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.CDVT.Vattu
{
    public class Xincapvattu1Controller : Controller
    {
        // GET: Xincapvattu1
        [Auther(RightID = "33,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phan-xuong/xin-cap-vat-tu-sctx")]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Supply> listSupply = db.Supplies.Where(x => x.unit != "L" && x.unit != "kWh").ToList();
            ViewBag.listSupply = listSupply;
            return View("/Views/CDVT/Vattu/Xincapvattulan1.cshtml");
        }


        [Auther(RightID = "33,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phan-xuong/xin-cap-vat-tu-sctx/getinformation")]
        [HttpPost]
        public ActionResult GetInformation()
        {
            try
            {

                using (QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities())
                {
                    // only taken by each department.
                    string department_id = Session["departID"].ToString();
                    List<Eq> listequipment;
                    int count = DBContext.SupplyPlans.Where(x => x.departmentid == department_id && x.date.Month == DateTime.Now.Month && x.status == 1).Count();
                    if (count > 0)
                    {
                        string query = "select equipmentId,equipment_name from Equipment inner join Department on Equipment.department_id=Department.department_id " +
                   " where Department.department_id='' ";
                        listequipment = DBContext.Database.SqlQuery<Eq>(query,
                          new SqlParameter("department_id", department_id)
                           ).ToList();
                    }
                    else
                    {


                        string query = "select equipmentId,equipment_name from Equipment inner join Department on Equipment.department_id=Department.department_id " +
                               " where Department.department_id=@department_id ";
                        listequipment = DBContext.Database.SqlQuery<Eq>(query,
                          new SqlParameter("department_id", department_id)
                           ).ToList();
                    }

                    int totalrows = listequipment.Count;
                    int totalrowsafterfiltering = listequipment.Count;


                    return Json(new { success = true, data = listequipment, draw = Request["draw"], recordsTotal = totalrows/*, recordsFiltered = totalrowsafterfiltering*/ }, JsonRequestBehavior.AllowGet);
                } }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            } 
        }
        [Auther(RightID = "33,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phan-xuong/xin-cap-vat-tu-sctx/getListSupply")]
        [HttpPost]
        public JsonResult getListSupply(String equipmentId)
        {
           using(QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            { 

                {
                    List<SupplyPlanDB> m = db.Database.SqlQuery<SupplyPlanDB>("select supp.supplyid, s.supply_name,supp.dinh_muc, s.unit ,supp.quantity_plan,supp.id,(case when su.quantity is null then 0 else su.quantity end) 'quantity'  " +
                   "from Supply s inner join SupplyPlan supp on s.supply_id = supp.supplyid left join Supply_DuPhong su on supp.supplyid=su.supply_id where supp.equipmentid = @equipmentid and status=0", new SqlParameter("equipmentid", equipmentId)).ToList();

                    return Json(m);
                } }
        }

        [Auther(RightID = "33,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phan-xuong/xin-cap-vat-tu-sctx/editoradd")]
        [HttpPost]
        public ActionResult InsertInformation(String equipmentid)
        {


            var supplyid = Request["supplyid"];
            var xin_cap = Request["xin_cap"];
            var general = Request["general"];
            var supplyplanid = Request["supplyplanid"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            string[] listsupplyid = js.Deserialize<string[]>(supplyid);
            string[] listxin_cap = js.Deserialize<string[]>(xin_cap);
            string[] listgeneral = js.Deserialize<string[]>(general);
            string[] listsupplyplanid = js.Deserialize<string[]>(supplyplanid);

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    string sqlQuery = "insert into SupplyPlan(supplyid,departmentid,equipmentid,date,dinh_muc,quantity_plan,quantity,status) values";
                    string bulk_update = string.Empty;
                    DateTime today = DateTime.Today;
                    SupplyPlan s = new SupplyPlan();
                    Equipment e = db.Equipments.Where(x => x.equipmentId == equipmentid).First();
                    for (int i = 0; i < listsupplyid.Length; i++)
                    {
                        if (listsupplyplanid[i].Equals(""))
                        {
                            sqlQuery += " ('" + listsupplyid[i] + "','" + e.department_id + "','" + equipmentid + "','" + DateTime.Now + "'," + Convert.ToDouble(listgeneral[i]) + "," + Int32.Parse(listxin_cap[i]) + ",0,0),";
                        }
                        else
                        {

                            string sub_update = $"UPDATE SupplyPlan SET supplyid= '{listsupplyid[i]}',dinh_muc = {Convert.ToDouble(listgeneral[i])}, quantity_plan = {Int32.Parse(listxin_cap[i])}, [date] = '{today}' WHERE id = {int.Parse(listsupplyplanid[i])}";
                            bulk_update = string.Concat(bulk_update, sub_update);

                        }

                    }
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
                    if (sqlQuery.Length > 107) { db.Database.ExecuteSqlCommand(sqlQuery); }

                    if (bulk_update.Equals("")) { db.Database.ExecuteSqlCommand("update SupplyPlan set supplyid = '', departmentid = '', equipmentid = '', date = '', dinh_muc = '', quantity_plan = '' where id = ''"); }
                    else
                    {
                        db.Database.ExecuteSqlCommand(bulk_update);
                    }
                    db.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Chỉnh sửa thành công" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();

                    return new HttpStatusCodeResult(400);
                }
            }
        }
        [Auther(RightID = "33,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phan-xuong/xin-cap-vat-tu-sctx/xincap")]
        [HttpPost]
        public ActionResult XinCap()
        {
            string department_id = Session["departID"].ToString();
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("update Supplyplan set status=1,date=getdate() where departmentid=@departmentid and month(date)=month(getDate())",
                    new SqlParameter("departmentid", department_id));
                    db.SaveChanges();

                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();

                    return new HttpStatusCodeResult(400);
                }
            }
        }



        [Route("phan-xuong/xin-cap-vat-tu-sctx/returnsupplymaintainName")]
        [HttpPost]
        public JsonResult returnsupplymaintainname(String supplyid)
        {

            try
            {
                int quantity;
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var supply = db.Supplies.Where(x => x.supply_id == supplyid).First();
                var supplyduphong = db.Supply_DuPhong.Where(x => (x.supply_id == supplyid)).SingleOrDefault();
                if (supplyduphong == null) quantity = 0;
                else quantity = supplyduphong.quantity;
                
                

                return Json(new
                {
                    supply_name = supply.supply_name ,
                    unit = supply.unit,
                    quantity = quantity
                }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception)
            { 
                return Json( new {supply_name = "0",
                    unit = "0",
                    quantity = 0}, JsonRequestBehavior.AllowGet);
            }

        }
    }
    public class Eq
    {
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }
    }
    public class SupplyPlanDB : SupplyPlan
    {
        public int duphong { get; set; }
        public string supply_name { get; set; }
        public string unit { get; set; }

    }
}