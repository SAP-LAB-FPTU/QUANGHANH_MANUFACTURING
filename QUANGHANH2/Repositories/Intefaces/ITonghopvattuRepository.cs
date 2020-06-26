

using QUANGHANH2.ModelViews;
using System.Collections.Generic;

namespace QUANGHANH2.Repositories.Intefaces
{
    public interface ITonghopvattuRepository
    {
        IList<TonghopvattuDepartmentModelView> GetDepartments();
        IList<TonghopvattuDetailModelView> GetDetails(TonghopVattuSearchModelView search, string sortColumnName, string sortDirection, int start, int length);

        IList<TonghopvattuSummaryModelView> GetSummary(TonghopVattuSearchModelView search, string sortColumnName, string sortDirection, int start, int length);
        IList<TonghopvattuDetailModelView> ExcelDetails(TonghopVattuSearchModelView search);
        IList<TonghopvattuSummaryModelView> ExcelSummary(TonghopVattuSearchModelView search);
        int CountDetails(TonghopVattuSearchModelView search);
        int CountSummary(TonghopVattuSearchModelView search);
    }
}
