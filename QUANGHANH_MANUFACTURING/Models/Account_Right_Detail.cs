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
    
    public partial class Account_Right_Detail
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int RightID { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Account_Right Account_Right { get; set; }
    }
}
