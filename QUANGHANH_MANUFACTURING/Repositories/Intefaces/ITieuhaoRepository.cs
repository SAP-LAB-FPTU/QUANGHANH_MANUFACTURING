using System.Collections.Generic;
using QUANGHANH_MANUFACTURING.ModelViews;

namespace QUANGHANH_MANUFACTURING.Repositories.Intefaces
{
    public interface ITieuhaoRepository
    {
        List<TieuhaoModelView> GetDetails(TieuhaoSearchModelView search);
        List<TieuhaoModelView> GetSummary(TieuhaoSearchModelView search);
    }
}
