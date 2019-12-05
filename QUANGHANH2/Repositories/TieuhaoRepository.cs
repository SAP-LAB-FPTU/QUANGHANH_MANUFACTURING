using System;
using System.Collections.Generic;
using System.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using Unity;

namespace QUANGHANH2.Repositories
{
    public class TieuhaoRepository : ITieuhaoRepository
    {
        [Dependency]
        public QUANGHANHABCEntities context { get; set; }

        public List<TieuhaoModelView> GetDetails(TieuhaoSearchModelView search)
        {
            var today = DateTime.Now;
            //var details = context.Database.SqlQuery<TieuhaoModelView>($"" +
            //    $"SELECT st.supplyid SupplyId, 0 SupplyInventory, st.departmentid DepartmentId, d.department_name DepartmentName, st.[quantity] SupplyQuantity, s.unit SupplyUnit, s.supply_name SupplyName, st.thuhoi SupplyEviction, st.used SupplyUsed  " +
            //    $"FROM Supply_tieuhao st, Supply s, Department d " +
            //    $"WHERE s.supply_id = st.supplyid AND " +
            //    $"d.department_id = st.departmentid AND " +
            //    $"YEAR(st.[date]) = {today.Year} AND " +
            //    $"MONTH(st.[date]) = {today.Month} AND " +
            //    $"st.departmentid LIKE N'%{search.DepartmentId}%' AND " +
            //    $"d.department_name LIKE N'%{search.DeparmentName}%' AND " +
            //    $"st.supplyid LIKE N'%{search.SupplyId}%' AND " +
            //    $"s.supply_name LIKE N'%{search.SupplyName}%' ORDER BY st.departmentid").ToList();
            var details = context.Database.SqlQuery<TieuhaoModelView>("select a.supply_id SupplyId, a.supply_name SupplyName, a.departmentid DepartmentId, sum(a.quantity) SupplyQuantity, a.unit SupplyUnit,a.department_name DepartmentName, sum(a.used) SupplyUsed, sum(a.thuhoi) SupplyEviction " +
" from " +
 "(select s.supply_id , s.supply_name, sp.departmentid, sp.quantity, s.unit,d.department_name, " +
"(case when mcd.supplyStatus = 1 then mcd.quantity else 0 end) +(case when esd.supplyStatus = 1 then mcd.quantity else 0 end) +   " +
"(case when fac.consumption_value is null then 0 else fac.consumption_value end) as used, " +
"(case when mcd.supplyStatus = 2 then mcd.quantity else 0 end) +(case when esd.supplyStatus = 2 then mcd.quantity else 0 end) as thuhoi " +
"from Supply s inner " +
"join SupplyPlan sp " +
"on s.supply_id = sp.supplyid inner join Department d on sp.departmentid= d.department_id left " +
"join Maintain_Car mc on mc.departmentid = sp.departmentid left " +
"join Maintain_Car_Detail mcd " +
"on s.supply_id = mcd.supplyid left " +
"join Equipment_SCTX es on es.department_id = sp.departmentid left " +
"join Equipment_SCTX_Detail esd " +
"on s.supply_id = esd.supplyid left " +
"join Equipment e on sp.departmentid = e.department_id left " +
"join Fuel_activities_consumption fac on fac.fuel_type = s.supply_id " +
$" where Year(sp.date)= {today.Year} AND MONTH(sp.[date]) = {today.Month} " +
")as a " +
$" where a.departmentid LIKE N'%{search.DepartmentId}%' and a.department_name LIKE N'%{search.DeparmentName}%' " +
$" and a.supply_id LIKE N'%{search.SupplyId}%' and a.supply_name LIKE N'%{search.SupplyName}%' " +
"group by a.supply_id, a.supply_name, a.departmentid, a.unit,a.department_name").ToList();

            return details;
        }

        public List<TieuhaoModelView> GetSummary(TieuhaoSearchModelView search)
        {
            var today = DateTime.Now;
            //var details = context.Database.SqlQuery<TieuhaoModelView>($"" +
            //    $"SELECT tmp.*, s.supply_name SupplyName, 0 SupplyInventory, s.unit SupplyUnit " +
            //    $"FROM (SELECT st.supplyid SupplyId, SUM(st.[quantity]) SupplyQuantity, SUM(st.thuhoi) SupplyEviction, SUM(st.used) SupplyUsed FROM Supply_tieuhao st, Supply s " +
            //        $"WHERE s.supply_id = st.supplyid AND " +
            //        $"YEAR(st.[date]) = {today.Year} AND " +
            //        $"MONTH(st.[date]) = {today.Month} AND " +
            //        $"st.supplyid LIKE N'%{search.SupplyId}%' AND " +
            //        $"s.supply_name LIKE N'%{search.SupplyName}%' " +
            //        $"GROUP BY SupplyId) tmp, Supply s " +
            //    $"WHERE s.supply_id = tmp.SupplyId").ToList();
            var details = context.Database.SqlQuery<TieuhaoModelView>("select a.supply_id SupplyId, a.supply_name SupplyName, sum(a.quantity) SupplyQuantity, a.unit, sum(a.used) SupplyUsed, sum(a.thuhoi) SupplyEviction "+
" from "+
 "(select s.supply_id, s.supply_name, sp.departmentid, sp.quantity, s.unit, "+
 "(case when mcd.supplyStatus = 1 then mcd.quantity else 0 end) +(case when esd.supplyStatus = 1 then mcd.quantity else 0 end) + "+
"(case when fac.consumption_value is null then 0 else fac.consumption_value end) as used , "+
"(case when mcd.supplyStatus = 2 then mcd.quantity else 0 end) +(case when esd.supplyStatus = 2 then mcd.quantity else 0 end) as thuhoi "+
"from Supply s inner "+
"join SupplyPlan sp "+
"on s.supply_id = sp.supplyid left "+
"join Maintain_Car mc on mc.departmentid = sp.departmentid left "+
"join Maintain_Car_Detail mcd "+
"on s.supply_id = mcd.supplyid left "+
"join Equipment_SCTX es on es.department_id = sp.departmentid left "+
"join Equipment_SCTX_Detail esd "+
"on s.supply_id = esd.supplyid left "+
"join Equipment e on sp.departmentid = e.department_id left "+
"join Fuel_activities_consumption fac on fac.fuelid = s.supply_id "+
$" where Month(sp.date) = {today.Year} AND YEAR(sp.[date]) = {today.Year} " +
")as a "+
$" where a.supply_id LIKE N'%{search.SupplyId}%' and a.supply_name  LIKE N'%{search.SupplyName}%' "+
" group by a.supply_id, a.supply_name, a.unit").ToList();
            return details;
        }
    }
}