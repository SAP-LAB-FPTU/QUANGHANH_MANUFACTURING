using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{

    public class LylichController : Controller
    {
        public class EquipWithName : Equipment
        {
            public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
            public string statusname { get; set; }
            public string Equipment_category_name { get; set; }
            public string department_name { get; set; }
        }
        public class Supply_DK : Supply_DiKem
        {
            public string equipment_name { get; set; }

        }

        public class Supply_DP : Supply_DuPhong
        {
            public string supply_name { get; set; }
        }

        [HttpPost]
        public ActionResult deleteLS(string id, string iddoc)
        {
            ViewBag.listID = null;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            string sql = "update Documentary_repair_details set isVisible = 0 where documentary_id = @iddoc and equipmentId = @id";
            db.Database.ExecuteSqlCommand(sql, new SqlParameter("id", id), new SqlParameter("iddoc", iddoc));

            return Json(new { success = true}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("phong-cdvt/thiet-bi")]
        public ActionResult Index()
        {
            return Redirect("/phong-cdvt/huy-dong");
        }
        [Auther(RightID = "10,6,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/thiet-bi")]
        [HttpPost]
        public ActionResult ABC(string id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            //lít vat tu
            List<Supply> listSup = DBContext.Supplies.ToList<Supply>();
            ViewBag.listSup = listSup;
            //list vat tu di kem
            List<Supply_DK> listsupdk = DBContext.Database.SqlQuery<Supply_DK>("select equipment_name from Equipment where isAttach = 1").ToList();
            ViewBag.listsupdk = listsupdk;
            //NK su co
            var years = DBContext.Database.SqlQuery<int>("SELECT distinct year(i.start_time) as years FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = @id order by years desc", new SqlParameter("id", id)).ToList();
            List<IncidentByYear> listbyyear = new List<IncidentByYear>();
            foreach (int year in years)
            {
                int count = 0;
                IncidentByYear tempyear = new IncidentByYear();
                List<IncidentByDate> listbydate = new List<IncidentByDate>();
                var dates = DBContext.Database.SqlQuery<DateTime>("SELECT distinct i.start_time as dates FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = @id and year(start_time) = @year order by dates desc", new SqlParameter("id", id), new SqlParameter("year", year)).ToList();
                foreach (DateTime date in dates)
                {
                    IncidentByDate tempdate = new IncidentByDate();
                    tempdate.date = date;
                    tempdate.incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT d.department_name, " +
                        "i.* FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d " +
                        "on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = @id and start_time = @date and year(start_time) = @year order by start_time desc"
                        , new SqlParameter("id", id)
                        , new SqlParameter("date", date)
                        , new SqlParameter("year", year)).ToList();
                    count += tempdate.incidents.Count;
                    listbydate.Add(tempdate);
                }
                tempyear.year = year;
                tempyear.IncidentByDates = listbydate;
                tempyear.count = count;
                listbyyear.Add(tempyear);
            }
            ViewBag.incidents = listbyyear;
            //DD thiet bi
            var equipment = DBContext.Database.SqlQuery<EquipWithName>("SELECT e.*,d.department_name,s.statusname FROM Equipment e,Status s,Department d WHERE d.department_id = e.department_id and e.current_Status = s.statusid and e.equipmentId = @id", new SqlParameter("id", id)).First();
            ViewBag.equipment = equipment;
            //Vat tu di kem
            var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment e join Supply_DiKem s on e.equipmentId = s.equipmentId_dikem where s.equipmentId = @id", new SqlParameter("id", equipment.equipmentId)).ToList();
            ViewBag.sup = sup;
            //Vat tu SCTX
            var supSCTX = DBContext.Database.SqlQuery<Supply_DP>("select s.*,e.supply_name from Supply e join Supply_DuPhong s on e.supply_id = s.supply_id where s.equipmentId = @id", new SqlParameter("id", equipment.equipmentId)).ToList();
            ViewBag.supSCTX = supSCTX;
            //Vat tu DP
            var supDP = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Supply_DiKem s join Equipment e on s.equipmentId_dikem = e.equipmentId where s.equipmentId = @id", new SqlParameter("id", equipment.equipmentId)).ToList();
            ViewBag.supDP = supDP;
            //NK kiem dinh
            years = DBContext.Database.SqlQuery<int>("SELECT distinct year(ei.inspect_date) as years FROM Equipment_Inspection ei inner join Equipment e on e.equipmentId = ei.equipmentId where ei.inspect_date is not null and e.equipmentId = @equipmentId order by years desc",
                new SqlParameter("equipmentId", id)).ToList();
            List<Equipment_InspectionDB> EI = DBContext.Database.SqlQuery<Equipment_InspectionDB>("SELECT * FROM Equipment_Inspection WHERE inspect_date IS NOT NULL AND equipmentId = @equipmentId",
                new SqlParameter("equipmentId", id)).ToList();
            List<Equipment_InspectionByYear> listKD = new List<Equipment_InspectionByYear>();
            for (int i = 0; i < years.Count; i++)
            {
                Equipment_InspectionByYear item = new Equipment_InspectionByYear();
                item.year = years[i];
                item.count = 0;
                item.equipment_Inspections = new List<Equipment_InspectionDB>();
                listKD.Add(item);
            }
            for (int i = 0; i < EI.Count; i++)
            {
                Equipment_InspectionDB temp = EI[i];
                DateTime dateTime;
                DateTime.TryParse(temp.inspect_date.ToString(), out dateTime);
                foreach (Equipment_InspectionByYear item in listKD)
                {
                    var stringdate = dateTime.ToString("yyyy");
                    if (stringdate.Equals(item.year + ""))
                    {
                        item.equipment_Inspections.Add(temp);
                        item.count++;
                        break;
                    }

                }
            }
            ViewBag.listKD = listKD;
            //NK bao hiem
            years = DBContext.Database.SqlQuery<int>("SELECT distinct year(ei.insurance_start_date) as years FROM Equipment_Insurance ei inner join Equipment e on e.equipmentId = ei.equipmentId where  e.equipmentId = @equipmentId order by years desc",
                new SqlParameter("equipmentId", id)).ToList();
            List<Equipment_InsDB> EIs = DBContext.Database.SqlQuery<Equipment_InsDB>("SELECT * FROM Equipment_Insurance WHERE equipmentId = @equipmentId order by insurance_start_date desc",
                new SqlParameter("equipmentId", id)).ToList();
            List<Equipment_InsByYear> listBH = new List<Equipment_InsByYear>();
            for (int i = 0; i < years.Count; i++)
            {
                Equipment_InsByYear item = new Equipment_InsByYear();
                item.year = years[i];
                item.count = 0;
                item.equipment_Ins = new List<Equipment_InsDB>();
                listBH.Add(item);
            }
            for (int i = 0; i < EIs.Count; i++)
            {
                Equipment_InsDB temp = EIs[i];
                DateTime dateTime;
                DateTime.TryParse(temp.insurance_end_date.ToString(), out dateTime);
                foreach (Equipment_InsByYear item in listBH)
                {
                    var stringdate = dateTime.ToString("yyyy");
                    if (stringdate.Equals(item.year + ""))
                    {
                        item.equipment_Ins.Add(temp);
                        item.count++;
                        break;
                    }

                }
            }
            listBH.OrderBy(x => x.equipment_Ins.OrderByDescending(y => y.insurance_end_date));
            ViewBag.listBH = listBH;
            //NK dieu dong
            var yearDD = DBContext.Database.SqlQuery<int>("SELECT distinct year(d.date_created) as years FROM Documentary d, Documentary_moveline_details dm, Equipment e where e.equipmentId = @id and e.equipmentId = dm.equipmentId and dm.documentary_id = d.documentary_id order by years desc", new SqlParameter("id", id)).ToList<int>();
            List<moveLineByYear> listDD = new List<moveLineByYear>();
            foreach (int year in yearDD)
            {
                List<myMoveline> listMML = DBContext.Database.SqlQuery<myMoveline>("select dm.equipmentId, dm.date_to,dm.department_detail,d.department_id_to,d.person_created,dm.documentary_id,d.reason,d.date_created from Equipment e, Documentary_moveline_details dm, Documentary d where e.equipmentId = dm.equipmentId and d.documentary_id = dm.documentary_id and dm.equipmentId = @id and YEAR(d.date_created) = @year ", new SqlParameter("id", id), new SqlParameter("year", year)).ToList();
                moveLineByYear MLY = new moveLineByYear();
                foreach (var x in listMML)
                {
                    string s = toStringDate(x.date_created);
                    x.date = s;
                }
                MLY.listmoveline = listMML;
                MLY.year = year;
                MLY.count = listMML.Count();
                listDD.Add(MLY);
            }
            ViewBag.listDD = listDD;
            //NK sua chua
            var yearSC = DBContext.Database.SqlQuery<int>("select distinct YEAR(d.date_created) as years from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = @id and dr.isVisible = 1 order by years desc", new SqlParameter("id", id)).ToList<int>();
            List<repairByYear> listSC = new List<repairByYear>();
            foreach (int year in yearSC)
            {
                repairByYear rby = new repairByYear();
                List<myRepair> listrp = new List<myRepair>();
                var docID = DBContext.Database.SqlQuery<int>("select distinct d.documentary_id from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = @id and dr.isVisible = 1  and YEAR(d.date_created) = @year", new SqlParameter("id", id), new SqlParameter("year", year)).ToList<int>();
                foreach (int doc in docID)
                {
                    myRepair rp = DBContext.Database.SqlQuery<myRepair>("select dr.*,d.date_created,dr.documentary_id from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = @id and dr.isVisible = 1  and dr.documentary_id = @doc", new SqlParameter("id", id), new SqlParameter("year", year), new SqlParameter("doc", doc)).FirstOrDefault();
                    List<mySup_Doc> listTT = DBContext.Database.SqlQuery<mySup_Doc>("select sd.*,s.unit,s.supply_name from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = @id  and dr.isVisible = 1 and dr.documentary_id = @doc and YEAR(d.date_created) = @year", new SqlParameter("id", id), new SqlParameter("year", year), new SqlParameter("doc", doc)).ToList();
                    rp.rowCount = listTT.Count();
                    List<mySupply> listsp = new List<mySupply>();
                    for (int i = 0; i < rp.rowCount; i++)
                    {
                        mySupply mp = new mySupply();
                        try
                        {
                            mp.VTTT = listTT.ElementAt(i);
                        }
                        catch (Exception e)
                        {
                            mp.VTTT = new mySup_Doc();
                        }
                        if (i == 0)
                        {
                            mp.flag = 0;
                        }
                        else
                        {
                            mp.flag = 1;
                        }
                        listsp.Add(mp);
                    }
                    if (rp.equipment_repair_status == 0)
                    {
                        rp.afterStatus = "Tốt";
                    }
                    else
                    {
                        rp.afterStatus = "Chưa được";
                    }
                    rp.listSup = listsp;
                    listrp.Add(rp);
                }
                rby.year = year;
                rby.list = listrp;
                rby.count = listrp.Count();
                listSC.Add(rby);
            }
            ViewBag.listSC = listSC;
            return View("/Views/CDVT/Thietbi/Lylich.cshtml");
        }

        //NK sua chua thuong xuyen
        [Route("phong-cdvt/thiet-bi/listDailyRepair")]
        [HttpPost]
        public ActionResult listDailyRepair(string id)
        {
            using (QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities())
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                var temp = (from e in DBContext.Equipments
                            where e.equipmentId.Equals(id)
                            join s in DBContext.Equipment_SCTX on e.equipmentId equals s.equipmentId
                            join d in DBContext.Departments on s.department_id equals d.department_id
                            select new
                            {
                                s.date,
                                s.equipmentId,
                                e.equipment_name,
                                d.department_name,
                                s.maintain_content
                            }).ToList().Select(x => new
                            {
                                actdate = x.date.ToString("dd/MM/yyyy"),
                                x.equipmentId,
                                x.equipment_name,
                                x.department_name,
                                x.maintain_content

                            }).ToList();
                return Json(temp);
            }
        }

        //NK tieu thu
        [Route("phong-cdvt/thiet-bi/listFuel")]
        [HttpPost]
        public ActionResult listFuel(string id)
        {
            using (QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities())
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                List<myFuel> listFuel = DBContext.Database.SqlQuery<myFuel>("select f.*, d.department_name from Fuel_activities_consumption f, Equipment e, Department d where e.equipmentId = f.equipmentId and e.department_id =  d.department_id and e.equipmentId = @id order by f.date desc", new SqlParameter("id", id)).ToList();
                //var temp = from e in DBContext.Equipments join f in DBContext.Fuel_activities_consumption on e.equipmentId equals f.equipmentId
                //           join d in DBContext.Departments on f.
                foreach (var item in listFuel)
                {
                    item.actdate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(listFuel);
            }
        }

        private class myFuel : Fuel_activities_consumption
        {
            public string department_name { get; set; }
            public string actdate { get; set; }
        }

        //NK hoat dong
        [Route("phong-cdvt/thiet-bi/listActivities")]
        [HttpPost]
        public ActionResult listActivities(string id)
        {
            using (QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities())
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                List<myAct> listHD = DBContext.Database.SqlQuery<myAct>("select a.*,d.department_name from Activity a, Equipment e, Department d where a.equipmentid = e.equipmentId and e.department_id = d.department_id and a.equipmentid = @id", new SqlParameter("id", id)).ToList();
                foreach (var item in listHD)
                {
                    item.actdate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(listHD);
            }
        }

        private class myAct : Activity
        {
            public string department_name { get; set; }
            public string actdate { get; set; }
        }
        [Auther(RightID = "10,6")]
        [HttpPost]
        public ActionResult deleteDK(string id, string supid)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "delete from Supply_DiKem where equipmentId_dikem = @supid and equipmentId = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment e join Supply_DiKem s on e.equipmentId = s.equipmentId_dikem where s.equipmentId = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = sup }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        [HttpPost]
        public ActionResult updateDK(string id, string supid, int quan, string dvt, string note)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Supply_DiKem set quantity = @quan, note = @note where equipmentId_dikem = @supid and equipmentId = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("note", note), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment e join Supply_DiKem s on e.equipmentId = s.equipmentId_dikem where s.equipmentId = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = sup }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        [HttpPost]
        public ActionResult updateDP(string id, string supid, int quan, string dvt, string note)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Supply_DiKem set quantity_duphong = @quan, note = @note where equipmentId_dikem = @supid and equipmentId = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("note", note), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment e join Supply_DiKem s on e.equipmentId = s.equipmentId_dikem where s.equipmentId = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = sup }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [Auther(RightID = "10,6")]
        [HttpPost]
        public ActionResult addDK(string id, string nameSup, int quan, string dvt, string note)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (nameSup != null && quan != 0)
                    {


                        Equipment s = DBContext.Equipments.Where(x => x.equipment_name == nameSup).FirstOrDefault();

                        string sql_sup = "insert into Supply_DiKem values (@eid, @supid, @quan, @note, 0)";
                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@supid", s.equipmentId)
                            , new SqlParameter("@eid", id)
                            , new SqlParameter("@quan", quan)
                            , new SqlParameter("@note", note));



                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment e join Supply_DiKem s on e.equipmentId = s.equipmentId_dikem where s.equipmentId = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = sup }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        [HttpPost]
        public ActionResult addSCTX(string id, string nameSup, int quan)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (nameSup != null)
                    {
                        List<Supply> listSup = DBContext.Supplies.ToList();


                        Supply s = new Supply();
                        for (int j = 0; j < listSup.Count(); j++)
                        {
                            if (listSup.ElementAt(j).supply_name.Equals(nameSup))
                            {
                                s.supply_id = listSup.ElementAt(j).supply_id;
                                break;
                            }
                        }
                        string sql_sup = "insert into Supply_DuPhong values (@supid, @eid, @quan)";
                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@supid", s.supply_id)
                            , new SqlParameter("@eid", id)
                            , new SqlParameter("@quan", quan));
                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DP>("select e.*,s.supply_name from Supply_DuPhong e join Supply s on e.supply_id = s.supply_id where e.equipmentId = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = sup }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        [HttpPost]
        public ActionResult updateSCTX(string id, string supid, int quan)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Supply_DuPhong set quantity = @quan where supply_id = @supid and equipmentId = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DP>("select e.*,s.supply_name from Supply_DuPhong e join Supply s on e.supply_id = s.supply_id where e.equipmentId = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = sup }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        [HttpPost]
        public ActionResult deleteSCTX(string id, string supid)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "delete from Supply_DuPhong where supply_id = @supid and equipmentId = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DP>("select e.*,s.supply_name from Supply_DuPhong e join Supply s on e.supply_id = s.supply_id where e.equipmentId = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = sup }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        private string toStringDate(DateTime date)
        {
            string data = date.ToString("dddd-dd-MM");
            string[] words = data.Split('-');
            string result = "";
            switch (words[0])
            {
                case "Monday": result += "Thứ 2"; break;
                case "Tuesday": result += "Thứ 3"; break;
                case "Wednesday": result += "Thứ 4"; break;
                case "Thursday": result += "Thứ 5"; break;
                case "Friday": result += "Thứ 6"; break;
                case "Saturday": result += "Thứ 7"; break;
                case "Sunday": result += "Chủ nhật"; break;
            }
            result += ", ngày " + words[1] + ", tháng " + words[2];
            return result;
        }


    }

    public class mySup_Doc : Supply_Documentary_Equipment
    {
        public string supply_name { get; set; }
        public string unit { get; set; }
    }

    public class mySupply
    {
        public int flag { get; set; }
        public mySup_Doc VTTT { get; set; }
        public mySup_Doc VTTH { get; set; }
    }

    public class repairByYear
    {
        public List<myRepair> list { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }

    public class myRepair : Documentary_repair_details
    {
        public string afterStatus { get; set; }
        public int rowCount { get; set; }
        public System.DateTime date_created { get; set; }
        public List<mySupply> listSup { get; set; }
    }


    public class moveLineByYear
    {
        public List<myMoveline> listmoveline { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }
    public class myMoveline : Documentary_moveline_details
    {
        public string person_created { get; set; }
        public System.DateTime date_created { get; set; }
        public string reason { get; set; }
        public string department_id { get; set; }
        public string date { get; set; }
    }



    public class IncidentByDate
    {
        public List<IncidentDB> incidents { get; set; }
        public DateTime date { get; set; }
    }

    public class IncidentByYear
    {
        public int year { get; set; }
        public List<IncidentByDate> IncidentByDates { get; set; }
        public int count { get; set; }
    }

    public class IncidentDB
    {
        public string equipment_name { get; set; }
        public string equipmentId { get; set; }
        public string department_name { get; set; }
        public DateTime start_time { get; set; }
        public Nullable<DateTime> end_time { get; set; }
        public string reason { get; set; }
        public string incident_type { get; set; }
        public int incident_id { get; set; }
    }

    public class Equipment_InspectionByYear
    {
        public int year { get; set; }
        public List<Equipment_InspectionDB> equipment_Inspections { get; set; }
        public int count { get; set; }
    }
    public class Equipment_InsByYear
    {
        public int year { get; set; }
        public List<Equipment_InsDB> equipment_Ins { get; set; }
        public int count { get; set; }
    }

    public class Equipment_InsDB : Equipment_Insurance
    {
        public string equipment_name { get; set; }
        public string statusname { get; set; }
        public string stringExpectedTime { get; set; }
        public string stringStartTime { get; set; }
        public string stringEndTime { get; set; }
        public string updateAble { get; set; }

        public string getStringtime(Nullable<DateTime> dateTime)
        {
            if (dateTime == null) return "";
            else
            {
                DateTime temp;
                DateTime.TryParse(dateTime.ToString(), out temp);
                return temp.ToString("dd/MM/yyyy");
            }
        }

        public string getDateString(Nullable<DateTime> dateTime)
        {
            if (dateTime == null) return "";
            else
            {
                DateTime temp;
                DateTime.TryParse(dateTime.ToString(), out temp);
                return "Thứ " + ((int)temp.DayOfWeek + 1) + ", ngày " + temp.Day + " tháng " + temp.Month;
            }
        }
    }
}