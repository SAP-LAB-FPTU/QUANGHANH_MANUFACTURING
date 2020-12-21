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
        private QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/xu-ly/sua-chua")]
        [HttpGet]
        public ActionResult Index(int id)
        {
            try
            {
                db.Configuration.LazyLoadingEnabled = false;
                Documentary documentary = db.Documentaries.Find(id);

                if (documentary == null || String.IsNullOrEmpty(documentary.documentary_code))
                    return Redirect("/phong-cdvt/camera/xu-ly");

                List<Supply> supplies = db.Supplies.Select(x => new
                {
                    x.supply_id,
                    x.supply_name
                }).ToList().Select(x => new Supply
                {
                    supply_id = x.supply_id,
                    supply_name = x.supply_name
                }).ToList();
                ViewBag.Supplies = supplies;

                if (documentary.documentary_status == 1) ViewBag.AddAble = true;
                else ViewBag.AddAble = false;
                ViewBag.id = documentary.documentary_id;
                ViewBag.code = documentary.documentary_code as string;
                return View("/Views/Camera/Quyetdinh/SuaChua/XuLy.cshtml");
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
        public ActionResult GetData(int id)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            var equips = (from docu in db.Documentaries
                          join details in db.CameraRepairDetails on docu.documentary_id equals details.documentary_id
                          join depa in db.Departments on details.department_id equals depa.department_id
                          join r in db.Rooms on details.room_id equals r.room_id
                          where docu.documentary_type == 8 && details.documentary_id == id
                          select new
                          {
                              r.room_id,
                              r.room_name,
                              depa.department_name,
                              details.broken_camera_quantity,
                              docu.documentary_id,
                              details.documentary_camera_repair_status
                          }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();

            int totalrows = (from docu in db.Documentaries
                             join details in db.CameraRepairDetails on docu.documentary_id equals details.documentary_id
                             join depa in db.Departments on details.department_id equals depa.department_id
                             join r in db.Rooms on details.room_id equals r.room_id
                             where docu.documentary_type == 8 && details.documentary_id == id
                             select details).Count();

            return Json(new { success = true, data = equips, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows });
        }

        [Auther(RightID = "193")]
        [Route("cap-nhat/camera/quyet-dinh/sua-chua/edit")]
        [HttpPost]
        public ActionResult Update(string edit, int id)
        {
            if (edit != "")
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        JArray list = JArray.Parse(edit);
                        foreach (JValue item in list)
                        {
                            if (item.Value.ToString() == "")
                                continue;

                            CameraRepairDetail temp = db.CameraRepairDetails.Where(x => x.documentary_id == id && x.room_id == item.Value.ToString()).FirstOrDefault();
                            if (temp.documentary_camera_repair_status == 0)
                            {
                                temp.documentary_camera_repair_status = 1;
                                Acceptance a = new Acceptance
                                {
                                    acceptance_date = DateTime.Now,
                                    documentary_id = id,
                                    room_id = item.Value.ToString(),
                                    is_acceptance = false
                                };
                                db.Acceptances.Add(a);
                            }
                        }
                        if ((from docu in db.Documentaries
                             join details in db.CameraRepairDetails on docu.documentary_id equals details.documentary_id
                             where docu.documentary_type == 8 && details.documentary_id == id && details.documentary_camera_repair_status == 0
                             select details).Count() == 0)
                        {
                            Documentary docu = db.Documentaries.Find(id);
                            docu.documentary_status = 2;
                        }

                        db.SaveChanges();
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
        public ActionResult GetSupply(int documentary_id, string room_id)
        {
            //var supplies = db.Database.SqlQuery<Supply_Documentary_CameraDB>("SELECT s1.*, s2.supply_name FROM Supply_Documentary_Camera s1 inner join Supply s2 on s1.supply_id = s2.supply_id WHERE room_id = @room_id AND documentary_id = @documentary_id",
            //    new SqlParameter("room_id", room_id),
            //    new SqlParameter("documentary_id", documentary_id)).ToList();
            var supplies = (from s1 in db.RepairCameras
                            join s2 in db.Supplies on s1.supply_id equals s2.supply_id
                            where s1.room_id == room_id && s1.documentary_id == documentary_id
                            select new
                            {
                                s1.supply_status,
                                s1.supply_id,
                                s2.supply_name,
                                s1.quantity_plan,
                                s1.quantity_in,
                                s1.quantity_used,
                                s1.quantity_out
                            }).ToList();
            return Json(supplies);
        }
        [Auther(RightID = "193")]
        [Route("cap-nhat/camera/quyet-dinh/AddSupply")]
        [HttpPost]
        public ActionResult AddSupply(string list, int documentary_id, string room_id)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    CameraRepairDetail detail = db.CameraRepairDetails
                        .Where(x => x.room_id == room_id && x.documentary_id == documentary_id && x.documentary_camera_repair_status == 0).FirstOrDefault();
                    if (detail == null)
                        return Json(new { success = false, message = "Không thể chỉnh sửa quyết định đã xử lý" });

                    JObject json = JObject.Parse(list);
                    JArray arr = (JArray)json.SelectToken("list");

                    List<string> supply_ids = arr.Select(x => x["supply_id"].ToString()).ToList();
                    if (db.Supplies.Where(x => supply_ids.Contains(x.supply_id)).Count() != supply_ids.Count)
                        return Json(new { success = false, message = "Mã vật tư không tồn tại" });

                    foreach (JObject item in arr)
                    {
                        string supply_id = (string)item["supply_id"];
                        RepairCamera temp = db.RepairCameras
                            .Where(a => a.documentary_id == documentary_id && a.room_id.Equals(room_id) && a.supply_id == supply_id).FirstOrDefault();

                        if (temp == null)
                        {
                            temp = new RepairCamera
                            {
                                documentary_id = documentary_id,
                                room_id = room_id,
                                quantity_in = (int)item["quantity_in"],
                                quantity_out = (int)item["quantity_out"],
                                quantity_plan = (int)item["quantity_plan"],
                                quantity_used = (int)item["quantity_used"],
                                supply_status = (string)item["supplyStatus"],
                                supply_id = (string)item["supply_id"]
                            };
                            db.RepairCameras.Add(temp);
                        }
                        else
                        {
                            temp.quantity_in = (int)item["quantity_in"];
                            temp.quantity_out = item["quantity_out"] == null ? 0 : (int)item["quantity_out"];
                            temp.quantity_used = item["quantity_used"] == null ? 0 : (int)item["quantity_used"];
                            temp.supply_status = (string)item["supplyStatus"];
                        }
                        db.SaveChanges();
                    }
                    db.SaveChanges();
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

        public class Supply_Documentary_CameraDB : RepairCamera
        {
            public string supply_name { get; set; }
        }
    }
}