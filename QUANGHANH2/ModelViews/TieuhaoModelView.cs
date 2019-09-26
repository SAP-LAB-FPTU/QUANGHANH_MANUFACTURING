namespace QUANGHANH2.ModelViews
{
    public class TieuhaoModelView
    {
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int SupplyQuantity { get; set; }
        public string SupplyUnit { get; set; }
        public int SupplyEviction { get; set; }
        public int SupplyInventory { get; set; }
        public int SupplyUsed { get; set; }
    }

    public class TieuhaoSearchModelView
    {
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string DepartmentId { get; set; }

        public string DeparmentName { get; set; }
    }
}