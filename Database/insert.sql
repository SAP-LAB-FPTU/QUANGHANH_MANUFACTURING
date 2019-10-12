USE [QUANGHANHABC]
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (1, N'Than Hầm Lò')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (2, N'Than Lộ Thiên')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (3, N'Đất Đá Bóc')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (4, N'Nhập Dương Huy')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (5, N'Mét Lò Đào')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (6, N'Mét Lò Neo')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (7, N'Mét Lò Xén')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (8, N'Than Sàng Tuyển')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (9, N'Than Tiêu Thụ')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (10, N'Doanh Thu')
GO
INSERT [dbo].[NhomTieuChi] ([MaNhomTieuChi], [TenNhomTieuChi]) VALUES (11, N'Đá Xít Xuất Kho')
GO
SET IDENTITY_INSERT [dbo].[TieuChi] ON 

GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (1, N'Than đào lò', N'Tấn', 1)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (2, N'Than khai thác', N'Tấn', 1)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (3, N'LT Tự Làm', N'Tấn', 2)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (4, N'LT Thuê Ngoài', N'Tấn', 2)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (5, N'Đất đá bóc', N'Mét khối', 3)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (6, N'Nhập Dương Huy', N'Tấn', 4)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (7, N'Mét Lò Đào', N'Mét', 5)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (9, N'Mét Lò Neo', N'Mét', 6)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (10, N'ST - Cục 4a.2 (Ak 7,01-12,00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (11, N'ST - Cục 5a.2  (Ak = 8.01 - 12.00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (12, N'ST - Cám 4a.1(Ak = 19,01 - 23,00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (13, N'ST - Cám 5a.1 (Ak = 27,01 - 30,00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (14, N'ST - Cám 5b.1(Ak = 31,01 - 35,00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (15, N'ST - Cám 6a.1 (Ak = 35,01- 40,00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (16, N'ST - Bùn 3c (Ak = 40,01-:-45,00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (17, N'ST - Cục 1B  (Ak =13.01 - 17.00%)', N'Tấn', 8)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (18, N'Đá Xít Sau Sàng Tuyển', N'Tấn', 11)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (19, N'Méo Lò Xén', N'Mét', 7)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (21, N'TT - Cục 4a.2 (Ak 7,01-12,00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (22, N'TT - Cục 5a.2  (Ak = 8.01 - 12.00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (23, N'TT - Cám 4a.1(Ak = 19,01 - 23,00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (24, N'TT - Cám 5a.1 (Ak = 27,01 - 30,00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (25, N'TT - Cám 5b.1(Ak = 31,01 - 35,00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (26, N'TT - Cám 6a.1 (Ak = 35,01- 40,00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (27, N'TT - Bùn 3c (Ak = 40,01-:-45,00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (28, N'TT - Cục 1B  (Ak =13.01 - 17.00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (29, N'TT - Cục 1B  (Ak =13.01 - 17.00%)', N'Tấn', 9)
GO
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DonViDo], [MaNhomTieuChi]) VALUES (30, N'Doanh Thu', N'Tỷ', 10)
GO
SET IDENTITY_INSERT [dbo].[TieuChi] OFF
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'AT', N'An toàn', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'BGD', N'Ban giám đốc', N'Điều hành', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'BTK', N'BTK', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'CD', N'Công đoàn', N'Đoàn thể', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'CDVT', N'Cơ điện vận tải', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'CTA', N'Công ty ASEAN', N'Đơn vị sản xuất thuê ngoài', 0)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'CTYDH', N'Công Ty Dương Huy', N'Đơn vị sản xuất thuê ngoài', 0)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'CV', N'CV', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'DK', N'Điều khiển', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'DTM', N'DTM', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'DU', N'Đảng ủy', N'Đoàn thể', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'KCM', N'KCM', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'KCS', N'Kỹ thuật sàng tuyển', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'KH', N'KH', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'KT', N'KT', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXCDM', N'Phân xưởng cơ điện mỏ', N'Phân xưởng thuộc về phục vụ', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXCKSC', N'Phân xưởng cơ khí, sửa chữa', N'Phân xưởng thuộc về phục vụ', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXDL1', N'Công ty Xây lắp mỏ - TKV', N'Đơn vị sản xuất thuê ngoài', 0)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXDL2', N'Liên doanh nhà thầu Công ty CP thương mại - công nghệ CT Thăng Long và Công ty tư vấn Công ty Thăng Long', N'Đơn vị sản xuất thuê ngoài', 0)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXDL3', N'Phân xưởng đào lò 3', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXDL5', N'Phân xưởng đào lò 5', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXDL7', N'Phân xưởng đào lò 7', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXDL8', N'Phân xưởng đào lò 8', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXDS', N'Phân xưởng đời sống', N'Phân xưởng thuộc về phục vụ', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT1', N'Phân xưởng khải thác 1', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT10', N'Phân xưởng khai thác 10', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT11', N'Phân xưởng khai thác 11', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT2', N'Phân xưởng khai thác 2', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT3', N'Phân xưởng khai thác 3', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT4', N'Phân xưởng khai thác 4', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT5', N'Phân xưởng khai thác 5', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT6', N'Phân xưởng khai thác 6', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT7', N'Phân xưởng khai thác 7', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT8', N'Phân xưởng khai thác 8', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXKT9', N'Phân xưởng khai thác 9', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXLT', N'Phân xưởng lộ thiên', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXPV', N'Phân xưởng phục vụ', N'Phân xưởng thuộc về phục vụ', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXST', N'Phân xưởng sàng tuyển', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXTGQLKM', N'Phân xưởng thông gió - quản lý khí mỏ', N'Phân xưởng thuộc về phục vụ', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXVT1', N'Phân xưởng vận tải 1', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXVT2', N'Phân xưởng vận tải 2', N'Phân xưởng sản xuất chính', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'PXXD', N'Phân xưởng xây dựng', N'Phân xưởng thuộc về phục vụ', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'TCLD', N'Tổ chức lao động', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'TD', N'TD', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'TGM', N'TGM', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'TN', N'Thanh niên', N'Đoàn thể', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'VP', N'VP', N'Văn phòng', 1)
GO
INSERT [dbo].[Department] ([department_id], [department_name], [department_type], [isInside]) VALUES (N'YT', N'YT', N'Văn phòng', 1)
GO
SET IDENTITY_INSERT [dbo].[header_ThucHienTheoNgay] ON 

GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x16400B00 AS Date), 1, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x16400B00 AS Date), 2, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x16400B00 AS Date), 3, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x16400B00 AS Date), 4, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x16400B00 AS Date), 5, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x16400B00 AS Date), 6, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x16400B00 AS Date), 7, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x16400B00 AS Date), 8, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x16400B00 AS Date), 9, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x16400B00 AS Date), 10, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x16400B00 AS Date), 11, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x16400B00 AS Date), 12, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x16400B00 AS Date), 13, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x16400B00 AS Date), 14, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x16400B00 AS Date), 15, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x16400B00 AS Date), 16, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x16400B00 AS Date), 17, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x16400B00 AS Date), 18, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x16400B00 AS Date), 19, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x16400B00 AS Date), 20, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x16400B00 AS Date), 21, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x16400B00 AS Date), 22, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x16400B00 AS Date), 23, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x16400B00 AS Date), 24, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x16400B00 AS Date), 25, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x16400B00 AS Date), 26, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x16400B00 AS Date), 27, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x16400B00 AS Date), 28, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x16400B00 AS Date), 29, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x16400B00 AS Date), 30, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x16400B00 AS Date), 31, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x16400B00 AS Date), 32, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x16400B00 AS Date), 33, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x16400B00 AS Date), 34, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x16400B00 AS Date), 35, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x16400B00 AS Date), 36, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x16400B00 AS Date), 37, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x16400B00 AS Date), 38, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x16400B00 AS Date), 39, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x16400B00 AS Date), 40, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x16400B00 AS Date), 41, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x16400B00 AS Date), 42, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x16400B00 AS Date), 43, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x16400B00 AS Date), 44, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x16400B00 AS Date), 45, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x16400B00 AS Date), 46, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x16400B00 AS Date), 47, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x16400B00 AS Date), 48, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x16400B00 AS Date), 49, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x16400B00 AS Date), 50, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x16400B00 AS Date), 51, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x16400B00 AS Date), 52, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x16400B00 AS Date), 53, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x16400B00 AS Date), 54, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x16400B00 AS Date), 55, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x16400B00 AS Date), 56, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x16400B00 AS Date), 57, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x16400B00 AS Date), 58, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x16400B00 AS Date), 59, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x16400B00 AS Date), 60, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x16400B00 AS Date), 61, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x16400B00 AS Date), 62, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x16400B00 AS Date), 63, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x17400B00 AS Date), 64, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x17400B00 AS Date), 65, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x17400B00 AS Date), 66, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x17400B00 AS Date), 67, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x17400B00 AS Date), 68, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x17400B00 AS Date), 69, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x17400B00 AS Date), 70, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x17400B00 AS Date), 71, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x17400B00 AS Date), 72, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x17400B00 AS Date), 73, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x17400B00 AS Date), 74, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x17400B00 AS Date), 75, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x17400B00 AS Date), 76, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x17400B00 AS Date), 77, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x17400B00 AS Date), 78, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x17400B00 AS Date), 79, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x17400B00 AS Date), 80, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x17400B00 AS Date), 81, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x17400B00 AS Date), 82, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x17400B00 AS Date), 83, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x17400B00 AS Date), 84, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x17400B00 AS Date), 85, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x17400B00 AS Date), 86, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x17400B00 AS Date), 87, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x17400B00 AS Date), 88, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x17400B00 AS Date), 89, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x17400B00 AS Date), 90, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x17400B00 AS Date), 91, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x17400B00 AS Date), 92, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x17400B00 AS Date), 93, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x17400B00 AS Date), 94, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x17400B00 AS Date), 95, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x17400B00 AS Date), 96, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x17400B00 AS Date), 97, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x17400B00 AS Date), 98, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x17400B00 AS Date), 99, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x17400B00 AS Date), 100, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x17400B00 AS Date), 101, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x17400B00 AS Date), 102, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x17400B00 AS Date), 103, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x17400B00 AS Date), 104, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x17400B00 AS Date), 105, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x17400B00 AS Date), 106, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x17400B00 AS Date), 107, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x17400B00 AS Date), 108, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x17400B00 AS Date), 109, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x17400B00 AS Date), 110, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x17400B00 AS Date), 111, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x17400B00 AS Date), 112, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x17400B00 AS Date), 113, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x17400B00 AS Date), 114, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x17400B00 AS Date), 115, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x17400B00 AS Date), 116, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x17400B00 AS Date), 117, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x17400B00 AS Date), 118, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x17400B00 AS Date), 119, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x17400B00 AS Date), 120, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x17400B00 AS Date), 121, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x17400B00 AS Date), 122, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x17400B00 AS Date), 123, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x17400B00 AS Date), 124, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x17400B00 AS Date), 125, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x17400B00 AS Date), 126, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x18400B00 AS Date), 127, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x18400B00 AS Date), 128, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x18400B00 AS Date), 129, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x18400B00 AS Date), 130, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x18400B00 AS Date), 131, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x18400B00 AS Date), 132, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x18400B00 AS Date), 133, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x18400B00 AS Date), 134, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x18400B00 AS Date), 135, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x18400B00 AS Date), 136, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x18400B00 AS Date), 137, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x18400B00 AS Date), 138, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x18400B00 AS Date), 139, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x18400B00 AS Date), 140, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x18400B00 AS Date), 141, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x18400B00 AS Date), 142, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x18400B00 AS Date), 143, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x18400B00 AS Date), 144, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x18400B00 AS Date), 145, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x18400B00 AS Date), 146, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x18400B00 AS Date), 147, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x18400B00 AS Date), 148, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x18400B00 AS Date), 149, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x18400B00 AS Date), 150, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x18400B00 AS Date), 151, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x18400B00 AS Date), 152, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x18400B00 AS Date), 153, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x18400B00 AS Date), 154, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x18400B00 AS Date), 155, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x18400B00 AS Date), 156, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x18400B00 AS Date), 157, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x18400B00 AS Date), 158, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x18400B00 AS Date), 159, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x18400B00 AS Date), 160, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x18400B00 AS Date), 161, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x18400B00 AS Date), 162, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x18400B00 AS Date), 163, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x18400B00 AS Date), 164, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x18400B00 AS Date), 165, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x18400B00 AS Date), 166, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x18400B00 AS Date), 167, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x18400B00 AS Date), 168, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x18400B00 AS Date), 169, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x18400B00 AS Date), 170, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x18400B00 AS Date), 171, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x18400B00 AS Date), 172, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x18400B00 AS Date), 173, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x18400B00 AS Date), 174, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x18400B00 AS Date), 175, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x18400B00 AS Date), 176, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x18400B00 AS Date), 177, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x18400B00 AS Date), 178, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x18400B00 AS Date), 179, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x18400B00 AS Date), 180, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x18400B00 AS Date), 181, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x18400B00 AS Date), 182, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x18400B00 AS Date), 183, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x18400B00 AS Date), 184, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x18400B00 AS Date), 185, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x18400B00 AS Date), 186, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x18400B00 AS Date), 187, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x18400B00 AS Date), 188, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x18400B00 AS Date), 189, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x19400B00 AS Date), 190, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x19400B00 AS Date), 191, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x19400B00 AS Date), 192, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x19400B00 AS Date), 193, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x19400B00 AS Date), 194, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x19400B00 AS Date), 195, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x19400B00 AS Date), 196, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x19400B00 AS Date), 197, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x19400B00 AS Date), 198, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x19400B00 AS Date), 199, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x19400B00 AS Date), 200, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x19400B00 AS Date), 201, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x19400B00 AS Date), 202, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x19400B00 AS Date), 203, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x19400B00 AS Date), 204, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x19400B00 AS Date), 205, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x19400B00 AS Date), 206, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x19400B00 AS Date), 207, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x19400B00 AS Date), 208, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x19400B00 AS Date), 209, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x19400B00 AS Date), 210, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x19400B00 AS Date), 211, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x19400B00 AS Date), 212, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x19400B00 AS Date), 213, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x19400B00 AS Date), 214, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x19400B00 AS Date), 215, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x19400B00 AS Date), 216, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x19400B00 AS Date), 217, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x19400B00 AS Date), 218, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x19400B00 AS Date), 219, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x19400B00 AS Date), 220, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x19400B00 AS Date), 221, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x19400B00 AS Date), 222, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x19400B00 AS Date), 223, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x19400B00 AS Date), 224, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x19400B00 AS Date), 225, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x19400B00 AS Date), 226, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x19400B00 AS Date), 227, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x19400B00 AS Date), 228, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x19400B00 AS Date), 229, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x19400B00 AS Date), 230, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x19400B00 AS Date), 231, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x19400B00 AS Date), 232, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x19400B00 AS Date), 233, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x19400B00 AS Date), 234, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x19400B00 AS Date), 235, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x19400B00 AS Date), 236, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x19400B00 AS Date), 237, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x19400B00 AS Date), 238, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x19400B00 AS Date), 239, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x19400B00 AS Date), 240, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x19400B00 AS Date), 241, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x19400B00 AS Date), 242, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x19400B00 AS Date), 243, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x19400B00 AS Date), 244, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x19400B00 AS Date), 245, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x19400B00 AS Date), 246, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x19400B00 AS Date), 247, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x19400B00 AS Date), 248, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x19400B00 AS Date), 249, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x19400B00 AS Date), 250, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x19400B00 AS Date), 251, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x19400B00 AS Date), 252, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1A400B00 AS Date), 253, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1A400B00 AS Date), 254, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1A400B00 AS Date), 255, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1A400B00 AS Date), 256, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1A400B00 AS Date), 257, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1A400B00 AS Date), 258, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1A400B00 AS Date), 259, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1A400B00 AS Date), 260, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1A400B00 AS Date), 261, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1A400B00 AS Date), 262, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1A400B00 AS Date), 263, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1A400B00 AS Date), 264, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1A400B00 AS Date), 265, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1A400B00 AS Date), 266, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1A400B00 AS Date), 267, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1A400B00 AS Date), 268, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1A400B00 AS Date), 269, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1A400B00 AS Date), 270, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1A400B00 AS Date), 271, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1A400B00 AS Date), 272, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1A400B00 AS Date), 273, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1A400B00 AS Date), 274, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1A400B00 AS Date), 275, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1A400B00 AS Date), 276, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1A400B00 AS Date), 277, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1A400B00 AS Date), 278, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1A400B00 AS Date), 279, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1A400B00 AS Date), 280, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1A400B00 AS Date), 281, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1A400B00 AS Date), 282, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1A400B00 AS Date), 283, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1A400B00 AS Date), 284, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1A400B00 AS Date), 285, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1A400B00 AS Date), 286, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1A400B00 AS Date), 287, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1A400B00 AS Date), 288, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1A400B00 AS Date), 289, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1A400B00 AS Date), 290, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1A400B00 AS Date), 291, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1A400B00 AS Date), 292, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1A400B00 AS Date), 293, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1A400B00 AS Date), 294, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1A400B00 AS Date), 295, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1A400B00 AS Date), 296, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1A400B00 AS Date), 297, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1A400B00 AS Date), 298, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1A400B00 AS Date), 299, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1A400B00 AS Date), 300, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1A400B00 AS Date), 301, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1A400B00 AS Date), 302, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1A400B00 AS Date), 303, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1A400B00 AS Date), 304, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1A400B00 AS Date), 305, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1A400B00 AS Date), 306, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1A400B00 AS Date), 307, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1A400B00 AS Date), 308, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1A400B00 AS Date), 309, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1A400B00 AS Date), 310, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1A400B00 AS Date), 311, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1A400B00 AS Date), 312, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1A400B00 AS Date), 313, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1A400B00 AS Date), 314, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1A400B00 AS Date), 315, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1D400B00 AS Date), 316, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1D400B00 AS Date), 317, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1D400B00 AS Date), 318, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1D400B00 AS Date), 319, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1D400B00 AS Date), 320, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1D400B00 AS Date), 321, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1D400B00 AS Date), 322, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1D400B00 AS Date), 323, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1D400B00 AS Date), 324, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1D400B00 AS Date), 325, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1D400B00 AS Date), 326, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1D400B00 AS Date), 327, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1D400B00 AS Date), 328, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1D400B00 AS Date), 329, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1D400B00 AS Date), 330, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1D400B00 AS Date), 331, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1D400B00 AS Date), 332, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1D400B00 AS Date), 333, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1D400B00 AS Date), 334, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1D400B00 AS Date), 335, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1D400B00 AS Date), 336, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1D400B00 AS Date), 337, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1D400B00 AS Date), 338, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1D400B00 AS Date), 339, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1D400B00 AS Date), 340, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1D400B00 AS Date), 341, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1D400B00 AS Date), 342, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1D400B00 AS Date), 343, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1D400B00 AS Date), 344, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1D400B00 AS Date), 345, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1D400B00 AS Date), 346, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1D400B00 AS Date), 347, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1D400B00 AS Date), 348, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1D400B00 AS Date), 349, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1D400B00 AS Date), 350, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1D400B00 AS Date), 351, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1D400B00 AS Date), 352, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1D400B00 AS Date), 353, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1D400B00 AS Date), 354, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1D400B00 AS Date), 355, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1D400B00 AS Date), 356, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1D400B00 AS Date), 357, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1D400B00 AS Date), 358, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1D400B00 AS Date), 359, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1D400B00 AS Date), 360, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1D400B00 AS Date), 361, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1D400B00 AS Date), 362, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1D400B00 AS Date), 363, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1D400B00 AS Date), 364, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1D400B00 AS Date), 365, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1D400B00 AS Date), 366, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1D400B00 AS Date), 367, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1D400B00 AS Date), 368, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1D400B00 AS Date), 369, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1D400B00 AS Date), 370, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1D400B00 AS Date), 371, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1D400B00 AS Date), 372, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1D400B00 AS Date), 373, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1D400B00 AS Date), 374, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1D400B00 AS Date), 375, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1D400B00 AS Date), 376, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1D400B00 AS Date), 377, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1D400B00 AS Date), 378, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1E400B00 AS Date), 379, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1E400B00 AS Date), 380, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1E400B00 AS Date), 381, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1E400B00 AS Date), 382, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1E400B00 AS Date), 383, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1E400B00 AS Date), 384, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1E400B00 AS Date), 385, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1E400B00 AS Date), 386, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1E400B00 AS Date), 387, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1E400B00 AS Date), 388, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1E400B00 AS Date), 389, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1E400B00 AS Date), 390, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1E400B00 AS Date), 391, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1E400B00 AS Date), 392, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1E400B00 AS Date), 393, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1E400B00 AS Date), 394, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1E400B00 AS Date), 395, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1E400B00 AS Date), 396, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1E400B00 AS Date), 397, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1E400B00 AS Date), 398, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1E400B00 AS Date), 399, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1E400B00 AS Date), 400, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1E400B00 AS Date), 401, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1E400B00 AS Date), 402, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1E400B00 AS Date), 403, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1E400B00 AS Date), 404, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1E400B00 AS Date), 405, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1E400B00 AS Date), 406, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1E400B00 AS Date), 407, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1E400B00 AS Date), 408, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1E400B00 AS Date), 409, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1E400B00 AS Date), 410, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1E400B00 AS Date), 411, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1E400B00 AS Date), 412, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1E400B00 AS Date), 413, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1E400B00 AS Date), 414, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1E400B00 AS Date), 415, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1E400B00 AS Date), 416, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1E400B00 AS Date), 417, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1E400B00 AS Date), 418, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1E400B00 AS Date), 419, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1E400B00 AS Date), 420, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1E400B00 AS Date), 421, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1E400B00 AS Date), 422, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1E400B00 AS Date), 423, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1E400B00 AS Date), 424, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1E400B00 AS Date), 425, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1E400B00 AS Date), 426, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1E400B00 AS Date), 427, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1E400B00 AS Date), 428, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1E400B00 AS Date), 429, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1E400B00 AS Date), 430, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1E400B00 AS Date), 431, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1E400B00 AS Date), 432, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1E400B00 AS Date), 433, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1E400B00 AS Date), 434, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1E400B00 AS Date), 435, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1E400B00 AS Date), 436, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1E400B00 AS Date), 437, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1E400B00 AS Date), 438, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1E400B00 AS Date), 439, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1E400B00 AS Date), 440, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1E400B00 AS Date), 441, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1F400B00 AS Date), 442, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1F400B00 AS Date), 443, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1F400B00 AS Date), 444, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1F400B00 AS Date), 445, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1F400B00 AS Date), 446, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1F400B00 AS Date), 447, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1F400B00 AS Date), 448, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1F400B00 AS Date), 449, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1F400B00 AS Date), 450, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1F400B00 AS Date), 451, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1F400B00 AS Date), 452, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1F400B00 AS Date), 453, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1F400B00 AS Date), 454, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1F400B00 AS Date), 455, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1F400B00 AS Date), 456, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1F400B00 AS Date), 457, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1F400B00 AS Date), 458, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1F400B00 AS Date), 459, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1F400B00 AS Date), 460, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1F400B00 AS Date), 461, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1F400B00 AS Date), 462, 1, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1F400B00 AS Date), 463, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1F400B00 AS Date), 464, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1F400B00 AS Date), 465, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1F400B00 AS Date), 466, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1F400B00 AS Date), 467, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1F400B00 AS Date), 468, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1F400B00 AS Date), 469, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1F400B00 AS Date), 470, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1F400B00 AS Date), 471, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1F400B00 AS Date), 472, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1F400B00 AS Date), 473, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1F400B00 AS Date), 474, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1F400B00 AS Date), 475, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1F400B00 AS Date), 476, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1F400B00 AS Date), 477, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1F400B00 AS Date), 478, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1F400B00 AS Date), 479, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1F400B00 AS Date), 480, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1F400B00 AS Date), 481, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1F400B00 AS Date), 482, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1F400B00 AS Date), 483, 2, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT1', CAST(0x1F400B00 AS Date), 484, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT2', CAST(0x1F400B00 AS Date), 485, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT3', CAST(0x1F400B00 AS Date), 486, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT4', CAST(0x1F400B00 AS Date), 487, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT5', CAST(0x1F400B00 AS Date), 488, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT6', CAST(0x1F400B00 AS Date), 489, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT7', CAST(0x1F400B00 AS Date), 490, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT8', CAST(0x1F400B00 AS Date), 491, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT9', CAST(0x1F400B00 AS Date), 492, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT10', CAST(0x1F400B00 AS Date), 493, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXKT11', CAST(0x1F400B00 AS Date), 494, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL1', CAST(0x1F400B00 AS Date), 495, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL2', CAST(0x1F400B00 AS Date), 496, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL3', CAST(0x1F400B00 AS Date), 497, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL5', CAST(0x1F400B00 AS Date), 498, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL7', CAST(0x1F400B00 AS Date), 499, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXDL8', CAST(0x1F400B00 AS Date), 500, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'KCS', CAST(0x1F400B00 AS Date), 501, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXST', CAST(0x1F400B00 AS Date), 502, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'CTYDH', CAST(0x1F400B00 AS Date), 503, 3, NULL)
GO
INSERT [dbo].[header_ThucHienTheoNgay] ([MaPhongBan], [Ngay], [HeaderID], [Ca], [NgaySanXuat]) VALUES (N'PXLT', CAST(0x1F400B00 AS Date), 504, 3, NULL)
GO
SET IDENTITY_INSERT [dbo].[header_ThucHienTheoNgay] OFF
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (1, 2, 353, NULL, 820)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (1, 7, 1000, NULL, 105)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (1, 9, 901, NULL, 364)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (1, 19, 883, NULL, 717)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (2, 2, 778, NULL, 684)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (2, 7, 127, NULL, 184)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (2, 9, 431, NULL, 405)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (2, 19, 467, NULL, 320)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (3, 2, 785, NULL, 502)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (3, 7, 984, NULL, 472)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (3, 9, 845, NULL, 206)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (3, 19, 247, NULL, 880)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (4, 2, 415, NULL, 642)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (4, 7, 876, NULL, 336)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (4, 9, 229, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (4, 19, 925, NULL, 129)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (5, 2, 979, NULL, 238)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (5, 7, 957, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (5, 9, 704, NULL, 890)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (5, 19, 984, NULL, 165)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (6, 2, 152, NULL, 896)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (6, 7, 116, NULL, 969)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (6, 9, 487, NULL, 384)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (6, 19, 902, NULL, 715)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (7, 2, 830, NULL, 186)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (7, 7, 430, NULL, 335)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (7, 9, 172, NULL, 885)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (7, 19, 740, NULL, 806)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (8, 2, 598, NULL, 609)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (8, 7, 686, NULL, 627)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (8, 9, 417, NULL, 473)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (8, 19, 914, NULL, 577)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (9, 2, 920, NULL, 377)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (9, 7, 624, NULL, 749)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (9, 9, 484, NULL, 809)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (9, 19, 837, NULL, 109)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (10, 2, 371, NULL, 321)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (10, 7, 786, NULL, 972)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (10, 9, 181, NULL, 747)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (10, 19, 706, NULL, 864)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (11, 2, 752, NULL, 466)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (11, 7, 589, NULL, 512)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (11, 9, 643, NULL, 444)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (11, 19, 984, NULL, 882)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (12, 1, 320, NULL, 846)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (12, 7, 537, NULL, 918)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (12, 9, 922, NULL, 609)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (12, 19, 813, NULL, 615)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (13, 1, 471, NULL, 116)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (13, 7, 824, NULL, 631)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (13, 9, 742, NULL, 643)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (13, 19, 882, NULL, 984)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (14, 1, 451, NULL, 351)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (14, 7, 886, NULL, 948)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (14, 9, 592, NULL, 341)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (14, 19, 194, NULL, 890)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (15, 1, 863, NULL, 525)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (15, 7, 769, NULL, 450)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (15, 9, 358, NULL, 758)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (15, 19, 948, NULL, 703)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (16, 1, 188, NULL, 768)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (16, 7, 636, NULL, 688)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (16, 9, 622, NULL, 709)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (16, 19, 590, NULL, 993)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (17, 1, 169, NULL, 658)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (17, 7, 447, NULL, 263)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (17, 9, 471, NULL, 591)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (17, 19, 508, NULL, 941)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 18, 131, NULL, 122)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 21, 715, NULL, 408)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 22, 411, NULL, 592)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 23, 332, NULL, 878)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 24, 338, NULL, 572)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 25, 488, NULL, 650)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 26, 953, NULL, 517)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 27, 898, NULL, 778)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 28, 954, NULL, 927)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 29, 494, NULL, 137)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (18, 30, 253, NULL, 745)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 10, 380, NULL, 957)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 11, 602, NULL, 301)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 12, 868, NULL, 856)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 13, 326, NULL, 521)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 14, 335, NULL, 242)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 15, 682, NULL, 966)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 16, 547, NULL, 918)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (19, 17, 450, NULL, 150)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (20, 6, 240, NULL, 634)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (21, 3, 360, NULL, 711)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (21, 4, 111, NULL, 274)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (22, 2, 113, NULL, 370)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (22, 7, 578, NULL, 929)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (22, 9, 952, NULL, 492)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (22, 19, 410, NULL, 597)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (23, 2, 577, NULL, 417)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (23, 7, 249, NULL, 499)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (23, 9, 951, NULL, 490)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (23, 19, 258, NULL, 578)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (24, 2, 165, NULL, 534)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (24, 7, 228, NULL, 904)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (24, 9, 567, NULL, 154)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (24, 19, 609, NULL, 970)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (25, 2, 106, NULL, 431)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (25, 7, 905, NULL, 671)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (25, 9, 818, NULL, 808)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (25, 19, 821, NULL, 422)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (26, 2, 165, NULL, 479)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (26, 7, 339, NULL, 799)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (26, 9, 495, NULL, 474)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (26, 19, 441, NULL, 302)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (27, 2, 923, NULL, 245)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (27, 7, 617, NULL, 510)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (27, 9, 194, NULL, 208)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (27, 19, 259, NULL, 915)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (28, 2, 316, NULL, 361)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (28, 7, 987, NULL, 194)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (28, 9, 893, NULL, 373)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (28, 19, 696, NULL, 303)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (29, 2, 854, NULL, 554)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (29, 7, 174, NULL, 273)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (29, 9, 661, NULL, 387)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (29, 19, 214, NULL, 317)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (30, 2, 984, NULL, 926)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (30, 7, 481, NULL, 252)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (30, 9, 975, NULL, 310)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (30, 19, 299, NULL, 477)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (31, 2, 886, NULL, 764)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (31, 7, 724, NULL, 476)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (31, 9, 738, NULL, 491)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (31, 19, 806, NULL, 980)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (32, 2, 419, NULL, 254)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (32, 7, 176, NULL, 302)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (32, 9, 360, NULL, 176)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (32, 19, 114, NULL, 736)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (33, 1, 503, NULL, 373)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (33, 7, 918, NULL, 820)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (33, 9, 551, NULL, 139)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (33, 19, 765, NULL, 875)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (34, 1, 734, NULL, 983)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (34, 7, 905, NULL, 254)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (34, 9, 574, NULL, 241)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (34, 19, 165, NULL, 883)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (35, 1, 981, NULL, 822)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (35, 7, 584, NULL, 731)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (35, 9, 610, NULL, 294)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (35, 19, 496, NULL, 221)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (36, 1, 177, NULL, 713)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (36, 7, 521, NULL, 830)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (36, 9, 161, NULL, 597)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (36, 19, 221, NULL, 696)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (37, 1, 110, NULL, 194)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (37, 7, 444, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (37, 9, 845, NULL, 731)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (37, 19, 111, NULL, 439)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (38, 1, 955, NULL, 942)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (38, 7, 174, NULL, 202)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (38, 9, 524, NULL, 505)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (38, 19, 679, NULL, 597)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 18, 879, NULL, 239)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 21, 343, NULL, 854)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 22, 992, NULL, 233)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 23, 869, NULL, 322)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 24, 173, NULL, 407)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 25, 947, NULL, 314)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 26, 283, NULL, 488)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 27, 238, NULL, 844)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 28, 151, NULL, 223)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 29, 530, NULL, 283)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (39, 30, 517, NULL, 331)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 10, 427, NULL, 689)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 11, 270, NULL, 285)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 12, 360, NULL, 510)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 13, 910, NULL, 569)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 14, 494, NULL, 469)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 15, 433, NULL, 925)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 16, 464, NULL, 978)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (40, 17, 318, NULL, 817)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (41, 6, 143, NULL, 598)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (42, 3, 531, NULL, 859)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (42, 4, 748, NULL, 417)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (43, 2, 472, NULL, 343)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (43, 7, 932, NULL, 901)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (43, 9, 938, NULL, 886)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (43, 19, 193, NULL, 614)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (44, 2, 789, NULL, 442)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (44, 7, 352, NULL, 311)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (44, 9, 838, NULL, 723)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (44, 19, 823, NULL, 167)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (45, 2, 958, NULL, 914)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (45, 7, 292, NULL, 944)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (45, 9, 674, NULL, 955)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (45, 19, 227, NULL, 231)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (46, 2, 569, NULL, 733)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (46, 7, 759, NULL, 194)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (46, 9, 333, NULL, 406)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (46, 19, 278, NULL, 452)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (47, 2, 813, NULL, 477)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (47, 7, 902, NULL, 658)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (47, 9, 147, NULL, 878)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (47, 19, 527, NULL, 927)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (48, 2, 832, NULL, 403)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (48, 7, 747, NULL, 427)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (48, 9, 455, NULL, 477)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (48, 19, 143, NULL, 828)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (49, 2, 638, NULL, 861)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (49, 7, 731, NULL, 435)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (49, 9, 544, NULL, 418)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (49, 19, 894, NULL, 679)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (50, 2, 393, NULL, 235)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (50, 7, 816, NULL, 113)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (50, 9, 340, NULL, 662)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (50, 19, 450, NULL, 913)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (51, 2, 606, NULL, 940)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (51, 7, 343, NULL, 478)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (51, 9, 621, NULL, 985)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (51, 19, 977, NULL, 468)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (52, 2, 213, NULL, 403)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (52, 7, 109, NULL, 361)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (52, 9, 937, NULL, 937)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (52, 19, 906, NULL, 128)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (53, 2, 128, NULL, 139)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (53, 7, 889, NULL, 693)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (53, 9, 694, NULL, 369)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (53, 19, 735, NULL, 527)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (54, 1, 547, NULL, 636)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (54, 7, 296, NULL, 342)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (54, 9, 376, NULL, 843)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (54, 19, 919, NULL, 161)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (55, 1, 754, NULL, 925)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (55, 7, 780, NULL, 958)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (55, 9, 806, NULL, 166)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (55, 19, 330, NULL, 483)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (56, 1, 721, NULL, 646)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (56, 7, 477, NULL, 449)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (56, 9, 127, NULL, 554)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (56, 19, 650, NULL, 294)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (57, 1, 978, NULL, 919)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (57, 7, 181, NULL, 755)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (57, 9, 636, NULL, 967)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (57, 19, 316, NULL, 374)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (58, 1, 824, NULL, 461)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (58, 7, 841, NULL, 773)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (58, 9, 185, NULL, 271)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (58, 19, 796, NULL, 433)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (59, 1, 672, NULL, 146)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (59, 7, 719, NULL, 629)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (59, 9, 700, NULL, 631)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (59, 19, 382, NULL, 262)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 18, 637, NULL, 472)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 21, 892, NULL, 773)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 22, 868, NULL, 271)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 23, 834, NULL, 255)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 24, 422, NULL, 654)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 25, 860, NULL, 821)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 26, 525, NULL, 577)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 27, 140, NULL, 741)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 28, 587, NULL, 831)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 29, 870, NULL, 586)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (60, 30, 421, NULL, 389)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 10, 519, NULL, 825)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 11, 422, NULL, 777)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 12, 933, NULL, 126)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 13, 605, NULL, 896)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 14, 705, NULL, 235)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 15, 794, NULL, 174)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 16, 468, NULL, 733)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (61, 17, 739, NULL, 936)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (62, 6, 844, NULL, 353)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (63, 3, 452, NULL, 815)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (63, 4, 699, NULL, 929)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (64, 2, 966, NULL, 777)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (64, 7, 960, NULL, 878)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (64, 9, 754, NULL, 762)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (64, 19, 658, NULL, 314)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (65, 2, 645, NULL, 756)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (65, 7, 923, NULL, 917)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (65, 9, 447, NULL, 727)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (65, 19, 652, NULL, 228)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (66, 2, 325, NULL, 877)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (66, 7, 281, NULL, 250)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (66, 9, 250, NULL, 364)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (66, 19, 298, NULL, 584)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (67, 2, 696, NULL, 297)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (67, 7, 716, NULL, 156)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (67, 9, 219, NULL, 275)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (67, 19, 738, NULL, 140)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (68, 2, 405, NULL, 932)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (68, 7, 468, NULL, 492)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (68, 9, 894, NULL, 827)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (68, 19, 575, NULL, 262)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (69, 2, 350, NULL, 843)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (69, 7, 800, NULL, 139)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (69, 9, 653, NULL, 873)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (69, 19, 955, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (70, 2, 998, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (70, 7, 943, NULL, 831)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (70, 9, 343, NULL, 181)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (70, 19, 479, NULL, 695)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (71, 2, 425, NULL, 701)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (71, 7, 414, NULL, 227)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (71, 9, 148, NULL, 395)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (71, 19, 989, NULL, 550)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (72, 2, 241, NULL, 155)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (72, 7, 956, NULL, 846)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (72, 9, 527, NULL, 818)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (72, 19, 833, NULL, 905)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (73, 2, 363, NULL, 398)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (73, 7, 765, NULL, 980)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (73, 9, 147, NULL, 818)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (73, 19, 517, NULL, 877)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (74, 2, 620, NULL, 590)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (74, 7, 992, NULL, 393)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (74, 9, 308, NULL, 987)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (74, 19, 879, NULL, 919)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (75, 1, 757, NULL, 334)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (75, 7, 155, NULL, 206)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (75, 9, 431, NULL, 531)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (75, 19, 124, NULL, 396)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (76, 1, 118, NULL, 436)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (76, 7, 737, NULL, 996)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (76, 9, 878, NULL, 394)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (76, 19, 329, NULL, 986)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (77, 1, 123, NULL, 185)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (77, 7, 719, NULL, 964)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (77, 9, 665, NULL, 651)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (77, 19, 279, NULL, 360)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (78, 1, 321, NULL, 237)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (78, 7, 715, NULL, 700)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (78, 9, 829, NULL, 193)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (78, 19, 289, NULL, 618)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (79, 1, 226, NULL, 557)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (79, 7, 793, NULL, 129)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (79, 9, 412, NULL, 850)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (79, 19, 130, NULL, 347)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (80, 1, 808, NULL, 513)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (80, 7, 707, NULL, 353)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (80, 9, 104, NULL, 694)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (80, 19, 540, NULL, 276)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 18, 308, NULL, 394)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 21, 645, NULL, 464)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 22, 635, NULL, 530)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 23, 989, NULL, 454)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 24, 255, NULL, 412)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 25, 463, NULL, 500)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 26, 566, NULL, 306)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 27, 360, NULL, 954)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 28, 659, NULL, 652)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 29, 952, NULL, 998)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (81, 30, 731, NULL, 179)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 10, 313, NULL, 436)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 11, 338, NULL, 779)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 12, 628, NULL, 316)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 13, 760, NULL, 995)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 14, 983, NULL, 625)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 15, 604, NULL, 250)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 16, 981, NULL, 412)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (82, 17, 487, NULL, 291)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (83, 6, 993, NULL, 340)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (84, 3, 145, NULL, 882)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (84, 4, 707, NULL, 426)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (85, 2, 744, NULL, 876)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (85, 7, 801, NULL, 944)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (85, 9, 254, NULL, 430)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (85, 19, 928, NULL, 671)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (86, 2, 386, NULL, 863)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (86, 7, 734, NULL, 805)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (86, 9, 679, NULL, 765)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (86, 19, 829, NULL, 661)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (87, 2, 950, NULL, 237)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (87, 7, 959, NULL, 486)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (87, 9, 431, NULL, 171)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (87, 19, 561, NULL, 457)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (88, 2, 646, NULL, 221)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (88, 7, 406, NULL, 400)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (88, 9, 410, NULL, 400)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (88, 19, 311, NULL, 674)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (89, 2, 494, NULL, 691)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (89, 7, 417, NULL, 723)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (89, 9, 553, NULL, 373)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (89, 19, 740, NULL, 594)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (90, 2, 586, NULL, 617)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (90, 7, 910, NULL, 983)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (90, 9, 620, NULL, 356)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (90, 19, 337, NULL, 198)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (91, 2, 306, NULL, 373)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (91, 7, 804, NULL, 952)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (91, 9, 317, NULL, 298)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (91, 19, 838, NULL, 163)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (92, 2, 946, NULL, 363)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (92, 7, 393, NULL, 660)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (92, 9, 336, NULL, 245)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (92, 19, 282, NULL, 466)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (93, 2, 203, NULL, 729)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (93, 7, 767, NULL, 582)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (93, 9, 743, NULL, 355)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (93, 19, 790, NULL, 890)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (94, 2, 443, NULL, 177)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (94, 7, 674, NULL, 809)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (94, 9, 501, NULL, 489)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (94, 19, 497, NULL, 410)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (95, 2, 122, NULL, 397)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (95, 7, 574, NULL, 483)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (95, 9, 771, NULL, 143)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (95, 19, 575, NULL, 354)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (96, 1, 455, NULL, 348)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (96, 7, 528, NULL, 701)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (96, 9, 281, NULL, 692)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (96, 19, 388, NULL, 603)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (97, 1, 355, NULL, 908)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (97, 7, 797, NULL, 723)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (97, 9, 940, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (97, 19, 205, NULL, 184)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (98, 1, 135, NULL, 165)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (98, 7, 641, NULL, 888)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (98, 9, 281, NULL, 783)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (98, 19, 992, NULL, 148)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (99, 1, 773, NULL, 336)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (99, 7, 333, NULL, 664)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (99, 9, 965, NULL, 789)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (99, 19, 515, NULL, 231)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (100, 1, 166, NULL, 843)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (100, 7, 604, NULL, 496)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (100, 9, 263, NULL, 135)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (100, 19, 664, NULL, 186)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (101, 1, 925, NULL, 454)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (101, 7, 852, NULL, 620)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (101, 9, 368, NULL, 720)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (101, 19, 405, NULL, 750)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 18, 858, NULL, 319)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 21, 557, NULL, 506)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 22, 787, NULL, 547)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 23, 703, NULL, 734)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 24, 354, NULL, 273)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 25, 180, NULL, 930)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 26, 674, NULL, 274)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 27, 398, NULL, 150)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 28, 403, NULL, 569)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 29, 205, NULL, 632)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (102, 30, 903, NULL, 157)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 10, 204, NULL, 718)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 11, 487, NULL, 194)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 12, 362, NULL, 321)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 13, 614, NULL, 687)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 14, 978, NULL, 417)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 15, 671, NULL, 303)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 16, 452, NULL, 291)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (103, 17, 706, NULL, 208)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (104, 6, 275, NULL, 905)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (105, 3, 681, NULL, 343)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (105, 4, 613, NULL, 808)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (106, 2, 569, NULL, 881)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (106, 7, 523, NULL, 263)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (106, 9, 165, NULL, 313)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (106, 19, 399, NULL, 972)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (107, 2, 993, NULL, 935)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (107, 7, 319, NULL, 161)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (107, 9, 642, NULL, 779)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (107, 19, 135, NULL, 583)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (108, 2, 196, NULL, 441)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (108, 7, 793, NULL, 726)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (108, 9, 234, NULL, 842)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (108, 19, 981, NULL, 776)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (109, 2, 404, NULL, 862)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (109, 7, 610, NULL, 296)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (109, 9, 565, NULL, 735)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (109, 19, 623, NULL, 337)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (110, 2, 224, NULL, 403)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (110, 7, 181, NULL, 452)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (110, 9, 588, NULL, 390)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (110, 19, 294, NULL, 214)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (111, 2, 820, NULL, 219)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (111, 7, 292, NULL, 669)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (111, 9, 728, NULL, 923)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (111, 19, 386, NULL, 560)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (112, 2, 256, NULL, 856)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (112, 7, 473, NULL, 282)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (112, 9, 238, NULL, 300)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (112, 19, 302, NULL, 664)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (113, 2, 366, NULL, 332)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (113, 7, 922, NULL, 460)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (113, 9, 387, NULL, 150)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (113, 19, 193, NULL, 820)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (114, 2, 999, NULL, 543)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (114, 7, 243, NULL, 457)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (114, 9, 508, NULL, 352)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (114, 19, 739, NULL, 938)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (115, 2, 354, NULL, 294)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (115, 7, 504, NULL, 417)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (115, 9, 108, NULL, 541)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (115, 19, 316, NULL, 954)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (116, 2, 805, NULL, 482)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (116, 7, 427, NULL, 920)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (116, 9, 333, NULL, 884)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (116, 19, 625, NULL, 102)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (117, 1, 353, NULL, 441)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (117, 7, 102, NULL, 340)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (117, 9, 762, NULL, 183)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (117, 19, 353, NULL, 602)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (118, 1, 929, NULL, 162)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (118, 7, 948, NULL, 183)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (118, 9, 385, NULL, 731)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (118, 19, 753, NULL, 782)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (119, 1, 743, NULL, 977)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (119, 7, 931, NULL, 455)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (119, 9, 948, NULL, 788)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (119, 19, 546, NULL, 314)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (120, 1, 845, NULL, 562)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (120, 7, 624, NULL, 350)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (120, 9, 793, NULL, 501)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (120, 19, 260, NULL, 428)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (121, 1, 571, NULL, 397)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (121, 7, 197, NULL, 567)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (121, 9, 954, NULL, 177)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (121, 19, 157, NULL, 158)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (122, 1, 836, NULL, 493)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (122, 7, 908, NULL, 649)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (122, 9, 688, NULL, 776)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (122, 19, 870, NULL, 871)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 18, 294, NULL, 953)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 21, 190, NULL, 882)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 22, 362, NULL, 879)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 23, 282, NULL, 995)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 24, 229, NULL, 962)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 25, 487, NULL, 176)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 26, 720, NULL, 807)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 27, 315, NULL, 781)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 28, 841, NULL, 709)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 29, 244, NULL, 967)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (123, 30, 686, NULL, 445)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 10, 691, NULL, 960)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 11, 135, NULL, 557)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 12, 972, NULL, 839)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 13, 997, NULL, 490)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 14, 302, NULL, 691)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 15, 704, NULL, 183)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 16, 530, NULL, 326)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (124, 17, 119, NULL, 301)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (125, 6, 686, NULL, 887)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (126, 3, 390, NULL, 211)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (126, 4, 878, NULL, 296)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (127, 2, 503, NULL, 689)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (127, 7, 521, NULL, 956)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (127, 9, 256, NULL, 776)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (127, 19, 643, NULL, 299)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (128, 2, 551, NULL, 259)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (128, 7, 632, NULL, 877)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (128, 9, 965, NULL, 621)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (128, 19, 186, NULL, 927)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (129, 2, 670, NULL, 987)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (129, 7, 834, NULL, 349)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (129, 9, 770, NULL, 356)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (129, 19, 943, NULL, 854)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (130, 2, 287, NULL, 127)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (130, 7, 245, NULL, 217)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (130, 9, 817, NULL, 337)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (130, 19, 803, NULL, 233)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (131, 2, 458, NULL, 898)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (131, 7, 474, NULL, 252)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (131, 9, 410, NULL, 102)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (131, 19, 941, NULL, 247)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (132, 2, 481, NULL, 135)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (132, 7, 677, NULL, 239)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (132, 9, 983, NULL, 673)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (132, 19, 296, NULL, 761)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (133, 2, 830, NULL, 764)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (133, 7, 964, NULL, 576)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (133, 9, 478, NULL, 367)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (133, 19, 142, NULL, 181)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (134, 2, 713, NULL, 875)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (134, 7, 986, NULL, 119)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (134, 9, 786, NULL, 509)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (134, 19, 903, NULL, 231)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (135, 2, 162, NULL, 948)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (135, 7, 932, NULL, 623)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (135, 9, 750, NULL, 104)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (135, 19, 843, NULL, 752)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (136, 2, 708, NULL, 207)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (136, 7, 555, NULL, 208)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (136, 9, 259, NULL, 376)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (136, 19, 971, NULL, 916)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (137, 2, 229, NULL, 865)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (137, 7, 208, NULL, 203)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (137, 9, 190, NULL, 116)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (137, 19, 316, NULL, 826)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (138, 1, 135, NULL, 915)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (138, 7, 446, NULL, 674)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (138, 9, 501, NULL, 601)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (138, 19, 594, NULL, 610)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (139, 1, 568, NULL, 438)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (139, 7, 230, NULL, 941)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (139, 9, 447, NULL, 942)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (139, 19, 693, NULL, 945)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (140, 1, 502, NULL, 331)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (140, 7, 811, NULL, 442)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (140, 9, 711, NULL, 880)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (140, 19, 698, NULL, 111)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (141, 1, 530, NULL, 545)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (141, 7, 806, NULL, 609)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (141, 9, 394, NULL, 740)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (141, 19, 319, NULL, 831)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (142, 1, 321, NULL, 824)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (142, 7, 735, NULL, 730)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (142, 9, 935, NULL, 579)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (142, 19, 229, NULL, 219)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (143, 1, 719, NULL, 583)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (143, 7, 866, NULL, 714)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (143, 9, 965, NULL, 420)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (143, 19, 469, NULL, 842)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 18, 553, NULL, 250)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 21, 745, NULL, 227)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 22, 956, NULL, 991)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 23, 316, NULL, 274)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 24, 725, NULL, 357)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 25, 381, NULL, 199)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 26, 229, NULL, 390)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 27, 202, NULL, 956)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 28, 168, NULL, 592)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 29, 241, NULL, 901)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (144, 30, 396, NULL, 717)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 10, 386, NULL, 208)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 11, 898, NULL, 291)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 12, 324, NULL, 582)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 13, 567, NULL, 642)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 14, 932, NULL, 539)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 15, 392, NULL, 953)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 16, 718, NULL, 293)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (145, 17, 925, NULL, 126)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (146, 6, 924, NULL, 426)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (147, 3, 833, NULL, 147)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (147, 4, 138, NULL, 192)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (148, 2, 183, NULL, 130)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (148, 7, 101, NULL, 400)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (148, 9, 616, NULL, 505)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (148, 19, 329, NULL, 455)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (149, 2, 729, NULL, 348)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (149, 7, 778, NULL, 785)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (149, 9, 526, NULL, 997)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (149, 19, 760, NULL, 599)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (150, 2, 125, NULL, 950)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (150, 7, 473, NULL, 233)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (150, 9, 700, NULL, 636)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (150, 19, 216, NULL, 674)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (151, 2, 575, NULL, 543)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (151, 7, 508, NULL, 235)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (151, 9, 523, NULL, 230)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (151, 19, 335, NULL, 633)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (152, 2, 306, NULL, 640)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (152, 7, 234, NULL, 146)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (152, 9, 819, NULL, 562)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (152, 19, 286, NULL, 843)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (153, 2, 467, NULL, 962)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (153, 7, 727, NULL, 858)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (153, 9, 856, NULL, 574)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (153, 19, 186, NULL, 809)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (154, 2, 391, NULL, 717)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (154, 7, 459, NULL, 938)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (154, 9, 673, NULL, 378)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (154, 19, 944, NULL, 693)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (155, 2, 913, NULL, 588)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (155, 7, 294, NULL, 588)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (155, 9, 447, NULL, 164)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (155, 19, 284, NULL, 995)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (156, 2, 473, NULL, 345)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (156, 7, 297, NULL, 222)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (156, 9, 876, NULL, 763)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (156, 19, 587, NULL, 665)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (157, 2, 673, NULL, 244)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (157, 7, 805, NULL, 788)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (157, 9, 153, NULL, 784)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (157, 19, 820, NULL, 827)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (158, 2, 969, NULL, 806)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (158, 7, 913, NULL, 720)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (158, 9, 555, NULL, 630)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (158, 19, 845, NULL, 259)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (159, 1, 972, NULL, 570)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (159, 7, 476, NULL, 286)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (159, 9, 812, NULL, 748)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (159, 19, 560, NULL, 825)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (160, 1, 511, NULL, 398)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (160, 7, 831, NULL, 231)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (160, 9, 948, NULL, 445)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (160, 19, 356, NULL, 869)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (161, 1, 425, NULL, 849)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (161, 7, 609, NULL, 322)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (161, 9, 977, NULL, 104)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (161, 19, 150, NULL, 836)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (162, 1, 682, NULL, 630)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (162, 7, 804, NULL, 645)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (162, 9, 271, NULL, 818)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (162, 19, 722, NULL, 233)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (163, 1, 172, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (163, 7, 421, NULL, 806)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (163, 9, 746, NULL, 669)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (163, 19, 487, NULL, 855)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (164, 1, 610, NULL, 862)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (164, 7, 505, NULL, 414)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (164, 9, 355, NULL, 675)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (164, 19, 974, NULL, 934)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 18, 243, NULL, 527)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 21, 374, NULL, 687)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 22, 578, NULL, 809)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 23, 376, NULL, 464)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 24, 801, NULL, 995)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 25, 772, NULL, 991)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 26, 535, NULL, 862)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 27, 291, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 28, 609, NULL, 442)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 29, 400, NULL, 772)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (165, 30, 363, NULL, 290)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 10, 874, NULL, 418)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 11, 735, NULL, 600)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 12, 424, NULL, 928)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 13, 563, NULL, 583)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 14, 182, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 15, 786, NULL, 441)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 16, 853, NULL, 631)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (166, 17, 533, NULL, 318)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (167, 6, 359, NULL, 943)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (168, 3, 345, NULL, 654)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (168, 4, 909, NULL, 355)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (169, 2, 973, NULL, 946)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (169, 7, 647, NULL, 947)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (169, 9, 599, NULL, 307)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (169, 19, 953, NULL, 134)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (170, 2, 636, NULL, 940)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (170, 7, 727, NULL, 281)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (170, 9, 336, NULL, 818)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (170, 19, 683, NULL, 894)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (171, 2, 896, NULL, 172)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (171, 7, 557, NULL, 388)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (171, 9, 162, NULL, 241)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (171, 19, 163, NULL, 628)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (172, 2, 713, NULL, 702)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (172, 7, 420, NULL, 991)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (172, 9, 960, NULL, 788)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (172, 19, 930, NULL, 374)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (173, 2, 301, NULL, 818)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (173, 7, 320, NULL, 211)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (173, 9, 881, NULL, 496)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (173, 19, 986, NULL, 825)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (174, 2, 496, NULL, 620)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (174, 7, 123, NULL, 383)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (174, 9, 686, NULL, 649)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (174, 19, 525, NULL, 315)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (175, 2, 257, NULL, 743)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (175, 7, 150, NULL, 582)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (175, 9, 378, NULL, 150)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (175, 19, 317, NULL, 408)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (176, 2, 131, NULL, 277)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (176, 7, 731, NULL, 942)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (176, 9, 324, NULL, 208)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (176, 19, 738, NULL, 221)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (177, 2, 148, NULL, 314)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (177, 7, 633, NULL, 573)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (177, 9, 350, NULL, 959)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (177, 19, 701, NULL, 897)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (178, 2, 266, NULL, 453)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (178, 7, 921, NULL, 460)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (178, 9, 169, NULL, 343)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (178, 19, 602, NULL, 399)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (179, 2, 199, NULL, 819)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (179, 7, 851, NULL, 203)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (179, 9, 414, NULL, 756)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (179, 19, 999, NULL, 735)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (180, 1, 500, NULL, 348)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (180, 7, 457, NULL, 506)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (180, 9, 344, NULL, 499)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (180, 19, 911, NULL, 719)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (181, 1, 254, NULL, 422)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (181, 7, 132, NULL, 710)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (181, 9, 517, NULL, 465)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (181, 19, 408, NULL, 713)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (182, 1, 686, NULL, 960)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (182, 7, 250, NULL, 349)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (182, 9, 107, NULL, 621)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (182, 19, 576, NULL, 761)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (183, 1, 601, NULL, 461)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (183, 7, 383, NULL, 378)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (183, 9, 454, NULL, 673)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (183, 19, 718, NULL, 187)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (184, 1, 821, NULL, 572)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (184, 7, 829, NULL, 917)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (184, 9, 936, NULL, 935)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (184, 19, 760, NULL, 464)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (185, 1, 494, NULL, 729)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (185, 7, 132, NULL, 799)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (185, 9, 231, NULL, 699)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (185, 19, 170, NULL, 914)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 18, 565, NULL, 515)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 21, 872, NULL, 804)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 22, 703, NULL, 263)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 23, 944, NULL, 463)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 24, 790, NULL, 909)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 25, 795, NULL, 777)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 26, 518, NULL, 810)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 27, 144, NULL, 409)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 28, 846, NULL, 571)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 29, 223, NULL, 567)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (186, 30, 516, NULL, 720)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 10, 910, NULL, 589)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 11, 917, NULL, 966)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 12, 975, NULL, 988)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 13, 914, NULL, 691)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 14, 565, NULL, 750)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 15, 445, NULL, 380)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 16, 367, NULL, 170)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (187, 17, 223, NULL, 353)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (188, 6, 647, NULL, 359)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (189, 3, 752, NULL, 930)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (189, 4, 211, NULL, 285)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (190, 2, 863, NULL, 106)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (190, 7, 394, NULL, 317)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (190, 9, 480, NULL, 279)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (190, 19, 312, NULL, 359)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (191, 2, 979, NULL, 744)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (191, 7, 157, NULL, 898)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (191, 9, 653, NULL, 651)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (191, 19, 470, NULL, 173)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (192, 2, 807, NULL, 951)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (192, 7, 524, NULL, 363)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (192, 9, 380, NULL, 294)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (192, 19, 802, NULL, 198)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (193, 2, 372, NULL, 627)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (193, 7, 378, NULL, 565)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (193, 9, 495, NULL, 653)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (193, 19, 899, NULL, 954)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (194, 2, 333, NULL, 487)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (194, 7, 437, NULL, 872)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (194, 9, 224, NULL, 950)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (194, 19, 952, NULL, 910)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (195, 2, 124, NULL, 495)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (195, 7, 616, NULL, 228)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (195, 9, 101, NULL, 510)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (195, 19, 512, NULL, 196)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (196, 2, 651, NULL, 196)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (196, 7, 354, NULL, 481)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (196, 9, 623, NULL, 630)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (196, 19, 875, NULL, 292)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (197, 2, 754, NULL, 673)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (197, 7, 678, NULL, 260)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (197, 9, 264, NULL, 433)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (197, 19, 391, NULL, 320)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (198, 2, 785, NULL, 279)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (198, 7, 969, NULL, 254)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (198, 9, 967, NULL, 389)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (198, 19, 792, NULL, 457)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (199, 2, 653, NULL, 457)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (199, 7, 615, NULL, 526)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (199, 9, 270, NULL, 802)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (199, 19, 262, NULL, 341)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (200, 2, 458, NULL, 213)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (200, 7, 959, NULL, 414)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (200, 9, 761, NULL, 451)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (200, 19, 618, NULL, 838)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (201, 1, 424, NULL, 542)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (201, 7, 658, NULL, 170)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (201, 9, 771, NULL, 185)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (201, 19, 550, NULL, 601)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (202, 1, 856, NULL, 109)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (202, 7, 576, NULL, 203)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (202, 9, 232, NULL, 490)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (202, 19, 919, NULL, 994)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (203, 1, 540, NULL, 245)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (203, 7, 353, NULL, 256)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (203, 9, 775, NULL, 320)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (203, 19, 958, NULL, 695)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (204, 1, 236, NULL, 849)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (204, 7, 893, NULL, 145)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (204, 9, 143, NULL, 903)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (204, 19, 163, NULL, 137)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (205, 1, 446, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (205, 7, 937, NULL, 909)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (205, 9, 518, NULL, 108)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (205, 19, 875, NULL, 426)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (206, 1, 990, NULL, 876)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (206, 7, 986, NULL, 750)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (206, 9, 821, NULL, 439)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (206, 19, 440, NULL, 610)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 18, 825, NULL, 335)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 21, 660, NULL, 941)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 22, 173, NULL, 437)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 23, 715, NULL, 397)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 24, 388, NULL, 933)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 25, 938, NULL, 693)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 26, 916, NULL, 122)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 27, 235, NULL, 212)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 28, 226, NULL, 544)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 29, 212, NULL, 948)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (207, 30, 925, NULL, 534)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 10, 690, NULL, 736)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 11, 322, NULL, 286)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 12, 208, NULL, 859)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 13, 833, NULL, 613)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 14, 403, NULL, 825)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 15, 291, NULL, 537)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 16, 733, NULL, 505)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (208, 17, 435, NULL, 743)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (209, 6, 132, NULL, 367)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (210, 3, 854, NULL, 778)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (210, 4, 516, NULL, 474)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (211, 2, 546, NULL, 225)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (211, 7, 389, NULL, 403)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (211, 9, 271, NULL, 168)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (211, 19, 477, NULL, 218)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (212, 2, 754, NULL, 987)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (212, 7, 598, NULL, 998)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (212, 9, 394, NULL, 832)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (212, 19, 524, NULL, 316)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (213, 2, 146, NULL, 914)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (213, 7, 730, NULL, 964)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (213, 9, 439, NULL, 868)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (213, 19, 203, NULL, 122)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (214, 2, 350, NULL, 902)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (214, 7, 957, NULL, 814)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (214, 9, 330, NULL, 352)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (214, 19, 460, NULL, 400)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (215, 2, 397, NULL, 102)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (215, 7, 181, NULL, 204)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (215, 9, 117, NULL, 252)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (215, 19, 179, NULL, 572)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (216, 2, 893, NULL, 796)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (216, 7, 362, NULL, 980)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (216, 9, 607, NULL, 642)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (216, 19, 140, NULL, 552)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (217, 2, 776, NULL, 492)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (217, 7, 867, NULL, 609)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (217, 9, 730, NULL, 932)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (217, 19, 422, NULL, 590)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (218, 2, 251, NULL, 353)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (218, 7, 700, NULL, 930)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (218, 9, 430, NULL, 276)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (218, 19, 242, NULL, 863)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (219, 2, 566, NULL, 625)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (219, 7, 292, NULL, 494)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (219, 9, 337, NULL, 858)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (219, 19, 851, NULL, 244)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (220, 2, 693, NULL, 120)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (220, 7, 779, NULL, 952)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (220, 9, 588, NULL, 109)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (220, 19, 879, NULL, 465)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (221, 2, 248, NULL, 435)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (221, 7, 168, NULL, 289)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (221, 9, 115, NULL, 685)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (221, 19, 779, NULL, 104)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (222, 1, 791, NULL, 582)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (222, 7, 345, NULL, 653)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (222, 9, 176, NULL, 380)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (222, 19, 361, NULL, 626)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (223, 1, 329, NULL, 803)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (223, 7, 206, NULL, 230)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (223, 9, 360, NULL, 438)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (223, 19, 961, NULL, 352)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (224, 1, 114, NULL, 462)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (224, 7, 620, NULL, 271)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (224, 9, 213, NULL, 704)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (224, 19, 301, NULL, 390)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (225, 1, 895, NULL, 791)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (225, 7, 152, NULL, 925)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (225, 9, 148, NULL, 873)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (225, 19, 994, NULL, 108)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (226, 1, 683, NULL, 788)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (226, 7, 960, NULL, 922)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (226, 9, 811, NULL, 243)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (226, 19, 970, NULL, 735)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (227, 1, 215, NULL, 792)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (227, 7, 584, NULL, 305)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (227, 9, 772, NULL, 266)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (227, 19, 843, NULL, 764)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 18, 903, NULL, 389)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 21, 200, NULL, 759)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 22, 643, NULL, 134)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 23, 512, NULL, 284)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 24, 718, NULL, 214)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 25, 140, NULL, 762)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 26, 462, NULL, 635)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 27, 782, NULL, 592)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 28, 979, NULL, 556)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 29, 537, NULL, 264)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (228, 30, 526, NULL, 202)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 10, 137, NULL, 153)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 11, 615, NULL, 259)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 12, 898, NULL, 132)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 13, 923, NULL, 593)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 14, 718, NULL, 123)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 15, 529, NULL, 869)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 16, 632, NULL, 687)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (229, 17, 467, NULL, 663)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (230, 6, 685, NULL, 199)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (231, 3, 797, NULL, 679)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (231, 4, 985, NULL, 551)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (232, 2, 311, NULL, 647)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (232, 7, 586, NULL, 220)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (232, 9, 643, NULL, 390)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (232, 19, 864, NULL, 746)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (233, 2, 517, NULL, 973)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (233, 7, 526, NULL, 322)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (233, 9, 940, NULL, 227)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (233, 19, 527, NULL, 996)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (234, 2, 113, NULL, 140)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (234, 7, 606, NULL, 149)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (234, 9, 611, NULL, 961)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (234, 19, 515, NULL, 416)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (235, 2, 479, NULL, 738)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (235, 7, 922, NULL, 603)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (235, 9, 278, NULL, 515)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (235, 19, 485, NULL, 522)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (236, 2, 471, NULL, 106)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (236, 7, 785, NULL, 221)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (236, 9, 460, NULL, 781)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (236, 19, 479, NULL, 482)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (237, 2, 879, NULL, 317)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (237, 7, 857, NULL, 262)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (237, 9, 605, NULL, 340)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (237, 19, 185, NULL, 594)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (238, 2, 641, NULL, 930)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (238, 7, 921, NULL, 120)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (238, 9, 920, NULL, 380)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (238, 19, 914, NULL, 215)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (239, 2, 904, NULL, 384)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (239, 7, 922, NULL, 188)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (239, 9, 359, NULL, 554)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (239, 19, 550, NULL, 635)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (240, 2, 370, NULL, 532)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (240, 7, 362, NULL, 660)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (240, 9, 667, NULL, 132)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (240, 19, 235, NULL, 295)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (241, 2, 194, NULL, 772)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (241, 7, 335, NULL, 464)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (241, 9, 463, NULL, 479)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (241, 19, 947, NULL, 364)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (242, 2, 559, NULL, 182)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (242, 7, 702, NULL, 931)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (242, 9, 188, NULL, 144)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (242, 19, 738, NULL, 829)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (243, 1, 806, NULL, 110)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (243, 7, 721, NULL, 641)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (243, 9, 724, NULL, 551)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (243, 19, 469, NULL, 289)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (244, 1, 325, NULL, 778)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (244, 7, 460, NULL, 590)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (244, 9, 466, NULL, 838)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (244, 19, 823, NULL, 649)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (245, 1, 627, NULL, 702)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (245, 7, 283, NULL, 441)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (245, 9, 208, NULL, 962)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (245, 19, 275, NULL, 871)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (246, 1, 209, NULL, 371)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (246, 7, 685, NULL, 185)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (246, 9, 373, NULL, 282)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (246, 19, 469, NULL, 620)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (247, 1, 732, NULL, 883)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (247, 7, 697, NULL, 278)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (247, 9, 607, NULL, 221)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (247, 19, 850, NULL, 321)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (248, 1, 351, NULL, 112)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (248, 7, 552, NULL, 330)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (248, 9, 804, NULL, 308)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (248, 19, 317, NULL, 383)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 18, 707, NULL, 700)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 21, 479, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 22, 811, NULL, 242)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 23, 348, NULL, 563)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 24, 283, NULL, 464)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 25, 946, NULL, 255)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 26, 154, NULL, 806)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 27, 995, NULL, 687)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 28, 702, NULL, 923)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 29, 962, NULL, 357)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (249, 30, 861, NULL, 796)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 10, 698, NULL, 401)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 11, 403, NULL, 524)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 12, 610, NULL, 969)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 13, 771, NULL, 505)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 14, 490, NULL, 278)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 15, 793, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 16, 743, NULL, 592)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (250, 17, 416, NULL, 813)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (251, 6, 892, NULL, 844)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (252, 3, 181, NULL, 898)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (252, 4, 279, NULL, 148)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (253, 2, 828, NULL, 660)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (253, 7, 370, NULL, 386)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (253, 9, 474, NULL, 192)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (253, 19, 460, NULL, 898)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (254, 2, 333, NULL, 277)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (254, 7, 802, NULL, 935)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (254, 9, 127, NULL, 354)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (254, 19, 677, NULL, 513)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (255, 2, 863, NULL, 768)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (255, 7, 959, NULL, 990)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (255, 9, 335, NULL, 735)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (255, 19, 396, NULL, 652)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (256, 2, 139, NULL, 110)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (256, 7, 599, NULL, 651)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (256, 9, 820, NULL, 702)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (256, 19, 595, NULL, 854)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (257, 2, 621, NULL, 501)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (257, 7, 325, NULL, 606)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (257, 9, 888, NULL, 918)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (257, 19, 826, NULL, 470)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (258, 2, 214, NULL, 905)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (258, 7, 822, NULL, 144)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (258, 9, 496, NULL, 195)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (258, 19, 245, NULL, 487)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (259, 2, 259, NULL, 332)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (259, 7, 631, NULL, 909)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (259, 9, 607, NULL, 438)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (259, 19, 549, NULL, 889)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (260, 2, 333, NULL, 479)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (260, 7, 805, NULL, 434)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (260, 9, 862, NULL, 177)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (260, 19, 809, NULL, 375)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (261, 2, 379, NULL, 486)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (261, 7, 791, NULL, 644)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (261, 9, 206, NULL, 826)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (261, 19, 853, NULL, 697)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (262, 2, 254, NULL, 481)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (262, 7, 256, NULL, 906)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (262, 9, 343, NULL, 728)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (262, 19, 987, NULL, 628)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (263, 2, 307, NULL, 976)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (263, 7, 631, NULL, 200)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (263, 9, 279, NULL, 734)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (263, 19, 505, NULL, 434)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (264, 1, 133, NULL, 926)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (264, 7, 800, NULL, 801)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (264, 9, 627, NULL, 116)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (264, 19, 629, NULL, 229)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (265, 1, 351, NULL, 710)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (265, 7, 207, NULL, 151)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (265, 9, 898, NULL, 575)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (265, 19, 201, NULL, 644)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (266, 1, 589, NULL, 610)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (266, 7, 827, NULL, 386)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (266, 9, 332, NULL, 575)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (266, 19, 874, NULL, 971)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (267, 1, 524, NULL, 938)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (267, 7, 743, NULL, 273)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (267, 9, 290, NULL, 781)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (267, 19, 346, NULL, 823)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (268, 1, 589, NULL, 337)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (268, 7, 249, NULL, 631)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (268, 9, 925, NULL, 763)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (268, 19, 429, NULL, 827)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (269, 1, 795, NULL, 187)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (269, 7, 612, NULL, 354)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (269, 9, 572, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (269, 19, 933, NULL, 257)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 18, 680, NULL, 200)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 21, 556, NULL, 614)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 22, 433, NULL, 843)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 23, 809, NULL, 829)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 24, 241, NULL, 678)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 25, 199, NULL, 593)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 26, 243, NULL, 719)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 27, 406, NULL, 517)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 28, 328, NULL, 671)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 29, 741, NULL, 586)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (270, 30, 822, NULL, 553)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 10, 915, NULL, 815)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 11, 428, NULL, 797)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 12, 209, NULL, 581)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 13, 630, NULL, 860)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 14, 805, NULL, 944)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 15, 211, NULL, 492)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 16, 444, NULL, 492)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (271, 17, 309, NULL, 760)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (272, 6, 761, NULL, 680)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (273, 3, 421, NULL, 344)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (273, 4, 507, NULL, 333)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (274, 2, 545, NULL, 906)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (274, 7, 976, NULL, 150)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (274, 9, 751, NULL, 789)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (274, 19, 483, NULL, 259)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (275, 2, 214, NULL, 364)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (275, 7, 981, NULL, 956)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (275, 9, 271, NULL, 167)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (275, 19, 644, NULL, 959)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (276, 2, 178, NULL, 136)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (276, 7, 236, NULL, 490)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (276, 9, 711, NULL, 812)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (276, 19, 570, NULL, 970)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (277, 2, 186, NULL, 763)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (277, 7, 832, NULL, 802)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (277, 9, 151, NULL, 360)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (277, 19, 196, NULL, 493)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (278, 2, 609, NULL, 487)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (278, 7, 657, NULL, 681)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (278, 9, 609, NULL, 800)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (278, 19, 910, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (279, 2, 954, NULL, 550)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (279, 7, 427, NULL, 485)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (279, 9, 502, NULL, 547)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (279, 19, 413, NULL, 982)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (280, 2, 322, NULL, 322)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (280, 7, 722, NULL, 359)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (280, 9, 302, NULL, 466)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (280, 19, 894, NULL, 253)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (281, 2, 797, NULL, 526)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (281, 7, 690, NULL, 524)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (281, 9, 566, NULL, 162)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (281, 19, 673, NULL, 250)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (282, 2, 734, NULL, 407)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (282, 7, 819, NULL, 656)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (282, 9, 774, NULL, 673)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (282, 19, 530, NULL, 479)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (283, 2, 510, NULL, 244)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (283, 7, 328, NULL, 888)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (283, 9, 225, NULL, 223)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (283, 19, 812, NULL, 607)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (284, 2, 832, NULL, 928)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (284, 7, 802, NULL, 444)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (284, 9, 506, NULL, 271)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (284, 19, 387, NULL, 254)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (285, 1, 812, NULL, 603)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (285, 7, 707, NULL, 425)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (285, 9, 209, NULL, 581)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (285, 19, 342, NULL, 630)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (286, 1, 338, NULL, 924)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (286, 7, 126, NULL, 604)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (286, 9, 353, NULL, 906)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (286, 19, 309, NULL, 511)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (287, 1, 812, NULL, 298)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (287, 7, 197, NULL, 340)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (287, 9, 513, NULL, 773)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (287, 19, 671, NULL, 831)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (288, 1, 477, NULL, 648)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (288, 7, 826, NULL, 879)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (288, 9, 625, NULL, 785)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (288, 19, 316, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (289, 1, 722, NULL, 504)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (289, 7, 818, NULL, 391)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (289, 9, 419, NULL, 579)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (289, 19, 619, NULL, 681)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (290, 1, 105, NULL, 973)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (290, 7, 293, NULL, 635)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (290, 9, 793, NULL, 985)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (290, 19, 701, NULL, 991)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 18, 904, NULL, 493)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 21, 164, NULL, 928)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 22, 390, NULL, 520)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 23, 887, NULL, 249)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 24, 984, NULL, 594)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 25, 983, NULL, 815)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 26, 693, NULL, 729)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 27, 696, NULL, 551)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 28, 978, NULL, 358)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 29, 388, NULL, 222)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (291, 30, 428, NULL, 994)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 10, 851, NULL, 101)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 11, 752, NULL, 270)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 12, 757, NULL, 939)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 13, 975, NULL, 920)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 14, 408, NULL, 894)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 15, 276, NULL, 516)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 16, 600, NULL, 973)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (292, 17, 598, NULL, 449)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (293, 6, 111, NULL, 738)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (294, 3, 479, NULL, 642)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (294, 4, 582, NULL, 385)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (295, 2, 922, NULL, 787)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (295, 7, 937, NULL, 773)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (295, 9, 905, NULL, 890)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (295, 19, 864, NULL, 918)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (296, 2, 472, NULL, 496)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (296, 7, 667, NULL, 996)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (296, 9, 767, NULL, 614)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (296, 19, 264, NULL, 839)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (297, 2, 629, NULL, 861)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (297, 7, 444, NULL, 863)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (297, 9, 699, NULL, 657)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (297, 19, 606, NULL, 541)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (298, 2, 988, NULL, 595)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (298, 7, 443, NULL, 687)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (298, 9, 330, NULL, 288)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (298, 19, 323, NULL, 298)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (299, 2, 370, NULL, 563)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (299, 7, 410, NULL, 299)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (299, 9, 197, NULL, 377)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (299, 19, 793, NULL, 691)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (300, 2, 724, NULL, 978)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (300, 7, 175, NULL, 343)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (300, 9, 391, NULL, 938)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (300, 19, 407, NULL, 694)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (301, 2, 306, NULL, 147)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (301, 7, 664, NULL, 231)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (301, 9, 346, NULL, 526)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (301, 19, 460, NULL, 103)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (302, 2, 158, NULL, 223)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (302, 7, 805, NULL, 884)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (302, 9, 934, NULL, 366)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (302, 19, 295, NULL, 468)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (303, 2, 465, NULL, 569)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (303, 7, 378, NULL, 795)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (303, 9, 438, NULL, 532)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (303, 19, 932, NULL, 866)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (304, 2, 225, NULL, 885)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (304, 7, 866, NULL, 471)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (304, 9, 939, NULL, 898)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (304, 19, 904, NULL, 438)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (305, 2, 569, NULL, 456)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (305, 7, 882, NULL, 578)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (305, 9, 376, NULL, 404)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (305, 19, 752, NULL, 694)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (306, 1, 638, NULL, 185)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (306, 7, 688, NULL, 459)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (306, 9, 861, NULL, 702)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (306, 19, 501, NULL, 506)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (307, 1, 943, NULL, 597)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (307, 7, 918, NULL, 779)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (307, 9, 141, NULL, 715)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (307, 19, 349, NULL, 568)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (308, 1, 316, NULL, 351)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (308, 7, 403, NULL, 213)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (308, 9, 691, NULL, 768)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (308, 19, 630, NULL, 865)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (309, 1, 428, NULL, 509)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (309, 7, 108, NULL, 358)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (309, 9, 205, NULL, 557)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (309, 19, 599, NULL, 653)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (310, 1, 714, NULL, 387)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (310, 7, 829, NULL, 897)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (310, 9, 611, NULL, 532)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (310, 19, 441, NULL, 413)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (311, 1, 147, NULL, 747)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (311, 7, 851, NULL, 542)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (311, 9, 702, NULL, 331)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (311, 19, 752, NULL, 550)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 18, 970, NULL, 360)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 21, 601, NULL, 829)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 22, 269, NULL, 897)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 23, 131, NULL, 144)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 24, 477, NULL, 909)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 25, 747, NULL, 250)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 26, 954, NULL, 852)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 27, 682, NULL, 826)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 28, 448, NULL, 538)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 29, 659, NULL, 627)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (312, 30, 117, NULL, 110)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 10, 770, NULL, 521)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 11, 146, NULL, 317)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 12, 257, NULL, 290)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 13, 222, NULL, 346)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 14, 246, NULL, 214)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 15, 219, NULL, 551)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 16, 720, NULL, 782)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (313, 17, 691, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (314, 6, 707, NULL, 129)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (315, 3, 149, NULL, 107)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (315, 4, 985, NULL, 802)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (316, 2, 836, NULL, 701)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (316, 7, 441, NULL, 823)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (316, 9, 257, NULL, 627)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (316, 19, 907, NULL, 479)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (317, 2, 689, NULL, 101)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (317, 7, 981, NULL, 685)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (317, 9, 795, NULL, 909)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (317, 19, 346, NULL, 886)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (318, 2, 648, NULL, 641)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (318, 7, 549, NULL, 199)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (318, 9, 199, NULL, 930)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (318, 19, 185, NULL, 712)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (319, 2, 479, NULL, 479)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (319, 7, 430, NULL, 463)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (319, 9, 718, NULL, 231)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (319, 19, 377, NULL, 681)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (320, 2, 526, NULL, 434)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (320, 7, 354, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (320, 9, 486, NULL, 810)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (320, 19, 236, NULL, 379)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (321, 2, 550, NULL, 665)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (321, 7, 291, NULL, 979)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (321, 9, 623, NULL, 878)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (321, 19, 851, NULL, 910)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (322, 2, 783, NULL, 120)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (322, 7, 562, NULL, 395)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (322, 9, 809, NULL, 742)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (322, 19, 622, NULL, 201)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (323, 2, 891, NULL, 104)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (323, 7, 188, NULL, 524)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (323, 9, 338, NULL, 511)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (323, 19, 557, NULL, 754)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (324, 2, 557, NULL, 979)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (324, 7, 706, NULL, 541)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (324, 9, 856, NULL, 202)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (324, 19, 765, NULL, 381)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (325, 2, 807, NULL, 434)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (325, 7, 934, NULL, 501)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (325, 9, 525, NULL, 455)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (325, 19, 454, NULL, 441)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (326, 2, 402, NULL, 777)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (326, 7, 245, NULL, 778)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (326, 9, 794, NULL, 862)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (326, 19, 794, NULL, 286)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (327, 1, 920, NULL, 499)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (327, 7, 992, NULL, 326)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (327, 9, 911, NULL, 478)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (327, 19, 313, NULL, 831)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (328, 1, 900, NULL, 941)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (328, 7, 115, NULL, 152)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (328, 9, 985, NULL, 968)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (328, 19, 771, NULL, 434)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (329, 1, 319, NULL, 848)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (329, 7, 370, NULL, 880)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (329, 9, 117, NULL, 528)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (329, 19, 938, NULL, 826)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (330, 1, 805, NULL, 711)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (330, 7, 309, NULL, 677)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (330, 9, 554, NULL, 299)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (330, 19, 505, NULL, 627)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (331, 1, 662, NULL, 333)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (331, 7, 388, NULL, 168)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (331, 9, 931, NULL, 825)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (331, 19, 684, NULL, 612)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (332, 1, 173, NULL, 586)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (332, 7, 871, NULL, 103)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (332, 9, 113, NULL, 864)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (332, 19, 107, NULL, 316)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 18, 300, NULL, 673)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 21, 866, NULL, 170)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 22, 197, NULL, 858)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 23, 266, NULL, 894)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 24, 967, NULL, 429)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 25, 418, NULL, 390)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 26, 987, NULL, 118)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 27, 721, NULL, 833)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 28, 335, NULL, 396)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 29, 725, NULL, 956)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (333, 30, 996, NULL, 163)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 10, 273, NULL, 695)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 11, 618, NULL, 274)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 12, 269, NULL, 903)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 13, 846, NULL, 733)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 14, 493, NULL, 651)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 15, 841, NULL, 155)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 16, 189, NULL, 960)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (334, 17, 996, NULL, 699)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (335, 6, 767, NULL, 783)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (336, 3, 213, NULL, 549)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (336, 4, 322, NULL, 948)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (337, 2, 603, NULL, 915)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (337, 7, 789, NULL, 474)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (337, 9, 458, NULL, 366)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (337, 19, 197, NULL, 803)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (338, 2, 444, NULL, 120)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (338, 7, 619, NULL, 464)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (338, 9, 331, NULL, 140)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (338, 19, 666, NULL, 155)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (339, 2, 836, NULL, 268)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (339, 7, 208, NULL, 217)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (339, 9, 283, NULL, 558)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (339, 19, 401, NULL, 269)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (340, 2, 943, NULL, 804)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (340, 7, 776, NULL, 320)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (340, 9, 166, NULL, 992)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (340, 19, 401, NULL, 361)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (341, 2, 159, NULL, 857)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (341, 7, 202, NULL, 456)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (341, 9, 533, NULL, 913)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (341, 19, 324, NULL, 494)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (342, 2, 178, NULL, 995)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (342, 7, 784, NULL, 197)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (342, 9, 414, NULL, 361)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (342, 19, 932, NULL, 961)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (343, 2, 558, NULL, 470)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (343, 7, 338, NULL, 841)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (343, 9, 674, NULL, 536)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (343, 19, 642, NULL, 920)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (344, 2, 536, NULL, 873)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (344, 7, 374, NULL, 461)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (344, 9, 198, NULL, 484)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (344, 19, 349, NULL, 984)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (345, 2, 889, NULL, 343)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (345, 7, 962, NULL, 908)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (345, 9, 209, NULL, 471)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (345, 19, 921, NULL, 939)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (346, 2, 434, NULL, 178)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (346, 7, 544, NULL, 846)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (346, 9, 899, NULL, 787)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (346, 19, 422, NULL, 953)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (347, 2, 570, NULL, 492)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (347, 7, 270, NULL, 237)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (347, 9, 947, NULL, 381)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (347, 19, 287, NULL, 868)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (348, 1, 290, NULL, 323)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (348, 7, 459, NULL, 874)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (348, 9, 505, NULL, 571)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (348, 19, 501, NULL, 921)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (349, 1, 186, NULL, 469)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (349, 7, 689, NULL, 740)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (349, 9, 273, NULL, 985)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (349, 19, 862, NULL, 659)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (350, 1, 330, NULL, 361)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (350, 7, 991, NULL, 272)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (350, 9, 353, NULL, 152)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (350, 19, 785, NULL, 788)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (351, 1, 530, NULL, 499)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (351, 7, 204, NULL, 122)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (351, 9, 885, NULL, 798)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (351, 19, 697, NULL, 284)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (352, 1, 567, NULL, 799)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (352, 7, 666, NULL, 475)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (352, 9, 425, NULL, 506)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (352, 19, 656, NULL, 206)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (353, 1, 328, NULL, 408)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (353, 7, 602, NULL, 993)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (353, 9, 194, NULL, 600)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (353, 19, 908, NULL, 598)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 18, 298, NULL, 316)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 21, 417, NULL, 752)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 22, 597, NULL, 578)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 23, 635, NULL, 615)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 24, 362, NULL, 390)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 25, 486, NULL, 528)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 26, 354, NULL, 112)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 27, 934, NULL, 173)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 28, 595, NULL, 159)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 29, 535, NULL, 754)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (354, 30, 740, NULL, 108)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 10, 618, NULL, 186)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 11, 717, NULL, 407)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 12, 468, NULL, 910)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 13, 987, NULL, 530)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 14, 609, NULL, 167)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 15, 767, NULL, 312)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 16, 394, NULL, 260)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (355, 17, 589, NULL, 302)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (356, 6, 455, NULL, 535)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (357, 3, 313, NULL, 611)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (357, 4, 198, NULL, 475)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (358, 2, 608, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (358, 7, 598, NULL, 433)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (358, 9, 235, NULL, 484)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (358, 19, 985, NULL, 399)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (359, 2, 844, NULL, 249)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (359, 7, 183, NULL, 209)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (359, 9, 106, NULL, 584)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (359, 19, 988, NULL, 243)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (360, 2, 517, NULL, 984)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (360, 7, 726, NULL, 759)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (360, 9, 270, NULL, 347)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (360, 19, 748, NULL, 968)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (361, 2, 535, NULL, 504)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (361, 7, 155, NULL, 181)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (361, 9, 186, NULL, 552)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (361, 19, 427, NULL, 297)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (362, 2, 922, NULL, 317)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (362, 7, 542, NULL, 315)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (362, 9, 271, NULL, 521)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (362, 19, 732, NULL, 572)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (363, 2, 622, NULL, 802)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (363, 7, 936, NULL, 440)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (363, 9, 598, NULL, 310)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (363, 19, 708, NULL, 112)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (364, 2, 258, NULL, 660)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (364, 7, 826, NULL, 523)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (364, 9, 934, NULL, 887)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (364, 19, 864, NULL, 516)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (365, 2, 216, NULL, 857)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (365, 7, 657, NULL, 122)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (365, 9, 151, NULL, 877)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (365, 19, 744, NULL, 291)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (366, 2, 589, NULL, 921)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (366, 7, 930, NULL, 801)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (366, 9, 388, NULL, 942)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (366, 19, 627, NULL, 112)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (367, 2, 577, NULL, 550)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (367, 7, 708, NULL, 729)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (367, 9, 790, NULL, 599)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (367, 19, 183, NULL, 629)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (368, 2, 111, NULL, 137)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (368, 7, 133, NULL, 597)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (368, 9, 392, NULL, 860)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (368, 19, 963, NULL, 121)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (369, 1, 376, NULL, 553)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (369, 7, 718, NULL, 975)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (369, 9, 272, NULL, 637)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (369, 19, 945, NULL, 173)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (370, 1, 248, NULL, 377)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (370, 7, 959, NULL, 446)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (370, 9, 638, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (370, 19, 478, NULL, 925)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (371, 1, 680, NULL, 418)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (371, 7, 869, NULL, 663)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (371, 9, 457, NULL, 138)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (371, 19, 811, NULL, 957)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (372, 1, 964, NULL, 617)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (372, 7, 746, NULL, 767)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (372, 9, 789, NULL, 530)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (372, 19, 687, NULL, 209)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (373, 1, 862, NULL, 730)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (373, 7, 432, NULL, 135)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (373, 9, 488, NULL, 689)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (373, 19, 483, NULL, 160)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (374, 1, 529, NULL, 293)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (374, 7, 787, NULL, 187)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (374, 9, 987, NULL, 600)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (374, 19, 891, NULL, 310)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 18, 150, NULL, 765)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 21, 612, NULL, 503)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 22, 442, NULL, 788)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 23, 433, NULL, 236)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 24, 854, NULL, 190)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 25, 595, NULL, 884)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 26, 233, NULL, 740)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 27, 583, NULL, 311)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 28, 432, NULL, 793)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 29, 207, NULL, 659)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (375, 30, 632, NULL, 432)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 10, 720, NULL, 399)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 11, 475, NULL, 865)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 12, 416, NULL, 677)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 13, 917, NULL, 838)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 14, 278, NULL, 627)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 15, 806, NULL, 392)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 16, 959, NULL, 254)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (376, 17, 954, NULL, 284)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (377, 6, 701, NULL, 767)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (378, 3, 347, NULL, 471)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (378, 4, 624, NULL, 323)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (379, 2, 470, NULL, 178)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (379, 7, 155, NULL, 938)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (379, 9, 307, NULL, 558)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (379, 19, 846, NULL, 831)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (380, 2, 760, NULL, 388)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (380, 7, 649, NULL, 699)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (380, 9, 937, NULL, 235)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (380, 19, 739, NULL, 282)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (381, 2, 502, NULL, 655)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (381, 7, 246, NULL, 679)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (381, 9, 901, NULL, 354)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (381, 19, 369, NULL, 634)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (382, 2, 331, NULL, 210)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (382, 7, 144, NULL, 601)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (382, 9, 146, NULL, 288)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (382, 19, 581, NULL, 823)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (383, 2, 226, NULL, 658)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (383, 7, 482, NULL, 612)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (383, 9, 497, NULL, 394)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (383, 19, 153, NULL, 637)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (384, 2, 921, NULL, 328)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (384, 7, 865, NULL, 904)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (384, 9, 128, NULL, 890)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (384, 19, 384, NULL, 202)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (385, 2, 423, NULL, 688)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (385, 7, 218, NULL, 544)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (385, 9, 346, NULL, 903)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (385, 19, 408, NULL, 661)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (386, 2, 486, NULL, 462)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (386, 7, 631, NULL, 192)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (386, 9, 865, NULL, 235)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (386, 19, 500, NULL, 855)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (387, 2, 327, NULL, 595)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (387, 7, 618, NULL, 886)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (387, 9, 580, NULL, 480)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (387, 19, 829, NULL, 824)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (388, 2, 839, NULL, 988)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (388, 7, 334, NULL, 576)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (388, 9, 835, NULL, 919)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (388, 19, 570, NULL, 343)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (389, 2, 667, NULL, 575)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (389, 7, 992, NULL, 314)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (389, 9, 232, NULL, 708)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (389, 19, 960, NULL, 795)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (390, 1, 735, NULL, 126)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (390, 7, 679, NULL, 600)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (390, 9, 405, NULL, 938)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (390, 19, 125, NULL, 647)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (391, 1, 721, NULL, 202)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (391, 7, 631, NULL, 937)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (391, 9, 930, NULL, 679)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (391, 19, 706, NULL, 174)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (392, 1, 135, NULL, 725)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (392, 7, 351, NULL, 571)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (392, 9, 249, NULL, 123)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (392, 19, 876, NULL, 629)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (393, 1, 733, NULL, 473)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (393, 7, 552, NULL, 482)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (393, 9, 134, NULL, 645)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (393, 19, 286, NULL, 278)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (394, 1, 300, NULL, 310)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (394, 7, 197, NULL, 700)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (394, 9, 214, NULL, 484)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (394, 19, 786, NULL, 813)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (395, 1, 667, NULL, 117)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (395, 7, 816, NULL, 287)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (395, 9, 209, NULL, 531)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (395, 19, 366, NULL, 441)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 18, 905, NULL, 403)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 21, 688, NULL, 445)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 22, 648, NULL, 485)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 23, 128, NULL, 402)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 24, 945, NULL, 990)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 25, 130, NULL, 648)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 26, 616, NULL, 431)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 27, 479, NULL, 648)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 28, 518, NULL, 568)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 29, 104, NULL, 729)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (396, 30, 228, NULL, 895)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 10, 890, NULL, 253)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 11, 490, NULL, 515)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 12, 980, NULL, 537)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 13, 320, NULL, 311)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 14, 439, NULL, 428)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 15, 313, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 16, 959, NULL, 676)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (397, 17, 718, NULL, 442)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (398, 6, 413, NULL, 758)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (399, 3, 740, NULL, 576)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (399, 4, 929, NULL, 428)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (400, 2, 597, NULL, 856)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (400, 7, 180, NULL, 694)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (400, 9, 443, NULL, 188)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (400, 19, 163, NULL, 344)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (401, 2, 156, NULL, 761)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (401, 7, 715, NULL, 463)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (401, 9, 839, NULL, 592)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (401, 19, 758, NULL, 783)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (402, 2, 227, NULL, 688)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (402, 7, 118, NULL, 715)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (402, 9, 280, NULL, 954)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (402, 19, 329, NULL, 953)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (403, 2, 847, NULL, 682)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (403, 7, 808, NULL, 520)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (403, 9, 638, NULL, 469)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (403, 19, 750, NULL, 243)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (404, 2, 584, NULL, 101)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (404, 7, 309, NULL, 298)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (404, 9, 538, NULL, 946)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (404, 19, 741, NULL, 774)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (405, 2, 265, NULL, 509)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (405, 7, 383, NULL, 278)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (405, 9, 726, NULL, 468)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (405, 19, 728, NULL, 965)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (406, 2, 621, NULL, 748)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (406, 7, 666, NULL, 701)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (406, 9, 650, NULL, 536)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (406, 19, 158, NULL, 314)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (407, 2, 921, NULL, 129)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (407, 7, 624, NULL, 639)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (407, 9, 812, NULL, 762)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (407, 19, 798, NULL, 566)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (408, 2, 708, NULL, 569)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (408, 7, 789, NULL, 737)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (408, 9, 524, NULL, 549)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (408, 19, 106, NULL, 182)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (409, 2, 229, NULL, 214)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (409, 7, 865, NULL, 417)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (409, 9, 582, NULL, 746)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (409, 19, 203, NULL, 510)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (410, 2, 693, NULL, 552)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (410, 7, 286, NULL, 465)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (410, 9, 692, NULL, 627)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (410, 19, 355, NULL, 830)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (411, 1, 939, NULL, 546)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (411, 7, 997, NULL, 893)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (411, 9, 703, NULL, 511)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (411, 19, 967, NULL, 595)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (412, 1, 792, NULL, 837)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (412, 7, 971, NULL, 285)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (412, 9, 663, NULL, 712)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (412, 19, 268, NULL, 137)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (413, 1, 925, NULL, 229)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (413, 7, 671, NULL, 275)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (413, 9, 844, NULL, 450)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (413, 19, 824, NULL, 654)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (414, 1, 478, NULL, 208)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (414, 7, 742, NULL, 217)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (414, 9, 698, NULL, 139)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (414, 19, 902, NULL, 668)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (415, 1, 261, NULL, 981)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (415, 7, 439, NULL, 181)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (415, 9, 927, NULL, 924)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (415, 19, 118, NULL, 838)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (416, 1, 461, NULL, 881)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (416, 7, 274, NULL, 301)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (416, 9, 129, NULL, 669)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (416, 19, 409, NULL, 883)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 18, 768, NULL, 950)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 21, 863, NULL, 885)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 22, 587, NULL, 115)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 23, 378, NULL, 843)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 24, 711, NULL, 344)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 25, 572, NULL, 551)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 26, 955, NULL, 802)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 27, 107, NULL, 410)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 28, 289, NULL, 340)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 29, 442, NULL, 460)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (417, 30, 541, NULL, 239)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 10, 421, NULL, 715)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 11, 172, NULL, 773)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 12, 924, NULL, 378)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 13, 979, NULL, 845)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 14, 971, NULL, 860)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 15, 172, NULL, 187)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 16, 421, NULL, 265)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (418, 17, 646, NULL, 569)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (419, 6, 844, NULL, 840)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (420, 3, 792, NULL, 474)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (420, 4, 129, NULL, 823)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (421, 2, 996, NULL, 802)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (421, 7, 381, NULL, 563)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (421, 9, 344, NULL, 125)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (421, 19, 329, NULL, 641)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (422, 2, 477, NULL, 254)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (422, 7, 784, NULL, 542)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (422, 9, 210, NULL, 395)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (422, 19, 754, NULL, 763)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (423, 2, 829, NULL, 499)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (423, 7, 394, NULL, 370)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (423, 9, 470, NULL, 995)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (423, 19, 706, NULL, 192)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (424, 2, 159, NULL, 509)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (424, 7, 968, NULL, 983)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (424, 9, 397, NULL, 797)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (424, 19, 276, NULL, 799)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (425, 2, 110, NULL, 470)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (425, 7, 206, NULL, 735)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (425, 9, 168, NULL, 560)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (425, 19, 627, NULL, 395)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (426, 2, 577, NULL, 341)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (426, 7, 245, NULL, 180)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (426, 9, 835, NULL, 570)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (426, 19, 268, NULL, 650)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (427, 2, 886, NULL, 538)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (427, 7, 239, NULL, 902)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (427, 9, 599, NULL, 736)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (427, 19, 599, NULL, 614)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (428, 2, 656, NULL, 307)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (428, 7, 142, NULL, 762)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (428, 9, 524, NULL, 174)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (428, 19, 247, NULL, 217)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (429, 2, 740, NULL, 293)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (429, 7, 468, NULL, 659)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (429, 9, 683, NULL, 111)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (429, 19, 300, NULL, 285)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (430, 2, 383, NULL, 321)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (430, 7, 960, NULL, 951)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (430, 9, 179, NULL, 500)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (430, 19, 390, NULL, 547)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (431, 2, 679, NULL, 932)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (431, 7, 943, NULL, 846)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (431, 9, 122, NULL, 559)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (431, 19, 119, NULL, 660)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (432, 1, 485, NULL, 530)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (432, 7, 709, NULL, 942)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (432, 9, 886, NULL, 963)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (432, 19, 300, NULL, 697)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (433, 1, 609, NULL, 851)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (433, 7, 522, NULL, 974)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (433, 9, 999, NULL, 123)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (433, 19, 916, NULL, 934)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (434, 1, 177, NULL, 737)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (434, 7, 665, NULL, 807)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (434, 9, 280, NULL, 429)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (434, 19, 246, NULL, 185)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (435, 1, 143, NULL, 784)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (435, 7, 871, NULL, 785)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (435, 9, 849, NULL, 166)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (435, 19, 474, NULL, 364)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (436, 1, 621, NULL, 732)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (436, 7, 316, NULL, 370)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (436, 9, 162, NULL, 284)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (436, 19, 648, NULL, 675)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (437, 1, 742, NULL, 887)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (437, 7, 955, NULL, 704)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (437, 9, 360, NULL, 179)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (437, 19, 861, NULL, 563)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 18, 855, NULL, 926)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 21, 277, NULL, 573)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 22, 940, NULL, 635)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 23, 217, NULL, 744)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 24, 879, NULL, 732)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 25, 730, NULL, 150)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 26, 574, NULL, 312)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 27, 856, NULL, 891)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 28, 990, NULL, 978)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 29, 505, NULL, 999)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (438, 30, 984, NULL, 474)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 10, 943, NULL, 200)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 11, 147, NULL, 148)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 12, 699, NULL, 226)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 13, 123, NULL, 291)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 14, 425, NULL, 853)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 15, 700, NULL, 637)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 16, 713, NULL, 419)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (439, 17, 303, NULL, 913)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (440, 6, 453, NULL, 240)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (441, 3, 580, NULL, 973)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (441, 4, 748, NULL, 360)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (442, 2, 349, NULL, 813)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (442, 7, 743, NULL, 923)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (442, 9, 174, NULL, 604)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (442, 19, 633, NULL, 273)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (443, 2, 878, NULL, 423)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (443, 7, 200, NULL, 174)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (443, 9, 163, NULL, 873)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (443, 19, 803, NULL, 116)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (444, 2, 621, NULL, 392)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (444, 7, 226, NULL, 312)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (444, 9, 389, NULL, 373)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (444, 19, 724, NULL, 530)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (445, 2, 994, NULL, 122)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (445, 7, 818, NULL, 866)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (445, 9, 459, NULL, 782)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (445, 19, 366, NULL, 727)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (446, 2, 150, NULL, 774)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (446, 7, 676, NULL, 151)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (446, 9, 229, NULL, 221)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (446, 19, 581, NULL, 132)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (447, 2, 223, NULL, 121)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (447, 7, 468, NULL, 487)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (447, 9, 606, NULL, 881)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (447, 19, 221, NULL, 583)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (448, 2, 860, NULL, 268)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (448, 7, 225, NULL, 515)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (448, 9, 296, NULL, 247)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (448, 19, 531, NULL, 527)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (449, 2, 583, NULL, 261)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (449, 7, 465, NULL, 124)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (449, 9, 763, NULL, 511)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (449, 19, 574, NULL, 931)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (450, 2, 532, NULL, 349)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (450, 7, 305, NULL, 484)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (450, 9, 999, NULL, 303)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (450, 19, 437, NULL, 341)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (451, 2, 153, NULL, 242)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (451, 7, 317, NULL, 429)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (451, 9, 164, NULL, 679)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (451, 19, 210, NULL, 991)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (452, 2, 150, NULL, 220)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (452, 7, 863, NULL, 481)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (452, 9, 879, NULL, 167)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (452, 19, 651, NULL, 948)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (453, 1, 602, NULL, 311)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (453, 7, 751, NULL, 499)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (453, 9, 621, NULL, 898)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (453, 19, 869, NULL, 960)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (454, 1, 312, NULL, 506)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (454, 7, 717, NULL, 408)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (454, 9, 193, NULL, 400)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (454, 19, 102, NULL, 389)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (455, 1, 109, NULL, 604)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (455, 7, 520, NULL, 761)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (455, 9, 559, NULL, 397)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (455, 19, 681, NULL, 654)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (456, 1, 954, NULL, 651)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (456, 7, 802, NULL, 248)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (456, 9, 985, NULL, 589)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (456, 19, 485, NULL, 109)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (457, 1, 968, NULL, 592)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (457, 7, 150, NULL, 216)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (457, 9, 509, NULL, 922)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (457, 19, 383, NULL, 322)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (458, 1, 349, NULL, 200)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (458, 7, 347, NULL, 110)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (458, 9, 193, NULL, 838)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (458, 19, 197, NULL, 363)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 18, 669, NULL, 869)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 21, 591, NULL, 673)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 22, 645, NULL, 795)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 23, 733, NULL, 235)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 24, 613, NULL, 227)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 25, 178, NULL, 252)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 26, 708, NULL, 671)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 27, 181, NULL, 790)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 28, 801, NULL, 136)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 29, 476, NULL, 798)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (459, 30, 377, NULL, 514)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 10, 891, NULL, 833)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 11, 564, NULL, 319)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 12, 158, NULL, 387)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 13, 515, NULL, 411)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 14, 802, NULL, 117)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 15, 583, NULL, 124)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 16, 813, NULL, 856)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (460, 17, 165, NULL, 518)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (461, 6, 809, NULL, 311)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (462, 3, 101, NULL, 886)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (462, 4, 631, NULL, 746)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (463, 2, 105, NULL, 811)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (463, 7, 657, NULL, 214)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (463, 9, 122, NULL, 199)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (463, 19, 458, NULL, 296)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (464, 2, 845, NULL, 558)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (464, 7, 371, NULL, 601)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (464, 9, 814, NULL, 319)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (464, 19, 194, NULL, 835)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (465, 2, 408, NULL, 779)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (465, 7, 538, NULL, 783)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (465, 9, 492, NULL, 361)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (465, 19, 104, NULL, 689)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (466, 2, 874, NULL, 367)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (466, 7, 813, NULL, 569)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (466, 9, 762, NULL, 1000)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (466, 19, 968, NULL, 722)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (467, 2, 582, NULL, 127)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (467, 7, 174, NULL, 252)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (467, 9, 564, NULL, 936)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (467, 19, 723, NULL, 609)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (468, 2, 231, NULL, 568)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (468, 7, 223, NULL, 534)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (468, 9, 920, NULL, 978)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (468, 19, 838, NULL, 322)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (469, 2, 919, NULL, 742)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (469, 7, 999, NULL, 338)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (469, 9, 217, NULL, 379)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (469, 19, 458, NULL, 947)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (470, 2, 403, NULL, 535)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (470, 7, 526, NULL, 485)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (470, 9, 404, NULL, 631)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (470, 19, 547, NULL, 866)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (471, 2, 816, NULL, 300)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (471, 7, 421, NULL, 291)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (471, 9, 605, NULL, 882)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (471, 19, 457, NULL, 952)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (472, 2, 835, NULL, 549)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (472, 7, 989, NULL, 298)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (472, 9, 706, NULL, 836)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (472, 19, 747, NULL, 918)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (473, 2, 102, NULL, 800)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (473, 7, 572, NULL, 284)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (473, 9, 466, NULL, 708)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (473, 19, 750, NULL, 519)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (474, 1, 756, NULL, 541)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (474, 7, 430, NULL, 285)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (474, 9, 588, NULL, 389)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (474, 19, 655, NULL, 423)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (475, 1, 547, NULL, 358)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (475, 7, 341, NULL, 257)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (475, 9, 320, NULL, 939)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (475, 19, 146, NULL, 770)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (476, 1, 802, NULL, 396)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (476, 7, 313, NULL, 516)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (476, 9, 548, NULL, 121)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (476, 19, 103, NULL, 244)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (477, 1, 807, NULL, 824)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (477, 7, 923, NULL, 138)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (477, 9, 640, NULL, 228)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (477, 19, 626, NULL, 392)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (478, 1, 934, NULL, 775)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (478, 7, 159, NULL, 409)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (478, 9, 393, NULL, 304)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (478, 19, 986, NULL, 605)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (479, 1, 538, NULL, 392)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (479, 7, 339, NULL, 812)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (479, 9, 662, NULL, 413)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (479, 19, 710, NULL, 376)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 18, 410, NULL, 486)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 21, 482, NULL, 731)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 22, 605, NULL, 473)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 23, 275, NULL, 713)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 24, 632, NULL, 575)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 25, 456, NULL, 140)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 26, 458, NULL, 824)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 27, 333, NULL, 561)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 28, 555, NULL, 564)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 29, 700, NULL, 193)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (480, 30, 600, NULL, 854)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 10, 697, NULL, 644)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 11, 304, NULL, 279)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 12, 448, NULL, 421)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 13, 691, NULL, 461)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 14, 757, NULL, 218)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 15, 333, NULL, 137)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 16, 522, NULL, 281)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (481, 17, 356, NULL, 210)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (482, 6, 345, NULL, 311)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (483, 3, 1000, NULL, 301)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (483, 4, 906, NULL, 672)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (484, 2, 237, NULL, 549)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (484, 7, 216, NULL, 339)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (484, 9, 115, NULL, 669)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (484, 19, 613, NULL, 576)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (485, 2, 971, NULL, 820)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (485, 7, 786, NULL, 260)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (485, 9, 349, NULL, 607)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (485, 19, 557, NULL, 868)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (486, 2, 135, NULL, 899)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (486, 7, 855, NULL, 607)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (486, 9, 858, NULL, 670)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (486, 19, 769, NULL, 293)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (487, 2, 960, NULL, 760)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (487, 7, 357, NULL, 647)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (487, 9, 886, NULL, 132)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (487, 19, 537, NULL, 391)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (488, 2, 976, NULL, 921)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (488, 7, 762, NULL, 495)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (488, 9, 843, NULL, 786)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (488, 19, 728, NULL, 441)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (489, 2, 508, NULL, 957)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (489, 7, 543, NULL, 515)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (489, 9, 684, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (489, 19, 239, NULL, 519)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (490, 2, 868, NULL, 306)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (490, 7, 436, NULL, 154)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (490, 9, 355, NULL, 174)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (490, 19, 619, NULL, 604)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (491, 2, 513, NULL, 782)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (491, 7, 781, NULL, 329)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (491, 9, 600, NULL, 490)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (491, 19, 324, NULL, 720)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (492, 2, 332, NULL, 918)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (492, 7, 599, NULL, 973)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (492, 9, 386, NULL, 566)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (492, 19, 462, NULL, 567)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (493, 2, 526, NULL, 179)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (493, 7, 169, NULL, 471)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (493, 9, 870, NULL, 182)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (493, 19, 350, NULL, 888)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (494, 2, 142, NULL, 104)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (494, 7, 734, NULL, 542)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (494, 9, 830, NULL, 141)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (494, 19, 679, NULL, 699)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (495, 1, 389, NULL, 662)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (495, 7, 146, NULL, 775)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (495, 9, 408, NULL, 741)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (495, 19, 354, NULL, 781)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (496, 1, 348, NULL, 761)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (496, 7, 330, NULL, 436)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (496, 9, 957, NULL, 398)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (496, 19, 186, NULL, 915)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (497, 1, 150, NULL, 572)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (497, 7, 636, NULL, 836)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (497, 9, 854, NULL, 792)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (497, 19, 597, NULL, 455)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (498, 1, 748, NULL, 936)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (498, 7, 410, NULL, 902)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (498, 9, 758, NULL, 201)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (498, 19, 861, NULL, 540)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (499, 1, 840, NULL, 870)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (499, 7, 917, NULL, 260)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (499, 9, 275, NULL, 789)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (499, 19, 602, NULL, 351)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (500, 1, 207, NULL, 922)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (500, 7, 281, NULL, 259)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (500, 9, 510, NULL, 619)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (500, 19, 482, NULL, 443)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 18, 753, NULL, 215)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 21, 540, NULL, 982)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 22, 187, NULL, 669)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 23, 526, NULL, 530)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 24, 462, NULL, 722)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 25, 521, NULL, 332)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 26, 626, NULL, 941)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 27, 593, NULL, 779)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 28, 857, NULL, 731)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 29, 195, NULL, 317)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (501, 30, 841, NULL, 338)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 10, 691, NULL, 524)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 11, 670, NULL, 870)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 12, 997, NULL, 648)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 13, 445, NULL, 538)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 14, 240, NULL, 628)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 15, 219, NULL, 349)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 16, 996, NULL, 959)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (502, 17, 526, NULL, 507)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (503, 6, 983, NULL, 661)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (504, 3, 673, NULL, 808)
GO
INSERT [dbo].[ThucHien_TieuChi_TheoNgay] ([HeaderID], [MaTieuChi], [SanLuong], [GhiChu], [KeHoach]) VALUES (504, 4, 611, NULL, 510)
GO
SET IDENTITY_INSERT [dbo].[TrangThai] ON 

GO
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (1, N'Đang đi làm')
GO
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (2, N'Đã chấm dứt')
GO
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (3, N'Đang chờ điều động')
GO
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (4, N'Đang chờ chấm dứt')
GO
SET IDENTITY_INSERT [dbo].[TrangThai] OFF
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (1, N'Tiến sỹ')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (2, N'Thạc sỹ 
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (3, N'Đại học 
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (4, N'Cao đẳng 
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (5, N'Trung cấp chuyên nghiệp
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (6, N'CNKT(bằng nghề)
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (7, N'Sơ cấp 
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (8, N'Chứng chỉ 
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (9, N'Giấy chứng nhận
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (10, N'THPT
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (11, N'THCS')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (12, N'Trung cấp nghề')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (13, N'Trung cấp lý luận chính trị-Hành chính
')
GO
INSERT [dbo].[TrinhDo] ([MaTrinhDo], [TenTrinhDo]) VALUES (14, N'Cao đẳng nghề
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (1, N'Hồng Cẩm 
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (2, N'Hữu Nghị 
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (3, N'Mỏ Địa chất 
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (4, N'Đại học Công nghiệp 
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (5, N'Đại học Kinh Tế Quốc Dân
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (6, N'Trung Cấp Quân Y
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (7, N'Đại học Công nghiệp Quảng Ninh
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (8, N'Đại học xây dựng Hà Nội
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (9, N'Quản Lý Kinh Tế Công Nghiệp
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (10, N'Trung Học Kinh Tế Quảng Ninh
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (11, N'Đại học Bách Khoa
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (12, N'Viện Đại Học Mở
')
GO
INSERT [dbo].[Truong] ([MaTruong], [TenTruong]) VALUES (13, N'Học Viện Tài Chính
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'1', N'Kỹ thuật cơ điện mỏ hầm lò
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'2', N'Tin học B
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'3', N'Kỹ thuật khai thác mỏ hầm lò
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'4', N'Tiếng anh B
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'5', N'Kỹ thuật công trình xây dựng
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'6', N'Sửa chữa cơ điện mỏ hầm lò
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'7', N'Điện tử công nghiệp
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'8', N'Tin học A
')
GO
INSERT [dbo].[Nganh] ([MaNganh], [TenNganh]) VALUES (N'9', N'Kỹ thuật mỏ
')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'0101a', N'Trưởng ca vận hành
', N'Công Nhân Kỹ Thuật', NULL, N'3')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'0101b', N'Trưởng kíp vận hành
', N'Công Nhân Kỹ Thuật', NULL, N'3')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'0116', N'Nguội', N'Công Nhân Kỹ Thuật', N'Sửa chữa điện xí nghiệp
', N'4')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'10000', N'Khoa học tự nhiên 
', N'Trung Cấp', NULL, N'2')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'10600', N'Địa chất 
', N'Trung Cấp', N'Thủy văn
', N'2')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'10601', N'Địa chất tổng quát 
', N'Trung Cấp', NULL, N'2')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'10800', N'Địa chất
', N'Cao đẳng - Đại học ', NULL, N'1')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'10801', N'Địa chất học
', N'Cao đẳng - Đại học ', NULL, N'1')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'10803', N'Địa chất công trình
', N'Cao đẳng - Đại học ', NULL, N'1')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'10804', N'Địa chất thuỷ văn
', N'Cao đẳng - Đại học ', NULL, N'1')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'20100', N'Cơ khí 
', N'Cao đẳng - Đại học ', N'Quản lý đất đai
', N'1')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'20101', N'Cơ khí chế tạo máy 
', N'Cao đẳng - Đại học ', N'Cơ khí động lực, cơ khí ô tô, Cơ khí nông nghiệp, Kỹ thuật cơ khí
', N'1')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'20102', N'Chế tạo, sửa chữa máy 
', N'Trung Cấp', NULL, N'2')
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [TenChuyenNganh], [CapBac], [ChiTiet], [MaNganh]) VALUES (N'20103', N'Rèn dập 
', N'Trung Cấp', N'Chế tạo phụ tùng cơ khí
', N'2')
GO
SET IDENTITY_INSERT [dbo].[CongViec] ON 

GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (1, N'Giám đốc', N'TKV 09.2', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (2, N'Phó giám đốc', N'TKV 09.3', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (3, N'Kế toán trưởng', N'TKV 09.4', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (4, N'Bí thư đảng uỷ', N'TKV 09.2', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (5, N'Phó bí thư đảng uỷ', N'TKV 09.3', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (6, N'Chánh văn phòng đảng uỷ', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (7, N'Chánh văn phòng Công đoàn', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (8, N'Chủ tịch công đoàn', N'TKV 09.3', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (9, N'Phó chủ tịch Công đoàn', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (10, N'Bí thư đoàn thanh niên', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (11, N'Phó bí thư đoàn thanh niên', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (12, N'Trưởng phòng', N'TKV 08.3.VII', 724000)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (13, N'Phó trưởng phòng', N'TKV 08.3.VII', 579000)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (14, N'Quản đốc chỉ đạo sản xuất trực tiếp trong hầm lò', N'TKV 08.3.VII', 724000)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (15, N'Quản đốc Chỉ đạo sản xuất trực tiếp khai thác than lộ thiên và trong nhà máy sàng tuyển', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (16, N'Kỹ thuật viên phân xưởng chỉ đạo sản xuất trực tiếp khai thác than lộ thiên và trong nhà máy sàng tuyển', N'TKV 08.3.VII', 579000)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (17, N'Kỹ thuật viên phân xưởng', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (18, N'Quản đốc', N'TKV 08.4.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (19, N'Phó quản đốc chỉ đạo sản xuất trực tiếp trong hầm lò', N'TKV 08.3.VII', 579000)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (20, N'Phó quản đốc chỉ đạo sản xuất trực tiếp khai thác than lộ thiên và trong nhà máy sàng tuyển', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (21, N'Phó quản đốc', N'TKV 08.4.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (22, N'Phó quản đốc cơ điện chỉ đạo sản xuất trực tiếp trong hầm lò', N'TKV 08.4.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (23, N'Phó quản đốc cơ điện chỉ đạo sản xuất trực tiếp khai thác than lộ thiên và trong nhà máy sàng tuyển', N'TKV 08.3.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (24, N'Kỹ thuật viên phân xưởng ', N'TKV 01.NI.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (25, N'Kinh tế viên (Nhân viên kinh tế)', N'TKV 01.NI.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (26, N'Cán sự', N'TKV 01.NI.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (27, N'Cán sự (Nhân viên kinh tế)', N'TKV 02.NI.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (28, N'(Kỹ thuật viên) Chỉ đạo kỹ thuật trực tiếp trong hầm lò', N'TKV 02.NII.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (29, N'Kỹ thuật viên (Y tá) trực dưới hầm lò ', N'TKV 02.NII.VII', NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (30, N'Kỹ thuật viên (Y tá)', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (31, N'Chưa phân công', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (32, N'Chuyên viên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (33, N'(Công nhân) khai thác mỏ hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (34, N'(Lò trưởng) khai thác mỏ hầm lò ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (35, N'(Công nhân) khai thác mỏ hầm lò ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (36, N'Công nhân quan trắc (công nhân trực thông tin)', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (37, N'Công nhân trực thông tin', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (38, N'Công nhân trực thông tin (Công nhân quan trắc) ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (39, N'(Công nhân) Nấu ăn trong các nhà hàng, khách sạn, các bếp ăn tập thể có từ 100 suất ăn trở lên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (40, N'Công nhân lao động phổ thông', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (41, N'Công nhân cấp phát bồi dưỡng', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (42, N'Công nhân sản xuất nước uống tinh khiết', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (43, N'Công nhân quét dọn nhà vệ sinh công cộng; xử lý rác sinh hoạt ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (44, N'Công nhân thống kê', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (45, N'Công nhân giặt quần áo bảo hộ lao động', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (46, N'Công nhân giặt sấy bảo hộ lao động', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (47, N'Công nhân vận hành thiết bị điện tử tin học (VH cân giao than )', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (48, N'Công nhân thợ mộc, nề, sắt', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (49, N'Công nhân thủ kho vật tư', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (50, N'(Công nhân) bốc xếp thủ công ở các ga, kho, bến, bãi', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (51, N'Công nhân bốc xếp vật tư (bốc xếp thủ công ở các ga, kho, bến, bãi)', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (52, N'Công nhân tiếp liệu', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (53, N'Công nhân vận hành trạm bơm nước', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (54, N'Công nhân vẫy đầu đường, thống kế chuyến, điều xe', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (55, N'(Công nhân) sàng tuyển thủ công, khai thác than thủ công ở mỏ lộ thiên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (56, N'(Công nhân) vận hành băng tải, máy nghiền, sàng than, đá', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (57, N'(Công nhân) Sửa chữa, bảo dưỡng các thiết bị khai thác than', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (58, N'(Công nhân) lấy mẫu, hóa nghiệm phân tích than', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (59, N'Công nhân kiểm tra chất lượng sản phẩm ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (60, N'(Công nhân) Sửa chữa cơ điện trên các mỏ lộ thiên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (61, N'(Công nhân) Sửa chữa, bảo dưỡng các thiết bị khai thác than', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (62, N'Công nhân vận hành nồi hơi đốt than', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (63, N'(Công nhân) giao nhận, bán buôn, bán lẻ xăng, dầu, nhựa đường, các sản phẩm hoá dầu tại cửa hàng, kho,trạm, bến, bãi và trên sông', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (64, N'(Công nhân) Đo khí, đo gió, trực cửa gió, trắc địa. KCS trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (65, N'(Công nhân) trực gác cửa gió trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (66, N'(Công nhân) sửa chữa ắc quy', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (67, N'(Công nhân) vận hành, bảo trì trạm biến thế trung thế', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (68, N'(Công nhân) đo khí, đo gió trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (69, N'(Công nhân) vận tải than trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (70, N'(Công nhân) lái máy gạt, ủi công suất dưới 180 CV', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (71, N'(Công nhân) lái máy xúc dung tích gầu dưới 4m3', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (72, N'Sửa chữa cơ điện trong mỏ hầm lò (Đốc công)', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (73, N'(Công nhân) Sửa chữa cơ điện trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (74, N'(Công nhân) lắp đặt, sửa chữa hệ thống thông tin liên lạc trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (75, N'(Công nhân) vận hành trạm quạt khí nén, điện, diezel, trạm xạc ắc quy trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (76, N'(Công nhân khoan thăm dò) Khoan đá bằng búa máy cầm tay trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (77, N'(Công nhân) thủ kho mìn trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (78, N'(Công nhân) Bắn mìn lộ thiên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (79, N'(Công nhân) thủ kho vật liệu nổ công nghiệp', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (80, N'(Công nhân) Lái máy gạt, ủi có công suất từ 180 CV trở lên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (81, N'(Công nhân) Lái máy xúc dung tích gầu từ 4m3 trở lên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (82, N'(Công nhân) vận hành máy khoan super, khoan sông đơ, khoan đập cáp trên các mỏ lộ thiên', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (83, N'Công nhân trông giữ xe', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (84, N'Công nhân bảo vệ tuần tra, canh gác', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (85, N'(Công nhân) bảo vệ kho trong hầm lò', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (86, N'(Công nhân) bảo vệ tài nguyên, ranh giới mỏ than', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (87, N'Công nhân lái xe con', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (88, N'Công nhân lái xe con (lái xe cứu thương)', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (89, N'Công nhân lái xe khách dưới 20 ghế', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (90, N'Công nhân lái xe cẩu dưới 3,5 tấn ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (91, N'Công nhân lái xe tải từ 3,5 tấn đến dưới 7,5 tấn ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (92, N'Công nhân lái xe khách từ 20 ghế đến dưới 40 ghế ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (93, N'Công nhân lái xe cẩu từ 3,5 tấn đến dưới 7,5 tấn ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (94, N'Công nhân lái xe nâng, hạ từ 3,5 tấn đến dưới 7,5 tấn ', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (95, N'(Công nhân) Lái xe ô tô khách từ 40 ghế đến dưới 80 ghế', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (96, N'(Công nhân) lái xe vận tải từ 7 tấn đến dưới 20 tấn', NULL, NULL)
GO
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec], [ThangLuong], [PhuCap]) VALUES (97, N'(Công nhân) lái xe vận tải, có trọng tải 20 tấn trở lên', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CongViec] OFF
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8056', N'Cao Thành Duy', NULL, 1, NULL, NULL, NULL, CAST(0x171C0B00 AS Date), N'Hải Phòng', N'Kinh', N'Dương Quan, Thủy Nguyên, Hải Phòng', NULL, N'Cẩm Thủy, Cẩm Phả, Quảng Ninh', N'01659166660', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 25, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8057', N'Lưu Đức Thắng', NULL, 1, NULL, NULL, NULL, CAST(0x2F1D0B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'0962168826', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 46, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8058', N'Đào Văn Thành', NULL, 1, NULL, NULL, NULL, CAST(0xB31D0B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'0963382104', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 34, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8059', N'Nguyễn Văn Đại', NULL, 1, NULL, NULL, NULL, CAST(0x69170B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'0974089302', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 14, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8060', N'Phạm Duy Hùng', NULL, 1, NULL, NULL, NULL, CAST(0xC41C0B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'01689223039', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 25, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8061', N'Nguyễn Văn Lâm', NULL, 1, NULL, NULL, NULL, CAST(0xA41B0B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'0987320421', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 18, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8062', N'Phạm Ngọc Quý', NULL, 1, NULL, NULL, NULL, CAST(0xDC190B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'0965154965', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8063', N'Đặng Thái Hà', NULL, 1, NULL, NULL, NULL, CAST(0xC90E0B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'0989439878', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 32, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8064', N'Nguyễn Văn Thọ', NULL, 1, NULL, NULL, NULL, CAST(0xE4060B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'0987045771', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8065', N'Vừ A Dinh', NULL, 1, NULL, NULL, NULL, CAST(0xB30D0B00 AS Date), NULL, NULL, NULL, NULL, NULL, N'01697642352', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'khoe', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 32, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8066', N'Trần Nhật Thu', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CNKT', 31, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8067', N'Nguyễn Duy Giang', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CNCD', 56, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8069', N'Đỗ Văn Oai', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CNKT', 24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'PXKT1')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ten], [Tenkhac], [GioiTinh], [CapUyHienTai], [CapUyKiem], [PhuCapChucVu], [NgaySinh], [NoiSinh], [DanToc], [QueQuan], [TonGiao], [NoiOHienTai], [SoDienThoai], [TPGiaDinhXuatThan], [NgayThamGiaCachMang], [NgayVaoDangCSVN], [NgayChinhThuc], [NgayVaoToChucCTXH], [ToChuc], [NgayNhapNgu], [NgayXuatNgu], [QuanHamChucVuCaoNhat], [HocHamHocViCaoNhat], [LyLuanChinhTri], [NgoaiNgu], [CongTacChinhDangLam], [NgachCongChuc], [MaNgach], [DanhHieuDuocPhong], [SoTruongCongTac], [CongViecDaLamLauNhat], [KhenThuong], [KyLuat], [TinhTrangSucKhoe], [ChiTietSucKhoe], [ChieuCao], [CanNang], [NhomMau], [HangThuongBinh], [GiaDinhChinhSach], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgayDiLam], [MaUyQuyen], [SoBHXH], [NgayTraBHXH], [LoaiNhanVien], [MaCongViec], [MucLuong], [MaTrinhDo], [MaTruong], [BacLuong], [NgheTruoc], [NgayTuyenDungTruoc], [CoQuanTruoc], [HeSo], [TuThang], [MaTrangThai], [MaChuyenNganh], [MaPhongBan]) VALUES (N'8070', N'Vũ Anh Tuấn', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CNCD', 21, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'PXKT1')
GO
SET IDENTITY_INSERT [dbo].[BangCap_GiayChungNhan] ON 

GO
INSERT [dbo].[BangCap_GiayChungNhan] ([MaTruong], [MaBangCap_GiayChungNhan], [MaTrinhDo], [KieuBangCap], [ThoiHan], [TenBangCap], [Loai], [MaChuyenNganh]) VALUES (5, 1, 2, N'Bản gốc', N'-1', N'Bằng cử nhân đại học', N'Bằng cấp', N'10600')
GO
SET IDENTITY_INSERT [dbo].[BangCap_GiayChungNhan] OFF
GO
SET IDENTITY_INSERT [dbo].[ChungChi] ON 

GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (1, N'AT điện bậc 1', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (2, N'AT điện bậc 2', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (3, N'AT điện bậc 3', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (4, N'ĐGKNN Đạt', 12, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (5, N'Giảng viên HLATLĐ', 12, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (6, N'Thiết bị áp lực VH hàn hơi', 6, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (7, N'Thiết bị áp lực VH máy nén khí', 18, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (8, N'Thiết bị áp lực VH nồi hơi', 18, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (9, N'Thiết bị áp lực VH thiết bị áp lực', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (10, N'Tời VH tời trục mỏ', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (11, N'Thiết bị nâng VH Monoray', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (12, N'Tời VH tời chở người', 18, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (13, N'Tời Phụ trách toa xe', 18, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (14, N'Vật liệu nổ Người quản lý', 24, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (15, N'Vật liệu nổ Chỉ huy nổ mìn', 24, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (16, N'Vật liệu nổ Người phục vụ', 24, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (17, N'Vật liệu nổ Người vận chuyển', 24, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (18, N'Vật liệu nổ Quản lý kho VLNCN', 24, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (19, N'Vật liệu nổ Thợ mìn hạng B', 24, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (20, N'Vật liệu nổ Thợ mìn hạng C', 24, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (21, N'Vì neo Vì neo', 18, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (22, N'VH tàu điện', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (23, N'Thiết bị nâng Thiết bị nâng hạ', 36, N'Bản gốc')
GO
INSERT [dbo].[ChungChi] ([MaChungChi], [TenChungChi], [ThoiHan], [KieuChungChi]) VALUES (24, N'Thiết bị nâng VH xe nâng hàng', 36, N'Bản gốc')
GO
SET IDENTITY_INSERT [dbo].[ChungChi] OFF
GO
INSERT [dbo].[ChungChi_NhanVien] ([SoHieu], [NgayCap], [MaNV], [MaChungChi], [NgayTra]) VALUES (N'1', CAST(0x38400B00 AS Date), N'8056', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[NhiemVu] ON 

GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'ĐGKNN', N'ĐẠT', 4, 1)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'AT điện', N'Bậc 1', 1, 2)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'AT điện', N'Bậc 2', 2, 3)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'AT điện', N'Bậc 3', 3, 4)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vật liệu nổ', N'Người quản lý', 14, 5)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vật liệu nổ', N'Chỉ huy nổ mìn', 15, 6)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vật liệu nổ', N'Người phục vụ', 16, 7)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vật liệu nổ', N'Người vận chuyển', 17, 8)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vật liệu nổ', N'Quản lý kho VLNCN', 18, 9)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vật liệu nổ', N'Thợ mìn hạng B', 19, 10)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vật liệu nổ', N'Thợ mìn hạng C', 20, 12)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Tời', N'Phụ trách toa xe', 13, 13)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Tời', N'VH tời chở người', 12, 14)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Tời', N'VH tời trục mỏ', 10, 15)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Thiết bị áp lực', N'VH hàn hơi', 6, 16)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Thiết bị áp lực', N'VH máy nén khí', 7, 17)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Thiết bị áp lực', N'VH nồi hơi', 8, 18)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Thiết bị áp lực', N'VH thiết bị áp lực', 9, 19)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Thiết bị nâng', N'Vh Monoray', 11, 21)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Thiết bị nâng', N'VH thiết bị nâng hạ', 23, 22)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Thiết bị nâng', N'VH xe nâng hàng', 24, 23)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Giảng viên HL ATLĐ', N'GVHLATLĐ', 5, 24)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'Vì neo', N'Vì neo', 21, 25)
GO
INSERT [dbo].[NhiemVu] ([Loai], [TenNhiemVu], [MaChungChi], [MaNhiemVu]) VALUES (N'VH tàu điện', N'VH tàu điện', 22, 26)
GO
SET IDENTITY_INSERT [dbo].[NhiemVu] OFF
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'BNHL', N'Bơm nước hầm lò', N'Hầm lò')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'BNLT', N'Bơm nước lộ thiên', N'Lộ thiên')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'BT', N'Băng tải', N'Hầm lò')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'DD', N'Hệ thống dây đẫn', N'Cung cấp điện, truyền dẫn')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'MC', N'Máng cào', N'Hầm lò')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'MCC', N'Máy cắt, tủ cắt', N'Cung cấp điện, truyền dẫn')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'MX', N'Máy xúc', N'Lộ thiên')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'MXD', N'Máy xúc đá', N'Hầm lò')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'OTOHD', N'Ô tô vận tải Hyundai HD270', N'Lộ thiên')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'OTOKZ', N'Ô tô vận tải Kraz 65055', N'Lộ thiên')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'ST15', N'Hệ thống sàng tuyển 1,5 triệu tấn/năm', N'Sàng tuyển')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'ST25', N'Hệ thống sàng tuyển 2,5 triệu tấn/năm', N'Sàng tuyển')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'TBA', N'Trạm biến áp', N'Cung cấp điện, truyền dẫn')
GO
INSERT [dbo].[Equipment_category] ([Equipment_category_id], [Equipment_category_name], [divce_type]) VALUES (N'TTR', N'Tời trục', N'Hầm lò')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (1, N'Chờ điều động')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (2, N'Đang hoạt động')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (3, N'Đang sửa chữa')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (4, N'Hỏng')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (5, N'Đang bảo dưỡng')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (6, N'Đang điều động')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (7, N'Đang thu hồi')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (8, N'Đang thanh lý')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (9, N'Đang trung đại tu')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (10, N'Đang kiểm định')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (11, N'Đang chờ nghiệm thu')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (12, N'Đang hạn bảo đưỡng')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (13, N'Mới mua')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (14, N'Cấp mới')
GO
INSERT [dbo].[Status] ([statusid], [statusname]) VALUES (15, N'Đã thanh lý')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14L-5676', N'Ô tô Hyundai HD270', N'Huyndai', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOHD', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14L-5684', N'Ô tô Hyundai HD270', N'Huyndai', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOHD', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14M-5655', N'Ô tô Kamaz 6520', N'Kamaz', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOKZ', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14M-7618', N'Ô tô Kamaz 6520', N'Kamaz', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOKZ', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14M-7626', N'Ô tô Kamaz 6520', N'Kamaz', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOKZ', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14M-7905', N'Ô tô Kamaz 6520', N'Kamaz', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOKZ', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14M-7906', N'Ô tô Kamaz 6520', N'Kamaz', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOKZ', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'14M-7907', N'Ô tô Kamaz 6520', N'Kamaz', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'OTOKZ', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BNLT001', N'Máy bơm nước LT 500-70  (P=135 kW) số 1', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BNLT', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BNLT002', N'Máy bơm nước LT 500-70  (P=135 kW) số 2', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BNLT', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BNLT003', N'Máy bơm nước LT 360-52,5x2  (P=200 kW) số 3', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BNLT', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BT001', N'Băng tải B650  số 1', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BT', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BT002', N'Băng tải B1000 số 2', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BT', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BT003', N'Băng tải B800 số 1', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BT', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BT004', N'Băng tải B800 số 2', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BT', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'BT005', N'Băng tải B650 số 3', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'BT', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MC001', N'Bộ máng cào SGB 420/22', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'MC', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MC002', N'Máng cào than mã hiệu MC 420/22', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'MC', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MC003', N'Máng cào SGZ630/220', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'MC', N'PXKT1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX001', N'Kobelco SK230LC-6', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX002', N'Kobelco SK330LC-6', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX003', N'Hitachi ZX670LCH-3', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX004', N'Kawasaky 85 ZIV', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX005', N'Kawasaky 80 ZIV', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX006', N'Kawasaky 90 ZIV Số 1', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX007', N'Kawasaky 90 ZIV Số 2', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'MX008', N'Hyundai HL770-9S', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 16, N'SK230LC-6', N'A', N'Đường kế toán', N'MX', N'PXLT')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'ST001', N'Băng tải cấp liệu (số 1)', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'ST15', N'PXDL2')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'ST002', N'Băng tải cấp liệu (số 2)', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'ST15', N'PXDL2')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'ST003', N'Băng tải nhặt tay (số 1)', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'ST15', N'PXDL2')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'TBA001', N'Trạm biến áp 35/6kV-2x7500kVA +1x5000kVA', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'TBA', N'PXDL1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'TBA002', N'TBA số1:160kva- 6/0,4kv.(khu VP mỏ Ngã hai)', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'TBA', N'PXDL1')
GO
INSERT [dbo].[Equipment] ([equipmentId], [equipment_name], [supplier], [date_import], [depreciation_estimate], [depreciation_present], [durationOfInspection], [durationOfInsurance], [usedDay], [durationOfMaintainance], [total_operating_hours], [current_Status], [fabrication_number], [mark_code], [quality_type], [input_channel], [Equipment_category_id], [department_id]) VALUES (N'TBA003', N'TBA số2 160kVA - 6/0,4kv (MB +27) ', N'TCMOTOR', CAST(0x74320B00 AS Date), 20, 1.5, CAST(0xCB340B00 AS Date), CAST(0x803A0B00 AS Date), CAST(0x7D330B00 AS Date), CAST(0xB2350B00 AS Date), 365, 2, 20, N'HD270', N'A', N'Đường kế toán', N'TBA', N'PXDL1')
GO
SET IDENTITY_INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ON 

GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [Ca], [MaPhongBan], [NgayDiemDanh], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI]) VALUES (1, 1, N'PXKT1', CAST(0x1F400B00 AS Date), 0, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [Ca], [MaPhongBan], [NgayDiemDanh], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI]) VALUES (2, 1, N'PXKT1', CAST(0x20400B00 AS Date), 0, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [Ca], [MaPhongBan], [NgayDiemDanh], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI]) VALUES (3, 1, N'PXKT1', CAST(0x21400B00 AS Date), 0, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [Ca], [MaPhongBan], [NgayDiemDanh], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI]) VALUES (4, 1, N'PXKT1', CAST(0x22400B00 AS Date), 0, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [Ca], [MaPhongBan], [NgayDiemDanh], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI]) VALUES (5, 1, N'PXKT1', CAST(0x23400B00 AS Date), 0, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [Ca], [MaPhongBan], [NgayDiemDanh], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI]) VALUES (6, 1, N'PXKT1', CAST(0x24400B00 AS Date), 0, 0, 0, 0, NULL, 0)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [Ca], [MaPhongBan], [NgayDiemDanh], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI]) VALUES (7, 1, N'PXKT1', CAST(0x25400B00 AS Date), 0, 0, 0, 0, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] OFF
GO
SET IDENTITY_INSERT [dbo].[Incident] ON 

GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (1, CAST(0x0000A883014F1540 AS DateTime), CAST(0x0000A8BE00B28720 AS DateTime), N'Lò DV-110V7.3', N'Đứt xích', N'MX001', N'PXLT')
GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (2, CAST(0x0000A88300CDFE60 AS DateTime), CAST(0x0000A88500CB3F40 AS DateTime), N'Lò DV-110V7.3', N'Đứt xích', N'MX001', N'PXKT1')
GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (3, CAST(0x0000A89F00EEF3E0 AS DateTime), CAST(0x0000A89F0130DEE0 AS DateTime), N'Lò DV-110V7.3', N'Đứt xích', N'MX002', N'PXKT2')
GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (4, CAST(0x0000A89F00CB3F40 AS DateTime), CAST(0x0000A8BE00CB3F40 AS DateTime), N'Lò DV-110V7.3', N'Đứt xích', N'MX003', N'PXDL1')
GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (5, CAST(0x0000A8BE00EC34C0 AS DateTime), CAST(0x0000A8C1002932E0 AS DateTime), N'Lò DV-110V7.3', N'Đứt xích', N'MX004', N'PXDL2')
GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (6, CAST(0x0000A8BE00895440 AS DateTime), CAST(0x0000A8C00078D980 AS DateTime), N'Lò DV-110V7.3', N'Đứt xích', N'MX005', N'PXDL1')
GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (7, CAST(0x0000A8BE009C8E20 AS DateTime), CAST(0x0000A8BE00CB3F40 AS DateTime), N'Lò DV-110V7.3', N'Đứt xích', N'MX006', N'PXLT')
GO
INSERT [dbo].[Incident] ([incident_id], [start_time], [end_time], [detail_location], [reason], [equipmentId], [department_id]) VALUES (8, CAST(0x0000A8DC00A0ACD0 AS DateTime), NULL, N'Lò DV-110V7.3', NULL, N'MX001', N'PXKT3')
GO
SET IDENTITY_INSERT [dbo].[Incident] OFF
GO
SET IDENTITY_INSERT [dbo].[Maintain_Car] ON 

GO
INSERT [dbo].[Maintain_Car] ([maintainid], [equipmentid], [date], [departmentid], [maintain_content]) VALUES (1, N'14M-7905', CAST(0x893F0B00 AS Date), N'PXLT', N'Thay dầu')
GO
INSERT [dbo].[Maintain_Car] ([maintainid], [equipmentid], [date], [departmentid], [maintain_content]) VALUES (2, N'14M-7905', CAST(0x8A3F0B00 AS Date), N'PXLT', N'Thay dầu')
GO
INSERT [dbo].[Maintain_Car] ([maintainid], [equipmentid], [date], [departmentid], [maintain_content]) VALUES (3, N'14M-7905', CAST(0x8B3F0B00 AS Date), N'PXLT', N'Thay dầu')
GO
INSERT [dbo].[Maintain_Car] ([maintainid], [equipmentid], [date], [departmentid], [maintain_content]) VALUES (4, N'14M-7905', CAST(0x8C3F0B00 AS Date), N'PXLT', N'Thay dầu')
GO
SET IDENTITY_INSERT [dbo].[Maintain_Car] OFF
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'BL', N'Bu lông M20x200', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'BRZ39', N'Bánh răng Z39', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'CSGC', N'Cao su giảm chấn bánh xe', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'DAU', N'Dầu diezen', N'L', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'DIEN', N'Điện', N'kWh', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'KD', N'Khóa dịch KJ31,5', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'KNM16', N'Khớp nối móc KJ16', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'KNM19', N'Khớp nối móc KJ19', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'LHD', N'Lọc hồi dịch KJ19', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'P110', N'Phớt 110x125', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'P135', N'Phớt 110x135', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'P190', N'Phớt 190x230', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'P220', N'Phớt 220x260x10', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'T1.5', N'Thép tấm 1,5mm', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'T10', N'Thép tấm 10mm', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'T12', N'Thép tấm 12mm', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'T15', N'Thép tấm 15mm', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'T5', N'Thép tấm 5mm', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'T6', N'Thép tấm 6mm', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'VTG', N'Van tay gạt KJ16', N'Cái', NULL)
GO
INSERT [dbo].[Supply] ([supply_id], [supply_name], [unit], [price]) VALUES (N'XANG', N'Xăng A95', N'L', NULL)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'P110', N'PXKT2', CAST(0x623F0B00 AS Date), 14, 12, 5)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'P190', N'PXKT3', CAST(0x623F0B00 AS Date), 12, 5, 4)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'P220', N'PXLT', CAST(0x623F0B00 AS Date), 13, 11, 5)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'T10', N'PXKT2', CAST(0x623F0B00 AS Date), 10, 9, 3)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'T12', N'PXKT4', CAST(0x623F0B00 AS Date), 14, 7, 2)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'T15', N'PXKT5', CAST(0x623F0B00 AS Date), 10, 6, 3)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'T5', N'PXKT1', CAST(0x623F0B00 AS Date), 15, 10, 5)
GO
INSERT [dbo].[Supply_tieuhao] ([supplyid], [departmentid], [date], [quantity], [used], [thuhoi]) VALUES (N'T6', N'PXKT3', CAST(0x623F0B00 AS Date), 10, 8, 4)
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (1, CAST(0x03400B00 AS Date), N'BT002', N'Đào đá', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (2, CAST(0x02400B00 AS Date), N'BT002', N'Đào than', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (3, CAST(0x01400B00 AS Date), N'BT002', N'Chở đá', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (4, CAST(0x00400B00 AS Date), N'BT002', N'Chở than', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (5, CAST(0xFF3F0B00 AS Date), N'BT002', N'Xúc đá', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (6, CAST(0xFE3F0B00 AS Date), N'BT002', N'Đào than', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (7, CAST(0xFD3F0B00 AS Date), N'BT002', N'Chở than', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (8, CAST(0xFC3F0B00 AS Date), N'BT002', N'Chở than', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (9, CAST(0xFB3F0B00 AS Date), N'BT002', N'Chở đá', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (10, CAST(0xFA3F0B00 AS Date), N'BT002', N'Chở than', 10, 150)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (11, CAST(0x03400B00 AS Date), N'14M-7905', N'Xúc đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (12, CAST(0x02400B00 AS Date), N'14M-7905', N'Chở than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (13, CAST(0x01400B00 AS Date), N'14M-7905', N'Chở đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (14, CAST(0x00400B00 AS Date), N'14M-7905', N'Xúc than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (15, CAST(0xFF3F0B00 AS Date), N'14M-7905', N'Xúc than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (16, CAST(0xFE3F0B00 AS Date), N'14M-7905', N'Xúc than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (17, CAST(0xFD3F0B00 AS Date), N'14M-7905', N'Chở đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (18, CAST(0xFC3F0B00 AS Date), N'14M-7905', N'Xúc đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (19, CAST(0xFB3F0B00 AS Date), N'14M-7905', N'Chở than', 10, 30)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (20, CAST(0xFA3F0B00 AS Date), N'14M-7905', N'Xúc đá', 10, 20)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (21, CAST(0xDB3F0B00 AS Date), N'14M-7905', N'Chở than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (22, CAST(0xBD3F0B00 AS Date), N'14M-7905', N'Xúc đá', 10, 40)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (23, CAST(0x9E3F0B00 AS Date), N'14M-7905', N'Chở đá', 10, 30)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (24, CAST(0x03400B00 AS Date), N'MX008', N'Xúc đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (25, CAST(0x02400B00 AS Date), N'MX008', N'Chở than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (26, CAST(0x01400B00 AS Date), N'MX008', N'Chở đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (27, CAST(0x00400B00 AS Date), N'MX008', N'Xúc đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (28, CAST(0xFF3F0B00 AS Date), N'MX008', N'Chở than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (29, CAST(0xFE3F0B00 AS Date), N'MX008', N'Xúc đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (30, CAST(0xFD3F0B00 AS Date), N'MX008', N'Xúc đá', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (31, CAST(0xFC3F0B00 AS Date), N'MX008', N'Chở than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (32, CAST(0xFB3F0B00 AS Date), N'MX008', N'Xúc than', 10, 50)
GO
INSERT [dbo].[Activity] ([activityid], [date], [equipmentid], [activityname], [hours_per_day], [quantity]) VALUES (33, CAST(0xFA3F0B00 AS Date), N'MX008', N'Chở đá', 10, 50)
GO
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'AT001', N'Kích cỡ gầu', N'mm', N'MX')
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'AT002', N'Khổ đường ray', N'mm', N'MX')
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'AT003', N'Lực kéo', N'lb', N'MX')
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'AT004', N'tốc độ xoay', N'rpm', N'MX')
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'OTO001', N'Số khung', N'mm', N'OTOHD')
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'OTO002', N'Số máy', N'mm', N'OTOHD')
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'OTO003', N'Số khung', N'mm', N'OTOKZ')
GO
INSERT [dbo].[Equipment_category_attribute] ([Equipment_category_attribute_id], [Equipment_category_attribute_name], [unit], [Equipment_category_id]) VALUES (N'OTO004', N'Số máy', N'mm', N'OTOKZ')
GO
INSERT [dbo].[Category_attribute_value] ([Value], [equipmentId], [Equipment_category_id], [Equipment_category_attribute_id]) VALUES (1000, N'MX001', N'MX', N'AT001')
GO
INSERT [dbo].[Category_attribute_value] ([Value], [equipmentId], [Equipment_category_id], [Equipment_category_attribute_id]) VALUES (1000, N'MX001', N'MX', N'AT002')
GO
INSERT [dbo].[Category_attribute_value] ([Value], [equipmentId], [Equipment_category_id], [Equipment_category_attribute_id]) VALUES (1000, N'MX001', N'MX', N'AT003')
GO
INSERT [dbo].[Category_attribute_value] ([Value], [equipmentId], [Equipment_category_id], [Equipment_category_attribute_id]) VALUES (1000, N'MX001', N'MX', N'AT004')
GO
INSERT [dbo].[Equipment_attribute] ([Equipment_attribute_id], [Equipment_attribute_name], [value], [unit], [equipmentId]) VALUES (N'SK001', N'Dung tích:', 123456789, N'Cái', N'14L-5684')
GO
INSERT [dbo].[Equipment_attribute] ([Equipment_attribute_id], [Equipment_attribute_name], [value], [unit], [equipmentId]) VALUES (N'SK002', N'Yeah yeah', 123456789, N'l', N'14M-7626')
GO
INSERT [dbo].[Equipment_attribute] ([Equipment_attribute_id], [Equipment_attribute_name], [value], [unit], [equipmentId]) VALUES (N'SK003', N'GG', 123456789, N'a', N'14L-5676')
GO
INSERT [dbo].[Equipment_attribute] ([Equipment_attribute_id], [Equipment_attribute_name], [value], [unit], [equipmentId]) VALUES (N'SM001', N'S? bánh', 123456789, N'B?', N'14L-5684')
GO
INSERT [dbo].[Equipment_attribute] ([Equipment_attribute_id], [Equipment_attribute_name], [value], [unit], [equipmentId]) VALUES (N'SM002', N'Oh yeah', 123456789, N'm', N'14M-7626')
GO
INSERT [dbo].[Equipment_attribute] ([Equipment_attribute_id], [Equipment_attribute_name], [value], [unit], [equipmentId]) VALUES (N'SM003', N'Congrate', 123456789, N'b', N'14L-5676')
GO
SET IDENTITY_INSERT [dbo].[Equipment_Inspection] ON 

GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (1, N'14L-5676', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (2, N'14L-5684', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (3, N'14M-5655', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (4, N'14M-7618', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (5, N'14M-7626', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (6, N'14M-7905', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (7, N'14M-7906', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (8, N'14M-7907', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (9, N'BNLT001', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (10, N'BNLT002', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (11, N'BNLT003', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (12, N'BT001', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (13, N'BT002', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (14, N'BT003', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (15, N'BT004', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (16, N'BT005', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (17, N'MC001', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (18, N'MC002', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (19, N'MC003', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (20, N'MX001', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (21, N'MX002', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (22, N'MX003', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (23, N'MX004', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (24, N'MX005', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (25, N'MX006', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (26, N'MX007', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (27, N'MX008', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (28, N'ST001', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (29, N'ST002', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (30, N'ST003', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (31, N'TBA001', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (32, N'TBA002', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Equipment_Inspection] ([inspect_id], [equipmentId], [inspect_expected_date], [inspect_start_date], [inspect_end_date]) VALUES (33, N'TBA003', CAST(0x00009F7000000000 AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Equipment_Inspection] OFF
GO
SET IDENTITY_INSERT [dbo].[Fuel_activities_consumption] ON 

GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (1, 1350, CAST(0xEF3E0B00 AS Date), N'14L-5676', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (2, 400, CAST(0xEF3E0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (3, 1350, CAST(0xF03E0B00 AS Date), N'14L-5676', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (4, 400, CAST(0xF03E0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (5, 1350, CAST(0xF13E0B00 AS Date), N'14L-5676', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (6, 400, CAST(0xF13E0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (7, 1460, CAST(0xBD3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (8, 10, CAST(0xDB3F0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (9, 1460, CAST(0xDB3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (10, 10, CAST(0xFA3F0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (11, 1460, CAST(0xFA3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (12, 10, CAST(0xFB3F0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (13, 1250, CAST(0xFB3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (14, 10, CAST(0xFC3F0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (15, 1250, CAST(0xFC3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (16, 10, CAST(0xFD3F0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (17, 1250, CAST(0xFD3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (18, 10, CAST(0xFE3F0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (19, 1250, CAST(0xFE3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (20, 10, CAST(0xFF3F0B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (21, 1250, CAST(0xFF3F0B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (22, 10, CAST(0x00400B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (23, 1250, CAST(0x00400B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (24, 10, CAST(0x01400B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (25, 1250, CAST(0x01400B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (26, 10, CAST(0x02400B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (27, 1250, CAST(0x02400B00 AS Date), N'BT002', N'DIEN')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (28, 10, CAST(0x03400B00 AS Date), N'14L-5676', N'XANG')
GO
INSERT [dbo].[Fuel_activities_consumption] ([fuelid], [consumption_value], [date], [equipmentId], [fuel_type]) VALUES (29, 1250, CAST(0x03400B00 AS Date), N'BT002', N'DIEN')
GO
SET IDENTITY_INSERT [dbo].[Fuel_activities_consumption] OFF
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8056', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8056', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8056', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8056', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8056', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8056', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8056', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8058', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8058', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8058', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8058', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8058', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8058', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8058', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8059', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8059', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8059', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8059', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8059', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8059', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8059', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8060', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8060', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8060', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8060', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8060', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8060', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8060', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8061', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8061', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8061', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8061', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8061', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8061', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8061', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8063', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8063', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8063', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8063', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8063', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8063', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8063', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8064', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8064', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8064', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8064', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8064', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8064', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8064', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8066', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8066', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8066', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8066', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8066', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8066', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8066', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8067', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8067', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8067', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8067', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8067', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8067', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8067', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8069', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8069', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8069', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8069', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8069', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8069', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8069', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8070', 1, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8070', 2, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8070', 3, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8070', 4, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8070', 5, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8070', 6, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [HeSoChiaLuong], [DiemLuong], [DuBaoNguyCo], [DiLam], [GhiChu], [LyDoVangMat], [GiaiPhapNguyCo]) VALUES (N'8070', 7, CAST(0x0000AAC400000000 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Maintain_Car_Detail] ON 

GO
INSERT [dbo].[Maintain_Car_Detail] ([maintaindetailid], [maintainid], [supplyid], [quantity], [supplyType], [supplyStatus]) VALUES (1, 1, N'T1.5', 2, 1, 1)
GO
INSERT [dbo].[Maintain_Car_Detail] ([maintaindetailid], [maintainid], [supplyid], [quantity], [supplyType], [supplyStatus]) VALUES (2, 2, N'T10', 2, 1, 2)
GO
INSERT [dbo].[Maintain_Car_Detail] ([maintaindetailid], [maintainid], [supplyid], [quantity], [supplyType], [supplyStatus]) VALUES (3, 3, N'T10', 2, 1, 2)
GO
INSERT [dbo].[Maintain_Car_Detail] ([maintaindetailid], [maintainid], [supplyid], [quantity], [supplyType], [supplyStatus]) VALUES (4, 3, N'T12', 2, 1, 2)
GO
INSERT [dbo].[Maintain_Car_Detail] ([maintaindetailid], [maintainid], [supplyid], [quantity], [supplyType], [supplyStatus]) VALUES (5, 3, N'T15', 2, 1, 2)
GO
INSERT [dbo].[Maintain_Car_Detail] ([maintaindetailid], [maintainid], [supplyid], [quantity], [supplyType], [supplyStatus]) VALUES (6, 4, N'P220', 2, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Maintain_Car_Detail] OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (1, N'Trần Thị Thương', N'thuongtt', N'gj37F6TZpGBfr6ITnly2IQ==', N'Chuyên Viên CĐVT', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (2, N'Hoàng Bá Long', N'longhb', N'Fc+jC62BdOx2oXf4jd8exw==', N'Chuyên Viên CĐVT', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (3, N'Nguyễn Văn Trữ', N'trunv', N'trunv', N'Chuyên Viên CĐVT', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (4, N'Lại Bình Minh', N'minhlb', N'minhlb', N'Chuyên Viên CĐVT', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (5, N'Nguyễn Văn Học', N'hocnv', N'WDs0YAymf9ffpA2YL3W6OA==', N'Phó Phòng TCLĐ', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (6, N'Nguyễn Thị Hòa', N'hoant', N'hoant', N'Chuyên Viên TCLĐ', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (7, N'Nguyễn Bá Vương', N'vuongnb', N'ctlJgcp3tKeOaa6b0IW1ig==', N'Chuyên Viên TCLĐ', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (8, N'Nguyễn Thị Trà', N'trant', N'trant', N'Chuyên Viên TCLĐ', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (9, N'Nguyễn Văn Long', N'longnv', N'rfSpMzUIM+4RBjHg4d4f/w==', N'Chuyên Viên TCLĐ', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (10, N'Trần Văn Tú', N'tutv', N'tutv', N'Giám Đốc', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (11, N' Lê Minh Đức', N'duclm', N'duclm', N'Chuyên Viên KCS', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (12, N'Vũ Văn An', N'anvv', N'anvv', N'Chuyên Viên Điều Khiển', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (13, N'Nguyễn Đức Cương', N'cuongnd', N'cuongnd', N'Quản Đốc PXKT', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (14, N'ADMIN', N'admin', N'ISMvKXpXpadDiUoOSoAfww==', N'Quản lí phần mềm', NULL, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (22, N'cdvt', N'cdvt', N'4QrcOUm6Wau+VuBX8g+IPg==', N'Chuyên Viên CĐVT', NULL, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (23, N'tcld', N'tcld', N'4QrcOUm6Wau+VuBX8g+IPg==', N'Chuyên Viên TCLD', NULL, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (24, N'bgd', N'bgd', N'4QrcOUm6Wau+VuBX8g+IPg==', N'Giám Đốc', NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (25, N'dk', N'dk', N'4QrcOUm6Wau+VuBX8g+IPg==', N'Điều Khiển', NULL, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (26, N'pxkt', N'pxkt', N'4QrcOUm6Wau+VuBX8g+IPg==', N'Phân Xưởng Khai Thác', NULL, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (27, N'kcs', N'kcs', N'4QrcOUm6Wau+VuBX8g+IPg==', N'Chuyên Viên KCS', NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (28, N'pxds', N'pxds', N'4QrcOUm6Wau+VuBX8g+IPg==', N'Phân Xưởng Đời Sống', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (29, N'Nguyễn Thị Thúy', N'thuynt', N'UKj1ec3L2bPqFTQ8TCbp+w==', N'Chuyên Viên TCLĐ', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Account] ([ID], [Name], [Username], [Password], [Position], [NVID], [CDVT], [TCLD], [BGD], [DK], [KCS], [PXKT], [PXDL], [PXVT], [PXST], [PXPV], [PXDS], [PXCDM], [PXTGQLM], [PXXD], [PXLT], [AT], [KCM], [ADMIN]) VALUES (30, N'Nguyễn Văn Thành', N'thanhnv', N'xyUIXxi+3+1z/tqaMh6tQA==', N'Trưởng phòng TCLĐ', NULL, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8057', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8058', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8059', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8060', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8061', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8062', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8063', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8064', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8065', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8066', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8067', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8069', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[FakeAPI] ([MaNV], [NgayDiemDanh], [CaDiemDanh], [GioDiemDanh]) VALUES (N'8070', CAST(0x1F400B00 AS Date), 1, CAST(0x0000AAC4009C8E20 AS DateTime))
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, CAST(0x34400B00 AS Date), N'Long', N'Có', N'Bản gốc', N'Bản gốc', NULL, N'Thùy', N'Thúy', N'8056', CAST(0x34400B00 AS Date), CAST(0x39400B00 AS Date), N'Phân xưởng khải thác 1', CAST(0x39400B00 AS Date), CAST(0x39400B00 AS Date), N'Điều khiển')
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, CAST(0x37400B00 AS Date), N'Long', NULL, NULL, NULL, NULL, NULL, N'Thúy', N'8057', CAST(0x37400B00 AS Date), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8058', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8059', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8060', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8061', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8062', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8063', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8064', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8065', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8066', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8067', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8069', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HoSo] ([TrangThaiHoSo], [NgayNhanHoSo], [NguoiGiaoHoSo], [CamKetTuyenDung], [QuyetDinhTiepNhanDVC], [QDChamDutHopDongDVC], [NLDHocTheoChiTieuCTDT], [NguoiBanGiaoBangNhapKho], [NguoiGiuHoSo], [MaNV], [NgayQuyetDinhTuyenDung], [NgayDiLam], [DonViKyQuyetDinhTiepNhan], [NgayQuyetDinhChamDut], [NgayChamDut], [DonViKyQuyetDinhChamDut]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8070', NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[QuanHeGiaDinh] ON 

GO
INSERT [dbo].[QuanHeGiaDinh] ([MaQuanHeGiaDinh], [LoaiGiaDinh], [MoiQuanHe], [NgaySinh], [LyLich], [MaNV], [HoTen], [NoiThuongTru], [SoDienThoai]) VALUES (1, N'Nhà vợ', N'Bố', CAST(0x3B400B00 AS Date), N'Đi làm', N'8056', N'Nguyễn A Xử', NULL, NULL)
GO
INSERT [dbo].[QuanHeGiaDinh] ([MaQuanHeGiaDinh], [LoaiGiaDinh], [MoiQuanHe], [NgaySinh], [LyLich], [MaNV], [HoTen], [NoiThuongTru], [SoDienThoai]) VALUES (2, N'Nhà chồng', N'Mẹ', CAST(0x3B400B00 AS Date), N'Đi làm', N'8056', N'Nguyễn Thân Sinh', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[QuanHeGiaDinh] OFF
GO
SET IDENTITY_INSERT [dbo].[Account_Right] ON 

GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (1, N'1', 1, N'Thêm mới thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (2, N'1', 1, N'Cập nhật ngày kiểm định thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (3, N'1', 1, N'Xuất ra excel danh sách thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (4, N'1', 1, N'Sửa thông tin thiết bị huy động', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (5, N'1', 1, N'Xóa thông tin thiết bị huy động', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (6, N'1', 1, N'Xem màn huy động thiết bị', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (7, N'1', 29, N'Xem màn cập nhật hoạt động thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (8, N'1', 29, N'Thêm cập nhật hoạt động thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (9, N'1', 29, N'Chỉnh sửa cập nhập hoạt động thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (10, N'1', 2, N'Xem màn huy động ô tô', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (11, N'1', 2, N'Thêm mới ô tô', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (12, N'1', 2, N'Sửa thông tin ô tô', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (13, N'1', 3, N'Xem màn cập nhật hoạt động ô tô', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (14, N'1', 3, N'Thêm cập nhật hoạt động ô tô', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (15, N'1', 3, N'Chỉnh sửa cập nhật hoạt động ô tô', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (16, N'1', 4, N'Xem màn bảo dưỡng hằng ngày ô tô', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (17, N'1', 4, N'Thêm bảo dưỡng hằng ngày ô tô', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (18, N'1', 4, N'Chỉnh sửa bảo dưỡng hàng ngày ô tô', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (19, N'1', 5, N'Xem màn thông tin sự cố', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (20, N'1', 5, N'Thêm sự cố', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (21, N'1', 5, N'Chỉnh sửa/Cập nhật sự cố', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (23, N'1', 6, N'Xem danh sách quyết định chưa xử lí', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (24, N'1', 7, N'Xem danh sách kiểm định', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (25, N'1', 8, N'Xem màn danh sách thiết bị chờ nghiệm thu', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (26, N'1', 9, N'Xem màn danh sách thiết bị đã nghiệm thu', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (27, N'1', 10, N'Xem màn xin cấp vật tư sửa chữa thường xuyên', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (28, N'1', 11, N'Xem màn tổng hợp vật tư sửa chữa thường xuyên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (29, N'1', 12, N'Xem màn tiêu hao vật tư', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (30, N'1', 13, N'Danh sách quyết định sửa chữa', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (31, N'1', 14, N'Danh sách quyết định bảo dưỡng', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (33, N'1', 10, N'Thêm vật tư sửa chữa thường xuyên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (35, N'1', 11, N'Chỉnh sửa bảng chi tiết tổng hợp vật tư', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (37, N'1', 12, N'Chỉnh sửa tiêu hao vật tư', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (38, N'1', 16, N'Danh sách quyết định điều động', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (39, N'1', 17, N'Danh sách quyết định thu hồi', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (40, N'1', 18, N'Danh sách quyết định thanh lí', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (41, N'1', 19, N'Danh sách quyết định kiểm định', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (42, N'1', 20, N'Danh sách quyết định trùng đại tu', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (43, N'1', 21, N'Báo cáo sử dụng năng lượng', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (44, N'1', 22, N'Báo cáo sử dụng nhiên liệu', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (45, N'1', 23, N'Báo cáo huy động bơm thoát nước', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (46, N'1', 24, N'Báo cáo thanh lí thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (47, N'1', 25, N'Báo cáo biến động tăng giảm thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (48, N'1', 26, N'Báo cáo sữa chữa thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (49, N'1', 27, N'Báo cáo trung đại tu thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (50, N'1', 28, N'Báo cáo thu hồi thiết bị', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (51, N'2', 1, N'Xem danh sách hồ sơ nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (52, N'2', 1, N'Tuyển dụng nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (53, N'2', 1, N'Chỉnh sửa hồ sơ nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (54, N'2', 1, N'Xem lịch sử làm việc/điều chuyển nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (55, N'2', 1, N'Thanh lí hợp đồng nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (56, N'2', 1, N'Xem chi tiết hồ sơ nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (57, N'2', 8, N'Xem báo cáo thực hiện lao động, tiền lương công nhân', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (62, N'2', 3, N'Danh sách bảo hộ lao động', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (63, N'2', 4, N'Xem bảng tổng hợp toàn công ty', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (64, N'2', 5, N'Xem màn điều động nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (65, N'2', 5, N'Điều động nhân viên', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (67, N'2', 6, N'Báo cáo năng suất lao động và tiền lương', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (71, N'3', 2, N'Báo cáo chất lượng than tồn kho - tiêu thụ và sản xuất', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (72, N'3', 2, N'Sửa báo cáo chất lượng than tồn kho - tiêu thụ và sản xuất', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (73, N'3', 1, N'Nhập báo cáo chất lượng than tồn kho - tiêu thụ và sản xuất', 0)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (74, N'4', 1, N'Màn báo cáo chi tiết sản xuất than', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (75, N'4', 1, N'Chỉnh sửa báo cáo chi tiết sản xuất than', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (77, N'4', 2, N'Báo cáo nhân lực ngày/tháng', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (79, N'4', 3, N'Báo cáo sự cố', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (80, N'5', 1, N'Ban giám đốc', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (81, N'6', 1, N'Nhập báo cáo thực hiện kế hoạch sản xuất', 1)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (82, N'1', 8, N'Nghiệm thu thiết bị', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (83, N'1', 13, N'Thêm danh sách quyết định sửa chữa', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (84, N'1', 13, N'Chỉnh sửa/Cập nhật quyết định sửa chữa', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (85, N'1', 14, N'Thêm danh sách quyết định bảo dưỡng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (86, N'1', 14, N'Chỉnh sửa/Cập nhật quyết định bảo dưỡng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (87, N'1', 16, N'Thêm danh sách quyết định điều động', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (88, N'1', 16, N'Chỉnh sửa/Cập nhật quyết định điều động', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (89, N'1', 17, N'Thêm danh sách quyết định thu hồi', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (90, N'1', 17, N'Chỉnh sửa/Cập nhật quyết định thu hồi', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (91, N'1', 18, N'Thêm danh sách quyết định thanh lí', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (92, N'1', 18, N'Chỉnh sửa/Cập nhật quyết định thanh lí', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (93, N'1', 19, N'Thêm danh sách quyết định kiểm định', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (94, N'1', 19, N'Chỉnh sửa/Cập nhật quyết định kiểm định', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (95, N'1', 20, N'Thêm danh sách quyết định trung đại tu', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (96, N'1', 20, N'Chỉnh sửa/Cập nhật quyết định trung đại tu', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (102, N'2', 12, N'Xem màn đã xữ lí quyết định điều động', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (103, N'2', 13, N'Xem màn chưa xử lí quyết định điều động', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (104, N'2', 14, N'Màn tổng hợp các đơn vị chấm dứt tuyển dụng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (106, N'2', 15, N'Xem màn tổng hợp tuyển dụng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (108, N'2', 16, N'Xem màn tổng hợp chấm dứt', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (110, N'2', 17, N'Xem báo cáo tăng giảm lao động', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (111, N'2', 18, N'Xem màn biên bản chung', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (112, N'2', 19, N'Xem lịch sử thay đổi dữ liệu', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (114, N'1', 1, N'Thêm nhóm thiết bị', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (115, N'1', 2, N'Cập nhật ngày kiểm định ô tô', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (116, N'1', 6, N'Xử lí quyết định', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (117, N'1', 15, N'Màn cấp vật tư sữa chữa thường xuyên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (118, N'1', 11, N'Chỉnh sửa bảng tổng hợp vật tư', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (119, N'2', 13, N'Thêm mã quyết định điều động nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (120, N'2', 13, N'Xóa quyết định điều động nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (121, N'2', 12, N'Xóa quyết định đã xử lí', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (122, N'12', 20, N'Xem màn đăng kí suất ăn', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (123, N'12', 20, N'Đăng kí suất ăn', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (124, N'2', 21, N'Xem màn chưa quyết định chấm dứt hợp đồng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (125, N'2', 21, N'Thêm mã quyết định chấm dứt hợp đồng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (126, N'2', 21, N'Xóa quyết định chờ chấm dứt hợp đồng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (127, N'2', 22, N'Xem màn đã chấm dứt hợp đồng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (128, N'2', 22, N'Xóa quyết định đã chấm dứt hợp đồng', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (129, N'2', 23, N'Xem màn quản lí hồ sơ trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (130, N'2', 23, N'Xem chi tiết hồ sơ nhân viên trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (131, N'2', 23, N'Sửa chi tiết hồ sơ nhân viên trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (132, N'2', 24, N'Xem quản lí hồ sơ ngoài công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (133, N'2', 24, N'Xem chi tiết hồ sơ ngoài công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (134, N'2', 24, N'Sửa chi tiết hồ sơ ngoài công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (135, N'2', 25, N'Xem màn chuẩn hóa tên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (136, N'2', 25, N'Thêm chuẩn hóa tên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (137, N'2', 25, N'Chỉnh sửa chuẩn hóa tên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (138, N'2', 26, N'Xem màn đăng kí nhiệm vụ', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (139, N'2', 26, N'Xác nhận đăng kí nhiệm vụ', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (140, N'2', 26, N'Xem chứng chỉ của 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (141, N'2', 27, N'Xem màn báo cáo tình trạng chứng chỉ', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (142, N'2', 27, N'Gia hạn chứng chỉ', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (143, N'2', 27, N'Đăng kí chứng chỉ', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (144, N'3', 1, N'Lưu báo cáo', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (146, N'2', 23, N'Xem danh sách giấy tờ của nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (147, N'2', 23, N'Sửa giấy tờ của nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (148, N'2', 23, N'Xóa giấy tờ của nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (149, N'2', 26, N'Xem danh sách chứng chỉ của cả công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (150, N'2', 26, N'Thêm chứng chỉ mới của công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (151, N'2', 26, N'Sửa chứng chỉ mới của công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (152, N'2', 26, N'Xóa chứng chỉ của công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (153, N'2', 26, N'Xem danh sách chứng chỉ của nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (154, N'2', 26, N'Thêm chứng chỉ cho 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (155, N'2', 26, N'Sửa chứng chỉ của 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (156, N'2', 26, N'Xóa chứng chỉ của nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (157, N'2', 23, N'Thêm giấy tờ cho 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (158, N'4', 4, N'Nhập tai nạn lao động', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (159, N'2', 23, N'Xem danh sách bằng cấp, giấy chứng nhận có trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (160, N'2', 23, N'Thêm bằng cấp, giấy chứng nhận cho công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (161, N'2', 23, N'Sửa bằng cấp, giấy chứng nhận trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (162, N'2', 23, N'Xóa bằng cấp, giấy chứng nhận có trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (163, N'2', 23, N'Xem danh sách bằng cấp, giấy chứng nhận cho 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (164, N'2', 23, N'Thêm bằng cấp, giấy chứng nhận cho 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (165, N'2', 23, N'Sửa bằng cấp, giấy chứng nhận cho 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (166, N'2', 23, N'Xóa bằng cấp, giấy chứng nhận của 1 nhân viên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (167, N'2', 25, N'Xóa chuẩn hóa tên', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (168, N'2', 23, N'Thêm đợt bổ sung sơ yếu lí lịch của hồ sơ trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (169, N'2', 23, N'Sửa đợt bổ sung sơ yếu lí lịch của hồ sơ trong công ty', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (170, N'1', 5, N'Xuất excel màn sự cố', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (171, N'1', 7, N'Cập nhật kiểm định', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (172, N'1', 69, N'Xem loại vật tư', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (173, N'1', 69, N'Thêm vật tư', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (174, N'1', 69, N'Xóa vật tư', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (175, N'2', 30, N'Xem danh sách phòng ban', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (176, N'2', 30, N'Thêm phòng ban', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (177, N'2', 30, N'Sửa phòng ban', NULL)
GO
INSERT [dbo].[Account_Right] ([ID], [ModuleID], [GroupID], [Right], [isBasic]) VALUES (178, N'2', 30, N'Xóa phòng ban', NULL)
GO
SET IDENTITY_INSERT [dbo].[Account_Right] OFF
GO
SET IDENTITY_INSERT [dbo].[Account_Right_Detail] ON 

GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3028, 1, 1)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3029, 1, 6)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3513, 5, 57)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3514, 5, 67)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3499, 7, 138)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3500, 7, 139)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3501, 7, 140)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3502, 7, 141)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3503, 7, 142)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3504, 7, 143)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3505, 7, 149)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3506, 7, 150)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3507, 7, 151)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3508, 7, 152)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3509, 7, 153)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3510, 7, 154)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3511, 7, 155)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3512, 7, 156)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3340, 9, 51)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3341, 9, 52)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3342, 9, 53)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3343, 9, 54)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3344, 9, 55)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3345, 9, 56)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3346, 9, 64)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3347, 9, 65)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3348, 9, 102)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3349, 9, 103)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3350, 9, 104)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3351, 9, 106)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3352, 9, 108)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3353, 9, 119)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3354, 9, 120)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3355, 9, 121)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3356, 9, 124)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3357, 9, 125)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3358, 9, 126)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3359, 9, 127)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3360, 9, 128)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2387, 14, 1)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2388, 14, 2)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2389, 14, 3)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2390, 14, 4)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2391, 14, 5)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2392, 14, 6)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2393, 14, 7)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2394, 14, 8)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2395, 14, 9)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2396, 14, 10)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2397, 14, 11)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2398, 14, 12)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2399, 14, 13)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2400, 14, 14)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2401, 14, 15)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2402, 14, 16)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2403, 14, 17)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2404, 14, 18)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2405, 14, 19)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2406, 14, 20)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2407, 14, 21)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2408, 14, 22)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2409, 14, 23)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2410, 14, 24)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2411, 14, 25)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2412, 14, 26)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2413, 14, 27)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2414, 14, 28)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2415, 14, 29)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2416, 14, 30)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2417, 14, 31)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2418, 14, 32)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2419, 14, 33)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2420, 14, 34)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2421, 14, 35)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2422, 14, 36)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2423, 14, 37)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2424, 14, 38)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2425, 14, 39)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2426, 14, 40)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2427, 14, 41)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2428, 14, 42)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2429, 14, 43)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2430, 14, 44)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2431, 14, 45)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2432, 14, 46)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2433, 14, 47)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2434, 14, 48)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2435, 14, 49)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2436, 14, 50)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2437, 14, 51)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2438, 14, 52)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2439, 14, 53)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2440, 14, 54)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2441, 14, 55)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2442, 14, 56)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2443, 14, 57)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2444, 14, 58)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2445, 14, 59)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2446, 14, 60)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2447, 14, 61)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2448, 14, 62)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2449, 14, 63)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2450, 14, 64)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2451, 14, 65)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2452, 14, 66)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2453, 14, 67)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2454, 14, 68)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2455, 14, 69)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2456, 14, 70)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2457, 14, 71)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2458, 14, 72)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2459, 14, 73)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2460, 14, 74)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2461, 14, 75)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2462, 14, 76)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2463, 14, 77)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2464, 14, 78)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2465, 14, 79)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2466, 14, 80)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (2467, 14, 81)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3030, 22, 1)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3031, 22, 2)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3032, 22, 3)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3033, 22, 4)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3034, 22, 5)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3035, 22, 6)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3036, 22, 7)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3037, 22, 8)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3038, 22, 9)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3039, 22, 10)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3040, 22, 11)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3041, 22, 12)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3042, 22, 13)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3043, 22, 14)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3044, 22, 15)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3045, 22, 16)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3046, 22, 17)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3047, 22, 18)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3048, 22, 19)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3049, 22, 20)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3050, 22, 21)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3051, 22, 23)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3052, 22, 24)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3053, 22, 25)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3054, 22, 26)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3055, 22, 27)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3056, 22, 28)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3057, 22, 29)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3058, 22, 30)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3059, 22, 31)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3060, 22, 33)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3061, 22, 35)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3062, 22, 37)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3063, 22, 38)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3064, 22, 39)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3065, 22, 40)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3066, 22, 41)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3067, 22, 42)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3068, 22, 43)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3069, 22, 44)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3070, 22, 45)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3071, 22, 46)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3072, 22, 47)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3073, 22, 48)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3074, 22, 49)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3075, 22, 50)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3076, 22, 82)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3077, 22, 83)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3078, 22, 84)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3079, 22, 85)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3080, 22, 86)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3081, 22, 87)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3082, 22, 88)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3083, 22, 89)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3084, 22, 90)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3085, 22, 91)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3086, 22, 92)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3087, 22, 93)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3088, 22, 94)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3089, 22, 95)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3090, 22, 96)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3091, 22, 114)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3092, 22, 115)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3093, 22, 116)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3094, 22, 117)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3095, 22, 118)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3390, 23, 51)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3391, 23, 52)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3392, 23, 53)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3393, 23, 54)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3394, 23, 55)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3395, 23, 56)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3396, 23, 57)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3397, 23, 58)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3398, 23, 59)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3399, 23, 60)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3400, 23, 61)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3401, 23, 62)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3402, 23, 63)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3403, 23, 64)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3404, 23, 65)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3405, 23, 67)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3406, 23, 102)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3407, 23, 103)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3408, 23, 104)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3409, 23, 106)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3410, 23, 108)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3411, 23, 110)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3412, 23, 111)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3413, 23, 112)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3414, 23, 119)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3415, 23, 120)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3416, 23, 121)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3417, 23, 122)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3418, 23, 123)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3419, 23, 124)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3420, 23, 125)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3421, 23, 126)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3422, 23, 127)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3423, 23, 128)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3424, 23, 129)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3425, 23, 130)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3426, 23, 131)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3427, 23, 132)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3428, 23, 133)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3429, 23, 134)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3430, 23, 135)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3431, 23, 136)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3432, 23, 137)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3433, 23, 138)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3434, 23, 139)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3435, 23, 140)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3436, 23, 141)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3437, 23, 142)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3438, 23, 143)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3439, 23, 146)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3440, 23, 147)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3441, 23, 148)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3442, 23, 149)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3443, 23, 150)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3444, 23, 151)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3445, 23, 152)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3446, 23, 153)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3447, 23, 154)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3448, 23, 155)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3449, 23, 156)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3450, 23, 157)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3451, 23, 159)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3452, 23, 160)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3453, 23, 161)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3454, 23, 162)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3455, 23, 163)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3456, 23, 164)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3457, 23, 165)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3458, 23, 166)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3459, 23, 167)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3460, 23, 168)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3461, 23, 169)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3462, 23, 175)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3463, 23, 176)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3464, 23, 177)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3465, 23, 178)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3152, 24, 80)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3587, 25, 74)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3588, 25, 75)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3589, 25, 77)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3590, 25, 79)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3591, 25, 158)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3157, 26, 81)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3158, 27, 71)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3159, 27, 72)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3160, 27, 73)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3161, 27, 144)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3592, 28, 122)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3593, 28, 123)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3468, 29, 51)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3469, 29, 53)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3470, 29, 54)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3471, 29, 56)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3472, 29, 129)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3473, 29, 130)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3474, 29, 131)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3475, 29, 132)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3476, 29, 133)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3477, 29, 134)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3478, 29, 135)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3479, 29, 136)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3480, 29, 137)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3481, 29, 140)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3482, 29, 141)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3483, 29, 146)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3484, 29, 147)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3485, 29, 148)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3486, 29, 149)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3487, 29, 153)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3488, 29, 157)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3489, 29, 159)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3490, 29, 160)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3491, 29, 161)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3492, 29, 162)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3493, 29, 163)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3494, 29, 164)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3495, 29, 165)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3496, 29, 166)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3497, 29, 168)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3498, 29, 169)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3515, 30, 51)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3516, 30, 52)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3517, 30, 53)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3518, 30, 54)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3519, 30, 55)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3520, 30, 56)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3521, 30, 57)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3522, 30, 62)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3523, 30, 63)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3524, 30, 64)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3525, 30, 65)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3526, 30, 67)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3527, 30, 102)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3528, 30, 103)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3529, 30, 104)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3530, 30, 106)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3531, 30, 108)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3532, 30, 110)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3533, 30, 111)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3534, 30, 112)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3535, 30, 119)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3536, 30, 120)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3537, 30, 121)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3538, 30, 122)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3539, 30, 123)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3540, 30, 124)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3541, 30, 125)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3542, 30, 126)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3543, 30, 127)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3544, 30, 128)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3545, 30, 129)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3546, 30, 130)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3547, 30, 131)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3548, 30, 132)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3549, 30, 133)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3550, 30, 134)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3551, 30, 135)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3552, 30, 136)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3553, 30, 137)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3554, 30, 138)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3555, 30, 139)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3556, 30, 140)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3557, 30, 141)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3558, 30, 142)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3559, 30, 143)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3560, 30, 146)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3561, 30, 147)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3562, 30, 148)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3563, 30, 149)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3564, 30, 150)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3565, 30, 151)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3566, 30, 152)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3567, 30, 153)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3568, 30, 154)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3569, 30, 155)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3570, 30, 156)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3571, 30, 157)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3572, 30, 159)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3573, 30, 160)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3574, 30, 161)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3575, 30, 162)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3576, 30, 163)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3577, 30, 164)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3578, 30, 165)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3579, 30, 166)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3580, 30, 167)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3581, 30, 168)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3582, 30, 169)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3583, 30, 175)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3584, 30, 176)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3585, 30, 177)
GO
INSERT [dbo].[Account_Right_Detail] ([ID], [AccountID], [RightID]) VALUES (3586, 30, 178)
GO
SET IDENTITY_INSERT [dbo].[Account_Right_Detail] OFF
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'7', N'ADMIN')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'17', N'AT')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'5', N'BGD')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'1', N'CDVT')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'4', N'DK')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'18', N'KCM')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'3', N'KCS')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'13', N'PXCDM')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'8', N'PXDL')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'12', N'PXDS')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'6', N'PXKT')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'16', N'PXLT')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'11', N'PXPV')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'10', N'PXST')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'14', N'PXTGQLM')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'9', N'PXVT')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'15', N'PXXD')
GO
INSERT [dbo].[Module] ([ID], [Module]) VALUES (N'2', N'TCLD')
GO
