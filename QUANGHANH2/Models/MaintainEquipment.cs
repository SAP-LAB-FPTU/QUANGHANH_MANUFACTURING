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
    
    public partial class MaintainEquipment
    {
        public int supply_documentary_equipment_id { get; set; }
        public int documentary_maintain_id { get; set; }
        public string supply_id { get; set; }
        public int quantity_plan { get; set; }
        public int quantity_in { get; set; }
        public int quantity_used { get; set; }
        public int quantity_out { get; set; }
        public string equipment_id { get; set; }
    
        public virtual MaintainDetail MaintainDetail { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
