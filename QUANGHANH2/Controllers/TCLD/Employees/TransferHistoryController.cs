//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace QUANGHANH2.Controllers.TCLD.Employees
//{
//    public class TransferHistoryController : Controller
//    {
//        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-dong")]
//        [HttpGet]
//        public ActionResult TransferHistoryget(string ddid)
//        {
//            ViewBag.ddid = ddid;
//            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
//            var temp = from n in db.NhanViens
//                       where n.MaNV == ddid
//                       select n.Ten;
//            string name = temp.FirstOrDefault().ToString();
//            ViewBag.name = name.ToUpper();
//            return View("/Views/TCLD/Brief/TransferHistory.cshtml");
//        }

//        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-dong")]
//        [HttpPost]
//        public ActionResult TransferHistory()
//        {
//            var ddid = Request["ddid"];
//            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

//            int start = Convert.ToInt32(Request["start"]);
//            int length = Convert.ToInt32(Request["length"]);
//            string searchValue = Request["search[value]"];
//            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//            string sortDirection = Request["order[0][dir]"];
//            var temp = @"select dd_nv.Ten, dd_nv.MaQuyetDinh, dd_nv.NgayQuyetDinh, dd_nv.SoQuyetDinh, 
//                        (select department_name from Department where department_id = dd_nv.MaDonViCu) as 'DonViCu',
//                        (select cv.TenCongViec from CongViec cv where cv.MaCongViec = dd_nv.MaChucVuCu) as 'ChucVuCu',
//                        (select department_name from Department where department_id = dd_nv.MaDonViMoi) as 'DonViMoi',
//                        (select cv.TenCongViec from CongViec cv where cv.MaCongViec = dd_nv.MaChucVuMoi) as 'ChucVuMoi'
//                        from
//                        (select dd_nv.Ten, dd_nv.MaQuyetDinh, qd.NgayQuyetDinh, qd.SoQuyetDinh, dd_nv.MaChucVuMoi, dd_nv.MaChucVuCu, dd_nv.MaDonViCu, dd_nv.MaDonViMoi 
//                        from QuyetDinh qd right outer join 
//                        (select b.Ten, a.MaQuyetDinh, a.MaChucVuMoi, a.MaChucVuCu, a.MaDonViCu, a.MaDonViMoi from DieuDong_NhanVien a left outer join NhanVien b on a.MaNV = b.MaNV
//                        where a.MaNV = @ddid) as dd_nv on qd.MaQuyetDinh = dd_nv.MaQuyetDinh) as dd_nv 
//                        order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
//            List<lichSuDieuDong> newlist = db.Database.SqlQuery<lichSuDieuDong>(temp, new SqlParameter("ddid", ddid)).ToList().Select(p => new lichSuDieuDong()
//            {
//                Ten = p.Ten,
//                SoQuyetDinh = p.SoQuyetDinh,
//                NgayQuyetDinh = p.NgayQuyetDinh,
//                DonViMoi = p.DonViMoi,
//                DonViCu = p.DonViCu,
//                ChucVuMoi = p.ChucVuMoi,
//                ChucVuCu = p.ChucVuCu
//            }).ToList();
//            int totalrows = newlist.Count;
//            int totalrowsafterfiltering = newlist.Count;
//            return Json(new { data = newlist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

//        }

//        public class lichSuDieuDong : NhanVien
//        {
//            public string SoQuyetDinh { get; set; }
//            public Nullable<System.DateTime> NgayQuyetDinh { get; set; }
//            public string DonViMoi { get; set; }
//            public string DonViCu { get; set; }
//            public string ChucVuMoi { get; set; }
//            public string ChucVuCu { get; set; }
//        }
//    }
//}