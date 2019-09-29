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
            var details = context.Database.SqlQuery<TieuhaoModelView>($"" +
                $"SELECT st.supplyid SupplyId, 0 SupplyInventory, st.departmentid DepartmentId, d.department_name DepartmentName, st.[quantity] SupplyQuantity, s.unit SupplyUnit, s.supply_name SupplyName, st.thuhoi SupplyEviction, st.used SupplyUsed  " +
                $"FROM Supply_tieuhao st, Supply s, Department d " +
                $"WHERE s.supply_id = st.supplyid AND " +
                $"d.department_id = st.departmentid AND " +
                $"YEAR(st.[date]) = {today.Year} AND " +
                $"MONTH(st.[date]) = {today.Month} AND " +
                $"st.departmentid LIKE N'%{search.DepartmentId}%' AND " +
                $"d.department_name LIKE N'%{search.DeparmentName}%' AND " +
                $"st.supplyid LIKE N'%{search.SupplyId}%' AND " +
                $"s.supply_name LIKE N'%{search.SupplyName}%' ORDER BY st.departmentid").ToList();
            return details;
        }

        public List<TieuhaoModelView> GetSummary(TieuhaoSearchModelView search)
        {
            var today = DateTime.Now;
            var details = context.Database.SqlQuery<TieuhaoModelView>($"" +
                $"SELECT tmp.*, s.supply_name SupplyName, 0 SupplyInventory, s.unit SupplyUnit " +
                $"FROM (SELECT st.supplyid SupplyId, SUM(st.[quantity]) SupplyQuantity, SUM(st.thuhoi) SupplyEviction, SUM(st.used) SupplyUsed FROM Supply_tieuhao st, Supply s " +
                    $"WHERE s.supply_id = st.supplyid AND " +
                    $"YEAR(st.[date]) = {today.Year} AND " +
                    $"MONTH(st.[date]) = {today.Month} AND " +
                    $"st.supplyid LIKE N'%{search.SupplyId}%' AND " +
                    $"s.supply_name LIKE N'%{search.SupplyName}%' " +
                    $"GROUP BY SupplyId) tmp, Supply s " +
                $"WHERE s.supply_id = tmp.SupplyId").ToList();
            return details;
        }
    }
}