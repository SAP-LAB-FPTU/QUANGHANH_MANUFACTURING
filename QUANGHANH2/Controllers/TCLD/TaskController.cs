﻿using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class TaskController : Controller
    {

        [Auther(RightID = "138")]
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

                List<NhanVien_Extend> emp = null;
                if (name == null || name.Equals(""))
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens

                                on pxx.department_id equals nv.MaPhongBan
                                where (pxx.department_name.Contains(px))
                                && nv.MaTrangThai == 1
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    emp = temp.ToList().Select(p => new NhanVien_Extend { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                }
                else if (px == null || px.Equals(""))
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (nv.Ten.Contains(name))
                                && nv.MaTrangThai == 1
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    emp = temp.ToList().Select(p => new NhanVien_Extend { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                }
                else
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (pxx.department_name.Contains(px) && nv.Ten.Contains(name) && nv.MaTrangThai == 1)
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    emp = temp.ToList().Select(p => new NhanVien_Extend { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                }

                int totalrows = emp.Count;
                int totalrowsafterfiltering = emp.Count;
                emp = emp.Skip(start).Take(length).ToList<NhanVien_Extend>();

                foreach (NhanVien_Extend nv in emp)
                {
                    foreach (ChiTiet_NhiemVu_NhanVien nvnv in db.ChiTiet_NhiemVu_NhanVien)
                    {
                        if (nv.MaNV.Equals(nvnv.MaNV) && nvnv.IsInProcess == true)
                        {
                            nv.MaNhiemVu.Add(nvnv.MaNhiemVu);
                        }
                    }
                }
                return Json(new { success = true, data = emp, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }

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

        [Auther(RightID = "138")]
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
                // myArrPhanXuong = new 
                IOrderedEnumerable<NhiemVu> arrNhiemVu = db.NhiemVus.ToList().OrderBy(n => n.Loai);

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
                ViewBag.arrNhiemVu = model;
                return View("/Views/TCLD/Task/ViewJobByPX.cshtml");
            }

        }


        [Auther(RightID = "139")]
        [HttpPost]
        public ActionResult AssignTask(List<string> tasks, List<string> removedTask)
        {
            try
            {
                string[] tSplit;
                string[] rtSplit;
                ChiTiet_NhiemVu_NhanVien cnn;
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    if (removedTask != null)
                    {
                        foreach (string rt in removedTask) // truong hop bo nhiem vu cua nhan vien di va khong dang ki cai moi
                        {
                            rtSplit = rt.Split('_');
                            string mnv = rtSplit[1];
                            int mnvu = Convert.ToInt16(rtSplit[0]);
                            ChiTiet_NhiemVu_NhanVien temp = db.ChiTiet_NhiemVu_NhanVien.Where(p => p.MaNV.Equals(mnv) && p.MaNhiemVu == mnvu).Where(p => p.IsInProcess == true).FirstOrDefault();
                            if (temp != null)
                            {
                                temp.IsInProcess = false;
                            }
                        }
                    }

                    if (tasks != null)
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
                                NgayNhanNhiemVu = now,
                                IsInProcess = true
                            };
                            List<ChiTiet_NhiemVu_NhanVien> temp = db.ChiTiet_NhiemVu_NhanVien.Where(p => p.MaNV.Equals(mnv)).ToList();

                            if (temp != null) //set het trang thai nhiem vu cu cua nhan vien -> false(da lam)
                            {
                                temp.ForEach(p => p.IsInProcess = false);

                            }

                            db.ChiTiet_NhiemVu_NhanVien.Add(cnn); //them nhiem vu moi voi trang thai  = true (dang lam)

                        }
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                string m = e.Message;
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "140")]
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
                                ConHan = (DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) > 0 ? "Hết Hạn" :
                                DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) <= 0 ? "Còn Hạn" : "Còn Hạn"
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

        [Auther(RightID = "138")]
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
                            where nv.MaTrangThai == 1
                            select new
                            {
                                TenNhanVien = nv.Ten,
                                MaNhanVien = nv.MaNV
                            });
                List<NhanVien_Extend> arrNhanVien = temp.ToList().Select(p => new NhanVien_Extend { Ten = p.TenNhanVien, MaNV = p.MaNhanVien }).ToList();
                foreach (NhanVien_Extend nv in arrNhanVien)
                {
                    foreach (ChiTiet_NhiemVu_NhanVien nvnv in db.ChiTiet_NhiemVu_NhanVien)
                    {
                        if (nv.MaNV.Equals(nvnv.MaNV) && nvnv.IsInProcess == true)
                        {
                            nv.MaNhiemVu.Add(nvnv.MaNhiemVu);
                        }
                    }
                }

                IOrderedEnumerable<NhanVien_Extend> arrnvorder = arrNhanVien.OrderBy(n => n.MaNV);
                int totalrows = arrNhanVien.Count;
                int totalrowsafterfiltering = arrNhanVien.Count;
                arrNhanVien = arrNhanVien.OrderBy(sortColumnName + " " + sortDirection).ToList<NhanVien_Extend>();
                arrNhanVien = arrNhanVien.Skip(start).Take(length).ToList<NhanVien_Extend>();

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

        [Auther(RightID = "141")]
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
                                where n.MaTrangThai == 1
                                join cc in db.ChungChis
                                on nv.MaChungChi equals cc.MaChungChi
                                join ccnv in db.ChungChi_NhanVien
                                on new { n.MaNV, cc.MaChungChi } equals new { ccnv.MaNV, ccnv.MaChungChi }
                                into tb
                                from mtb in tb.DefaultIfEmpty()
                                where n.MaPhongBan.Equals("DL1")
                                && ct.IsInProcess == true
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
                                where n.MaTrangThai == 1
                                join cc in db.ChungChis
                                on nv.MaChungChi equals cc.MaChungChi
                                join ccnv in db.ChungChi_NhanVien
                                on new { n.MaNV, cc.MaChungChi } equals new { ccnv.MaNV, ccnv.MaChungChi }
                                into tb
                                from mtb in tb.DefaultIfEmpty()
                                where n.MaPhongBan.Equals(maPhongBan)
                                && ct.IsInProcess == true
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

        [Auther(RightID = "141")]
        [HttpPost]
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


        [Auther(RightID = "142")]
        [HttpPost]
        public ActionResult XacNhanGiaHan(string data)
        {
            dynamic dataJson = JObject.Parse(data);
            dynamic maNV = dataJson.mnv;
            dynamic maCC = dataJson.mcc;
            dynamic ngayCap = DateTime.ParseExact(Convert.ToString(dataJson.ngaycap), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            dynamic sohieu = dataJson.sohieu + "";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ChungChi_NhanVien ccnv = new ChungChi_NhanVien { MaNV = maNV, MaChungChi = maCC, NgayCap = Convert.ToDateTime(ngayCap), SoHieu = sohieu };
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

        [Auther(RightID = "143")]
        [HttpPost]
        public ActionResult XacNhanThemMoi(string data)
        {
            try
            {
                dynamic dataJson = JObject.Parse(data);
                dynamic maNV = dataJson.mnv;
                dynamic maCC = dataJson.mcc;
                dynamic ngayCap = DateTime.ParseExact(Convert.ToString(dataJson.ngaycap), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                            .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                dynamic sohieu = dataJson.sohieu + "";
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    ChungChi_NhanVien ccnv = new ChungChi_NhanVien { MaNV = maNV, MaChungChi = maCC, NgayCap = Convert.ToDateTime(ngayCap), SoHieu = sohieu };
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
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public void ExportExcel(string pb = "")
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Report_Job.xlsx");
            FileInfo file = new FileInfo(path);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    List<NhanVien_Extend> arrNhanVien = null;
                    if (pb.Equals(""))
                    {
                        var temp = (from px in db.Departments
                                    join
                                    nv in db.NhanViens
                                    on px.department_id equals nv.MaPhongBan
                                    where nv.MaTrangThai == 1
                                    select new
                                    {
                                        TenNhanVien = nv.Ten,
                                        MaNhanVien = nv.MaNV
                                    });
                        arrNhanVien = temp.ToList().Select(p => new NhanVien_Extend { Ten = p.TenNhanVien, MaNV = p.MaNhanVien }).ToList();
                    }
                    else
                    {
                        var temp = (from px in db.Departments
                                    join
                                    nv in db.NhanViens
                                    on px.department_id equals nv.MaPhongBan
                                    where px.department_name.Equals(pb)
                                    && nv.MaTrangThai == 1
                                    select new
                                    {
                                        TenNhanVien = nv.Ten,
                                        MaNhanVien = nv.MaNV
                                    });
                        arrNhanVien = temp.ToList().Select(p => new NhanVien_Extend { Ten = p.TenNhanVien, MaNV = p.MaNhanVien }).ToList();
                    }

                    foreach (NhanVien_Extend nv in arrNhanVien)
                    {
                        foreach (ChiTiet_NhiemVu_NhanVien nvnv in db.ChiTiet_NhiemVu_NhanVien)
                        {
                            if (nv.MaNV.Equals(nvnv.MaNV) && nvnv.IsInProcess == true)
                            {
                                nv.MaNhiemVu.Add(nvnv.MaNhiemVu);
                            }
                        }
                    }
                    excelWorksheet.Cells[1, 1, 2, 1].Merge = true;
                    excelWorksheet.Cells[1, 1].Value = "Mã nhân viên";
                    excelWorksheet.Cells[1, 2, 2, 2].Merge = true;
                    excelWorksheet.Cells[1, 2].Value = "Tên nhân viên";

                    IOrderedEnumerable<NhiemVu> arrNhiemVu = db.NhiemVus.ToList().OrderBy(n => n.Loai);

                    List<MyModal> PhanXuongModel = new List<MyModal>();


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
                            PhanXuongModel.Add(tempModel);
                        }
                        else
                        {
                            tempModel.arrNV.Add(v);
                        }
                    }
                    int k = 0;
                    int currentPonter = 3;
                    for (int i = 3; i < PhanXuongModel.Count + 3; i++) //done
                    {
                        excelWorksheet.Cells[1, currentPonter, 1, currentPonter + PhanXuongModel.ElementAt(k).arrNV.Count - 1].Merge = true;
                        excelWorksheet.Cells[1, currentPonter].Value = PhanXuongModel.ElementAt(k).loai;
                        currentPonter += PhanXuongModel.ElementAt(k).arrNV.Count;
                        k++;
                    }

                    int m = 3;
                    for (int i = 0; i < PhanXuongModel.Count; i++)
                    {
                        k = 0;
                        for (int j = 3; j < PhanXuongModel.ElementAt(i).arrNV.Count + 3; j++)
                        {
                            excelWorksheet.Cells[2, m].Value = PhanXuongModel.ElementAt(i).arrNV.ElementAt(k).TenNhiemVu;
                            k++;
                            m++;
                        }
                    }

                    int x = 3, y = 1;
                    foreach (NhanVien_Extend nvien in arrNhanVien)
                    {
                        y = 1;
                        excelWorksheet.Cells[x, y].Value = nvien.MaNV;
                        y++;
                        excelWorksheet.Cells[x, y].Value = nvien.Ten;
                        y++;
                        foreach (var px in PhanXuongModel)
                        {
                            foreach (var nvu in px.arrNV)
                            {
                                if (nvien.MaNhiemVu.Contains(nvu.MaNhiemVu))
                                {
                                    excelWorksheet.Cells[x, y].Value = "Đang làm";
                                    y++;
                                }
                                else
                                {
                                    excelWorksheet.Cells[x, y].Value = "-";
                                    y++;
                                }

                            }
                        }
                        x++;
                    }
                    string location = HostingEnvironment.MapPath("/excel/TCLD/download");
                    if (pb.Equals(""))
                    {
                        excelPackage.SaveAs(new FileInfo(location + "/Report_Job_Total.xlsx"));
                    }
                    else
                    {
                        excelPackage.SaveAs(new FileInfo(location + "/Report_Job_" + pb + ".xlsx"));
                    }
                }
            }

        }
    }
}
