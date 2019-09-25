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
    public class ThuhoiController : Controller
    {
        [Auther(RightID = "90")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/thu-hoi")]
        [HttpGet]
        public ActionResult Index(string id)
        {
            ViewBag.id = id as string;
            return View("/Views/CDVT/Cap_nhat/Chitiet/Thuhoi.cshtml");
        }

        [Auther(RightID = "90")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/thu-hoi/GetData")]
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
            List<Documentary_revoke_detailsDB> equips = DBContext.Database.SqlQuery<Documentary_revoke_detailsDB>("select e.equipment_name, depa.department_name, details.* from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_revoke_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 4 and details.documentary_id = " + id).ToList();
            foreach (Documentary_revoke_detailsDB item in equips)
            {
                item.statusAndEquip = item.equipment_revoke_status + "^" + item.equipmentId;
                item.idAndEquip = id + "^" + item.equipmentId;
            }
            int totalrows = equips.Count;
            int totalrowsafterfiltering = equips.Count;
            ViewBag.List = equips.Count;
            //sorting
            equips = equips.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_revoke_detailsDB>();
            //paging
            equips = equips.Skip(start).Take(length).ToList<Documentary_revoke_detailsDB>();
            return Json(new { success = true, data = equips, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "90")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/thu-hoi/edit")]
        [HttpPost]
        public ActionResult editpost(string edit, string id)
        {
            if (edit != "")
            {
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
                            Documentary_revoke_details temp = DBContext.Documentary_revoke_details.Find(id, item);
                            temp.equipment_revoke_status = 1;
                            DBContext.SaveChanges();
                        }
                        if (DBContext.Database.SqlQuery<Documentary_revoke_detailsDB>("select details.equipment_revoke_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_revoke_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 4 and details.documentary_id = " + id + " and equipment_revoke_status = '0'").Count() == 0)
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