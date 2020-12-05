
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class BriefController : Controller
    {
        // GET: /<controller>/

        public static string id_ = "";
        [Auther(RightID = "129")]
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty")]
        [HttpGet]
        public ActionResult Inside()
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

            List <Custom_Employee> employee_list = db.Database.SqlQuery<Custom_Employee>("select employee_id,BASIC_INFO_full_name as employee_name from HumanResources.Employee").ToList();
            
            List<SelectListItem> type_papers = new List<SelectListItem>
            {
                new SelectListItem { Text = "Gốc", Value = "Gốc" },
                new SelectListItem { Text = "Dấu đỏ", Value = "Dấu đỏ" },
                new SelectListItem { Text = "Sao,Công chứng", Value = "Sao,Công chứng" },
                new SelectListItem { Text = "Photo", Value = "Photo" }
            };


            ViewBag.type_papers = type_papers;
            ViewBag.nameDepartment = "quanlyhoso";
            ViewBag.employee_list = employee_list;

            return View("/Views/TCLD/Brief/ManageBrief/Inside.cshtml");
        }
        /// /////////////////////////Long/////////////////////////////////////////////

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/giay-to")]
        IEnumerable<Employee> getAllNhanVien()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                return db.Employees.ToList<Employee>();
            }
        }
        
        //Sửa giấy tờ
        [Auther(RightID = "147")]
        [HttpPost]
        public ActionResult suaGiayTo(Paper document)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                try
                {
                    db.Entry(document).State = EntityState.Modified;//
                    db.SaveChanges();

                    return RedirectToAction("GetAllDocuments");
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }

            }


        }
        [Auther(RightID = "147")]
        [HttpGet]
        public ActionResult suaGiayTo(string id)
        {

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                //tạo data bên popup của sửa giấy tờ
                List<SelectListItem> KieuGT = new List<SelectListItem>
                    {
                        new SelectListItem { Text = "Gốc", Value = "Gốc" },
                        new SelectListItem { Text = "Dấu đỏ", Value = "Dấu đỏ" },
                        new SelectListItem { Text = "Sao,Công chứng", Value = "Sao,Công chứng" },
                        new SelectListItem { Text = "Photo", Value = "Photo" }
                    };
                ViewBag.kindODoc = KieuGT;
                Paper doc = new Paper();
                var documents = db.Papers.ToList<Paper>();
                doc = db.Papers.Where(x => x.papers_id.ToString() == id).FirstOrDefault<Paper>();
                return View(doc);
            }
        }
        //thêm giấy tờ
        //[Auther(RightID = "157")]
        //[HttpGet]
        //public ActionResult themGiayTo()
        //{
        //    List<SelectListItem> type_papers = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Gốc", Value = "Gốc" },
        //        new SelectListItem { Text = "Dấu đỏ", Value = "Dấu đỏ" },
        //        new SelectListItem { Text = "Sao,Công chứng", Value = "Sao,Công chứng" },
        //        new SelectListItem { Text = "Photo", Value = "Photo" }
        //    };
        //    ViewBag.type_papers = type_papers;
        //    return View(new Paper());
        //}

        
        [Auther(RightID = "157")]
        [HttpPost]
        //public ActionResult themGiayTo(Paper g)
        //{

        //    var a = getAllNhanVien();
        //    ViewBag.nhanvien = a;
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        try
        //        {
        //            db.Papers.Add(g);
        //            db.SaveChanges();
        //        }
        //        catch (Exception)
        //        {

        //            return Json(new { message = "Failed" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return RedirectToAction("Inside");
        //}

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/giay-to/them")]
        public ActionResult themGiayTo(string employee_id, string employee_name, string paper_name, string type_name)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                try
                {
                    
                    //db.SaveChanges();
                }
                catch (Exception)
                {

                    return Json(new { message = "Failed" }, JsonRequestBehavior.AllowGet);
                }
            }
            return RedirectToAction("Inside");
        }

        private string getPaperTypeID(string paper_name)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            string papers_type_id = db.Database.SqlQuery<string>("select papers_type_id from HumanResources.PapersType where name = N@paper_name", new SqlParameter("paper_name", paper_name)).First();
            return papers_type_id;

        }

        private string getPaperStorageTypeID(string type_name) 
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            string papers_storage_type_id = db.Database.SqlQuery<string>("select papers_storage_type_id from HumanResources.PapersStorageType where name = N@type_name", new SqlParameter("type_name", type_name)).First();
            return type_name;
        }

        //check id của nhân viên
        [HttpPost]
        public ActionResult validateID(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                Employee nv = db.Employees.Where(x => x.employee_id == id).FirstOrDefault<Employee>();
                if (nv == null || nv.current_status_id == 2)
                {
                    return Json(new { success = true, responseText = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = nv.BASIC_INFO_full_name }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [Auther(RightID = "148")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteDoc(int id)
        {
            //id = id.Substring(1, id.Length - 2);
            //nameOfDoc = nameOfDoc.Substring(1, nameOfDoc.Length - 2);
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    Paper emp = db.Papers.Where(x => x.papers_id == id).FirstOrDefault<Paper>();
                    db.Papers.Remove(emp);
                    db.SaveChanges();
                    List<Paper> list = new List<Paper>();
                    //List<Paper> list = db.Database.SqlQuery<TenNV>("select n.Ten,g.* from GiayTo g, NhanVien n where g.MaNV = n.MaNV").ToList<Paper>();
                    return Json(new { success = true, responseText = "Your message successfuly sent!", list }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }

        //*cancel
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/giay-to")]
        [HttpPost]
        public ActionResult Search(string employee_id, string employee_name, string paper_name, string type_name)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            
            string query = @"select e.employee_id,e.BASIC_INFO_full_name as employee_name ,pt.name as paper_name, pst.name as type_name
                    , p.papers_id from HumanResources.Employee e
                    inner join HumanResources.Records r on r.employee_id = e.employee_id
                    inner join HumanResources.RecordsPapers rp on rp.records_id = r.records_id
                    inner join HumanResources.Papers p on rp.papers_id = p.papers_id
					inner join HumanResources.PapersType pt on pt.papers_type_id = p.papers_type_id
                    inner join HumanResources.PapersStorageType pst 
                    on pst.papers_storage_type_id = rp.papers_storage_type_id where e.current_status_id != 2  ";


            if (!employee_id.Equals("") || !employee_name.Equals("") || !paper_name.Equals("") || !type_name.Equals(""))
            {
                if (!employee_id.Equals("")) query += " AND e.employee_id like @employee_id ";
                if (!employee_name.Equals("")) query += "AND e.BASIC_INFO_full_name LIKE @employee_name ";
                if (!paper_name.Equals("")) query += "AND pt.name LIKE @paper_name ";
                if (!type_name.Equals("")) query += "AND pst.name LIKE @paper_storage_type_name ";
            }


            List<Relevant_Paper> searchList = db.Database.SqlQuery<Relevant_Paper>(query,
                new SqlParameter("employee_id", '%' + employee_id + '%'),
                new SqlParameter("employee_name", '%' + employee_name + '%'),
                new SqlParameter("paper_name", '%' + paper_name + '%'),
                new SqlParameter("paper_storage_type_name", type_name)
                ).ToList();

            int totalrows = searchList.Count;
            int totalrowsafterfiltering = searchList.Count;
            //sorting
            searchList = searchList.OrderBy(sortColumnName + " " + sortDirection).ToList<Relevant_Paper>();
            //paging
            searchList = searchList.Skip(start).Take(length).ToList<Relevant_Paper>();
            if (employee_id.Trim() != "")
            {
                if (checkEm(employee_id) == false)
                {
                    return Json(new { data = searchList, message = "Failed_Search", draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }




        public Boolean checkEm(string manv)
        {
            Employee em = null;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                em = db.Employees.Where(x => x.employee_id.Trim().Equals(manv.Trim())).FirstOrDefault<Employee>();
            }
            if (em != null)
            {
                if (em.current_status_id != 2)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }


        //listByThuong
        [Auther(RightID = "129")]
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty")]
        [HttpPost]
        //public ActionResult listAllHoSo()
        //{

        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        db.Configuration.LazyLoadingEnabled = false;

        //        int start = Convert.ToInt32(Request["start"]);
        //        int length = Convert.ToInt32(Request["length"]);
        //        string searchValue = Request["search[value]"];
        //        string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
        //        string sortDirection = Request["order[0][dir]"];
        //        List<HoSoNhanVien> hs_nv = new List<HoSoNhanVien>();
        //        //hs_nv = (from nv in db.Employees6
        //        //         join hs in db.Records
        //        //         on nv.employee_id equals hs.employee_id
        //        //         where nv.current_status_id != 2
        //        //         select new
        //        //         {
        //        //             maNV = hs.employee_id,
        //        //             ten = nv.BASIC_INFO_full_name,
        //        //             ngaysinh = nv.BASIC_INFO_date_of_birth,
        //        //             nguoiGiaoHoSo = hs.delivery_employee_id,
        //        //             ngayNhanHoSo = hs.received_date,
        //        //             nguoiGiuHoSo = hs.management_employee_id
        //        //         }).ToList().Select(p => new HoSoNhanVien
        //        //         {
        //        //             MaNV = p.maNV,
        //        //             Ten = p.ten,
        //        //             NgaySinh = p.ngaysinh,
        //        //             NguoiGiaoHoSo = p.nguoiGiaoHoSo,
        //        //             NgayNhanHoSo = p.ngayNhanHoSo,
        //        //             NguoiGiuHoSo = p.nguoiGiuHoSo

        //        //         }).ToList();

        //        int totalrows = hs_nv.Count;
        //        int totalrowsafterfiltering = hs_nv.Count;
        //        hs_nv = hs_nv.OrderBy(sortColumnName + " " + sortDirection).ToList<HoSoNhanVien>();
        //        //paging
        //        hs_nv = hs_nv.Skip(start).Take(length).ToList<HoSoNhanVien>();
        //        var dataJson = Json(new { success = true, data = hs_nv, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        //        string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

        //        return dataJson;
        //    }

        //}

        public ActionResult listAllHoSo()
        {

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                List<HoSoNhanVien> hs_nv = new List<HoSoNhanVien>();
                

                int totalrows = hs_nv.Count;
                int totalrowsafterfiltering = hs_nv.Count;
                hs_nv = hs_nv.OrderBy(sortColumnName + " " + sortDirection).ToList<HoSoNhanVien>();
                //paging
                hs_nv = hs_nv.Skip(start).Take(length).ToList<HoSoNhanVien>();
                var dataJson = Json(new { success = true, data = hs_nv, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }

        }

        //detailByThuong
        [Auther(RightID = "129")]
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-chi-tiet")]
        [HttpGet]
        public ActionResult InsideDetail(string id = "")
        {
            id_ = id;
            ViewBag.MaNV = id;
            return View("/Views/TCLD/Brief/ManageBrief/InsideDetail.cshtml");
        }

        [Auther(RightID = "129")]
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-ho-so")]
        [HttpPost]
        public ActionResult listHoSo(string id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();


            var HoSoByMaNV = from hs in db.Records
                             join nv in db.Employees on hs.employee_id equals nv.employee_id
                             where nv.employee_id == id
                             select new
                             {
                                 maNV = hs.employee_id,
                                 ten = nv.BASIC_INFO_full_name,
                                 nguoiGiuHoSo = hs.management_employee_id,
                                 ngayNhanHoSo = hs.received_date,
                                 nguoiGiaoHoSo = hs.delivery_employee_id
                                 //camKetTuyenDung = hs.CamKetTuyenDung,
                                 //quyetDinhTiepNhan = hs.QuyetDinhTiepNhanDVC,
                                 //nguoiBanGiaoBangNhapKho = hs.NguoiBanGiaoBangNhapKho,


                                 //quyetDinhTiepNhanDVC = hs.QuyetDinhTiepNhanDVC,
                                 //ngayQDTiepNhan = hs.NgayQuyetDinhTuyenDung,
                                 //ngayDiLam = hs.NgayDiLam,
                                 //donViKyQuyetDinhTiepNhan = hs.DonViKyQuyetDinhTiepNhan,
                                 //quyetDinhChamDut = hs.QDChamDutHopDongDVC,
                                 //ngayQDChamDut = hs.NgayQuyetDinhChamDut,
                                 //ngayChamDut = hs.NgayChamDut,
                                 //donViKyChamDut = hs.DonViKyQuyetDinhChamDut
                             };
            var dataJson = Json(new { success = true, data = HoSoByMaNV });




            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;
        }

        [Auther(RightID = "130")]
        [HttpPost]
        public ActionResult listNhanVien()
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<Employee> listNhanVien = db.Employees.ToList();
            foreach (var nvt in listNhanVien)
            {
                if (nvt.employee_id.Equals(id_))
                {
                    //if (nvt.MaTrinhDo != null)
                    //{
                    //    var nhanVien = (from nv in db.NhanViens
                    //                    from td in db.TrinhDoes
                    //                    where (nv.MaNV == id_)
                    //                    && (td.MaTrinhDo == nv.MaTrinhDo)

                    //                    select new
                    //                    {
                    //                        maNV = nv.MaNV,
                    //                        ten = nv.Ten,
                    //                        ngaySinh = nv.NgaySinh,
                    //                        soCMND = nv.SoCMND,
                    //                        soBHXH = nv.SoBHXH,
                    //                        soDT = nv.SoDienThoai,
                    //                        queQuan = nv.QueQuan,
                    //                        noiOHientai = nv.NoiOHienTai,
                    //                        trinhDoHocVan = td.TenTrinhDo

                    //                    });
                    //    return Json(new { success = true, data = nhanVien, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
                    //}
                    //else
                    //{
                    //    var nhanVien = (from nv in db.NhanViens
                    //                    from td in db.TrinhDoes
                    //                    where (nv.MaNV == id_)

                    //                    select new
                    //                    {
                    //                        maNV = nv.MaNV,
                    //                        ten = nv.Ten,
                    //                        ngaySinh = nv.NgaySinh,
                    //                        soCMND = nv.SoCMND,
                    //                        soBHXH = nv.SoBHXH,
                    //                        soDT = nv.SoDienThoai,
                    //                        queQuan = nv.QueQuan,
                    //                        noiOHientai = nv.NoiOHienTai,
                    //                        trinhDoHocVan = ""

                    //                    });
                    //    return Json(new { success = true, data = nhanVien, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
                    //}
                }
            }

            return Json(new { success = false, data = "", draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
        }


        //[Auther(RightID = "130")]
        //[Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/syll-bo-sung")]
        //[HttpPost]
        //public ActionResult listLichSuBoSung(string id)
        //{
        //    QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();


        //    var LichSuBoSungByMaNV = from lsbs in db.AdditionalHistoryResumes
        //                             join nv in db.Employees on lsbs.MaN equals nv.MaNV
        //                             where lsbs.MaNV == id_
        //                             select new
        //                             {
        //                                 maNV = nv.MaNV,
        //                                 ten = nv.Ten,
        //                                 namBoSung = lsbs.NamBoSung

        //                             };
        //    var dataJson = Json(new { success = true, data = LichSuBoSungByMaNV });

        //    string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

        //    return dataJson;
        //}

        //[Auther(RightID = "130")]
        //[Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-giay-to")]
        //[HttpPost]
        //public ActionResult listGiayTo()
        //{
        //    QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();


        //    var giayToMaNV = from gt in db.GiayToes
        //                     join nv in db.NhanViens on gt.MaNV equals nv.MaNV
        //                     where gt.MaNV == id_
        //                     select new
        //                     {
        //                         maNV = nv.MaNV,
        //                         ten = nv.Ten,
        //                         tenGiayTo = gt.TenGiayTo,
        //                         maGiayTo = gt.MaGiayTo,
        //                         kieuGiayTo = gt.KieuGiayTo,
        //                         ngayTra = gt.NgayTra.ToString()
        //                     };
        //    var dataJson = Json(new { success = true, data = giayToMaNV }, JsonRequestBehavior.AllowGet);

        //    string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

        //    return dataJson;

        //}
        //[Auther(RightID = "130")]
        //[Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-bang-cap")]
        //[HttpPost]
        //public ActionResult chiTietbangCap()
        //{
        //    QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();


        //    var chiTietBangCapByMaNV = from ctbc in db.ChiTiet_BangCap_GiayChungNhan
        //                               join nv in db.NhanViens on ctbc.MaNV equals nv.MaNV
        //                               join bc in db.BangCap_GiayChungNhan on ctbc.MaBangCap_GiayChungNhan equals bc.MaBangCap_GiayChungNhan
        //                               join truong in db.Truongs on bc.MaTruong equals truong.MaTruong
        //                               join cn in db.ChuyenNganhs on bc.MaChuyenNganh equals cn.MaChuyenNganh
        //                               join nganh in db.Nganhs on cn.MaNganh equals nganh.MaNganh
        //                               where
        //                                ctbc.MaNV == id_
        //                               select new
        //                               {
        //                                   maNV = nv.MaNV,
        //                                   ten = nv.Ten,
        //                                   soHieu = ctbc.SoHieu,
        //                                   maBangCap = ctbc.MaBangCap_GiayChungNhan,
        //                                   ngayCap = ctbc.NgayCap,
        //                                   loai = bc.Loai,
        //                                   truong = truong.TenTruong,
        //                                   tenBangCap = bc.TenBangCap,
        //                                   kieu = bc.KieuBangCap,
        //                                   chuyenNganh = cn.TenChuyenNganh,
        //                                   nganh = nganh.TenNganh,
        //                                   thoiHan = bc.ThoiHan

        //                               };



        //    var dataJson = Json(new { success = true, data = chiTietBangCapByMaNV });

        //    string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

        //    return dataJson;

        //}
        [Auther(RightID = "130")]
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/quan-he-gia-dinh")]
        [HttpPost]
        public ActionResult quanHeGiadinh()
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();


            var quanHeGiaDinhByMaNV = from qhgd in db.Families
                                      join nv in db.Employees on qhgd.employee_id equals nv.employee_id

                                      where qhgd.employee_id == id_
                                      select new
                                      {
                                          maNV = nv.employee_id,
                                          ten = nv.BASIC_INFO_full_name,
                                          moiQuanhe = qhgd.family_relationship_id,
                                          ngaySinh = qhgd.date_of_birth,
                                          lyLich = qhgd.background,
                                          loaiGiaDinh = qhgd.family_type_id,
                                          tenQH = qhgd.full_name


                                      };
            var dataJson = Json(new { success = true, data = quanHeGiaDinhByMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;

        }



        //editByThuong
        [Auther(RightID = "131")]
        [HttpGet]
        public ActionResult EditHoSo()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                Dictionary<int, string> listTypesBrief = new Dictionary<int, string>();
                listTypesBrief.Add(1, "Photo");
                listTypesBrief.Add(2, "Sao, Công chứng");
                listTypesBrief.Add(3, "Bản gốc");
                listTypesBrief.Add(4, "Dấu đỏ");

                Dictionary<int, string> listDepartmet = new Dictionary<int, string>();
                List<Department> department = db.Departments.ToList();
                int i = 1;
                foreach (var d in department)
                {
                    listDepartmet.Add(i, d.department_name);
                    i++;
                }
                SelectList listD = new SelectList(listDepartmet, "Value", "Value");
                SelectList listOptionBrief = new SelectList(listTypesBrief, "Value", "Value");
                ViewBag.listOptionBrief = listOptionBrief;
                ViewBag.listDepartmet = listD;
                Record hoSo = db.Records.Where(x => x.employee_id == id_).FirstOrDefault<Record>();
                return View(hoSo);
            }
        }
        [Auther(RightID = "131")]
        [HttpPost]
        public ActionResult EditHoSo(Record hoSo)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (hoSo != null)
                {
                    db.Entry(hoSo).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("listAllHoSo");
            }
        }

        //[HttpGet]
        //public ActionResult EditChiTietbangCap(string id)
        //{
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {

        //        RecordsPaper chiTiet = db.RecordsPapers.Where(x => x. == id).FirstOrDefault<ChiTiet_BangCap_GiayChungNhan>();
        //        return View(chiTiet);
        //    }
        //}

        [HttpPost]
        public ActionResult EditChiTietbangCap(RecordsPaper chiTiet_BangCap)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chiTiet_BangCap != null)
                {
                    db.Entry(chiTiet_BangCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("listAllHoSo");
            }
        }
        [HttpGet]
        public ActionResult EditQuanHeGiaDinh()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {

                Family qh = db.Families.Where(x => x.employee_id == id_).FirstOrDefault<Family>();
                return View(qh);
            }
        }
        [HttpPost]
        public ActionResult EditQuanHeGiaDinh(Family quanHeGiaDinh)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (quanHeGiaDinh != null)
                {
                    db.Entry(quanHeGiaDinh).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("listAllHoSo");
            }
        }

        //[Auther(RightID = "169")]
        //[HttpGet]
        //public ActionResult EditLichSuBoSung()
        //{
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {

        //        AdditionalHistoryResume qh = db.AdditionalHistoryResumes.Where(x => x.MaNV == id_).FirstOrDefault<AdditionalHistoryResume>();
        //        return View(qh);
        //    }
        //}

        //[Auther(RightID = "169")]
        //[HttpPost]
        //public ActionResult EditLichSuBoSung(AdditionalHistoryResume lichSuBoSungSYLL)
        //{
        //    lichSuBoSungSYLL.Ma = id_;

        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {

        //        List<LichSuBoSungSYLL> list = new List<LichSuBoSungSYLL>();

        //        list = (from lsbs in db.LichSuBoSungSYLLs
        //                where lsbs.MaNV == id_
        //                select new
        //                {
        //                    id = lsbs.ID,
        //                    maNV = lsbs.MaNV,
        //                    namBoSung = lsbs.NamBoSung

        //                }).ToList().Select(p => new LichSuBoSungSYLL
        //                {
        //                    ID = p.id,
        //                    MaNV = p.maNV,
        //                    NamBoSung = p.namBoSung
        //                }).ToList();
        //        bool check = false;
        //        foreach (var i in list)
        //        {
        //            if (i.NamBoSung.Equals(lichSuBoSungSYLL.NamBoSung))
        //            {
        //                check = true;
        //            }
        //        }
        //        if (lichSuBoSungSYLL != null && check == false)
        //        {
        //            db.Entry(lichSuBoSungSYLL).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("listAllHoSo");
        //    }
        //}

        [Auther(RightID = "168")]
        [HttpGet]
        public ActionResult AddLichSuBoSung()
        {
            Dictionary<int, string> listYear = new Dictionary<int, string>();
            for (int i = 1990; i < 2100; i++)
            {
                listYear.Add(i, i + "");
            }
            SelectList listOptionYear = new SelectList(listYear, "Value", "Value");
            ViewBag.listOptionYear = listOptionYear;
            return View();
        }

        //[Auther(RightID = "168")]
        //[HttpPost]
        //public ActionResult AddLichSuBoSung(LichSuBoSungSYLL lichSuBoSungSYLL)
        //{

        //    lichSuBoSungSYLL.MaNV = id_;

        //    List<LichSuBoSungSYLL> lsbs = new List<LichSuBoSungSYLL>();


        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        List<LichSuBoSungSYLL> list = new List<LichSuBoSungSYLL>();

        //        list = (from lsbs1 in db.LichSuBoSungSYLLs
        //                where lsbs1.MaNV == id_
        //                select new
        //                {
        //                    id = lsbs1.ID,
        //                    maNV = lsbs1.MaNV,
        //                    namBoSung = lsbs1.NamBoSung

        //                }).ToList().Select(p => new LichSuBoSungSYLL
        //                {
        //                    ID = p.id,
        //                    MaNV = p.maNV,
        //                    NamBoSung = p.namBoSung
        //                }).ToList();
        //        bool check = false;
        //        foreach (var i in list)
        //        {
        //            if (i.NamBoSung.Equals(lichSuBoSungSYLL.NamBoSung))
        //            {
        //                check = true;
        //            }
        //        }


        //        if (lichSuBoSungSYLL != null && check == false)
        //        {
        //            //db.Entry(lichSuBoSungSYLL).State = EntityState.Modified;
        //            db.LichSuBoSungSYLLs.Add(lichSuBoSungSYLL);
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("listAllHoSo");
        //    }
        //}

        [Auther(RightID = "129")]
        [HttpPost]
        public ActionResult searchlistAllBrief(string searchList)
        {


            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                List<HoSoNhanVien> hs_nv = new List<HoSoNhanVien>();
                string[] idsArray = searchList.Split(',').ToArray();
                var manv = idsArray[0];
                var tennv = idsArray[1];
                var nguoigiaohoso = idsArray[2];
                var nguoigiuhoso = idsArray[3];
                if (manv != null || tennv != null && nguoigiaohoso != null && nguoigiuhoso != null)
                {
                    //hs_nv = (from nv in db.Employees
                    //         join hs in db.Records
                    //         on nv.employee_id equals hs.employee_id
                    //         where (nv.current_status_id != 2)
                    //         && ((nv.employee_id + " ").Contains(manv))
                    //         && ((nv.BASIC_INFO_full_name + " ").Contains(tennv))
                    //         && ((hs.delivery_employee_id + " ").Contains(nguoigiaohoso))
                    //         && ((hs.management_employee_id + " ").Contains(nguoigiuhoso))
                    //         select new
                    //         {
                    //             maNV = hs.employee_id,
                    //             ten = nv.BASIC_INFO_full_name,
                    //             ngaysinh = nv.BASIC_INFO_date_of_birth,
                    //             nguoiGiaoHoSo = hs.delivery_employee_id,
                    //             ngayNhanHoSo = hs.received_date,
                    //             nguoiGiuHoSo = hs.management_employee_id
                    //             //camKetTuyenDung = hs.CamKetTuyenDung,

                    //             //quyetDinhTiepNhanDVC = hs.QuyetDinhTiepNhanDVC,
                    //             //ngayQDTiepNhan = hs.NgayQuyetDinhTuyenDung,
                    //             //ngayDiLam = nv.NgayDiLam,
                    //             //donViKyQuyetDinhTiepNhan = hs.DonViKyQuyetDinhTiepNhan,

                    //             //quyetDinhChamDut = hs.QDChamDutHopDongDVC,
                    //             //ngayQDChamDut = hs.NgayQuyetDinhChamDut,
                    //             //ngayChamDut = hs.NgayChamDut,
                    //             //donViKyChamDut = hs.DonViKyQuyetDinhChamDut
                    //         }).ToList().Select(p => new HoSoNhanVien
                    //         {
                    //             MaNV = p.maNV,
                    //             Ten = p.ten,
                    //             NgaySinh = p.ngaysinh,
                    //             NguoiGiaoHoSo = p.nguoiGiaoHoSo,
                    //             NgayNhanHoSo = p.ngayNhanHoSo,
                    //             NguoiGiuHoSo = p.nguoiGiuHoSo

                    //             //CamKetTuyenDung = p.camKetTuyenDung,
                    //             //QuyetDinhTiepNhanDVC = p.quyetDinhTiepNhanDVC,
                    //             //NgayQDTiepNhan = p.ngayQDTiepNhan,
                    //             //NgayDiLam = p.ngayDiLam,
                    //             //DonViKyQuyetDinhTiepNhan = p.donViKyQuyetDinhTiepNhan,
                    //             //QuyetDinhChamDut = p.quyetDinhChamDut,
                    //             //NgayQDChamDut = p.ngayQDChamDut,
                    //             //NgayChamDut = p.ngayChamDut,
                    //             //DonViKyChamDut = p.donViKyChamDut


                    //         }).ToList();


                    int totalrows = hs_nv.Count;
                    int totalrowsafterfiltering = hs_nv.Count;
                    hs_nv = hs_nv.OrderBy(sortColumnName + " " + sortDirection).ToList<HoSoNhanVien>();
                    //paging
                    hs_nv = hs_nv.Skip(start).Take(length).ToList<HoSoNhanVien>();
                    var dataJson = Json(new { success = true, data = hs_nv, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                    string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                    return dataJson;
                }
            }
            return RedirectToAction("listAllHoSo");
        }
        //***start hoang


        [Auther(RightID = "132")]
        [Route("phong-tcld/quan-ly-ho-so/ho-so-ngoai-cong-ty")]
        public ActionResult Outside()
        {

            return View("/Views/TCLD/Brief/ManageBrief/Outside.cshtml");

        }

        //[HttpPost]
        //public ActionResult Outside(String mnv)
        //{
        //    int start = Convert.ToInt32(Request["start"]);
        //    int length = Convert.ToInt32(Request["length"]);
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        var mydata = (from p   in db.Employees
        //                      join p1 in db.Records on p.employee_id equals p1.employee_id
        //                      join p2 in db.ChamDut_NhanVien on p.MaNV equals p2.MaNV into cd_nv
        //                      join p3 in db.Departments on p.MaPhongBan equals p3.department_id into pb
        //                      where p.MaTrangThai == 2
        //                      from p2 in cd_nv.DefaultIfEmpty()
        //                      from p3 in pb.DefaultIfEmpty()
        //                      select new
        //                      {
        //                          stt = "1",
        //                          manv = p.MaNV,
        //                          ten = p.Ten,
        //                          dvcdhd = p3.department_name,
        //                          sobhxh = p.SoBHXH,
        //                          sdt = p.SoDienThoai,
        //                          diachi = p.NoiOHienTai,
        //                          loaichamdut = p2.LoaiChamDut,
        //                          edit = true
        //                      }).ToList();
        //        int totalrows = mydata.Count;
        //        int totalrowsafterfiltering = mydata.Count;
        //        mydata = mydata.Skip(start).Take(length).ToList();
        //        return Json(new { success = true, data = mydata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[Auther(RightID = "133")]
        //[HttpGet]
        //[Route("phong-tcld/quan-ly-ho-so/ho-so-ngoai-cong-ty/chi-tiet-ho-so")]
        //public ActionResult OutSideDetail()
        //{
        //    String mnv = Request.QueryString["manv"];
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {

        //        var count = (from p in db.Employees
        //                     join p1 in db.Records on p.employee_id equals p1.employee_id
        //                     join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV into cd_nv
        //                     where p.MaTrangThai == 2 & p.MaNV == mnv
        //                     from p2 in cd_nv.DefaultIfEmpty()
        //                     select p).Count();
        //        if (count != 1)
        //        {
        //            return RedirectToAction("OutSide", "Brief");
        //        }
        //        ViewBag.nameDepartment = "quanlyhoso";

        //    }
        //    ViewBag.manv = mnv;
        //    return View("/Views/TCLD/Brief/ManageBrief/OutSideDetail.cshtml");
        //}

        //public ActionResult thongTinUyQuyen()
        //{
        //    String mnv = Request.QueryString["manv"];

        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        var mydata = (from p in db.Employees
        //                      join p1 in db.RecordsGettingAuthorizes on p. equals p1.MaUyQuyen
        //                      where p.MaNV == mnv
        //                      select new
        //                      {
        //                          hoTenNguoiUyQuyen = p1.HoTen,
        //                          quanHeNguoiUyQuyen = p1.QuanHe,
        //                          soCMT = p1.SoCMND,
        //                          soDT = p1.SoDienThoai
        //                      }).ToList();
        //        Debug.WriteLine(mydata.Count(), "TAG");
        //        return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public ActionResult taiThongTinCoBanHSNgoai()
        //{
        //    String mnv = Request.QueryString["manv"];

        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        var mydata = (from p in db.Employees
        //                      join p1 in db.Records on p.employee_id equals p1.employee_id
        //                      join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV into cd_nv
        //                      join p3 in db.Departments on p.MaPhongBan equals p3.department_id into pb
        //                      where p.MaNV == mnv
        //                      from p2 in cd_nv.DefaultIfEmpty()
        //                      from p3 in pb.DefaultIfEmpty()
        //                      select new
        //                      {
        //                          stt = "",
        //                          sothe = p.MaNV,
        //                          hoVaTen = p.Ten,
        //                          ngaythangnamsinh = p.NgaySinh,
        //                          donvicd = p3.department_name,
        //                          soBH = p.SoBHXH,
        //                          sodt = p.SoDienThoai,
        //                          diachithuongtru = p.NoiOHienTai,
        //                          edit = true
        //                      }).ToList();

        //        return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
        //    }
        //}


        //public ActionResult thongtinLoaiChamdut()
        //{
        //    String mnv = Request.QueryString["manv"];

        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {

        //        var listTenChamdut = (from p in db.ChamDut_NhanVien
        //                              select p.LoaiChamDut).Distinct().ToList();
        //        var mydata = (from p in db.ChamDut_NhanVien
        //                      join p1 in db.QuyetDinhs on p.MaQuyetDinh equals p1.MaQuyetDinh
        //                      where p.MaNV == mnv
        //                      select new
        //                      {
        //                          tenLoaiChamDut = p.LoaiChamDut,
        //                          soQD = p.MaQuyetDinh,
        //                          ngayQD = p1.NgayQuyetDinh,
        //                          ngayCD = p.NgayChamDut,
        //                          listChamDut = listTenChamdut
        //                      }).ToList();
        //        Debug.WriteLine(mydata.Count(), "TAG");
        //        return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public ActionResult updateThongTinCoBan(String json)
        //{

        //    dynamic js = JObject.Parse(json);
        //    String hoVaTen = js.hoVaTen;
        //    String sothe = js.sothe;
        //    String ngaythangnamsinh = js.ngaythangnamsinh;
        //    String donvicd = js.donvicd;
        //    String soBH = js.soBH;
        //    String sodt = js.sodt;
        //    String diachithuongtru = js.diachithuongtru;
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        Employee nv = (from p in db.Employees where p.employee_id == sothe select p).SingleOrDefault();
        //        nv.BASIC_INFO_full_name = hoVaTen;
        //        nv.BASIC_INFO_social_insurance_number = soBH;
        //        nv.BASIC_INFO_phone_number = sodt;
        //        nv.BASIC_INFO_current_residence = diachithuongtru;
        //        if (isValidateDateTime(ngaythangnamsinh))
        //        {
        //            nv.BASIC_INFO_date_of_birth = Convert.ToDateTime(ngaythangnamsinh);
        //        }

        //        ChamDut_NhanVien cd = (from p in db.ChamDut_NhanVien where p.MaNV == sothe select p).SingleOrDefault();
        //        //     cd.DonViKhiChamDut = donvicd;

        //        db.SaveChanges();

        //        ViewBag.nameDepartment = "quanlyhoso";
        //        return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

        //    }


        //}



        //[HttpPost]
        //public ActionResult updateLoaiChamDut(String json)
        //{

        //    dynamic js = JObject.Parse(json);
        //    String tenLoaiChamDut = js.tenLoaiChamDut;
        //    String soQD = js.soQD;
        //    String ngayQD = js.ngayQD;
        //    String ngayCD = js.ngayCD;
        //    int soQD1 = Int32.Parse(soQD.Trim());
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        ChamDut_NhanVien nv = (from p in db.ChamDut_NhanVien where p.MaQuyetDinh == soQD1 select p).SingleOrDefault();
        //        nv.LoaiChamDut = tenLoaiChamDut;
        //        if (isValidateDateTime(ngayCD))
        //        {
        //            nv.NgayChamDut = Convert.ToDateTime(ngayCD);
        //        }

        //        QuyetDinh cd = (from p in db.QuyetDinhs where p.MaQuyetDinh == soQD1 select p).SingleOrDefault();
        //        if (isValidateDateTime(ngayQD))
        //        {
        //            cd.NgayQuyetDinh = Convert.ToDateTime(ngayQD);
        //        }


        //        db.SaveChanges();

        //        ViewBag.nameDepartment = "quanlyhoso";
        //        return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

        //    }


        //}
        //public Boolean isValidateDateTime(String dateTime)
        //{
        //    try
        //    {
        //        DateTime dt = Convert.ToDateTime(dateTime);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}



        //public ActionResult updateUyQuyen(String json)
        //{
        //    dynamic js = JObject.Parse(json);
        //    String hoTenNguoiUyQuyen = js.hoTenNguoiUyQuyen;
        //    String quanHeNguoiUyQuyen = js.quanHeNguoiUyQuyen;
        //    String soCMT = js.soCMT;
        //    String soDT = js.soDT;
        //    String mnv = js.manv;
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {

        //        var count = (from p in db.NhanViens
        //                     join p1 in db.NguoiUyQuyenLayHoSo_BaoHiem on p.MaUyQuyen equals p1.MaUyQuyen
        //                     where p.MaNV == mnv
        //                     select p1).Count();

        //        NguoiUyQuyenLayHoSo_BaoHiem n = (from p in db.NguoiUyQuyenLayHoSo_BaoHiem
        //                                         join p1 in db.NhanViens on p.MaUyQuyen equals p1.MaUyQuyen
        //                                         where p1.MaNV == mnv
        //                                         select p

        //                                        ).SingleOrDefault();
        //        if (count == 1)
        //        {
        //            n.HoTen = hoTenNguoiUyQuyen;
        //            n.QuanHe = quanHeNguoiUyQuyen;
        //            n.SoCMND = soCMT;
        //            n.SoDienThoai = soDT;
        //        }
        //        else
        //        {
        //            int id = (from p in db.NguoiUyQuyenLayHoSo_BaoHiem select p).Count() + 1;
        //            NhanVien nv = (from p in db.NhanViens where p.MaNV == mnv select p).SingleOrDefault();
        //            n = new NguoiUyQuyenLayHoSo_BaoHiem();
        //            nv.MaUyQuyen = id;
        //            n.MaUyQuyen = id;
        //            n.HoTen = hoTenNguoiUyQuyen;
        //            n.QuanHe = quanHeNguoiUyQuyen;
        //            n.SoCMND = soCMT;
        //            n.SoDienThoai = soDT;
        //            db.NguoiUyQuyenLayHoSo_BaoHiem.Add(n);
        //        }




        //        db.SaveChanges();


        //        return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

        //    }


        //}

        //public ActionResult thongTinGiayTo()
        //{
        //    int start = Convert.ToInt32(Request["start"]);
        //    int length = Convert.ToInt32(Request["length"]);
        //    String mnv = Request.QueryString["manv"];
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        var x = (from a in db.GiayToes

        //                 where a.MaNV == mnv
        //                 select
        //        new
        //        {
        //            ma = a.MaGiayTo,
        //            kieu = a.KieuGiayTo,
        //            ngaytra = a.NgayTra,
        //            sohieu = "",
        //            ngaycap = (DateTime?)null,
        //            ten = a.TenGiayTo,
        //            manv = a.MaNV

        //        }).ToList();
        //        var y = (from a in db.ChungChi_NhanVien
        //                 join b in db.ChungChis on a.MaChungChi equals b.MaChungChi
        //                 where a.MaNV == mnv
        //                 select
        //                 new
        //                 {
        //                     ma = a.MaChungChi,
        //                     kieu = b.KieuChungChi,
        //                     ngaytra = a.NgayTra,
        //                     sohieu = a.SoHieu,
        //                     ngaycap = a.NgayCap,
        //                     ten = b.TenChungChi,
        //                     manv = a.MaNV
        //                 }
        //                ).ToList();
        //        var z = (from a in db.ChiTiet_BangCap_GiayChungNhan
        //                 join b in db.BangCap_GiayChungNhan on a.MaBangCap_GiayChungNhan equals b.MaBangCap_GiayChungNhan
        //                 where a.MaNV == mnv
        //                 select
        //                 new
        //                 {
        //                     ma = a.MaBangCap_GiayChungNhan,
        //                     kieu = b.KieuBangCap,
        //                     ngaytra = a.NgayTra,
        //                     sohieu = a.SoHieu,
        //                     ngaycap = a.NgayCap,
        //                     ten = b.TenBangCap,
        //                     manv = a.MaNV
        //                 }
        //                ).ToList();
        //        var m = y.Union(z.Union(x)).ToList();
        //        int totalrows = m.Count;
        //        int totalrowsafterfiltering = m.Count;
        //        m = m.Skip(start).Take(length).ToList();
        //        return Json(new { success = true, data = m, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        //    }


        //}

        //public ActionResult updateGiayTo(String json)
        //{
        //    dynamic js = JObject.Parse(json);
        //    String manv = js.manv;
        //    int ma = js.ma;
        //    String sohieu = js.sohieu;
        //    String kieu = js.kieu;
        //    String ngaytra = js.ngaytra;
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        //  GiayChungNhan_NhanVien x = (from a in db.GiayChungNhan_NhanVien where a.MaNV == manv & a.SoHieu==sohieu  select a).SingleOrDefault() ;
        //        ChungChi_NhanVien x = (from a in db.ChungChi_NhanVien where a.MaNV == manv & a.SoHieu == sohieu & a.MaChungChi == ma select a).SingleOrDefault();
        //        ChiTiet_BangCap_GiayChungNhan y = (from a in db.ChiTiet_BangCap_GiayChungNhan where a.MaNV == manv & a.SoHieu == sohieu & a.MaBangCap_GiayChungNhan == ma select a).SingleOrDefault();
        //        GiayTo z = (from a in db.GiayToes where a.MaNV == manv & a.MaGiayTo == ma select a).SingleOrDefault();
        //        if (x != null)
        //        {
        //            if (isValidateDateTime(ngaytra))
        //                x.NgayTra = Convert.ToDateTime(ngaytra);
        //        }
        //        if (y != null)
        //        {
        //            if (isValidateDateTime(ngaytra))
        //                y.NgayTra = Convert.ToDateTime(ngaytra);

        //        }
        //        if (z != null & sohieu.Equals(""))
        //        {
        //            if (isValidateDateTime(ngaytra))
        //                z.NgayTra = Convert.ToDateTime(ngaytra);

        //        }
        //        //if (z != null)
        //        //{
        //        //    if (isValidateDateTime(ngaytra))
        //        //        z.NgayTra = Convert.ToDateTime(ngaytra);

        //        //}
        //        db.SaveChanges();
        //        return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet); ;
        //    }

        //}


        //public ActionResult insertGiayTo(String json)
        //{
        //    dynamic js = JObject.Parse(json);
        //    String manv = js.manv;

        //    String kieu = js.kieu;
        //    String ten = js.ten;
        //    if (kieu.Equals("") & ten.Equals(""))
        //        return Json(new { success = false, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {
        //        GiayTo giayTo;

        //        giayTo = new GiayTo();
        //        giayTo.TenGiayTo = ten;
        //        giayTo.MaNV = manv;
        //        giayTo.KieuGiayTo = kieu;
        //        giayTo.NgayTra = null;
        //        db.GiayToes.Add(giayTo);
        //        db.SaveChanges();
        //        return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);




        //    }

        //}

        //public ActionResult searchOutSide(String data)
        //{
        //    dynamic js = JObject.Parse(data);
        //    String manv = js.manv;
        //    String ten = js.ten;
        //    String loaichamdut = js.loaichamdut;
        //    int start = Convert.ToInt32(Request["start"]);
        //    int length = Convert.ToInt32(Request["length"]);

        //    // String 
        //    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //    {

        //        // search ma nhan vien

        //        var mydata = (from p in db.NhanViens
        //                      join p1 in db.HoSoes on p.MaNV equals p1.MaNV
        //                      join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
        //                      join p3 in db.Departments on p.MaPhongBan equals p3.department_id
        //                      where p.MaTrangThai == 2 &
        //                      p.MaNV.Contains(manv)
        //                      & (p.Ten.Contains(ten) | p.Ten == null)
        //                      & (p2.LoaiChamDut.Contains(loaichamdut) | loaichamdut == "")
        //                      select new
        //                      {
        //                          stt = "1",
        //                          manv = p.MaNV,
        //                          ten = p.Ten,
        //                          dvcdhd = p3.department_name,
        //                          sobhxh = p.SoBHXH,
        //                          sdt = p.SoDienThoai,
        //                          diachi = p.NoiOHienTai,
        //                          loaichamdut = p2.LoaiChamDut,
        //                          edit = true
        //                      }).ToList();
        //        int totalrows = mydata.Count;
        //        int totalrowsafterfiltering = mydata.Count;
        //        mydata = mydata.Skip(start).Take(length).ToList();
        //        return Json(new { success = true, data = mydata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);


        //    }


        //}

        //[HttpPost]
        //public ActionResult ExportExcel()
        //{


        //    string path = HostingEnvironment.MapPath("/excel/TCLD/Hoso/ho-so-ngoai.xlsx");

        //    string saveAsPath = ("/excel/TCLD/download/ho-so-ngoai.xlsx");
        //    FileInfo file = new FileInfo(path);
        //    using (ExcelPackage excelPackage = new ExcelPackage(file))
        //    {
        //        ExcelWorkbook excelWorkbook = excelPackage.Workbook;
        //        ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
        //        using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //        {


        //            var mydata = (from p in db.NhanViens
        //                          join p1 in db.HoSoes on p.MaNV equals p1.MaNV
        //                          join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV into cd_nv
        //                          join p3 in db.Departments on p.MaPhongBan equals p3.department_id into pb
        //                          join p4 in db.NguoiUyQuyenLayHoSo_BaoHiem on p.MaUyQuyen equals p4.MaUyQuyen into pp
        //                          where p.MaTrangThai == 2
        //                          from p2 in cd_nv.DefaultIfEmpty()
        //                          from p3 in pb.DefaultIfEmpty()
        //                          from p4 in pp.DefaultIfEmpty()
        //                          select new
        //                          {
        //                              stt = "1",
        //                              manv = p.MaNV,
        //                              ten = p.Ten,
        //                              dvcdhd = p3.department_name,
        //                              sobhxh = p.SoBHXH,
        //                              sdt = p.SoDienThoai,
        //                              diachi = p.NoiOHienTai,
        //                              loaichamdut = p2.LoaiChamDut,
        //                              edit = true,
        //                              tenUQ = p4.HoTen,
        //                              quanheUQ = p4.QuanHe,
        //                              sdtUQ = p4.SoDienThoai,
        //                              socmtUQ = p4.SoCMND
        //                          }).ToList();

        //            var giaytoList = (from p in db.GiayToes
        //                              select
        //                              new
        //                              {
        //                                  manv = p.MaNV,
        //                                  ten = p.TenGiayTo,
        //                                  kieu = p.KieuGiayTo,
        //                                  ngaycap = "",
        //                                  ngaytra = p.NgayTra

        //                              }).ToList();

        //            var chungchiList = (from p in db.ChungChis
        //                                join p1 in db.ChungChi_NhanVien on p.MaChungChi equals p1.MaChungChi

        //                                select new
        //                                {
        //                                    manv = p1.MaNV,
        //                                    ten = p.TenChungChi,
        //                                    kieu = p.KieuChungChi,
        //                                    ngaycap = p1.NgayCap,
        //                                    ngaytra = p1.NgayTra
        //                                }
        //                               ).ToList();

        //            var bangcapList = (from p in db.BangCap_GiayChungNhan
        //                               join p1 in db.ChiTiet_BangCap_GiayChungNhan on p.MaBangCap_GiayChungNhan equals p1.MaBangCap_GiayChungNhan

        //                               select new
        //                               {
        //                                   manv = p1.MaNV,
        //                                   ten = p.TenBangCap,
        //                                   kieu = p.KieuBangCap,
        //                                   ngaycap = p1.NgayCap,
        //                                   ngaytra = p1.NgayTra
        //                               }).ToList();



        //            int index = 4;
        //            int tempIndex;
        //            int stt = 1;
        //            foreach (var item in mydata)
        //            {
        //                tempIndex = index;
        //                excelWorksheet.Cells[index, 1].Value = stt;
        //                excelWorksheet.Cells[index, 2].Value = item.manv;
        //                excelWorksheet.Cells[index, 3].Value = item.ten;
        //                excelWorksheet.Cells[index, 4].Value = item.dvcdhd;
        //                excelWorksheet.Cells[index, 5].Value = item.sobhxh;
        //                excelWorksheet.Cells[index, 6].Value = item.sdt;
        //                excelWorksheet.Cells[index, 7].Value = item.diachi;
        //                excelWorksheet.Cells[index, 8].Value = item.loaichamdut;
        //                var giayto = giaytoList.Where(p => p.manv == item.manv).ToList();


        //                // not empty
        //                if (giayto.Count != 0)
        //                {
        //                    int indexGiayTo = index;
        //                    foreach (var i in giayto)
        //                    {
        //                        excelWorksheet.Cells[indexGiayTo, 9].Value = i.ten;
        //                        excelWorksheet.Cells[indexGiayTo, 10].Value = i.kieu;

        //                        excelWorksheet.Cells[indexGiayTo, 11].Value = i.ngaycap;
        //                        excelWorksheet.Cells[indexGiayTo, 12].Value = i.ngaytra.HasValue ? i.ngaytra.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                        indexGiayTo++;
        //                    }
        //                    if (indexGiayTo >= tempIndex) tempIndex = indexGiayTo;
        //                }
        //                var chungchi = chungchiList.Where(p => p.manv == item.manv).ToList();
        //                if (chungchi.Count != 0)
        //                {
        //                    int indexChungChi = index;
        //                    foreach (var i in chungchi)
        //                    {
        //                        excelWorksheet.Cells[indexChungChi, 13].Value = i.ten;
        //                        excelWorksheet.Cells[indexChungChi, 14].Value = i.kieu;
        //                        excelWorksheet.Cells[indexChungChi, 15].Value = i.ngaycap.HasValue ? i.ngaycap.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                        excelWorksheet.Cells[indexChungChi, 16].Value = i.ngaytra.HasValue ? i.ngaytra.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                        indexChungChi++;
        //                    }
        //                    if (indexChungChi >= tempIndex)
        //                    {
        //                        tempIndex = indexChungChi;
        //                    }
        //                }
        //                var bangcap = bangcapList.Where(p => p.manv == item.manv).ToList();
        //                if (bangcap.Count != 0)
        //                {
        //                    int indexBangCap = index;
        //                    foreach (var i in bangcap)
        //                    {
        //                        excelWorksheet.Cells[indexBangCap, 17].Value = i.ten;
        //                        excelWorksheet.Cells[indexBangCap, 18].Value = i.kieu;
        //                        excelWorksheet.Cells[indexBangCap, 19].Value = i.ngaycap.HasValue ? i.ngaycap.Value.ToString("dd/MM/yyyy") : string.Empty; ;
        //                        excelWorksheet.Cells[indexBangCap, 20].Value = i.ngaytra.HasValue ? i.ngaytra.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                        indexBangCap++;
        //                    }
        //                    if (indexBangCap >= tempIndex)
        //                    {
        //                        tempIndex = indexBangCap;
        //                    }
        //                }

        //                var thongtinUyQuyen = mydata.Where(p => p.manv == item.manv).ToList();
        //                if (thongtinUyQuyen.Count != 0)
        //                {
        //                    foreach (var i in thongtinUyQuyen)
        //                    {
        //                        excelWorksheet.Cells[index, 21].Value = i.tenUQ;
        //                        excelWorksheet.Cells[index, 22].Value = i.quanheUQ;
        //                        excelWorksheet.Cells[index, 23].Value = i.sdtUQ;
        //                        excelWorksheet.Cells[index, 24].Value = i.socmtUQ;
        //                    }
        //                }

        //                //if (item.listgiayto !=null)
        //                //{
        //                //    foreach(var i in item.listgiayto)
        //                //    {
        //                //        excelWorksheet.Cells[1, indexGiayTo, indexGiayTo+3, index].Merge = true;
        //                //        excelWorksheet.Cells[1, indexGiayTo].Value = "Ten giay to";
        //                //        excelWorksheet.Cells[2, indexGiayTo].Value = "Kieu giay to";
        //                //        excelWorksheet.Cells[2, indexGiayTo + 1].Value = "Kieu giay to";
        //                //        excelWorksheet.Cells[2, indexGiayTo + 2].Value = "Kieu giay to";
        //                //        excelWorksheet.Cells[2, indexGiayTo + 3].Value = "Kieu giay to";
        //                //        indexGiayTo += 5;
        //                //    }
        //                //}
        //                //excelWorksheet.Cells[5, 1, 5, 2].Merge = true;
        //                //excelWorksheet.Cells[5, 1].Value = "Value";
        //                if (tempIndex > index) index = tempIndex;
        //                else
        //                {
        //                    index++;
        //                }
        //                //   index++;
        //                stt++;

        //            }

        //            excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
        //            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        //        }
        //    }



        //}



        ////***end hoang
        //[Auther(RightID = "130")]
        //[Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-chung-chi")]
        //[HttpPost]
        //public ActionResult listChungChi()
        //{
        //    QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();


        //    var chungchi = from cc_nv in db.ChungChi_NhanVien
        //                   join nv in db.NhanViens on cc_nv.MaNV equals nv.MaNV
        //                   join cc in db.ChungChis on cc_nv.MaChungChi equals cc.MaChungChi
        //                   where cc_nv.MaNV == id_
        //                   select new
        //                   {
        //                       maNV = nv.MaNV,
        //                       ten = nv.Ten,
        //                       soHieu = cc_nv.SoHieu,
        //                       ngayCap = cc_nv.NgayCap,
        //                       maChungChi = cc_nv.MaChungChi,
        //                       ngayTra = cc_nv.NgayTra,
        //                       tenChungChi = cc.TenChungChi,
        //                       loai = cc.KieuChungChi

        //                   };
        //    var dataJson = Json(new { success = true, data = chungchi }, JsonRequestBehavior.AllowGet);

        //    string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

        //    return dataJson;

        //}
        //[Auther(RightID = "130")]
        //[Route("phong-tcld/chung-chi/danh-sach-ho-so-trong/xuat-file-excel")]
        //[HttpPost]
        //public ActionResult ExportToExcel()
        //{
        //    try
        //    {

        //        string path = HostingEnvironment.MapPath("/excel/TCLD/Brief/Inside.xlsx");
        //        string saveAsPath = ("/excel/TCLD/Certificate/List/download/Hồ sơ trong.xlsx");
        //        FileInfo file = new FileInfo(path);
        //        using (ExcelPackage excelPackage = new ExcelPackage(file))
        //        {
        //            ExcelWorkbook excelWorkbook = excelPackage.Workbook;
        //            ExcelWorksheet ws = excelWorkbook.Worksheets.First();
        //            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //            {
        //                string query = @"select 
        //                    a.MaNV, a.Ten, a.NgaySinh, a.SoBHXH, a.SoDienThoai, a.QueQuan, a.NoiOHienTai, a.SoCMND, a.NgayDiLam,
        //                    b.TenTrinhDo,
        //                    c.NguoiGiaoHoSo, c.NguoiGiuHoSo, c.CamKetTuyenDung, c.NguoiBanGiaoBangNhapKho,
        //                    c.NgayQuyetDinhTuyenDung, c.DonViKyQuyetDinhTiepNhan, c.NgayQuyetDinhChamDut, 
        //                    c.NgayChamDut, c.DonViKyQuyetDinhChamDut,
        //                    d.TenGiayTo, d.KieuGiayTo,
        //                    j.SoHieu as 'SoHieuBangCap', e.Loai as 'LoaiBangCap', e.TenBangCap, e.KieuBangCap, h.TenTruong, f.TenChuyenNganh, g.TenNganh, j.NgayCap as 'NgayCapBang', e.ThoiHan as 'ThoiHanBang',
        //                    k.SoHieu as 'SoHieuChungChi', l.TenChungChi, l.KieuChungChi, k.NgayCap as 'NgayCapChungChi',
        //                    m.LoaiGiaDinh, m.MoiQuanHe, m.HoTen as 'TenNguoiQH', m.NgaySinh as 'NgaySinhQH', m.LyLich,
        //                    n.NamBoSung
        //                    from NhanVien a 
        //                    left join TrinhDo b on a.MaTrinhDo = b.MaTrinhDo
        //                    left join HoSo c on a.MaNV = c.MaNV
        //                    left join GiayTo d on a.MaNV = d.MaNV
        //                    left join BangCap_GiayChungNhan e on a.MaTrinhDo = e.MaTrinhDo
        //                    left join ChuyenNganh f on e.MaChuyenNganh = f.MaChuyenNganh
        //                    left join Nganh g on f.MaNganh = g.MaNganh
        //                    left join Truong h on e.MaTruong = h.MaTruong
        //                    left join ChiTiet_BangCap_GiayChungNhan j on e.MaBangCap_GiayChungNhan = j.MaBangCap_GiayChungNhan
        //                    left join ChungChi_NhanVien k on a.MaNV = k.MaNV
        //                    left join ChungChi l on k.MaChungChi = l.MaChungChi
        //                    left join QuanHeGiaDinh m on a.MaNV = m.MaNV
        //                    left join LichSuBoSungSYLL n on a.MaNV = n.MaNV
        //                    where a.MaTrangThai = 1";


        //                List<InsideExcel> dic = new List<InsideExcel>();

        //                dic = db.Database.SqlQuery<InsideExcel>(query).ToList();



        //                int rowStart = 3;
        //                foreach (var l in dic)
        //                {
        //                    ws.Cells[rowStart, 1].Value = l.MaNV;
        //                    ws.Cells[rowStart, 2].Value = l.Ten;
        //                    ws.Cells[rowStart, 3].Value = l.NgaySinh.HasValue ? l.NgaySinh.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                    ws.Cells[rowStart, 4].Value = l.SoBHXH;
        //                    ws.Cells[rowStart, 5].Value = l.SoDienThoai;
        //                    ws.Cells[rowStart, 6].Value = l.QueQuan;
        //                    ws.Cells[rowStart, 7].Value = l.NoiOHienTai;
        //                    ws.Cells[rowStart, 8].Value = l.SoCMND;
        //                    ws.Cells[rowStart, 9].Value = l.NgayDiLam;
        //                    ws.Cells[rowStart, 10].Value = l.TrinhDoHocVan;
        //                    ws.Cells[rowStart, 11].Value = l.NguoiGiaoHoSo;
        //                    ws.Cells[rowStart, 12].Value = l.NguoiGiuHoSo;
        //                    ws.Cells[rowStart, 13].Value = l.CamKetTuyenDung;
        //                    ws.Cells[rowStart, 14].Value = l.NguoiBanGiaoBangNhapKho;
        //                    ws.Cells[rowStart, 15].Value = l.QuyetDinhTiepNhanDVC;
        //                    ws.Cells[rowStart, 16].Value = l.NgayQuyetDinhTuyenDung.HasValue ? l.NgayQuyetDinhTuyenDung.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                    ws.Cells[rowStart, 17].Value = l.DonViKyQuyetDinhTiepNhan;
        //                    ws.Cells[rowStart, 18].Value = l.NgayQuyetDinhChamDut.HasValue ? l.NgayQuyetDinhChamDut.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                    ws.Cells[rowStart, 19].Value = l.NgayChamDut.HasValue ? l.NgayChamDut.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                    ws.Cells[rowStart, 20].Value = l.DonViKyQuyetDinhChamDut;
        //                    ws.Cells[rowStart, 21].Value = l.TenGiayTo;
        //                    ws.Cells[rowStart, 22].Value = l.KieuGiayTo;
        //                    ws.Cells[rowStart, 23].Value = l.SoHieuBangCap;
        //                    ws.Cells[rowStart, 24].Value = l.LoaiBangCap;
        //                    ws.Cells[rowStart, 25].Value = l.TenBangCap;
        //                    ws.Cells[rowStart, 26].Value = l.KieuBangCap;
        //                    ws.Cells[rowStart, 27].Value = l.TenTruong;
        //                    ws.Cells[rowStart, 28].Value = l.TenChuyenNganh;
        //                    ws.Cells[rowStart, 29].Value = l.TenNganh;
        //                    ws.Cells[rowStart, 30].Value = l.NgayCapBang.HasValue ? l.NgayCapBang.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                    ws.Cells[rowStart, 31].Value = l.ThoiHanBang;
        //                    ws.Cells[rowStart, 32].Value = l.SoHieuChungChi;
        //                    ws.Cells[rowStart, 33].Value = l.TenChungChi;
        //                    ws.Cells[rowStart, 34].Value = l.KieuChungChi;
        //                    ws.Cells[rowStart, 35].Value = l.NgayCapChungChi.HasValue ? l.NgayCapChungChi.Value.ToString("dd/MM/yyyy") : string.Empty;
        //                    ws.Cells[rowStart, 36].Value = l.LoaiGiaDinh;
        //                    ws.Cells[rowStart, 37].Value = l.MoiQuanHe;
        //                    ws.Cells[rowStart, 38].Value = l.TenNguoiQH;
        //                    ws.Cells[rowStart, 39].Value = l.NgaySinhQH;
        //                    ws.Cells[rowStart, 40].Value = l.LyLich;
        //                    ws.Cells[rowStart, 41].Value = l.NamBoSung;
        //                    rowStart++;
        //                }

        //            }
        //            excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
        //        }
        //        return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        //    }

        //    catch (Exception e)
        //    {
        //        return null;
        //    }

        //}

        //public string convertDate(string d)
        //{
        //    try
        //    {
        //        if (d != null)
        //        {
        //            DateTime oDate = DateTime.Parse(d);
        //            //DateTime oDate = DateTime.ParseExact(d, "MM/dd/yyyy HH:mm:ss tt", null);
        //            return oDate.ToString("dd/MM/yyyy");
        //        }
        //        return "";
        //    }
        //    catch (Exception e)
        //    {
        //        return "";
        //    }

        //}

        public class Relevant_Paper
        {
            public string employee_id { get; set; }

            public string employee_name { get; set; }

            public string paper_name { get; set; }
            public string paper_id { get; set; }
            public string type_name { get; set; }
            public string papers_type_id { get; set; }
            public string papers_storage_type_id { get; set; }
        }

        public class Custom_Employee
        {
            public string employee_id { get; set; }

            public string employee_name { get; set; }
        }

    }


}
