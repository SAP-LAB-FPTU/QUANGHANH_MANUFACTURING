using QUANGHANH2.Models;
using QUANGHANH2.Models.HumanResources;
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
                List<WorkGroupType> workGroupTypes = new List<WorkGroupType>();
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    var sql_work_group_types = @"select * from HumanResources.WorkGroupType";
                    workGroupTypes = db.Database.SqlQuery<WorkGroupType>(sql_work_group_types).ToList<WorkGroupType>();
                    ViewBag.workGroupTypes = workGroupTypes;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        ////////////////////////////////LIST////////////////////////////////////
        [Route("phong-tcld/quan-ly-nhom-cong-viec/danh-sach-nhom-cong-viec")]
        [HttpGet]
        public ActionResult list()
        {

            List<WorkGroup_Extend> workGroups = new List<WorkGroup_Extend>();
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                //get data's table to paging
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];

                var sqlList = @"select wg.*, wgt.name 'work_group_type_name'
                                from HumanResources.WorkGroup wg
                                left outer join HumanResources.WorkGroupType wgt on wg.work_group_type_id = wgt.work_group_type_id 
                                order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY";
                workGroups = db.Database.SqlQuery<WorkGroup_Extend>(sqlList).ToList();

                int totalrows = db.WorkGroups.Count();
                int totalrowsafterfiltering = totalrows;


                return Json(new { workGroups = workGroups, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
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
                    var sqlGetData = @"select wg.*, wgt.name 'work_group_type_name'
                                from HumanResources.WorkGroup wg
                                left outer join HumanResources.WorkGroupType wgt on wg.work_group_type_id = wgt.work_group_type_id where wg.work_group_id = @work_group_id";
                    var workGroup = db.Database.SqlQuery<WorkGroup_Extend>(sqlGetData, new SqlParameter("work_group_id", work_group_id)).FirstOrDefault();
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
                    var sqlDelete = @"delete HumanResources.WorkGroup where work_group_id = @work_group_id";
                    db.Database.ExecuteSqlCommand(sqlDelete, new SqlParameter("work_group_id", work_group_id));
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