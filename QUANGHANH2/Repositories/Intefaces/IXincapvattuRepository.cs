using QUANGHANH2.ModelViews;
using System.Collections.Generic;


namespace QUANGHANH2.Repositories.Intefaces
{
    public interface IXincapvattuRepository
    {
        IList<XincapvattuModelView> Vattus();
        bool CreateVattus(IList<XincapvattuModelView> vattus, int status=1);
        bool UpdateVattus(IList<XincapvattuModelView> vattus);
        bool UpdateVattuStatus(IList<XincapvattuModelView> vattus);
        bool HasDraft();
        bool HasSent();
    }
}
