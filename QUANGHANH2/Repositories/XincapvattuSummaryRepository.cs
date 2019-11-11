using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                DateTime today = DateTime.Today;
                foreach (XincapvattuSummaryModelView vattu in vattus)
                {
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

        public IList<XincapvattuSummaryModelViewVer2> GetVattus(string departmentId)
        {
            var vattus = new List<XincapvattuSummaryModelViewVer2>();
            if (!HasProvided(departmentId))
            {
                //string query = $"SELECT CONCAT(tmp.DepartmentId, '_', tmp.SupplyId) Id, tmp.DepartmentId, tmp.SupplyId, tmp.SupplyAverage, tmp.SupplyPlan, s.supply_name SupplyName, s.unit SupplyUnit, 0 AS SupplyQuantity " +
                //$"FROM (SELECT DISTINCT '{departmentId}' DepartmentId, supplyid SupplyId, sum(dinh_muc) SupplyAverage, sum(quantity_plan) SupplyPlan FROM SupplyPlan WHERE departmentid='{departmentId}' AND [date] >= (SELECT MAX([date]) FROM SupplyPlan WHERE departmentid='{departmentId}' AND [status] = 1) AND [status] = 1 GROUP BY supplyid) tmp, Supply s " +
                //$"WHERE s.supply_id = tmp.SupplyId";
        //        string query = "select supp.equipmentid,e.equipment_name,supp.supplyid, s.supply_name,supp.dinh_muc, s.unit ,supp.quantity_plan "+
        //"from Supply s inner join SupplyPlan supp on s.supply_id = supp.supplyid inner join Equipment e on supp.equipmentid = e.equipmentId where" +
        //            " supp.departmentid = 'PXdl2' and month(date) = month(getdate()) and status = 1";
                vattus = context.Database.SqlQuery<XincapvattuSummaryModelViewVer2>("select supp.equipmentId Equipmentid,e.equipment_name,supp.supplyid, s.supply_name SupplyName,supp.dinh_muc SupplyAverage, s.unit SupplyUnit ,supp.quantity_plan " +
        "from Supply s inner join SupplyPlan supp on s.supply_id = supp.supplyid inner join Equipment e on supp.equipmentid = e.equipmentId where" +
                    " supp.departmentid = @departmentid and month(date) = month(getdate()) and status = 1",new SqlParameter("departmentid", departmentId)).ToList();
            }
            return vattus;
        }
       

        public bool HasProvided(string departmentId)
        {
            return context.Database.SqlQuery<int>($"DECLARE @max_date_from_sp DATE SET @max_date_from_sp = (SELECT MAX(date) FROM SupplyPlan WHERE departmentid = '{departmentId}') SELECT COUNT(1) from Supply_tieuhao WHERE departmentid = '{departmentId}' AND YEAR([date]) = YEAR(@max_date_from_sp) AND MONTH([date]) = MONTH(@max_date_from_sp)").First() > 0;
        }
    }
  
    

}