
using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
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


        //listByThuong
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty")]
        [HttpPost]
        public ActionResult listAllHoSo()
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
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
                             NguoiGiuHoSo = p.nguoiGiuHoSo

                         }).ToList();

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
        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-chi-tiet")]
        [HttpGet]
        public ActionResult InsideDetail(string id = "")
        {
            id_ = id;
            ViewBag.MaNV = id;
            return View("/Views/TCLD/Brief/ManageBrief/InsideDetail.cshtml");
        }

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-ho-so")]
        [HttpPost]
        public ActionResult listHoSo(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var HoSoByMaNV = from hs in db.HoSoes
                             join nv in db.NhanViens on hs.MaNV equals nv.MaNV
                             where nv.MaNV == id_
                             select new
                             {
                                 maNV = hs.MaNV,
                                 ten = nv.Ten,
                                 nguoiGiuHoSo = hs.NguoiGiuHoSo,
                                 ngayNhanHoSo = hs.NgayNhanHoSo.ToString(),
                                 nguoiGiaoHoSo = hs.NguoiGiaoHoSo,
                                 camKetTuyenDung = hs.CamKetTuyenDung,
                                 quyetDinhTiepNhan = hs.QuyetDinhTiepNhanDVC,
                                 nguoiBanGiaoBangNhapKho = hs.NguoiBanGiaoBangNhapKho,


                                 quyetDinhTiepNhanDVC = hs.QuyetDinhTiepNhanDVC,
                                 ngayQDTiepNhan = hs.NgayQuyetDinhTuyenDung,
                                 ngayDiLam = nv.NgayDiLam,
                                 donViKyQuyetDinhTiepNhan = hs.DonViKyQuyetDinhTiepNhan,
                                 quyetDinhChamDut = hs.QDChamDutHopDongDVC,
                                 ngayQDChamDut = hs.NgayQuyetDinhChamDut,
                                 ngayChamDut = hs.NgayChamDut,
                                 donViKyChamDut = hs.DonViKyQuyetDinhChamDut



                             };
            var dataJson = Json(new { success = true, data = HoSoByMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;
        }


        [HttpGet]
        public ActionResult listNhanVien()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var nhanVien = (from nv in db.NhanViens
                            join td in db.TrinhDoes on nv.MaTrinhDo equals td.MaTrinhDo
                            where nv.MaNV == id_

                           select new
                           {
                               maNV = nv.MaNV,
                               ten = nv.Ten,
                               ngaySinh = nv.NgaySinh.ToString(),
                               soCMND = nv.SoCMND,
                               soBHXH = nv.SoBHXH,
                               soDT = nv.SoDienThoai,
                               queQuan = nv.QueQuan,
                               noiOHientai = nv.NoiOHienTai,
                               trinhDoHocVan = td.TenTrinhDo

                           });
            return Json(new { success = true, data = nhanVien, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
        }



        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/syll-bo-sung")]
        [HttpPost]
        public ActionResult listLichSuBoSung(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var LichSuBoSungByMaNV = from lsbs in db.LichSuBoSungSYLLs
                                     join nv in db.NhanViens on lsbs.MaNV equals nv.MaNV
                                     where lsbs.MaNV == id_
                                     select new
                                     {
                                         maNV = nv.MaNV,
                                         ten = nv.Ten,
                                         namBoSung = lsbs.NamBoSung.ToString(),
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
                                 kieuGiayTo = gt.KieuGiayTo,
                                 ngayTra = gt.NgayTra.ToString()
                             };
            var dataJson = Json(new { success = true, data = giayToMaNV }, JsonRequestBehavior.AllowGet);

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
                                       join bc in db.BangCap_GiayChungNhan on ctbc.MaBangCap_GiayChungNhan equals bc.MaBangCap_GiayChungNhan
                                       join truong in db.Truongs on bc.MaTruong equals truong.MaTruong
                                       where
                                        ctbc.MaNV == id_
                                       select new
                                       {
                                           maNV = nv.MaNV,
                                           ten = nv.Ten,
                                           soHieu = ctbc.SoHieu,
                                           maBangCap = ctbc.MaBangCap_GiayChungNhan,
                                           ngayCap = ctbc.NgayCap.ToString(),
                                           loai = bc.Loai,
                                           truong = truong.TenTruong
                                       };
          


            var dataJson = Json(new { success = true, data = chiTietBangCapByMaNV });

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;

        }

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/quan-he-gia-dinh")]
        [HttpPost]
        public ActionResult quanHeGiadinh()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var quanHeGiaDinhByMaNV = from qhgd in db.QuanHeGiaDinhs
                                      join nv in db.NhanViens on qhgd.MaNV equals nv.MaNV

                                      where qhgd.MaNV == id_
                                      select new
                                      {
                                          maNV = nv.MaNV,
                                          ten = nv.Ten,
                                          moiQuanhe = qhgd.MoiQuanHe,
                                          ngaySinh = qhgd.NgaySinh,
                                          lyLich = qhgd.LyLich,
                                          loaiGiaDinh = qhgd.LoaiGiaDinh,
                                          tenQH = qhgd.HoTen


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
                return RedirectToAction("listAllHoSo");
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
                return RedirectToAction("listAllHoSo");
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
                return RedirectToAction("listAllHoSo");
            }
        }
        [HttpGet]
        public ActionResult EditLichSuBoSung(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                LichSuBoSungSYLL qh = db.LichSuBoSungSYLLs.Where(x => x.MaNV == id).FirstOrDefault<LichSuBoSungSYLL>();
                //List<string> listMaNV = new List<string>();
                var listMaNV = (from nv in db.NhanViens
                                 select new
                                 {
                                     maNV = nv.MaNV,
                                     tenNV = nv.Ten
                                 }).ToList();
                SelectList list = new SelectList(listMaNV, "maNV", "maNV");
                ViewBag.listMaNv = list;
                return View(qh);
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
                return RedirectToAction("listAllHoSo");
            }
        }


        [HttpPost]
        public ActionResult searchlistAllBrief(string searchList)
        {


            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
                    hs_nv = (from nv in db.NhanViens
                             join hs in db.HoSoes
                             on nv.MaNV equals hs.MaNV
                             where (hs.TrangThaiHoSo != "hồ sơ ngoài")
                             && ((nv.MaNV + " ").Contains(manv))
                             && ((nv.Ten + " ").Contains(tennv))
                             && ((hs.NguoiGiaoHoSo + " ").Contains(nguoigiaohoso))
                             && ((hs.NguoiGiuHoSo + " ").Contains(nguoigiuhoso))
                             select new
                             {
                                 maNV = hs.MaNV,
                                 ten = nv.Ten,
                                 ngaysinh = nv.NgaySinh,
                                 nguoiGiaoHoSo = hs.NguoiGiaoHoSo,
                                 ngayNhanHoSo = hs.NgayNhanHoSo,
                                 nguoiGiuHoSo = hs.NguoiGiuHoSo,
                                 camKetTuyenDung = hs.CamKetTuyenDung,

                                 quyetDinhTiepNhanDVC = hs.QuyetDinhTiepNhanDVC,
                                 ngayQDTiepNhan = hs.NgayQuyetDinhTuyenDung,
                                 ngayDiLam = nv.NgayDiLam,
                                 donViKyQuyetDinhTiepNhan = hs.DonViKyQuyetDinhTiepNhan,

                                 quyetDinhChamDut = hs.QDChamDutHopDongDVC,
                                 ngayQDChamDut = hs.NgayQuyetDinhChamDut,
                                 ngayChamDut = hs.NgayChamDut,
                                 donViKyChamDut = hs.DonViKyQuyetDinhChamDut
                             }).ToList().Select(p => new HoSoNhanVien
                             {
                                 MaNV = p.maNV,
                                 Ten = p.ten,
                                 NgaySinh = p.ngaysinh.ToString(),
                                 NguoiGiaoHoSo = p.nguoiGiaoHoSo,
                                 NgayNhanHoSo = p.ngayNhanHoSo.ToString(),
                                 NguoiGiuHoSo = p.nguoiGiuHoSo,

                                 CamKetTuyenDung = p.camKetTuyenDung,
                                 QuyetDinhTiepNhanDVC = p.quyetDinhTiepNhanDVC,
                                 NgayQDTiepNhan = p.ngayQDTiepNhan.ToString(),
                                 NgayDiLam = p.ngayDiLam.ToString(),
                                 DonViKyQuyetDinhTiepNhan = p.donViKyQuyetDinhTiepNhan,
                                 QuyetDinhChamDut = p.quyetDinhChamDut,
                                 NgayQDChamDut = p.ngayQDChamDut.ToString(),
                                 NgayChamDut = p.ngayChamDut.ToString(),
                                 DonViKyChamDut = p.donViKyChamDut


                             }).ToList();


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

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty/chi-tiet-chung-chi")]
        [HttpPost]
        public ActionResult listChungChi()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();


            var chungchi = from cc_nv in db.ChungChi_NhanVien
                             join nv in db.NhanViens on cc_nv.MaNV equals nv.MaNV
                             join cc in db.ChungChis on cc_nv.MaChungChi equals cc.MaChungChi
                             where cc_nv.MaNV == id_
                             select new
                             {
                                 maNV = nv.MaNV,
                                 ten = nv.Ten,
                                 soHieu = cc_nv.SoHieu,
                                 ngayCap = cc_nv.NgayCap.ToString(),
                                 maChungChi = cc_nv.MaChungChi,
                                 ngayTra = cc_nv.NgayTra.ToString(),
                                 tenChungChi = cc.TenChungChi
  
                             };
            var dataJson = Json(new { success = true, data = chungchi }, JsonRequestBehavior.AllowGet);

            string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

            return dataJson;

        }

        [Route("phong-tcld/chung-chi/ho-so-trong-cong-ty/xuat-file-excel")]
        [HttpPost]
        public ActionResult ExporTotExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Certificate/Danh-sách-nhân-viên-hồ-sơ-trong.xlsx");
            string saveAsPath = ("/excel/TCLD/Certificate/List/download/ListCertificate.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet ws = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    
                    var nhanVien = (from nv in db.NhanViens
                                    select new
                                    {
                                        maNV = nv.MaNV,
                                        ten = nv.Ten,
                                        ngaySinh = nv.NgaySinh.ToString(),
                                        soCMND = nv.SoCMND,
                                        soBHXH = nv.SoBHXH,
                                        soDT = nv.SoDienThoai,
                                        queQuan = nv.QueQuan,
                                        noiOHientai = nv.NoiOHienTai,
                                        trinhDoHocVan = nv.TrinhDo

                                    });

                    int rowStart = 6;
                    foreach (var list in nhanVien)
                    {
                        ws.Cells[string.Format("B{0}", rowStart)].Value = list.ten;
                        ws.Cells[string.Format("C{0}", rowStart)].Value = list.maNV;
                        //ws.Cells[string.Format("D{0}", rowStart)].Value = i.KieuChungChi;
                        rowStart++;

                    }
                }
                excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }



    }


}
