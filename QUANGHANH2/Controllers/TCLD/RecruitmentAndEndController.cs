using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                TenPhongBan = String.Empty;
                TongTuyenDungCoDien = 0;
                TongChamDutCoDien = 0;
                TongTuyenDungKhaiThac = 0;
                TongChamDutKhaiThac = 0;
                TongTuyenDung = 0;
                TongChamDut = 0;
                GhiChu = String.Empty;
                ChenhLech = 0;
            }
        }

        public class CountModel
        {
            public string TenPhongBan { get; set; }
            public int count { get; set; }
        }

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-cac-don-vi-cham-dut-tuyen-dung")]
        public ActionResult RecruitmentAndEnd()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/RecruitmentAndEnd.cshtml");
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                // them phan check nam vao day
                var arrTuyenDungCoDien = ((from cn in db.TuyenDung_NhanVien join
                                          n in db.NhanViens on
                                          cn.MaNV equals n.MaNV
                                           where n.LoaiNhanVien.Equals("Cơ điện")
                                           join d in db.Departments on
                                           n.MaPhongBan equals d.department_id
                                           into tb1
                                           from tb2 in tb1.DefaultIfEmpty()
                                           group tb2 by tb2.department_name into groupted
                                           select new CountModel { TenPhongBan = groupted.Key,count = groupted.Count() })
                                          ).ToList();
                var arrTuyenDungKhaiThac = ((from cn in db.TuyenDung_NhanVien
                                             join
                                           n in db.NhanViens on
                                           cn.MaNV equals n.MaNV
                                           where n.LoaiNhanVien.Equals("Khai thác")
                                           join d in db.Departments on
                                           n.MaPhongBan equals d.department_id
                                           into tb1
                                           from tb2 in tb1.DefaultIfEmpty()
                                           group tb2 by tb2.department_name into groupted
                                           select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                          ).ToList();
                var arrChamDutCoDien = ((from cn in db.ChamDut_NhanVien
                                           join
                                           n in db.NhanViens on
                                           cn.MaNV equals n.MaNV
                                           where n.LoaiNhanVien.Equals("Cơ điện")
                                           join d in db.Departments on
                                           n.MaPhongBan equals d.department_id
                                           into tb1
                                           from tb2 in tb1.DefaultIfEmpty()
                                           group tb2 by tb2.department_name into groupted
                                           select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                          ).ToList();
                var arrChamDutKhaiThac = ((from cn in db.ChamDut_NhanVien
                                             join
                                             n in db.NhanViens on
                                             cn.MaNV equals n.MaNV
                                             where n.LoaiNhanVien.Equals("Khai thác")
                                             join d in db.Departments on
                                             n.MaPhongBan equals d.department_id
                                             into tb1
                                             from tb2 in tb1.DefaultIfEmpty()
                                             group tb2 by tb2.department_name into groupted
                                             select new CountModel { TenPhongBan = groupted.Key, count = groupted.Count() })
                                          ).ToList();
                // end them phan check nam vao day
                var arrPhongBan = db.Departments.Select(p => new TDCDModel { TenPhongBan = p.department_name, Stt = 1,
                                                                                TongTuyenDungCoDien = 0,
                                                                                TongChamDutCoDien = 0,
                                                                                TongTuyenDungKhaiThac = 0,
                                                                                TongChamDutKhaiThac = 0,
                                                                                TongTuyenDung = 0,
                                                                                TongChamDut = 0,
                                                                                GhiChu = String.Empty,
                                                                                ChenhLech = 0,
            }).ToList();
                int stt = 1;
                foreach(var phongBan in arrPhongBan)
                {
                    phongBan.Stt = stt++;
                    foreach(var tdcd in arrTuyenDungCoDien)
                    {
                        if (tdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                        {
                            phongBan.TongTuyenDungCoDien = tdcd.count;
                            phongBan.TongTuyenDung += tdcd.count;
                            break;
                        }
                    }
                    foreach (var tdkt in arrTuyenDungKhaiThac)
                    {
                        if (tdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                        {
                            phongBan.TongTuyenDungKhaiThac = tdkt.count;
                            phongBan.TongTuyenDung += tdkt.count;
                            break;
                        }
                    }
                    foreach (var cdcd in arrChamDutCoDien)
                    {
                        if (cdcd.TenPhongBan.Equals(phongBan.TenPhongBan))
                        {
                            phongBan.TongChamDutCoDien = cdcd.count;
                            phongBan.TongChamDut += cdcd.count;
                            break;
                        }
                    }
                    foreach (var cdkt in arrChamDutKhaiThac)
                    {
                        if (cdkt.TenPhongBan.Equals(phongBan.TenPhongBan))
                        {
                            phongBan.TongChamDutKhaiThac = cdkt.count;
                            phongBan.TongChamDut += cdkt.count;
                            break;
                        }
                    }
                    phongBan.ChenhLech = phongBan.TongTuyenDung - phongBan.TongChamDut;
                }
                int totalrows = arrPhongBan.Count;
                int totalrowsafterfiltering = arrPhongBan.Count;
                arrPhongBan = arrPhongBan.Skip(start).Take(length).ToList<TDCDModel>();
                return Json(new { success = true, data = arrPhongBan, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-tuyen-dung")]
        public ActionResult Recruitment()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/Recruitment.cshtml");
        }

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-cham-dut")]
        public ActionResult End()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/End.cshtml");
        }

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tang-giam-lao-dong")]
        public ActionResult ListFrequency()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/ListFrequency.cshtml");
        }
        [Route("phong-tcld/cham-dut-va-tuyen-dung/tang-giam-lao-dong/theo-quy")]
        public ActionResult Frequency()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/Frequency.cshtml");
        }
    }
}