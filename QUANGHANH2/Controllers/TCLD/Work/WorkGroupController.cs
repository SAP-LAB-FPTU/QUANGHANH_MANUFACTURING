using QUANGHANH2.EntityResult;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class GroupOccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-nhom-cong-viec")]
        public ActionResult view()
        {
            getDataFromWorkGroupType();
            return View("/Views/TCLD/Work/WorkGroup.cshtml");
        }

        //GET DATA FROM WorkGroupType TABLE
        public void getDataFromWorkGroupType()
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    List<WorkGroupType> workGroupTypes = db.WorkGroupTypes.ToList();
                    ViewBag.workGroupTypes = workGroupTypes;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ////////////////////////////////LIST////////////////////////////////////
        [Route("phong-tcld/quan-ly-nhom-cong-viec/danh-sach-nhom-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                try
                {
                    //search data
                    string search_work_group_name = Request["search_work_group_name"];
                    string search_work_group_acronym = Request["search_work_group_acronym"];
                    string search_work_group_type = Request["search_work_group_type"];

                    //get data's table to paging
                    int start = Convert.ToInt32(Request["start"]);
                    int length = Convert.ToInt32(Request["length"]);
                    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                    string sortDirection = Request["order[0][dir]"];

                    List<GetDataWorkGroups_Result> workGroups = db.Database.SqlQuery<GetDataWorkGroups_Result>(@"HumanResources.GetDataWorkGroups {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                        "", search_work_group_name, search_work_group_acronym, search_work_group_type, sortColumnName, sortDirection, start, length, "DataTable").ToList();

                    int totalrows = db.WorkGroups.Count();
                    int totalrowsafterfiltering = totalrows;

                    return Json(new { workGroups = workGroups, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                } catch (Exception e)
                {
                    throw e;
                }
            }
        }

        //ADD
        [Route("phong-tcld/quan-ly-nhom-cong-viec/them-nhom-cong-viec")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                var work_group_name = Request["work_group_name"];
                var work_group_acronym = Request["work_group_acronym"];
                var work_group_type_id = Request["work_group_type_id"];

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    if (work_group_name.Equals("") || work_group_acronym.Equals(""))
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Tên nhóm công việc hoặc tên viết tắt không được để trống." });
                    }
                    else
                    {
                        var sqlCheck_Dupicate = @"select * 
                                            from HumanResources.WorkGroup 
                                            where name = @work_group_name";
                        var check_duplicate_object = db.Database.SqlQuery<WorkGroup>(sqlCheck_Dupicate, new SqlParameter("work_group_name", work_group_name)).FirstOrDefault();

                        if (check_duplicate_object == null)
                        {
                            WorkGroup workGroup = new WorkGroup();
                            workGroup.name = work_group_name;
                            workGroup.acronym = work_group_acronym;
                            workGroup.work_group_type_id = (work_group_type_id == "") ? (int?)null : Convert.ToInt32(work_group_type_id);
                            db.WorkGroups.Add(workGroup);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Thêm nhóm công viêc thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Tên nhóm công việc đã tồn tại." });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        //GET DATA FROM WorkGroup BY work_group_id
        [Route("phong-tcld/quan-ly-nhom-cong-viec/lay-du-lieu-theo-manhomcongviec")]
        [HttpPost]
        public ActionResult getData()
        {
            try
            {
                var work_group_id = Request["work_group_id"];
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    GetDataWorkGroups_Result workGroup = db.Database.SqlQuery<GetDataWorkGroups_Result>(@"HumanResources.GetDataWorkGroups {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                    work_group_id, "", "", "", "", "", "", "", "Not DataTable").FirstOrDefault();

                    return Json(new { success = true, workGroup = workGroup });
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        //UPDATE
        [Route("phong-tcld/quan-ly-nhom-cong-viec/cap-nhat-nhomcongviec")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                int work_group_id = Convert.ToInt32(Request["work_group_id"]);
                var work_group_name = Request["work_group_name"];
                var work_group_acronym = Request["work_group_acronym"];
                var work_group_type_id = Request["work_group_type_id"];

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    if (work_group_name.Equals("") || work_group_acronym.Equals(""))
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Tên nhóm công việc hoặc tên viết tắt không được để trống." });
                    }
                    else
                    {
                        WorkGroup check_workGroup = db.WorkGroups.Where(x => !(x.work_group_id == work_group_id) && (x.name.Equals(work_group_name) || x.acronym.Equals(work_group_acronym))).FirstOrDefault();
                        if (check_workGroup == null)
                        {
                            var workGroup = db.WorkGroups.Find(work_group_id);
                            workGroup.name = work_group_name;
                            workGroup.acronym = work_group_acronym;
                            workGroup.work_group_type_id = (work_group_type_id == "") ? null : (int?)Convert.ToInt32(work_group_type_id);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Cập nhật nhóm công việc thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Tên nhóm công viêc hoặc Loại nhóm công việc đã có." });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        //DELETE
        [Route("phong-tcld/quan-ly-nhom-cong-viec/xoa-nhomcongviec")]
        [HttpPost]
        public ActionResult delete()
        {
            try
            {
                int work_group_id = Convert.ToInt32(Request["work_group_id"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    WorkGroup workGroup = db.WorkGroups.Find(work_group_id);
                    db.WorkGroups.Remove(workGroup);
                    db.SaveChanges();
                    return Json(new { success = true, title = "Thành công", message = "Xóa nhóm công việc thành công." });
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Dữ liệu về nhóm công việc hiện tại đang còn tồn tại ở các bản ghi khác." });
            }
        }

        ////CHECK EXIST DATA RELATED TO OTHER TABLE
        //public Boolean check_Exist_Data(int manhomcongviec)
        //{
        //    bool flag = false;
        //    try
        //    {
        //        using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
        //        {
        //            var sqlCheck = @"select a.MaNhomCongViec from NhomCongViec a right outer join CongViec_NhomCongViec b on a.MaNhomCongViec = b.MaNhomCongViec
        //                        where a.MaNhomCongViec = @manhomcongviec";
        //            var exSql = db.Database.SqlQuery<int>(sqlCheck, new SqlParameter("manhomcongviec", manhomcongviec)).Count();
        //            flag = (exSql == 0) ? true : false;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return flag;
        //}
    }
}