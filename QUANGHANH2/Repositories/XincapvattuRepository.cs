using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace QUANGHANH2.Repositories
{
    public class XincapvattuRepository : IXincapvattuRepository
    {
        [Dependency]
        public QUANGHANHABCEntities Context { get; set; }

        public bool CreateVattus(IList<XincapvattuModelView> vattus, int status = 1)
        {
            //TODO: should use bulk insert linq. timeless.
            try
            {
                string bulk_insert = string.Empty;
                DateTime today = DateTime.Today;
                foreach (XincapvattuModelView vattu in vattus)
                {
                    string sub_insert = $"INSERT INTO SupplyPlan(supplyid, departmentid, equipmentid, [date], dinh_muc, quantity_plan, quantity, [status]) VALUES (" +
                        $"'{vattu.SupplyId}','{vattu.DepartementId}','{vattu.EquipmentId}','{today}',{vattu.SupplyAverage},{vattu.SupplyPlan},{0},{status});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                }
                Context.Database.ExecuteSqlCommand(bulk_insert);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool UpdateVattuStatus(IList<XincapvattuModelView> vattus)
        {
            //TODO: should use bulk update linq. timeless.
            try
            {
                string bulk_update = string.Empty;
                DateTime today = DateTime.Today;
                foreach (XincapvattuModelView vattu in vattus)
                {
                    string sub_update = $"UPDATE SupplyPlan SET dinh_muc = {vattu.SupplyAverage}, quantity_plan = {vattu.SupplyPlan}, [date] = '{today}', [status] = 1 WHERE id = {vattu.Id}";
                    bulk_update = string.Concat(bulk_update, sub_update);
                }
                Context.Database.ExecuteSqlCommand(bulk_update);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateVattus(IList<XincapvattuModelView> vattus)
        {
            //TODO: should use bulk update linq. timeless.
            try
            {
                
                if (HasDraft())
                {
                    string bulk_update = string.Empty;
                    DateTime today = DateTime.Today;
                    foreach (XincapvattuModelView vattu in vattus)
                    {
                        string sub_update = $"UPDATE SupplyPlan SET dinh_muc = {vattu.SupplyAverage}, quantity_plan = {vattu.SupplyPlan}, [date] = '{today}' WHERE id = {vattu.Id};";
                        bulk_update = string.Concat(bulk_update, sub_update);
                    }
                    Context.Database.ExecuteSqlCommand(bulk_update);
                }
                else
                {
                    CreateVattus(vattus, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<XincapvattuModelView> Vattus()
        {
            var vattus = new List<XincapvattuModelView>();
            // DISTINCT for data duplication.
            if (!HasSent())
            {
                string query = string.Empty;
                if (HasDraft())
                {
                    var today = DateTime.Now;
                    query = $"SELECT DISTINCT CAST(sp.id AS VARCHAR(10)) Id, sp.departmentid DepartmentId, sp.supplyid SupplyId, sp.equipmentid EquipmentId, sp.dinh_muc SupplyAverage, sp.quantity_plan SupplyPlan, e.Equipment_category_id EquipmentCategoryId, i.detail_location DetailLocation, s.supply_name SupplyName, s.unit SupplyUnit, e.equipment_name EquipmentName " +
                        $"FROM SupplyPlan sp, Equipment e, Incident i, Supply s " +
                        $"WHERE sp.[status] = 0 AND " +
                        $"YEAR(sp.[date]) = ${today.Year} AND " +
                        $"MONTH(sp.[date]) = ${today.Month} AND " +
                        $"e.equipmentId = sp.equipmentid AND " +
                        $"e.department_id = i.department_id AND " +
                        $"s.supply_id = sp.supplyid " +
                        $"ORDER BY DepartmentId";
                }
                else
                {
                    query = "SELECT DISTINCT CONCAT(e.equipmentId, '_', s.supply_id) Id, e.department_id DepartementId , e.Equipment_category_id EquipmentCategoryId, e.equipmentId EquipmentId, e.equipment_name EquipmentName, i.detail_location [DetailLocation], s.supply_id SupplyId, s.supply_name SupplyName, s.unit SupplyUnit, 0 SypplyAverage, 0 SypplyPlan " +
                        "FROM Supply s, Supply_Documentary_Equipment sde, Equipment e, Incident i " +
                        "WHERE sde.equipmentId = e.equipmentId AND s.supply_id = sde.supply_id AND " +
                        "i.department_id = e.department_id";
                }
                vattus = Context.Database.SqlQuery<XincapvattuModelView>(query).ToList();
            }
            return vattus;
        }

        public bool HasDraft()
        {
            var today = DateTime.Now;
            return Context.Database.SqlQuery<int>($"SELECT COUNT(1) FROM SupplyPlan s WHERE YEAR(s.[date]) = {today.Year} AND MONTH(s.[date]) = {today.Month} AND s.[status] = 0").First() > 0;
        }

        public bool HasSent()
        {
            var today = DateTime.Now;
            return Context.Database.SqlQuery<int>($"SELECT COUNT(1) FROM SupplyPlan s WHERE YEAR(s.[date]) = {today.Year} AND MONTH(s.[date]) = {today.Month} AND s.[status] = 1").First() > 0;
        }
    }
}