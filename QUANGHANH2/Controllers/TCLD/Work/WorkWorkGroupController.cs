using QUANGHANH2.EntityResult;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class WorkWorkGroupController : Controller
    {
        // GET: WorkWorkGroup
        [Route("phong-tcld/cong-viec-nhom-cong-viec")]
        public ActionResult Index()
        {
            getDataWorks();
            getDataWorkGroups();
            return View("/Views/TCLD/Work/WorkWorkGroup.cshtml");
        }

        /////////////////////////////GET DATA FROM Work/////////////////////////////
        public void getDataWorks()
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    List<Work> works = db.Works.ToList();
                    ViewBag.works = works;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //////////////////////////////////GET DATA FROM WorkGroup////////////////////////
        public void getDataWorkGroups()
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    List<WorkGroup> workGroups = db.WorkGroups.ToList();
                    ViewBag.workGroups = workGroups;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ////////////////////////////////////LIST////////////////////////////////////////
        [Route("phong-tcld/cong-viec-nhom-cong-viec/danh-sach-cong-viec-nhom-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    //search data
                    string search_work_name = Request["search_work_name"];
                    string search_work_group_name = Request["search_work_group_name"];

                    //get data's table to paging
                    int start = Convert.ToInt32(Request["start"]);
                    int length = Convert.ToInt32(Request["length"]);
                    string searchValue = Request["search[value]"];
                    string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                    string sortDirection = Request["order[0][dir]"];

                    List<GetDataWorkWorkGroups_Result> workWorkGroups = db.Database.SqlQuery<GetDataWorkWorkGroups_Result>("HumanResources.GetDataWorkWorkGroups {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                        "", search_work_name, search_work_group_name, sortColumnName, sortDirection, start, length, "DataTable").ToList();

                    int totalrows = db.WorkWorkGroups.Count();
                    int totalrowsafterfiltering = totalrows;

                    return Json(new { workWorkGroups = workWorkGroups, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { title = "Có lỗi", message = "Đã có lỗi xảy ra." });
            }
        }

        //////////////////////////////////////ADD///////////////////////////////////////
        [Route("phong-tcld/cong-viec-nhom-cong-viec/them-cong-viec-nhom-cong-viec")]
        [HttpPost]
        public ActionResult add()
        {
            try
            {
                string work_id_param = Request["work_id"];
                string work_group_id_param = Request["work_group_id"];

                if (work_id_param == "" || work_group_id_param == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Công việc hoặc nhóm công việc không thể đồng thời để trống." });
                }
                else
                {
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {
                        //parse to int
                        int work_id = Convert.ToInt32(work_id_param);
                        int work_group_id = Convert.ToInt32(work_group_id_param);

                        WorkWorkGroup workWorkGroups = db.WorkWorkGroups.Where(x => x.work_id.Equals(work_id) && x.work_group_id.Equals(work_group_id)).FirstOrDefault();
                        if (workWorkGroups == null)
                        {
                            workWorkGroups = new WorkWorkGroup();
                            workWorkGroups.work_id = work_id;
                            workWorkGroups.work_group_id = work_group_id;
                            db.WorkWorkGroups.Add(workWorkGroups);
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Thêm công viêc - nhóm công việc thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Công việc ứng với Nhóm công việc chọn đã tồn tại." });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        /////////////////////////////////////////////////EDIT//////////////////////////////////////////////////
        /////////GET DATA WorkWorkGroup
        [Route("phong-tcld/cong-viec-nhom-cong-viec/lay-du-lieu-theo-macongviec-nhomcongviec")]
        [HttpPost]
        public ActionResult getDataWorkWorkType()
        {
            try
            {
                string work_work_group_id_param = Request["work_work_group_id"];

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    if (work_work_group_id_param == "")
                    {
                        return Json(new { title = "Có lỗi", message = "Không tìm thấy dữ liệu về công việc - nhóm công việc." });
                    }
                    else
                    {
                        int work_work_group_id = Convert.ToInt32(work_work_group_id_param);
                        GetDataWorkWorkGroups_Result workWorkGroups = db.Database.SqlQuery<GetDataWorkWorkGroups_Result>("HumanResources.GetDataWorkWorkGroups {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                            work_work_group_id, "", "", "", "", "", "", "Not DataTable").FirstOrDefault();
                        return Json(new { workWorkGroups = workWorkGroups });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { title = "Có lỗi", message = "Cõ lỗi xảy ra." });
            }
        }

        ////////////UPDATE
        [Route("phong-tcld/cong-viec-nhom-cong-viec/cap-nhat-cong-viec-nhom-cong-viec")]
        [HttpPost]
        public ActionResult update()
        {
            try
            {
                var work_work_group_id_param = Request["work_work_group_id"];
                var work_id_param = Request["work_id"];
                var work_group_id_param = Request["work_group_id"];

                if (work_id_param == "" || work_group_id_param == "")
                {
                    return Json(new { error = true, title = "Có lỗi", message = "Công việc hoặc nhóm công việc không thể đồng thời để trống." });
                }
                else
                {
                    using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                    {
                        int work_work_group_id = Convert.ToInt32(work_work_group_id_param);
                        int new_work_id = Convert.ToInt32(work_id_param);
                        int new_work_group_id = Convert.ToInt32(work_group_id_param);

                        WorkWorkGroup workWorkGroup = db.WorkWorkGroups.Find(work_work_group_id);
                        if (workWorkGroup != null)
                        {
                            workWorkGroup.work_id = new_work_id;
                            workWorkGroup.work_group_id = new_work_group_id;
                            db.SaveChanges();
                            return Json(new { success = true, title = "Thành công", message = "Cập nhật công việc - nhóm công việc thành công." });
                        }
                        else
                        {
                            return Json(new { error = true, title = "Có lỗi", message = "Không tìm thấy công việc - nhóm công việc tương ứng." });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }

        /////////////////////////////////////////////////DELETE/////////////////////////////////////////////////////
        [Route("phong-tcld/cong-viec-nhom-cong-viec/xoa-cong-viec-nhom-cong-viec")]
        [HttpPost]
        public ActionResult delete()
        {
            try
            {
                string work_work_group_id_param = Request["work_work_group_id"];

                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    int work_work_group_id = Convert.ToInt32(work_work_group_id_param);
                    try
                    {
                        WorkWorkGroup workWorkGroup = db.WorkWorkGroups.Find(work_work_group_id);
                        db.WorkWorkGroups.Remove(workWorkGroup);
                        db.SaveChanges();
                        return Json(new { success = true, title = "Thành công", message = "Xóa công việc - nhóm công việc thành công." });
                    } catch (Exception e)
                    {
                        return Json(new { success = false, title = "Có lỗi", message = "Dữ liệu công việc - nhóm công việc đang được sử dụng." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { error = true, title = "Có lỗi", message = "Có lỗi xảy ra." });
            }
        }
    }
}