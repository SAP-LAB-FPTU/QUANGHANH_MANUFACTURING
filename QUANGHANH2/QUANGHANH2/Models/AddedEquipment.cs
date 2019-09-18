using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class AddedEquipment
    {
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }
        public string supplier { get; set; }
        public System.DateTime date_import { get; set; }
        public double depreciation_estimate { get; set; }
        public double depreciation_present { get; set; }
        public System.DateTime durationOfInspection { get; set; }
        public System.DateTime durationOfInsurance { get; set; }
        public System.DateTime usedDay { get; set; }
        public System.DateTime nearest_Maintenance_Day { get; set; }
        public int total_operating_hours { get; set; }
        public string current_Status { get; set; }
        public string fabrication_number { get; set; }
        public string quality_type { get; set; }
        public string input_channel { get; set; }
        public string Equipment_category_id { get; set; }
        public string department_id { get; set; }
    }
}