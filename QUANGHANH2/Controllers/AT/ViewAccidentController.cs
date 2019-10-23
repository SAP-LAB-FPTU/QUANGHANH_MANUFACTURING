using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.AT
{
    public class ViewAccidentController : Controller
    {
        [Auther(RightID = "007")]
        [Route("phong-an-toan/danh-sach-tai-nan")]
        public ActionResult DanhSachBaoCao()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<NhanVien> listNhanVien = db.NhanViens.ToList<NhanVien>();
            ViewBag.listNhanVien = listNhanVien;
            return View("/Views/AT/ViewAccident.cshtml");
        }
        [Route("phong-an-toan/danh-sach-tai-nan/search-accident")]
        [HttpPost]
        public ActionResult SearchAccident(string employeeID, string EmployeeName, string timeFrom, string timeTo)
        {
            try
            {

                if (timeFrom.Trim() == "")
                {
                    timeFrom = "01/01/1900";
                }
                DateTime timeF = DateTime.ParseExact(timeFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //validate timeTo when input blank
                DateTime timeT;
                if (timeTo.Trim() == "")
                {
                    timeT = DateTime.Now;
                }
                else
                {
                    timeT = DateTime.ParseExact(timeTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    List<TaiNanDB> listTainan = (from tainan in db.TaiNans
                                                 join nhanvien in db.NhanViens on tainan.MaNV equals nhanvien.MaNV
                                                 join depart in db.Departments on nhanvien.MaPhongBan equals depart.department_id
                                                 select new TaiNanDB
                                                 {
                                                     MaTaiNan = tainan.MaTaiNan,
                                                     MaNV = tainan.MaNV,
                                                     Ten = nhanvien.Ten,
                                                     department_name = depart.department_name,
                                                     LyDo = tainan.LyDo,
                                                     Ca_Name = tainan.Ca == 1 ? "CA 1" : tainan.Ca == 2 ? "CA 2" : "CA 3",
                                                     Ngay = tainan.Ngay,
                                                     Loai = tainan.Loai
                                                 }
                                  ).Where(x => x.MaNV.Contains(employeeID) && x.Ten.Contains(EmployeeName) && x.Ngay >= timeF && x.Ngay <= timeT).ToList();

                    int totalrows = listTainan.Count;
                    int totalrowsafterfiltering = listTainan.Count;
                    listTainan = listTainan.OrderBy(sortColumnName + " " + sortDirection).ToList<TaiNanDB>();
                    listTainan = listTainan.Skip(start).Take(length).ToList<TaiNanDB>();
                    return Json(new { success = true, data = listTainan, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }

    }
}
public class TaiNanDB : TaiNan
{
    public String stringDate { get; set; }
    public string Ten { get; set; }
    public string Ca_Name { get; set; }
    public string department_name { get; set; }

}
public class dsTainan
{
    public int MaTaiNan { get; set; }
    public string MaNV { get; set; }

    public string LyDo { get; set; }
    public Nullable<int> Ca { get; set; }
    public Nullable<DateTime> Ngay { get; set; }
}

