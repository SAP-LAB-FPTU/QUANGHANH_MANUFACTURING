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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                ////////////////////////////GET so luot huy dong////////////////////////////////
                string sql = "select count(MaQuyetDinh) as SoLuotHuyDong from quyetdinh\n" +
                "where maquyetdinh in\n" +
                "(SELECT  distinct MaQuyetDinh FROM DIEUDONG_NHANVIEN)\n" +
                "AND NgayQuyetDinh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))";
                soLuotHuyDong = db.Database.SqlQuery<int>(sql).ToList<int>()[0];

                ////////////////////////////GET SO LUONG TAI NAN//////////////////////////////
                sql = "select Count(tn.MaNV)  from \n" +
                      "(select MaNV, Ngay from TaiNan where\n" +
                      "Ngay = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))) as tn";
                vuTaiNan = db.Database.SqlQuery<int>(sql).ToList<int>()[0];

                ///////////////////////////////GET SO LUONG HET HAN CC//////////////////////////////
                sql = "select sum(th.st) \n" +
                      "from(select cn.MaNV, cn.NgayCap, cc.ThoiHan, (case\n" +
                      "when DATEADD(MONTH, cc.ThoiHan, cn.NgayCap) <= GETDATE()\n" +
                      "then 1 else 0 end) as st\n" +
                      "from ChungChi_NhanVien cn join ChungChi cc on cn.MaChungChi = cc.MaChungChi) as th";
                hetHanChungChi = db.Database.SqlQuery<int>(sql).ToList<int>()[0];

                ////////////////////////////GET SO LUONG NGHI VLD//////////////////////////////
                sql = "select Count(vld.MaNV) from \n" +
                        "(select MaNV, NgayDiemDanh from DiemDanh_NangSuatLaoDong\n" +
                        "where NgayDiemDanh = (SELECT CONVERT(VARCHAR(10), getdate() - 1, 101))\n" +
                        "and XacNhan = 1) as vld";
                nghiVLD = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                ////////////////////////////////////////////////////////////////////////////////
            }
            ViewBag.soLuotHuyDong = soLuotHuyDong;
            ViewBag.hetHanChungChi = hetHanChungChi;
            ViewBag.vuTaiNan = vuTaiNan;
            ViewBag.nghiVLD = nghiVLD;
            ViewBag.tren82 = "Doan Van Thang";
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
                      "when DATEADD(MONTH, cc.ThoiHan, cn.NgayCap) <= GETDATE()\n" +
                      "then 1 else 0 end) as st\n" +
                      "from ChungChi_NhanVien cn join ChungChi cc on cn.MaChungChi = cc.MaChungChi) as th";
                    hetHanChungChi = db.Database.SqlQuery<int>(sql).ToList<int>()[0];
                    //////////////////////////////////////////////////////////////////////////////

                    /// ////////////////////////////GET SO LUONG NGHI VLD//////////////////////////////
                    sql = "select Count(vld.MaNV) from \n" +
                        "(select MaNV, NgayDiemDanh from DiemDanh_NangSuatLaoDong\n" +
                        "where NgayDiemDanh = @NgayQuyetDinh\n" +
                        "and XacNhan = 1) as vld";
                    nghiVLD = db.Database.SqlQuery<int>(sql,
                    new SqlParameter("NgayQuyetDinh", DateTime.Parse(date))).ToList<int>()[0];
                    //////////////////////////////////////////////////////////////////////////////
                }
                return Json(new { success = true, soLuongHuyDong = soLuotHuyDong, vuTaiNan = vuTaiNan, nghiVLD = nghiVLD, hetHanChungChi = hetHanChungChi }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }
       
        //[Route("phong-tcld/bien-ban-chung")]
        //public ActionResult CommonRecord()
        //{
        //    ViewBag.nameDepartment = "baocao-sanluon-laodong";
        //    return View("/Views/TCLD/CommonRecord.cshtml");
        //}
    }
}
