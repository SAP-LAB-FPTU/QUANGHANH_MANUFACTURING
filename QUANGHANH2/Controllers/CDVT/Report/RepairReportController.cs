using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    [Auther(RightID = "48")]
    public class RepairReportController : Controller
    {
        /*aa*/
        [Route("phong-cdvt/bao-cao/sua-chua")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {
            var noww = DateTime.Now.Date.ToString("dd/MM/yyyy");
            ViewBag.now = noww;
            int h100bag = 0, h200bag = 0, h500bag = 0, h1000bag = 0, h2000bag = 0, dotxuatbag = 0,thuongxuyenbag=0;
            Wherecondition(type, date, month, quarter, year);
            List<Content> content = new List<Content>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var eqID = db.Database.SqlQuery<Eqp>("select dm.equipmentId as id from Documentary_maintain_details dm union select dr.equipmentId as id from Documentary_repair_details dr").ToList();
                foreach (var item in eqID)
                {
                    if (ViewBag.ContentBaoDuong.Count > 0 || ViewBag.ContentSuaChua.Count > 0)
                    {
                    string id = item.id;
                    int h100 = 0, h200 = 0, h500 = 0, h1000 = 0, h2000 = 0, DotXuat = 0, ThuongXuyen = 0, Thang = 0,Nam = 0 ;
                    string MaThietBi = ""; string TenThietBi = ""; string MaTSCD = "";
                    foreach (var item1 in ViewBag.ContentBaoDuong)
                    {
                        if (id.Equals(item1.MaThietBi))
                        {
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 100h")) { h100++; h100bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 200h")) { h200++; h200bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 500h")) { h500++; h500bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 1000h")){ h1000++; h1000bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 2000h")){ h2000++; h2000bag++; }
                                MaThietBi = item1.MaThietBi; TenThietBi = item1.TenThietBi; MaTSCD = item1.MaTSCD;
                                Thang = item1.Thang; Nam = item1.Nam;
                        }
                    }
                    foreach(var item1 in ViewBag.ContentSuaChua)
                    {
                        if (id.Equals(item1.MaThietBi))
                        {
                                if (item1.LoaiSuaChua.Equals("sửa chữa lớn")) { DotXuat++; dotxuatbag++; }
                                if (item1.LoaiSuaChua.Equals("sửa chữa nhỏ")) { ThuongXuyen++; thuongxuyenbag++; }
                                MaThietBi = item1.MaThietBi; TenThietBi = item1.TenThietBi; MaTSCD = item1.MaTSCD;
                                Thang = item1.Thang; Nam = item1.Nam;
                            }
                    }
                        if (!String.IsNullOrEmpty(MaThietBi))
                        {
                            content.Add(new Content
                            {
                                Thang = Thang,
                                Nam = Nam,
                                MaThietBi = MaThietBi,
                                TenThietBi = TenThietBi,
                                MaTSCD = MaTSCD,
                                h100 = h100,
                                h200 = h200,
                                h500 = h500,
                                h1000 = h1000,
                                h2000 = h2000,
                                DotXuat = DotXuat,
                                ThuongXuyen = ThuongXuyen
                            });
                        }
                    }
                }
                db.SaveChanges();
            }
            ViewBag.all = content;
            ViewBag.h100 = h100bag;
            ViewBag.h200 = h200bag;
            ViewBag.h500 = h500bag;
            ViewBag.h1000 = h1000bag;
            ViewBag.h2000 = h2000bag;
            ViewBag.dotxuat = dotxuatbag;
            ViewBag.thuongxuyen = thuongxuyenbag;
            ViewBag.baoduong = h100bag + h200bag + h500bag + h1000bag + h2000bag;
            ViewBag.suachua = dotxuatbag + thuongxuyenbag;
                return View("/Views/CDVT/Report/RepairReport.cshtml");
        }
        private void Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string queryBD = "";
            string querySC = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, "+
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and dm.finish_date_plan = '"+ngay+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, "+
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and dm.finish_date_plan = '"+ngay+"'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and dm.finish_date_plan = '" + ngay + "'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and dm.finish_date_plan = '" + ngay + "'";
                ViewBag.now = date;
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and MONTH(dm.finish_date_plan) = '"+thang+"' and YEAR(dm.finish_date_plan) = '"+nam+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and MONTH(dm.finish_date_plan) = '" + thang + "' and YEAR(dm.finish_date_plan) = '" + nam + "'";
            }
            if (type == "quarter")
            {
                int nam = Convert.ToInt32(year);
                string quy = "";
                if (quarter == "1")
                {
                    quy = " (1,2,3) ";
                }
                if (quarter == "2")
                {
                    quy = " (4,5,6) ";
                }
                if (quarter == "3")
                {
                    quy = " (7,8,9) ";
                }
                if (quarter == "4")
                {
                    quy = " (10,11,12) ";
                }
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and MONTH(dm.finish_date_plan) in "+quy+" and YEAR(dm.finish_date_plan) = '"+nam+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and MONTH(dm.finish_date_plan) in " + quy + " and YEAR(dm.finish_date_plan) = '" + nam + "'";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and YEAR(dm.finish_date_plan) = '"+nam+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_id = dm.documentary_id and YEAR(dm.finish_date_plan) = '" + nam + "'";
            }

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                ViewBag.ContentBaoDuong = db.Database.SqlQuery<contentBaoDuong>(queryBD).ToList();
                ViewBag.ContentSuaChua = db.Database.SqlQuery<contentSuaChua>(querySC).ToList();
            }
        }
        [Route("phong-cdvt/bao-cao/sua-chua/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/suachua.xlsx");
            string saveAsPath = ("/excel/CDVT/download/suachua.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    int h100bag = 0, h200bag = 0, h500bag = 0, h1000bag = 0, h2000bag = 0, dotxuatbag = 0, thuongxuyenbag = 0;
                    Wherecondition(type, date, month, quarter, year);
                    List<Content> content = new List<Content>();
                        var eqID = db.Database.SqlQuery<Eqp>("select dm.equipmentId as id from Documentary_maintain_details dm union select dr.equipmentId as id from Documentary_repair_details dr").ToList();
                        foreach (var item in eqID)
                        {
                            if (ViewBag.ContentBaoDuong.Count > 0 || ViewBag.ContentSuaChua.Count > 0)
                            {
                                string id = item.id;
                                int h100 = 0, h200 = 0, h500 = 0, h1000 = 0, h2000 = 0, DotXuat = 0, ThuongXuyen = 0, Thang = 0, Nam = 0;
                                string MaThietBi = ""; string TenThietBi = ""; string MaTSCD = "";
                                foreach (var item1 in ViewBag.ContentBaoDuong)
                                {
                                    if (id.Equals(item1.MaThietBi))
                                    {
                                        if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 100h")) { h100++; h100bag++; }
                                        if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 200h")) { h200++; h200bag++; }
                                        if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 500h")) { h500++; h500bag++; }
                                        if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 1000h")) { h1000++; h1000bag++; }
                                        if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 2000h")) { h2000++; h2000bag++; }
                                        MaThietBi = item1.MaThietBi; TenThietBi = item1.TenThietBi; MaTSCD = item1.MaTSCD;
                                        Thang = item1.Thang; Nam = item1.Nam;
                                    }
                                }
                                foreach (var item1 in ViewBag.ContentSuaChua)
                                {
                                    if (id.Equals(item1.MaThietBi))
                                    {
                                        if (item1.LoaiSuaChua.Equals("sửa chữa lớn")) { DotXuat++; dotxuatbag++; }
                                        if (item1.LoaiSuaChua.Equals("sửa chữa nhỏ")) { ThuongXuyen++; thuongxuyenbag++; }
                                        MaThietBi = item1.MaThietBi; TenThietBi = item1.TenThietBi; MaTSCD = item1.MaTSCD;
                                        Thang = item1.Thang; Nam = item1.Nam;
                                    }
                                }
                                if (!String.IsNullOrEmpty(MaThietBi))
                                {
                                    content.Add(new Content
                                    {
                                        Thang = Thang,
                                        Nam = Nam,
                                        MaThietBi = MaThietBi,
                                        TenThietBi = TenThietBi,
                                        MaTSCD = MaTSCD,
                                        h100 = h100,
                                        h200 = h200,
                                        h500 = h500,
                                        h1000 = h1000,
                                        h2000 = h2000,
                                        DotXuat = DotXuat,
                                        ThuongXuyen = ThuongXuyen
                                    });
                                }
                            }
                        }
                    int k = 3;
                    for(int i = 0; i < content.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = content.ElementAt(i).Thang + "/" + content.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = content.ElementAt(i).MaThietBi;
                        excelWorksheet.Cells[k, 3].Value = content.ElementAt(i).TenThietBi;
                        excelWorksheet.Cells[k, 4].Value = content.ElementAt(i).MaTSCD;
                        excelWorksheet.Cells[k, 5].Value = content.ElementAt(i).h100;
                        excelWorksheet.Cells[k, 6].Value = content.ElementAt(i).h200;
                        excelWorksheet.Cells[k, 7].Value = content.ElementAt(i).h500;
                        excelWorksheet.Cells[k, 8].Value = content.ElementAt(i).h1000;
                        excelWorksheet.Cells[k, 9].Value = content.ElementAt(i).h2000;
                        excelWorksheet.Cells[k, 10].Value = content.ElementAt(i).DotXuat;
                        excelWorksheet.Cells[k, 11].Value = content.ElementAt(i).ThuongXuyen;
                        k++;
                    }
                    excelWorksheet.Cells[k, 4].Value = "Tổng";
                    excelWorksheet.Cells[k, 5].Value = h100bag;
                    excelWorksheet.Cells[k, 6].Value = h200bag;
                    excelWorksheet.Cells[k, 7].Value = h500bag;
                    excelWorksheet.Cells[k, 8].Value = h1000bag;
                    excelWorksheet.Cells[k, 9].Value = h2000bag;
                    excelWorksheet.Cells[k, 10].Value = dotxuatbag;
                    excelWorksheet.Cells[k, 11].Value = thuongxuyenbag;
                    excelWorksheet.Cells[k, 4].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 4].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 6].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 7].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 8].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 9].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 10].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 11].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
                return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }
    public class contentBaoDuong
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string MaTSCD { get; set; }
        public string LoaiBaoDuong { get; set; }
    }
    public class contentSuaChua
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string MaTSCD { get; set; }
        public string LoaiSuaChua { get; set; }
    }
    public class Content
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string MaTSCD { get; set; }
        public int h100 { get; set; }
        public int h200 { get; set; }
        public int h500 { get; set; }
        public int h1000 { get; set; }
        public int h2000 { get; set; }
        public int DotXuat { get; set; }
        public int ThuongXuyen { get; set; }
    }
    public class Eqp
    {
        public string id { get; set; }
    }
}