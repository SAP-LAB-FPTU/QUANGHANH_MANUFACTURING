using System.Collections.Generic;

namespace QUANGHANH_MANUFACTURING.Models
{
    public class NhanVien_Extend : NhanVien
    {
        public List<Chung_Chi_Nhan_Vien_Extend> ChungChiNhiemVu { get; set; }
        public List<int> MaNhiemVu { get; set; }
        public NhanVien_Extend()
        {
            ChungChiNhiemVu = new List<Chung_Chi_Nhan_Vien_Extend>();
            MaNhiemVu = new List<int>();
        }

    }
}