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
