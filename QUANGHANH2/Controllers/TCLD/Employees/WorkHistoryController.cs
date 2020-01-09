using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;
using System.Data.SqlClient;

namespace QUANGHANH2.Controllers.TCLD
{
    public class WorkHistoryController : Controller
    {
        public string id_ = "";
        // GET: WorkHistory
        public ActionResult Index()
        {
            return View();
        }
        [Route("lich-su-lam-viec")]
        [HttpGet]
        public ActionResult WorkHistory()
        {
            return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        }
        [HttpPost]
        public ActionResult workHistoryOfEmployee(string id)

        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                NhanVien nhanVien = db.NhanViens.Where(x => x.MaNV == id).FirstOrDefault();
                HistoryWork history = new HistoryWork();
                List<Department> listDepartment = db.Departments.ToList();
                string query = "select (case when MAX(a.HeaderID) is null then 0 else MAX(a.HeaderID) end) as 'MaxId' from DiemDanh_NangSuatLaoDong a where a.MaNV = @id";
                int newHeader = db.Database.SqlQuery<int>(query, new SqlParameter("id", id)).FirstOrDefault();
                List<CongViec> listCongViec = db.CongViecs.ToList();
                history.MaNV = nhanVien.MaNV;
                history.Ten = nhanVien.Ten;
                history.NgaySinh = nhanVien.NgaySinh;
                history.GioiTinh = nhanVien.GioiTinh == true ? "Nam" : "Nữ";
                history.DiaChi = nhanVien.NoiOHienTai;
                foreach (var d in listDepartment)
                {
                    if (d.department_id.Equals(nhanVien.MaPhongBan))
                    {
                        history.BoPhan = d.department_name;
                    }
                }
                DateTime dateMax = new DateTime();
                if (newHeader != 0)
                {
                    dateMax = db.Header_DiemDanh_NangSuat_LaoDong.Where(x => x.HeaderID == newHeader).Select(x => x.NgayDiemDanh).FirstOrDefault();
                }
                history.NgayDiLamGanNhat = dateMax;
                foreach (var cv in listCongViec)
                {
                    if (nhanVien.MaCongViec == cv.MaCongViec)
                    {
                        history.ChucVu = cv.TenCongViec;
                    }
                }
                List<HistoryWork> hisList = new List<HistoryWork>();
                hisList.Add(history);
                return Json(new
                {
                    success = true,
                    data = hisList,
                    draw = Request["draw"]
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult getDataHistoryWork(string id)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    int start = Convert.ToInt32(Request["start"]);
                    int length = Convert.ToInt32(Request["length"]);
                    string searchValue = Request["search[value]"];
                    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                    string sortDirection = Request["order[0][dir]"];
                    List<DiemDanh_NangSuatLaoDong> listDiemDanh = db.DiemDanh_NangSuatLaoDong.ToList();
                    List<DayHistoryWork> listDiemDanhById = new List<DayHistoryWork>();
                    foreach (var dd in listDiemDanh)
                    {
                        if (dd.MaNV.Equals(id))
                        {
                            int ca = db.Header_DiemDanh_NangSuat_LaoDong.Where(x => x.HeaderID.Equals(dd.HeaderID)).Select(x => x.Ca).FirstOrDefault();
                            DateTime ngay_diem_danh = db.Header_DiemDanh_NangSuat_LaoDong.Where(x => x.HeaderID.Equals(dd.HeaderID)).Select(x => x.NgayDiemDanh).FirstOrDefault();
                            if (dd.DiLam == true)
                            {
                                DayHistoryWork d = new DayHistoryWork();
                                d.ngayDiemDanh = ngay_diem_danh;
                                d.calamViec = ca.ToString();
                                d.ghiChu = dd.GhiChu;
                                listDiemDanhById.Add(d);
                            }

                        }
                    }
                    for (int i = 0; i < listDiemDanhById.Count(); i++)
                    {
                        for (int j = i + 1; j < listDiemDanhById.Count() - 1; j++)
                        {
                            if (listDiemDanhById[i].ngayDiemDanh == listDiemDanhById[j].ngayDiemDanh)
                            {

                                listDiemDanhById[i].calamViec += " " + listDiemDanhById[j].calamViec;
                                listDiemDanhById.Remove(listDiemDanhById[j]);
                                j = j - 1;
                            }
                        }

                    }
                    int totalrows = listDiemDanhById.Count;
                    int totalrowsafterfiltering = listDiemDanhById.Count;
                    listDiemDanhById = listDiemDanhById.OrderBy(sortColumnName + " " + sortDirection).ToList<DayHistoryWork>();
                    //paging
                    listDiemDanhById = listDiemDanhById.Skip(start).Take(length).ToList<DayHistoryWork>();
                    var dataJson = Json(new { success = true, data = listDiemDanhById, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                    string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                    return dataJson;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
