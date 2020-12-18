using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using OfficeOpenXml;
using QUANGHANH2.EntityResult;
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
using static QUANGHANH2.Controllers.TCLD.ShutDownController;

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
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    if (id == null)
                    {
                        id = "";
                    }
                    List<SelectListItem> salary_level = new List<SelectListItem>();
                    string query_salary_level = "[HumanResources].GetSalaryLevel";
                    string type = "view";
                    List<GetSalaryLevel_Result> list_level_salary =
                        db.Database.SqlQuery<GetSalaryLevel_Result>(query_salary_level).ToList();
                    Array id_type = id.Split('_');
                    if (id_type.Length == 2)
                    {
                        id = id_type.GetValue(0) + "";
                        type = id_type.GetValue(1) + "";
                    }
                    GetListEmployees_Result employee = db.Database.SqlQuery<GetListEmployees_Result>
                        ("HumanResources.[GetAnEmployee] {0}", id).FirstOrDefault();
                    foreach (GetSalaryLevel_Result i in list_level_salary)
                    {
                        salary_level.Add(new SelectListItem
                        {
                            Text = i.rate_table_level,
                            Value = i.salary_id.ToString()
                        });
                        if (employee == null)
                        {
                            return List();
                        }
                    }
                    ViewBag.load_salary_level = employee.rate_table_level;
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
                    List<Work> Jobdb = db.Works.ToList();
                    List<SelectListItem> Job = new List<SelectListItem>();

                    foreach (Work cv in Jobdb)
                    {
                        Job.Add(new SelectListItem { Text = cv.name.Trim(), Value = cv.work_id.ToString() });
                        if (db.Employees.Where(x => x.employee_id == id).FirstOrDefault().current_work_id == cv.work_id)
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

                    string family_query = "[HumanResources].GetFamiliesOfAnEmployee {0}";
                    List<GetFamiliesOfAnEmployee_Result> qhList = db.Database.SqlQuery<GetFamiliesOfAnEmployee_Result>(family_query, id).ToList();
                    ViewBag.qhList = qhList;
                    List<FamilyType> familyTypes = db.FamilyTypes.ToList();
                    ViewBag.familyTypes = familyTypes;
                    List<FamilyRelationship> familyRelationships = db.FamilyRelationships.ToList();
                    ViewBag.familyRelationships = familyRelationships;
                    WorkingProcess qt = new WorkingProcess();
                    List<WorkingProcess> qtList = db.WorkingProcesses.Where(x => x.employee_id == id).ToList();
                    ViewBag.qtList = qtList;
                    if (type.Equals("edit"))
                    {
                        return View("/Views/TCLD/Brief/Edit.cshtml", employee);
                    }
                    else if (type.Equals("view"))
                    {
                        return View("/Views/TCLD/Brief/View.cshtml", employee);
                    }
                    else
                    {
                        return List();
                    }
                }
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(404);
            }

        }



        [Auther(RightID = "53")]
        [HttpPost]
        public ActionResult SaveEdit(Employee emp, string position, string hiddenSalary, string[] giaDinh,
            string[] ngaySinhGiaDinh, string[] hoTen, string[] moiQuanHe, string[] lyLich, string[] donVi,
            string[] chucDanh, string[] chucVu, string[] tuNgayDenNgay)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    List<Work> Jobdb = db.Works.ToList<Work>();
                    foreach (Work cv in Jobdb)
                    {
                        if (position.Trim().Equals(cv.name.Trim()))
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
                string query_list = @"HumanResources.GetListEmployees {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}";
                List<GetListEmployees_Result> employees = db.Database.SqlQuery<GetListEmployees_Result>(query_list,
                    MaNV, TenNV, Gender, pb, sortColumnName, sortDirection, start, length).ToList();
                Session["excel"] = db.Database.SqlQuery<GetListEmployees_Result>(query_list,
                    MaNV, TenNV, Gender, pb, sortColumnName, sortDirection, start, 2147483647).ToList();
                string query_count = @"HumanResources.GetCountEmployees {0}, {1}, {2}, {3}";
                GetCountEmployees_Result get_count_employees = db.Database.SqlQuery<GetCountEmployees_Result>(query_count,
                     MaNV, TenNV, Gender, pb).FirstOrDefault();
                int? totalrows = 0;
                if (get_count_employees != null)
                {
                    totalrows = get_count_employees.count;
                }
                return Json(new { data = employees, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { data = "", draw = Request["draw"], recordsTotal = 0, recordsFiltered = 0 }, JsonRequestBehavior.AllowGet);

            }
        }



        //        public class ChamDutModel
        //        {
        //            public string MaNV { get; set; }
        //            public string LoaiChamDut { get; set; }
        //            public string NgayChamDut { get; set; }
        //            public string SoQD { get; set; }
        //        }

        [Auther(RightID = "55")]
        [Route("delete")]
        [HttpPost]
        public ActionResult TLHD(string selectedList)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    Decision qd = new Decision();
                    var js = new JavaScriptSerializer();
                    var result = JsonConvert.DeserializeObject<List<GetListEmployees_Result>>(selectedList);
                    //string[] date = result[0].terminate_date.Split('/');
                    var emp = new Employee();
                    if (result[0].decision_number.Equals(""))
                    {
                        qd.decision_id = 0;
                        foreach (var item in result)
                        {
                            emp = db.Employees.Where(x => x.employee_id == item.employee_id).FirstOrDefault();
                            emp.current_status_id = 4;
                        }
                    }
                    else
                    {
                        qd.decision_id = Convert.ToInt32(result[0].decision_number);
                        foreach (var item in result)
                        {
                            emp = db.Employees.Where(x => x.employee_id == item.employee_id).FirstOrDefault();
                            emp.current_status_id = 2;
                        }
                    }
                    qd.date = DateTime.ParseExact(result[0].terminate_date + "","dd/MM/yyyy", null);
                    db.Entry(emp).State = EntityState.Modified;
                    db.Decisions.Add(qd);
                    db.SaveChanges();

                    int maqd = db.Decisions.Select(n => n.decision_id).DefaultIfEmpty(0).Max();
                    foreach (var item in result)
                    {
                        Termination tlhd = new Termination();
                        tlhd.employee_id = item.employee_id;
                        tlhd.decision_id = maqd;
                        tlhd.terminate_date = DateTime.ParseExact(result[0].terminate_date + "", "dd/MM/yyyy", null);
                        tlhd.termination_type_id = item.termination_type_id;
                        db.Terminations.Add(tlhd);

                    }
                    db.SaveChanges();
                    dbct.Commit();
                    return Json(new { success = true, message = "Tạo quyết định thành công" }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    dbct.Rollback();
                    return Json(new { success = false, message = "Lỗi" }, JsonRequestBehavior.AllowGet);

                }



            }

        }


        [Route("deleteFamily")]
        [HttpPost]
        public JsonResult DeleteFamily(string family_type, string id, string family_relation)
        {
            List<GetFamiliesOfAnEmployee_Result> qhList = new List<GetFamiliesOfAnEmployee_Result>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string query = @"delete from [HumanResources].Family where 
                                        employee_id = {0} and 
                                        family_relationship_id = {1} and 
                                        family_type_id = {2}
                                        exec [HumanResources].GetFamiliesOfAnEmployee {3}";
                        qhList = db.Database.SqlQuery<GetFamiliesOfAnEmployee_Result>
                            (query, id, family_relation, family_type, id).ToList();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Lỗi!" + e.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { success = true, listQH = qhList }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("deleteWork")]
        [HttpPost]
        public JsonResult DeleteWork(string maCT, string id)
        {
            List<WorkingProcess> list = new List<WorkingProcess>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string query = @"delete from [HumanResources].WorkingProcess where working_process_id = {0}
                                         select * from [HumanResources].WorkingProcess where employee_id = {1}";
                        list = db.Database.SqlQuery<WorkingProcess>(query, maCT, id).ToList();
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

        public class NhanVienExcel : Employee
        {
            public string TenTrinhDo { get; set; }
            public string TenChuyenNganh { get; set; }
            public string TenCongViec { get; set; }
            public string MucThangLuong { get; set; }
            public string MucBacLuong { get; set; }
            public string MucLuongNhanVien { get; set; }
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
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    List<GetListEmployees_Result> list = (List<GetListEmployees_Result>) Session["excel"];
                    int k = 4;
                    for (int i = 0; i < list.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = i + 1;
                        excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).employee_id;
                        excelWorksheet.Cells[k, 3].Value = list.ElementAt(i).BASIC_INFO_full_name;
                        if ((bool)list.ElementAt(i).BASIC_INFO_gender)
                        {
                            excelWorksheet.Cells[k, 4].Value = "Nam";
                        }
                        else
                        {
                            excelWorksheet.Cells[k, 4].Value = "Nữ";
                        }
                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).BASIC_INFO_date_of_birth.HasValue ? list.ElementAt(i).BASIC_INFO_date_of_birth.Value.ToString("dd/MM/yyyy") : "";
                        excelWorksheet.Cells[k, 6].Value = list.ElementAt(i).BASIC_INFO_identity_card;
                        excelWorksheet.Cells[k, 7].Value = list.ElementAt(i).BASIC_INFO_social_insurance_number;
                        excelWorksheet.Cells[k, 8].Value = list.ElementAt(i).RECRUITMENT_company;
                        excelWorksheet.Cells[k, 9].Value = list.ElementAt(i).RECRUITMENT_profession;
                        excelWorksheet.Cells[k, 10].Value = list.ElementAt(i).current_department_id;
                        //
                        excelWorksheet.Cells[k, 11].Value = list.ElementAt(i).work;
                        excelWorksheet.Cells[k, 12].Value = list.ElementAt(i).salary_number;
                        excelWorksheet.Cells[k, 13].Value = list.ElementAt(i).pay_table;
                        excelWorksheet.Cells[k, 14].Value = list.ElementAt(i).pay_rate;
                        excelWorksheet.Cells[k, 17].Value = list.ElementAt(i).ACADEMIC_academic_level;
                        excelWorksheet.Cells[k, 18].Value = list.ElementAt(i).ACADEMIC_highest_qualification;
                        excelWorksheet.Cells[k, 19].Value = list.ElementAt(i).BASIC_INFO_home_town;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/download/Danh-sách-nhân-viên.xlsx")));
                }
            }

        }
    }
}