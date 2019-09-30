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
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class BriefRegulationController : Controller
    {
        private object sqlBuilder;

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten")]
        [HttpGet]
        public ActionResult Regulation()
        {
            ViewBag.nameDepartment = "quanlyhoso";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<ChuyenNganh> listdata = db.ChuyenNganhs.ToList<ChuyenNganh>();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listdata, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten/truong")]
        [HttpPost]
        public ActionResult ListTruong()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<Truong> listdata = db.Truongs.ToList<Truong>();
                var js = Json(new { success = true, data = listdata }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten/trinhdo")]
        [HttpPost]
        public ActionResult ListTrinhDo()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<TrinhDo> listdata = db.TrinhDoes.ToList<TrinhDo>();
                var js = Json(new { success = true, data = listdata }, JsonRequestBehavior.AllowGet);
                var dataserialize = new JavaScriptSerializer().Serialize(js.Data);
                return js;
            }
        }

        [Route("phong-tcld/quan-ly-ho-so/chuan-hoa-ten/nganh")]
        [HttpPost]
        public ActionResult ListNganh()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<Nganh> listdata = db.Nganhs.ToList();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listdata, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult deleteChuyenNganh(string id = "")
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ChuyenNganh chuyenNganh = db.ChuyenNganhs.Where(x => x.MaChuyenNganh.ToString().Replace("\r\n", "").Equals(id)).FirstOrDefault<ChuyenNganh>();
                db.ChuyenNganhs.Remove(chuyenNganh);
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult deleteNganh(string id = "")
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Nganh nganh = db.Nganhs.Where(x => x.MaNganh.Equals(id)).FirstOrDefault<Nganh>();
                var cnganhs = db.ChuyenNganhs.Where(x => x.MaNganh.Equals(id)).ToList<ChuyenNganh>();
                db.Nganhs.Remove(nganh);
                foreach(var cnganh in cnganhs)
                {
                    db.ChuyenNganhs.Remove(cnganh);
                }
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult deleteTruong(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Truong truong = db.Truongs.Where(x => x.MaTruong == id).FirstOrDefault<Truong>();
                db.Truongs.Remove(truong);
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult deleteTrinhDo(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                TrinhDo trinhDo = db.TrinhDoes.Where(x => x.MaTrinhDo == id).FirstOrDefault<TrinhDo>();
                db.TrinhDoes.Remove(trinhDo);
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public ActionResult ThemChuyenNganh()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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

        [HttpPost]
        public ActionResult ThemChuyenNganh(ChuyenNganh chuyenNganh)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (chuyenNganh != null)
                {
                    db.ChuyenNganhs.Add(chuyenNganh);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult SuaChuyenNganh(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
                if(temp != null)
                {
                    
                    String tenNganh = getTenNganh1(temp.MaNganh);
                    ViewBag.TenNganh = tenNganh;
                }
                
                ViewBag.List_nganh = listNganh;
                
               
                return View(temp);
            }
        }

        [HttpPost]
        public ActionResult SuaChuyenNganh(ChuyenNganh chuyenNganh)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (chuyenNganh != null)
                {
                    db.Entry(chuyenNganh).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult SuaTruong(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Truong truong = db.Truongs.Where(x => x.MaTruong == id).FirstOrDefault<Truong>();
                return View(truong);
            }
        }

        [HttpPost]
        public ActionResult SuaTruong(Truong truong)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (truong != null)
                {
                    db.Entry(truong).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult SuaNganh(Nganh nganh)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (nganh != null)
                {
                    db.Entry(nganh).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult SuaNganh(string id = "")
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Nganh nganh = db.Nganhs.Where(x => x.MaNganh.Equals(id)).FirstOrDefault<Nganh>();
                return View(nganh);
            }
        }



        [HttpGet]
        public ActionResult SuaTrinhDo(int id = 0)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                TrinhDo trinhDo = db.TrinhDoes.Where(x => x.MaTrinhDo == id).FirstOrDefault<TrinhDo>();
                return View(trinhDo);
            }
        }

        [HttpPost]
        public ActionResult SuaTrinhDo(TrinhDo trinhDo)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (trinhDo != null)
                {
                    db.Entry(trinhDo).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ThemNganh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNganh(Nganh nganh)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (nganh != null)
                {
                    db.Nganhs.Add(nganh);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ThemTruong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTruong(Truong truong)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (truong != null)
                {
                    db.Truongs.Add(truong);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ThemTrinhDo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTrinhDo(TrinhDo trinhDo)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
        public ActionResult validateIDTruong(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var mt = db.Truongs.Where(x => x.MaTruong.ToString().Equals(id)).FirstOrDefault<Truong>();
                if (mt == null)
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
        public ActionResult validateIDTD(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
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
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            dynamic jsonData = JObject.Parse(data);
            string name = jsonData.name;
            string cb = jsonData.cb;
            if (name == "" && cb == "-1")
            {
                List<ChuyenNganh> listdata = db.ChuyenNganhs.ToList();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listdata, Formatting.Indented, jss);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);

            }
            else if (name == "" && cb != "")
            {
                var temp = db.ChuyenNganhs.Where(p => p.CapBac.Equals(cb)).ToList();
                var result = temp.Select(p => new ChuyenNganh { MaChuyenNganh = p.MaChuyenNganh, TenChuyenNganh = p.TenChuyenNganh, CapBac = p.CapBac, ChiTiet = p.ChiTiet, MaNganh = p.MaNganh }).ToList();

                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result1 = JsonConvert.SerializeObject(result, Formatting.Indented, jss);
                return Json(new { success = true, message = "Search Thành Công", data = result1 }, JsonRequestBehavior.AllowGet);
            }
            else if (name != "" && cb == "-1")
            {
                var temp = db.ChuyenNganhs.Where(p => p.TenChuyenNganh.Contains(name)).ToList();
                var result = temp.Select(p => new ChuyenNganh { MaChuyenNganh = p.MaChuyenNganh, TenChuyenNganh = p.TenChuyenNganh, CapBac = p.CapBac, ChiTiet = p.ChiTiet, MaNganh = p.MaNganh });
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result1 = JsonConvert.SerializeObject(result, Formatting.Indented, jss);
                return Json(new { success = true, message = "Search Thành Công", data = result1 }, JsonRequestBehavior.AllowGet);

            }
            else

            {
                var temp = db.ChuyenNganhs.Where(p => p.TenChuyenNganh.Contains(name) && p.CapBac.Equals(cb)).ToList();
                var result = temp.Select(p => new ChuyenNganh { MaChuyenNganh = p.MaChuyenNganh, TenChuyenNganh = p.TenChuyenNganh, CapBac = p.CapBac, ChiTiet = p.ChiTiet, MaNganh = p.MaNganh });
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result1 = JsonConvert.SerializeObject(result, Formatting.Indented, jss);
                return Json(new { success = true, message = "Search Thành Công", data = result1 }, JsonRequestBehavior.AllowGet);
            }

        }

        private ActionResult QueryList(string sql)
        {
            throw new NotImplementedException();
        }
    }

}