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
    
    public partial class ChamDut_NhanVien
    {
        public string SoQuyetDinh { get; set; }
        public string MaNV { get; set; }
        public string LoaiChamDut { get; set; }
        public Nullable<System.DateTime> NgayChamDut { get; set; }
        public string DonViKhiChamDut { get; set; }
    
        public virtual QuyetDinh QuyetDinh { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
