--BÁO CÁO TỔNG HỢP CÁN BỘ NHÂN VIÊN ĐI LÀM / NGHỈ--
select 
sum(case when (nv_cv.TenNhomCongViec = N'Công nhân khai thác' and nv_cv.DiLam = 1) then 1 else 0 end) as 'DiLam_CNKT',
sum(case when (nv_cv.TenNhomCongViec = N'Công nhân khai thác' and nv_cv.DiLam = 0) then 1 else 0 end) as 'Nghi_CNKT',
sum(case when (nv_cv.TenNhomCongViec = N'Công nhân cơ điện' and nv_cv.DiLam = 1) then 1 else 0 end) as 'DiLam_CNCD',
sum(case when (nv_cv.TenNhomCongViec = N'Công nhân cơ điện' and nv_cv.DiLam = 0) then 1 else 0 end) as 'Nghi_CNCD',
sum(case when ((nv_cv.DiLam = 1 and nv_cv.MaPhongBan in (N'ĐS', N'PV', N'XD', N'CKCS', N'PXCBT')) 
				or (nv_cv.DiLam = 1 and nv_cv.TenCongViec in (N'(Công nhân) Bắn mìn lộ thiên', 
																N'(Công nhân) Sửa chữa cơ điện trên các mỏ lộ thiên',
																N'Công nhân vận hành trạm cảnh báo khí, gió mỏ',
																N'Công nhân lao động phổ thông',
																N'Công nhân trực thông tin',
																N'(Công nhân) vận hành, bảo trì trạm biến thế trung thế'))) then 1 else 0 end) as 'DiLam_CNMB',
sum(case when ((nv_cv.DiLam = 0 and nv_cv.MaPhongBan in (N'ĐS', N'PV', N'XD', N'CKCS', N'PXCBT')) 
				or (nv_cv.DiLam = 0 and nv_cv.TenCongViec in (N'(Công nhân) Bắn mìn lộ thiên', 
																N'(Công nhân) Sửa chữa cơ điện trên các mỏ lộ thiên',
																N'Công nhân vận hành trạm cảnh báo khí, gió mỏ',
																N'Công nhân lao động phổ thông',
																N'Công nhân trực thông tin',
																N'(Công nhân) vận hành, bảo trì trạm biến thế trung thế'))) then 1 else 0 end) as 'Nghi_CNMB',
sum(case when (nv_cv.DiLam = 1 and nv_cv.TenCongViec in (N'Giám Đốc', N'Phó giám đốc', N'Trưởng phòng', N'Phó trưởng phòng', N'Chuyên viên',
															N'Cán sự')) then 1 else 0 end) as 'DiLam_QLPB_NV',
sum(case when (nv_cv.DiLam = 0 and nv_cv.TenCongViec in (N'Giám Đốc', N'Phó giám đốc', N'Trưởng phòng', N'Phó trưởng phòng', N'Chuyên viên',
															N'Cán sự')) then 1 else 0 end) as 'Nghi_QLPB_NV'															 
from
(select 
dd.MaNV,
nv_cv.MaPhongBan, 
dd.DiLam,
nv_cv.Ten, 
nv_cv.TenCongViec, 
nv_cv.TenNhomCongViec
from
(select dd.MaNV, dd.DiLam
from
(select 
Min(hd.HeaderID) as 'HeaderID' 
from Header_DiemDanh_NangSuat_LaoDong hd 
where hd.NgayDiemDanh = '2020-04-06' and hd.Status = 1) as hd 
join
DiemDanh_NangSuatLaoDong dd on dd.HeaderID = hd.HeaderID) as dd
join
(select 
nv.MaNV,
nv.Ten,
cv.TenCongViec,
ncv.TenNhomCongViec,
nv.MaPhongBan
from NhanVien nv 
left join CongViec cv on nv.MaCongViec = cv.MaCongViec 
left join CongViec_NhomCongViec cv_ncv on cv.MaCongViec = cv_ncv.MaCongViec
left join NhomCongViec ncv on ncv.MaNhomCongViec = cv_ncv.MaNhomCongViec
where nv.MaTrangThai = 1) as nv_cv on nv_cv.MaNV = dd.MaNV) as nv_cv



