using QUANGHANH2.ModelViews;
using System.Collections.Generic;


namespace QUANGHANH2.Repositories.Intefaces
{
    public interface IXincapvattuSummaryRepository
    {
         IList<XincapvattuSummaryModelViewVer2> GetVattus(string departmentId);
        //IList<EquipmentDb> GetVattus(string departmentId);

        bool CreateSupplyConsumable(IList<XincapvattuSummaryModelView> vattus);

        IList<XincapvattuDepartmentSummaryModelView> GetDepartments();

        bool HasProvided(string departmentId);
    }
}
