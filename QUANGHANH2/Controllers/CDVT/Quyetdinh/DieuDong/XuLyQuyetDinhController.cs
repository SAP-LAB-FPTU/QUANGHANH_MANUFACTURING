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

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.DieuDong
{
    public class XuLyController : Controller
    {
        QUANGHANHABCEntities db = new QUANGHANHABCEntities();

        [Auther(RightID = "88,179,180,181,183,184,185,186,187,189,195")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/dieu-dong")]
        [HttpGet]
        public ActionResult Index(string id)
        {
            try
            {
                string departid = Session["departID"].ToString();
                Documentary documentary = db.Database.SqlQuery<Documentary>("SELECT docu.*, docu.[out/in_come] as out_in_come FROM Documentary_moveline_details as detail inner join Documentary as docu on detail.documentary_id = docu.documentary_id WHERE docu.documentary_code IS NOT NULL AND detail.documentary_id = @documentary_id and docu.department_id_to = @departid ",
                    new SqlParameter("documentary_id", id), new SqlParameter("departid", departid)).First();
                if (documentary.documentary_status == 1) ViewBag.AddAble = true;
                else ViewBag.AddAble = false;
                ViewBag.id = documentary.documentary_id;
                ViewBag.code = documentary.documentary_code as string;
                return View("/Views/CDVT/Quyetdinh/DieuDong/XuLy.cshtml");
            }
            catch (Exception)
            {
                Response.Write("Số quyết định không tồn tại hoặc chưa được cấp");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/dieu-dong/GetData")]
        [HttpPost]
        public ActionResult GetData(string id)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string departid = Session["departID"].ToString();
            List<Documentary_moveline_detailsDB> equips = db.Database.SqlQuery<Documentary_moveline_detailsDB>("select e.equipmentId, e.equipment_name, depa.department_name, details.date_to, details.department_detail, details.equipment_moveline_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id_to inner join Documentary_moveline_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 3 and details.documentary_id = @documentary_id and docu.department_id_to = @departid",
                new SqlParameter("documentary_id", id), new SqlParameter("departid", departid)).ToList();
            foreach (Documentary_moveline_detailsDB item in equips)
            {
                item.stringDate = item.date_to.ToString("dd/MM/yyyy");
            }
            int totalrows = equips.Count;
            int totalrowsafterfiltering = equips.Count;
            ViewBag.List = equips.Count;
            //sorting
            equips = equips.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_moveline_detailsDB>();
            //paging
            equips = equips.Skip(start).Take(length).ToList<Documentary_moveline_detailsDB>();
            return Json(new { success = true, data = equips, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "88,179,180,181,183,184,185,186,187,189,195")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/dieu-dong/edit")]
        [HttpPost]
        public ActionResult editpost(string edit, int documentary_id)
        {
            if (edit != "")
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        edit = edit.Substring(0, edit.Length - 1);
                        char[] spearator = { '^' };
                        String[] list = edit.Split(spearator,
                           StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in list)
                        {
                            Documentary_moveline_details temp = db.Documentary_moveline_details.Where(x => x.equipmentId == item && x.documentary_id == documentary_id).FirstOrDefault();
                            temp.equipment_moveline_status = 1;
                            Acceptance a = new Acceptance
                            {
                                acceptance_date = DateTime.Now,
                                documentary_id = documentary_id,
                                equipmentId = item,
                                equipmentStatus = 2
                            };
                            db.Acceptances.Add(a);
                            db.SaveChanges();
                        }
                        //kiểm tra xem còn thiết bị nào chưa xử lý xong không
                        if (db.Database.SqlQuery<Documentary_moveline_detailsDB>("select details.equipment_moveline_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id_to inner join Documentary_moveline_details details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 3 and details.documentary_id = @documentary_id and equipment_moveline_status = '0'", new SqlParameter("documentary_id", documentary_id)).Count() == 0)
                        {
                            Documentary docu = db.Documentaries.Find(documentary_id);
                            docu.documentary_status = 2;

                            Notification noti = new Notification
                            {
                                date = DateTime.Now.Date,
                                department_id = docu.department_id_to,
                                description = "dieu dong 2",
                                id_problem = docu.documentary_id,
                                isread = false
                            };
                            db.Notifications.Add(noti);
                            db.SaveChanges();

                        }

                        db.SaveChanges();
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

        [Auther(RightID = "88,179,180,181,183,184,185,186,187,189,195")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/dieu-dong/so-luong")]
        public ActionResult GetQuantity(int documentary_id, string equipmentId)
        {
            List<SupplyEquip> supplyEquip = db.Database.SqlQuery<SupplyEquip>(@"select a.equipmentId, a.equipmentId_dikem,
                c.equipment_name, a.supply_id, b.supply_name, a.quantity_plan, a.quantity_in, a.supplyStatus 
                from Supply_Documentary_Equipment a 
                left join Supply b on a.supply_id = b.supply_id
                left join Equipment c on a.equipmentId_dikem = c.equipmentId
                where a.documentary_id = @documentary_id and a.equipmentId = @equipmentId
                order by a.supplyDocumentaryEquipmentId asc",
                new SqlParameter("documentary_id", documentary_id),
                new SqlParameter("equipmentId", equipmentId)).ToList();
            return Json(supplyEquip, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "88,179,180,181,183,184,185,186,187,189,195")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/dieu-dong/so-luong")]
        [HttpPost]
        public ActionResult UpdateQuantity(string list, int documentary_id, string equipmentId, bool type)
        {
            db.Configuration.LazyLoadingEnabled = false;
            if (db.Documentary_moveline_details
                .Where(x => x.documentary_id == documentary_id && x.equipmentId == equipmentId && x.equipment_moveline_status == 1).Any())
                return Json(new { success = false, message = "Thiết bị đã được xử lý" });
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    JObject json = JObject.Parse(list);
                    JArray arr = (JArray)json.SelectToken("list");  //list của thiết bị con đi kèm, dự phòng và vật tư sctx
                    foreach (JObject item in arr)
                    {
                        if (!type)
                        {
                            string equipmentId_dikem = (string)item["equipmentId_dikem"];
                            List<Supply_Documentary_Equipment> listTemp = db.Supply_Documentary_Equipment
                                .Where(a => a.documentary_id == documentary_id && a.equipmentId == equipmentId && a.equipmentId_dikem == equipmentId_dikem)
                                .OrderBy(a => a.supplyDocumentaryEquipmentId).ToList();
                            Supply_Documentary_Equipment dikem = listTemp.Where(x => x.supplyStatus == "dikem").FirstOrDefault();
                            if (dikem != null)
                                dikem.quantity_in = (int)item["quantity_dikem"];
                            Supply_Documentary_Equipment duphong = listTemp.Where(x => x.supplyStatus == "duphong").FirstOrDefault();
                            if (duphong != null)
                                duphong.quantity_in = (int)item["quantity_duphong"];
                        }
                        else
                        {
                            string supply_id = (string)item["supply_id"];
                            Supply_Documentary_Equipment temp = db.Supply_Documentary_Equipment.Where(a => a.documentary_id == documentary_id && a.equipmentId == equipmentId && a.supply_id == supply_id).FirstOrDefault();
                            temp.quantity_in = (int)item["quantity_in"] < temp.quantity_in ? temp.quantity_in : (int)item["quantity_in"];
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

        public class SupplyEquip
        {
            public string equipmentId { get; set; }
            public string equipmentId_dikem { get; set; }
            public string equipment_name { get; set; }
            public string supply_id { get; set; }
            public string supply_name { get; set; }
            public int quantity_plan { get; set; }
            public int quantity_in { get; set; }
            public string supplyStatus { get; set; }
        }
    }
}