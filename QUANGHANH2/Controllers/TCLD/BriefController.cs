
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;
using System.Web.Script.Serialization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class BriefController : Controller
    {
        // GET: /<controller>/

        public static string id_ = "";

        [Route("phong-tcld/quan-ly-ho-so/ho-so-ngoai-cong-ty")]
        public ActionResult Outside()
        {
            ViewBag.nameDepartment = "quanlyhoso";
            return View("/Views/TCLD/Brief/ManageBrief/Outside.cshtml");
        }

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty")]
        [HttpGet]
        public ActionResult Inside()
        {
            ViewBag.nameDepartment = "quanlyhoso";
            return View("/Views/TCLD/Brief/ManageBrief/Inside.cshtml");
        }


        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten")]
        public ActionResult Regulation()
        {
            ViewBag.nameDepartment = "quanlyhoso";
            return View("/Views/TCLD/Brief/ManageBrief/Regulations.cshtml");
        }

        //detailByThuong
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-chi-tiet")]
        [HttpGet]
        public ActionResult InsideDetail(string id = "")
        {
            id_ = id;
            ViewBag.MaNV = id;
            return View("/Views/TCLD/Brief/ManageBrief/InsideDetail.cshtml");
        }
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/giay-to")]
        IEnumerable<NhanVien> getAllNhanVien()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                return db.NhanViens.ToList<NhanVien>();
            }
        }
        //[HttpPost]
        //public ActionResult GetAllDocuments()
        //{
        //    int start = Convert.ToInt32(Request["start"]);
        //    int length = Convert.ToInt32(Request["length"]);
        //    string searchValue = Request["search[value]"];
        //    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
        //    string sortDirection = Request["order[0][dir]"];
        //    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        //    {
        //        db.Configuration.LazyLoadingEnabled = false;
        //        List<TenNV> list = db.Database.SqlQuery<TenNV>("select n.Ten,g.* from GiayTo g, NhanVien n where g.MaNV = n.MaNV").ToList<TenNV>();
        //        ViewBag.giaytolist = list;
        //        int totalrows = list.Count;
        //        int totalrowsafterfiltering = list.Count;
        //        //sorting
        //        list = list.OrderBy(sortColumnName + " " + sortDirection).ToList<TenNV>();
        //        //paging
        //        list = list.Skip(start).Take(length).ToList<TenNV>();
        //        return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public class TenNV : GiayTo
        {
            public string Ten { get; set; }
        }
        //Sửa giấy tờ

        [HttpPost]
        public ActionResult suaGiayTo(GiayTo document)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
        [HttpGet]
        public ActionResult suaGiayTo(string id)
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
                GiayTo doc = new GiayTo();
                var documents = db.GiayToes.ToList<GiayTo>();
                doc = db.GiayToes.Where(x => x.MaGiayTo.ToString() == id).FirstOrDefault<GiayTo>();
                return View(doc);
            }
        }
        //thêm giấy tờ
        [HttpGet]
        public ActionResult themGiayTo()
        {
            List<SelectListItem> listNV = new List<SelectListItem>();

            var a = getAllNhanVien();
            foreach (NhanVien nvs in a)
            {
                listNV.Add(new SelectListItem { Text = nvs.MaNV, Value = nvs.Ten });
            }
            ViewBag.nhanvien = listNV;
            List<SelectListItem> KieuGT = new List<SelectListItem>
            {
                new SelectListItem { Text = "Gốc", Value = "Gốc" },
                new SelectListItem { Text = "Dấu đỏ", Value = "Dấu đỏ" },
                new SelectListItem { Text = "Sao,Công chứng", Value = "Sao,Công chứng" },
                new SelectListItem { Text = "Photo", Value = "Photo" }
            };
            ViewBag.kindODoc = KieuGT;
            return View(new GiayTo());
        }
        [HttpPost]
        public ActionResult themGiayTo(GiayTo g)
        {

            var a = getAllNhanVien();
            ViewBag.nhanvien = a;


            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                try
                {
                   
                    db.GiayToes.Add(g);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    return Json(new { message = "Failed" }, JsonRequestBehavior.AllowGet);
                  
                }
            }

            return RedirectToAction("Inside");

        }
        //check id của nhân viên
        [HttpPost]
        public ActionResult validateID(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                NhanVien nv = db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>();
                if (nv == null)
                {
                    return Json(new { success = true, responseText = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = nv.Ten }, JsonRequestBehavior.AllowGet);
                }
            }
        }

     
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteDoc(int id)
        {
            //id = id.Substring(1, id.Length - 2);
            //nameOfDoc = nameOfDoc.Substring(1, nameOfDoc.Length - 2);
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    GiayTo emp = db.GiayToes.Where(x => x.MaGiayTo == id).FirstOrDefault<GiayTo>();
                    db.GiayToes.Remove(emp);
                    db.SaveChanges();
                    List<GiayTo> list = db.Database.SqlQuery<TenNV>("select n.Ten,g.* from GiayTo g, NhanVien n where g.MaNV = n.MaNV").ToList<GiayTo>();
                    return Json(new { success = true, responseText = "Your message successfuly sent!", list }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }



        //listByThuong

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty")]
        [HttpPost]
        public ActionResult list()
        {
            using(QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<HoSoNhanVien> hs_nv = new List<HoSoNhanVien>();
                hs_nv = (from nv in db.NhanViens
                         join hs in db.HoSoes
                         on nv.MaNV equals hs.MaNV
                         where hs.TrangThaiHoSo != "hồ sơ ngoài"
                         select new
                         {
                             maNV = hs.MaNV,
                             ten = nv.Ten,
                             ngaysinh = nv.NgaySinh,
                             nguoiGiaoHoSo = hs.NguoiGiaoHoSo,
                             ngayNhanHoSo = hs.NgayNhanHoSo,
                             nguoiGiuHoSo = hs.NguoiGiuHoSo
                         }).ToList().Select(p => new HoSoNhanVien
                         {
                             MaNV = p.maNV,
                             Ten = p.ten,
                             NgaySinh = p.ngaysinh.ToString(),
                             NguoiGiaoHoSo = p.nguoiGiaoHoSo,
                             NgayNhanHoSo = p.ngayNhanHoSo.ToString(),
                             NguoiGiuHoSo = p.nguoiGiaoHoSo

                         }).ToList();


                var dataJson = Json(new { success = true, data = hs_nv });

                string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }
            
        }
        


        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-ho-so")]
        [HttpPost]
        public ActionResult listHoSo(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            

            var HoSoByMaNV = from hs in db.HoSoes join nv in db.NhanViens on hs.MaNV equals nv.MaNV
                             where nv.MaNV == id_
                             select new
                              {
                                  maNV = hs.MaNV,
                                  ten = nv.Ten,
                                  nguoiGiuHoSo = hs.NguoiGiuHoSo,
                                  ngayNhanHoSo = hs.NgayNhanHoSo,
                                  nguoiGiaoHoSo = hs.NguoiGiaoHoSo,
                                  camKetTuyenDung = hs.CamKetTuyenDung,
                                  quyetDinhTiepNhan = hs.QuyetDinhTiepNhanDVC,
                                  nguoiBanGiaoBangNhapKho = hs.NguoiBanGiaoBangNhapKho

  
                              };
            var dataJson = Json(new { success = true, data = HoSoByMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;
        }

        [Route("#")]
        [HttpPost]
        public ActionResult listNhanVien(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var nhanVien = from nv in db.NhanViens
                             where nv.MaNV ==id
                             select new
                             {
                                 maNV= nv.MaNV,
                                 ten = nv.Ten,
                                 ngaySinh = nv.NgaySinh,
                                 soCMND = nv.SoCMND,
                                 soBHXH = nv.SoBHXH,
                                 soDT = nv.SoDienThoai,
                                 queQuan = nv.QueQuan,
                                 noiOHientai = nv.NoiOHienTai,
                                 trinhDoHocVan = nv.TrinhDoHocVan

                             };
            var dataJson = Json(new { success = true, data = nhanVien });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;
        }



        [Route("#")]
        [HttpPost]
        public ActionResult listLichSuBoSung(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var LichSuBoSungByMaNV = from lsbs in db.LichSuBoSungSYLLs
                             join nv in db.NhanViens on lsbs.MaNV equals nv.MaNV
                             where lsbs.MaNV == id
                             select new
                             {
                                 maNV = nv.MaNV,
                                 ten = nv.Ten,
                                 namBoSung = lsbs.NamBoSung,
                                 dotBoSung = lsbs.DotBoSung

                             };
            var dataJson = Json(new { success = true, data = LichSuBoSungByMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;
        }

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-giay-to")]
        [HttpPost]
        public ActionResult listGiayTo()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var giayToMaNV = from gt in db.GiayToes
                             join nv in db.NhanViens on gt.MaNV equals nv.MaNV
                             where gt.MaNV == id_
                             select new
                             {
                                 maNV = nv.MaNV,
                                 ten = nv.Ten,
                                 tenGiayTo = gt.TenGiayTo,
                                 maGiayTo = gt.MaGiayTo,
                                 kieuGiayTo = gt.KieuGiayTo

                             };
            var dataJson = Json(new { success = true, data = giayToMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;

        }

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-bang-cap")]
        [HttpPost]
        public ActionResult chiTietbangCap()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var chiTietBangCapByMaNV = from ctbc in db.ChiTiet_BangCap_GiayChungNhan
                             join nv in db.NhanViens on ctbc.MaNV equals nv.MaNV
                             
                             where ctbc.MaNV == id_
                             select new
                             {
                                 maNV = nv.MaNV,
                                 ten = nv.Ten,
                                 soHieu = ctbc.SoHieu,
                                 maBangCap = ctbc.MaBangCap_GiayChungNhan,
                                 ngayCap = ctbc.NgayCap.ToString()                                                                  

                             };
            var dataJson = Json(new { success = true, data = chiTietBangCapByMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;

        }

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/quan-he-gia-dinh")]
        [HttpPost]
        public ActionResult quanHeGiadinh(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var quanHeGiaDinhByMaNV = from qhgd in db.QuanHeGiaDinhs
                                       join nv in db.NhanViens on qhgd.MaNV equals nv.MaNV

                                       where qhgd.MaNV == id
                                       select new
                                       {
                                           maNV = nv.MaNV,
                                           ten = nv.Ten,
                                           moiQuanhe = qhgd.MoiQuanHe,
                                           ngaySinh = qhgd.NgaySinh,
                                           lyLich = qhgd.LyLich,
                                           loaiGiaDinh = qhgd.LoaiGiaDinh
                                           

                                       };
            var dataJson = Json(new { success = true, data = quanHeGiaDinhByMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;

        }


        //editByThuong
        [HttpGet]
        public ActionResult EditHoSo(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                HoSo hoSo = db.HoSoes.Where(x => x.MaNV == id).FirstOrDefault<HoSo>();
                return View(hoSo);
            }
        }
        [HttpPost]
        public ActionResult EditHoSo(HoSo hoSo)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (hoSo != null)
                {
                    db.Entry(hoSo).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        public ActionResult EditChiTietbangCap(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                ChiTiet_BangCap_GiayChungNhan chiTiet = db.ChiTiet_BangCap_GiayChungNhan.Where(x => x.MaNV == id).FirstOrDefault<ChiTiet_BangCap_GiayChungNhan>();
                return View(chiTiet);
            }
        }
        [HttpPost]
        public ActionResult EditChiTietbangCap(ChiTiet_BangCap_GiayChungNhan chiTiet_BangCap)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (chiTiet_BangCap != null)
                {
                    db.Entry(chiTiet_BangCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        public ActionResult EditQuanHeGiaDinh(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                QuanHeGiaDinh qh = db.QuanHeGiaDinhs.Where(x => x.MaNV == id).FirstOrDefault<QuanHeGiaDinh>();
                return View(qh);
            }
        }
        [HttpPost]
        public ActionResult EditQuanHeGiaDinh(QuanHeGiaDinh quanHeGiaDinh)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (quanHeGiaDinh != null)
                {
                    db.Entry(quanHeGiaDinh).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult EditLichSuBoSung(LichSuBoSungSYLL lichSuBoSungSYLL)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (lichSuBoSungSYLL != null)
                {
                    db.Entry(lichSuBoSungSYLL).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/giay-to")]
        [HttpPost]
        public ActionResult Search(string MaNV, string TenNV, string TenGT, string KieuGT)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string query = "select n.Ten,g.* from GiayTo g, NhanVien n where g.MaNV = n.MaNV AND ";
            if (!MaNV.Equals("") || !TenNV.Equals("") || !TenGT.Equals("") || !KieuGT.Equals(""))
            {
                if (!MaNV.Equals("")) query += "n.MaNV LIKE @MaNV AND ";
                if (!TenNV.Equals("")) query += "n.Ten LIKE @Ten AND ";
                if (!TenGT.Equals("")) query += "g.TenGiayTo LIKE @TenGiayTo AND ";
                if (!KieuGT.Equals("")) query += "g.KieuGiayTo LIKE @KieuGiayTo AND ";
            }
            query = query.Substring(0, query.Length - 5);
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;
            string kieuGT = "";
            if (KieuGT.Equals("goc"))
            {
                kieuGT = "Gốc";
            }
            else if (KieuGT.Equals("daudo"))
            {
                kieuGT = "Dấu đỏ";
            }
            else if (KieuGT.Equals("sao"))
            {
                kieuGT = "Sao,Công chứng";
            }
            else
            {
                kieuGT = "Photo";
            }
            List<TenNV> searchList = db.Database.SqlQuery<TenNV>(query,
                new SqlParameter("MaNV", '%' + MaNV + '%'),
                new SqlParameter("Ten", '%' + TenNV + '%'),
                new SqlParameter("TenGiayTo", '%' + TenGT + '%'),
                new SqlParameter("KieuGiayTo", kieuGT)
                ).ToList();
            int totalrows = searchList.Count;
            int totalrowsafterfiltering = searchList.Count;
            //sorting
            searchList = searchList.OrderBy(sortColumnName + " " + sortDirection).ToList<TenNV>();
            //paging
            searchList = searchList.Skip(start).Take(length).ToList<TenNV>();

            return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }

    }

}
