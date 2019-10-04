using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using QUANGHANHCORE.Controllers.PX.PXKT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class TCLDController : Controller
    {

        // GET: /<controller>/
        [Auther(RightID="002")]
        [Route("phong-tcld")]
        public ActionResult Dashboard()
        {
            int soLuotHuyDong = 0;
            int vuTaiNan = 0;
            int nghiVLD = 0;
            int hetHanChungChi = 0;
            int tren82=0;
            int duoi82=0;
            List<NghiVLD> listNghiVLD = new List<NghiVLD>();
            int temp = 0;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                ////////////////////////////GET so luot huy dong////////////////////////////////
                string sql = "select count(MaQuyetDinh) as SoLuotHuyDong from quyetdinh\n" +
                "where maquyetdinh in\n" +
                "(SELECT  distinct MaQuyetDinh FROM DIEUDONG_NHANVIEN)\n" +
                "AND NgayQuyetDinh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))";
                temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                soLuotHuyDong = temp != null ? temp : 0;

                ////////////////////////////GET SO LUONG TAI NAN///////////////////////////////////////////
                sql = "select Count(tn.MaNV)  from \n" +
                      "(select MaNV, Ngay from TaiNan where\n" +
                      "Ngay = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))) as tn";
                temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                vuTaiNan = temp != null ? temp : 0;

                ///////////////////////////////GET SO LUONG HET HAN CC///////////////////////////////////////////
                sql = "select sum(th.st) \n" +
                      "from(select cn.MaNV, cn.NgayCap, cc.ThoiHan, (case\n" +
                      "when DATEADD(MONTH, cc.ThoiHan, cn.NgayCap) <= GETDATE()\n" +
                      "then 1 else 0 end) as st\n" +
                      "from ChungChi_NhanVien cn join ChungChi cc on cn.MaChungChi = cc.MaChungChi) as th";
                temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                hetHanChungChi = temp!=null?temp:0;

                ////////////////////////////GET SO LUONG NGHI VLD///////////////////////////////////////////
                sql = "select Count(vld.MaNV) from \n" +
                        "(select MaNV, NgayDiemDanh from DiemDanh_NangSuatLaoDong\n" +
                        "where NgayDiemDanh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))\n" +
                        "and XacNhan = 1) as vld";
                temp = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                nghiVLD = temp != null ? temp : 0;
                /////////////////////////////////////////////////////////////////////////////////////////////

                //////////////////////////////////////GET TI LE HUY DONG////////////////////////////////////////
                string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
                sql = QUANGHANHCORE.Controllers.TCLD.ReportController.QueryForReportAlll(currentDate);
                List<TatCaDonVI> listTLHD = db.Database.SqlQuery<TatCaDonVI>(sql).ToList();
                for(int i = 0; i < listTLHD.Count; i++)
                {
                    if (listTLHD[i].TyLe > 82)
                    {
                        tren82++;
                    }
                    else {
                        duoi82++;
                    }
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////

                //////////////////////////////////////GET NV NGHI VLD////////////////////////////////////////
                sql = "select dd.MaNV,n.Ten as HoTen,d.department_name as TenDonVi from DiemDanh_NangSuatLaoDong dd,Department d,NhanVien n\n" +
                "where Dilam = 0 and LyDoVangMat = 'vld'\n" +
                "and dd.MaDonVi = d.department_id and n.MaNV = dd.MaNV and NgayDiemDanh=(SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))";
                listNghiVLD = db.Database.SqlQuery<NghiVLD>(sql).ToList<NghiVLD>();
                //listNghiVLD.Add(new NghiVLD("7887", "aHIHI", "QuangHanh"));
                ///////////////////////////////////////////////////////////////////////////////////////////////////
            }
            ViewBag.soLuotHuyDong = soLuotHuyDong;
            ViewBag.hetHanChungChi = hetHanChungChi;
            ViewBag.vuTaiNan = vuTaiNan;
            ViewBag.nghiVLD = nghiVLD;
            ViewBag.tren82 = tren82;
            ViewBag.duoi82 = duoi82;
            ViewBag.listNghiVLD = listNghiVLD;
            return View("/Views/TCLD/bao-cao-nhanh.cshtml");
        }
        //[Auther(RightID="57")]
        //[Route("phong-tcld/bao-cao-chi-tiet-theo-ca")]
        //public ActionResult Report1(string ca, string donvi, string date)
        //{
        //    if(ca == null)
        //    {
        //        ca = "1";
        //    }
        //    if (date == null)
        //    {
        //        date = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
        //    }
        //    if (donvi == null) { }
           
        //    return null;
        //}

        [Route("phong-tcld/get-data")]
        [HttpPost]
        public ActionResult GetData()
        {
            try
            {
                string date = Request["date"];
                date = date.Split('/')[2] + "/" + date.Split('/')[1] + "/" + date.Split('/')[0];
                int soLuotHuyDong = 0;
                int vuTaiNan = 0;
                int nghiVLD = 0;
                int hetHanChungChi = 0;
                int tren82 = 0;
                int duoi82 = 0;
                List<NghiVLD> listNghiVLD = new List<NghiVLD>();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    ////////////////////////////GET so luot huy dong////////////////////////////////

                    db.Configuration.LazyLoadingEnabled = false;
                    string sql = "select count(MaQuyetDinh) as SoLuotHuyDong from quyetdinh\n" +
                    "where maquyetdinh in\n" +
                    "(SELECT  distinct MaQuyetDinh FROM DIEUDONG_NHANVIEN)\n" +
                    "AND NgayQuyetDinh = @NgayQuyetDinh";
                    soLuotHuyDong = db.Database.SqlQuery<int>(sql,
                        new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];

                    ////////////////////////////GET SO LUONG TAI NAN//////////////////////////////
                    sql = "select Count(tn.MaNV)  from \n" +
                      "(select MaNV, Ngay from TaiNan where\n" +
                      "Ngay = @NgayQuyetDinh) as tn";
                    vuTaiNan = db.Database.SqlQuery<int>(sql,
                        new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];
                    //////////////////////////////////////////////////////////////////////////////

                    /// ////////////////////////////GET SO LUONG HET HAN CC//////////////////////////////
                    sql = "select sum(th.st) \n" +
                      "from(select cn.MaNV, cn.NgayCap, cc.ThoiHan, (case\n" +
                      "when DATEADD(MONTH, cc.ThoiHan, cn.NgayCap) <= @NgayQuyetDinh\n" +
                      "then 1 else 0 end) as st\n" +
                      "from ChungChi_NhanVien cn join ChungChi cc on cn.MaChungChi = cc.MaChungChi) as th";
                    hetHanChungChi = db.Database.SqlQuery<int>(sql,new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];
                    //////////////////////////////////////////////////////////////////////////////

                    /// ////////////////////////////GET SO LUONG NGHI VLD//////////////////////////////
                    sql = "select Count(vld.MaNV) from \n" +
                        "(select MaNV, NgayDiemDanh from DiemDanh_NangSuatLaoDong\n" +
                        "where NgayDiemDanh = @NgayQuyetDinh\n" +
                        "and XacNhan = 1) as vld";
                    nghiVLD = db.Database.SqlQuery<int>(sql,
                    new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];
                    //////////////////////////////////////////////////////////////////////////////
                    
                    //////////////////////////////////////GET TI LE HUY DONG////////////////////////////////////////
                    string tempDate = date.Split('/')[2] + "/" + date.Split('/')[1] + "/" + date.Split('/')[0];
                    sql = QUANGHANHCORE.Controllers.TCLD.ReportController.QueryForReportAlll(tempDate);
                    List<TatCaDonVI> listTLHD = db.Database.SqlQuery<TatCaDonVI>(sql).ToList();
                    for (int i = 0; i < listTLHD.Count; i++)
                    {
                        if (listTLHD[i].TyLe > 82)
                        {
                            tren82++;
                        }
                        else
                        {
                            duoi82++;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////GET NV NGHI VLD////////////////////////////////////////
                    sql = "select dd.MaNV,n.Ten as HoTen,d.department_name as TenDonVi from DiemDanh_NangSuatLaoDong dd,Department d,NhanVien n\n" +
                    "where XacNhan = 0 and LyDoVangMat = 'vld'\n" +
                    "and dd.MaDonVi = d.department_id and n.MaNV = dd.MaNV and NgayDiemDanh=@NgayDiemDanh";
                    listNghiVLD = db.Database.SqlQuery<NghiVLD>(sql,new SqlParameter("NgayDiemDanh", date)).ToList<NghiVLD>();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////
                }
                return Json(new { success = true, tren82=tren82, duoi82= duoi82, soLuongHuyDong = soLuotHuyDong, vuTaiNan = vuTaiNan, nghiVLD = nghiVLD, hetHanChungChi = hetHanChungChi, listNghiVLD= listNghiVLD }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }

        //[Route("phong-tcld/bao-cao-nhanh-lao-dong-tien-luong-vtl1")]
        //public ActionResult DetailReport()
        //{
        //    ViewBag.nameDepartment = "baocao-sanluon-laodong";
        //    return View("/Views/TCLD/bao_cao_nhanh_tung_phan_xuong.cshtml");
        //}

        [Route("phong-tcld/bao-cao-chi-tiet-theo-ca")]
        public ActionResult Report1(string ca, string donvi, string date)
        {
            if (ca == null)
            {
                ca = "1";
            }
            if (date == null)
            {
                date = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
            if (donvi == null)
            {
                donvi = "DL1";
            }
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            ViewBag.ca = ca;
            ViewBag.donvi = donvi;
            ViewBag.date = date;
            return View("/Views/TCLD/bao_cao_chi_tiet_theo_ca.cshtml");
        }

        [Route("phong-tcld/bao-cao-chi-tiet-theo-ca")]
        [HttpPost]
        public ActionResult List(string ca, string donvi, string date)
        {
            if (ca == "CA 1" || ca == null)
            {
                ca = "1";
            }
            if (ca == "CA 2")
            {
                ca = "2";
            }
            if (ca == "CA 3")
            {
                ca = "3";
            }
            if (date == null)
            {
                date = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
            if (donvi == null)
            {
                donvi = "DL1";
            }
            var calamviec = Convert.ToInt32(ca);
            var datesql = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<DiemDanh_NangSuatLaoDong> list = db.Departments.Where(a => a.department_id == donvi).First().DiemDanh_NangSuatLaoDong
                    .Where(a => a.NgayDiemDanh == datesql)
                    .Where(a => a.CaDiemDanh == calamviec).ToList();
                List<BaoCaoTheoCa> customNSLDs = new List<BaoCaoTheoCa>();
                BaoCaoTheoCa cus;
                int stt = 1;
                foreach (var i in list)
                {
                    cus = new BaoCaoTheoCa
                    {
                        ID = stt,
                        Name = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().Ten,
                        BacTho = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().BacLuong,
                        ChucDanh = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec == null ? "" : db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec.TenCongViec,
                        DuBaoNguyCo = i.DuBaoNguyCo,
                        HeSoChiaLuong = i.HeSoChiaLuong.ToString(),
                        LuongSauDuyet = i.Luong.ToString(),
                        LuongTruocDuyet = i.Luong.ToString(),
                        NoiDungCongViec = db.Departments.Where(a => a.department_id == i.MaDonVi).First().department_name,
                        NSLD = i.NangSuatLaoDong.ToString(),
                        SoThe = i.MaNV,
                        YeuCauBPKTAT = i.GiaiPhapNguyCo
                    };
                    customNSLDs.Add(cus);
                    stt++;
                }
                ViewBag.nsld = customNSLDs;
                var js = Json(new { success = true, data = customNSLDs }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }

        //[Route("phong-tcld/bien-ban-chung")]
        //public ActionResult CommonRecord()
        //{
        //    ViewBag.nameDepartment = "baocao-sanluon-laodong";
        //    return View("/Views/TCLD/CommonRecord.cshtml");
        //}
    }
    public class NghiVLD
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string TenDonVi { get; set; }

        public NghiVLD()
        {
        }

        public NghiVLD(string maNV, string hoTen, string tenDonVi)
        {
            MaNV = maNV;
            HoTen = hoTen;
            TenDonVi = tenDonVi;
        }
    }
}
