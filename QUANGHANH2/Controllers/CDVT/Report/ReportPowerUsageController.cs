using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using QUANGHANH2.EntityResult;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    [Auther(RightID ="43")]
    public class ReportPowerUsageController : Controller
    {
        /*aa*/
        [Route("phong-cdvt/bao-cao/dien-nang")]
        public ActionResult Quarter(string type, string date, string month, string quarter, string year)
        {
            if (type == null) date = DateTime.Now.Date.ToString("dd/MM/yyyy");
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<GetPowerReport_Result> listdata = db.Database.SqlQuery<GetPowerReport_Result>("Equipment.GetPowerReport {0, {1}, {2}, {3}, {4}", type, date, month, quarter, year).ToList();
                double totaltieuthu = 0; double totalsanluong = 0;
                if (listdata != null)
                {
                    foreach (var item in listdata)
                    {
                        totaltieuthu += item.LuongTieuThu;
                        totalsanluong += item.SanLuong;
                    }
                }
                ViewBag.Dien = totaltieuthu;
                ViewBag.SanLuong = totalsanluong;
            }

            return View("/Views/CDVT/Report/QuarterPowerUsage.cshtml");
        }
        [Route("phong-cdvt/bao-cao/dien-nang")]
        [HttpPost]
        public ActionResult List(string type, string date, string month, string quarter, string year)
        {
            if (type == null) date = DateTime.Now.Date.ToString("dd/MM/yyyy");
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<GetPowerReport_Result> listdata = db.Database.SqlQuery<GetPowerReport_Result>("Equipment.GetPowerReport {0, {1}, {2}, {3}, {4}", type, date, month, quarter, year).ToList();
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

                query = "select b.Thang, b.Nam,b.MaThietBi, b.TenThietBi,(b.[value]/ 1000) * b.[time] as 'LuongTieuThu', " +
                        " b.SanLuong, b.DonVi from " +
                        " (select MONTH(a.date) as Thang, YEAR(a.date) as Nam, AVG(CAST(ca.[Value] as float)) as 'value', e.equipmentId as MaThietBi, " +
                        " equipment_name as TenThietBi,a.hours_per_day as " +
                        " 'time',a.quantity as SanLuong, ca.unit as DonVi " +
                        " from Equipment e " +
                        " left Join Equipment_attribute ca on e.equipmentId = ca.equipmentId " +
                        " left join Activity a on a.equipmentid = e.equipmentId " +
                        " where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW'  and a.date = '" + ngay + "' " +
                        " group by a.[date], e.equipmentId, e.equipment_name, a.hours_per_day, a.quantity, ca.unit) as b";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date,"dd/MM/yyyy",null).ToString("yyyy-MM-dd");
                query = "select b.Thang, b.Nam,b.MaThietBi, b.TenThietBi,(b.[value]/ 1000) * b.[time] as 'LuongTieuThu', " +
                        " b.SanLuong, b.DonVi from " +
                        " (select MONTH(a.date) as Thang, YEAR(a.date) as Nam, AVG(CAST(ca.[Value] as float)) as 'value', e.equipmentId as MaThietBi, " +
                        " equipment_name as TenThietBi,a.hours_per_day as " +
                        " 'time',a.quantity as SanLuong, ca.unit as DonVi " +
                        " from Equipment e " +
                        " left Join Equipment_attribute ca on e.equipmentId = ca.equipmentId " +
                        " left join Activity a on a.equipmentid = e.equipmentId " +
                        " where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW'  and a.date = '" + ngay + "' " +
                        " group by a.[date], e.equipmentId, e.equipment_name, a.hours_per_day, a.quantity, ca.unit) as b";
                ViewBag.now = date;
            }
            
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = "select b.Thang, b.Nam,b.MaThietBi, b.TenThietBi,(b.[value]/ 1000) * b.[time] as 'LuongTieuThu', " +
                        " b.SanLuong, b.DonVi from " +
                        " (select MONTH(a.date) as Thang, YEAR(a.date) as Nam, AVG(CAST(ca.[Value] as float)) as 'value', e.equipmentId as MaThietBi, " +
                        " equipment_name as TenThietBi,a.hours_per_day as " +
                        " 'time',a.quantity as SanLuong, ca.unit as DonVi " +
                        " from Equipment e " +
                        " left Join Equipment_attribute ca on e.equipmentId = ca.equipmentId " +
                        " left join Activity a on a.equipmentid = e.equipmentId " +
                        " where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW'  and YEAR(a.date) = " + nam + " and MONTH(a.date) = " + thang +
                        " group by a.[date], e.equipmentId, e.equipment_name, a.hours_per_day, a.quantity, ca.unit) as b";
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
                
                query = "select b.Thang, b.Nam,b.MaThietBi, b.TenThietBi,(b.[value]/ 1000) * b.[time] as 'LuongTieuThu', " +
                        " b.SanLuong, b.DonVi from " +
                        " (select MONTH(a.date) as Thang, YEAR(a.date) as Nam, AVG(CAST(ca.[Value] as float)) as 'value', e.equipmentId as MaThietBi, " +
                        " equipment_name as TenThietBi,a.hours_per_day as " +
                        " 'time',a.quantity as SanLuong, ca.unit as DonVi " +
                        " from Equipment e " +
                        " left Join Equipment_attribute ca on e.equipmentId = ca.equipmentId " +
                        " left join Activity a on a.equipmentid = e.equipmentId " +
                        " where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW'  and YEAR(a.date) = " + nam + " and Month(a.date) in " + quy +
                        " group by a.[date], e.equipmentId, e.equipment_name, a.hours_per_day, a.quantity, ca.unit) as b";
            }
            if (type == "year")
            {
                
                int nam = Convert.ToInt32(year);
                query = "select b.Thang, b.Nam,b.MaThietBi, b.TenThietBi,(b.[value]/ 1000) * b.[time] as 'LuongTieuThu', " +
                        " b.SanLuong, b.DonVi from " +
                        " (select MONTH(a.date) as Thang, YEAR(a.date) as Nam, AVG(CAST(ca.[Value] as float)) as 'value', e.equipmentId as MaThietBi, " +
                        " equipment_name as TenThietBi,a.hours_per_day as " +
                        " 'time',a.quantity as SanLuong, ca.unit as DonVi " +
                        " from Equipment e " +
                        " left Join Equipment_attribute ca on e.equipmentId = ca.equipmentId " +
                        " left join Activity a on a.equipmentid = e.equipmentId " +
                        " where ca.Equipment_attribute_name like N'%Công suất%' and ca.unit = 'kW'  and YEAR(a.date) = " + nam +
                        " group by a.[date], e.equipmentId, e.equipment_name, a.hours_per_day, a.quantity, ca.unit) as b";
            }
            return query;
        }
        [Route("phong-cdvt/bao-cao/dien-nang/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/diennang.xlsx");
            string saveAsPath = ("/excel/CDVT/download/diennang.xlsx");
            FileInfo file = new FileInfo(path);
            using(ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    if (type == null) date = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    List<GetPowerReport_Result> content = db.Database.SqlQuery<GetPowerReport_Result>("Equipment.GetPowerReport {0, {1}, {2}, {3}, {4}", type, date, month, quarter, year).ToList();
                    double totaltieuthu = 0; double totalsanluong = 0;
                    if (content != null)
                    {
                        foreach (var item in content)
                        {
                            totaltieuthu += item.LuongTieuThu;
                            totalsanluong += item.SanLuong;
                        }
                    }
                    int k = 3;
                    for (int i = 0; i < content.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = content.ElementAt(i).Thang + "/" + content.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = content.ElementAt(i).MaThietBi;
                        excelWorksheet.Cells[k, 3].Value = content.ElementAt(i).TenThietBi;
                        excelWorksheet.Cells[k, 4].Value = content.ElementAt(i).LuongTieuThu;
                        excelWorksheet.Cells[k, 5].Value = content.ElementAt(i).SanLuong;
                        excelWorksheet.Cells[k, 6].Value = content.ElementAt(i).DonVi;
                        k++;
                    }
                    excelWorksheet.Cells[k, 3].Value = "Tổng";
                    excelWorksheet.Cells[k, 4].Value = totaltieuthu;
                    excelWorksheet.Cells[k, 5].Value = totalsanluong;
                    excelWorksheet.Cells[k, 3].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 3].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 4].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }
}