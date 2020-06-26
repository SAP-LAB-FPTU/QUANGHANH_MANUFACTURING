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
using Newtonsoft.Json.Linq;

namespace QUANGHANH2.Controllers.Camera
{
    public class XuLyQuyetDinhController : Controller
    {
        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/xu-ly/sua-chua")]
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
                return View("/Views/Camera/Quyetdinh/SuaChua/XuLyQuyetDinh.cshtml");
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Response.Write("Số quyết định không tồn tại hoặc chưa được cấp");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-cdvt/camera/xu-ly/sua-chua")]
        [HttpPost]
        public ActionResult GetData(string id)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Documentary_cam_repair_detailsDB> equips;

            equips = DBContext.Database.SqlQuery<Documentary_cam_repair_detailsDB>(@"select r.room_id, r.room_name, depa.department_name, details.*
                from Documentary docu inner join Documentary_camera_repair_details details on details.documentary_id = docu.documentary_id
                inner join Department depa on details.department_id = depa.department_id
                inner join Room r on r.room_id = details.room_id 
                where docu.documentary_type = 8 and details.documentary_id = @documentary_id",
                new SqlParameter("documentary_id", id)).ToList();

            int totalrows = equips.Count;
            int totalrowsafterfiltering = equips.Count;
            ViewBag.List = equips.Count;
            //sorting
            equips = equips.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_cam_repair_detailsDB>();
            //paging
            equips = equips.Skip(start).Take(length).ToList<Documentary_cam_repair_detailsDB>();
            return Json(new { success = true, data = equips, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [Auther(RightID = "193")]
        [Route("cap-nhat/camera/quyet-dinh/sua-chua/edit")]
        [HttpPost]
        public ActionResult editpost(string edit, int id)
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
                            Documentary_camera_repair_details temp = DBContext.Documentary_camera_repair_details.Where(x => x.documentary_id == id && x.room_id == item).FirstOrDefault();
                            temp.Documentary_camera_repair_status = 1;
                            Camera_Acceptance a = new Camera_Acceptance
                            {
                                acceptance_date = DateTime.Now,
                                documentary_id = id,
                                room_id = item,
                                isAcceptance = false
                            };
                            DBContext.Camera_Acceptance.Add(a);
                            DBContext.SaveChanges();
                        }
                        if (DBContext.Database.SqlQuery<int>(@"select count(details.Documentary_camera_repair_status) 
                            from Documentary docu
                            inner join Documentary_camera_repair_details details on details.documentary_id = docu.documentary_id
                            where docu.documentary_type = 8 and details.documentary_id = @documentary_id and Documentary_camera_repair_status = '0'", 
                            new SqlParameter("documentary_id", id)).FirstOrDefault() == 0)
                        {
                            Documentary docu = DBContext.Documentaries.Find(id);
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
        [Route("cap-nhat/camera/quyet-dinh/GetSupply")]
        [HttpPost]
        public ActionResult GetSupply2(string documentary_id, string room_id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Documentary_CameraDB> supplies = DBContext.Database.SqlQuery<Supply_Documentary_CameraDB>("SELECT s1.*, s2.supply_name FROM Supply_Documentary_Camera s1 inner join Supply s2 on s1.supply_id = s2.supply_id WHERE room_id = @room_id AND documentary_id = @documentary_id",
                new SqlParameter("room_id", room_id),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            return Json(supplies);
        }
        [Auther(RightID = "193")]
        [Route("cap-nhat/camera/quyet-dinh/AddSupply")]
        [HttpPost]
        public ActionResult AddSupply(string list, int documentary_id, string room_id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary_camera_repair_details detail = DBContext.Documentary_camera_repair_details
                        .Where(x => x.room_id == room_id && x.documentary_id == documentary_id && x.Documentary_camera_repair_status == 0).FirstOrDefault();
                    if (detail == null)
                        return Json(new { success = false, message = "Không thể chỉnh sửa quyết định đã xử lý" });

                    JObject json = JObject.Parse(list);
                    JArray arr = (JArray)json.SelectToken("list");
                    foreach (JObject item in arr)
                    {
                        string supply_id = (string)item["supply_id"];
                        if (DBContext.Supplies.Find(supply_id) == null)
                            return Json(new { success = false, message = "Mã vật tư không tồn tại" });
                        Supply_Documentary_Camera temp = DBContext.Supply_Documentary_Camera
                            .Where(a => a.documentary_id == documentary_id && a.room_id.Equals(room_id) && a.supply_id == supply_id).FirstOrDefault();

                        if (temp == null)
                        {
                            temp = new Supply_Documentary_Camera
                            {
                                documentary_id = documentary_id,
                                room_id = room_id,
                                quantity_in = (int)item["quantity_in"],
                                quantity_out = (int)item["quantity_out"],
                                quantity_plan = (int)item["quantity_plan"],
                                quantity_used = (int)item["quantity_used"],
                                supplyStatus = (string)item["supplyStatus"],
                                supply_id = (string)item["supply_id"]
                            };
                            DBContext.Supply_Documentary_Camera.Add(temp);
                        }
                        else
                        {
                            temp.quantity_in = (int)item["quantity_in"];
                            temp.quantity_out = item["quantity_out"] == null ? 0 : (int)item["quantity_out"];
                            temp.quantity_used = item["quantity_used"] == null ? 0 : (int)item["quantity_used"];
                            temp.supplyStatus = (string)item["supplyStatus"];
                        }
                        DBContext.SaveChanges();
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Cập nhật thành công" });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                }
            }
        }

        public class Supply_Documentary_CameraDB : Supply_Documentary_Camera
        {
            public string supply_name { get; set; }
        }
    }
}