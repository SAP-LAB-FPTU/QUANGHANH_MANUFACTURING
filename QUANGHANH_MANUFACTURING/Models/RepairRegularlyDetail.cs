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
    
    public partial class RepairRegularlyDetail
    {
        public int maintain_detail_id { get; set; }
        public int maintain_id { get; set; }
        public string supplyid { get; set; }
        public int used { get; set; }
        public int thuhoi { get; set; }
    
        public virtual RepairRegularly RepairRegularly { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
