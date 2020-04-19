------------------HÀNG THỨ 1------------------------
--1.Than hầm lò--
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 1 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 1 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--2.Than lộ thiên
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 2 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 2 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--3.Mét lò đào
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 5 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 5 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--4.Mét lò neo
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 6 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 6 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--5.Mét lò xén
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 7 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 7 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--6.Than tiêu thụ
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 9 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 9 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--7.Đá xít kho
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 11 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 11 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--8.Đất đá bóc tự làm
select a.TenNhomTieuChi, b.Ngay, a.KeHoach, b.SanLuong from  
(select ntc.TenNhomTieuChi, ht.NgayNhapKH, sum(kt.KeHoach) 'KeHoach'
from Tieuchi t
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi 
left join ( select kt.MaTieuChi, kt.HeaderID, max(kt.ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' from 
KeHoach_TieuChi_TheoNgay kt
group by kt.MaTieuChi, kt.HeaderID) as tt on t.MaTieuChi = tt.MaTieuChi
left join KeHoach_TieuChi_TheoNgay kt on tt.HeaderID = kt.HeaderID and tt.MaTieuChi = kt.MaTieuChi and tt.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung
left join header_KeHoach_TieuChi_TheoNgay ht on ht.HeaderID = tt.HeaderID 
where t.MaNhomTieuChi = 3 and (ht.NgayNhapKH between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or ht.NgayNhapKH is null) 
group by ntc.TenNhomTieuChi, ht.NgayNhapKH) as a
inner join 
(select  ntc.TenNhomTieuChi, th.Ngay, sum(tt.SanLuong) 'SanLuong'
from Tieuchi t 
left join NhomTieuChi ntc on t.MaNhomTieuChi = ntc.MaNhomTieuChi
left join ThucHien_TieuChi_TheoNgay tt on t.MaTieuChi = tt.MaTieuChi
left join header_ThucHienTheoNgay ht on ht.HeaderID = tt.HeaderID 
left join ThucHienTheoNgay th on th.NgayID = ht.NgayID
where t.MaNhomTieuChi = 3 and (th.Ngay between DATEADD(DAY,1,EOMONTH('2020-01-05',-1)) and '2020-01-05' or th.Ngay is null)
group by ntc.TenNhomTieuChi, th.Ngay) as b 
on a.TenNhomTieuChi = b.TenNhomTieuChi and a.NgayNhapKH = b.Ngay

--------------------HÀNG THỨ 2-----------------------
--------------------THAN SẢN XUẤT--------------------
select 
                        pb.MaPhongBan as 'MaPhongBan',
                        (case when th.SanLuongThucHien is null then 0 else th.SanLuongThucHien end)as 'SanLuongThucHienNgay',
                        (case when khn.SanLuongKeHoach is null then 0 else khn.SanLuongKeHoach end)as 'SanLuongKeHoachNgay',
                        (case when lk.SanLuongLuyKe is null then 0 else lk.SanLuongLuyKe end)as 'SanLuongLuyKeNgay',
                        (case when kht.SanLuongKeHoachThang is null then 0 else kht.SanLuongKeHoachThang end)as 'SanLuongKeHoachThang',
                        (case when (kht.SanLuongKeHoachThang - lk.SanLuongLuyKe) is null then 0 else (kht.SanLuongKeHoachThang - lk.SanLuongLuyKe) end) as 'SanLuongConLai',
                        (case when (th.SanLuongThucHien >= khn.SanLuongKeHoach) then N'Đạt' else N'Không đạt' end) as 'TinhTrang'
                        from 
						(select 
						hd.MaPhongBan
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kh on hd.ThangID = kh.ThangID
						join KeHoach_TieuChi_TheoThang khtc on khtc.HeaderID = hd.HeaderID
						group by hd.MaPhongBan) as pb
						LEFT JOIN
                        (select 
                        hd.MaPhongBan, 
                        (CASE WHEN SUM(tt.SanLuong) is null then 0 else SUM(tt.SanLuong) end) as 'SanLuongThucHien' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (1,2) and thn.Ngay = @Ngay
                        group by hd.MaPhongBan) as th on pb.MaPhongBan = th.MaPhongBan
                        LEFT JOIN
                        (select 
                        hd.MaPhongBan,
                        (CASE WHEN SUM(kh.KeHoach) is null then 0 else SUM(kh.KeHoach) end) as 'SanLuongKeHoach',
                        MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung'
                        from 
                        header_KeHoach_TieuChi_TheoNgay hd 
                        join KeHoach_TieuChi_TheoNgay kh on hd.HeaderID = kh.HeaderID
                        join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (1,2) and hd.NgayNhapKH = @Ngay
                        group by hd.MaPhongBan, hd.NgayNhapKH) as khn on pb.MaPhongBan = khn.MaPhongBan 
                        LEFT JOIN 
                        (select 
                        hd.MaPhongBan, 
                        (CASE WHEN SUM(tt.SanLuong) is null then 0 else SUM(tt.SanLuong) end) as 'SanLuongLuyKe' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (1,2) and thn.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay
                        group by hd.MaPhongBan) as lk on lk.MaPhongBan = pb.MaPhongBan
                        LEFT JOIN
                        (select kht.MaPhongBan,
						sum(kht.SanLuong) as 'SanLuongKeHoachThang'
						from
						(select
						hd.MaPhongBan,
						kh.SanLuong,
						ntc.TenNhomTieuChi,
						MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung' 
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kht on hd.ThangID = kht.ThangID
						join KeHoach_TieuChi_TheoThang kh on hd.HeaderID = kh.HeaderID
						join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
						join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
						where ntc.MaNhomTieuChi in (1,2) and kht.ThangKeHoach = MONTH(@Ngay) and kht.NamKeHoach = YEAR(@Ngay)
						group by hd.MaPhongBan, tc.MaTieuChi, kh.SanLuong, ntc.TenNhomTieuChi) as kht
						group by MaPhongBan) as kht on kht.MaPhongBan = pb.MaPhongBan

------------------------MÉT LÒ--------------------------
select 
                        pb.MaPhongBan as 'MaPhongBan',
                        (case when th.SanLuongThucHien is null then 0 else th.SanLuongThucHien end)as 'SanLuongThucHienNgay',
                        (case when khn.SanLuongKeHoach is null then 0 else khn.SanLuongKeHoach end)as 'SanLuongKeHoachNgay',
                        (case when lk.SanLuongLuyKe is null then 0 else lk.SanLuongLuyKe end)as 'SanLuongLuyKeNgay',
                        (case when kht.SanLuongKeHoachThang is null then 0 else kht.SanLuongKeHoachThang end)as 'SanLuongKeHoachThang',
                        (case when (kht.SanLuongKeHoachThang - lk.SanLuongLuyKe) is null then 0 else (kht.SanLuongKeHoachThang - lk.SanLuongLuyKe) end) as 'SanLuongConLai',
                        (case when (th.SanLuongThucHien >= khn.SanLuongKeHoach) then N'Đạt' else N'Không đạt' end) as 'TinhTrang'
                        from 
						(select 
						hd.MaPhongBan
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kh on hd.ThangID = kh.ThangID
						join KeHoach_TieuChi_TheoThang khtc on khtc.HeaderID = hd.HeaderID
						group by hd.MaPhongBan) as pb
						LEFT JOIN
                        (select 
                        hd.MaPhongBan, 
                        (CASE WHEN SUM(tt.SanLuong) is null then 0 else SUM(tt.SanLuong) end) as 'SanLuongThucHien' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (5,6,7) and thn.Ngay = @Ngay
                        group by hd.MaPhongBan) as th on pb.MaPhongBan = th.MaPhongBan
                        LEFT JOIN
                        (select 
                        hd.MaPhongBan,
                        (CASE WHEN SUM(kh.KeHoach) is null then 0 else SUM(kh.KeHoach) end) as 'SanLuongKeHoach',
                        MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung'
                        from 
                        header_KeHoach_TieuChi_TheoNgay hd 
                        join KeHoach_TieuChi_TheoNgay kh on hd.HeaderID = kh.HeaderID
                        join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (5,6,7) and hd.NgayNhapKH = @Ngay
                        group by hd.MaPhongBan, hd.NgayNhapKH) as khn on pb.MaPhongBan = khn.MaPhongBan 
                        LEFT JOIN 
                        (select 
                        hd.MaPhongBan, 
                        (CASE WHEN SUM(tt.SanLuong) is null then 0 else SUM(tt.SanLuong) end) as 'SanLuongLuyKe' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (5,6,7) and thn.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay
                        group by hd.MaPhongBan) as lk on lk.MaPhongBan = pb.MaPhongBan
                        LEFT JOIN
                        (select kht.MaPhongBan,
						sum(kht.SanLuong) as 'SanLuongKeHoachThang'
						from
						(select
						hd.MaPhongBan,
						kh.SanLuong,
						ntc.TenNhomTieuChi,
						MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung' 
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kht on hd.ThangID = kht.ThangID
						join KeHoach_TieuChi_TheoThang kh on hd.HeaderID = kh.HeaderID
						join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
						join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
						where ntc.MaNhomTieuChi in (5,6,7) and kht.ThangKeHoach = MONTH(@Ngay) and kht.NamKeHoach = YEAR(@Ngay)
						group by hd.MaPhongBan, tc.MaTieuChi, kh.SanLuong, ntc.TenNhomTieuChi) as kht
						group by MaPhongBan) as kht on kht.MaPhongBan = pb.MaPhongBan

-----------------ĐẤT ĐÁ----------------------
select 
                        pb.MaPhongBan as 'MaPhongBan',
                        (case when th.SanLuongThucHien is null then 0 else th.SanLuongThucHien end)as 'SanLuongThucHienNgay',
                        (case when khn.SanLuongKeHoach is null then 0 else khn.SanLuongKeHoach end)as 'SanLuongKeHoachNgay',
                        (case when lk.SanLuongLuyKe is null then 0 else lk.SanLuongLuyKe end)as 'SanLuongLuyKeNgay',
                        (case when kht.SanLuongKeHoachThang is null then 0 else kht.SanLuongKeHoachThang end)as 'SanLuongKeHoachThang',
                        (case when (kht.SanLuongKeHoachThang - lk.SanLuongLuyKe) is null then 0 else (kht.SanLuongKeHoachThang - lk.SanLuongLuyKe) end) as 'SanLuongConLai',
                        (case when (th.SanLuongThucHien >= khn.SanLuongKeHoach) then N'Đạt' else N'Không đạt' end) as 'TinhTrang'
                        from 
						(select 
						hd.MaPhongBan
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kh on hd.ThangID = kh.ThangID
						join KeHoach_TieuChi_TheoThang khtc on khtc.HeaderID = hd.HeaderID
						group by hd.MaPhongBan) as pb
						LEFT JOIN
                        (select 
                        hd.MaPhongBan, 
                        (CASE WHEN SUM(tt.SanLuong) is null then 0 else SUM(tt.SanLuong) end) as 'SanLuongThucHien' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (3,11) and thn.Ngay = @Ngay
                        group by hd.MaPhongBan) as th on pb.MaPhongBan = th.MaPhongBan
                        LEFT JOIN
                        (select 
                        hd.MaPhongBan,
                        (CASE WHEN SUM(kh.KeHoach) is null then 0 else SUM(kh.KeHoach) end) as 'SanLuongKeHoach',
                        MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung'
                        from 
                        header_KeHoach_TieuChi_TheoNgay hd 
                        join KeHoach_TieuChi_TheoNgay kh on hd.HeaderID = kh.HeaderID
                        join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (3,11) and hd.NgayNhapKH = @Ngay
                        group by hd.MaPhongBan, hd.NgayNhapKH) as khn on pb.MaPhongBan = khn.MaPhongBan 
                        LEFT JOIN 
                        (select 
                        hd.MaPhongBan, 
                        (CASE WHEN SUM(tt.SanLuong) is null then 0 else SUM(tt.SanLuong) end) as 'SanLuongLuyKe' 
                        from header_ThucHienTheoNgay hd
                        join ThucHienTheoNgay thn on hd.NgayID = thn.NgayID
                        join ThucHien_TieuChi_TheoNgay tt on hd.HeaderID = tt.HeaderID
                        join TieuChi tc on tc.MaTieuChi = tt.MaTieuChi
                        join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
                        where ntc.MaNhomTieuChi in (3,11) and thn.Ngay between DATEADD(DAY,1,EOMONTH(@Ngay,-1)) and @Ngay
                        group by hd.MaPhongBan) as lk on lk.MaPhongBan = pb.MaPhongBan
                        LEFT JOIN
                        (select kht.MaPhongBan,
						sum(kht.SanLuong) as 'SanLuongKeHoachThang'
						from
						(select
						hd.MaPhongBan,
						kh.SanLuong,
						ntc.TenNhomTieuChi,
						MAX(kh.ThoiGianNhapCuoiCung) as 'ThoiGianNhapCuoiCung' 
						from header_KeHoachTungThang hd 
						join KeHoachTungThang kht on hd.ThangID = kht.ThangID
						join KeHoach_TieuChi_TheoThang kh on hd.HeaderID = kh.HeaderID
						join TieuChi tc on tc.MaTieuChi = kh.MaTieuChi
						join NhomTieuChi ntc on tc.MaNhomTieuChi = ntc.MaNhomTieuChi
						where ntc.MaNhomTieuChi in (3,11) and kht.ThangKeHoach = MONTH(@Ngay) and kht.NamKeHoach = YEAR(@Ngay)
						group by hd.MaPhongBan, tc.MaTieuChi, kh.SanLuong, ntc.TenNhomTieuChi) as kht
						group by MaPhongBan) as kht on kht.MaPhongBan = pb.MaPhongBan

---------------------------------------------------------------------------------------------------------------------------------
--Lũy kế tháng trong năm / kế hoạch năm
select
kh.MaTieuChi,
(case when lk.LUYKE is null then 0 else lk.LUYKE end) as 'LUYKE', 
(case when kh.KH is null then 0 else kh.KH end) as 'KH'
from
(select MaTieuChi, sum(SanLuong) as 'LUYKE' from ThucHien_TieuChi_TheoNgay as th
join (select tht.*,hth.MaPhongBan,hth.HeaderID from header_ThucHienTheoNgay hth 
join ThucHienTheoNgay tht on hth.NgayID = tht.NgayID and Month(Ngay) between 1  and Month('2020-04-01')) as h on th.HeaderID = h.HeaderID
group by MaTieuChi) as lk
LEFT OUTER JOIN
(select a.MaTieuChi, sum(kt.SanLuongKeHoach) 'KH'
from(select  kt.HeaderID, hkt.MaPhongBan, hkt.Nam,kt.MaTieuChi,max(ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung'
from KeHoach_TieuChi_TheoNam kt inner join header_KeHoach_TieuChi_TheoNam hkt on kt.HeaderID = hkt.HeaderID
where hkt.Nam = Year('2020-04-01')
group by kt.HeaderID, hkt.MaPhongBan, hkt.Nam, kt.MaTieuChi) as a 
inner join KeHoach_TieuChi_TheoNam kt on a.HeaderID = kt.HeaderID and a.ThoiGianNhapCuoiCung = kt.ThoiGianNhapCuoiCung and a.MaTieuChi = kt.MaTieuChi
group by a.MaTieuChi) as kh on lk.MaTieuChi = kh.MaTieuChi