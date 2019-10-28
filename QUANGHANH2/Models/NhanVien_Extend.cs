using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
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