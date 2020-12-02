using QUANGHANH2.Models;
using QUANGHANH2.Models.HumanResources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.TCLD
{
    public class WorkController : Controller
    {
        [Route("phong-tcld/quan-ly-cong-viec")]
        public ActionResult Index()
        {
            //get data from PayTable table to fill to select > option
            getDataFromPayTable();
            return View("/Views/TCLD/Work/Work.cshtml");
        }

        //////////////////////////////////////GET DATA FROM THANGLUONG///////////////////////////////////////
        public void getDataFromPayTable()
        {
            try
            {
                List<PayTable> list_pay_tables = new List<PayTable>();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqlGetData = @"select * from HumanResources.PayTable";
                    list_pay_tables = db.Database.SqlQuery<PayTable>(sqlGetData).ToList();
                    ViewBag.list_pay_tables = list_pay_tables;
                }
            }
            catch (Exception e)
            {

            }
        }

        ////////////////////////////LIST/////////////////////////////
        [Route("phong-tcld/quan-ly-cong-viec/danh-sach-cong-viec")]
        [HttpGet]
        public ActionResult List()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = true;

                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                try
                {
                    List<Work_Extend> list_works = new List<Work_Extend>();
                    var sqlList = @"select w.work_id, w.name, w.allowance, pt.pay_table 
                                    from HumanResources.Work w 
                                    left outer join HumanResources.PayTable pt on w.pay_table_id = pt.pay_table_id 
                                    order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                    list_works = db.Database.SqlQuery<Work_Extend>(sqlList).ToList();

                    int totalrows = db.Works.Count();
                    int totalrowsafterfiltering = totalrows;
                    return Json(new { list_works = list_works, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {

                }
                return null;
            }
        }

        ///////////////////////ADD///////////////////////////
        [Route("phong-tcld/quan-ly-cong-viec/them-cong-viec")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                var add_work_name = Request["add_work_name"];
                var add_work_allowance = Request["add_work_allowance"];
                var add_work_pay_table_select = Request["add_work_pay_table_select"];

                if (add_work_name == null || add_work_name == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Tên công việc thể để trống." });
                }
                else if (!((Regex.Match(add_work_allowance, @"(^[0-9]*$)")).Success))
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Phụ cấp chỉ chứa số." });
                }
                else
                {
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {
                        Work cv = db.Works.Where(x => x.name.Equals(add_work_name)).FirstOrDefault();
                        if (cv == null)
                        {
                            cv = new Work();
                            cv.name = add_work_name;
                            cv.pay_table_id = (add_work_pay_table_select == "") ? null : (int?)Convert.ToInt32(add_work_pay_table_select);
                            cv.allowance = (add_work_allowance == "") ? null : add_work_allowance;
                            db.Works.Add(cv);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Thêm thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Đã có tên công việc." });
                        }
                    }
                }
            }
            catch
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        ///////////////////////////////////EDIT///////////////////////////////////
        ////////GET DATA BY WORK ID////////
        [Route("phong-tcld/quan-ly-cong-viec/lay-du-lieu-theo-macongviec")]
        [HttpPost]
        public ActionResult getDataFromWorkByWorkID()
        {
            try
            {
                int work_id = Convert.ToInt32(Request["work_id"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sqlGetData = @"select w.work_id, w.name, w.allowance, w.pay_table_id 
                                        from HumanResources.Work w 
                                        where w.work_id = @work_id";
                    var list_works = db.Database.SqlQuery<Work_Extend>(sqlGetData, new SqlParameter("work_id", work_id)).FirstOrDefault();
                    if (list_works != null)
                    {
                        return Json(new { success = true, list_works = list_works });
                    }
                    else
                    {
                        return Json(new { success = false, title = "Có lỗi", message = "Không tìm thấy dữ liệu về công việc tương ứng." });
                    }

                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        /////////////UPDATE//////////////
        [Route("phong-tcld/quan-ly-cong-viec/cap-nhat-cong-viec")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                int work_id = Convert.ToInt32(Request["work_id"]);
                var work_name = Request["work_name"];
                var pay_table_id = Request["pay_table_id"];
                var allowance = Request["allowance"];

                if (work_name == null || work_name == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Tên công việc không thể để trống." });
                }
                else if (!((Regex.Match(allowance, @"(^[0-9]*$)")).Success))
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Phụ cấp chỉ chứa số." });
                }
                else
                {
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {
                        Work work = db.Works.Where(w => !w.work_id.Equals(work_id) && w.name.Equals(work_name)).FirstOrDefault();
                        if (work == null)
                        {
                            var found_work = db.Works.Find(work_id);
                            found_work.name = work_name;
                            found_work.allowance = (allowance == "") ? null : allowance;
                            found_work.pay_table_id = (pay_table_id == "") ? null : (int?)Convert.ToInt32(pay_table_id);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Cập nhật công việc thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Trùng tên với công việc khác." });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        /////////////////////////////////////////DELETE///////////////////////////////////////////
        [Route("phong-tcld/quan-ly-cong-viec/xoa-cong-viec")]
        [HttpPost]
        public ActionResult deleteWork()
        {
            try
            {
                int work_id = Convert.ToInt32(Request["work_id"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    //access delete by macongviec
                    var sqlDelete = @"delete HumanResources.Work where work_id = @work_id";
                    db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("work_id", work_id));
                    db.SaveChanges();
                    return Json(new { success = true, title = "Thành công", message = "Xóa công việc thành công." });
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Dữ liệu về công việc hiện tại đang còn tồn tại trên các bản ghi khác." });
            }
        }
    }
}
