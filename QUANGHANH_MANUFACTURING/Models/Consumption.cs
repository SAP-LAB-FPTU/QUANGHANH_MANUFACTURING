//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QUANGHANH_MANUFACTURING.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consumption
    {
        public string supplyid { get; set; }
        public string departmentid { get; set; }
        public System.DateTime date { get; set; }
        public int quantity { get; set; }
        public int used { get; set; }
        public int thuhoi { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
