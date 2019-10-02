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
            var temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 3").ToList<Temp>();
            etk.total_repair = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 5").ToList<Temp>();
            etk.total_maintain = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 8").ToList<Temp>();
            etk.total_TL = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 1").ToList<Temp>();
            etk.total_TH = temp.Count().ToString();

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
                querySC = "select t.[month] as [date], count(g.equipmentId) as soluong from " +
                            " (select number as [month] from master..spt_values where Type = 'P' and number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from " +
                            " Acceptance a left join Documentary d on d.documentary_id = a.documentary_id " +
                            " where d.documentary_type = 1 and YEAR(a.acceptance_date) = " + nam + " ) as g " +
                            " on t.[month] = month(g.acceptance_date) " +
                            "group by t.[month] order by t.[month] asc";
                queryBD = "select t.[month] as [date], count(g.equipmentId) as soluong from " +
                            " (select number as [month] from master..spt_values where Type = 'P' and number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from " +
                            " Acceptance a left join Documentary d on d.documentary_id = a.documentary_id " +
                            " where d.documentary_type = 2 and YEAR(a.acceptance_date) = " + nam + ") as g " +
                            " on t.[month] = month(g.acceptance_date) " +
                            " group by t.[month] order by t.[month] asc";
                queryTL = "select t.[month] as [date], count(g.equipmentId) as soluong from " +
                            " (select number as [month] from master..spt_values where Type = 'P' and number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from " +
                            " Acceptance a left join Documentary d on d.documentary_id = a.documentary_id " +
                            " where d.documentary_type = 5 and YEAR(a.acceptance_date) = " + nam + ") as g " +
                            " on t.[month] = month(g.acceptance_date) " +
                            " group by t.[month] order by t.[month] asc";
                queryTDT = "select t.[month] as [date], count(g.equipmentId) as soluong from " +
                            " (select number as [month] from master..spt_values where Type = 'P' and number <= 12 and number > 0) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from " +
                            " Acceptance a left join Documentary d on d.documentary_id = a.documentary_id " +
                            " where d.documentary_type = 6 and YEAR(a.acceptance_date) = " + nam + ") as g " +
                            " on t.[month] = month(g.acceptance_date) " +
                            " group by t.[month] order by t.[month] asc";
                queryKD = "select t.[month] as [date], count(e.equipmentId) as soluong from (select number as [month] " +
                            " from master..spt_values where Type = 'P' and number <= 12 and number > 0) as t left join Equipment_Inspection e " +
                            " on t.[month] = month(e.inspect_end_date) and YEAR(e.inspect_end_date) = " + nam + " group by t.[month]";
            }
            if (type == "yearss")
            {
                querySC = "select t.[year] as [date], count(g.equipmentId) as soluong from " +
                            " (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) FROM  master..spt_values " +
                            " WHERE Type = 'P' AND DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 1) as g " +
                            " on t.[year] = year(g.acceptance_date) group by t.[year] order by t.[year] asc";
                queryBD = "select t.[year] as [date], count(g.equipmentId) as soluong from " +
                            " (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) FROM  master..spt_values " +
                            " WHERE Type = 'P' AND DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 2) as g " +
                            " on t.[year] = year(g.acceptance_date) group by t.[year] order by t.[year] asc";
                queryTL = "select t.[year] as [date], count(g.equipmentId) as soluong from " +
                            " (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) FROM  master..spt_values " +
                            " WHERE Type = 'P' AND DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 5) as g " +
                            " on t.[year] = year(g.acceptance_date) group by t.[year] order by t.[year] asc";
                queryTDT = "select t.[year] as [date], count(g.equipmentId) as soluong from " +
                            " (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) FROM  master..spt_values " +
                            " WHERE Type = 'P' AND DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join " +
                            " (select a.acceptance_date, a.equipmentId from Acceptance a left join Documentary d " +
                            " on d.documentary_id = a.documentary_id where d.documentary_type = 6) as g " +
                            " on t.[year] = year(g.acceptance_date) group by t.[year] order by t.[year] asc";
                queryKD = "select t.[year] as [date], count(e.equipmentId) as soluong from " +
                            " (SELECT[year] = year(DATEADD(year, Number, cast('01/01/2010' as date))) " +
                            " FROM  master..spt_values WHERE Type = 'P' " +
                            " AND DATEADD(year, Number, '01/01/2010') <= GETDATE()) as t left join Equipment_Inspection e " +
                            " on t.[year] = year(e.inspect_end_date) group by t.[year]";
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
}