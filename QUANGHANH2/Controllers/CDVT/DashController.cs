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
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

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
                                                                    new SqlParameter("date",date),
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
                listhd = (from equip in db.Equipments.Where(x => x.current_Status == 2) join c in db.Cars on equip.equipmentId equals c.equipmentId
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
                string query = @"select e.equipment_name, COUNT(e.equipmentId) as 'num',
                                SUM(case when e.current_Status = 2 then 1 else 0 end) as 'sum1',
                                SUM(case when e.current_Status != 2 then 1 else 0 end) as 'sum2'
                                from Equipment e join Car c on e.equipmentId = c.equipmentId
                                where e.isAttach = 0
                                group by e.equipment_name";
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
                string query = @"select e.equipment_name, COUNT(e.equipmentId) as 'num',
                                SUM(case when e.current_Status = 2 then 1 else 0 end) as 'sum1',
                                SUM(case when e.current_Status != 2 then 1 else 0 end) as 'sum2'
                                from Equipment e
                                where e.isAttach = 0
                                group by e.equipment_name";
                var tonghop = db.Database.SqlQuery<ExportByGroup>(query).ToList();
                ViewBag.hd = tonghop;
                //ViewBag.hd = listhd.Except(listcar);
                ViewBag.khd = listkhd.Except(listcar);
            }

            EquipThongKe etk = new EquipThongKe();
            var equipList = db.Equipments.ToList<Equipment>();
            etk.total = equipList.Count().ToString();
            int total_repair = 0; int total_maintain = 0; int total_TL = 0; int total_TH = 0;
            var listKD = (from equip in db.Equipments
                                        .Where(equip => equip.current_Status == 10)
                          join cate in db.Equipment_category
                          on equip.Equipment_category_id equals cate.Equipment_category_id
                          select new DashEquip
                          {
                              equipmentId = equip.equipmentId,
                              equipment_name = equip.equipment_name
                          }).ToList();
            ViewBag.listKD = listKD;
            ViewBag.totalKD = listKD.Count();

            etk.total_HD = db.Equipments.Where(x => x.current_Status == 2).Count();
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
            var hanDangKiem = db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now).OrderBy(x => x.durationOfInspection).
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
            var hanBaoduong = db.Equipments.Where(x => x.durationOfMaintainance <= testTime && x.durationOfMaintainance >= DateTime.Now).OrderBy(x => x.durationOfMaintainance).
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
            return View("/Views/CDVT/Dashboard.cshtml");
        }

        private void Wherecondition(string type, string month, string year)
        {
            string querySC = "";
            string queryBD = "";
            string queryTL = "";
            string queryTDT = "";
            string queryKD = "";
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
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.suachua = db.Database.SqlQuery<form>(querySC).ToList();
                ViewBag.baoduong = db.Database.SqlQuery<form>(queryBD).ToList();
                ViewBag.thanhli = db.Database.SqlQuery<form>(queryTL).ToList();
                ViewBag.trungdaitu = db.Database.SqlQuery<form>(queryTDT).ToList();
                ViewBag.kiemdinh = db.Database.SqlQuery<form>(queryKD).ToList();
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