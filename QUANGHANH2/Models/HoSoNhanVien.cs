using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class HoSoNhanVien
    {

        public string MaNV { get; set; }
        public string Ten { get; set; }
        public string NgaySinh { get; set; }
        public string NguoiGiaoHoSo { get; set; }
        public DateTime NgayNhanHoSo { get; set; }
        public string NguoiGiuHoSo { get; set; }

        public HoSoNhanVien(string maNV, string ten, string ngaySinh, string nguoiGiaoHoSo, DateTime nguoiNhanHoSo, string nguoiGiuHoSo)
        {
            MaNV = maNV;
            Ten = ten;
            NgaySinh = ngaySinh;
            NguoiGiaoHoSo = nguoiGiaoHoSo;
            NgayNhanHoSo = nguoiNhanHoSo;
            NguoiGiuHoSo = nguoiGiuHoSo;
        }
        public HoSoNhanVien() { }
    }
}