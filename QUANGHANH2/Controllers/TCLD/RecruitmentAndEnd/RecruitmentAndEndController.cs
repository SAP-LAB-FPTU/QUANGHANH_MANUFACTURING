using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class RecruitmentAndEndController : Controller
    {

        public class TDCDModel
        {
            public int Stt { get; set; }
            public string TenPhongBan { get; set; }
            public int TongTuyenDungCoDien { get; set; }
            public int TongChamDutCoDien { get; set; }
            public int TongTuyenDungKhaiThac { get; set; }
            public int TongChamDutKhaiThac { get; set; }
            public int TongTuyenDung { get; set; }
            public int TongChamDut { get; set; }
            public string GhiChu { get; set; }
            public int ChenhLech { get; set; }
            public TDCDModel()
            {
                Stt = 1;
                TenPhongBan = string.Empty;
                TongTuyenDungCoDien = 0;
                TongChamDutCoDien = 0;
                TongTuyenDungKhaiThac = 0;
                TongChamDutKhaiThac = 0;
                TongTuyenDung = 0;
                TongChamDut = 0;
                GhiChu = string.Empty;
                ChenhLech = 0;
            }
        }

        public class CountModel
        {
            public string TenPhongBan { get; set; }
            public int count { get; set; }
        }

        [Auther(RightID = "104")]
        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-cac-don-vi-cham-dut-tuyen-dung")]
        public ActionResult RecruitmentAndEnd()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/RecruitmentAndEnd.cshtml");
        }

        [HttpPost]
        public ActionResult GetAll(int year = 0)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            if (year == 0)
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    // them phan check nam vao day
                    System.Collections.Generic.List<CountModel> arrTuyenDungCoDien = ((from cn in db.TuyenDung_NhanVien
                                                                                       join
                                                                                       n in db.NhanViens on
                                                                                       cn.MaNV equals n.MaNV
                                                                                       join cv in db.CongViecs
                                                                                       on n.MaCongViec equals cv.MaCongViec
                                                                                       join cvncv in db.CongViec_NhomCongViec
                                                                                       on cv.MaCongViec equals cvncv.MaCongViec
                                                                                       join ncv in db.NhomCongViecs
                                                                                       on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                       where ncv.MaNhomCongViec == 7
                                                                                       join qd in db.QuyetDinhs
                                                                                       on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                       where qd.SoQuyetDinh != null
                                                                                       join d in db.Departments on
                                                                                       n.MaPhongBan equals d.department_id
                                                                                       into tb1
                                                                                       from tb2 in tb1.DefaultIfEmpty()
                                                                                       group tb2 by tb2.department_name into groupted
                                                                                       select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();
                    System.Collections.Generic.List<CountModel> arrTuyenDungKhaiThac = ((from cn in db.TuyenDung_NhanVien
                                                                                         join
                                                                                         n in db.NhanViens on
                                                                                         cn.MaNV equals n.MaNV
                                                                                         join cv in db.CongViecs
                                                                                         on n.MaCongViec equals cv.MaCongViec
                                                                                         join cvncv in db.CongViec_NhomCongViec
                                                                                         on cv.MaCongViec equals cvncv.MaCongViec
                                                                                         join ncv in db.NhomCongViecs
                                                                                         on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                         where ncv.MaNhomCongViec == 6
                                                                                         join qd in db.QuyetDinhs
                                                                                         on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                         where qd.SoQuyetDinh != null
                                                                                         join d in db.Departments on
                                                                                         n.MaPhongBan equals d.department_id
                                                                                         into tb1
                                                                                         from tb2 in tb1.DefaultIfEmpty()
                                                                                         group tb2 by tb2.department_name into groupted
                                                                                         select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();
                    System.Collections.Generic.List<CountModel> arrChamDutCoDien = ((from cn in db.ChamDut_NhanVien
                                                                                     join
                                                                                     n in db.NhanViens on
                                                                                     cn.MaNV equals n.MaNV
                                                                                     join cv in db.CongViecs
                                                                                     on n.MaCongViec equals cv.MaCongViec
                                                                                     join cvncv in db.CongViec_NhomCongViec
                                                                                     on cv.MaCongViec equals cvncv.MaCongViec
                                                                                     join ncv in db.NhomCongViecs
                                                                                     on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                     where ncv.MaNhomCongViec == 7
                                                                                     join qd in db.QuyetDinhs
                                                                                     on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                     where qd.SoQuyetDinh != null
                                                                                     join d in db.Departments on
                                                                                     n.MaPhongBan equals d.department_id
                                                                                     into tb1
                                                                                     from tb2 in tb1.DefaultIfEmpty()
                                                                                     group tb2 by tb2.department_name into groupted
                                                                                     select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();
                    System.Collections.Generic.List<CountModel> arrChamDutKhaiThac = ((from cn in db.ChamDut_NhanVien
                                                                                       join
                                                                                       n in db.NhanViens on
                                                                                       cn.MaNV equals n.MaNV
                                                                                       join cv in db.CongViecs
                                                                                        on n.MaCongViec equals cv.MaCongViec
                                                                                       join cvncv in db.CongViec_NhomCongViec
                                                                                       on cv.MaCongViec equals cvncv.MaCongViec
                                                                                       join ncv in db.NhomCongViecs
                                                                                       on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                       where ncv.MaNhomCongViec == 6
                                                                                       join qd in db.QuyetDinhs
                                                                                       on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                       where qd.SoQuyetDinh != null
                                                                                       join d in db.Departments on
                                                                                       n.MaPhongBan equals d.department_id
                                                                                       into tb1
                                                                                       from tb2 in tb1.DefaultIfEmpty()
                                                                                       group tb2 by tb2.department_name into groupted
                                                                                       select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();
                    System.Collections.Generic.List<TDCDModel> arrPhongBan = db.Departments.Where(p => !p.department_type.Contains("Điều hành")
                                                                 && !p.department_type.Contains("Đoàn thể") &&
                                                                 !p.department_type.Contains("ngoài")).Select(p => new TDCDModel
                                                                 {
                                                                     TenPhongBan = p.department_name,
                                                                     Stt = 1,
                                                                     TongTuyenDungCoDien = 0,
                                                                     TongChamDutCoDien = 0,
                                                                     TongTuyenDungKhaiThac = 0,
                                                                     TongChamDutKhaiThac = 0,
                                                                     TongTuyenDung = 0,
                                                                     TongChamDut = 0,
                                                                     GhiChu = string.Empty,
                                                                     ChenhLech = 0,
                                                                 }).ToList();
                    int stt = 1;
                    int tongCD = 0, tongTD = 0, tongCDCD = 0, tongCDKT = 0, tongTDCD = 0, tongTDKT = 0;
                    foreach (TDCDModel phongBan in arrPhongBan)
                    {
                        phongBan.Stt = stt++;
                        foreach (CountModel tdcd in arrTuyenDungCoDien)
                        {
                            if (tdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongTuyenDungCoDien = tdcd.count;
                                phongBan.TongTuyenDung += tdcd.count;
                                break;
                            }
                        }
                        foreach (CountModel tdkt in arrTuyenDungKhaiThac)
                        {
                            if (tdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongTuyenDungKhaiThac = tdkt.count;
                                phongBan.TongTuyenDung += tdkt.count;
                                break;
                            }
                        }
                        foreach (CountModel cdcd in arrChamDutCoDien)
                        {
                            if (cdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongChamDutCoDien = cdcd.count;
                                phongBan.TongChamDut += cdcd.count;
                                break;
                            }
                        }
                        foreach (CountModel cdkt in arrChamDutKhaiThac)
                        {
                            if (cdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongChamDutKhaiThac = cdkt.count;
                                phongBan.TongChamDut += cdkt.count;
                                break;
                            }
                        }
                        // them tong cham dut va tuyen dung cua tat ca cac phong ban
                        phongBan.ChenhLech = phongBan.TongTuyenDung - phongBan.TongChamDut;
                        tongTD += phongBan.TongTuyenDung;
                        tongCD += phongBan.TongChamDut;
                        tongCDCD += phongBan.TongChamDutCoDien;
                        tongCDKT += phongBan.TongChamDutKhaiThac;
                        tongTDCD += phongBan.TongTuyenDungCoDien;
                        tongTDKT += phongBan.TongTuyenDungKhaiThac;
                    }

                    // row cuối cùng trong dtable để tính tổng
                    TDCDModel totalModel = new TDCDModel
                    {
                        Stt = 0,
                        TenPhongBan = "Tổng cộng",
                        TongTuyenDung = tongTD,
                        TongTuyenDungCoDien = tongTDCD,
                        TongTuyenDungKhaiThac = tongTDKT,
                        TongChamDut = tongCD,
                        TongChamDutCoDien = tongCDCD,
                        TongChamDutKhaiThac = tongCDKT
                    };

                    totalModel.ChenhLech = totalModel.TongTuyenDung - totalModel.TongChamDut;

                    int totalrows = arrPhongBan.Count;
                    int totalrowsafterfiltering = arrPhongBan.Count;
                    arrPhongBan = arrPhongBan.Skip(start).Take(length).ToList<TDCDModel>();
                    arrPhongBan = arrPhongBan.OrderBy(sortColumnName + " " + sortDirection).ToList<TDCDModel>();
                    arrPhongBan.Add(totalModel);
                    return Json(new { success = true, data = arrPhongBan, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
            }
            else // khi tìm kiếm bằng năm
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    // them phan check nam vao day
                    System.Collections.Generic.List<CountModel> arrTuyenDungCoDien = ((from cn in db.TuyenDung_NhanVien
                                                                                       join
                                                                                         n in db.NhanViens on
                                                                                         cn.MaNV equals n.MaNV
                                                                                       join cv in db.CongViecs
                                                                                       on n.MaCongViec equals cv.MaCongViec
                                                                                       join cvncv in db.CongViec_NhomCongViec
                                                                                       on cv.MaCongViec equals cvncv.MaCongViec
                                                                                       join ncv in db.NhomCongViecs
                                                                                       on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                       where ncv.MaNhomCongViec == 7
                                                                                       join qd in db.QuyetDinhs
                                                                                       on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                       where qd.SoQuyetDinh != null
                                                                                       && cn.NgayTuyenDung.Year == year
                                                                                       join d in db.Departments on
                                                                                       n.MaPhongBan equals d.department_id
                                                                                       into tb1
                                                                                       from tb2 in tb1.DefaultIfEmpty()
                                                                                       group tb2 by tb2.department_name into groupted
                                                                                       select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();
                    System.Collections.Generic.List<CountModel> arrTuyenDungKhaiThac = ((from cn in db.TuyenDung_NhanVien
                                                                                         join
                                                                                         n in db.NhanViens on
                                                                                         cn.MaNV equals n.MaNV
                                                                                         join cv in db.CongViecs
                                                                                         on n.MaCongViec equals cv.MaCongViec
                                                                                         join cvncv in db.CongViec_NhomCongViec
                                                                                         on cv.MaCongViec equals cvncv.MaCongViec
                                                                                         join ncv in db.NhomCongViecs
                                                                                         on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                         where ncv.MaNhomCongViec == 6
                                                                                         join qd in db.QuyetDinhs
                                                                                         on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                         where qd.SoQuyetDinh != null
                                                                                           && cn.NgayTuyenDung.Year == year
                                                                                         join d in db.Departments on
                                                                                         n.MaPhongBan equals d.department_id
                                                                                         into tb1
                                                                                         from tb2 in tb1.DefaultIfEmpty()
                                                                                         group tb2 by tb2.department_name into groupted
                                                                                         select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();
                    System.Collections.Generic.List<CountModel> arrChamDutCoDien = ((from cn in db.ChamDut_NhanVien
                                                                                     join
                                                                                     n in db.NhanViens on
                                                                                     cn.MaNV equals n.MaNV
                                                                                     join cv in db.CongViecs
                                                                                     on n.MaCongViec equals cv.MaCongViec
                                                                                     join cvncv in db.CongViec_NhomCongViec
                                                                                     on cv.MaCongViec equals cvncv.MaCongViec
                                                                                     join ncv in db.NhomCongViecs
                                                                                     on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                     where ncv.MaNhomCongViec == 7
                                                                                     join qd in db.QuyetDinhs
                                                                                     on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                     where qd.SoQuyetDinh != null
                                                                                     && cn.NgayChamDut.Year == year
                                                                                     join d in db.Departments on
                                                                                     n.MaPhongBan equals d.department_id
                                                                                     into tb1
                                                                                     from tb2 in tb1.DefaultIfEmpty()
                                                                                     group tb2 by tb2.department_name into groupted
                                                                                     select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();
                    System.Collections.Generic.List<CountModel> arrChamDutKhaiThac = ((from cn in db.ChamDut_NhanVien
                                                                                       join
                                                                                       n in db.NhanViens on
                                                                                       cn.MaNV equals n.MaNV
                                                                                       join cv in db.CongViecs
                                                                                        on n.MaCongViec equals cv.MaCongViec
                                                                                       join cvncv in db.CongViec_NhomCongViec
                                                                                       on cv.MaCongViec equals cvncv.MaCongViec
                                                                                       join ncv in db.NhomCongViecs
                                                                                       on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                       where ncv.MaNhomCongViec == 6
                                                                                       join qd in db.QuyetDinhs
                                                                                       on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                       where qd.SoQuyetDinh != null
                                                                                       && cn.NgayChamDut.Year == year
                                                                                       join d in db.Departments on
                                                                                       n.MaPhongBan equals d.department_id
                                                                                       into tb1
                                                                                       from tb2 in tb1.DefaultIfEmpty()
                                                                                       group tb2 by tb2.department_name into groupted
                                                                                       select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                              ).ToList();

                    System.Collections.Generic.List<TDCDModel> arrPhongBan = db.Departments.Where(p => !p.department_type.Contains("Điều hành")
                                                                 && !p.department_type.Contains("Đoàn thể") &&
                                                                 !p.department_type.Contains("ngoài")).Select(p => new TDCDModel
                                                                 {
                                                                     TenPhongBan = p.department_name,
                                                                     Stt = 1,
                                                                     TongTuyenDungCoDien = 0,
                                                                     TongChamDutCoDien = 0,
                                                                     TongTuyenDungKhaiThac = 0,
                                                                     TongChamDutKhaiThac = 0,
                                                                     TongTuyenDung = 0,
                                                                     TongChamDut = 0,
                                                                     GhiChu = string.Empty,
                                                                     ChenhLech = 0,
                                                                 }).ToList();
                    int stt = 1;
                    int tongCD = 0, tongTD = 0, tongCDCD = 0, tongCDKT = 0, tongTDCD = 0, tongTDKT = 0;
                    foreach (TDCDModel phongBan in arrPhongBan)
                    {
                        phongBan.Stt = stt++;
                        foreach (CountModel tdcd in arrTuyenDungCoDien)
                        {
                            if (tdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongTuyenDungCoDien = tdcd.count;
                                phongBan.TongTuyenDung += tdcd.count;
                                break;
                            }
                        }
                        foreach (CountModel tdkt in arrTuyenDungKhaiThac)
                        {
                            if (tdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongTuyenDungKhaiThac = tdkt.count;
                                phongBan.TongTuyenDung += tdkt.count;
                                break;
                            }
                        }
                        foreach (CountModel cdcd in arrChamDutCoDien)
                        {
                            if (cdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongChamDutCoDien = cdcd.count;
                                phongBan.TongChamDut += cdcd.count;
                                break;
                            }
                        }
                        foreach (CountModel cdkt in arrChamDutKhaiThac)
                        {
                            if (cdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                            {
                                phongBan.TongChamDutKhaiThac = cdkt.count;
                                phongBan.TongChamDut += cdkt.count;
                                break;
                            }
                        }
                        // them tong cham dut va tuyen dung cua tat ca cac phong ban
                        phongBan.ChenhLech = phongBan.TongTuyenDung - phongBan.TongChamDut;
                        tongTD += phongBan.TongTuyenDung;
                        tongCD += phongBan.TongChamDut;
                        tongCDCD += phongBan.TongChamDutCoDien;
                        tongCDKT += phongBan.TongChamDutKhaiThac;
                        tongTDCD += phongBan.TongTuyenDungCoDien;
                        tongTDKT += phongBan.TongTuyenDungKhaiThac;
                    }
                    // row cuối cùng trong dtable để tính tổng
                    TDCDModel totalModel = new TDCDModel
                    {
                        Stt = 0,
                        TenPhongBan = "Tổng cộng",
                        TongTuyenDung = tongTD,
                        TongTuyenDungCoDien = tongTDCD,
                        TongTuyenDungKhaiThac = tongTDKT,
                        TongChamDut = tongCD,
                        TongChamDutCoDien = tongCDCD,
                        TongChamDutKhaiThac = tongCDKT
                    };

                    totalModel.ChenhLech = totalModel.TongTuyenDung - totalModel.TongChamDut;

                    int totalrows = arrPhongBan.Count;
                    int totalrowsafterfiltering = arrPhongBan.Count;
                    arrPhongBan = arrPhongBan.Skip(start).Take(length).ToList<TDCDModel>();
                    arrPhongBan = arrPhongBan.OrderBy(sortColumnName + " " + sortDirection).ToList<TDCDModel>();
                    arrPhongBan.Add(totalModel);
                    return Json(new { success = true, data = arrPhongBan, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public void ExportExcel(int year = 0)
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/CD_TD_Report.xlsx");
            FileInfo file = new FileInfo(path);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    if (year == 0)
                    {
                        System.Collections.Generic.List<CountModel> arrTuyenDungCoDien = ((from cn in db.TuyenDung_NhanVien
                                                                                           join
                                                                                           n in db.NhanViens on
                                                                                           cn.MaNV equals n.MaNV
                                                                                           join cv in db.CongViecs
                                                                                           on n.MaCongViec equals cv.MaCongViec
                                                                                           join cvncv in db.CongViec_NhomCongViec
                                                                                           on cv.MaCongViec equals cvncv.MaCongViec
                                                                                           join ncv in db.NhomCongViecs
                                                                                           on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                           where ncv.MaNhomCongViec == 7
                                                                                           join qd in db.QuyetDinhs
                                                                                           on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                           where qd.SoQuyetDinh != null
                                                                                           join d in db.Departments on
                                                                                           n.MaPhongBan equals d.department_id
                                                                                           into tb1
                                                                                           from tb2 in tb1.DefaultIfEmpty()
                                                                                           group tb2 by tb2.department_name into groupted
                                                                                           select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<CountModel> arrTuyenDungKhaiThac = ((from cn in db.TuyenDung_NhanVien
                                                                                             join
                                                                                             n in db.NhanViens on
                                                                                             cn.MaNV equals n.MaNV
                                                                                             join cv in db.CongViecs
                                                                                             on n.MaCongViec equals cv.MaCongViec
                                                                                             join cvncv in db.CongViec_NhomCongViec
                                                                                             on cv.MaCongViec equals cvncv.MaCongViec
                                                                                             join ncv in db.NhomCongViecs
                                                                                             on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                             where ncv.MaNhomCongViec == 6
                                                                                             join qd in db.QuyetDinhs
                                                                                             on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                             where qd.SoQuyetDinh != null
                                                                                             join d in db.Departments on
                                                                                             n.MaPhongBan equals d.department_id
                                                                                             into tb1
                                                                                             from tb2 in tb1.DefaultIfEmpty()
                                                                                             group tb2 by tb2.department_name into groupted
                                                                                             select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<CountModel> arrChamDutCoDien = ((from cn in db.ChamDut_NhanVien
                                                                                         join
                                                                                         n in db.NhanViens on
                                                                                         cn.MaNV equals n.MaNV
                                                                                         join cv in db.CongViecs
                                                                                         on n.MaCongViec equals cv.MaCongViec
                                                                                         join cvncv in db.CongViec_NhomCongViec
                                                                                         on cv.MaCongViec equals cvncv.MaCongViec
                                                                                         join ncv in db.NhomCongViecs
                                                                                         on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                         where ncv.MaNhomCongViec == 7
                                                                                         join qd in db.QuyetDinhs
                                                                                         on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                         where qd.SoQuyetDinh != null
                                                                                         join d in db.Departments on
                                                                                         n.MaPhongBan equals d.department_id
                                                                                         into tb1
                                                                                         from tb2 in tb1.DefaultIfEmpty()
                                                                                         group tb2 by tb2.department_name into groupted
                                                                                         select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<CountModel> arrChamDutKhaiThac = ((from cn in db.ChamDut_NhanVien
                                                                                           join
                                                                                           n in db.NhanViens on
                                                                                           cn.MaNV equals n.MaNV
                                                                                           join cv in db.CongViecs
                                                                                           on n.MaCongViec equals cv.MaCongViec
                                                                                           join cvncv in db.CongViec_NhomCongViec
                                                                                           on cv.MaCongViec equals cvncv.MaCongViec
                                                                                           join ncv in db.NhomCongViecs
                                                                                           on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                           where ncv.MaNhomCongViec == 6
                                                                                           join qd in db.QuyetDinhs
                                                                                           on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                           where qd.SoQuyetDinh != null
                                                                                           join d in db.Departments on
                                                                                           n.MaPhongBan equals d.department_id
                                                                                           into tb1
                                                                                           from tb2 in tb1.DefaultIfEmpty()
                                                                                           group tb2 by tb2.department_name into groupted
                                                                                           select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<TDCDModel> arrPhongBan = db.Departments.Where(p => !p.department_type.Contains("Điều hành")
                                                                 && !p.department_type.Contains("Đoàn thể") &&
                                                                 !p.department_type.Contains("ngoài")).Select(p => new TDCDModel
                                                                 {
                                                                     TenPhongBan = p.department_name,
                                                                     Stt = 1,
                                                                     TongTuyenDungCoDien = 0,
                                                                     TongChamDutCoDien = 0,
                                                                     TongTuyenDungKhaiThac = 0,
                                                                     TongChamDutKhaiThac = 0,
                                                                     TongTuyenDung = 0,
                                                                     TongChamDut = 0,
                                                                     GhiChu = string.Empty,
                                                                     ChenhLech = 0,
                                                                 }).ToList();
                        int stt = 1;
                        int tongCD = 0, tongTD = 0, tongCDCD = 0, tongCDKT = 0, tongTDCD = 0, tongTDKT = 0;
                        foreach (TDCDModel phongBan in arrPhongBan)
                        {
                            phongBan.Stt = stt++;
                            foreach (CountModel tdcd in arrTuyenDungCoDien)
                            {
                                if (tdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongTuyenDungCoDien = tdcd.count;
                                    phongBan.TongTuyenDung += tdcd.count;
                                    break;
                                }
                            }
                            foreach (CountModel tdkt in arrTuyenDungKhaiThac)
                            {
                                if (tdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongTuyenDungKhaiThac = tdkt.count;
                                    phongBan.TongTuyenDung += tdkt.count;
                                    break;
                                }
                            }
                            foreach (CountModel cdcd in arrChamDutCoDien)
                            {
                                if (cdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongChamDutCoDien = cdcd.count;
                                    phongBan.TongChamDut += cdcd.count;
                                    break;
                                }
                            }
                            foreach (CountModel cdkt in arrChamDutKhaiThac)
                            {
                                if (cdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongChamDutKhaiThac = cdkt.count;
                                    phongBan.TongChamDut += cdkt.count;
                                    break;
                                }
                            }
                            phongBan.ChenhLech = phongBan.TongTuyenDung - phongBan.TongChamDut;
                            tongTD += phongBan.TongTuyenDung;
                            tongCD += phongBan.TongChamDut;
                            tongCDCD += phongBan.TongChamDutCoDien;
                            tongCDKT += phongBan.TongChamDutKhaiThac;
                            tongTDCD += phongBan.TongTuyenDungCoDien;
                            tongTDKT += phongBan.TongTuyenDungKhaiThac;
                        }

                        TDCDModel totalModel = new TDCDModel
                        {
                            Stt = 0,
                            TenPhongBan = "Tổng cộng",
                            TongTuyenDung = tongTD,
                            TongTuyenDungCoDien = tongTDCD,
                            TongTuyenDungKhaiThac = tongTDKT,
                            TongChamDut = tongCD,
                            TongChamDutCoDien = tongCDCD,
                            TongChamDutKhaiThac = tongCDKT
                        };
                        arrPhongBan.Add(totalModel);
                        int k = 0;
                        int totalCD = 0;
                        int totalTD = 0;
                        for (int i = 5; i < arrPhongBan.Count + 5; i++)
                        {
                            excelWorksheet.Cells[i, 1].Value = arrPhongBan.ElementAt(k).Stt;
                            excelWorksheet.Cells[i, 2].Value = arrPhongBan.ElementAt(k).TenPhongBan;
                            excelWorksheet.Cells[i, 3].Value = arrPhongBan.ElementAt(k).TongChamDut;
                            excelWorksheet.Cells[i, 4].Value = arrPhongBan.ElementAt(k).TongChamDutKhaiThac;
                            excelWorksheet.Cells[i, 5].Value = arrPhongBan.ElementAt(k).TongChamDutCoDien;
                            excelWorksheet.Cells[i, 6].Value = arrPhongBan.ElementAt(k).TongTuyenDung;
                            excelWorksheet.Cells[i, 7].Value = arrPhongBan.ElementAt(k).TongTuyenDungKhaiThac;
                            excelWorksheet.Cells[i, 8].Value = arrPhongBan.ElementAt(k).TongTuyenDungCoDien;
                            excelWorksheet.Cells[i, 9].Value = arrPhongBan.ElementAt(k).ChenhLech;
                            excelWorksheet.Cells[i, 10].Value = arrPhongBan.ElementAt(k).GhiChu;
                            totalCD += arrPhongBan.ElementAt(k).TongChamDut;
                            totalTD += arrPhongBan.ElementAt(k).TongTuyenDung;
                            k++;
                        }

                        string location = HostingEnvironment.MapPath("/excel/TCLD/download");
                        excelPackage.SaveAs(new FileInfo(location + "/CD_TD_Report_Total.xlsx"));
                    }
                    else
                    {
                        System.Collections.Generic.List<CountModel> arrTuyenDungCoDien = ((from cn in db.TuyenDung_NhanVien
                                                                                           join
                                                                                           n in db.NhanViens on
                                                                                           cn.MaNV equals n.MaNV
                                                                                           join cv in db.CongViecs
                                                                                           on n.MaCongViec equals cv.MaCongViec
                                                                                           join cvncv in db.CongViec_NhomCongViec
                                                                                           on cv.MaCongViec equals cvncv.MaCongViec
                                                                                           join ncv in db.NhomCongViecs
                                                                                           on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                           where ncv.MaNhomCongViec == 7
                                                                                           join qd in db.QuyetDinhs
                                                                                           on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                           where qd.SoQuyetDinh != null
                                                                                               && cn.NgayTuyenDung.Year == year
                                                                                           join d in db.Departments on
                                                                                           n.MaPhongBan equals d.department_id
                                                                                           into tb1
                                                                                           from tb2 in tb1.DefaultIfEmpty()
                                                                                           group tb2 by tb2.department_name into groupted
                                                                                           select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<CountModel> arrTuyenDungKhaiThac = ((from cn in db.TuyenDung_NhanVien
                                                                                             join
                                                                                           n in db.NhanViens on
                                                                                           cn.MaNV equals n.MaNV
                                                                                             join cv in db.CongViecs
                                                                                             on n.MaCongViec equals cv.MaCongViec
                                                                                             join cvncv in db.CongViec_NhomCongViec
                                                                                             on cv.MaCongViec equals cvncv.MaCongViec
                                                                                             join ncv in db.NhomCongViecs
                                                                                             on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                             where ncv.MaNhomCongViec == 6
                                                                                             join qd in db.QuyetDinhs
                                                                                             on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                             where qd.SoQuyetDinh != null
                                                                                                   && cn.NgayTuyenDung.Year == year
                                                                                             join d in db.Departments on
                                                                                             n.MaPhongBan equals d.department_id
                                                                                             into tb1
                                                                                             from tb2 in tb1.DefaultIfEmpty()
                                                                                             group tb2 by tb2.department_name into groupted
                                                                                             select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<CountModel> arrChamDutCoDien = ((from cn in db.ChamDut_NhanVien
                                                                                         join
                                                                                         n in db.NhanViens on
                                                                                         cn.MaNV equals n.MaNV
                                                                                         join cv in db.CongViecs
                                                                                         on n.MaCongViec equals cv.MaCongViec
                                                                                         join cvncv in db.CongViec_NhomCongViec
                                                                                         on cv.MaCongViec equals cvncv.MaCongViec
                                                                                         join ncv in db.NhomCongViecs
                                                                                         on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                         where ncv.MaNhomCongViec == 7
                                                                                         join qd in db.QuyetDinhs
                                                                                         on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                         where qd.SoQuyetDinh != null
                                                                                           && cn.NgayChamDut.Year == year
                                                                                         join d in db.Departments on
                                                                                         n.MaPhongBan equals d.department_id
                                                                                         into tb1
                                                                                         from tb2 in tb1.DefaultIfEmpty()
                                                                                         group tb2 by tb2.department_name into groupted
                                                                                         select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<CountModel> arrChamDutKhaiThac = ((from cn in db.ChamDut_NhanVien
                                                                                           join
                                                                                           n in db.NhanViens on
                                                                                           cn.MaNV equals n.MaNV
                                                                                           join cv in db.CongViecs
                                                                                           on n.MaCongViec equals cv.MaCongViec
                                                                                           join cvncv in db.CongViec_NhomCongViec
                                                                                           on cv.MaCongViec equals cvncv.MaCongViec
                                                                                           join ncv in db.NhomCongViecs
                                                                                           on cvncv.MaNhomCongViec equals ncv.MaNhomCongViec
                                                                                           where ncv.MaNhomCongViec == 6
                                                                                           join qd in db.QuyetDinhs
                                                                                           on cn.MaQuyetDinh equals qd.MaQuyetDinh
                                                                                           where qd.SoQuyetDinh != null
                                                                                               && cn.NgayChamDut.Year == year
                                                                                           join d in db.Departments on
                                                                                           n.MaPhongBan equals d.department_id
                                                                                           into tb1
                                                                                           from tb2 in tb1.DefaultIfEmpty()
                                                                                           group tb2 by tb2.department_name into groupted
                                                                                           select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                                  ).ToList();
                        System.Collections.Generic.List<TDCDModel> arrPhongBan = db.Departments.Where(p => !p.department_type.Contains("Điều hành")
                                                                 && !p.department_type.Contains("Đoàn thể") &&
                                                                 !p.department_type.Contains("ngoài")).Select(p => new TDCDModel
                                                                 {
                                                                     TenPhongBan = p.department_name,
                                                                     Stt = 1,
                                                                     TongTuyenDungCoDien = 0,
                                                                     TongChamDutCoDien = 0,
                                                                     TongTuyenDungKhaiThac = 0,
                                                                     TongChamDutKhaiThac = 0,
                                                                     TongTuyenDung = 0,
                                                                     TongChamDut = 0,
                                                                     GhiChu = string.Empty,
                                                                     ChenhLech = 0,
                                                                 }).ToList();
                        int stt = 1;
                        int tongCD = 0, tongTD = 0, tongCDCD = 0, tongCDKT = 0, tongTDCD = 0, tongTDKT = 0;
                        foreach (TDCDModel phongBan in arrPhongBan)
                        {
                            phongBan.Stt = stt++;
                            foreach (CountModel tdcd in arrTuyenDungCoDien)
                            {
                                if (tdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongTuyenDungCoDien = tdcd.count;
                                    phongBan.TongTuyenDung += tdcd.count;
                                    break;
                                }
                            }
                            foreach (CountModel tdkt in arrTuyenDungKhaiThac)
                            {
                                if (tdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongTuyenDungKhaiThac = tdkt.count;
                                    phongBan.TongTuyenDung += tdkt.count;
                                    break;
                                }
                            }
                            foreach (CountModel cdcd in arrChamDutCoDien)
                            {
                                if (cdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongChamDutCoDien = cdcd.count;
                                    phongBan.TongChamDut += cdcd.count;
                                    break;
                                }
                            }
                            foreach (CountModel cdkt in arrChamDutKhaiThac)
                            {
                                if (cdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                                {
                                    phongBan.TongChamDutKhaiThac = cdkt.count;
                                    phongBan.TongChamDut += cdkt.count;
                                    break;
                                }
                            }
                            phongBan.ChenhLech = phongBan.TongTuyenDung - phongBan.TongChamDut;
                            tongTD += phongBan.TongTuyenDung;
                            tongCD += phongBan.TongChamDut;
                            tongCDCD += phongBan.TongChamDutCoDien;
                            tongCDKT += phongBan.TongChamDutKhaiThac;
                            tongTDCD += phongBan.TongTuyenDungCoDien;
                            tongTDKT += phongBan.TongTuyenDungKhaiThac;
                        }

                        TDCDModel totalModel = new TDCDModel
                        {
                            Stt = 0,
                            TenPhongBan = "Tổng cộng",
                            TongTuyenDung = tongTD,
                            TongTuyenDungCoDien = tongTDCD,
                            TongTuyenDungKhaiThac = tongTDKT,
                            TongChamDut = tongCD,
                            TongChamDutCoDien = tongCDCD,
                            TongChamDutKhaiThac = tongCDKT
                        };
                        arrPhongBan.Add(totalModel);
                        int k = 0;
                        for (int i = 5; i < arrPhongBan.Count + 5; i++)
                        {
                            excelWorksheet.Cells[i, 1].Value = arrPhongBan.ElementAt(k).Stt;
                            excelWorksheet.Cells[i, 2].Value = arrPhongBan.ElementAt(k).TenPhongBan;
                            excelWorksheet.Cells[i, 3].Value = arrPhongBan.ElementAt(k).TongChamDut;
                            excelWorksheet.Cells[i, 4].Value = arrPhongBan.ElementAt(k).TongChamDutKhaiThac;
                            excelWorksheet.Cells[i, 5].Value = arrPhongBan.ElementAt(k).TongChamDutCoDien;
                            excelWorksheet.Cells[i, 6].Value = arrPhongBan.ElementAt(k).TongTuyenDung;
                            excelWorksheet.Cells[i, 7].Value = arrPhongBan.ElementAt(k).TongTuyenDungKhaiThac;
                            excelWorksheet.Cells[i, 8].Value = arrPhongBan.ElementAt(k).TongTuyenDungCoDien;
                            excelWorksheet.Cells[i, 9].Value = arrPhongBan.ElementAt(k).ChenhLech;
                            excelWorksheet.Cells[i, 10].Value = arrPhongBan.ElementAt(k).GhiChu;
                            k++;
                        }
                        string location = HostingEnvironment.MapPath("/excel/TCLD/download");
                        excelPackage.SaveAs(new FileInfo(location + "/CD_TD_Report_" + year + ".xlsx"));
                    }
                }

            }

        }


        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-cham-dut")]
        public ActionResult End()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/End.cshtml");
        }

    }
}