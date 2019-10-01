using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace QUANGHANH2.Controllers.TCLD
{
    public class DiplomaController : Controller
    {
        // GET: Diploma
        [Route("phong-tcld/bang-cap-va-giay-chung-nhan/danh-sach-bang-cap-va-giay-chung-nhan")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Diploma/List.cshtml");
        }
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                listdataDip = (from bc in db.BangCap_GiayChungNhan
                               join cn in db.ChuyenNganhs on bc.MaChuyenNghanh equals cn.MaChuyenNganh
                               join td in db.TrinhDoes on bc.MaTrinhDo equals td.MaTrinhDo
                               join truong in db.Truongs on bc.MaTruong equals truong.MaTruong
                               select new
                               {
                                   MaTruong = bc.MaTruong,
                                   MaChuyenNghanh = bc.MaChuyenNghanh,
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
                                   MaChuyenNghanh = bangcap.MaChuyenNghanh,
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                listdataDipEmp = (from bc_chitiet in db.ChiTiet_BangCap_GiayChungNhan
                               join nv in db.NhanViens on bc_chitiet.MaNV equals nv.MaNV
                               join bc in db.BangCap_GiayChungNhan on bc_chitiet.MaBangCap_GiayChungNhan equals bc.MaBangCap_GiayChungNhan
                               select new
                               {
                                   SoHieu=bc_chitiet.SoHieu,
                                   MaBangCap_GiayChungNhan=bc_chitiet.MaBangCap_GiayChungNhan,
                                   NgayCap=bc_chitiet.NgayCap,
                                   MaNV=bc_chitiet.MaNV,
                                   NgayTra= bc_chitiet.NgayTra,
                                   TenBangCap=bc.TenBangCap,
                                   TenNV=nv.Ten,
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
        [HttpGet]
        public ActionResult AddDiploma()
        {
            getDataSelectDiploma();
            return View();

        }
        [HttpPost]
        public ActionResult AddDiploma(BangCap_GiayChungNhan bangcap)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (bangcap != null)
                {

                    db.BangCap_GiayChungNhan.Add(bangcap);
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }


        }
        //Add Diploma's Employee
        [HttpGet]
        public ActionResult AddDiplomaEmployee()
        {

            getDataSelectDiplomaEmployee();
            return View();

        }
        [HttpPost]
        public ActionResult AddDiplomaEmployee(ChiTiet_BangCap_GiayChungNhan chitietbangcap)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
        [HttpGet]
        public ActionResult EditDiploma(int id = 0)
        {
            getDataSelectDiploma();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                BangCap_GiayChungNhan bc = db.BangCap_GiayChungNhan.Where(x => x.MaBangCap_GiayChungNhan == id).FirstOrDefault<BangCap_GiayChungNhan>();
                return View(bc);
            }

        }
        [HttpPost]
        public ActionResult EditDiploma(BangCap_GiayChungNhan bangcap)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (bangcap != null)
                {
                    db.Entry(bangcap).State = EntityState.Modified;
                    db.SaveChanges();
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
            SelectList listTypesDip = new SelectList(listTypesDiploma, "Value", "Value");
            ViewBag.listTypesDip = listTypesDip;

            Dictionary<int, string> list_loai = new Dictionary<int, string>();
            list_loai.Add(1, "Bằng cấp");
            list_loai.Add(2, "Giấy chứng nhận");
            SelectList listSelectListTypeDip = new SelectList(list_loai, "Value", "Value");
            ViewBag.listSelectListTypeDip = listSelectListTypeDip;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
       //Delete Diploma
        [HttpPost]
        public ActionResult DeleteDiploma(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
                return Json(new { success = true, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);

            }
        }
        //Delete Diploma's Employee
        [HttpPost]
        public ActionResult DeleteDiplomaEmployee(string id )
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
        //Set dropdown for Diploma's Employee
        public void getDataSelectDiplomaEmployee()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<BangCap_GiayChungNhan> listdata_bangcap = db.BangCap_GiayChungNhan.ToList<BangCap_GiayChungNhan>();
                List<NhanVien> listdata_nv = db.NhanViens.ToList<NhanVien>();
                SelectList listSelect_bangcap = new SelectList(listdata_bangcap, "MaBangCap_GiayChungNhan", "TenBangCap");
                SelectList listSelect_nhanvien = new SelectList(listdata_nv, "MaNV", "MaNV");
                ViewBag.listSelect_nhanvien = listSelect_nhanvien;
                ViewBag.listSelect_bangcap = listSelect_bangcap;

            }
        }
        //Edit Diploma's Emp
        [HttpGet]
        public ActionResult EditDiplomaEmployee(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
        [HttpPost]
        public ActionResult EditDiplomaEmployee(ChiTiet_BangCap_GiayChungNhan chitiet_bc)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (truong_text != null || nganh_text != null || trinhdo_text != null|| bangcap_text != null)
                {
                    listdataDip = (from bc in db.BangCap_GiayChungNhan
                                   where (bc.TenBangCap.Contains(bangcap_text))
                                   join cn in db.ChuyenNganhs on bc.MaChuyenNghanh equals cn.MaChuyenNganh
                                   where (cn.TenChuyenNganh.Contains(nganh_text))
                                   join td in db.TrinhDoes on bc.MaTrinhDo equals td.MaTrinhDo
                                   where (td.TenTrinhDo.Contains(trinhdo_text))
                                   join truong in db.Truongs on bc.MaTruong equals truong.MaTruong
                                   where (truong.TenTruong.Contains(truong_text))
                                   select new
                                   {
                                       MaTruong = bc.MaTruong,
                                       MaChuyenNghanh = bc.MaChuyenNghanh,
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
                                       MaChuyenNghanh = bangcap.MaChuyenNghanh,
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (sohieu_text != null || bangcap_text != null || tennv_text != null)
                {
                    listdataDipEmp = (from bc_chitiet in db.ChiTiet_BangCap_GiayChungNhan
                                      join nv in db.NhanViens on bc_chitiet.MaNV equals nv.MaNV
                                      join bc in db.BangCap_GiayChungNhan on bc_chitiet.MaBangCap_GiayChungNhan equals bc.MaBangCap_GiayChungNhan
                                      where (bc_chitiet.SoHieu.Contains(sohieu_text))&(nv.Ten.Contains(tennv_text))&(bc.TenBangCap.Contains(bangcap_text))
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var chungchi_nvs = db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>();
                if (chungchi_nvs != null)
                {
                    return Json(new { data = chungchi_nvs.Ten, success = true, message = "ok" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data="Không tồn tại",success = false, message = "wrong" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        //Check Employee have ẽ yet?
        public ActionResult validateExistDiplomaOfEmp(string manv, int mabangcap, string first_diploma)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
    }
}