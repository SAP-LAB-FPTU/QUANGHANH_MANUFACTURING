using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Web.Hosting;
using System.IO;
using OfficeOpenXml;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.TCLD
{
    public class DiplomaController : Controller
    {
        // GET: Diploma
        [Auther(RightID = "159")]
        [Route("phong-tcld/bang-cap-va-giay-chung-nhan/danh-sach-bang-cap-va-giay-chung-nhan")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Diploma/List.cshtml");
        }
        [Auther(RightID = "159")]
        //Get list Diploma
        [Route("phong-tcld/bang-cap-va-giay-chung-nhan/danh-sach-bang-cap-va-giay-chung-nhan")]
        [HttpPost]
        public ActionResult List()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<BangCap_detailsDB> listdataDip = new List<BangCap_detailsDB>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                //List<BangCap_GiayChungNhan> listdataDip =db.BangCap_GiayChungNhan.ToList<BangCap_GiayChungNhan>();
                listdataDip = (from bc in db.BangCap_GiayChungNhan
                               join cn in db.ChuyenNganhs on bc.MaChuyenNganh equals cn.MaChuyenNganh into cnganh
                               from cn in cnganh.DefaultIfEmpty()
                               join td in db.TrinhDoes on bc.MaTrinhDo equals td.MaTrinhDo into tdo
                               from td in tdo.DefaultIfEmpty()
                               join truong in db.Truongs on bc.MaTruong equals truong.MaTruong into tt
                               from truong in tt.DefaultIfEmpty()
                               select new
                               {
                                   MaTruong = bc.MaTruong,
                                   MaChuyenNganh = bc.MaChuyenNganh,
                                   MaBangCap_GiayChungNhan = bc.MaBangCap_GiayChungNhan,
                                   MaTrinhDo = bc.MaTrinhDo,
                                   KieuBangCap = bc.KieuBangCap,
                                   ThoiHan = bc.ThoiHan,
                                   TenBangCap = bc.TenBangCap,
                                   Loai = bc.Loai,
                                   TenTruong = truong.TenTruong,
                                   TenChuyenNganh = cn.TenChuyenNganh,
                                   TenTrinhDo = td.TenTrinhDo
                               }).ToList().Select(bangcap => new BangCap_detailsDB
                               {
                                   MaTruong = bangcap.MaTruong,
                                   MaChuyenNganh = bangcap.MaChuyenNganh,
                                   MaBangCap_GiayChungNhan = bangcap.MaBangCap_GiayChungNhan,
                                   MaTrinhDo = bangcap.MaTrinhDo,
                                   KieuBangCap = bangcap.KieuBangCap,
                                   ThoiHan = bangcap.ThoiHan,
                                   TenBangCap = bangcap.TenBangCap,
                                   Loai = bangcap.Loai,
                                   TenTruong = bangcap.TenTruong,
                                   TenChuyenNganh = bangcap.TenChuyenNganh,
                                   TenTrinhDo = bangcap.TenTrinhDo
                               }).ToList();


                int totalrows = listdataDip.Count;
                int totalrowsafterfiltering = listdataDip.Count;
                listdataDip = listdataDip.OrderBy(sortColumnName + " " + sortDirection).ToList<BangCap_detailsDB>();
                //paging
                listdataDip = listdataDip.Skip(start).Take(length).ToList<BangCap_detailsDB>();
                var dataJson = Json(new { success = true, data = listdataDip, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dtSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }
        }
        [Auther(RightID = "163")]
        //Get list Diploma's Employee
        [Route("phong-tcld/bang-cap-va-giay-chung-nhan/danh-sach-bang-cap-va-giay-chung-nhan-cua-nhan-vien")]
        [HttpPost]
        public ActionResult DiplomaEmployeeList()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<BangCap_GiayChungNhan_detailsDB> listdataDipEmp = new List<BangCap_GiayChungNhan_detailsDB>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                listdataDipEmp = (from bc_chitiet in db.ChiTiet_BangCap_GiayChungNhan
                                  join nv in db.NhanViens on bc_chitiet.MaNV equals nv.MaNV into bc_gcn_nv1
                                  from sub_bc_gcn_nv1 in bc_gcn_nv1.DefaultIfEmpty()
                                  join bc in db.BangCap_GiayChungNhan on bc_chitiet.MaBangCap_GiayChungNhan equals bc.MaBangCap_GiayChungNhan into bc_gcn_nv2
                                  from sub_bc_gcn_nv2 in bc_gcn_nv2.DefaultIfEmpty()
                                  select new
                                  {
                                      SoHieu = bc_chitiet.SoHieu,
                                      MaBangCap_GiayChungNhan = bc_chitiet.MaBangCap_GiayChungNhan,
                                      NgayCap = bc_chitiet.NgayCap,
                                      MaNV = bc_chitiet.MaNV,
                                      NgayTra = bc_chitiet.NgayTra,
                                      TenBangCap = sub_bc_gcn_nv2.TenBangCap,
                                      TenNV = sub_bc_gcn_nv1.Ten,
                                  }).ToList().Select(dip => new BangCap_GiayChungNhan_detailsDB
                                  {
                                      SoHieu = dip.SoHieu,
                                      MaBangCap_GiayChungNhan = dip.MaBangCap_GiayChungNhan,
                                      NgayCap = dip.NgayCap,
                                      MaNV = dip.MaNV,
                                      NgayTra = dip.NgayTra,
                                      TenBangCap = dip.TenBangCap,
                                      Ten = dip.TenNV,
                                  }).ToList();

                int totalrows = listdataDipEmp.Count;
                int totalrowsafterfiltering = listdataDipEmp.Count;
                listdataDipEmp = listdataDipEmp.OrderBy(sortColumnName + " " + sortDirection).ToList<BangCap_GiayChungNhan_detailsDB>();
                //paging
                listdataDipEmp = listdataDipEmp.Skip(start).Take(length).ToList<BangCap_GiayChungNhan_detailsDB>();
                var dataJson = Json(new { success = true, data = listdataDipEmp, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dtSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }
        }
        //Add Diploma
        [Auther(RightID = "160")]
        [HttpGet]
        public ActionResult AddDiploma()
        {
            getDataSelectDiploma();
            return View();

        }
        [Auther(RightID = "160")]
        [HttpPost]
        public ActionResult AddDiploma(BangCap_GiayChungNhan bangcap)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (bangcap != null)
                {
                    var checkDupicate = db.BangCap_GiayChungNhan.Where(x => x.MaTruong == bangcap.MaTruong && x.MaChuyenNganh == bangcap.MaChuyenNganh
                                                                                                            && x.MaTrinhDo == bangcap.MaTrinhDo && x.KieuBangCap == bangcap.KieuBangCap
                                                                                                            && x.ThoiHan == bangcap.ThoiHan && x.TenBangCap == bangcap.TenBangCap
                                                                                                            && x.Loai == bangcap.Loai).FirstOrDefault();
                    if (checkDupicate == null)
                    {
                        db.BangCap_GiayChungNhan.Add(bangcap);
                        db.SaveChanges();
                    }
                    else
                    {
                        return Json(new { error = true, title = "Lỗi", message = "Bằng cấp hoặc giấy chứng nhận đang thêm đã tồn tại." });
                    }
                }
                return RedirectToAction("List");
            }


        }
        [Auther(RightID = "164")]
        //Add Diploma's Employee
        [HttpGet]
        public ActionResult AddDiplomaEmployee()
        {

            getDataSelectDiplomaEmployee();
            return View();

        }
        [Auther(RightID = "164")]
        [HttpPost]
        public ActionResult AddDiplomaEmployee(ChiTiet_BangCap_GiayChungNhan chitietbangcap)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chitietbangcap != null)
                {
                    db.ChiTiet_BangCap_GiayChungNhan.Add(chitietbangcap);
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }


        }
        //Edit Diploma
        [Auther(RightID = "161")]
        [HttpGet]
        public ActionResult EditDiploma(int id = 0)
        {
            getDataSelectDiploma();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                BangCap_GiayChungNhan bc = db.BangCap_GiayChungNhan.Where(x => x.MaBangCap_GiayChungNhan == id).FirstOrDefault<BangCap_GiayChungNhan>();
                return View(bc);
            }

        }
        [Auther(RightID = "161")]
        [HttpPost]
        public ActionResult EditDiploma(BangCap_GiayChungNhan bangcap)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (bangcap != null)
                {
                    var checkDupicate = db.BangCap_GiayChungNhan.Where(x => x.MaTruong == bangcap.MaTruong && x.MaChuyenNganh == bangcap.MaChuyenNganh
                                                                                        && x.MaTrinhDo == bangcap.MaTrinhDo && x.KieuBangCap == bangcap.KieuBangCap
                                                                                        && x.ThoiHan == bangcap.ThoiHan && x.TenBangCap == bangcap.TenBangCap
                                                                                        && x.Loai == bangcap.Loai).FirstOrDefault();
                    if (checkDupicate == null)
                    {
                        db.Entry(bangcap).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        return Json(new { error = true, title = "Lỗi", message = "Đã tồn tại bằng cấp hoặc giấy chứng nhận." });
                    }
                }
                return RedirectToAction("List");
            }
        }
        // Set data dropdown for Diploma
        public void getDataSelectDiploma()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "Vĩnh viễn");
            list.Add(2, "Thời hạn");

            SelectList listOption = new SelectList(list, "Key", "Value");
            ViewBag.listOption = listOption;

            Dictionary<int, string> listTypesDiploma = new Dictionary<int, string>();
            listTypesDiploma.Add(1, "Photo");
            listTypesDiploma.Add(2, "Sao, Công chứng");
            listTypesDiploma.Add(3, "Bản gốc");
            listTypesDiploma.Add(4, "Dấu đỏ");
            SelectList listTypesDip = new SelectList(listTypesDiploma, "Value", "Value");
            ViewBag.listTypesDip = listTypesDip;

            Dictionary<int, string> list_loai = new Dictionary<int, string>();
            list_loai.Add(1, "Bằng cấp");
            list_loai.Add(2, "Giấy chứng nhận");
            SelectList listSelectListTypeDip = new SelectList(list_loai, "Value", "Value");
            ViewBag.listSelectListTypeDip = listSelectListTypeDip;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<Truong> listdata_truong = db.Truongs.ToList<Truong>();
                List<TrinhDo> listdata_trinhdo = db.TrinhDoes.ToList<TrinhDo>();
                List<ChuyenNganh> listdata_chuyennganh = db.ChuyenNganhs.ToList<ChuyenNganh>();
                SelectList listSelect_truong = new SelectList(listdata_truong, "MaTruong", "TenTruong");
                SelectList listSelect_trinhdo = new SelectList(listdata_trinhdo, "MaTrinhDo", "TenTrinhDo");
                SelectList listSelect_chuyennganh = new SelectList(listdata_chuyennganh, "MaChuyenNganh", "TenChuyenNganh");

                ViewBag.listSelect_truong = listSelect_truong;
                ViewBag.listSelect_trinhdo = listSelect_trinhdo;
                ViewBag.listSelect_chuyennganh = listSelect_chuyennganh;
            }
        }
        [Auther(RightID = "162")]
        //Delete Diploma
        [HttpPost]
        public ActionResult DeleteDiploma(int id = 0)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {

                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        BangCap_GiayChungNhan bangcap = db.BangCap_GiayChungNhan.Where(x => x.MaBangCap_GiayChungNhan == id).FirstOrDefault<BangCap_GiayChungNhan>();

                        db.BangCap_GiayChungNhan.Remove(bangcap);
                        //List<ChungChi_NhanVien> ccnv = new List<ChungChi_NhanVien>();
                        var bcnv = from item in db.ChiTiet_BangCap_GiayChungNhan
                                   where item.MaBangCap_GiayChungNhan == id
                                   select item;
                        //var chungchi_nvs = db.ChungChi_NhanVien.Where(x => x.MaChungChi == id).FirstOrDefault<ChungChi_NhanVien>();
                        if (bcnv != null)
                        {
                            foreach (var item in bcnv)
                            {
                                db.ChiTiet_BangCap_GiayChungNhan.Remove(item);
                            }

                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
                return RedirectToAction("List");
            }
        }
        //Delete Diploma's Employee
        [Auther(RightID = "166")]
        [HttpPost]
        public ActionResult DeleteDiplomaEmployee(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {

                ChiTiet_BangCap_GiayChungNhan chitiet_bangcap = db.ChiTiet_BangCap_GiayChungNhan.Where(x => x.SoHieu.Equals(id)).FirstOrDefault<ChiTiet_BangCap_GiayChungNhan>();
                if (chitiet_bangcap != null)
                {
                    db.ChiTiet_BangCap_GiayChungNhan.Remove(chitiet_bangcap);
                    db.SaveChanges();
                }

                return Json(new { success = true, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);

            }
        }

        public class DisplayBangCap : BangCap_GiayChungNhan
        {
            public string TenDisplay { get; set; }
            public string TenTrinhDo { get; set; }
            public string TenTruong { get; set; }
            public string TenChuyenNganh { get; set; }
        }
        //Set dropdown for Diploma's Employee
        public void getDataSelectDiplomaEmployee()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                string query = @"select b.*, t.TenTrinhDo, tr.TenTruong, cn.TenChuyenNganh from BangCap_GiayChungNhan b
                         join TrinhDo t on b.MaTrinhDo = t.MaTrinhDo
                         join Truong tr on b.MaTruong = tr.MaTruong
                         join ChuyenNganh cn on b.MaChuyenNganh = cn.MaChuyenNganh";
                List<DisplayBangCap> listdata_bangcap = db.Database.SqlQuery<DisplayBangCap>(query).ToList();
                foreach (var item in listdata_bangcap)
                {
                    item.TenDisplay = item.TenBangCap + " - " + item.TenChuyenNganh + " - " + item.TenTruong + " - " + item.TenTrinhDo + " - " + item.KieuBangCap + " - " + item.Loai;
                    if (item.ThoiHan.Equals("-1"))
                    {
                        item.TenDisplay += " - Vĩnh viễn";
                    }
                    else
                    {
                        item.TenDisplay += " - " + item.ThoiHan + " tháng";
                    }
                }
                List<NhanVien> listdata_nv = db.NhanViens.ToList<NhanVien>();
                var result = listdata_nv.Where(s => s.MaTrangThai != 2);
                SelectList listSelect_bangcap = new SelectList(listdata_bangcap, "MaBangCap_GiayChungNhan", "TenDisplay");
                SelectList listSelect_nhanvien = new SelectList(result, "MaNV", "MaNV");
                ViewBag.listSelect_nhanvien = listSelect_nhanvien;
                ViewBag.listSelect_bangcap = listSelect_bangcap;

            }
        }
        //Edit Diploma's Emp
        [Auther(RightID = "165")]
        [HttpGet]
        public ActionResult EditDiplomaEmployee(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                getDataSelectDiplomaEmployee();

                ChiTiet_BangCap_GiayChungNhan chitiet_bangcap = db.ChiTiet_BangCap_GiayChungNhan.Where(x => x.SoHieu.Equals(id)).FirstOrDefault<ChiTiet_BangCap_GiayChungNhan>();

                if (chitiet_bangcap != null)
                {
                    var emp = db.NhanViens.Where(x => x.MaNV == chitiet_bangcap.MaNV).FirstOrDefault<NhanVien>();
                    if (emp != null)
                    {
                        ViewBag.nameEmpEdit = emp.Ten;
                        ViewBag.first_cir = chitiet_bangcap.MaBangCap_GiayChungNhan;
                    }
                }
                return View(chitiet_bangcap);
            }

        }
        [Auther(RightID = "165")]
        [HttpPost]
        public ActionResult EditDiplomaEmployee(ChiTiet_BangCap_GiayChungNhan chitiet_bc)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chitiet_bc != null)
                {
                    db.Entry(chitiet_bc).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
        // Search Diploma follow Truong,Nganh,Trinh do, Bang cap
        [HttpPost]
        public ActionResult SearchDiploma(string ListSearch)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<BangCap_detailsDB> listdataDip = new List<BangCap_detailsDB>();
            string[] idsArray = ListSearch.Split(',').ToArray();
            var truong_text = idsArray[0];
            var nganh_text = idsArray[1];
            var trinhdo_text = idsArray[2];
            var bangcap_text = idsArray[3];
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (truong_text != null || nganh_text != null || trinhdo_text != null || bangcap_text != null)
                {
                    listdataDip = (from bc in db.BangCap_GiayChungNhan
                                   join cn in db.ChuyenNganhs on bc.MaChuyenNganh equals cn.MaChuyenNganh into cnganh
                                   from cn in cnganh.DefaultIfEmpty()
                                   join td in db.TrinhDoes on bc.MaTrinhDo equals td.MaTrinhDo into tdo
                                   from td in tdo.DefaultIfEmpty()
                                   join truong in db.Truongs on bc.MaTruong equals truong.MaTruong into tt
                                   from truong in tt.DefaultIfEmpty()
                                   where ((truong.TenTruong == null ? "".Contains(truong_text) : truong.TenTruong.Contains(truong_text)) && (bc.TenBangCap.Contains(bangcap_text))
                                   && (cn.TenChuyenNganh == null ? "".Contains(nganh_text) : cn.TenChuyenNganh.Contains(nganh_text)) && (td.TenTrinhDo == null ? "".Contains(trinhdo_text) : td.TenTrinhDo.Contains(trinhdo_text))
                                   )
                                   select new
                                   {
                                       MaTruong = bc.MaTruong,
                                       MaChuyenNghanh = bc.MaChuyenNganh,
                                       MaBangCap_GiayChungNhan = bc.MaBangCap_GiayChungNhan,
                                       MaTrinhDo = bc.MaTrinhDo,
                                       KieuBangCap = bc.KieuBangCap,
                                       ThoiHan = bc.ThoiHan,
                                       TenBangCap = bc.TenBangCap,
                                       Loai = bc.Loai,
                                       TenTruong = truong.TenTruong,
                                       TenChuyenNganh = cn.TenChuyenNganh,
                                       TenTrinhDo = td.TenTrinhDo
                                   }).ToList().Select(bangcap => new BangCap_detailsDB
                                   {
                                       MaTruong = bangcap.MaTruong,
                                       MaChuyenNganh = bangcap.MaChuyenNghanh,
                                       MaBangCap_GiayChungNhan = bangcap.MaBangCap_GiayChungNhan,
                                       MaTrinhDo = bangcap.MaTrinhDo,
                                       KieuBangCap = bangcap.KieuBangCap,
                                       ThoiHan = bangcap.ThoiHan,
                                       TenBangCap = bangcap.TenBangCap,
                                       Loai = bangcap.Loai,
                                       TenTruong = bangcap.TenTruong,
                                       TenChuyenNganh = bangcap.TenChuyenNganh,
                                       TenTrinhDo = bangcap.TenTrinhDo
                                   }).ToList();
                }
                int totalrows = listdataDip.Count;
                int totalrowsafterfiltering = listdataDip.Count;
                listdataDip = listdataDip.OrderBy(sortColumnName + " " + sortDirection).ToList<BangCap_detailsDB>();
                //paging
                listdataDip = listdataDip.Skip(start).Take(length).ToList<BangCap_detailsDB>();
                var dataJson = Json(new { success = true, data = listdataDip, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dtSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }

        }
        //Search Diploma's Employee 
        [HttpPost]
        public ActionResult SearchDiplomaEmployee(string ListSearchDipEmp)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<BangCap_GiayChungNhan_detailsDB> listdataDipEmp = new List<BangCap_GiayChungNhan_detailsDB>();
            string[] idsArray = ListSearchDipEmp.Split(',').ToArray();
            var sohieu_text = idsArray[0];
            var bangcap_text = idsArray[1];
            var tennv_text = idsArray[2];
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (sohieu_text != null || bangcap_text != null || tennv_text != null)
                {
                    listdataDipEmp = (from bc_chitiet in db.ChiTiet_BangCap_GiayChungNhan
                                      join nv in db.NhanViens on bc_chitiet.MaNV equals nv.MaNV
                                      join bc in db.BangCap_GiayChungNhan on bc_chitiet.MaBangCap_GiayChungNhan equals bc.MaBangCap_GiayChungNhan
                                      where (bc_chitiet.SoHieu.Contains(sohieu_text)) & (nv.Ten.Contains(tennv_text)) & (bc.TenBangCap.Contains(bangcap_text))
                                      select new
                                      {
                                          SoHieu = bc_chitiet.SoHieu,
                                          MaBangCap_GiayChungNhan = bc_chitiet.MaBangCap_GiayChungNhan,
                                          NgayCap = bc_chitiet.NgayCap,
                                          MaNV = bc_chitiet.MaNV,
                                          NgayTra = bc_chitiet.NgayTra,
                                          TenBangCap = bc.TenBangCap,
                                          TenNV = nv.Ten,
                                      }).ToList().Select(dip => new BangCap_GiayChungNhan_detailsDB
                                      {
                                          SoHieu = dip.SoHieu,
                                          MaBangCap_GiayChungNhan = dip.MaBangCap_GiayChungNhan,
                                          NgayCap = dip.NgayCap,
                                          MaNV = dip.MaNV,
                                          NgayTra = dip.NgayTra,
                                          TenBangCap = dip.TenBangCap,
                                          Ten = dip.TenNV,
                                      }).ToList();
                }
                int totalrows = listdataDipEmp.Count;
                int totalrowsafterfiltering = listdataDipEmp.Count;
                listdataDipEmp = listdataDipEmp.OrderBy(sortColumnName + " " + sortDirection).ToList<BangCap_GiayChungNhan_detailsDB>();
                //paging
                listdataDipEmp = listdataDipEmp.Skip(start).Take(length).ToList<BangCap_GiayChungNhan_detailsDB>();
                var dataJson = Json(new { success = true, data = listdataDipEmp, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dtSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }
        }
        //Check SoHieu exist 
        [HttpPost]
        public ActionResult validateIDDiploma(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var bangcap_nvs = db.ChiTiet_BangCap_GiayChungNhan.Where(x => x.SoHieu == id).FirstOrDefault<ChiTiet_BangCap_GiayChungNhan>();
                if (bangcap_nvs != null)
                {
                    return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        //Get name of Employee
        [HttpPost]
        public ActionResult getName(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var chungchi_nvs = db.NhanViens.Where(x => (x.MaNV == id) && (x.MaTrangThai != 2)).FirstOrDefault<NhanVien>();
                if (chungchi_nvs != null)
                {
                    return Json(new { data = chungchi_nvs.Ten, success = true, message = "ok" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Không tồn tại", success = false, message = "wrong" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        //Check Employee have ẽ yet?
        public ActionResult validateExistDiplomaOfEmp(string manv, int mabangcap, string first_diploma)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var bangcap_nvs = db.ChiTiet_BangCap_GiayChungNhan.Where(x => (x.MaNV == manv) && (x.MaBangCap_GiayChungNhan == mabangcap)).FirstOrDefault<ChiTiet_BangCap_GiayChungNhan>();
                if (bangcap_nvs != null)
                {
                    if (first_diploma != "" && (bangcap_nvs.MaBangCap_GiayChungNhan.ToString()).Equals(first_diploma))
                    {
                        return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (first_diploma != "" && !(bangcap_nvs.MaBangCap_GiayChungNhan.ToString()).Equals(first_diploma))
                    {
                        return Json(new { success = true, message = "right id" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult validateNameDuplicateDiploma(string name_diploma)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var bangcap = db.BangCap_GiayChungNhan.Where(x => x.TenBangCap == name_diploma).FirstOrDefault<BangCap_GiayChungNhan>();
                if (bangcap != null)
                {
                    return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [Route("phong-tcld/bang-cap/danh-sach-bang-cap/xuat-file-excel")]
        [HttpPost]
        public ActionResult ExporTotExcelDiploma()
        {
            try
            {
                string path = HostingEnvironment.MapPath("/excel/TCLD/Diploma/Bằng cấp - giấy chứng nhận.xlsx");
                string saveAsPath = ("/excel/TCLD/download/Bằng cấp - giấy chứng nhận.xlsx");
                FileInfo file = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                    ExcelWorksheet ws_cert_emp = excelWorkbook.Worksheets.First();
                    List<BangCap_detailsDB> listdataDiploma = new List<BangCap_detailsDB>();
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {

                        int count = 0;
                        listdataDiploma = (from bc in db.BangCap_GiayChungNhan
                                           join cn in db.ChuyenNganhs on bc.MaChuyenNganh equals cn.MaChuyenNganh into bc_gcn1
                                           from sub_bc_gcn1 in bc_gcn1.DefaultIfEmpty()
                                           join td in db.TrinhDoes on bc.MaTrinhDo equals td.MaTrinhDo into bc_gcn2
                                           from sub_bc_gcn2 in bc_gcn2.DefaultIfEmpty()
                                           join truong in db.Truongs on bc.MaTruong equals truong.MaTruong into bc_gcn3
                                           from sub_bc_gcn3 in bc_gcn3.DefaultIfEmpty()
                                           select new
                                           {
                                               MaTruong = bc.MaTruong,
                                               MaChuyenNganh = bc.MaChuyenNganh,
                                               MaBangCap_GiayChungNhan = bc.MaBangCap_GiayChungNhan,
                                               MaTrinhDo = bc.MaTrinhDo,
                                               KieuBangCap = bc.KieuBangCap ?? String.Empty,
                                               ThoiHan = bc.ThoiHan ?? String.Empty,
                                               TenBangCap = bc.TenBangCap ?? String.Empty,
                                               Loai = bc.Loai ?? String.Empty,
                                               TenTruong = sub_bc_gcn3.TenTruong ?? String.Empty,
                                               TenChuyenNganh = sub_bc_gcn1.TenChuyenNganh ?? String.Empty,
                                               TenTrinhDo = sub_bc_gcn2.TenTrinhDo ?? String.Empty
                                           }).ToList().Select(bangcap => new BangCap_detailsDB
                                           {
                                               MaTruong = bangcap.MaTruong,
                                               MaChuyenNganh = bangcap.MaChuyenNganh,
                                               MaBangCap_GiayChungNhan = bangcap.MaBangCap_GiayChungNhan,
                                               MaTrinhDo = bangcap.MaTrinhDo,
                                               KieuBangCap = bangcap.KieuBangCap,
                                               ThoiHan = bangcap.ThoiHan,
                                               TenBangCap = bangcap.TenBangCap,
                                               Loai = bangcap.Loai,
                                               TenTruong = bangcap.TenTruong,
                                               TenChuyenNganh = bangcap.TenChuyenNganh,
                                               TenTrinhDo = bangcap.TenTrinhDo
                                           }).ToList();

                        ws_cert_emp.Cells["A1"].Value = "Bảng danh sách bằng cấp và giấy chứng nhận";
                        ws_cert_emp.Cells["B1"].Value = "Tên trường";
                        ws_cert_emp.Cells["C1"].Value = "Tên chuyên ngành";
                        ws_cert_emp.Cells["D1"].Value = "Tên trình độ";
                        ws_cert_emp.Cells["E1"].Value = "Tên bằng cấp";
                        ws_cert_emp.Cells["F1"].Value = "Kiểu bằng cấp";
                        ws_cert_emp.Cells["G1"].Value = "Thời hạn";
                        ws_cert_emp.Cells["H1"].Value = "Loại";
                        int rowStart = 3;

                        foreach (var item in listdataDiploma)
                        {
                            count++;
                            ws_cert_emp.Cells[string.Format("A{0}", rowStart)].Value = count;
                            ws_cert_emp.Cells[string.Format("B{0}", rowStart)].Value = item.TenTruong;
                            ws_cert_emp.Cells[string.Format("C{0}", rowStart)].Value = item.TenChuyenNganh;
                            ws_cert_emp.Cells[string.Format("D{0}", rowStart)].Value = item.TenTrinhDo;
                            ws_cert_emp.Cells[string.Format("E{0}", rowStart)].Value = item.TenBangCap;
                            ws_cert_emp.Cells[string.Format("F{0}", rowStart)].Value = item.KieuBangCap;
                            if (item.ThoiHan.Equals("-1"))
                            {
                                ws_cert_emp.Cells[string.Format("G{0}", rowStart)].Value = "Vĩnh viễn";
                            }
                            else
                            {
                                ws_cert_emp.Cells[string.Format("G{0}", rowStart)].Value = item.ThoiHan;
                            }
                            ws_cert_emp.Cells[string.Format("H{0}", rowStart)].Value = item.Loai;


                            rowStart++;

                        }
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
                return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("phong-tcld/bang-cap/danh-sach-bang-cap-cua-nhan-vien/xuat-file-excel")]
        [HttpPost]
        public ActionResult ExporTotExcelDiplomaEmployee()
        {
            try
            {
                string path = HostingEnvironment.MapPath("/excel/TCLD/Diploma/bằng cấp và giấy chứng nhận của nhân viên.xlsx");
                string saveAsPath = ("/excel/TCLD/download/Bằng cấp - giấy chứng nhận của nhân viên.xlsx");
                FileInfo file = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                    ExcelWorksheet ws_cert_emp = excelWorkbook.Worksheets.First();
                    List<BangCap_GiayChungNhan_detailsDB> listdataDipEmpDetail = new List<BangCap_GiayChungNhan_detailsDB>();
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {
                        int count = 0;
                        listdataDipEmpDetail = (from bc_chitiet in db.ChiTiet_BangCap_GiayChungNhan
                                                join nv in db.NhanViens on bc_chitiet.MaNV equals nv.MaNV
                                                join bc in db.BangCap_GiayChungNhan on bc_chitiet.MaBangCap_GiayChungNhan equals bc.MaBangCap_GiayChungNhan
                                                select new
                                                {
                                                    SoHieu = bc_chitiet.SoHieu,
                                                    MaBangCap_GiayChungNhan = bc_chitiet.MaBangCap_GiayChungNhan,
                                                    NgayCap = bc_chitiet.NgayCap,
                                                    MaNV = bc_chitiet.MaNV,
                                                    NgayTra = bc_chitiet.NgayTra,
                                                    TenBangCap = bc.TenBangCap,
                                                    TenNV = nv.Ten,
                                                }).ToList().Select(dip => new BangCap_GiayChungNhan_detailsDB
                                                {
                                                    SoHieu = dip.SoHieu,
                                                    MaBangCap_GiayChungNhan = dip.MaBangCap_GiayChungNhan,
                                                    NgayCap = dip.NgayCap,
                                                    MaNV = dip.MaNV,
                                                    NgayTra = dip.NgayTra,
                                                    TenBangCap = dip.TenBangCap,
                                                    Ten = dip.TenNV,
                                                }).ToList();
                        ws_cert_emp.Cells["A1"].Value = "Bảng danh sách bằng cấp - giấy chứng nhận của nhân viên";
                        ws_cert_emp.Cells["B1"].Value = "Số hiệu";
                        ws_cert_emp.Cells["C1"].Value = "Tên bằng cấp";
                        ws_cert_emp.Cells["D1"].Value = "Mã nhân viên";
                        ws_cert_emp.Cells["E1"].Value = "Tên nhân viên";
                        ws_cert_emp.Cells["F1"].Value = "Ngày cấp";
                        int rowStart = 3;

                        foreach (var item in listdataDipEmpDetail)
                        {
                            count++;
                            ws_cert_emp.Cells[string.Format("A{0}", rowStart)].Value = count;
                            ws_cert_emp.Cells[string.Format("B{0}", rowStart)].Value = item.SoHieu;
                            ws_cert_emp.Cells[string.Format("C{0}", rowStart)].Value = item.TenBangCap;
                            ws_cert_emp.Cells[string.Format("D{0}", rowStart)].Value = item.MaNV;
                            ws_cert_emp.Cells[string.Format("E{0}", rowStart)].Value = item.Ten;

                            if (item.NgayCap != null)
                            {
                                ws_cert_emp.Cells[string.Format("F{0}", rowStart)].Value = ((DateTime)item.NgayCap).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                ws_cert_emp.Cells[string.Format("F{0}", rowStart)].Value = item.NgayCap;
                            }


                            rowStart++;

                        }
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
                return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}