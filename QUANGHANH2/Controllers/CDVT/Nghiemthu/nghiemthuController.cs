
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

        [Auther(RightID = "25")]
        [Route("phong-cdvt/nghiem-thu/search")]
        [HttpPost]
        public ActionResult Search(string document_code, string equiment_id, string equiment_name)
        {
            //Server Side Parameter
            //string requestID = Request["sessionId"];
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

                docList = (from a in db.Acceptances

                           join b in db.Equipments on a.equipmentId equals b.equipmentId
                           join c in db.Documentaries on a.documentary_id equals c.documentary_id
                           where (a.equipmentStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equiment_id)) && (b.equipment_name.Contains(equiment_name))
                           select new
                           {
                               documentary_id = a.documentary_id,
                               equipmentId = b.equipmentId,
                               equipment_name = b.equipment_name,
                               documentary_code = c.documentary_code,
                               documentary_type = c.documentary_type

                           }).ToList().Select(p => new Documentary_Extend
                           {
                               documentary_id = p.documentary_id,
                               equipmentId = p.equipmentId,
                               equipment_name = p.equipment_name,
                               documentary_code = p.documentary_code,
                               documentary_type = p.documentary_type
                           }).ToList();
                foreach (Documentary_Extend item in docList)
                {
                    item.temp = item.documentary_id + "^" + item.documentary_code;
                }
 

                foreach (Documentary_Extend items in docList)
                {
                    items.linkIdCode = new LinkIdCode2();
                    switch (items.documentary_type)
                    {
                        case "1":
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case "2":
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case "3":
                            items.linkIdCode.link = "vat-tu-kem-theo";
                            break;
                        case "4":
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case "5":
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case "6":
                            items.linkIdCode.link = "vat-tu";
                            break;
                    }
                    items.linkIdCode.code = items.equipmentId;
                    items.linkIdCode.id = items.equipmentId;
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
                var query = db.Documentaries.SqlQuery("Select doc.documentary_id,doc.documentary_code,doc.reason,doc.documentary_type,doc.department_id,doc.documentary_id, doc.date_created,doc.person_created,doc.[out/in_come] as out_in_come,doc.documentary_status from Documentary doc where documentary_id = @id",
                     new SqlParameter("id", id)).FirstOrDefault<Documentary>();
                return View(query);
            }

        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            List<Acceptance> AcceptanceList = new List<Acceptance>();
            List<Document> documentList = new List<Document>();
            List<Suply> supplyList = new List<Suply>();
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    //Boolean status = true;
                    db.Configuration.LazyLoadingEnabled = false;
                    documentList = (from a in db.Acceptances
                                    join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                    where a.equipmentId == id
                                    select new
                                    {
                                        documentary_id = a.documentary_id,
                                        equipmentId = a.equipmentId,
                                        documentary_type = b.documentary_type

                                    }).ToList().Select(p => new Document
                                    {
                                        documentary_id = p.documentary_id,
                                        equipmentId = p.equipmentId,
                                        documentary_type = p.documentary_type
                                    }).ToList();

                    supplyList = (from a in db.Supply_Documentary_Equipment
                                    join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                    join c in db.Supplies on a.supply_id equals c.supply_id
                                    join d in db.Supply_tieuhao on c.supply_id equals d.supplyid
                                    where a.equipmentId == id
                                    select new
                                    {
                                        supplyid = a.supply_id,
                                        equipmentId = a.equipmentId,
                                        departmentid = b.department_id


                                    }).ToList().Select(p => new Suply
                                    {
                                        supplyid = p.supplyid,
                                        equipmentId = p.equipmentId,
                                        departmentid = p.departmentid
                                    }).ToList();


                    foreach (Document items in documentList)
                    {
                        try
                        {
                            var query = "  UPDATE Acceptance SET acceptance_date = getdate(), equipmentStatus = 3 where equipmentId =  @id";
                            var query2 = "  UPDATE Supply_Documentary_Equipment SET supply_documentary_status = 1 WHERE documentary_id = @documentary_id and equipmentId = @equipmentId";
                            db.Database.ExecuteSqlCommand(query,
                               new SqlParameter("id", id));
                            db.Database.ExecuteSqlCommand(query2,
                                new SqlParameter("documentary_id", items.documentary_id),
                                 new SqlParameter("equipmentId", items.equipmentId));
                        }
                        catch (Exception e)
                        {
                            Response.Write("Có lỗi xảy ra");
                            return new HttpStatusCodeResult(400);
                        }
                        db.SaveChanges();
                    }
                    int count1 = 0, count2 = 0;
                    foreach (Document items in documentList)
                    {
                        Document query = db.Database.SqlQuery<Document>("select count(documentary_id) as countID from Acceptance where equipmentStatus = 3 and documentary_id = @documentary_id",
                                    new SqlParameter("documentary_id", items.documentary_id)).First();
                        count1 = query.countID;
                        var queryX = "";
                        var queryY = "";
                        switch (items.documentary_type)
                        {
                            case "1":
                                Document query1 = db.Database.SqlQuery<Document>("select count(documentary_id) as countID from Documentary_repair_details where documentary_id = @documentary_id",
                                    new SqlParameter("documentary_id", items.documentary_id)).First();
                                count2 = query1.countID;
                                queryX = "Update Equipment SET current_Status = 2 WHERE equipmentId = @equipmentId";
                                queryY = "Update Equipment SET department_id = T2.department_id FROM Equipment T1,Documentary_repair_details T2 Where T1.equipmentId = T2.equipmentId and T1.equipmentId = @equipmentId and T2.documentary_id = @documentary_id";

                                foreach (Suply item in supplyList)
                                {
                                    UpdateSupply(item.supplyid, item.equipmentId, item.departmentid);
                                    break;
                                }
                                break;
                            case "2":
                                Document query2 = db.Database.SqlQuery<Document>("select count(documentary_id) as countID from Documentary_maintain_details where documentary_id = @documentary_id",
                                    new SqlParameter("documentary_id", items.documentary_id)).First();
                                count2 = query2.countID;
                                queryX = "Update Equipment SET current_Status = 2 WHERE equipmentId = @equipmentId";
                                queryY = "Update Equipment SET department_id = T2.department_id FROM Equipment T1,Documentary_maintain_details T2 Where T1.equipmentId = T2.equipmentId and T1.equipmentId = @equipmentId and T2.documentary_id = @documentary_id ";
                                foreach (Suply item in supplyList)
                                {
                                    UpdateSupply(item.supplyid, item.equipmentId, item.departmentid);
                                    break;
                                }
                                break;
                            case "3":
                                Document query3 = db.Database.SqlQuery<Document>("select count(documentary_id) as countID from Documentary_moveline_details where documentary_id = @documentary_id",
                                    new SqlParameter("documentary_id", items.documentary_id)).First();
                                count2 = query3.countID;
                                queryX = "Update Equipment SET current_Status = 2 WHERE equipmentId = @equipmentId";
                                queryY = "Update Equipment SET department_id = T2.department_id FROM Equipment T1,Documentary_moveline_details T2 Where T1.equipmentId = T2.equipmentId and T1.equipmentId = @equipmentId  and T2.documentary_id = @documentary_id";
                                break;
                            case "4":
                                Document query4 = db.Database.SqlQuery<Document>("select count(documentary_id) as countID from Documentary_revoke_details where documentary_id = @documentary_id",
                                    new SqlParameter("documentary_id", items.documentary_id)).First();
                                count2 = query4.countID;
                                queryX = "Update Equipment SET current_Status = 1 WHERE equipmentId = @equipmentId";
                                queryY = "Update Equipment SET department_id = 'CDVT' FROM Equipment T1,Documentary_revoke_details T2 Where T1.equipmentId = T2.equipmentId and T1.equipmentId = @equipmentId  and T2.documentary_id = @documentary_id";
                                break;
                            case "5":
                                Document query5 = db.Database.SqlQuery<Document>("select count(documentary_id) as countID from Documentary_liquidation_details where documentary_id = @documentary_id",
                                    new SqlParameter("documentary_id", items.documentary_id)).First();
                                count2 = query5.countID;
                                queryX = "Update Equipment SET current_Status = 15 WHERE equipmentId = @equipmentId";
                                queryY = "Update Equipment SET department_id = 'CDVT' FROM Equipment T1,Documentary_liquidation_details T2 Where T1.equipmentId = T2.equipmentId and T1.equipmentId = @equipmentId  and T2.documentary_id = @documentary_id";
                                break;
                            case "6":
                                Document query6 = db.Database.SqlQuery<Document>("select count(documentary_id) as countID from Documentary_big_maintain_details where documentary_id = @documentary_id",
                                    new SqlParameter("documentary_id", items.documentary_id)).First();
                                count2 = query6.countID;
                                queryX = "Update Equipment SET current_Status = 1 WHERE equipmentId = @equipmentId";
                                queryY = "Update Equipment SET department_id = T2.department_id FROM Equipment T1,Documentary_big_maintain_details T2 Where T1.equipmentId = T2.equipmentId and T1.equipmentId = @equipmentId   and T2.documentary_id = @documentary_id";
                                foreach (Suply item in supplyList)
                                {
                                    UpdateSupply(item.supplyid, item.equipmentId, item.departmentid);
                                    break;
                                }
                                break;
                        }
                        if (queryX != "" && queryY != "")
                        {
                            db.Database.ExecuteSqlCommand(queryX,
                                new SqlParameter("equipmentId", items.equipmentId));
                            db.Database.ExecuteSqlCommand(queryY,
                                new SqlParameter("equipmentId", items.equipmentId),
                                new SqlParameter("documentary_id", items.documentary_id));
                            db.SaveChanges();
                        }
                        if (count1 == count2)
                        {
                            var queryZ = "UPDATE Documentary SET documentary_status = 3 FROM Acceptance T1, Documentary T2 WHERE T1.documentary_id = T2.documentary_id AND T1.equipmentId = @id";
                            db.Database.ExecuteSqlCommand(queryZ,
                               new SqlParameter("id", id));
                            db.SaveChanges();
                        }
                    }
                    transaction.Commit();
                    return View();
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
               Suply query = db.Database.SqlQuery<Suply>(" select sum(quantity) as sum_type_1 from Supply_Documentary_Equipment where supplyType = 1 and equipmentId = @equipmentId group by supply_id, equipmentId, documentary_id",
                   new SqlParameter("equipmentId", equipmentId)).First();
               Suply query2 = db.Database.SqlQuery<Suply>(" select sum(quantity) as sum_type_2 from Supply_Documentary_Equipment where supplyType = 2 and equipmentId =  @equipmentId group by supply_id, equipmentId, documentary_id",
                   new SqlParameter("equipmentId", equipmentId)).First();
                    var query3 = "Update Supply_tieuhao Set used = used + @sum1,thuhoi = thuhoi + @sum2 From Supply_Documentary_Equipment T1, Documentary T2, Supply T3, Supply_tieuhao T4 Where T1.documentary_id = T2.documentary_id and T1.supply_id = T3.supply_id and T3.supply_id = T4.supplyid and T3.supply_id = @supply_id and departmentid = @departmentid and month(GETDATE()) = month([date]) and year(GETDATE()) = year([date])";
                db.Database.ExecuteSqlCommand(query3,
                    new SqlParameter("sum1", query.sum_type_1),
                    new SqlParameter("sum2", query.sum_type_2),
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