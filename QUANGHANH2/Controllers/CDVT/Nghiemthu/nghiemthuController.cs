
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

namespace QUANGHANHCORE.Controllers.CDVT.Nghiemthu
{
    public class nghiemthuController : Controller
    {
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
            List<Document> documentList = new List<Document>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                if (departID.Contains("PX"))
                {
                    docList = (from a in db.Acceptances

                               join b in db.Equipments.Where(x => x.department_id.Equals(departID)) on a.equipmentId equals b.equipmentId
                               join c in db.Documentaries on a.documentary_id equals c.documentary_id
                               where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                               join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                               select new
                               {
                                   documentary_id = a.documentary_id,
                                   equipmentId = b.equipmentId,
                                   equipment_name = b.equipment_name,
                                   documentary_code = c.documentary_code,
                                   documentary_type = c.documentary_type,
                                   documentary_name = d.documentary_name,
                                   du_phong = d.du_phong,
                                   di_kem = d.di_kem

                               }).ToList().Select(p => new Documentary_Extend
                               {
                                   documentary_id = p.documentary_id,
                                   equipmentId = p.equipmentId,
                                   equipment_name = p.equipment_name,
                                   documentary_code = p.documentary_code,
                                   documentary_type = p.documentary_type,
                                   documentary_name = p.documentary_name,
                                   du_phong = p.du_phong,
                                   di_kem = p.di_kem
                               }).ToList();
                }
                else
                {
                    docList = (from a in db.Acceptances

                               join b in db.Equipments on a.equipmentId equals b.equipmentId
                               join c in db.Documentaries on a.documentary_id equals c.documentary_id
                               where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                               join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                               select new
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

                               }).ToList().Select(p => new Documentary_Extend
                               {
                                   documentary_id = p.documentary_id,
                                   equipmentId = p.equipmentId,
                                   equipment_name = p.equipment_name,
                                   documentary_code = p.documentary_code,
                                   documentary_type = p.documentary_type,
                                   documentary_name = p.documentary_name,
                                   du_phong = p.du_phong,
                                   di_kem = p.di_kem,
                                   can = p.can
                               }).ToList();
                }

                foreach (Documentary_Extend item in docList)
                {
                    item.temp = item.documentary_id + "^" + item.documentary_code;
                }
 

                foreach (Documentary_Extend items in docList)
                {
                    items.idAndid = items.equipmentId + "^" + items.documentary_id;
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




                //docList = db.Documentaries.ToList<Documentary>();
                int totalrows = docList.Count;
                int totalrowsafterfiltering = docList.Count;
                //sorting
                docList = docList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_Extend>();
                //paging
                docList = docList.Skip(start).Take(length).ToList<Documentary_Extend>();
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var query = db.Documentaries.SqlQuery("Select doc.documentary_id,doc.documentary_code,doc.reason,doc.documentary_type,doc.department_id,doc.department_id_to,doc.documentary_id, doc.date_created,doc.person_created,doc.[out/in_come] as out_in_come,doc.documentary_status from Documentary doc where documentary_id = @id",
                     new SqlParameter("id", id)).FirstOrDefault<Documentary>();
                return View(query);
            }

        }


        [Auther(RightID = "82")]
        [HttpPost]
        [Route("phong-cdvt/nghiem-thu/Edit")]
        public ActionResult Edit(string id, string documentary_code, string documentary_id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
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
                            equipment.current_Status = 2;
                            break;
                        case 2:
                            Documentary_maintain_details Documentary_maintain_details = db.Database.SqlQuery<Documentary_maintain_details>("SELECT * FROM Documentary_maintain_details WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id),
                                new SqlParameter("documentary_id", documentary.documentary_id)).First();
                            equipment.current_Status = 2;
                            break;
                        case 3:
                            Documentary_moveline_details documentary_Moveline_Details = db.Database.SqlQuery<Documentary_moveline_details>("SELECT * FROM Documentary_moveline_details WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id),
                                new SqlParameter("documentary_id", documentary.documentary_id)).First();
                            db.Database.ExecuteSqlCommand("DELETE FROM Supply_DuPhong WHERE equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id));
                            db.Database.ExecuteSqlCommand("DELETE FROM Supply_DiKem WHERE equipmentId = @equipmentId",
                                new SqlParameter("equipmentId", id));
                            List<Supply_Documentary_Equipment> supplies_Moveline = db.Supply_Documentary_Equipment.Where(x => x.documentary_id == documentary.documentary_id && x.equipmentId == id).ToList();
                            foreach (Supply_Documentary_Equipment item in supplies_Moveline)
                            {
                                if (item.supply_documentary_status == 0)
                                {
                                    Supply_DiKem s = db.Supply_DiKem.Where(x => x.equipmentId == id && x.equipmentId_dikem == item.equipmentId_dikem).FirstOrDefault();
                                    if (s == null)
                                    {
                                        s = new Supply_DiKem();
                                        s.equipmentId = id;
                                        s.note = item.supplyStatus;
                                        s.quantity = item.quantity_in;
                                        s.equipmentId_dikem = item.equipmentId_dikem;
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
                                    Supply_DuPhong s = db.Supply_DuPhong.Where(x => x.equipmentId == id && x.supply_id == item.supply_id).FirstOrDefault();
                                    if (s == null)
                                    {
                                        s = new Supply_DuPhong();
                                        s.equipmentId = id;
                                        s.quantity = item.quantity_in;
                                        s.supply_id = item.supply_id;
                                        db.Supply_DuPhong.Add(s);
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
                            db.Database.ExecuteSqlCommand("DELETE FROM Supply_DuPhong WHERE equipmentId = @equipmentId",
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
                                    s = new Supply_DiKem();
                                    s.equipmentId = id;
                                    s.note = item.supplyStatus;
                                    s.quantity = item.quantity_used;
                                    s.equipmentId_dikem = item.equipmentId_dikem;
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
                    //List<Supply_Documentary_Equipment> ListSD = db.Database.SqlQuery<Supply_Documentary_Equipment>("SELECT * FROM Supply_Documentary_Equipment WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId AND supplyType = 1",
                    //    new SqlParameter("equipmentId", id),
                    //    new SqlParameter("documentary_id", documentary.documentary_id)).ToList();
                    //List<Supply_Documentary_Equipment> ListTH = db.Database.SqlQuery<Supply_Documentary_Equipment>("SELECT * FROM Supply_Documentary_Equipment WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId AND supplyType = 2",
                    //    new SqlParameter("equipmentId", id),
                    //    new SqlParameter("documentary_id", documentary.documentary_id)).ToList();
                    //foreach (Supply_Documentary_Equipment item in ListSD)
                    //{
                    //    db.Database.ExecuteSqlCommand("UPDATE Supply_tieuhao SET used = (used + @param) WHERE supplyid = @supplyid",
                    //        new SqlParameter("param", item.quantity_used),
                    //        new SqlParameter("supplyid", item.supply_id));
                    //}
                    //foreach (Supply_Documentary_Equipment item in ListTH)
                    //{
                    //    db.Database.ExecuteSqlCommand("UPDATE Supply_tieuhao SET thuhoi = (thuhoi + @param) WHERE supplyid = @supplyid",
                    //        new SqlParameter("param", item.quantity_out),
                    //        new SqlParameter("supplyid", item.supply_id));
                    //}
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



    //public ActionResult ChangeStatus(string id)
    //{
    //    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
    //    {
    //        try
    //        {
    //            var query = "UPDATE Documentary SET documentary_status = 3 FROM Acceptance T1, Documentary T2 WHERE T1.documentary_id = T2.documentary_id AND T1.equipmentId = '" + id + "'";
    //            db.Database.ExecuteSqlCommand(query);
    //            db.SaveChanges();
    //        }
    //        catch
    //        {
    //            Response.Write("Có lỗi xảy ra");
    //            return new HttpStatusCodeResult(400);
    //        }
    //        return RedirectToAction("Search");
    //    }
    //}


    public ActionResult UpdateSupply(string supply_id, string equipmentId, string departmentid)
    {
        using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        {
            try
            {
               Suply query = db.Database.SqlQuery<Suply>(" select sum(quantity) as sum_type_1 from Supply_Documentary_Equipment where supplyType = 1 and equipmentId = @equipmentId",
                   new SqlParameter("equipmentId", equipmentId)).First();
               Suply query2 = db.Database.SqlQuery<Suply>(" select sum(quantity) as sum_type_2 from Supply_Documentary_Equipment where supplyType = 2 and equipmentId =  @equipmentId",
                   new SqlParameter("equipmentId", equipmentId)).First();
                    var query3 = "Update Supply_tieuhao Set used = used + @sum1,thuhoi = thuhoi + @sum2 From Supply_Documentary_Equipment T1, Documentary T2, Supply T3, Supply_tieuhao T4 Where T1.documentary_id = T2.documentary_id and T1.supply_id = T3.supply_id and T3.supply_id = T4.supplyid and T3.supply_id = @supply_id and departmentid = @departmentid and month(GETDATE()) = month([date]) and year(GETDATE()) = year([date])";
                db.Database.ExecuteSqlCommand(query3,
                    new SqlParameter("sum1", query.sum_type_1),
                    new SqlParameter("sum2", query2.sum_type_2),
                    new SqlParameter("supply_id", supply_id),
                    new SqlParameter("departmentid", departmentid));
                    db.SaveChanges();
            }
            catch
            {
                Response.Write("Có lỗi xảy ra");
                return new HttpStatusCodeResult(400);
            }
            return View();
        }
    }
}







    public class Document
        {
            public string documentary_type { get; set; }
            public int documentary_id { get; set; }

            public string equipmentId { get; set; }
            public int countID { get; set; }
    }

    public class Suply
    {
        public string supplyid { get; set; }
        public string departmentid { get; set; }
        public DateTime date { get; set; }
        public int used { get; set; }
        public int thuhoi { get; set; }
        public int sumUsed { get; set; }
        public int sumThuhoi { get; set; }
        public string equipmentId { get; set; }
        public int sum_type_1 { get; set; }
        public int sum_type_2 { get; set; }
    }
}
