using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.PX.PXKT
{
    public class PXKTController : Controller
    {
        [Route("phan-xuong-khai-thac")]
        public ActionResult Index()
        {
            return View("/Views/PX/PXKT/Report.cshtml");
        }
        [Route("phan-xuong-khai-thac/chi-tiet")]
        public ActionResult Detail()
        {
            return View("/Views/PX/PXKT/Detail.cshtml");
        }
        [Route("phan-xuong-khai-thac/nhap-du-lieu")]
        public ActionResult Add()
        {
            return View("/Views/PX/PXKT/Add.cshtml");
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong")]
        public ActionResult NSLD()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<Department> listDepartment = db.Departments
                    .Where(a => a.department_type.Contains("Chính") &&
                    !a.department_id.Contains("PXLT") &&
                    !a.department_id.Contains("PXST")).ToList();
                ViewBag.TenToChuc = listDepartment;
            }
            return View("/Views/PX/PXKT/NSLD.cshtml");
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong-getData")]
        [HttpPost]
        public ActionResult getDataNSLD()
        {
            try
            {
                string caSearch = Request["caSearch"];
                string ngaySearch = Request["ngaySearch"];
                string Donvi = Request["phongbanSearch"];
                ngaySearch = ngaySearch.Split('"')[1];
                int calamviec = Int32.Parse(caSearch.Split('"')[1]);
                ngaySearch = ngaySearch.Split('/')[1] + "/" + ngaySearch.Split('/')[0] + "/" + ngaySearch.Split('/')[2];
                DateTime date = DateTime.Parse(ngaySearch);
                List<BaoCaoTheoCa> customNSLDs = new List<BaoCaoTheoCa>();

                Donvi = Donvi.Split('"')[1];
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Find(calamviec, Donvi, date);
                List<DiemDanh_NangSuatLaoDong> list = db.DiemDanh_NangSuatLaoDong
                    .Where(a => a.DiLam == true)
                    .Where(a => a.HeaderID == header.HeaderID)
                    .ToList();
                customNSLDs = new List<BaoCaoTheoCa>();
                BaoCaoTheoCa cus;
                int num = 1;
                foreach (var i in list)
                {
                    string MaPhongBan = db.Header_DiemDanh_NangSuat_LaoDong.Where(a => a.HeaderID == i.HeaderID).First().MaPhongBan;
                    cus = new BaoCaoTheoCa
                    {
                        STT = num,
                        Name = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().Ten,
                        BacTho = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().BacLuong,
                        ChucDanh = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec == null ? "" : db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec.TenCongViec,
                        DuBaoNguyCo = i.DuBaoNguyCo,
                        HeSoChiaLuong = i.HeSoChiaLuong.ToString(),
                        LuongSauDuyet = i.DiemLuong.ToString(),
                        LuongTruocDuyet = i.DiemLuong.ToString(),
                        NoiDungCongViec = db.Departments.Where(a => a.department_id == MaPhongBan).First().department_name,
                        SoThe = i.MaNV,
                        YeuCauBPKTAT = i.GiaiPhapNguyCo
                    };
                    customNSLDs.Add(cus);
                    num++;
                }
                return Json(new { success = true, customNSLDs = customNSLDs, total_point = header.TotalEffort }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [Route("phan-xuong-khai-thac/nang-suat-lao-dong-update")]
        public ActionResult UpdateNSLD(string stringjson)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        JObject json = JObject.Parse(stringjson);
                        int calamviec = (int)json["ca"];
                        string Donvi = (string)json["phongban"];
                        DateTime date = DateTime.ParseExact((string)json["ngay"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Find(calamviec, Donvi, date);
                        header.TotalEffort = (double)json["total_point"];
                        JArray temp = (JArray)json.SelectToken("list");
                        foreach (JObject item in temp)
                        {
                            DiemDanh_NangSuatLaoDong NSLD = db.DiemDanh_NangSuatLaoDong.Find((string)item["MaNhanVien"], header.HeaderID);
                            NSLD.HeSoChiaLuong = (double)item["HeSoChiaLuong"];
                            NSLD.DiemLuong = (double)item["Luong"];
                            NSLD.DuBaoNguyCo = (string)item["DuBaoNguyCo"];
                            NSLD.GiaiPhapNguyCo = (string)item["YeuCauBPKTAT"];
                        }
                        db.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, message = "Cập nhật thành công" });
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Cập nhật thất bại" });
                    }
                }

            }

        }

        [Route("phan-xuong-khai-thac/diem-danh")]
        public ActionResult takeAttendanceView()
        {

            return View("/Views/PX/PXKT/takeAttendance.cshtml");
        }

        public dynamic getAll(int session, string departmentID, DateTime date)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var listAttendance = (from emp in db.NhanViens
                                      join per in db.DiemDanh_NangSuatLaoDong
                                        //.Where(per => per.MaDonVi == departmentID && per.NgayDiemDanh == date && per.CaDiemDanh == session)
                                      on emp.MaNV equals per.MaNV into attendance
                                      from att in attendance.DefaultIfEmpty()
                                      select new
                                      {
                                          maNV = emp.MaNV,
                                          //maDD = (int?)att.MaDiemDanh,
                                          //maDV = att.MaDonVi,
                                          tenNV = emp.Ten,
                                          status = att.DiLam,
                                          timeAttendance = att.ThoiGianThucTeDiemDanh,
                                          reason = att.LyDoVangMat,
                                          description = att.GhiChu
                                      }).OrderBy(att => att.status).ToList();
                return listAttendance;

            }
        }

        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh")]
        public ActionResult takeAttendance()
        {
            // fixxing
            var departmentID = "DL1";
            var dateAtt = Convert.ToDateTime("2019-09-10");
            int session = 1;
            //
            var listAttendance = getAll(session, departmentID, dateAtt);
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
            return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            //
        }

        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh/cap-nhat")]
        public ActionResult updateAttendance()
        {
            var listUpdateJSON = Request["sessionId"];
            var departmentID = Request["department"];
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int session = Int32.Parse(Request["session"]);
            var listUpdate = JsonConvert.DeserializeObject<List<updateStatus>>(listUpdateJSON);
            using (var transaction = new TransactionScope())
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    foreach (var item in listUpdate)
                    {
                        DiemDanh_NangSuatLaoDong dn = new DiemDanh_NangSuatLaoDong();
                        dn.MaNV = item.maNV;
                        dn.DiLam = item.status;
                        //if (item.timeAttendance != "")
                        //{
                        //    dn.ThoiGianThucTeDiemDanh = DateTime.ParseExact(item.timeAttendance, "M/d/yyyy hh:mm:ss", null);
                        //}
                        //dn.MaDonVi = item.maDV;
                        dn.LyDoVangMat = item.reason;
                        dn.GhiChu = item.description;
                        //dn.CaDiemDanh = session;
                        //dn.NgayDiemDanh = dateAtt;
                        //dn.MaDonVi = departmentID;
                        //dn.XacNhan = true;
                        if (item.isEnvolved)
                        {
                            if (item.maDD != null)
                            {
                                // db.Entry(dn).State = EntityState.Modified;
                                //dn.MaDiemDanh = Int32.Parse(item.maDD);
                                db.Entry(dn).State = EntityState.Modified; //do it here
                            }
                            else
                            {
                                db.DiemDanh_NangSuatLaoDong.Add(dn);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            if (item.maDD != null)
                            {
                                // db.Entry(dn).State = EntityState.Modified;
                                //dn.MaDiemDanh = Int32.Parse(item.maDD);
                                db.Entry(dn).State = EntityState.Deleted; //do it here
                            }
                        }
                    }
                    db.SaveChanges();
                    transaction.Complete();
                }
            }
            var listAttendance = getAll(session, departmentID, dateAtt);
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
            return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("phan-xuong-khai-thac/diem-danh/dang-ky-nhan-vien")]
        public ActionResult registerEmployee()
        {
            return View("/Views/PX/PXKT/registerEmployee.cshtml");
        }

        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh/dang-ky-nhan-vien")]
        public ActionResult loadEmployee()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var listNV = db.NhanViens.ToList();
                listNV = listNV.Skip(start).Take(length).ToList<NhanVien>();
                int totalrows = listNV.Count;
                int totalrowsafterfiltering = listNV.Count;
                return Json(new { success = true, data = listNV, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh/lua-chon-diem-danh")]
        public ActionResult filterEmployee()
        {
            //
            var workAll = bool.Parse(Request["workChecked"]);
            var notWorkAll = bool.Parse(Request["notWorkChecked"]);
            // fixxing
            var departmentID = Request["department"];
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int ca = Int32.Parse(Request["session"]);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var listAttendance = (from emp in db.NhanViens
                                      join per in db.DiemDanh_NangSuatLaoDong
                                        //.Where(per => per.MaDonVi == departmentID && per.NgayDiemDanh == dateAtt && per.CaDiemDanh == ca)
                                      on emp.MaNV equals per.MaNV into attendance
                                      from att in attendance.DefaultIfEmpty()
                                        .Where(att => ((workAll ? (att.DiLam == true) : (att.DiLam == false)) || (notWorkAll ? (att.DiLam == false /*|| att.MaDiemDanh == null*/) : (att.DiLam == true))) && (workAll || notWorkAll))
                                      select new
                                      {
                                          maNV = emp.MaNV,
                                          //maDD = (int?)att.MaDiemDanh,
                                          //maDV = att.MaDonVi,
                                          tenNV = emp.Ten,
                                          status = att.DiLam,
                                          timeAttendance = att.ThoiGianThucTeDiemDanh,
                                          //dateAttendance = att.NgayDiemDanh,
                                          reason = att.LyDoVangMat,
                                          description = att.GhiChu
                                      }).OrderBy(att => att.status).ToList();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh/lay-thong-tin")]
        public ActionResult fetchAPI()
        {
            var departmentID = Request["department"];
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int session = Int32.Parse(Request["session"]);
            //
            var listAttendanceFromAPI = new List<FakeAPI>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Task t = Task.Run(async () =>
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://foodserver.azurewebsites.net/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method
                        HttpResponseMessage response = await client.GetAsync("api/Attendance");
                        using (HttpContent content = response.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            listAttendanceFromAPI = JsonConvert.DeserializeObject<List<FakeAPI>>(data);
                        }
                    }
                });
                t.Wait();
                //
                List<String> listAttendanceFromAPI_ID = new List<string>();
                foreach (var item in listAttendanceFromAPI)
                {
                    listAttendanceFromAPI_ID.Add(item.MaNV);
                }
                try
                {
                    using (var transaction = new TransactionScope())
                    {
                        // get all "ma nhan vien" already have been taken attendance.
                        List<String> listAttendanceID = db.DiemDanh_NangSuatLaoDong/*.Where(dd => dd.CaDiemDanh == session && dd.MaDonVi == departmentID && dd.NgayDiemDanh == dateAtt)*/.Select(col => col.MaNV).ToList();
                        foreach (var id in listAttendanceFromAPI_ID)
                        {
                            if (!listAttendanceID.Contains(id))
                            {
                                DiemDanh_NangSuatLaoDong dn = new DiemDanh_NangSuatLaoDong();
                                //dn.MaDonVi = departmentID;
                                //dn.CaDiemDanh = session;
                                //dn.NgayDiemDanh = dateAtt;
                                dn.MaNV = id;
                                // from API
                                //dn.XacNhan = false;
                                db.DiemDanh_NangSuatLaoDong.Add(dn);
                                db.SaveChanges();
                            }
                        }
                        transaction.Complete();
                    }
                    var listAttendance = getAll(session, departmentID, dateAtt);
                    JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                    var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                    return Json(new { success = true, data = result, time = "hihi" }, JsonRequestBehavior.AllowGet);
                }
                catch
                {

                }
            }
            return View();
        }
    }

    public class updateStatus
    {
        public bool isEnvolved { get; set; }
        public string maDD { get; set; }
        public string maDV { get; set; }
        public string maNV { get; set; }
        public string tenNV { get; set; }
        public bool status { get; set; }
        public string timeAttendance { get; set; }
        public string reason { get; set; }
        public string description { get; set; }
    }

    public class BaoCaoTheoCa
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public string SoThe { get; set; }
        public string BacTho { get; set; }
        public string ChucDanh { get; set; }
        public string NoiDungCongViec { get; set; }
        public string HeSoChiaLuong { get; set; }
        public string LuongTruocDuyet { get; set; }
        public string LuongSauDuyet { get; set; }
        public string DuBaoNguyCo { get; set; }
        public string YeuCauBPKTAT { get; set; }
    }
}