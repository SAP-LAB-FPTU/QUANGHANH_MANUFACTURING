using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.Models;
using System.Data.Entity;
using System.Linq.Dynamic;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.CDVT.Cap_nhat
{
    public class BaoduongController : Controller
    {
        [Auther(RightID = "86")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/bao-duong")]
        [HttpGet]
        public ActionResult Index(string id)
        {
            ViewBag.id = id as string;
            return View("/Views/CDVT/Cap_nhat/Chitiet/Baoduong.cshtml");
        }

        [Auther(RightID = "86")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/bao-duong/GetData")]
        [HttpPost]
        public ActionResult GetData(string id)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Documentary_maintain_detailsDB> equips = DBContext.Database.SqlQuery<Documentary_maintain_detailsDB>("select e.equipmentId, e.equipment_name, depa.department_name, details.finish_date_plan, details.equipment_maintain_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_maintain_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 2 and details.documentary_id = " + id).ToList();
            foreach (Documentary_maintain_detailsDB item in equips)
            {
                item.stringDate = item.finish_date_plan.ToString("dd/MM/yyyy");
                item.statusAndEquip = item.equipment_maintain_status + "^" + item.equipmentId;
                item.idAndEquip = id + "^" + item.equipmentId;
            }
            int totalrows = equips.Count;
            int totalrowsafterfiltering = equips.Count;
            ViewBag.List = equips.Count;
            //sorting
            equips = equips.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_maintain_detailsDB>();
            //paging
            equips = equips.Skip(start).Take(length).ToList<Documentary_maintain_detailsDB>();
            return Json(new { success = true, data = equips, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "86")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/bao-duong/edit")]
        [HttpPost]
        public ActionResult editpost(string edit, string id)
        {
            ViewBag.id = id as string;
            if (edit != "") {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
                {
                    try
                    {
                        edit = edit.Substring(0, edit.Length - 1);
                        char[] spearator = { '^' };
                        String[] list = edit.Split(spearator,
                           StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in list)
                        {
                            Documentary_maintain_details temp = DBContext.Documentary_maintain_details.Find(id, item);
                            temp.equipment_maintain_status = 1;
                            DBContext.SaveChanges();
                        }
                        if (DBContext.Database.SqlQuery<Documentary_maintain_detailsDB>("select details.equipment_maintain_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_maintain_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 2 and details.documentary_id = " + id + " and equipment_maintain_status = '0'").Count() == 0)
                        {
                            Documentary docu = DBContext.Documentaries.Find(id);
                            docu.documentary_status = 2;
                        }

                        DBContext.SaveChanges();
                        transaction.Commit();
                        return new HttpStatusCodeResult(201);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                        return new HttpStatusCodeResult(400);
                    }
                }
            }
            return new HttpStatusCodeResult(201);
        }
    }
}