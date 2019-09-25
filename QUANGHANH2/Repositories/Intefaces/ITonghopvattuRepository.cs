

using QUANGHANH2.ModelViews;
using System.Collections.Generic;

namespace QUANGHANH2.Repositories.Intefaces
{
    public interface ITonghopvattuRepository
    {
        IList<TonghopvattuDepartmentModelView> GetDepartments();
        IList<TonghopvattuDetailModelView> GetDetails(TonghopVattuSearchModelView search);

        IList<TonghopvattuSummaryModelView> GetSummary(TonghopVattuSearchModelView search);
    }
}
