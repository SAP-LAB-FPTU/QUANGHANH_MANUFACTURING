using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using DocumentFormat.OpenXml.Packaging;
using System.Web.Hosting;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Linq.Dynamic;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using static QUANGHANH2.Controllers.TCLD.EmployeesController;
using static QUANGHANHCORE.Controllers.TCLD.TransferController;
using System.IO.Compression;
using System.Net;
using OfficeOpenXml;

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
        [Auther(RightID = "127")]
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut")]
        [HttpGet]
        public ActionResult List()
        {
            List<CongViec> listCongViec = new List<CongViec>();
            List<Department> listPhongBan = new List<Department>();
            //List<DoiChieu_Luong> listBacAndLuong = new List<DoiChieu_Luong>();

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql = "select * from CongViec";
                listCongViec = db.CongViecs.SqlQuery(sql).ToList<CongViec>();

                sql = "select * from Department";
                listPhongBan = db.Departments.SqlQuery(sql).ToList<Department>();

                sql = "select * from DoiChieu_Luong";
                //listBacAndLuong = db.Database.SqlQuery<DoiChieu_Luong>(sql).ToList<DoiChieu_Luong>();

            }
            ViewBag.listCongViec = listCongViec;
            ViewBag.listPhongBan = listPhongBan;
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Shutdown/Process.cshtml");
        }

        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut")]
        [HttpPost]
        public ActionResult Search(string MaNV, string TenNV, string ChucVu, string PhongBan)
        {
            try
            {
                while (MaNV.Contains("  "))
                {
                    MaNV = MaNV.Replace("  ", " ");
                }
                MaNV = MaNV.Trim();
                string[] searchListID = MaNV.Split(' ');
                MaNV = "";
                for (int i = 0; i < searchListID.Length; i++)
                {
                    MaNV += "'" + searchListID[i] + "',";
                }
                MaNV = MaNV.Contains(",") ? MaNV.Substring(0, MaNV.Length - 1) : MaNV;
                MaNV = MaNV == "''" ? "" : MaNV;
                HttpCookie cookie;
                if (HttpContext.Request.Cookies["DanhSachNhanVien"] == null)
                {
                    cookie = new HttpCookie("DanhSachNhanVien");
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    cookie.Value = "[]";
                }
                else
                {
                    cookie = HttpContext.Request.Cookies["DanhSachNhanVien"];
                    cookie.Value = Request["selectList"];
                };

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string query = @"select n.*, t.TenTrangThai, c.TenCongViec from NhanVien n inner join 
                    [TrangThai] t on n.MaTrangThai = t.MaTrangThai join 
                    CongViec c on n.MaCongViec = c.MaCongViec 
                    where n.MaTrangThai = 1 AND ";
                if (!MaNV.Equals("") || !TenNV.Equals("") || !ChucVu.Equals("-1") || !PhongBan.Equals("-1"))
                {
                    if (!MaNV.Equals("")) query += "n.MaNV in (" + MaNV + ") AND ";
                    if (!TenNV.Equals("")) query += "n.Ten LIKE @Ten AND ";
                    if (!ChucVu.Equals("-1")) query += "n.MaCongViec = @ChucVu AND ";
                    if (!PhongBan.Equals("-1")) query += "n.MaPhongBan = @PhongBan AND ";
                }
                query = query.Substring(0, query.Length - 5);
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                db.Configuration.LazyLoadingEnabled = false;
                //bool GioiTinh = true;
                //if (Gender.Equals("true"))
                //{
                //    GioiTinh = true;
                //}
                //else if (Gender.Equals("false"))
                //{
                //    GioiTinh = false;
                //}
                List<NhanVienLink> searchList = db.Database.SqlQuery<NhanVienLink>(query + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("MaNV", MaNV),
                    new SqlParameter("Ten", '%' + TenNV + '%'),
                    new SqlParameter("ChucVu", ChucVu),
                    new SqlParameter("PhongBan", PhongBan)
                    ).ToList();
                int totalrows = db.Database.SqlQuery<int>(query.Replace("n.*, t.TenTrangThai, c.TenCongViec", "count(t.TenTrangThai)"),
                    new SqlParameter("MaNV", MaNV),
                    new SqlParameter("Ten", '%' + TenNV + '%'),
                    new SqlParameter("ChucVu", ChucVu),
                    new SqlParameter("PhongBan", PhongBan)
                    ).FirstOrDefault();
                ViewBag.totalrows = totalrows;
                return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return null;
            }




        }
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut-step2")]
        [HttpPost]
        public ActionResult Step2()
        {
            // MessageBox.Show(Request["selectedList"]);
            string selected;
            HttpCookie cookie;
            if (HttpContext.Request.Cookies["DanhSachNhanVien"] == null)
            {
                return null;
            }
            else
            {
                selected = Request["selectedList"];
                selected = selected.Substring(1, selected.Length - 2);
                selected = selected.Replace("\"", "\'");
            }

            List<NhanVienModel> listNhanVien = new List<NhanVienModel>();
            int totalrows = listNhanVien.Count;
            int totalrowsafterfiltering = listNhanVien.Count;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string sql =
                @"SELECT A.MaNV,A.Ten,B.department_name,C.TenCongViec,C.PhuCap, D.MucBacLuong as BacLuong, D.MucThangLuong as ThangLuong, D.MucLuong as Luong
                 FROM(
                (SELECT * FROM NhanVien where MaNV in (" + selected + @" )) A
                 left OUTER JOIN
                 (SELECT department_id, department_name FROM Department) B on A.MaPhongBan = B.department_id
                 left OUTER JOIN
                 (SELECT MaCongViec, TenCongViec,PhuCap,MaThangLuong FROM CongViec) C on A.MaCongViec = C.MaCongViec
				 left OUTER JOIN
				 (SELECT tl.MaThangLuong,bl.MaBacLuong, mtm.MaBacLuong_ThangLuong_MucLuong ,tl.MucThangLuong,bl.MucBacLuong,mtm.MucLuong 
				 FROM BacLuong_ThangLuong_MucLuong mtm , BacLuong bl, ThangLuong tl WHERE mtm.MaBacLuong=bl.MaBacLuong AND mtm.MaThangLuong=tl.MaThangLuong) D
				 on A.MaBacLuong_ThangLuong_MucLuong=D.MaBacLuong_ThangLuong_MucLuong
				 ) ";
                listNhanVien = db.Database.SqlQuery<NhanVienModel>(sql).ToList<NhanVienModel>();
            }
            return Json(new { success = true, data = listNhanVien, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
        [Auther(RightID = "127")]
        // GET: ShutDown
        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut")]
        [HttpGet]
        public ActionResult Did()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Shutdown/Did.cshtml");
        }
        [Auther(RightID = "127")]
        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut")]
        [HttpPost]
        public ActionResult DidList(string NgayQuyetDinh, string SoQuyetDinh, string NgayChamDut)
        {
            try
            {

                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

                db.Configuration.LazyLoadingEnabled = false;

                string dateQDFixed = "";
                string dateCDFixed = "";
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string query = @" select q.*,cd.NgayChamDut from QuyetDinh q inner join ChamDut_NhanVien cd
                on q.MaQuyetDinh = cd.MaQuyetDinh where cd.LoaiChamDut is not null and q.SoQuyetDinh != ''
				 and ";
                if (!NgayQuyetDinh.Equals(""))
                {
                    string[] fixDate1 = NgayQuyetDinh.ToString().Split('/');
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
                query += @" group by q.MaQuyetDinh, q.SoQuyetDinh, q.NgayQuyetDinh, cd.NgayChamDut";
                List<QuyetDinhLink> searchList = db.Database.SqlQuery<QuyetDinhLink>(query + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("NgayQD", dateQDFixed),
                    new SqlParameter("NgayCD", dateCDFixed),
                    new SqlParameter("SoQD", '%' + SoQuyetDinh + '%')
                    ).ToList();

                int totalrows = db.Database.SqlQuery<int>(query.Replace("q.*,cd.NgayChamDut", "count(cd.NgayChamDut)"),
                    new SqlParameter("NgayQD", dateQDFixed),
                    new SqlParameter("NgayCD", dateCDFixed),
                    new SqlParameter("SoQD", '%' + SoQuyetDinh + '%')
                    ).FirstOrDefault();

                return Json(new { data = searchList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut/check-duplicate-sqd")]
        [HttpPost]
        public ActionResult checkDuplicateSQD()
        {
            string sqd = Request["SoQD"];
            if (sqd != null && sqd != "")
            {
                int result;
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string sql = "select count(SoQuyetDinh) as sqd from QuyetDinh\n" +
                    "where SoQuyetDinh = @SoQD ";
                    result = db.Database.SqlQuery<int>(sql, new SqlParameter("SoQD", sqd)).ToList<int>()[0];
                }
                if (result != 0)
                {
                    return Json(new { success = true, data = true });
                }
                else
                {
                    return Json(new { success = true, data = false });
                }
            }
            return Json(new { success = false, message = "Lỗi" });
        }


        [Route("phong-tcld/quan-ly-nhan-vien/da-xu-ly-cham-dut-chi-tiet")]
        [HttpPost]
        public JsonResult DidListDetail(string id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;

            string query = "select q.SoQuyetDinh, nv.MaNV, nv.Ten, cd.LoaiChamDut, cd.NgayChamDut " +
                "from QuyetDinh q inner join ChamDut_NhanVien cd " +
                "on q.MaQuyetDinh = cd.MaQuyetDinh inner join NhanVien nv " +
                "on cd.MaNV = nv.MaNV where cd.LoaiChamDut is not null and q.SoQuyetDinh != '' and q.MaQuyetDinh = @id";
            List<QuyetDinhLink> list = db.Database.SqlQuery<QuyetDinhLink>(query, new SqlParameter("id", id)).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        [Auther(RightID = "128")]
        [Route("deleteDetail")]
        [HttpPost]
        public JsonResult DidDetailDel(string id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    string query3 = "select cd.* from ChamDut_NhanVien cd inner join NhanVien nv on cd.MaNV = nv.MaNV inner join QuyetDinh q on q.MaQuyetDinh = cd.MaQuyetDinh where cd.MaQuyetDinh = @id";
                    List<ChamDut_NhanVien> list = db.Database.SqlQuery<ChamDut_NhanVien>(query3, new SqlParameter("id", id)).ToList();
                    string listMaNV = "";
                    foreach(var MaNV in list)
                    {
                        listMaNV += "'"+MaNV.MaNV +"'"+ ",";
                    }
                    listMaNV = listMaNV.Substring(0, listMaNV.Length-1);
                    string query4 = "update NhanVien set MaTrangThai = 1 where MaNV in("+ listMaNV + ")";
                    db.Database.ExecuteSqlCommand(query4);

                    string query1 = "delete from ChamDut_NhanVien where MaQuyetDinh = @id";
                    db.Database.ExecuteSqlCommand(query1, new SqlParameter("id", id));
                    string query2 = "delete from QuyetDinh where MaQuyetDinh = @id";
                    db.Database.ExecuteSqlCommand(query2, new SqlParameter("id", id));
                    db.SaveChanges();
                    dbct.Commit();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    dbct.Rollback();
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

            }
        }
        [Auther(RightID = "126")]
        [Route("deleteNotYet")]
        [HttpPost]
        public JsonResult NotYetDelete(string id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    string query3 = "select cd.* from ChamDut_NhanVien cd inner join NhanVien nv on cd.MaNV = nv.MaNV inner join QuyetDinh q on q.MaQuyetDinh = cd.MaQuyetDinh where cd.MaQuyetDinh = @id";
                    List<ChamDut_NhanVien> list = db.Database.SqlQuery<ChamDut_NhanVien>(query3, new SqlParameter("id", id)).ToList();
                    string listMaNV = "";
                    foreach (var MaNV in list)
                    {
                        listMaNV += "'" + MaNV.MaNV + "'" + ",";
                    }
                    listMaNV = listMaNV.Substring(0, listMaNV.Length - 1);
                    string query4 = "update NhanVien set MaTrangThai = 1 where MaNV in(" + listMaNV + ")";
                    db.Database.ExecuteSqlCommand(query4);

                    string query1 = "delete from ChamDut_NhanVien where MaQuyetDinh = @id";
                    db.Database.ExecuteSqlCommand(query1, new SqlParameter("id", id));
                    string query2 = "delete from QuyetDinh where MaQuyetDinh = @id";
                    db.Database.ExecuteSqlCommand(query2, new SqlParameter("id", id));
                    db.SaveChanges();
                    dbct.Commit();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception)
                {
                    dbct.Rollback();
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [Auther(RightID = "124")]
        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpGet]
        public ActionResult NotYet()
        {
            return View("/Views/TCLD/Shutdown/NotYet.cshtml");
        }

        [Auther(RightID = "124")]
        [Route("phong-tcld/quan-ly-nhan-vien/chua-xu-ly-cham-dut")]
        [HttpPost]
        public ActionResult NotYetList(string MaQuyetDinh, string NgayChamDut)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

            db.Configuration.LazyLoadingEnabled = false;
            string dateFix = "";
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string query = "select q.*,cd.NgayChamDut from QuyetDinh q,ChamDut_NhanVien cd " +
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
            query += @" group by q.MaQuyetDinh, q.SoQuyetDinh, q.NgayQuyetDinh, cd.NgayChamDut";
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
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            db.Configuration.LazyLoadingEnabled = false;

            string query = "select  nv.MaNV, nv.Ten, cd.LoaiChamDut, cd.NgayChamDut " +
                "from QuyetDinh q inner join ChamDut_NhanVien cd on q.MaQuyetDinh = cd.MaQuyetDinh inner join NhanVien nv on cd.MaNV = nv.MaNV where q.SoQuyetDinh = '' and q.MaQuyetDinh = @id";
            List<QuyetDinhLink> list = db.Database.SqlQuery<QuyetDinhLink>(query, new SqlParameter("id", id)).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "125")]
        [Route("UpdateSoQD")]
        [HttpPost]
        public JsonResult UpdateSoQD(string id, string SoQD)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    if (!SoQD.Equals(""))
                    {
                        string query = @"select * from QuyetDinh where SoQuyetDinh = @SoQD";
                        List<QuyetDinh> qdList = db.Database.SqlQuery<QuyetDinh>(query, new SqlParameter("SoQD", SoQD)).ToList();

                        if (qdList.Count > 0)
                        {
                            return Json(new { success = false, message = "Số quyết định trùng" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            int MaQD = Convert.ToInt32(id);
                            QuyetDinh qd = db.QuyetDinhs.Where(x => x.MaQuyetDinh == MaQD).FirstOrDefault();
                            qd.SoQuyetDinh = SoQD;
                            qd.NgayQuyetDinh = System.DateTime.Now.AddDays(2);
                            db.Entry(qd).State = EntityState.Modified;

                            List<string> maNV = db.ChamDut_NhanVien.Where(x => x.MaQuyetDinh == qd.MaQuyetDinh).Select(x => x.MaNV).ToList();
                            foreach (var item in maNV)
                            {
                                var Nv = db.NhanViens.Where(nv => nv.MaNV == item).FirstOrDefault();
                                Nv.MaTrangThai = 2;
                                db.Entry(Nv).State = EntityState.Modified;
                            }

                            db.SaveChanges();
                            dbct.Commit();
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = "Chưa nhập số quyết định" }, JsonRequestBehavior.AllowGet);
                    }


                    return Json(new { success = true, message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);


                }
                catch (Exception e)
                {
                    dbct.Rollback();
                    return Json(new { success = false, message = "Có lỗi khi thêm" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult validateID(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                QuyetDinh nv = db.QuyetDinhs.Where(x => x.SoQuyetDinh == id).FirstOrDefault<QuyetDinh>();
                if (nv != null)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public class ChamDutModel
        {
            public string MaNV { get; set; }
            public string Ten { get; set; }
            public string LoaiChamDut { get; set; }
            public string NgayChamDut { get; set; }
            public string DonViHienTai { get; set; }
            public string PhanXuong { get; set; }
            public string SoQD { get; set; }
            public string BacLuong { get; set; }
            public string ThangLuong { get; set; }
            public string SoBHXH { get; set; }
            public string MucLuong { get; set; }
            public string PhongBan { get; set; }
            public Nullable<DateTime> NgaySinh { get; set; }
            public Nullable<DateTime> NgayDiLam { get; set; }
            public bool GioiTinh { get; set; }
        }


        [Route("phong-tcld/quan-ly-nhan-vien/cham-dut/export-quyet-dinh")]
        [HttpPost]
        public ActionResult ExportReport(string selectedList)
        {
            string zipPath = HostingEnvironment.MapPath("/doc/TCLD/chamdutzip" + "/quyetdinh.zip");
            string sourcePath = HostingEnvironment.MapPath("/doc/TCLD/chamdutdow");
            try
            {

                var js = new JavaScriptSerializer();
                List<ChamDutModel> result = JsonConvert.DeserializeObject<List<ChamDutModel>>(selectedList);
                string manv = "";
                for (int i = 0; i < result.Count; i++)
                {
                    manv += "" + int.Parse(((ChamDutModel)result[i]).MaNV) + ",";
                }
                manv = manv.Remove(manv.Length - 1);
                List<ChamDutModel> exportList = new List<ChamDutModel>();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    string query = @"select a.*, b.department_name as 'PhanXuong', d.MucThangLuong as 'ThangLuong' from NhanVien a
                            left join Department b on a.MaPhongBan = b.department_id
                            left join BacLuong_ThangLuong_MucLuong c on 
                            a.MaBacLuong_ThangLuong_MucLuong = c.MaBacLuong_ThangLuong_MucLuong 
                            left join ThangLuong d on c.MaThangLuong = d.MaThangLuong                       
                            where a.MaNV in (" + manv + ")";
                    exportList = db.Database.SqlQuery<ChamDutModel>(query).ToList();
                }
                string chamdut = result[0].NgayChamDut;
                for (int i = 0; i < exportList.Count; i++)
                {
                    exportList[i].NgayChamDut = result[i].NgayChamDut;
                    exportList[i].LoaiChamDut = result[i].LoaiChamDut;
                }
                int count = 1;

                //Mot nguoi
                System.IO.DirectoryInfo di = new DirectoryInfo(HostingEnvironment.MapPath("/doc/TCLD/chamdutdow"));

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                string savePath = "";
                string fileName = HostingEnvironment.MapPath("/doc/TCLD/chamdut/motnguoi/chamdut-ko-tro-cap-template.docx");
                byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
                foreach (ChamDutModel item in exportList)
                {
                    using (var stream = new MemoryStream())
                    {
                        stream.Write(byteArray, 0, byteArray.Length);
                        using (var doc = WordprocessingDocument.Open(stream, true))
                        {
                            string docText = null;
                            using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                            {
                                docText = sr.ReadToEnd();
                            }

                            string Flocation = "/doc/TCLD/chamdutdow/quyetdinh-chamdut_";
                            Regex regexText = new Regex("%ngayquyetdinh%");
                            string[] ngay = item.NgayChamDut.Split('/');
                            docText = regexText.Replace(docText, "Ngày " + ngay[0] + " tháng " + ngay[1] + " năm " + ngay[2]);

                            regexText = new Regex("%ngaychamdut%");
                            docText = regexText.Replace(docText, ngay[1] + "/" + ngay[2]);

                            regexText = new Regex("%soqd%");
                            docText = regexText.Replace(docText, item.SoQD == null ? "" : item.SoQD);

                            regexText = new Regex("%name%");
                            docText = regexText.Replace(docText, item.Ten);

                            regexText = new Regex("%gender%");
                            docText = regexText.Replace(docText, item.GioiTinh ? "Ông" : "Bà");

                            regexText = new Regex("%sothe%");
                            docText = regexText.Replace(docText, item.MaNV);

                            regexText = new Regex("%ngaysinh%");
                            docText = regexText.Replace(docText, item.NgaySinh == null ? "" : item.NgaySinh.Value.ToString("dd/MM/yyyy"));

                            regexText = new Regex("%ngaydilam%");
                            docText = regexText.Replace(docText, item.NgayDiLam == null ? "" : item.NgayDiLam.Value.ToString("MM/yyyy"));

                            regexText = new Regex("%soBHXH%");
                            docText = regexText.Replace(docText, item.SoBHXH == null ? "" : item.SoBHXH);

                            regexText = new Regex("%nghenghiep%");
                            docText = regexText.Replace(docText, item.DonViHienTai == null ? "" : item.DonViHienTai);

                            regexText = new Regex("%bacluong%");
                            docText = regexText.Replace(docText, item.BacLuong == null ? "" : item.BacLuong);

                            regexText = new Regex("%mucluong%");
                            docText = regexText.Replace(docText, item.DonViHienTai == null ? "" : item.DonViHienTai);

                            regexText = new Regex("%thangluong%");
                            docText = regexText.Replace(docText, item.ThangLuong == null ? "" : item.ThangLuong);

                            regexText = new Regex("%phanxuong%");
                            docText = regexText.Replace(docText, item.PhanXuong == null ? "" : item.PhanXuong);

                            regexText = new Regex("%lydo%");
                            docText = regexText.Replace(docText, item.LoaiChamDut == null ? "" : item.LoaiChamDut);
                            using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                            {
                                sw.Write(docText);
                            }

                            doc.MainDocumentPart.Document.Save(); // won't update the original file 

                            Flocation += item.MaNV + ".doc";
                            savePath = HostingEnvironment.MapPath(Flocation);
                            stream.Position = 0;
                            System.IO.File.WriteAllBytes(savePath, stream.ToArray());
                            doc.Close();
                        }
                    }
                }
                if (System.IO.File.Exists(zipPath))
                {
                    System.IO.File.Delete(zipPath);
                }
                ZipFile.CreateFromDirectory(sourcePath, zipPath);


                return Json(new { success = true, location = "/doc/TCLD/chamdutzip/quyetdinh.zip" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return null;
            }



            //nhieu nguoi
            //else
            //{
            //    string fileName = HostingEnvironment.MapPath("/doc/TCLD/dieudong/nhieunguoi/dieudong-template.docx");
            //    byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
            //    using (var stream = new MemoryStream())
            //    {
            //        stream.Write(byteArray, 0, byteArray.Length);
            //        using (var doc = WordprocessingDocument.Open(stream, true))
            //        {
            //            string docText = null;
            //            using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
            //            {
            //                docText = sr.ReadToEnd();
            //            }
            //            Regex regexText = new Regex("%ngayquyetdinh%");
            //            string[] ngay = result[0].NgayChamDut.Split('/');
            //            docText = regexText.Replace(docText, "Ngày " + ngay[0] + " tháng " + ngay[1] + " năm " + ngay[2]);

            //            regexText = new Regex("%soquyetdinh%");
            //            docText = regexText.Replace(docText, result[0].SoQD);

            //            using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
            //            {
            //                sw.Write(docText);
            //            }
            //            Table table =  doc.MainDocumentPart.Document.Body.Elements<Table>().ElementAt(2);
            //            int i = 0;
            //            foreach (ChamDutModel d in result)
            //            {
            //                TableRow tr = new TableRow();
            //                i++;
            //                TableCell tc1 = new TableCell();
            //                tc1.Append(new Paragraph(new Run(new Text((i).ToString()))));
            //                tr.Append(tc1);

            //                TableCell tc2 = new TableCell();
            //                tc2.Append(new Paragraph(new Run(new Text(d.MaNV))));
            //                tr.Append(tc2);

            //                TableCell tc3 = new TableCell();
            //                tc3.Append(new Paragraph(new Run(new Text(d.TenNV))));
            //                tr.Append(tc3);

            //                TableCell tc4 = new TableCell();
            //                tc4.Append(new Paragraph(new Run(new Text(d.DonViHienTai))));
            //                tr.Append(tc4);

            //                TableCell tc5 = new TableCell();
            //                tc5.Append(new Paragraph(new Run(new Text(d.LoaiChamDut))));
            //                tr.Append(tc5);

            //                table.Append(tr);
            //            }
            //            doc.MainDocumentPart.Document.Save(); // won't update the original file 
            //        }
            //        // Save the file with the new name
            //        string savePath = HostingEnvironment.MapPath(Flocation);
            //        stream.Position = 0;
            //        System.IO.File.WriteAllBytes(savePath, stream.ToArray());
            //    }
            //}



        }


        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-cham-dut/excel")]
        [HttpPost]
        public void ReturnExcel()
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Brief/Danh-sách-nhân-viên.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string query = "select * from NhanVien nv left outer join CongViec cv on nv.MaCongViec = cv.MaCongViec where nv.MaTrangThai = 2";
                    List<NhanVienExcel> list = db.Database.SqlQuery<NhanVienExcel>(query).ToList();
                    int k = 4;
                    for (int i = 0; i < list.Count; i++)
                    {

                        excelWorksheet.Cells[k, 1].Value = i + 1;
                        excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).MaNV;
                        excelWorksheet.Cells[k, 3].Value = list.ElementAt(i).Ten;
                        if (list.ElementAt(i).GioiTinh)
                        {
                            excelWorksheet.Cells[k, 4].Value = "Nam";
                        }
                        else
                        {
                            excelWorksheet.Cells[k, 4].Value = "Nữ";
                        }
                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).NgaySinh.HasValue ? list.ElementAt(i).NgaySinh.Value.ToString("dd/MM/yyyy") : "";
                        excelWorksheet.Cells[k, 6].Value = list.ElementAt(i).SoCMND;
                        excelWorksheet.Cells[k, 7].Value = list.ElementAt(i).SoBHXH;
                        excelWorksheet.Cells[k, 14].Value = list.ElementAt(i).TenCongViec;
                        excelWorksheet.Cells[k, 15].Value = list.ElementAt(i).MucLuong;
                        excelWorksheet.Cells[k, 17].Value = list.ElementAt(i).BacLuong;
                        if (list.ElementAt(i).MaTrinhDo != null)
                        {
                            if (list.ElementAt(i).MaTrinhDo.Equals("1"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "Tiểu học";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("2"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "THCS";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("3"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "THPT";
                            }
                            else if (list.ElementAt(i).MaTrinhDo.Equals("4"))
                            {
                                excelWorksheet.Cells[k, 20].Value = "Trung cấp";
                            }
                            else
                            {
                                excelWorksheet.Cells[k, 20].Value = "Đại học";
                            }
                        }
                        excelWorksheet.Cells[k, 22].Value = list.ElementAt(i).QueQuan;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/TCLD/download/Danh-sách-nhân-viên.xlsx")));
                }
            }

        }
    }

}