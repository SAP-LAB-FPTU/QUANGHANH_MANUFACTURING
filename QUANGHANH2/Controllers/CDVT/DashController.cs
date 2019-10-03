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
    }/*a*/
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
            int total_repair = 0; int total_maintain = 0; int total_TL = 0; int total_TH = 0;
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
            var listKD = (from equip in db.Equipments
                                        .Where(equip => equip.current_Status == 10)
                                      join cate in db.Equipment_category
                                      on equip.Equipment_category_id equals cate.Equipment_category_id
                                      select new DashEquip
                                      {
                                          equipmentId = equip.equipmentId,
                                          equipment_name = equip.equipment_name
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

            var listRepair = db.Equipments.Where(x => x.current_Status == 3).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name= x.equipment_name }).ToList().Distinct();
            ViewBag.listRepair = listRepair;

            var listMain = db.Equipments.Where(x => x.current_Status == 5).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
            ViewBag.listMain = listMain;

            var listTL = db.Equipments.Where(x => x.current_Status == 8).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
            ViewBag.listTL = listTL;

            var listTH = db.Equipments.Where(x => x.current_Status == 1).Select(x => new DashEquip { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
            ViewBag.listTH = listTH;
            ViewBag.Thongke = etk;
            var testTime = DateTime.Now.AddDays(10);
            var hanDangKiem = db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now).OrderBy(x => x.durationOfInspection).
                                    Select(x => new form1
                                    {
                                        equipment_name = x.equipment_name,
                                        equipmentId = x.equipmentId,
                                        ngay = x.durationOfInspection.Day,
                                        thang = x.durationOfInspection.Month,
                                        nam = x.durationOfInspection.Year
                                    }).Take(10).ToList().Distinct();
            int kiemdinhtag = 0;
            foreach (var item in hanDangKiem)
            {
                kiemdinhtag++;
            }
            ViewBag.kiemdinhtag = kiemdinhtag;
            ViewBag.handangkiem = hanDangKiem;
            var hanBaoduong = db.Equipments.Where(x => x.durationOfMaintainance <= testTime && x.durationOfMaintainance >= DateTime.Now).OrderBy(x => x.durationOfMaintainance).
                                    Select(x => new form1
                                    {
                                        equipment_name = x.equipment_name,
                                        equipmentId = x.equipmentId,
                                        ngay = x.durationOfMaintainance.Day,
                                        thang = x.durationOfMaintainance.Month,
                                        nam = x.durationOfMaintainance.Year
                                    }).Take(10).ToList().Distinct();
            int baoduongtag = 0;
            foreach (var item in hanBaoduong)
            {
                baoduongtag++;
            }
            ViewBag.baoduongtag = baoduongtag;
            ViewBag.hanbaoduong = hanBaoduong;

            var tongcogioi = (from equip in db.Equipments
                              join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                              on equip.Equipment_category_id equals cate.Equipment_category_id
                              select new DashEquip
                              {
                                  equipment_name = equip.equipment_name,
                                  equipmentId = equip.equipmentId
                              }).ToList().Distinct();
            ViewBag.tongcogioi = tongcogioi.Count().ToString();

            var cogioihd = (from equip in db.Equipments.Where(x => x.current_Status == 2)
                            join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                            on equip.Equipment_category_id equals cate.Equipment_category_id
                            group equip by equip.current_Status into g
                            select new
                            {
                               count = g.Count()
                            }).Select(x=> new SL{ count = x.count}).Distinct().FirstOrDefault();
            ViewBag.cogioikhd = tongcogioi.Count() - cogioihd.count;
            ViewBag.cogioihd = cogioihd.count;
            var cogioiSC = (from equip in db.Equipments.Where(x => x.current_Status == 3)
                                        join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                        on equip.Equipment_category_id equals cate.Equipment_category_id
                                        select new DashEquip
                                        {
                                            equipment_name = equip.equipment_name,
                                            equipmentId = equip.equipmentId
                                        }).ToList().Distinct();
            ViewBag.cogioiSC = cogioiSC;
            var slSC = (from equip in db.Equipments.Where(x => x.current_Status == 3)
                        join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                        on equip.Equipment_category_id equals cate.Equipment_category_id
                        group equip by equip.current_Status into g
                        select new
                        {
                            count = g.Count()
                        }).Select(x => new SL{ count = x.count }).FirstOrDefault();
            if (slSC == null) {
                slSC = new SL{ count = 0 };
            }
            ViewBag.slSC = slSC.count;

            var cogioiBD = (from equip in db.Equipments.Where(x => x.current_Status == 5)
                                        join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                        on equip.Equipment_category_id equals cate.Equipment_category_id
                                        select new DashEquip
                                        {
                                            equipment_name = equip.equipment_name,
                                            equipmentId = equip.equipmentId
                                        }).ToList().Distinct();
            ViewBag.cogioiBD = cogioiBD;
            var slBD = (from equip in db.Equipments.Where(x => x.current_Status == 5)
                        join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                        on equip.Equipment_category_id equals cate.Equipment_category_id
                        group equip by equip.current_Status into g
                        select new
                        {
                            count = g.Count()
                        }).Select(x => new SL{ count = x.count }).FirstOrDefault();
            if (slBD == null)
            {
                slBD = new SL{ count = 0 };
            }
            ViewBag.slBD = slBD.count;

            var cogioiKD = (from equip in db.Equipments.Where(x => x.current_Status == 10)
                            join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                            on equip.Equipment_category_id equals cate.Equipment_category_id
                            join Equipment_category in db.Equipment_category
                            on equip.Equipment_category_id equals Equipment_category.Equipment_category_id
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).ToList();
            int slKD = 0;
            foreach (var item in cogioiKD)
            {
                slKD++;
            }
            ViewBag.cogioiKD = cogioiKD;
            ViewBag.slKD = slKD;

            var cogioiTL = (from equip in db.Equipments.Where(x => x.current_Status == 8)
                            join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                            on equip.Equipment_category_id equals cate.Equipment_category_id
                            select new DashEquip
                            {
                                equipment_name = equip.equipment_name,
                                equipmentId = equip.equipmentId
                            }).ToList();
            ViewBag.cogioiTL = cogioiTL;
            var slTL = (from equip in db.Equipments.Where(x => x.current_Status == 8)
                        join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                        on equip.Equipment_category_id equals cate.Equipment_category_id
                        group equip by equip.current_Status into g
                        select new
                        {
                            count = g.Count()
                        }).Select(x => new SL{ count = x.count }).FirstOrDefault();
            if (slTL == null)
            {
                slTL = new SL{ count = 0 };
            }
            ViewBag.slTL = slTL.count;

            var cogioiTH = (from equip in db.Equipments.Where(x => x.current_Status == 7)
                                        join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                        on equip.Equipment_category_id equals cate.Equipment_category_id
                                        select new DashEquip
                                        {
                                            equipment_name = equip.equipment_name,
                                            equipmentId = equip.equipmentId
                                        }).ToList();
            ViewBag.cogioiTH = cogioiTH;
            var slTH = (from equip in db.Equipments.Where(x => x.current_Status == 7)
                        join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                        on equip.Equipment_category_id equals cate.Equipment_category_id
                        group equip by equip.current_Status into g
                        select new
                        {
                            count = g.Count()
                        }).Select(x => new SL { count = x.count }).FirstOrDefault();
            if (slTH == null)
            {
                slTH = new SL{ count = 0 };
            }
            ViewBag.slTH = slTH.count;

            var hanDangKiemcogioi = (from equip in db.Equipments.Where(x =>x.durationOfInspection <= testTime && x.durationOfInspection >=DateTime.Now).OrderBy(x=>x.durationOfInspection)
                                     join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                        on equip.Equipment_category_id equals cate.Equipment_category_id
                                     select new form1
                                     {
                                         equipment_name = equip.equipment_name,
                                         equipmentId = equip.equipmentId,
                                         ngay = equip.durationOfInspection.Day,
                                         thang = equip.durationOfInspection.Month,
                                         nam = equip.durationOfInspection.Year
                                     }).Take(10).ToList().Distinct();
            int kiemdinhcogioitag = 0;
            foreach (var item in hanDangKiemcogioi)
            {
                kiemdinhcogioitag++;
            }
            ViewBag.kiemdinhcogioitag = kiemdinhcogioitag;
            ViewBag.hanDangKiemcogioi = hanDangKiemcogioi;

            var hanBaoduongcogioi = (from equip in db.Equipments.Where(x => x.durationOfMaintainance <= testTime && x.durationOfMaintainance >= DateTime.Now).OrderBy(x => x.durationOfMaintainance)
                                     join cate in db.Equipment_category_attribute.Where(x => x.Equipment_category_attribute_name == "Số máy" || x.Equipment_category_attribute_name == "Số khung")
                                        on equip.Equipment_category_id equals cate.Equipment_category_id
                                     select new form1
                                     {
                                         equipment_name = equip.equipment_name,
                                         equipmentId = equip.equipmentId,
                                         ngay = equip.durationOfMaintainance.Day,
                                         thang = equip.durationOfMaintainance.Month,
                                         nam = equip.durationOfMaintainance.Year
                                     }).Take(10).ToList().Distinct();
            int baoduongcogioitag = 0;
            foreach (var item in hanBaoduongcogioi)
            {
                baoduongcogioitag++;
            }
            ViewBag.baoduongcogioitag = baoduongcogioitag;
            ViewBag.hanBaoduongcogioi = hanBaoduongcogioi;


            //Wherecondition(type, month, year);
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
                queryKD = "select DAY(e.inspect_end_date) as [date] ,COUNT(e.inspect_end_date) as soluong " +
                            " from Equipment_Inspection e where MONTH(e.inspect_end_date) = " + monthnull + " and YEAR(e.inspect_end_date) = " + yearnull + " " +
                            " group by DAY(e.inspect_end_date)";
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
        public int count { get; set; }
    }
}