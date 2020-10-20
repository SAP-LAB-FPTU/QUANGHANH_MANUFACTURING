using System;

namespace QUANGHANH_MANUFACTURING.Models
{
    public class HoSoNhanVien
    {

        public string MaNV { get; set; }
        public string Ten { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string NguoiGiaoHoSo { get; set; }
        public Nullable<System.DateTime> NgayNhanHoSo { get; set; }
        public string NguoiGiuHoSo { get; set; }

        public string CamKetTuyenDung { get; set; }
        public string QuyetDinhTiepNhanDVC { get; set; }
        public Nullable<System.DateTime> NgayQDTiepNhan { get; set; }
        public Nullable<System.DateTime> NgayDiLam { get; set; }
        public string DonViKyQuyetDinhTiepNhan { get; set; }
        public string QuyetDinhChamDut { get; set; }
        public Nullable<System.DateTime> NgayQDChamDut { get; set; }
        public Nullable<System.DateTime> NgayChamDut { get; set; }
        public string DonViKyChamDut { get; set; }

        public HoSoNhanVien(string maNV, string ten, DateTime ngaySinh, string nguoiGiaoHoSo, DateTime ngayNhanHoSo, string nguoiGiuHoSo, string camKetTuyenDung, string quyetDinhTiepNhanDVC, DateTime ngayQDTiepNhan, DateTime ngayDiLam, string donViKyQuyetDinhTiepNhan, string quyetDinhChamDut, DateTime ngayQDChamDut, DateTime ngayChamDut, string donViKyChamDut)
        {
            MaNV = maNV;
            Ten = ten;
            NgaySinh = ngaySinh;
            NguoiGiaoHoSo = nguoiGiaoHoSo;
            NgayNhanHoSo = ngayNhanHoSo;
            NguoiGiuHoSo = nguoiGiuHoSo;
            CamKetTuyenDung = camKetTuyenDung;
            QuyetDinhTiepNhanDVC = quyetDinhTiepNhanDVC;
            NgayQDTiepNhan = ngayQDTiepNhan;
            NgayDiLam = ngayDiLam;
            DonViKyQuyetDinhTiepNhan = donViKyQuyetDinhTiepNhan;
            QuyetDinhChamDut = quyetDinhChamDut;
            NgayQDChamDut = ngayQDChamDut;
            NgayChamDut = ngayChamDut;
            DonViKyChamDut = donViKyChamDut;
        }

        public HoSoNhanVien() { }
    }
}