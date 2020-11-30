using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class BriefRegulationController : Controller
    {
        private object sqlBuilder;
        [Auther(RightID = "135")]
        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten")]
        [HttpGet]
        public ActionResult Regulation()
        {
            ViewBag.nameDepartment = "quanlyhoso";
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {

                var temp = (from cn in db.ChuyenNganhs select new { capbac = cn.CapBac }).Distinct();
                var data = temp.ToList().Select(p => new ChuyenNganh { CapBac = p.capbac }).ToList();

                ViewBag.List_CapBac = data;
            }
            return View("/Views/TCLD/Brief/ManageBrief/Regulations.cshtml");
        }

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten")]
        [HttpPost]
        public ActionResult List()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = 10;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<ChuyenNganh> listdata = db.ChuyenNganhs.ToList<ChuyenNganh>();

                int totalrows = listdata.Count;
                int totalrowsafterfiltering = listdata.Count;
                listdata = listdata.OrderBy(sortColumnName + " " + sortDirection).ToList<ChuyenNganh>();
                //paging
                listdata = listdata.Skip(start).Take(length).ToList<ChuyenNganh>();
                var js = Json(new { success = true, data = listdata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten/truong")]
        [HttpPost]
        public ActionResult ListTruong()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = 10;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Truong> listdata = new List<Truong>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                listdata = db.Truongs.ToList<Truong>();

                int totalrows = listdata.Count;
                int totalrowsafterfiltering = listdata.Count;
                listdata = listdata.OrderBy(sortColumnName + " " + sortDirection).ToList<Truong>();
                //paging
                listdata = listdata.Skip(start).Take(length).ToList<Truong>();
                var json = Json(new { success = true, data = listdata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(json.Data);
                return json;
            }
        }

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten/trinhdo")]
        [HttpPost]
        public ActionResult ListTrinhDo()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = 10;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<TrinhDo> listdata = new List<TrinhDo>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                listdata = db.TrinhDoes.ToList();
                int totalrows = listdata.Count;
                int totalrowsafterfiltering = listdata.Count;
                listdata = listdata.OrderBy(sortColumnName + " " + sortDirection).ToList<TrinhDo>();
                //paging
                listdata = listdata.Skip(start).Take(length).ToList<TrinhDo>();
                var json = Json(new { success = true, data = listdata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(json.Data);
                return json;
            }
        }

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten/nganh")]
        [HttpPost]
        public ActionResult ListNganh()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = 10;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Nganh> listdata = new List<Nganh>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                listdata = db.Nganhs.ToList();

                int totalrows = listdata.Count;
                int totalrowsafterfiltering = listdata.Count;
                listdata = listdata.OrderBy(sortColumnName + " " + sortDirection).ToList<Nganh>();
                //paging
                listdata = listdata.Skip(start).Take(length).ToList<Nganh>();
                var json = Json(new { success = true, data = listdata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(json.Data);
                return json;

            }
        }
        [Auther(RightID = "167")]
        [HttpPost]
        public ActionResult deleteChuyenNganh(string id = "")
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                ChuyenNganh chuyenNganh = db.ChuyenNganhs.Where(x => x.MaChuyenNganh.ToString().Equals(id)).FirstOrDefault<ChuyenNganh>();
                var bangcaps = db.BangCap_GiayChungNhan.Where(x => x.MaChuyenNganh.ToString().Equals(id)).ToList<BangCap_GiayChungNhan>();
                db.ChuyenNganhs.Remove(chuyenNganh);
                foreach (var bangcap in bangcaps)
                {
                    bangcap.MaChuyenNganh = null;
                }
                var nvs = db.NhanViens.Where(x => x.MaTrinhDo.ToString().Equals(id)).ToList<NhanVien>();
                foreach (var nv in nvs)
                {
                    nv.MaChuyenNganh = null;
                }
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }
        [Auther(RightID = "167")]

        [HttpPost]
        public ActionResult deleteNganh(string id = "")
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                Nganh nganh = db.Nganhs.Where(x => x.MaNganh.Equals(id)).FirstOrDefault<Nganh>();
                var cnganhs = db.ChuyenNganhs.Where(x => x.MaNganh.Equals(id)).ToList<ChuyenNganh>();
                db.Nganhs.Remove(nganh);
                foreach (var cnganh in cnganhs)
                {
                    db.ChuyenNganhs.Remove(cnganh);
                }
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }
        [Auther(RightID = "167")]
        [HttpPost]
        public ActionResult deleteTruong(string id = "")
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                Truong truong = db.Truongs.Where(x => x.MaTruong.ToString().Equals(id)).FirstOrDefault<Truong>();
                var bangcaps = db.BangCap_GiayChungNhan.Where(x => x.MaTruong.ToString().Equals(id)).ToList<BangCap_GiayChungNhan>();
                foreach (var bangcap in bangcaps)
                {
                    bangcap.MaTruong = null;
                }
                var nvs = db.NhanViens.Where(x => x.MaTrinhDo.ToString().Equals(id)).ToList<NhanVien>();
                foreach (var nv in nvs)
                {
                    nv.MaTruong = null;
                }
                db.Truongs.Remove(truong);
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }
        [Auther(RightID = "167")]
        [HttpPost]
        public ActionResult deleteTrinhDo(string id = "")
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                TrinhDo trinhDo = db.TrinhDoes.Where(x => x.MaTrinhDo.ToString().Equals(id)).FirstOrDefault<TrinhDo>();
                var bangcaps = db.BangCap_GiayChungNhan.Where(x => x.MaTrinhDo.ToString().Equals(id)).ToList<BangCap_GiayChungNhan>();
                foreach (var bangcap in bangcaps)
                {
                    bangcap.MaTrinhDo = null;
                }
                var nvs = db.NhanViens.Where(x => x.MaTrinhDo.ToString().Equals(id)).ToList<NhanVien>();
                foreach (var nv in nvs)
                {
                    nv.MaTrinhDo = null;
                }
                db.TrinhDoes.Remove(trinhDo);
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }
        [Auther(RightID = "136")]
        [HttpGet]
        public ActionResult ThemChuyenNganh()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<ChuyenNganh> listdata_chuyennganh = db.ChuyenNganhs.ToList<ChuyenNganh>();
                List<Nganh> listdata_nganh = db.Nganhs.ToList<Nganh>();

                SelectList listChuyenNganh = new SelectList(listdata_chuyennganh, "MaChuyenNganh", "TenChuyenNganh");
                SelectList listNganh = new SelectList(listdata_nganh, "MaNganh", "MaNganh");
                var temp = (from cn in db.ChuyenNganhs select new { capbac = cn.CapBac }).Distinct();
                var data = temp.ToList().Select(p => new ChuyenNganh { CapBac = p.capbac }).ToList();
                SelectList sl = new SelectList(data, "CapBac", "CapBac");
                ViewBag.List_CapBac = sl;
                ViewBag.List_chuyennganh = listChuyenNganh;
                ViewBag.List_nganh = listNganh;
                //  ViewBag.listdata_Nganh = listdata_nganh;
                return View();
            }
        }
        [Auther(RightID = "136")]
        [HttpPost]
        public ActionResult ThemChuyenNganh(ChuyenNganh chuyenNganh)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chuyenNganh != null)
                {
                    db.ChuyenNganhs.Add(chuyenNganh);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        [Auther(RightID = "137")]
        [HttpGet]
        public ActionResult SuaChuyenNganh(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                //var AllCN = db.ChuyenNganhs.ToList<ChuyenNganh>();
                ChuyenNganh temp = new ChuyenNganh();
                List<Nganh> listdata_nganh = db.Nganhs.ToList<Nganh>();
                temp = db.ChuyenNganhs.Where(x => x.MaChuyenNganh.Equals(id)).FirstOrDefault<ChuyenNganh>();
                SelectList listNganh = new SelectList(listdata_nganh, "MaNganh", "MaNganh");
                var temp1 = (from cn in db.ChuyenNganhs select new { capbac = cn.CapBac }).Distinct();
                var data = temp1.ToList().Select(p => new ChuyenNganh { CapBac = p.capbac }).ToList();
                SelectList sl = new SelectList(data, "CapBac", "CapBac");
                ViewBag.List_CapBac = sl;
                if (temp != null)
                {

                    String tenNganh = getTenNganh1(temp.MaNganh);
                    ViewBag.TenNganh = tenNganh;
                }

                ViewBag.List_nganh = listNganh;


                return View(temp);
            }
        }
        [Auther(RightID = "137")]
        [HttpPost]
        public ActionResult SuaChuyenNganh(ChuyenNganh chuyenNganh)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (chuyenNganh != null)
                {
                    db.Entry(chuyenNganh).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        [Auther(RightID = "137")]
        [HttpGet]
        public ActionResult SuaTruong(int id = 0)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                Truong truong = db.Truongs.Where(x => x.MaTruong == id).FirstOrDefault<Truong>();
                return View(truong);
            }
        }
        [Auther(RightID = "137")]
        [HttpPost]
        public ActionResult SuaTruong(Truong truong)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (truong != null)
                {
                    db.Entry(truong).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        [Auther(RightID = "137")]
        [HttpPost]
        public ActionResult SuaNganh(Nganh nganh)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (nganh != null)
                {
                    db.Entry(nganh).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        [Auther(RightID = "137")]
        [HttpGet]
        public ActionResult SuaNganh(string id = "")
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                Nganh nganh = db.Nganhs.Where(x => x.MaNganh.Equals(id)).FirstOrDefault<Nganh>();
                return View(nganh);
            }
        }


        [Auther(RightID = "137")]
        [HttpGet]
        public ActionResult SuaTrinhDo(int id = 0)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                TrinhDo trinhDo = db.TrinhDoes.Where(x => x.MaTrinhDo == id).FirstOrDefault<TrinhDo>();
                return View(trinhDo);
            }
        }
        [Auther(RightID = "137")]
        [HttpPost]
        public ActionResult SuaTrinhDo(TrinhDo trinhDo)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (trinhDo != null)
                {
                    db.Entry(trinhDo).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        [Auther(RightID = "136")]
        [HttpGet]
        public ActionResult ThemNganh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNganh(Nganh nganh)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (nganh != null)
                {
                    db.Nganhs.Add(nganh);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        [Auther(RightID = "136")]
        [HttpGet]
        public ActionResult ThemTruong()
        {
            return View();
        }
        [Auther(RightID = "136")]
        [HttpPost]
        public ActionResult ThemTruong(Truong truong)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (truong != null)
                {
                    if (db.Truongs.Where(x => x.TenTruong.Equals(truong.TenTruong) || x.MaTruong.Equals(truong.MaTruong)).Count() == 0)
                        db.Truongs.Add(truong);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        [Auther(RightID = "136")]
        [HttpGet]
        public ActionResult ThemTrinhDo()
        {
            return View();
        }
        [Auther(RightID = "136")]
        [HttpPost]
        public ActionResult ThemTrinhDo(TrinhDo trinhDo)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                if (trinhDo != null)
                {
                    db.TrinhDoes.Add(trinhDo);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult getTenNganh(string id = "")
        {
            //int intid = Convert.ToInt32(id);
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var nganh = db.Nganhs.Where(x => x.MaNganh.Equals(id)).FirstOrDefault<Nganh>();

                if (nganh != null)
                {
                    string tenNganh = nganh.TenNganh;
                    return Json(new { data = tenNganh, success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public string getTenNganh1(string id = "")
        {
            //int intid = Convert.ToInt32(id);
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var nganh = db.Nganhs.Where(x => x.MaNganh.Equals(id)).FirstOrDefault<Nganh>();

                if (nganh != null)
                {
                    string tenNganh = nganh.TenNganh;
                    return tenNganh;
                }
                else
                {
                    return null;
                }
            }
        }
        [HttpPost]
        public ActionResult validateIDCN(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var nv = db.ChuyenNganhs.Where(x => x.MaChuyenNganh.Equals(id)).FirstOrDefault<ChuyenNganh>();
                if (nv == null)
                {
                    return Json(new { success = false, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult validateIDN(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var mn = db.Nganhs.Where(x => x.MaNganh.ToString() == id).FirstOrDefault<Nganh>();
                if (mn == null)
                {
                    return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult validateIDTruong(string id, string name)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var mt = db.Truongs.Where(x => x.MaTruong.ToString().Equals(id) || x.TenTruong.Equals(name)).ToList();
                bool dup_id = false;
                bool dup_name = false;
                if (mt.Where(x => x.MaTruong.ToString().Equals(id)).Any())
                {
                    dup_id = true;
                }
                if (mt.Where(x => x.TenTruong.ToString().Equals(name)).Any())
                {
                    dup_name = true;
                }
                return Json(new { dup_id, dup_name });
            }
        }

        [HttpPost]
        public ActionResult validateIDTD(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var td = db.TrinhDoes.Where(x => x.MaTrinhDo.ToString().Equals(id)).FirstOrDefault<TrinhDo>();
                if (td == null)
                {
                    return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult validateIDNganh(string id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var n = db.Nganhs.Where(x => x.MaNganh.Equals(id)).FirstOrDefault<Nganh>();
                if (n == null)
                {
                    return Json(new { success = true, message = "id has been exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "right id" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult SearchSpecialized(string data)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            dynamic jsonData = JObject.Parse(data);
            string name = jsonData.name;
            string cb = jsonData.cb;
            if (name == "" && cb == "-1")
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<ChuyenNganh> listdata = db.ChuyenNganhs.ToList();
                var js = Json(new { success = true, data = listdata }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;

            }
            else if (name == "" && cb != "")
            {
                var temp = db.ChuyenNganhs.Where(p => p.CapBac.Equals(cb)).ToList();
                var result = temp.Select(p => new ChuyenNganh { MaChuyenNganh = p.MaChuyenNganh, TenChuyenNganh = p.TenChuyenNganh, CapBac = p.CapBac, ChiTiet = p.ChiTiet, MaNganh = p.MaNganh }).ToList();
                var jss = Json(new { success = true, message = "Search Thành Công", data = result }, JsonRequestBehavior.AllowGet);
                var result1 = JsonConvert.SerializeObject(jss);
                return jss;
            }
            else if (name != "" && cb == "-1")
            {
                var temp = db.ChuyenNganhs.Where(p => p.TenChuyenNganh.Contains(name)).ToList();
                var result = temp.Select(p => new ChuyenNganh { MaChuyenNganh = p.MaChuyenNganh, TenChuyenNganh = p.TenChuyenNganh, CapBac = p.CapBac, ChiTiet = p.ChiTiet, MaNganh = p.MaNganh });
                var jss = Json(new { success = true, message = "Search Thành Công", data = result }, JsonRequestBehavior.AllowGet);
                var result1 = JsonConvert.SerializeObject(jss);
                return jss;

            }
            else
            {
                var temp = db.ChuyenNganhs.Where(p => p.TenChuyenNganh.Contains(name) && p.CapBac.Equals(cb)).ToList();
                var result = temp.Select(p => new ChuyenNganh { MaChuyenNganh = p.MaChuyenNganh, TenChuyenNganh = p.TenChuyenNganh, CapBac = p.CapBac, ChiTiet = p.ChiTiet, MaNganh = p.MaNganh });
                var jss = Json(new { success = true, message = "Search Thành Công", data = result }, JsonRequestBehavior.AllowGet);
                var result1 = JsonConvert.SerializeObject(jss);
                return jss;
            }

        }

        private ActionResult QueryList(string sql)
        {
            throw new NotImplementedException();
        }
    }

}