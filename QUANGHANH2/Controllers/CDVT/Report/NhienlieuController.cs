using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using QUANGHANH2.EntityResult;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    [Auther(RightID = "44")]
    public class NhienlieuController : Controller
    {
        [Route("phong-cdvt/bao-cao/nhien-lieu")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {
            if (type == null) date = DateTime.Now.Date.ToString("dd/MM/yyyy");
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<GetFuelReport_Result> listdata = db.Database.SqlQuery<GetFuelReport_Result>("Equipment.GetFuelReport {0}, {1}, {2}, {3}, {4}", type, date, month, quarter, year).ToList();
                double totaltieuthu = 0;
                if (listdata != null)
                {
                    foreach (var item in listdata)
                    {
                        totaltieuthu += item.LuongTieuThu;
                    }
                }
                ViewBag.all = totaltieuthu;
            }
            return View("/Views/CDVT/Report/FuelConsumption.cshtml");
        }

        [Route("phong-cdvt/bao-cao/nhien-lieu")]
        [HttpPost]
        public ActionResult List(string type, string date, string month, string quarter, string year)
        {
            if (type == null) date = DateTime.Now.Date.ToString("dd/MM/yyyy");
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<GetFuelReport_Result> listdata = db.Database.SqlQuery<GetFuelReport_Result>("Equipment.GetFuelReport {0}, {1}, {2}, {3}, {4}", type, date, month, quarter, year).ToList();
                var js = Json(new { success = true, data = listdata }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }


        [Route("phong-cdvt/bao-cao/nhien-lieu/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/nhienlieu.xlsx");
            string saveAsPath = ("/excel/CDVT/download/nhienlieu.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    if (type == null) date = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    List<GetFuelReport_Result> listdata = db.Database.SqlQuery<GetFuelReport_Result>("Equipment.GetFuelReport {0}, {1}, {2}, {3}, {4}", type, date, month, quarter, year).ToList();
                    int k = 3;
                    for (int i = 0; i < listdata.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = listdata.ElementAt(i).Thang + "/" + listdata.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = listdata.ElementAt(i).MaThietBi;
                        excelWorksheet.Cells[k, 3].Value = listdata.ElementAt(i).TenThietBi;
                        excelWorksheet.Cells[k, 4].Value = listdata.ElementAt(i).LoaiNhienLieu;
                        excelWorksheet.Cells[k, 5].Value = listdata.ElementAt(i).LuongTieuThu;
                        excelWorksheet.Cells[k, 6].Value = listdata.ElementAt(i).DonVi;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }

        private string Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = "select MONTH(fa.date) as Thang, YEAR(fa.date) as Nam,e.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,consumption_value as " +
                "LuongTieuThu, unit as DonVi from Fuel_activities_consumption fa " +
                "inner join Equipment e on e.equipmentId = fa.equipmentId " +
                "inner join Supply s on s.supply_id = fa.fuel_type " +
                "where s.unit like N'Lít' and fa.date = '" + ngay + "'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = "select MONTH(fa.date) as Thang, YEAR(fa.date) as Nam,e.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,consumption_value as " +
                "LuongTieuThu, unit as DonVi from Fuel_activities_consumption fa " +
                "inner join Equipment e on e.equipmentId = fa.equipmentId " +
                "inner join Supply s on s.supply_id = fa.fuel_type " +
                "where s.unit like N'Lít' and fa.date = '" + ngay + "'";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = "select MONTH(fa.date) as Thang, YEAR(fa.date) as Nam,e.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,sum(consumption_value) as " +
                "LuongTieuThu, unit as DonVi from Fuel_activities_consumption fa " +
                "inner join Equipment e on e.equipmentId = fa.equipmentId " +
                "inner join Supply s on s.supply_id = fa.fuel_type " +
                "where s.unit like N'Lít' and Month(fa.date) = " + thang + " and Year(fa.date) = " + nam + "" +
                "group by MONTH(fa.date) , YEAR(fa.date) ,e.equipmentId ," +
                "equipment_name, supply_name,consumption_value, unit";
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
                query = "select MONTH(fa.date) as Thang, YEAR(fa.date) as Nam,e.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,sum(consumption_value) as " +
                "LuongTieuThu, unit as DonVi from Fuel_activities_consumption fa " +
                "inner join Equipment e on e.equipmentId = fa.equipmentId " +
                "inner join Supply s on s.supply_id = fa.fuel_type " +
                "where s.unit like N'Lít' and Month(fa.date) in " + quy + " and Year(fa.date) = " + nam + "" +
                "group by MONTH(fa.date) , YEAR(fa.date) ,e.equipmentId ," +
                "equipment_name, supply_name,consumption_value, unit";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                query = "select MONTH(date) as Thang, YEAR(date) as Nam,e.equipmentId as MaThietBi, " +
                            "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,sum(consumption_value) as " +
                            "LuongTieuThu, unit as DonVi " +
                            "from Fuel_activities_consumption fa " +
                            "inner join Equipment e on e.equipmentId = fa.equipmentId " +
                            "inner join Supply s on s.supply_id = fa.fuel_type " +
                            "where s.unit like N'Lít' and YEAR(date) = " + nam + "" +
                            "group by MONTH(date) , YEAR(date) ,e.equipmentId ," +
                            "equipment_name, supply_name,consumption_value, unit";
            }

            return query;
        }
    }
}