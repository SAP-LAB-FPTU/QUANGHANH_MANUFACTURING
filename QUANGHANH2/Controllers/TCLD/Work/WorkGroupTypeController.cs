using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class WorkGroupTypeController : Controller
    {
        [Route("phong-tcld/quan-ly-loai-cong-viec")]
        public ActionResult index()
        {
            return View("/Views/TCLD/Work/WorkGroupType.cshtml");
        }

        //////////////////////////////LIST///////////////////////////////
        [Route("phong-tcld/quan-ly-loai-cong-viec/danh-sach-loai-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                try
                {
                    //search
                    string search_work_group_type_name = Request["search_work_group_type_name"];

                    //get data's table to paging
                    int start = Convert.ToInt32(Request["start"]);
                    int length = Convert.ToInt32(Request["length"]);
                    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                    string sortDirection = Request["order[0][dir]"];

                    List<WorkGroupType> workGroupTypes = db.Database.SqlQuery<WorkGroupType>("HumanResources.GetDataWorkGroupTypes {0}, {1}, {2}, {3}, {4}, {5}, {6}",
                        "", search_work_group_type_name, sortColumnName, sortDirection, start, length, "DataTable").ToList();

                    int totalrows = db.WorkGroupTypes.Count();
                    int totalrowsafterfiltering = totalrows;
                    return Json(new { workGroupTypes = workGroupTypes, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        //////////////////////////////ADD////////////////////////////////
        [Route("phong-tcld/quan-ly-loai-cong-viec/them-loai-cong-viec")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                var add_work_group_type_name = Request["add_work_group_type_name"];
                if (add_work_group_type_name == null || add_work_group_type_name == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Tên diện công việc không thể để trống." });
                }
                else
                {
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {
                        WorkGroupType workGroupType = db.WorkGroupTypes.Where(x => x.name.Equals(add_work_group_type_name)).FirstOrDefault();
                        if (workGroupType == null)
                        {
                            workGroupType = new WorkGroupType();
                            workGroupType.name = add_work_group_type_name;
                            db.WorkGroupTypes.Add(workGroupType);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Thêm loại công việc mới thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Đã có tên diện công việc." });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        ///////////////////////////////GET WorkGroupType BY work_group_type_id/////////////////////////////////
        [Route("phong-tcld/quan-ly-loai-cong-viec/lay-tenloaicongviec-theo-maloaicongviec")]
        [HttpPost]
        public ActionResult getData()
        {
            try
            {
                int work_group_type_id = Convert.ToInt32(Request["work_group_type_id"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    WorkGroupType workGroupType = db.Database.SqlQuery<WorkGroupType>("HumanResources.GetDataWorkGroupTypes {0}, {1}, {2}, {3}, {4}, {5}, {6}",
                        work_group_type_id, "", "", "", "", "", "Not DataTable").FirstOrDefault();
                    return Json(new { success = true, workGroupType = workGroupType });
                };
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        /////////////////////////////////////////////UPDATE///////////////////////////////////////////////
        [Route("phong-tcld/quan-ly-loai-cong-viec/cap-nhat-tenloaicongviec")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                int work_group_type_id = Convert.ToInt32(Request["work_group_type_id"]);
                string work_group_type_name = Request["work_group_type_name"];
                if (work_group_type_name == null || work_group_type_name == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Tên diện công việc không thể để trống." });
                }
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    WorkGroupType workGroupType = db.WorkGroupTypes.Find(work_group_type_id);
                    if (workGroupType == null)
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
                    }
                    else
                    {
                        workGroupType.name = work_group_type_name;
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Cập nhật thành công." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi",message = "Có lỗi xảy ra." });
            }
        }

        //////////////////////////////////DELETE/////////////////////////////////////////
        [Route("phong-tcld/quan-ly-loai-cong-viec/xoa-loaicongviec")]
        [HttpPost]
        public ActionResult delete()
        {
            try
            {
                int work_group_type_id = Convert.ToInt32(Request["work_group_type_id"]);
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    WorkGroupType workGroupType = db.WorkGroupTypes.Find(work_group_type_id);
                    if (workGroupType == null)
                    {
                        return Json(new { error = true, title = "Có lỗi", message = "Không tìm thấy loại công việc tương ứng." });
                    }
                    else
                    {
                        try
                        {
                            db.WorkGroupTypes.Remove(workGroupType);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Xóa thành công." });
                        } catch (Exception e)
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Dữ liệu về loại công việc đã được sử dụng nên không thể xóa." });
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi",message = "Có lỗi xảy ra." });
            }
        }
    }
}