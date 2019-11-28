using Microsoft.Ajax.Utilities;
using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using QUANGHANH2.SupportClass;
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
        // code's hoangnd18

        private class RecordTotalEmployee
        {
            public RecordTotalEmployee()
            {
            }

            public string dv { get; set; }
            public int ldts { get; set; }
            public int nu { get; set; }
            public int tsgt { get; set; }
            public int qd { get; set; }
            public int pppgd { get; set; }
            public int pqdcd { get; set; }
            public int nvkt { get; set; }
            public int cv { get; set; }
            public int ts1 { get; set; }
            public int kt { get; set; }
            public int cdl { get; set; }
            public int khac { get; set; }
            public int ts2 { get; set; }
            public int pv { get; set; }
            public int ktv { get; set; }
            public int pt { get; set; }
            public string ghichu { get; set; }
        }

        public ActionResult exportExcelToListEmployees()
        {
            List<RecordTotalEmployee> list = ListAllEmployees();

            string path = HostingEnvironment.MapPath("/excel/TCLD/TongHopNhanSu/Tổng-hợp-nhân-lực.xlsx");

            string saveAsPath = ("/excel/TCLD/download/Tổng-hợp-nhân-lực.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                int index = 3;
                foreach (var item in list)
                {
                    if (item.ghichu.Equals("tong") || item.ghichu.Equals("phongban"))
                    {
                        excelWorksheet.Cells[index, 1].Style.Font.Bold = true;

                    }

                    excelWorksheet.Cells[index, 1].Value = item.dv;
                    excelWorksheet.Cells[index, 2].Value = item.ldts;
                    excelWorksheet.Cells[index, 3].Value = item.nu;
                    excelWorksheet.Cells[index, 4].Value = item.tsgt;
                    excelWorksheet.Cells[index, 5].Value = item.qd;
                    excelWorksheet.Cells[index, 6].Value = item.pppgd;
                    excelWorksheet.Cells[index, 7].Value = item.pqdcd;
                    excelWorksheet.Cells[index, 8].Value = item.nvkt;
                    excelWorksheet.Cells[index, 9].Value = item.cv;
                    excelWorksheet.Cells[index, 10].Value = item.ts1;
                    excelWorksheet.Cells[index, 11].Value = item.kt;
                    excelWorksheet.Cells[index, 12].Value = item.cdl;
                    excelWorksheet.Cells[index, 13].Value = item.khac;
                    excelWorksheet.Cells[index, 14].Value = item.ts2;
                    excelWorksheet.Cells[index, 15].Value = item.pv;
                    excelWorksheet.Cells[index, 16].Value = item.ktv;
                    excelWorksheet.Cells[index, 17].Value = item.pt;
                    index++;
                }

                excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult getDataTongNhanSu()
        {
            List<RecordTotalEmployee> list = ListAllEmployees();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            int totalrows = list.Count;
            int totalrowsafterfiltering = list.Count;
            list = list.Skip(start).Take(length).ToList();
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);


        }
        private List<RecordTotalEmployee> ListAllEmployees()
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<RecordTotalEmployee> listAll = new List<RecordTotalEmployee>();
                List<RecordTotalEmployee> listAllTemp = new List<RecordTotalEmployee>();
                var recordAll = (from p in db.Departments
                                 join p1 in db.NhanViens on p.department_id equals p1.MaPhongBan
                                 join p2 in db.CongViecs on p1.MaCongViec equals p2.MaCongViec
                                 join p3 in db.CongViec_NhomCongViec on p2.MaCongViec equals p3.MaCongViec
                                 join p4 in db.NhomCongViecs on p3.MaNhomCongViec equals p4.MaNhomCongViec
                                 join p5 in db.DienCongViecs on p4.MaDienCongViec equals p5.MaDienCongViec

                                 where p1.MaTrangThai == 1 & p.isInside != false & p3.MaNhomCongViec >=1 & p3.MaNhomCongViec <=9
                                 select
                                 new
                                 {
                                     idCongViec = p2.MaCongViec,
                                     idDienCongViec = p5.MaDienCongViec,
                                     idNhomCongViec = p3.MaNhomCongViec,
                                     tenPhongBan = p.department_name,
                                     maPhongBan = p.department_id,
                                     tenDonVi = p.department_type,
                                     gioiTinh = p1.GioiTinh,
                                     maNv = p1.MaNV,

                                 }

                                ).ToList();
                var listDonVi = (from p in db.Departments
                                 where p.isInside != false
                                 select new
                                 {
                                     tenPhongBan = p.department_name,
                                     maPhongBan = p.department_id,
                                     tenDonVi = p.department_type,

                                 }).ToList();

                foreach (var i in listDonVi.DistinctBy(x => x.tenDonVi).ToList())
                {
                    var listPhongBan = listDonVi.Where(x => x.tenDonVi == i.tenDonVi);
                    var count = listPhongBan.Count();
                    List<RecordTotalEmployee> listPhongBanAll = new List<RecordTotalEmployee>();
                    List<RecordTotalEmployee> listPhongBanTemp = new List<RecordTotalEmployee>();

                    foreach (var item in listPhongBan)
                    {

                        var tonglaodongphongban = recordAll.Where(x => x.maPhongBan == item.maPhongBan).Count();
                        var tonglaodongphongbanNu = recordAll.Where(x => x.gioiTinh == false & x.maPhongBan == item.maPhongBan).Count();
                        var quandocNumber = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 1).Count();
                        var ppOrPgd = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 2).Count();
                        var pqdcdV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 3).Count();
                        var nvktV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 4).Count();
                        var cvV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 5).Count();
                        var ktvV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 6).Count();
                        var cdlV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 7).Count();
                        //recordAll.Where(x => x.maPhongBan == i.maPhongBan ).Count();
                                              
                        var pvV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 8).Count();
                        //recordAll.Where(x => x.maPhongBan == i.maPhongBan).Count();
                        var ktV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 9).Count();
                        var ptV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 10).Count();
                        var khacV = tonglaodongphongban - (quandocNumber + ppOrPgd + pqdcdV + nvktV + cvV + ktvV + cdlV + pvV + ktV + ptV);
                        //recordAll.Where(x => x.maPhongBan == i.maPhongBan).Count();
                        RecordTotalEmployee phongban = new RecordTotalEmployee
                        {
                            dv = item.tenPhongBan,
                            ldts = tonglaodongphongban,
                            nu = tonglaodongphongbanNu,
                            tsgt = quandocNumber + ppOrPgd + nvktV + cvV + pqdcdV,
                            qd = quandocNumber,
                            pppgd = ppOrPgd,
                            pqdcd = pqdcdV,
                            nvkt = nvktV,
                            cv = cvV,
                            ts1 = ktvV + cdlV + khacV,
                            kt = ktvV,
                            cdl = cdlV,
                            khac = khacV,
                            ts2 = pvV + ktvV + ptV,
                            pv = pvV,
                            ktv = ktvV,
                            pt = ptV,
                            ghichu = "donvi"
                        };
                        listPhongBanTemp.Add(phongban);
                    }

                    //first row donvi=>phong ban

                    var tonglaodongdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi).Count(); ;
                    var tonglaodongdonviNu = recordAll.Where(x => x.gioiTinh == false & x.tenDonVi == i.tenDonVi).Count();
                    var quandocNumberdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 1).Count();
                    var ppOrPgddonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 2).Count();
                    var pqdcdVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 3).Count(); ;
                    var nvktVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 4).Count();
                    var cvVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 5).Count();
                    var ktvVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 6).Count();
                    var cdlVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 7).Count();
                    var pvVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 8).Count();
                    var ktVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 9).Count();
                    var ptVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 10).Count();
                    var khacVdonvi = tonglaodongdonvi - (quandocNumberdonvi + ppOrPgddonvi + pqdcdVdonvi + nvktVdonvi + cvVdonvi + ktvVdonvi + cdlVdonvi + pvVdonvi + ktVdonvi + ptVdonvi);

                    listPhongBanAll.Add(new RecordTotalEmployee
                    {
                        dv = i.tenDonVi.ToUpper(),
                        ldts = tonglaodongdonvi,
                        nu = tonglaodongdonviNu,
                        tsgt = quandocNumberdonvi + ppOrPgddonvi + nvktVdonvi + cvVdonvi + pqdcdVdonvi,
                        qd = quandocNumberdonvi,
                        pppgd = ppOrPgddonvi,
                        pqdcd = pqdcdVdonvi,
                        nvkt = nvktVdonvi,
                        cv = cvVdonvi,
                        ts1 = ktvVdonvi + cdlVdonvi + khacVdonvi,
                        kt = ktvVdonvi,
                        cdl = cdlVdonvi,
                        khac = khacVdonvi,
                        ts2 = pvVdonvi + ktVdonvi + ptVdonvi,
                        pv = pvVdonvi,
                        ktv = ktVdonvi,
                        pt = ptVdonvi,
                        ghichu = "phongban"
                    });
                    listPhongBanAll.AddRange(listPhongBanTemp);



                    listAllTemp.AddRange(listPhongBanAll);
                }

                //total Tong

                var tonglaodongAll = recordAll.Count();
                var tonglaodongAllNu = recordAll.Where(x => x.gioiTinh == false).Count();
                var quandocNumberAll = recordAll.Where(x => x.idNhomCongViec == 1).Count();
                var ppOrPgdAll = recordAll.Where(x => x.idNhomCongViec == 2).Count();
                var pqdcdVAll = recordAll.Where(x => x.idNhomCongViec == 3).Count(); ;
                var nvktVAll = recordAll.Where(x => x.idNhomCongViec == 4).Count();
                var cvVAll = recordAll.Where(x => x.idNhomCongViec == 5).Count();
                var ktvVAll = recordAll.Where(x => x.idNhomCongViec == 6).Count();
                var cdlVAll = recordAll.Where(x => x.idNhomCongViec == 7).Count();          
                var pvVAll = recordAll.Where(x => x.idNhomCongViec == 8).Count();
                var ktVAll = recordAll.Where(x => x.idNhomCongViec == 9).Count();
                var ptVAll = recordAll.Where(x => x.idNhomCongViec == 10).Count();
                var khacVAll = tonglaodongAll - (quandocNumberAll + ppOrPgdAll + pqdcdVAll + nvktVAll + cvVAll + ktvVAll + cdlVAll + pvVAll + ktVAll + ptVAll);
                listAll.Add(new RecordTotalEmployee
                {
                    dv = "Tổng ",
                    ldts = tonglaodongAll,
                    nu = tonglaodongAllNu,
                    tsgt = quandocNumberAll + ppOrPgdAll + nvktVAll + cvVAll + pqdcdVAll,
                    qd = quandocNumberAll,
                    pppgd = ppOrPgdAll,
                    pqdcd = pqdcdVAll,
                    nvkt = nvktVAll,
                    cv = cvVAll,
                    ts1 = ktvVAll + cdlVAll + khacVAll,
                    kt = ktvVAll,
                    cdl = cdlVAll,
                    khac = khacVAll,
                    ts2 = pvVAll + ktVAll + ptVAll,
                    pv = pvVAll,
                    ktv = ktVAll,
                    pt = ptVAll,
                    ghichu = "tong"
                });










                //total phan xuong 

                var tonglaodongphanxuong = recordAll.Where(x => x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ").Count(); ;
                var tonglaodongphanxuongNu = recordAll.Where(x => x.gioiTinh == false & (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ")).Count();
                var quandocNumberphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 1).Count();
                var ppOrPgdphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 2).Count();
                var pqdcdVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 3).Count(); ;
                var nvktVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 4).Count();
                var cvVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 5).Count();
                var ktvVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 6).Count();
                var cdlVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 7).Count();  
                var pvVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 8).Count();
                var ktVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 9).Count();
                var ptVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 10).Count();
                var khacVphanxuong = tonglaodongphanxuong - (quandocNumberphanxuong + ppOrPgdphanxuong + pqdcdVphanxuong + nvktVphanxuong + cvVphanxuong + ktvVphanxuong + cdlVphanxuong + pvVphanxuong + ktVphanxuong + ptVphanxuong);
                listAll.Add(new RecordTotalEmployee
                {
                    dv = "PHÂN XƯỞNG",
                    ldts = tonglaodongphanxuong,
                    nu = tonglaodongphanxuongNu,
                    tsgt = quandocNumberphanxuong + pqdcdVphanxuong + nvktVphanxuong + cvVphanxuong + ppOrPgdphanxuong,
                    qd = quandocNumberphanxuong,
                    pppgd = ppOrPgdphanxuong,
                    pqdcd = pqdcdVphanxuong,
                    nvkt = nvktVphanxuong,
                    cv = cvVphanxuong,
                    ts1 = ktvVphanxuong + cdlVphanxuong + khacVphanxuong,
                    kt = ktvVphanxuong,
                    cdl = cdlVphanxuong,
                    khac = khacVphanxuong,
                    ts2 = pvVphanxuong + ktVphanxuong + ptVphanxuong,
                    pv = pvVphanxuong,
                    ktv = ktVphanxuong,
                    pt = ptVphanxuong,
                    ghichu = "phongban"
                });
                listAll.AddRange(listAllTemp);

                return listAll;
            }
        }





        // endline hoangnd18



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
                QuanHeGiaDinh qh = new QuanHeGiaDinh();
                List<QuanHeGiaDinh> qhList = db.QuanHeGiaDinhs.Where(x => x.MaNV == id).ToList();
                ViewBag.qhList = qhList;
                QuaTrinhCongTac qt = new QuaTrinhCongTac();
                List<QuaTrinhCongTac> qtList = db.QuaTrinhCongTacs.Where(x => x.MaNV == id).ToList();
                ViewBag.qtList = qtList;
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

                QuanHeGiaDinh qh = new QuanHeGiaDinh();
                List<QuanHeGiaDinh> qhList = db.QuanHeGiaDinhs.Where(x => x.MaNV == id).ToList();
                ViewBag.qhList = qhList;
                QuaTrinhCongTac qt = new QuaTrinhCongTac();
                List<QuaTrinhCongTac> qtList = db.QuaTrinhCongTacs.Where(x => x.MaNV == id).ToList();
                ViewBag.qtList = qtList;
                return View("/Views/TCLD/Brief/Edit.cshtml", db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault<NhanVien>());
            }
        }
        [Auther(RightID = "53")]
        [HttpPost]
        public ActionResult SaveEdit(NhanVien emp, string test, string[] giaDinh, string[] ngaySinhGiaDinh, string[] hoTen, string[] moiQuanHe, string[] lyLich, string[] donVi, string[] chucDanh, string[] chucVu, string[] tuNgayDenNgay)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
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

                    if (giaDinh != null)
                    {
                        List<QuanHeGiaDinh> qhList = db.QuanHeGiaDinhs.ToList();
                        for (int i = 0; i < giaDinh.Length; i++)
                        {
                            if (!giaDinh[i].Equals(""))
                            {
                                string moiQuanHeX = moiQuanHe[i];
                                string giaDinhX = giaDinh[i];
                                List<QuanHeGiaDinh> Gd = db.QuanHeGiaDinhs.Where(nv => (nv.MaNV.Equals(emp.MaNV)) && (nv.MoiQuanHe.Equals(moiQuanHeX)) && (nv.LoaiGiaDinh.Equals(giaDinhX))).ToList();
                                if (Gd.Count == 0)
                                {
                                    QuanHeGiaDinh gd = new QuanHeGiaDinh();
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
                                else
                                {
                                    QuanHeGiaDinh gd = new QuanHeGiaDinh();
                                    gd.MaNV = emp.MaNV;
                                    gd.LoaiGiaDinh = giaDinh[i];

                                    var GD = db.QuanHeGiaDinhs.Where(nv => (nv.MaNV.Equals(emp.MaNV)) && (nv.MoiQuanHe.Equals(moiQuanHeX)) && (nv.LoaiGiaDinh.Equals(giaDinhX))).FirstOrDefault();
                                    GD.HoTen = hoTen[i];
                                    if (ngaySinhGiaDinh[i] != "")
                                    {
                                        string[] date = ngaySinhGiaDinh[i].Split('/');
                                        GD.NgaySinh = Convert.ToDateTime(date[1] + "/" + date[0] + "/" + date[2]);
                                    }
                                    GD.MoiQuanHe = moiQuanHe[i];
                                    GD.LyLich = lyLich[i];
                                    db.Entry(GD).State = EntityState.Modified;
                                    db.SaveChanges();

                                }
                            }
                        }
                    }

                    if (donVi != null)
                    {
                        List<QuaTrinhCongTac> list = db.QuaTrinhCongTacs.ToList();
                        for (int i = 0; i < donVi.Length; i++)
                        {
                            if (!donVi[i].Equals(""))
                            {
                                string[] ngay = tuNgayDenNgay[i].Split('-');
                                string DonViCongTacX = donVi[i];
                                string[] ngayFix = ngay[0].Trim().Split('/');
                                List<QuaTrinhCongTac> ct = db.QuaTrinhCongTacs.Where(qtct => (qtct.MaNV.Equals(emp.MaNV)) && (qtct.DonViCongTac.Equals(DonViCongTacX))).ToList();
                                if (ct.Count == 0)
                                {
                                    QuaTrinhCongTac qtct = new QuaTrinhCongTac();
                                    qtct.MaNV = emp.MaNV;
                                    qtct.DonViCongTac = donVi[i];
                                    if (ngay[0] != "" && ngay[1] != "")
                                    {
                                        string[] dateStart = ngay[0].Split('/');
                                        qtct.NgayBatDau = Convert.ToDateTime(dateStart[1] + "/" + dateStart[0] + "/" + dateStart[2]);
                                        string[] dateEnd = ngay[1].Split('/');
                                        qtct.NgayKetThuc = Convert.ToDateTime(dateEnd[1] + "/" + dateEnd[0] + "/" + dateEnd[2]);
                                    }
                                    qtct.ChucVu = chucVu[i];
                                    qtct.ChucDanh = chucDanh[i];
                                    db.QuaTrinhCongTacs.Add(qtct);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    QuaTrinhCongTac qtct = new QuaTrinhCongTac();
                                    qtct.MaNV = emp.MaNV;
                                    qtct.DonViCongTac = donVi[i];

                                    var quaTrinh = db.QuaTrinhCongTacs.Where(congTac => (congTac.MaNV.Equals(emp.MaNV)) && (congTac.DonViCongTac.Equals(DonViCongTacX))).FirstOrDefault();
                                    if (ngay[0] != "" && ngay[1] != "")
                                    {
                                        string[] dateStart = ngay[0].Split('/');
                                        quaTrinh.NgayBatDau = Convert.ToDateTime(dateStart[1] + "/" + dateStart[0] + "/" + dateStart[2]);
                                        string[] dateEnd = ngay[1].Split('/');
                                        quaTrinh.NgayKetThuc = Convert.ToDateTime(dateEnd[1] + "/" + dateEnd[0] + "/" + dateEnd[2]);
                                    }
                                    quaTrinh.ChucVu = chucVu[i];
                                    quaTrinh.ChucDanh = chucDanh[i];
                                    db.Entry(quaTrinh).State = EntityState.Modified;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    dbct.Rollback();
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

        public class lichSuDieuDong : NhanVien
        {
            public string Ten { get; set; }
            public string SoQuyetDinh { get; set; }
            public Nullable<System.DateTime> NgayQuyetDinh { get; set; }
            public string DonViMoi { get; set; }
            public string DonViCu { get; set; }
            public string ChucVuMoi { get; set; }
            public string ChucVuCu { get; set; }
            public string BacLuongMoi { get; set; }
            public string BacLuongCu { get; set; }
            public double? MucLuongMoi { get; set; }
            public double? MucLuongCu { get; set; }
        }

        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-dong")]
        [HttpGet]
        public ActionResult TransferHistoryget(string ddid)
        {
            ViewBag.ddid = ddid;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            var temp = from n in db.NhanViens
                       where n.MaNV == ddid
                       select n.Ten;
            string name = temp.FirstOrDefault().ToString();
            ViewBag.name = name;
            return View("/Views/TCLD/Brief/TransferHistory.cshtml");
        }

        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-dong")]
        [HttpPost]
        public ActionResult TransferHistory()
        {
            var ddid = Request["ddid"];
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            var temp = from n in db.NhanViens
                       join d in db.DieuDong_NhanVien on n.MaNV equals d.MaNV
                       join q in db.QuyetDinhs on d.MaQuyetDinh equals q.MaQuyetDinh
                       where (d.MaNV == ddid
                       && q.SoQuyetDinh != null
                       || q.SoQuyetDinh.Equals(""))
                       select new
                       {
                           n.Ten,
                           q.NgayQuyetDinh,
                           q.SoQuyetDinh,
                           d.DonViMoi,
                           d.DonViCu,
                           d.ChucVuMoi,
                           d.ChucVuCu,
                           d.BacLuongCu,
                           d.BacLuongMoi,
                           d.MucLuongMoi,
                           d.MucLuongCu
                       };
            List<lichSuDieuDong> newlist = temp.ToList().Select(p => new lichSuDieuDong()
            {
                Ten = p.Ten,
                SoQuyetDinh = p.SoQuyetDinh,
                NgayQuyetDinh = p.NgayQuyetDinh,
                DonViMoi = p.DonViMoi,
                DonViCu = p.DonViCu,
                ChucVuMoi = p.ChucVuMoi,
                ChucVuCu = p.ChucVuCu,
                BacLuongMoi = p.BacLuongMoi,
                BacLuongCu = p.BacLuongCu,
                MucLuongMoi = p.MucLuongMoi,
                MucLuongCu = p.MucLuongCu
            }).ToList();
            int totalrows = newlist.Count;
            int totalrowsafterfiltering = newlist.Count;
            //sorting
            newlist = newlist.OrderBy(sortColumnName + " " + sortDirection).ToList();
            //paging
            //newlist = newlist.Skip(start).Take(length).ToList<lichSuDieuDong>();
            //ViewBag.listnv = newlist;
            return Json(new { data = newlist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

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
                    return Json(new { success = true, message = "Chưa nhập ngày chấm dứt" }, JsonRequestBehavior.AllowGet);

                }



            }

        }


        [Route("deleteFamily")]
        [HttpPost]
        public JsonResult DeleteFamily(string maQH, string id)
        {
            List<QuanHeGiaDinh> list = new List<QuanHeGiaDinh>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string query = "delete from QuanHeGiaDinh where MaQuanHeGiaDinh = @maQH";
                        db.Database.ExecuteSqlCommand(query, new SqlParameter("maQH", maQH));
                        string query2 = "select * from QuanHeGiaDinh where MaNV = @id";
                        list = db.Database.SqlQuery<QuanHeGiaDinh>(query2, new SqlParameter("id", id)).ToList();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Lỗi!" + e.Message }, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(new { success = true, listQH = list }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("deleteWork")]
        [HttpPost]
        public JsonResult DeleteWork(string maCT, string id)
        {
            List<QuaTrinhCongTac> list = new List<QuaTrinhCongTac>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string query = "delete from QuaTrinhCongTac where MaCongTac = @maCT";
                        db.Database.ExecuteSqlCommand(query, new SqlParameter("maCT", maCT));
                        string query2 = "select * from QuaTrinhCongTac where MaNV = @id";
                        list = db.Database.SqlQuery<QuaTrinhCongTac>(query2, new SqlParameter("id", id)).ToList();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Lỗi!" + e.Message }, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(new { success = true, listCT = list }, JsonRequestBehavior.AllowGet);
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
                    string query = "select * from NhanVien nv, CongViec cv where nv.MaCongViec = cv.MaCongViec ";
                    List<NhanVienExcel> list = db.Database.SqlQuery<NhanVienExcel>(query).ToList();
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
                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).NgaySinh.HasValue ? list.ElementAt(i).NgaySinh.Value.ToString("dd/MM/yyyy") : "";
                        excelWorksheet.Cells[k, 6].Value = list.ElementAt(i).SoCMND;
                        excelWorksheet.Cells[k, 7].Value = list.ElementAt(i).SoBHXH;
                        excelWorksheet.Cells[k, 14].Value = list.ElementAt(i).TenCongViec;
                        excelWorksheet.Cells[k, 15].Value = list.ElementAt(i).MucLuong;
                        excelWorksheet.Cells[k, 17].Value = list.ElementAt(i).BacLuong;
                        if (list.ElementAt(i).MaTrinhDo != null)
                        {
                            if (list.ElementAt(i).MaTrinhDo.Equals("1"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "Tiểu học";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("2"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "THCS";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("3"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "THPT";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("4"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "Trung cấp";
                            }
                            else
                            {
                                excelWorksheet.Cells[k, 20].Value = "Đại học";
                            }
                        }
                        excelWorksheet.Cells[k, 22].Value = list.ElementAt(i).QueQuan;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/download/Danh-sách-nhân-viên.xlsx")));
                }
            }

        }
    }
}