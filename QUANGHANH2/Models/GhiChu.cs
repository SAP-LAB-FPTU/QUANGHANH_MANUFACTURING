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
    
    public partial class GhiChu
    {
        public int MaGhiChu { get; set; }
        public int MaThucHien { get; set; }
        public int MaKeHoach { get; set; }
        public string NoiDungGhiChu { get; set; }
    
        public virtual KeHoach_TieuChi KeHoach_TieuChi { get; set; }
        public virtual ThucHien_TieuChi ThucHien_TieuChi { get; set; }
    }
}
