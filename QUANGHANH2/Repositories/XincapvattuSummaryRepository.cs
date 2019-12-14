using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                //Truncate Table to delete all old records.
                //Check for NULL.

                try
                {
                    string bulk_insert = string.Empty;
                   // DateTime today = DateTime.Today;
                    foreach (XincapvattuSummaryModelView vattu in vattus)
                    {
                        string sub_insert = $"  if exists (select * from Supply_DuPhong  where supply_id='{vattu.SupplyId}' and equipmentId='{vattu.Equipmentid}') " +
                                            "begin " +
                                           " update Supply_DuPhong set " +
                                           $"quantity = (select quantity where supply_id='{vattu.SupplyId}' and equipmentId='{vattu.Equipmentid}')+{vattu.SupplyQuantity} " +
                                           $"where supply_id = '{vattu.SupplyId}' and equipmentId = '{vattu.Equipmentid}' " +
                                           "end " +
                                           "else " +
                                           "begin " +
                                           $"insert into Supply_DuPhong(supply_id, equipmentId, quantity) VALUES('{vattu.SupplyId}', '{vattu.Equipmentid}', {vattu.SupplyQuantity}) " +
                                          "end ;" +
                                          $" update Supplyplan set quantity={vattu.SupplyQuantity}, date=getdate() where id={vattu.Id} ;";
                        bulk_insert = string.Concat(bulk_insert, sub_insert);

                    }

                    context.Database.ExecuteSqlCommand(bulk_insert);
                    context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
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
            if (HasProvided(departmentId))
            {
                //string query = $"SELECT CONCAT(tmp.DepartmentId, '_', tmp.SupplyId) Id, tmp.DepartmentId, tmp.SupplyId, tmp.SupplyAverage, tmp.SupplyPlan, s.supply_name SupplyName, s.unit SupplyUnit, 0 AS SupplyQuantity " +
                //$"FROM (SELECT DISTINCT '{departmentId}' DepartmentId, supplyid SupplyId, sum(dinh_muc) SupplyAverage, sum(quantity_plan) SupplyPlan FROM SupplyPlan WHERE departmentid='{departmentId}' AND [date] >= (SELECT MAX([date]) FROM SupplyPlan WHERE departmentid='{departmentId}' AND [status] = 1) AND [status] = 1 GROUP BY supplyid) tmp, Supply s " +
                //$"WHERE s.supply_id = tmp.SupplyId";
                //        string query = "select supp.equipmentid,e.equipment_name,supp.supplyid, s.supply_name,supp.dinh_muc, s.unit ,supp.quantity_plan "+
                //"from Supply s inner join SupplyPlan supp on s.supply_id = supp.supplyid inner join Equipment e on supp.equipmentid = e.equipmentId where" +
                //            " supp.departmentid = 'PXdl2' and month(date) = month(getdate()) and status = 1";
                vattus = context.Database.SqlQuery<XincapvattuSummaryModelViewVer2>("select supp.id Id,supp.equipmentId Equipmentid,e.equipment_name,supp.supplyid, s.supply_name SupplyName,supp.dinh_muc SupplyAverage, s.unit SupplyUnit ,supp.quantity_plan SupplyPlan " +
        " from Supply s inner join SupplyPlan supp on s.supply_id = supp.supplyid inner join Equipment e on supp.equipmentid = e.equipmentId where" +
                    " supp.departmentid = @departmentid and month(date) = month(getdate()) and status = 1", new SqlParameter("departmentid", departmentId)).ToList();
            }
            return vattus;
        }


        public bool HasProvided(string departmentId)
        {

            return context.Database.SqlQuery<int>($"SELECT COUNT(1) from SupplyPlan WHERE departmentid = '{departmentId}' " +
          "AND YEAR([date]) = YEAR(GETDATE()) AND MONTH([date]) = MONTH(Getdate())and quantity = 0").First() > 0;
        }

    }



}