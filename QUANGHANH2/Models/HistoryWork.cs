using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class HistoryWork
    {
        public string MaNV { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public string BoPhan { get; set; }
        public DateTime NgayDiLamGanNhat { get; set; }
        public HistoryWork() { }
        public HistoryWork(string maNV, string ten, string gioiTinh, DateTime ngaySinh, string diaChi, string chucVu, string boPhan, DateTime ngayDiLamGanNhat)
        {
            MaNV = maNV;
            Ten = ten;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            ChucVu = chucVu;
            BoPhan = boPhan;
            NgayDiLamGanNhat = ngayDiLamGanNhat;
        }
    }
}