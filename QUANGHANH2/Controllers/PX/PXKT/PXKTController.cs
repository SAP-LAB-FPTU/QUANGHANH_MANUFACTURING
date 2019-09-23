using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.PX.PXKT
{
    public class PXKTController : Controller
    {
        [Auther(RightID ="006")]
        [Route("phan-xuong-khai-thac")]
        public ActionResult Index()
        {
            return View("/Views/PX/PXKT/Report.cshtml");
        }
        [Route("phan-xuong-khai-thac/chi-tiet")]
        public ActionResult Detail()
        {
            return View("/Views/PX/PXKT/Detail.cshtml");
        }
        [Route("phan-xuong-khai-thac/nhap-du-lieu")]
        public ActionResult Add()
        {
            return View("/Views/PX/PXKT/Add.cshtml");
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong")]
        public ActionResult NSLD(string intCa, string strDate)
        {
            if (intCa == null)
            {
                intCa = "1";
            }
            if (strDate == null)
            {
                strDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
            var calamviec = Convert.ToInt32(intCa);
            var date = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<DiemDanh_NangSuatLaoDong> list = db.DiemDanh_NangSuatLaoDong
                    .Where(a => a.NgayDiemDanh == date)
                    .Where(a => a.CaDiemDanh == calamviec).ToList();
                List<CustomNSLD> customNSLDs = new List<CustomNSLD>();
                CustomNSLD cus;
                foreach (var i in list)
                {
                    cus = new CustomNSLD
                    {
                        ID = i.MaDiemDanh,
                        Name = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().Ten,
                        BacTho = "6/6",
                        ChucDanh = "MT",
                        DuBaoNguyCo = "Không kiểm tra thiết bị trước khi vận hành",
                        HeSoChiaLuong = i.HeSoChiaLuong.ToString(),
                        LuongSauDuyet = i.LuongSauDuyet.ToString(),
                        LuongTruocDuyet = i.LuongTruocDuyet.ToString(),
                        NoiDungCongViec = db.Departments.Where(a => a.department_id == i.MaDonVi).First().department_name,
                        NSLD = i.NangSuatLaoDong,
                        SoThe = i.MaNV,
                        YeuCauBPKTAT = "Trước khi vận hành phải kiểm tra thiết bị đảm bảo an toàn trước khi được vận hành"
                    };
                    customNSLDs.Add(cus);
                }
                ViewBag.nsld = customNSLDs;
            }
            return View("/Views/PX/PXKT/NSLD.cshtml");
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong-update")]
        public void UpdateNSLD(int[] ids, string[] NSLDS, string intCa, string strDate)
        {
            int length = NSLDS.Length;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                for (int i = 0; i < length; i++)
                {
                    int id = ids[i];
                    string NSLD = NSLDS[i];
                    DiemDanh_NangSuatLaoDong f = db.DiemDanh_NangSuatLaoDong.FirstOrDefault(x => x.MaDiemDanh == id);
                    f.NangSuatLaoDong = NSLD;
                    db.SaveChanges();
                }
            }
            NSLD(intCa, strDate);
        }



    }
    public class CustomNSLD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SoThe { get; set; }
        public string BacTho { get; set; }
        public string ChucDanh { get; set; }
        public string NoiDungCongViec { get; set; }
        public string NSLD { get; set; }
        public string HeSoChiaLuong { get; set; }
        public string LuongTruocDuyet { get; set; }
        public string LuongSauDuyet { get; set; }
        public string DuBaoNguyCo { get; set; }
        public string YeuCauBPKTAT { get; set; }
    }
}