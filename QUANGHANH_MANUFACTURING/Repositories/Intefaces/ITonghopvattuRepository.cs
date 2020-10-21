using System.Collections.Generic;
using QUANGHANH_MANUFACTURING.ModelViews;

namespace QUANGHANH_MANUFACTURING.Repositories.Intefaces
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
