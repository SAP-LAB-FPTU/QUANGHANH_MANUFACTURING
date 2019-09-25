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
        public QUANGHANHABCEntities context { get; set; }

        public bool CreateVattus(IList<XincapvattuModelView> vattus)
        {
            //TODO: should use bulk insert linq. timeless.
            try
            {
                string bulk_insert = string.Empty;
                DateTime today = DateTime.Today;
                foreach (XincapvattuModelView vattu in vattus)
                {
                    string sub_insert = $"INSERT INTO SupplyPlan(supplyid, departmentid, equipmentid, [date], dinh_muc, quantity_plan, quantity) VALUES (" +
                        $"'{vattu.SupplyId}','{vattu.DepartementId}','{vattu.EquipmentId}','{today}',{vattu.SupplyAverage},{vattu.SupplyPlan},{0});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                }
                context.Database.ExecuteSqlCommand(bulk_insert);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IList<XincapvattuModelView> Vattus()
        {
            // DISTINCT for data duplication.
            var vattus = context.Database.SqlQuery<XincapvattuModelView>(
                "SELECT DISTINCT CONCAT(e.equipmentId, '_', s.supply_id) Id, e.department_id DepartementId , e.Equipment_category_id EquipmentCategoryId, e.equipmentId EquipmentId, e.equipment_name EquipmentName, i.detail_location [DetailLocation], s.supply_id SupplyId, s.supply_name SupplyName, s.unit SupplyUnit, 0 SypplyAverage, 0 SypplyPlan FROM Supply s, Supply_Documentary_Equipment sde, Equipment e, Incident i WHERE sde.equipmentId = e.equipmentId AND s.supply_id = sde.supply_id AND i.department_id = e.department_id").ToList();
            return vattus;
        }
    }
}