namespace QUANGHANH_MANUFACTURING.Models
{
    public class equipmentExtend : Equipment
    {
        public string department_name { get; set; }
        public int order_number { get; set; }
        public string statusname { get; set; }
    }
}