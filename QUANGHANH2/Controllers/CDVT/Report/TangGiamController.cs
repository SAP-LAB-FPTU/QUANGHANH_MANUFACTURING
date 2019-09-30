using OfficeOpenXml;
using OfficeOpenXml.Style;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT.Report
{
    public class TangGiamController : Controller
    {
        /*a*/
        [Route("phong-cdvt/bao-cao/tang-giam")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {
            Wherecondition(type, date, month, quarter, year);
            List<content> content = new List<content>();
            int tangbag = 0;int giambag = 0;
            using (QUANGHANHABCEntities db= new QUANGHANHABCEntities())
            {
                var nhom = db.Database.SqlQuery<CaName>("select ec.Equipment_category_name as MaNhom from Equipment e,Equipment_category ec where e.Equipment_category_id=ec.Equipment_category_id group by ec.Equipment_category_name").ToList();
                foreach(var item in nhom)
                {
                    if(ViewBag.ContentReportTang.Count > 0 || ViewBag.ContentReportGiam.Count > 0)
                    {
                        string find = item.MaNhom;
                        int tang = 0, giam = 0, Thang = 0, Nam = 0;
                        string MaNhom = ""; string MaHieu = ""; DateTime usedDay = DateTime.Now;
                        foreach (var item1 in ViewBag.ContentReportTang)
                        {
                            if (find.Equals(item1.MaNhom))
                            {
                                tang++;
                                tangbag++;
                                MaNhom = item1.MaNhom; MaHieu = item1.MaHieu; usedDay = item1.usedDay; Thang = item1.Thang; Nam = item1.Nam;
                            }
                            
                        }
                        foreach (var item1 in ViewBag.ContentReportGiam)
                        {
                            if (find.Equals(item1.MaNhom))
                            {
                                giam++;
                                giambag++;
                                MaNhom = item1.MaNhom; MaHieu = item1.MaHieu; usedDay = item1.usedDay; Thang = item1.Thang; Nam = item1.Nam;
                            }
                            
                        }
                        if (!String.IsNullOrEmpty(MaNhom))
                        {
                            content.Add(new content
                            {
                                Thang = Thang,
                                Nam = Nam,
                                MaNhom = MaNhom,
                                MaHieu = MaHieu,
                                usedDay = usedDay.Date,
                                Tang = tang,
                                Giam = giam
                            });
                        }
                    }
                }
                db.SaveChanges();
            }
            ViewBag.Tang = tangbag;
            ViewBag.Giam = giambag;
            ViewBag.content = content;
            return View("/Views/CDVT/Report/TangGiam.cshtml");
        }
        private void Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string queryT = "";
            string queryG = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                queryT = "select MONTH(e.date_import) as Thang,YEAR(e.date_import) as Nam, ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay from Equipment e," +
                    "Equipment_category ec where e.Equipment_category_id=ec.Equipment_category_id and " +
                    " e.date_import = '"+ngay+"'";
                queryG = "select MONTH(do.date_created) as Thang,YEAR(do.date_created) as Nam,ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay" +
                            " from Documentary do,Documentary_liquidation_details dl,Equipment e,Equipment_category ec " +
                            " where do.documentary_code = dl.documentary_id and e.equipmentId = dl.equipmentId and e.Equipment_category_id = ec.Equipment_category_id " +
                            " and do.date_created = '"+ngay+"'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                queryT = "select MONTH(e.date_import) as Thang,YEAR(e.date_import) as Nam, ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay from Equipment e," +
                    "Equipment_category ec where e.Equipment_category_id=ec.Equipment_category_id and " +
                    " e.date_import = '" + ngay + "'";
                queryG = "select MONTH(do.date_created) as Thang,YEAR(do.date_created) as Nam,ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay" +
                            " from Documentary do,Documentary_liquidation_details dl,Equipment e,Equipment_category ec " +
                            " where do.documentary_code = dl.documentary_id and e.equipmentId = dl.equipmentId and e.Equipment_category_id = ec.Equipment_category_id " +
                            " and do.date_created = '" + ngay + "'";
                ViewBag.now = date;
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                queryT = "select MONTH(e.date_import) as Thang,YEAR(e.date_import) as Nam, ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay " +
                            " from Equipment e,Equipment_category ec " +
                            " where e.Equipment_category_id = ec.Equipment_category_id " +
                            " and MONTH(e.date_import) = '"+thang+ "' and YEAR(e.date_import) = '"+nam+"'";
                queryG = "select MONTH(do.date_created) as Thang,YEAR(do.date_created) as Nam,ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay" +
                            " from Documentary do,Documentary_liquidation_details dl,Equipment e,Equipment_category ec " +
                            " where do.documentary_code = dl.documentary_id and e.equipmentId = dl.equipmentId and e.Equipment_category_id = ec.Equipment_category_id " +
                            " and MONTH(do.date_created) = '"+thang+"' and YEAR(do.date_created) = '"+nam+"'";
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
                queryT = "select MONTH(e.date_import) as Thang,YEAR(e.date_import) as Nam, ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay " +
                            " from Equipment e,Equipment_category ec " +
                            " where e.Equipment_category_id = ec.Equipment_category_id " +
                            " and MONTH(e.date_import) in "+quy+" and YEAR(e.date_import) = '"+nam+"'";
                queryG = "select MONTH(do.date_created) as Thang,YEAR(do.date_created) as Nam,ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay " +
                            " from Documentary do,Documentary_liquidation_details dl,Equipment e,Equipment_category ec " +
                            " where do.documentary_code = dl.documentary_id and e.equipmentId = dl.equipmentId and e.Equipment_category_id = ec.Equipment_category_id " +
                            " and MONTH(do.date_created) in "+quy+" and YEAR(do.date_created) = '"+nam+"'";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                queryT = "select MONTH(e.date_import) as Thang,YEAR(e.date_import) as Nam, ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay " +
                            " from Equipment e,Equipment_category ec " +
                            " where e.Equipment_category_id = ec.Equipment_category_id " +
                            " and YEAR(e.date_import) = '" + nam + "'";
                queryG = "select MONTH(do.date_created) as Thang,YEAR(do.date_created) as Nam,ec.Equipment_category_name as MaNhom,e.mark_code as MaHieu,e.usedDay " +
                            " from Documentary do,Documentary_liquidation_details dl,Equipment e,Equipment_category ec " +
                            " where do.documentary_code = dl.documentary_id and e.equipmentId = dl.equipmentId and e.Equipment_category_id = ec.Equipment_category_id " +
                            " and YEAR(do.date_created) = '" + nam + "'";
            }

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.ContentReportTang = db.Database.SqlQuery<contentreportTang>(queryT).ToList();
                ViewBag.ContentReportGiam = db.Database.SqlQuery<contentreportGiam>(queryG).ToList();
            }
        }
        [HttpPost]
        [Route("phong-cdvt/bao-cao/tang-giam/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/Tang-Giam.xlsx");
            string saveAsPath = ("/excel/CDVT/download/Tang-Giam.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Wherecondition(type, date, month, quarter, year);
                    List<content> content = new List<content>();
                    int tangbag = 0; int giambag = 0;
                        var nhom = db.Database.SqlQuery<CaName>("select ec.Equipment_category_name as MaNhom from Equipment e,Equipment_category ec where e.Equipment_category_id=ec.Equipment_category_id group by ec.Equipment_category_name").ToList();
                        foreach (var item in nhom)
                        {
                            if (ViewBag.ContentReportTang.Count > 0 || ViewBag.ContentReportGiam.Count > 0)
                            {
                                string find = item.MaNhom;
                                int tang = 0, giam = 0, Thang = 0, Nam = 0;
                                string MaNhom = ""; string MaHieu = ""; DateTime usedDay = DateTime.Now;
                                foreach (var item1 in ViewBag.ContentReportTang)
                                {
                                    if (find.Equals(item1.MaNhom))
                                    {
                                        tang++;
                                        tangbag++;
                                        MaNhom = item1.MaNhom; MaHieu = item1.MaHieu; usedDay = item1.usedDay; Thang = item1.Thang; Nam = item1.Nam;
                                    }

                                }
                                foreach (var item1 in ViewBag.ContentReportGiam)
                                {
                                    if (find.Equals(item1.MaNhom))
                                    {
                                        giam++;
                                        giambag++;
                                        MaNhom = item1.MaNhom; MaHieu = item1.MaHieu; usedDay = item1.usedDay; Thang = item1.Thang; Nam = item1.Nam;
                                    }

                                }
                                if (!String.IsNullOrEmpty(MaNhom))
                                {
                                    content.Add(new content
                                    {
                                        Thang = Thang,
                                        Nam = Nam,
                                        MaNhom = MaNhom,
                                        MaHieu = MaHieu,
                                        usedDay = usedDay.Date,
                                        Tang = tang,
                                        Giam = giam
                                    });
                                }
                            }
                        }
                    int k = 3;
                    for (int i = 0; i < content.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = content.ElementAt(i).Thang + "/" + content.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = content.ElementAt(i).MaNhom;
                        excelWorksheet.Cells[k, 3].Value = content.ElementAt(i).MaHieu;
                        excelWorksheet.Cells[k, 4].Value = content.ElementAt(i).usedDay;
                        excelWorksheet.Cells[k, 5].Value = content.ElementAt(i).Tang;
                        excelWorksheet.Cells[k, 6].Value = content.ElementAt(i).Giam;
                        k++;
                    }
                    excelWorksheet.Cells[k, 4].Value = "Tổng";
                    excelWorksheet.Cells[k, 5].Value = tangbag;
                    excelWorksheet.Cells[k, 6].Value = giambag;
                    excelWorksheet.Cells[k, 4].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 4].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 6].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }
    public class contentreportTang
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaNhom { get; set; }
        public string MaHieu { get; set; }
        public DateTime usedDay { get; set; }
    }
    public class contentreportGiam
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaNhom { get; set; }
        public string MaHieu { get; set; }
        public DateTime usedDay { get; set; }
    }
    public class CaName
    {
        public string MaNhom { get; set; }
    }
    public class content
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaNhom { get; set; }
        public string MaHieu { get; set; }
        public DateTime usedDay { get; set; }
        public int Tang { get; set; }
        public int Giam { get; set; }
    }
}