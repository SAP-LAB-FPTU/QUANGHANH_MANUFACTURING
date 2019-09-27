using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public class MyModal
        {
            public string loai { get; set; }
            public List<NhiemVu> arrNV { get; set; }
            public MyModal()
            {
                arrNV = new List<NhiemVu>();
            }
        }


        public ActionResult SearchEmployee(string data)
        {

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                dynamic dataJson = JObject.Parse(data);

                string name = dataJson.name;
                string px = dataJson.px;

                if (name == null || name.Equals("")) //chi search bang phan xuong
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (pxx.department_name.Contains(px))
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    List<NhanVien> emp = temp.ToList().Select(p => new NhanVien { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                    int totalrows = emp.Count;
                    int totalrowsafterfiltering = emp.Count;
                    emp = emp.Skip(start).Take(length).ToList<NhanVien>();
                    return Json(new { success = true, data = emp, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
                else if (px == null || px.Equals("")) // chi search bang ten nv
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (nv.Ten.Contains(name))
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    List<NhanVien> emp = temp.ToList().Select(p => new NhanVien { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                    int totalrows = emp.Count;
                    int totalrowsafterfiltering = emp.Count;
                    emp = emp.Skip(start).Take(length).ToList<NhanVien>();
                    return Json(new { success = true, data = emp, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
                else // search bang ca 2
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (pxx.department_name.Contains(px) && nv.Ten.Contains(name))
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    List<NhanVien> emp = temp.ToList().Select(p => new NhanVien { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                    int totalrows = emp.Count;
                    int totalrowsafterfiltering = emp.Count;
                    emp = emp.Skip(start).Take(length).ToList<NhanVien>();
                    return Json(new { success = true, data = emp, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
            }

        }


        [Route("phong-tcld/dang-ky-cong-viec")]
        public ActionResult ViewJobByPX()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from a in db.Departments select new { TenPhanXuong = a.department_name }).ToList();

                IEnumerable<Department> arrPhanXuong = temp.Distinct().ToList().Select(p => new Department { department_name = p.TenPhanXuong });
                ViewBag.nameDepartment = "vld-antoan";
                ViewBag.PhanXuongs = arrPhanXuong;
                List<string> arrNhanvienNhiemVu = new List<string>();

                IOrderedEnumerable<NhiemVu> arrNhiemVu = db.NhiemVus.ToList().OrderBy(n => n.Loai);
                foreach (NhiemVu n in arrNhiemVu)
                {
                    arrNhanvienNhiemVu.Add(n.MaNhiemVu.ToString());
                }
                List<MyModal> model = new List<MyModal>();


                MyModal tempModel = new MyModal();

                foreach (NhiemVu v in arrNhiemVu)
                {
                    if (!v.Loai.Equals(tempModel.loai))
                    {
                        tempModel = new MyModal
                        {
                            loai = v.Loai
                        };
                        tempModel.arrNV.Add(v);
                        model.Add(tempModel);
                    }
                    else
                    {
                        tempModel.arrNV.Add(v);
                    }
                }



                ViewBag.arrNhanVien_NhiemVu = arrNhanvienNhiemVu;
                ViewBag.arrNhiemVu = model;
                return View("/Views/TCLD/Task/ViewJobByPX.cshtml");
            }

        }



        [HttpPost]
        public ActionResult AssignTask(List<string> tasks)
        {
            try
            {
                string[] tSplit;
                ChiTiet_NhiemVu_NhanVien cnn;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    DateTime now = DateTime.Now;
                    foreach (string t in tasks)
                    {
                        tSplit = t.Split('_');
                        string mnv = tSplit[1];
                        int mnvu = Convert.ToInt16(tSplit[0]);
                        cnn = new ChiTiet_NhiemVu_NhanVien
                        {
                            MaNhiemVu = mnvu,
                            MaNV = mnv,
                            NgayNhanNhiemVu = now
                        };
                        var temp = db.ChiTiet_NhiemVu_NhanVien.Where(p => p.MaNhiemVu == mnvu && p.MaNV.Equals(mnv)).FirstOrDefault();
                        if (temp == null)
                        {
                            db.ChiTiet_NhiemVu_NhanVien.Add(cnn);
                        }
                        else
                        {
                            cnn.MaChiTiet_NhiemVu_NhanVien = temp.MaChiTiet_NhiemVu_NhanVien; //MaChiTiet_NhiemVu_NhanVien
                            db.Entry(cnn).State = EntityState.Modified;
                        }
                    }
                    db.SaveChanges();
                    foreach (ChiTiet_NhiemVu_NhanVien cn in db.ChiTiet_NhiemVu_NhanVien)
                    {
                        int nv = cn.MaNhiemVu;
                    }

                }
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetNhanVienByPX(string tenPhanXuong = "")
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from px in db.Departments
                            join
                            nv in db.NhanViens
                            on px.department_id equals nv.MaPhongBan
                            where px.department_name == tenPhanXuong
                            select new
                            {
                                nv.Ten,
                                nv.MaNV
                            });
                List<NhanVien> arrNhanVienByPX = temp.ToList().Select(p => new NhanVien { Ten = p.Ten, MaNV = p.MaNV }).ToList();

                int totalrows = arrNhanVienByPX.Count;
                int totalrowsafterfiltering = arrNhanVienByPX.Count;

                arrNhanVienByPX = arrNhanVienByPX.Skip(start).Take(length).ToList<NhanVien>();
                return Json(new { success = true, data = arrNhanVienByPX, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }


        [Route("phong-tcld/chung-chi-cua-nhan-vien")]
        [HttpGet]
        public ActionResult ViewChungChiNhanVien()
        {
            string mnv = Request.QueryString["MaNV"];
            ViewBag.MaNV = mnv;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                NhanVien nhanVien = db.NhanViens.ToList().Where(p => p.MaNV.Equals(mnv)).FirstOrDefault();
                string tenNhanVien = nhanVien.Ten;
                ViewBag.TenNhanVien = tenNhanVien;
            }
            return View("/Views/TCLD/Task/ViewCertificateByNV.cshtml");
        }

        [HttpPost]
        public ActionResult GetAllChungChiOfNV(string mnv = "")
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from cc in db.ChungChis
                            join ccnv in db.ChungChi_NhanVien
                            on cc.MaChungChi equals ccnv.MaChungChi
                            where ccnv.MaNV.Equals(mnv)
                            select new
                            {
                                MaNV = ccnv.MaNV,
                                TenChungChi = cc.TenChungChi,
                                SoHieu = ccnv.SoHieu,
                                NgayCap = ccnv.NgayCap,
                                ConHan = (DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) < 0 ? "Hết Hạn" :
                                DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) >= 0 ? "Còn Hạn" : "Còn Hạn"
                                )
                            });
                List<ChungChi_NhanVien_Model> arrChungChi = temp.ToList().Select(p => new ChungChi_NhanVien_Model
                {
                    TenChungChi = p.TenChungChi,
                    SoHieu = p.SoHieu,
                    NgayCap = p.NgayCap,
                    isConHan = p.ConHan
                }).ToList();
                return Json(new { success = true, data = arrChungChi }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetAllNhanVienByPX()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];


            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from px in db.Departments
                            join
                            nv in db.NhanViens
                            on px.department_id equals nv.MaPhongBan
                            select new
                            {
                                TenNhanVien = nv.Ten,
                                MaNhanVien = nv.MaNV
                            });
                List<NhanVien> arrNhanVien = temp.ToList().Select(p => new NhanVien { Ten = p.TenNhanVien, MaNV = p.MaNhanVien }).ToList();

                IOrderedEnumerable<NhanVien> arrnvorder = arrNhanVien.OrderBy(n => n.MaNV);
                int totalrows = arrNhanVien.Count;
                int totalrowsafterfiltering = arrNhanVien.Count;
                arrNhanVien = arrNhanVien.OrderBy(sortColumnName + " " + sortDirection).ToList<NhanVien>();
                arrNhanVien = arrNhanVien.Skip(start).Take(length).ToList<NhanVien>();

                return Json(new { success = true, data = arrNhanVien, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        public class ReportModel
        {
            public string Loai { get; set; }
            public List<TaskModel> arrTask { get; set; }
            public int Rowspan { get; set; }

            public ReportModel()
            {
                Loai = "";
                arrTask = new List<TaskModel>();
                Rowspan = 0;
            }
        }

        public class TaskModel
        {
            public string TenNhiemVu { get; set; }
            public List<ChungChi_NhanVien_Model> arrNhanVien { get; set; }
            public int Rowspan { get; set; }

            public TaskModel()
            {
                arrNhanVien = new List<ChungChi_NhanVien_Model>();
                Rowspan = 0;
                TenNhiemVu = "";
            }
        }

        [Route("phong-tcld/bao-cao-tinh-trang-chung-chi-cho-cong-viec")]
        public ActionResult ReportJob(string maPhongBan = "", string tenPhongBan = "")
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from a in db.Departments select new { maPhongBan = a.department_id, TenPhanXuong = a.department_name }).ToList();
                IEnumerable<Department> arrPhanXuong = temp.Distinct().ToList().Select(p => new Department { department_id = p.maPhongBan, department_name = p.TenPhanXuong });
                ViewBag.PhanXuongs = arrPhanXuong;
            }
            ViewBag.nameDepartment = "vld-antoan";

            if (maPhongBan.Equals(""))
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var temp = (from ct in db.ChiTiet_NhiemVu_NhanVien
                                join n in db.NhanViens
                                on ct.MaNV equals n.MaNV
                                join nv in db.NhiemVus
                                on ct.MaNhiemVu equals nv.MaNhiemVu
                                join cc in db.ChungChis
                                on nv.MaChungChi equals cc.MaChungChi
                                join ccnv in db.ChungChi_NhanVien
                                on new { n.MaNV, cc.MaChungChi } equals new { ccnv.MaNV, ccnv.MaChungChi }
                                into tb
                                from mtb in tb.DefaultIfEmpty()
                                where n.MaPhongBan.Equals("DL1")
                                orderby nv.Loai
                                select new
                                {
                                    SoHieu = mtb.SoHieu,
                                    Loai = nv.Loai,
                                    TenNhanVien = n.Ten,
                                    TenNhiemVu = nv.TenNhiemVu,
                                    TenChungChi = cc.TenChungChi,
                                    MaChungChi = cc.MaChungChi,
                                    MaNhanVien = n.MaNV,
                                    IsConHan = (DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) > 0 ? "Hết hạn" :
                                                DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) <= 0 ? "Còn hạn" : "Chưa có")
                                                ,
                                    SoNgay = (DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) < 0 ? -DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) :
                                               DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) >= 0 ? DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) : 0),
                                }
                                 ).ToList();
                    List<ReportModel> arrReportModels = new List<ReportModel>();
                    bool isContainLoai = false;
                    bool isContainNV = false;
                    foreach (var myTemp in temp)
                    {
                        foreach (ReportModel reportModel in arrReportModels)
                        {
                            if (reportModel.Loai.Equals(myTemp.Loai))
                            {
                                foreach (TaskModel taskModel in reportModel.arrTask)
                                {
                                    if (taskModel.TenNhiemVu.Equals(myTemp.TenNhiemVu))
                                    {
                                        ChungChi_NhanVien_Model ccnv = new ChungChi_NhanVien_Model { TenNV = myTemp.TenNhanVien, SoHieu = myTemp.SoHieu, MaNV = myTemp.MaNhanVien, MaChungChi = myTemp.MaChungChi, TenChungChi = myTemp.TenChungChi, SoNgay = myTemp.SoNgay, isConHan = myTemp.IsConHan };
                                        taskModel.arrNhanVien.Add(ccnv);
                                        reportModel.Rowspan++;
                                        taskModel.Rowspan++;
                                        isContainNV = true;
                                    }
                                }
                                if (!isContainNV)
                                {
                                    TaskModel taskModel = new TaskModel
                                    {
                                        TenNhiemVu = myTemp.TenNhiemVu
                                    };
                                    ChungChi_NhanVien_Model ccnv = new ChungChi_NhanVien_Model { TenNV = myTemp.TenNhanVien, SoHieu = myTemp.SoHieu, MaNV = myTemp.MaNhanVien, MaChungChi = myTemp.MaChungChi, TenChungChi = myTemp.TenChungChi, SoNgay = myTemp.SoNgay, isConHan = myTemp.IsConHan };
                                    taskModel.arrNhanVien.Add(ccnv);
                                    reportModel.arrTask.Add(taskModel);
                                    reportModel.Rowspan++;
                                    taskModel.Rowspan++;
                                    isContainNV = false;
                                }
                                isContainLoai = true;
                            }
                        }
                        if (!isContainLoai)
                        {
                            ReportModel reportModel = new ReportModel
                            {
                                Loai = myTemp.Loai
                            };
                            TaskModel taskModel = new TaskModel
                            {
                                TenNhiemVu = myTemp.TenNhiemVu
                            };
                            ChungChi_NhanVien_Model ccnv = new ChungChi_NhanVien_Model { TenNV = myTemp.TenNhanVien, SoHieu = myTemp.SoHieu, MaNV = myTemp.MaNhanVien, MaChungChi = myTemp.MaChungChi, TenChungChi = myTemp.TenChungChi, SoNgay = myTemp.SoNgay, isConHan = myTemp.IsConHan };
                            reportModel.Rowspan++;
                            taskModel.Rowspan++;
                            taskModel.arrNhanVien.Add(ccnv);
                            reportModel.arrTask.Add(taskModel);
                            arrReportModels.Add(reportModel);
                        }
                        isContainLoai = false;
                    }

                    ViewBag.arrReportModels = arrReportModels;
                }

            }
            else
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var temp = (from ct in db.ChiTiet_NhiemVu_NhanVien
                                join n in db.NhanViens
                                on ct.MaNV equals n.MaNV
                                join nv in db.NhiemVus
                                on ct.MaNhiemVu equals nv.MaNhiemVu
                                join cc in db.ChungChis
                                on nv.MaChungChi equals cc.MaChungChi
                                join ccnv in db.ChungChi_NhanVien
                                on new { n.MaNV, cc.MaChungChi } equals new { ccnv.MaNV, ccnv.MaChungChi }
                                into tb
                                from mtb in tb.DefaultIfEmpty()
                                where n.MaPhongBan.Equals(maPhongBan)
                                orderby nv.Loai
                                select new
                                {
                                    SoHieu = mtb.SoHieu,
                                    Loai = nv.Loai,
                                    TenNhanVien = n.Ten,
                                    TenNhiemVu = nv.TenNhiemVu,
                                    TenChungChi = cc.TenChungChi,
                                    MaChungChi = cc.MaChungChi,
                                    MaNhanVien = n.MaNV,
                                    IsConHan = (DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) > 0 ? "Hết hạn" :
                                                DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) <= 0 ? "Còn hạn" : "Chưa có")
                                                ,
                                    SoNgay = (DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) < 0 ? -DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) :
                                               DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) >= 0 ? DbFunctions.DiffDays(DbFunctions.AddMonths(mtb.NgayCap, cc.ThoiHan), DateTime.Now) : 0),
                                }
                                 ).ToList();
                    List<ReportModel> arrReportModels = new List<ReportModel>();
                    bool isContainLoai = false;
                    bool isContainNV = false;
                    foreach (var myTemp in temp)
                    {
                        foreach (ReportModel reportModel in arrReportModels)
                        {
                            if (reportModel.Loai.Equals(myTemp.Loai))
                            {
                                foreach (TaskModel taskModel in reportModel.arrTask)
                                {
                                    if (taskModel.TenNhiemVu.Equals(myTemp.TenNhiemVu))
                                    {
                                        ChungChi_NhanVien_Model ccnv = new ChungChi_NhanVien_Model { TenNV = myTemp.TenNhanVien, SoHieu = myTemp.SoHieu, MaNV = myTemp.MaNhanVien, MaChungChi = myTemp.MaChungChi, TenChungChi = myTemp.TenChungChi, SoNgay = myTemp.SoNgay, isConHan = myTemp.IsConHan };
                                        taskModel.arrNhanVien.Add(ccnv);
                                        reportModel.Rowspan++;
                                        taskModel.Rowspan++;
                                        isContainNV = true;
                                    }
                                }
                                if (!isContainNV)
                                {
                                    TaskModel taskModel = new TaskModel
                                    {
                                        TenNhiemVu = myTemp.TenNhiemVu
                                    };
                                    ChungChi_NhanVien_Model ccnv = new ChungChi_NhanVien_Model { TenNV = myTemp.TenNhanVien, SoHieu = myTemp.SoHieu, MaNV = myTemp.MaNhanVien, MaChungChi = myTemp.MaChungChi, TenChungChi = myTemp.TenChungChi, SoNgay = myTemp.SoNgay, isConHan = myTemp.IsConHan };
                                    taskModel.arrNhanVien.Add(ccnv);
                                    reportModel.arrTask.Add(taskModel);
                                    reportModel.Rowspan++;
                                    taskModel.Rowspan++;
                                    isContainNV = false;
                                }
                                isContainLoai = true;
                            }
                        }
                        if (!isContainLoai)
                        {
                            ReportModel reportModel = new ReportModel
                            {
                                Loai = myTemp.Loai
                            };
                            TaskModel taskModel = new TaskModel
                            {
                                TenNhiemVu = myTemp.TenNhiemVu
                            };
                            ChungChi_NhanVien_Model ccnv = new ChungChi_NhanVien_Model { TenNV = myTemp.TenNhanVien, SoHieu = myTemp.SoHieu, MaNV = myTemp.MaNhanVien, MaChungChi = myTemp.MaChungChi, TenChungChi = myTemp.TenChungChi, SoNgay = myTemp.SoNgay, isConHan = myTemp.IsConHan };
                            reportModel.Rowspan++;
                            taskModel.Rowspan++;
                            taskModel.arrNhanVien.Add(ccnv);
                            reportModel.arrTask.Add(taskModel);
                            arrReportModels.Add(reportModel);
                        }
                        isContainLoai = false;
                    }

                    ViewBag.arrReportModels = arrReportModels;
                    ViewBag.tenPhongBan = tenPhongBan;
                }
            }


            return View("/Views/TCLD/Task/ReportJob.cshtml");
        }

        [HttpGet]
        public ActionResult getGiaHanPopUpInfo(string maNV, int maCC)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from ccnv in db.ChungChi_NhanVien
                            join
                            nv in db.NhanViens on ccnv.MaNV equals nv.MaNV
                            join cc in db.ChungChis
                            on ccnv.MaChungChi equals cc.MaChungChi
                            where nv.MaNV.Equals(maNV) && ccnv.MaChungChi == maCC
                            select new
                            {
                                TenNhanVien = nv.Ten,
                                TenChungChi = cc.TenChungChi,
                                SoHieu = ccnv.SoHieu,
                                MaNhanVien = nv.MaNV,
                                MaChungChi = cc.MaChungChi
                            }).ToList();

                List<ChungChi_NhanVien_Model> dt = temp.Select(p => new ChungChi_NhanVien_Model
                {
                    TenNV = p.TenNhanVien,
                    TenChungChi = p.TenChungChi,
                    SoHieu = p.SoHieu,
                    MaNV = p.MaNhanVien,
                    MaChungChi = p.MaChungChi
                }).ToList();
                return Json(new { success = true, data = dt }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult getThemMoiPopUpInfo(string maNV, int maCC)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from ccnv in db.ChungChi_NhanVien
                            join
                            nv in db.NhanViens on ccnv.MaNV equals nv.MaNV
                            join cc in db.ChungChis
                            on ccnv.MaChungChi equals cc.MaChungChi
                            where nv.MaNV.Equals(maNV) && ccnv.MaChungChi == maCC
                            select new
                            {
                                TenNhanVien = nv.Ten,
                                TenChungChi = cc.TenChungChi,
                                SoHieu = ccnv.SoHieu,
                                MaNhanVien = nv.MaNV,
                                MaChungChi = cc.MaChungChi
                            }).ToList();

                List<ChungChi_NhanVien_Model> dt = temp.Select(p => new ChungChi_NhanVien_Model
                {
                    TenNV = p.TenNhanVien,
                    TenChungChi = p.TenChungChi,
                    SoHieu = p.SoHieu
                                                                        ,
                    MaNV = p.MaNhanVien,
                    MaChungChi = p.MaChungChi
                }).ToList();
                return Json(new { success = true, data = dt }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult XacNhanGiaHan(string data)
        {
            dynamic dataJson = JObject.Parse(data);
            var maNV = dataJson.mnv;
            var maCC = dataJson.mcc;
            var ngayCap = DateTime.ParseExact(Convert.ToString(dataJson.ngaycap), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            var ngayTra = DateTime.ParseExact(Convert.ToString(dataJson.ngaytra), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            var sohieu = dataJson.sohieu + "";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ChungChi_NhanVien ccnv = new ChungChi_NhanVien { MaNV = maNV, MaChungChi = maCC, NgayCap = Convert.ToDateTime(ngayCap), NgayTra = Convert.ToDateTime(ngayTra), SoHieu = sohieu };
                if (ccnv.SoHieu != null && !ccnv.SoHieu.Equals(""))
                {
                    db.Entry(ccnv).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult XacNhanThemMoi(string data)
        {
            dynamic dataJson = JObject.Parse(data);
            var maNV = dataJson.mnv;
            var maCC = dataJson.mcc;
            var ngayCap = DateTime.ParseExact(Convert.ToString(dataJson.ngaycap), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            var ngayTra = DateTime.ParseExact(Convert.ToString(dataJson.ngaytra), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            var sohieu = dataJson.sohieu + "";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                try
                {
                    ChungChi_NhanVien ccnv = new ChungChi_NhanVien { MaNV = maNV, MaChungChi = maCC, NgayCap = Convert.ToDateTime(ngayCap), NgayTra = Convert.ToDateTime(ngayTra), SoHieu = sohieu };
                    if (ccnv.SoHieu != null && !ccnv.SoHieu.Equals(""))
                    {
                        db.ChungChi_NhanVien.Add(ccnv);
                        db.SaveChanges();
                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception)
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}