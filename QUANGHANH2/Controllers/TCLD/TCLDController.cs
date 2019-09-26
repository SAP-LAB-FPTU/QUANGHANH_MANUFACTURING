using QUANGHANH2.Models;
using QUANGHANHCORE.Controllers.PX.PXKT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;
using System.Web.Script.Serialization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class TCLDController : Controller
    {
        // GET: /<controller>/
        [Route("phong-tcld/")]
        public ActionResult Dashboard()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/bao-cao-nhanh.cshtml");
        }
        [Route("phong-tcld/bao-cao-nhanh-lao-dong-tien-luong-vtl1")]
        public ActionResult DetailReport()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/bao_cao_nhanh_tung_phan_xuong.cshtml");
        }

        [Route("phong-tcld/bao-cao-chi-tiet-theo-ca")]
        public ActionResult Report1(string ca, string donvi, string date)
        {
            ca = "1";
            donvi = "DL1";
            date = "10/09/2019";
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
                date = "20/09/2019";
                //date = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
            var calamviec = Convert.ToInt32(ca);
            var datesql = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<DiemDanh_NangSuatLaoDong> list = db.DiemDanh_NangSuatLaoDong
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
                        ChucDanh = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec == null ? "": db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec.TenCongViec,
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

       

        [Route("phong-tcld/bien-ban-chung")]
        public ActionResult CommonRecord()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/CommonRecord.cshtml");
        }
        //[Route("~/{tenphong}/")]
        //public ActionResult Hocnt(String tenphong, [FromQuery] String ten)
        //{
        //    ViewBag.name = ten + tenphong;
        //    return View("Views/TCLD/bao-cao-nhanh.cshtml");
        //}
    }
}
