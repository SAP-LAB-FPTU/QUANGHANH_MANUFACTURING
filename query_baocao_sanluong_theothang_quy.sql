set statistics time on
select d.*,department.department_name as TenPhongBan,NhomTieuChi.TenNhomTieuChi from (select c.*, (Jan + Feb + March + April) as [Q1],(May + June + July + Aug) as [Q2],(Sep + Oct + Nov + [Dec]) as [Q3] from
(select MaNhomTieuChi,MaPhongBan,
SUM(Jan) as [Jan],SUM([Feb]) as [Feb],SUM([March]) as [March],SUM([April]) as [April], 
SUM([May]) as [May],SUM([June]) as [June],SUM([July]) as [July],SUM([Aug]) as [Aug], 
SUM([Sep]) as [Sep],SUM([Oct]) as [Oct],SUM([Nov]) as [Nov],SUM([Dec]) as [Dec] 
FROM (select MaNhomTieuChi, MaPhongBan,
Sum(case when a.Ngay between '2019-01-01' and '2019-01-31' then SanLuong else 0 end) as [Jan],
Sum(case when a.Ngay between '2019-02-01' and '2019-02-28' then SanLuong else 0 end) as [Feb],
Sum(case when a.Ngay between '2019-03-01' and '2019-03-31' then SanLuong else 0 end) as [March],
Sum(case when a.Ngay between '2019-04-01' and '2019-04-30' then SanLuong else 0 end) as [April],
Sum(case when a.Ngay between '2019-05-01' and '2019-05-31' then SanLuong else 0 end) as [May],
Sum(case when a.Ngay between '2019-06-01' and '2019-06-30' then SanLuong else 0 end) as [June],
Sum(case when a.Ngay between '2019-07-01' and '2019-07-31' then SanLuong else 0 end) as [July],
Sum(case when a.Ngay between '2019-08-01' and '2019-08-31' then SanLuong else 0 end) as [Aug],
Sum(case when a.Ngay between '2019-09-01' and '2019-09-30' then SanLuong else 0 end) as [Sep],
Sum(case when a.Ngay between '2019-10-01' and '2019-10-31' then SanLuong else 0 end) as [Oct],
Sum(case when a.Ngay between '2019-11-01' and '2019-11-30' then SanLuong else 0 end) as [Nov],
Sum(case when a.Ngay between '2019-12-01' and '2019-12-31' then SanLuong else 0 end) as [Dec]
from 
(select th.SanLuong,header.MaPhongBan,header.Ngay,TieuChi.MaNhomTieuChi from ThucHien_TieuChi_TheoNgay as th
inner join (select * from header_ThucHienTheoNgay where header_ThucHienTheoNgay.Ngay between '2019-01-01' and '2019-12-31' )as header 
on th.HeaderID = header.HeaderID
inner join TieuChi  
on th.MaTieuChi = TieuChi.MaTieuChi
) as a
group by  MaNhomTieuChi ,MaPhongBan) as b
group by MaNhomTieuChi, MaPhongBan) as c ) as d
inner join Department on d.MaPhongBan = Department.department_id
inner join NhomTieuChi on d.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi
order by MaPhongBan,MaNhomTieuChi
set statistics time off

select * from KeHoach_TieuChi_TheoNgay
where HeaderID = 1


select d.*,department_name,TenNhomTieuChi from (
select MaPhongBan,MaNhomTieuChi, SUM(case when c.ThangKeHoach = 1 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [Jan],
SUM(case when c.ThangKeHoach = 2 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [Feb], 
SUM(case when c.ThangKeHoach = 3 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [March], 
SUM(case when c.ThangKeHoach = 4 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [April], 
SUM(case when((c.ThangKeHoach = 4 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 1 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 2 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 3 and c.NamKeHoach = 2019)) then SanLuong else 0 end) as [Q1],
SUM(case when c.ThangKeHoach = 5 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [May], 
SUM(case when c.ThangKeHoach = 6 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [June], 
SUM(case when c.ThangKeHoach = 7 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [July], 
SUM(case when c.ThangKeHoach = 8 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [Aug], 
SUM(case when((c.ThangKeHoach = 5 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 6 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 7 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 8 and c.NamKeHoach = 2019)) then SanLuong else 0 end) as [Q2], 
SUM(case when c.ThangKeHoach = 9 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [Sep],
SUM(case when c.ThangKeHoach = 10 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [Oct],
SUM(case when c.ThangKeHoach = 11 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [Nov],
SUM(case when c.ThangKeHoach = 12 and c.NamKeHoach = 2019 then SanLuong else 0 end) as [Dec], 
SUM(case when((c.ThangKeHoach = 9 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 10 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 11 and c.NamKeHoach = 2019) or(c.ThangKeHoach = 12 and c.NamKeHoach = 2019)) then SanLuong else 0 end) as [Q3] from(
select TieuChi.MaNhomTieuChi, b.SanLuong, header.ThangKeHoach, header.NamKeHoach, header.MaPhongBan  from (
select kehoach.* from (
Select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung] from KeHoach_TieuChi_TheoThang 
group by MaTieuChi, HeaderID) as a 
inner join 
KeHoach_TieuChi_TheoThang as kehoach 
on a.HeaderID = kehoach.HeaderID and a.MaTieuChi = kehoach.MaTieuChi and a.ThoiGianNhapCuoiCung = kehoach.ThoiGianNhapCuoiCung) as b 
inner join
(select * from header_KeHoachTungThang where header_KeHoachTungThang.NamKeHoach = 2019) as header 
on header.HeaderID = b.HeaderID 
inner join TieuChi 
on TieuChi.MaTieuChi = b.MaTieuChi) as c group by MaPhongBan,MaNhomTieuChi) as d 
inner join 
Department 
on d.MaPhongBan = Department.department_id 
inner join 
NhomTieuChi 
on d.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi 
order by MaPhongBan,MaNhomTieuChi

select * from header_KeHoachTungThang
where HeaderID = 1

insert into KeHoach_TieuChi_TheoThang(HeaderID,MaTieuChi,SanLuong,ThoiGianNhapCuoiCung)
values (1,17,2000,'2019-11-1')

select * from header_ThucHienTheoNgay
where Ngay = '2019-01-01'

insert into ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong)
values (13861,17,1000)