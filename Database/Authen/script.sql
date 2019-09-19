USE [QUANGHANHABC]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/16/2019 10:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [nvarchar](10) NOT NULL,
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
/****** Object:  Table [dbo].[Account_Right]    Script Date: 9/16/2019 10:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Right](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [nvarchar](50) NULL,
	[GroupID] [nvarchar](50) NULL,
	[Right] [nvarchar](70) NULL,
	[isBasic] [bit] NULL,
 CONSTRAINT [PK_Account_Right] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account_Right_Detail]    Script Date: 9/16/2019 10:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Right_Detail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [nvarchar](50) NOT NULL,
	[RightID] [int] NOT NULL,
 CONSTRAINT [PK_Account_Right_Detail] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[RightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 9/16/2019 10:37:41 PM ******/
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
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'1', N'Trần Thị Thương', N'thuongtt', N'thuongtt', N'Chuyên Viên CĐVT', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'10', N'Trần Văn Tú', N'tutv', N'tutv', N'Giám Đốc', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'11', N' Lê Minh Đức', N'duclm', N'duclm', N'Chuyên Viên KCS', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'12', N'Vũ Văn An', N'anvv', N'anvv', N'Chuyên Viên Điều Khiển', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'13', N'Nguyễn Đức Cương', N'cuongnd', N'cuongnd', N'Quản Đốc PXKT', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'14', N'ADMIN', N'admin', N'admin', N'Quản lí phần mềm', 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'16', N'test1', N'test1', N'', N'Tester', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'18', N'test4', N'test4', N'', N'Tester', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'2', N'Hoàng Bá Long', N'longhb', N'longhb', N'Chuyên Viên CĐVT', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'3', N'Nguyễn Văn Trữ', N'trunv', N'trunv', N'Chuyên Viên CĐVT', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'4', N'Lại Bình Minh', N'minhlb', N'minhlb', N'Chuyên Viên CĐVT', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'5', N'Nguyễn Văn Học', N'hocnv', N'hocnv', N'Phó Phòng TCLĐ', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'6', N'Nguyễn Thị Hòa', N'hoant', N'hoant', N'Chuyên Viên TCLĐ', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'7', N'Nguyễn Bá Vương', N'vuongnb', N'vuongnb', N'Chuyên Viên TCLĐ', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'8', N'Nguyễn Thị Trà', N'trant', N'trant', N'Chuyên Viên TCLĐ', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [ADMIN]) VALUES (N'9', N'Nguyễn Văn Long', N'longnv', N'longnv', N'Chuyên Viên TCLĐ', 0, 0, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Account_Right] ON 

INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (1, N'1', N'1', N'Thêm mới thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (2, N'1', N'1', N'Cập nhật ngày kiểm định thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (3, N'1', N'1', N'Xuất ra excel danh sách thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (4, N'1', N'1', N'Sửa thông tin thiết bị huy động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (5, N'1', N'1', N'Xóa thông tin thiết bị huy động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (6, N'1', N'1', N'Xem màn huy động thiết bị', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (7, N'1', N'29', N'Xem màn cập nhật hoạt động thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (8, N'1', N'29', N'Thêm cập nhật hoạt động thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (9, N'1', N'29', N'Chỉnh sửa cập nhập hoạt động thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (10, N'1', N'2', N'Xem màn huy động ô tô', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (11, N'1', N'2', N'Thêm mới ô tô', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (12, N'1', N'2', N'Sửa thông tin ô tô', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (13, N'1', N'3', N'Xem màn cập nhật hoạt động ô tô', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (14, N'1', N'3', N'Thêm cập nhật hoạt động ô tô', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (15, N'1', N'3', N'Chỉnh sửa cập nhật hoạt động ô tô', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (16, N'1', N'4', N'Xem màn bảo dưỡng hằng ngày ô tô', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (17, N'1', N'4', N'Thêm bảo dưỡng hằng ngày ô tô', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (18, N'1', N'4', N'Chỉnh sửa bảo dưỡng hàng ngày ô tô', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (19, N'1', N'5', N'Xem màn thông tin sự cố', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (20, N'1', N'5', N'Thêm sự cố', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (21, N'1', N'5', N'Chỉnh sửa/Cập nhật sự cố', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (22, N'1', N'5', N'Xóa sự cố', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (23, N'1', N'6', N'Xem danh sách quyết định chưa xử lí', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (24, N'1', N'7', N'Xem danh sách quyết định đã xử lí', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (25, N'1', N'8', N'Xem màn danh sách thiết bị chờ nghiệm thu', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (26, N'1', N'9', N'Xem màn danh sách thiết bị đã nghiệm thu', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (27, N'1', N'10', N'Xem màn xin cấp vật tư sửa chữa thường xuyên', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (28, N'1', N'11', N'Xem màn tổng hợp vật tư sửa chữa thường xuyên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (29, N'1', N'12', N'Xem màn tiêu hao vật tư', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (30, N'1', N'13', N'Danh sách quyết định sửa chữa', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (31, N'1', N'14', N'Danh sách quyết định bảo dưỡng', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (33, N'1', N'10', N'Thêm vật tư sửa chữa thường xuyên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (34, N'1', N'10', N'Chỉnh sửa vật tư sửa chữa thường xuyên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (35, N'1', N'11', N'Chỉnh sửa tổng hợp vật tư', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (36, N'1', N'12', N'Thêm tiêu hao vật tư', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (37, N'1', N'12', N'Chỉnh sửa tiêu hao vật tư', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (38, N'1', N'16', N'Danh sách quyết định điều động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (39, N'1', N'17', N'Danh sách quyết định thu hồi', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (40, N'1', N'18', N'Danh sách quyết định thanh lí', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (41, N'1', N'19', N'Danh sách quyết định kiểm định', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (42, N'1', N'20', N'Danh sách quyết định trùng đại tu', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (43, N'1', N'21', N'Báo cáo sử dụng năng lượng', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (44, N'1', N'22', N'Báo cáo sử dụng nhiên liệu', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (45, N'1', N'23', N'Báo cáo huy động bơm thoát nước', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (46, N'1', N'24', N'Báo cáo thanh lí thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (47, N'1', N'25', N'Báo cáo bảo dưỡng thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (48, N'1', N'26', N'Báo cáo sữa chữa thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (49, N'1', N'27', N'Báo cáo kiểm định thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (50, N'1', N'28', N'Báo cáo thu hồi thiết bị', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (51, N'2', N'1', N'Xem danh sách hồ sơ nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (52, N'2', N'1', N'Thêm hồ sơ nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (53, N'2', N'1', N'Chỉnh sửa hồ sơ nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (54, N'2', N'1', N'Xem lịch sử làm việc/điều chuyển nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (55, N'2', N'1', N'Xóa hồ sơ nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (56, N'2', N'1', N'Xem chi tiết hồ sơ nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (57, N'2', N'8', N'Xem báo cáo thực hiện lao động, tiền lương công nhân', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (58, N'2', N'2', N'Xem danh sách chứng chỉ lao động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (59, N'2', N'2', N'Thêm chứng chỉ lao động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (60, N'2', N'2', N'Chỉnh sửa chứng chỉ lao động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (61, N'2', N'2', N'Xóa chứng chỉ lao động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (62, N'2', N'3', N'Danh sách bảo hộ lao động', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (63, N'2', N'4', N'Xem bảng tổng hợp toàn công ty', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (64, N'2', N'5', N'Xem màn điều động nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (65, N'2', N'5', N'Điều động nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (67, N'2', N'6', N'Danh sách khen thưởng phòng ban', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (68, N'2', N'7', N'Xem danh sách kỷ luật nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (69, N'2', N'7', N'Thêm biên bản kỷ luật nhân viên', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (71, N'3', N'2', N'Báo cáo chất lượng than tồn kho - tiêu thụ và sản xuất', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (72, N'3', N'2', N'Sửa báo cáo chất lượng than tồn kho - tiêu thụ và sản xuất', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (73, N'3', N'1', N'Nhập báo cáo chất lượng than tồn kho - tiêu thụ và sản xuất', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (74, N'4', N'1', N'Tổng hợp phòng điều khiển', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (75, N'4', N'2', N'Màn báo cáo chi tiết sản xuất than', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (76, N'4', N'2', N'Chỉnh sửa báo cáo chi tiết sản xuất than', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (77, N'4', N'3', N'Báo cáo nhân lực ngày/tháng', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (78, N'4', N'3', N'Chỉnh sửa báo cáo nhân lực ngày tháng', 0)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (79, N'4', N'4', N'Báo cáo sự cố', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (80, N'5', N'1', N'Ban giám đốc', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (81, N'6', N'1', N'Màn tổng hợp phân xưởng khai thác', 1)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (82, N'1', N'8', N'Nghiệm thu thiết bị', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (83, N'1', N'13', N'Thêm danh sách quyết định sửa chữa', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (84, N'1', N'13', N'Chỉnh sửa/Cập nhật quyết định sửa chữa', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (85, N'1', N'14', N'Thêm danh sách quyết định bảo dưỡng', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (86, N'1', N'14', N'Chỉnh sửa/Cập nhật quyết định bảo dưỡng', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (87, N'1', N'16', N'Thêm danh sách quyết định điều động', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (88, N'1', N'16', N'Chỉnh sửa/Cập nhật quyết định điều động', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (89, N'1', N'17', N'Thêm danh sách quyết định thu hồi', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (90, N'1', N'17', N'Chỉnh sửa/Cập nhật quyết định thu hồi', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (91, N'1', N'18', N'Thêm danh sách quyết định thanh lí', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (92, N'1', N'18', N'Chỉnh sửa/Cập nhật quyết định thanh lí', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (93, N'1', N'19', N'Thêm danh sách quyết định kiểm định', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (94, N'1', N'19', N'Chỉnh sửa/Cập nhật quyết định kiểm định', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (95, N'1', N'20', N'Thêm danh sách quyết định trung đại tu', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (96, N'1', N'20', N'Chỉnh sửa/Cập nhật quyết định trung đại tu', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (97, N'2', N'3', N'Xác nhận bảo hộ lao động', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (98, N'2', N'9', N'Xem chứng chỉ,chứng nhận đào tạo', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (99, N'2', N'10', N'Xem màn đăng kí công việc', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (100, N'2', N'10', N'Chỉnh sửa bảng đăng kí công việc', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (101, N'2', N'11', N'Xem báo cáo tình trạng chứng chỉ công việc', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (102, N'2', N'12', N'Xem màn đã xữ lí quyết định điều động', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (103, N'2', N'13', N'Xem màn chưa xử lí quyết định điều động', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (104, N'2', N'14', N'Màn tổng hợp các đơn vị chấm dứt tuyển dụng', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (105, N'2', N'14', N'Chỉnh sửa tổng hợp các đơn vị chấm dứt tuyển dụng', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (106, N'2', N'15', N'Xem màn tổng hợp tuyển dụng', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (107, N'2', N'15', N'Chỉnh sửa tổng hợp tuyển dụng', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (108, N'2', N'16', N'Xem màn tổng hợp chấm dứt', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (109, N'2', N'16', N'Chỉnh sửa tổng hợp chấm dứt', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (110, N'2', N'17', N'Xem báo cáo tăng giảm lao động', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (111, N'2', N'18', N'Xem màn biên bản chung', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (112, N'2', N'19', N'Xem lịch sử thay đổi dữ liệu', NULL)
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (113, N'6', N'1', N'Nhập dữ liệu phân xưởng khai thác', NULL)
SET IDENTITY_INSERT [dbo].[Account_Right] OFF
SET IDENTITY_INSERT [dbo].[Account_Right_Detail] ON 

INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2223, N'1', 1)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2224, N'1', 6)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2387, N'14', 1)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2388, N'14', 2)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2389, N'14', 3)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2390, N'14', 4)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2391, N'14', 5)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2392, N'14', 6)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2393, N'14', 7)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2394, N'14', 8)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2395, N'14', 9)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2396, N'14', 10)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2397, N'14', 11)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2398, N'14', 12)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2399, N'14', 13)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2400, N'14', 14)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2401, N'14', 15)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2402, N'14', 16)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2403, N'14', 17)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2404, N'14', 18)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2405, N'14', 19)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2406, N'14', 20)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2407, N'14', 21)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2408, N'14', 22)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2409, N'14', 23)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2410, N'14', 24)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2411, N'14', 25)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2412, N'14', 26)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2413, N'14', 27)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2414, N'14', 28)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2415, N'14', 29)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2416, N'14', 30)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2417, N'14', 31)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2418, N'14', 32)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2419, N'14', 33)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2420, N'14', 34)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2421, N'14', 35)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2422, N'14', 36)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2423, N'14', 37)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2424, N'14', 38)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2425, N'14', 39)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2426, N'14', 40)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2427, N'14', 41)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2428, N'14', 42)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2429, N'14', 43)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2430, N'14', 44)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2431, N'14', 45)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2432, N'14', 46)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2433, N'14', 47)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2434, N'14', 48)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2435, N'14', 49)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2436, N'14', 50)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2437, N'14', 51)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2438, N'14', 52)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2439, N'14', 53)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2440, N'14', 54)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2441, N'14', 55)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2442, N'14', 56)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2443, N'14', 57)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2444, N'14', 58)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2445, N'14', 59)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2446, N'14', 60)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2447, N'14', 61)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2448, N'14', 62)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2449, N'14', 63)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2450, N'14', 64)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2451, N'14', 65)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2452, N'14', 66)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2453, N'14', 67)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2454, N'14', 68)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2455, N'14', 69)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2456, N'14', 70)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2457, N'14', 71)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2458, N'14', 72)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2459, N'14', 73)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2460, N'14', 74)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2461, N'14', 75)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2462, N'14', 76)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2463, N'14', 77)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2464, N'14', 78)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2465, N'14', 79)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2466, N'14', 80)
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2467, N'14', 81)
SET IDENTITY_INSERT [dbo].[Account_Right_Detail] OFF
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'7', N'ADMIN')
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'5', N'BGD')
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'1', N'CDVT')
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'4', N'DK')
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'3', N'KCS')
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'6', N'PXKT')
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'2', N'TCLD')
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account_Right_Detail'
GO
