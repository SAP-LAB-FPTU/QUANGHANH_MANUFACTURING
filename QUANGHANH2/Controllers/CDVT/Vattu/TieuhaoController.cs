using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Vattu
{
    public class TieuhaoController : Controller
    {
        private readonly ITieuhaoRepository _repository;
        public QUANGHANHABCEntities context = new QUANGHANHABCEntities();
        public TieuhaoController(ITieuhaoRepository repo)
        {
            _repository = repo;
        }

        [Auther(RightID = "35")]
        [Route("phong-cdvt/vat-tu/tieu-hao")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Vattu/Tieuhao.cshtml");
        }

        [HttpGet]
        [Route("phong-cdvt/vat-tu/tieu-hao/details")]
        public ActionResult Details(string SupplyId, string SupplyName, string DepartmentId, string DeparmentName, string type, string month, string year)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            var search = new Detail
            {
                SupplyId = SupplyId.Trim(),
                SupplyName = SupplyName.Trim(),
                DepartmentId = DepartmentId.Trim(),
                DeparmentName = DeparmentName.Trim(),
                type = type.Trim(),
                month = month.Trim(),
                year = year.Trim()
            };
            var details = GetDetails(search);
            int recordsTotal = details.Count;
            int recordsFiltered = details.Count;
            details = details.Skip(start).Take(length).ToList();
            return Json(new
            {
                success = true,
                data = details,
                recordsTotal,
                recordsFiltered
            }, JsonRequestBehavior.AllowGet);
        }
        public List<DataTieuHao> GetDetails(Detail search)
        {
            var val = search.month.Split(' ');
            if(search.type == null || search.type == "month")
            {
                string sql = @"select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
                                                                            (case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 
                                                                            (case when a.department_name is null then b.department_name else a.department_name end) 'DepartmentName', 
                                                                            (case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity', 
                                                                            (case when a.unit is null then b.unit else a.unit end) 'SupplyUnit', 
                                                                            sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
                                                                            sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction' 
                                                                            from 
                                                                            (select s.supply_id, s.supply_name, es.department_id, d.department_name, s.unit, 
                                                                            sum(case when esd.supplyStatus = 1 then esd.quantity else 0 end) 'used', 
                                                                            sum(case when esd.supplyStatus = 2 then esd.quantity else 0 end) 'thuhoi' 
                                                                            from Supply s inner join Equipment_SCTX_Detail esd 
                                                                            on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id 
                                                                            inner join Department d on es.department_id = d.department_id 
                                                                            and MONTH(es.[date]) = @month AND YEAR(es.[date]) = @year 
                                                                            group by s.supply_id, es.department_id, s.supply_name, d.department_name, s.unit 
                                                                            union all 
                                                                            select s.supply_id, s.supply_name, mc.departmentid, d.department_name, s.unit, 
                                                                            sum(case when mcd.supplyStatus = 1 then mcd.quantity else 0 end) 'used', 
                                                                            sum(case when mcd.supplyStatus = 2 then mcd.quantity else 0 end) 'thuhoi' 
                                                                            from Supply s inner join Maintain_Car_Detail mcd 
                                                                            on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid 
                                                                            inner join Department d on d.department_id = mc.departmentid 
                                                                            and MONTH(mc.[date]) = @month AND YEAR(mc.[date]) = @year 
                                                                            group by s.supply_id, mc.departmentid, s.supply_name, d.department_name, s.unit 
                                                                            union all 
                                                                            select s.supply_id, s.supply_name, d.department_id, d.department_name, s.unit, 
                                                                            sum(fac.consumption_value) 'used', 
                                                                            0 'thuhoi' 
                                                                            from Supply s inner join Fuel_activities_consumption fac 
                                                                            on s.supply_id = fac.fuel_type inner join Equipment e on fac.equipmentId = e.equipmentId 
                                                                            and MONTH(fac.[date]) = @month AND YEAR(fac.[date]) = @year  
                                                                            inner join Department d on d.department_id = e.department_id 
                                                                            group by s.supply_id, s.supply_name, d.department_id, d.department_name, s.unit) as a  
                                                                            full outer join  
                                                                            (select sp.supplyid, s.supply_name, sp.departmentid, d.department_name, sum(sp.quantity) 'quantity', s.unit 
                                                                            from Supply s inner join SupplyPlan sp 
                                                                            on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id 
                                                                            where MONTH(sp.[date]) = @month and year(sp.[date]) = @year 
                                                                            group by  sp.supplyid, s.supply_name, sp.departmentid, d.department_name, s.unit 
                                                                            ) as b 
                                                                            on a.department_id = b.departmentid and a.supply_id = b.supplyid  
                                                                            where (a.supply_id like @supplyid or b.supplyid like @supplyid) and (b.departmentid like @departid or a.department_id like @departid)  
                                                                            and (a.supply_name like @supplyname or b.supply_name like @supplyname) and (b.department_name like @departname or a.department_name like @departname) 
                                                                            group by a.supply_id, a.department_id, b.supplyid,b.quantity, b.departmentid, a.supply_name, b.supply_name, 
                                                                            a.department_name, b.department_name, a.unit, b.unit"; 
                 var details = context.Database.SqlQuery<DataTieuHao>(sql, 
                                                                            new SqlParameter("month",val[1]),
                                                                            new SqlParameter("year",val[2]),
                                                                            new SqlParameter("supplyid","%" + search.SupplyId +"%"),
                                                                            new SqlParameter("departid", "%" + search.DepartmentId + "%"),
                                                                            new SqlParameter("supplyname", "%" + search.SupplyName + "%"),
                                                                            new SqlParameter("departname", "%" + search.DeparmentName + "%")
                                                                            ).ToList();
                return details;
            }
            if(search.type == "year")
            {
                string sql = @"select (case when a.supply_id is null then b.supplyid else a.supply_id end) 'SupplyId', 
                                                                            (case when a.supply_name is null then b.supply_name else a.supply_name end) 'SupplyName', 
                                                                            (case when a.department_name is null then b.department_name else a.department_name end) 'DepartmentName', 
                                                                            (case when b.quantity is null then 0 else b.quantity end) 'SupplyQuantity', 
                                                                            (case when a.unit is null then b.unit else a.unit end) 'SupplyUnit', 
                                                                            sum(case when a.used is null then 0 else a.used end) 'SupplyUsed', 
                                                                            sum(case when a.thuhoi is null then 0 else a.thuhoi end) 'SupplyEviction' 
                                                                            from 
                                                                            (select s.supply_id, s.supply_name, es.department_id, d.department_name, s.unit, 
                                                                            sum(case when esd.supplyStatus = 1 then esd.quantity else 0 end) 'used', 
                                                                            sum(case when esd.supplyStatus = 2 then esd.quantity else 0 end) 'thuhoi' 
                                                                            from Supply s inner join Equipment_SCTX_Detail esd 
                                                                            on s.supply_id = esd.supplyid inner join Equipment_SCTX es on es.maintain_id = esd.maintain_id 
                                                                            inner join Department d on es.department_id = d.department_id 
                                                                            and  YEAR(es.[date]) = @year 
                                                                            group by s.supply_id, es.department_id, s.supply_name, d.department_name, s.unit 
                                                                            union all 
                                                                            select s.supply_id, s.supply_name, mc.departmentid, d.department_name, s.unit, 
                                                                            sum(case when mcd.supplyStatus = 1 then mcd.quantity else 0 end) 'used', 
                                                                            sum(case when mcd.supplyStatus = 2 then mcd.quantity else 0 end) 'thuhoi' 
                                                                            from Supply s inner join Maintain_Car_Detail mcd 
                                                                            on s.supply_id = mcd.supplyid inner join Maintain_Car mc on mc.maintainid = mcd.maintainid 
                                                                            inner join Department d on d.department_id = mc.departmentid 
                                                                            and YEAR(mc.[date]) = @year 
                                                                            group by s.supply_id, mc.departmentid, s.supply_name, d.department_name, s.unit 
                                                                            union all 
                                                                            select s.supply_id, s.supply_name, d.department_id, d.department_name, s.unit, 
                                                                            sum(fac.consumption_value) 'used', 
                                                                            0 'thuhoi' 
                                                                            from Supply s inner join Fuel_activities_consumption fac 
                                                                            on s.supply_id = fac.fuel_type inner join Equipment e on fac.equipmentId = e.equipmentId 
                                                                            and  YEAR(fac.[date]) = @year  
                                                                            inner join Department d on d.department_id = e.department_id 
                                                                            group by s.supply_id, s.supply_name, d.department_id, d.department_name, s.unit) as a  
                                                                            full outer join  
                                                                            (select sp.supplyid, s.supply_name, sp.departmentid, d.department_name, sum(sp.quantity) 'quantity', s.unit 
                                                                            from Supply s inner join SupplyPlan sp 
                                                                            on s.supply_id = sp.supplyid inner join Department d on sp.departmentid = d.department_id 
                                                                            where  year(sp.[date]) = @year 
                                                                            group by  sp.supplyid, s.supply_name, sp.departmentid, d.department_name, s.unit 
                                                                            ) as b 
                                                                            on a.department_id = b.departmentid and a.supply_id = b.supplyid  
                                                                            where (a.supply_id like @supplyid or b.supplyid like @supplyid) and (b.departmentid like @departid or a.department_id like @departid)  
                                                                            and (a.supply_name like @supplyname or b.supply_name like @supplyname) and (b.department_name like @departname or a.department_name like @departname) 
                                                                            group by a.supply_id, a.department_id, b.supplyid,b.quantity, b.departmentid, a.supply_name, b.supply_name, 
                                                                            a.department_name, b.department_name, a.unit, b.unit";
                var details = context.Database.SqlQuery<DataTieuHao>(sql, 
                                                                            new SqlParameter("year", search.year),
                                                                            new SqlParameter("supplyid", "%" + search.SupplyId + "%"),
                                                                            new SqlParameter("departid", "%" + search.DepartmentId + "%"),
                                                                            new SqlParameter("supplyname", "%" + search.SupplyName + "%"),
                                                                            new SqlParameter("departname", "%" + search.DeparmentName + "%")
                                                                            ).ToList();
                return details;
            }
            return new List<DataTieuHao>();
        }

        public List<DataTieuHao> GetSummary(Detail search)
        {
            //var details= context.Database.SqlQuery<DataTieuHao>("select a.supply_id SupplyId, a.supply_name SupplyName, sum(a.quantity) SupplyQuantity, a.unit, sum(a.used) SupplyUsed, sum(a.thuhoi) SupplyEviction " +
            //                        " from " +
            //                         "(select s.supply_id, s.supply_name, sp.departmentid, sp.quantity, s.unit, " +
            //                         "(case when mcd.supplyStatus = 1 then mcd.quantity else 0 end) +(case when esd.supplyStatus = 1 then mcd.quantity else 0 end) + " +
            //                        "(case when fac.consumption_value is null then 0 else fac.consumption_value end) as used , " +
            //                        "(case when mcd.supplyStatus = 2 then mcd.quantity else 0 end) +(case when esd.supplyStatus = 2 then mcd.quantity else 0 end) as thuhoi " +
            //                        "from Supply s inner " +
            //                        "join SupplyPlan sp " +
            //                        "on s.supply_id = sp.supplyid left " +
            //                        "join Maintain_Car mc on mc.departmentid = sp.departmentid left " +
            //                        "join Maintain_Car_Detail mcd " +
            //                        "on s.supply_id = mcd.supplyid left " +
            //                        "join Equipment_SCTX es on es.department_id = sp.departmentid left " +
            //                        "join Equipment_SCTX_Detail esd " +
            //                        "on s.supply_id = esd.supplyid left " +
            //                        "join Equipment e on sp.departmentid = e.department_id left " +
            //                        "join Fuel_activities_consumption fac on fac.fuel_type = s.supply_id " +
            //                        $" where Month(sp.date) = {today.Year} AND YEAR(sp.[date]) = {today.Year} " +
            //                        ")as a " +
            //                        $" where a.supply_id LIKE N'%{search.SupplyId}%' and a.supply_name  LIKE N'%{search.SupplyName}%' " +
            //                        " group by a.supply_id, a.supply_name, a.unit").ToList();
            return new List<DataTieuHao>();
        }

        [Auther(RightID = "35")]
        [HttpGet]
        [Route("phong-cdvt/vat-tu/tieu-hao/summary")]
        public ActionResult Summary(string SupplyId, string SupplyName, string DepartmentId, string DeparmentName)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            var search = new TieuhaoSearchModelView
            {
                SupplyId = SupplyId.Trim(),
                SupplyName = SupplyName.Trim()
            };
            var details = _repository.GetSummary(search);
            int recordsTotal = details.Count;
            int recordsFiltered = details.Count;
            //details = details.Skip(start).Take(length).ToList();
            //// calc SupplyInventory
            ////foreach (var detail in details)
            ////{
            ////    detail.SupplyInventory = detail.SupplyQuantity - detail.SupplyUsed;
            ////}
            return Json(new
            {
                success = true,
                data = details,
                recordsTotal,
                recordsFiltered
            }, JsonRequestBehavior.AllowGet);
        }
    }
    public class Detail
    {
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string DepartmentId { get; set; }

        public string DeparmentName { get; set; }
        public string type { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }
    public class DataTieuHao
    {
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string DepartmentName { get; set; }
        public int SupplyQuantity { get; set; }
        public string SupplyUnit { get; set; }
        public int SupplyUsed { get; set; }
        public int SupplyEviction { get; set; }

    }
}