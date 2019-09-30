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
            if (!NgayQuyetDinh.Equals(""))
            {
                string[] fixDate1 = NgayQuyetDinh.Split('/');
                dateQDFixed = fixDate1[1] + "/" + fixDate1[0] + "/" + fixDate1[2];
                if (!NgayQuyetDinh.Equals("")) query += "q.NgayQuyetDinh = @NgayQD AND ";
            }
            if (!NgayChamDut.Equals(""))
            {
                string[] fixDate2 = NgayChamDut.Split('/');
                dateCDFixed = fixDate2[1] + "/" + fixDate2[0] + "/" + fixDate2[2];
                if (!NgayChamDut.Equals("")) query += "cd.NgayChamDut = @NgayCD AND ";

            }
            if (!SoQuyetDinh.Equals(""))
            {
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
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;

            string query = "select q.SoQuyetDinh, nv.MaNV, nv.Ten, cd.LoaiChamDut, cd.NgayChamDut " +
                "from QuyetDinh q inner join ChamDut_NhanVien cd " +
                "on q.MaQuyetDinh = cd.MaQuyetDinh inner join NhanVien nv " +
                "on cd.MaNV = nv.MaNV where cd.LoaiChamDut is not null and q.SoQuyetDinh != '' and q.MaQuyetDinh = " + id;
            List<QuyetDinhLink> list = db.Database.SqlQuery<QuyetDinhLink>(query).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        [Route("deleteDetail")]
        [HttpPost]
        public JsonResult DidDetailDel(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;
            //using (DbContextTransaction dbct = db.Database.BeginTransaction())
            //{
            //    try
            //    {
            string query1 = "delete from ChamDut_NhanVien where MaQuyetDinh = " + id;
            db.Database.ExecuteSqlCommand(query1);
            string query2 = "delete from QuyetDinh where MaQuyetDinh = " + id;
            db.Database.ExecuteSqlCommand(query2);
            //db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);

            //    }
            //    catch (Exception)
            //    {
            //        dbct.Rollback();
            //        string output = "";
            //        if (output == "")
            //            output += "Xóa không thành công";
            //        Response.Write(output);
            //        return Json("", JsonRequestBehavior.AllowGet);
            //    }

            //}
        }

        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpGet]
        public ActionResult NotYet()
        {
            return View("/Views/TCLD/Shutdown/NotYet.cshtml");
        }


        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpPost]
        public ActionResult NotYetList(string MaQuyetDinh, string NgayChamDut)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();

            db.Configuration.LazyLoadingEnabled = false;
            string dateFix = "";
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string query = "select q.MaQuyetDinh, q.SoQuyetDinh, q.NgayQuyetDinh, cd.LoaiChamDut, cd.NgayChamDut from QuyetDinh q,ChamDut_NhanVien cd " +
                "where q.MaQuyetDinh = cd.MaQuyetDinh and cd.LoaiChamDut is not null and q.SoQuyetDinh = '' and ";
            if (!MaQuyetDinh.Equals(""))
            {

                if (!MaQuyetDinh.Equals("")) query += "q.MaQuyetDinh = @MaQD AND ";

            }
            if (!NgayChamDut.Equals(""))
            {
                string[] fix = NgayChamDut.Split('/');
                dateFix = fix[1] + "/" + fix[0] + "/" + fix[2];
                if (!NgayChamDut.Equals("")) query += "cd.NgayChamDut = @NgayCD AND ";
            }
            query = query.Substring(0, query.Length - 5);

            List<QuyetDinhLink> searchList = db.Database.SqlQuery<QuyetDinhLink>(query,
                new SqlParameter("MaQD", MaQuyetDinh),
                new SqlParameter("NgayCD", dateFix)
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


        [Route("NotYetDetail")]
        [HttpPost]
        public JsonResult NotYetDetail(string id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;

            string query = "select  nv.MaNV, nv.Ten, cd.LoaiChamDut, cd.NgayChamDut " +
                "from QuyetDinh q inner join ChamDut_NhanVien cd on q.MaQuyetDinh = cd.MaQuyetDinh inner join NhanVien nv on cd.MaNV = nv.MaNV where q.SoQuyetDinh = '' and q.MaQuyetDinh = " + id;
            List<QuyetDinhLink> list = db.Database.SqlQuery<QuyetDinhLink>(query).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [Route("UpdateSoQD")]
        [HttpPost]
        public JsonResult UpdateSoQD(string id, string SoQD)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;
            string query = "update QuyetDinh set SoQuyetDinh = " + SoQD + ", NgayQuyetDinh = GETDATE() where MaQuyetDinh = " + id;
            db.Database.ExecuteSqlCommand(query);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}