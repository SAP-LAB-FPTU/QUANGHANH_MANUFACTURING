
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                             NgayNhanHoSo = p.ngayNhanHoSo,
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



    }

}
