  select d.*,department_name,TenNhomTieuChi from (select MaPhongBan,MaNhomTieuChi,
  SUM(case when c.ThangKeHoach =1 then SanLuong else 0 end) as [Jan],
  SUM(case when c.ThangKeHoach =2 then SanLuong else 0 end) as [Feb],
  SUM(case when c.ThangKeHoach =3 then SanLuong else 0 end) as [March],
  SUM(case when c.ThangKeHoach =4 then SanLuong else 0 end) as [April],
  SUM(case when ((c.ThangKeHoach =4) or (c.ThangKeHoach =1) or (c.ThangKeHoach =2) or (c.ThangKeHoach =3)) then SanLuong else 0 end) as [Q1],
  SUM(case when c.ThangKeHoach =5 then SanLuong else 0 end) as [May],
  SUM(case when c.ThangKeHoach =6 then SanLuong else 0 end) as [June],
  SUM(case when c.ThangKeHoach =1 then SanLuong else 0 end) as [July],
  SUM(case when c.ThangKeHoach =2 then SanLuong else 0 end) as [Aug],
  SUM(case when ((c.ThangKeHoach =5) or (c.ThangKeHoach =6) or (c.ThangKeHoach =7) or (c.ThangKeHoach =8)) then SanLuong else 0 end) as [Q2],
  SUM(case when c.ThangKeHoach =3 then SanLuong else 0 end) as [Sep],
  SUM(case when c.ThangKeHoach =4 then SanLuong else 0 end) as [Oct],
  SUM(case when c.ThangKeHoach =5 then SanLuong else 0 end) as [Nov],
  SUM(case when c.ThangKeHoach =6 then SanLuong else 0 end) as [Dec],
  SUM(case when ((c.ThangKeHoach =9) or (c.ThangKeHoach =10) or (c.ThangKeHoach =11) or (c.ThangKeHoach =12)) then SanLuong else 0 end) as [Q3]
  from (select TieuChi.MaNhomTieuChi,b.SanLuong,header.ThangKeHoach,header.NamKeHoach,header.MaPhongBan  from
  (select kehoach.* from
  (Select HeaderID,MaTieuChi,Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung]  
  from KeHoach_TieuChi_TheoThang
  group by MaTieuChi,HeaderID) as a 
  inner join KeHoach_TieuChi_TheoThang as kehoach
  on a.HeaderID = kehoach.HeaderID and a.MaTieuChi = kehoach.MaTieuChi and a.ThoiGianNhapCuoiCung = kehoach.ThoiGianNhapCuoiCung) as b
  inner join (select * from header_KeHoachTungThang where header_KeHoachTungThang.NamKeHoach=2019) as header on header.HeaderID = b.HeaderID
  inner join TieuChi on TieuChi.MaTieuChi = b.MaTieuChi) as c
  group by MaPhongBan,MaNhomTieuChi) as d
  inner join Department on d.MaPhongBan = Department.department_id
  inner join NhomTieuChi on d.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi
  order by MaPhongBan,MaNhomTieuChi