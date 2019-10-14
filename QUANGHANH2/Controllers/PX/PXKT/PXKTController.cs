using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
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
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
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
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
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
                Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Where(a => a.MaPhongBan == Donvi && a.Ca == calamviec && a.NgayDiemDanh == date).First();
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
                return Json(new {
                    success = true,
                    customNSLDs = customNSLDs,
                    total_point = header.TotalEffort,
                    than = header.ThanThucHien,
                    lo = header.MetLoThucHien,
                    xen = header.XenThucHien,
                    note = header.GhiChu == null?"":header.GhiChu
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
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
                        Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Where(a => a.MaPhongBan == Donvi && a.Ca == calamviec && a.NgayDiemDanh == date).First();
                        header.TotalEffort = (double)json["total_point"];
                        header.GhiChu = (string)json["note"];
                        header.ThanThucHien = (double)json["than"];
                        header.MetLoThucHien = (double)json["lo"];
                        header.XenThucHien = (double)json["xen"];
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
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phan-xuong-khai-thac/diem-danh")]
        public ActionResult takeAttendanceView()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Department> d = db.Departments
                .Where(i => i.department_type == "Phân xưởng sản xuất chính" && i.department_id != "PXLT" && i.department_id != "PXST").ToList();
            ViewBag.departments = d;
            return View("/Views/PX/PXKT/takeAttendance.cshtml");
        }

        public dynamic getAll(int session, string departmentID, DateTime date)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Where(a => a.MaPhongBan == departmentID && a.Ca == session && a.NgayDiemDanh == date).First();
                List<string> listAttended = (from h in db.Header_DiemDanh_NangSuat_LaoDong
                                                .Where(h => h.MaPhongBan == departmentID && h.NgayDiemDanh == date && h.Ca != session)
                                          join per in db.DiemDanh_NangSuatLaoDong
                                          on h.HeaderID equals per.HeaderID
                                          select per.MaNV).ToList();
                var leftouterjoin = (from emp in db.NhanViens
                                        .Where(emp => emp.MaPhongBan == departmentID && !listAttended.Any(y => emp.MaNV.Equals(y)))
                                      join per in db.DiemDanh_NangSuatLaoDong.Where(per => per.HeaderID == header.HeaderID) 
                                      on emp.MaNV equals per.MaNV into temp
                                      from per in temp.DefaultIfEmpty()
                                      select new
                                      {
                                          maNV = emp.MaNV,
                                          tenNV = emp.Ten,
                                          status = per == null ? null : (bool?)per.DiLam,
                                          timeAttendance = per == null ? null : per.ThoiGianThucTeDiemDanh,
                                          reason = per == null ? null : per.LyDoVangMat,
                                          description = per == null ? null : per.GhiChu,
                                          headerID = per == null ? null : (int?)per.HeaderID
                                      }).OrderBy(att => att.status).ToList();
                var rightouterjoin = (from per in db.DiemDanh_NangSuatLaoDong.Where(per => per.HeaderID == header.HeaderID)
                                      join emp in db.NhanViens
                                        .Where(emp => emp.MaPhongBan == departmentID && !listAttended.Any(y => emp.MaNV.Equals(y)))
                                      on per.MaNV equals emp.MaNV into temp
                                      from emp in temp.DefaultIfEmpty()
                                      select new
                                      {
                                          maNV = emp == null ? null : emp.MaNV,
                                          tenNV = emp == null ? null : emp.Ten,
                                          status = (bool?)per.DiLam,
                                          timeAttendance = per.ThoiGianThucTeDiemDanh,
                                          reason = per.LyDoVangMat,
                                          description = per.GhiChu,
                                          headerID = (int?)per.HeaderID
                                      }).OrderBy(att => att.status).ToList();
                return leftouterjoin.Union(rightouterjoin);
            }
        }
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
        [HttpPost]
        [Route("phan-xuong-khai-thac/diem-danh")]
        public ActionResult takeAttendance()
        {
            var departmentID = Request["department"];
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int session = Int32.Parse(Request["session"]);
            dynamic listAttendance;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var head = db.Header_DiemDanh_NangSuat_LaoDong
                             .Where(h => h.MaPhongBan == departmentID && h.NgayDiemDanh == dateAtt && h.Ca == session)
                             .FirstOrDefault();
                if (head == null)
                {
                    Header_DiemDanh_NangSuat_LaoDong header = new Header_DiemDanh_NangSuat_LaoDong();
                    header.MaPhongBan = departmentID;
                    header.Ca = session;
                    header.NgayDiemDanh = dateAtt;
                    db.Header_DiemDanh_NangSuat_LaoDong.Add(header);
                    db.SaveChanges();
                }
                listAttendance = getAll(session, departmentID, dateAtt);
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
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
                    var headerID = db.Header_DiemDanh_NangSuat_LaoDong
                                     .Where(x => x.MaPhongBan == departmentID && x.NgayDiemDanh == dateAtt && x.Ca == session)
                                     .Select(x => x.HeaderID).FirstOrDefault();
                    //
                    foreach (var item in listUpdate)
                    {
                        DiemDanh_NangSuatLaoDong dn = new DiemDanh_NangSuatLaoDong();
                        dn.MaNV = item.maNV;
                        dn.DiLam = item.status;
                        dn.LyDoVangMat = item.reason;
                        dn.ThoiGianThucTeDiemDanh = item.timeAttendance != "" ? (DateTime?) Convert.ToDateTime(item.timeAttendance) : null;
                        dn.GhiChu = item.description;
                        if (item.isEnvolved)
                        {
                            dn.HeaderID = headerID;
                            if (item.headerID == null)
                            {
                                db.DiemDanh_NangSuatLaoDong.Add(dn);
                            }
                            else
                            {
                                db.Entry(dn).State = EntityState.Modified;
                            }
                        } else
                        {
                            if (item.headerID != null)
                            {
                                dn.HeaderID = headerID;
                                db.Entry(dn).State = EntityState.Modified;
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
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
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
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
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
            int session = Int32.Parse(Request["session"]);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var listAttendance = (from emp in db.NhanViens
                                        .Where(emp => emp.MaPhongBan == departmentID)
                                      join per in db.DiemDanh_NangSuatLaoDong
                                      on emp.MaNV equals per.MaNV into tmp1
                                      from tmp2 in tmp1.DefaultIfEmpty()
                                        .Where(per => ((workAll ? (per.DiLam == true) : (per.DiLam == false || per.DiLam == null)) || (notWorkAll ? (per.DiLam == false || per.DiLam == null) : (per.DiLam == true))) && (workAll || notWorkAll))
                                      join header in db.Header_DiemDanh_NangSuat_LaoDong
                                        .Where(h => h.MaPhongBan == departmentID && h.Ca == session && h.NgayDiemDanh == dateAtt)
                                      on tmp2.HeaderID equals header.HeaderID into attendance
                                      from att in attendance.DefaultIfEmpty()
                                      select new
                                      {
                                          maNV = emp.MaNV,
                                          tenNV = emp.Ten,
                                          status = (bool?)tmp2.DiLam,
                                          timeAttendance = tmp2.ThoiGianThucTeDiemDanh,
                                          reason = tmp2.LyDoVangMat,
                                          description = tmp2.GhiChu
                                      }).OrderBy(att => att.status).ToList();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
        [Auther(RightID = "179,180,181,182,183,184,185,186,187,188,189")]
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
        public int? headerID { get; set; }
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