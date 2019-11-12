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

namespace QUANGHANH2.Controllers.Camera
{
    public class ChiTietXuLyQDController : Controller
    {
        [Route("cap-nhat/camera/quyet-dinh/sua-chua")]
        [HttpGet]
        public ActionResult Index(string id)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                Documentary documentary;

                documentary = DBContext.Database.SqlQuery<Documentary>("SELECT docu.*, docu.[out/in_come] as out_in_come FROM Documentary_camera_repair_details as detail inner join Documentary as docu on detail.documentary_id = docu.documentary_id WHERE docu.documentary_code IS NOT NULL AND detail.documentary_id = @documentary_id",
                    new SqlParameter("documentary_id", id)).First();

                List<Supply> supplies = DBContext.Supplies.ToList();
                ViewBag.Supplies = supplies;
                if (documentary.documentary_status == 1) ViewBag.AddAble = true;
                else ViewBag.AddAble = false;
                ViewBag.id = documentary.documentary_id;
                ViewBag.code = documentary.documentary_code as string;
                return View("/Views/Camera/Suachua.cshtml");
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Response.Write("Số quyết định không tồn tại hoặc chưa được cấp");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("cap-nhat/camera/quyet-dinh/sua-chua/GetData")]
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
            List<Documentary_cam_repair_detailsDB> equips;

            equips = DBContext.Database.SqlQuery<Documentary_cam_repair_detailsDB>("select e.camera_id as 'equipmentId', e.camera_name as 'equipment_name', depa.department_name, details.* from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_camera_repair_details details on details.documentary_id = docu.documentary_id inner join Camera e on e.camera_id = details.camera_id where docu.documentary_type = 8 and details.documentary_id = @documentary_id",
               new SqlParameter("documentary_id", id)).ToList();

            foreach (Documentary_cam_repair_detailsDB item in equips)
            {
                //item.stringDate = item.finish_date_plan.ToString("dd/MM/yyyy");
                item.statusAndEquip = item.Documentary_camera_repair_status + "^" + item.equipmentId;
                item.idAndEquip = id + "^" + item.equipmentId;
            }
            int totalrows = equips.Count;
            int totalrowsafterfiltering = equips.Count;
            ViewBag.List = equips.Count;
            //sorting
            equips = equips.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_cam_repair_detailsDB>();
            //paging
            equips = equips.Skip(start).Take(length).ToList<Documentary_cam_repair_detailsDB>();
            return Json(new { success = true, data = equips, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Route("cap-nhat/camera/quyet-dinh/sua-chua/edit")]
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
                            Documentary_camera_repair_details temp = DBContext.Documentary_camera_repair_details.Find(idnumber, item);
                            temp.Documentary_camera_repair_status = 1;
                            Camera_Acceptance a = new Camera_Acceptance();
                            a.acceptance_date = DateTime.Now;
                            a.documentary_id = idnumber;
                            a.camera_id = item;
                            a.cameraStatus = 2;
                            DBContext.Camera_Acceptance.Add(a);
                            DBContext.SaveChanges();
                        }
                        if (DBContext.Database.SqlQuery<Documentary_cam_repair_detailsDB>("select details.Documentary_camera_repair_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id inner join Documentary_camera_repair_details details on details.documentary_id = docu.documentary_id inner join Camera e on e.camera_id = details.camera_id where docu.documentary_type = 8 and details.documentary_id = @documentary_id and Documentary_camera_repair_status = '0'", new SqlParameter("documentary_id", id)).Count() == 0)
                        {
                            Documentary docu = DBContext.Documentaries.Find(idnumber);
                            docu.documentary_status = 2;
                        }

                        DBContext.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                        transaction.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}