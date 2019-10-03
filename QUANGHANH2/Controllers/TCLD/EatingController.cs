using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class EatingController : Controller
    {
        // GET: Eating
        [Route("phong-tcld/dang-ky-suat-an")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Eating/Register.cshtml");
        }
        [HttpGet]
        public ActionResult searchSuatAn(String data, DateTime time)
        {
            dynamic js = JObject.Parse(data);
            String mapb1 = js.mapb;
            String tenpb1 = js.tenpb;

            DateTime now = time;
            now = now.AddDays(1);
            DateTime dayStart;
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayStart = now;
                    break;
                case DayOfWeek.Tuesday:
                    dayStart = now.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    dayStart = now.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    dayStart = now.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    dayStart = now.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    dayStart = now.AddDays(-5);
                    break;
                default:
                    dayStart = now.AddDays(-6);
                    break;

            }
            DateTime Tuesday = dayStart.AddDays(1);
            DateTime Wednesday = dayStart.AddDays(2);
            DateTime Thursday = dayStart.AddDays(3);
            DateTime Friday = dayStart.AddDays(4);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                var t2 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id

                          where p1.date_regs.Day == dayStart.Day & p1.date_regs.Month == dayStart.Month & p1.date_regs.Year == dayStart.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t2 = p1.num_regs_plan,
                              t2tt = p1.num_regs

                          }).Distinct().ToList();

                var t3 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Tuesday.Day & p1.date_regs.Month == Tuesday.Month & p1.date_regs.Year == Tuesday.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t3 = p1.num_regs_plan,
                              t3tt = p1.num_regs
                          }).Distinct().ToList();
                var t4 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Wednesday.Day & p1.date_regs.Month == Wednesday.Month & p1.date_regs.Year == Wednesday.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t4 = p1.num_regs_plan,
                              t4tt = p1.num_regs
                          }).Distinct().ToList();


                var t5 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Thursday.Day & p1.date_regs.Month == Thursday.Month & p1.date_regs.Year == Thursday.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t5 = p1.num_regs_plan,
                              t5tt = p1.num_regs
                          }).Distinct().ToList();
                var t6 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Friday.Day & p1.date_regs.Month == Friday.Month & p1.date_regs.Year == Friday.Year

                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t6 = p1.num_regs_plan,
                              t6tt = p1.num_regs
                          }).Distinct().ToList();




                var mydata = (from a in t2
                              join a1 in t3 on a.mapb equals a1.mapb
                              join a2 in t4 on a1.mapb equals a2.mapb
                              join a3 in t5 on a2.mapb equals a3.mapb
                              join a4 in t6 on a3.mapb equals a4.mapb
                              where a.mapb.Contains(mapb1.ToUpper())
                                  & a.tenpb.Contains(tenpb1.ToUpper())

                              select
                            new
                            {
                                mapb =
                                a.mapb,
                                tenpb =
                                a.tenpb,
                                t2 =
                                a.t2,
                                t2tt = a.t2tt,
                                t3 =
                                a1.t3,
                                t3tt = a1.t3tt,
                                t4 =
                                a2.t4,
                                t4tt = a2.t4tt,
                                t5 =
                                a3.t5,
                                t5tt = a3.t5tt,
                                t6 =
                                a4.t6,
                                t6tt = a4.t6tt,
                                tong = a.t2 + a1.t3 + a2.t4 + a3.t5 + a4.t6,
                                tongtt = a.t2tt + a1.t3tt + a2.t4tt + a3.t5tt + a4.t6tt,
                                ngay = dayStart
                            }
                              ).ToList();


                return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);
            }
        }
        // display suat an
        [HttpGet]
        public ActionResult getDataSuatAn(DateTime time)
        {

            DateTime now = time;
            now = now.AddDays(1);
            DateTime dayStart;
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayStart = now;
                    break;
                case DayOfWeek.Tuesday:
                    dayStart = now.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    dayStart = now.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    dayStart = now.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    dayStart = now.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    dayStart = now.AddDays(-5);
                    break;
                default:
                    dayStart = now.AddDays(-6);
                    break;

            }
            DateTime Tuesday = dayStart.AddDays(1);
            DateTime Wednesday = dayStart.AddDays(2);
            DateTime Thursday = dayStart.AddDays(3);
            DateTime Friday = dayStart.AddDays(4);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {


                var t2 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id

                          where p1.date_regs.Day == dayStart.Day & p1.date_regs.Month == dayStart.Month & p1.date_regs.Year == dayStart.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t2 = p1.num_regs_plan,
                              t2tt = p1.num_regs

                          }).Distinct().ToList();

                var t3 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Tuesday.Day & p1.date_regs.Month == Tuesday.Month & p1.date_regs.Year == Tuesday.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t3 = p1.num_regs_plan,
                              t3tt = p1.num_regs
                          }).Distinct().ToList();
                var t4 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Wednesday.Day & p1.date_regs.Month == Wednesday.Month & p1.date_regs.Year == Wednesday.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t4 = p1.num_regs_plan,
                              t4tt = p1.num_regs
                          }).Distinct().ToList();


                var t5 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Thursday.Day & p1.date_regs.Month == Thursday.Month & p1.date_regs.Year == Thursday.Year
                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t5 = p1.num_regs_plan,
                              t5tt = p1.num_regs
                          }).Distinct().ToList();
                var t6 = (from p in db.Departments
                          join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                          where p1.date_regs.Day == Friday.Day & p1.date_regs.Month == Friday.Month & p1.date_regs.Year == Friday.Year

                          select new
                          {
                              id = p1.id,
                              mapb = p.department_id,
                              tenpb = p.department_name,
                              t6 = p1.num_regs_plan,
                              t6tt = p1.num_regs
                          }).Distinct().ToList();




                var mydata = (from a in t2
                              join a1 in t3 on a.mapb equals a1.mapb
                              join a2 in t4 on a1.mapb equals a2.mapb
                              join a3 in t5 on a2.mapb equals a3.mapb
                              join a4 in t6 on a3.mapb equals a4.mapb


                              select
                            new
                            {
                                mapb =
                                a.mapb,
                                tenpb =
                                a.tenpb,
                                t2 =
                                a.t2,
                                t2tt = a.t2tt,
                                t3 =
                                a1.t3,
                                t3tt = a1.t3tt,
                                t4 =
                                a2.t4,
                                t4tt = a2.t4tt,
                                t5 =
                                a3.t5,
                                t5tt = a3.t5tt,
                                t6 =
                                a4.t6,
                                t6tt = a4.t6tt,
                                tong = a.t2 + a1.t3 + a2.t4 + a3.t5 + a4.t6,
                                tongtt = a.t2tt + a1.t3tt + a2.t4tt + a3.t5tt + a4.t6tt,
                                ngay = dayStart
                            }
                              ).ToList();
                return Json(new { success = true, data = mydata, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

            }

        }


        [HttpPost]
        public ActionResult ExportExcel(DateTime time)
        {

            DateTime now = time;
            now = now.AddDays(1);
            DateTime dayStart;
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayStart = now;
                    break;
                case DayOfWeek.Tuesday:
                    dayStart = now.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    dayStart = now.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    dayStart = now.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    dayStart = now.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    dayStart = now.AddDays(-5);
                    break;
                default:
                    dayStart = now.AddDays(-6);
                    break;

            }
            DateTime Tuesday = dayStart.AddDays(1);
            DateTime Wednesday = dayStart.AddDays(2);
            DateTime Thursday = dayStart.AddDays(3);
            DateTime Friday = dayStart.AddDays(4);
            string path = HostingEnvironment.MapPath("/excel/TCLD/suat-an/suat-an.xlsx");

            string saveAsPath = ("/excel/TCLD/download/suat-an.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    var t2 = (from p in db.Departments
                              join p1 in db.MealRegistrations on p.department_id equals p1.department_id

                              where p1.date_regs.Day == dayStart.Day & p1.date_regs.Month == dayStart.Month & p1.date_regs.Year == dayStart.Year
                              select new
                              {
                                  id = p1.id,
                                  mapb = p.department_id,
                                  tenpb = p.department_name,
                                  t2 = p1.num_regs_plan,
                                  t2tt = p1.num_regs

                              }).Distinct().ToList();

                    var t3 = (from p in db.Departments
                              join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                              where p1.date_regs.Day == Tuesday.Day & p1.date_regs.Month == Tuesday.Month & p1.date_regs.Year == Tuesday.Year
                              select new
                              {
                                  id = p1.id,
                                  mapb = p.department_id,
                                  tenpb = p.department_name,
                                  t3 = p1.num_regs_plan,
                                  t3tt = p1.num_regs
                              }).Distinct().ToList();
                    var t4 = (from p in db.Departments
                              join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                              where p1.date_regs.Day == Wednesday.Day & p1.date_regs.Month == Wednesday.Month & p1.date_regs.Year == Wednesday.Year
                              select new
                              {
                                  id = p1.id,
                                  mapb = p.department_id,
                                  tenpb = p.department_name,
                                  t4 = p1.num_regs_plan,
                                  t4tt = p1.num_regs
                              }).Distinct().ToList();


                    var t5 = (from p in db.Departments
                              join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                              where p1.date_regs.Day == Thursday.Day & p1.date_regs.Month == Thursday.Month & p1.date_regs.Year == Thursday.Year
                              select new
                              {
                                  id = p1.id,
                                  mapb = p.department_id,
                                  tenpb = p.department_name,
                                  t5 = p1.num_regs_plan,
                                  t5tt = p1.num_regs
                              }).Distinct().ToList();
                    var t6 = (from p in db.Departments
                              join p1 in db.MealRegistrations on p.department_id equals p1.department_id
                              where p1.date_regs.Day == Friday.Day & p1.date_regs.Month == Friday.Month & p1.date_regs.Year == Friday.Year

                              select new
                              {
                                  id = p1.id,
                                  mapb = p.department_id,
                                  tenpb = p.department_name,
                                  t6 = p1.num_regs_plan,
                                  t6tt = p1.num_regs
                              }).Distinct().ToList();




                    var mydata = (from a in t2
                                  join a1 in t3 on a.mapb equals a1.mapb
                                  join a2 in t4 on a1.mapb equals a2.mapb
                                  join a3 in t5 on a2.mapb equals a3.mapb
                                  join a4 in t6 on a3.mapb equals a4.mapb


                                  select
                                new
                                {
                                    mapb =
                                    a.mapb,
                                    tenpb =
                                    a.tenpb,
                                    t2 =
                                    a.t2,
                                    t2tt = a.t2tt,
                                    t3 =
                                    a1.t3,
                                    t3tt = a1.t3tt,
                                    t4 =
                                    a2.t4,
                                    t4tt = a2.t4tt,
                                    t5 =
                                    a3.t5,
                                    t5tt = a3.t5tt,
                                    t6 =
                                    a4.t6,
                                    t6tt = a4.t6tt,
                                    tong = a.t2 + a1.t3 + a2.t4 + a3.t5 + a4.t6,
                                    tongtt = a.t2tt + a1.t3tt + a2.t4tt + a3.t5tt + a4.t6tt,
                                    ngay = dayStart
                                }
                                  ).ToList();
                    int index = 4;
                    foreach (var item in mydata)
                    {
                        excelWorksheet.Cells[index, 1].Value = item.mapb;
                        excelWorksheet.Cells[index, 2].Value = item.tenpb;
                        excelWorksheet.Cells[index, 3].Value = item.t2;
                        excelWorksheet.Cells[index, 4].Value = item.t2tt;
                        excelWorksheet.Cells[index, 5].Value = item.t3;
                        excelWorksheet.Cells[index, 6].Value = item.t3tt;
                        excelWorksheet.Cells[index, 7].Value = item.t4;
                        excelWorksheet.Cells[index, 8].Value = item.t4tt;
                        excelWorksheet.Cells[index, 9].Value = item.t5;
                        excelWorksheet.Cells[index, 10].Value = item.t5tt;
                        excelWorksheet.Cells[index, 11].Value = item.t6;
                        excelWorksheet.Cells[index, 12].Value = item.t6tt;
                        excelWorksheet.Cells[index, 13].Value = item.tong;
                        excelWorksheet.Cells[index, 14].Value = item.tongtt;
                        index++;

                    }


                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }

            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);

        }
    }
}