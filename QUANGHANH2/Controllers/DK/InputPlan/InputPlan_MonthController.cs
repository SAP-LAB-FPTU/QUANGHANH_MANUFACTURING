using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace QUANGHANH2.Controllers.DK.InputPlan
{
    public class InputPlan_MonthController : Controller
    {
        // GET: InputPlan_Month
        [Route("phong-dieu-khien/ke-hoach-san-xuat")]
        public ActionResult Index()
        {
            return View("/Views/DK/InputPlan/InputPlan_Month.cshtml");
        }
        //
        [Route("phong-dieu-khien/ke-hoach-san-xuat/lay-thong-tin")]
        public ActionResult getInformation()
        {
            var month = Int32.Parse(Request["month"]);
            var year = Int32.Parse(Request["year"]);
            var departmentID = Request["department"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var listAspect = (from header_kh in db.header_KeHoachTungThang
                                    .Where(kh => kh.MaPhongBan == departmentID && kh.ThangKeHoach == month && kh.NamKeHoach == year)
                                  join kh in db.KeHoach_TieuChi_TheoThang
                                  on header_kh.HeaderID equals kh.HeaderID into tmp1
                                  from firstResult in tmp1.DefaultIfEmpty()
                                  join tieuchi in db.TieuChis on firstResult.MaTieuChi equals tieuchi.MaTieuChi into tmp2
                                  from result in tmp2.DefaultIfEmpty()
                                  select new
                                  {
                                      Identify = result.MaTieuChi != null ? result.MaTieuChi + "-" + header_kh.HeaderID : header_kh.HeaderID + "-undified",
                                      MaTieuChi = (int?)result.MaTieuChi,
                                      TenTieuChi = result.TenTieuChi,
                                      DonVi = result.DonViDo,
                                      SanLuong = (float?)firstResult.SanLuong,
                                      GhiChu = firstResult.GhiChu == null ? "" : firstResult.GhiChu,
                                      totalDays = header_kh.SoNgayLamViec,
                                      headerID = header_kh.HeaderID
                                  }).ToList();

                var listAspectDepartments = (from pbtc in db.PhongBan_TieuChi
                                             .Where(x => x.MaPhongBan == departmentID)
                                             join tieuchi in db.TieuChis on pbtc.MaTieuChi equals tieuchi.MaTieuChi
                                             select new
                                             {
                                                 MaTieuChi = tieuchi.MaTieuChi,
                                                 TenTieuChi = tieuchi.TenTieuChi
                                             }).ToList();
                return Json(new { data = listAspect, aspects = listAspectDepartments, totalDays = (listAspect == null ? 0 : listAspect[0].totalDays), headerID = listAspect == null ? -1 : listAspect[0].headerID }, JsonRequestBehavior.AllowGet);
            }
        }
        //
        [Route("phong-dieu-khien/ke-hoach-san-xuat/cap-nhat-thong-tin")]
        public ActionResult UpdteInformation()
        {
            var month = Int32.Parse(Request["month"]);
            var year = Int32.Parse(Request["year"]);
            var departmentID = Request["department"];
            var headerID = Int32.Parse(Request["headerID"]);
            var data = Request["data"];
            List<KeHoach_TieuChi_TheoThang> listUpdate = JsonConvert.DeserializeObject<List<KeHoach_TieuChi_TheoThang>>(data);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                DateTime currentTime = DateTime.Now;
                foreach(var item in listUpdate)
                {
                    KeHoach_TieuChi_TheoThang kh = new KeHoach_TieuChi_TheoThang();
                    kh.MaTieuChi = item.MaTieuChi;
                    kh.HeaderID = item.HeaderID;
                    kh.SanLuong = item.SanLuong;
                    kh.GhiChu = item.GhiChu;
                    kh.ThoiGianNhapCuoiCung = currentTime;
                    db.Entry<KeHoach_TieuChi_TheoThang>(kh).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

            }
            return Json(new { });
        }
    }
}