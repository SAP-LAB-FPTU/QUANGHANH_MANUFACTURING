using System.Collections.Generic;
using QUANGHANH_MANUFACTURING.ModelViews;

namespace QUANGHANH_MANUFACTURING.Repositories.Intefaces
{
    public interface IXincapvattuSummaryRepository
    {
         IList<XincapvattuSummaryModelViewVer2> GetVattus(string departmentId);
        
        //IList<EquipmentDb> GetVattus(string departmentId);

        bool CreateSupplyConsumable(IList<XincapvattuSummaryModelView> vattus,string departmentid);

        IList<XincapvattuDepartmentSummaryModelView> GetDepartments();

        bool HasProvided(string departmentId);
    }
}
