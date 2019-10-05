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
        public Nullable<System.DateTime> NgayQuyetDinhTiepNhanDVC { get; set; }
        public Nullable<System.DateTime> NgayDiLam { get; set; }
        public string DonViKyQuyetDinhTiepNhanDVC { get; set; }
        public string KieuQuyetDinhChamDutDVC { get; set; }
        public Nullable<System.DateTime> NgayQuyetDinhChamDutDVC { get; set; }
        public Nullable<System.DateTime> NgayChamDutDVC { get; set; }
        public string DonViKyQuyetDinhChamDutDVC { get; set; }
        public List<GiayTo> giayTo { get; set; }
        public List<ChiTiet_BangCap_GiayChungNhan> ChiTietBangCapGiayChungNhan { get; set; }
        public List<ChungChi_NhanVien> ChungChiNhanVien { get; set; }
        public List<QuanHeGiaDinh> quanHeGiaDinh { get; set; }
        public List<LichSuBoSungSYLL> syll { get; set; }

        public InsideExcel() { }

        public InsideExcel(string maNV, string ten, DateTime? ngaySinh, string soBHXH, string soCMND, string soDienThoai, string queQuan, string noiOHienTai, string trinhDoHocVan, DateTime? ngayNhanHoSo, string nguoiGiaoHoSo, string nguoiGiuHoSo, string camKetTuyenDung, string quyetDinhTiepNhanDVC, string qDChamDutHopDongDVC, string nLDHocTheoChiTieuCTDT, string nguoiBanGiaoBangNhapKho, string kieuQuyetDinhTiepNhanDVC, DateTime? ngayQuyetDinhTiepNhanDVC, DateTime? ngayDiLam, string donViKyQuyetDinhTiepNhanDVC, string kieuQuyetDinhChamDutDVC, DateTime? ngayQuyetDinhChamDutDVC, DateTime? ngayChamDutDVC, string donViKyQuyetDinhChamDutDVC, List<GiayTo> giayTo, List<ChiTiet_BangCap_GiayChungNhan> chiTietBangCapGiayChungNhan, List<ChungChi_NhanVien> chungChiNhanVien, List<QuanHeGiaDinh> quanHeGiaDinh, List<LichSuBoSungSYLL> syll)
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
            NgayQuyetDinhTiepNhanDVC = ngayQuyetDinhTiepNhanDVC;
            NgayDiLam = ngayDiLam;
            DonViKyQuyetDinhTiepNhanDVC = donViKyQuyetDinhTiepNhanDVC;
            KieuQuyetDinhChamDutDVC = kieuQuyetDinhChamDutDVC;
            NgayQuyetDinhChamDutDVC = ngayQuyetDinhChamDutDVC;
            NgayChamDutDVC = ngayChamDutDVC;
            DonViKyQuyetDinhChamDutDVC = donViKyQuyetDinhChamDutDVC;
            this.giayTo = giayTo;
            ChiTietBangCapGiayChungNhan = chiTietBangCapGiayChungNhan;
            ChungChiNhanVien = chungChiNhanVien;
            this.quanHeGiaDinh = quanHeGiaDinh;
            this.syll = syll;
        }
    }
}