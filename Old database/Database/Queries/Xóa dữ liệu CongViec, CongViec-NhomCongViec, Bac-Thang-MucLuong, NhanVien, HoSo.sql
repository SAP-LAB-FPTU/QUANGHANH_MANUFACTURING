EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
--Xóa bảng Bậc,thang,mức lương
delete from BacLuong_ThangLuong_MucLuong

--Xóa bảng Thang Lương
delete from ThangLuong

--Xóa bảng Bậc Lương
delete from BacLuong

--Xóa bảng Công việc-Nhóm Công Việc
delete from CongViec_NhomCongViec

--Xóa bảng Công việc
delete from CongViec

--Xóa bảng Nhân viên
delete from NhanVien

--Xóa bảng Hồ sơ
delete from HoSo
EXEC sp_MSforeachtable "ALTER TABLE ? CHECK CONSTRAINT all"

