using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.BGD.ReportHuman.Summary
{
    public class Human_Department_DailyController : Controller
    {
        [Route("ban-giam-doc/bao-cao-nhan-luc/bao-cao-tong-hop-nhan-theo-phan-xuong-theo-ngay")]
        public ActionResult Index()
        {
            return View("/Views/BGD/ReportHuman/Summary/Human_Department_Daily.cshtml");
        }

        [Route("ban-giam-doc/bao-cao-nhan-luc/bao-cao-tong-hop-nhan-theo-phan-xuong-theo-ngay/lay-du-lieu")]
        public ActionResult ProcessRequest()
        {
            string dateYear = Request["year"];
            return getData(dateYear);
        }

        public ActionResult getData(string date)
        {
            try
            {
                DateTime dateConverted = ConvertString(date);
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                string[] listDepartment = new string[] { "KT1", "KT2", "KT3"
                , "KT4", "KT5", "KT6", "KT7", "KT8"
                , "KT9", "KT10", "KT11" , "VTL1", "VTL2"
                , "ĐL1", "ĐL2", "ĐL3" , "ĐL5", "ĐL7" ,"ĐL8"
                , "PV" , "ĐS" , "PXCBT" , "TG-QLKM", "CĐM" , "CKSC"};

                string query_KT_CD = @"select DiLam , TenNhomCongViec , MaPhongBan , count(*) as SoLuong
                    from 
                    (select d.MaNV, max(convert(int,d.DiLam)) as DiLam  from 
                    (select Min(hd.HeaderID) as 'HeaderID'
                    from Header_DiemDanh_NangSuat_LaoDong hd 
                    where hd.NgayDiemDanh = @date and hd.Status = 1
                    group by hd.Ca) as headerIDtbl
                    left join DiemDanh_NangSuatLaoDong d on headerIDtbl.HeaderID = d.HeaderID group by d.MaNV) as tb1
                    inner join 
                    (select nv.MaNV,ncv.MaNhomCongViec,ncv.TenNhomCongViec,nv.MaPhongBan from NhanVien nv 
                    left join CongViec cv on nv.MaCongViec = cv.MaCongViec 
                    left join CongViec_NhomCongViec cv_ncv on cv.MaCongViec = cv_ncv.MaCongViec
                    join NhomCongViec ncv on ncv.MaNhomCongViec = cv_ncv.MaNhomCongViec
                    where nv.MaTrangThai != 2) tb2 on tb1.MaNV = tb2.MaNV
                    where MaNhomCongViec = 6 or MaNhomCongViec = 7
                    group by DiLam , TenNhomCongViec , MaPhongBan";

                string query_MB_QL = @"select * , count(*) as SoLuong
                    from
                    (select DiLam,MaPhongBan,
                    (case 
	                    when ( (MaPhongBan in (N'ĐS', N'PV', N'XD', N'CKCS', N'PXCBT')) or
	                    TenCongViec in (N'(Công nhân) Bắn mìn lộ thiên', N'(Công nhân) Sửa chữa cơ điện trên các mỏ lộ thiên',
		                    N'Công nhân vận hành trạm cảnh báo khí, gió mỏ',N'Công nhân lao động phổ thông',
		                    N'Công nhân trực thông tin',
		                    N'(Công nhân) vận hành, bảo trì trạm biến thế trung thế')) then 1
	                    when (TenCongViec in (N'Giám Đốc', N'Phó giám đốc', N'Trưởng phòng', N'Phó trưởng phòng', N'Chuyên viên',
		                    N'Cán sự')) then 2
	                    else 0
                    end) as TruongHop
                    from 
                    (select d.MaNV, max(convert(int,d.DiLam)) as DiLam  from 
                    (select 
                    Min(hd.HeaderID) as 'HeaderID'
                    from Header_DiemDanh_NangSuat_LaoDong hd 
                    where hd.NgayDiemDanh = @date and hd.Status = 1
                    group by hd.Ca) as headerIDtbl
                    left join DiemDanh_NangSuatLaoDong d on headerIDtbl.HeaderID = d.HeaderID 
                    group by d.MaNV) as tb1
                    inner join 
                    (select nv.MaNV , nv.MaPhongBan,cv.TenCongViec from NhanVien nv
                    left join CongViec cv on nv.MaCongViec = cv.MaCongViec 
                    where nv.MaTrangThai = 1) tb2 on tb1.MaNV = tb2.MaNV) tb3
                    where tb3.TruongHop != 0
                    group by DiLam, MaPhongBan , TruongHop";

                List<Result> listDataReturn = new List<Result>();
                foreach (string departmentName in listDepartment)
                {
                    listDataReturn.Add(new Result(departmentName, 0, 0, 0, 0, 0, 0, 0, 0));
                }

                List<DataDB_KT_CD> data_KT_CD = db.Database.SqlQuery<DataDB_KT_CD>(query_KT_CD,new SqlParameter("date", dateConverted)).ToList();
                List<DataDB_MB_QL> data_MB_QL = db.Database.SqlQuery<DataDB_MB_QL>(query_MB_QL, new SqlParameter("date", dateConverted)).ToList();

                //Adding dataReturn from db
                //KT_CD
                foreach (var item in data_KT_CD)
                {
                    Result dataReturn = listDataReturn.Find(x => (x.Department_Name.Equals(item.MaPhongBan)));
                    if (dataReturn != null)
                    {
                        if (item.TenNhomCongViec.Equals("Công nhân khai thác"))
                        {
                            if (item.Dilam == 1)
                            {
                                dataReturn.Dilam_KT = item.SoLuong;
                            }
                            else
                            {
                                dataReturn.Nghi_KT = item.SoLuong;
                            }
                        }
                        else if (item.TenNhomCongViec.Equals("Công nhân cơ điện"))
                        {
                            if (item.Dilam == 1)
                            {
                                dataReturn.Dilam_CD = item.SoLuong;
                            }
                            else
                            {
                                dataReturn.Nghi_CD = item.SoLuong;
                            }
                        }
                    }
                }

                //MB_QL
                foreach (var item in data_MB_QL)
                {
                    Result dataReturn = listDataReturn.Find(x => (x.Department_Name.Equals(item.MaPhongBan)));
                    if (dataReturn != null)
                    {
                        if (item.TruongHop == 1)
                        {
                            if (item.Dilam == 1)
                            {
                                dataReturn.Dilam_MB = item.SoLuong;
                            }
                            else
                            {
                                dataReturn.Nghi_MB = item.SoLuong;
                            }
                        }
                        else if (item.TruongHop == 2)
                        {
                            if (item.Dilam == 1)
                            {
                                dataReturn.Dilam_QLPB = item.SoLuong;
                            }
                            else
                            {
                                dataReturn.Nghi_QLPB = item.SoLuong;
                            }
                        }
                    }
                }

                //Result dataReturn = listDataReturn.Find(x => (x.Department_Name.Equals("KT1")));
                return Json(new { success = true, listDepartment = listDataReturn, date = date }, JsonRequestBehavior.AllowGet);
            } 
            catch (Exception e) 
            {
                //throw e;
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }  
        }

        private DateTime ConvertString(string date)
        {
            string[] data = new string[4];
            if (date != null)
            {
                data = date.Split('/');
                date = data[2] + "-" + data[1] + "-" + data[0];
            }
            else
            {
                DateTime d = DateTime.Today;
                date = d.ToString("dd/MM/yyyy");
                data = date.Split('/');
                date = data[2] + "-" + data[1] + "-" + data[0];
            }
            DateTime timeConverted = Convert.ToDateTime(date);
            return timeConverted;
        }
    }

    public class Result
    {
        public Result()
        {

        }

        public Result(string name , int DilamKT, int NghiKT, int DilamCD, int NghiCD, int DilamMB, int NghiMB , int DilamQLPB, int NghiQLPB)
        {
            this.Department_Name = name;
            this.Dilam_KT = DilamKT;
            this.Nghi_KT = NghiKT;
            this.Dilam_CD = DilamCD;
            this.Nghi_CD = NghiCD;
            this.Dilam_MB = DilamMB;
            this.Nghi_MB = NghiMB;
            this.Dilam_QLPB = DilamQLPB;
            this.Nghi_QLPB = NghiQLPB;
        }

        public string Department_Name { get; set; }

        public int Dilam_KT{ get; set; }

        public int Nghi_KT { get; set; }

        public int Dilam_CD { get; set; }

        public int Nghi_CD { get; set; }

        public int Dilam_MB { get; set; }

        public int Nghi_MB { get; set; }

        public int Dilam_QLPB { get; set; }

        public int Nghi_QLPB { get; set; }
    }

    public class DataDB_KT_CD
    {
        public int Dilam { get; set; }
        public string TenNhomCongViec { get; set; }
        public string MaPhongBan { get; set; }
        public int SoLuong { get; set; }
    }

    public class DataDB_MB_QL
    {
        public int Dilam { get; set; }
        public string MaPhongBan { get; set; }
        public int TruongHop { get; set; }
        public int SoLuong { get; set; }
    }

}