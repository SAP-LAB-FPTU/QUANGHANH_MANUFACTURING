using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Quyetdinh.BaoDuong
{
    public class XuLyController : Controller
    {
        [Auther(RightID = "86,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/bao-duong")]
        public ActionResult Index(int id)
        {
            try
            {
                QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
                string departid = Session["departID"].ToString();
                Documentary documentary = DBContext.Documentaries.Where(x => x.documentary_id == id && x.department_id_to == departid).FirstOrDefault();
                if (documentary == null)
                    Redirect("/phong-cdvt/cap-nhat/quyet-dinh");

                if (documentary.documentary_status == 1) ViewBag.AddAble = true;
                else ViewBag.AddAble = false;

                ViewBag.documentary_id = documentary.documentary_id;
                ViewBag.documentary_code = documentary.documentary_code as string;
                return View("/Views/CDVT/Quyetdinh/BaoDuong/XuLy.cshtml");
            }
            catch (Exception)
            {
                Response.Write("Số quyết định không tồn tại hoặc chưa được cấp");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-cdvt/quyet-dinh/bao-duong/xu-ly/GetData")]
        [HttpPost]
        public ActionResult GetData(int id)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<string> equipmentId = new List<string>();

                List<Detail> details = (from a in db.Documentary_maintain_details
                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                        where (b.documentary_id == id)
                                        select new Detail
                                        {
                                            documentary_maintain_id = a.documentary_maintain_id,
                                            equipmentId = a.equipmentId,
                                            attach_to = a.attach_to,
                                            equipment_maintain_reason = a.equipment_maintain_reason,
                                            maintain_type = a.maintain_type,
                                            finish_date_plan = a.finish_date_plan + "",
                                            quantity = a.quantity,
                                            equipment_maintain_status = a.equipment_maintain_status
                                        }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();

                foreach (Detail item in details)
                {
                    equipmentId.Add(item.equipmentId);
                    item.finish_date_plan = DateTime.Parse(item.finish_date_plan).ToString("dd/MM/yyyy");
                }

                var dict = db.Equipments
                    .Where(x => equipmentId.Contains(x.equipmentId))
                    .Select(x => new { x.equipmentId, x.equipment_name })
                    .AsEnumerable()
                    .ToDictionary(x => x.equipmentId, x => x.equipment_name);

                details.ForEach(x => x.equipment_name = dict[x.equipmentId]);
                return Json(new { success = true, data = details, draw = Request["draw"], recordsTotal = details.Count, recordsFiltered = details.Count }, JsonRequestBehavior.AllowGet);
            }
        }

        public class Detail
        {
            public int documentary_maintain_id { get; set; }
            public string equipmentId { get; set; }
            public string attach_to { get; set; }
            public string equipment_name { get; set; }
            public string equipment_maintain_reason { get; set; }
            public string maintain_type { get; set; }
            public string finish_date_plan { get; set; }
            public int quantity { get; set; }
            public int equipment_maintain_status { get; set; }
        }

        [Auther(RightID = "86,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/quyet-dinh/bao-duong/xu-ly")]
        [HttpPost]
        public ActionResult editpost(string edit, int id)
        {
            if (edit != "")
            {
                QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
                using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
                {
                    try
                    {
                        JArray array = JArray.Parse(edit);
                        foreach (var item in array)
                        {
                            Documentary_maintain_details temp = DBContext.Documentary_maintain_details.Find(item.Value<int>());
                            temp.equipment_maintain_status = 1;
                            Acceptance a = new Acceptance
                            {
                                acceptance_date = DateTime.Now,
                                documentary_id = id,
                                equipmentId = temp.equipmentId,
                                attach_to = temp.attach_to,
                                equipmentStatus = 2
                            };
                            DBContext.Acceptances.Add(a);
                            DBContext.SaveChanges();
                        }
                        int NotDone = (from a in DBContext.Documentary_maintain_details
                                       join b in DBContext.Documentaries on a.documentary_id equals b.documentary_id
                                       where b.documentary_id == id && b.documentary_type == 1 && a.equipment_maintain_status == 0
                                       select a).Count();
                        if (NotDone == 0)
                        {
                            Documentary docu = DBContext.Documentaries.Find(id);
                            docu.documentary_status = 2;

                            Notification noti = new Notification
                            {
                                date = DateTime.Now.Date,
                                department_id = docu.department_id_to,
                                description = "sua chua 2",
                                id_problem = docu.documentary_id,
                                isread = false
                            };
                            DBContext.Notifications.Add(noti);
                            DBContext.SaveChanges();
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

        [Auther(RightID = "82,86,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/quyet-dinh/bao-duong/xu-ly/edit")]
        [HttpPost]
        public ActionResult EditDetails(string data)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        JObject input = JObject.Parse(data);
                        List<int> supplyDocumentaryEquipmentId = input.Properties().Select(x => int.Parse(x.Name)).ToList();
                        List<Supply_Documentary_Maintain_Equipment> list = db.Supply_Documentary_Maintain_Equipment.Where(x => supplyDocumentaryEquipmentId.Contains(x.supplyDocumentaryEquipmentId)).ToList();
                        if (list.Select(x => x.documentary_maintain_id).Distinct().Count() != 1)
                        {
                            return Json(new { success = false, message = "Dữ liệu truyền vào không đúng" });
                        }

                        List<string> RightIDs = (List<string>)HttpContext.Session["RightIDs"];

                        if (!RightIDs.Contains("82") && db.Documentary_maintain_details.Find(list[0].documentary_maintain_id).equipment_maintain_status == 1)
                        {
                            return Json(new { success = false, message = "Thiết bị đã được xử lý xong" });
                        }

                        foreach (var item in list)
                        {
                            int quantity_in = int.Parse(input[item.supplyDocumentaryEquipmentId.ToString()]["quantity_in"].ToString());
                            int quantity_out = int.Parse(input[item.supplyDocumentaryEquipmentId.ToString()]["quantity_out"].ToString());
                            int quantity_used = int.Parse(input[item.supplyDocumentaryEquipmentId.ToString()]["quantity_used"].ToString());

                            if (quantity_in < item.quantity_in || quantity_out < item.quantity_out || quantity_used < item.quantity_used)
                            {
                                transaction.Rollback();
                                return Json(new { success = false, message = "Không được nhập giá trị nhỏ hơn ban đầu" });
                            }

                            item.quantity_in = quantity_in;
                            item.quantity_out = quantity_out;
                            item.quantity_used = quantity_used;
                        }
                        db.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true });
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" });
                    }
                }
            }
        }
    }
}