create VIEW view2 AS
select *,(table2.TH-table2.KH) as [CHENHLECH],(CASE WHEN KH =0 THEN 100 ELSE ROUND(TH*100/KH,0) end) as [PERCENTAGE],
0.0 as [KHDC], 0.0 as [percentDC],0.0 as [SUM],0.0 as [perday], 0.0 as [BQKHDC],0.0 as [VATLIEUCHONG],0.0 AS [DIENTICHDAO],0.0 as [BC],0.0 AS [CT]
from (select MaTieuChi,TenTieuChi, 
Sum(case when ca=1 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA1],
Sum(case when ca=2 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA2],
Sum(case when ca=3 and Ngay = '2019-09-10' then SanLuong else 0  end )as [CA3],
Sum(case when Ngay = '2019-09-10' then SanLuong else 0  end )as [TH],
Sum(case when Ngay = '2019-09-10' then KeHoach else 0  end )as [KH],
SUM(SanLuong) as [LUYKE]
from (select thuchien.HeaderID,thuchien.MaTieuChi,TieuChi.TenTieuChi,thuchien.SanLuong,thuchien.KeHoach,header_th.Ca,header_th.Ngay,px.department_id,px.isInside from ThucHien_TieuChi_TheoNgay as thuchien
inner JOIN header_ThucHienTheoNgay as header_th 
    on thuchien.HeaderID = header_th.HeaderID and header_th.Ngay >= '2019-09-1' and header_th.Ngay <= '2019-09-10' 
INNER JOIN Department as px on px.department_id = header_th.MaPhongBan
INNER JOIN TieuChi on thuchien.MaTieuChi = TieuChi.MaTieuChi) as a 
GROUP BY MaTieuChi,TenTieuChi) as table2
ORDER By MaTieuChi

SELECT c.name,
       t.name,
       c.max_length,
       c.precision,
       c.scale
FROM   sys.columns c
       JOIN sys.types t
         ON t.user_type_id = c.user_type_id
            AND t.system_type_id = c.system_type_id
WHERE  object_id = OBJECT_ID('view1') 