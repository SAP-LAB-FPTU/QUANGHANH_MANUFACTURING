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
    
    public partial class Documentary_liquidation_details
    {
        public int equipment_liquidation_status { get; set; }
        public string buyer { get; set; }
        public string documentary_id { get; set; }
        public string equipmentId { get; set; }
    
        public virtual Documentary Documentary { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
