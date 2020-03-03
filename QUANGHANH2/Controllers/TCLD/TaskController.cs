using Newtonsoft.Json.Linq;
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
            dynamic dataJson = JObject.Parse(data);

            string name = dataJson.name==null?"": dataJson.name.Trim();
            string mnv = dataJson.mnv == null ? "" : dataJson.mnv;
            mnv = mnv.Trim();
            try { string[] d = mnv.Split(' '); mnv = ""; foreach (string i in d) { mnv += "'" + i + "',"; } mnv = mnv.Substring(0, mnv.Length - 1); mnv = mnv == "''" ? "" : mnv; } catch (Exception e) { }
            string dept_id = dataJson.px==null?"": dataJson.px;
            dept_id = dept_id.Trim();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string sql = @"select * from nhanvien nv join Department dp
                on nv.MaPhongBan=dp.department_id and nv.MaTrangThai<>2 and nv.Ten like @name";
                sql += mnv == "" ? "" : " and nv.MaNV in (" + mnv + ")";
                sql += dept_id == "" ? "" : " and nv.MaPhongBan=@phongban";
                List<NhanVien> listMaNV = db.Database.SqlQuery<NhanVien>(sql + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("name", "%" + name + "%"),
                    new SqlParameter("phongban", dept_id)).ToList();
                int totalrows = db.Database.SqlQuery<int>(sql.Replace("*","count(*)"), 
                    new SqlParameter("name", "%" + name + "%"),
                    new SqlParameter("phongban", dept_id)).ToList()[0];
                return getData(listMaNV, totalrows);
            }

        }

        public ActionResult SearchEmployeeInPX(string data)
        {

            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string department_id = Session["departID"].ToString();
                dynamic dataJson = JObject.Parse(data);

                string name = dataJson.name;
                string mnv = dataJson.mnv;

                List<NhanVien_Extend> emp = null;
                if (mnv != null)
                { // search bang mnv
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (nv.MaNV.Contains(mnv))
                                && nv.MaTrangThai == 1
                                && pxx.department_id.Equals(department_id)
                                select new
                                {
                                    pxx.department_name,
                                    nv.Ten,
                                    nv.MaNV
                                }).FirstOrDefault();
                    emp = new List<NhanVien_Extend>();

                    if (temp != null)
                    {
                        NhanVien_Extend nv = new NhanVien_Extend { Ten = temp.Ten, MaNV = temp.MaNV };
                        emp.Add(nv);

                    }
                }
                else if (name == null && mnv == null) //  chi search bang px
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens

                                on pxx.department_id equals nv.MaPhongBan
                                where nv.MaTrangThai == 1
                                && pxx.department_id.Equals(department_id)
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    emp = temp.ToList().Select(p => new NhanVien_Extend { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                }
                else if (name != null && mnv == null) // chi search bang name
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (nv.Ten.Contains(name))
                                && nv.MaTrangThai == 1
                                && pxx.department_id.Equals(department_id)
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    emp = temp.ToList().Select(p => new NhanVien_Extend { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                }
                else if (name != null && mnv == null) // search bang ten va px
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where (nv.Ten.Contains(name)
                                && nv.MaTrangThai == 1
                                && pxx.department_id.Equals(department_id))
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    emp = temp.ToList().Select(p => new NhanVien_Extend { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                }
                else // lay ra all
                {
                    var temp = (from pxx in db.Departments
                                join
                                nv in db.NhanViens
                                on pxx.department_id equals nv.MaPhongBan
                                where pxx.department_id.Equals(department_id)
                                select new
                                {
                                    nv.Ten,
                                    nv.MaNV
                                });
                    emp = temp.ToList().Select(p => new NhanVien_Extend { MaNV = p.MaNV, Ten = p.Ten }).ToList();
                }
                IOrderedEnumerable<NhiemVu> arrNhiemVu = db.NhiemVus.ToList().OrderBy(n => n.Loai);
                int totalrows = emp.Count;
                int totalrowsafterfiltering = emp.Count;
                emp = emp.Skip(start).Take(length).ToList<NhanVien_Extend>();

                foreach (NhanVien_Extend nv in emp)
                {
                    foreach (NhiemVu nvu in arrNhiemVu)
                    {

                        var isNvienDoingThisJob = (from nvnhiemvu in db.ChiTiet_NhiemVu_NhanVien
                                                   where nvnhiemvu.MaNV.Equals(nv.MaNV)
                                                   && nvnhiemvu.MaNhiemVu.Equals(nvu.MaNhiemVu)
                                                   && nvnhiemvu.IsInProcess == true
                                                   select new { nvnhiemvu.MaNV }
                                  ).FirstOrDefault();
                        if (isNvienDoingThisJob != null)
                        {
                            int mcc = Convert.ToInt16(nvu.MaChungChi);
                            TinhTrangChungChi ttcc = CheckTinhTrangChungChi(nv.MaNV, mcc);
                            Chung_Chi_Nhan_Vien_Extend ccnv;
                            if (ttcc == null)
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = nvu.MaNhiemVu,
                                    TinhTrangChungChi = "Chưa có",
                                    SoNgay = 0,
                                    MaChungChi = mcc
                                };
                            }
                            else
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = nvu.MaNhiemVu,
                                    TinhTrangChungChi = ttcc.TinhTrang,
                                    SoNgay = ttcc.SoNgay,
                                    MaChungChi = mcc
                                };
                            }
                            nv.MaNhiemVu.Add(nvu.MaNhiemVu);
                            nv.ChungChiNhiemVu.Add(ccnv);
                        }
                        else
                        {
                            int mcc = Convert.ToInt16(nvu.MaChungChi);
                            TinhTrangChungChi ttcc = CheckTinhTrangChungChi(nv.MaNV, mcc);
                            Chung_Chi_Nhan_Vien_Extend ccnv;
                            if (ttcc == null)
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = -1,
                                    TinhTrangChungChi = "Chưa có",
                                    SoNgay = 0,
                                    MaChungChi = mcc
                                };
                            }
                            else
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = -1,
                                    TinhTrangChungChi = ttcc.TinhTrang,
                                    SoNgay = ttcc.SoNgay,
                                    MaChungChi = mcc
                                };
                            }
                            nv.ChungChiNhiemVu.Add(ccnv);
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
                var temp = (from a in db.Departments where a.department_type.Contains("chính") select new { MaPhanXuong = a.department_id, TenPhanXuong = a.department_name }).ToList();

                IEnumerable<Department> arrPhanXuong = temp.Select(p => new Department { department_id = p.MaPhanXuong, department_name = p.TenPhanXuong });
                ViewBag.nameDepartment = "vld-antoan";
                ViewBag.PhanXuongs = arrPhanXuong;
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

        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [Route("phan-xuong/dang-ki-nhiem-vu")]
        public ActionResult DangKiNhiemVu()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from a in db.Departments where a.department_type.Contains("chính") select new { TenPhanXuong = a.department_name }).ToList();

                IEnumerable<Department> arrPhanXuong = temp.Select(p => new Department { department_name = p.TenPhanXuong });
                ViewBag.nameDepartment = "vld-antoan";
                ViewBag.PhanXuongs = arrPhanXuong;
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
                return View("/Views/PX/PXKT/DangKiNhiemVu.cshtml");
            }
        }

        // [Auther(RightID = "139")]
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
                    DateTime now = DateTime.Now;
                    if (removedTask != null)
                    {
                        foreach (string rt in removedTask) // truong hop bo nhiem vu cua nhan vien di va khong dang ki cai moi
                        {
                            rtSplit = rt.Split('_');
                            string mnv = rtSplit[1];
                            int mnvu = Convert.ToInt16(rtSplit[0]);
                            ChiTiet_NhiemVu_NhanVien at = db.ChiTiet_NhiemVu_NhanVien.Where(p => p.MaNV.Equals(mnv)
                            && p.MaNhiemVu.Equals(mnvu) && p.IsInProcess == true && p.IsUpdated == false).FirstOrDefault();
                            if (at != null)
                            {
                                at.IsUpdated = true;
                            }
                            ChiTiet_NhiemVu_NhanVien nvu = new ChiTiet_NhiemVu_NhanVien
                            {
                                MaNV = mnv,
                                MaNhiemVu = mnvu,
                                NgayNhanNhiemVu = now,
                                IsInProcess = false,
                                IsUpdated = false,
                                LanCuoiCapNhat = now
                            };
                            db.ChiTiet_NhiemVu_NhanVien.Add(nvu);
                        }
                    }

                    if (tasks != null)
                    {
                        foreach (string t in tasks) // truong hop bo nhiem vu cua nhan vien di va khong dang ki cai moi
                        {
                            tSplit = t.Split('_');
                            string mnv = tSplit[1];
                            int mnvu = Convert.ToInt16(tSplit[0]);
                            ChiTiet_NhiemVu_NhanVien at = db.ChiTiet_NhiemVu_NhanVien.Where(p => p.MaNV.Equals(mnv)
                            && p.MaNhiemVu.Equals(mnvu) && p.IsUpdated == false).FirstOrDefault();
                            if (at != null)
                            {
                                if (!at.IsInProcess == true)
                                {
                                    at.IsUpdated = true;
                                    ChiTiet_NhiemVu_NhanVien nvu = new ChiTiet_NhiemVu_NhanVien
                                    {
                                        MaNV = mnv,
                                        MaNhiemVu = mnvu,
                                        NgayNhanNhiemVu = now,
                                        IsInProcess = true,
                                        IsUpdated = false,
                                        LanCuoiCapNhat = now
                                    };
                                    db.ChiTiet_NhiemVu_NhanVien.Add(nvu);
                                }
                            }
                            else
                            {
                                ChiTiet_NhiemVu_NhanVien nvu = new ChiTiet_NhiemVu_NhanVien
                                {
                                    MaNV = mnv,
                                    MaNhiemVu = mnvu,
                                    NgayNhanNhiemVu = now,
                                    IsInProcess = true,
                                    IsUpdated = false,
                                    LanCuoiCapNhat = now
                                };
                                db.ChiTiet_NhiemVu_NhanVien.Add(nvu);
                            }

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

        // [Auther(RightID = "138")]
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
                List<NhanVien> listMaNV = (from px in db.Departments
                                                  join
                                                  nv in db.NhanViens
                                                  on px.department_id equals nv.MaPhongBan
                                                  where nv.MaTrangThai != 2
                                                  select nv).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
                int totalrows = db.NhanViens.Where(x => x.MaTrangThai != 2).ToList().Count;
                return getData(listMaNV, totalrows);
            }
        }

        public JsonResult getData(List<NhanVien> listMaNV,int totalrows)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string arrMaNV = "";
                foreach (NhanVien n in listMaNV)
                {
                    arrMaNV += "'" + n.MaNV + "',";
                }
                string sql = "select a.SoHieu,a.NgayCap,a.MaNV,a.MaChungChi," +
                            "NhanVien.Ten as TenNV," +
                            "(CASE when (getDate() between a.NgayCap and DATEADD(month, chungchi.ThoiHan, a.NgayCap)) then '1' else '0' end)" +
                            "as isConHan," +
                            "chungchi.TenChungChi from chungchi,NhanVien,"
                            + "(select * from chungchi_nhanvien "+(arrMaNV.Length<=0?"": " where manv in (" + arrMaNV.Substring(0, arrMaNV.Length - 1) + ")") +") a" +
                            " where chungchi.MaChungChi=a.MaChungChi and NhanVien.MaNV=a.MaNV and NhanVien.MaTrangThai!=2 order by a.MaNV";
                List<ChungChi_NhanVien_Model> listNhanVien_ChungChi = db.Database.SqlQuery<ChungChi_NhanVien_Model>(sql).ToList();

                //lấy list tất cả các trạng thái và set giá trị status (ý là tình trạng) về false hết để làm sample
                List<TrangThaiChungChiNhanVienModel> listChungChiDefault =
                    (from cc in db.ChungChis
                     select new TrangThaiChungChiNhanVienModel
                     {
                         MaChungChi = cc.MaChungChi,
                         TenChungChi = cc.TenChungChi,
                         KieuChungChi = cc.KieuChungChi,
                         ThoiHan = cc.ThoiHan,
                     })
                    .ToList<TrangThaiChungChiNhanVienModel>();
                IOrderedEnumerable<NhiemVu> orders_chungchi = db.NhiemVus.ToList().OrderBy(n => n.Loai);
                int[] newOrder = new int[orders_chungchi.Count()];
                for (int j = 0; j < orders_chungchi.Count(); j++) { newOrder[j] = (int)orders_chungchi.ElementAt(j).MaChungChi; }
                //sort list chứng chỉ theo như thứ tự ở bảng ngoài view luôn để tránh việc chạy nhiều vòng lặp và tiết kiệm bước xử lý
                Dictionary<int, int> newOrderIndexedMap = Enumerable.Range(0, newOrder.Length).ToDictionary(r => newOrder[r], r => r);
                listChungChiDefault = listChungChiDefault.OrderBy(test => newOrderIndexedMap[test.MaChungChi]).ToList();

                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                List<NhanVienChungChiNewModel> list = new List<NhanVienChungChiNewModel>();
                foreach (NhanVien nv in listMaNV)
                {
                    NhanVienChungChiNewModel a = new NhanVienChungChiNewModel();
                    a.chungchi = listChungChiDefault.Select(x => (TrangThaiChungChiNhanVienModel)x.Clone()).ToList();
                    a.Ten = nv.Ten;
                    a.MaNV = nv.MaNV;
                    foreach (TrangThaiChungChiNhanVienModel thisChungChi in a.chungchi)
                    {
                        foreach (ChungChi_NhanVien_Model ccnv in listNhanVien_ChungChi)
                        {
                            if (ccnv.MaNV == nv.MaNV && ccnv.MaChungChi == thisChungChi.MaChungChi)
                            {
                                thisChungChi.status = ccnv.isConHan == "1";
                            }
                        }
                    }
                    list.Add(a);
                }
                int totalrowsafterfiltering = totalrows;
                return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetAllNhanVienByPX2()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];


            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string department_id = Session["departID"].ToString();
                var temp = (from px in db.Departments
                            join
                            nv in db.NhanViens
                            on px.department_id equals nv.MaPhongBan
                            where nv.MaTrangThai == 1
                            && px.department_id.Equals(department_id)
                            select new
                            {
                                TenNhanVien = nv.Ten,
                                MaNhanVien = nv.MaNV
                            });
                List<NhanVien_Extend> arrNhanVien = temp.ToList().Select(p => new NhanVien_Extend { Ten = p.TenNhanVien, MaNV = p.MaNhanVien }).ToList();
                IOrderedEnumerable<NhiemVu> arrNhiemVu = db.NhiemVus.ToList().OrderBy(n => n.Loai);
                int totalrows = arrNhanVien.Count;
                int totalrowsafterfiltering = arrNhanVien.Count;
                arrNhanVien = arrNhanVien.Skip(start).Take(length).ToList<NhanVien_Extend>();
                foreach (NhanVien_Extend nv in arrNhanVien)
                {
                    foreach (NhiemVu nvu in arrNhiemVu)
                    {

                        var isNvienDoingThisJob = (from nvnhiemvu in db.ChiTiet_NhiemVu_NhanVien
                                                   where nvnhiemvu.MaNV.Equals(nv.MaNV)
                                                   && nvnhiemvu.MaNhiemVu.Equals(nvu.MaNhiemVu)
                                                   && nvnhiemvu.IsInProcess == true
                                                   && nvnhiemvu.IsUpdated == false
                                                   select new { nvnhiemvu.MaNV }
                                  ).FirstOrDefault();
                        if (isNvienDoingThisJob != null)
                        {
                            int mcc = Convert.ToInt16(nvu.MaChungChi);
                            TinhTrangChungChi ttcc = CheckTinhTrangChungChi(nv.MaNV, mcc);
                            Chung_Chi_Nhan_Vien_Extend ccnv;
                            if (ttcc == null)
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = nvu.MaNhiemVu,
                                    TinhTrangChungChi = "Chưa có",
                                    SoNgay = 0,
                                    MaChungChi = mcc
                                };
                            }
                            else
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = nvu.MaNhiemVu,
                                    TinhTrangChungChi = ttcc.TinhTrang,
                                    SoNgay = ttcc.SoNgay,
                                    MaChungChi = mcc
                                };
                            }
                            nv.MaNhiemVu.Add(nvu.MaNhiemVu);
                            nv.ChungChiNhiemVu.Add(ccnv);
                        }
                        else
                        {
                            int mcc = Convert.ToInt16(nvu.MaChungChi);
                            TinhTrangChungChi ttcc = CheckTinhTrangChungChi(nv.MaNV, mcc);
                            Chung_Chi_Nhan_Vien_Extend ccnv;
                            if (ttcc == null)
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = -1,
                                    TinhTrangChungChi = "Chưa có",
                                    SoNgay = 0,
                                    MaChungChi = mcc
                                };
                            }
                            else
                            {
                                ccnv = new Chung_Chi_Nhan_Vien_Extend
                                {
                                    MaNhiemVu = -1,
                                    TinhTrangChungChi = ttcc.TinhTrang,
                                    SoNgay = ttcc.SoNgay,
                                    MaChungChi = mcc
                                };
                            }
                            nv.ChungChiNhiemVu.Add(ccnv);
                        }

                    }
                }

                IOrderedEnumerable<NhanVien_Extend> arrnvorder = arrNhanVien.OrderBy(n => n.MaNV);

                arrNhanVien = arrNhanVien.OrderBy(sortColumnName + " " + sortDirection).ToList<NhanVien_Extend>();

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

        private class TinhTrangChungChi
        {
            public string TinhTrang { get; set; }
            public int? SoNgay { get; set; }
        }

        private TinhTrangChungChi CheckTinhTrangChungChi(string mnv, int mcc)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from n in db.NhanViens
                            join ccnv in db.ChungChi_NhanVien
                            on n.MaNV equals ccnv.MaNV
                            where n.MaNV.Equals(mnv)
                            join cc in db.ChungChis
                            on ccnv.MaChungChi equals cc.MaChungChi
                            where cc.MaChungChi.Equals(mcc)
                            select new
                            {
                                IsConHan = (DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) > 0 ? "Hết hạn" :
                                            DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) <= 0 ? "Còn hạn" : "Chưa có")
                                            ,
                                SoNgay = (DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) < 0 ? -DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) :
                                           DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) >= 0 ? DbFunctions.DiffDays(DbFunctions.AddMonths(ccnv.NgayCap, cc.ThoiHan), DateTime.Now) : 0),
                            }
                             ).FirstOrDefault();
                if (temp == null)
                {
                    return null;
                }
                TinhTrangChungChi ttcc = new TinhTrangChungChi { TinhTrang = temp.IsConHan, SoNgay = temp.SoNgay };
                return ttcc;
            }
        }

        [Auther(RightID = "141")]
        [Route("phong-tcld/bao-cao-tinh-trang-chung-chi-cho-cong-viec")]
        public ActionResult ReportJob(string maPhongBan = "", string tenPhongBan = "")
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from a in db.Departments where a.department_type.Contains("chính") select new { maPhongBan = a.department_id, TenPhanXuong = a.department_name }).ToList();
                IEnumerable<Department> arrPhanXuong = temp.Select(p => new Department { department_id = p.maPhongBan, department_name = p.TenPhanXuong });
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

        [Auther(RightID = "141")]
        [HttpPost]
        public ActionResult getThemMoiPopUpInfo(string maNV, int maCC)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var temp = (from n in db.NhanViens
                            where n.MaNV.Equals(maNV)
                            select new
                            {
                                TenNhanVien = n.Ten,
                            }).FirstOrDefault();
                var temp1 = (from cc in db.ChungChis
                             where cc.MaChungChi.Equals(maCC)
                             select new
                             {
                                 TenChungChi = cc.TenChungChi,
                             }).FirstOrDefault();

                ChungChi_NhanVien_Model ccnv = new ChungChi_NhanVien_Model { TenChungChi = temp1.TenChungChi, TenNV = temp.TenNhanVien };
                return Json(new { success = true, data = ccnv }, JsonRequestBehavior.AllowGet);
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
                                    where px.department_id.Equals(pb)
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
                            if (nv.MaNV.Equals(nvnv.MaNV) && nvnv.IsInProcess == true && Convert.ToBoolean(nvnv.IsUpdated) == false)
                            {

                                var mccTemp = (from nvunv in db.ChiTiet_NhiemVu_NhanVien
                                               join NhiemVu nvu in db.NhiemVus
                                               on nvunv.MaNhiemVu equals nvu.MaNhiemVu
                                               join cc in db.ChungChis
                                               on nvu.MaChungChi equals cc.MaChungChi
                                               where nvu.MaNhiemVu.Equals(nvnv.MaNhiemVu)
                                               select new { mcc = cc.MaChungChi }
                                           ).FirstOrDefault();
                                int mcc = mccTemp.mcc;
                                TinhTrangChungChi ttcc = CheckTinhTrangChungChi(nv.MaNV, mcc);
                                Chung_Chi_Nhan_Vien_Extend ccnv;
                                if (ttcc == null)
                                {
                                    ccnv = new Chung_Chi_Nhan_Vien_Extend
                                    {
                                        MaNhiemVu = nvnv.MaNhiemVu,
                                        TinhTrangChungChi = "Chưa có",
                                        SoNgay = 0,
                                        MaChungChi = mcc
                                    };
                                }
                                else
                                {
                                    ccnv = new Chung_Chi_Nhan_Vien_Extend
                                    {
                                        MaNhiemVu = nvnv.MaNhiemVu,
                                        TinhTrangChungChi = ttcc.TinhTrang,
                                        SoNgay = ttcc.SoNgay,
                                        MaChungChi = mcc
                                    };
                                }

                                nv.MaNhiemVu.Add(nvnv.MaNhiemVu);
                                nv.ChungChiNhiemVu.Add(ccnv);
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
                        foreach (MyModal px in PhanXuongModel)
                        {
                            foreach (NhiemVu nvu in px.arrNV)
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
        public void ExportExcelInPX()
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Report_Job.xlsx");
            FileInfo file = new FileInfo(path);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string department_id = Session["departID"].ToString();
                    List<NhanVien_Extend> arrNhanVien = null;

                    var temp = (from px in db.Departments
                                join
                                nv in db.NhanViens
                                on px.department_id equals nv.MaPhongBan
                                where nv.MaTrangThai == 1
                                && px.department_id.Equals(department_id)
                                select new
                                {
                                    TenNhanVien = nv.Ten,
                                    MaNhanVien = nv.MaNV
                                });
                    arrNhanVien = temp.ToList().Select(p => new NhanVien_Extend { Ten = p.TenNhanVien, MaNV = p.MaNhanVien }).ToList();

                    foreach (NhanVien_Extend nv in arrNhanVien)
                    {
                        foreach (ChiTiet_NhiemVu_NhanVien nvnv in db.ChiTiet_NhiemVu_NhanVien)
                        {
                            if (nv.MaNV.Equals(nvnv.MaNV) && nvnv.IsInProcess == true && Convert.ToBoolean(nvnv.IsUpdated) == false)
                            {

                                var mccTemp = (from nvunv in db.ChiTiet_NhiemVu_NhanVien
                                               join NhiemVu nvu in db.NhiemVus
                                               on nvunv.MaNhiemVu equals nvu.MaNhiemVu
                                               join cc in db.ChungChis
                                               on nvu.MaChungChi equals cc.MaChungChi
                                               where nvu.MaNhiemVu.Equals(nvnv.MaNhiemVu)
                                               select new { mcc = cc.MaChungChi }
                                           ).FirstOrDefault();
                                int mcc = mccTemp.mcc;
                                TinhTrangChungChi ttcc = CheckTinhTrangChungChi(nv.MaNV, mcc);
                                Chung_Chi_Nhan_Vien_Extend ccnv;
                                if (ttcc == null)
                                {
                                    ccnv = new Chung_Chi_Nhan_Vien_Extend
                                    {
                                        MaNhiemVu = nvnv.MaNhiemVu,
                                        TinhTrangChungChi = "Chưa có",
                                        SoNgay = 0,
                                        MaChungChi = mcc
                                    };
                                }
                                else
                                {
                                    ccnv = new Chung_Chi_Nhan_Vien_Extend
                                    {
                                        MaNhiemVu = nvnv.MaNhiemVu,
                                        TinhTrangChungChi = ttcc.TinhTrang,
                                        SoNgay = ttcc.SoNgay,
                                        MaChungChi = mcc
                                    };
                                }

                                nv.MaNhiemVu.Add(nvnv.MaNhiemVu);
                                nv.ChungChiNhiemVu.Add(ccnv);
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
                        foreach (MyModal px in PhanXuongModel)
                        {
                            foreach (NhiemVu nvu in px.arrNV)
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

                    excelPackage.SaveAs(new FileInfo(location + "/Report_Job_" + department_id + ".xlsx"));
                }
            }

        }

        class NhanVienChungChiNewModel
        {
            public String MaNV { get; set; }
            public String Ten { get; set; }
            public List<TrangThaiChungChiNhanVienModel> chungchi { get; set; }

        }
        class TrangThaiChungChiNhanVienModel : ChungChi, ICloneable
        {
            public bool status { get; set; }

            public TrangThaiChungChiNhanVienModel()
            {
                this.status = false;
            }
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }
    }
}
