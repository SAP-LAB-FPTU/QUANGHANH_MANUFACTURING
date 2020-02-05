using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class InsideExcel
    {
        public string MaNV { get; set; }
        public string Ten { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SoBHXH { get; set; }
        public string SoCMND { get; set; }

        public string SoDienThoai { get; set; }
        public string QueQuan { get; set; }
        public string NoiOHienTai { get; set; }
        public string TrinhDoHocVan { get; set; }
        public Nullable<System.DateTime> NgayNhanHoSo { get; set; }
        public string NguoiGiaoHoSo { get; set; }

        public string NguoiGiuHoSo { get; set; }
        public string CamKetTuyenDung { get; set; }
        public string QuyetDinhTiepNhanDVC { get; set; }
        public string QDChamDutHopDongDVC { get; set; }
        public string NLDHocTheoChiTieuCTDT { get; set; }
        public string NguoiBanGiaoBangNhapKho { get; set; }
        public string KieuQuyetDinhTiepNhanDVC { get; set; }
        public Nullable<System.DateTime> NgayQuyetDinhTuyenDung { get; set; }
        public Nullable<System.DateTime> NgayDiLam { get; set; }
        public string DonViKyQuyetDinhTiepNhan { get; set; }
        public string KieuQuyetDinhChamDutDVC { get; set; }
        public Nullable<System.DateTime> NgayQuyetDinhChamDut { get; set; }
        public Nullable<System.DateTime> NgayChamDut { get; set; }
        public string DonViKyQuyetDinhChamDut { get; set; }
        public string TenGiayTo { get; set; }
        public string KieuGiayTo { get; set; }
        public string SoHieuBangCap { get; set; }
        public string TenBangCap { get; set; }
        public string KieuBangCap { get; set; }
        public string LoaiBangCap { get; set; }
        public string TenTruong { get; set; }
        public string TenChuyenNganh { get; set; }
        public string TenNganh { get; set; }
        public Nullable<System.DateTime> NgayCapBang { get; set; }
        public string ThoiHanBang { get; set; }
        public string SoHieuChungChi { get; set; }
        public string TenChungChi { get; set; }
        public string KieuChungChi { get; set; }
        public Nullable<System.DateTime> NgayCapChungChi { get; set; }
        public string LoaiGiaDinh { get; set; }
        public string MoiQuanHe { get; set; }
        public string TenNguoiQH { get; set; }
        public Nullable<System.DateTime> NgaySinhQH { get; set; }
        public string LyLich { get; set; }
        public string NamBoSung { get; set; }

        public InsideExcel() { }

        public InsideExcel(string maNV, string ten, DateTime? ngaySinh, string soBHXH, string soCMND, string soDienThoai, string queQuan, string noiOHienTai, string trinhDoHocVan, DateTime? ngayNhanHoSo, string nguoiGiaoHoSo, string nguoiGiuHoSo, string camKetTuyenDung, string quyetDinhTiepNhanDVC, string qDChamDutHopDongDVC, string nLDHocTheoChiTieuCTDT, string nguoiBanGiaoBangNhapKho, string kieuQuyetDinhTiepNhanDVC, DateTime? ngayQuyetDinhTuyenDung, DateTime? ngayDiLam, string donViKyQuyetDinhTiepNhan, string kieuQuyetDinhChamDutDVC, DateTime? ngayQuyetDinhChamDut, DateTime? ngayChamDut, string donViKyQuyetDinhChamDut, string tenGiayTo, string kieuGiayTo, string soHieuBangCap, string tenBangCap, string kieuBangCap, string loaiBangCap, string tenTruong, string tenChuyenNganh, string tenNganh, DateTime? ngayCapBang, string thoiHanBang, string soHieuChungChi, string tenChungChi, string kieuChungChi, DateTime? ngayCapChungChi, string loaiGiaDinh, string moiQuanHe, string tenNguoiQH, DateTime? ngaySinhQH, string lyLich, string namBoSung)
        {
            MaNV = maNV;
            Ten = ten;
            NgaySinh = ngaySinh;
            SoBHXH = soBHXH;
            SoCMND = soCMND;
            SoDienThoai = soDienThoai;
            QueQuan = queQuan;
            NoiOHienTai = noiOHienTai;
            TrinhDoHocVan = trinhDoHocVan;
            NgayNhanHoSo = ngayNhanHoSo;
            NguoiGiaoHoSo = nguoiGiaoHoSo;
            NguoiGiuHoSo = nguoiGiuHoSo;
            CamKetTuyenDung = camKetTuyenDung;
            QuyetDinhTiepNhanDVC = quyetDinhTiepNhanDVC;
            QDChamDutHopDongDVC = qDChamDutHopDongDVC;
            NLDHocTheoChiTieuCTDT = nLDHocTheoChiTieuCTDT;
            NguoiBanGiaoBangNhapKho = nguoiBanGiaoBangNhapKho;
            KieuQuyetDinhTiepNhanDVC = kieuQuyetDinhTiepNhanDVC;
            NgayQuyetDinhTuyenDung = ngayQuyetDinhTuyenDung;
            NgayDiLam = ngayDiLam;
            DonViKyQuyetDinhTiepNhan = donViKyQuyetDinhTiepNhan;
            KieuQuyetDinhChamDutDVC = kieuQuyetDinhChamDutDVC;
            NgayQuyetDinhChamDut = ngayQuyetDinhChamDut;
            NgayChamDut = ngayChamDut;
            DonViKyQuyetDinhChamDut = donViKyQuyetDinhChamDut;
            TenGiayTo = tenGiayTo;
            KieuGiayTo = kieuGiayTo;
            SoHieuBangCap = soHieuBangCap;
            TenBangCap = tenBangCap;
            KieuBangCap = kieuBangCap;
            LoaiBangCap = loaiBangCap;
            TenTruong = tenTruong;
            TenChuyenNganh = tenChuyenNganh;
            TenNganh = tenNganh;
            NgayCapBang = ngayCapBang;
            ThoiHanBang = thoiHanBang;
            SoHieuChungChi = soHieuChungChi;
            TenChungChi = tenChungChi;
            KieuChungChi = kieuChungChi;
            NgayCapChungChi = ngayCapChungChi;
            LoaiGiaDinh = loaiGiaDinh;
            MoiQuanHe = moiQuanHe;
            TenNguoiQH = tenNguoiQH;
            NgaySinhQH = ngaySinhQH;
            LyLich = lyLich;
            NamBoSung = namBoSung;
        }
    }
}