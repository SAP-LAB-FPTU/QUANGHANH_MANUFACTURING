USE [master]
GO
/****** Object:  Database [QUANGHANHABC]    Script Date: 9/25/2019 6:50:51 PM ******/
CREATE DATABASE [QUANGHANHABC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANGHANHABC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QUANGHANHABC.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QUANGHANHABC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QUANGHANHABC_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QUANGHANHABC] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANGHANHABC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANGHANHABC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QUANGHANHABC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANGHANHABC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANGHANHABC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QUANGHANHABC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANGHANHABC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET RECOVERY FULL 
GO
ALTER DATABASE [QUANGHANHABC] SET  MULTI_USER 
GO
ALTER DATABASE [QUANGHANHABC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANGHANHABC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANGHANHABC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANGHANHABC] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QUANGHANHABC', N'ON'
GO
USE [QUANGHANHABC]
GO
/****** Object:  Table [dbo].[Acceptance]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acceptance](
	[equipmentStatus] [int] NOT NULL,
	[acceptance_date] [date] NOT NULL,
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
/****** Object:  Table [dbo].[Account]    Script Date: 9/25/2019 6:50:51 PM ******/
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
	[CDVT] [bit] NOT NULL,
	[TCLD] [bit] NOT NULL,
	[BGD] [bit] NOT NULL,
	[DK] [bit] NOT NULL,
	[KCS] [bit] NOT NULL,
	[PXKT] [bit] NOT NULL,
	[ADMIN] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account_Right]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Account_Right_Detail]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Activity]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[BangCap_GiayChungNhan]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangCap_GiayChungNhan](
	[MaTruong] [int] NULL,
	[MaChuyenNghanh] [int] NULL,
	[MaBangCap_GiayChungNhan] [int] IDENTITY(1,1) NOT NULL,
	[MaTrinhDo] [int] NULL,
	[KieuBangCap] [nvarchar](100) NULL,
	[ThoiHan] [nvarchar](50) NULL,
	[TenBangCap] [nvarchar](100) NULL,
	[Loai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBangCap_GiayChungNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category_attribute_value]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[ChamDut_NhanVien]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamDut_NhanVien](
	[MaQuyetDinh] [int] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[LoaiChamDut] [nvarchar](100) NULL,
	[NgayChamDut] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_BangCap_GiayChungNhan]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[ChiTiet_CongViec_NhanVien]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_CongViec_NhanVien](
	[HeSo] [float] NULL,
	[Bac] [float] NULL,
	[ThangLuong] [nvarchar](100) NULL,
	[MucLuong] [float] NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[MaCongViec] [int] NOT NULL,
 CONSTRAINT [PK_ChiTiet_CongViec_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[MaCongViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_NhiemVu_NhanVien]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_NhiemVu_NhanVien](
	[NgayNhanNhiemVu] [date] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[MaNhiemVu] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChungChi]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChungChi](
	[MaChungChi] [int] IDENTITY(1,1) NOT NULL,
	[TenChungChi] [nvarchar](100) NULL,
	[ThoiHan] [nvarchar](50) NULL,
	[KieuChungChi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChungChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChungChi_NhanVien]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[ChuyenNganh]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenNganh](
	[MaChuyenNganh] [int] IDENTITY(1,1) NOT NULL,
	[TenChuyenNganh] [nvarchar](100) NULL,
	[CapBac] [nvarchar](100) NULL,
	[ChiTiet] [nvarchar](100) NULL,
	[MaNganh] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChuyenNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CongViec]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongViec](
	[TenCongViec] [nvarchar](100) NOT NULL,
	[Loai] [nvarchar](100) NOT NULL,
	[MaCongViec] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCongViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[department_id] [nvarchar](150) NOT NULL,
	[department_name] [nvarchar](150) NOT NULL,
	[department_type] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DiemDanh_NangSuatLaoDong]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh_NangSuatLaoDong](
	[MaDiemDanh] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[NgayDiemDanh] [date] NULL,
	[CaDiemDanh] [int] NULL,
	[ThoiGianThucTeDiemDanh] [datetime] NULL,
	[MaDonVi] [nvarchar](150) NOT NULL,
	[NangSuatLaoDong] [nvarchar](100) NULL,
	[HeSoChiaLuong] [float] NULL,
	[LuongTruocDuyet] [float] NULL,
	[LuongSauDuyet] [float] NULL,
	[DuBaoNguyCo] [nvarchar](1000) NULL,
	[GiaiPhapNguyCo] [nvarchar](1000) NULL,
	[LyDoVangMat] [nvarchar](1000) NULL,
 CONSTRAINT [PK__DiemDanh__1512439D84C5FA52] PRIMARY KEY CLUSTERED 
(
	[MaDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DieuDong_NhanVien]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DieuDong_NhanVien](
	[MaQuyetDinh] [int] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[LyDoDieuDong] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Documentary_big_maintain_details]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_big_maintain_details](
	[equipment_big_maintain_status] [int] NOT NULL,
	[remodel_type] [nvarchar](150) NOT NULL,
	[end_date] [date] NOT NULL,
	[next_remodel_type] [nvarchar](150) NOT NULL,
	[next_end_time] [date] NOT NULL,
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
/****** Object:  Table [dbo].[Documentary_liquidation_details]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Documentary_maintain_details]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_maintain_details](
	[equipment_maintain_status] [int] NOT NULL,
	[maintain_type] [nvarchar](150) NOT NULL,
	[finish_date_plan] [date] NOT NULL,
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
/****** Object:  Table [dbo].[Documentary_moveline_details]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_moveline_details](
	[equipment_moveline_status] [int] NOT NULL,
	[department_detail] [nvarchar](150) NOT NULL,
	[date_to] [date] NOT NULL,
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
/****** Object:  Table [dbo].[Documentary_repair_details]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentary_repair_details](
	[equipment_repair_status] [int] NOT NULL,
	[repair_type] [nvarchar](150) NOT NULL,
	[repair_reason] [nvarchar](150) NOT NULL,
	[finish_date_plan] [date] NOT NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK__Document__91679028E1AEF922] PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentary_revoke_details]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Equipment]    Script Date: 9/25/2019 6:50:51 PM ******/
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
	[nearest_Maintenance_Day] [date] NOT NULL,
	[total_operating_hours] [int] NOT NULL,
	[current_Status] [nvarchar](150) NOT NULL,
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
/****** Object:  Table [dbo].[Equipment_attribute]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Equipment_category]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Equipment_category_attribute]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Equipment_Inspection]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_Inspection](
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[documentary_id] [int] NOT NULL,
	[equipmentId] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[documentary_id] ASC,
	[equipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fuel_activities_consumption]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[GhiChu]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GhiChu](
	[MaGhiChu] [int] IDENTITY(1,1) NOT NULL,
	[MaThucHien] [int] NOT NULL,
	[MaKeHoach] [int] NOT NULL,
	[NoiDungGhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGhiChu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiayTo]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[HoSo]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSo](
	[TrangThaiHoSo] [nvarchar](100) NULL,
	[NgayNhanHoSo] [nvarchar](100) NULL,
	[NguoiGiaoHoSo] [nvarchar](100) NULL,
	[CamKetTuyenDung] [nvarchar](100) NULL,
	[QuyetDinhTiepNhanDVC] [nvarchar](100) NULL,
	[QDChamDutHopDongDVC] [nvarchar](100) NULL,
	[NLDHocTheoChiTieuCTDT] [nvarchar](100) NULL,
	[NguoiBanGiaoBangNhapKho] [nvarchar](100) NULL,
	[NguoiGiuHoSo] [nvarchar](100) NULL,
	[MaNV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incident]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[KeHoach_TieuChi]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeHoach_TieuChi](
	[MaKeHoach] [int] IDENTITY(1,1) NOT NULL,
	[MaPhongBan] [nvarchar](150) NOT NULL,
	[MaTieuChi] [int] NOT NULL,
	[ThangKeHoach] [int] NULL,
	[NamKeHoach] [int] NULL,
	[SoNgayLamViec] [int] NULL,
	[SanLuongKeHoach] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKeHoach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KeHoach_TieuChi_VatLieuSanXuat]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeHoach_TieuChi_VatLieuSanXuat](
	[MaKeHoach] [int] NOT NULL,
	[MaTieuChi_VatLieuSanXuat] [int] NOT NULL,
	[TietDienDao] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKeHoach] ASC,
	[MaTieuChi_VatLieuSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuBoSungSYLL]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuBoSungSYLL](
	[NamBoSung] [nvarchar](100) NOT NULL,
	[DotBoSung] [nvarchar](100) NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NamBoSung] ASC,
	[DotBoSung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Maintain_Car]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Maintain_Car_Detail]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Module]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Nganh]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[MaNganh] [int] IDENTITY(1,1) NOT NULL,
	[TenNganh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiUyQuyenLayHoSo_BaoHiem]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[NhanVien]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[Tenkhac] [nvarchar](100) NULL,
	[GioiTinh] [bit] NOT NULL,
	[CapUyHienTai] [nvarchar](100) NULL,
	[CapUyKiem] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](100) NULL,
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
	[TrinhDoHocVan] [nvarchar](100) NULL,
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
	[SoCMND] [char](20) NULL,
	[NgayCapCMND] [date] NULL,
	[NoiCapCMND] [nvarchar](100) NULL,
	[NgayDiLam] [nvarchar](100) NULL,
	[TenPhanXuong] [nvarchar](100) NULL,
	[TrangThaiLamViec] [nvarchar](100) NULL,
	[MaPhongBan] [nvarchar](150) NOT NULL,
	[MaUyQuyen] [int] NULL,
	[SoBHXH] [nvarchar](100) NULL,
	[NgayTraBHXH] [date] NULL,
 CONSTRAINT [PK__NhanVien__2725D70AC587C2A2] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhiemVu]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[QuanHeGiaDinh]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanHeGiaDinh](
	[LoaiGiaDinh] [nvarchar](100) NOT NULL,
	[MoiQuanHe] [nvarchar](100) NOT NULL,
	[NgaySinh] [date] NULL,
	[LyLich] [nvarchar](100) NULL,
	[MaNV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LoaiGiaDinh] ASC,
	[MoiQuanHe] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuaTrinhCongTac]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuaTrinhCongTac](
	[ChucDanh] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](100) NULL,
	[DonViCongTac] [nvarchar](100) NOT NULL,
	[NgayBatDau] [date] NOT NULL,
	[NgayKetThuc] [date] NULL,
	[MaNV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DonViCongTac] ASC,
	[NgayBatDau] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuyetDinh]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyetDinh](
	[MaQuyetDinh] [int] IDENTITY(1,1) NOT NULL,
	[SoQuyetDinh] [nvarchar](50) NULL,
	[NgayQuyetDinh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supply]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Supply_Documentary_Equipment]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Supply_tieuhao]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[SupplyPlan]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplyPlan](
	[supplyid] [nvarchar](150) NOT NULL,
	[departmentid] [nvarchar](150) NOT NULL,
	[equipmentid] [nvarchar](150) NOT NULL,
	[date] [date] NOT NULL,
	[dinh_muc] [float] NOT NULL,
	[quantity_plan] [int] NOT NULL,
	[quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[supplyid] ASC,
	[departmentid] ASC,
	[equipmentid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThucHien_TieuChi]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThucHien_TieuChi](
	[MaThucHien] [int] IDENTITY(1,1) NOT NULL,
	[MaPhongBan] [nvarchar](150) NOT NULL,
	[MaTieuChi] [int] NOT NULL,
	[NgayThucHien] [date] NULL,
	[CaThucHien] [int] NULL,
	[SanLuongThucHien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThucHien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThucHien_TieuChi_VatLieuSanXuat]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThucHien_TieuChi_VatLieuSanXuat](
	[MaThucHien] [int] NOT NULL,
	[MaTieuChi_VatLieuSanXuat] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThucHien] ASC,
	[MaTieuChi_VatLieuSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TieuChi]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TieuChi](
	[MaTieuChi] [int] IDENTITY(1,1) NOT NULL,
	[TenTieuChi] [nvarchar](100) NULL,
	[DonViDo] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TieuChi_VatLieuSanXuat]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TieuChi_VatLieuSanXuat](
	[MaTieuChi_VatLieuSanXuat] [int] IDENTITY(1,1) NOT NULL,
	[MaTieuChi] [int] NOT NULL,
	[MaVatLieu] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTieuChi_VatLieuSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrinhDo]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[Truong]    Script Date: 9/25/2019 6:50:51 PM ******/
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
/****** Object:  Table [dbo].[TuyenDung_NhanVien]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuyenDung_NhanVien](
	[MaQuyetDinh] [int] NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyetDinh] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VatLieuSanXuat]    Script Date: 9/25/2019 6:50:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VatLieuSanXuat](
	[MaVatLieu] [int] IDENTITY(1,1) NOT NULL,
	[LoaiVatLieu] [nvarchar](100) NULL,
	[TenVatLieu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVatLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD FOREIGN KEY([equipmentid])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[BangCap_GiayChungNhan]  WITH CHECK ADD  CONSTRAINT [FK_BangCap_ChuyenNganh] FOREIGN KEY([MaChuyenNghanh])
REFERENCES [dbo].[ChuyenNganh] ([MaChuyenNganh])
GO
ALTER TABLE [dbo].[BangCap_GiayChungNhan] CHECK CONSTRAINT [FK_BangCap_ChuyenNganh]
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
ALTER TABLE [dbo].[ChamDut_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaQuyetDinh])
REFERENCES [dbo].[QuyetDinh] ([MaQuyetDinh])
GO
ALTER TABLE [dbo].[ChiTiet_BangCap_GiayChungNhan]  WITH CHECK ADD FOREIGN KEY([MaBangCap_GiayChungNhan])
REFERENCES [dbo].[BangCap_GiayChungNhan] ([MaBangCap_GiayChungNhan])
GO
ALTER TABLE [dbo].[ChiTiet_BangCap_GiayChungNhan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_BangCap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTiet_BangCap_GiayChungNhan] CHECK CONSTRAINT [FK_ChiTiet_BangCap_NhanVien]
GO
ALTER TABLE [dbo].[ChiTiet_CongViec_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_CongViec_NhanVien_CongViec] FOREIGN KEY([MaCongViec])
REFERENCES [dbo].[CongViec] ([MaCongViec])
GO
ALTER TABLE [dbo].[ChiTiet_CongViec_NhanVien] CHECK CONSTRAINT [FK_ChiTiet_CongViec_NhanVien_CongViec]
GO
ALTER TABLE [dbo].[ChiTiet_CongViec_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_CongViec_NhanVien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTiet_CongViec_NhanVien] CHECK CONSTRAINT [FK_ChiTiet_CongViec_NhanVien_NhanVien]
GO
ALTER TABLE [dbo].[ChiTiet_NhiemVu_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTiet_NhiemVu_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_NhiemVu_NhanVien_NhiemVu] FOREIGN KEY([MaNhiemVu])
REFERENCES [dbo].[NhiemVu] ([MaNhiemVu])
GO
ALTER TABLE [dbo].[ChiTiet_NhiemVu_NhanVien] CHECK CONSTRAINT [FK_ChiTiet_NhiemVu_NhanVien_NhiemVu]
GO
ALTER TABLE [dbo].[ChungChi_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaChungChi])
REFERENCES [dbo].[ChungChi] ([MaChungChi])
GO
ALTER TABLE [dbo].[ChungChi_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChuyenNganh]  WITH CHECK ADD FOREIGN KEY([MaNganh])
REFERENCES [dbo].[Nganh] ([MaNganh])
GO
ALTER TABLE [dbo].[DiemDanh_NangSuatLaoDong]  WITH CHECK ADD  CONSTRAINT [FK__DiemDanh___MaDon__3C34F16F] FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[DiemDanh_NangSuatLaoDong] CHECK CONSTRAINT [FK__DiemDanh___MaDon__3C34F16F]
GO
ALTER TABLE [dbo].[DiemDanh_NangSuatLaoDong]  WITH CHECK ADD  CONSTRAINT [FK__DiemDanh_N__MaNV__3D2915A8] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DiemDanh_NangSuatLaoDong] CHECK CONSTRAINT [FK__DiemDanh_N__MaNV__3D2915A8]
GO
ALTER TABLE [dbo].[DieuDong_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaQuyetDinh])
REFERENCES [dbo].[QuyetDinh] ([MaQuyetDinh])
GO
ALTER TABLE [dbo].[DieuDong_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Documentary]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__depar__40058253] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary] CHECK CONSTRAINT [FK__Documenta__depar__40058253]
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
ALTER TABLE [dbo].[Documentary_liquidation_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__43D61337] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_liquidation_details] CHECK CONSTRAINT [FK__Documenta__equip__43D61337]
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
ALTER TABLE [dbo].[Documentary_repair_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__489AC854] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_repair_details] CHECK CONSTRAINT [FK__Documenta__docum__489AC854]
GO
ALTER TABLE [dbo].[Documentary_repair_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__498EEC8D] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_repair_details] CHECK CONSTRAINT [FK__Documenta__equip__498EEC8D]
GO
ALTER TABLE [dbo].[Documentary_revoke_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__docum__4A8310C6] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documentary_revoke_details] CHECK CONSTRAINT [FK__Documenta__docum__4A8310C6]
GO
ALTER TABLE [dbo].[Documentary_revoke_details]  WITH CHECK ADD  CONSTRAINT [FK__Documenta__equip__4B7734FF] FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Documentary_revoke_details] CHECK CONSTRAINT [FK__Documenta__equip__4B7734FF]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
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
ALTER TABLE [dbo].[Equipment_Inspection]  WITH CHECK ADD  CONSTRAINT [FK__Equipment__docum__503BEA1C] FOREIGN KEY([documentary_id])
REFERENCES [dbo].[Documentary] ([documentary_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Equipment_Inspection] CHECK CONSTRAINT [FK__Equipment__docum__503BEA1C]
GO
ALTER TABLE [dbo].[Equipment_Inspection]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Fuel_activities_consumption]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[Fuel_activities_consumption]  WITH CHECK ADD FOREIGN KEY([fuel_type])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[GhiChu]  WITH CHECK ADD FOREIGN KEY([MaKeHoach])
REFERENCES [dbo].[KeHoach_TieuChi] ([MaKeHoach])
GO
ALTER TABLE [dbo].[GhiChu]  WITH CHECK ADD FOREIGN KEY([MaThucHien])
REFERENCES [dbo].[ThucHien_TieuChi] ([MaThucHien])
GO
ALTER TABLE [dbo].[GiayTo]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoSo]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Incident]  WITH CHECK ADD FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Incident]  WITH CHECK ADD FOREIGN KEY([equipmentId])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[KeHoach_TieuChi]  WITH CHECK ADD FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[KeHoach_TieuChi]  WITH CHECK ADD FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TieuChi] ([MaTieuChi])
GO
ALTER TABLE [dbo].[KeHoach_TieuChi_VatLieuSanXuat]  WITH CHECK ADD FOREIGN KEY([MaKeHoach])
REFERENCES [dbo].[KeHoach_TieuChi] ([MaKeHoach])
GO
ALTER TABLE [dbo].[KeHoach_TieuChi_VatLieuSanXuat]  WITH CHECK ADD FOREIGN KEY([MaTieuChi_VatLieuSanXuat])
REFERENCES [dbo].[TieuChi_VatLieuSanXuat] ([MaTieuChi_VatLieuSanXuat])
GO
ALTER TABLE [dbo].[LichSuBoSungSYLL]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[HoSo] ([MaNV])
GO
ALTER TABLE [dbo].[Maintain_Car]  WITH CHECK ADD FOREIGN KEY([departmentid])
REFERENCES [dbo].[Department] ([department_id])
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
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaUyQuyen])
REFERENCES [dbo].[NguoiUyQuyenLayHoSo_BaoHiem] ([MaUyQuyen])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Department] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Department]
GO
ALTER TABLE [dbo].[NhiemVu]  WITH CHECK ADD  CONSTRAINT [FK_NhiemVu_ChungChi] FOREIGN KEY([MaChungChi])
REFERENCES [dbo].[ChungChi] ([MaChungChi])
GO
ALTER TABLE [dbo].[NhiemVu] CHECK CONSTRAINT [FK_NhiemVu_ChungChi]
GO
ALTER TABLE [dbo].[QuanHeGiaDinh]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
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
ALTER TABLE [dbo].[Supply_tieuhao]  WITH CHECK ADD FOREIGN KEY([departmentid])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[Supply_tieuhao]  WITH CHECK ADD FOREIGN KEY([supplyid])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD FOREIGN KEY([departmentid])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD FOREIGN KEY([equipmentid])
REFERENCES [dbo].[Equipment] ([equipmentId])
GO
ALTER TABLE [dbo].[SupplyPlan]  WITH CHECK ADD FOREIGN KEY([supplyid])
REFERENCES [dbo].[Supply] ([supply_id])
GO
ALTER TABLE [dbo].[ThucHien_TieuChi]  WITH CHECK ADD FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[Department] ([department_id])
GO
ALTER TABLE [dbo].[ThucHien_TieuChi]  WITH CHECK ADD FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TieuChi] ([MaTieuChi])
GO
ALTER TABLE [dbo].[ThucHien_TieuChi_VatLieuSanXuat]  WITH CHECK ADD FOREIGN KEY([MaThucHien])
REFERENCES [dbo].[ThucHien_TieuChi] ([MaThucHien])
GO
ALTER TABLE [dbo].[ThucHien_TieuChi_VatLieuSanXuat]  WITH CHECK ADD FOREIGN KEY([MaTieuChi_VatLieuSanXuat])
REFERENCES [dbo].[TieuChi_VatLieuSanXuat] ([MaTieuChi_VatLieuSanXuat])
GO
ALTER TABLE [dbo].[TieuChi_VatLieuSanXuat]  WITH CHECK ADD FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TieuChi] ([MaTieuChi])
GO
ALTER TABLE [dbo].[TieuChi_VatLieuSanXuat]  WITH CHECK ADD FOREIGN KEY([MaVatLieu])
REFERENCES [dbo].[VatLieuSanXuat] ([MaVatLieu])
GO
ALTER TABLE [dbo].[TuyenDung_NhanVien]  WITH CHECK ADD FOREIGN KEY([MaQuyetDinh])
REFERENCES [dbo].[QuyetDinh] ([MaQuyetDinh])
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account_Right_Detail'
GO
USE [master]
GO
ALTER DATABASE [QUANGHANHABC] SET  READ_WRITE 
GO
