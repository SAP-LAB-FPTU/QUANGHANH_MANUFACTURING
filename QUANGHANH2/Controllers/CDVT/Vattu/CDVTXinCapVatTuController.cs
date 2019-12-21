using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.CDVT.Vattu
{
    public class CDVTXinCapVatTuController : Controller
    {
        // GET: CDVTXinCapVatTu
        [Auther(RightID = "35")]
        [Route("phong-cdvt/xin-cap-vat-tu")]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Supply> listSupply = db.Supplies.Where(x => x.unit != "L" && x.unit != "kWh").ToList();
            ViewBag.listSupply = listSupply;
            return View("/Views/CDVT/Vattu/CdvtXincapvattu.cshtml");
        }
        [Auther(RightID = "35")]
        [Route("phong-cdvt/xin-cap-vat-tu/getinformationofsupply")]
        [HttpPost]
        public ActionResult GetInformation()
        {
            try
            {

                using (QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities())
                {
                    // only taken by each department.
                   
                    List<Xincap> listequipment;
                    int count = DBContext.SupplyPlans.Where(x => x.departmentid == "CDVT" && x.date.Month == DateTime.Now.Month && x.status == 1).Count();
                    if (count > 0)
                    {
                        string query = @" select id,supplyid,departmentid,equipmentid,quantity_plan,status
from SupplyPlan 
where departmentid='' ";
                        listequipment = DBContext.Database.SqlQuery<Xincap>(query).ToList();
                    }
                    else
                    {


                        string query = @" select id,supplyid,departmentid,equipmentid,quantity_plan,status,supply_name,unit
from SupplyPlan inner join Supply on SupplyPlan.supplyid=Supply.supply_id
where departmentid='CDVT' and status=0 and month(date)=month(getdate())";
                        listequipment = DBContext.Database.SqlQuery<Xincap>(query).ToList();
                    }

                 


                    return Json(new
                    {
                        listsupply = listequipment,
                        count = count,

                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
        [Auther(RightID = "35")]
        [Route("phong-cdvt/xin-cap-vat-tu/editoradd")]
        [HttpPost]
        public ActionResult InsertInformation()
        {
            var supplyid = Request["supplyid"];
            var xin_cap = Request["xin_cap"];

            var supplyplanid = Request["supplyplanid"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            string[] listsupplyid = js.Deserialize<string[]>(supplyid);
            string[] listxin_cap = js.Deserialize<string[]>(xin_cap);

            string[] listsupplyplanid = js.Deserialize<string[]>(supplyplanid);

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                //try
                //{

                    string bulk_insert = string.Empty;
                    
                    for (int i = 0; i < listsupplyid.Length; i++)
                    {
                     string sub_insert = $"if exists (select * from SupplyPlan  where id='{listsupplyplanid[i]}')  "+
                                            " begin "+
                                           " update SupplyPlan set "+
                                           $" supplyid = '{listsupplyid[i]}' , date = getdate(),quantity_plan = {Int32.Parse(listxin_cap[i])} "+
                                          $" where id = '{listsupplyplanid[i]}'"+
                                          " end "+
                                          " else "+
                                         " begin  "+
                                         $" insert into Supplyplan(supplyid, departmentid, [date], quantity_plan,quantity, [status]) VALUES('{listsupplyid[i]}', 'CDVT', getdate(), {Int32.Parse(listxin_cap[i])},0, 0) "+
                                         " end;  ";
                        bulk_insert = string.Concat(bulk_insert, sub_insert);

                    }

                   db.Database.ExecuteSqlCommand(bulk_insert);
                    db.SaveChanges();
                    transaction.Commit();
                    return Json("", JsonRequestBehavior.AllowGet);
            //}
            //    catch (Exception)
            //{
            //    transaction.Rollback();

            //    return new HttpStatusCodeResult(400);
            //}
        }
        }
        [Auther(RightID = "35")]
        [Route("phong-cdvt/xin-cap-vat-tu/xincap")]
        [HttpPost]
        public ActionResult XinCap()
        {
           
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("update Supplyplan set status=1,date=getdate() where departmentid='CDVT' and month(date)=month(getDate())"
                  );
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
        [Route("phong-cdvt/xin-cap-vat-tu/returnsupplymaintainName")]
        [HttpPost]
        public JsonResult returnsupplymaintainname(String supplyid)
        {

            try
            {
                
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                var supply = db.Supplies.Where(x => x.supply_id == supplyid).First();
               



                return Json(new
                {
                    supply_name = supply.supply_name,
                    unit = supply.unit,
                   
                }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception)
            {
                return Json(new
                {
                    supply_name = "0",
                    unit = "0",
                   
                }, JsonRequestBehavior.AllowGet);
            }

        }
    }
    public class Xincap
    {
        public int id { get; set; }
        public string supplyid { get; set; }
        public string departmentid { get; set; }
        public string equipmentid { get; set; }
        public int quantity_plan { get; set; }
       
        public int status { get; set; }
       

        public string supply_name { get; set; }
        public string unit { get; set; }

    }
}