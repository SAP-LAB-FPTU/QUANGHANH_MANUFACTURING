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
    
    public partial class Documentary_camera_repair_details
    {
        public int documentary_id { get; set; }
        public string camera_id { get; set; }
        public string repair_requirement { get; set; }
        public string note { get; set; }
    
        public virtual Camera Camera { get; set; }
        public virtual Documentary Documentary { get; set; }
    }
}
