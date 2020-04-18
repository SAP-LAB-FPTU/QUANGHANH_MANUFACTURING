
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace QUANGHANHCORE.Controllers.CDVT.Nghiemthu
{
    public class nghiemthuController : Controller
    {
        QUANGHANHABCEntities db = new QUANGHANHABCEntities();

        [Auther(RightID = "25")]
        [Route("phong-cdvt/nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Nghiemthu/Nghiemthu.cshtml");
        }

        [Route("phong-cdvt/nghiem-thu/search")]
        [HttpPost]
        public ActionResult Search(string document_code, string equiment_id, string equiment_name)
        {
            //Server Side Parameter
            //string requestID = Request["sessionId"];
            string departID = Session["departID"].ToString();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Documentary_Extend> docList = new List<Documentary_Extend>();
            int totalrows = 0;

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                if (Session["departName"].ToString().Contains("Phân xưởng"))
                {
                    docList = (from a in db.Acceptances
                               join b in db.Equipments.Where(x => x.department_id.Equals(departID)) on a.equipmentId equals b.equipmentId
                               join c in db.Documentaries on a.documentary_id equals c.documentary_id
                               where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                               join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                               select new Documentary_Extend
                               {
                                   documentary_id = a.documentary_id,
                                   equipmentId = b.equipmentId,
                                   equipment_name = b.equipment_name,
                                   documentary_code = c.documentary_code,
                                   documentary_type = c.documentary_type,
                                   documentary_name = d.documentary_name,
                                   du_phong = d.du_phong,
                                   di_kem = d.di_kem

                               }).ToList().OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
                    totalrows = (from a in db.Acceptances
                                 join b in db.Equipments.Where(x => x.department_id.Equals(departID)) on a.equipmentId equals b.equipmentId
                                 join c in db.Documentaries on a.documentary_id equals c.documentary_id
                                 where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                                 join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                                 select new Documentary_Extend
                                 {
                                     documentary_id = a.documentary_id,
                                     equipmentId = b.equipmentId,
                                     equipment_name = b.equipment_name,
                                     documentary_code = c.documentary_code,
                                     documentary_type = c.documentary_type,
                                     documentary_name = d.documentary_name,
                                     du_phong = d.du_phong,
                                     di_kem = d.di_kem
                                 }).Count();
                }
                else
                {
                    docList = (from a in db.Acceptances
                               join b in db.Equipments on a.equipmentId equals b.equipmentId
                               join c in db.Documentaries on a.documentary_id equals c.documentary_id
                               where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                               join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                               select new Documentary_Extend
                               {
                                   documentary_id = a.documentary_id,
                                   equipmentId = b.equipmentId,
                                   equipment_name = b.equipment_name,
                                   documentary_code = c.documentary_code,
                                   documentary_type = c.documentary_type,
                                   documentary_name = d.documentary_name,
                                   du_phong = d.du_phong,
                                   di_kem = d.di_kem,
                                   can = d.can
                               }).ToList().OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
                    totalrows = (from a in db.Acceptances
                                 join b in db.Equipments on a.equipmentId equals b.equipmentId
                                 join c in db.Documentaries on a.documentary_id equals c.documentary_id
                                 where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                                 join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                                 select new Documentary_Extend
                                 {
                                     documentary_id = a.documentary_id,
                                     equipmentId = b.equipmentId,
                                     equipment_name = b.equipment_name,
                                     documentary_code = c.documentary_code,
                                     documentary_type = c.documentary_type,
                                     documentary_name = d.documentary_name,
                                     du_phong = d.du_phong,
                                     di_kem = d.di_kem,
                                     can = d.can
                                 }).Count();
                }

                foreach (Documentary_Extend items in docList)
                {
                    items.linkIdCode = new LinkIdCode2();
                    switch (items.documentary_type)
                    {
                        case 1:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 2:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 3:
                            items.linkIdCode.link = "vat-tu-kem-theo";
                            break;
                        case 4:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 5:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 6:
                            items.linkIdCode.link = "vat-tu";
                            break;
                    }
                    items.linkIdCode.code = items.equipmentId;
                    items.linkIdCode.id = items.equipmentId;
                    items.linkIdCode.doc = items.documentary_id;
                }
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
        }

        [Auther(RightID = "82")]
        [Route("phong-cdvt/nghiem-thu/detail")]
        [HttpPost]
        public ActionResult Detail(int documentary_id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var doc = (from a in db.Documentaries
                       join b in db.Departments on a.department_id_to equals b.department_id
                       where a.documentary_id == documentary_id
                       select new
                       {
                           b.department_name,
                           a.date_created,
                           a.person_created,
                           a.reason,
                           a.out_in_come
                       }).FirstOrDefault();
            return Json(doc);
        }

        [Auther(RightID = "82")]
        [HttpPost]
        [Route("phong-cdvt/nghiem-thu/Edit")]
        public ActionResult Edit(string id, string documentary_code, string documentary_id)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Acceptance acceptance = db.Acceptances.Find(int.Parse(documentary_id), id);
                    acceptance.equipmentStatus = 3;
                    db.SaveChanges();

                    int acceptanced = db.Database.SqlQuery<Acceptance>("SELECT * FROM Acceptance WHERE documentary_id = @documentary_id AND equipmentStatus = 3",
                        new SqlParameter("documentary_id", int.Parse(documentary_id))).ToList().Count;

                    int total = db.Database.SqlQuery<Acceptance>("SELECT * FROM Acceptance WHERE documentary_id = @documentary_id",
                        new SqlParameter("documentary_id", int.Parse(documentary_id))).ToList().Count;
                    Documentary documentary = db.Documentaries.Find(int.Parse(documentary_id));
                    if (total == acceptanced)
                    {
                        documentary.documentary_status = 3;
                    }
                    Equipment equipment = db.Equipments.Find(id);
                    equipment.department_id = documentary.department_id_to;

                    switch (documentary.documentary_type)
                    {
                        case 1:
                            Documentary_repair_details documentary_Repair_Details = db.Database.SqlQuery<Documentary_repair_details>("SELECT * FROM Documentary_repair_details WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id),
                                new SqlParameter("documentary_id", documentary.documentary_id)).First();
                            equipment.current_Status = 1;
                            break;
                        case 2:
                            Documentary_maintain_details Documentary_maintain_details = db.Database.SqlQuery<Documentary_maintain_details>("SELECT * FROM Documentary_maintain_details WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id),
                                new SqlParameter("documentary_id", documentary.documentary_id)).First();
                            equipment.current_Status = 1;
                            break;
                        case 3:
                            Documentary_moveline_details documentary_Moveline_Details = db.Database.SqlQuery<Documentary_moveline_details>("SELECT * FROM Documentary_moveline_details WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id),
                                new SqlParameter("documentary_id", documentary.documentary_id)).First();
                            db.Database.ExecuteSqlCommand("DELETE FROM Supply_SCTX WHERE equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id));
                            db.Database.ExecuteSqlCommand("update Supply_DiKem set quantity = 0 where equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id));
                            List<Supply_Documentary_Equipment> supplies_Moveline = db.Supply_Documentary_Equipment.Where(x => x.documentary_id == documentary.documentary_id && x.equipmentId == id).ToList();
                            foreach (Supply_Documentary_Equipment item in supplies_Moveline)
                            {
                                if (item.equipmentId_dikem != null)
                                {
                                    Supply_DiKem s = db.Supply_DiKem.Where(x => x.equipmentId == id && x.equipmentId_dikem == item.equipmentId_dikem).FirstOrDefault();
                                    if (s == null)
                                    {
                                        s = new Supply_DiKem
                                        {
                                            equipmentId = id,
                                            note = item.supplyStatus,
                                            quantity = item.quantity_in,
                                            equipmentId_dikem = item.equipmentId_dikem
                                        };
                                        db.Supply_DiKem.Add(s);
                                    }
                                    else
                                    {
                                        s.quantity = item.quantity_in;
                                        s.note = item.supplyStatus;
                                    }
                                }
                                else
                                {
                                    Supply_SCTX s = db.Supply_SCTX.Where(x => x.equipmentId == id && x.supply_id == item.supply_id).FirstOrDefault();
                                    if (s == null)
                                    {
                                        s = new Supply_SCTX
                                        {
                                            equipmentId = id,
                                            quantity = item.quantity_in,
                                            supply_id = item.supply_id
                                        };
                                        db.Supply_SCTX.Add(s);
                                    }
                                    else
                                    {
                                        s.quantity = item.quantity_in;
                                    }
                                }
                                db.SaveChanges();
                            }
                            equipment.current_Status = 2;
                            break;
                        case 4:
                            equipment.current_Status = 1;
                            break;
                        case 5:
                            equipment.current_Status = 15;
                            db.Database.ExecuteSqlCommand("DELETE FROM Supply_SCTX WHERE equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id));
                            db.Database.ExecuteSqlCommand("DELETE FROM Supply_DiKem WHERE equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id));
                            break;
                        case 6:
                            Documentary_big_maintain_details documentary_Big_Maintain_Details = db.Database.SqlQuery<Documentary_big_maintain_details>("SELECT * FROM Documentary_big_maintain_details WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id),
                                new SqlParameter("documentary_id", documentary.documentary_id)).First();
                            equipment.current_Status = 1;
                            break;
                        case 7:
                            Documentary_Improve_Detail documentary_Improve_Details = db.Database.SqlQuery<Documentary_Improve_Detail>("SELECT * FROM Documentary_Improve_Detail WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id),
                                new SqlParameter("documentary_id", documentary.documentary_id)).First();
                            List<Supply_Documentary_Equipment> supplies = db.Supply_Documentary_Equipment.Where(x => x.documentary_id == documentary.documentary_id && x.equipmentId == id).ToList();
                            foreach (Supply_Documentary_Equipment item in supplies)
                            {
                                Supply_DiKem s = db.Supply_DiKem.Where(x => x.equipmentId == id && x.equipmentId_dikem == item.equipmentId_dikem).FirstOrDefault();
                                if (s == null)
                                {
                                    s = new Supply_DiKem
                                    {
                                        equipmentId = id,
                                        note = item.supplyStatus,
                                        quantity = item.quantity_used,
                                        equipmentId_dikem = item.equipmentId_dikem
                                    };
                                    db.Supply_DiKem.Add(s);
                                }
                                else
                                {
                                    s.quantity += item.quantity_used;
                                    s.note = item.supplyStatus;
                                }
                                db.SaveChanges();
                            }
                            equipment.current_Status = 1;
                            break;
                        default:
                            break;
                    }
                    if (documentary.documentary_type == 1 || documentary.documentary_type == 2 || documentary.documentary_type == 6)
                    {
                        List<Supply_Documentary_Equipment> list = db.Supply_Documentary_Equipment.Where(x => x.documentary_id == documentary.documentary_id && x.equipmentId == id).ToList();
                        List<string> supplies_id = list.Select(x => x.supply_id).ToList();
                        List<Supply_SCTX> s = db.Supply_SCTX.Where(x => x.equipmentId == id && supplies_id.Contains(x.supply_id)).ToList();
                        foreach (Supply_SCTX item in s)
                        {
                            Supply_Documentary_Equipment temp = list.Where(x => x.supply_id.Equals(item.supply_id)).FirstOrDefault();
                            item.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                            supplies_id.Remove(item.supply_id);
                        }
                        foreach (string item in supplies_id)
                        {
                            Supply_Documentary_Equipment temp = list.Where(x => x.supply_id.Equals(item)).FirstOrDefault();
                            Supply_SCTX supply = new Supply_SCTX
                            {
                                equipmentId = id,
                                supply_id = item
                            };
                            supply.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                            db.Supply_SCTX.Add(supply);
                        }
                    }
                    db.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Nghiệm thu thành công" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Nghiệm thu thất bại" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [Auther(RightID = "82")]
        [HttpPost]
        [Route("phong-cdvt/nghiem-thu/cap-nhat-so-luong")]
        public ActionResult Update(int documentary_id, string equipmentId, bool isSupply)
        {
            db.Configuration.LazyLoadingEnabled = false;
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var temp = JArray.Parse(Request["list"]);
                    List<Supply_Documentary_Equipment> list = db.Supply_Documentary_Equipment.Where(x => x.documentary_id.Equals(documentary_id) && x.equipmentId.Equals(equipmentId)).ToList();
                    foreach (JObject item in temp)
                    {
                        if (isSupply)
                        {
                            Supply_Documentary_Equipment s = list.Where(x => x.supply_id.Equals((string)item["supply_id"])).FirstOrDefault();
                            s.quantity_in = (int)item["quantity_in"];
                            s.quantity_out = (int)item["quantity_out"];
                            s.quantity_plan = (int)item["quantity_plan"];
                            s.quantity_used = (int)item["quantity_used"];
                        }
                        else
                        {
                            Supply_Documentary_Equipment s = list.Where(x => x.equipmentId_dikem.Equals((string)item["equipmentId_dikem"])).FirstOrDefault();
                            s.quantity_in = (int)item["quantity_in"];
                            s.quantity_plan = (int)item["quantity_plan"];
                        }
                    }
                    db.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Cập nhật thành công" });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Cập nhật thất bại" });
                }
            }
        }

        [Auther(RightID = "82")]
        [Route("phong-cdvt/nghiem-thu/cap-nhat-so-luong-dieu-dong")]
        [HttpPost]
        public ActionResult UpdateQuantity(string list, int documentary_id, string equipmentId, bool type)
        {
            db.Configuration.LazyLoadingEnabled = false;
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
                            listTemp.First().quantity_in = (int)item["quantity_dikem"];
                            if (listTemp.Count == 2)
                            {
                                listTemp.Last().quantity_in = (int)item["quantity_duphong"];
                            }
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

        private class Document
        {
            public string documentary_type { get; set; }
            public int documentary_id { get; set; }

            public string equipmentId { get; set; }
            public int countID { get; set; }
        }
    }
}