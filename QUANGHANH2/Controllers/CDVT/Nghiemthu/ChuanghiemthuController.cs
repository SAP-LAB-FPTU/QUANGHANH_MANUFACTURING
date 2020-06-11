
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
            List<MyDoc> docList = new List<MyDoc>();
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
                               select new MyDoc
                               {
                                   documentary_id = a.documentary_id,
                                   equipmentId = b.equipmentId,
                                   equipment_name = b.equipment_name,
                                   attach_to = a.attach_to,
                                   documentary_code = c.documentary_code,
                                   documentary_type = c.documentary_type,
                                   documentary_name = d.documentary_name,
                                   du_phong = d.du_phong,
                                   di_kem = d.di_kem,
                                   can = d.can,
                                   acceptance_id = a.acceptance_id
                               }).ToList().OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
                    totalrows = (from a in db.Acceptances
                                 join b in db.Equipments.Where(x => x.department_id.Equals(departID)) on a.equipmentId equals b.equipmentId
                                 join c in db.Documentaries on a.documentary_id equals c.documentary_id
                                 where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                                 join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                                 select new MyDoc
                                 {
                                     documentary_id = a.documentary_id,
                                     equipmentId = b.equipmentId,
                                     equipment_name = b.equipment_name,
                                     attach_to = a.attach_to,
                                     documentary_code = c.documentary_code,
                                     documentary_type = c.documentary_type,
                                     documentary_name = d.documentary_name,
                                     du_phong = d.du_phong,
                                     di_kem = d.di_kem,
                                     can = d.can,
                                     acceptance_id = a.acceptance_id
                                 }).Count();
                }
                else
                {
                    docList = (from a in db.Acceptances
                               join b in db.Equipments on a.equipmentId equals b.equipmentId
                               join c in db.Documentaries on a.documentary_id equals c.documentary_id
                               where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                               join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                               select new MyDoc
                               {
                                   documentary_id = a.documentary_id,
                                   equipmentId = b.equipmentId,
                                   equipment_name = b.equipment_name,
                                   attach_to = a.attach_to,
                                   documentary_code = c.documentary_code,
                                   documentary_type = c.documentary_type,
                                   documentary_name = d.documentary_name,
                                   du_phong = d.du_phong,
                                   di_kem = d.di_kem,
                                   can = d.can,
                                   acceptance_id = a.acceptance_id
                               }).ToList().OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
                    totalrows = (from a in db.Acceptances
                                 join b in db.Equipments on a.equipmentId equals b.equipmentId
                                 join c in db.Documentaries on a.documentary_id equals c.documentary_id
                                 where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                                 join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                                 select new MyDoc
                                 {
                                     documentary_id = a.documentary_id,
                                     equipmentId = b.equipmentId,
                                     equipment_name = b.equipment_name,
                                     attach_to = a.attach_to,
                                     documentary_code = c.documentary_code,
                                     documentary_type = c.documentary_type,
                                     documentary_name = d.documentary_name,
                                     du_phong = d.du_phong,
                                     di_kem = d.di_kem,
                                     can = d.can,
                                     acceptance_id = a.acceptance_id
                                 }).Count();
                }

                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
        }

        public class MyDoc
        {
            public int documentary_id { get; set; }
            public string documentary_code { get; set; }
            public string documentary_name { get; set; }
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
            public string attach_to { get; set; }
            public int documentary_type { get; set; }
            public bool du_phong { get; set; }
            public bool di_kem { get; set; }
            public bool can { get; set; }
            public int acceptance_id { get; set; }
        }

        [Auther(RightID = "82")]
        [Route("phong-cdvt/nghiem-thu/detail")]
        [HttpPost]
        public ActionResult DetailDoc(int documentary_id)
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
        public ActionResult Edit(int acceptance_id)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Acceptance acceptance = db.Acceptances.Find(acceptance_id);
                    int documentary_id = acceptance.documentary_id;

                    acceptance.equipmentStatus = 3;
                    db.SaveChanges();

                    int acceptanced = db.Acceptances.Where(x => x.documentary_id == documentary_id && x.equipmentStatus == 3).Count();

                    int total = db.Acceptances.Where(x => x.documentary_id == documentary_id).Count();

                    Documentary documentary = db.Documentaries.Find(documentary_id);
                    if (total == acceptanced)
                    {
                        documentary.documentary_status = 3;
                    }

                    string equipmentId = acceptance.equipmentId;
                    Equipment equipment = db.Equipments.Find(equipmentId);
                    if (acceptance.attach_to == null)
                    {
                        equipment.department_id = documentary.department_id_to;
                    }

                    List<string> supplies_id = new List<string>();
                    List<Supply_SCTX> s = new List<Supply_SCTX>();

                    switch (documentary.documentary_type)
                    {
                        case 1:
                            if (acceptance.attach_to == null)
                            {
                                int documentary_repair_id = db.Documentary_repair_details.Where(x => x.equipmentId == acceptance.equipmentId && x.documentary_id == acceptance.documentary_id).First().documentary_repair_id;

                                List<Supply_Documentary_Repair_Equipment> list1 = db.Supply_Documentary_Repair_Equipment.Where(x => x.documentary_repair_id == documentary_repair_id).ToList();

                                supplies_id = list1.Where(x => x.supply_id != null).Select(x => x.supply_id).ToList();
                                s = db.Supply_SCTX.Where(x => x.equipmentId == equipmentId && supplies_id.Contains(x.supply_id)).ToList();

                                foreach (Supply_SCTX item in s)
                                {
                                    Supply_Documentary_Repair_Equipment temp = list1.Where(x => x.supply_id.Equals(item.supply_id)).FirstOrDefault();
                                    item.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                                    supplies_id.Remove(item.supply_id);
                                }
                                foreach (string item in supplies_id)
                                {
                                    Supply_Documentary_Repair_Equipment temp = list1.Where(x => x.supply_id.Equals(item)).FirstOrDefault();
                                    Supply_SCTX supply = new Supply_SCTX
                                    {
                                        equipmentId = equipmentId,
                                        supply_id = item
                                    };
                                    supply.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                                    db.Supply_SCTX.Add(supply);
                                }
                                equipment.current_Status = 1;
                            }
                            break;
                        case 2:
                            if (acceptance.attach_to == null)
                            {
                                int documentary_maintain_id = db.Documentary_maintain_details.Where(x => x.equipmentId == acceptance.equipmentId && x.documentary_id == acceptance.documentary_id).First().documentary_maintain_id;

                                List<Supply_Documentary_Maintain_Equipment> list2 = db.Supply_Documentary_Maintain_Equipment.Where(x => x.documentary_maintain_id == documentary_maintain_id).ToList();

                                supplies_id = list2.Where(x => x.supply_id != null).Select(x => x.supply_id).ToList();
                                s = db.Supply_SCTX.Where(x => x.equipmentId == equipmentId && supplies_id.Contains(x.supply_id)).ToList();

                                foreach (Supply_SCTX item in s)
                                {
                                    Supply_Documentary_Maintain_Equipment temp = list2.Where(x => x.supply_id.Equals(item.supply_id)).FirstOrDefault();
                                    item.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                                    supplies_id.Remove(item.supply_id);
                                }
                                foreach (string item in supplies_id)
                                {
                                    Supply_Documentary_Maintain_Equipment temp = list2.Where(x => x.supply_id.Equals(item)).FirstOrDefault();
                                    Supply_SCTX supply = new Supply_SCTX
                                    {
                                        equipmentId = equipmentId,
                                        supply_id = item
                                    };
                                    supply.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                                    db.Supply_SCTX.Add(supply);
                                }
                                equipment.current_Status = 1;
                            }
                            break;
                        case 3:
                            db.Database.ExecuteSqlCommand("DELETE FROM Supply_SCTX WHERE equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", equipmentId));
                            db.Database.ExecuteSqlCommand("update Supply_DiKem set quantity = 0 where equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", equipmentId));
                            List<Supply_Documentary_Equipment> supplies_Moveline = db.Supply_Documentary_Equipment.Where(x => x.documentary_id == documentary.documentary_id && x.equipmentId == equipmentId).ToList();
                            foreach (Supply_Documentary_Equipment item in supplies_Moveline)
                            {
                                if (item.equipmentId_dikem != null)
                                {
                                    Supply_DiKem thietbi = db.Supply_DiKem.Where(x => x.equipmentId == equipmentId && x.equipmentId_dikem == item.equipmentId_dikem).FirstOrDefault();
                                    if (thietbi == null)
                                    {
                                        thietbi = new Supply_DiKem
                                        {
                                            equipmentId = equipmentId,
                                            note = item.supplyStatus,
                                            quantity = item.quantity_in,
                                            equipmentId_dikem = item.equipmentId_dikem
                                        };
                                        db.Supply_DiKem.Add(thietbi);
                                    }
                                    else
                                    {
                                        thietbi.quantity = item.quantity_in;
                                        thietbi.note = item.supplyStatus;
                                    }
                                }
                                else
                                {
                                    Supply_SCTX vattu = db.Supply_SCTX.Where(x => x.equipmentId == equipmentId && x.supply_id == item.supply_id).FirstOrDefault();
                                    if (vattu == null)
                                    {
                                        vattu = new Supply_SCTX
                                        {
                                            equipmentId = equipmentId,
                                            quantity = item.quantity_in,
                                            supply_id = item.supply_id
                                        };
                                        db.Supply_SCTX.Add(vattu);
                                    }
                                    else
                                    {
                                        vattu.quantity = item.quantity_in;
                                    }
                                }
                                db.SaveChanges();
                            }
                            if (acceptance.attach_to == null)
                            {
                                equipment.current_Status = 2;
                            }
                            break;
                        case 4:
                            if (acceptance.attach_to == null)
                            {
                                equipment.current_Status = 1;
                            }
                            break;
                        case 5:
                            if (acceptance.attach_to == null)
                            {
                                equipment.current_Status = 15;
                                db.Database.ExecuteSqlCommand("DELETE FROM Supply_SCTX WHERE equipmentId = @equipmentId",
                                    new SqlParameter("equipmentId", equipmentId));
                                db.Database.ExecuteSqlCommand("DELETE FROM Supply_DiKem WHERE equipmentId = @equipmentId",
                                    new SqlParameter("equipmentId", equipmentId));
                            }
                            break;
                        case 6:
                            int documentary_big_maintain_id = db.Documentary_big_maintain_details.Where(x => x.equipmentId == acceptance.equipmentId && x.documentary_id == acceptance.documentary_id).First().documentary_big_maintain_id;

                            List<Supply_Documentary_Big_Maintain_Equipment> list = db.Supply_Documentary_Big_Maintain_Equipment.Where(x => x.documentary_big_maintain_id == documentary_big_maintain_id).ToList();

                            supplies_id = list.Where(x => x.supply_id != null).Select(x => x.supply_id).ToList();
                            s = db.Supply_SCTX.Where(x => x.equipmentId == equipmentId && supplies_id.Contains(x.supply_id)).ToList();

                            foreach (Supply_SCTX item in s)
                            {
                                Supply_Documentary_Big_Maintain_Equipment temp = list.Where(x => x.supply_id.Equals(item.supply_id)).FirstOrDefault();
                                item.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                                supplies_id.Remove(item.supply_id);
                            }
                            foreach (string item in supplies_id)
                            {
                                Supply_Documentary_Big_Maintain_Equipment temp = list.Where(x => x.supply_id.Equals(item)).FirstOrDefault();
                                Supply_SCTX supply = new Supply_SCTX
                                {
                                    equipmentId = equipmentId,
                                    supply_id = item
                                };
                                supply.quantity += temp.quantity_in + temp.quantity_out - temp.quantity_used;
                                db.Supply_SCTX.Add(supply);
                            }
                            if (acceptance.attach_to == null)
                            {
                                equipment.current_Status = 1;
                            }
                            break;
                        case 7:
                            List<Supply_Documentary_Equipment> supplies = db.Supply_Documentary_Equipment.Where(x => x.documentary_id == documentary.documentary_id && x.equipmentId == equipmentId).ToList();
                            foreach (Supply_Documentary_Equipment item in supplies)
                            {
                                if (item.equipmentId_dikem != null)
                                {
                                    Supply_DiKem supply7 = db.Supply_DiKem.Where(x => x.equipmentId == equipmentId && x.equipmentId_dikem == item.equipmentId_dikem).FirstOrDefault();
                                    if (supply7 == null)
                                    {
                                        supply7 = new Supply_DiKem
                                        {
                                            equipmentId = equipmentId,
                                            quantity = item.quantity_in,
                                            equipmentId_dikem = item.equipmentId_dikem
                                        };
                                        db.Supply_DiKem.Add(supply7);
                                    }
                                    else
                                    {
                                        supply7.quantity = item.quantity_in;
                                    }
                                }
                                else
                                {
                                    Vattu_Dikem supply7 = db.Vattu_Dikem.Where(x => x.equipmentId == equipmentId && x.supply_id == item.supply_id).FirstOrDefault();
                                    if (supply7 == null)
                                    {
                                        supply7 = new Vattu_Dikem
                                        {
                                            equipmentId = equipmentId,
                                            quantity = item.quantity_in,
                                            supply_id = item.supply_id
                                        };
                                        db.Vattu_Dikem.Add(supply7);
                                    }
                                    else
                                    {
                                        supply7.quantity = item.quantity_in;
                                    }
                                }
                                db.SaveChanges();
                            }
                            if (acceptance.attach_to == null)
                            {
                                equipment.current_Status = 1;
                            }
                            break;
                        default:
                            break;
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

        [Auther(RightID = "82")]
        [HttpPost]
        [Route("phong-cdvt/quyet-dinh/sua-chua/nghiem-thu/GetData")]
        public ActionResult GetDetail(string equipmentId, string attach_to, bool isSupply, int documentary_type, int documentary_id)
        {
            attach_to = attach_to == "" ? null : attach_to;
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    if (documentary_type == 1)
                        if (isSupply)
                        {
                            var list = (from a in db.Supplies
                                        join b in db.Supply_Documentary_Repair_Equipment on a.supply_id equals b.supply_id
                                        join c in db.Documentary_repair_details on b.documentary_repair_id equals c.documentary_repair_id
                                        where c.equipmentId == equipmentId && c.attach_to == attach_to && c.documentary_id == documentary_id
                                        select new
                                        {
                                            a.supply_id,
                                            a.supply_name,
                                            b.quantity_plan,
                                            b.quantity_in,
                                            b.quantity_out,
                                            b.quantity_used,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                        else
                        {
                            var list = (from a in db.Equipments
                                        join b in db.Supply_Documentary_Repair_Equipment on a.equipmentId equals b.equipmentId
                                        join c in db.Documentary_repair_details on b.documentary_repair_id equals c.documentary_repair_id
                                        where c.equipmentId == equipmentId && c.attach_to == attach_to && c.documentary_id == documentary_id
                                        select new
                                        {
                                            a.equipmentId,
                                            a.equipment_name,
                                            b.quantity_plan,
                                            b.quantity_in,
                                            b.quantity_out,
                                            b.quantity_used,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                    else if (documentary_type == 2)
                        if (isSupply)
                        {
                            var list = (from a in db.Supplies
                                        join b in db.Supply_Documentary_Maintain_Equipment on a.supply_id equals b.supply_id
                                        join c in db.Documentary_maintain_details on b.documentary_maintain_id equals c.documentary_maintain_id
                                        where c.equipmentId == equipmentId && c.attach_to == attach_to && c.documentary_id == documentary_id
                                        select new
                                        {
                                            a.supply_id,
                                            a.supply_name,
                                            b.quantity_plan,
                                            b.quantity_in,
                                            b.quantity_out,
                                            b.quantity_used,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                        else
                        {
                            var list = (from a in db.Equipments
                                        join b in db.Supply_Documentary_Maintain_Equipment on a.equipmentId equals b.equipmentId
                                        join c in db.Documentary_maintain_details on b.documentary_maintain_id equals c.documentary_maintain_id
                                        where c.equipmentId == equipmentId && c.attach_to == attach_to && c.documentary_id == documentary_id
                                        select new
                                        {
                                            a.equipmentId,
                                            a.equipment_name,
                                            b.quantity_plan,
                                            b.quantity_in,
                                            b.quantity_out,
                                            b.quantity_used,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                    else if (documentary_type == 6)
                        if (isSupply)
                        {
                            var list = (from a in db.Supplies
                                        join b in db.Supply_Documentary_Big_Maintain_Equipment on a.supply_id equals b.supply_id
                                        join c in db.Documentary_big_maintain_details on b.documentary_big_maintain_id equals c.documentary_big_maintain_id
                                        where c.equipmentId == equipmentId && c.attach_to == attach_to && c.documentary_id == documentary_id
                                        select new
                                        {
                                            a.supply_id,
                                            a.supply_name,
                                            b.quantity_plan,
                                            b.quantity_in,
                                            b.quantity_out,
                                            b.quantity_used,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                        else
                        {
                            var list = (from a in db.Equipments
                                        join b in db.Supply_Documentary_Big_Maintain_Equipment on a.equipmentId equals b.equipmentId
                                        join c in db.Documentary_big_maintain_details on b.documentary_big_maintain_id equals c.documentary_big_maintain_id
                                        where c.equipmentId == equipmentId && c.attach_to == attach_to && c.documentary_id == documentary_id
                                        select new
                                        {
                                            a.equipmentId,
                                            a.equipment_name,
                                            b.quantity_plan,
                                            b.quantity_in,
                                            b.quantity_out,
                                            b.quantity_used,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                    else if (documentary_type == 7)
                        if (isSupply)
                        {
                            var list = (from a in db.Supplies
                                        join b in db.Supply_Documentary_Improve_Equipment on a.supply_id equals b.supply_id
                                        join c in db.Documentary_Improve_Detail on b.documentary_improve_id equals c.documentary_improve_id
                                        where c.equipmentId == equipmentId && c.documentary_id == documentary_id
                                        select new
                                        {
                                            id = a.supply_id,
                                            name = a.supply_name,
                                            b.quantity_before,
                                            b.quantity_after,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                        else
                        {
                            var list = (from a in db.Equipments
                                        join b in db.Supply_Documentary_Improve_Equipment on a.equipmentId equals b.equipmentId
                                        join c in db.Documentary_Improve_Detail on b.documentary_improve_id equals c.documentary_improve_id
                                        where c.equipmentId == equipmentId && c.documentary_id == documentary_id
                                        select new
                                        {
                                            id = a.equipmentId,
                                            name = a.equipment_name,
                                            b.quantity_before,
                                            b.quantity_after,
                                            b.supplyDocumentaryEquipmentId
                                        }).ToList();
                            return Json(new { success = true, data = list });
                        }
                    else
                        return Json(new { success = false });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
    }
}