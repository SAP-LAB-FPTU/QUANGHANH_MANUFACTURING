using QUANGHANH2.ModelViews;
using System.Collections.Generic;

namespace QUANGHANH2.Repositories.Intefaces
{
    public interface ITieuhaoRepository
    {
        List<TieuhaoModelView> GetDetails(TieuhaoSearchModelView search);
    }
}
