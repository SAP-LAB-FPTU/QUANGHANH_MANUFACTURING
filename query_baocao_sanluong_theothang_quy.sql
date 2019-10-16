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