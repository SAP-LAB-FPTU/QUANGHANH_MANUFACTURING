namespace QUANGHANH_MANUFACTURING.Models
{
    public class Documentary_Improve_DetailDB : Documentary_Improve_Detail
    {
        public string equipment_name { get; set; }
        public string statusAndEquip { get; set; }
        public string department_name { get; set; }
        public string department_id { get; set; }
        public string department_id_to { get; set; }
        public string reason { get; set; }
        public int order_number { get; set; }
        public string documentary_code { get; set; }
        public string idAndEquip { get; set; }
    }
}