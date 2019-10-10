using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;
namespace QUANGHANH2.Controllers.TCLD
{
    public class WorkHistoryController : Controller
    {
        public static string id_ = "";
        // GET: WorkHistory
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult WorkHistory(string id)
        {
            id_ = id;
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        }
        [HttpPost]
        public ActionResult workHistoryOfEmployee()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<NhanVien> listNhanVien = db.NhanViens.ToList();
            HistoryWork history = new HistoryWork();
            List<Department> listDepartment = db.Departments.ToList();
            List<DiemDanh_NangSuatLaoDong> listDiemDanh = db.DiemDanh_NangSuatLaoDong.ToList();
            List<CongViec> listCongViec = db.CongViecs.ToList();
            foreach (var nvt in listNhanVien)
            {
                if (nvt.MaNV.Equals(id_))
                {
                    history.MaNV = nvt.MaNV;
                    history.Ten = nvt.Ten;
                    history.NgaySinh = nvt.NgaySinh;
                    history.GioiTinh = nvt.GioiTinh == true ? "Nam" : "Nữ";
                    history.DiaChi = nvt.NoiOHienTai;
                    foreach(var d in listDepartment)
                    {
                        if (d.department_id.Equals(nvt.MaPhongBan))
                        {
                            history.BoPhan = d.department_name;
                        }
                    }
                    List<DateTime> listDateTimes = new List<DateTime>();
                    //foreach(var diemDanh in listDiemDanh)
                    //{
                    //    if (diemDanh.MaNV.Equals(id_))
                    //    {

                    //        listDateTimes.Add(diemDanh.NgayDiemDanh);
                    //    }
                    //}
                    DateTime dateMax = listDateTimes[0];
                    for(int i = 0; i < listDateTimes.Count(); i++)
                    {
                        if (listDateTimes[i] > dateMax)
                        {
                            dateMax = listDateTimes[i];
                        }
                    }

                    history.NgayDiLamGanNhat = dateMax;
                    foreach(var cv in listCongViec)
                    {
                        if(nvt.MaCongViec == cv.MaCongViec)
                        {
                            history.ChucVu = cv.TenCongViec;
                        }
                    }
                    

                }
            }
            List<HistoryWork> hisList = new List<HistoryWork>();
            hisList.Add(history);
            return Json(new { success = true, data = hisList, draw = Request["draw"] }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult getDataHistoryWork()
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
                //foreach (var dd in listDiemDanh)
                //{
                //    if (dd.MaNV.Equals(id_))
                //    {
                //        if (dd.XacNhan == true)
                //        {
                //            DayHistoryWork d = new DayHistoryWork();
                //            //d.ngayDiemDanh = dd.NgayDiemDanh;
                //            //d.calamViec = dd.CaDiemDanh.ToString();
                //            d.ghiChu = dd.GhiChu;
                //            listDiemDanhById.Add(d);
                //        }

                //    }
                //}
                for (int i = 0; i < listDiemDanhById.Count(); i++)
                {
                    for (int j = i+ 1; j < listDiemDanhById.Count()-1; j++)
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


    }
}
