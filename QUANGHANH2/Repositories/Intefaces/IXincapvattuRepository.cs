using QUANGHANH2.ModelViews;
using System.Collections.Generic;


namespace QUANGHANH2.Repositories.Intefaces
{
    public interface IXincapvattuRepository
    {
        IList<XincapvattuModelView> Vattus();

        bool CreateVattus(IList<XincapvattuModelView> vattus);
    }
}
