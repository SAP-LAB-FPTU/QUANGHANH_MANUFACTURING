USE [master]
GO
/****** Object:  Database [QUANGHANHABC]    Script Date: 10/10/2019 5:42:52 PM ******/
CREATE DATABASE [QUANGHANHABC]
GO
USE [QUANGHANHABC]
GO
/****** Object:  Table [dbo].[Acceptance]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acceptance](
	[equipmentStatus] [int] NOT NULL,
	[acceptance_date] [date] NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[acceptance_result] [nvarchar](150) NULL,
	[documentary_process_result] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[equipmentId] ASC,
	[documentary_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[NVID] [nvarchar](50) NULL,
	[CDVT] [bit] NOT NULL,
	[TCLD] [bit] NOT NULL,
	[BGD] [bit] NOT NULL,
	[DK] [bit] NOT NULL,
	[KCS] [bit] NOT NULL,
	[PXKT] [bit] NOT NULL,
	[PXDL] [bit] NOT NULL,
	[PXVT] [bit] NOT NULL,
	[PXST] [bit] NOT NULL,
	[PXPV] [bit] NOT NULL,
	[PXDS] [bit] NOT NULL,
	[PXCDM] [bit] NOT NULL,
	[PXTGQLM] [bit] NOT NULL,
	[PXXD] [bit] NOT NULL,
	[PXLT] [bit] NOT NULL,
	[AT] [bit] NOT NULL,
	[KCM] [bit] NOT NULL,
	[ADMIN] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account_Right]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Right](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [nvarchar](50) NULL,
	[GroupID] [int] NULL,
	[Right] [nvarchar](70) NULL,
	[isBasic] [bit] NULL,
 CONSTRAINT [PK_Account_Right] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account_Right_Detail]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Right_Detail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[RightID] [int] NOT NULL,
 CONSTRAINT [PK_Account_Right_Detail] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[RightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Activity]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[activityid] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[equipmentid] [nvarchar](150) NOT NULL,
	[activityname] [nvarchar](150) NOT NULL,
	[hours_per_day] [float] NOT NULL,
	[quantity] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[activityid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[equipmentid] ASC,
	[date] ASC,
	[activityname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BangCap_GiayChungNhan]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangCap_GiayChungNhan](
	[MaTruong] [int] NULL,
	[MaBangCap_GiayChungNhan] [int] IDENTITY(1,1) NOT NULL,
	[MaTrinhDo] [int] NULL,
	[KieuBangCap] [nvarchar](100) NULL,
	[ThoiHan] [nvarchar](50) NULL,
	[TenBangCap] [nvarchar](100) NULL,
	[Loai] [nvarchar](100) NULL,
	[MaChuyenNganh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBangCap_GiayChungNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category_attribute_value]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_attribute_value](
	[Value] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[Equipment_category_id] [nvarchar](150) NOT NULL,
	[Equipment_category_attribute_id] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[equipmentId] ASC,
	[Equipment_category_id] ASC,
	[Equipment_category_attribute_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChamDut_NhanVien]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamDut_NhanVien](
	[MaQuyetDinh] [int] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[LoaiChamDut] [nvarchar](100) NULL,
	[NgayChamDut] [date] NOT NULL,
 CONSTRAINT [PK__ChamDut___8D1F62BBD51B05BB] PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_BangCap_GiayChungNhan]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_BangCap_GiayChungNhan](
	[SoHieu] [nvarchar](100) NOT NULL,
	[MaBangCap_GiayChungNhan] [int] NOT NULL,
	[NgayCap] [date] NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[NgayTra] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[SoHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_KeHoach_TieuChi_TheoThang]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_KeHoach_TieuChi_TheoThang](
	[HeaderID] [int] NOT NULL,
	[MaTieuChi] [int] NOT NULL,
	[SanLuong] [float] NULL,
 CONSTRAINT [PK_ChiTiet_KeHoach_TieuChi_TheoThang] PRIMARY KEY CLUSTERED 
(
	[HeaderID] ASC,
	[MaTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_NhiemVu_NhanVien]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_NhiemVu_NhanVien](
	[NgayNhanNhiemVu] [date] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[MaNhiemVu] [int] NOT NULL,
	[MaChiTiet_NhiemVu_NhanVien] [int] IDENTITY(1,1) NOT NULL,
	[IsInProcess] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet_NhiemVu_NhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_ThucHien_TieuChi_TheoNgay]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_ThucHien_TieuChi_TheoNgay](
	[HeaderID] [int] NOT NULL,
	[MaTieuChi] [int] NOT NULL,
	[SanLuong] [int] NULL,
	[KeHoach] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChiTiet_ThucHien_TieuChi_TheoNgay] PRIMARY KEY CLUSTERED 
(
	[HeaderID] ASC,
	[MaTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChungChi]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChungChi](
	[MaChungChi] [int] IDENTITY(1,1) NOT NULL,
	[TenChungChi] [nvarchar](100) NULL,
	[ThoiHan] [int] NULL,
	[KieuChungChi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChungChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChungChi_NhanVien]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChungChi_NhanVien](
	[SoHieu] [nvarchar](100) NOT NULL,
	[NgayCap] [date] NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[MaChungChi] [int] NOT NULL,
	[NgayTra] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[SoHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuyenNganh]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenNganh](
	[MaChuyenNganh] [nvarchar](100) NOT NULL,
	[TenChuyenNganh] [nvarchar](100) NULL,
	[CapBac] [nvarchar](100) NULL,
	[ChiTiet] [nvarchar](100) NULL,
	[MaNganh] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChuyenNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CongViec]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongViec](
	[MaCongViec] [int] IDENTITY(1,1) NOT NULL,
	[TenCongViec] [nvarchar](500) NULL,
	[ThangLuong] [nvarchar](100) NULL,
	[PhuCap] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCongViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[department_id] [nvarchar](150) NOT NULL,
	[department_name] [nvarchar](150) NOT NULL,
	[department_type] [nvarchar](150) NOT NULL,
	[isInside] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DiemDanh_NangSuatLaoDong]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh_NangSuatLaoDong](
	[MaNV] [nvarchar](50) NOT NULL,
	[HeaderID] [int] NOT NULL,
	[ThoiGianThucTeDiemDanh] [datetime] NULL,
	[HeSoChiaLuong] [float] NULL,
	[DiemLuong] [float] NULL,
	[DuBaoNguyCo] [nvarchar](1000) NULL,
	[DiLam] [bit] NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[LyDoVangMat] [nvarchar](1000) NULL,
	[GiaiPhapNguyCo] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[HeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DieuDong_NhanVien]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DieuDong_NhanVien](
	[MaQuyetDinh] [int] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[LyDoDieuDong] [nvarchar](1000) NULL,
	[DonViMoi] [nvarchar](100) NULL,
	[ChucVuMoi] [nvarchar](100) NULL,
	[BacLuongMoi] [nvarchar](100) NULL,
	[MucLuongMoi] [float] NULL,
	[DonViCu] [nvarchar](100) NULL,
	[ChucVuCu] [nvarchar](100) NULL,
	[BacLuongCu] [nvarchar](100) NULL,
	[MucLuongCu] [float] NULL,
 CONSTRAINT [PK__DieuDong__8D1F62BB8D1403C8] PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary](
	[documentary_id] [int] IDENTITY(1,1) NOT NULL,
	[documentary_code] [nvarchar](150) NULL,
	[documentary_type] [nvarchar](150) NOT NULL,
	[department_id] [nvarchar](150) NOT NULL,
	[date_created] [date] NOT NULL,
	[person_created] [nvarchar](150) NOT NULL,
	[reason] [nvarchar](150) NOT NULL,
	[out/in_come] [nvarchar](150) NULL,
	[documentary_status] [int] NOT NULL,
 CONSTRAINT [PK__Document__98F1320301ABE4FB] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary_big_maintain_details]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_big_maintain_details](
	[equipment_big_maintain_status] [int] NOT NULL,
	[remodel_type] [nvarchar](150) NOT NULL,
	[end_date] [date] NOT NULL,
	[next_remodel_type] [nvarchar](150) NOT NULL,
	[next_end_time] [float] NOT NULL,
	[department_id] [nvarchar](150) NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[equipment_big_maintain_reason] [nvarchar](150) NULL,
 CONSTRAINT [PK__Document__91679028640B9ABD] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary_liquidation_details]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_liquidation_details](
	[equipment_liquidation_status] [int] NOT NULL,
	[buyer] [nvarchar](150) NOT NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[equipment_liquidation_reason] [nvarchar](150) NULL,
 CONSTRAINT [PK__Document__91679028451AF592] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary_maintain_details]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_maintain_details](
	[equipment_maintain_status] [int] NOT NULL,
	[maintain_type] [nvarchar](150) NOT NULL,
	[finish_date_plan] [date] NOT NULL,
	[department_id] [nvarchar](150) NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[equipment_maintain_reason] [nvarchar](150) NULL,
 CONSTRAINT [PK__Document__91679028188D90C1] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary_moveline_details]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_moveline_details](
	[equipment_moveline_status] [int] NOT NULL,
	[department_detail] [nvarchar](150) NOT NULL,
	[date_to] [date] NOT NULL,
	[department_id] [nvarchar](150) NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[equipment_moveline_reason] [nvarchar](150) NULL,
 CONSTRAINT [PK__Document__9167902838E8012A] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary_repair_details]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_repair_details](
	[equipment_repair_status] [int] NOT NULL,
	[repair_type] [nvarchar](150) NOT NULL,
	[repair_reason] [nvarchar](150) NOT NULL,
	[finish_date_plan] [date] NOT NULL,
	[department_id] [nvarchar](150) NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK__Document__91679028E1AEF922] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary_revoke_details]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_revoke_details](
	[equipment_revoke_status] [int] NOT NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[equipment_revoke_reason] [nvarchar](150) NULL,
 CONSTRAINT [PK__Document__9167902836A80706] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[equipmentId] [nvarchar](150) NOT NULL,
	[equipment_name] [nvarchar](150) NOT NULL,
	[supplier] [nvarchar](150) NOT NULL,
	[date_import] [date] NOT NULL,
	[depreciation_estimate] [float] NOT NULL,
	[depreciation_present] [float] NOT NULL,
	[durationOfInspection] [date] NOT NULL,
	[durationOfInsurance] [date] NOT NULL,
	[usedDay] [date] NOT NULL,
	[durationOfMaintainance] [date] NOT NULL,
	[total_operating_hours] [int] NOT NULL,
	[current_Status] [int] NOT NULL,
	[fabrication_number] [float] NULL,
	[mark_code] [nvarchar](150) NULL,
	[quality_type] [nvarchar](150) NOT NULL,
	[input_channel] [nvarchar](150) NOT NULL,
	[Equipment_category_id] [nvarchar](150) NOT NULL,
	[department_id] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment_attribute]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_attribute](
	[Equipment_attribute_id] [nvarchar](150) NOT NULL,
	[Equipment_attribute_name] [nvarchar](150) NOT NULL,
	[value] [int] NOT NULL,
	[unit] [nvarchar](150) NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Equipment_attribute_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment_category]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_category](
	[Equipment_category_id] [nvarchar](150) NOT NULL,
	[Equipment_category_name] [nvarchar](150) NOT NULL,
	[divce_type] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Equipment_category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment_category_attribute]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_category_attribute](
	[Equipment_category_attribute_id] [nvarchar](150) NOT NULL,
	[Equipment_category_attribute_name] [nvarchar](150) NOT NULL,
	[unit] [nvarchar](150) NOT NULL,
	[Equipment_category_id] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Equipment_category_attribute_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment_Category_Supply]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_Category_Supply](
	[ecsId] [int] IDENTITY(1,1) NOT NULL,
	[Equipment_category_id] [nvarchar](150) NOT NULL,
	[supply_id] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Equipment_Category_Supply] PRIMARY KEY CLUSTERED 
(
	[ecsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Equipment_category_id] ASC,
	[supply_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment_Inspection]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_Inspection](
	[inspect_id] [int] IDENTITY(1,1) NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[inspect_expected_date] [datetime] NOT NULL,
	[inspect_start_date] [datetime] NULL,
	[inspect_end_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[inspect_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[equipmentId] ASC,
	[inspect_start_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FakeAPI]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FakeAPI](
	[MaNV] [nvarchar](50) NOT NULL,
	[NgayDiemDanh] [date] NOT NULL,
	[CaDiemDanh] [int] NOT NULL,
	[GioDiemDanh] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[NgayDiemDanh] ASC,
	[CaDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fuel_activities_consumption]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fuel_activities_consumption](
	[fuelid] [int] IDENTITY(1,1) NOT NULL,
	[consumption_value] [int] NOT NULL,
	[date] [date] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[fuel_type] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[fuelid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_FAC] UNIQUE NONCLUSTERED 
(
	[date] ASC,
	[equipmentId] ASC,
	[fuel_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiayTo]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiayTo](
	[MaNV] [nvarchar](50) NOT NULL,
	[TenGiayTo] [nvarchar](100) NOT NULL,
	[KieuGiayTo] [nvarchar](100) NULL,
	[MaGiayTo] [int] IDENTITY(1,1) NOT NULL,
	[NgayTra] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGiayTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Header_DiemDanh_NangSuat_LaoDong]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Header_DiemDanh_NangSuat_LaoDong](
	[HeaderID] [int] IDENTITY(1,1) NOT NULL,
	[Ca] [int] NOT NULL,
	[MaPhongBan] [nvarchar](150) NOT NULL,
	[NgayDiemDanh] [date] NOT NULL,
	[TotalEffort] [float] NOT NULL,
	[isFilledFromAPI] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Ca] ASC,
	[MaPhongBan] ASC,
	[NgayDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[HeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[header_KeHoachTungThang]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[header_KeHoachTungThang](
	[HeaderID] [int] IDENTITY(1,1) NOT NULL,
	[MaPhongBan] [nvarchar](150) NULL,
	[ThangKeHoach] [int] NULL,
	[NamKeHoach] [int] NULL,
	[SoNgayLamViec] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[header_ThucHienTheoNgay]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[header_ThucHienTheoNgay](
	[MaPhongBan] [nvarchar](150) NOT NULL,
	[Ngay] [date] NOT NULL,
	[HeaderID] [int] IDENTITY(1,1) NOT NULL,
	[Ca] [int] NOT NULL,
 CONSTRAINT [PK_header_ThucHienTheoNgay] PRIMARY KEY CLUSTERED 
(
	[HeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoSo]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSo](
	[TrangThaiHoSo] [nvarchar](100) NULL,
	[NgayNhanHoSo] [date] NULL,
	[NguoiGiaoHoSo] [nvarchar](100) NULL,
	[CamKetTuyenDung] [nvarchar](100) NULL,
	[QuyetDinhTiepNhanDVC] [nvarchar](100) NULL,
	[QDChamDutHopDongDVC] [nvarchar](100) NULL,
	[NLDHocTheoChiTieuCTDT] [nvarchar](100) NULL,
	[NguoiBanGiaoBangNhapKho] [nvarchar](100) NULL,
	[NguoiGiuHoSo] [nvarchar](100) NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[NgayQuyetDinhTuyenDung] [date] NULL,
	[NgayDiLam] [date] NULL,
	[DonViKyQuyetDinhTiepNhan] [nvarchar](100) NULL,
	[NgayQuyetDinhChamDut] [date] NULL,
	[NgayChamDut] [date] NULL,
	[DonViKyQuyetDinhChamDut] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incident]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incident](
	[incident_id] [int] IDENTITY(1,1) NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NULL,
	[detail_location] [nvarchar](150) NULL,
	[reason] [nvarchar](150) NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[department_id] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[incident_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuBoSungSYLL]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuBoSungSYLL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](50) NULL,
	[NamBoSung] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Maintain_Car]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintain_Car](
	[maintainid] [int] IDENTITY(1,1) NOT NULL,
	[equipmentid] [nvarchar](150) NOT NULL,
	[date] [date] NOT NULL,
	[departmentid] [nvarchar](150) NOT NULL,
	[maintain_content] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maintainid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Maintain_Car_Detail]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintain_Car_Detail](
	[maintaindetailid] [int] IDENTITY(1,1) NOT NULL,
	[maintainid] [int] NOT NULL,
	[supplyid] [nvarchar](150) NOT NULL,
	[quantity] [int] NOT NULL,
	[supplyType] [int] NOT NULL,
	[supplyStatus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maintaindetailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MealRegistration]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealRegistration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[department_id] [nvarchar](150) NULL,
	[date_regs] [date] NOT NULL,
	[num_regs] [int] NULL,
	[num_regs_plan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Module]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ID] [nvarchar](50) NOT NULL,
	[Module] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Module_1] PRIMARY KEY CLUSTERED 
(
	[Module] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[MaNganh] [nvarchar](100) NOT NULL,
	[TenNganh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiUyQuyenLayHoSo_BaoHiem]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiUyQuyenLayHoSo_BaoHiem](
	[MaUyQuyen] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[QuanHe] [nvarchar](100) NULL,
	[SoCMND] [nvarchar](100) NULL,
	[SoDienThoai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaUyQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[Tenkhac] [nvarchar](100) NULL,
	[GioiTinh] [bit] NOT NULL,
	[CapUyHienTai] [nvarchar](100) NULL,
	[CapUyKiem] [nvarchar](100) NULL,
	[PhuCapChucVu] [float] NULL,
	[NgaySinh] [date] NULL,
	[NoiSinh] [nvarchar](100) NULL,
	[DanToc] [nvarchar](100) NULL,
	[QueQuan] [nvarchar](100) NULL,
	[TonGiao] [nvarchar](100) NULL,
	[NoiOHienTai] [nvarchar](100) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[TPGiaDinhXuatThan] [nvarchar](100) NULL,
	[NgayThamGiaCachMang] [date] NULL,
	[NgayVaoDangCSVN] [date] NULL,
	[NgayChinhThuc] [date] NULL,
	[NgayVaoToChucCTXH] [date] NULL,
	[ToChuc] [nvarchar](100) NULL,
	[NgayNhapNgu] [date] NULL,
	[NgayXuatNgu] [date] NULL,
	[QuanHamChucVuCaoNhat] [nvarchar](100) NULL,
	[HocHamHocViCaoNhat] [nvarchar](100) NULL,
	[LyLuanChinhTri] [nvarchar](100) NULL,
	[NgoaiNgu] [nvarchar](100) NULL,
	[CongTacChinhDangLam] [nvarchar](100) NULL,
	[NgachCongChuc] [nvarchar](100) NULL,
	[MaNgach] [float] NULL,
	[DanhHieuDuocPhong] [nvarchar](100) NULL,
	[SoTruongCongTac] [nvarchar](100) NULL,
	[CongViecDaLamLauNhat] [nvarchar](100) NULL,
	[KhenThuong] [nvarchar](100) NULL,
	[KyLuat] [nvarchar](100) NULL,
	[TinhTrangSucKhoe] [nvarchar](100) NULL,
	[ChiTietSucKhoe] [nvarchar](100) NULL,
	[ChieuCao] [float] NULL,
	[CanNang] [float] NULL,
	[NhomMau] [nvarchar](100) NULL,
	[HangThuongBinh] [nvarchar](100) NULL,
	[GiaDinhChinhSach] [nvarchar](100) NULL,
	[SoCMND] [nvarchar](20) NULL,
	[NgayCapCMND] [date] NULL,
	[NoiCapCMND] [nvarchar](100) NULL,
	[NgayDiLam] [date] NULL,
	[MaUyQuyen] [int] NULL,
	[SoBHXH] [nvarchar](100) NULL,
	[NgayTraBHXH] [date] NULL,
	[LoaiNhanVien] [nvarchar](100) NULL,
	[MaCongViec] [int] NULL,
	[MucLuong] [float] NULL,
	[MaTrinhDo] [int] NULL,
	[MaTruong] [int] NULL,
	[BacLuong] [nvarchar](100) NULL,
	[NgheTruoc] [nvarchar](100) NULL,
	[NgayTuyenDungTruoc] [date] NULL,
	[CoQuanTruoc] [nvarchar](100) NULL,
	[HeSo] [float] NULL,
	[TuThang] [int] NULL,
	[MaTrangThai] [int] NOT NULL,
	[MaChuyenNganh] [nvarchar](100) NULL,
	[MaPhongBan] [nvarchar](150) NULL,
 CONSTRAINT [PK__NhanVien__2725D70AC587C2A2] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhiemVu]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhiemVu](
	[Loai] [nvarchar](100) NOT NULL,
	[TenNhiemVu] [nvarchar](100) NOT NULL,
	[MaChungChi] [int] NULL,
	[MaNhiemVu] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhiemVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhomTieuChi]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomTieuChi](
	[MaNhomTieuChi] [int] NOT NULL,
	[TenNhomTieuChi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NhomTieuChi] PRIMARY KEY CLUSTERED 
(
	[MaNhomTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuanHeGiaDinh]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanHeGiaDinh](
	[MaQuanHeGiaDinh] [int] IDENTITY(1,1) NOT NULL,
	[LoaiGiaDinh] [nvarchar](100) NULL,
	[MoiQuanHe] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[LyLich] [nvarchar](100) NULL,
	[MaNV] [nvarchar](50) NULL,
	[HoTen] [nvarchar](100) NULL,
	[NoiThuongTru] [nvarchar](100) NULL,
	[SoDienThoai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuanHeGiaDinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuaTrinhCongTac]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuaTrinhCongTac](
	[MaCongTac] [int] IDENTITY(1,1) NOT NULL,
	[ChucDanh] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](100) NULL,
	[DonViCongTac] [nvarchar](100) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[MaNV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCongTac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuyetDinh]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyetDinh](
	[MaQuyetDinh] [int] IDENTITY(1,1) NOT NULL,
	[SoQuyetDinh] [nvarchar](50) NULL,
	[NgayQuyetDinh] [date] NULL,
 CONSTRAINT [PK__QuyetDin__3F6D3FCB2549C64E] PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[statusid] [int] NOT NULL,
	[statusname] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[statusid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supply]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[supply_id] [nvarchar](150) NOT NULL,
	[supply_name] [nvarchar](150) NOT NULL,
	[unit] [nvarchar](150) NOT NULL,
	[price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[supply_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supply_Documentary_Equipment]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply_Documentary_Equipment](
	[supplyDocumentaryEquipmentId] [int] IDENTITY(1,1) NOT NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
	[supply_id] [nvarchar](150) NOT NULL,
	[quantity] [int] NOT NULL,
	[supplyType] [int] NOT NULL,
	[supplyStatus] [nvarchar](150) NOT NULL,
	[supply_documentary_status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[supplyDocumentaryEquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_SDE] UNIQUE NONCLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC,
	[supply_id] ASC,
	[supplyType] ASC,
	[supplyStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supply_tieuhao]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply_tieuhao](
	[supplyid] [nvarchar](150) NOT NULL,
	[departmentid] [nvarchar](150) NOT NULL,
	[date] [date] NOT NULL,
	[quantity] [int] NOT NULL,
	[used] [int] NOT NULL,
	[thuhoi] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[supplyid] ASC,
	[departmentid] ASC,
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplyPlan]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplyPlan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supplyid] [nvarchar](150) NOT NULL,
	[departmentid] [nvarchar](150) NOT NULL,
	[equipmentid] [nvarchar](150) NOT NULL,
	[date] [date] NOT NULL,
	[dinh_muc] [float] NOT NULL,
	[quantity_plan] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiNan]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiNan](
	[MaTaiNan] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[LyDo] [nvarchar](max) NULL,
	[Ngay] [date] NULL,
	[Ca] [int] NULL,
	[Loai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTaiNan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TieuChi]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TieuChi](
	[MaTieuChi] [int] IDENTITY(1,1) NOT NULL,
	[TenTieuChi] [nvarchar](100) NULL,
	[DonViDo] [nvarchar](100) NULL,
	[MaNhomTieuChi] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[MaTrangThai] [int] IDENTITY(1,1) NOT NULL,
	[TenTrangThai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrinhDo]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDo](
	[MaTrinhDo] [int] NOT NULL,
	[TenTrinhDo] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTrinhDo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Truong]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Truong](
	[MaTruong] [int] NOT NULL,
	[TenTruong] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTruong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TuyenDung_NhanVien]    Script Date: 10/10/2019 5:42:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuyenDung_NhanVien](
	[MaQuyetDinh] [int] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[NgayTuyenDung] [date] NOT NULL,
 CONSTRAINT [PK__TuyenDun__8D1F62BBF450B11C] PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_isInside]  DEFAULT ((0)) FOR [isInside]
GO
ALTER TABLE [dbo].[Header_DiemDanh_NangSuat_LaoDong] ADD  CONSTRAINT [DF_Table_1_Tổng Điểm]  DEFAULT ((0)) FOR [TotalEffort]
GO
ALTER TABLE [dbo].[Header_DiemDanh_NangSuat_LaoDong] ADD  CONSTRAINT [DF_Header_DiemDanh_NangSuat_LaoDong_isFilledFromAPI]  DEFAULT ((0)) FOR [isFilledFromAPI]
GO
ALTER TABLE [dbo].[header_ThucHienTheoNgay] ADD  CONSTRAINT [DF_header_ThucHienTheoNgay_Ca]  DEFAULT ((0)) FOR [Ca]
GO
ALTER TABLE [dbo].[SupplyPlan] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Acceptance]  WITH CHECK ADD  CONSTRAINT [FK__Acceptanc__docum__2A164134] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Acceptance] CHECK CONSTRAINT [FK__Acceptanc__docum__2A164134]
GO
ALTER TABLE [dbo].[Acceptance]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_NhanVien] FOREIGN KEY([NVID])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_NhanVien]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD FOREIGN KEY([equipmentid])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[BangCap_GiayChungNhan]  WITH CHECK ADD FOREIGN KEY([MaChuyenNganh])
REFERENCES [dbo].[ChuyenNganh] ([MaChuyenNganh])
GO
ALTER TABLE [dbo].[BangCap_GiayChungNhan]  WITH CHECK ADD  CONSTRAINT [FK_BangCap_TrinhDo] FOREIGN KEY([MaTrinhDo])
REFERENCES [dbo].[TrinhDo] ([MaTrinhDo])
GO
ALTER TABLE [dbo].[BangCap_GiayChungNhan] CHECK CONSTRAINT [FK_BangCap_TrinhDo]
GO
ALTER TABLE [dbo].[BangCap_GiayChungNhan]  WITH CHECK ADD  CONSTRAINT [FK_BangCap_Truong] FOREIGN KEY([MaTruong])
REFERENCES [dbo].[Truong] ([MaTruong])
GO
ALTER TABLE [dbo].[BangCap_GiayChungNhan] CHECK CONSTRAINT [FK_BangCap_Truong]
GO
ALTER TABLE [dbo].[Category_attribute_value]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Category_attribute_value]  WITH CHECK ADD FOREIGN KEY([Equipment_category_id])
REFERENCES [dbo].[Equipment_category] ([Equipment_category_id])
GO
ALTER TABLE [dbo].[Category_attribute_value]  WITH CHECK ADD FOREIGN KEY([Equipment_category_attribute_id])
REFERENCES [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id])
GO
ALTER TABLE [dbo].[ChamDut_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__ChamDut_N__MaQuy__0B91BA14] FOREIGN KEY([MaQuyetDinh])
REFERENCES [dbo].[QuyetDinh] ([MaQuyetDinh])
GO
ALTER TABLE [dbo].[ChamDut_NhanVien] CHECK CONSTRAINT [FK__ChamDut_N__MaQuy__0B91BA14]
GO
ALTER TABLE [dbo].[ChamDut_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_ChamDut_NhanVien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChamDut_NhanVien] CHECK CONSTRAINT [FK_ChamDut_NhanVien_NhanVien]
GO
ALTER TABLE [dbo].[ChiTiet_BangCap_GiayChungNhan]  WITH CHECK ADD FOREIGN KEY([MaBangCap_GiayChungNhan])
REFERENCES [dbo].[BangCap_GiayChungNhan] ([MaBangCap_GiayChungNhan])
GO
ALTER TABLE [dbo].[ChiTiet_BangCap_GiayChungNhan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_BangCap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTiet_BangCap_GiayChungNhan] CHECK CONSTRAINT [FK_ChiTiet_BangCap_NhanVien]
GO
ALTER TABLE [dbo].[ChiTiet_KeHoach_TieuChi_TheoThang]  WITH CHECK ADD  CONSTRAINT [FK__ChiTiet_K__Heade__05A3D694] FOREIGN KEY([HeaderID])
REFERENCES [dbo].[header_KeHoachTungThang] ([HeaderID])
GO
ALTER TABLE [dbo].[ChiTiet_KeHoach_TieuChi_TheoThang] CHECK CONSTRAINT [FK__ChiTiet_K__Heade__05A3D694]
GO
ALTER TABLE [dbo].[ChiTiet_KeHoach_TieuChi_TheoThang]  WITH CHECK ADD  CONSTRAINT [FK__ChiTiet_K__MaTie__0697FACD] FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TieuChi] ([MaTieuChi])
GO
ALTER TABLE [dbo].[ChiTiet_KeHoach_TieuChi_TheoThang] CHECK CONSTRAINT [FK__ChiTiet_K__MaTie__0697FACD]
GO
ALTER TABLE [dbo].[ChiTiet_NhiemVu_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__ChiTiet_Nh__MaNV__1CBC4616] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTiet_NhiemVu_NhanVien] CHECK CONSTRAINT [FK__ChiTiet_Nh__MaNV__1CBC4616]
GO
ALTER TABLE [dbo].[ChiTiet_NhiemVu_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_NhiemVu_NhanVien_NhiemVu] FOREIGN KEY([MaNhiemVu])
REFERENCES [dbo].[NhiemVu] ([MaNhiemVu])
GO
ALTER TABLE [dbo].[ChiTiet_NhiemVu_NhanVien] CHECK CONSTRAINT [FK_ChiTiet_NhiemVu_NhanVien_NhiemVu]
GO
ALTER TABLE [dbo].[ChiTiet_ThucHien_TieuChi_TheoNgay]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_ThucHien_TieuChi_TheoNgay_header_ThucHienTheoNgay] FOREIGN KEY([HeaderID])
REFERENCES [dbo].[header_ThucHienTheoNgay] ([HeaderID])
GO
ALTER TABLE [dbo].[ChiTiet_ThucHien_TieuChi_TheoNgay] CHECK CONSTRAINT [FK_ChiTiet_ThucHien_TieuChi_TheoNgay_header_ThucHienTheoNgay]
GO
ALTER TABLE [dbo].[ChiTiet_ThucHien_TieuChi_TheoNgay]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_ThucHien_TieuChi_TheoNgay_TieuChi] FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TieuChi] ([MaTieuChi])
GO
ALTER TABLE [dbo].[ChiTiet_ThucHien_TieuChi_TheoNgay] CHECK CONSTRAINT [FK_ChiTiet_ThucHien_TieuChi_TheoNgay_TieuChi]
GO
ALTER TABLE [dbo].[ChungChi_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaChungChi])
REFERENCES [dbo].[ChungChi] ([MaChungChi])
GO
ALTER TABLE [dbo].[ChungChi_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__ChungChi_N__MaNV__1F98B2C1] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChungChi_NhanVien] CHECK CONSTRAINT [FK__ChungChi_N__MaNV__1F98B2C1]
GO
ALTER TABLE [dbo].[ChuyenNganh]  WITH CHECK ADD FOREIGN KEY([MaNganh])
REFERENCES [dbo].[Nganh] ([MaNganh])
GO
ALTER TABLE [dbo].[DiemDanh_NangSuatLaoDong]  WITH CHECK ADD FOREIGN KEY([HeaderID])
REFERENCES [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID])
GO
ALTER TABLE [dbo].[DiemDanh_NangSuatLaoDong]  WITH CHECK ADD  CONSTRAINT [FK_DiemDanh_NangSuatLaoDong_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DiemDanh_NangSuatLaoDong] CHECK CONSTRAINT [FK_DiemDanh_NangSuatLaoDong_NhanVien]
GO
ALTER TABLE [dbo].[DieuDong_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__DieuDong___MaQuy__17036CC0] FOREIGN KEY([MaQuyetDinh])
REFERENCES [dbo].[QuyetDinh] ([MaQuyetDinh])
GO
ALTER TABLE [dbo].[DieuDong_NhanVien] CHECK CONSTRAINT [FK__DieuDong___MaQuy__17036CC0]
GO
ALTER TABLE [dbo].[DieuDong_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__DieuDong_N__MaNV__17F790F9] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DieuDong_NhanVien] CHECK CONSTRAINT [FK__DieuDong_N__MaNV__17F790F9]
GO
ALTER TABLE [dbo].[Documentary]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__40058253] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary] CHECK CONSTRAINT [FK__Documenta__depar__40058253]
GO
ALTER TABLE [dbo].[Documentary_big_maintain_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__4E53A1AA] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_big_maintain_details] CHECK CONSTRAINT [FK__Documenta__depar__4E53A1AA]
GO
ALTER TABLE [dbo].[Documentary_big_maintain_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__4F47C5E3] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_big_maintain_details] CHECK CONSTRAINT [FK__Documenta__depar__4F47C5E3]
GO
ALTER TABLE [dbo].[Documentary_big_maintain_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__40F9A68C] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_big_maintain_details] CHECK CONSTRAINT [FK__Documenta__docum__40F9A68C]
GO
ALTER TABLE [dbo].[Documentary_big_maintain_details]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_liquidation_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__42E1EEFE] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_liquidation_details] CHECK CONSTRAINT [FK__Documenta__docum__42E1EEFE]
GO
ALTER TABLE [dbo].[Documentary_liquidation_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__43D61338] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_liquidation_details] CHECK CONSTRAINT [FK__Documenta__equip__43D61338]
GO
ALTER TABLE [dbo].[Documentary_maintain_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__540C7B00] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_maintain_details] CHECK CONSTRAINT [FK__Documenta__depar__540C7B00]
GO
ALTER TABLE [dbo].[Documentary_maintain_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__55009F39] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_maintain_details] CHECK CONSTRAINT [FK__Documenta__depar__55009F39]
GO
ALTER TABLE [dbo].[Documentary_maintain_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__44CA3770] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_maintain_details] CHECK CONSTRAINT [FK__Documenta__docum__44CA3770]
GO
ALTER TABLE [dbo].[Documentary_maintain_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__45BE5BA9] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_maintain_details] CHECK CONSTRAINT [FK__Documenta__equip__45BE5BA9]
GO
ALTER TABLE [dbo].[Documentary_moveline_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__57DD0BE4] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_moveline_details] CHECK CONSTRAINT [FK__Documenta__depar__57DD0BE4]
GO
ALTER TABLE [dbo].[Documentary_moveline_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__58D1301D] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_moveline_details] CHECK CONSTRAINT [FK__Documenta__depar__58D1301D]
GO
ALTER TABLE [dbo].[Documentary_moveline_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__46B27FE2] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_moveline_details] CHECK CONSTRAINT [FK__Documenta__docum__46B27FE2]
GO
ALTER TABLE [dbo].[Documentary_moveline_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__47A6A41B] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_moveline_details] CHECK CONSTRAINT [FK__Documenta__equip__47A6A41B]
GO
ALTER TABLE [dbo].[Documentary_repair_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__5BAD9CC8] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_repair_details] CHECK CONSTRAINT [FK__Documenta__depar__5BAD9CC8]
GO
ALTER TABLE [dbo].[Documentary_repair_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__5CA1C101] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Documentary_repair_details] CHECK CONSTRAINT [FK__Documenta__depar__5CA1C101]
GO
ALTER TABLE [dbo].[Documentary_repair_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__489AC854] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_repair_details] CHECK CONSTRAINT [FK__Documenta__docum__489AC854]
GO
ALTER TABLE [dbo].[Documentary_repair_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__498EEC82] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_repair_details] CHECK CONSTRAINT [FK__Documenta__equip__498EEC82]
GO
ALTER TABLE [dbo].[Documentary_revoke_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__4A8310C6] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_revoke_details] CHECK CONSTRAINT [FK__Documenta__docum__4A8310C6]
GO
ALTER TABLE [dbo].[Documentary_revoke_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__4B7734FA] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_revoke_details] CHECK CONSTRAINT [FK__Documenta__equip__4B7734FA]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([current_Status])
REFERENCES [dbo].[Status] ([statusid])
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK__Equipment__depar__625A9A57] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK__Equipment__depar__625A9A57]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([Equipment_category_id])
REFERENCES [dbo].[Equipment_category] ([Equipment_category_id])
GO
ALTER TABLE [dbo].[Equipment_attribute]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Equipment_category_attribute]  WITH CHECK ADD FOREIGN KEY([Equipment_category_id])
REFERENCES [dbo].[Equipment_category] ([Equipment_category_id])
GO
ALTER TABLE [dbo].[Equipment_Category_Supply]  WITH CHECK ADD FOREIGN KEY([Equipment_category_id])
REFERENCES [dbo].[Equipment_category] ([Equipment_category_id])
GO
ALTER TABLE [dbo].[Equipment_Category_Supply]  WITH CHECK ADD FOREIGN KEY([supply_id])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[Equipment_Inspection]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[FakeAPI]  WITH CHECK ADD  CONSTRAINT [FK__FakeAPI__MaNV__40F9A68C] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[FakeAPI] CHECK CONSTRAINT [FK__FakeAPI__MaNV__40F9A68C]
GO
ALTER TABLE [dbo].[Fuel_activities_consumption]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Fuel_activities_consumption]  WITH CHECK ADD FOREIGN KEY([fuel_type])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[GiayTo]  WITH CHECK ADD  CONSTRAINT [FK__GiayTo__MaNV__45BE5BA9] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[GiayTo] CHECK CONSTRAINT [FK__GiayTo__MaNV__45BE5BA9]
GO
ALTER TABLE [dbo].[header_KeHoachTungThang]  WITH CHECK ADD FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[header_ThucHienTheoNgay]  WITH CHECK ADD  CONSTRAINT [FK_header_ThucHienTheoNgay_Department] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[header_ThucHienTheoNgay] CHECK CONSTRAINT [FK_header_ThucHienTheoNgay_Department]
GO
ALTER TABLE [dbo].[HoSo]  WITH CHECK ADD  CONSTRAINT [FK__HoSo__MaNV__46B27FE2] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoSo] CHECK CONSTRAINT [FK__HoSo__MaNV__46B27FE2]
GO
ALTER TABLE [dbo].[Incident]  WITH CHECK ADD  CONSTRAINT [FK__Incident__depart__6FB49575] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Incident] CHECK CONSTRAINT [FK__Incident__depart__6FB49575]
GO
ALTER TABLE [dbo].[Incident]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[LichSuBoSungSYLL]  WITH CHECK ADD  CONSTRAINT [FK__LichSuBoSu__MaNV__4D5F7D71] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[LichSuBoSungSYLL] CHECK CONSTRAINT [FK__LichSuBoSu__MaNV__4D5F7D71]
GO
ALTER TABLE [dbo].[Maintain_Car]  WITH CHECK ADD  CONSTRAINT [FK__Maintain___depar__76619304] FOREIGN KEY([departmentid])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Maintain_Car] CHECK CONSTRAINT [FK__Maintain___depar__76619304]
GO
ALTER TABLE [dbo].[Maintain_Car]  WITH CHECK ADD FOREIGN KEY([equipmentid])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Maintain_Car_Detail]  WITH CHECK ADD FOREIGN KEY([maintainid])
REFERENCES [dbo].[Maintain_Car] ([maintainid])
GO
ALTER TABLE [dbo].[Maintain_Car_Detail]  WITH CHECK ADD FOREIGN KEY([supplyid])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[MealRegistration]  WITH CHECK ADD  CONSTRAINT [FK__MealRegis__depar__7A3223E8] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[MealRegistration] CHECK CONSTRAINT [FK__MealRegis__depar__7A3223E8]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaChuy__531856C7] FOREIGN KEY([MaChuyenNganh])
REFERENCES [dbo].[ChuyenNganh] ([MaChuyenNganh])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaChuy__531856C7]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaPhon__793DFFAF] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaPhon__793DFFAF]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaTran__540C7B00] FOREIGN KEY([MaTrangThai])
REFERENCES [dbo].[TrangThai] ([MaTrangThai])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaTran__540C7B00]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaTrin__55009F39] FOREIGN KEY([MaTrinhDo])
REFERENCES [dbo].[TrinhDo] ([MaTrinhDo])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaTrin__55009F39]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaTruo__55F4C372] FOREIGN KEY([MaTruong])
REFERENCES [dbo].[Truong] ([MaTruong])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaTruo__55F4C372]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaUyQu__56E8E7AB] FOREIGN KEY([MaUyQuyen])
REFERENCES [dbo].[NguoiUyQuyenLayHoSo_BaoHiem] ([MaUyQuyen])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaUyQu__56E8E7AB]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_CongViec] FOREIGN KEY([MaCongViec])
REFERENCES [dbo].[CongViec] ([MaCongViec])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_CongViec]
GO
ALTER TABLE [dbo].[NhiemVu]  WITH CHECK ADD  CONSTRAINT [FK_NhiemVu_ChungChi] FOREIGN KEY([MaChungChi])
REFERENCES [dbo].[ChungChi] ([MaChungChi])
GO
ALTER TABLE [dbo].[NhiemVu] CHECK CONSTRAINT [FK_NhiemVu_ChungChi]
GO
ALTER TABLE [dbo].[QuanHeGiaDinh]  WITH CHECK ADD  CONSTRAINT [FK__QuanHeGiaD__MaNV__5AB9788F] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[QuanHeGiaDinh] CHECK CONSTRAINT [FK__QuanHeGiaD__MaNV__5AB9788F]
GO
ALTER TABLE [dbo].[QuaTrinhCongTac]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Supply_Documentary_Equipment]  WITH CHECK ADD  CONSTRAINT [FK__Supply_Do__docum__671F4F74] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supply_Documentary_Equipment] CHECK CONSTRAINT [FK__Supply_Do__docum__671F4F74]
GO
ALTER TABLE [dbo].[Supply_Documentary_Equipment]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Supply_Documentary_Equipment]  WITH CHECK ADD FOREIGN KEY([supply_id])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[Supply_tieuhao]  WITH CHECK ADD  CONSTRAINT [FK__Supply_ti__depar__078C1F06] FOREIGN KEY([departmentid])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Supply_tieuhao] CHECK CONSTRAINT [FK__Supply_ti__depar__078C1F06]
GO
ALTER TABLE [dbo].[Supply_tieuhao]  WITH CHECK ADD FOREIGN KEY([supplyid])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD  CONSTRAINT [FK__SupplyPla__depar__09746778] FOREIGN KEY([departmentid])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[SupplyPlan] CHECK CONSTRAINT [FK__SupplyPla__depar__09746778]
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD  CONSTRAINT [FK__SupplyPla__depar__0A688BB1] FOREIGN KEY([departmentid])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[SupplyPlan] CHECK CONSTRAINT [FK__SupplyPla__depar__0A688BB1]
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD FOREIGN KEY([equipmentid])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD FOREIGN KEY([supplyid])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD FOREIGN KEY([supplyid])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[TaiNan]  WITH CHECK ADD  CONSTRAINT [FK__TaiNan__MaNV__662B2B3B] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiNan] CHECK CONSTRAINT [FK__TaiNan__MaNV__662B2B3B]
GO
ALTER TABLE [dbo].[TieuChi]  WITH CHECK ADD  CONSTRAINT [FK_TieuChi_NhomTieuChi] FOREIGN KEY([MaNhomTieuChi])
REFERENCES [dbo].[NhomTieuChi] ([MaNhomTieuChi])
GO
ALTER TABLE [dbo].[TieuChi] CHECK CONSTRAINT [FK_TieuChi_NhomTieuChi]
GO
ALTER TABLE [dbo].[TuyenDung_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__TuyenDung__MaQuy__4D5F7D71] FOREIGN KEY([MaQuyetDinh])
REFERENCES [dbo].[QuyetDinh] ([MaQuyetDinh])
GO
ALTER TABLE [dbo].[TuyenDung_NhanVien] CHECK CONSTRAINT [FK__TuyenDung__MaQuy__4D5F7D71]
GO
ALTER TABLE [dbo].[TuyenDung_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_TuyenDung_NhanVien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TuyenDung_NhanVien] CHECK CONSTRAINT [FK_TuyenDung_NhanVien_NhanVien]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account_Right_Detail'
GO
USE [master]
GO
ALTER DATABASE [QUANGHANHABC] SET  READ_WRITE 
GO
