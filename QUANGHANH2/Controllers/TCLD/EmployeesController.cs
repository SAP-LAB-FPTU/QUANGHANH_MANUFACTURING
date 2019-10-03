using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
//using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.TCLD
{
    public class EmployeesController : Controller
    {

        // GET: Employees
        [Route("phong-tcld/danh-sach-toan-cong-ty")]
        public ActionResult ListAll()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/ListAll.cshtml");
        }
        [Auther(RightID = "56")]
        [Route("phong-tcld/quan-ly-nhan-vien/xem-chi-tiet-nhan-vien")]
        [HttpGet]
        public ActionResult ViewInfor(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<SelectListItem> Month = new List<SelectListItem>();
                for (int i = 1; i <= 12; i++)
                {
                    Month.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                }

                ViewBag.months = Month;

                List<SelectListItem> Genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "true" },
                new SelectListItem { Text = "Nữ", Value = "false" }
            };
                ViewBag.genders = Genders;

                List<TrinhDo> Leveldb = db.TrinhDoes.ToList<TrinhDo>();
                List<SelectListItem> Level = new List<SelectListItem>();

                foreach (TrinhDo td in Leveldb)
                {
                    Level.Add(new SelectListItem { Text = td.TenTrinhDo.Trim(), Value = td.MaTrinhDo.ToString() });
                }

                ViewBag.level = Level;
                List<CongViec> Jobdb = db.CongViecs.ToList<CongViec>();

                List<SelectListItem> Job = new List<SelectListItem>();

                foreach (CongViec cv in Jobdb)
                {
                    Job.Add(new SelectListItem { Text = cv.TenCongViec.Trim(), Value = cv.MaCongViec.ToString() });
                    if (db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>().MaCongViec == cv.MaCongViec)
                    {
                        ViewBag.loadJob = cv.TenCongViec.Trim();
                    }
                }
                ViewBag.job = Job;
                List<SelectListItem> Heal = new List<SelectListItem>
            {
                new SelectListItem { Text = "Khỏe", Value = "khoe" },
                new SelectListItem { Text = "Bình thường", Value = "binhthuong" },
                new SelectListItem { Text = "Yếu", Value = "yeu" },
                new SelectListItem { Text = "Bệnh mãn tính", Value = "benhmantinh" }
            };
                ViewBag.heal = Heal;
                List<SelectListItem> ThuongBinh = new List<SelectListItem>
            {
                new SelectListItem { Text = "Không", Value = "0" },
                new SelectListItem { Text = "1/4(Thương tật 81% trở lên)", Value = "1" },
                new SelectListItem { Text = "2/4(Thương tật từ 61% trở lên)", Value = "2" },
                new SelectListItem { Text = "3/4(Thương tật từ 41% trở lên)", Value = "3" },
                new SelectListItem { Text = "4/4(Thương tật từ 21% trở lên)", Value = "4" }
            };
                ViewBag.thuongbinh = ThuongBinh;

                return View("/Views/TCLD/Brief/View.cshtml", db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>());
            }
        }
        [Auther(RightID = "53")]
        [Route("phong-tcld/quan-ly-nhan-vien/chinh-sua-nhan-vien")]
        [HttpGet]
        public ActionResult LoadEdit(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<SelectListItem> Month = new List<SelectListItem>();
                for (int i = 1; i <= 12; i++)
                {
                    Month.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                }

                ViewBag.months = Month;
                List<SelectListItem> Genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "true" },
                new SelectListItem { Text = "Nữ", Value = "false" }
            };
                ViewBag.genders = Genders;

                List<TrinhDo> Leveldb = db.TrinhDoes.ToList<TrinhDo>();
                List<SelectListItem> Level = new List<SelectListItem>();

                foreach (TrinhDo td in Leveldb)
                {
                    Level.Add(new SelectListItem { Text = td.TenTrinhDo.Trim(), Value = td.MaTrinhDo.ToString() });
                }

                ViewBag.level = Level;
                List<CongViec> Jobdb = db.CongViecs.ToList<CongViec>();

                List<SelectListItem> Job = new List<SelectListItem>();

                foreach (CongViec cv in Jobdb)
                {
                    Job.Add(new SelectListItem { Text = cv.TenCongViec.Trim(), Value = cv.MaCongViec.ToString() });
                    if (db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>().MaCongViec == cv.MaCongViec)
                    {
                        ViewBag.loadJob = cv.TenCongViec.Trim();
                    }
                }
                ViewBag.job = Job;
                List<SelectListItem> Heal = new List<SelectListItem>
            {
                new SelectListItem { Text = "Khỏe", Value = "khoe" },
                new SelectListItem { Text = "Bình thường", Value = "binhthuong" },
                new SelectListItem { Text = "Yếu", Value = "yeu" },
                new SelectListItem { Text = "Bệnh mãn tính", Value = "benhmantinh" }
            };
                ViewBag.heal = Heal;
                List<SelectListItem> ThuongBinh = new List<SelectListItem>
            {
                new SelectListItem { Text = "Không", Value = "0" },
                new SelectListItem { Text = "1/4(Thương tật 81% trở lên)", Value = "1" },
                new SelectListItem { Text = "2/4(Thương tật từ 61% trở lên)", Value = "2" },
                new SelectListItem { Text = "3/4(Thương tật từ 41% trở lên)", Value = "3" },
                new SelectListItem { Text = "4/4(Thương tật từ 21% trở lên)", Value = "4" }
            };
                ViewBag.thuongbinh = ThuongBinh;


                return View("/Views/TCLD/Brief/Edit.cshtml", db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>());
            }
        }
        [Auther(RightID = "53")]
        [HttpPost]
        public ActionResult SaveEdit(NhanVien emp, string test, string[] giaDinh, string[] ngaySinhGiaDinh, string[] hoTen, string[] moiQuanHe, string[] lyLich)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                List<CongViec> Jobdb = db.CongViecs.ToList<CongViec>();
                foreach (CongViec cv in Jobdb)
                {
                    if (test.Trim().Equals(cv.TenCongViec.Trim()))
                    {
                        emp.MaCongViec = cv.MaCongViec;
                        break;
                    }
                }
                QuanHeGiaDinh gd = new QuanHeGiaDinh();
                for (int i = 0; i < giaDinh.Length; i++)
                {
                    gd.MaNV = emp.MaNV;
                    gd.LoaiGiaDinh = giaDinh[i];
                    if (ngaySinhGiaDinh[i] != "")
                    {
                        string[] date = ngaySinhGiaDinh[i].Split('/');
                        gd.NgaySinh = Convert.ToDateTime(date[1] + "/" + date[0] + "/" + date[2]);
                    }
                    gd.HoTen = hoTen[i];
                    gd.MoiQuanHe = moiQuanHe[i];
                    gd.LyLich = lyLich[i];
                    db.QuanHeGiaDinhs.Add(gd);
                    db.SaveChanges();

                }
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                dbct.Commit();


            }
            return RedirectToAction("Search");

        }
        [Auther(RightID = "51")]
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien")]
        [HttpGet]
        public ActionResult List()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/List.cshtml");
        }

        public class NhanVienLink : NhanVien
        {
            public string TenTrangThai { get; set; }
            public string TenTrinhDo { get; set; }
            public string TenCongViec { get; set; }
        }
        [Auther(RightID = "51")]
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien")]
        [HttpPost]
        public ActionResult Search(string MaNV, string TenNV, string Gender)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string query = "select n.*, t.TenTrangThai from NhanVien n inner join" +
                " [TrangThai] t on n.MaTrangThai = t.MaTrangThai " +
                "where n.MaTrangThai = 1 AND ";
            if (!MaNV.Equals("") || !TenNV.Equals("") || !Gender.Equals(""))
            {
                if (!MaNV.Equals("")) query += "n.MaNV LIKE @MaNV AND ";
                if (!TenNV.Equals("")) query += "n.Ten LIKE @Ten AND ";
                if (!Gender.Equals("")) query += "n.GioiTinh LIKE @GioiTinh AND ";
            }
            query = query.Substring(0, query.Length - 5);
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;
            bool GioiTinh = true;
            if (Gender.Equals("true"))
            {
                GioiTinh = true;
            }
            else if (Gender.Equals("false"))
            {
                GioiTinh = false;
            }
            List<NhanVienLink> searchList = db.Database.SqlQuery<NhanVienLink>(query,
                new SqlParameter("MaNV", '%' + MaNV + '%'),
                new SqlParameter("Ten", '%' + TenNV + '%'),
                new SqlParameter("GioiTinh", GioiTinh)
                ).ToList();
            int totalrows = searchList.Count;
            int totalrowsafterfiltering = searchList.Count;
            //sorting
            searchList = searchList.OrderBy(sortColumnName + " " + sortDirection).ToList<NhanVienLink>();
            //paging
            searchList = searchList.Skip(start).Take(length).ToList<NhanVienLink>();

            return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }

        //[Route("phong-tcld/quan-ly-nhan-vien/them-nhan-vien")]
        //public ActionResult LoadAdd()
        //{
        //    List<SelectListItem> Genders = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Nam", Value = "true" },
        //        new SelectListItem { Text = "Nữ", Value = "false" }
        //    };
        //    ViewBag.genders = Genders;

        //    List<SelectListItem> Level = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Tiểu Học", Value = "1" },
        //        new SelectListItem { Text = "THCS", Value = "2" },
        //        new SelectListItem { Text = "THPT", Value = "3" },
        //        new SelectListItem { Text = "Trung cấp", Value = "4" },
        //        new SelectListItem { Text = "Đại học", Value = "5" }
        //    };
        //    ViewBag.level = Level;
        //    List<SelectListItem> Heal = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Khỏe", Value = "khoe" },
        //        new SelectListItem { Text = "Bình thường", Value = "binhthuong" },
        //        new SelectListItem { Text = "Yếu", Value = "yeu" },
        //        new SelectListItem { Text = "Bệnh mãn tính", Value = "benhmantinh" }
        //    };
        //    ViewBag.heal = Heal;
        //    List<SelectListItem> ThuongBinh = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Không", Value = "0" },
        //        new SelectListItem { Text = "1/4(Thương tật 81% trở lên)", Value = "1" },
        //        new SelectListItem { Text = "2/4(Thương tật từ 61% trở lên)", Value = "2" },
        //        new SelectListItem { Text = "3/4(Thương tật từ 41% trở lên)", Value = "3" },
        //        new SelectListItem { Text = "4/4(Thương tật từ 21% trở lên)", Value = "4" }
        //    };
        //    ViewBag.thuongbinh = ThuongBinh;

        //    ViewBag.nameDepartment = "baohiem";
        //    return View("/Views/TCLD/Brief/Add.cshtml");
        //}

        //[HttpPost]
        //public ActionResult SaveAdd(NhanVien emp)
        //{
        //    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        //    {
        //        emp.MaTrangThai = 1;
        //        emp.MaPhongBan = "DL1";
        //        db.NhanViens.Add(emp);
        //        db.SaveChanges();
        //        return RedirectToAction("Search");


        //        //return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [Route("phong-tcld/quan-ly-nhan-vien/lich-su-lam-viec")]
        public ActionResult WorkHistory()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-chuyen")]
        public ActionResult TransferHistory()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/TransferHistory.cshtml");
        }
        [Auther(RightID = "55")]
        [Route("delete")]
        [HttpPost]
        public ActionResult TLHD(string id, string soQD, string lydo, string dateTLHD, string group1, string group2, string elseCase)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    QuyetDinh qd = new QuyetDinh();
                    List<QuyetDinh> qdList = db.QuyetDinhs.ToList<QuyetDinh>();
                    if (!soQD.Equals(""))
                    {
                        foreach (var qdL in qdList)
                        {
                            if (soQD == qdL.SoQuyetDinh)
                            {
                                return Json(new { message = "Số quyết định đã tồn tại", success = "soQDExist" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    string[] arr2 = dateTLHD.Split('/');
                    string dateTLHDFix = "";
                    for (int i = 0; i < arr2.Length; i++)
                    {
                        dateTLHDFix = arr2[1] + "/" + arr2[0] + "/" + arr2[2];
                    }
                    var emp = db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault();
                    if (soQD.Equals(""))
                    {
                        emp.MaTrangThai = 4;
                    }
                    else
                    {
                        emp.MaTrangThai = 2;
                    }
                    db.Entry(emp).State = EntityState.Modified;

                    qd.SoQuyetDinh = soQD;
                    qd.NgayQuyetDinh = DateTime.Today;
                    db.QuyetDinhs.Add(qd);

                    ChamDut_NhanVien tlhd = new ChamDut_NhanVien();
                    tlhd.MaNV = id;
                    if (lydo.Equals("Đi đơn vị ngoài"))
                    {
                        tlhd.LoaiChamDut = group1;
                    }
                    else if (lydo.Equals("Các trường hợp khác"))
                    {
                        if (group2.Equals("on"))
                        {
                            tlhd.LoaiChamDut = elseCase;
                        }
                        else
                        {
                            tlhd.LoaiChamDut = group2;
                        }
                    }
                    else
                    {
                        tlhd.LoaiChamDut = lydo;
                    }
                    tlhd.NgayChamDut = Convert.ToDateTime(dateTLHDFix);
                    db.ChamDut_NhanVien.Add(tlhd);
                    db.SaveChanges();
                    dbct.Commit();
                    return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    dbct.Rollback();
                    return Json(new { success = true , message = "Chưa nhập ngày chấm dứt" }, JsonRequestBehavior.AllowGet);

                }



            }

        }
        public class NhanVienExcel : NhanVien
        {
            public string TenTrinhDo { get; set; }

            public string TenChuyenNganh { get; set; }

            public string TenCongViec { get; set; }
            public string ThangLuong { get; set; }


        }

        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien/excel")]
        [HttpPost]
        public void ReturnExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Brief/Danh-sách-nhân-viên.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string query = "select * from NhanVien";
                    List<NhanVien> list = db.Database.SqlQuery<NhanVien>(query).ToList();
                    int k = 4;
                    for (int i = 0; i < list.Count; i++)
                    {

                        excelWorksheet.Cells[k, 1].Value = i + 1;
                        excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).MaNV;
                        excelWorksheet.Cells[k, 3].Value = list.ElementAt(i).Ten;
                        if (list.ElementAt(i).GioiTinh)
                        {
                            excelWorksheet.Cells[k, 4].Value = "Nam";
                        }
                        else
                        {
                            excelWorksheet.Cells[k, 4].Value = "Nữ";
                        }
                        excelWorksheet.Cells[k, 4].Value = list.ElementAt(i).NgaySinh.HasValue ? list.ElementAt(i).NgaySinh.Value.ToString("dd/MM/yyyy") : "";
                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).SoBHXH;
                        if (list.ElementAt(i).MaTrinhDo != null)
                        {
                            if (list.ElementAt(i).MaTrinhDo.Equals("1"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "Tiểu học";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("2"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "THCS";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("3"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "THPT";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("4"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "Trung cấp";
                            }
                            else
                            {
                                excelWorksheet.Cells[k, 18].Value = "Đại học";
                            }
                        }
                        excelWorksheet.Cells[k, 20].Value = list.ElementAt(i).QueQuan;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/download/Danh-sách-nhân-viên.xlsx")));
                }
            }

        }
    }
}