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
    [Auther(RightID ="49")]
    public class TrungdaituReportController : Controller
    {
        [Route("phong-cdvt/bao-cao/trung-tu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Report/bao_cao_trung_tu.cshtml");
        }

        [Route("phong-cdvt/bao-cao/trung-tu")]
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
                List<TrungTuReport> listdata = db.Database.SqlQuery<TrungTuReport>(query).ToList();


                int totalrows = listdata.Count;
                int totalrowsafterfiltering = listdata.Count;
                //sorting
                listdata = listdata.OrderBy(sortColumnName + " " + sortDirection).ToList<TrungTuReport>();
                //paging
                listdata = listdata.Skip(start).Take(length).ToList<TrungTuReport>();

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
                query = " select MONTH(c.date_created) as Thang, YEAR(c.date_created) as Nam,a.Equipment_category_id as Ma, " +
                "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, c.date_created as Ngayquyetdinh, " +
                "SUM(case b.next_remodel_type when N'Tiểu tu' then 1 else 0 end) as Tieutu, " +
                "SUM(case b.next_remodel_type when N'Trung tu' then 1 else 0 end) as Trungtu, " +
                "SUM(case b.next_remodel_type when N'Đại tu' then 1 else 0 end) as Daitu " +
                "from Equipment a,Documentary_big_maintain_details b, Documentary c " +
                "where a.equipmentId = b.equipmentId and b.documentary_id = c.documentary_id and c.date_created = '" + ngay + "'" +
                "group by b.documentary_id, a.equipmentId, c.date_created, a.Equipment_category_id, a.equipment_name, a.mark_code ";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = " select MONTH(c.date_created) as Thang, YEAR(c.date_created) as Nam,a.Equipment_category_id as Ma, " +
                   "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, c.date_created as Ngayquyetdinh, " +
                   "SUM(case b.next_remodel_type when N'Tiểu tu' then 1 else 0 end) as Tieutu, " +
                   "SUM(case b.next_remodel_type when N'Trung tu' then 1 else 0 end) as Trungtu, " +
                   "SUM(case b.next_remodel_type when N'Đại tu' then 1 else 0 end) as Daitu " +
                   "from Equipment a,Documentary_big_maintain_details b, Documentary c " +
                   "where a.equipmentId = b.equipmentId and b.documentary_id = c.documentary_id and c.date_created = '" + ngay + "'" +
                   "group by b.documentary_id, a.equipmentId, c.date_created, a.Equipment_category_id, a.equipment_name, a.mark_code ";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = " select MONTH(c.date_created) as Thang, YEAR(c.date_created) as Nam,a.Equipment_category_id as Ma, " +
                    "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, c.date_created as Ngayquyetdinh, " +
                    "SUM(case b.next_remodel_type when N'Tiểu tu' then 1 else 0 end) as Tieutu, " +
                    "SUM(case b.next_remodel_type when N'Trung tu' then 1 else 0 end) as Trungtu, " +
                    "SUM(case b.next_remodel_type when N'Đại tu' then 1 else 0 end) as Daitu " +
                    "from Equipment a,Documentary_big_maintain_details b, Documentary c " +
                    " where a.equipmentId = b.equipmentId and b.documentary_id = c.documentary_id and YEAR( c.date_created) = " + nam + " and MONTH( c.date_created) = " + thang +
                    "group by b.documentary_id, a.equipmentId, c.date_created, a.Equipment_category_id, a.equipment_name, a.mark_code ";
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
                query = " select MONTH(c.date_created) as Thang, YEAR(c.date_created) as Nam,a.Equipment_category_id as Ma, " +
             "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, c.date_created as Ngayquyetdinh, " +
             "SUM(case b.next_remodel_type when N'Tiểu tu' then 1 else 0 end) as Tieutu, " +
             "SUM(case b.next_remodel_type when N'Trung tu' then 1 else 0 end) as Trungtu, " +
             "SUM(case b.next_remodel_type when N'Đại tu' then 1 else 0 end) as Daitu " +
             "from Equipment a,Documentary_big_maintain_details b, Documentary c " +
              " where a.equipmentId = b.equipmentId and b.documentary_id = c.documentary_id and YEAR( c.date_created) = " + nam + " and Month(c.date_created) in " + quy +
                "group by b.documentary_id, a.equipmentId, c.date_created, a.Equipment_category_id, a.equipment_name, a.mark_code ";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                query = " select MONTH(c.date_created) as Thang, YEAR(c.date_created) as Nam,a.Equipment_category_id as Ma, " +
             "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, c.date_created as Ngayquyetdinh, " +
             "SUM(case b.next_remodel_type when N'Tiểu tu' then 1 else 0 end) as Tieutu, " +
             "SUM(case b.next_remodel_type when N'Trung tu' then 1 else 0 end) as Trungtu, " +
             "SUM(case b.next_remodel_type when N'Đại tu' then 1 else 0 end) as Daitu " +
             "from Equipment a,Documentary_big_maintain_details b, Documentary c " +
             " where a.equipmentId = b.equipmentId and b.documentary_id = c.documentary_id and YEAR( c.date_created) = " + nam +
              "group by b.documentary_id, a.equipmentId, c.date_created, a.Equipment_category_id, a.equipment_name, a.mark_code ";
            }

            return query;

        }

        [Route("phong-cdvt/bao-cao/trung-tu/excel")]
        public void ExportExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/BaoCaoTrungTu_Template.xlsx");
            FileInfo file = new FileInfo(path);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string query = " select MONTH(c.date_created) as Thang, YEAR(c.date_created) as Nam,a.Equipment_category_id as Ma, " +
             "a.equipment_name as Tenthietbi, a.mark_code as Sohieu, a.equipmentId as Matscd, c.date_created as Ngayquyetdinh, " +
             "SUM(case b.next_remodel_type when N'Tiểu tu' then 1 else 0 end) as Tieutu, " +
             "SUM(case b.next_remodel_type when N'Trung tu' then 1 else 0 end) as Trungtu, " +
             "SUM(case b.next_remodel_type when N'Đại tu' then 1 else 0 end) as Daitu " +
             "from Equipment a,Documentary_big_maintain_details b, Documentary c " +
             " where a.equipmentId = b.equipmentId and b.documentary_id = c.documentary_id " +
             "group by b.documentary_id, a.equipmentId, c.date_created, a.Equipment_category_id, a.equipment_name, a.mark_code ";
                    List<TrungTuReport> listdata = db.Database.SqlQuery<TrungTuReport>(query).ToList();
                    int k = 0;
                    for (int i = 3; i < listdata.Count + 3; i++)
                    {
                        excelWorksheet.Cells[i, 1].Value = (k + 1);
                        excelWorksheet.Cells[i, 2].Value = listdata.ElementAt(k).Ma;
                        excelWorksheet.Cells[i, 3].Value = listdata.ElementAt(k).Tenthietbi;
                        excelWorksheet.Cells[i, 4].Value = listdata.ElementAt(k).Sohieu;
                        excelWorksheet.Cells[i, 5].Value = listdata.ElementAt(k).Matscd;
                        excelWorksheet.Cells[i, 6].Value = listdata.ElementAt(k).Ngayquyetdinh.ToString("hh:mm tt dd/MM/yyyy");
                        excelWorksheet.Cells[i, 7].Value = listdata.ElementAt(k).Tieutu;
                        excelWorksheet.Cells[i, 8].Value = listdata.ElementAt(k).Trungtu;
                        excelWorksheet.Cells[i, 9].Value = listdata.ElementAt(k).Daitu;
                        k++;
                    }
                    string location = HostingEnvironment.MapPath("/excel/CDVT/download");
                    excelPackage.SaveAs(new FileInfo(location + "/BaoCaoTrungTu.xlsx"));
                }

            }

        }
    }

    public class TrungTuReport
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string Ma { get; set; }
        public string Tenthietbi { get; set; }
        public string Sohieu { get; set; }
        public string Matscd { get; set; }
        public DateTime Ngayquyetdinh { get; set; }
        public int Tieutu { get; set; }
        public int Trungtu { get; set; }
        public int Daitu { get; set; }


    }

}