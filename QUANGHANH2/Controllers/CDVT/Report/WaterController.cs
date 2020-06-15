using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    [Auther(RightID = "45")]
    public class WaterController : Controller
    {
        /*aa*/
        [Route("phong-cdvt/bao-cao/thoat-nuoc")]
        public ActionResult Water(string type, string date, string month, string quarter, string year)
        {
            string query;
            if (type == null)
            {
                var ngay = DateTime.Now.Date.ToString("dd/MM/yyyy");
                query = Wherecondition("day", ngay, null, null, null);
            }
            else
            {
                query = Wherecondition(type, date, month, quarter, year);
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<contentreportWater> listdata = db.Database.SqlQuery<contentreportWater>(query).ToList();
                if (listdata != null)
                {
                    double totaltieuhao = 0; double totalsanluong = 0; double totalgio = 0;
                    foreach (var item in listdata)
                    {
                        totaltieuhao += item.LuongTieuThu;
                        totalsanluong += item.SanLuong;
                        totalgio += item.GioHoatDong;
                        item.LuongTieuThu = Math.Round(item.LuongTieuThu, 1);
                    }
                    ViewBag.TieuHao = totaltieuhao;
                    ViewBag.SanLuong = totalsanluong;
                    ViewBag.GioHoatDong = totalgio;
                }
            }

            return View("/Views/CDVT/Report/WaterReport.cshtml");
        }
        [Route("phong-cdvt/bao-cao/thoat-nuoc")]
        [HttpPost]
        public ActionResult List(string type, string date, string month, string quarter, string year)
        {
            string query;
            if (type == null)
            {
                var ngay = DateTime.Now.Date.ToString("dd/MM/yyyy");
                query = Wherecondition("day", ngay, null, null, null);
            }
            else
            {
                query = Wherecondition(type, date, month, quarter, year);
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<contentreportWater> listdata = db.Database.SqlQuery<contentreportWater>(query).ToList();
                foreach (var item in listdata)
                {
                    item.LuongTieuThu = Math.Round(item.LuongTieuThu, 1);
                }
                var js = Json(new { success = true, data = listdata }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }
        private string Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = @"select MONTH(ac.date) as Thang, YEAR(ac.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, 
                          d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong , hours_per_day * (CAST(ca.[Value] as float) / 1000) as 
                          LuongTieuThu,ac.quantity as SanLuong from Equipment c 
                          inner join Activity ac on c.equipmentId = ac.equipmentid 
                          inner join Department d on d.department_id = c.department_id 
                          inner join Equipment_attribute ca on ca.equipmentId = c.equipmentId
                          where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW' and ac.date = '" + ngay+"' and c.Equipment_category_id = 'BN'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                query = @"select MONTH(ac.date) as Thang, YEAR(ac.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, 
                          d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong , hours_per_day * (CAST(ca.[Value] as float) / 1000) as 
                          LuongTieuThu,ac.quantity as SanLuong from Equipment c 
                          inner join Activity ac on c.equipmentId = ac.equipmentid 
                          inner join Department d on d.department_id = c.department_id 
                          inner join Equipment_attribute ca on ca.equipmentId = c.equipmentId
                          where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW' and ac.date = '" + ngay+"' and c.Equipment_category_id = 'BN'";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = @"select MONTH(ac.date) as Thang, YEAR(ac.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, 
                          d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong , hours_per_day * (CAST(ca.[Value] as float) / 1000) as 
                          LuongTieuThu,ac.quantity as SanLuong from Equipment c 
                          inner join Activity ac on c.equipmentId = ac.equipmentid 
                          inner join Department d on d.department_id = c.department_id 
                          inner join Equipment_attribute ca on ca.equipmentId = c.equipmentId
                          where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW' and YEAR(ac.date) = " + nam+" and MONTH(ac.date) = "+thang+" and c.Equipment_category_id = 'BN'";
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
                query = @"select MONTH(ac.date) as Thang, YEAR(ac.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, 
                          d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong , hours_per_day * (CAST(ca.[Value] as float) / 1000) as 
                          LuongTieuThu,ac.quantity as SanLuong from Equipment c 
                          inner join Activity ac on c.equipmentId = ac.equipmentid 
                          inner join Department d on d.department_id = c.department_id 
                          inner join Equipment_attribute ca on ca.equipmentId = c.equipmentId
                          where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW' and MONTH(ac.date) in " + quy+" and YEAR(ac.date) = "+nam+" and c.Equipment_category_id = 'BN'";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                query = @"select MONTH(ac.date) as Thang, YEAR(ac.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, 
                          d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong , hours_per_day * (CAST(ca.[Value] as float) / 1000) as 
                          LuongTieuThu,ac.quantity as SanLuong from Equipment c 
                          inner join Activity ac on c.equipmentId = ac.equipmentid 
                          inner join Department d on d.department_id = c.department_id 
                          inner join Equipment_attribute ca on ca.equipmentId = c.equipmentId
                          where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW' and YEAR(ac.date) = " + nam+" and c.Equipment_category_id = 'BN'";
            }
            return query;
        }
        [Route("phong-cdvt/bao-cao/thoat-nuoc/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/thoatnuoc.xlsx");
            string saveAsPath = ("/excel/CDVT/download/thoatnuoc.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string query;
                    if (type == null)
                    {
                        var ngay = DateTime.Now.Date.ToString("dd/MM/yyyy");
                        query = Wherecondition("day", ngay, null, null, null);
                    }
                    else
                    {
                        query = Wherecondition(type, date, month, quarter, year);
                    }
                    List<contentreportWater> content = db.Database.SqlQuery<contentreportWater>(query).ToList();
                    double totaltieuhao = 0; double totalsanluong = 0; double totalgio = 0;
                    if (content != null)
                    {
                        foreach (var item in content)
                        {
                            totaltieuhao += item.LuongTieuThu;
                            totalsanluong += item.SanLuong;
                            totalgio += item.GioHoatDong;
                        }
                    }
                    int k = 3;
                    for (int i = 0; i < content.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = content.ElementAt(i).Thang + "/" + content.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = content.ElementAt(i).TenThietBi;
                        excelWorksheet.Cells[k, 3].Value = content.ElementAt(i).MaThietBi;
                        excelWorksheet.Cells[k, 4].Value = content.ElementAt(i).MaTSCD;
                        excelWorksheet.Cells[k, 5].Value = content.ElementAt(i).ViTriDat;
                        excelWorksheet.Cells[k, 6].Value = content.ElementAt(i).GioHoatDong;
                        excelWorksheet.Cells[k, 7].Value = content.ElementAt(i).LuongTieuThu;
                        excelWorksheet.Cells[k, 8].Value = content.ElementAt(i).SanLuong;
                        k++;
                    }
                    excelWorksheet.Cells[k, 5].Value = "Tổng";
                    excelWorksheet.Cells[k, 6].Value = totalgio;
                    excelWorksheet.Cells[k, 7].Value = totaltieuhao;
                    excelWorksheet.Cells[k, 8].Value = totalsanluong;
                    excelWorksheet.Cells[k, 5].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 6].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 7].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 8].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }
    public class contentreportWater
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string MaTSCD { get; set; }
        public string ViTriDat { get; set; }
        public string TenThietBi { get; set; }
        public double GioHoatDong { get; set; }
        public double LuongTieuThu { get; set; }
        public double SanLuong { get; set; }
    }
}