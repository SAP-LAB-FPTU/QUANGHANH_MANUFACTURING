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
    
    public partial class Activity
    {
        public int activityid { get; set; }
        public System.DateTime date { get; set; }
        public string equipmentid { get; set; }
        public string activityname { get; set; }
        public double hours_per_day { get; set; }
        public double quantity { get; set; }
    
        public virtual Equipment Equipment { get; set; }
    }
}