using OfficeOpenXml;
using QUANGHANH2.Models;
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
        private const string V = "";

        // GET: Employees
        [Route("phong-tcld/danh-sach-toan-cong-ty")]
        public ActionResult ListAll()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/ListAll.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/xem-chi-tiet-nhan-vien")]
        [HttpGet]
        public ActionResult ViewInfor(string id)
        {
            List<SelectListItem> Genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "true" },
                new SelectListItem { Text = "Nữ", Value = "false" }
            };
            ViewBag.genders = Genders;

            List<SelectListItem> Level = new List<SelectListItem>
            {
                new SelectListItem { Text = "Tiểu Học", Value = "1" },
                new SelectListItem { Text = "THCS", Value = "2" },
                new SelectListItem { Text = "THPT", Value = "3" },
                new SelectListItem { Text = "Trung cấp", Value = "4" },
                new SelectListItem { Text = "Đại học", Value = "5" }
            };
            ViewBag.level = Level;
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

            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                return View("/Views/TCLD/Brief/View.cshtml", db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>());
            }
        }
        [Route("phong-tcld/quan-ly-nhan-vien/chinh-sua-nhan-vien")]
        [HttpGet]
        public ActionResult LoadEdit(string id)
        {
            List<SelectListItem> Genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "true" },
                new SelectListItem { Text = "Nữ", Value = "false" }
            };
            ViewBag.genders = Genders;

            List<SelectListItem> Level = new List<SelectListItem>
            {
                new SelectListItem { Text = "Tiểu Học", Value = "1" },
                new SelectListItem { Text = "THCS", Value = "2" },
                new SelectListItem { Text = "THPT", Value = "3" },
                new SelectListItem { Text = "Trung cấp", Value = "4" },
                new SelectListItem { Text = "Đại học", Value = "5" }
            };
            ViewBag.level = Level;
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

            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                return View("/Views/TCLD/Brief/Edit.cshtml", db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>());
            }
        }

        [HttpPost]
        public ActionResult SaveEdit(NhanVien emp)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                emp.TrangThaiLamViec = "Đang đi làm";
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Search");

        }
        //[Auther(RightID = "51")]
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien")]
        [HttpGet]
        public ActionResult List()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/List.cshtml");
        }

        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien/search")]
        [HttpPost]
        public ActionResult Search(string MaNV, string TenNV, string Gender)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string query = "select n.* from NhanVien n where n.TrangThaiLamViec = N'Đang đi làm' AND ";
            if(!MaNV.Equals("") || !TenNV.Equals("") || !Gender.Equals(""))
            {
                if (!MaNV.Equals("")) query += "n.MaNV LIKE @MaNV AND ";
                if (!TenNV.Equals("")) query += "n.Ten LIKE @Ten AND ";
                if (!Gender.Equals("")) query += "n.GioiTinh LIKE @GioiTinh AND ";
            }
            query = query.Substring(0, query.Length - 5);
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;
            bool GioiTinh = true;
            if(Gender.Equals("true"))
            {
                GioiTinh = true;
            }else if(Gender.Equals("false"))
            {
                GioiTinh = false;
            }
            List<NhanVien> searchList = db.Database.SqlQuery<NhanVien>(query,
                new SqlParameter("MaNV", '%' + MaNV + '%'),
                new SqlParameter("Ten", '%' + TenNV + '%'),
                new SqlParameter("GioiTinh", GioiTinh)
                ).ToList();
            int totalrows = searchList.Count;
            int totalrowsafterfiltering = searchList.Count;
            //sorting
            searchList = searchList.OrderBy(sortColumnName + " " + sortDirection).ToList<NhanVien>();
            //paging
            searchList = searchList.Skip(start).Take(length).ToList<NhanVien>();

            return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }

        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien")]
        [HttpPost]
        public ActionResult getAllNhanVien()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            db.Configuration.LazyLoadingEnabled = false;
            List<NhanVien> list = db.NhanViens.ToList<NhanVien>();
            //list = db.NhanViens.ToList<NhanVien>();
            list = db.Database.SqlQuery<NhanVien>("select n.* from NhanVien n where n.TrangThaiLamViec = N'Đang đi làm'").ToList();
            int totalrows = list.Count;
            int totalrowsafterfiltering = list.Count;
            //sorting
            list = list.OrderBy(sortColumnName + " " + sortDirection).ToList<NhanVien>();
            //paging
            list = list.Skip(start).Take(length).ToList<NhanVien>();

            return Json(new { data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }

        [Route("phong-tcld/quan-ly-nhan-vien/them-nhan-vien")]
        public ActionResult LoadAdd()
        {
            List<SelectListItem> Genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "true" },
                new SelectListItem { Text = "Nữ", Value = "false" }
            };
            ViewBag.genders = Genders;

            List<SelectListItem> Level = new List<SelectListItem>
            {
                new SelectListItem { Text = "Tiểu Học", Value = "1" },
                new SelectListItem { Text = "THCS", Value = "2" },
                new SelectListItem { Text = "THPT", Value = "3" },
                new SelectListItem { Text = "Trung cấp", Value = "4" },
                new SelectListItem { Text = "Đại học", Value = "5" }
            };
            ViewBag.level = Level;
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

            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/Add.cshtml");
        }

        [HttpPost]
        public ActionResult SaveAdd(NhanVien emp)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                emp.TrangThaiLamViec = "Đang đi làm";
                emp.MaPhongBan = "DL1";
                db.NhanViens.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Search");

                //return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
            }
        }

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
        [Route("delete")]
        [HttpPost]
        public JsonResult TLHD(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var emp = db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault();
                emp.TrangThaiLamViec = "Đã chấm dứt";
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json("", JsonRequestBehavior.AllowGet);

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
                    int k = 3;
                    for (int i = 0; i < list.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = list.ElementAt(i).MaNV;
                        excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).Ten;
                        if (list.ElementAt(i).GioiTinh)
                        {
                            excelWorksheet.Cells[k, 3].Value = "Nam";
                        }
                        else
                        {
                            excelWorksheet.Cells[k, 3].Value = "Nữ";
                        }
                        //excelWorksheet.Cells[k, 4].Value = list.ElementAt(i).NgaySinh.ToString("dd/MM/yyyy");
                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).SoBHXH;
                        if(list.ElementAt(i).TrinhDoHocVan != null)
                        {
                            if(list.ElementAt(i).TrinhDoHocVan.Equals("1"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "Tiểu học";
                            }else if(list.ElementAt(i).TrinhDoHocVan.Equals("2"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "THCS";
                            }else if(list.ElementAt(i).TrinhDoHocVan.Equals("3"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "THPT";
                            }else if(list.ElementAt(i).TrinhDoHocVan.Equals("4"))
                            {
                                excelWorksheet.Cells[k, 18].Value = "Trung cấp";
                            }else
                            {
                                excelWorksheet.Cells[k, 18].Value = "Đại học";
                            }
                        }
                        excelWorksheet.Cells[k, 20].Value = list.ElementAt(i).QueQuan;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/download/Danh_sách_nhân_viên.xlsx")));
                }
            }

        }
    }
}