using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.InputCharcoal
{
    public class InputController : Controller
    {
        // GET: Input
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/nhap-lieu-san-xuat")]
        public ActionResult InputCharcoal()
        {
            return View("/Views/DK/InputCharcoal/InputCharcoal.cshtml");
        }
        [Route("change")]
        [HttpPost]
        public JsonResult Change(string px_value, string to_value, string date)
        {
            List<TieuChi> tcList = null;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            if (px_value != null)
            {
                if (px_value.Contains("KT"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (2,24,9)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
                else if (px_value.Contains("DL"))
                {
                    if (px_value.Contains("TL") || px_value.Contains("AS") || px_value.Contains("XLM"))
                    {
                        string query = "select * from TieuChi where MaTieuChi in (1,23,9)";
                        tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                    }else
                    {
                        string query = "select * from TieuChi where MaTieuChi in (1,24,9)";
                        tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                    }
                }
                else if(px_value.Equals("KCS"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (18,19,22)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }else if(px_value.Equals("ST"))
                {

                }
            }
            return Json(new { success = true, list = tcList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveChange(string date, string px_value, string ca_value,
            string[] thucHien, string[] keHoach, string[] chenhLech, string[] phanTramTH,
            string[] luyKe, string[] KHDC, string[] phanTramTD, string[] tong, string[] motNgay, string[] ghiChu)
        {

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}