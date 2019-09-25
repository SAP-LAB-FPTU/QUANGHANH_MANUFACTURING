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
create table VatLieuSanXuat
(
MaVatLieu int not null primary key identity(1,1),
LoaiVatLieu nvarchar(100),
TenVatLieu nvarchar(100)
)

--add table TieuChi_VatLieuSanXuat
create table TieuChi_VatLieuSanXuat
(
MaTieuChi_VatLieuSanXuat int not null primary key identity(1,1),
MaTieuChi int not null foreign key references TieuChi(MaTieuChi),
MaVatLieu int not null foreign key references VatLieuSanXuat(MaVatLieu)
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

--add table ThucHien_TieuChi_VatLieuSanXuat
create table ThucHien_TieuChi_VatLieuSanXuat
(
MaThucHien int not null foreign key references ThucHien_TieuChi(MaThucHien),
MaTieuChi_VatLieuSanXuat int not null foreign key references TieuChi_VatLieuSanXuat(MaTieuChi_VatLieuSanXuat),
primary key (MaThucHien, MaTieuChi_VatLieuSanXuat)
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

--add table KeHoach_TieuChi_VatLieuSanXuat
create table KeHoach_TieuChi_VatLieuSanXuat
(
MaKeHoach int not null foreign key references KeHoach_TieuChi(MaKeHoach),
MaTieuChi_VatLieuSanXuat int not null foreign key references TieuChi_VatLieuSanXuat(MaTieuChi_VatLieuSanXuat),
TietDienDao float,
primary key (MaKeHoach, MaTieuChi_VatLieuSanXuat)
)

--add table GhiChu
create table GhiChu
(
MaGhiChu int not null primary key identity(1,1),
MaThucHien int not null foreign key references ThucHien_TieuChi(MaThucHien),
MaKeHoach int not null foreign key references KeHoach_TieuChi(MaKeHoach),
NoiDungGhiChu nvarchar(max)
)

-- 21/09/2019
--xoa bang Activity
drop table Activity

-- tao lai bang cap nhat hoat dong
drop table Quantity_activities
create table Activity
(
activityid int identity(1,1),
[date] date not null,
equipmentid nvarchar(150) not null,
activityname nvarchar(150) not null,
hours_per_day float not null,
quantity float not null,
)

--xoa bang upgrading attribute
drop table upgrading_attribute

--them cac bang vat tu tieu hao
create table Supply_tieuhao
(
	supplyid NVARCHAR(150) NOT NULL,
	departmentid NVARCHAR(150) NOT NULL,
	[date] date NOT NULL,
	quantity INT NOT NULL,
	used INT NOT NULL,
	thuhoi INT NOT NULL,
	PRIMARY KEY (supplyid, departmentid, [date]),
	FOREIGN KEY (supplyid) REFERENCES Supply(supply_id),
	FOREIGN KEY (departmentid) REFERENCES Department(department_id)
);

-- them bang vat tu xin cap
create table SupplyPlan
(
	supplyid NVARCHAR(150) NOT NULL,
	departmentid NVARCHAR(150) NOT NULL,
	equipmentid NVARCHAR(150) NOT NULL,
	[date] date not null,
	dinh_muc float not null,
	quantity_plan INT not null,
	quantity INT NOT NULL,
	PRIMARY KEY(supplyid,departmentid, equipmentid),
	FOREIGN KEY (supplyid) REFERENCES Supply(supply_id),
	FOREIGN KEY (departmentid) REFERENCES Department(department_id),
	FOREIGN KEY (equipmentid) REFERENCES Equipment(equipmentId)
)

--them bang bao duong hang ngay
create table Maintain_Car (
maintainid int identity(1,1),
equipmentid nvarchar(150) not null,
[date] date not null,
departmentid nvarchar(150) not null,
maintain_content nvarchar(150) not null,
primary key (maintainid),
foreign key (equipmentid) references Equipment(equipmentId),
foreign key (departmentid) references Department(department_id)
)

--them bảng vat tu bao duong hang ngay
create table Maintain_Car_Detail
(
maintaindetailid int identity (1,1),
maintainid int not null,
supplyid nvarchar(150) not null,
quantity int not null,
supplyType int not null,
supplyStatus int not null,
primary key (maintaindetailid),
foreign key (supplyid) references Supply(supply_id),
foreign key (maintainid) references Maintain_Car(maintainid)
)

--them truong li do cho tung thiet bi cua quyet dinh
alter table Documentary_liquidation_details add equipment_liquidation_reason nvarchar(150)
alter table Documentary_revoke_details add equipment_revoke_reason nvarchar(150)
alter table Documentary_big_maintain_details add equipment_big_maintain_reason nvarchar(150)
alter table Documentary_maintain_details add equipment_maintain_reason nvarchar(150)
alter table Documentary_moveline_details add equipment_moveline_reason nvarchar(150)

--them truong gia uoc tinh trong bang vat tu
alter table Supply alter column price float

--xoa bang chi tiet quyet dinh kiem dinh (kiem dinh khong co quyet dinh)
drop table Documentary_Inspection_details
					      
--21/09/2019
--add table TuyenDung_NhanVien
create table TuyenDung_NhanVien
(
MaNV nvarchar(50) not null foreign key references NhanVien(MaNV),
SoQuyetDinh nvarchar(50) not null foreign key references QuyetDinh(SoQuyetDinh),
primary key (MaNV,SoQuyetDinh)
)
