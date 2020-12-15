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
        public class VT_DK : AccompaniedSupply
        {
            public string supply_name { get; set; }
        }
        public class ddplus
        {
            public string ten { get; set; }
            public string value { get; set; }
        }
        public class dactinh : CategoryAttribute
        {
            public int Value { get; set; }
        }
        public class EquipWithName : Equipment
        {
            public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
            public string status_name { get; set; }
            public string Equipment_category_name { get; set; }
            public string department_name { get; set; }
        }
        public class Dikem_Vattu : Equipment
        {
            public string supply_id { get; set; }
            public string supply_name { get; set; }
            public int quantity { get; set; }
            public string accompanied_equipment_id { get; set; }
        }
        public class Supply_DK : AccompaniedEquipment
        {
            public string equipment_name { get; set; }

        }

        public class Supply_DP : RepairRegularly1
        {
            public string supply_name { get; set; }
        }

        public class vtdk : Equipment
        {
            public string accompanied_equipment_id { get; set; }
        }

        [HttpPost]
        public ActionResult deleteLS(string id, string iddoc)
        {
            ViewBag.listID = null;
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            string sql = "update Documentary.RepairDetails set is_visible = 0 where documentary_id = @iddoc and equipment_id = @id";
            db.Database.ExecuteSqlCommand(sql, new SqlParameter("id", id), new SqlParameter("iddoc", iddoc));

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
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
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            //lít vat tu
            List<Supply> listSup = DBContext.Supplies.ToList<Supply>();
            ViewBag.listSup = listSup;
            //list vat tu di kem
            List<Supply_DK> listsupdk = DBContext.Database.SqlQuery<Supply_DK>("select equipment_name from Equipment.Equipment where is_attach = 1").ToList();
            ViewBag.listsupdk = listsupdk;
            //list vat tu di kem cua thiet bi
            List<vtdk> listsupdktb = DBContext.Database.SqlQuery<vtdk>("select s.accompanied_equipment_id, e.equipment_name from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
            ViewBag.listtbdk = listsupdktb;
            List<Dikem_Vattu> listdkvt = DBContext.Database.SqlQuery<Dikem_Vattu>("select s.accompanied_equipment_id, e.equipment_name, su.supply_id, su.supply_name, ss.quantity from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id join Equipment.AccompaniedSupply ss on s.accompanied_equipment_id = ss.equipment_id join Supply.Supply su on ss.supply_id = su.supply_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
            ViewBag.dikemvattu = listdkvt;
            //NK su co
            var years = DBContext.Database.SqlQuery<int>("SELECT distinct year(i.start_time) as years FROM Equipment.Incident i inner join Equipment.Equipment e on e.equipment_id = i.equipment_id inner join General.Department d on d.department_id = i.department_id where i.end_time is not null and e.equipment_id = @id order by years desc", new SqlParameter("id", id)).ToList();
            List<IncidentByYear> listbyyear = new List<IncidentByYear>();
            foreach (int year in years)
            {
                int count = 0;
                IncidentByYear tempyear = new IncidentByYear();
                List<IncidentByDate> listbydate = new List<IncidentByDate>();
                var dates = DBContext.Database.SqlQuery<DateTime>("SELECT distinct i.start_time as dates FROM Equipment.Incident i inner join Equipment.Equipment e on e.equipment_id = i.equipment_id inner join General.Department d on d.department_id = i.department_id where i.end_time is not null and e.equipment_id = @id and year(start_time) = @year order by dates desc", new SqlParameter("id", id), new SqlParameter("year", year)).ToList();
                foreach (DateTime date in dates)
                {
                    IncidentByDate tempdate = new IncidentByDate();
                    tempdate.date = date;
                    tempdate.incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT d.department_name, " +
                        "i.* FROM Equipment.Incident i inner join Equipment.Equipment e on e.equipment_id = i.equipment_id inner join General.Department d " +
                        "on d.department_id = i.department_id where i.end_time is not null and e.equipment_id = @id and start_time = @date and year(start_time) = @year order by start_time desc"
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
            var equipment = DBContext.Database.SqlQuery<EquipWithName>("SELECT e.*,d.department_name,s.status_name FROM Equipment.Equipment e LEFT JOIN Equipment.Status s on e.current_Status = s.status_id LEFT JOIN General.Department d ON d.department_id = e.department_id WHERE e.equipment_id = @id", new SqlParameter("id", id)).FirstOrDefault();
            ViewBag.equipment = equipment;
            List<ddplus> listddplus = new List<ddplus>();
            var car = DBContext.Database.SqlQuery<Car>("select * from Equipment.Car where equipment_id = @id", new SqlParameter("id", id)).FirstOrDefault();
            if (car != null)
            {
                ddplus dd = new ddplus();
                dd.ten = "Số khung"; dd.value = car.chassis_number; listddplus.Add(dd); dd = new ddplus();
                dd.ten = "Số máy"; dd.value = car.engine_number; listddplus.Add(dd); dd = new ddplus();
                dd.ten = "Năm sản xuất"; dd.value = car.manufacture_year.ToString(); listddplus.Add(dd); dd = new ddplus();
                dd.ten = "GPS";
                if (car.GPS == true) dd.value = "Có tín hiệu";
                else dd.value = "Mất tín hiệu";
                listddplus.Add(dd); dd = new ddplus();
                dd.ten = "Nhiên liệu";
                if (car.fuel == true) dd.value = "Có nhiên liệu";
                else dd.value = "Hết nhiên liệu";
                listddplus.Add(dd);
            }
            ViewBag.plus = listddplus;
            string mysql = @"select ec.Equipment_category_attribute_id, ec.Equipment_category_attribute_name, c.Value, ec.unit
                        from Equipment.CategoryAttribute ec join Equipment.CategoryAttributeValue c on ec.Equipment_category_attribute_id = c.Equipment_category_attribute_id
                        where c.equipment_id = @id";
            var dactinh = DBContext.Database.SqlQuery<dactinh>(mysql, new SqlParameter("id", id)).ToList();
            ViewBag.dactinh = dactinh;
            mysql = @"select e.*
                        from Equipment.Attribute e
                        where e.equipment_id = @id";
            var thuoctinh = DBContext.Database.SqlQuery<QUANGHANH2.Models.Attribute>(mysql, new SqlParameter("id", id)).ToList();
            ViewBag.thuoctinh = thuoctinh;
            //thiet bi di kem
            var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id where s.equipment_id = @id", new SqlParameter("id", equipment.equipment_id)).ToList();
            ViewBag.sup = sup;
            //vat tu di kem
            var supVTDK = DBContext.Database.SqlQuery<VT_DK>("select s.*,e.equipment_name,sp.supply_name from Equipment.Equipment e join Equipment.AccompaniedSupply s on e.equipment_id = s.equipment_id join Supply.Supply sp on sp.supply_id = s.supply_id where s.equipment_id = @id", new SqlParameter("id", equipment.equipment_id)).ToList();
            ViewBag.supVTDK = supVTDK;
            //Vat tu SCTX
            var supSCTX = DBContext.Database.SqlQuery<Supply_DP>("select s.*,e.supply_name from Supply.Supply e join Supply.RepairRegularly s on e.supply_id = s.supply_id where s.equipment_id = @id", new SqlParameter("id", equipment.equipment_id)).ToList();
            ViewBag.supSCTX = supSCTX;
            //Vat tu DP
            var supDP = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment.AccompaniedEquipment s join Equipment.Equipment e on s.accompanied_equipment_id = e.equipment_id where s.equipment_id = @id", new SqlParameter("id", equipment.equipment_id)).ToList();
            ViewBag.supDP = supDP;
            //NK kiem dinh
            years = DBContext.Database.SqlQuery<int>("SELECT distinct year(ei.inspect_date) as years FROM Equipment.Inspection ei inner join Equipment.Equipment e on e.equipment_id = ei.equipment_id where ei.inspect_date is not null and e.equipment_id = @equipment_id order by years desc",
                new SqlParameter("equipment_id", id)).ToList();
            List<Inspection> EI = DBContext.Database.SqlQuery<Inspection>("SELECT * FROM Equipment.Inspection WHERE inspect_date IS NOT NULL AND equipment_id = @equipment_id",
                new SqlParameter("equipment_id", id)).ToList();
            List<Equipment_InspectionByYear> listKD = new List<Equipment_InspectionByYear>();
            for (int i = 0; i < years.Count; i++)
            {
                Equipment_InspectionByYear item = new Equipment_InspectionByYear();
                item.year = years[i];
                item.count = 0;
                item.equipment_Inspections = new List<Inspection>();
                listKD.Add(item);
            }
            for (int i = 0; i < EI.Count; i++)
            {
                Inspection temp = EI[i];
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
            years = DBContext.Database.SqlQuery<int>("SELECT distinct year(ei.insurance_start_date) as years FROM Equipment.Insurance ei inner join Equipment.Equipment e on e.equipment_id = ei.equipment_id where  e.equipment_id = @equipment_id order by years desc",
                new SqlParameter("equipment_id", id)).ToList();
            List<Equipment_InsDB> EIs = DBContext.Database.SqlQuery<Equipment_InsDB>("SELECT * FROM Equipment.Insurance WHERE equipment_id = @equipment_id order by insurance_start_date desc",
                new SqlParameter("equipment_id", id)).ToList();
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
            var yearDD = DBContext.Database.SqlQuery<int>("SELECT distinct year(d.date_created) as years FROM Documentary.Documentary d, Documentary.MovelineDetails dm, Equipment.Equipment e where e.equipment_id = @id and e.equipment_id = dm.equipment_id and dm.documentary_id = d.documentary_id order by years desc", new SqlParameter("id", id)).ToList<int>();
            List<moveLineByYear> listDD = new List<moveLineByYear>();
            foreach (int year in yearDD)
            {
                List<myMoveline> listMML = DBContext.Database.SqlQuery<myMoveline>("select d.documentary_code,dm.equipment_id, dm.date_to,dm.department_detail,d.department_id_to,d.person_created,dm.documentary_id,d.reason,d.date_created from Equipment.Equipment e, Documentary.MovelineDetails dm, Documentary.Documentary d where e.equipment_id = dm.equipment_id and d.documentary_id = dm.documentary_id and dm.equipment_id = @id and YEAR(d.date_created) = @year ", new SqlParameter("id", id), new SqlParameter("year", year)).ToList();
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
            var yearSC = DBContext.Database.SqlQuery<int>(@"select distinct YEAR(d.date_created) as years 
                                                            from Documentary.Documentary d, Documentary.RepairDetails dr, Supply.Supply s, Supply.RepairEquipment sd 
                                                            where d.documentary_id = dr.documentary_id
	                                                            and dr.documentary_repair_id = sd.documentary_repair_id
	                                                            and sd.supply_id = s.supply_id
	                                                            and dr.equipment_id = @id
	                                                            and dr.is_visible = 1
                                                            order by years desc", new SqlParameter("id", id)).ToList<int>();
            List<repairByYear> listSC = new List<repairByYear>();
            foreach (int year in yearSC)
            {
                repairByYear rby = new repairByYear();
                List<myRepair> listrp = new List<myRepair>();
                var docID = DBContext.Database.SqlQuery<int>(@"select distinct d.documentary_id
                                                                from Documentary.Documentary d, Documentary.RepairDetails dr, Supply.Supply s, Supply.RepairEquipment sd 
                                                                where dr.documentary_id = d.documentary_id 
	                                                                and sd.supply_id = s.supply_id 
	                                                                and sd.documentary_repair_id = dr.documentary_repair_id 
	                                                                and dr.equipment_id = @id 
	                                                                and dr.is_visible = 1  
	                                                                and YEAR(d.date_created) = @year", new SqlParameter("id", id), new SqlParameter("year", year)).ToList<int>();
                foreach (int doc in docID)
                {
                    myRepair rp = DBContext.Database.SqlQuery<myRepair>(@"select dr.*,d.date_created,dr.documentary_id,d.documentary_code 
                                                                        from Documentary.Documentary d, Documentary.RepairDetails dr, Supply.Supply s, Supply.RepairEquipment sd 
                                                                        where dr.documentary_id = d.documentary_id 
	                                                                        and sd.supply_id = s.supply_id 
	                                                                        and sd.documentary_repair_id = dr.documentary_repair_id 
	                                                                        and dr.equipment_id = @id and dr.is_visible = 1  and dr.documentary_id = @doc", new SqlParameter("id", id), new SqlParameter("year", year), new SqlParameter("doc", doc)).FirstOrDefault();
                    List<mySup_Doc> listTT = DBContext.Database.SqlQuery<mySup_Doc>(@"select sd.*,s.unit,s.supply_name 
                                                                                    from Documentary.Documentary d, Documentary.RepairDetails dr, Supply.Supply s, Supply.RepairEquipment sd 
                                                                                    where dr.documentary_id = d.documentary_id 
	                                                                                    and sd.supply_id = s.supply_id 
	                                                                                    and sd.documentary_repair_id = dr.documentary_repair_id 
	                                                                                    and dr.equipment_id = @id  
	                                                                                    and dr.is_visible = 1 
	                                                                                    and dr.documentary_id = @doc 
	                                                                                    and YEAR(d.date_created) = @year", new SqlParameter("id", id), new SqlParameter("year", year), new SqlParameter("doc", doc)).ToList();
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
            using (QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities())
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                var temp = (from e in DBContext.Equipments
                            where e.equipment_id.Equals(id)
                            join s in DBContext.RepairRegularlies on e.equipment_id equals s.equipment_id
                            join d in DBContext.Departments on s.department_id equals d.department_id
                            select new
                            {
                                s.date,
                                s.equipment_id,
                                e.equipment_name,
                                d.department_name,
                                s.maintain_content
                            }).ToList().Select(x => new
                            {
                                actdate = x.date.ToString("dd/MM/yyyy"),
                                x.equipment_id,
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
            using (QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities())
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                List<myFuel> listFuel = DBContext.Database.SqlQuery<myFuel>("select f.*, d.department_name from Equipment.FuelActivitiesConsumption f, Equipment.Equipment e, General.Department d where e.equipment_id = f.equipment_id and e.department_id =  d.department_id and e.equipment_id = @id order by f.date desc", new SqlParameter("id", id)).ToList();
                //var temp = from e in DBContext.Equipments join f in DBContext.Fuel_activities_consumption on e.equipment_id equals f.equipment_id
                //           join d in DBContext.Departments on f.
                foreach (var item in listFuel)
                {
                    item.actdate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(listFuel);
            }
        }

        private class myFuel : FuelActivitiesConsumption
        {
            public string department_name { get; set; }
            public string actdate { get; set; }
        }

        //NK hoat dong
        [Route("phong-cdvt/thiet-bi/listActivities")]
        [HttpPost]
        public ActionResult listActivities(string id)
        {
            using (QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities())
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                List<myAct> listHD = DBContext.Database.SqlQuery<myAct>("select a.*,d.department_name from Equipment.Activity a, Equipment.Equipment e, General.Department d where a.equipment_id = e.equipment_id and e.department_id = d.department_id and a.equipment_id = @id", new SqlParameter("id", id)).ToList();
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
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "delete from Equipment.AccompaniedEquipment where accompanied_equipment_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
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
        public ActionResult updateDK(string id, string supid, int quan, string dvt)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Equipment.AccompaniedEquipment set quantity = @quan where accompanied_equipment_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
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
        public ActionResult updateDP(string id, string supid, int quan, string dvt)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Equipment.AccompaniedEquipment set quantity_reserve = @quan where accompanied_equipment_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
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
        public ActionResult addTT(string idTT, string nameTT, int quan, string dvt, string eid)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (nameTT != null && quan != 0)
                    {



                        string sql_sup = "insert into Equipment.Attribute values (@id, @name, @value, @unit, @eid)";
                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@id", idTT)
                            , new SqlParameter("@name", nameTT)
                            , new SqlParameter("@value", quan)
                            , new SqlParameter("@unit", dvt)
                            , new SqlParameter("@eid", eid));



                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<QUANGHANH2.Models.Attribute>("select * from Equipment.Attribute e where e.equipment_id = @id", new SqlParameter("id", eid)).ToList();
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
        public ActionResult addDK(string id, string nameSup, int quan, string dvt)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (nameSup != null && quan != 0)
                    {


                        Equipment s = DBContext.Equipments.Where(x => x.equipment_name == nameSup).FirstOrDefault();

                        string sql_sup = "insert into Equipment.AccompaniedEquipment values (@eid, @supid, @quan, 0)";
                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@supid", s.equipment_id)
                            , new SqlParameter("@eid", id)
                            , new SqlParameter("@quan", quan));



                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
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
        public ActionResult addTBDK(string id, string[] nameSup, int[] quan, string id_e)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (nameSup.Count() != 0)
                    {
                        List<Supply> listSup = DBContext.Supplies.ToList();


                        string sql_sup = "";
                        for (int i = 0; i < nameSup.Count(); i++)
                        {
                            Supply s = new Supply();
                            for (int j = 0; j < listSup.Count(); j++)
                            {
                                if (listSup.ElementAt(j).supply_name.Equals(nameSup[i]))
                                {
                                    s.supply_id = listSup.ElementAt(j).supply_id;
                                    sql_sup += "insert into Equipment.AccompaniedSupply values ('" + s.supply_id + "', @eid, " + quan[i] + ") ";
                                    break;
                                }
                            }
                        }


                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@eid", id));
                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Dikem_Vattu>("select s.accompanied_equipment_id, e.equipment_name, su.supply_id, su.supply_name, ss.quantity from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id join Equipment.AccompaniedSupply ss on s.accompanied_equipment_id = ss.equipment_id join Supply.Supply su on ss.supply_id = su.supply_id where s.equipment_id = @id", new SqlParameter("id", id_e)).ToList();
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
        public ActionResult updateTBDK(string id, string supid, int quan, string id_e)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Equipment.AccompaniedSupply set quantity = @quan where supply_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Dikem_Vattu>("select s.accompanied_equipment_id, e.equipment_name, su.supply_id, su.supply_name, ss.quantity from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.equipment_id join Equipment.AccompaniedSupply ss on s.accompanied_equipment_id = ss.equipment_id join Supply.Supply su on ss.supply_id = su.supply_id where e.equipment_id = @id", new SqlParameter("id", id_e)).ToList();
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
        public ActionResult deleteTBDK(string id, string supid, string id_e)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "delete from Equipment.AccompaniedSupply where supply_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Dikem_Vattu>("select s.accompanied_equipment_id, e.equipment_name, su.supply_id, su.supply_name, ss.quantity from Equipment.Equipment e join Equipment.AccompaniedEquipment s on e.equipment_id = s.accompanied_equipment_id join Equipment.AccompaniedSupply ss on s.accompanied_equipment_id = ss.equipment_id join Supply.Supply su on ss.supply_id = su.supply_id where s.equipment_id = @id", new SqlParameter("id", id_e)).ToList();
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
        public ActionResult addVTDK(string id, string nameSup, int quan)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
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
                        string sql_sup = "insert into Equipment.AccompaniedSupply values (@supid, @eid, @quan)";
                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@supid", s.supply_id)
                            , new SqlParameter("@eid", id)
                            , new SqlParameter("@quan", quan));
                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var supVTDK = DBContext.Database.SqlQuery<VT_DK>("select s.*,e.equipment_name,sp.supply_name from Equipment.Equipment e join Equipment.AccompaniedSupply s on e.equipment_id = s.equipment_id join Supply.Supply sp on sp.supply_id = s.supply_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = supVTDK }, JsonRequestBehavior.AllowGet);
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
        public ActionResult updateVTDK(string id, string supid, int quan)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Equipment.AccompaniedSupply set quantity = @quan where supply_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var supVTDK = DBContext.Database.SqlQuery<VT_DK>("select s.*,e.equipment_name,sp.supply_name from Equipment.Equipment e join Equipment.AccompaniedSupply s on e.equipment_id = s.equipment_id join Supply.Supply sp on sp.supply_id = s.supply_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = supVTDK }, JsonRequestBehavior.AllowGet);
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
        public ActionResult deleteVTDK(string id, string supid)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "delete from Equipment.AccompaniedSupply where supply_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var supVTDK = DBContext.Database.SqlQuery<VT_DK>("select s.*,e.equipment_name,sp.supply_name from Equipment.Equipment e join Equipment.AccompaniedSupply s on e.equipment_id = s.equipment_id join Supply.Supply sp on sp.supply_id = s.supply_id where s.equipment_id = @id", new SqlParameter("id", id)).ToList();
                    return Json(new { success = true, data = supVTDK }, JsonRequestBehavior.AllowGet);
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
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
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
                                s.supply_name = listSup.ElementAt(j).supply_name;
                                break;
                            }
                        }
                        string sql_sup = "insert into Supply.RepairRegularly(supply_id, equipment_id, quantity) values (@supid, @eid, @quan)";
                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@supid", s.supply_id)
                            , new SqlParameter("@eid", id)
                            , new SqlParameter("@quan", quan));
                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DP>("select e.*,s.supply_name from Supply.RepairRegularly e join Supply.Supply s on e.supply_id = s.supply_id where e.equipment_id = @id", new SqlParameter("id", id)).ToList();
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
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "update Supply.RepairRegularly set quantity = @quan where supply_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("quan", quan), new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DP>("select e.*,s.supply_name from Supply.RepairRegularly e join Supply.Supply s on e.supply_id = s.supply_id where e.equipment_id = @id", new SqlParameter("id", id)).ToList();
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
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "delete from Supply.RepairRegularly where supply_id = @supid and equipment_id = @eid";
                    DBContext.Database.ExecuteSqlCommand(sql, new SqlParameter("supid", supid), new SqlParameter("eid", id));
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<Supply_DP>("select e.*,s.supply_name from Supply.RepairRegularly e join Supply.Supply s on e.supply_id = s.supply_id where e.equipment_id = @id", new SqlParameter("id", id)).ToList();
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

    public class mySup_Doc : RepairEquipment
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

    public class myRepair : RepairDetail
    {
        public string documentary_code { get; set; }
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
    public class myMoveline : MovelineDetail
    {
        public string documentary_code { get; set; }
        public string person_created { get; set; }
        public System.DateTime date_created { get; set; }
        public string reason { get; set; }
        public string department_id_to { get; set; }
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
        public string equipment_id { get; set; }
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
        public List<Inspection> equipment_Inspections { get; set; }
        public int count { get; set; }
    }
    public class Equipment_InsByYear
    {
        public int year { get; set; }
        public List<Equipment_InsDB> equipment_Ins { get; set; }
        public int count { get; set; }
    }

    public class Equipment_InsDB : Insurance
    {
        public string equipment_name { get; set; }
        public string status_name { get; set; }
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