//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using System.Web.Routing;
//using QUANGHANH2.Models;
//using System.Data.Entity;
//using System.Linq.Dynamic;
//using QUANGHANH2.SupportClass;
//using System.Data.SqlClient;
//using Newtonsoft.Json.Linq;

//namespace QUANGHANH2.Controllers.CDVT.Cap_nhat
//{
//    public class QDCaitienController : Controller
//    {
//        [Auther(RightID = "86,179,180,181,183,184,185,186,187,189,195,003")]
//        [Route("phong-cdvt/cap-nhat/quyet-dinh/cai-tien")]
//        [HttpGet]
//        public ActionResult Index(int id)
//        {
//            try
//            {
//                QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
//                string departid = Session["departID"].ToString();
//                Documentary documentary = DBContext.Database.SqlQuery<Documentary>("SELECT docu.*, docu.[out/in_come] as out_in_come FROM Documentary_Improve_Detail as detail inner join Documentary as docu on detail.documentary_id = docu.documentary_id WHERE docu.documentary_code IS NOT NULL AND detail.documentary_id = @documentary_id AND docu.department_id_to = @departid",
//                    new SqlParameter("documentary_id", id), new SqlParameter("departid", departid)).First();
//                //List<Supply> supplies = DBContext.Supplies.ToList();
//                //List<Equipment> equipAttached = DBContext.Equipments.Where(x => x.isAttach == true).ToList().Select(x => new Equipment
//                //{
//                //    equipmentId = x.equipmentId,
//                //    equipment_name = x.equipment_name
//                //}).ToList();
//                //ViewBag.equipAttached = equipAttached;
//                //ViewBag.Supplies = supplies;
//                if (documentary.documentary_status == 1) ViewBag.AddAble = true;
//                else ViewBag.AddAble = false;
//                ViewBag.id = documentary.documentary_id;
//                ViewBag.code = documentary.documentary_code as string;
//                return View("/Views/CDVT/Quyetdinh/DieuChinh/XuLy.cshtml");
//            }
//            catch (Exception)
//            {
//                Response.Write("Số quyết định không tồn tại hoặc chưa được cấp");
//                return new HttpStatusCodeResult(400);
//            }
//        }

//        [Route("phong-cdvt/cap-nhat/quyet-dinh/cai-tien/GetData")]
//        [HttpPost]
//        public ActionResult GetData(int id)
//        {
//            //Server Side Parameter
//            int start = Convert.ToInt32(Request["start"]);
//            int length = Convert.ToInt32(Request["length"]);
//            string searchValue = Request["search[value]"];
//            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//            string sortDirection = Request["order[0][dir]"];
//            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
//            db.Configuration.LazyLoadingEnabled = false;
//            string departid = Session["departID"].ToString();
//            List<Detail> documentariesList = (from a in db.Documentary_Improve_Detail
//                                              join b in db.Documentaries on a.documentary_id equals b.documentary_id
//                                              join c in db.Equipments on a.equipmentId equals c.equipmentId
//                                              join d in db.Status on c.current_Status equals d.statusid
//                                              where (b.documentary_id == id)
//                                              select new Detail
//                                              {
//                                                  documentary_improve_id = a.documentary_improve_id,
//                                                  equipmentId = c.equipmentId,
//                                                  equipment_name = c.equipment_name,
//                                                  statusname = d.statusname,
//                                                  equipment_Improve_status = a.equipment_Improve_status
//                                              }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
//            int totalrows = (from a in db.Documentary_Improve_Detail
//                             join b in db.Documentaries on a.documentary_id equals b.documentary_id
//                             join c in db.Equipments on a.equipmentId equals c.equipmentId
//                             join d in db.Status on c.current_Status equals d.statusid
//                             where (b.documentary_id == id)
//                             select new Detail
//                             {
//                                 documentary_improve_id = a.documentary_improve_id,
//                                 equipmentId = c.equipmentId,
//                                 equipment_name = c.equipment_name,
//                                 statusname = d.statusname,
//                                 equipment_Improve_status = a.equipment_Improve_status
//                             }).Count();

//            return Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
//        }

//        public class Detail
//        {
//            public int documentary_improve_id { get; set; }
//            public string equipmentId { get; set; }
//            public string equipment_name { get; set; }
//            public string statusname { get; set; }
//            public int equipment_Improve_status { get; set; }
//        }

//        [Auther(RightID = "86,179,180,181,183,184,185,186,187,189,195,003")]
//        [Route("phong-cdvt/cap-nhat/quyet-dinh/cai-tien/edit")]
//        [HttpPost]
//        public ActionResult editpost(string edit, int id)
//        {
//            ViewBag.id = id;
//            if (edit != "")
//            {
//                QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
//                using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
//                {
//                    try
//                    {
//                        edit = edit.Substring(0, edit.Length - 1);
//                        char[] spearator = { '^' };
//                        String[] list = edit.Split(spearator,
//                           StringSplitOptions.RemoveEmptyEntries);
//                        foreach (var item in list)
//                        {
//                            Documentary_Improve_Detail temp = DBContext.Documentary_Improve_Detail.Where(x => x.equipmentId.Equals(item) && x.documentary_id.Equals(id)).First();
//                            temp.equipment_Improve_status = 1;
//                            Acceptance a = new Acceptance();
//                            a.acceptance_date = DateTime.Now;
//                            a.documentary_id = id;
//                            a.equipmentId = item;
//                            a.equipmentStatus = 2;
//                            DBContext.Acceptances.Add(a);
//                            DBContext.SaveChanges();
//                        }
//                        if (DBContext.Database.SqlQuery<Documentary_Improve_DetailDB>("select details.equipment_Improve_status from Department depa inner join Documentary docu on depa.department_id = docu.department_id_to inner join Documentary_Improve_Detail details on details.documentary_id = docu.documentary_id inner join Equipment e on e.equipmentId = details.equipmentId where docu.documentary_type = 7 and details.documentary_id = @documentary_id and equipment_Improve_status = '0'", new SqlParameter("documentary_id", id)).Count() == 0)
//                        {
//                            Documentary docu = DBContext.Documentaries.Find(id);
//                            docu.documentary_status = 2;

//                            Notification noti = new Notification();
//                            noti.date = DateTime.Now.Date;
//                            noti.department_id = docu.department_id_to;
//                            noti.description = "cai tien 2";
//                            noti.id_problem = docu.documentary_id;
//                            noti.isread = false;
//                            DBContext.Notifications.Add(noti);
//                            DBContext.SaveChanges();
//                        }

//                        DBContext.SaveChanges();
//                        transaction.Commit();
//                        return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
//                    }
//                    catch (Exception)
//                    {
//                        transaction.Rollback();
//                        return Json(new { success = false, message = "Có lỗi xảy ra" }, JsonRequestBehavior.AllowGet);
//                    }
//                }
//            }
//            return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
//        }

//        [Auther(RightID = "86,179,180,181,183,184,185,186,187,189,195,003")]
//        [Route("phong-cdvt/cap-nhat/quyet-dinh/cai-tien/update")]
//        [HttpPost]
//        public ActionResult AddSupply(string list, int documentary_id, string equipmentId, bool IsSupply)
//        {
//            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
//            Documentary_Improve_Detail detail = DBContext.Documentary_Improve_Detail.Where(x => x.equipmentId == equipmentId && x.documentary_id == documentary_id).FirstOrDefault();
//            if (detail.equipment_Improve_status == 1)
//                return Json(new { success = false, message = "Thiết bị đã được xử lý xong" });

//            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
//            {
//                try
//                {
//                    JObject json = JObject.Parse(list);
//                    JArray arr = (JArray)json.SelectToken("list");  //list của thiết bị con đi kèm, dự phòng và vật tư sctx
//                    foreach (JObject item in arr)
//                    {
//                        string supply_id = (string)item["supply_id"];
//                        Supply_Documentary_Equipment temp;
//                        if (!IsSupply)
//                        {
//                            temp = DBContext.Supply_Documentary_Equipment.Where(a => a.documentary_id == documentary_id && a.equipmentId == equipmentId && a.equipmentId_dikem == supply_id).FirstOrDefault();
//                        }
//                        else
//                        {
//                            temp = DBContext.Supply_Documentary_Equipment.Where(a => a.documentary_id == documentary_id && a.equipmentId == equipmentId && a.supply_id == supply_id).FirstOrDefault();
//                        }
//                        if (temp == null)
//                        {
//                            temp = new Supply_Documentary_Equipment
//                            {
//                                documentary_id = documentary_id,
//                                equipmentId = equipmentId,
//                                quantity_in = (int)item["quantity_in"],
//                                quantity_plan = item["quantity_plan"] == null ? 0 : (int)item["quantity_plan"],
//                            };
//                            if (IsSupply)
//                                temp.supply_id = supply_id;
//                            else
//                                temp.equipmentId_dikem = supply_id;
//                            DBContext.Supply_Documentary_Equipment.Add(temp);
//                        }
//                        else
//                        {
//                            temp.quantity_in = (int)item["quantity_in"] < temp.quantity_in ? temp.quantity_in : (int)item["quantity_in"];
//                        }
//                        DBContext.SaveChanges();
//                    }
//                    DBContext.SaveChanges();
//                    transaction.Commit();
//                    return Json(new { success = true, message = "Cập nhật thành công" });
//                }
//                catch (Exception)
//                {
//                    transaction.Rollback();
//                    return Json(new { success = false, message = "Có lỗi xảy ra" });
//                }
//            }
//        }
//    }
//}