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
    public class LiquidationReportController : Controller
    {
        [Auther(RightID ="46")]
        [Route("phong-cdvt/bao-cao/thanh-ly")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {
            Wherecondition(type, date, month, quarter, year);
            int sl = 0;
            foreach(var item in ViewBag.ContentReport)
            {
                sl++;
            }
            ViewBag.sl = sl;
            
            return View("/Views/CDVT/Report/LiquidationReport.cshtml");
        }
        private void Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = "select MONTH(ac.acceptance_date) as Thang, YEAR(ac.acceptance_date) as Nam, e.equipment_name as TenThietBi, "+
                            " e.equipmentId as MaThietBi from Equipment e,Acceptance ac, Documentary do where ac.equipmentId = e.equipmentId " +
                            " and do.documentary_id = ac.documentary_id and do.documentary_type = 5 and ac.acceptance_date = '"+ngay+"'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                query = "select MONTH(ac.acceptance_date) as Thang, YEAR(ac.acceptance_date) as Nam, e.equipment_name as TenThietBi, " +
                            " e.equipmentId as MaThietBi from Equipment e,Acceptance ac, Documentary do where ac.equipmentId = e.equipmentId " +
                            " and do.documentary_id = ac.documentary_id and do.documentary_type = 5 and ac.acceptance_date = '" + ngay + "'";
                ViewBag.now = date;
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = "select MONTH(ac.acceptance_date) as Thang, YEAR(ac.acceptance_date) as Nam, e.equipment_name as TenThietBi, " +
                            " e.equipmentId as MaThietBi from Equipment e,Acceptance ac, Documentary do where ac.equipmentId = e.equipmentId " +
                            " and do.documentary_id = ac.documentary_id and do.documentary_type = 5 and MONTH(ac.acceptance_date) = "+thang+" and YEAR(ac.acceptance_date) = "+nam+"";
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
                query = "select MONTH(ac.acceptance_date) as Thang, YEAR(ac.acceptance_date) as Nam, e.equipment_name as TenThietBi, " +
                            " e.equipmentId as MaThietBi from Equipment e,Acceptance ac, Documentary do where ac.equipmentId = e.equipmentId " +
                            " and do.documentary_id = ac.documentary_id and do.documentary_type = 5 and MONTH(ac.acceptance_date) in "+quy+" and YEAR(ac.acceptance_date) = "+nam+"";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                query = "select MONTH(ac.acceptance_date) as Thang, YEAR(ac.acceptance_date) as Nam, e.equipment_name as TenThietBi, " +
                            " e.equipmentId as MaThietBi from Equipment e,Acceptance ac, Documentary do where ac.equipmentId = e.equipmentId " +
                            " and do.documentary_id = ac.documentary_id and do.documentary_type = 5 and  YEAR(ac.acceptance_date) = "+nam+"";
            }

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                ViewBag.ContentReport = db.Database.SqlQuery<contentreportTL>(query).ToList();
            }
        }
        [Route("phong-cdvt/bao-cao/thanh-ly/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/thanhly.xlsx");
            string saveAsPath = ("/excel/CDVT/download/thanhly.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    Wherecondition(type, date, month, quarter, year);
                    int k = 3;
                    List<contentreportTL> content = ViewBag.ContentReport;
                    for (int i = 0; i < content.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = content.ElementAt(i).Thang + "/" + content.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = content.ElementAt(i).MaThietBi;
                        excelWorksheet.Cells[k, 3].Value = content.ElementAt(i).TenThietBi;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }
    public class contentreportTL
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
    }
}