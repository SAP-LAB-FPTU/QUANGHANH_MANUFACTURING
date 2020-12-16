using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh
{
    public class MethodChungController : Controller
    {
        [HttpPost]
        public ActionResult GetSmallEquip(string equipment_id)
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var data = (from a in db.Equipments
                                join b in db.AccompaniedEquipments on a.equipment_id equals b.accompanied_equipment_id
                                where a.is_attach == true && b.equipment_id.Equals(equipment_id) && b.quantity > 0
                                select new
                                {
                                    a.equipment_id,
                                    a.equipment_name,
                                    b.quantity,
                                }).ToList();
                    return Json(new { success = true, data });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult GetAccompaniedSupplies(string equipment_id)
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var data = (from a in db.Supplies
                                join b in db.AccompaniedSupplies on a.supply_id equals b.supply_id
                                where b.equipment_id.Equals(equipment_id)
                                select new
                                {
                                    a.supply_id,
                                    a.supply_name,
                                    b.quantity,
                                }).ToList();
                    return Json(new { success = true, data });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult GetSupplyWithID(string supply_id)
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var supply = db.Supplies
                        .Where(x => x.supply_id.Contains(supply_id))
                        .Take(10)
                        .Select(x => new
                        {
                            x.supply_id,
                            x.supply_name
                        })
                        .ToList();
                    return Json(new { success = true, supply });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult GetSupplyWithName(string supply_name)
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var supply = db.Supplies
                        .Where(x => x.supply_name.Contains(supply_name))
                        .Take(10)
                        .Select(x => new
                        {
                            x.supply_id,
                            x.supply_name
                        })
                        .ToList();
                    return Json(new { success = true, supply });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [Route("phong-cdvt/quyet-dinh/update")]
        [HttpPost]
        public ActionResult Update()
        {
            int documentary_id = int.Parse(Request["documentary_id"]);
            string documentary_code = Request["documentary_code"];
            string reason = Request["reason"];
            string out_in_come = Request["out_in_come"];
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {

                        if (db.Documentaries.Where(x => x.documentary_code == documentary_code).FirstOrDefault() != null)
                            return Json(new { success = false, message = "Số quyết định đã tồn tại" });
                        Documentary doc = db.Documentaries.Find(documentary_id);
                        if (doc == null)
                            return Json(new { success = false, message = "Quyết định không tồn tại" });
                        doc.documentary_code = documentary_code == "" ? null : documentary_code;
                        doc.reason = reason;
                        doc.out_income = out_in_come;

                        if (doc.documentary_code != null)
                        {
                            Notification noti = new Notification
                            {
                                description = ""
                            };
                            switch (doc.documentary_type)
                            {
                                case 1:
                                    (from a in db.Equipments
                                     join b in db.RepairDetails on a.equipment_id equals b.equipment_id
                                     where b.documentary_id == documentary_id
                                     select a).ToList().ForEach(x => x.current_status = 3);

                                    noti.description = "sua chua";
                                    break;
                                case 2:
                                    (from a in db.Equipments
                                     join b in db.MaintainDetails on a.equipment_id equals b.equipment_id
                                     where b.documentary_id == documentary_id
                                     select a).ToList().ForEach(x => x.current_status = 5);

                                    noti.description = "bao duong";
                                    break;
                                case 3:
                                    (from a in db.Equipments
                                     join b in db.MovelineDetails on a.equipment_id equals b.equipment_id
                                     where b.documentary_id == documentary_id
                                     select a).ToList().ForEach(x => x.current_status = 6);

                                    noti.description = "dieu dong";
                                    break;
                                case 4:
                                    (from a in db.Equipments
                                     join b in db.RevokeDetails on a.equipment_id equals b.equipment_id
                                     where b.documentary_id == documentary_id
                                     select a).ToList().ForEach(x => x.current_status = 7);

                                    noti.description = "thu hoi";
                                    break;
                                case 5:
                                    (from a in db.Equipments
                                     join b in db.LiquidationDetails on a.equipment_id equals b.equipment_id
                                     where b.documentary_id == documentary_id
                                     select a).ToList().ForEach(x => x.current_status = 8);

                                    noti.description = "thanh ly";
                                    break;
                                case 6:
                                    (from a in db.Equipments
                                     join b in db.BigMaintainDetails on a.equipment_id equals b.equipment_id
                                     where b.documentary_id == documentary_id
                                     select a).ToList().ForEach(x => x.current_status = 9);

                                    noti.description = "trung dai tu";
                                    break;
                                case 7:
                                    (from a in db.Equipments
                                     join b in db.ImproveDetails on a.equipment_id equals b.equipment_id
                                     where b.documentary_id == documentary_id
                                     select a).ToList().ForEach(x => x.current_status = 16);

                                    noti.description = "cai tien";
                                    break;
                                case 8:
                                    break;
                                default:
                                    return Json(new { success = false, message = "Loại quyết định không tồn tại" });
                            }
                            if (!noti.description.Equals(""))
                            {
                                noti.date = DateTime.Now.Date;
                                noti.department_id = doc.department_id_to;
                                noti.id_problem = doc.documentary_id;
                                noti.isread = false;
                                db.Notifications.Add(noti);
                                db.SaveChanges();
                            }
                        }

                        db.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" });
                    }
                }
            }
            return Json(new { success = true, message = "Cập nhật thành công" });
        }

        [Route("phong-cdvt/quyet-dinh/delete")]
        [HttpPost]
        public ActionResult Delete()
        {
            try
            {
                int documentary_id = int.Parse(Request["documentary_id"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    Documentary doc = db.Documentaries.Find(documentary_id);
                    if (doc == null)
                        return Json(new { success = false, message = "Mã quyết định không tồn tại" });

                    if (doc.documentary_code != null)
                        return Json(new { success = false, message = "Bạn không được xóa quyết định này" });

                    db.Documentaries.Remove(doc);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Xóa thành công" });
                }

            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }
    }
}