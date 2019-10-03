using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using static QUANGHANHCORE.Controllers.CDVT.Thietbi.HoatdongController;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class Temp
    {
        public string abc { get; set; }
    }
    public class DashController : Controller
    {
        [Auther(RightID = "001")]
        [Route("phong-cdvt")]
        public ActionResult Index(string type, string month, string year)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Department> listDepeartment = db.Departments.ToList<Department>();
            ViewBag.listDepeartment = listDepeartment;
            EquipThongKe etk = new EquipThongKe();
            var equipList = db.Equipments.ToList<Equipment>();
            etk.total = equipList.Count().ToString();
            List<int> temp = db.Equipments.Where(x=>x.current_Status == 3 || x.current_Status == 8 ||x.current_Status == 1 ||x.current_Status == 5).Select(x => x.current_Status).ToList();
            int total_repair = 0; int total_maintain = 0; int total_TL = 0; int total_TH = 0; int totalKD = 0;
            foreach (var item in temp)
            {
                switch (item)
                {
                    case 3:
                        total_repair++;
                        break;
                    case 5:
                        total_maintain++;
                        break;
                    case 8:
                        total_TL++;
                        break;
                    case 1:
                        total_TH++;
                        break;
                }
            }
            etk.total_repair = total_repair+"";
            etk.total_maintain = total_maintain+"";
            etk.total_TL = total_TL + "";
            etk.total_TH = total_TH + "";
            List<DashEquip> listKD = (from equip in db.Equipments
                                        .Where(equip => equip.current_Status == 10)
                                      join cate in db.Equipment_category
                                      on equip.Equipment_category_id equals cate.Equipment_category_id
                                      select new
                                      {
                                          equipmentID = equip.equipmentId,
                                          equipmentName = equip.equipment_name

                                      }).ToList();
            int totalKD = 0;
            foreach (var item in listKD)
            {
                totalKD++;
            }
            ViewBag.listKD = listKD;
            ViewBag.totalKD = totalKD;
            etk.total_KHD = Convert.ToInt32(etk.total_repair) + Convert.ToInt32(etk.total_maintain) + Convert.ToInt32(etk.total_KD) + Convert.ToInt32(etk.total_TH) + Convert.ToInt32(etk.total_TL);
            etk.total_HD = Convert.ToInt32(etk.total) - Convert.ToInt32(etk.total_KHD);

            List<DashEquip> listRepair = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 3").ToList();
            ViewBag.listRepair = listRepair;

            List<DashEquip> listMain = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 5").ToList();
            ViewBag.listMain = listMain;

            List<DashEquip> listTL = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 8").ToList();
            ViewBag.listTL = listTL;

            List<DashEquip> listTH = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 1").ToList();
            ViewBag.listTH = listTH;
            ViewBag.Thongke = etk;
            List<form1> hanDangKiem = db.Database.SqlQuery<form1>("select top 10 e.equipment_name,e.equipmentId,DAY(e.durationOfInspection) as ngay,MONTH(e.durationOfInspection) as thang,YEAR(e.durationOfInspection) as nam from Equipment e where (CAST(e.durationOfInspection as datetime) - GETDATE() between -1 and 10)  and YEAR(e.durationOfInspection) = YEAR(GETDATE()) order by e.durationOfInspection asc").ToList();
            int kiemdinhtag = 0;
            foreach (var item in hanDangKiem)
            {
                kiemdinhtag++;
            }
            ViewBag.kiemdinhtag = kiemdinhtag;
            ViewBag.handangkiem = hanDangKiem;
            List<form1> hanBaoduong = db.Database.SqlQuery<form1>("select top 10 e.equipment_name,e.equipmentId, DAY(e.nearest_Maintenance_Day) as ngay,MONTH(e.nearest_Maintenance_Day) as thang,YEAR(e.nearest_Maintenance_Day) as nam  from Equipment e where (CAST(e.nearest_Maintenance_Day as datetime) - GETDATE() between -1 and 10) and YEAR(e.nearest_Maintenance_Day) = YEAR(GETDATE()) order by e.nearest_Maintenance_Day asc").ToList();
            int baoduongtag = 0;
            foreach (var item in hanBaoduong)
            {
                baoduongtag++;
            }
            ViewBag.baoduongtag = baoduongtag;
            ViewBag.hanbaoduong = hanBaoduong;

            var tongcogioi = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy')").ToList();
            ViewBag.tongcogioi = tongcogioi.Count().ToString();

            var cogioihd = db.Database.SqlQuery<SL>("select COUNT(e.current_Status) as abc from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status =2").FirstOrDefault();
            ViewBag.cogioikhd = tongcogioi.Count() - cogioihd.abc;
            ViewBag.cogioihd = cogioihd.abc;
            List<DashEquip> cogioiSC = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 3").ToList();
            ViewBag.cogioiSC = cogioiSC;
            var slSC = db.Database.SqlQuery<SL>("select COUNT(e.equipmentId) as abc from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 3").FirstOrDefault();
            ViewBag.slSC = slSC.abc;

            List<DashEquip> cogioiBD = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 5").ToList();
            ViewBag.cogioiBD = cogioiBD;
            var slBD = db.Database.SqlQuery<SL>("select COUNT(e.equipmentId) as abc from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 5").FirstOrDefault();
            ViewBag.slBD = slBD.abc;

            List<DashEquip> cogioiKD = db.Database.SqlQuery<DashEquip>("select distinct t.equipmentId, t.equipment_name from (select e.equipmentId, e.equipment_name, e.current_Status,ec.Equipment_category_id from Equipment e inner join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id where e.current_Status = 10) as t  inner join Equipment_category_attribute ea on ea.Equipment_category_id = t.Equipment_category_id  where ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy'").ToList();
            int slKD = 0;
            foreach (var item in cogioiKD)
            {
                slKD++;
            }
            ViewBag.cogioiKD = cogioiKD;
            ViewBag.slKD = slKD;

            List<DashEquip> cogioiTL = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 8").ToList();
            ViewBag.cogioiTL = cogioiTL;
            var slTL = db.Database.SqlQuery<SL>("select COUNT(e.equipmentId) as abc from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 8").FirstOrDefault();
            ViewBag.slTL = slTL.abc;

            List<DashEquip> cogioiTH = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 7").ToList();
            ViewBag.cogioiTH = cogioiTH;
            var slTH = db.Database.SqlQuery<SL>("select COUNT(e.equipmentId) as abc from Equipment e where e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') and e.current_Status = 7").FirstOrDefault();
            ViewBag.slTH = slTH.abc;

            List<form1> hanDangKiemcogioi = db.Database.SqlQuery<form1>("select top 10 e.equipment_name,e.equipmentId,DAY(e.durationOfInspection) as ngay,MONTH(e.durationOfInspection) as thang,YEAR(e.durationOfInspection) as nam from Equipment e where (CAST(e.durationOfInspection as datetime) - GETDATE() between -1 and 10)  and YEAR(e.durationOfInspection) = YEAR(GETDATE()) and e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') order by e.durationOfInspection asc").ToList();
            int kiemdinhcogioitag = 0;
            foreach (var item in hanDangKiem)
            {
                kiemdinhcogioitag++;
            }
            ViewBag.kiemdinhcogioitag = kiemdinhcogioitag;
            ViewBag.hanDangKiemcogioi = hanDangKiemcogioi;

            List<form1> hanBaoduongcogioi = db.Database.SqlQuery<form1>("select top 10 e.equipment_name,e.equipmentId, DAY(e.nearest_Maintenance_Day) as ngay,MONTH(e.nearest_Maintenance_Day) as thang,YEAR(e.nearest_Maintenance_Day) as nam  from Equipment e where (CAST(e.nearest_Maintenance_Day as datetime) - GETDATE() between -1 and 10) and YEAR(e.nearest_Maintenance_Day) = YEAR(GETDATE()) and e.Equipment_category_id in (select ec.Equipment_category_id from Equipment_category_attribute ec where ec.Equipment_category_attribute_name = N'Số khung' or ec.Equipment_category_attribute_name = N'Số máy') order by e.nearest_Maintenance_Day asc").ToList();
            int baoduongcogioitag = 0;
            foreach (var item in hanBaoduongcogioi)
            {
                baoduongcogioitag++;
            }
            ViewBag.baoduongcogioitag = baoduongcogioitag;
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
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 1 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryBD = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 2 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryTL = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 5 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryTDT = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 6 " +
                             " and MONTH(a.acceptance_date) = " + monthnull + " and YEAR(a.acceptance_date) = " + yearnull + " " +
                             " group by DAY(a.acceptance_date)";
                queryKD = "select DAY(e.inspect_end_date) as [date] ,COUNT(e.inspect_end_date) as soluong " +
                            " from Equipment_Inspection e where MONTH(e.inspect_end_date) = " + monthnull + " and YEAR(e.inspect_end_date) = " + yearnull + " " +
                            " group by DAY(e.inspect_end_date)";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                querySC = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 1 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryBD = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 2 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryTL = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 5 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryTDT = "select DAY(a.acceptance_date) as [date],COUNT(a.acceptance_date) as soluong from Documentary do , Acceptance a " +
                             " where do.documentary_code = a.documentary_id and do.documentary_type = 6 " +
                             " and MONTH(a.acceptance_date) = " + thang + " and YEAR(a.acceptance_date) = " + nam + " " +
                             " group by DAY(a.acceptance_date)";
                queryKD = "select DAY(e.inspect_end_date) as [date] ,COUNT(e.inspect_end_date) as soluong " +
                            " from Equipment_Inspection e where MONTH(e.inspect_end_date) = " + thang + " and YEAR(e.inspect_end_date) = " + nam + " " +
                            " group by DAY(e.inspect_end_date)";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                querySC = "select CAST(t.[month] as int) as [date], count(g.equipmentId) as soluong from (select number as [month] " +
                            " from(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                            " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a where number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 1) as g " +
                            " on t.[month] = month(g.acceptance_date) and YEAR(g.acceptance_date) = "+nam+" group by t.[month] order by t.[month] asc";
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
                             " on t.[month] = month(e.inspect_end_date) and YEAR(e.inspect_end_date) = "+nam+" group by t.[month]";
            }
            if (type == "yearss")
            {
                querySC = "select t.[year] as [date], count(g.equipmentId) as soluong from  (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) "+
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
                queryKD = "select t.[year] as [date], count(e.equipmentId) as soluong from "+
                             " (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) " +
                             " FROM(SELECT ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) as Number FROM(VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) a(n), " +
                             " (VALUES(0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) b(n)) as a " +
                             " where DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join Equipment_Inspection e " +
                             " on t.[year] = year(e.inspect_end_date) group by t.[year] order by t.[year] asc";
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
        public int abc { get; set; }
    }
}