namespace QUANGHANH_MANUFACTURING.Models
{
    public class Equipment_InsuranceDB : Insurance
    {
        public string equipment_name { get; set; }
        public string statusname { get; set; }
        public string stringStartDate { get; set; }
        public string stringEndDate { get; set; }
    }
}