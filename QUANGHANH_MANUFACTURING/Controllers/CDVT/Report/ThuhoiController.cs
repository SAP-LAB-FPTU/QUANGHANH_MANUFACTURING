using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using OfficeOpenXml;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Report
{
    [Auther(RightID ="50")]
    public class ThuhoiController : Controller
    {
        [Route("phong-cdvt/bao-cao/thu-hoi")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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

        private string Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, f.statusname as Tinhtrang " +
                         "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e, Status f " +
                         "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                         "and b.equipmentId = a.equipmentId and a.department_id = e.department_id and f.statusid = a.current_Status and b.acceptance_date = '" + ngay + "'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, f.statusname as Tinhtrang " +
                         "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e, Status f " +
                         "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                         "and b.equipmentId = a.equipmentId and a.department_id = e.department_id and f.statusid = a.current_Status and b.acceptance_date = '" + ngay + "'";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                          "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, f.statusname as Tinhtrang " +
                          "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e, Status f " +
                          "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                          "and b.equipmentId = a.equipmentId and a.department_id = e.department_id and f.statusid = a.current_Status and YEAR( b.acceptance_date) = " + nam + " and MONTH( b.acceptance_date) = " + thang;
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
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, f.statusname as Tinhtrang " +
                          "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e, Status f " +
                          "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                          "and b.equipmentId = a.equipmentId and a.department_id = e.department_id and f.statusid = a.current_Status and YEAR(b.acceptance_date) = " + nam + " and Month(b.acceptance_date) in " + quy;
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);

                query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                          "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, f.statusname as Tinhtrang " +
                           "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e, Status f " +
                          "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                          "and b.equipmentId = a.equipmentId and a.department_id = e.department_id  and f.statusid = a.current_Status and YEAR(b.acceptance_date) = " + nam;
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

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string query = " select MONTH(acceptance_date) as Thang, YEAR(acceptance_date) as Nam,a.Equipment_category_id as Ma, " +
                         "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, b.acceptance_date as Ngaythuhoi,e.department_name as Vitrithuhoi, f.statusname as Tinhtrang " +
                         "from Equipment a, Acceptance b, Documentary c, Documentary_revoke_details d, Department e, Status f " +
                         "where a.equipmentId = d.equipmentId and d.documentary_id = c.documentary_id " +
                         "and b.equipmentId = a.equipmentId and a.department_id = e.department_id and f.statusid = a.current_Status";
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
                        excelWorksheet.Cells[i, 8].Value = listdata.ElementAt(k).Tinhtrang;
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
        public string Tinhtrang { get; set; }

    }

}