using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.Models;
using System.Data.Entity;
using System.Linq.Dynamic;
using QUANGHANH2.SupportClass;
using System.Data.SqlClient;

namespace QUANGHANH2.Controllers.CDVT.Cap_nhat
{
    public class BaoduongController : Controller
    {
        [Auther(RightID = "86")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/bao-duong")]
        [HttpGet]
        public ActionResult Index(int id)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                Documentary documentary = DBContext.Database.SqlQuery<Documentary>("SELECT docu.*, docu.[out/in_come] as out_in_come FROM Documentary_maintain_details as detail inner join Documentary as docu on detail.documentary_id = docu.documentary_id WHERE docu.documentary_code IS NOT NULL AND detail.documentary_id = @documentary_id",
                    new SqlParameter("documentary_id", id)).First();
                List<Supply> supplies = DBContext.Supplies.ToList();
                ViewBag.Supplies = supplies;
                if (documentary.documentary_status == 1) ViewBag.AddAble = true;
                else ViewBag.AddAble = false;
                ViewBag.id = documentary.documentary_id;
                ViewBag.code = documentary.documentary_code as string;
                return View("/Views/CDVT/Cap_nhat/Chitiet/Baoduong.cshtml");
            }
            catch (Exception)
            {
                Response.Write("Số quyết định không tồn tại hoặc chưa được cấp");
                return new HttpStatusCodeResult(400);
            }
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
            List<Documentary_maintain_detailsDB> equips = DBContext.Database.SqlQuery<Documentary_maintain_detailsDB>("select e.equipmentId, e.equipment_name, depa.department_name, details.finish_date_plan, details.equipment_maintain_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_maintain_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 2 and details.documentary_id = @documentary_id",
                new SqlParameter("documentary_id", id)).ToList();
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
                        int idnumber = int.Parse(id);
                        edit = edit.Substring(0, edit.Length - 1);
                        char[] spearator = { '^' };
                        String[] list = edit.Split(spearator,
                           StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in list)
                        {
                            Documentary_maintain_details temp = DBContext.Documentary_maintain_details.Find(idnumber, item);
                            temp.equipment_maintain_status = 1;
                            Acceptance a = new Acceptance();
                            a.acceptance_date = DateTime.Now;
                            a.acceptance_result = null;
                            a.documentary_id = idnumber;
                            a.documentary_process_result = null;
                            a.equipmentId = item;
                            a.equipmentStatus = 2;
                            DBContext.Acceptances.Add(a);
                            DBContext.SaveChanges();
                        }
                        if (DBContext.Database.SqlQuery<Documentary_maintain_detailsDB>("select details.equipment_maintain_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_maintain_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 2 and details.documentary_id = @documentary_id and equipment_maintain_status = '0'", new SqlParameter("documentary_id", id)).Count() == 0)
                        {
                            Documentary docu = DBContext.Documentaries.Find(idnumber);
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