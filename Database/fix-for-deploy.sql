CREATE TABLE Documentary_Inspection_details(
start_date datetime,
end_date datetime,
documentary_id nvarchar (150) references Documentary(documentary_id),
equipmentId nvarchar (150) references Equipment(equipmentId)
)
--Dua Hau : TCLD
Use QUANGHANHABC
--add table GiayChungNhan_NhanVien
create table GiayChungNhan_NhanVien 
(
SoHieu nvarchar(100) not null primary key,
NgayCap date,
MaNV nvarchar(50) foreign key references NhanVien(MaNV),
MaChungNhan int foreign key references GiayChungNhan(MaChungNhan)
)
--add table DiemDanh_NangSuatLaoDong
create table DiemDanh_NangSuatLaoDong
(
MaDiemDanh int not null primary key identity(1,1),
MaNV nvarchar(50) not null foreign key references NhanVien(MaNV),
NgayDiemDanh date,
CaDiemDanh int,
ThoiGianThucTeDiemDanh datetime,
MaDonVi nvarchar(150) not null foreign key references Department(department_id),
NangSuatLaoDong nvarchar(100),
HeSoChiaLuong float,
LuongTruocDuyet float,
LuongSauDuyet float,
DuBaoNguyCo nvarchar(1000),
GiaiPhapNguyCo nvarchar(1000)
)
--fix LoaiQuyetDinh's length in QuyetDinh table
alter table QuyetDinh
alter column LoaiQuyetDinh nvarchar(100)

--add table ChamDut_NhanVien
create table ChamDut_NhanVien
(
SoQuyetDinh nvarchar(50) not null foreign key references QuyetDinh(SoQuyetDinh),
MaNV nvarchar(50) not null foreign key references NhanVien(MaNV),
LoaiChamDut nvarchar(100),
NgayChamDut date,
DonViKhiChamDut nvarchar(100)
primary key (SoQuyetDinh, MaNV)
)
--add table NguoiUyQuyenLayHoSo_BaoHiem
create table NguoiUyQuyenLayHoSo_BaoHiem
(
MaUyQuyen int not null primary key identity(1,1),
HoTen nvarchar(100),
QuanHe nvarchar(100),
SoCMND nvarchar(100),
SoDienThoai nvarchar(100)
)

--alter table NhanVien to add MaUyQuyen references to NguoiUyQuyenLayHoSo_BaoHiem table
alter table NhanVien
add MaUyQuyen int foreign key references NguoiUyQuyenLayHoSo_BaoHiem(MaUyQuyen),
SoBHXH nvarchar(100),
NgayTraBHXH date

alter table ChiTiet_BangCap
add NgayTra date

alter table ChungChi_NhanVien
add NgayTra date

alter table GiayChungNhan_NhanVien
add NgayTra date

alter table GiayTo
add NgayTra date

--20/09/2019
--San xuat
--add table TieuChi
create table TieuChi
(
MaTieuChi int not null primary key identity(1,1),
TenTieuChi nvarchar(100),
DonViDo nvarchar(100)
)

--add table VatLieuSanXuat
create table VatLieu_SanXuat
(
MaVatLieu int not null primary key identity(1,1),
LoaiVatLieu nvarchar(100),
TenVatLieu nvarchar(100),
MaTieuChi int not null foreign key references TieuChi(MaTieuChi)
)

--add table ThucHien_TieuChi
create table ThucHien_TieuChi
(
MaThucHien int not null primary key identity(1,1),
MaPhongBan nvarchar(150) not null foreign key references Department(department_id),
MaTieuChi int not null foreign key references TieuChi(MaTieuChi),
NgayThucHien date,
CaThucHien int,
SanLuongThucHien float
)

--add table KeHoach_TieuChi
create table KeHoach_TieuChi
(
MaKeHoach int not null primary key identity(1,1),
MaPhongBan nvarchar(150) not null foreign key references Department(department_id),
MaTieuChi int not null foreign key references TieuChi(MaTieuChi),
ThangKeHoach int,
NamKeHoach int,
SoNgayLamViec int,
SanLuongKeHoach float
)

--add table GhiChu
create table GhiChu
(
MaGhiChu int not null primary key identity(1,1),
MaThucHien int not null foreign key references ThucHien_TieuChi(MaThucHien),
MaKeHoach int not null foreign key references KeHoach_TieuChi(MaKeHoach),
NoiDungGhiChu nvarchar(max)
)
