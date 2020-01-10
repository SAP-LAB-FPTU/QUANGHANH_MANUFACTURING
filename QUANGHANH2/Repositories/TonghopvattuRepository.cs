using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Unity;

namespace QUANGHANH2.Repositories
{
    public class TonghopvattuRepository : ITonghopvattuRepository
    {
        [Dependency]
        public QUANGHANHABCEntities context { get; set; }

        public IList<TonghopvattuDepartmentModelView> GetDepartments()
        {
            var departments = context.Database.SqlQuery<TonghopvattuDepartmentModelView>("SELECT " +
                "department_id DepartmentId, department_name DepartmentName, department_type DepartmentType " +
                "FROM Department").ToList();
            return departments;
        }

        public IList<TonghopvattuDetailModelView> GetDetails(TonghopVattuSearchModelView search)
        {
            
            //string query = $"SELECT tmp.SupplyId, s.supply_name SupplyName, s.unit SupplyUnit, tmp.SupplyAverage, st.quantity SupplyQuantity " +
            //    $"FROM (SELECT supplyid SupplyId, SUM(dinh_muc) AS SupplyAverage FROM SupplyPlan WHERE departmentid = '{search.DepartmentId}' AND YEAR([date]) = {monthPicked.Year} AND MONTH([date]) = {monthPicked.Month} AND [status] = 1 GROUP BY supplyid) tmp, Supply s, Supply_tieuhao st " +
            //    $"WHERE st.supplyid = tmp.SupplyId AND s.supply_id = tmp.SupplyId AND " +
            //    $"st.departmentid = '{search.DepartmentId}' AND " +
            //    $"s.supply_id LIKE N'%{search.SupplyId}%' AND " +
            //    $"s.supply_name LIKE N'%{search.SupplyName}%'";
            var val = search.MonthPicked.Split(' ');
            string query = "select  SUM(quantity) SupplyQuantity,supply_name as SupplyName, unit as SupplyUnit " +
                            "from SupplyPlan inner join Supply "+
                          " on SupplyPlan.supplyid = supply.supply_id "+
                          "  where departmentid = @DepartmentId AND [status] = 1  and YEAR([date]) = @year AND MONTH([date]) = @month " +
                          " and supply_name LIKE @name" +
                          " group by supplyplan.supplyid,supply_name,unit";
            var details = context.Database.SqlQuery<TonghopvattuDetailModelView>(query,new SqlParameter("DepartmentId", search.DepartmentId),
                                                                                       new SqlParameter("year", val[2]),
                                                                                       new SqlParameter("month", val[1]),
                                                                                       new SqlParameter("name", "%" + search.SupplyName + "%")).ToList();
            return details;
        }

        public IList<TonghopvattuSummaryModelView> GetSummary(TonghopVattuSearchModelView search)
        {
            var val = search.MonthPicked.Split(' ');
            //DateTime monthPicked = DateTime.ParseExact(search.MonthPicked,"dd/MM/yyyy",null);
            string query = "SELECT tmp.SupplyId, tmp.SupplyQuantity, s.supply_name SupplyName, s.unit SupplyUnit " +
                "FROM (SELECT st.supplyid SupplyId, SUM(st.quantity) SupplyQuantity FROM SupplyPlan st, Supply s WHERE st.supplyid = s.supply_id AND YEAR([date]) = @year AND MONTH([date]) = @month GROUP BY st.supplyid) tmp, Supply s " +
                "WHERE tmp.SupplyId = s.supply_id AND " +
                "s.supply_name LIKE @name";
            var summary = context.Database.SqlQuery<TonghopvattuSummaryModelView>(query,new SqlParameter("year", val[2]),
                                                                                       new SqlParameter("month", val[1]),
                                                                                       new SqlParameter("name", "%" + search.SupplyName+"%" )).ToList();
            return summary;
        }
    }
}