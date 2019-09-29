using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.TCLD
{

    public class ShutDownController : Controller
    {
        public class QuyetDinhLink : QuyetDinh
        {
            public string LoaiChamDut { get; set; }

            public Nullable<DateTime> NgayChamDut { get; set; }

            public string Ten { get; set; }
            public string MaNV { get; set; }
        }
        // GET: ShutDown
        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut")]
        [HttpGet]
        public ActionResult Did()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Shutdown/Did.cshtml");
        }

        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut")]
        [HttpPost]
        public ActionResult DidList(string NgayQuyetDinh, string SoQuyetDinh, string NgayChamDut)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            db.Configuration.LazyLoadingEnabled = false;

            string dateQDFixed = "";
            string dateCDFixed = "";
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string query = "  select q.*, cd.MaNV,cd.LoaiChamDut, cd.NgayChamDut from QuyetDinh q inner join ChamDut_NhanVien cd " +
                "on q.MaQuyetDinh = cd.MaQuyetDinh where cd.LoaiChamDut is not null and q.SoQuyetDinh != '' and ";
            if (!NgayQuyetDinh.Equals("") || !SoQuyetDinh.Equals("") || !NgayChamDut.Equals(""))
            {
                string[] fixDate1 = NgayQuyetDinh.Split('/');
                dateQDFixed = fixDate1[1] + "/" + fixDate1[0] + "/" + fixDate1[2];
                string[] fixDate2 = NgayChamDut.Split('/');
                dateCDFixed = fixDate2[1] + "/" + fixDate2[0] + "/" + fixDate2[2];
                if (!NgayQuyetDinh.Equals("")) query += "q.NgayQuyetDinh = @NgayQD AND ";
                if (!NgayChamDut.Equals("")) query += "cd.NgayChamDut = @NgayCD AND ";
                if (!SoQuyetDinh.Equals("")) query += "q.SoQuyetDinh LIKE @SoQD AND ";
            }
            query = query.Substring(0, query.Length - 5);

            List<QuyetDinhLink> searchList = db.Database.SqlQuery<QuyetDinhLink>(query,
                new SqlParameter("NgayQD", dateQDFixed),
                new SqlParameter("NgayCD", dateCDFixed),
                new SqlParameter("SoQD", '%' + SoQuyetDinh + '%')
                ).ToList();

            //List<QuyetDinhLink> searchList = db.Database.SqlQuery<QuyetDinhLink>("select q.MaQuyetDinh, q.SoQuyetDinh, q.NgayQuyetDinh, cd.LoaiChamDut, cd.NgayChamDut from QuyetDinh q,ChamDut_NhanVien cd where q.MaQuyetDinh = cd.MaQuyetDinh and cd.LoaiChamDut is not null").ToList();
            Console.WriteLine();

            int totalrows = searchList.Count;
            int totalrowsafterfiltering = searchList.Count;
            //sorting
            searchList = searchList.OrderBy(sortColumnName + " " + sortDirection).ToList<QuyetDinhLink>();
            //paging
            searchList = searchList.Skip(start).Take(length).ToList<QuyetDinhLink>();

            return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }

        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut-chi-tiet")]
        [HttpPost]
        public JsonResult DidListDetail(string id)
        {
            //string query = ""
            return Json("", JsonRequestBehavior.AllowGet);

        }


        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpGet]
        public ActionResult NotYet()
        {
            return View("/Views/TCLD/Shutdown/NotYet.cshtml");
        }


        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpPost]
        public ActionResult NotYetList(string MaQuyetDinh, string SoQuyetDinh)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            db.Configuration.LazyLoadingEnabled = false;

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string query = "select q.MaQuyetDinh, q.SoQuyetDinh, q.NgayQuyetDinh, cd.LoaiChamDut, cd.NgayChamDut from QuyetDinh q,ChamDut_NhanVien cd " +
                "where q.MaQuyetDinh = cd.MaQuyetDinh and cd.LoaiChamDut is not null and q.SoQuyetDinh = '' and ";
            if (!MaQuyetDinh.Equals("") || !SoQuyetDinh.Equals(""))
            {
                if (!MaQuyetDinh.Equals("")) query += "q.MaQuyetDinh LIKE @MaQD AND ";
                if (!SoQuyetDinh.Equals("")) query += "q.SoQuyetDinh LIKE @SoQD AND ";
            }
            query = query.Substring(0, query.Length - 5);

            List<QuyetDinhLink> searchList = db.Database.SqlQuery<QuyetDinhLink>(query,
                new SqlParameter("MaQD", '%' + MaQuyetDinh + '%'),
                new SqlParameter("SoQD", '%' + SoQuyetDinh + '%')
                ).ToList();

            //List<QuyetDinhLink> searchList = db.Database.SqlQuery<QuyetDinhLink>("select q.MaQuyetDinh, q.SoQuyetDinh, q.NgayQuyetDinh, cd.LoaiChamDut, cd.NgayChamDut from QuyetDinh q,ChamDut_NhanVien cd where q.MaQuyetDinh = cd.MaQuyetDinh and cd.LoaiChamDut is not null").ToList();
            Console.WriteLine();

            int totalrows = searchList.Count;
            int totalrowsafterfiltering = searchList.Count;
            //sorting
            searchList = searchList.OrderBy(sortColumnName + " " + sortDirection).ToList<QuyetDinhLink>();
            //paging
            searchList = searchList.Skip(start).Take(length).ToList<QuyetDinhLink>();

            return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        }
        //[Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut-chi-tiet")]
        //[HttpGet]
        //public ActionResult NotYetDetailView()
        //{
        //    return View("/Views/TCLD/Shutdown/NotYetDetail.cshtml");
        //}



        //[Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut-chi-tiet")]
        //[HttpPost]
        //public ActionResult NotYetDetail(string detail)
        //{
        //    QUANGHANHABCEntities db = new QUANGHANHABCEntities();

        //    db.Configuration.LazyLoadingEnabled = false;

        //    int start = Convert.ToInt32(Request["start"]);
        //    int length = Convert.ToInt32(Request["length"]);
        //    string searchValue = Request["search[value]"];
        //    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
        //    string sortDirection = Request["order[0][dir]"];
        //    //string query = " select cd.LoaiChamDut, cd.NgayChamDut, nv.Ten, nv.MaNV " +
        //    //    "from QuyetDinh q inner" +
        //    //    "  join ChamDut_NhanVien cd on q.MaQuyetDinh = cd.MaQuyetDinh " +
        //    //    "inner join NhanVien nv on cd.MaNV = nv.MaNV where q.SoQuyetDinh = '' and q.MaQuyetDinh =5";
        //    //query = query.Substring(0, query.Length - 5);

        //    List<QuyetDinhLink> searchList = db.Database.SqlQuery<QuyetDinhLink>("select cd.LoaiChamDut, cd.NgayChamDut, nv.Ten, nv.MaNV " +
        //        "from QuyetDinh q inner join ChamDut_NhanVien cd on q.MaQuyetDinh = cd.MaQuyetDinh " +
        //        "inner join NhanVien nv on cd.MaNV = nv.MaNV where q.SoQuyetDinh = '' and q.MaQuyetDinh = "+ detail).ToList();

        //    Console.WriteLine();

        //    int totalrows = searchList.Count;
        //    int totalrowsafterfiltering = searchList.Count;
        //    //sorting
        //    //searchList = searchList.OrderBy(sortColumnName + " " + sortDirection).ToList<QuyetDinhLink>();
        //    //paging
        //    searchList = searchList.Skip(start).Take(length).ToList<QuyetDinhLink>();

        //    return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        //}
    }
}