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

        public bool CreateSupplyConsumable(IList<XincapvattuSummaryModelView> vattus,String departmentid)
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
                            string sub_insert = $" update Supplyplan set quantity_provide={vattu.SupplyQuantity}, date=getdate() where id={vattu.Id} ;";
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
                if (departmentId == "CDVT")
                    vattus = context.Database.SqlQuery<XincapvattuSummaryModelViewVer2>(@"select supp.id Id,supp.equipmentId Equipmentid,supp.supplyid, s.supply_name SupplyName, s.unit SupplyUnit ,supp.quantity_plan SupplyPlan  
         from Supply s inner
         join SupplyPlan supp on s.supply_id = supp.supplyid where
           supp.departmentid = 'cdvt' and month(date) = month(getdate()) and status = 1").ToList();
                
                else
                vattus = context.Database.SqlQuery<XincapvattuSummaryModelViewVer2>("select supp.id Id,supp.equipmentId Equipmentid,e.equipment_name,supp.supplyid, s.supply_name SupplyName,supp.dinh_muc SupplyAverage, s.unit SupplyUnit ,supp.quantity_plan SupplyPlan,(case when su.quantity is null then 0 else su.quantity end) SupplyRemaining " +
                    " from Supply s inner join SupplyPlan supp on s.supply_id = supp.supplyid left join Supply_DuPhong_SCTX su on supp.equipmentid=su.equipmentId and supp.supplyid=su.supply_id inner join Equipment e on supp.equipmentid = e.equipmentId where" +
                    " supp.departmentid = @departmentid and month(date) = month(getdate()) and status = 1 order by equipmentid asc", new SqlParameter("departmentid", departmentId)).ToList();
            }
            return vattus;
        }


        public bool HasProvided(string departmentId)
        {

            return context.Database.SqlQuery<int>($"SELECT COUNT(1) from SupplyPlan WHERE departmentid = '{departmentId}' " +
          "AND YEAR([date]) = YEAR(GETDATE()) AND MONTH([date]) = MONTH(Getdate())and quantity_provide   = 0").First() > 0;
        }

    }



}