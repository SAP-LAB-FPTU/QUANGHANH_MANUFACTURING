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
    
    public partial class Equipment_Inspection
    {
        public int inspect_id { get; set; }
        public string equipmentId { get; set; }
        public System.DateTime inspect_expected_date { get; set; }
        public Nullable<System.DateTime> inspect_real_date { get; set; }
    
        public virtual Equipment Equipment { get; set; }
    }
}
