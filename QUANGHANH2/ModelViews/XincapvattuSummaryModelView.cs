namespace QUANGHANH2.ModelViews
{
    public class XincapvattuSummaryModelView
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string SupplyUnit { get; set; }
        public double SupplyAverage { get; set; }
        public int SupplyPlan { get; set; }
        public int SupplyQuantity { get; set; }
    }
    public class XincapvattuSummaryModelViewVer2
    {
        public string Id { get; set; }
        public string Equipmentid { get; set; }
        public string equipment_name { get; set; }
        public string DepartmentId { get; set; }
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string SupplyUnit { get; set; }
        public double SupplyAverage { get; set; }
        public int SupplyPlan { get; set; }
        public int SupplyQuantity { get; set; }
    }
}