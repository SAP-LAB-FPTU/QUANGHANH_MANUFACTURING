using System;

namespace QUANGHANH2.ModelViews
{
    public class PxdsModelView
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int RegMonday { get; set; }
        public int RegTuesday { get; set; }
        public int RegWednesday { get; set; }
        public int RegThursday { get; set; }
        public int RegFriday { get; set; }
        public int RegMondayPlan { get; set; }
        public int RegTuesdayPlan { get; set; }
        public int RegWednesdayPlan { get; set; }
        public int RegThursdayPlan { get; set; }
        public int RegFridayPlan { get; set; }
    }

    public class PxdsMealRegistrationModelView
    {
        public int Id { get; set; }
        public string DepartmentId { get; set; }
        public DateTime DateRegistration { get; set; }
        public int NumOfMealRegistrations { get; set; }
        public int NumOfMealRegistrationsPlan { get; set; }
    }
}