using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using static QUANGHANHCORE.Controllers.CDVT.Thietbi.HoatdongController;
using System.Data.SqlClient;
namespace QUANGHANHCORE.Controllers.CDVT
{
    public class Temp
    {
        public string abc { get; set; }
    }/*a*/
    public class DashController : Controller
    {
        [Auther(RightID = "001")]
        [Route("phong-cdvt")]
        public ActionResult Index(string type, string month, string year)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

            List<string> rights = (List<string>)Session["RightIDs"];
            List<DashEquip> listhd = new List<DashEquip>();
            List<DashEquip> listkhd = new List<DashEquip>();
            List<DashEquip> listcar = new List<DashEquip>();

            DateTime date = DateTime.Now.Date;
            int sess = 0;
            int hour = DateTime.Now.Hour;
            if (hour >= 6 && hour < 14) sess = 1;
            else if (hour >= 14 && hour < 22) sess = 2;
            else if (hour >= 22 || hour < 6) sess = 3;
            // GPS car unavailable
            var gpsunavailble = db.Database.SqlQuery<GPSCarAvail>(@"select c.equipmentId
                                                                    from CarGPS c
                                                                    where c.[date] = @date and c.[session] = @sess and c.available = 0",
                                                                    new SqlParameter("date", date),
                                                                    new SqlParameter("sess", sess)
                                                                    ).ToList();
            ViewBag.gpsavail = gpsunavailble.Count;

            listcar = (from equip in db.Equipments
                       join c in db.Cars on equip.equipmentId equals c.equipmentId
                       select new DashEquip
                       {
                           equipment_name = equip.equipment_name,
                           equipmentId = equip.equipmentId
                       }).ToList();
            if (rights.Contains("10"))
            {
                listhd = (from equip in db.Equipments.Where(x => x.current_Status == 2)
                          join c in db.Cars on equip.equipmentId equals c.equipmentId
                          select new DashEquip
                          {
                              equipment_name = equip.equipment_name,
                              equipmentId = equip.equipmentId
                          }).ToList();
                listkhd = (from equip in db.Equipments.Where(x => x.current_Status != 2)
                           join c in db.Cars on equip.equipmentId equals c.equipmentId
                           select new DashEquip
                           {
                               equipment_name = equip.equipment_name,
                               equipmentId = equip.equipmentId
                           }).ToList();
                string query = @"select ec.Equipment_category_id,ec.Equipment_category_name, COUNT(e.equipmentId) as 'num',ROW_NUMBER() over (order by ec.Equipment_category_name) as 'stt',
                                SUM(case when e.current_Status = 2 then 1 else 0 end) as 'sum1',
                                SUM(case when e.current_Status != 2 then 1 else 0 end) as 'sum2'
                                from Equipment e join Car c on e.equipmentId = c.equipmentId join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id
                                group by ec.Equipment_category_id,ec.Equipment_category_name";
                var tonghop = db.Database.SqlQuery<ExportByGroup>(query).ToList();
                ViewBag.hd = tonghop;
                //ViewBag.hd = listhd;
                ViewBag.khd = listkhd;
            }
            else
            {
                listhd = (from e in db.Equipments
                          where e.current_Status == 2
                          select new DashEquip
                          {
                              equipmentId = e.equipmentId,
                              equipment_name = e.equipment_name
                          }).ToList();
                listkhd = (from e in db.Equipments
                           where e.current_Status != 2
                           select new DashEquip
                           {
                               equipmentId = e.equipmentId,
                               equipment_name = e.equipment_name
                           }).ToList();
                string query = @"select ec.Equipment_category_id, ec.Equipment_category_name, COUNT(e.equipmentId) as 'num',ROW_NUMBER() over (order by ec.Equipment_category_name)  as 'stt',
                                SUM(case when e.current_Status = 2 then 1 else 0 end) as 'sum1',
                                SUM(case when e.current_Status != 2 then 1 else 0 end) as 'sum2'
                            from Equipment_category ec left join Equipment e on ec.Equipment_category_id = e.Equipment_category_id
                            group by ec.Equipment_category_id,ec.Equipment_category_name
                            except
                            select ec.Equipment_category_id,ec.Equipment_category_name, COUNT(e.equipmentId) as 'num',ROW_NUMBER() over (order by ec.Equipment_category_name),
                                SUM(case when e.current_Status = 2 then 1 else 0 end) as 'sum1',
                                SUM(case when e.current_Status != 2 then 1 else 0 end) as 'sum2'
                                from Equipment e join Car c on e.equipmentId = c.equipmentId join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id
                                group by ec.Equipment_category_id,ec.Equipment_category_name";
                var tonghop = db.Database.SqlQuery<ExportByGroup>(query).ToList();
                ViewBag.hd = tonghop;
                //ViewBag.hd = listhd.Except(listcar);
                ViewBag.khd = listkhd.Except(listcar);
            }

            EquipThongKe etk = new EquipThongKe();
            var equipList = db.Equipments.ToList<Equipment>();
            etk.total = equipList.Where(x => x.isAttach == false).Count().ToString();
            int total_repair = 0; int total_maintain = 0; int total_TL = 0; int total_TH = 0;
            var listKD = (from equip in db.Equipments.Where(equip => equip.current_Status == 10)
                          select new DashEquip
                          {
                              equipmentId = equip.equipmentId,
                              equipment_name = equip.equipment_name
                          }).ToList();
            ViewBag.listKD = listKD;
            ViewBag.totalKD = listKD.Count();

            etk.total_HD = db.Equipments.Where(x => x.current_Status == 2 && x.isAttach == false).Count();
            etk.total_KHD = int.Parse(etk.total) - etk.total_HD;

            var listRepair = db.Equipments.Where(x => x.current_Status == 3).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
            ViewBag.listRepair = listRepair;

            var listMain = db.Equipments.Where(x => x.current_Status == 5).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
            ViewBag.listMain = listMain;

            var listTL = db.Equipments.Where(x => x.current_Status == 8).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
            ViewBag.listTL = listTL;

            var listTH = db.Equipments.Where(x => x.current_Status == 7).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
            total_repair = listRepair.Count();
            total_maintain = listMain.Count();
            total_TL = listTL.Count();
            total_TH = listTH.Count();
            ViewBag.listTH = listTH;
            etk.total_repair = total_repair + "";
            etk.total_maintain = total_maintain + "";
            etk.total_TL = total_TL + "";
            etk.total_TH = total_TH + "";
            ViewBag.Thongke = etk;
            var testTime = DateTime.Now.AddDays(10);
            var hanDangKiem = db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now && x.isAttach == false).OrderBy(x => x.durationOfInspection).
                                    Select(x => new form1
                                    {
                                        equipment_name = x.equipment_name,
                                        equipmentId = x.equipmentId,
                                        ngay = x.durationOfInspection.Value.Day,
                                        thang = x.durationOfInspection.Value.Month,
                                        nam = x.durationOfInspection.Value.Year
                                    }).Take(10).ToList().Distinct();
            ViewBag.kiemdinhtag = hanDangKiem.Count();
            ViewBag.handangkiem = hanDangKiem;
            var hanBaoduong = db.Equipments.Where(x => x.durationOfMaintainance <= testTime && x.durationOfMaintainance >= DateTime.Now && x.isAttach == false).OrderBy(x => x.durationOfMaintainance).
                                    Select(x => new form1
                                    {
                                        equipment_name = x.equipment_name,
                                        equipmentId = x.equipmentId,
                                        ngay = x.durationOfMaintainance.Value.Day,
                                        thang = x.durationOfMaintainance.Value.Month,
                                        nam = x.durationOfMaintainance.Value.Year
                                    }).Take(10).ToList().Distinct();
            ViewBag.baoduongtag = hanBaoduong.Count();
            ViewBag.hanbaoduong = hanBaoduong;

            var tongcogioi = (from equip in db.Equipments
                              join car in db.Cars
                              on equip.equipmentId equals car.equipmentId
                              select new DashEquip
                              {
                                  equipment_name = equip.equipment_name,
                                  equipmentId = equip.equipmentId
                              }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
            ViewBag.tongcogioi = tongcogioi.Count();

            var cogioihd = (from equip in db.Equipments.Where(x => x.current_Status == 2)
                            join car in db.Cars
                              on equip.equipmentId equals car.equipmentId
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
            ViewBag.cogioikhd = tongcogioi.Count() - cogioihd.Count();
            ViewBag.cogioihd = cogioihd.Count();
            var cogioiSC = (from equip in db.Equipments.Where(x => x.current_Status == 3)
                            join car in db.Cars
                                on equip.equipmentId equals car.equipmentId
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
            ViewBag.cogioiSC = cogioiSC;
            ViewBag.slSC = cogioiSC.Count();

            var cogioiBD = (from equip in db.Equipments.Where(x => x.current_Status == 5)
                            join car in db.Cars
                              on equip.equipmentId equals car.equipmentId
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
            ViewBag.cogioiBD = cogioiBD;
            ViewBag.slBD = cogioiBD.Count();

            var cogioiKD = (from equip in db.Equipments.Where(x => x.current_Status == 10)
                            join car in db.Cars
                              on equip.equipmentId equals car.equipmentId
                            join Equipment_category in db.Equipment_category
                            on equip.Equipment_category_id equals Equipment_category.Equipment_category_id
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
            ViewBag.cogioiKD = cogioiKD;
            ViewBag.slKD = cogioiKD.Count();

            var cogioiTL = (from equip in db.Equipments.Where(x => x.current_Status == 8)
                            join car in db.Cars
                              on equip.equipmentId equals car.equipmentId
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
            ViewBag.cogioiTL = cogioiTL;
            ViewBag.slTL = cogioiTL.Count();

            var cogioiTH = (from equip in db.Equipments.Where(x => x.current_Status == 7)
                            join car in db.Cars
                              on equip.equipmentId equals car.equipmentId
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
            ViewBag.cogioiTH = cogioiTH;
            ViewBag.slTH = cogioiTH.Count();

            var hanDangKiemcogioi = (from equip in db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now)
                                     join car in db.Cars
                                        on equip.equipmentId equals car.equipmentId
                                     select new SL
                                     {
                                         equipment_name = equip.equipment_name,
                                         equipmentId = equip.equipmentId,
                                         day = equip.durationOfInspection.Value,
                                         ngay = equip.durationOfInspection.Value.Day,
                                         thang = equip.durationOfInspection.Value.Month,
                                         nam = equip.durationOfInspection.Value.Year
                                     }).Take(10).GroupBy(x => x.equipment_name + x.equipmentId + x.ngay + x.thang + x.nam).Select(x => x.FirstOrDefault()).OrderBy(x => x.day);
            ViewBag.kiemdinhcogioitag = hanDangKiemcogioi.Count();
            ViewBag.hanDangKiemcogioi = hanDangKiemcogioi;

            var hanBaoduongcogioi = (from equip in db.Equipments.Where(x => x.durationOfMaintainance <= testTime && x.durationOfMaintainance >= DateTime.Now).OrderBy(x => x.durationOfMaintainance)
                                     join car in db.Cars
                                        on equip.equipmentId equals car.equipmentId
                                     select new form1
                                     {
                                         equipment_name = equip.equipment_name,
                                         equipmentId = equip.equipmentId,
                                         ngay = equip.durationOfMaintainance.Value.Day,
                                         thang = equip.durationOfMaintainance.Value.Month,
                                         nam = equip.durationOfMaintainance.Value.Year
                                     }).Take(10).GroupBy(x => x.equipment_name + x.equipmentId + x.ngay + x.thang + x.nam).Select(x => x.FirstOrDefault());
            ViewBag.baoduongcogioitag = hanBaoduongcogioi.Count();
            ViewBag.hanBaoduongcogioi = hanBaoduongcogioi;


            Wherecondition(type, month, year);

            if (rights.Contains("193"))
            {
                DateTime d = DateTime.Today;
                ViewBag.today = month == null ? d.ToString("MM yyyy") : (month + " " + year);
                string query = @"select COUNT(ci.incident_id) as 'sum', 
                    case when SUM(case when ci.end_time is not null  then 1 else  0 end) is null then 0 else SUM(case when ci.end_time is not null  then 1 else  0 end) end as 'done', 
                    case when SUM(case when ci.reason like N'%sét%' or ci.reason like '%set%' then 1 else 0 end) is null then 0 else SUM(case when ci.reason like N'%sét%' or ci.reason like '%set%' then 1 else 0 end) end as 'lightning'
                    from CameraIncident ci
                    where MONTH(ci.start_time) = @month and YEAR(ci.start_time) = @year";
                DashCam dc = db.Database.SqlQuery<DashCam>(query, new SqlParameter("month", month == null ? d.Month.ToString() : month), new SqlParameter("year", year == null ? d.Year.ToString() : year)).FirstOrDefault();
                dc.notdone = dc.sum - dc.done;
                ViewBag.dc = dc;

                string query2 = @"select case when SUM(case when r.camera_available = r.camera_quantity then 1 else 0 end) is null then 0 else SUM(case when r.camera_available = r.camera_quantity then 1 else 0 end) end as 'daydu',
                    case when SUM(case when r.camera_available < r.camera_quantity and r.camera_available > 0 then 1 else 0 end) is null then 0 else SUM(case when r.camera_available < r.camera_quantity and r.camera_available > 0 then 1 else 0 end) end as 'kodaydu',
                    case when SUM(case when r.camera_available = 0 then 1 else 0 end) is null then 0 else SUM(case when r.camera_available = 0 then 1 else 0 end) end as 'ko'
                    from Room r";
                DashRoom dr = db.Database.SqlQuery<DashRoom>(query2).FirstOrDefault();
                ViewBag.dr = dr;
            }
            return View("/Views/CDVT/Dashboard.cshtml");
        }

        private void Wherecondition(string type, string month, string year)
        {
            string querySC = "";
            string queryBD = "";
            string queryTL = "";
            string queryTDT = "";
            string queryKD = "";
            string queryCamera = "";
            if (type == null)
            {
                int monthnull = DateTime.Now.Date.Month;
                int yearnull = DateTime.Now.Date.Year;
                querySC = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 1 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryBD = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 2 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryTL = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 5 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryTDT = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 6 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryKD = "select DAY(e.inspect_date) as [date] ,COUNT(e.inspect_date) as soluong " +
                            " from Equipment_Inspection e where MONTH(e.inspect_date) = " + monthnull + " and YEAR(e.inspect_date) = " + yearnull + " " +
                            " group by DAY(e.inspect_date)";
                queryCamera = @"select DAY(e.start_time) as [date] ,SUM(e.incident_camera_quantity) as soluong  
                             from CameraIncident e where MONTH(e.start_time) = " + monthnull + " and YEAR(e.start_time) = " + yearnull +
                             " group by DAY(e.start_time)";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                querySC = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 1 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryBD = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 2 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryTL = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 5 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryTDT = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_id = a.documentary_id and do.documentary_type = 6 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryKD = "select DAY(e.inspect_date) as [date] ,COUNT(e.inspect_date) as soluong " +
                            " from Equipment_Inspection e where MONTH(e.inspect_date) = " + thang + " and YEAR(e.inspect_date) = " + nam + " " +
                            " group by DAY(e.inspect_date)";
                queryCamera = @"select DAY(e.start_time) as [date] ,SUM(e.incident_camera_quantity) as soluong  
                             from CameraIncident e where MONTH(e.start_time) = " + thang + " and YEAR(e.start_time) = " + nam +
                             " group by DAY(e.start_time)";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                querySC = "select CAST(t.[month] as int) as [date], count(g.equipmentId) as soluong from (select number as [month] " +
                            " from(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a where number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 1) as g " +
                            " on t.[month] = month(g.acceptance_date) and YEAR(g.acceptance_date) = " + nam + " group by t.[month] order by t.[month] asc";
                queryBD = "select CAST(t.[month] as int) as [date], count(g.equipmentId) as soluong from (select number as [month] " +
                            " from(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a where number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 2) as g " +
                            " on t.[month] = month(g.acceptance_date) and YEAR(g.acceptance_date) = " + nam + " group by t.[month] order by t.[month] asc";
                queryTL = "select CAST(t.[month] as int) as [date], count(g.equipmentId) as soluong from (select number as [month] " +
                            " from(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a where number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 5) as g " +
                            " on t.[month] = month(g.acceptance_date) and YEAR(g.acceptance_date) = " + nam + " group by t.[month] order by t.[month] asc";
                queryTDT = "select CAST(t.[month] as int) as [date], count(g.equipmentId) as soluong from (select number as [month] " +
                            " from(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a where number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 6) as g " +
                            " on t.[month] = month(g.acceptance_date) and YEAR(g.acceptance_date) = " + nam + " group by t.[month] order by t.[month] asc";
                queryKD = "select CAST(t.[month] as int) as [date], count(e.equipmentId) as soluong from (select number as [month] " +
                             " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                             " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a where number <= 12 and number > 0) as t left join Equipment_Inspection e " +
                             " on t.[month] = month(e.inspect_date) and YEAR(e.inspect_date) = " + nam + " group by t.[month]";
                queryCamera = @"select CAST(t.[month] as int) as [date], case when sum(e.incident_camera_quantity) is null then 0 else sum(e.incident_camera_quantity) end as soluong from (select number as [month]  
                              FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n),  
                              (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a where number <= 12 and number > 0) as t left join CameraIncident e  
                              on t.[month] = month(e.start_time) and YEAR(e.end_time) = " + nam + " group by t.[month]";
            }
            if (type == "yearss")
            {
                querySC = "select t.[year] as [date], count(g.equipmentId) as soluong from  (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) " +
                            " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a WHERE DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                              " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                              " on d.documentary_id = a.documentary_id where d.documentary_type = 1) as g on t.[year] = year(g.acceptance_date) " +
                            " group by t.[year] order by t.[year] asc";
                queryBD = "select t.[year] as [date], count(g.equipmentId) as soluong from  (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) " +
                            " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a WHERE DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                              " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                              " on d.documentary_id = a.documentary_id where d.documentary_type = 2) as g on t.[year] = year(g.acceptance_date) " +
                            " group by t.[year] order by t.[year] asc";
                queryTL = "select t.[year] as [date], count(g.equipmentId) as soluong from  (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) " +
                            " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a WHERE DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                              " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                              " on d.documentary_id = a.documentary_id where d.documentary_type = 5) as g on t.[year] = year(g.acceptance_date) " +
                            " group by t.[year] order by t.[year] asc";
                queryTDT = "select t.[year] as [date], count(g.equipmentId) as soluong from  (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) " +
                            " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a WHERE DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                              " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                              " on d.documentary_id = a.documentary_id where d.documentary_type = 6) as g on t.[year] = year(g.acceptance_date) " +
                            " group by t.[year] order by t.[year] asc";
                queryKD = "select t.[year] as [date], count(e.equipmentId) as soluong from " +
                             " (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) " +
                             " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                             " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a " +
                             " where DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join Equipment_Inspection e " +
                             " on t.[year] = year(e.inspect_date) group by t.[year] order by t.[year] asc";
                queryCamera = @"select t.[year] as [date], case when sum(e.incident_camera_quantity) is null then 0 else sum(e.incident_camera_quantity) end as soluong from  
                              (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date)))  
                              FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n),  
                              (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a  
                              where DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join CameraIncident e  
                              on t.[year] = year(e.start_time) group by t.[year] order by t.[year] asc";
            }
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                ViewBag.suachua = db.Database.SqlQuery<form>(querySC).ToList();
                ViewBag.baoduong = db.Database.SqlQuery<form>(queryBD).ToList();
                ViewBag.thanhli = db.Database.SqlQuery<form>(queryTL).ToList();
                ViewBag.trungdaitu = db.Database.SqlQuery<form>(queryTDT).ToList();
                ViewBag.kiemdinh = db.Database.SqlQuery<form>(queryKD).ToList();
                ViewBag.camera = db.Database.SqlQuery<form>(queryCamera).ToList();
                if (type == "month" || type == null)
                {
                    ViewBag.type = "month";
                }
                if (type == "year")
                {
                    ViewBag.type = "year";
                }
                if (type == "yearss")
                {
                    ViewBag.type = "yearss";
                }

            }
        }

        [Route("camera/changedate")]
        [HttpPost]
        public ActionResult ChangeDate(string date)
        {
            string[] d = date.Split(' ');
            string query = @"select COUNT(ci.incident_id) as 'sum', case when SUM(case when ci.end_time is not null then 1 else 0 end) is null then 0 else SUM(case when ci.end_time is not null then 1 else 0 end) end  as 'done',
                            case when SUM(case when ci.reason like N'%sét%' or ci.reason like '%set%' then 1 else 0 end) is null then 0 else SUM(case when ci.reason like N'%sét%' or ci.reason like '%set%' then 1 else 0 end) end as 'lightning'
                            from CameraIncident ci
                            where MONTH(ci.start_time) = @month and YEAR(ci.start_time) = @year";
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            DashCam dc = db.Database.SqlQuery<DashCam>(query, new SqlParameter("month", d[1]), new SqlParameter("year", d[2])).FirstOrDefault();
            dc.notdone = dc.sum - dc.done;
            return Json(new { success = true, message = "", dc = dc }, JsonRequestBehavior.AllowGet);
        }

        [Route("camera/getList")]
        [HttpPost]
        public ActionResult getList(string type)
        {
            try
            {
                string query = @"select r.room_name, d.department_name, r.camera_available, r.camera_quantity
                                from Room r join Department d on r.department_id = d.department_id";
                if (type.Equals("Hoạt động không đầy đủ"))
                {
                    query += " where r.camera_available < r.camera_quantity and r.camera_available > 0";
                }
                else if (type.Equals("Hoạt động đầy đủ"))
                {
                    query += " where r.camera_available = r.camera_quantity";
                }
                else if (type.Equals("Không hoạt động"))
                {
                    query += " where r.camera_available = 0";
                }
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                List<RoomThongKe> list = db.Database.SqlQuery<RoomThongKe>(query).ToList();
                return Json(new { success = true, listDB = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
        public class DashCam
        {
            public int sum { get; set; }
            public int done { get; set; }
            public int notdone { get; set; }
            public int lightning { get; set; }

        }

        public class DashRoom
        {
            public int daydu { get; set; }
            public int kodaydu { get; set; }
            public int ko { get; set; }
        }

        public class RoomThongKe
        {
            public string room_name { get; set; }
            public string department_name { get; set; }
            public int camera_available { get; set; }
            public int camera_quantity { get; set; }
        }
    }

    public class DashEquip
    {
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }
    }
    public class form
    {
        public int date { get; set; }
        public int soluong { get; set; }
    }
    public class form1
    {
        public string equipment_name { get; set; }
        public string equipmentId { get; set; }
        public int ngay { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
    }
    public class SL
    {
        public string equipment_name { get; set; }
        public string equipmentId { get; set; }
        public DateTime day { get; set; }
        public int ngay { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
    }
    public class GPSCarAvail
    {
        public string equipmentId { get; set; }
    }
}