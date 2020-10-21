namespace QUANGHANH_MANUFACTURING.Models
{
    public class Documentary_revoke_detailsDB : Documentary_revoke_details
    {
        public string equipment_name { get; set; }
        public string statusAndEquip { get; set; }
        public string department_name { get; set; }
        public string department_id { get; set; }
        public string reason { get; set; }
        public int order_number { get; set; }
        public string documentary_code { get; set; }
        public string idAndEquip { get; set; }
    }
}