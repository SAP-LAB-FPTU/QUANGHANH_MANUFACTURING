using QUANGHANH2.ModelViews;
using System.Collections.Generic;


namespace QUANGHANH2.Repositories.Intefaces
{
    public interface IXincapvattuSummaryRepository
    {
        IList<XincapvattuSummaryModelView> GetVattus(string departmentId);

        bool CreateSupplyConsumable(IList<XincapvattuSummaryModelView> vattus);

        IList<XincapvattuDepartmentSummaryModelView> GetDepartments();
    }
}
