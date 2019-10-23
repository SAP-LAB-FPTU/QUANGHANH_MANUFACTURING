select TieuChi.MaTieuChi,TieuChi.TenTieuChi, TieuChi.MaNhomTieuChi,NhomTieuChi.TenNhomTieuChi,MaPhongBan,(
Case when CA1 IS NULL then CONVERT(float, 0) else CA1 end) as [CA1],(Case when CA2 IS NULL then CONVERT(float,0) else CA2 end) as [CA2], 
(Case when CA3 IS NULL then CONVERT(float,0) else CA3 end) as [CA3], (Case when TH IS NULL then CONVERT(float,0) else TH end) as TH, 
(Case when LUYKE IS NULL then CONVERT(float,0) else LUYKE end) as LUYKE, (Case when KH IS NULL then CONVERT(float,0) else KH end) as KH, 
(Case when CHENHLECH IS NULL then CONVERT(float,0) else CHENHLECH end) as [CHENHLECH], (Case when[PERCENTAGE] IS NULL then CONVERT(float,0) else [PERCENTAGE] end) as [PERCENTAGE], 
(Case when KHDC IS NULL then CONVERT(float,0) else KHDC end) as KHDC, (Case when percentDC IS NULL then 0 else percentDC end) as percentDC, (Case when LUYKE IS NULL then 0 else LUYKE end) as LUYKE, 
(Case when KH IS NULL then 0 else KH end) as KH from TieuChi 
left join (select * ,CONVERT(float, 0) as [KH],CONVERT(float, 0) as [CHENHLECH],CONVERT(float, 0) as [PERCENTAGE], CONVERT(float, 0) as [KHDC], 
CONVERT(float, 0) as [percentDC], CONVERT(float, 0) as [SUM], CONVERT(float, 0) as [perday],  CONVERT(float, 0) as [BQKHDC] from(select MaTieuChi, 
MaPhongBan, Sum(case when ca = 1 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA1], Sum(case when ca = 2 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA2], 
Sum(case when ca = 3 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA3], Sum(case when Ngay = '2019-09-10' then SanLuong else 0  end )as [TH],  SUM(SanLuong) as [LUYKE] 
from(select header_th.MaPhongBan, thuchien.HeaderID, thuchien.MaTieuChi, thuchien.SanLuong, header_th.Ca, header_th.Ngay, px.department_id, px.isInside from ThucHien_TieuChi_TheoNgay as thuchien 
inner JOIN header_ThucHienTheoNgay as header_th on thuchien.HeaderID = header_th.HeaderID and header_th.Ngay >= '2019-09-01' and header_th.Ngay <= '2019-09-10' 
INNER JOIN Department as px on px.department_id = header_th.MaPhongBan) as a GROUP BY MaTieuChi,MaPhongBan) as table2 ) as table3 on table3.MaTieuChi = TieuChi.MaTieuChi
inner join NhomTieuChi on TieuChi.MaNhomTieuChi = NhomTieuChi.MaNhomTieuChi order by MaTieuChi