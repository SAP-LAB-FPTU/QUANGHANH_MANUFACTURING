//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QUANGHANH2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RepairDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RepairDetail()
        {
            this.RepairEquipments = new HashSet<RepairEquipment>();
        }
    
        public int documentary_repair_id { get; set; }
        public int equipment_repair_status { get; set; }
        public string repair_type { get; set; }
        public string repair_reason { get; set; }
        public System.DateTime finish_date_plan { get; set; }
        public int documentary_id { get; set; }
        public string equipment_id { get; set; }
        public string attach_to { get; set; }
        public int quantity { get; set; }
        public string department_id_from { get; set; }
        public bool is_visible { get; set; }
    
        public virtual Documentary Documentary { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Equipment Equipment1 { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RepairEquipment> RepairEquipments { get; set; }
    }
}
