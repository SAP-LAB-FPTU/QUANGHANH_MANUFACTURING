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
    
    public partial class ChiTiet_ThucHien_TieuChi_TheoNgay
    {
        public int HeaderID { get; set; }
        public int MaTieuChi { get; set; }
        public Nullable<int> SanLuong { get; set; }
        public Nullable<int> KeHoach { get; set; }
    
        public virtual header_ThucHienTheoNgay header_ThucHienTheoNgay { get; set; }
        public virtual TieuChi TieuChi { get; set; }
    }
}
