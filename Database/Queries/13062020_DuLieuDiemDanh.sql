USE [QUANGHANHABC]
GO
SET IDENTITY_INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ON 
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [NgayDiemDanh], [Ca], [isCreatedManually], [Status], [Message], [FetchDataTime], [VERSION]) VALUES (1, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1, 1, 1, NULL, CAST(N'2020-06-12T09:01:35.103' AS DateTime), NULL)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [NgayDiemDanh], [Ca], [isCreatedManually], [Status], [Message], [FetchDataTime], [VERSION]) VALUES (2, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1, 0, 1, NULL, CAST(N'2020-06-12T09:01:45.307' AS DateTime), N'2019.11.5.5                   ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [NgayDiemDanh], [Ca], [isCreatedManually], [Status], [Message], [FetchDataTime], [VERSION]) VALUES (3, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1, 1, 1, NULL, CAST(N'2020-06-12T09:02:11.417' AS DateTime), NULL)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [NgayDiemDanh], [Ca], [isCreatedManually], [Status], [Message], [FetchDataTime], [VERSION]) VALUES (4, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 2, 0, 1, NULL, CAST(N'2020-06-12T09:03:48.310' AS DateTime), N'2019.11.5.5                   ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [NgayDiemDanh], [Ca], [isCreatedManually], [Status], [Message], [FetchDataTime], [VERSION]) VALUES (5, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1, 0, 1, NULL, CAST(N'2020-06-12T09:04:19.187' AS DateTime), N'2019.11.5.5                   ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [NgayDiemDanh], [Ca], [isCreatedManually], [Status], [Message], [FetchDataTime], [VERSION]) VALUES (6, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 3, 0, 1, NULL, CAST(N'2020-06-12T09:05:23.423' AS DateTime), N'2019.11.5.5                   ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] ([HeaderID], [NgayDiemDanh], [Ca], [isCreatedManually], [Status], [Message], [FetchDataTime], [VERSION]) VALUES (7, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 3, 0, 1, NULL, CAST(N'2020-06-12T09:06:17.697' AS DateTime), N'2019.11.5.5                   ')
GO
SET IDENTITY_INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong] OFF
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1001', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:47:32.047' AS DateTime), CAST(N'2020-06-11T22:18:12.350' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1002', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:49:48.063' AS DateTime), CAST(N'2020-06-12T06:15:10.163' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1010', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:29:53.690' AS DateTime), CAST(N'2020-06-11T22:08:19.033' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1025', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:40.320' AS DateTime), CAST(N'2020-06-11T23:05:48.210' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1032', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:23:46.740' AS DateTime), CAST(N'2020-06-11T11:33:43.663' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1037', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T13:13:52.390' AS DateTime), CAST(N'2020-06-11T13:14:32.997' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1039', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:25:39.920' AS DateTime), CAST(N'2020-06-11T19:14:07.883' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1045', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:16:13.963' AS DateTime), CAST(N'2020-06-11T10:41:54.770' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1048', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:14:53.397' AS DateTime), CAST(N'2020-06-11T11:29:02.227' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1049', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:25:52.010' AS DateTime), CAST(N'2020-06-12T06:43:16.760' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1057', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:50:00.533' AS DateTime), CAST(N'2020-06-11T13:15:44.820' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1058', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:23.020' AS DateTime), CAST(N'2020-06-11T23:56:31.240' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1059', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:52.917' AS DateTime), CAST(N'2020-06-11T15:55:04.703' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1060', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:24:22.640' AS DateTime), CAST(N'2020-06-11T22:34:55.447' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1061', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:11.703' AS DateTime), CAST(N'2020-06-11T13:50:09.330' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1063', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:44.830' AS DateTime), CAST(N'2020-06-11T23:52:05.113' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1068', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:58:26.997' AS DateTime), CAST(N'2020-06-11T21:33:31.120' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1073', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:34:28.347' AS DateTime), CAST(N'2020-06-11T22:49:38.253' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1076', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:32.677' AS DateTime), CAST(N'2020-06-11T14:47:27.803' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1082', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:21:53.960' AS DateTime), CAST(N'2020-06-11T22:08:49.653' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1083', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:41.923' AS DateTime), CAST(N'2020-06-11T15:52:15.773' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1084', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:28:30.753' AS DateTime), CAST(N'2020-06-11T15:55:14.317' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1087', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:06.203' AS DateTime), CAST(N'2020-06-11T13:31:03.113' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1088', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:49:18.040' AS DateTime), CAST(N'2020-06-12T05:08:15.050' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1092', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:11:35.973' AS DateTime), CAST(N'2020-06-11T13:41:34.987' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1099', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:07.017' AS DateTime), CAST(N'2020-06-11T15:05:20.563' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1100', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:25:23.110' AS DateTime), CAST(N'2020-06-11T22:29:57.243' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1101', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:43:49.580' AS DateTime), CAST(N'2020-06-11T15:28:47.333' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1102', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:03:00.800' AS DateTime), CAST(N'2020-06-12T06:24:54.470' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1104', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:45:35.047' AS DateTime), CAST(N'2020-06-11T20:38:49.797' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1105', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:34:21.777' AS DateTime), CAST(N'2020-06-11T22:49:33.043' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1110', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:54.637' AS DateTime), CAST(N'2020-06-11T14:59:17.847' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1111', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:55.220' AS DateTime), CAST(N'2020-06-11T22:49:01.413' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1113', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:37:38.163' AS DateTime), CAST(N'2020-06-12T05:48:06.527' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1115', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:40.383' AS DateTime), CAST(N'2020-06-11T14:21:34.867' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1118', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:39:17.487' AS DateTime), CAST(N'2020-06-11T21:43:27.357' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1123', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:25:49.623' AS DateTime), CAST(N'2020-06-11T19:14:54.660' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1124', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:42.350' AS DateTime), CAST(N'2020-06-11T22:49:26.123' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1125', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:06:00.630' AS DateTime), CAST(N'2020-06-11T16:28:47.840' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1135', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:46:36.000' AS DateTime), CAST(N'2020-06-11T15:28:45.360' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1139', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:36.843' AS DateTime), CAST(N'2020-06-11T14:13:22.053' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1140', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:31.273' AS DateTime), CAST(N'2020-06-11T14:05:43.290' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1147', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:30.170' AS DateTime), CAST(N'2020-06-11T16:12:05.137' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1148', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:30.447' AS DateTime), CAST(N'2020-06-11T14:25:24.990' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1151', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:02:21.343' AS DateTime), CAST(N'2020-06-12T06:22:13.343' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1157', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:24.397' AS DateTime), CAST(N'2020-06-11T23:16:32.073' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1160', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:13:27.577' AS DateTime), CAST(N'2020-06-11T13:44:31.043' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1167', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:55:16.047' AS DateTime), CAST(N'2020-06-12T05:47:50.400' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1170', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:17.477' AS DateTime), CAST(N'2020-06-11T22:24:27.563' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1173', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:29.553' AS DateTime), CAST(N'2020-06-11T23:09:15.997' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1186', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:57:33.023' AS DateTime), CAST(N'2020-06-11T14:59:16.083' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1187', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:25:20.610' AS DateTime), CAST(N'2020-06-12T06:37:01.350' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'119', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:22:15.383' AS DateTime), CAST(N'2020-06-11T22:08:01.463' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1190', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:49:54.420' AS DateTime), CAST(N'2020-06-11T23:20:44.910' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1192', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:48:04.730' AS DateTime), CAST(N'2020-06-11T22:41:41.273' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1200', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:15.847' AS DateTime), CAST(N'2020-06-11T23:43:35.203' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1201', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:20.267' AS DateTime), CAST(N'2020-06-11T23:17:51.560' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1207', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:06.500' AS DateTime), CAST(N'2020-06-11T21:27:57.417' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1208', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T00:47:05.360' AS DateTime), CAST(N'2020-06-12T04:40:26.387' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1209', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:27:40.037' AS DateTime), CAST(N'2020-06-11T23:22:31.643' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1224', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:10.907' AS DateTime), CAST(N'2020-06-11T14:22:05.237' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1225', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:43.933' AS DateTime), CAST(N'2020-06-12T00:35:31.337' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1229', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:03:26.550' AS DateTime), CAST(N'2020-06-11T23:35:57.490' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1230', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:10:04.633' AS DateTime), CAST(N'2020-06-12T06:20:56.087' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1233', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:46:15.200' AS DateTime), CAST(N'2020-06-11T12:10:58.650' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1236', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:37:27.757' AS DateTime), CAST(N'2020-06-11T15:21:23.257' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1238', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:33:47.253' AS DateTime), CAST(N'2020-06-11T11:48:55.210' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1242', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:44:44.670' AS DateTime), CAST(N'2020-06-11T13:43:43.987' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1243', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:21:49.683' AS DateTime), CAST(N'2020-06-11T22:08:54.313' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1247', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:03.920' AS DateTime), CAST(N'2020-06-11T22:31:42.890' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1249', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:02.760' AS DateTime), CAST(N'2020-06-11T14:07:06.100' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1250', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:13.763' AS DateTime), CAST(N'2020-06-11T23:44:30.083' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1251', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:09.250' AS DateTime), CAST(N'2020-06-11T22:57:15.453' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1253', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:21.663' AS DateTime), CAST(N'2020-06-11T13:49:42.533' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1254', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:08.313' AS DateTime), CAST(N'2020-06-11T23:35:24.763' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1255', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:11:11.843' AS DateTime), CAST(N'2020-06-12T06:42:58.217' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1256', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:51:41.940' AS DateTime), CAST(N'2020-06-11T13:03:30.907' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1267', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:29.623' AS DateTime), CAST(N'2020-06-11T16:38:47.577' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1268', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:10:30.323' AS DateTime), CAST(N'2020-06-11T15:18:39.287' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1269', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:13.120' AS DateTime), CAST(N'2020-06-11T16:38:24.960' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1270', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:40.120' AS DateTime), CAST(N'2020-06-11T14:02:01.393' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1308', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:52.597' AS DateTime), CAST(N'2020-06-11T13:32:21.660' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1313', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:02:49.050' AS DateTime), CAST(N'2020-06-12T06:24:41.313' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1332', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:11:09.430' AS DateTime), CAST(N'2020-06-12T06:45:47.907' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1333', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:03.607' AS DateTime), CAST(N'2020-06-11T23:04:36.107' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1339', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:06.533' AS DateTime), CAST(N'2020-06-11T15:30:20.103' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1340', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:27:29.820' AS DateTime), CAST(N'2020-06-12T05:38:15.293' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1343', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:54.803' AS DateTime), CAST(N'2020-06-11T13:32:57.807' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1363', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:59.640' AS DateTime), CAST(N'2020-06-12T00:36:23.730' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1367', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:23:18.117' AS DateTime), CAST(N'2020-06-11T12:31:27.977' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1368', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:13:29.487' AS DateTime), CAST(N'2020-06-12T01:47:41.433' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1372', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:03:10.340' AS DateTime), CAST(N'2020-06-11T13:26:32.483' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1383', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:30.160' AS DateTime), CAST(N'2020-06-11T14:40:35.660' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1387', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:01.217' AS DateTime), CAST(N'2020-06-11T15:07:53.080' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1388', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:08:29.213' AS DateTime), CAST(N'2020-06-11T22:58:13.670' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1390', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:16:23.423' AS DateTime), CAST(N'2020-06-11T13:53:56.097' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1392', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:24.437' AS DateTime), CAST(N'2020-06-11T21:41:53.350' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1399', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:47:46.910' AS DateTime), CAST(N'2020-06-11T13:14:28.737' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1407', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:41:38.543' AS DateTime), CAST(N'2020-06-12T06:40:05.530' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1411', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:10:28.273' AS DateTime), CAST(N'2020-06-12T00:02:13.557' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1414', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:14.573' AS DateTime), CAST(N'2020-06-11T17:36:18.010' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1415', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:38.747' AS DateTime), CAST(N'2020-06-11T23:19:37.037' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1424', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:38.953' AS DateTime), CAST(N'2020-06-11T23:45:32.027' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1441', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:34:18.903' AS DateTime), CAST(N'2020-06-11T17:52:12.440' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1455', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:07:15.043' AS DateTime), CAST(N'2020-06-11T15:23:59.530' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1456', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:10:57.913' AS DateTime), CAST(N'2020-06-11T12:33:39.703' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1461', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:51.133' AS DateTime), CAST(N'2020-06-11T15:50:04.220' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1466', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:43:51.780' AS DateTime), CAST(N'2020-06-11T23:34:32.727' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1469', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:44.187' AS DateTime), CAST(N'2020-06-11T14:53:41.697' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1473', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T18:05:24.660' AS DateTime), CAST(N'2020-06-12T06:37:42.383' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1477', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:00.873' AS DateTime), CAST(N'2020-06-11T15:25:36.160' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1479', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:03:44.493' AS DateTime), CAST(N'2020-06-11T15:27:58.850' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1482', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:13:08.707' AS DateTime), CAST(N'2020-06-11T13:50:55.173' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1485', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:25:58.123' AS DateTime), CAST(N'2020-06-12T06:12:00.113' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1512', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:40.200' AS DateTime), CAST(N'2020-06-11T20:47:32.013' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1520', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:56:51.117' AS DateTime), CAST(N'2020-06-11T11:14:11.487' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1523', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:18:35.460' AS DateTime), CAST(N'2020-06-11T11:51:54.573' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1527', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:55:14.820' AS DateTime), CAST(N'2020-06-11T15:38:54.673' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1531', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:45:25.317' AS DateTime), CAST(N'2020-06-11T20:38:44.720' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1532', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:39.697' AS DateTime), CAST(N'2020-06-11T14:19:24.797' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1533', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:34.857' AS DateTime), CAST(N'2020-06-11T23:35:13.933' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1535', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:56.303' AS DateTime), CAST(N'2020-06-11T12:30:53.463' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1537', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:17:25.520' AS DateTime), CAST(N'2020-06-11T16:01:54.283' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1541', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:37.970' AS DateTime), CAST(N'2020-06-12T00:35:37.233' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1543', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:43.777' AS DateTime), CAST(N'2020-06-11T23:10:28.590' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1546', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:57:10.063' AS DateTime), CAST(N'2020-06-11T12:52:39.150' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1551', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:52.437' AS DateTime), CAST(N'2020-06-11T23:46:18.557' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1557', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:23:08.033' AS DateTime), CAST(N'2020-06-11T16:33:51.107' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1559', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:09.853' AS DateTime), CAST(N'2020-06-11T22:36:20.280' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1561', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:42.967' AS DateTime), CAST(N'2020-06-11T15:04:11.773' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1580', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:09.423' AS DateTime), CAST(N'2020-06-11T14:06:32.857' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1582', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:31.987' AS DateTime), CAST(N'2020-06-12T00:02:06.880' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1586', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:07.337' AS DateTime), CAST(N'2020-06-11T15:22:28.807' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1593', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:53:30.717' AS DateTime), CAST(N'2020-06-11T22:34:06.370' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1595', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:05.997' AS DateTime), CAST(N'2020-06-11T16:16:16.757' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1612', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:41:47.117' AS DateTime), CAST(N'2020-06-11T22:28:51.170' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1614', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:37.997' AS DateTime), CAST(N'2020-06-11T16:38:37.443' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1618', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:54:32.817' AS DateTime), CAST(N'2020-06-12T00:05:43.057' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1620', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:23:03.603' AS DateTime), CAST(N'2020-06-11T18:17:34.630' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1621', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T13:55:55.847' AS DateTime), CAST(N'2020-06-11T23:02:47.490' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1622', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:21:48.033' AS DateTime), CAST(N'2020-06-11T22:10:35.820' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1632', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:04.870' AS DateTime), CAST(N'2020-06-11T22:48:55.703' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1641', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:41:16.933' AS DateTime), CAST(N'2020-06-11T13:43:03.190' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1652', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:30:24.373' AS DateTime), CAST(N'2020-06-11T23:31:40.910' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1658', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:54:03.397' AS DateTime), CAST(N'2020-06-11T14:35:16.980' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1661', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:47.320' AS DateTime), CAST(N'2020-06-11T15:21:01.347' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1664', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:16:47.617' AS DateTime), CAST(N'2020-06-11T22:25:45.143' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1665', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:24:24.917' AS DateTime), CAST(N'2020-06-11T12:06:57.567' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1670', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:23.460' AS DateTime), CAST(N'2020-06-11T14:34:37.403' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1671', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:26:14.257' AS DateTime), CAST(N'2020-06-11T23:30:19.167' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1679', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:07:09.400' AS DateTime), CAST(N'2020-06-11T14:03:43.657' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1680', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:26.477' AS DateTime), CAST(N'2020-06-11T14:19:34.077' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1685', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:26:01.553' AS DateTime), CAST(N'2020-06-11T23:30:57.520' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1707', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:19.763' AS DateTime), CAST(N'2020-06-11T14:06:03.340' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1727', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:51.117' AS DateTime), CAST(N'2020-06-11T15:35:26.367' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1731', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:34.557' AS DateTime), CAST(N'2020-06-11T15:00:18.457' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1733', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:01:38.010' AS DateTime), CAST(N'2020-06-11T23:31:51.870' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1737', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:16.770' AS DateTime), CAST(N'2020-06-11T15:25:58.557' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1738', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:44.643' AS DateTime), CAST(N'2020-06-11T22:49:05.240' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1742', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:46.237' AS DateTime), CAST(N'2020-06-11T22:11:39.280' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1746', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:39.197' AS DateTime), CAST(N'2020-06-12T00:05:56.073' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1748', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:08:02.037' AS DateTime), CAST(N'2020-06-11T14:51:12.953' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1761', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:10:28.587' AS DateTime), CAST(N'2020-06-11T12:33:23.377' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1785', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:48.363' AS DateTime), CAST(N'2020-06-12T06:55:03.810' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1786', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:01:28.110' AS DateTime), CAST(N'2020-06-11T23:07:29.667' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1794', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:39.060' AS DateTime), CAST(N'2020-06-11T15:18:10.100' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1808', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:49:35.017' AS DateTime), CAST(N'2020-06-11T23:35:38.987' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1810', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:42.670' AS DateTime), CAST(N'2020-06-11T23:15:24.720' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1811', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:25.710' AS DateTime), CAST(N'2020-06-11T22:48:41.600' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1814', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:05.917' AS DateTime), CAST(N'2020-06-11T22:10:46.483' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1821', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:16:13.577' AS DateTime), CAST(N'2020-06-12T04:04:58.580' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1822', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:05:46.807' AS DateTime), CAST(N'2020-06-11T22:05:53.403' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1824', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:46.900' AS DateTime), CAST(N'2020-06-11T23:33:51.537' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1828', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:30:55.280' AS DateTime), CAST(N'2020-06-11T15:20:31.623' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1853', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:44.823' AS DateTime), CAST(N'2020-06-11T23:48:16.457' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1887', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:25.183' AS DateTime), CAST(N'2020-06-11T16:43:35.970' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1888', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:09:01.803' AS DateTime), CAST(N'2020-06-11T15:41:35.773' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1890', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:40:57.953' AS DateTime), CAST(N'2020-06-12T06:56:55.233' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1901', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:40.497' AS DateTime), CAST(N'2020-06-11T13:58:32.393' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1906', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:27.173' AS DateTime), CAST(N'2020-06-11T15:15:29.277' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1907', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:50.980' AS DateTime), CAST(N'2020-06-11T15:54:45.487' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1909', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:00.613' AS DateTime), CAST(N'2020-06-11T23:21:50.957' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1918', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:47.383' AS DateTime), CAST(N'2020-06-11T14:21:44.477' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1923', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:45.597' AS DateTime), CAST(N'2020-06-11T13:29:03.580' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1927', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:34.803' AS DateTime), CAST(N'2020-06-11T12:38:46.160' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1928', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:36.510' AS DateTime), CAST(N'2020-06-11T14:15:59.750' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'194', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:17:45.510' AS DateTime), CAST(N'2020-06-11T23:15:41.837' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1944', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:03.437' AS DateTime), CAST(N'2020-06-11T13:48:22.330' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1949', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:41:06.880' AS DateTime), CAST(N'2020-06-11T13:53:02.660' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1967', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:03:26.693' AS DateTime), CAST(N'2020-06-12T06:53:56.213' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1971', 1, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T07:07:38.533' AS DateTime), CAST(N'2020-06-12T07:48:10.723' AS DateTime), 0, 2, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1971', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:38.230' AS DateTime), CAST(N'2020-06-11T15:52:19.317' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1973', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:05:37.617' AS DateTime), CAST(N'2020-06-11T07:21:44.343' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1974', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:24.233' AS DateTime), CAST(N'2020-06-11T16:11:55.110' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1975', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:54:58.713' AS DateTime), CAST(N'2020-06-11T10:37:53.433' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1986', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:41:29.150' AS DateTime), CAST(N'2020-06-11T15:30:58.387' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1996', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:22:56.373' AS DateTime), CAST(N'2020-06-11T23:05:12.510' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'1998', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:56:24.000' AS DateTime), CAST(N'2020-06-11T16:04:32.397' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2008', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:30:08.807' AS DateTime), CAST(N'2020-06-11T22:09:25.747' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2012', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:36.270' AS DateTime), CAST(N'2020-06-11T22:46:15.437' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2019', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:48.510' AS DateTime), CAST(N'2020-06-11T16:15:16.273' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2029', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:17:44.220' AS DateTime), CAST(N'2020-06-11T22:37:24.237' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2034', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:58:01.927' AS DateTime), CAST(N'2020-06-11T19:01:00.817' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2035', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:23.137' AS DateTime), CAST(N'2020-06-11T14:51:55.400' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2036', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:11.910' AS DateTime), CAST(N'2020-06-11T15:55:00.530' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2062', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:29:28.190' AS DateTime), CAST(N'2020-06-12T06:27:26.890' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2063', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:02.133' AS DateTime), CAST(N'2020-06-11T14:44:55.473' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2074', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:00.420' AS DateTime), CAST(N'2020-06-11T15:41:15.207' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2076', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:34.707' AS DateTime), CAST(N'2020-06-11T15:53:48.683' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2079', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:49.617' AS DateTime), CAST(N'2020-06-11T13:58:20.857' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2080', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:27.153' AS DateTime), CAST(N'2020-06-11T22:07:39.903' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2082', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:07.587' AS DateTime), CAST(N'2020-06-11T13:59:08.873' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2086', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:48.720' AS DateTime), CAST(N'2020-06-11T23:57:41.160' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2088', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:38:39.953' AS DateTime), CAST(N'2020-06-11T15:12:40.197' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2090', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:22.457' AS DateTime), CAST(N'2020-06-11T15:24:47.757' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2125', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:49:42.787' AS DateTime), CAST(N'2020-06-11T23:16:02.307' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2135', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:28:57.310' AS DateTime), CAST(N'2020-06-11T15:08:37.657' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2139', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:54.063' AS DateTime), CAST(N'2020-06-11T20:20:33.140' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2142', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:01.197' AS DateTime), CAST(N'2020-06-11T12:53:33.643' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2163', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:56.600' AS DateTime), CAST(N'2020-06-11T23:04:31.537' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2167', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:58.863' AS DateTime), CAST(N'2020-06-12T00:04:54.077' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2179', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:29.320' AS DateTime), CAST(N'2020-06-11T16:28:08.180' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2180', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:56.430' AS DateTime), CAST(N'2020-06-12T00:36:36.177' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2191', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:58:56.220' AS DateTime), CAST(N'2020-06-12T00:02:51.473' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2198', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T06:55:56.517' AS DateTime), CAST(N'2020-06-12T06:56:11.633' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2209', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:56.247' AS DateTime), CAST(N'2020-06-11T16:14:40.527' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2214', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:11.807' AS DateTime), CAST(N'2020-06-11T14:08:21.020' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2232', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:20:28.503' AS DateTime), CAST(N'2020-06-12T06:32:02.853' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2234', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:50.780' AS DateTime), CAST(N'2020-06-11T23:09:59.520' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2237', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:47:34.987' AS DateTime), CAST(N'2020-06-11T13:38:17.823' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2238', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:12:37.923' AS DateTime), CAST(N'2020-06-11T16:07:57.230' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2239', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:13:51.570' AS DateTime), CAST(N'2020-06-12T06:54:18.263' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2245', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:47.767' AS DateTime), CAST(N'2020-06-11T14:07:45.660' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2248', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:08:34.180' AS DateTime), CAST(N'2020-06-11T23:25:02.357' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2258', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:23.693' AS DateTime), CAST(N'2020-06-11T23:28:53.193' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2261', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:12:48.297' AS DateTime), CAST(N'2020-06-11T22:44:18.063' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'23', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:54:51.647' AS DateTime), CAST(N'2020-06-11T17:32:46.703' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2301', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:31:52.230' AS DateTime), CAST(N'2020-06-12T06:06:42.693' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2304', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:07:24.017' AS DateTime), CAST(N'2020-06-11T23:17:03.340' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2308', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:42.500' AS DateTime), CAST(N'2020-06-12T00:04:16.383' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2309', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:32.443' AS DateTime), CAST(N'2020-06-11T15:54:55.823' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2314', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:42:51.790' AS DateTime), CAST(N'2020-06-12T05:37:15.483' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2316', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:27:28.767' AS DateTime), CAST(N'2020-06-11T22:16:30.247' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2330', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:57:07.593' AS DateTime), CAST(N'2020-06-11T16:12:13.867' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2339', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:30:14.107' AS DateTime), CAST(N'2020-06-11T15:24:29.143' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2365', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:21.310' AS DateTime), CAST(N'2020-06-11T22:01:23.627' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2385', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:23.380' AS DateTime), CAST(N'2020-06-11T15:16:02.910' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2388', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:57:57.197' AS DateTime), CAST(N'2020-06-11T13:48:05.890' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2389', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:45:56.247' AS DateTime), CAST(N'2020-06-11T11:51:11.637' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2389', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:37:54.953' AS DateTime), CAST(N'2020-06-12T06:19:03.090' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2397', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:00:45.270' AS DateTime), CAST(N'2020-06-11T23:43:31.397' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2399', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T20:09:06.897' AS DateTime), CAST(N'2020-06-11T23:29:56.270' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2410', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:43.900' AS DateTime), CAST(N'2020-06-11T23:06:25.503' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2420', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:00:41.673' AS DateTime), CAST(N'2020-06-12T06:24:34.220' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'243', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:40:57.560' AS DateTime), CAST(N'2020-06-11T22:46:03.810' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2441', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:11:00.147' AS DateTime), CAST(N'2020-06-11T20:16:28.833' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2442', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:00:47.043' AS DateTime), CAST(N'2020-06-11T16:32:17.753' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2444', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:00:55.743' AS DateTime), CAST(N'2020-06-11T16:31:29.883' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2458', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:16.550' AS DateTime), CAST(N'2020-06-11T15:58:49.493' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2461', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:24.747' AS DateTime), CAST(N'2020-06-11T16:53:04.890' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2469', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:49.497' AS DateTime), CAST(N'2020-06-11T15:52:10.277' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2472', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:54.883' AS DateTime), CAST(N'2020-06-11T14:22:08.597' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2474', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:51.257' AS DateTime), CAST(N'2020-06-11T23:33:39.260' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2481', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:08.097' AS DateTime), CAST(N'2020-06-11T23:31:30.523' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2499', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:20.267' AS DateTime), CAST(N'2020-06-11T15:23:16.943' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2506', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:36:13.943' AS DateTime), CAST(N'2020-06-12T06:46:33.000' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2507', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:47.147' AS DateTime), CAST(N'2020-06-11T23:45:18.280' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2508', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:31:00.897' AS DateTime), CAST(N'2020-06-11T16:42:20.033' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2509', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:47:27.643' AS DateTime), CAST(N'2020-06-11T23:30:24.310' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2529', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:57:20.480' AS DateTime), CAST(N'2020-06-11T14:29:19.723' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2530', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:05:41.507' AS DateTime), CAST(N'2020-06-12T06:27:11.533' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2542', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:04:26.607' AS DateTime), CAST(N'2020-06-11T16:17:37.323' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2547', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:13:43.297' AS DateTime), CAST(N'2020-06-12T06:54:29.180' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2551', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:58.247' AS DateTime), CAST(N'2020-06-12T00:01:49.883' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2557', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:01:23.417' AS DateTime), CAST(N'2020-06-11T13:47:06.457' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2558', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T06:29:44.337' AS DateTime), CAST(N'2020-06-12T06:41:00.753' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2560', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:05.150' AS DateTime), CAST(N'2020-06-11T23:46:09.390' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2562', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:51:31.697' AS DateTime), CAST(N'2020-06-11T12:56:04.693' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2574', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:13:31.363' AS DateTime), CAST(N'2020-06-11T09:29:37.097' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2577', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:33:39.243' AS DateTime), CAST(N'2020-06-11T11:49:27.453' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'258', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:01:36.077' AS DateTime), CAST(N'2020-06-11T11:13:59.137' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2586', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:10:29.190' AS DateTime), CAST(N'2020-06-12T06:54:10.593' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2594', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T20:09:51.793' AS DateTime), CAST(N'2020-06-11T20:09:59.923' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2605', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:45.537' AS DateTime), CAST(N'2020-06-11T14:30:08.163' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2607', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:15:40.293' AS DateTime), CAST(N'2020-06-11T22:29:57.567' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2608', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:06.700' AS DateTime), CAST(N'2020-06-12T00:59:16.097' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2611', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:55.547' AS DateTime), CAST(N'2020-06-11T23:07:29.123' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2612', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:25:12.870' AS DateTime), CAST(N'2020-06-12T06:36:56.453' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2614', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:13:37.917' AS DateTime), CAST(N'2020-06-11T15:40:37.953' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2617', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:02.060' AS DateTime), CAST(N'2020-06-11T23:20:36.300' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2643', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:16.473' AS DateTime), CAST(N'2020-06-11T23:35:04.273' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2645', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:06:20.433' AS DateTime), CAST(N'2020-06-11T15:29:32.760' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2646', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:00.913' AS DateTime), CAST(N'2020-06-11T23:27:07.017' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2652', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:35:45.583' AS DateTime), CAST(N'2020-06-12T06:42:26.240' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2657', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:49:55.740' AS DateTime), CAST(N'2020-06-11T23:53:26.810' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2665', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:47.630' AS DateTime), CAST(N'2020-06-11T15:29:16.157' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2671', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:36.537' AS DateTime), CAST(N'2020-06-11T16:33:40.823' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2672', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:30:24.293' AS DateTime), CAST(N'2020-06-11T23:46:01.937' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2682', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:33.810' AS DateTime), CAST(N'2020-06-11T15:55:32.953' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2711', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:41:04.497' AS DateTime), CAST(N'2020-06-11T15:29:44.463' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2713', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:56:12.677' AS DateTime), CAST(N'2020-06-12T05:47:33.430' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2725', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:18:31.940' AS DateTime), CAST(N'2020-06-12T05:21:57.493' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2731', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:56:28.493' AS DateTime), CAST(N'2020-06-11T10:37:57.467' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2748', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:01.630' AS DateTime), CAST(N'2020-06-12T00:08:32.527' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2752', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:06:18.040' AS DateTime), CAST(N'2020-06-11T21:48:29.903' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2757', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:01:39.760' AS DateTime), CAST(N'2020-06-11T16:31:02.723' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2762', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:37:30.190' AS DateTime), CAST(N'2020-06-12T06:56:33.807' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2763', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:43:47.457' AS DateTime), CAST(N'2020-06-11T14:25:46.407' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2764', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:00:29.747' AS DateTime), CAST(N'2020-06-11T16:30:01.587' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'280', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:40.663' AS DateTime), CAST(N'2020-06-11T16:43:46.543' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2811', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:09.070' AS DateTime), CAST(N'2020-06-11T15:29:48.433' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2829', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:17.913' AS DateTime), CAST(N'2020-06-11T22:59:02.763' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2863', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:21:34.253' AS DateTime), CAST(N'2020-06-12T05:47:01.490' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'288', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:55:08.527' AS DateTime), CAST(N'2020-06-11T22:26:19.947' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2884', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:18.090' AS DateTime), CAST(N'2020-06-11T22:59:08.573' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2897', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:31:50.383' AS DateTime), CAST(N'2020-06-11T15:20:38.413' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2905', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:19.547' AS DateTime), CAST(N'2020-06-11T15:25:18.847' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2906', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:26.437' AS DateTime), CAST(N'2020-06-11T23:46:15.280' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'291', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:02:37.917' AS DateTime), CAST(N'2020-06-12T06:50:57.907' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2911', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:43:43.913' AS DateTime), CAST(N'2020-06-11T14:25:37.780' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2918', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:23:10.487' AS DateTime), CAST(N'2020-06-11T21:39:42.360' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2926', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:36:03.343' AS DateTime), CAST(N'2020-06-12T06:49:57.510' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'293', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:25.103' AS DateTime), CAST(N'2020-06-11T15:52:36.240' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'295', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:05:00.613' AS DateTime), CAST(N'2020-06-12T06:48:52.570' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2950', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:03:53.363' AS DateTime), CAST(N'2020-06-11T16:30:54.910' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'297', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:12.177' AS DateTime), CAST(N'2020-06-11T14:59:22.203' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'2978', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:41.947' AS DateTime), CAST(N'2020-06-11T16:36:18.647' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3021', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:12:02.627' AS DateTime), CAST(N'2020-06-12T05:34:46.350' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3039', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:43:48.540' AS DateTime), CAST(N'2020-06-12T06:09:46.213' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3044', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:36.847' AS DateTime), CAST(N'2020-06-11T15:34:03.093' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3053', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:47.780' AS DateTime), CAST(N'2020-06-11T14:32:31.883' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3054', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:29:06.030' AS DateTime), CAST(N'2020-06-11T14:46:41.673' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3055', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:51:14.303' AS DateTime), CAST(N'2020-06-11T23:02:57.120' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3056', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:55:08.700' AS DateTime), CAST(N'2020-06-11T23:04:11.777' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3069', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:45.133' AS DateTime), CAST(N'2020-06-11T14:05:54.023' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3079', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:41:36.413' AS DateTime), CAST(N'2020-06-11T21:39:55.223' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3083', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:23:16.873' AS DateTime), CAST(N'2020-06-12T06:52:29.050' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3085', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:05.517' AS DateTime), CAST(N'2020-06-11T22:03:47.400' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3096', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:30.973' AS DateTime), CAST(N'2020-06-11T23:03:52.517' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3103', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:58:41.307' AS DateTime), CAST(N'2020-06-11T16:26:14.607' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3121', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:55:13.440' AS DateTime), CAST(N'2020-06-11T15:32:36.183' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3122', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:59:27.340' AS DateTime), CAST(N'2020-06-11T23:22:18.790' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3127', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:39:41.763' AS DateTime), CAST(N'2020-06-11T11:14:15.867' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3131', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:16.517' AS DateTime), CAST(N'2020-06-11T14:35:57.083' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'314', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T06:28:41.680' AS DateTime), CAST(N'2020-06-12T06:31:27.120' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3146', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:44.527' AS DateTime), CAST(N'2020-06-11T23:26:53.217' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3191', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:07:55.300' AS DateTime), CAST(N'2020-06-11T23:09:04.977' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3193', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:27:25.487' AS DateTime), CAST(N'2020-06-11T15:55:27.500' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3196', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:45:16.060' AS DateTime), CAST(N'2020-06-11T11:51:08.357' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3201', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:37:12.110' AS DateTime), CAST(N'2020-06-11T15:31:25.010' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3212', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:12:37.367' AS DateTime), CAST(N'2020-06-11T15:03:54.983' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3218', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:09:55.830' AS DateTime), CAST(N'2020-06-12T06:58:47.487' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3219', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:19:31.747' AS DateTime), CAST(N'2020-06-11T23:22:52.630' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3237', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:43:38.497' AS DateTime), CAST(N'2020-06-11T22:29:35.837' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3238', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:06:19.400' AS DateTime), CAST(N'2020-06-11T22:24:44.427' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3239', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:30.343' AS DateTime), CAST(N'2020-06-11T16:43:30.993' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3247', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:01:31.960' AS DateTime), CAST(N'2020-06-11T11:49:11.740' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3248', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:58:34.237' AS DateTime), CAST(N'2020-06-11T22:58:36.217' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3250', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:25.480' AS DateTime), CAST(N'2020-06-11T12:37:32.337' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3259', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:11:35.080' AS DateTime), CAST(N'2020-06-11T14:34:44.263' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3262', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:45.710' AS DateTime), CAST(N'2020-06-11T16:54:28.583' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3272', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T00:03:42.270' AS DateTime), CAST(N'2020-06-12T00:03:52.597' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3275', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:33:24.937' AS DateTime), CAST(N'2020-06-11T16:33:28.523' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3281', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:24:50.073' AS DateTime), CAST(N'2020-06-11T13:53:40.390' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3297', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T11:03:34.200' AS DateTime), CAST(N'2020-06-12T06:52:45.753' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3303', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:34:19.047' AS DateTime), CAST(N'2020-06-11T23:45:57.910' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3308', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:50.427' AS DateTime), CAST(N'2020-06-11T15:37:35.907' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3310', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:36.060' AS DateTime), CAST(N'2020-06-11T23:35:09.503' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3311', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T05:13:20.653' AS DateTime), CAST(N'2020-06-12T06:48:33.327' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3315', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:28:59.073' AS DateTime), CAST(N'2020-06-11T15:58:22.940' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3318', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:59:33.217' AS DateTime), CAST(N'2020-06-11T15:22:25.490' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3321', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:41:30.937' AS DateTime), CAST(N'2020-06-12T06:43:38.067' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'333', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:10.687' AS DateTime), CAST(N'2020-06-11T23:19:46.070' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3350', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:04.570' AS DateTime), CAST(N'2020-06-11T15:12:45.820' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3352', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:29.940' AS DateTime), CAST(N'2020-06-12T00:00:26.823' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3361', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:07:47.757' AS DateTime), CAST(N'2020-06-11T14:24:42.790' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3375', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:44:31.077' AS DateTime), CAST(N'2020-06-11T23:01:26.557' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3376', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:09:58.873' AS DateTime), CAST(N'2020-06-12T06:20:52.283' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3377', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:56.680' AS DateTime), CAST(N'2020-06-11T16:10:12.057' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3378', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:34.537' AS DateTime), CAST(N'2020-06-12T00:01:27.683' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3380', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:45:12.997' AS DateTime), CAST(N'2020-06-12T00:05:05.797' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3381', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:35.830' AS DateTime), CAST(N'2020-06-11T15:35:23.357' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3392', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:15.787' AS DateTime), CAST(N'2020-06-11T14:18:27.337' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3412', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:35.800' AS DateTime), CAST(N'2020-06-11T23:34:39.970' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3419', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:38:04.870' AS DateTime), CAST(N'2020-06-11T11:21:33.283' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3420', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:30:58.817' AS DateTime), CAST(N'2020-06-11T14:16:56.627' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3421', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:20.060' AS DateTime), CAST(N'2020-06-11T20:31:56.707' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3423', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:51.407' AS DateTime), CAST(N'2020-06-11T15:23:22.540' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3424', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:13.637' AS DateTime), CAST(N'2020-06-11T15:27:32.490' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3425', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:19:58.890' AS DateTime), CAST(N'2020-06-11T14:19:42.060' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3437', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:36.803' AS DateTime), CAST(N'2020-06-11T21:54:16.147' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3444', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:27:46.360' AS DateTime), CAST(N'2020-06-11T23:24:26.417' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3450', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:33.220' AS DateTime), CAST(N'2020-06-12T00:36:07.127' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3451', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:46.020' AS DateTime), CAST(N'2020-06-11T15:29:06.530' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3458', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:52:46.590' AS DateTime), CAST(N'2020-06-11T23:02:27.200' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3460', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:55:10.453' AS DateTime), CAST(N'2020-06-11T15:25:46.323' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3465', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:10.687' AS DateTime), CAST(N'2020-06-11T22:20:45.487' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3467', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:35.283' AS DateTime), CAST(N'2020-06-11T14:35:45.673' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3470', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:21:42.183' AS DateTime), CAST(N'2020-06-11T23:19:30.983' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3484', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:29.117' AS DateTime), CAST(N'2020-06-11T23:06:19.563' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3486', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:02.237' AS DateTime), CAST(N'2020-06-11T15:22:14.713' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3488', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:52.937' AS DateTime), CAST(N'2020-06-12T00:35:56.440' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3502', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:55.567' AS DateTime), CAST(N'2020-06-11T23:37:36.127' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3509', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:29:01.333' AS DateTime), CAST(N'2020-06-12T06:53:44.877' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3513', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:49.587' AS DateTime), CAST(N'2020-06-11T21:53:36.777' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3519', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:40.973' AS DateTime), CAST(N'2020-06-11T15:41:06.997' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3520', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:22.993' AS DateTime), CAST(N'2020-06-12T00:05:01.163' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3532', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T18:28:56.947' AS DateTime), CAST(N'2020-06-11T23:18:11.920' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'354', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:17:51.380' AS DateTime), CAST(N'2020-06-12T05:30:46.043' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3548', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:28.837' AS DateTime), CAST(N'2020-06-11T15:20:55.377' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3552', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:49.990' AS DateTime), CAST(N'2020-06-11T14:32:37.513' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3589', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:02.643' AS DateTime), CAST(N'2020-06-11T23:01:30.530' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3603', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:48.803' AS DateTime), CAST(N'2020-06-11T22:39:45.483' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3616', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:31.710' AS DateTime), CAST(N'2020-06-11T23:04:33.503' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3636', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:20:46.963' AS DateTime), CAST(N'2020-06-12T06:39:15.680' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3637', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:21.680' AS DateTime), CAST(N'2020-06-11T23:57:55.143' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3645', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:21:33.733' AS DateTime), CAST(N'2020-06-11T22:20:01.123' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3654', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:49.540' AS DateTime), CAST(N'2020-06-11T22:45:43.337' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3663', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:43.477' AS DateTime), CAST(N'2020-06-11T15:43:47.097' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3679', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:49.520' AS DateTime), CAST(N'2020-06-11T22:05:39.680' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3684', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:16:51.740' AS DateTime), CAST(N'2020-06-11T14:49:49.820' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3689', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:44:25.660' AS DateTime), CAST(N'2020-06-11T22:19:34.247' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3695', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:16.783' AS DateTime), CAST(N'2020-06-11T23:17:58.917' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3701', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:07.520' AS DateTime), CAST(N'2020-06-11T22:31:49.430' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3705', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:27.310' AS DateTime), CAST(N'2020-06-11T23:24:58.773' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3726', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:19:55.530' AS DateTime), CAST(N'2020-06-11T14:37:45.970' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3729', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:32.427' AS DateTime), CAST(N'2020-06-11T16:43:26.403' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3739', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:46.283' AS DateTime), CAST(N'2020-06-11T16:39:27.727' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3741', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:33.863' AS DateTime), CAST(N'2020-06-11T16:35:59.720' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3757', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:34:26.220' AS DateTime), CAST(N'2020-06-11T23:59:07.383' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3766', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:56.857' AS DateTime), CAST(N'2020-06-11T22:36:02.130' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3794', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:41.847' AS DateTime), CAST(N'2020-06-11T14:13:14.187' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3813', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:30.397' AS DateTime), CAST(N'2020-06-11T15:06:57.877' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3823', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:29.013' AS DateTime), CAST(N'2020-06-11T23:19:24.687' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3838', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:44:12.450' AS DateTime), CAST(N'2020-06-11T15:31:05.083' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3861', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:00.280' AS DateTime), CAST(N'2020-06-11T16:22:14.517' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3875', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:18:11.100' AS DateTime), CAST(N'2020-06-12T06:59:18.583' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3905', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:14.517' AS DateTime), CAST(N'2020-06-11T15:45:49.733' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3935', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:11.000' AS DateTime), CAST(N'2020-06-11T15:29:19.420' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'394', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:18:21.017' AS DateTime), CAST(N'2020-06-11T23:30:49.087' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'397', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:24:03.623' AS DateTime), CAST(N'2020-06-11T14:45:08.007' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'397', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T21:42:16.577' AS DateTime), CAST(N'2020-06-12T06:20:24.237' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3973', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:06.860' AS DateTime), CAST(N'2020-06-11T12:37:13.893' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3978', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:01:29.077' AS DateTime), CAST(N'2020-06-11T11:14:53.287' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3980', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:54:09.100' AS DateTime), CAST(N'2020-06-11T23:22:02.977' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3990', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:08.553' AS DateTime), CAST(N'2020-06-11T15:23:38.427' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3995', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:26:39.583' AS DateTime), CAST(N'2020-06-11T14:58:35.293' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'3997', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:18:56.607' AS DateTime), CAST(N'2020-06-12T06:39:25.387' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4002', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:26.597' AS DateTime), CAST(N'2020-06-11T15:55:30.987' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4004', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:38:46.250' AS DateTime), CAST(N'2020-06-12T05:41:45.767' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4018', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:40:28.067' AS DateTime), CAST(N'2020-06-12T06:43:54.077' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4045', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:52:10.820' AS DateTime), CAST(N'2020-06-11T22:49:06.797' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4086', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:14.050' AS DateTime), CAST(N'2020-06-12T00:36:31.910' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4091', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:07.050' AS DateTime), CAST(N'2020-06-11T15:55:08.203' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4092', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:27.403' AS DateTime), CAST(N'2020-06-11T23:39:01.957' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4094', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:52.017' AS DateTime), CAST(N'2020-06-12T00:35:46.080' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4103', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:02.457' AS DateTime), CAST(N'2020-06-11T14:17:37.397' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4107', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:41.983' AS DateTime), CAST(N'2020-06-11T16:28:38.740' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4115', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:59.820' AS DateTime), CAST(N'2020-06-12T00:01:14.067' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4136', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:29.527' AS DateTime), CAST(N'2020-06-11T23:57:13.440' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4137', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:51.927' AS DateTime), CAST(N'2020-06-11T15:29:00.250' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4139', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:52.263' AS DateTime), CAST(N'2020-06-11T23:30:33.610' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4150', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:28.710' AS DateTime), CAST(N'2020-06-11T14:17:00.250' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4157', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:37.247' AS DateTime), CAST(N'2020-06-12T06:55:56.157' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4170', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:17:30.663' AS DateTime), CAST(N'2020-06-11T22:42:46.283' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4180', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:18:04.607' AS DateTime), CAST(N'2020-06-11T23:21:57.883' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4190', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:49:02.430' AS DateTime), CAST(N'2020-06-11T14:43:09.123' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4195', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:12:05.210' AS DateTime), CAST(N'2020-06-11T15:18:07.690' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4200', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:43:26.967' AS DateTime), CAST(N'2020-06-11T12:59:29.990' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4200', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:14:13.720' AS DateTime), CAST(N'2020-06-11T22:29:48.527' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4201', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:18:25.220' AS DateTime), CAST(N'2020-06-11T12:54:05.977' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4203', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:11:37.207' AS DateTime), CAST(N'2020-06-12T05:51:59.313' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4205', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:37.540' AS DateTime), CAST(N'2020-06-11T23:21:28.290' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4206', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:01:41.200' AS DateTime), CAST(N'2020-06-11T11:14:04.693' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4217', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:20:23.120' AS DateTime), CAST(N'2020-06-12T06:32:10.200' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4245', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:45:41.707' AS DateTime), CAST(N'2020-06-12T05:48:17.710' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4273', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:51.383' AS DateTime), CAST(N'2020-06-11T14:29:01.090' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4291', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:37.760' AS DateTime), CAST(N'2020-06-11T23:01:47.853' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4292', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:22.613' AS DateTime), CAST(N'2020-06-12T00:06:33.060' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'43', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:36.537' AS DateTime), CAST(N'2020-06-11T15:37:49.723' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4312', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T20:08:58.703' AS DateTime), CAST(N'2020-06-11T23:29:53.227' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4340', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:08.490' AS DateTime), CAST(N'2020-06-11T13:29:23.943' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4345', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:54:55.250' AS DateTime), CAST(N'2020-06-11T10:37:37.067' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4348', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T06:27:03.633' AS DateTime), CAST(N'2020-06-12T06:50:44.900' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4353', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:22.787' AS DateTime), CAST(N'2020-06-11T16:52:41.333' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4372', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:00.923' AS DateTime), CAST(N'2020-06-11T15:30:23.270' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4396', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:23:30.960' AS DateTime), CAST(N'2020-06-11T21:49:43.713' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4400', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:54:46.833' AS DateTime), CAST(N'2020-06-11T17:32:53.223' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4408', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:21.007' AS DateTime), CAST(N'2020-06-11T11:51:59.927' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4414', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:23.290' AS DateTime), CAST(N'2020-06-11T13:59:06.920' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4429', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:41.463' AS DateTime), CAST(N'2020-06-11T22:48:19.247' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4438', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:58.373' AS DateTime), CAST(N'2020-06-11T23:17:56.447' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4452', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:49:40.073' AS DateTime), CAST(N'2020-06-11T15:28:37.090' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4474', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:52.007' AS DateTime), CAST(N'2020-06-11T22:49:24.083' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4475', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:08.720' AS DateTime), CAST(N'2020-06-11T15:28:56.820' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4482', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:54.710' AS DateTime), CAST(N'2020-06-11T15:50:55.290' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4485', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:10.800' AS DateTime), CAST(N'2020-06-11T15:21:10.710' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4500', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:54.107' AS DateTime), CAST(N'2020-06-11T15:07:11.210' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4501', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:34:24.177' AS DateTime), CAST(N'2020-06-11T22:53:50.617' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4511', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:47.177' AS DateTime), CAST(N'2020-06-11T22:12:03.413' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4512', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:34.467' AS DateTime), CAST(N'2020-06-12T00:04:44.003' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4524', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:41:21.077' AS DateTime), CAST(N'2020-06-11T13:43:17.427' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4528', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:45:32.063' AS DateTime), CAST(N'2020-06-11T13:27:20.667' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4534', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:07:01.313' AS DateTime), CAST(N'2020-06-11T23:20:32.617' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4551', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:49.500' AS DateTime), CAST(N'2020-06-11T15:34:00.267' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4572', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:25:10.870' AS DateTime), CAST(N'2020-06-12T06:36:41.510' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4577', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:41:21.427' AS DateTime), CAST(N'2020-06-12T06:06:47.333' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4578', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:17:46.857' AS DateTime), CAST(N'2020-06-11T22:15:47.863' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4583', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:06.503' AS DateTime), CAST(N'2020-06-11T23:24:15.073' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4589', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:24.890' AS DateTime), CAST(N'2020-06-11T14:57:01.283' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4594', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:32.337' AS DateTime), CAST(N'2020-06-11T14:34:40.977' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4604', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:30.793' AS DateTime), CAST(N'2020-06-11T23:34:48.140' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4631', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:48.350' AS DateTime), CAST(N'2020-06-11T16:35:08.993' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4643', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:55:41.760' AS DateTime), CAST(N'2020-06-11T23:19:22.053' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4646', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:51.237' AS DateTime), CAST(N'2020-06-12T06:30:12.910' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4647', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:47:50.277' AS DateTime), CAST(N'2020-06-11T22:41:24.083' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4660', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:38.787' AS DateTime), CAST(N'2020-06-11T14:31:21.907' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4669', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:20:47.023' AS DateTime), CAST(N'2020-06-11T22:38:39.510' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4707', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:01:44.590' AS DateTime), CAST(N'2020-06-12T06:46:39.280' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4709', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T13:03:53.133' AS DateTime), CAST(N'2020-06-12T06:32:33.767' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4716', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:42:22.617' AS DateTime), CAST(N'2020-06-11T22:29:09.617' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4718', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:50:29.183' AS DateTime), CAST(N'2020-06-11T13:05:42.497' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4720', 1, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T07:52:01.417' AS DateTime), CAST(N'2020-06-12T07:52:04.523' AS DateTime), 0, 2, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4721', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:59:49.557' AS DateTime), CAST(N'2020-06-11T23:46:37.133' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4726', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:29.610' AS DateTime), CAST(N'2020-06-11T22:48:12.403' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4730', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:13:55.453' AS DateTime), CAST(N'2020-06-11T15:41:17.763' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4738', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:30:18.847' AS DateTime), CAST(N'2020-06-11T15:37:29.140' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4749', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:50.443' AS DateTime), CAST(N'2020-06-11T22:08:10.450' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4756', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:26:08.803' AS DateTime), CAST(N'2020-06-12T06:22:51.417' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4770', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:20.760' AS DateTime), CAST(N'2020-06-11T23:26:31.140' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4772', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:06.067' AS DateTime), CAST(N'2020-06-11T15:53:58.677' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4775', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:15:05.190' AS DateTime), CAST(N'2020-06-12T06:19:10.277' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4785', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:39.517' AS DateTime), CAST(N'2020-06-12T00:00:41.387' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4786', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:26.873' AS DateTime), CAST(N'2020-06-11T23:05:45.520' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4802', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:20:19.697' AS DateTime), CAST(N'2020-06-12T06:23:02.977' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4808', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:25.743' AS DateTime), CAST(N'2020-06-11T13:48:00.087' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4830', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:29:20.170' AS DateTime), CAST(N'2020-06-12T06:27:21.697' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4839', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:09:06.747' AS DateTime), CAST(N'2020-06-11T14:44:51.720' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4839', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T21:33:20.630' AS DateTime), CAST(N'2020-06-12T06:43:00.400' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4846', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:42:49.247' AS DateTime), CAST(N'2020-06-11T22:28:57.053' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4848', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:32:02.860' AS DateTime), CAST(N'2020-06-12T06:02:31.003' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4861', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:02:52.953' AS DateTime), CAST(N'2020-06-12T06:20:04.440' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4871', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:39:12.253' AS DateTime), CAST(N'2020-06-11T15:49:29.047' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4887', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:36:53.350' AS DateTime), CAST(N'2020-06-12T06:46:38.140' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4900', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:53.553' AS DateTime), CAST(N'2020-06-11T15:38:51.980' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4908', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:57:36.370' AS DateTime), CAST(N'2020-06-11T23:32:17.577' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4913', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:57.297' AS DateTime), CAST(N'2020-06-11T23:50:13.293' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4917', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:17:09.553' AS DateTime), CAST(N'2020-06-12T06:39:46.190' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4919', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:05.237' AS DateTime), CAST(N'2020-06-11T23:01:36.747' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4965', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:55:26.633' AS DateTime), CAST(N'2020-06-11T11:22:25.847' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4975', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:39.173' AS DateTime), CAST(N'2020-06-11T16:20:58.540' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4988', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:11.170' AS DateTime), CAST(N'2020-06-11T14:31:17.180' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4993', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:36.040' AS DateTime), CAST(N'2020-06-11T15:28:41.560' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'4995', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:28:38.030' AS DateTime), CAST(N'2020-06-11T15:29:27.350' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5002', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:33.823' AS DateTime), CAST(N'2020-06-11T14:51:46.877' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5015', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:27.127' AS DateTime), CAST(N'2020-06-12T00:05:31.610' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5018', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:12.487' AS DateTime), CAST(N'2020-06-11T16:14:53.170' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5020', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:15:14.217' AS DateTime), CAST(N'2020-06-12T05:34:41.743' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5024', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:04.863' AS DateTime), CAST(N'2020-06-11T15:23:26.713' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5026', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:56:01.320' AS DateTime), CAST(N'2020-06-11T14:52:01.180' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5030', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:05.767' AS DateTime), CAST(N'2020-06-11T23:14:25.010' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5032', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T11:52:07.203' AS DateTime), CAST(N'2020-06-11T14:36:15.713' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5033', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:42.820' AS DateTime), CAST(N'2020-06-11T16:40:50.963' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5035', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:34.677' AS DateTime), CAST(N'2020-06-12T00:00:59.213' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5037', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:58:23.247' AS DateTime), CAST(N'2020-06-11T22:52:44.367' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5066', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:42:11.450' AS DateTime), CAST(N'2020-06-12T06:12:05.683' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5094', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:05:41.420' AS DateTime), CAST(N'2020-06-11T15:27:34.777' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5103', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:10:10.227' AS DateTime), CAST(N'2020-06-11T22:39:58.737' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5108', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:26.830' AS DateTime), CAST(N'2020-06-11T15:47:07.853' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5112', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:15.390' AS DateTime), CAST(N'2020-06-11T15:29:24.300' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5117', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:31:05.153' AS DateTime), CAST(N'2020-06-12T06:37:23.920' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5120', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:07.717' AS DateTime), CAST(N'2020-06-11T23:31:38.953' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5125', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:10.987' AS DateTime), CAST(N'2020-06-11T14:34:04.727' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5131', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:57:31.253' AS DateTime), CAST(N'2020-06-11T22:52:19.823' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5133', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:24.183' AS DateTime), CAST(N'2020-06-11T15:51:55.207' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5162', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:55:20.490' AS DateTime), CAST(N'2020-06-11T23:20:14.397' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5176', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:37.447' AS DateTime), CAST(N'2020-06-11T23:04:07.700' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5205', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T00:03:59.857' AS DateTime), CAST(N'2020-06-12T06:54:02.113' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5238', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:13:11.567' AS DateTime), CAST(N'2020-06-12T06:22:12.280' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5251', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:02.527' AS DateTime), CAST(N'2020-06-11T23:01:34.000' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5280', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:11:08.893' AS DateTime), CAST(N'2020-06-11T20:15:49.907' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5284', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:57.137' AS DateTime), CAST(N'2020-06-11T15:34:41.603' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5289', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:47.910' AS DateTime), CAST(N'2020-06-11T22:49:16.850' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5298', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:46.447' AS DateTime), CAST(N'2020-06-11T21:38:00.710' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5308', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:54.673' AS DateTime), CAST(N'2020-06-11T22:48:51.117' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5313', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:48:26.487' AS DateTime), CAST(N'2020-06-11T12:53:46.410' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5317', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T06:31:12.110' AS DateTime), CAST(N'2020-06-12T06:33:57.753' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5318', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:21:40.907' AS DateTime), CAST(N'2020-06-11T22:32:41.567' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5330', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:42:53.900' AS DateTime), CAST(N'2020-06-11T22:29:03.060' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5331', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:52.067' AS DateTime), CAST(N'2020-06-11T13:36:11.437' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5365', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:48:56.110' AS DateTime), CAST(N'2020-06-12T06:54:37.170' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5367', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:12.550' AS DateTime), CAST(N'2020-06-11T15:29:51.030' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5379', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:24:03.377' AS DateTime), CAST(N'2020-06-11T22:25:01.810' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5383', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:06:20.770' AS DateTime), CAST(N'2020-06-11T15:18:59.457' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5391', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:44.807' AS DateTime), CAST(N'2020-06-12T00:04:05.363' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5403', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:32.310' AS DateTime), CAST(N'2020-06-11T13:27:23.747' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5414', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:02.620' AS DateTime), CAST(N'2020-06-11T13:32:11.493' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5429', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:58:35.277' AS DateTime), CAST(N'2020-06-11T22:56:54.463' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5451', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T13:58:23.410' AS DateTime), CAST(N'2020-06-11T22:26:10.577' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5452', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:02.707' AS DateTime), CAST(N'2020-06-11T12:37:00.757' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5457', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:41:02.647' AS DateTime), CAST(N'2020-06-11T22:27:07.957' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5465', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:03.647' AS DateTime), CAST(N'2020-06-12T00:04:50.467' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5467', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:09.167' AS DateTime), CAST(N'2020-06-11T14:59:06.157' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5469', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:33.283' AS DateTime), CAST(N'2020-06-11T22:48:33.120' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5477', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:04.453' AS DateTime), CAST(N'2020-06-11T15:29:31.137' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5485', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:18.643' AS DateTime), CAST(N'2020-06-11T15:30:58.960' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5492', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:04.263' AS DateTime), CAST(N'2020-06-11T15:29:43.273' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5494', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:10.133' AS DateTime), CAST(N'2020-06-11T15:46:57.530' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5495', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:32.780' AS DateTime), CAST(N'2020-06-11T16:11:43.100' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5505', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T19:23:20.463' AS DateTime), CAST(N'2020-06-11T22:18:01.310' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5507', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:59:04.040' AS DateTime), CAST(N'2020-06-12T06:27:01.550' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5509', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T06:56:02.053' AS DateTime), CAST(N'2020-06-12T06:56:07.967' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5511', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:48:41.220' AS DateTime), CAST(N'2020-06-11T23:15:35.977' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5514', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:41:55.560' AS DateTime), CAST(N'2020-06-12T05:52:01.687' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5528', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:55:24.240' AS DateTime), CAST(N'2020-06-12T05:47:53.657' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5543', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:29.143' AS DateTime), CAST(N'2020-06-11T15:28:19.967' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5544', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:36:57.733' AS DateTime), CAST(N'2020-06-11T23:45:59.967' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5546', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:52:43.130' AS DateTime), CAST(N'2020-06-11T13:53:51.523' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5559', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:00:48.000' AS DateTime), CAST(N'2020-06-12T06:26:50.993' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5565', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:03:21.597' AS DateTime), CAST(N'2020-06-11T23:07:49.820' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5573', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:53.333' AS DateTime), CAST(N'2020-06-11T15:13:22.537' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5584', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:47:54.797' AS DateTime), CAST(N'2020-06-11T22:41:50.917' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5592', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:16:16.067' AS DateTime), CAST(N'2020-06-11T16:40:25.820' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5603', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:40:16.207' AS DateTime), CAST(N'2020-06-12T06:24:23.350' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5614', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:47:56.497' AS DateTime), CAST(N'2020-06-11T12:52:55.210' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5616', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T20:09:21.210' AS DateTime), CAST(N'2020-06-11T23:29:49.967' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5619', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:54.157' AS DateTime), CAST(N'2020-06-11T14:18:13.900' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5620', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:54.683' AS DateTime), CAST(N'2020-06-11T23:31:23.240' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5622', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:41:21.610' AS DateTime), CAST(N'2020-06-12T06:54:47.753' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5628', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:11:38.247' AS DateTime), CAST(N'2020-06-11T16:11:34.340' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5633', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:12:00.040' AS DateTime), CAST(N'2020-06-11T11:43:08.277' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5635', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:18.867' AS DateTime), CAST(N'2020-06-12T00:07:56.460' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5637', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:17.123' AS DateTime), CAST(N'2020-06-11T23:54:47.897' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5647', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:04.483' AS DateTime), CAST(N'2020-06-11T22:33:18.113' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5650', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:14.823' AS DateTime), CAST(N'2020-06-11T23:11:15.913' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5652', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:08:29.667' AS DateTime), CAST(N'2020-06-11T23:35:03.950' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5659', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:23:18.947' AS DateTime), CAST(N'2020-06-11T21:39:48.347' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5663', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:25:01.867' AS DateTime), CAST(N'2020-06-12T06:05:59.117' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5664', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T12:47:28.313' AS DateTime), CAST(N'2020-06-11T14:40:19.543' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5664', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:48.307' AS DateTime), CAST(N'2020-06-12T06:34:58.177' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5666', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:15.403' AS DateTime), CAST(N'2020-06-11T23:35:22.093' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5667', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:15:59.017' AS DateTime), CAST(N'2020-06-11T14:30:32.550' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5668', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:16:19.717' AS DateTime), CAST(N'2020-06-11T22:37:22.230' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5683', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:48.653' AS DateTime), CAST(N'2020-06-11T14:54:21.803' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5684', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:09:58.980' AS DateTime), CAST(N'2020-06-11T22:37:58.010' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5701', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:46.153' AS DateTime), CAST(N'2020-06-11T14:55:53.723' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5704', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:02:48.047' AS DateTime), CAST(N'2020-06-11T15:29:11.720' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5706', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:42.343' AS DateTime), CAST(N'2020-06-11T23:34:37.517' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5717', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T21:57:49.980' AS DateTime), CAST(N'2020-06-12T06:58:26.950' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5723', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:18:27.950' AS DateTime), CAST(N'2020-06-12T06:54:56.157' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5724', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T01:27:33.123' AS DateTime), CAST(N'2020-06-12T01:27:39.337' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5737', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:29.687' AS DateTime), CAST(N'2020-06-11T23:20:37.643' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5738', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:44.817' AS DateTime), CAST(N'2020-06-11T15:41:31.073' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5741', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T20:09:34.663' AS DateTime), CAST(N'2020-06-11T23:29:45.967' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5764', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:27.953' AS DateTime), CAST(N'2020-06-11T16:43:28.943' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5766', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:50:21.707' AS DateTime), CAST(N'2020-06-11T13:06:45.053' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5771', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:00.357' AS DateTime), CAST(N'2020-06-11T13:27:11.703' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5778', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:16.107' AS DateTime), CAST(N'2020-06-11T14:24:15.843' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5786', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:43.723' AS DateTime), CAST(N'2020-06-11T15:01:16.353' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5787', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:30:27.537' AS DateTime), CAST(N'2020-06-11T15:28:50.470' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5804', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:47.970' AS DateTime), CAST(N'2020-06-11T23:02:58.377' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5808', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:28.107' AS DateTime), CAST(N'2020-06-11T16:53:00.323' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5813', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:28.040' AS DateTime), CAST(N'2020-06-11T13:58:58.163' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5818', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:11.997' AS DateTime), CAST(N'2020-06-11T15:24:52.773' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5820', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:54:05.570' AS DateTime), CAST(N'2020-06-11T22:56:22.817' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5822', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:39:45.170' AS DateTime), CAST(N'2020-06-12T06:46:35.423' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5825', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:57.267' AS DateTime), CAST(N'2020-06-11T23:01:30.853' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5829', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:41.437' AS DateTime), CAST(N'2020-06-11T15:29:44.993' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5834', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:08:22.373' AS DateTime), CAST(N'2020-06-11T23:20:53.370' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5838', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:06.833' AS DateTime), CAST(N'2020-06-11T23:03:35.627' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5841', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:12.910' AS DateTime), CAST(N'2020-06-11T15:28:14.610' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5843', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:42:44.773' AS DateTime), CAST(N'2020-06-11T22:40:22.543' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5844', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:07:12.260' AS DateTime), CAST(N'2020-06-11T23:06:44.737' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5845', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:42:40.087' AS DateTime), CAST(N'2020-06-11T22:00:06.420' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5847', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:13.550' AS DateTime), CAST(N'2020-06-11T14:53:11.140' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5854', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:43.087' AS DateTime), CAST(N'2020-06-11T22:02:18.663' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5867', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:27.497' AS DateTime), CAST(N'2020-06-11T13:47:45.210' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5876', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:29:48.380' AS DateTime), CAST(N'2020-06-11T22:08:24.080' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5889', 1, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T07:07:25.590' AS DateTime), CAST(N'2020-06-12T07:48:14.297' AS DateTime), 0, 2, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5889', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:22.387' AS DateTime), CAST(N'2020-06-11T15:52:44.113' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5900', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:44.163' AS DateTime), CAST(N'2020-06-11T13:45:06.113' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5910', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:09.347' AS DateTime), CAST(N'2020-06-11T23:21:01.797' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5935', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:01:23.327' AS DateTime), CAST(N'2020-06-11T23:07:31.777' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5936', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:21:10.713' AS DateTime), CAST(N'2020-06-12T06:56:30.173' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5946', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:22.107' AS DateTime), CAST(N'2020-06-11T13:58:34.353' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5958', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:33:17.317' AS DateTime), CAST(N'2020-06-12T00:04:07.823' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5973', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:33.227' AS DateTime), CAST(N'2020-06-11T23:57:08.950' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5982', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:09.877' AS DateTime), CAST(N'2020-06-12T00:03:39.173' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'599', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:25:52.883' AS DateTime), CAST(N'2020-06-12T06:22:55.970' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5994', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:01.633' AS DateTime), CAST(N'2020-06-11T15:28:27.390' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5995', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:11.387' AS DateTime), CAST(N'2020-06-11T15:48:10.490' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'5996', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:23.627' AS DateTime), CAST(N'2020-06-11T14:31:34.260' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6004', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:45:04.250' AS DateTime), CAST(N'2020-06-11T22:26:23.877' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6010', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:07:41.903' AS DateTime), CAST(N'2020-06-11T15:37:43.600' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6014', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T21:28:21.807' AS DateTime), CAST(N'2020-06-12T06:53:52.823' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6017', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:09.700' AS DateTime), CAST(N'2020-06-11T17:03:34.667' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'602', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:16:50.710' AS DateTime), CAST(N'2020-06-12T06:43:38.323' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6064', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:47:09.023' AS DateTime), CAST(N'2020-06-11T15:58:17.457' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6065', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:13.920' AS DateTime), CAST(N'2020-06-11T15:09:01.763' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6069', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:45:35.547' AS DateTime), CAST(N'2020-06-12T06:56:24.930' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6093', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:36:15.403' AS DateTime), CAST(N'2020-06-11T20:31:49.707' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6103', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:40:11.857' AS DateTime), CAST(N'2020-06-12T06:23:52.203' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6105', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:30.267' AS DateTime), CAST(N'2020-06-11T14:40:25.320' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6112', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:55:00.987' AS DateTime), CAST(N'2020-06-11T13:53:07.267' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6118', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:34:16.763' AS DateTime), CAST(N'2020-06-11T23:20:26.640' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6121', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:49.603' AS DateTime), CAST(N'2020-06-11T21:50:37.330' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6125', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T00:15:16.803' AS DateTime), CAST(N'2020-06-12T05:50:31.700' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6135', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:17:58.793' AS DateTime), CAST(N'2020-06-11T23:21:03.143' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6137', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:23:49.587' AS DateTime), CAST(N'2020-06-11T11:33:46.997' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6146', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:48.260' AS DateTime), CAST(N'2020-06-11T15:45:41.850' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6151', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:49.310' AS DateTime), CAST(N'2020-06-11T23:51:41.483' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6152', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:47:23.970' AS DateTime), CAST(N'2020-06-11T23:15:13.823' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6159', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:37.220' AS DateTime), CAST(N'2020-06-11T16:43:43.497' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6186', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:58:13.907' AS DateTime), CAST(N'2020-06-11T14:54:41.403' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6194', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:56.727' AS DateTime), CAST(N'2020-06-11T22:31:47.943' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6204', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:54.833' AS DateTime), CAST(N'2020-06-11T17:22:37.107' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6235', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:50:40.647' AS DateTime), CAST(N'2020-06-11T22:26:38.690' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6276', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:17:05.423' AS DateTime), CAST(N'2020-06-11T11:29:18.753' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6277', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:07:38.583' AS DateTime), CAST(N'2020-06-12T06:31:14.373' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6293', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:16:14.793' AS DateTime), CAST(N'2020-06-11T23:02:30.853' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6293', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:39.003' AS DateTime), CAST(N'2020-06-11T16:59:35.017' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6294', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:21.447' AS DateTime), CAST(N'2020-06-11T23:17:40.210' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6309', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:51:54.320' AS DateTime), CAST(N'2020-06-11T22:23:08.027' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6324', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:54.363' AS DateTime), CAST(N'2020-06-11T23:32:14.917' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6332', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:19:17.513' AS DateTime), CAST(N'2020-06-11T23:26:21.823' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6344', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:06:53.407' AS DateTime), CAST(N'2020-06-11T23:22:31.693' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6368', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:05:49.477' AS DateTime), CAST(N'2020-06-11T15:27:37.937' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6372', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:38:41.300' AS DateTime), CAST(N'2020-06-12T06:50:07.597' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6373', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:00:33.987' AS DateTime), CAST(N'2020-06-12T06:27:15.323' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6382', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:37:00.250' AS DateTime), CAST(N'2020-06-12T06:47:56.433' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6403', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:19:04.627' AS DateTime), CAST(N'2020-06-11T23:26:13.720' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6411', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:48:30.897' AS DateTime), CAST(N'2020-06-11T12:53:05.490' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6414', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:36:08.863' AS DateTime), CAST(N'2020-06-11T14:36:15.013' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6422', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:09:54.593' AS DateTime), CAST(N'2020-06-11T21:53:22.187' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6423', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:38:25.717' AS DateTime), CAST(N'2020-06-11T15:45:26.707' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6426', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:38:23.847' AS DateTime), CAST(N'2020-06-11T10:24:21.540' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6431', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:27:37.290' AS DateTime), CAST(N'2020-06-11T22:40:50.790' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6432', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:56.600' AS DateTime), CAST(N'2020-06-11T22:33:53.283' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6433', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:36.327' AS DateTime), CAST(N'2020-06-11T14:31:05.627' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6480', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:54:11.667' AS DateTime), CAST(N'2020-06-11T23:20:45.297' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6499', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:00.133' AS DateTime), CAST(N'2020-06-11T12:37:03.617' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6544', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:04.407' AS DateTime), CAST(N'2020-06-11T22:37:55.737' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6550', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:59:32.777' AS DateTime), CAST(N'2020-06-11T10:33:26.937' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6558', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:16.233' AS DateTime), CAST(N'2020-06-11T23:27:52.553' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6578', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:07:26.193' AS DateTime), CAST(N'2020-06-11T15:10:08.603' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6579', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:23:26.907' AS DateTime), CAST(N'2020-06-12T06:46:32.127' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6590', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:03.707' AS DateTime), CAST(N'2020-06-11T14:30:59.643' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6613', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:10:55.313' AS DateTime), CAST(N'2020-06-11T20:44:17.083' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6615', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:22:36.013' AS DateTime), CAST(N'2020-06-11T23:25:07.927' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6619', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T13:26:14.810' AS DateTime), CAST(N'2020-06-11T14:27:30.847' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6621', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:33.903' AS DateTime), CAST(N'2020-06-11T23:20:07.377' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6633', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:44.923' AS DateTime), CAST(N'2020-06-11T22:48:38.857' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6643', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:10:06.437' AS DateTime), CAST(N'2020-06-12T00:04:40.513' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6645', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:33.350' AS DateTime), CAST(N'2020-06-11T14:08:03.547' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6662', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:58.053' AS DateTime), CAST(N'2020-06-11T15:45:38.827' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6670', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:11:33.097' AS DateTime), CAST(N'2020-06-11T11:14:50.520' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6682', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:04:37.357' AS DateTime), CAST(N'2020-06-12T06:49:06.550' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6689', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:19.977' AS DateTime), CAST(N'2020-06-11T23:22:50.553' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6694', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:12.540' AS DateTime), CAST(N'2020-06-11T15:25:15.037' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6710', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:28:00.820' AS DateTime), CAST(N'2020-06-11T13:58:41.577' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6714', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:10.037' AS DateTime), CAST(N'2020-06-11T14:35:56.203' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6717', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:07:16.177' AS DateTime), CAST(N'2020-06-11T13:52:41.347' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6720', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:27:42.227' AS DateTime), CAST(N'2020-06-11T21:53:54.527' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6729', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:37.357' AS DateTime), CAST(N'2020-06-11T23:34:13.103' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6734', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:21:34.263' AS DateTime), CAST(N'2020-06-11T22:03:14.527' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'674', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:53.460' AS DateTime), CAST(N'2020-06-11T12:31:51.003' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6747', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:53:25.940' AS DateTime), CAST(N'2020-06-11T15:07:39.950' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6763', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:17.753' AS DateTime), CAST(N'2020-06-11T15:28:39.723' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6769', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:24:48.287' AS DateTime), CAST(N'2020-06-12T06:23:46.490' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6779', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:52.213' AS DateTime), CAST(N'2020-06-11T14:07:27.210' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6789', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:46.663' AS DateTime), CAST(N'2020-06-11T14:49:29.337' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6799', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:27.477' AS DateTime), CAST(N'2020-06-11T16:12:22.990' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6812', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:20:48.290' AS DateTime), CAST(N'2020-06-12T06:41:21.613' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6856', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:22.137' AS DateTime), CAST(N'2020-06-11T14:24:05.003' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6875', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:26.770' AS DateTime), CAST(N'2020-06-12T00:36:21.473' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6880', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:54:24.647' AS DateTime), CAST(N'2020-06-11T22:17:09.847' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6882', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:30:52.940' AS DateTime), CAST(N'2020-06-11T22:49:10.827' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6900', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:05:45.287' AS DateTime), CAST(N'2020-06-11T15:27:42.367' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6909', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:57.793' AS DateTime), CAST(N'2020-06-11T14:06:05.760' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6920', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:58.783' AS DateTime), CAST(N'2020-06-11T14:38:24.583' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6929', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:32:35.737' AS DateTime), CAST(N'2020-06-12T00:01:39.740' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6933', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:28.663' AS DateTime), CAST(N'2020-06-11T23:31:41.590' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'694', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:28.880' AS DateTime), CAST(N'2020-06-11T22:10:42.920' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6943', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:30.040' AS DateTime), CAST(N'2020-06-11T23:20:58.787' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6944', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:15.583' AS DateTime), CAST(N'2020-06-11T15:27:42.110' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6946', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:18.773' AS DateTime), CAST(N'2020-06-12T06:55:39.633' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'695', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:06.043' AS DateTime), CAST(N'2020-06-11T16:40:36.520' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'6970', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:00:17.483' AS DateTime), CAST(N'2020-06-11T14:26:37.787' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7001', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:29.257' AS DateTime), CAST(N'2020-06-12T00:03:00.423' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7002', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:44.237' AS DateTime), CAST(N'2020-06-11T11:07:42.730' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7006', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:48.807' AS DateTime), CAST(N'2020-06-11T23:40:42.303' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7007', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:47.407' AS DateTime), CAST(N'2020-06-11T23:41:37.213' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7013', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:32:29.117' AS DateTime), CAST(N'2020-06-11T23:45:51.267' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7033', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:17.340' AS DateTime), CAST(N'2020-06-12T00:36:14.107' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7037', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:03:20.387' AS DateTime), CAST(N'2020-06-11T23:47:37.820' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7038', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:52.730' AS DateTime), CAST(N'2020-06-11T23:16:52.257' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7044', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:51:11.383' AS DateTime), CAST(N'2020-06-11T21:27:52.083' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7055', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:01.713' AS DateTime), CAST(N'2020-06-11T23:20:47.837' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7060', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:02.607' AS DateTime), CAST(N'2020-06-11T15:21:35.643' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7062', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:57:28.503' AS DateTime), CAST(N'2020-06-11T23:17:43.253' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7069', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:00:10.067' AS DateTime), CAST(N'2020-06-11T15:54:58.117' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7078', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:26:33.623' AS DateTime), CAST(N'2020-06-11T22:26:28.127' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7079', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:40:16.760' AS DateTime), CAST(N'2020-06-11T23:59:03.987' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7095', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:45:11.217' AS DateTime), CAST(N'2020-06-12T00:05:07.860' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7101', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:25.823' AS DateTime), CAST(N'2020-06-11T15:21:38.350' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7106', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:43:21.897' AS DateTime), CAST(N'2020-06-11T12:56:54.353' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7107', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:12:08.973' AS DateTime), CAST(N'2020-06-11T15:18:09.973' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7108', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:37.877' AS DateTime), CAST(N'2020-06-12T00:05:04.150' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7110', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:06:23.347' AS DateTime), CAST(N'2020-06-11T20:32:34.850' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7111', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:21.347' AS DateTime), CAST(N'2020-06-11T23:47:49.037' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7118', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:38.207' AS DateTime), CAST(N'2020-06-11T20:52:46.020' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7142', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:44:40.533' AS DateTime), CAST(N'2020-06-11T15:12:37.567' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7144', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:21:58.240' AS DateTime), CAST(N'2020-06-12T06:41:16.570' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'716', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:45:36.383' AS DateTime), CAST(N'2020-06-11T22:34:47.033' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7163', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:29.347' AS DateTime), CAST(N'2020-06-11T15:47:09.397' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7172', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:23:29.503' AS DateTime), CAST(N'2020-06-11T23:14:43.937' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7177', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:41:47.733' AS DateTime), CAST(N'2020-06-11T13:26:42.123' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7180', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:27.803' AS DateTime), CAST(N'2020-06-11T22:48:58.010' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7181', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:34.947' AS DateTime), CAST(N'2020-06-11T15:54:47.983' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7185', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:58.870' AS DateTime), CAST(N'2020-06-11T15:54:41.283' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7187', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:22.403' AS DateTime), CAST(N'2020-06-11T23:35:37.543' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7212', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:53.943' AS DateTime), CAST(N'2020-06-11T23:34:21.823' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7222', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:52.390' AS DateTime), CAST(N'2020-06-11T21:08:47.963' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7224', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:14:08.600' AS DateTime), CAST(N'2020-06-12T04:04:50.707' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7227', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:45.160' AS DateTime), CAST(N'2020-06-11T15:10:06.503' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7228', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:47.570' AS DateTime), CAST(N'2020-06-11T16:11:08.690' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7238', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:21:57.987' AS DateTime), CAST(N'2020-06-11T22:30:30.987' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7265', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:55:59.420' AS DateTime), CAST(N'2020-06-11T11:48:18.347' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7266', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:49:58.557' AS DateTime), CAST(N'2020-06-11T22:30:32.340' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7285', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:10:04.440' AS DateTime), CAST(N'2020-06-12T00:04:36.683' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7288', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:09.757' AS DateTime), CAST(N'2020-06-11T14:27:50.880' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7290', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:15:54.667' AS DateTime), CAST(N'2020-06-12T06:28:42.160' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7297', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:48.927' AS DateTime), CAST(N'2020-06-11T15:50:18.383' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7303', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:30.980' AS DateTime), CAST(N'2020-06-11T15:29:53.447' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7352', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:10.540' AS DateTime), CAST(N'2020-06-11T15:55:35.680' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7354', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:41.813' AS DateTime), CAST(N'2020-06-11T23:53:47.963' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7356', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:28.020' AS DateTime), CAST(N'2020-06-11T15:23:37.323' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7365', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:28.890' AS DateTime), CAST(N'2020-06-11T15:18:06.833' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7380', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:00:40.217' AS DateTime), CAST(N'2020-06-11T23:47:15.470' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7381', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:57:51.790' AS DateTime), CAST(N'2020-06-11T23:47:22.307' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7412', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:10.230' AS DateTime), CAST(N'2020-06-11T22:11:52.380' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7414', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:37:44.287' AS DateTime), CAST(N'2020-06-11T23:00:29.973' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7423', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:14:35.153' AS DateTime), CAST(N'2020-06-11T22:44:06.807' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7430', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:45.240' AS DateTime), CAST(N'2020-06-11T23:26:15.113' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7433', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:17:20.283' AS DateTime), CAST(N'2020-06-12T06:43:11.877' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7436', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:18.660' AS DateTime), CAST(N'2020-06-11T15:41:04.573' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7451', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:31.337' AS DateTime), CAST(N'2020-06-11T15:58:36.463' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7463', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:40:49.473' AS DateTime), CAST(N'2020-06-12T06:56:50.543' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7466', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:49.113' AS DateTime), CAST(N'2020-06-11T15:43:52.660' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7467', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:55.537' AS DateTime), CAST(N'2020-06-11T15:29:50.817' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7474', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:30:06.903' AS DateTime), CAST(N'2020-06-11T15:29:55.617' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7480', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:00.237' AS DateTime), CAST(N'2020-06-11T15:50:07.587' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7486', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:35.690' AS DateTime), CAST(N'2020-06-11T14:47:30.123' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7494', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:04:41.587' AS DateTime), CAST(N'2020-06-12T00:05:18.173' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7510', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:28:33.687' AS DateTime), CAST(N'2020-06-11T15:29:13.020' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7511', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:20.213' AS DateTime), CAST(N'2020-06-11T15:55:45.150' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7512', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:07:22.043' AS DateTime), CAST(N'2020-06-11T11:13:49.970' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7516', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:25.817' AS DateTime), CAST(N'2020-06-11T22:20:15.227' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7518', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:53:41.790' AS DateTime), CAST(N'2020-06-11T13:06:15.123' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7520', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:42.170' AS DateTime), CAST(N'2020-06-11T15:48:18.377' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7523', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:17.023' AS DateTime), CAST(N'2020-06-12T00:05:10.647' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7524', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:45.257' AS DateTime), CAST(N'2020-06-11T15:28:24.997' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7528', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:06:02.863' AS DateTime), CAST(N'2020-06-11T23:35:09.227' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7545', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:26:13.037' AS DateTime), CAST(N'2020-06-11T16:34:55.003' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7555', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:22:23.930' AS DateTime), CAST(N'2020-06-11T21:42:10.690' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7556', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:15.263' AS DateTime), CAST(N'2020-06-11T15:41:01.967' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7564', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:16:44.187' AS DateTime), CAST(N'2020-06-12T06:18:23.407' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7572', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:17:09.557' AS DateTime), CAST(N'2020-06-12T06:47:02.843' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7573', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:26:37.093' AS DateTime), CAST(N'2020-06-11T22:30:37.223' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7578', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:43.370' AS DateTime), CAST(N'2020-06-11T16:10:52.907' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7583', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:43.707' AS DateTime), CAST(N'2020-06-11T22:48:29.193' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7590', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:34:23.540' AS DateTime), CAST(N'2020-06-12T06:42:14.123' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7615', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:17:33.430' AS DateTime), CAST(N'2020-06-12T06:39:33.490' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7616', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T12:51:34.533' AS DateTime), CAST(N'2020-06-11T12:51:40.990' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7627', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:38:48.057' AS DateTime), CAST(N'2020-06-11T12:52:53.720' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7629', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:57:38.737' AS DateTime), CAST(N'2020-06-11T22:40:14.257' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7630', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:35.463' AS DateTime), CAST(N'2020-06-11T23:47:28.093' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7652', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:01.653' AS DateTime), CAST(N'2020-06-11T15:38:21.847' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7653', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:22.617' AS DateTime), CAST(N'2020-06-11T23:35:47.060' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7658', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T10:08:43.770' AS DateTime), CAST(N'2020-06-11T15:43:23.710' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7660', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:34.077' AS DateTime), CAST(N'2020-06-11T14:24:10.193' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7671', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:14:06.923' AS DateTime), CAST(N'2020-06-11T22:39:34.520' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7674', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:16.317' AS DateTime), CAST(N'2020-06-11T23:33:55.793' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7692', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:18.550' AS DateTime), CAST(N'2020-06-12T00:19:51.977' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7695', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:52:47.283' AS DateTime), CAST(N'2020-06-11T13:54:10.017' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7698', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:27.663' AS DateTime), CAST(N'2020-06-11T15:06:49.807' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7700', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:10.383' AS DateTime), CAST(N'2020-06-11T23:23:54.677' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7701', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:04.260' AS DateTime), CAST(N'2020-06-11T23:45:11.643' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7703', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:58.323' AS DateTime), CAST(N'2020-06-11T14:36:41.643' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7709', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:24.107' AS DateTime), CAST(N'2020-06-11T16:11:59.827' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7720', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:02.600' AS DateTime), CAST(N'2020-06-11T16:42:36.800' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7732', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:09.300' AS DateTime), CAST(N'2020-06-11T22:49:19.040' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7735', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:06:48.510' AS DateTime), CAST(N'2020-06-11T23:20:29.543' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7746', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:40.930' AS DateTime), CAST(N'2020-06-11T15:10:12.737' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7750', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:53.450' AS DateTime), CAST(N'2020-06-11T14:36:53.667' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7752', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:16:42.227' AS DateTime), CAST(N'2020-06-12T06:18:08.063' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7755', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:52.247' AS DateTime), CAST(N'2020-06-11T12:52:58.973' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7763', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:23:37.923' AS DateTime), CAST(N'2020-06-11T11:33:39.490' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7764', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:31.797' AS DateTime), CAST(N'2020-06-12T00:36:04.933' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7784', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:15:28.967' AS DateTime), CAST(N'2020-06-11T10:21:32.217' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7794', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:42.150' AS DateTime), CAST(N'2020-06-11T15:06:40.007' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7801', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:35.817' AS DateTime), CAST(N'2020-06-11T22:48:31.420' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7803', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:23.093' AS DateTime), CAST(N'2020-06-12T00:36:29.190' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7823', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:40:01.773' AS DateTime), CAST(N'2020-06-12T00:02:26.997' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7828', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:18.843' AS DateTime), CAST(N'2020-06-11T15:29:41.533' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7838', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:20:51.893' AS DateTime), CAST(N'2020-06-12T05:46:48.980' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7859', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:38.800' AS DateTime), CAST(N'2020-06-12T00:04:10.153' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7862', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:58.283' AS DateTime), CAST(N'2020-06-11T15:55:04.423' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7892', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:41.013' AS DateTime), CAST(N'2020-06-12T00:04:47.840' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7897', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:17:31.583' AS DateTime), CAST(N'2020-06-12T06:22:41.577' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7920', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:09.563' AS DateTime), CAST(N'2020-06-11T23:07:13.837' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7922', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:43:15.930' AS DateTime), CAST(N'2020-06-11T15:40:41.393' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7924', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:42.310' AS DateTime), CAST(N'2020-06-11T14:17:14.293' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7926', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:36:12.780' AS DateTime), CAST(N'2020-06-12T06:42:21.030' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7942', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:07:19.230' AS DateTime), CAST(N'2020-06-11T20:52:50.763' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7944', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:47:11.953' AS DateTime), CAST(N'2020-06-11T15:58:14.727' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7945', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:39.070' AS DateTime), CAST(N'2020-06-11T15:45:29.527' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7947', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:46.460' AS DateTime), CAST(N'2020-06-11T23:19:11.320' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'795', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:52.197' AS DateTime), CAST(N'2020-06-11T21:33:27.507' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7951', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:53.283' AS DateTime), CAST(N'2020-06-11T16:11:35.973' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7954', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:58.780' AS DateTime), CAST(N'2020-06-12T00:02:41.247' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7958', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:32.753' AS DateTime), CAST(N'2020-06-11T23:01:34.257' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7974', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:21:12.343' AS DateTime), CAST(N'2020-06-11T23:55:36.127' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7985', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:14.303' AS DateTime), CAST(N'2020-06-11T15:23:47.157' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7987', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:06:31.940' AS DateTime), CAST(N'2020-06-11T15:03:14.297' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7990', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:08.090' AS DateTime), CAST(N'2020-06-11T16:40:42.003' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7992', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:40:47.423' AS DateTime), CAST(N'2020-06-12T06:57:13.793' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'7999', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:02.720' AS DateTime), CAST(N'2020-06-12T00:36:18.843' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:08:45.197' AS DateTime), CAST(N'2020-06-11T14:19:05.520' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8000', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T12:59:41.957' AS DateTime), CAST(N'2020-06-11T13:27:59.343' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8018', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:42:55.333' AS DateTime), CAST(N'2020-06-12T05:48:34.213' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8019', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:33:49.143' AS DateTime), CAST(N'2020-06-11T23:46:05.267' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8020', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:38:28.550' AS DateTime), CAST(N'2020-06-11T22:36:16.120' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8023', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:45.027' AS DateTime), CAST(N'2020-06-12T00:36:01.120' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8028', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:20:03.527' AS DateTime), CAST(N'2020-06-11T14:37:55.023' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8031', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:09.020' AS DateTime), CAST(N'2020-06-11T23:07:03.790' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8035', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:34.667' AS DateTime), CAST(N'2020-06-11T15:55:20.633' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8038', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:38:17.787' AS DateTime), CAST(N'2020-06-12T05:21:07.397' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8043', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:59.917' AS DateTime), CAST(N'2020-06-11T15:28:10.033' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8044', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:06:45.027' AS DateTime), CAST(N'2020-06-11T23:13:19.980' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8049', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:10.903' AS DateTime), CAST(N'2020-06-11T14:00:55.767' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8050', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:27:48.243' AS DateTime), CAST(N'2020-06-11T23:00:20.247' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8058', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T20:24:59.127' AS DateTime), CAST(N'2020-06-11T23:30:04.537' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8063', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:19.303' AS DateTime), CAST(N'2020-06-11T13:40:02.953' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8064', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:06.000' AS DateTime), CAST(N'2020-06-11T13:39:52.153' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8065', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:02.407' AS DateTime), CAST(N'2020-06-11T14:27:58.193' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8071', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:05.720' AS DateTime), CAST(N'2020-06-11T15:07:20.517' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8072', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:48.853' AS DateTime), CAST(N'2020-06-11T15:35:21.547' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8078', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:56.690' AS DateTime), CAST(N'2020-06-11T15:30:34.783' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8089', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:58:13.547' AS DateTime), CAST(N'2020-06-11T14:17:44.507' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8094', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:05.263' AS DateTime), CAST(N'2020-06-11T16:04:23.293' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8113', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:27.490' AS DateTime), CAST(N'2020-06-11T17:22:46.210' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8114', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:46.933' AS DateTime), CAST(N'2020-06-11T23:33:41.810' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8124', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:03:12.450' AS DateTime), CAST(N'2020-06-11T07:03:17.703' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8124', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:21:11.143' AS DateTime), CAST(N'2020-06-12T06:39:10.073' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8132', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:54:35.317' AS DateTime), CAST(N'2020-06-11T15:14:18.200' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8133', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:37.860' AS DateTime), CAST(N'2020-06-11T12:34:09.927' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8134', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:53:26.413' AS DateTime), CAST(N'2020-06-11T16:27:54.657' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8140', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T10:09:15.007' AS DateTime), CAST(N'2020-06-11T12:57:38.803' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8145', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:04:52.730' AS DateTime), CAST(N'2020-06-11T23:33:07.560' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8155', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:57.557' AS DateTime), CAST(N'2020-06-11T22:05:48.863' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8165', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:22.123' AS DateTime), CAST(N'2020-06-11T15:28:51.990' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8168', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:42:09.893' AS DateTime), CAST(N'2020-06-11T23:38:59.913' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8171', 1, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T07:07:35.823' AS DateTime), CAST(N'2020-06-12T07:48:21.937' AS DateTime), 0, 2, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8171', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:32.590' AS DateTime), CAST(N'2020-06-11T15:52:24.550' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8173', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:56.853' AS DateTime), CAST(N'2020-06-11T22:38:17.133' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8175', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:16.650' AS DateTime), CAST(N'2020-06-12T00:08:19.887' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8180', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:26.477' AS DateTime), CAST(N'2020-06-11T22:37:34.603' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8191', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:14.243' AS DateTime), CAST(N'2020-06-11T14:36:58.940' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8199', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:39.010' AS DateTime), CAST(N'2020-06-11T15:26:01.333' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8211', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:14:11.047' AS DateTime), CAST(N'2020-06-12T04:04:54.070' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8215', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:22.287' AS DateTime), CAST(N'2020-06-11T23:09:53.030' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8218', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:17:12.303' AS DateTime), CAST(N'2020-06-11T11:29:14.260' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8222', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:48.417' AS DateTime), CAST(N'2020-06-12T00:01:01.533' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8232', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:31.180' AS DateTime), CAST(N'2020-06-11T21:08:20.370' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'824', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:21:08.087' AS DateTime), CAST(N'2020-06-12T06:54:32.057' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8245', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:11.467' AS DateTime), CAST(N'2020-06-12T00:15:35.553' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8283', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:27:00.780' AS DateTime), CAST(N'2020-06-12T06:37:29.147' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8288', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:50.400' AS DateTime), CAST(N'2020-06-11T14:16:19.430' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8293', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:25:08.140' AS DateTime), CAST(N'2020-06-12T06:36:53.327' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8299', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:07:29.900' AS DateTime), CAST(N'2020-06-11T14:48:32.163' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8307', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:58.183' AS DateTime), CAST(N'2020-06-11T15:28:57.873' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8309', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:47.253' AS DateTime), CAST(N'2020-06-11T23:36:07.603' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8311', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:03.677' AS DateTime), CAST(N'2020-06-11T15:10:23.827' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8339', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:06:31.650' AS DateTime), CAST(N'2020-06-11T22:55:31.257' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8349', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:52:36.210' AS DateTime), CAST(N'2020-06-11T23:21:25.670' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8350', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:06:22.347' AS DateTime), CAST(N'2020-06-11T15:29:12.663' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8352', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:05.353' AS DateTime), CAST(N'2020-06-11T23:22:45.730' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8356', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:52:54.977' AS DateTime), CAST(N'2020-06-11T23:19:09.627' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8358', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:52:42.873' AS DateTime), CAST(N'2020-06-11T23:19:52.860' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8369', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:37:01.480' AS DateTime), CAST(N'2020-06-11T14:39:11.593' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8380', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:57:49.607' AS DateTime), CAST(N'2020-06-11T23:47:10.917' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8387', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:02:57.243' AS DateTime), CAST(N'2020-06-11T16:31:16.450' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8394', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:49.473' AS DateTime), CAST(N'2020-06-12T00:04:45.963' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8395', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:46.357' AS DateTime), CAST(N'2020-06-11T15:01:19.290' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8405', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:43:41.767' AS DateTime), CAST(N'2020-06-11T13:36:29.413' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8409', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:44:59.830' AS DateTime), CAST(N'2020-06-11T15:23:02.880' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8417', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:00.503' AS DateTime), CAST(N'2020-06-11T23:45:33.690' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8425', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:04:34.447' AS DateTime), CAST(N'2020-06-11T23:21:05.417' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8426', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:22.233' AS DateTime), CAST(N'2020-06-11T23:20:46.447' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8428', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:38.170' AS DateTime), CAST(N'2020-06-11T23:44:02.450' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8429', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:36.870' AS DateTime), CAST(N'2020-06-11T15:58:01.877' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8448', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:31:43.827' AS DateTime), CAST(N'2020-06-12T00:35:39.317' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8450', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:58.830' AS DateTime), CAST(N'2020-06-11T15:48:52.650' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8455', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:50.530' AS DateTime), CAST(N'2020-06-11T16:39:29.683' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8463', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:53:22.950' AS DateTime), CAST(N'2020-06-11T23:19:04.790' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8468', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:26.420' AS DateTime), CAST(N'2020-06-11T15:35:02.927' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8471', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:42:04.827' AS DateTime), CAST(N'2020-06-12T06:28:48.277' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8475', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:58.423' AS DateTime), CAST(N'2020-06-11T23:20:29.590' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8482', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:32:05.737' AS DateTime), CAST(N'2020-06-11T23:45:47.270' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8492', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:12.587' AS DateTime), CAST(N'2020-06-12T00:27:53.063' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8496', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T06:34:10.893' AS DateTime), CAST(N'2020-06-12T06:51:52.693' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8502', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:43.077' AS DateTime), CAST(N'2020-06-11T14:17:40.590' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8505', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:40.470' AS DateTime), CAST(N'2020-06-11T23:03:31.937' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8509', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:12.433' AS DateTime), CAST(N'2020-06-11T17:03:29.357' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8512', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:00.990' AS DateTime), CAST(N'2020-06-11T14:30:22.697' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8519', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:49.797' AS DateTime), CAST(N'2020-06-11T14:32:15.907' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8521', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:02.510' AS DateTime), CAST(N'2020-06-11T23:48:01.800' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8522', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:38:58.570' AS DateTime), CAST(N'2020-06-12T05:47:43.520' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8523', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:51.957' AS DateTime), CAST(N'2020-06-11T15:51:05.563' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8526', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:09.223' AS DateTime), CAST(N'2020-06-11T14:07:19.627' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8530', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:23.450' AS DateTime), CAST(N'2020-06-11T19:57:15.833' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8533', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:08.960' AS DateTime), CAST(N'2020-06-11T14:38:13.173' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8534', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:37:13.360' AS DateTime), CAST(N'2020-06-12T00:02:36.613' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8537', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:50.973' AS DateTime), CAST(N'2020-06-11T23:20:32.427' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8545', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:38.647' AS DateTime), CAST(N'2020-06-11T15:41:19.483' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8553', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:15:46.060' AS DateTime), CAST(N'2020-06-12T04:04:36.610' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8569', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:48:59.730' AS DateTime), CAST(N'2020-06-11T22:41:04.520' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'857', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:25:57.680' AS DateTime), CAST(N'2020-06-11T19:14:20.173' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8570', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:21.977' AS DateTime), CAST(N'2020-06-11T23:23:23.180' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8571', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:48:09.370' AS DateTime), CAST(N'2020-06-12T06:55:36.753' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8575', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:20.370' AS DateTime), CAST(N'2020-06-11T15:55:39.270' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'858', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:02:44.787' AS DateTime), CAST(N'2020-06-12T05:42:25.013' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8585', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:32.320' AS DateTime), CAST(N'2020-06-11T23:04:09.927' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8587', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:33.173' AS DateTime), CAST(N'2020-06-11T15:29:39.237' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8594', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:18.203' AS DateTime), CAST(N'2020-06-11T22:03:27.753' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8597', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:19.543' AS DateTime), CAST(N'2020-06-12T00:36:02.877' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8603', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:00.453' AS DateTime), CAST(N'2020-06-11T16:15:22.260' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8604', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:37:23.953' AS DateTime), CAST(N'2020-06-11T15:25:31.213' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8605', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:01.453' AS DateTime), CAST(N'2020-06-11T22:56:49.423' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8606', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:38.380' AS DateTime), CAST(N'2020-06-11T14:35:12.500' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8610', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:33.427' AS DateTime), CAST(N'2020-06-11T16:11:38.490' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8614', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:03.077' AS DateTime), CAST(N'2020-06-11T13:27:29.293' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8615', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:04.427' AS DateTime), CAST(N'2020-06-11T23:05:48.643' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8627', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:55.720' AS DateTime), CAST(N'2020-06-11T16:15:49.740' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'864', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:00:44.670' AS DateTime), CAST(N'2020-06-12T06:55:12.600' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8651', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:00:51.843' AS DateTime), CAST(N'2020-06-12T06:01:24.037' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8656', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:30:37.843' AS DateTime), CAST(N'2020-06-11T17:11:03.727' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'866', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:41:11.790' AS DateTime), CAST(N'2020-06-12T06:24:43.927' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8667', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:39.493' AS DateTime), CAST(N'2020-06-11T22:39:50.567' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'867', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:29:52.300' AS DateTime), CAST(N'2020-06-11T11:47:30.230' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8673', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:42.510' AS DateTime), CAST(N'2020-06-11T22:07:16.783' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8675', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:03:52.713' AS DateTime), CAST(N'2020-06-12T00:35:43.763' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8681', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:01.383' AS DateTime), CAST(N'2020-06-11T23:45:35.767' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8684', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:11.370' AS DateTime), CAST(N'2020-06-11T22:55:55.307' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8691', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:16:11.620' AS DateTime), CAST(N'2020-06-11T10:28:19.673' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8692', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:10.750' AS DateTime), CAST(N'2020-06-11T23:33:53.940' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8693', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:08:24.513' AS DateTime), CAST(N'2020-06-11T23:21:21.583' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8697', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:35.757' AS DateTime), CAST(N'2020-06-11T23:43:51.870' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'870', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:09.410' AS DateTime), CAST(N'2020-06-11T14:29:19.610' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8700', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:47.127' AS DateTime), CAST(N'2020-06-11T23:44:40.360' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'871', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:53:31.963' AS DateTime), CAST(N'2020-06-11T14:46:10.580' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8715', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:40:41.370' AS DateTime), CAST(N'2020-06-11T12:22:23.887' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'872', 1, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T08:09:20.153' AS DateTime), CAST(N'2020-06-12T08:15:09.690' AS DateTime), 0, 2, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8728', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:15.770' AS DateTime), CAST(N'2020-06-11T16:11:03.540' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8742', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:21:08.823' AS DateTime), CAST(N'2020-06-12T06:57:38.523' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8753', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:19.250' AS DateTime), CAST(N'2020-06-11T23:43:19.777' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8759', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:41:04.673' AS DateTime), CAST(N'2020-06-11T13:43:11.430' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8766', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:34.610' AS DateTime), CAST(N'2020-06-11T21:37:52.467' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8781', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:56.697' AS DateTime), CAST(N'2020-06-11T15:29:03.213' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8784', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:07.867' AS DateTime), CAST(N'2020-06-11T22:38:06.163' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8785', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:08.633' AS DateTime), CAST(N'2020-06-11T15:23:46.217' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8792', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:51:53.500' AS DateTime), CAST(N'2020-06-11T23:33:06.377' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8793', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:30.383' AS DateTime), CAST(N'2020-06-11T15:40:52.343' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8794', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:04.327' AS DateTime), CAST(N'2020-06-11T23:41:09.283' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8795', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T20:23:24.410' AS DateTime), CAST(N'2020-06-12T02:35:11.063' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8806', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:56.463' AS DateTime), CAST(N'2020-06-11T23:55:00.697' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8807', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:13.457' AS DateTime), CAST(N'2020-06-11T22:11:42.257' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8820', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T17:14:48.990' AS DateTime), CAST(N'2020-06-11T22:29:18.803' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8823', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:29.780' AS DateTime), CAST(N'2020-06-11T15:52:03.187' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8824', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:25.917' AS DateTime), CAST(N'2020-06-11T23:40:53.930' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8825', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:05:02.537' AS DateTime), CAST(N'2020-06-11T23:24:06.050' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8827', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:16.050' AS DateTime), CAST(N'2020-06-11T15:29:22.147' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8834', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:42.603' AS DateTime), CAST(N'2020-06-11T14:24:08.310' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8843', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:36.480' AS DateTime), CAST(N'2020-06-11T15:28:59.460' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8846', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:17.607' AS DateTime), CAST(N'2020-06-11T16:38:53.670' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8847', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:20:42.517' AS DateTime), CAST(N'2020-06-12T06:15:14.667' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8852', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:41.773' AS DateTime), CAST(N'2020-06-11T14:31:03.030' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8854', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:46.273' AS DateTime), CAST(N'2020-06-11T23:11:22.377' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8855', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:07.497' AS DateTime), CAST(N'2020-06-11T15:29:46.677' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8856', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:12.670' AS DateTime), CAST(N'2020-06-11T15:18:03.143' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'886', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:16:13.000' AS DateTime), CAST(N'2020-06-12T06:46:43.423' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8861', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:23.027' AS DateTime), CAST(N'2020-06-11T23:01:57.103' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8871', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:59.040' AS DateTime), CAST(N'2020-06-12T00:08:24.143' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8874', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:21.040' AS DateTime), CAST(N'2020-06-11T14:21:55.153' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8878', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:19:27.603' AS DateTime), CAST(N'2020-06-11T23:26:17.450' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8880', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:32:56.440' AS DateTime), CAST(N'2020-06-11T23:46:07.713' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8881', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:44:15.080' AS DateTime), CAST(N'2020-06-11T13:36:22.253' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8891', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:16.053' AS DateTime), CAST(N'2020-06-11T19:57:26.017' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8892', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:19.833' AS DateTime), CAST(N'2020-06-11T23:26:44.743' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8895', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:10:53.017' AS DateTime), CAST(N'2020-06-11T20:15:47.563' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8896', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:20:54.743' AS DateTime), CAST(N'2020-06-12T00:35:58.250' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8901', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:02:13.603' AS DateTime), CAST(N'2020-06-11T12:37:19.677' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8902', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:28.747' AS DateTime), CAST(N'2020-06-11T23:16:08.123' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8914', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:13:07.497' AS DateTime), CAST(N'2020-06-11T14:22:00.323' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8915', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:07:03.310' AS DateTime), CAST(N'2020-06-11T23:12:32.320' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8916', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:57.447' AS DateTime), CAST(N'2020-06-11T13:25:34.987' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8922', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:35:58.470' AS DateTime), CAST(N'2020-06-12T06:40:55.157' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8928', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:18.560' AS DateTime), CAST(N'2020-06-11T16:16:19.100' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8934', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:57.763' AS DateTime), CAST(N'2020-06-11T14:32:11.283' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8936', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:14.453' AS DateTime), CAST(N'2020-06-11T16:59:09.643' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8941', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:59.627' AS DateTime), CAST(N'2020-06-11T14:36:17.663' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8944', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:15:48.697' AS DateTime), CAST(N'2020-06-12T06:18:35.400' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8948', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:09:50.320' AS DateTime), CAST(N'2020-06-11T11:46:37.863' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8951', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:58:18.690' AS DateTime), CAST(N'2020-06-11T14:17:08.033' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8953', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:23.860' AS DateTime), CAST(N'2020-06-11T23:34:34.853' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8954', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:31.893' AS DateTime), CAST(N'2020-06-12T00:36:20.310' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8956', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:09.263' AS DateTime), CAST(N'2020-06-12T00:15:20.487' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8959', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:33.117' AS DateTime), CAST(N'2020-06-11T15:28:29.563' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8964', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:07:55.390' AS DateTime), CAST(N'2020-06-11T15:29:34.517' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8965', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:48:45.617' AS DateTime), CAST(N'2020-06-11T22:41:31.623' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8972', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:50.230' AS DateTime), CAST(N'2020-06-11T22:50:51.630' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8973', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:07.290' AS DateTime), CAST(N'2020-06-11T15:45:49.233' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8974', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:38.027' AS DateTime), CAST(N'2020-06-11T22:31:24.147' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8980', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:11.707' AS DateTime), CAST(N'2020-06-11T15:49:56.300' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8992', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:20.377' AS DateTime), CAST(N'2020-06-11T15:26:05.770' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8994', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:49.463' AS DateTime), CAST(N'2020-06-11T15:49:21.483' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8995', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:08:52.190' AS DateTime), CAST(N'2020-06-11T14:49:20.907' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'8996', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:30:55.227' AS DateTime), CAST(N'2020-06-12T06:22:09.727' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9004', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:58.953' AS DateTime), CAST(N'2020-06-11T23:35:43.360' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9013', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:16.827' AS DateTime), CAST(N'2020-06-11T22:10:53.983' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9015', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:36.913' AS DateTime), CAST(N'2020-06-11T16:15:03.227' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9032', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:10.140' AS DateTime), CAST(N'2020-06-11T23:40:33.120' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9034', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:03.467' AS DateTime), CAST(N'2020-06-11T13:31:00.390' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9035', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:10.070' AS DateTime), CAST(N'2020-06-11T21:51:25.603' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9039', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:24.983' AS DateTime), CAST(N'2020-06-11T22:02:02.630' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9047', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:30.800' AS DateTime), CAST(N'2020-06-11T23:39:10.890' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9048', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:34.067' AS DateTime), CAST(N'2020-06-11T20:55:52.270' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9049', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:16.370' AS DateTime), CAST(N'2020-06-11T22:38:08.607' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'905', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:28:50.383' AS DateTime), CAST(N'2020-06-11T14:29:26.017' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9050', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:03.470' AS DateTime), CAST(N'2020-06-11T15:21:53.160' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9051', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:52.923' AS DateTime), CAST(N'2020-06-11T15:14:44.773' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9059', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:12:16.607' AS DateTime), CAST(N'2020-06-11T14:21:56.503' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9065', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:31.083' AS DateTime), CAST(N'2020-06-11T22:59:16.980' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9067', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:04.890' AS DateTime), CAST(N'2020-06-11T15:45:39.740' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9076', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:09.020' AS DateTime), CAST(N'2020-06-12T00:07:46.073' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9077', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:56.143' AS DateTime), CAST(N'2020-06-11T23:25:31.867' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9078', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:03.427' AS DateTime), CAST(N'2020-06-11T23:48:44.097' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9080', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:28.130' AS DateTime), CAST(N'2020-06-11T15:22:22.977' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9081', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:11:25.480' AS DateTime), CAST(N'2020-06-11T14:38:08.950' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9082', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:56.923' AS DateTime), CAST(N'2020-06-11T16:39:49.610' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9086', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:26.763' AS DateTime), CAST(N'2020-06-11T22:33:58.523' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9089', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:17:29.513' AS DateTime), CAST(N'2020-06-12T05:22:16.983' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9091', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:49:05.513' AS DateTime), CAST(N'2020-06-11T22:44:03.697' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9092', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:01.240' AS DateTime), CAST(N'2020-06-11T15:31:11.790' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9093', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:52.850' AS DateTime), CAST(N'2020-06-11T14:19:13.497' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9094', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:36.833' AS DateTime), CAST(N'2020-06-11T23:43:57.983' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9095', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:13:00.740' AS DateTime), CAST(N'2020-06-11T23:13:16.650' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9109', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:15:45.190' AS DateTime), CAST(N'2020-06-12T06:39:37.463' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9112', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:55.550' AS DateTime), CAST(N'2020-06-11T22:49:08.730' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9113', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:58.307' AS DateTime), CAST(N'2020-06-11T23:00:46.377' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9125', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:37.047' AS DateTime), CAST(N'2020-06-11T23:45:22.343' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9129', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:30.063' AS DateTime), CAST(N'2020-06-11T23:31:20.513' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9133', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:49.567' AS DateTime), CAST(N'2020-06-11T22:37:42.880' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9138', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:36.580' AS DateTime), CAST(N'2020-06-11T22:37:05.770' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9139', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:27.410' AS DateTime), CAST(N'2020-06-11T23:54:38.280' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'914', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:27.967' AS DateTime), CAST(N'2020-06-11T23:13:20.397' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9141', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:17.917' AS DateTime), CAST(N'2020-06-11T15:28:31.403' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9145', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:04.897' AS DateTime), CAST(N'2020-06-11T16:14:27.143' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9152', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:37:05.180' AS DateTime), CAST(N'2020-06-12T00:04:52.543' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9158', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:06:02.610' AS DateTime), CAST(N'2020-06-11T23:40:38.530' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9159', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:21.207' AS DateTime), CAST(N'2020-06-11T16:25:05.443' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'916', 1, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T07:07:29.510' AS DateTime), CAST(N'2020-06-12T07:48:27.267' AS DateTime), 0, 2, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'916', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:36:28.797' AS DateTime), CAST(N'2020-06-11T15:52:41.737' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9164', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:39:35.223' AS DateTime), CAST(N'2020-06-11T16:46:24.160' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9170', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:36.757' AS DateTime), CAST(N'2020-06-11T13:50:22.183' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9174', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:39.653' AS DateTime), CAST(N'2020-06-12T00:07:30.747' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9176', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:04.123' AS DateTime), CAST(N'2020-06-12T00:04:33.630' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9177', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:49.803' AS DateTime), CAST(N'2020-06-11T15:01:13.637' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9180', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:21.230' AS DateTime), CAST(N'2020-06-11T14:37:13.673' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9181', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:26.457' AS DateTime), CAST(N'2020-06-11T23:07:57.630' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9189', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:07.590' AS DateTime), CAST(N'2020-06-12T00:05:14.733' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9195', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:16.860' AS DateTime), CAST(N'2020-06-11T15:58:45.580' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9197', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:53.873' AS DateTime), CAST(N'2020-06-11T23:07:47.727' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9200', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:47.087' AS DateTime), CAST(N'2020-06-11T22:36:55.227' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9202', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:16.960' AS DateTime), CAST(N'2020-06-11T15:49:21.573' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9206', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:00.997' AS DateTime), CAST(N'2020-06-11T13:53:16.007' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9211', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:21:25.463' AS DateTime), CAST(N'2020-06-12T06:38:56.873' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9213', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:11:24.063' AS DateTime), CAST(N'2020-06-12T00:27:43.333' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9215', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:24:03.243' AS DateTime), CAST(N'2020-06-11T16:01:22.473' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9217', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:55:24.493' AS DateTime), CAST(N'2020-06-11T22:39:28.673' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9218', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:39:25.343' AS DateTime), CAST(N'2020-06-12T00:13:23.090' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9220', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:55:27.140' AS DateTime), CAST(N'2020-06-11T23:16:45.717' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9222', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:43:42.000' AS DateTime), CAST(N'2020-06-11T23:39:50.150' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9223', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:41:25.033' AS DateTime), CAST(N'2020-06-11T23:39:18.850' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9224', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:42.157' AS DateTime), CAST(N'2020-06-11T23:34:27.720' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9225', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:48:50.950' AS DateTime), CAST(N'2020-06-11T22:43:55.247' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9226', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:46.113' AS DateTime), CAST(N'2020-06-11T15:55:16.210' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9227', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:35:19.167' AS DateTime), CAST(N'2020-06-11T23:26:29.977' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9228', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:25:40.013' AS DateTime), CAST(N'2020-06-12T00:36:26.783' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9230', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:16.627' AS DateTime), CAST(N'2020-06-11T16:25:13.990' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9237', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:54.300' AS DateTime), CAST(N'2020-06-11T15:50:50.543' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'924', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:20.360' AS DateTime), CAST(N'2020-06-11T21:59:05.323' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9241', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:18.160' AS DateTime), CAST(N'2020-06-11T16:11:00.923' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9243', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:26.870' AS DateTime), CAST(N'2020-06-11T15:52:38.923' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9245', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:10:17.487' AS DateTime), CAST(N'2020-06-12T06:42:33.907' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9246', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:14:11.570' AS DateTime), CAST(N'2020-06-11T23:53:57.423' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9248', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:31.527' AS DateTime), CAST(N'2020-06-12T00:35:49.910' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'925', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:16.653' AS DateTime), CAST(N'2020-06-11T17:03:32.167' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9252', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:21.203' AS DateTime), CAST(N'2020-06-11T23:46:23.807' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9255', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:13:26.663' AS DateTime), CAST(N'2020-06-11T23:28:04.220' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9257', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:28:54.090' AS DateTime), CAST(N'2020-06-11T23:45:24.763' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9258', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:10:22.577' AS DateTime), CAST(N'2020-06-12T00:08:07.083' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9259', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:26.450' AS DateTime), CAST(N'2020-06-11T15:28:43.417' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9263', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:53.653' AS DateTime), CAST(N'2020-06-11T14:32:58.980' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9272', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:25.550' AS DateTime), CAST(N'2020-06-12T00:01:10.263' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9273', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:00.653' AS DateTime), CAST(N'2020-06-11T23:45:14.340' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9274', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:14:31.820' AS DateTime), CAST(N'2020-06-12T06:28:37.027' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9281', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:04.967' AS DateTime), CAST(N'2020-06-11T12:36:42.820' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9282', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:49.570' AS DateTime), CAST(N'2020-06-11T23:41:34.903' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9283', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:16.397' AS DateTime), CAST(N'2020-06-11T23:03:00.543' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9286', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:32:26.140' AS DateTime), CAST(N'2020-06-11T23:45:49.300' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9288', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:32.783' AS DateTime), CAST(N'2020-06-11T22:37:49.287' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9289', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:27:11.573' AS DateTime), CAST(N'2020-06-12T00:04:26.440' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9296', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:41.490' AS DateTime), CAST(N'2020-06-11T15:05:51.510' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9300', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:01.973' AS DateTime), CAST(N'2020-06-11T15:25:56.440' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9308', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:37:22.800' AS DateTime), CAST(N'2020-06-12T06:53:35.920' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9317', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:29:30.363' AS DateTime), CAST(N'2020-06-11T15:27:24.360' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9319', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:13.160' AS DateTime), CAST(N'2020-06-11T23:05:20.817' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9321', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:58.693' AS DateTime), CAST(N'2020-06-12T00:00:01.987' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9322', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:58.977' AS DateTime), CAST(N'2020-06-11T15:28:56.143' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9324', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:54.707' AS DateTime), CAST(N'2020-06-11T22:11:07.403' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9331', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:58:31.210' AS DateTime), CAST(N'2020-06-11T14:17:03.303' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9332', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T21:53:27.493' AS DateTime), CAST(N'2020-06-12T06:55:09.837' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9334', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:56:22.823' AS DateTime), CAST(N'2020-06-11T22:59:26.710' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9335', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:35:21.683' AS DateTime), CAST(N'2020-06-11T15:22:01.127' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9336', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:13.750' AS DateTime), CAST(N'2020-06-11T15:20:15.927' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9337', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:13.867' AS DateTime), CAST(N'2020-06-11T16:00:11.057' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9338', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:14:37.630' AS DateTime), CAST(N'2020-06-11T15:40:57.723' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9340', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:09.513' AS DateTime), CAST(N'2020-06-11T15:58:05.633' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9344', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:25:16.557' AS DateTime), CAST(N'2020-06-12T06:36:31.970' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9345', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:09.610' AS DateTime), CAST(N'2020-06-11T23:28:43.340' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9348', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:10:51.497' AS DateTime), CAST(N'2020-06-12T06:37:05.340' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'935', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T09:13:17.050' AS DateTime), CAST(N'2020-06-11T09:29:29.253' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9353', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:46:22.807' AS DateTime), CAST(N'2020-06-11T23:39:46.760' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9359', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:33.607' AS DateTime), CAST(N'2020-06-11T23:09:58.320' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9361', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:49:06.320' AS DateTime), CAST(N'2020-06-12T06:48:49.723' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9362', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:29.533' AS DateTime), CAST(N'2020-06-11T14:09:27.647' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9364', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:33:53.863' AS DateTime), CAST(N'2020-06-11T15:22:32.663' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9370', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:16:07.143' AS DateTime), CAST(N'2020-06-11T14:44:48.577' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9371', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:10:34.717' AS DateTime), CAST(N'2020-06-12T06:42:41.647' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9373', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:23:03.590' AS DateTime), CAST(N'2020-06-11T14:32:50.087' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9374', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:39.220' AS DateTime), CAST(N'2020-06-11T20:56:21.060' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9375', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:26:35.457' AS DateTime), CAST(N'2020-06-12T00:04:57.133' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9376', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:27:03.657' AS DateTime), CAST(N'2020-06-11T16:11:13.700' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9377', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:59:40.837' AS DateTime), CAST(N'2020-06-12T00:01:21.117' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9378', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:34:56.147' AS DateTime), CAST(N'2020-06-11T15:21:50.117' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9382', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:22:25.243' AS DateTime), CAST(N'2020-06-11T15:23:20.267' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9386', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:57:34.527' AS DateTime), CAST(N'2020-06-11T23:48:38.983' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9387', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:04.030' AS DateTime), CAST(N'2020-06-11T14:28:47.417' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9388', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:12:05.457' AS DateTime), CAST(N'2020-06-11T23:48:30.813' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9402', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:56.933' AS DateTime), CAST(N'2020-06-11T15:46:03.340' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9406', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:16:47.847' AS DateTime), CAST(N'2020-06-12T06:18:58.967' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9410', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:09.147' AS DateTime), CAST(N'2020-06-11T13:31:08.837' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9411', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:45:36.550' AS DateTime), CAST(N'2020-06-11T15:15:20.150' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9412', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:06.527' AS DateTime), CAST(N'2020-06-11T15:29:11.277' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9414', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:16:06.057' AS DateTime), CAST(N'2020-06-11T23:45:39.540' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9415', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:02.840' AS DateTime), CAST(N'2020-06-11T15:55:17.143' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9416', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:47.570' AS DateTime), CAST(N'2020-06-12T00:36:10.947' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9419', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:09.650' AS DateTime), CAST(N'2020-06-11T14:06:53.503' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9429', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:58.277' AS DateTime), CAST(N'2020-06-11T14:55:10.763' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9432', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:22:31.717' AS DateTime), CAST(N'2020-06-11T23:19:30.377' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9433', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:15:25.797' AS DateTime), CAST(N'2020-06-11T14:55:27.593' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9434', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:17:50.840' AS DateTime), CAST(N'2020-06-11T23:13:22.270' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9435', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T08:43:30.913' AS DateTime), CAST(N'2020-06-11T12:56:47.437' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9436', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:28:46.440' AS DateTime), CAST(N'2020-06-11T14:29:21.770' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9440', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:24:52.270' AS DateTime), CAST(N'2020-06-11T23:31:56.463' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9443', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:18:01.820' AS DateTime), CAST(N'2020-06-11T15:29:17.780' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9447', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:49:34.747' AS DateTime), CAST(N'2020-06-11T23:15:44.120' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9451', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:11:40.637' AS DateTime), CAST(N'2020-06-11T16:11:44.737' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9452', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:15:22.163' AS DateTime), CAST(N'2020-06-11T21:38:09.887' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9463', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:40:47.307' AS DateTime), CAST(N'2020-06-12T00:15:33.170' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9464', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:26:04.037' AS DateTime), CAST(N'2020-06-11T17:07:22.710' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9467', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:10.687' AS DateTime), CAST(N'2020-06-11T15:28:54.053' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9468', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:40:15.513' AS DateTime), CAST(N'2020-06-11T23:20:14.723' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9471', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:15:07.837' AS DateTime), CAST(N'2020-06-12T06:18:49.027' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9474', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:44.447' AS DateTime), CAST(N'2020-06-11T14:12:59.937' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9478', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:48:57.123' AS DateTime), CAST(N'2020-06-11T23:16:27.160' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'948', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:16:15.067' AS DateTime), CAST(N'2020-06-11T14:44:29.000' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9481', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:19:41.103' AS DateTime), CAST(N'2020-06-11T22:48:47.943' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9484', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:07.000' AS DateTime), CAST(N'2020-06-11T13:36:42.647' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9488', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:42:34.723' AS DateTime), CAST(N'2020-06-11T14:33:17.507' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9489', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:21:56.080' AS DateTime), CAST(N'2020-06-11T15:15:23.500' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9492', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:44:34.620' AS DateTime), CAST(N'2020-06-11T23:45:43.077' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9494', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:29:18.360' AS DateTime), CAST(N'2020-06-11T23:27:40.100' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9496', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:17:16.923' AS DateTime), CAST(N'2020-06-11T16:34:54.370' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9503', 6, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T23:02:19.320' AS DateTime), CAST(N'2020-06-12T06:19:43.533' AS DateTime), 0, 6, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9504', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:20:41.323' AS DateTime), CAST(N'2020-06-11T15:45:55.110' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9507', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:25:10.400' AS DateTime), CAST(N'2020-06-11T15:28:22.600' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9508', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:17.913' AS DateTime), CAST(N'2020-06-11T15:43:07.843' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9509', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:23:04.007' AS DateTime), CAST(N'2020-06-12T00:35:29.137' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9510', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:05.983' AS DateTime), CAST(N'2020-06-11T15:27:38.070' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9512', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:31:08.143' AS DateTime), CAST(N'2020-06-12T00:04:13.313' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9514', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:22.737' AS DateTime), CAST(N'2020-06-11T15:28:35.003' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9518', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:59.823' AS DateTime), CAST(N'2020-06-11T16:13:50.163' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9522', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:19:29.257' AS DateTime), CAST(N'2020-06-11T16:10:58.863' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9525', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T07:32:37.740' AS DateTime), CAST(N'2020-06-11T12:53:08.200' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9528', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T16:06:29.537' AS DateTime), CAST(N'2020-06-11T23:33:09.533' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9531', 1, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-12T07:33:13.603' AS DateTime), CAST(N'2020-06-12T07:36:01.140' AS DateTime), 0, 2, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'9531', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:50:02.203' AS DateTime), CAST(N'2020-06-12T04:55:07.083' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'955', 3, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T14:44:55.627' AS DateTime), CAST(N'2020-06-11T21:33:14.623' AS DateTime), 0, 5, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'958', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T22:19:27.587' AS DateTime), CAST(N'2020-06-12T06:09:36.370' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[DiemDanh_NangSuatLaoDong] ([MaNV], [HeaderID], [ThoiGianThucTeDiemDanh], [DiemLuong], [DiLam], [GhiChu], [LyDoVangMat], [ThoiGianXuongLo], [ThoiGianLenLo], [isChangedManually], [ActualHeaderFetched], [isFilledFromAPI]) VALUES (N'990', 4, NULL, NULL, 1, NULL, NULL, CAST(N'2020-06-11T15:18:12.097' AS DateTime), CAST(N'2020-06-11T22:50:40.377' AS DateTime), 0, 4, 1)
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'AT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'BGĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'BTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CBT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CĐM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'Cđoàn')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CKSC')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CTA')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CTTL')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CTV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CTXLM-TKV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CTYDH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'CV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'ĐK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'ĐL3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'ĐL5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'ĐL7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'ĐL8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'ĐS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'ĐTM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'Đủy')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KCM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KCS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KHO')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT10')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT11')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT4')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT6')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KT9')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'KTTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'PV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'TCLĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'TĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'TGM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'TG-QLKM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'TNiên')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'VP')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'VT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'VTL1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'VTL2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'XD')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (1, 0, 0, 0, 0, NULL, 0, N'YT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'AT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'BGĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'BTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CBT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CĐM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'Cđoàn')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CKSC')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CTA')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CTTL')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CTV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CTXLM-TKV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CTYDH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'CV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'ĐK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'ĐL3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'ĐL5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'ĐL7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'ĐL8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'ĐS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'ĐTM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'Đủy')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KCM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KCS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KHO')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT10')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT11')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT4')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT6')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KT9')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'KTTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'PV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'TCLĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'TĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'TGM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'TG-QLKM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'TNiên')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'VP')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'VT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'VTL1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'VTL2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'XD')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (3, 0, 0, 0, 0, NULL, 0, N'YT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'AT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'BGĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'BTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CBT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CĐM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'Cđoàn')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CKSC')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CTA')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CTTL')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CTV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CTXLM-TKV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CTYDH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'CV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'ĐK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'ĐL3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'ĐL5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'ĐL7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'ĐL8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'ĐS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'ĐTM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'Đủy')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KCM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KCS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KHO')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT10')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT11')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT4')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT6')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KT9')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'KTTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'PV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'TCLĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'TĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'TGM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'TG-QLKM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'TNiên')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'VP')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'VT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'VTL1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'VTL2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'XD')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (4, 0, 0, 0, 0, NULL, 0, N'YT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'AT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'BGĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'BTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CBT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CĐM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'Cđoàn')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CKSC')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CTA')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CTTL')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CTV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CTXLM-TKV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CTYDH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'CV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'ĐK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'ĐL3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'ĐL5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'ĐL7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'ĐL8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'ĐS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'ĐTM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'Đủy')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KCM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KCS')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KH')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KHO')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT10')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT11')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT3')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT4')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT5')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT6')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT7')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT8')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KT9')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'KTTK')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'PV')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'TCLĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'TĐ')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'TGM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'TG-QLKM')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'TNiên')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'VP')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'VT')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'VTL1')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'VTL2')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'XD')
GO
INSERT [dbo].[Header_DiemDanh_NangSuat_LaoDong_Detail] ([HeaderID], [TotalEffort], [ThanThucHien], [MetLoThucHien], [XenThucHien], [GhiChu], [isFilledFromAPI], [MaPhongBan]) VALUES (6, 0, 0, 0, 0, NULL, 0, N'YT')
GO
