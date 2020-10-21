using System;
using System.Collections.Generic;
using QUANGHANH_MANUFACTURING.ModelViews;

namespace QUANGHANH_MANUFACTURING.Repositories.Intefaces
{
    public interface IPxdsRepository
    {
        IList<PxdsModelView> GetDetails();

        bool SaveMealRegistration(IList<PxdsModelView> details);

        bool UpdateMealRegistration(IList<PxdsModelView> details);

        bool HasMealRegistration(DateTime mondayOfNextWeek);
    }
}
