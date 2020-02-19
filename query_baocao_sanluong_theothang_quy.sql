set statistics time on
select d.*,department.department_name as TenPhongBan,NhomTieuChi.TenNhomTieuChi from (
select c.*, (Jan + Feb + March + April) as [Q1],(May + June + July + Aug) as [Q2],(Sep + Oct + Nov + [Dec]) as [Q3] from
(select MaNhomTieuChi,MaPhongBan,
SUM(Jan) as [Jan],SUM([Feb]) as [Feb],SUM([March]) as [March],SUM([April]) as [April], 
SUM([May]) as [May],SUM([June]) as [June],SUM([July]) as [July],SUM([Aug]) as [Aug], 
SUM([Sep]) as [Sep],SUM([Oct]) as [Oct],SUM([Nov]) as [Nov],SUM([Dec]) as [Dec] 
FROM (select MaNhomTieuChi, MaPhongBan,
Sum(case when a.Ngay between '2020-01-01' and '2020-01-31' then SanLuong else 0 end) as [Jan],
Sum(case when a.Ngay between '2020-02-01' and '2020-02-29' then SanLuong else 0 end) as [Feb],
Sum(case when a.Ngay between '2020-03-01' and '2020-03-31' then SanLuong else 0 end) as [March],
Sum(case when a.Ngay between '2020-04-01' and '2020-04-30' then SanLuong else 0 end) as [April],
Sum(case when a.Ngay between '2020-05-01' and '2020-05-31' then SanLuong else 0 end) as [May],
Sum(case when a.Ngay between '2020-06-01' and '2020-06-30' then SanLuong else 0 end) as [June],
Sum(case when a.Ngay between '2020-07-01' and '2020-07-31' then SanLuong else 0 end) as [July],
Sum(case when a.Ngay between '2020-08-01' and '2020-08-31' then SanLuong else 0 end) as [Aug],
Sum(case when a.Ngay between '2020-09-01' and '2020-09-30' then SanLuong else 0 end) as [Sep],
Sum(case when a.Ngay between '2020-10-01' and '2020-10-31' then SanLuong else 0 end) as [Oct],
Sum(case when a.Ngay between '2020-11-01' and '2020-11-30' then SanLuong else 0 end) as [Nov],
Sum(case when a.Ngay between '2020-12-01' and '2020-12-31' then SanLuong else 0 end) as [Dec]
from 
(select th.SanLuong,header.MaPhongBan,header.Ngay,TieuChi.MaNhomTieuChi from ThucHien_TieuChi_TheoNgay as th
inner join (select * from header_ThucHienTheoNgay where header_ThucHienTheoNgay.Ngay between '2020-01-01' and '2020-12-31' )as header 
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

select * from header_KeHoachTungThang

select * from KeHoach_TieuChi_TheoThang

select tmp5.*,Department.department_name as TenPhongBan,NhomTieuChi.TenNhomTieuChi from (
select tmp4.*, (Jan + Feb + March + April) as [Q1],(May + June + July + Aug) as [Q2],(Sep + Oct + Nov + [Dec]) as [Q3],(Jan + Feb + March + April + May + June + July + Aug + Sep + Oct + Nov + [Dec]) as [totalYear]  from
(select MaNhomTieuChi,MaPhongBan,
SUM(Jan) as [Jan],SUM([Feb]) as [Feb],SUM([March]) as [March],SUM([April]) as [April], 
SUM([May]) as [May],SUM([June]) as [June],SUM([July]) as [July],SUM([Aug]) as [Aug], 
SUM([Sep]) as [Sep],SUM([Oct]) as [Oct],SUM([Nov]) as [Nov],SUM([Dec]) as [Dec]
FROM(
select MaNhomTieuChi, MaPhongBan,
Sum(case when tmp2.Ngay between '2020-01-01' and '2020-01-31' then SanLuong else 0 end) as [Jan],
Sum(case when tmp2.Ngay between '2020-02-01' and '2020-02-29' then SanLuong else 0 end) as [Feb],
Sum(case when tmp2.Ngay between '2020-03-01' and '2020-03-31' then SanLuong else 0 end) as [March],
Sum(case when tmp2.Ngay between '2020-04-01' and '2020-04-30' then SanLuong else 0 end) as [April],
Sum(case when tmp2.Ngay between '2020-05-01' and '2020-05-31' then SanLuong else 0 end) as [May],
Sum(case when tmp2.Ngay between '2020-06-01' and '2020-06-30' then SanLuong else 0 end) as [June],
Sum(case when tmp2.Ngay between '2020-07-01' and '2020-07-31' then SanLuong else 0 end) as [July],
Sum(case when tmp2.Ngay between '2020-08-01' and '2020-08-31' then SanLuong else 0 end) as [Aug],
Sum(case when tmp2.Ngay between '2020-09-01' and '2020-09-30' then SanLuong else 0 end) as [Sep],
Sum(case when tmp2.Ngay between '2020-10-01' and '2020-10-31' then SanLuong else 0 end) as [Oct],
Sum(case when tmp2.Ngay between '2020-11-01' and '2020-11-30' then SanLuong else 0 end) as [Nov],
Sum(case when tmp2.Ngay between '2020-12-01' and '2020-12-31' then SanLuong else 0 end) as [Dec]
from (
select tmp1.* , TieuChi.MaNhomTieuChi from
(select mutualCitirias.MaPhongBan,mutualCitirias.MaTieuChi,
(Case when performance.Ngay IS NULL then '2019-01-01' else performance.Ngay end) as [Ngay],
(Case when performance.SanLuong IS NULL then 0 else performance.SanLuong end) as [SanLuong] from
(select distinct MaTieuChi,MaPhongBan from ThucHien_TieuChi_TheoNgay as a
inner join (select * from header_ThucHienTheoNgay where Ngay  between '2020-01-01' and '2020-12-31') as b
on a.HeaderID = b.HeaderID
union
select distinct MaTieuChi,MaPhongBan from PhongBan_TieuChi
where Nam = 2020
union
select distinct MaTieuChi,MaPhongBan from (select * from header_KeHoach_TieuChi_TheoNam where Nam = 2020) as c
inner join (select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan inner join (
select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam
group by HeaderID,MaTieuChi ) as maxTime
on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as d
on c.HeaderID = d.HeaderID) mutualCitirias
left join
(select MaPhongBan,Ngay,MaTieuChi,SanLuong from
(select * from header_ThucHienTheoNgay where Ngay  between '2020-01-01' and '2020-12-31') as header
left join 
ThucHien_TieuChi_TheoNgay on ThucHien_TieuChi_TheoNgay.HeaderID = header.HeaderID) as performance
on mutualCitirias.MaPhongBan = performance.MaPhongBan and mutualCitirias.MaTieuChi = performance.MaTieuChi) as tmp1
inner join TieuChi  
on tmp1.MaTieuChi = TieuChi.MaTieuChi) as tmp2
group by MaNhomTieuChi, MaPhongBan ) as tmp3
group by MaNhomTieuChi, MaPhongBan) as tmp4 ) as tmp5
inner join Department on tmp5.MaPhongBan = Department.department_id
inner join NhomTieuChi on tmp5.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi
order by MaPhongBan,MaNhomTieuChi


select * from KeHoach_TieuChi_TheoNam

select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan inner join (
select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam
group by HeaderID,MaTieuChi ) as maxTime
on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung

select * from header_KeHoach_TieuChi_TheoNgay
##
select MaPhongBan,MaNhomTieuChi,
SUM(case when tmp6.ThangKeHoach = 1 then SanLuong else 0 end) as [Jan],SUM(case when tmp6.ThangKeHoach = 2 then SanLuong else 0 end) as [Feb], 
SUM(case when tmp6.ThangKeHoach = 3 then SanLuong else 0 end) as [March], SUM(case when tmp6.ThangKeHoach = 4 then SanLuong else 0 end) as [April], 
SUM(case when((tmp6.ThangKeHoach = 4) or(tmp6.ThangKeHoach = 1) or(tmp6.ThangKeHoach = 2) or(tmp6.ThangKeHoach = 3)) then SanLuong else 0 end) as [Q1],
SUM(case when tmp6.ThangKeHoach = 5 then SanLuong else 0 end) as [May], SUM(case when tmp6.ThangKeHoach = 6 then SanLuong else 0 end) as [June],
SUM(case when tmp6.ThangKeHoach = 7 then SanLuong else 0 end) as [July], SUM(case when tmp6.ThangKeHoach = 8 then SanLuong else 0 end) as [Aug], 
SUM(case when((tmp6.ThangKeHoach = 5) or(tmp6.ThangKeHoach = 6) or(tmp6.ThangKeHoach = 7) or(tmp6.ThangKeHoach = 8)) then SanLuong else 0 end) as [Q2], 
SUM(case when tmp6.ThangKeHoach = 9 then SanLuong else 0 end) as [Sep],SUM(case when tmp6.ThangKeHoach = 10 then SanLuong else 0 end) as [Oct],
SUM(case when tmp6.ThangKeHoach = 11 then SanLuong else 0 end) as [Nov],SUM(case when tmp6.ThangKeHoach = 12 then SanLuong else 0 end) as [Dec], 
SUM(case when((tmp6.ThangKeHoach = 9) or(tmp6.ThangKeHoach = 10) or(tmp6.ThangKeHoach = 11) or(tmp6.ThangKeHoach = 12)) then SanLuong else 0 end) as [Q3]
from
(select MaPhongBan,SanLuong,ThangKeHoach,MaNhomTieuChi from
(select tmp3.MaPhongBan,tmp3.MaTieuChi,(case when tmp4.SanLuong is null then 0 else tmp4.SanLuong end) as [SanLuong],(case when tmp4.ThangKeHoach is null then 1 else tmp4.ThangKeHoach end) as [ThangKeHoach] from(
select distinct MaTieuChi,MaPhongBan from ThucHien_TieuChi_TheoNgay as a
inner join (select * from header_ThucHienTheoNgay where Ngay  between '2020-01-01' and '2020-12-31') as b
on a.HeaderID = b.HeaderID
union
select distinct MaTieuChi,MaPhongBan from PhongBan_TieuChi
where Nam = 2020
union
select distinct MaTieuChi,MaPhongBan from (select * from header_KeHoach_TieuChi_TheoNam where Nam = 2020) as c
inner join (select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan inner join (
select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam
group by HeaderID,MaTieuChi ) as maxTime
on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as d
on c.HeaderID = d.HeaderID) as tmp3
left join
(select MaPhongBan,MaTieuChi,SanLuong,ThangKeHoach from
(select monthlyplan.* from 
KeHoach_TieuChi_TheoThang as monthlyplan inner join (
select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoThang
group by HeaderID,MaTieuChi ) as maxTime
on monthlyplan.HeaderID = maxTime.HeaderID and monthlyplan.MaTieuChi = maxTime.MaTieuChi and monthlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as tmp1
inner join 
(select * from header_KeHoachTungThang where NamKeHoach = 2020) as tmp2
on tmp1.HeaderID = tmp2.HeaderID) as tmp4
on tmp3.MaPhongBan = tmp4.MaPhongBan and tmp3.MaTieuChi = tmp4.MaTieuChi) as tmp5 
inner join TieuChi on tmp5.MaTieuChi = TieuChi.MaTieuChi) as tmp6
group by MaPhongBan,MaNhomTieuChi

select * from header_KeHoachTungThang

SUM(case when c.ThangKeHoach = 1 then SanLuong else 0 end) as [Jan],SUM(case when c.ThangKeHoach = 2 then SanLuong else 0 end) as [Feb], 
SUM(case when c.ThangKeHoach = 3 then SanLuong else 0 end) as [March], SUM(case when c.ThangKeHoach = 4 then SanLuong else 0 end) as [April], 
SUM(case when((c.ThangKeHoach = 4) or(c.ThangKeHoach = 1) or(c.ThangKeHoach = 2) or(c.ThangKeHoach = 3)) then SanLuong else 0 end) as [Q1],
SUM(case when c.ThangKeHoach = 5 then SanLuong else 0 end) as [May], SUM(case when c.ThangKeHoach = 6 then SanLuong else 0 end) as [June], S
UM(case when c.ThangKeHoach = 7 then SanLuong else 0 end) as [July], SUM(case when c.ThangKeHoach = 8 then SanLuong else 0 end) as [Aug], 
SUM(case when((c.ThangKeHoach = 5) or(c.ThangKeHoach = 6) or(c.ThangKeHoach = 7) or(c.ThangKeHoach = 8)) then SanLuong else 0 end) as [Q2], 
SUM(case when c.ThangKeHoach = 9 then SanLuong else 0 end) as [Sep],SUM(case when c.ThangKeHoach = 10 then SanLuong else 0 end) as [Oct],
SUM(case when c.ThangKeHoach = 11 then SanLuong else 0 end) as [Nov],SUM(case when c.ThangKeHoach = 12 then SanLuong else 0 end) as [Dec], 
SUM(case when((c.ThangKeHoach = 9) or(c.ThangKeHoach = 10) or(c.ThangKeHoach = 11) or(c.ThangKeHoach = 12)) then SanLuong else 0 end) as [Q3]


select * from Department
where department_type = N'Phân xưởng sản xuất chính'

select * from KeHoach_TieuChi_TheoNam


Select MaPhongBan,MaNhomTieuChi,SUM(SanLuong) as [SanLuong] from
(select MaPhongBan,TieuChi.MaNhomTieuChi,SanLuong from (
select tmp3.MaTieuChi,tmp3. MaPhongBan,(Case when SanLuong IS NULL then 0 else SanLuong end) as [SanLuong] from
(select distinct MaTieuChi,MaPhongBan from ThucHien_TieuChi_TheoNgay as a
inner join (select * from header_ThucHienTheoNgay where Ngay  between '2020-01-01' and '2020-12-31') as b
on a.HeaderID = b.HeaderID
union
select distinct MaTieuChi,MaPhongBan from PhongBan_TieuChi
where Nam = 2020
union
select distinct MaTieuChi,MaPhongBan from (select * from header_KeHoach_TieuChi_TheoNam where Nam = 2020) as c
inner join (select yearlyplan.* from KeHoach_TieuChi_TheoNam as yearlyplan inner join (
select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam
group by HeaderID,MaTieuChi ) as maxTime
on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as d
on c.HeaderID = d.HeaderID ) as tmp3
left join
(select MaPhongBan,MaTieuChi,[SanLuongKeHoach] as [SanLuong] from
(select yearlyplan.* from 
KeHoach_TieuChi_TheoNam as yearlyplan inner join (
select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  from KeHoach_TieuChi_TheoNam
group by HeaderID,MaTieuChi ) as maxTime
on yearlyplan.HeaderID = maxTime.HeaderID and yearlyplan.MaTieuChi = maxTime.MaTieuChi and yearlyplan.ThoiGianNhapCuoiCung = maxTime.ThoiGianNhapCuoiCung) as tmp1
inner join 
(select * from header_KeHoach_TieuChi_TheoNam where Nam = 2020) as tmp2
on tmp1.HeaderID = tmp2.HeaderID) as tmp4
on tmp3.MaPhongBan = tmp4.MaPhongBan and tmp3.MaTieuChi = tmp4.MaTieuChi ) as tmp5
inner join TieuChi on
tmp5.MaTieuChi = TieuChi.MaTieuChi ) as tmp6
group by MaPhongBan,MaNhomTieuChi

select * from header_KeHoach_TieuChi_TheoNam