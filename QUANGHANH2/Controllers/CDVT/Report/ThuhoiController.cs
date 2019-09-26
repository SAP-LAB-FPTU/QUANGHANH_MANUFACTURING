using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class ThuhoiController : Controller
    {
        [Route("phong-cdvt/bao-cao/thu-hoi")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {

            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                getContentbyDay(ngay);
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                getContentbyDay(ngay);
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                getContentbyMonth(thang, nam);
            }
            if (type == "quarter")
            {
                int quy = Convert.ToInt32(quarter);
                int nam = Convert.ToInt32(year);
                getContentbyQuater(quy, nam);
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                getContentbyYear(nam);
            }
            return View("/Views/CDVT/Report/bao_cao_thu_hoi.cshtml");
        }

        [Route("phong-cdvt/bao-cao/thu-hoi")]
        [HttpPost]
        public ActionResult List(string type, string date, string month, string quarter, string year)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            string query = "";
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
                List<ThuhoiReport> listdata = db.Database.SqlQuery<ThuhoiReport>(query).ToList();


                int totalrows = listdata.Count;
                int totalrowsafterfiltering = listdata.Count;
                //sorting
                listdata = listdata.OrderBy(sortColumnName + " " + sortDirection).ToList<ThuhoiReport>();
                //paging
                listdata = listdata.Skip(start).Take(length).ToList<ThuhoiReport>();

                var js = Json(new { success = true, data = listdata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }


        private void getContentbyDay(DateTime date)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date == date).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date == date).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date == date).Sum(a => a.consumption_value);
                }

            }
        }
        private void getContentbyMonth(int month, int year)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.consumption_value);
                }
            }
        }
        private void getContentbyQuater(int quarter, int year)
        {
            int low = 1;
            int high = 3;
            if (quarter == 1)
            {
                low = 1;
                high = 3;
            }
            if (quarter == 2)
            {
                low = 4;
                high = 6;
            }
            if (quarter == 3)
            {
                low = 7;
                high = 9;
            }
            if (quarter == 4)
            {
                low = 10;
                high = 12;
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
            }
        }
        private void getContentbyYear(int year)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Year == year).Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Year == year).Sum(a => a.consumption_value); ;
                }
            }
        }

        private string Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, b.equipmentStatus as Tinhtrang " +
                         "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e " +
                         "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                         "and b.equipmentId = a.equipmentId and a.department_id = e.department_id  and b.acceptance_date = '" + ngay + "'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, b.equipmentStatus as Tinhtrang " +
                         "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e " +
                         "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                         "and b.equipmentId = a.equipmentId and a.department_id = e.department_id  and b.acceptance_date = '" + ngay + "'";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                          "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, b.equipmentStatus as Tinhtrang " +
                          "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e " +
                          "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                          "and b.equipmentId = a.equipmentId and a.department_id = e.department_id  and YEAR( b.acceptance_date) = " + nam + " and MONTH( b.acceptance_date) = " + thang;
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
                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, b.equipmentStatus as Tinhtrang " +
                          "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e " +
                          "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                          "and b.equipmentId = a.equipmentId and a.department_id = e.department_id and YEAR(b.acceptance_date) = " + nam + " and Month(b.acceptance_date) in " + quy;
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);

                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                          "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, b.equipmentStatus as Tinhtrang " +
                           "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e " +
                          "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                          "and b.equipmentId = a.equipmentId and a.department_id = e.department_id and YEAR(b.acceptance_date) = " + nam;
            }

            return query;

        }

        [Route("phong-cdvt/bao-cao/thu-hoi/excel")]
        public void ExportExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/BaoCaoThuHoi_Template.xlsx");
            FileInfo file = new FileInfo(path);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, b.equipmentStatus as Tinhtrang " +
                         "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e " +
                         "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                         "and b.equipmentId = a.equipmentId and a.department_id = e.department_id";
                    List<ThuhoiReport> listdata = db.Database.SqlQuery<ThuhoiReport>(query).ToList();
                    int k = 0;
                    for (int i = 2; i < listdata.Count + 2; i++)
                    {
                        excelWorksheet.Cells[i, 1].Value = (k + 1);                      
                        excelWorksheet.Cells[i, 2].Value = listdata.ElementAt(k).Ma;
                        excelWorksheet.Cells[i, 3].Value = listdata.ElementAt(k).Tenthietbi;
                        excelWorksheet.Cells[i, 4].Value = listdata.ElementAt(k).Sohieu;
                        excelWorksheet.Cells[i, 5].Value = listdata.ElementAt(k).Matscd;
                        excelWorksheet.Cells[i, 6].Value = listdata.ElementAt(k).Ngaythuhoi.ToString("hh:mm tt dd/MM/yyyy");
                        excelWorksheet.Cells[i, 7].Value = listdata.ElementAt(k).Vitrithuhoi;
                        if (listdata.ElementAt(k).Tinhtrang == 1) excelWorksheet.Cells[i, 8].Value = "Chờ điều động";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 2) excelWorksheet.Cells[i, 8].Value = "Đang hoạt động";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 3) excelWorksheet.Cells[i, 8].Value = "Đang sửa chữa";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 4) excelWorksheet.Cells[i, 8].Value = "Hỏng";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 5) excelWorksheet.Cells[i, 8].Value = "Đang bảo dưỡng";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 6) excelWorksheet.Cells[i, 8].Value = "Đang điều động";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 7) excelWorksheet.Cells[i, 8].Value = "Đang thu hồi";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 8) excelWorksheet.Cells[i, 8].Value = "Đang thanh lý";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 9) excelWorksheet.Cells[i, 8].Value = "Đang trung tu";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 10) excelWorksheet.Cells[i, 8].Value = "Đang đại tu";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 11) excelWorksheet.Cells[i, 8].Value = "Đang chờ nghiệm thu";
                        else
                        if (listdata.ElementAt(k).Tinhtrang == 12) excelWorksheet.Cells[i, 8].Value = "Đến hạn bảo dưỡng";
                        k++;
                    }
                    string location = HostingEnvironment.MapPath("/excel/CDVT/download");
                    excelPackage.SaveAs(new FileInfo(location + "/BaoCaoThuHoi.xlsx"));
                }

            }

        }
    }

    public class ThuhoiReport
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string Ma { get; set; }
        public string Tenthietbi { get; set; }
        public string Sohieu { get; set; }
        public string Matscd { get; set; }
        public DateTime Ngaythuhoi { get; set; }
        public string Vitrithuhoi { get; set; }
        public int Tinhtrang { get; set; }

    }
 
}