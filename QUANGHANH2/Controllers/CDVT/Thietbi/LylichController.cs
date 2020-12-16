﻿using Newtonsoft.Json.Linq;
using QUANGHANH2.EntityResult;
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
        public class ddplus
        {
            public string ten { get; set; }
            public string value { get; set; }
        }

        [HttpPost]
        public ActionResult deleteLS(string id, string iddoc)
        {
            ViewBag.listID = null;
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            string sql = "Equipment.Profile_Delete_History {0}, {1}";
            db.Database.ExecuteSqlCommand(sql, iddoc, id);

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
            List<ProfileGetListDK_Result> listsupdk = DBContext.Database.SqlQuery<ProfileGetListDK_Result>("Equipment.Get_List_Name_Accompanied_Equip").ToList();
            ViewBag.listsupdk = listsupdk;
            //list vat tu di kem cua thiet bi
            List<ProfileGetListTBDKoTB_Result> listsupdktb = DBContext.Database.SqlQuery<ProfileGetListTBDKoTB_Result>("Equipment.Profile_Get_List 'TBDKoTB', {0}", id).ToList();
            ViewBag.listtbdk = listsupdktb;
            List<ProfileGetListTBDK_Result> listdkvt = DBContext.Database.SqlQuery<ProfileGetListTBDK_Result>("Equipment.Profile_Get_List 'TBDK', {0}", id).ToList();
            ViewBag.dikemvattu = listdkvt;
            //NK su co
            var years = DBContext.Database.SqlQuery<int>("Equipment.Profile_Get_List 'yearSC', {0}", id).ToList();
            List<IncidentByYear> listbyyear = new List<IncidentByYear>();
            foreach (int year in years)
            {
                int count = 0;
                IncidentByYear tempyear = new IncidentByYear();
                List<IncidentByDate> listbydate = new List<IncidentByDate>();
                var dates = DBContext.Database.SqlQuery<DateTime>("Equipment.Profile_Get_List_Date_SC {0}, {1}", id, year).ToList();
                foreach (DateTime date in dates)
                {
                    IncidentByDate tempdate = new IncidentByDate();
                    tempdate.date = date;
                    tempdate.incidents = DBContext.Database.SqlQuery<IncidentDB>("Equipment.Profile_Get_List_Incident_By_Date {0}, {1}, {2}", id, date, year).ToList();
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
            var equipment = DBContext.Database.SqlQuery<GetExportList_Result>("Equipment.Profile_Get_List 'DD', {0}", id).FirstOrDefault();
            ViewBag.equipment = equipment;
            List<ddplus> listddplus = new List<ddplus>();
            var car = DBContext.Database.SqlQuery<Car>("Equipment.Profile_Get_List 'car', {0}", id).FirstOrDefault();
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
            string mysql = @"Equipment.Profile_Get_List 'DT', {0}";
            var dactinh = DBContext.Database.SqlQuery<ProfileGetListDT_Result>(mysql, id).ToList();
            ViewBag.dactinh = dactinh;
            mysql = @"Equipment.Profile_Get_List 'TT', {0}";
            var thuoctinh = DBContext.Database.SqlQuery<QUANGHANH2.Models.Attribute>(mysql, id).ToList();
            ViewBag.thuoctinh = thuoctinh;
            //thiet bi di kem
            var sup = DBContext.Database.SqlQuery<ProfileGetListDK_Result>("Equipment.Profile_Get_List 'DK', {0}", equipment.equipment_id).ToList();
            ViewBag.sup = sup;
            //vat tu di kem
            var supVTDK = DBContext.Database.SqlQuery<ProfileGetListVTDK_Result>("Equipment.Profile_Get_List 'VTDK', {0}", equipment.equipment_id).ToList();
            ViewBag.supVTDK = supVTDK;
            //Vat tu SCTX
            var supSCTX = DBContext.Database.SqlQuery<ProfileGetListSCTX_Result>("Equipment.Profile_Get_List 'supSCTX', {0}", equipment.equipment_id).ToList();
            ViewBag.supSCTX = supSCTX;
            //Vat tu DP
            //var supDP = DBContext.Database.SqlQuery<Supply_DK>("select s.*,e.equipment_name from Equipment.AccompaniedEquipment s join Equipment.Equipment e on s.accompanied_equipment_id = e.equipment_id where s.equipment_id = @id", new SqlParameter("id", equipment.equipment_id)).ToList();
            //ViewBag.supDP = supDP;
            //NK kiem dinh
            years = DBContext.Database.SqlQuery<int>("Equipment.Profile_Get_List 'yearKD', {0}", id).ToList();
            List<Inspection> EI = DBContext.Database.SqlQuery<Inspection>("Equipment.Profile_Get_List 'EI', {0}", id).ToList();
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
            years = DBContext.Database.SqlQuery<int>("Equipment.Profile_Get_List 'yearBH', {0}", id).ToList();
            List<Equipment_InsDB> EIs = DBContext.Database.SqlQuery<Equipment_InsDB>("Equipment.Profile_Get_List 'EIs', {0}", id).ToList();
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
            var yearDD = DBContext.Database.SqlQuery<int>("Equipment.Profile_Get_List 'yearDD', {0}", id).ToList<int>();
            List<moveLineByYear> listDD = new List<moveLineByYear>();
            foreach (int year in yearDD)
            {
                List<myMoveline> listMML = DBContext.Database.SqlQuery<myMoveline>("Equipment.Profile_Get_List_Moveline_By_Year {0}, {1}", id, year).ToList();
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
            var yearSC = DBContext.Database.SqlQuery<int>(@"Equipment.Profile_Get_List 'yearRepair', {0}", id).ToList<int>();
            List<repairByYear> listSC = new List<repairByYear>();
            foreach (int year in yearSC)
            {
                repairByYear rby = new repairByYear();
                List<myRepair> listrp = new List<myRepair>();
                var docID = DBContext.Database.SqlQuery<int>(@"Equipment.Profile_Get_DocID_Repair {0}, {1}", id, year).ToList<int>();
                foreach (int doc in docID)
                {
                    myRepair rp = DBContext.Database.SqlQuery<myRepair>(@"Equipment.Profile_Get_Repair {0}, {1}, {2}", id, year, doc).FirstOrDefault();
                    List<mySup_Doc> listTT = DBContext.Database.SqlQuery<mySup_Doc>(@"Equipment.Profile_Get_ListTT {0}, {1}, {2}", id, year, doc).ToList();
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
                List<ProfileGetListListFuel_Result> listFuel = DBContext.Database.SqlQuery<ProfileGetListListFuel_Result>("Equipment.Profile_Get_List 'listFuel', {0}", id).ToList();
                //var temp = from e in DBContext.Equipments join f in DBContext.Fuel_activities_consumption on e.equipment_id equals f.equipment_id
                //           join d in DBContext.Departments on f.
                foreach (var item in listFuel)
                {
                    item.actdate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(listFuel);
            }
        }

        //NK hoat dong
        [Route("phong-cdvt/thiet-bi/listActivities")]
        [HttpPost]
        public ActionResult listActivities(string id)
        {
            using (QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities())
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                List<ProfileGetListListHD_Result> listHD = DBContext.Database.SqlQuery<ProfileGetListListHD_Result>("Equipment.Profile_Get_List 'listHD', {0}", id).ToList();
                foreach (var item in listHD)
                {
                    item.actdate = item.date.ToString("dd/MM/yyyy");
                }
                return Json(listHD);
            }
        }
        

        [HttpPost]
        public ActionResult updateDP(string id, string supid, int quan)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "Equipment.Profile_Update_DP {0}, {1}, {2}";
                    DBContext.Database.ExecuteSqlCommand(sql, quan, supid, id);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListDK_Result>("Equipment.Profile_Get_List 'DP', {0}", id).ToList();
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



                        string sql_sup = "Equipment.Profile_Add_TT {0}, {1}, {2}, {3}, {4}";
                        DBContext.Database.ExecuteSqlCommand(sql_sup, idTT, nameTT, quan, dvt, eid);



                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<QUANGHANH2.Models.Attribute>("Equipment.Profile_Get_List 'TT', {0}", eid).ToList();
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

                        string sql_sup = "Equipment.Profile_Add_Update_DK 'add', {0}, {1}, {2}";
                        DBContext.Database.ExecuteSqlCommand(sql_sup, s.equipment_id, id, quan);



                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListDK_Result>("Equipment.Profile_Get_List 'DK', {0}", id).ToList();
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
        public ActionResult updateDK(string id, string supid, int quan)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "Equipment.Profile_Add_Update_DK 'update', {0}, {1}, {2}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id, quan);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListDK_Result>("Equipment.Profile_Get_List 'DK', {0}", id).ToList();
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
        public ActionResult deleteDK(string id, string supid)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbc = DBContext.Database.BeginTransaction())
            {
                try
                {
                    string sql = "Equipment.Profile_Delete 'DK', {0}, {1}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListDK_Result>("Equipment.Profile_Get_List 'DK', {0}", id).ToList();
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
                                    sql_sup += "Equipment.Profile_Add_Update_TBDK 'add', '" + s.supply_id + "', @eid, " + quan[i];
                                    break;
                                }
                            }
                        }


                        DBContext.Database.ExecuteSqlCommand(sql_sup
                            , new SqlParameter("@eid", id));
                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListTBDK_Result>("Equipment.Profile_Get_List 'TBDK', {0}", id_e).ToList();
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
                    string sql = "Equipment.Profile_Add_Update_TBDK 'update', {0}, {1}, {2}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id, quan);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListTBDK_Result>("Equipment.Profile_Get_List 'TBDK', {0}", id_e).ToList();
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
                    string sql = "Equipment.Profile_Delete 'TBDK', {0}, {1}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListTBDK_Result>("Equipment.Profile_Get_List 'TBDK', {0}", id_e).ToList();
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
                        string sql_sup = "Equipment.Profile_Add_Update_VTDK 'add', {0}, {1}, {2}";
                        DBContext.Database.ExecuteSqlCommand(sql_sup, s.supply_id, id, quan);
                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var supVTDK = DBContext.Database.SqlQuery<ProfileGetListVTDK_Result>("Equipment.Profile_Get_List 'VTDK', {0}", id).ToList();
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
                    string sql = "Equipment.Profile_Add_Update_VTDK 'update', {0}, {1}, {2}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id, quan);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var supVTDK = DBContext.Database.SqlQuery<ProfileGetListVTDK_Result>("Equipment.Profile_Get_List 'VTDK', {0}", id).ToList();
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
                    string sql = "Equipment.Profile_Delete 'VTDK', {0}, {1}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var supVTDK = DBContext.Database.SqlQuery<ProfileGetListVTDK_Result>("Equipment.Profile_Get_List 'VTDK', {0}", id).ToList();
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
                        string sql_sup = "Equipment.Profile_Add_Update_SCTX 'add', {0}, {1}, {2}";
                        DBContext.Database.ExecuteSqlCommand(sql_sup, s.supply_id, id, quan);
                    }
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListSCTX_Result>("Equipment.Profile_Get_List 'SCTX', {0}",id).ToList();
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
                    string sql = "Equipment.Profile_Add_Update_SCTX 'update', {0}, {1}, {2}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id, quan);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListSCTX_Result>("Equipment.Profile_Get_List 'SCTX', {0}", id).ToList();
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
                    string sql = "Equipment.Profile_Delete 'SCTX', {0}, {1}";
                    DBContext.Database.ExecuteSqlCommand(sql, supid, id);
                    DBContext.SaveChanges();
                    dbc.Commit();
                    var sup = DBContext.Database.SqlQuery<ProfileGetListSCTX_Result>("Equipment.Profile_Get_List 'SCTX', {0}", id).ToList();
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