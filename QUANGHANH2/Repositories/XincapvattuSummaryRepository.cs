using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace QUANGHANH2.Repositories
{
    public class XincapvattuSummaryRepository : IXincapvattuSummaryRepository
    {
        [Dependency]
        public QUANGHANHABCEntities context { get; set; }

        public bool CreateSupplyConsumable(IList<XincapvattuSummaryModelView> vattus)
        {
            //TODO: should use bulk insert linq. timeless.
            try
            {
                string bulk_insert = string.Empty;
                foreach (XincapvattuSummaryModelView vattu in vattus)
                {
                    DateTime today = DateTime.Today;
                    string sub_insert = "INSERT INTO Supply_tieuhao(supplyid, departmentid, [date], quantity, used, thuhoi) VALUES (" +
                        $"'{vattu.SupplyId}','{vattu.DepartmentId}','{today}',{vattu.SupplyQuantity}, 0, 0);";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                }
                context.Database.ExecuteSqlCommand(bulk_insert);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<XincapvattuDepartmentSummaryModelView> GetDepartments()
        {
            var departments = context.Database.SqlQuery<XincapvattuDepartmentSummaryModelView>("SELECT " +
                "department_id DepartmentId, department_name DepartmentName, department_type DepartmentType " +
                "FROM Department").ToList();
            return departments;
        }

        public IList<XincapvattuSummaryModelView> GetVattus(string departmentId)
        {
            string query = $"SELECT CONCAT(tmp.DepartmentId, '_', tmp.SupplyId) Id, tmp.DepartmentId, tmp.SupplyId, tmp.SupplyAverage, tmp.SupplyPlan, s.supply_name SupplyName, s.unit SupplyUnit, 0 AS SupplyQuantity  FROM (SELECT DISTINCT '{departmentId}' DepartmentId, supplyid SupplyId, sum(dinh_muc) SupplyAverage, sum(quantity_plan) SupplyPlan FROM SupplyPlan WHERE departmentid='{departmentId}' and [date] >= (SELECT MAX([date]) FROM SupplyPlan WHERE departmentid='KT1') GROUP BY supplyid) tmp, Supply s WHERE s.supply_id = tmp.SupplyId";
            var vattus = context.Database.SqlQuery<XincapvattuSummaryModelView>(query).ToList();
            return vattus;
        }
    }
}