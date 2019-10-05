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
            return Json(new { success = true, data =list , draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);


        }
        private List<RecordTotalEmployee> ListAllEmployees()
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<RecordTotalEmployee> listAll = new List<RecordTotalEmployee>();
                List<RecordTotalEmployee> listAllTemp = new List<RecordTotalEmployee>();

                // ten den vi
                var tenCacDonVi = (from p in db.Departments select p.department_type).Distinct().ToList();

                int tonglaodongAll = 0;
                int tonglaodongNuAll = 0;
                int tongquandocAll = 0;
                int ppOrPgdAll = 0;
                int pqdcdVDonViAll = 0;
                int nvktVDonViAll = 0;
                int cvVDonViAll = 0;
                int ktVDonViAll = 0;
                int cdlVDonViAll = 0;
                int khacVDonViAll = 0;
                int pvVDonViAll = 0;
                int ptVDonViAll = 0;


                // bao gom SX chính và Phục vụ, phụ trợ
                int tonglaodongPhanxuong = 0;
                int tonglaodongNuPhanxuong = 0;
                int tongquandocPhanxuong = 0;
                int ppOrPgdPhanxuong = 0;
                int pqdcdVDonViPhanxuong = 0;
                int nvktVDonViPhanxuong = 0;
                int cvVDonViPhanxuong = 0;
                int ktVDonViPhanxuong = 0;
                int cdlVDonViPhanxuong = 0;
                int khacVDonViPhanxuong = 0;
                int pvVDonViPhanxuong = 0;
                int ptVDonViPhanxuong = 0;


                
                foreach (var item in tenCacDonVi)
                {
                    var tenDonVi = item;
                    // tinh thong so lao dong don vi 
                    //var tonglaodong = (from p in db.Departments
                    //                   join p1 in db.NhanViens on p.department_id equals p1.MaPhongBan
                    //                   where p.department_type == tenDonVi
                    //                   select p).Distinct().ToList();

                    //// chi tiet cac phong ban
                    var cacphongban = (from p in db.Departments
                                       where p.department_type == tenDonVi
                                       select
                                      new
                                      {
                                          id = p.department_id,
                                          tenphongban = p.department_name
                                      }).ToList();



                    List<RecordTotalEmployee> listPhongBan = new List<RecordTotalEmployee>();
                    List<RecordTotalEmployee> listPhongBanTemp = new List<RecordTotalEmployee>();
                    int tonglaodongDonVi = 0;
                    int tonglaodongDonViNu = 0;
                    int tongquandocDonVi = 0;
                    int ppOrPgdDonVi = 0;
                    int pqdcdVDonVi = 0;
                    int nvktVDonVi = 0;
                    int cvVDonVi = 0;
                    int ktVDonVi = 0;
                    int cdlVDonVi = 0;
                    int khacVDonVi = 0;
                    int pvVDonVi = 0;
                    int ptVDonVi = 0;
                    //   z = z.Union(donvi).ToList();

                    if(!tenDonVi.Equals("Đơn vị sản xuất thuê ngoài"))
                    // lay chi tiet tung phong ban
                    foreach (var phongban in cacphongban)
                    {


                        var phongbanId = phongban.id;

                        var tonglaodongphongban = (from p in db.NhanViens where p.MaPhongBan == phongbanId & p.MaTrangThai==1 select p).Count();
                        tonglaodongDonVi += tonglaodongphongban;
                        var tonglaodongphongbanNu = (from p in db.NhanViens where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & p.GioiTinh == false select p).Count();
                        tonglaodongDonViNu += tonglaodongphongbanNu;
                        var quandocNumber = (from p in db.NhanViens
                                             join p1 in db.CongViecs on p.MaCongViec equals p1.MaCongViec
                                             where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & p1.MaCongViec == 18
                                             select p).Count();
                        tongquandocDonVi += quandocNumber;
                        var ppOrPgd = (from p in db.NhanViens
                                       join p1 in db.CongViecs on p.MaCongViec equals p1.MaCongViec
                                       where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & (p1.MaCongViec == 21 | p1.MaCongViec == 13)
                                       select p).Count();
                        ppOrPgdDonVi += ppOrPgd;
                        var pqdcdV = (from p in db.NhanViens
                                      join p1 in db.CongViecs on p.MaCongViec equals p1.MaCongViec
                                      where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & (p1.MaCongViec == 22 | p1.MaCongViec == 23)
                                      select p).Count();
                        pqdcdVDonVi += pqdcdV;
                        // nhan vien kinh te , can su
                        var nvktV = (from p in db.NhanViens
                                     join p1 in db.CongViecs on p.MaCongViec equals p1.MaCongViec
                                     where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & (p1.MaCongViec == 27)
                                     select p).Count();
                        nvktVDonVi += nvktV;
                        //chuyen vien
                        var cvV = (from p in db.NhanViens
                                   join p1 in db.CongViecs on p.MaCongViec equals p1.MaCongViec
                                   where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & p1.MaCongViec == 32
                                   select p).Count();
                        cvVDonVi += cvV;
                        //khai thac ham lo
                        var ktV = (from p in db.NhanViens
                                   join p1 in db.CongViecs on p.MaCongViec equals p1.MaCongViec
                                   where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & p1.MaCongViec == 24
                                   select p).Count();
                        ktVDonVi += ktV;
                        // co dien lo => k co trong db
                        var cdlV = 0;
                        cdlVDonVi += cdlV;


                        // chua define khac co nhung gi
                        var khacV = 0;
                        khacVDonVi += khacV;

                        // Phuc vu k co


                        var pvV = 0;
                        pvVDonVi += pvV;
                        //ky thuat vien phan xuong
                        var ktvV = (from p in db.NhanViens
                                    join p1 in db.CongViecs on p.MaCongViec equals p1.MaCongViec
                                    where p.MaPhongBan == phongbanId & p.MaTrangThai == 1 & p1.MaCongViec == 15
                                    select p).Count();
                        ktVDonVi += ktvV;
                        // phu tro k co
                        var ptV = 0;
                        ptVDonVi += ptV;
                        var rocordPhongBan = (from p in db.Departments
                                              
                                              where p.department_id == phongbanId & p.department_type == tenDonVi
                                              select new RecordTotalEmployee
                                              {
                                                  dv = p.department_name,
                                                  ldts = tonglaodongphongban,
                                                  nu = tonglaodongphongbanNu,
                                                  tsgt = quandocNumber + ppOrPgd + nvktV + cvV,
                                                  qd = quandocNumber,
                                                  pppgd = ppOrPgd,
                                                  pqdcd = pqdcdV,
                                                  nvkt = nvktV,
                                                  cv = cvV,
                                                  ts1 = ktV + cdlV + khacV,
                                                  kt = ktV,
                                                  cdl = cdlV,
                                                  khac = khacV,
                                                  ts2 = pvV + ktvV + ptV,
                                                  pv = pvV,
                                                  ktv = ktvV,
                                                  pt = ptV,
                                                  ghichu = "donvi"

                                              }).ToList();
                        listPhongBanTemp.AddRange(rocordPhongBan);



                    }
                    if(tenDonVi.Equals("Phân xưởng sản xuất chính") || tenDonVi.Equals("Phân xưởng thuộc về phục vụ"))
                    {
                        tonglaodongPhanxuong += tonglaodongDonVi;
                        tonglaodongNuPhanxuong += tonglaodongDonViNu;
                        tongquandocPhanxuong += tongquandocDonVi;
                        ppOrPgdPhanxuong += ppOrPgdDonVi;
                        pqdcdVDonViPhanxuong += pqdcdVDonVi;
                        nvktVDonViPhanxuong += nvktVDonVi;
                        cvVDonViPhanxuong += cvVDonVi;
                        ktVDonViPhanxuong = ktVDonVi;
                        cdlVDonViPhanxuong += cdlVDonVi;
                        khacVDonViPhanxuong += khacVDonVi;
                        pvVDonViPhanxuong += pvVDonVi;
                        ktVDonViPhanxuong += ktVDonVi;
                        ptVDonViPhanxuong += ptVDonVi;
                    }


                    tonglaodongAll += tonglaodongDonVi;
                    tonglaodongNuAll += tonglaodongDonViNu;
                    tongquandocAll += tongquandocDonVi;
                    ppOrPgdAll += ppOrPgdDonVi;
                    pqdcdVDonViAll += pqdcdVDonVi;
                    nvktVDonViAll += nvktVDonVi;
                    cvVDonViAll += cvVDonVi;
                    ktVDonViAll = ktVDonVi;
                    cdlVDonViAll += cdlVDonVi;
                    khacVDonViAll += khacVDonVi;
                    pvVDonViAll += pvVDonVi;
                    ktVDonViAll += ktVDonVi;
                    ptVDonViAll += ptVDonVi;
                    if (!tenDonVi.Equals("Đơn vị sản xuất thuê ngoài"))
                    {
                        RecordTotalEmployee donvi1 =
                                  new RecordTotalEmployee
                                  {
                                      dv = tenDonVi,
                                      ldts = tonglaodongDonVi,
                                      nu = tonglaodongDonViNu,
                                      tsgt = tongquandocDonVi + ppOrPgdDonVi + pqdcdVDonVi + nvktVDonVi + cvVDonVi,
                                      qd = tongquandocDonVi,
                                      pppgd = ppOrPgdDonVi,
                                      pqdcd = pqdcdVDonVi,
                                      nvkt = nvktVDonVi,
                                      cv = cvVDonVi,
                                      ts1 = ktVDonVi + cdlVDonVi + khacVDonVi,
                                      kt = ktVDonVi,
                                      cdl = cdlVDonVi,
                                      khac = khacVDonVi,
                                      ts2 = pvVDonVi + ktVDonVi + ptVDonVi,
                                      pv = pvVDonVi,
                                      ktv = ktVDonVi,
                                      pt = ptVDonVi,
                                      ghichu = "phongban"

                                  };
                        listPhongBan.Add(donvi1);
                        listPhongBan.AddRange(listPhongBanTemp);
                        listAllTemp.AddRange(listPhongBan);
                    }
                        
                    



                }
                // create tong 
                RecordTotalEmployee donvi =
                                 new RecordTotalEmployee
                                 {
                                     dv = "Tổng cộng",
                                     ldts = tonglaodongAll,
                                     nu = tonglaodongNuAll,
                                     tsgt = tongquandocAll + ppOrPgdAll + pqdcdVDonViAll + nvktVDonViAll + cvVDonViAll,
                                     qd = tongquandocAll,
                                     pppgd = ppOrPgdAll,
                                     pqdcd = pqdcdVDonViAll,
                                     nvkt = nvktVDonViAll,
                                     cv = cvVDonViAll,
                                     ts1 = ktVDonViAll + cdlVDonViAll + khacVDonViAll,
                                     kt = ktVDonViAll,
                                     cdl = cdlVDonViAll,
                                     khac = khacVDonViAll,
                                     ts2 = pvVDonViAll + ktVDonViAll + ptVDonViAll,
                                     pv = pvVDonViAll,
                                     ktv = ktVDonViAll,
                                     pt = ptVDonViAll,
                                     ghichu = "tong"

                                 };
                RecordTotalEmployee phanxuong =
                                 new RecordTotalEmployee
                                 {
                                     dv = "PHÂN XƯỞNG",
                                     ldts = tonglaodongPhanxuong,
                                     nu = tonglaodongNuPhanxuong,
                                     tsgt = tongquandocPhanxuong + ppOrPgdPhanxuong + pqdcdVDonViPhanxuong + nvktVDonViPhanxuong + cvVDonViPhanxuong,
                                     qd = tongquandocPhanxuong,
                                     pppgd = ppOrPgdPhanxuong,
                                     pqdcd = pqdcdVDonViPhanxuong,
                                     nvkt = nvktVDonViPhanxuong,
                                     cv = cvVDonViPhanxuong,
                                     ts1 = ktVDonViPhanxuong + cdlVDonViPhanxuong + khacVDonViPhanxuong,
                                     kt = ktVDonViPhanxuong,
                                     cdl = cdlVDonViPhanxuong,
                                     khac = khacVDonViPhanxuong,
                                     ts2 = pvVDonViPhanxuong + ktVDonViPhanxuong + ptVDonViPhanxuong,
                                     pv = pvVDonViPhanxuong,
                                     ktv = ktVDonViPhanxuong,
                                     pt = ptVDonViPhanxuong,
                                     ghichu = "phongban"

                                 };
                
                listAll.Add(donvi);
                listAll.Add(phanxuong);
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
               

                List<QuanHeGiaDinh> qhList = db.QuanHeGiaDinhs.ToList();
                for (int i = 0; i < giaDinh.Length; i++)
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
                    return Json(new { success = true, message = "Chưa nhập ngày chấm dứt" }, JsonRequestBehavior.AllowGet);

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