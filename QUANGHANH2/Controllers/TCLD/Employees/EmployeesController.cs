using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using OfficeOpenXml;
using QUANGHANH2.Models;
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
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.TCLD
{
    public class EmployeesController : Controller
    {
        //        // code's hoangnd18

        //        private class RecordTotalEmployee
        //        {
        //            public RecordTotalEmployee()
        //            {
        //            }

        //            public string dv { get; set; }
        //            public int ldts { get; set; }
        //            public int nu { get; set; }
        //            public int tsgt { get; set; }
        //            public int qd { get; set; }
        //            public int pppgd { get; set; }
        //            public int pqdcd { get; set; }
        //            public int nvkt { get; set; }
        //            public int cv { get; set; }
        //            public int ts1 { get; set; }
        //            public int kt { get; set; }
        //            public int cdl { get; set; }
        //            public int khac { get; set; }
        //            public int ts2 { get; set; }
        //            public int pv { get; set; }
        //            public int ktv { get; set; }
        //            public int pt { get; set; }
        //            public string ghichu { get; set; }
        //        }

        //        public ActionResult exportExcelToListEmployees()
        //        {
        //            List<RecordTotalEmployee> list = ListAllEmployees();

        //            string path = HostingEnvironment.MapPath("/excel/TCLD/TongHopNhanSu/Tổng-hợp-nhân-lực.xlsx");

        //            string saveAsPath = ("/excel/TCLD/download/Tổng-hợp-nhân-lực.xlsx");
        //            FileInfo file = new FileInfo(path);
        //            using (ExcelPackage excelPackage = new ExcelPackage(file))
        //            {
        //                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
        //                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
        //                int index = 3;
        //                foreach (var item in list)
        //                {
        //                    if (item.ghichu.Equals("tong") || item.ghichu.Equals("phongban"))
        //                    {
        //                        excelWorksheet.Cells[index, 1].Style.Font.Bold = true;

        //                    }

        //                    excelWorksheet.Cells[index, 1].Value = item.dv;
        //                    excelWorksheet.Cells[index, 2].Value = item.ldts;
        //                    excelWorksheet.Cells[index, 3].Value = item.nu;
        //                    excelWorksheet.Cells[index, 4].Value = item.tsgt;
        //                    excelWorksheet.Cells[index, 5].Value = item.qd;
        //                    excelWorksheet.Cells[index, 6].Value = item.pppgd;
        //                    excelWorksheet.Cells[index, 7].Value = item.pqdcd;
        //                    excelWorksheet.Cells[index, 8].Value = item.nvkt;
        //                    excelWorksheet.Cells[index, 9].Value = item.cv;
        //                    excelWorksheet.Cells[index, 10].Value = item.ts1;
        //                    excelWorksheet.Cells[index, 11].Value = item.kt;
        //                    excelWorksheet.Cells[index, 12].Value = item.cdl;
        //                    excelWorksheet.Cells[index, 13].Value = item.khac;
        //                    excelWorksheet.Cells[index, 14].Value = item.ts2;
        //                    excelWorksheet.Cells[index, 15].Value = item.pv;
        //                    excelWorksheet.Cells[index, 16].Value = item.ktv;
        //                    excelWorksheet.Cells[index, 17].Value = item.pt;
        //                    index++;
        //                }

        //                excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
        //                return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        //            }
        //        }

        //        [HttpPost]
        //        public ActionResult getDataTongNhanSu()
        //        {
        //            List<RecordTotalEmployee> list = ListAllEmployees();
        //            int totalrows = list.Count;
        //            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        //        }
        //        private List<RecordTotalEmployee> ListAllEmployees()
        //        {

        //            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //            {
        //                List<RecordTotalEmployee> listAll = new List<RecordTotalEmployee>();
        //                List<RecordTotalEmployee> listAllTemp = new List<RecordTotalEmployee>();
        //                var recordAll = (from p1 in db.NhanViens
        //                                 join p in db.Departments.DefaultIfEmpty() on p1.MaPhongBan equals p.department_id
        //                                 join p2 in db.CongViecs.DefaultIfEmpty() on p1.MaCongViec equals p2.MaCongViec
        //                                 join p3 in db.CongViec_NhomCongViec.DefaultIfEmpty() on p2.MaCongViec equals p3.MaCongViec
        //                                 join p4 in db.NhomCongViecs.DefaultIfEmpty() on p3.MaNhomCongViec equals p4.MaNhomCongViec
        //                                 join p5 in db.DienCongViecs.DefaultIfEmpty() on p4.MaDienCongViec equals p5.MaDienCongViec
        //                                 where p1.MaTrangThai == 1 & p.isInside != false
        //                                 select
        //                                 new
        //                                 {
        //                                     idCongViec = p2.MaCongViec,
        //                                     idDienCongViec = p5.MaDienCongViec,
        //                                     idNhomCongViec = p3.MaNhomCongViec,
        //                                     tenPhongBan = p.department_name,
        //                                     maPhongBan = p.department_id,
        //                                     tenDonVi = p.department_type,
        //                                     gioiTinh = p1.GioiTinh,
        //                                     maNv = p1.MaNV
        //                                 }).ToList();
        //                var listDonVi = (from p in db.Departments
        //                                 where p.isInside != false
        //                                 select new
        //                                 {
        //                                     tenPhongBan = p.department_name,
        //                                     maPhongBan = p.department_id,
        //                                     tenDonVi = p.department_type,

        //                                 }).ToList();

        //                foreach (var i in listDonVi.DistinctBy(x => x.tenDonVi).ToList())
        //                {
        //                    var listPhongBan = listDonVi.Where(x => x.tenDonVi == i.tenDonVi);
        //                    var count = listPhongBan.Count();
        //                    List<RecordTotalEmployee> listPhongBanAll = new List<RecordTotalEmployee>();
        //                    List<RecordTotalEmployee> listPhongBanTemp = new List<RecordTotalEmployee>();

        //                    foreach (var item in listPhongBan)
        //                    {

        //                        var tonglaodongphongban = recordAll.Where(x => x.maPhongBan == item.maPhongBan).Count();
        //                        var tonglaodongphongbanNu = recordAll.Where(x => x.gioiTinh == false & x.maPhongBan == item.maPhongBan).Count();
        //                        var quandocNumber = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 1).Count();
        //                        var ppOrPgd = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 2).Count();
        //                        var pqdcdV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 3).Count();
        //                        var nvktV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 4).Count();
        //                        var cvV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 5).Count();
        //                        var ktvV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 6).Count();
        //                        var cdlV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 7).Count();
        //                        //recordAll.Where(x => x.maPhongBan == i.maPhongBan ).Count();

        //                        var pvV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 8).Count();
        //                        //recordAll.Where(x => x.maPhongBan == i.maPhongBan).Count();
        //                        var ktV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 9).Count();
        //                        var ptV = recordAll.Where(x => x.maPhongBan == item.maPhongBan & x.idNhomCongViec == 10).Count();
        //                        var khacV = tonglaodongphongban - (quandocNumber + ppOrPgd + pqdcdV + nvktV + cvV + ktvV + cdlV + pvV + ktV + ptV);
        //                        //recordAll.Where(x => x.maPhongBan == i.maPhongBan).Count();
        //                        RecordTotalEmployee phongban = new RecordTotalEmployee
        //                        {
        //                            dv = item.tenPhongBan,
        //                            ldts = tonglaodongphongban,
        //                            nu = tonglaodongphongbanNu,
        //                            tsgt = quandocNumber + ppOrPgd + nvktV + cvV + pqdcdV,
        //                            qd = quandocNumber,
        //                            pppgd = ppOrPgd,
        //                            pqdcd = pqdcdV,
        //                            nvkt = nvktV,
        //                            cv = cvV,
        //                            ts1 = ktvV + cdlV + khacV,
        //                            kt = ktvV,
        //                            cdl = cdlV,
        //                            khac = khacV,
        //                            ts2 = pvV + ktvV + ptV,
        //                            pv = pvV,
        //                            ktv = ktvV,
        //                            pt = ptV,
        //                            ghichu = "donvi"
        //                        };
        //                        listPhongBanTemp.Add(phongban);
        //                    }

        //                    //first row donvi=>phong ban

        //                    var tonglaodongdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi).Count(); ;
        //                    var tonglaodongdonviNu = recordAll.Where(x => x.gioiTinh == false & x.tenDonVi == i.tenDonVi).Count();
        //                    var quandocNumberdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 1).Count();
        //                    var ppOrPgddonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 2).Count();
        //                    var pqdcdVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 3).Count(); ;
        //                    var nvktVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 4).Count();
        //                    var cvVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 5).Count();
        //                    var ktvVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 6).Count();
        //                    var cdlVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 7).Count();
        //                    var pvVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 8).Count();
        //                    var ktVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 9).Count();
        //                    var ptVdonvi = recordAll.Where(x => x.tenDonVi == i.tenDonVi & x.idNhomCongViec == 10).Count();
        //                    var khacVdonvi = tonglaodongdonvi - (quandocNumberdonvi + ppOrPgddonvi + pqdcdVdonvi + nvktVdonvi + cvVdonvi + ktvVdonvi + cdlVdonvi + pvVdonvi + ktVdonvi + ptVdonvi);

        //                    listPhongBanAll.Add(new RecordTotalEmployee
        //                    {
        //                        dv = i.tenDonVi.ToUpper(),
        //                        ldts = tonglaodongdonvi,
        //                        nu = tonglaodongdonviNu,
        //                        tsgt = quandocNumberdonvi + ppOrPgddonvi + nvktVdonvi + cvVdonvi + pqdcdVdonvi,
        //                        qd = quandocNumberdonvi,
        //                        pppgd = ppOrPgddonvi,
        //                        pqdcd = pqdcdVdonvi,
        //                        nvkt = nvktVdonvi,
        //                        cv = cvVdonvi,
        //                        ts1 = ktvVdonvi + cdlVdonvi + khacVdonvi,
        //                        kt = ktvVdonvi,
        //                        cdl = cdlVdonvi,
        //                        khac = khacVdonvi,
        //                        ts2 = pvVdonvi + ktVdonvi + ptVdonvi,
        //                        pv = pvVdonvi,
        //                        ktv = ktVdonvi,
        //                        pt = ptVdonvi,
        //                        ghichu = "phongban"
        //                    });
        //                    listPhongBanAll.AddRange(listPhongBanTemp);



        //                    listAllTemp.AddRange(listPhongBanAll);
        //                }

        //                //total Tong

        //                var tonglaodongAll = recordAll.Count();
        //                var tonglaodongAllNu = recordAll.Where(x => x.gioiTinh == false).Count();
        //                var quandocNumberAll = recordAll.Where(x => x.idNhomCongViec == 1).Count();
        //                var ppOrPgdAll = recordAll.Where(x => x.idNhomCongViec == 2).Count();
        //                var pqdcdVAll = recordAll.Where(x => x.idNhomCongViec == 3).Count(); ;
        //                var nvktVAll = recordAll.Where(x => x.idNhomCongViec == 4).Count();
        //                var cvVAll = recordAll.Where(x => x.idNhomCongViec == 5).Count();
        //                var ktvVAll = recordAll.Where(x => x.idNhomCongViec == 6).Count();
        //                var cdlVAll = recordAll.Where(x => x.idNhomCongViec == 7).Count();
        //                var pvVAll = recordAll.Where(x => x.idNhomCongViec == 8).Count();
        //                var ktVAll = recordAll.Where(x => x.idNhomCongViec == 9).Count();
        //                var ptVAll = recordAll.Where(x => x.idNhomCongViec == 10).Count();
        //                var khacVAll = tonglaodongAll - (quandocNumberAll + ppOrPgdAll + pqdcdVAll + nvktVAll + cvVAll + ktvVAll + cdlVAll + pvVAll + ktVAll + ptVAll);
        //                listAll.Add(new RecordTotalEmployee
        //                {
        //                    dv = "Tổng ",
        //                    ldts = tonglaodongAll,
        //                    nu = tonglaodongAllNu,
        //                    tsgt = quandocNumberAll + ppOrPgdAll + nvktVAll + cvVAll + pqdcdVAll,
        //                    qd = quandocNumberAll,
        //                    pppgd = ppOrPgdAll,
        //                    pqdcd = pqdcdVAll,
        //                    nvkt = nvktVAll,
        //                    cv = cvVAll,
        //                    ts1 = ktvVAll + cdlVAll + khacVAll,
        //                    kt = ktvVAll,
        //                    cdl = cdlVAll,
        //                    khac = khacVAll,
        //                    ts2 = pvVAll + ktVAll + ptVAll,
        //                    pv = pvVAll,
        //                    ktv = ktVAll,
        //                    pt = ptVAll,
        //                    ghichu = "tong"
        //                });










        //                //total phan xuong 

        //                var tonglaodongphanxuong = recordAll.Where(x => x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ").Count(); ;
        //                var tonglaodongphanxuongNu = recordAll.Where(x => x.gioiTinh == false & (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ")).Count();
        //                var quandocNumberphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 1).Count();
        //                var ppOrPgdphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 2).Count();
        //                var pqdcdVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 3).Count(); ;
        //                var nvktVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 4).Count();
        //                var cvVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 5).Count();
        //                var ktvVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 6).Count();
        //                var cdlVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 7).Count();
        //                var pvVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 8).Count();
        //                var ktVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 9).Count();
        //                var ptVphanxuong = recordAll.Where(x => (x.tenDonVi == "Phân xưởng sản xuất chính" | x.tenDonVi == "Phân xưởng thuộc về phục vụ") & x.idNhomCongViec == 10).Count();
        //                var khacVphanxuong = tonglaodongphanxuong - (quandocNumberphanxuong + ppOrPgdphanxuong + pqdcdVphanxuong + nvktVphanxuong + cvVphanxuong + ktvVphanxuong + cdlVphanxuong + pvVphanxuong + ktVphanxuong + ptVphanxuong);
        //                listAll.Add(new RecordTotalEmployee
        //                {
        //                    dv = "PHÂN XƯỞNG",
        //                    ldts = tonglaodongphanxuong,
        //                    nu = tonglaodongphanxuongNu,
        //                    tsgt = quandocNumberphanxuong + pqdcdVphanxuong + nvktVphanxuong + cvVphanxuong + ppOrPgdphanxuong,
        //                    qd = quandocNumberphanxuong,
        //                    pppgd = ppOrPgdphanxuong,
        //                    pqdcd = pqdcdVphanxuong,
        //                    nvkt = nvktVphanxuong,
        //                    cv = cvVphanxuong,
        //                    ts1 = ktvVphanxuong + cdlVphanxuong + khacVphanxuong,
        //                    kt = ktvVphanxuong,
        //                    cdl = cdlVphanxuong,
        //                    khac = khacVphanxuong,
        //                    ts2 = pvVphanxuong + ktVphanxuong + ptVphanxuong,
        //                    pv = pvVphanxuong,
        //                    ktv = ktVphanxuong,
        //                    pt = ptVphanxuong,
        //                    ghichu = "phongban"
        //                });
        //                listAll.AddRange(listAllTemp);

        //                return listAll;
        //            }
        //        }





        //        // endline hoangnd18



        //        // GET: Employees
        //        [Route("phong-tcld/danh-sach-toan-cong-ty")]
        //        public ActionResult ListAll()
        //        {
        //            ViewBag.nameDepartment = "baohiem";
        //            return View("/Views/TCLD/Brief/ListAll.cshtml");
        //        }
        public class BacLuong_ThangLuong_MucLuong_Extend : Salary
        {
            public String MucBacLuong { get; set; }
            public String MucThangLuong { get; set; }
        }
        [Auther(RightID = "56")]
        [Route("phong-tcld/quan-ly-nhan-vien/xem-chi-tiet-nhan-vien")]
        [HttpGet]
        public ActionResult ViewInfor(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<SelectListItem> salary_level = new List<SelectListItem>();
                String query_salary_level = @"select a.*, b.pay_rate, c.pay_table from HumanResources.Salary a 
                                            join HumanResources.PayRate b on a.pay_rate_id = b.pay_rate_id 
                                            join HumanResources.PayTable c on a.pay_table_id = c.pay_table_id";
                List<BacLuong_ThangLuong_MucLuong_Extend> list_level_salary = new List<BacLuong_ThangLuong_MucLuong_Extend>();
                list_level_salary = db.Database.SqlQuery<BacLuong_ThangLuong_MucLuong_Extend>(query_salary_level).ToList();
                foreach (BacLuong_ThangLuong_MucLuong_Extend i in list_level_salary)
                {
                    salary_level.Add(new SelectListItem
                    {
                        Text = i.MucBacLuong + " - " + i.MucThangLuong + " - " + i.salary_number,
                        Value = i.salary_id.ToString()
                    });
                    if (db.Employees.Where(x => x.employee_id == id).FirstOrDefault<Employee>().current_salary_id == i.salary_id)
                    {

                        ViewBag.load_salary_level = i.MucBacLuong + " - " + i.MucThangLuong + " - " + i.salary_number;

                    }
                }

                ViewBag.level_salary = salary_level;

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

                List<Qualification> Leveldb = db.Qualifications.ToList<Qualification>();
                List<SelectListItem> Level = new List<SelectListItem>();

                foreach (Qualification td in Leveldb)
                {
                    Level.Add(new SelectListItem { Text = td.name.Trim(), Value = td.name.ToString() });
                }

                ViewBag.level = Level;
                List<Work> Jobdb = db.Works.ToList<Work>();

                List<SelectListItem> Job = new List<SelectListItem>();

                foreach (Work cv in Jobdb)
                {
                    Job.Add(new SelectListItem { Text = cv.name.Trim(), Value = cv.work_id.ToString() });
                    if (db.Employees.Where(x => x.employee_id == id).FirstOrDefault<Employee>().current_work_id == cv.work_id)
                    {
                        ViewBag.loadJob = cv.name.Trim();
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
                Family qh = new Family();
                List<Family> qhList = db.Families.Where(x => x.employee_id == id).ToList();
                ViewBag.qhList = qhList;
                WorkingProcess qt = new WorkingProcess();
                List<WorkingProcess> qtList = db.WorkingProcesses.Where(x => x.employee_id == id).ToList();
                ViewBag.qtList = qtList;
                return View("/Views/TCLD/Brief/View.cshtml", db.Employees.Where(x => x.employee_id == id).FirstOrDefault<Employee>());
            }
        }


        [Auther(RightID = "53")]
        [Route("phong-tcld/quan-ly-nhan-vien/chinh-sua-nhan-vien")]
        [HttpGet]
        public ActionResult LoadEdit(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<SelectListItem> salary_level = new List<SelectListItem>();
                String query_salary_level = @"select a.*, b.pay_rate, c.pay_table from HumanResources.Salary a 
                                            join HumanResources.PayRate b on a.pay_rate_id = b.pay_rate_id 
                                            join HumanResources.PayTable c on a.pay_table_id = c.pay_table_id";
                List<BacLuong_ThangLuong_MucLuong_Extend> list_level_salary = new List<BacLuong_ThangLuong_MucLuong_Extend>();
                list_level_salary = db.Database.SqlQuery<BacLuong_ThangLuong_MucLuong_Extend>(query_salary_level).ToList();
                foreach (BacLuong_ThangLuong_MucLuong_Extend i in list_level_salary)
                {
                    salary_level.Add(new SelectListItem
                    {
                        Text = i.MucBacLuong + " - " + i.MucThangLuong + " - " + i.salary_number,
                        Value = i.salary_id.ToString()
                    });
                    if (db.Employees.Where(x => x.employee_id == id).FirstOrDefault<Employee>().current_salary_id == i.salary_id)
                    {
                        ViewBag.load_salary_level = i.MucBacLuong + " - " + i.MucThangLuong + " - " + i.salary_number;
                    }
                }
                ViewBag.level_salary = salary_level;

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

                List<Qualification> Leveldb = db.Qualifications.ToList<Qualification>();
                List<SelectListItem> Level = new List<SelectListItem>();

                foreach (Qualification td in Leveldb)
                {
                    Level.Add(new SelectListItem { Text = td.name.Trim(), Value = td.qualification_id.ToString() });
                }

                ViewBag.level = Level;
                List<Work> Jobdb = db.Works.ToList<Work>();

                List<SelectListItem> Job = new List<SelectListItem>();

                foreach (Work cv in Jobdb)
                {
                    Job.Add(new SelectListItem { Text = cv.name.Trim(), Value = cv.work_id.ToString() });
                    if (db.Employees.Where(x => x.employee_id == id).FirstOrDefault<Employee>().current_work_id == cv.work_id)
                    {
                        ViewBag.loadJob = cv.name.Trim();
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

                Family qh = new Family();
                List<Family> qhList = db.Families.Where(x => x.employee_id == id).ToList();
                ViewBag.qhList = qhList;
                List<FamilyType> familyTypes = db.FamilyTypes.ToList();
                ViewBag.familyTypes = familyTypes;
                List<FamilyRelationship> familyRelationships = db.FamilyRelationships.ToList();
                ViewBag.familyRelationships = familyRelationships;
                WorkingProcess qt = new WorkingProcess();
                List<WorkingProcess> qtList = db.WorkingProcesses.Where(x => x.employee_id == id).ToList();
                ViewBag.qtList = qtList;
                return View("/Views/TCLD/Brief/Edit.cshtml", db.Employees.Where(x => x.employee_id == id).FirstOrDefault<Employee>());
            }
        }
        [Auther(RightID = "53")]
        [HttpPost]
        public ActionResult SaveEdit(Employee emp, string test, string hiddenSalary, string[] giaDinh, string[] ngaySinhGiaDinh, string[] hoTen, string[] moiQuanHe, string[] lyLich, string[] donVi, string[] chucDanh, string[] chucVu, string[] tuNgayDenNgay)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    List<Work> Jobdb = db.Works.ToList<Work>();
                    foreach (Work cv in Jobdb)
                    {
                        if (test.Trim().Equals(cv.name.Trim()))
                        {
                            emp.current_work_id = cv.work_id;
                            break;
                        }
                    }

                    if (giaDinh != null)
                    {
                        for (int i = 0; i < giaDinh.Length; i++)
                        {
                            if (giaDinh[i].Equals("") || moiQuanHe[i].Equals(""))
                            {
                                continue;
                            }
                            Family family = new Family();
                            family.full_name = hoTen[i];
                            if (ngaySinhGiaDinh[i] != "")
                            {
                                family.date_of_birth = DateTime.ParseExact(ngaySinhGiaDinh[i], "dd/MM/yyyy", null);

                            }
                            else
                            {
                                family.date_of_birth = null;
                            }
                            family.background = lyLich[i];
                            family.family_relationship_id = Int32.Parse(moiQuanHe[i]);
                            family.family_type_id = Int32.Parse(giaDinh[i]);
                            family.employee_id = emp.employee_id;
                            db.Families.Add(family);


                        }
                        db.SaveChanges();

                    }

                    if (donVi != null)
                    {
                        List<WorkingProcess> list = db.WorkingProcesses.ToList();
                        for (int i = 0; i < donVi.Length; i++)
                        {
                            if (!donVi[i].Equals(""))
                            {
                                string[] ngay = tuNgayDenNgay[i].Split('-');
                                string DonViCongTacX = donVi[i];
                                string[] ngayFix = ngay[0].Trim().Split('/');
                                List<WorkingProcess> ct = db.WorkingProcesses.Where(qtct => (qtct.employee_id.Equals(emp.employee_id)) && (qtct.office.Equals(DonViCongTacX))).ToList();
                                if (ct.Count == 0)
                                {
                                    WorkingProcess qtct = new WorkingProcess();
                                    qtct.employee_id = emp.employee_id;
                                    qtct.office = donVi[i];
                                    if (ngay[0] != "" && ngay[1] != "")
                                    {
                                        string[] dateStart = ngay[0].Split('/');
                                        qtct.date_start = Convert.ToDateTime(dateStart[1] + "/" + dateStart[0] + "/" + dateStart[2]);
                                        string[] dateEnd = ngay[1].Split('/');
                                        qtct.date_end = Convert.ToDateTime(dateEnd[1] + "/" + dateEnd[0] + "/" + dateEnd[2]);
                                    }
                                    qtct.position = chucVu[i];
                                    qtct.title = chucDanh[i];
                                    db.WorkingProcesses.Add(qtct);
                                }
                                else
                                {
                                    WorkingProcess qtct = new WorkingProcess();
                                    qtct.employee_id = emp.employee_id;
                                    qtct.office = donVi[i];

                                    var quaTrinh = db.WorkingProcesses.Where(congTac => (congTac.employee_id.Equals(emp.employee_id)) && (congTac.office.Equals(DonViCongTacX))).FirstOrDefault();
                                    if (ngay[0] != "" && ngay[1] != "")
                                    {
                                        string[] dateStart = ngay[0].Split('/');
                                        quaTrinh.date_start = Convert.ToDateTime(dateStart[1] + "/" + dateStart[0] + "/" + dateStart[2]);
                                        string[] dateEnd = ngay[1].Split('/');
                                        quaTrinh.date_end = Convert.ToDateTime(dateEnd[1] + "/" + dateEnd[0] + "/" + dateEnd[2]);
                                    }
                                    quaTrinh.position = chucVu[i];
                                    quaTrinh.title = chucDanh[i];
                                    db.Entry(quaTrinh).State = EntityState.Modified;
                                }
                            }
                        }
                        db.SaveChanges();

                    }
                }
                catch (Exception e)
                {
                    dbct.Rollback();
                }
                if (hiddenSalary != "")
                {
                    emp.current_salary_id = Convert.ToInt32(hiddenSalary);
                }
                else
                {
                    emp.current_salary_id = null;
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
            string sql = @"select * from General.Department";
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<Department> pb = db.Database.SqlQuery<Department>(sql).ToList();
            ViewBag.pb = pb;
            return View("/Views/TCLD/Brief/List.cshtml");
        }

        public class NhanVienLink : Employee
        {
            public string StatusName { get; set; }
            public string TenTrinhDo { get; set; }
            public string TenCongViec { get; set; }
        }
        [Auther(RightID = "51")]
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien")]
        [HttpPost]
        public ActionResult Search(string MaNV, string TenNV, string Gender, string pb)
        {
            try
            {
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                db.Configuration.LazyLoadingEnabled = false;
                string query_list = @"TCLD_get_list_employees @MaNV = @MaNV, @Ten = @Ten, @GioiTinh = @GioiTinh, @pb = @pb,
                               @order_column = @order_column, @sort = @sort, @start = @start, @length = @length";
                List<TCLD_get_list_employees_Result> employees = db.Database.SqlQuery<TCLD_get_list_employees_Result>(query_list,    
                    new SqlParameter("MaNV", MaNV),
                    new SqlParameter("Ten",  TenNV ),
                    new SqlParameter("GioiTinh", Gender),
                    new SqlParameter("pb", pb),
                    new SqlParameter("order_column", sortColumnName),
                    new SqlParameter("sort", sortDirection),
                    new SqlParameter("start", start),
                    new SqlParameter("length", length)
                    ).ToList();

                string query_count = @"TCLD_get_count_employees @MaNV = @MaNV, @Ten = @Ten, @GioiTinh = @GioiTinh, @pb = @pb";
                TCLD_get_count_employees_Result totalrows = db.Database.SqlQuery<TCLD_get_count_employees_Result>(query_count,
                    new SqlParameter("MaNV", MaNV),
                    new SqlParameter("Ten", TenNV),
                    new SqlParameter("GioiTinh", Gender),
                    new SqlParameter("pb", pb)).FirstOrDefault();

                return Json(new { data = employees, draw = Request["draw"], recordsTotal = totalrows.count, recordsFiltered = totalrows.count }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(404);

            }
        }


        //        //[Route("phong-tcld/quan-ly-nhan-vien/lich-su-lam-viec")]
        //        //public ActionResult WorkHistory()
        //        //{
        //        //    ViewBag.nameDepartment = "baohiem";
        //        //    return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        //        //}
        //        public class ChamDutModel
        //        {
        //            public string MaNV { get; set; }
        //            public string LoaiChamDut { get; set; }
        //            public string NgayChamDut { get; set; }
        //            public string SoQD { get; set; }
        //        }

        //        [Auther(RightID = "55")]
        //        [Route("delete")]
        //        [HttpPost]
        //        public ActionResult TLHD(string selectedList)
        //        {
        //            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
        //            using (DbContextTransaction dbct = db.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    QuyetDinh qd = new QuyetDinh();
        //                    var js = new JavaScriptSerializer();
        //                    var result = JsonConvert.DeserializeObject<List<ChamDutModel>>(selectedList);
        //                    string[] date = result[0].NgayChamDut.Split('/');
        //                    var emp = new NhanVien();
        //                    if (result[0].SoQD.Equals(""))
        //                    {
        //                        qd.SoQuyetDinh = "";
        //                        foreach (var item in result)
        //                        {
        //                            emp = db.NhanViens.Where(x => x.MaNV == item.MaNV).FirstOrDefault();
        //                            emp.MaTrangThai = 4;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        qd.SoQuyetDinh = result[0].SoQD;
        //                        foreach (var item in result)
        //                        {
        //                            emp = db.NhanViens.Where(x => x.MaNV == item.MaNV).FirstOrDefault();
        //                            emp.MaTrangThai = 2;
        //                        }
        //                    }
        //                    qd.NgayQuyetDinh = DateTime.Parse(date[2] + "/" + date[1] + "/" + date[0]);
        //                    db.Entry(emp).State = EntityState.Modified;
        //                    db.QuyetDinhs.Add(qd);
        //                    db.SaveChanges();

        //                    int maqd = db.QuyetDinhs.Select(n => n.MaQuyetDinh).DefaultIfEmpty(0).Max();
        //                    foreach (var item in result)
        //                    {
        //                        ChamDut_NhanVien tlhd = new ChamDut_NhanVien();
        //                        tlhd.MaNV = item.MaNV;
        //                        tlhd.MaQuyetDinh = maqd;
        //                        tlhd.NgayChamDut = DateTime.Parse(date[2] + "/" + date[1] + "/" + date[0]);
        //                        tlhd.LoaiChamDut = item.LoaiChamDut;
        //                        db.ChamDut_NhanVien.Add(tlhd);

        //                    }
        //                    db.SaveChanges();
        //                    dbct.Commit();
        //                    return Json(new { success = true, message = "Tạo quyết định thành công" }, JsonRequestBehavior.AllowGet);

        //                }
        //                catch (Exception e)
        //                {
        //                    dbct.Rollback();
        //                    return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);

        //                }



        //            }

        //        }


        //        [Route("deleteFamily")]
        //        [HttpPost]
        //        public JsonResult DeleteFamily(string maQH, string id)
        //        {
        //            List<QuanHeGiaDinh> list = new List<QuanHeGiaDinh>();
        //            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //            {
        //                using (DbContextTransaction transaction = db.Database.BeginTransaction())
        //                {
        //                    try
        //                    {
        //                        string query = "delete from QuanHeGiaDinh where MaQuanHeGiaDinh = @maQH";
        //                        db.Database.ExecuteSqlCommand(query, new SqlParameter("maQH", maQH));
        //                        string query2 = "select * from QuanHeGiaDinh where MaNV = @id";
        //                        list = db.Database.SqlQuery<QuanHeGiaDinh>(query2, new SqlParameter("id", id)).ToList();
        //                        transaction.Commit();
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        transaction.Rollback();
        //                        return Json(new { success = false, message = "Lỗi!" + e.Message }, JsonRequestBehavior.AllowGet);
        //                    }
        //                }

        //                return Json(new { success = true, listQH = list }, JsonRequestBehavior.AllowGet);
        //            }
        //        }

        //        [Route("deleteWork")]
        //        [HttpPost]
        //        public JsonResult DeleteWork(string maCT, string id)
        //        {
        //            List<QuaTrinhCongTac> list = new List<QuaTrinhCongTac>();
        //            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //            {
        //                using (DbContextTransaction transaction = db.Database.BeginTransaction())
        //                {
        //                    try
        //                    {
        //                        string query = "delete from QuaTrinhCongTac where MaCongTac = @maCT";
        //                        db.Database.ExecuteSqlCommand(query, new SqlParameter("maCT", maCT));
        //                        string query2 = "select * from QuaTrinhCongTac where MaNV = @id";
        //                        list = db.Database.SqlQuery<QuaTrinhCongTac>(query2, new SqlParameter("id", id)).ToList();
        //                        transaction.Commit();
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        transaction.Rollback();
        //                        return Json(new { success = false, message = "Lỗi!" + e.Message }, JsonRequestBehavior.AllowGet);
        //                    }
        //                }

        //                return Json(new { success = true, listCT = list }, JsonRequestBehavior.AllowGet);
        //            }
        //        }

        //        public class NhanVienExcel : NhanVien
        //        {
        //            public string TenTrinhDo { get; set; }
        //            public string TenChuyenNganh { get; set; }
        //            public string TenCongViec { get; set; }
        //            public string MucThangLuong { get; set; }
        //            public string MucBacLuong { get; set; }
        //            public string MucLuongNhanVien { get; set; }
        //        }
        //        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien/excel")]
        //        [HttpPost]
        //        public void ReturnExcel()
        //        {
        //            string path = HostingEnvironment.MapPath("/excel/TCLD/Brief/Danh-sách-nhân-viên.xlsx");
        //            FileInfo file = new FileInfo(path);
        //            using (ExcelPackage excelPackage = new ExcelPackage(file))
        //            {
        //                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
        //                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
        //                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //                {
        //                    string searchMaNV = Request["MaNV"];
        //                    string searchTenNV = Request["TenNV"];
        //                    string searchGioiTinh = Request["GioiTinh"];
        //                    string searchMaPhongBan = Request["MaPhongBan"];

        //                    string query = @"select nv.*, cv.TenCongViec, 
        //                                    tl.MucThangLuong as 'MucThangLuong',
        //                                    bl.MucBacLuong as 'MucBacLuong',
        //                                    bl_tl_ml.MucLuong as 'MucLuongNhanVien'
        //                                    from NhanVien nv
        //                                    left outer join CongViec cv on nv.MaCongViec = cv.MaCongViec
        //                                    left outer join BacLuong_ThangLuong_MucLuong bl_tl_ml on nv.MaBacLuong_ThangLuong_MucLuong = bl_tl_ml.MaBacLuong_ThangLuong_MucLuong
        //                                    left outer join BacLuong bl on bl.MaBacLuong = bl_tl_ml.MaBacLuong
        //                                    left outer join ThangLuong tl on tl.MaThangLuong = bl_tl_ml.MaThangLuong";
        //                    if (searchMaNV != "" || searchTenNV != "" || searchGioiTinh != "" || searchMaPhongBan != "")
        //                    {
        //                        query += " where";
        //                        if (searchMaNV != "") query += " nv.MaNV like @searchMaNV and";
        //                        if (searchTenNV != "") query += " nv.Ten like @searchTenNV and";
        //                        if (searchGioiTinh != "")
        //                        {
        //                            searchGioiTinh = searchGioiTinh == "true" ? "1" : "0";
        //                            query += " nv.GioiTinh = @searchGioiTinh and";
        //                        }
        //                        if (searchMaPhongBan != "") query += " nv.MaPhongBan = @searchMaPhongBan and";
        //                        query = query.Substring(0, query.Length - 4);
        //                    }
        //                    List<NhanVienExcel> list = db.Database.SqlQuery<NhanVienExcel>(query, new SqlParameter("searchMaNV", searchMaNV),
        //                                                                                            new SqlParameter("searchTenNV", searchTenNV),
        //                                                                                            new SqlParameter("searchGioiTinh", searchGioiTinh),
        //                                                                                            new SqlParameter("searchMaPhongBan", searchMaPhongBan)).ToList();
        //                    int k = 4;
        //                    for (int i = 0; i < list.Count; i++)
        //                    {
        //                        excelWorksheet.Cells[k, 1].Value = i + 1;
        //                        excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).MaNV;
        //                        excelWorksheet.Cells[k, 3].Value = list.ElementAt(i).Ten;
        //                        if (list.ElementAt(i).GioiTinh)
        //                        {
        //                            excelWorksheet.Cells[k, 4].Value = "Nam";
        //                        }
        //                        else
        //                        {
        //                            excelWorksheet.Cells[k, 4].Value = "Nữ";
        //                        }
        //                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).NgaySinh.HasValue ? list.ElementAt(i).NgaySinh.Value.ToString("dd/MM/yyyy") : "";
        //                        excelWorksheet.Cells[k, 6].Value = list.ElementAt(i).SoCMND;
        //                        excelWorksheet.Cells[k, 7].Value = list.ElementAt(i).SoBHXH;
        //                        excelWorksheet.Cells[k, 13].Value = list.ElementAt(i).MaPhongBan;
        //                        excelWorksheet.Cells[k, 14].Value = list.ElementAt(i).TenCongViec;
        //                        excelWorksheet.Cells[k, 15].Value = list.ElementAt(i).MucLuongNhanVien;
        //                        excelWorksheet.Cells[k, 16].Value = list.ElementAt(i).MucThangLuong;
        //                        excelWorksheet.Cells[k, 17].Value = list.ElementAt(i).MucBacLuong;
        //                        if (list.ElementAt(i).MaTrinhDo != null)
        //                        {
        //                            if (list.ElementAt(i).MaTrinhDo.Equals("1"))
        //                            {
        //                                excelWorksheet.Cells[k, 20].Value = "Tiểu học";
        //                            }
        //                            else if (list.ElementAt(i).MaTrinhDo.Equals("2"))
        //                            {
        //                                excelWorksheet.Cells[k, 20].Value = "THCS";
        //                            }
        //                            else if (list.ElementAt(i).MaTrinhDo.Equals("3"))
        //                            {
        //                                excelWorksheet.Cells[k, 20].Value = "THPT";
        //                            }
        //                            else if (list.ElementAt(i).MaTrinhDo.Equals("4"))
        //                            {
        //                                excelWorksheet.Cells[k, 20].Value = "Trung cấp";
        //                            }
        //                            else
        //                            {
        //                                excelWorksheet.Cells[k, 20].Value = "Đại học";
        //                            }
        //                        }
        //                        excelWorksheet.Cells[k, 22].Value = list.ElementAt(i).QueQuan;
        //                        k++;
        //                    }
        //                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/download/Danh-sách-nhân-viên.xlsx")));
        //                }
        //            }

        //        }
    }
}