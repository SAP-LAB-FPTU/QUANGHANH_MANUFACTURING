using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Occupation
{
    public class GroupOccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-nhom-cong-viec")]
        public ActionResult view()
        {
            getData_From_DienCongViec();
            return View("/Views/TCLD/Occupation/GroupOccupation.cshtml");
        }

        ////////////////////////////////LIST////////////////////////////////////
        [Route("phong-tcld/quan-ly-nhom-cong-viec/danh-sach-nhom-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {

            List<NhomCongViec_DienCongViec> listData = new List<NhomCongViec_DienCongViec>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                var sqlList = @"select a.TenNhomCongViec, a.LoaiNhomCongViec, b.TenDienCongViec from NhomCongViec a 
                            left outer join DienCongViec b on a.MaDienCongViec = b.MaDienCongViec";
                listData = db.Database.SqlQuery<NhomCongViec_DienCongViec>(sqlList).ToList();

                int totalrows = listData.Count();
                int totalrowsafterfiltering = totalrows;

                //sorting
                listData = listData.OrderBy<NhomCongViec_DienCongViec>(sortColumnName + " " + sortDirection).ToList();
                //paging
                listData = listData.Skip(start).Take(length).ToList<NhomCongViec_DienCongViec>();

                return Json(new { listData = listData, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering}, JsonRequestBehavior.AllowGet);
            }
        }

        //////////////////////////////GET DATA FROM DIENCONGVIEC TABLE//////////////////////////////////
        public void getData_From_DienCongViec()
        {
            try
            {
                List<DienCongViec> listDienCongViec = new List<DienCongViec>();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var sqlListData_DienCongViec = @"select * from DienCongViec";
                    listDienCongViec = db.Database.SqlQuery<DienCongViec>(sqlListData_DienCongViec).ToList<DienCongViec>();
                    ViewBag.listDienCongViec = listDienCongViec;
                }
            }
            catch (Exception e)
            {

            }
        }

        public class NhomCongViec_DienCongViec : NhomCongViec
        {
            public string TenDienCongViec { get; set; }
        }
    }
}