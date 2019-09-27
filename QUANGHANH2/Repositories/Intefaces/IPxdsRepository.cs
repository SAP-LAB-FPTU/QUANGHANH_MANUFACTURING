using QUANGHANH2.ModelViews;
using System;
using System.Collections.Generic;

namespace QUANGHANH2.Repositories.Intefaces
{
    public interface IPxdsRepository
    {
        IList<PxdsModelView> GetDetails();

        bool SaveMealRegistration(IList<PxdsModelView> details);

        bool UpdateMealRegistration(IList<PxdsModelView> details);

        bool HasMealRegistration(DateTime mondayOfNextWeek);

        DateTime StartOfNextWeek(DateTime dt, DayOfWeek startOfWeek);
    }
}
