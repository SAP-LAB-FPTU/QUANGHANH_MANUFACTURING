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
    public class ThuhoiController : Controller
    {
        [Auther(RightID = "90,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/thu-hoi")]
        [HttpGet]
        public ActionResult Index(int id)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                string departid = Session["departID"].ToString();
                Documentary documentary;
                if (departid.Contains("PX"))
                {
                    documentary = DBContext.Database.SqlQuery<Documentary>("SELECT docu.*, docu.[out/in_come] as out_in_come FROM Documentary_revoke_details as detail inner join Documentary as docu on detail.documentary_id = docu.documentary_id WHERE docu.documentary_code IS NOT NULL AND detail.documentary_id = @documentary_id and docu.department_id =@departid",
                        new SqlParameter("documentary_id", id),new SqlParameter("departid",departid)).First();
                }
                else
                {
                    documentary = DBContext.Database.SqlQuery<Documentary>("SELECT docu.*, docu.[out/in_come] as out_in_come FROM Documentary_revoke_details as detail inner join Documentary as docu on detail.documentary_id = docu.documentary_id WHERE docu.documentary_code IS NOT NULL AND detail.documentary_id = @documentary_id",
                        new SqlParameter("documentary_id", id)).First();
                }
                if (documentary.documentary_status == 0) ViewBag.AddAble = true;
                else ViewBag.AddAble = false;
                ViewBag.id = documentary.documentary_id;
                ViewBag.code = documentary.documentary_code as string;
                return View("/Views/CDVT/Cap_nhat/Chitiet/Thuhoi.cshtml");
            }
            catch (Exception)
            {
                Response.Write("Số quyết định không tồn tại hoặc chưa được cấp");
                return new HttpStatusCodeResult(400);
            }
        }

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
            string departid = Session["departID"].ToString();
            List<Documentary_revoke_detailsDB> equips;
            if (departid.Contains("PX"))
            {
                equips = DBContext.Database.SqlQuery<Documentary_revoke_detailsDB>("select e.equipment_name, depa.department_name, details.* from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_revoke_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 4 and details.documentary_id = @documentary_id and docu.department_id = @departid",
                    new SqlParameter("documentary_id", id),new SqlParameter("departid",departid)).ToList();
            }
            else
            {
                equips = DBContext.Database.SqlQuery<Documentary_revoke_detailsDB>("select e.equipment_name, depa.department_name, details.* from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_revoke_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 4 and details.documentary_id = @documentary_id",
                    new SqlParameter("documentary_id", id)).ToList();
            }
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

        [Auther(RightID = "90,179,180,181,182,183,184,185,186,187,188,189")]
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
                        int idnumber = int.Parse(id);
                        edit = edit.Substring(0, edit.Length - 1);
                        char[] spearator = { '^' };
                        String[] list = edit.Split(spearator,
                           StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in list)
                        {
                            Documentary_revoke_details temp = DBContext.Documentary_revoke_details.Find(idnumber, item);
                            temp.equipment_revoke_status = 1;
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
                        if (DBContext.Database.SqlQuery<Documentary_revoke_detailsDB>("select details.equipment_revoke_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_revoke_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 4 and details.documentary_id = @documentary_id and equipment_revoke_status = '0'", new SqlParameter("documentary_id", id)).Count() == 0)
                        {
                            Documentary docu = DBContext.Documentaries.Find(idnumber);
                            docu.documentary_status = 2;
                        }

                  
                        DBContext.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}