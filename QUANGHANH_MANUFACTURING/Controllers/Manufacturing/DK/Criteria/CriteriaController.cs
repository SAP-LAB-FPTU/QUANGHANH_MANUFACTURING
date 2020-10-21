using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.DK.Criteria
{
    public class CriteriaController : Controller
    {
        [Route("phong-dieu-khien/quan-ly-tieu-chi")]
        public ActionResult Index()
        {
            getdata_from_nhomtieuchi();
            return View("/Views/DK/Criteria/Criteria.cshtml");
        }

        ///////////////////////  LIST  ///////////////////////
        [Route("phong-dieu-khien/quan-ly-tieu-chi/danhsach")]
        [HttpGet]
        public ActionResult list()
        {
            List<TieuChi_Detail> listData = new List<TieuChi_Detail>();
            using(QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                var sqlList = @"SELECT a.TenNhomTieuChi, b.MaTieuChi, b.TenTieuChi, b.DonViDo
                            FROM NhomTieuChi as a INNER JOIN
                                                TieuChi as b ON a.MaNhomTieuChi = b.MaNhomTieuChi
                            order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                listData = db.Database.SqlQuery<TieuChi_Detail>(sqlList, JsonRequestBehavior.AllowGet).ToList();
                
                int totalrows = db.TieuChis.Count();
                int totalrowsafterfiltering = totalrows;

                return Json(new { listData = listData, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }
        ////////////////////////  ADD  /////////////////////////////////
        [Route("phong-dieu-khien/quan-ly-tieu-chi/them-tieu-chi")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                using(QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    int nhomtieuchi = Convert.ToInt32(Request["nhomtieuchi"]);
                    string tentieuchi = Request["tentieuchi"].ToString();
                    string donvido = Request["donvido"].ToString();

                    var validate = db.TieuChis.Where(s => s.MaNhomTieuChi == nhomtieuchi && s.TenTieuChi.Equals(tentieuchi)
                                    && s.DonViDo.Equals(donvido)).FirstOrDefault();
                    if(validate == null)
                    {
                        TieuChi tieuchi = new TieuChi();
                        tieuchi.MaNhomTieuChi = nhomtieuchi;
                        tieuchi.TenTieuChi = tentieuchi;
                        tieuchi.DonViDo = donvido;

                        db.TieuChis.Add(tieuchi);
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Thêm tiêu chí thành công." });
                    }
                    else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Tiêu chí này đã tồn tại" });
                    }
                }
            }
            catch(Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }
        ///////////////// GET VALUE FOR EDIT POPUP /////////////////////////

        [Route("phong-dieu-khien/quan-ly-tieu-chi/lay-du-lieu-theo-matieuchi")]
        [HttpPost]
        public ActionResult GetEditCriteria()
        {
            try
            {
                int matieuchi = Convert.ToInt32(Request["matieuchi"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string sql = @"SELECT * FROM TieuChi WHERE MaTieuChi = @matieuchi";
                    TieuChi item = db.Database.SqlQuery<TieuChi>(sql, new SqlParameter("matieuchi", matieuchi)).FirstOrDefault();
                    return Json(new { success = true, item = item });
                }

            }
            catch (Exception e)
            {
                return Json(new { error = true, message = "Có lỗi xảy ra." });
            }
        }

        ///////////////////////////  UPDATE ///////////////////////////
        [Route("phong-dieu-khien/quan-ly-tieu-chi/chinhsua-tieu-chi")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    int matieuchi = Convert.ToInt32(Request["matieuchi"]);
                    int manhomtieuchi = Convert.ToInt32(Request["manhomtieuchi"]);
                    string tentieuchi = Request["tentieuchi"].ToString();
                    string donvido = Request["donvido"].ToString();
                    var validate = db.TieuChis.Where(s => s.MaNhomTieuChi == manhomtieuchi && s.TenTieuChi.Equals(tentieuchi)
                                    && s.DonViDo.Equals(donvido) && s.MaTieuChi != matieuchi).FirstOrDefault();
                    if (validate == null)
                    {
                        var tieuchi = db.TieuChis.Where(m => m.MaTieuChi == matieuchi);
                        foreach (var item in tieuchi)
                        {
                            item.MaNhomTieuChi = manhomtieuchi;
                            item.TenTieuChi = tentieuchi;
                            item.DonViDo = donvido;

                        }
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Chỉnh sửa thành công" });
                    }
                    else
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Tiêu chí này đã tồn tại" });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }


        //////////////////////////  DELETE  ////////////////////////
        [Route("phong-dieu-khien/quan-ly-tieu-chi/xoa-tieu-chi")]
        [HttpPost]
        public ActionResult delete()
        {
            try
            {
                string ma_tieu_chi = Request["matieuchi"];
                int idma_tieu_chi = Convert.ToInt32(ma_tieu_chi);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    ///////////////// Check relationship before delete //////////////////
                    PhongBan_TieuChi pbtc = db.PhongBan_TieuChi.Where(x => x.MaTieuChi == idma_tieu_chi).FirstOrDefault();
                    KeHoach_TieuChi_TheoNgay kttctng = db.KeHoach_TieuChi_TheoNgay.Where(x => x.MaTieuChi == idma_tieu_chi).FirstOrDefault();
                    KeHoach_TieuChi_TheoThang kttctt = db.KeHoach_TieuChi_TheoThang.Where(x => x.MaTieuChi == idma_tieu_chi).FirstOrDefault();
                    KeHoach_TieuChi_TheoNam kttctna = db.KeHoach_TieuChi_TheoNam.Where(x => x.MaTieuChi == idma_tieu_chi).FirstOrDefault();
                    ThucHien_TieuChi_TheoNgay thtctn = db.ThucHien_TieuChi_TheoNgay.Where(x => x.MaTieuChi == idma_tieu_chi).FirstOrDefault();
                    if (pbtc != null || kttctng !=null || kttctt != null || kttctna != null || thtctn != null)
                    {
                        return Json(new { error = true, message = "Tiêu chí này vẫn đang được sử dụng" });
                    }
                    TieuChi delete_item = db.TieuChis.Where(tc => tc.MaTieuChi == idma_tieu_chi).FirstOrDefault<TieuChi>();
                    db.TieuChis.Remove(delete_item);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Xóa thành công." });
                }
            }
            catch
            {
                return Json(new { error = true, message = "Có lỗi xảy ra." });
            }
        }

        //////////////////// Creterial Detail ////////////////////
        public class TieuChi_Detail : TieuChi
        {
            public string TenNhomTieuChi { get; set; }
        }

        ////////////////// Get Data from Nhom Tieu Chi ///////////////////
        public void getdata_from_nhomtieuchi()
        {
            try
            {
                List<NhomTieuChi> listnhomtieuchi = new List<NhomTieuChi>();
                using(QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqlListNhom = @"select * from NhomTieuChi";
                    listnhomtieuchi = db.Database.SqlQuery<NhomTieuChi>(sqlListNhom).ToList<NhomTieuChi>();
                    ViewBag.listnhomtieuchi = listnhomtieuchi;
                }
            }
            catch
            {

            }
        }
    }
}