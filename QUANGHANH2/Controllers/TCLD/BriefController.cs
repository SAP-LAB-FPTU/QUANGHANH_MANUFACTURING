﻿
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

       

        [Route("phong-tcld/quan-ly-ho-so/ho-so-trong-cong-ty")]
        [HttpGet]
        public ActionResult Inside()
        {
            ViewBag.nameDepartment = "quanlyhoso";
            return View("/Views/TCLD/Brief/ManageBrief/Inside.cshtml");
        }








        //[Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten")]
        //public ActionResult Regulation()
        //{
        //    ViewBag.nameDepartment = "quanlyhoso";
        //    return View("/Views/TCLD/Brief/ManageBrief/Regulations.cshtml");
        //}


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
                                 nguoiBanGiaoBangNhapKho = hs.NguoiBanGiaoBangNhapKho


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
                               //trinhDoHocVan = nv.TrinhDoHocVan

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
                                         //dotBoSung = lsbs.DotBoSung

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
            return RedirectToAction("listAllHoSo");
        }
        //***start hoang
        


        [Route("phong-tcld/quan-ly-ho-so/ho-so-ngoai-cong-ty")]
        public ActionResult Outside()
        {

            return View("/Views/TCLD/Brief/ManageBrief/Outside.cshtml");

        }
        [HttpPost]
        public ActionResult Outside(String mnv)
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var mydata = (from p in db.NhanViens
                              join p1 in db.HoSoes on p.MaNV equals p1.MaNV
                              join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
                              join p3 in db.Departments on p.MaPhongBan equals p3.department_id
                              //  where p1.TrangThaiHoSo == "ngoai" 
                              select new
                              {
                                  stt = "1",
                                  manv = p.MaNV,
                                  ten = p.Ten,
                                  dvcdhd = p3.department_name,
                                  sobhxh = p.SoBHXH,
                                  sdt = p.SoDienThoai,
                                  diachi = p.NoiOHienTai,
                                  loaichamdut = p2.LoaiChamDut,
                                  edit = true
                              }).ToList();

                return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpGet]
        [Route("phong-tcld/quan-ly-ho-so/ho-so-ngoai-cong-ty/chi-tiet-ho-so")]
        public ActionResult OutSideDetail()
        {
            String mnv = Request.QueryString["manv"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var count = (from p in db.NhanViens
                             join p1 in db.HoSoes on p.MaNV equals p1.MaNV
                             join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
                             where /*p1.TrangThaiHoSo == "ngoai" &*/ p.MaNV == mnv
                             select p).Count();
                if (count != 1)
                {
                    return RedirectToAction("OutSide", "Brief");
                }
                ViewBag.nameDepartment = "quanlyhoso";

            }
            ViewBag.manv = mnv;
            return View("/Views/TCLD/Brief/ManageBrief/OutSideDetail.cshtml");
        }
        public ActionResult thongTinUyQuyen()
        {
            String mnv = Request.QueryString["manv"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var mydata = (from p in db.NhanViens
                              join p1 in db.NguoiUyQuyenLayHoSo_BaoHiem on p.MaUyQuyen equals p1.MaUyQuyen
                              where p.MaNV == mnv
                              select new
                              {
                                  hoTenNguoiUyQuyen = p1.HoTen,
                                  quanHeNguoiUyQuyen = p1.QuanHe,
                                  soCMT = p1.SoCMND,
                                  soDT = p1.SoDienThoai
                              }).ToList();
                Debug.WriteLine(mydata.Count(), "TAG");
                return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult taiThongTinCoBanHSNgoai()
        {
            String mnv = Request.QueryString["manv"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var mydata = (from p in db.NhanViens
                              join p1 in db.HoSoes on p.MaNV equals p1.MaNV
                              join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
                              join p3 in db.Departments on p.MaPhongBan equals p3.department_id


                              where p.MaNV == mnv
                              select new
                              {
                                  stt = "",
                                  sothe = p.MaNV,
                                  hoVaTen = p.Ten,
                                  ngaythangnamsinh = p.NgaySinh,
                                  donvicd = p3.department_name,
                                  soBH = p.SoBHXH,
                                  sodt = p.SoDienThoai,
                                  diachithuongtru = p.NoiOHienTai,
                                  edit = true
                              }).ToList();

                return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult thongtinLoaiChamdut()
        {
            String mnv = Request.QueryString["manv"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var listTenChamdut = (from p in db.ChamDut_NhanVien
                                      select p.LoaiChamDut).Distinct().ToList();
                var mydata = (from p in db.ChamDut_NhanVien
                              join p1 in db.QuyetDinhs on p.MaQuyetDinh equals p1.MaQuyetDinh
                              where p.MaNV == mnv
                              select new
                              {
                                  tenLoaiChamDut = p.LoaiChamDut,
                                  soQD = p.MaQuyetDinh,
                                  ngayQD = p1.NgayQuyetDinh,
                                  ngayCD = p.NgayChamDut,
                                  listChamDut=listTenChamdut
                              }).ToList();
                Debug.WriteLine(mydata.Count(), "TAG");
                return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult updateThongTinCoBan(String json)
        {

            dynamic js = JObject.Parse(json);
            String hoVaTen = js.hoVaTen;
            String sothe = js.sothe;
            String ngaythangnamsinh = js.ngaythangnamsinh;
            String donvicd = js.donvicd;
            String soBH = js.soBH;
            String sodt = js.sodt;
            String diachithuongtru = js.diachithuongtru;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                NhanVien nv = (from p in db.NhanViens where p.MaNV == sothe select p).SingleOrDefault();
                nv.Ten = hoVaTen;
                nv.SoBHXH = soBH;
                nv.SoDienThoai = sodt;
                nv.NoiOHienTai = diachithuongtru;
                if (isValidateDateTime(ngaythangnamsinh))
                {
                    nv.NgaySinh = Convert.ToDateTime(ngaythangnamsinh);
                }

                ChamDut_NhanVien cd = (from p in db.ChamDut_NhanVien where p.MaNV == sothe select p).SingleOrDefault();
                //     cd.DonViKhiChamDut = donvicd;

                db.SaveChanges();

                ViewBag.nameDepartment = "quanlyhoso";
                return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

            }


        }



        [HttpPost]
        public ActionResult updateLoaiChamDut(String json)
        {

            dynamic js = JObject.Parse(json);
            String tenLoaiChamDut = js.tenLoaiChamDut;
            String soQD = js.soQD;
            String ngayQD = js.ngayQD;
            String ngayCD = js.ngayCD;
            int soQD1 = Int32.Parse(soQD.Trim());
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ChamDut_NhanVien nv = (from p in db.ChamDut_NhanVien where p.MaQuyetDinh == soQD1 select p).SingleOrDefault();
                nv.LoaiChamDut = tenLoaiChamDut;
                if (isValidateDateTime(ngayCD))
                {
                      nv.NgayChamDut = Convert.ToDateTime(ngayCD);
                }

                QuyetDinh cd = (from p in db.QuyetDinhs where p.SoQuyetDinh == soQD select p).SingleOrDefault();
                if (isValidateDateTime(ngayQD))
                {
                    cd.NgayQuyetDinh = Convert.ToDateTime(ngayQD);
                }


                db.SaveChanges();

                ViewBag.nameDepartment = "quanlyhoso";
                return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

            }


        }
        public Boolean isValidateDateTime(String dateTime)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(dateTime);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }



        public ActionResult updateUyQuyen(String json)
        {
            dynamic js = JObject.Parse(json);
            String hoTenNguoiUyQuyen = js.hoTenNguoiUyQuyen;
            String quanHeNguoiUyQuyen = js.quanHeNguoiUyQuyen;
            String soCMT = js.soCMT;
            String soDT = js.soDT;
            String mnv = js.manv;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var count = (from p in db.NhanViens
                             join p1 in db.NguoiUyQuyenLayHoSo_BaoHiem on p.MaUyQuyen equals p1.MaUyQuyen
                             where p.MaNV == mnv
                             select p1).Count();

                NguoiUyQuyenLayHoSo_BaoHiem n = (from p in db.NguoiUyQuyenLayHoSo_BaoHiem
                                                 join p1 in db.NhanViens on p.MaUyQuyen equals p1.MaUyQuyen
                                                 where p1.MaNV == mnv
                                                 select p

                                                ).SingleOrDefault();
                if (count == 1)
                {
                    n.HoTen = hoTenNguoiUyQuyen;
                    n.QuanHe = quanHeNguoiUyQuyen;
                    n.SoCMND = soCMT;
                    n.SoDienThoai = soDT;
                }
                else
                {
                    int id = (from p in db.NguoiUyQuyenLayHoSo_BaoHiem select p).Count() + 1;
                    NhanVien nv = (from p in db.NhanViens where p.MaNV == mnv select p).SingleOrDefault();
                    n = new NguoiUyQuyenLayHoSo_BaoHiem();
                    nv.MaUyQuyen = id;
                    n.MaUyQuyen = id;
                    n.HoTen = hoTenNguoiUyQuyen;
                    n.QuanHe = quanHeNguoiUyQuyen;
                    n.SoCMND = soCMT;
                    n.SoDienThoai = soDT;
                    db.NguoiUyQuyenLayHoSo_BaoHiem.Add(n);
                }




                db.SaveChanges();


                return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

            }


        }

        public ActionResult thongTinGiayTo()
        {
            String mnv = Request.QueryString["manv"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var x = (from a in db.GiayToes
                         
                         where a.MaNV == mnv
                         select
                new
                {
                    kieu = a.KieuGiayTo,
                    ngaytra = a.NgayTra,
                    sohieu = "",
                    ngaycap = a.NgayTra,
                    ten = a.TenGiayTo,
                    manv = a.MaNV

                }).ToList();
                var y = (from a in db.ChungChi_NhanVien
                         join b in db.ChungChis on a.MaChungChi equals b.MaChungChi
                         where a.MaNV == mnv
                         select
                         new
                         {
                             kieu = b.KieuChungChi,
                             ngaytra = a.NgayTra,
                             sohieu = a.SoHieu,
                             ngaycap=a.NgayCap,
                             ten=b.TenChungChi,
                             manv = a.MaNV
                         }
                        ).ToList();
                var z = (from a in db.ChiTiet_BangCap_GiayChungNhan
                         join b in db.BangCap_GiayChungNhan on a.MaBangCap_GiayChungNhan equals b.MaBangCap_GiayChungNhan
                         where a.MaNV == mnv
                         select
                         new
                         {
                             kieu = b.KieuBangCap,
                             ngaytra = a.NgayTra,
                             sohieu = a.SoHieu,
                             ngaycap = a.NgayCap,
                             ten = b.TenBangCap,
                             manv = a.MaNV
                         }
                        ).ToList();
                var m = y.Union(z.Union(x)).ToList();
                return Json(new { success = true, data = m, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult updateGiayTo(String json)
        {
            dynamic js = JObject.Parse(json);
            String manv = js.manv;
            String sohieu = js.sohieu;
            String kieu = js.kieu;
            String ngaytra = js.ngaytra;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //  GiayChungNhan_NhanVien x = (from a in db.GiayChungNhan_NhanVien where a.MaNV == manv & a.SoHieu==sohieu  select a).SingleOrDefault() ;
                ChungChi_NhanVien x = (from a in db.ChungChi_NhanVien where a.MaNV == manv & a.SoHieu == sohieu select a).SingleOrDefault();
                ChiTiet_BangCap_GiayChungNhan y = (from a in db.ChiTiet_BangCap_GiayChungNhan where a.MaNV == manv & a.SoHieu == sohieu select a).SingleOrDefault();
                if (x != null)
                {
                    if (isValidateDateTime(ngaytra))
                        x.NgayTra = Convert.ToDateTime(ngaytra);
                }
                if (y != null)
                {
                    if (isValidateDateTime(ngaytra))
                        y.NgayTra = Convert.ToDateTime(ngaytra);

                }
                //if (z != null)
                //{
                //    if (isValidateDateTime(ngaytra))
                //        z.NgayTra = Convert.ToDateTime(ngaytra);

                //}
                db.SaveChanges();
                return Json(new { success = true, draw = Request["draw"] }, JsonRequestBehavior.AllowGet); ;
            }

        }

        public ActionResult searchOutSide(String data)
        {
            dynamic js = JObject.Parse(data);
            String manv = js.manv;
            String ten = js.ten;
            String loaichamdut = js.loaichamdut;


            // String 
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                // search ma nhan vien

                var mydata = (from p in db.NhanViens
                              join p1 in db.HoSoes on p.MaNV equals p1.MaNV
                              join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
                              join p3 in db.Departments on p.MaPhongBan equals p3.department_id
                              where /*p1.TrangThaiHoSo == "ngoai" &*/
                              p.MaNV.Contains(manv)
                              & (p.Ten.Contains(ten) | p.Ten == null)
                              & (p2.LoaiChamDut.Contains(loaichamdut) | loaichamdut =="")
                              select new
                              {
                                  stt = "1",
                                  manv = p.MaNV,
                                  ten = p.Ten,
                                  dvcdhd = p3.department_name,
                                  sobhxh = p.SoBHXH,
                                  sdt = p.SoDienThoai,
                                  diachi = p.NoiOHienTai,
                                  loaichamdut = p2.LoaiChamDut,
                                  edit = true
                              }).ToList();
                //return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);


                //    var mydata1 = (from p in db.NhanViens
                //                  join p1 in db.HoSoes on p.MaNV equals p1.MaNV
                //                  join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
                //                  where /*p1.TrangThaiHoSo == "ngoai" &*/  p.Ten.Contains(ten) & ten !=""
                //                  select new
                //                  {
                //                      stt = "1",
                //                      manv = p.MaNV,
                //                      ten = p.Ten,
                //                      dvcdhd = p2.DonViKhiChamDut,
                //                      sobhxh = p.SoBHXH,
                //                      sdt = p.SoDienThoai,
                //                      diachi = p.NoiOHienTai,
                //                      edit = true
                //                  }).ToList();
                //   // return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);


                //    var mydata2 = (from p in db.NhanViens
                //                  join p1 in db.HoSoes on p.MaNV equals p1.MaNV
                //                  join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
                //                  where /*p1.TrangThaiHoSo == "ngoai" &*/  p2.LoaiChamDut.Contains(loaichamdut) & loaichamdut!=""
                //                  select new
                //                  {
                //                      stt = "1",
                //                      manv = p.MaNV,
                //                      ten = p.Ten,
                //                      dvcdhd = p2.DonViKhiChamDut,
                //                      sobhxh = p.SoBHXH,
                //                      sdt = p.SoDienThoai,
                //                      diachi = p.NoiOHienTai,
                //                      edit = true
                //                  }).ToList();
                //var x = mydata.Union(mydata1.Union(mydata2)).Distinct();
                return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

                return Json(new { success = false, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
            }


        }



        [HttpPost]
        public ActionResult ExportExcel()
        {

            
            string path = HostingEnvironment.MapPath("/excel/TCLD/Hoso/ho-so-ngoai.xlsx");

            string saveAsPath = ("/excel/TCLD/download/ho-so-ngoai.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var mydata = (from p in db.NhanViens
                                  join p1 in db.HoSoes on p.MaNV equals p1.MaNV
                                  join p2 in db.ChamDut_NhanVien on p1.MaNV equals p2.MaNV
                                  join p3 in db.Departments on p.MaPhongBan equals p3.department_id
                                  //  where p1.TrangThaiHoSo == "ngoai" 
                                  select new
                                  {
                                      stt = "1",
                                      manv = p.MaNV,
                                      ten = p.Ten,
                                      dvcdhd = p3.department_name,
                                      sobhxh = p.SoBHXH,
                                      sdt = p.SoDienThoai,
                                      diachi = p.NoiOHienTai,
                                      loaichamdut = p2.LoaiChamDut,
                                      edit = true
                                  }).ToList();
                    int index = 2;
                    int stt = 1;
                    foreach (var item in mydata)
                    {
                        excelWorksheet.Cells[index, 1].Value = stt;
                        excelWorksheet.Cells[index, 2].Value = item.manv;
                        excelWorksheet.Cells[index, 3].Value = item.ten;
                        excelWorksheet.Cells[index, 4].Value = item.dvcdhd;
                        excelWorksheet.Cells[index, 5].Value = item.sobhxh;
                        excelWorksheet.Cells[index, 6].Value = item.sdt;
                        excelWorksheet.Cells[index, 7].Value = item.diachi;
                        excelWorksheet.Cells[index, 8].Value = item.loaichamdut;
                        
                        index++;
                        stt++;

                    }

                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                    return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
                }
            }

            

        }



        //***end hoang

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

    }


}
